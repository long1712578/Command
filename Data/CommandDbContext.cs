using Commander.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.Data{
    public class CommandDbContext : DbContext
{
    public CommandDbContext(DbContextOptions<CommandDbContext> options)
        : base(options)
    { }

    public DbSet<Command> Commands { get; set; }
}
}