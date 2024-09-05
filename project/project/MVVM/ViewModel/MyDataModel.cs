using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.MVVM.ViewModel
{
    class MyDataModel : INotifyPropertyChanged
    {
    private string _durationTextValue;
    private string _examNameTextValue;
    private string _teacherNameTextValue;
        public MyDataModel(string examValue,string teacherValue, string durationValue)
        {
            _examNameTextValue = examValue;
            _teacherNameTextValue = teacherValue;
            _durationTextValue = durationValue;
        }
        public string DurationTextValue
        {
            get { return _durationTextValue; }
            set
            {
                if (_durationTextValue != value)
                {
                    _durationTextValue = value;
                    OnPropertyChanged(nameof(DurationTextValue));
                }
            }
        }
        public string ExamNameTextValue
        {
            get { return _examNameTextValue; }
            set
            {
                if (_examNameTextValue != value)
                {
                    _examNameTextValue = value;
                    OnPropertyChanged(nameof(ExamNameTextValue));
                }
            }
        }
        public string TeacherNameTextValue
        {
            get { return _teacherNameTextValue; }
            set
            {
                if (_teacherNameTextValue != value)
                {
                    _teacherNameTextValue = value;
                    OnPropertyChanged(nameof(TeacherNameTextValue));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
