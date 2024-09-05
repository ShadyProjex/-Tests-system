namespace WebApiServer.Models
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
