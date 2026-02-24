using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Mission08.Models   // match your namespace
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TasksContext>();

            // Make sure DB exists / apply migrations
            context.Database.Migrate();

            // Seed Categories
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category { CategoryName = "Home" },
                    new Category { CategoryName = "School" },
                    new Category { CategoryName = "Work" },
                    new Category { CategoryName = "Church" }
                );
            }

            // Seed a couple of example tasks
            if (!context.Tasks.Any())
            {
                context.Tasks.AddRange(
                    new TaskItem
                    {
                        TaskName = "Finish Mission 8",
                        Quadrant = 1,
                        Completed = false
                    },
                    new TaskItem
                    {
                        TaskName = "Plan weekend trip",
                        Quadrant = 2,
                        Completed = false
                    }
                );
            }

            context.SaveChanges();
        }
    }
}
