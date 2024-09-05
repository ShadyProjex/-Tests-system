using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.MVVM.Model
{
    public class ExamStatistics
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Grade { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public ExamStatistics() { }
        public ExamStatistics(ExamStatistics es)
        {
            this.ID = es.ID;
            this.Name = es.Name;
            this.Grade = es.Grade;
            this.StartTime = es.StartTime;
            this.EndTime = es.EndTime;
        }
    }
}
