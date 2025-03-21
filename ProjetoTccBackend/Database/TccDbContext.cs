﻿using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Pomelo.EntityFrameworkCore.MySql;

using ProjetoTccBackend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ProjetoTccBackend.Database
{
    public class TccDbContext : IdentityDbContext<User>
    {
        private IConfiguration _configuration;

        public DbSet<Group> Groups { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<CompetitionRanking> CompetitionRankings { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<GroupInCompetition> GroupsInCompetitions { get; set; }
        public DbSet<ExerciseInCompetition> ExercisesInCompetitions { get; set; }
        

        public TccDbContext(IConfiguration configuration) : base()
        {
            this._configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                this._configuration.GetConnectionString("mariaDB"),
                ServerVersion.AutoDetect(this._configuration.GetConnectionString("mariaDB"))
            );
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Group - Users
            builder.Entity<Group>()
                .HasMany<User>(u => u.Users)
                .WithOne(g => g.Group)
                .HasForeignKey(u => u.GroupId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(required: false);

            // Competitions - Groups
            builder.Entity<Competition>()
                .HasMany<Group>(e => e.Groups)
                .WithMany(u => u.Competitions)
                .UsingEntity<GroupInCompetition>(e => e.Property(p => p.CreatedOn).HasDefaultValueSql("CURRENT_TIMESTAMP"));

            // CompetitionRanking - Competition
            builder.Entity<CompetitionRanking>()
                .HasOne<Competition>(c => c.Competition)
                .WithOne(c => c.CompetitionRanking)
                .HasForeignKey<CompetitionRanking>(c => c.CompetitionId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(required: true);

            // Group - CompetitionRanking
            builder.Entity<Group>()
                .HasMany<CompetitionRanking>(c => c.CompetitionRankings)
                .WithOne(g => g.Group)
                .HasForeignKey(c => c.GroupId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(required: true);


            // Competition - Exercises
            builder.Entity<Competition>()
                .HasMany<Exercise>(c => c.Exercices)
                .WithMany(e => e.Competitions)
                .UsingEntity<ExerciseInCompetition>();

            
        }


    }
}
