using project.MVVM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.MVVM.ViewModel
{
    public class QuestionsEditorViewModel : INotifyPropertyChanged
    {
        private List<Question> _questions;
        public List<Question> Questions {
            get
            {
                return _questions;
            }
            set {
                _questions = value;
                OnPropertyChanged(nameof(Questions));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddQuestion(Question question)
        {
            Questions.Add(question);
        }
        public void UpdateQuestion(Question question) 
        {
            var existingQuestion = Questions.FirstOrDefault(q => q.id == question.id);
            if (existingQuestion != null)
            {
                existingQuestion.questionText = question.questionText;
                existingQuestion.correctAnswer = question.correctAnswer;
                existingQuestion.answers[0] = question.answers[0];
                existingQuestion.answers[1] = question.answers[1];
                existingQuestion.answers[2] = question.answers[2];
                existingQuestion.answers[3] = question.answers[3];
            }
        }
        public void DeleteQuestion(Question question) {
            Questions.Remove(question);

        }
    }
}
