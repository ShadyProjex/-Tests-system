using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.MVVM.Model
{
    public class Exam
    {
        public int examId { get; set; }
        public string examName { get; set; }
        public DateTime startDate { get; set; }
        public string teacherName { get; set; }
        public int overallTimeInMinutes { get; set; }
        public bool isRandomize { get; set; }
        public string questionsJson { get; set; }
    }

    public class Question
    {
        public string id { get; set; }
        public string name { get; set; }
        public string correctAnswer { get; set; }
        public string questionText { get; set; }
        public string[] answers { get; set; }

        public Question(string name,string txt, string correctAnswer,string answer1, string answer2, string answer3)
        {
            this.name = name;
            this.questionText = txt;
            this.correctAnswer = correctAnswer;
            this.id = Guid.NewGuid().ToString();
            this.answers= new string[4];
            this.answers[0]=correctAnswer;
            this.answers[1] = answer1;
            this.answers[2] = answer2;
            this.answers[3] = answer3;
        }
        public Question() : this("","", "","","","")
        {

        }
        public override string ToString()
        {
            return this.name;
        }
    }

}
