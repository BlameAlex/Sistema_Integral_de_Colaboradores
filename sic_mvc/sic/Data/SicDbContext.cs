namespace sic.Data;



using Microsoft.EntityFrameworkCore;

public class SicDbContext : DbContext
{
    public SicDbContext(DbContextOptions<SicDbContext> options)
        : base(options)
    {
    }  
    public DbSet<Permission> Permissions { get; set; }

 }    
