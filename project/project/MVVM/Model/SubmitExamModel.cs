using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.MVVM.Model
{
    public class SubmitExamModel
    {
        public int userId { get; set; }
        public int examId { get; set; }
        public string Grade { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
