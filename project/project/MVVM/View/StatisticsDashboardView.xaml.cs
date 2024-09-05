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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace project.MVVM.View
{
    /// <summary>
    /// Interaction logic for StatisticsDashboardView.xaml
    /// </summary>
    public partial class StatisticsDashboardView : UserControl
    {
        public string OverallAvgNum
        {
            get { return Overall_avg_num.Content.ToString(); }
            set { Overall_avg_num.Content = value; }
        }
        public string StudentsPassedNum
        {
            get { return Students_passed_num.Content.ToString(); }
            set { Students_passed_num.Content = value; }
        }
        public string StudentsAttendedNum
        {
            get { return Students_attended_num.Content.ToString(); }
            set { Students_attended_num.Content = value; }
        }
        public StatisticsDashboardView()
        {
            InitializeComponent();
            this.DataContext = new StatisticsDashboardViewModel();
        }
    }
}
