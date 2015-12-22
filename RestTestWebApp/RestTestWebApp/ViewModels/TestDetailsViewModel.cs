using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestTestWebApp.ViewModels
{
    public class TestDetailsViewModel : TestBaseItem
    {
        public string AuthToken { get; set; }

        [Required]
        public string Desctiption { get; set; }

        public List<int> QuestionIds { get; set; }

        public List<SelectListItem> SelectedQuestions { get; set; }

        public List<SelectListItem> AvailableQuiestions { get; set; }
    }
}