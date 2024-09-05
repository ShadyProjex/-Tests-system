using project.Helpers;
using project.MVVM.Model;
using project.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace project.MVVM.View
{
    /// <summary>
    /// Interaction logic for StudentExamView.xaml
    /// </summary>
    public partial class StudentExamView : UserControl
    {
        IQuestionsRepository repo;
        private DispatcherTimer _timer;
        private TimeSpan _timeRemaining;
        private StudentExamViewModel vm;
        private List<int> _answersSelected;
       
        public string QuestionText
        {
            get { return (string)GetValue(QuestionTextProperty); }
            set { SetValue(QuestionTextProperty, value); }
        }

        public static readonly DependencyProperty QuestionTextProperty =
            DependencyProperty.Register("QuestionText", typeof(string), typeof(StudentExamView), new PropertyMetadata(string.Empty));



        public StudentExamView()
        {
            InitializeComponent();
            this.repo = new QuestionsRepository();
            vm = new StudentExamViewModel(); // Instantiate view model
            DataContext = vm; // Set view model as the DataContext for the view
            
            if (UserStoredData.searchedExam != null)
            {
                var questionsJson = UserStoredData.searchedExam.questionsJson;

                if (questionsJson != null)
                {
                    try
                    {
                        var questionsList = JsonSerializer.Deserialize<Question[]>(questionsJson);
                        tbExamName.Text = UserStoredData.searchedExam.examName;
                        _timeRemaining = TimeSpan.FromMinutes(UserStoredData.searchedExam.overallTimeInMinutes);
                        _timer = new DispatcherTimer();
                        _timer.Interval = TimeSpan.FromSeconds(1);
                        foreach (Question item in questionsList)
                        {
                            if (UserStoredData.searchedExam.isRandomize) ShuffleAnswers(item.answers);
                            repo.AddQuestion(item);
                        }
                        this.listBoxQuestions.ItemsSource = repo.Questions;
                        _answersSelected = new List< int > (this.listBoxQuestions.Items.Count);
                        for(int i=0;i<this.listBoxQuestions.Items.Count;i++)
                        {
                            _answersSelected.Add(0);
                        }
                        _timer.Tick += Timer_Tick;
                        Loaded += UserControl_Loaded;
                    }
                    catch (Exception ex)
                    {
                        //
                    }
                }
            }
        }

            public void ShuffleAnswers(string[] answers)
            {
                Random random = new Random();

                // Perform Fisher-Yates shuffle
                for (int i = answers.Length - 1; i > 0; i--)
                {
                    int j = random.Next(i + 1);
                    string temp = answers[i];
                    answers[i] = answers[j];
                    answers[j] = temp;
                }
            }
        private void listBoxQuestions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.listBoxQuestions.SelectedItem is Question q)
            {

                this.tbQuestion.Text = q.questionText;
                this.rbChoiceA.Content = q.answers[0];
                
                this.rbChoiceB.Content = q.answers[1];
                
                this.rbChoiceC.Content = q.answers[2];
                
                this.rbChoiceD.Content = q.answers[3];
                
                switch (_answersSelected[this.listBoxQuestions.SelectedIndex])
                {
                    case 0:
                        this.rbChoiceA.IsChecked = false;
                        this.rbChoiceB.IsChecked = false;
                        this.rbChoiceC.IsChecked = false;
                        this.rbChoiceD.IsChecked = false;
                        break;
                    case 1:
                        this.rbChoiceA.IsChecked = true;
                        this.rbChoiceB.IsChecked = false;
                        this.rbChoiceC.IsChecked = false;
                        this.rbChoiceD.IsChecked = false;
                        break;
                    case 2:
                        this.rbChoiceA.IsChecked = false;
                        this.rbChoiceB.IsChecked = true;
                        this.rbChoiceC.IsChecked = false;
                        this.rbChoiceD.IsChecked = false;
                        break;
                    case 3:
                        this.rbChoiceA.IsChecked = false;
                        this.rbChoiceB.IsChecked = false;
                        this.rbChoiceC.IsChecked = true;
                        this.rbChoiceD.IsChecked = false;
                        break;
                    case 4:
                        this.rbChoiceA.IsChecked = false;
                        this.rbChoiceB.IsChecked = false;
                        this.rbChoiceC.IsChecked = false;
                        this.rbChoiceD.IsChecked = true;
                        break;
                }
            }
        }

        private void SetSelectedById(string id)
        {
            for (int i = 0; i < this.listBoxQuestions.Items.Count; i++)
            {

                Question? q = listBoxQuestions.Items[i] as Question;
                if (q != null)
                {
                    if (q.id == id)
                        this.listBoxQuestions.SelectedItem = q;
                }

            }
        }

        private void SetSelectedByIndex(int index)
        {
            if (index >= 0 && index < this.listBoxQuestions.Items.Count)
            {
                this.listBoxQuestions.SelectedIndex = index;
            }
        }

        private void previous_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (vm.IsrbChoiceAChecked) _answersSelected[this.listBoxQuestions.SelectedIndex] = 1;
            if (vm.IsrbChoiceBChecked) _answersSelected[this.listBoxQuestions.SelectedIndex] = 2;
            if (vm.IsrbChoiceCChecked) _answersSelected[this.listBoxQuestions.SelectedIndex] = 3;
            if (vm.IsrbChoiceDChecked) _answersSelected[this.listBoxQuestions.SelectedIndex] = 4;
            if (this.listBoxQuestions.SelectedIndex >= 1)
                this.listBoxQuestions.SelectedIndex--;
            
        }
        private async void next_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (vm.IsrbChoiceAChecked) _answersSelected[this.listBoxQuestions.SelectedIndex] = 1;
            if (vm.IsrbChoiceBChecked) _answersSelected[this.listBoxQuestions.SelectedIndex] = 2;
            if (vm.IsrbChoiceCChecked) _answersSelected[this.listBoxQuestions.SelectedIndex] = 3;
            if (vm.IsrbChoiceDChecked) _answersSelected[this.listBoxQuestions.SelectedIndex] = 4;
            if (this.listBoxQuestions.SelectedIndex < this.listBoxQuestions.Items.Count-1)
                this.listBoxQuestions.SelectedIndex++;
            else
            {
                await SubmitExam();
                rbChoiceA.IsEnabled = false;
                rbChoiceB.IsEnabled = false;
                rbChoiceC.IsEnabled = false;
                rbChoiceD.IsEnabled = false;
                GradeBlock.Text= "Your Final Grade IS : "+ calculateGrade().ToString()+"/"+ _answersSelected.Count;
                _timer.Stop();
            }
        }
        private int calculateGrade()
        {
            int count = 0;
            for (int i = 0; i < _answersSelected.Count; i++)
            {
                Question? q = listBoxQuestions.Items[i] as Question;
                if (_answersSelected[i] == 0)
                    continue;
                if (q.answers[_answersSelected[i] - 1] == q.correctAnswer)
                    count++;
            }
            return count;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _timer.Start();
            UpdateTimerText(_timeRemaining);
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (_timeRemaining > TimeSpan.Zero)
            {
                _timeRemaining = _timeRemaining.Subtract(TimeSpan.FromSeconds(1));
                UpdateTimerText(_timeRemaining);
            }
            else
            {
                rbChoiceA.IsEnabled = false;
                rbChoiceB.IsEnabled = false;
                rbChoiceC.IsEnabled = false;
                rbChoiceD.IsEnabled = false;
                GradeBlock.Text = "Your Final Grade IS : " + calculateGrade().ToString() + "/" + _answersSelected.Count;
                _timer.Stop();
            }
        }

        private async Task<bool> SubmitExam()
        {
            try
            {
                SubmitExamModel sem = new SubmitExamModel()
                {
                    StartTime = DateTime.Now.AddHours(-1),
                    EndTime = DateTime.Now,
                    examId = UserStoredData.searchedExam.examId,
                    Grade = calculateGrade().ToString(),
                    userId = UserStoredData.Id
                };
                string serializedModel = Newtonsoft.Json.JsonConvert.SerializeObject(sem);
                var response = await HttpClientService.SubmitExam(serializedModel);
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        private void UpdateTimerText(TimeSpan time)
        {
            tbTimer.Text = string.Format("{0:00}:{1:00}:{2:00}", (int)time.TotalHours, time.Minutes, time.Seconds);
        }

    }
}
