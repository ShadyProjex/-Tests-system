using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiServer.Models
{
    public class Exam
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int examId { get; set; }
        public string examName { get; set; }
        public DateTime startDate { get; set; }
        public string teacherName { get; set; }
        public int overallTimeInMinutes { get; set; }
        public bool isRandomize { get; set; }
        public string questionsJson { get; set; }
    }
}
