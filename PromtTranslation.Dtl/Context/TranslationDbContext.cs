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
                .Property(id => id.TranslationId)
                .ValueGeneratedOnAdd();

            modelBuilder
                .Entity<RouteModel>()
                .Property(id => id)
                .ValueGeneratedOnAdd();
        }

    }
}
