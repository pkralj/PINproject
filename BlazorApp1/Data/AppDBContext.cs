using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Data;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
    {
    }

    public DbSet<ScheduleItem> ScheduleItems { get; set; }
    public DbSet<UserAccount> UserAccounts { get; set; }
}

    
