using project.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.MVVM.ViewModel
{
    class StudentExamViewModel : ObservableObject
    {
        private bool _isrbChoiceAChecked;
        public bool IsrbChoiceAChecked
        {
            get { return _isrbChoiceAChecked; }
            set
            {
                _isrbChoiceAChecked = value;
                OnPropertyChanged(nameof(IsrbChoiceAChecked));
            }
        }
        private bool _isrbChoiceBChecked;
        public bool IsrbChoiceBChecked
        {
            get { return _isrbChoiceBChecked; }
            set
            {
                _isrbChoiceBChecked = value;
                OnPropertyChanged(nameof(IsrbChoiceBChecked));
            }
        }
        private bool _isrbChoiceCChecked;
        public bool IsrbChoiceCChecked
        {
            get { return _isrbChoiceCChecked; }
            set
            {
                _isrbChoiceCChecked = value;
                OnPropertyChanged(nameof(IsrbChoiceCChecked));
            }
        }
        private bool _isrbChoiceDChecked;
        public bool IsrbChoiceDChecked
        {
            get { return _isrbChoiceDChecked; }
            set
            {
                _isrbChoiceDChecked = value;
                OnPropertyChanged(nameof(IsrbChoiceDChecked));
            }
        }
    }
}
