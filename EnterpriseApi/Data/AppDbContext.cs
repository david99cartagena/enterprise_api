using Microsoft.EntityFrameworkCore;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Enterprise> Enterprises { get; set; }
    public DbSet<Code> Codes { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Code>()
            .HasOne(c => c.Enterprise)
            .WithMany(e => e.Codes)
            .HasForeignKey(c => c.Owner);
    }
}
