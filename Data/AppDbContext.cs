using ApiNet6.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiNet6.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TodoModel> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("conectionstring");
    }
}
