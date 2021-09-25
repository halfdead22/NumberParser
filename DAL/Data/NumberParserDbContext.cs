using DAL.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Data
{
    public class NumberParserDbContext :DbContext
    {
        public DbSet<InputOutputResult> InputOutputResult { get; set; }
        public DbSet<FileType> FileType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationBuilder configBuilder = new ConfigurationBuilder().AddJsonFile("appSettings.json");
            IConfiguration configuration = configBuilder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileType>()
                .HasData(
                    new FileType
                    {
                        Id = 1,
                        FileTypeFormat = "TEXT",
                    },
                    new FileType
                    {
                        Id = 2,
                        FileTypeFormat = "XML",
                    }, new FileType
                    {
                        Id = 3,
                        FileTypeFormat = "JSON",
                    }
                );
        }
    }
}
