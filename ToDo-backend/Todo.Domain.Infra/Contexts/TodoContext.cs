using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;

namespace Todo.Domain.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }
        public DbSet<TodoItem> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {
            ModelBuilder.Entity<TodoItem>().ToTable("Todo");
            ModelBuilder.Entity<TodoItem>().Property(x => x.Id);
            ModelBuilder.Entity<TodoItem>().Property(x => x.User).HasMaxLength(120).HasColumnType("varchar(120)");
            ModelBuilder.Entity<TodoItem>().Property(x => x.Title).HasMaxLength(160).HasColumnType("varchar(160)");
            ModelBuilder.Entity<TodoItem>().Property(x => x.Done).HasColumnType("bit");
            ModelBuilder.Entity<TodoItem>().Property(x => x.Date);
            ModelBuilder.Entity<TodoItem>().HasIndex(b => b.User);
        }
    }
}