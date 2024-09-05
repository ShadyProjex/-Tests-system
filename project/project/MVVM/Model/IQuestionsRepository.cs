using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.MVVM.Model
{
    interface IQuestionsRepository
    {
        void AddQuestion(Question question);
        void UpdateQuestion(Question question);
        void RemoveQuestion(string id);
        Question[] Questions { get; }
    }
}
