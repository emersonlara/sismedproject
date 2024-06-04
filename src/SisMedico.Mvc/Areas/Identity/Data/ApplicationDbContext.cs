using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SisMedico.Mvc.Extensions.IdentityServices;

namespace SisMedico.Mvc.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options){}

    public DbSet<ApplicationUser> ApplicationUser { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //ModelBuilderExtension.AddUserAndRole(builder);
        //builder.AddUserAndRole();
        //builder.AddGenericos();
        base.OnModelCreating(builder);
    }
}
