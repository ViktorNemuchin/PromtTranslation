using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PromtTranslation.Domain.Models;

namespace PromtTranslation.Dtl.Context
{
    public class TranslationDbContext:DbContext
    {
        public TranslationDbContext(DbContextOptions<TranslationDbContext> options)
            : base(options: options) { }
        
        public DbSet<TranslationModel> Translations;
        
        public DbSet<RouteModel> Routes;

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder
                .Entity<TranslationModel>()
                .Property(ent => ent.Id)
                .ValueGeneratedOnAdd();

            modelBuilder
                .Entity<TranslationModel>()
                .HasKey(ent => ent.Id);

            modelBuilder
                .Entity<RouteModel>()
                .Property(ent => ent.Id)
                .ValueGeneratedOnAdd();

            modelBuilder
                .Entity<RouteModel>()
                .HasKey(ent => ent.Id);

            modelBuilder
                .Entity<StatusModel>()
                .Property(ent => ent.Id)
                .ValueGeneratedOnAdd();

            modelBuilder
                .Entity<StatusModel>()
                .HasKey(ent => ent.Id);
        }

    }
}
