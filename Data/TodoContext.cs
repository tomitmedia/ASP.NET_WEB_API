using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoWebAPI.Models;

namespace ToDoWebAPI.Data
{
    public class TodoContext: IdentityDbContext<ApplicationUser>
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)  
        {
        }
        public DbSet<Todo> Todos { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.; Database=TodoAPI; Intergrated Security=True");
        //        base.OnConfiguring(optionsBuilder);
        //}
    }
}
