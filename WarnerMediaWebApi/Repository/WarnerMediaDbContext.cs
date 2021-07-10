using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarnerMedia.Data.Entities;

namespace WarnerMediaWebApi.Models
{
    public class WarnerMediaDbContext : DbContext
    {
        public DbSet<Title> Titles {get; set; }
        public DbSet<TitleGenre> TitleGenres { get; set; }
        public DbSet<TitleParticipant> TitleParticipants { get; set; }
        public DbSet<StoryLine> StoryLines { get; set; }
                       

        public WarnerMediaDbContext(DbContextOptions<WarnerMediaDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Title>().ToTable("Title");            
            modelBuilder.Entity<TitleGenre>().ToTable("TitleGenre");
            modelBuilder.Entity<TitleParticipant>().ToTable("TitleParticipant");
            modelBuilder.Entity<StoryLine>().ToTable("StoryLine"); 
            
        }

       

    }
}
