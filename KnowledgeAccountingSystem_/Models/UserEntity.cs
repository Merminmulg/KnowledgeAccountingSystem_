using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeAccountingSystem_.Models
{
    public class UserEntity
    {
        [Key]
        public int UserID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Admin { get; set; }
        public bool Manager { get; set; }
    }
}