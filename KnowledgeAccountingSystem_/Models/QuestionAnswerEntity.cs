using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeAccountingSystem_.Models
{
    public class QuestionAnswerEntity
    {
        [Key]
        public int AnswerID { get; set; }
        public string Title { get; set; }
        public int QuestionID { get; set; }

        public QuestionEntity Question { get; set; }
    }
}