using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.MVVM.Model
{
    class QuestionsRepository : IQuestionsRepository
    {
        private List<Question> _questions;
    public QuestionsRepository()
    {
        _questions = new List<Question>();
    }

    public Question[] Questions
    {
        get { return _questions.ToArray(); }

    }

    public void AddQuestion(Question question)
    {
        this._questions.Add(question);
    }

    public void UpdateQuestion(Question question)
    {
        int indexFound = this._questions.FindIndex(q => q.id == question.id);
        if (indexFound >= 0)
        {
            this._questions[indexFound] = question;

        }


    }

    public void RemoveQuestion(string id)
    {
        int indexFound = this._questions.FindIndex(s => s.id == id);
        if (indexFound >= 0)
        {
            this._questions.RemoveAt(indexFound);
        }
    }

}
}
