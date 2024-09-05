using project.Helpers;
using project.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace project.MVVM.ViewModel
{
    public class StatisticsDashboardViewModel :  INotifyPropertyChanged
    {
        private string _studentsAttendedNum;

        public string StudentsAttendedNum
        {
            get { return _studentsAttendedNum; }
            set
            {
                _studentsAttendedNum = value;
                OnPropertyChanged(nameof(StudentsAttendedNum));
            }
        }
        private string _studentsPassedNum;

        public string StudentsPassedNum
        {
            get { return _studentsPassedNum; }
            set
            {
                _studentsPassedNum = value;
                OnPropertyChanged(nameof(StudentsPassedNum));
            }
        }
        private string _overallAvgNum;

        public string OverallAvgNum
        {
            get { return _overallAvgNum; }
            set
            {
                _overallAvgNum = value;
                OnPropertyChanged(nameof(OverallAvgNum));
            }
        }

        public ObservableCollection<ExamStatistics> Students { get; set; }
        public StatisticsDashboardViewModel() {
            // Initialize the Students collection with some dynamic data
            Students = new ObservableCollection<ExamStatistics>();
            //add data here!!s
            int totalAvg = 0,passed=0;
            if (UserStoredData.searchedStatistics != null)
            {
                
                foreach (ExamStatistics student in UserStoredData.searchedStatistics) 
                {
                    Students.Add(new ExamStatistics(student));
                    totalAvg += int.Parse(student.Grade);
                    if (int.Parse(student.Grade) * 10 >= 50) passed++;
                }
                OverallAvgNum = (totalAvg / UserStoredData.searchedStatistics.Count).ToString();
                StudentsAttendedNum = UserStoredData.searchedStatistics.Count.ToString();
                StudentsPassedNum = passed.ToString();
            }
            
            


        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
