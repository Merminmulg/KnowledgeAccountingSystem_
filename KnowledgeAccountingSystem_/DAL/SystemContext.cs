using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using KnowledgeAccountingSystem_.Models;

namespace KnowledgeAccountingSystem_.DAL
{
    public class SystemContext : DbContext
    {
        public SystemContext() : base("SystemContext")
        {

        }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<QuestionEntity> Questions { get; set; }
        public DbSet<QuestionAnswerEntity> QuestionAnswers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}