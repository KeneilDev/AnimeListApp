using AnimeListApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeListApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<Models.AppUser, Models.AppRole, int> 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Models.AppUser>().Ignore(e => e.FullName);
            builder.Entity<UserAnimeList>()
           .HasKey(x => new { x.Id });
            builder.Entity<UserAnimeList>()
           .HasIndex(e => new { e.AppUserId, e.AnimeId }).IsUnique();
        }
        public DbSet<Anime> Anime { get; set; }
        public DbSet<UserAnimeList> UserAnimes { get; set; }
    }
}
