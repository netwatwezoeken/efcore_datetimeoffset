using Microsoft.EntityFrameworkCore;

namespace ClassLibrary;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }
    
    public virtual DbSet<Entity> Entities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Latin1_General_CI_AS");

        modelBuilder.Entity<Entity>(entity =>
            {
                entity.ToTable("Entity");

                entity.Property(e => e.Modifified).HasDefaultValueSql("(sysdatetimeoffset())");
            });
    }
}