using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using WebApiServer.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public ExamsController(ApplicationDBContext dbContext) 
        {
            _dbContext = dbContext;
        }
        // GET: api/<ExamsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exam>>> Get()
        {
            return _dbContext.Exams;
        }

        // GET api/<ExamsController>/test
        [HttpGet("{name}")]
        public async Task<ActionResult<Exam>> Get(string name)
        {
            if(_dbContext.Exams != null && !string.IsNullOrWhiteSpace(name))
            {
                Exam? exam = await _dbContext.Exams.Where(e => e.examName == name).FirstOrDefaultAsync();
                return Ok(exam);
            }
            return BadRequest();
        }

        // GET api/<ExamsController>/statistics/{examName}
        [HttpGet("statistics/{examName}")]
        public async Task<ActionResult<List<ExamStatistics>>> GetStatistics(string examName)
        {
            if (_dbContext.Exams != null && _dbContext.UsersExams != null && !string.IsNullOrWhiteSpace(examName))
            {
                Exam? exam = await _dbContext.Exams.Where(e => e.examName == examName).FirstOrDefaultAsync();
                if(exam == null)
                {
                    return NotFound();
                }
                List<ExamStatistics> students = (from eu in _dbContext.UsersExams
                                                 join us in _dbContext.Users on eu.userId equals us.Id
                                                 join ex in _dbContext.Exams on eu.examId equals ex.examId
                                                 where ex.examId == exam.examId
                                                 select new ExamStatistics()
                                                 {
                                                     ID = us.identification,
                                                     Name = us.userName,
                                                     Grade = eu.grade,
                                                     StartTime = eu.StartTime,
                                                     EndTime = eu.EndTime
                                                 }).ToList();
                return Ok(students);
            }
            return BadRequest();
        }

        // POST api/<ExamsController>/SubmitExam
        [HttpPost("SubmitExam")]
        public async Task<ActionResult> SubmitExam([FromBody] SubmitExamModel submitModel)
        {
            try
            {
                UserExam ue = new UserExam();
                ue.StartTime = submitModel.StartTime;
                ue.EndTime = submitModel.EndTime;
                ue.grade = submitModel.Grade;
                ue.userId = submitModel.userId;
                ue.examId = submitModel.examId;
                await _dbContext.UsersExams.AddAsync(ue);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
            return Ok();
        }

        // POST api/<ExamsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Exam exam)
        {
            try {
                await _dbContext.Exams.AddAsync(exam);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
            return Ok();
        }

        // PUT api/<ExamsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Exam exam)
        {
            if(id != exam.examId)
            {
                return BadRequest();
            }

            if (_dbContext.Exams != null && id > 0)
            {
                Exam? dbExam = await _dbContext.Exams.Where(e => e.examId == id).FirstOrDefaultAsync();
                if (dbExam != null)
                {
                    try
                    {
                        dbExam.startDate = exam.startDate;
                        dbExam.overallTimeInMinutes = exam.overallTimeInMinutes;
                        dbExam.teacherName = exam.teacherName;
                        dbExam.examName = exam.examName;
                        dbExam.isRandomize = exam.isRandomize;
                        dbExam.questionsJson = exam.questionsJson;
                        _dbContext.Entry(dbExam).State = EntityState.Modified;
                        await _dbContext.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return BadRequest();
                    }
                }
            }
            return Ok(exam);
        }
    }
}
