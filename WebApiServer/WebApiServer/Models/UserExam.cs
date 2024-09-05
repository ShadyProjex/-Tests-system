using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiServer.Models
{
    public class UserExam
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int userId { get; set; }
        public int examId { get; set; }
        public string grade { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
