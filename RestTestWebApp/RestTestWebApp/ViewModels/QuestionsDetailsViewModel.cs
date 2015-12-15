using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestTestWebApp.ViewModels
{
    public class QuestionsDetailsViewModel : QuestionsListItem
    {
        public List<AnswerViewModel> Answers { get; set; }

        public QuestionsDetailsViewModel()
        {
            Answers = new List<AnswerViewModel>();
        }
    }
}