using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetAPP.Core.Entities;
using TimesheetAPP.Core.Interfaces;

namespace TimesheetAPP.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }
        public DbSet<Intervenant> Intervenants { get; set; }
        public DbSet<Projet> Projets { get; set; }
        public DbSet<Solution> Solutions { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Consomation> Consomations { get; set; }
        public DbSet<Projet_Intervenant> Projet_Intervenants { get; set; }
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.
                UseLazyLoadingProxies().
                UseSqlServer(this.GetJsonConnectionString("appsettings.json"), options => options.CommandTimeout(120));
            base.OnConfiguring(optionsBuilder);
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        } 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Projet_Intervenant>().HasOne(p => p.Projet).WithMany(pi => pi.Projet_Intervenants).HasForeignKey(c => c.ProjetId);
            modelBuilder.Entity<Projet_Intervenant>().HasOne(i => i.Intervenant).WithMany(pi => pi.Projet_Intervenants).HasForeignKey(c => c.IntervenantId);
            modelBuilder.Entity<Projet_Intervenant>().HasKey(pi => new { pi.ProjetId, pi.IntervenantId, pi.Projet_IntervenantId });
            modelBuilder.Entity<Ticket>().HasOne(c => c.Consomation).WithMany(t => t.Tickets).HasForeignKey(c => c.ConsomationId);
            modelBuilder.Entity<Ticket>().HasOne(c => c.Solution).WithMany(t => t.Tickets).HasForeignKey(c => c.SolutionId);
            modelBuilder.Entity<Intervenant>().HasOne(c => c.Consomation).WithMany(t => t.Intervenants).HasForeignKey(c => c.ConsomationId);
            modelBuilder.Entity<Projet>().HasOne(c => c.Solution).WithMany(t => t.Projets).HasForeignKey(c => c.SolutionId);







        }

    }
}
