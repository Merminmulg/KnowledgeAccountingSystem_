using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using KnowledgeAccountingSystem_.Models;

namespace KnowledgeAccountingSystem_.DAL
{
    public class KaSInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SystemContext>
    {
        protected override void Seed(SystemContext context)
        {
            var Users = new List<UserEntity>
            {
                new UserEntity{Login = "MeRminM", Admin = true, Password = "380686142035", UserID = 1, Manager = false},
                new UserEntity{Login = "MeRminM1", Admin = true, Password = "380686142035", UserID = 2, Manager = false},
                new UserEntity{Login = "MeRminM2", Admin = true, Password = "380686142035", UserID = 3, Manager = false},
                new UserEntity{Login = "MeRminM3", Admin = false, Password = "380686142035", UserID = 4, Manager = false },
                new UserEntity{Login = "MeRminM4", Admin = false, Password = "380686142035", UserID = 5, Manager = false },
                new UserEntity{Login = "MeRminM5", Admin = false, Password = "380686142035", UserID = 6, Manager = true},
            };

            var Tasks = new List<TaskEntity>
            { new TaskEntity {TaskID = 1, Title = "Test task",
                Discription = "Test task for testing creating DB and view output", MaxScore = 1}, };

            var Questions = new List<QuestionEntity>
            {
                new QuestionEntity{QuestionID = 1, Title = "Do you like coding?", TaskID = 1, RightAnswer = 1},
                new QuestionEntity{QuestionID = 2, Title = "Find wrong data type", TaskID = 1, RightAnswer = 0},
                new QuestionEntity{QuestionID = 3, Title = "OOP is ", TaskID = 1, RightAnswer = 2},
            };
            var QuestionAnswers = new List<QuestionAnswerEntity>
            {
                new QuestionAnswerEntity{QuestionID = 1, AnswerID = 1, Title = "No"},
                new QuestionAnswerEntity{QuestionID = 1, AnswerID = 2, Title = "Yes"},
                new QuestionAnswerEntity{QuestionID = 2, AnswerID = 3, Title = "Stroke"},
                new QuestionAnswerEntity{QuestionID = 2, AnswerID = 4, Title = "String"},
                new QuestionAnswerEntity{QuestionID = 2, AnswerID = 5, Title = "Char"},
                new QuestionAnswerEntity{QuestionID = 3, AnswerID = 6, Title = "Open ost protocol"},
                new QuestionAnswerEntity{QuestionID = 3, AnswerID = 7, Title = "Opbjective onko praticise"},
                new QuestionAnswerEntity{QuestionID = 3, AnswerID = 8, Title = "Objective oriented programming"},
            };
            Users.ForEach(u => context.Users.Add(u));
            Tasks.ForEach(t => context.Tasks.Add(t));
            Questions.ForEach(q => context.Questions.Add(q));
            QuestionAnswers.ForEach(qa => context.QuestionAnswers.Add(qa));

            context.SaveChanges();
        }

    }
}