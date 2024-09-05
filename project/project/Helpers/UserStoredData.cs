using project.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Helpers
{
    public static class UserStoredData
    {
        public static int Id { get; set; } = 0;
        public static string userName { get; set; } = null;
        public static string userType { get; set; } = null;
        public static Exam searchedExam { get; set; } = null;
        public static bool updateMode { get; set; } = false;
        public static List<ExamStatistics> searchedStatistics { get; internal set; }
    }
}
