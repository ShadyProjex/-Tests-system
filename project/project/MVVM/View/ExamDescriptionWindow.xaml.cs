using Newtonsoft.Json;
using project.Helpers;
using project.MVVM.Model;
using project.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace project.MVVM.View
{
    /// <summary>
    /// Interaction logic for ExamDescriptionWindow.xaml
    /// </summary>
    public partial class ExamDescriptionWindow : Window
    {
        private readonly string _questionsJosn;
        private MyDataModel _myData;
        public ExamDescriptionWindow(string QuestionsJson)
        {
            InitializeComponent();
            _questionsJosn = QuestionsJson;
            if (UserStoredData.updateMode)
            {
                _myData = new MyDataModel(UserStoredData.searchedExam.examName, UserStoredData.searchedExam.teacherName, UserStoredData.searchedExam.overallTimeInMinutes.ToString());
                this.DataContext = _myData;
                DateTimepicker.Value = UserStoredData.searchedExam.startDate;
                if(UserStoredData.searchedExam.isRandomize)
                    isYesButton.IsChecked= true;
                else
                    isNoButton.IsChecked= true;
            }
            else
            {
                _myData = new MyDataModel("", "", "");
                this.DataContext = _myData;
            }
        }

        private void back_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        private async void apply_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(!int.TryParse(_myData.DurationTextValue, out int _duration))
            {
                _duration = 80;
            }
            if(!DateTimepicker.Value.HasValue)
            {
                return;
            }
            
            if(UserStoredData.updateMode)
            {
                Exam exam = new Exam()
                {
                    examId = UserStoredData.searchedExam.examId,
                    questionsJson = _questionsJosn,
                    teacherName = _myData.TeacherNameTextValue,
                    overallTimeInMinutes = _duration,
                    examName = _myData.ExamNameTextValue,
                    isRandomize = isYesButton.IsChecked.HasValue ? isYesButton.IsChecked.Value : false,
                    startDate = (DateTime)DateTimepicker.Value
                };
                string serializedModel = JsonConvert.SerializeObject(exam);
                var response = await HttpClientService.UpdateExam(serializedModel, UserStoredData.searchedExam.examId);
            }
            else
            {
                Exam exam = new Exam()
                {
                    questionsJson = _questionsJosn,
                    teacherName = _myData.TeacherNameTextValue,
                    overallTimeInMinutes = _duration,
                    examName = _myData.ExamNameTextValue,
                    isRandomize = isYesButton.IsChecked.HasValue ? isYesButton.IsChecked.Value : false,
                    startDate = (DateTime)DateTimepicker.Value
                };
                string serializedModel = JsonConvert.SerializeObject(exam);
                var response = await HttpClientService.CreateExam(serializedModel);
            }
            
            this.Close();
        }
    }
}
