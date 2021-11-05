using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeAccountingSystem_.Models
{
    public class TaskEntity
    {
        [Key]
        public int TaskID { get; set; }
        public string Title { get; set; }
        public string Discription { get; set; }
        public int MaxScore { get; set; }

        public virtual ICollection<QuestionEntity> Questions { get; set; }
    }
}