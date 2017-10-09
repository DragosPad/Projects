using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcTask.Models
{
    public class SampleData : DropCreateDatabaseAlways<TaskEntities>
    {
        protected override void Seed(TaskEntities context)
        {
            

             new List<ListGen>
            {
              new ListGen { Name = "Personal", Description = "Plec la munca", Tasks = new List<Task>()
              {
                 new Task { Name = "task 1", Deadline = new DateTime(1990, 3, 17), Priority = Priority.low},
                 new Task { Name = "task 2", Deadline = new DateTime(1989, 2, 12), Priority = Priority.medium},
                 new Task { Name = "task 3", Deadline = new DateTime(2000, 9, 21), Priority = Priority.high}
              }},
              new ListGen { Name = "Informatica", Description = "proiect MVC 3", Tasks = new List<Task>()
              {
                 new Task { Name = "task 4", Deadline = new DateTime(1989, 6, 27), Priority = Priority.low},
                 new Task { Name = "task 5", Deadline = new DateTime(1980, 8, 13), Priority = Priority.medium},
                 new Task { Name = "task 6", Deadline = new DateTime(2001, 5, 5), Priority = Priority.medium}
              }},
              new ListGen { Name = "Duminica", Description = "Joc tenis", Tasks = new List<Task>()
              {
                new Task { Name = "task 7", Deadline = new DateTime(1989, 6, 22), Priority = Priority.medium},
                 new Task { Name = "task 8", Deadline = new DateTime(1970, 3, 19), Priority = Priority.high},
                 new Task { Name = "task 9", Deadline = new DateTime(2017, 11, 21), Priority = Priority.low}
              }},
              new ListGen { Name = "Facultate", Description = "Examen", Tasks = new List<Task>()
              {
                new Task { Name = "task 10", Deadline = new DateTime(1989, 6, 22), Priority = Priority.medium},
                 new Task { Name = "task 11", Deadline = new DateTime(1988, 2, 12), Priority = Priority.medium},
                 new Task { Name = "task 12", Deadline = new DateTime(2002, 5, 21), Priority = Priority.low}
              }}
            }.ForEach(a => context.ListGens.Add(a));

            // new List<Task>
            //{
            //    new Task { Name = "task 1", Deadline = new DateTime(1991, 3, 17), Priority = Priority.high},
            //     new Task { Name = "task 2", Deadline = new DateTime(1989, 2, 12), Priority = Priority.low},
            //     new Task { Name = "task 3", Deadline = new DateTime(2000, 9, 21), Priority = Priority.medium},
            //     new Task { Name = "task 4", Deadline = new DateTime(1989, 6, 27), Priority = Priority.low},
            //     new Task { Name = "task 5", Deadline = new DateTime(1980, 8, 13), Priority = Priority.high},
            //     new Task { Name = "task 6", Deadline = new DateTime(2001, 5, 5), Priority = Priority.low},
            //     new Task { Name = "task 7", Deadline = new DateTime(1989, 6, 22), Priority = Priority.medium},
            //     new Task { Name = "task 8", Deadline = new DateTime(1970, 3, 19), Priority = Priority.low},
            //     new Task { Name = "task 9", Deadline = new DateTime(2017, 11, 21), Priority = Priority.high},
            //     new Task { Name = "task 10", Deadline = new DateTime(1989, 6, 22), Priority = Priority.low},
            //     new Task { Name = "task 11", Deadline = new DateTime(1988, 2, 12), Priority = Priority.medium},
            //     new Task { Name = "task 12", Deadline = new DateTime(2002, 5, 21), Priority = Priority.low}

                
            //}.ForEach(b => context.Tasks.Add(b));

            
        }
    }
}