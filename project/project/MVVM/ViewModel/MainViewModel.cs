using Newtonsoft.Json;
using project.Core;
using project.Helpers;
using project.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace project.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }

        private string _textValue;

        public string TextValue
        {
            get { return _textValue; }
            set
            {
                if (_textValue != value)
                {
                    _textValue = value;
                    OnPropertyChanged("TextValue");
                }
            }
        }

        private string _searchBoxText;
        public string SearchBoxText
        {
            get { return _searchBoxText; }
            set
            {
                if (_searchBoxText != value)
                {
                    _searchBoxText = value;
                    OnPropertyChanged("SearchBoxText");
                }
            }
        }

        public RelayCommand ExamEditorViewCommand { get; set; }

        public RelayCommand StatisticsDashboardViewCommand { get; set; }

        public RelayCommand StartExamViewCommand { get; set; }

        public RelayCommand updateExamEditorViewCommand { get; set; }

        public RelayCommand TeacherViewCommand { get; set; }

        public RelayCommand StudentViewCommand { get; set; }
        public RelayCommand LoginViewCommand { get; set; }
        public HomeViewModel HomeVm { get; set; }
        public ExamEditorViewModel ExamEditorVm { get; set; }

        public StudentExamViewModel StudentExamVm { get; set; }
        public TeacherViewModel TeacherVm { get; set; }

        public StudentViewModel StudentVm { get; set; }

        public StatisticsDashboardViewModel StatisticsVm { get; set; }
        public LoginViewModel LoginVm { get; set; }
        private object _currentView;
        private Visibility _isTeacherButtonVisiable=Visibility.Collapsed;
        
        public Visibility IsTeacherButtonVisiable


        {
            get { return _isTeacherButtonVisiable; }
            set
            {
                _isTeacherButtonVisiable= value;
                OnPropertyChanged(nameof(IsTeacherButtonVisiable));
            }
        }
        private Visibility _isLoginButtonVisiable = Visibility.Visible;
        public Visibility IsLoginButtonVisiable


        {
            get { return _isLoginButtonVisiable; }
            set
            {
                _isLoginButtonVisiable = value;
                OnPropertyChanged(nameof(IsLoginButtonVisiable));
            }
        }
        public RelayCommand ToggleTeacherButtonCommand { get; set; }
        private Visibility _isStudentButtonVisiable = Visibility.Collapsed;
        public Visibility IsStudentButtonVisiable


        {
            get { return _isStudentButtonVisiable; }
            set
            {
                _isStudentButtonVisiable = value;
                OnPropertyChanged(nameof(IsStudentButtonVisiable));
            }
        }

        public RelayCommand ToggleStudentButtonCommand { get; set; }
        public object CurrentView
        {
            get { return _currentView; }
            set 
            { 
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel() 
        {
            HomeVm= new HomeViewModel();
            TeacherVm= new TeacherViewModel();
            StudentVm= new StudentViewModel();
            ExamEditorVm = new ExamEditorViewModel();
            LoginVm = new LoginViewModel();
            StatisticsVm = new StatisticsDashboardViewModel();
            StudentExamVm= new StudentExamViewModel();
            CurrentView= HomeVm;
            ToggleTeacherButtonCommand = new RelayCommand(o =>
            {
                if (UserStoredData.userType == "teacher")
                    IsTeacherButtonVisiable = Visibility.Visible;
            });

            ToggleStudentButtonCommand = new RelayCommand(o =>
            {
                if (UserStoredData.userType == "student")
                    IsTeacherButtonVisiable = Visibility.Visible;
            });
            HomeViewCommand = new RelayCommand(o => 
            {
                CurrentView= HomeVm;
            });

            TeacherViewCommand = new RelayCommand(o =>
            {
                CurrentView = TeacherVm;
            });

            StudentViewCommand = new RelayCommand(o =>
            {
                CurrentView = StudentVm;
            });

            LoginViewCommand = new RelayCommand(o =>
            {
                CurrentView = LoginVm;
            });

            StatisticsDashboardViewCommand = new RelayCommand(async o =>
            {
                await GetStatistics(SearchBoxText);
                CurrentView = StatisticsVm;
            });
            ExamEditorViewCommand = new RelayCommand(async o =>
            {
                UserStoredData.updateMode = false;
                CurrentView = ExamEditorVm;
            });

            updateExamEditorViewCommand = new RelayCommand(async o =>
            {
                bool res = await SearchButton_Click();
                if (res)   
                { 
                    CurrentView = ExamEditorVm;
                    UserStoredData.updateMode= true;
                }
            });

            StartExamViewCommand = new RelayCommand(async o =>
            {
                
                bool res = await SearchButton_Click();
                if (res)
                {
                    int result = DateTime.Compare(UserStoredData.searchedExam.startDate, DateTime.Now);
                    if(result<0 && UserStoredData.searchedExam.startDate.AddMinutes(-10)<DateTime.Now)
                    {
                        CurrentView = StudentExamVm;
                        UserStoredData.updateMode = false;
                    }
                    else
                    {
                        MessageBox.Show("The actual date of the exam is " + UserStoredData.searchedExam.startDate);
                    }
                }
            });
        }

        private async Task<bool> GetStatistics(string examName)
        {
            var res = await HttpClientService.GetStatistics(examName);
            if (res != null)
            {
                try
                {
                    List<ExamStatistics> statistics = JsonConvert.DeserializeObject<List<ExamStatistics>>(res);
                    if (statistics != null)
                    {
                        UserStoredData.searchedStatistics = statistics;
                        return true;
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return false;
        }

        private async Task<bool> SearchButton_Click()
        {

            var res = await HttpClientService.GetExam(SearchBoxText);
            if (res != null)
            {
                try
                {
                    Exam exam = JsonConvert.DeserializeObject<Exam>(res);
                    if (exam != null)
                    {
                        UserStoredData.searchedExam = exam;
                        return true;
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return false;
        }
    }
}
