namespace ToDos.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ToDos.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ToDos.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ToDos.Models.ApplicationDbContext context)
        {
            var chores = new ToDo[] 
            { 
                new ToDo { TaskName = "Walk the dog", Description = "to petco", IsCompleted = true }, 
                new ToDo { TaskName = "Paint the house", Description = "color red", IsCompleted = false }, 
                new ToDo { TaskName = "Laundry", Description = "Wash sheets and towels together", IsCompleted = true } 

            };

            context.ToDos.AddOrUpdate(t => t.TaskName, chores);
                
        }
    }
}
