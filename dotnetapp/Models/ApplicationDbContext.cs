using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.AspNetCore.Mvc;

namespace dotnetapp.Models
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(){}
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Player>Players{get;set;}
        public virtual DbSet<Team>Teams{get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder obj)=>obj.UseSqlServer("User ID=sa;password=examlyMssql@123; server=localhost;Database=PlayerDb;trusted_connection=false;Persist Security Info=False;Encrypt=False");

        // Define DbSet properties for your custom application entities here, if needed.
        // For example, if you have a Player entity, you can add it ...
        
    }
}
