using Microsoft.Win32;
using project.Helpers;
using project.MVVM.Model;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace project.MVVM.View
{
    /// <summary>
    /// Interaction logic for ExamEditorView.xaml
    /// </summary>
    public partial class ExamEditorView : UserControl
    {
        IQuestionsRepository repo;

        public ExamEditorView()
        {
            InitializeComponent();
            this.repo = new QuestionsRepository();
            if (UserStoredData.updateMode)
            {
                if (UserStoredData.searchedExam != null)
                {
                    var questionsJson = UserStoredData.searchedExam.questionsJson;
                    if (questionsJson != null)
                    {
                        try
                        {
                            var questionsList = JsonSerializer.Deserialize<Question[]>(questionsJson);
                            foreach (Question item in questionsList)
                            {
                                repo.AddQuestion(item);
                            }
                            this.listBoxQuestions.ItemsSource = repo.Questions;
                        }
                        catch (Exception ex)
                        {
                            //
                        }
                    }

                }
            }
        }

        private void listBoxQuestions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.listBoxQuestions.SelectedItem is Question q)
            {
                this.questidtxt.Text = q.id;
                this.questiontxt.Text = q.questionText;
                this.correctanswertxt.Text = q.correctAnswer;
                this.answer1txt.Text = q.answers[1];
                this.answer2txt.Text = q.answers[2];
                this.answer3txt.Text = q.answers[3];

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
        int iNoName = 1;
        private void BtnAddQuestion_Click(object sender, RoutedEventArgs e)
        {
            Question q = new Question { name = "Question_" + iNoName };
            this.repo.AddQuestion(q);
            iNoName++;

            this.listBoxQuestions.ItemsSource = this.repo.Questions;
            SetSelectedById(q.id);
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (this.listBoxQuestions.SelectedItem is Question q)
            {
                repo.RemoveQuestion(q.id);
            }
            this.listBoxQuestions.ItemsSource = repo.Questions;
            SetSelectedByIndex(0);
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (this.listBoxQuestions.SelectedItem is Question q)
            {
                q.questionText = questiontxt.Text;
                q.correctAnswer = correctanswertxt.Text;
                q.answers[0] = correctanswertxt.Text;
                q.answers[1] = answer1txt.Text;
                q.answers[2] = answer2txt.Text;
                q.answers[3] = answer3txt.Text;
                this.repo.UpdateQuestion(q);
                this.listBoxQuestions.ItemsSource = repo.Questions;
                this.SetSelectedById(q.id);
            }
        }

        private void saveLocalBtn(object sender, MouseButtonEventArgs e)
        {

            List<Question> questions = repo.Questions.ToList(); ;

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonStudentsString = JsonSerializer.Serialize<List<Question>>(questions, options);

            if (!Directory.Exists("AppData"))
            {
                Directory.CreateDirectory("AppData");
            }

            File.WriteAllText("AppData/exam.json", jsonStudentsString);
        }
        private void loadLocalBtn(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                // The user selected a file, so do something with it
                string fileName = openFileDialog.FileName;
                string jsonText = File.ReadAllText(fileName);
                var questionsList =
               JsonSerializer.Deserialize<Question[]>(jsonText);
                //2)Add Objects to Repo Manager

                foreach (Question item in questionsList)
                {
                    repo.AddQuestion(item);
                }
                //3)Sync GUI LIST
                
                this.listBoxQuestions.ItemsSource = repo.Questions;
            }
        }

        private void deployButton_Click(object sender, RoutedEventArgs e)
        {
            List<Question> questions = repo.Questions.ToList(); ;

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonStudentsString = JsonSerializer.Serialize<List<Question>>(questions, options);
            Window win = new ExamDescriptionWindow(jsonStudentsString);
            win.ShowDialog();
        }
    }
}
