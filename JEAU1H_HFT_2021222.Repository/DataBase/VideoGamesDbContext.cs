using JEAU1H_HFT_2021222.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEAU1H_HFT_2021222.Repository
{
    public class VideoGamesDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<MinRequirements> Requirements { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public VideoGamesDbContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
               
                builder
                .UseLazyLoadingProxies()
                .UseInMemoryDatabase("Database");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //games studio connection
            modelBuilder.Entity<Game>(game => game
            .HasOne<Studio>()
            .WithMany()
            .HasForeignKey(game => game.StudioId)
            .OnDelete(DeleteBehavior.Cascade));
            //game requirement connection
            modelBuilder.Entity<Game>(game => game
            .HasOne<MinRequirements>()
            .WithMany()
            .HasForeignKey(game => game.ReqId)
            .OnDelete(DeleteBehavior.Cascade));


            modelBuilder.Entity<Game>().HasData(new Game[]
            {
                new Game("FarCry1", 1, "2008", 1,1),
                new Game("FarCry2", 2, "2008", 1,2),
                new Game("FarCry3", 3, "2012", 1,3),
                new Game("Dying Light", 4, "2015",2,4),
                
               
                



            });
            modelBuilder.Entity<Studio>().HasData(new Studio[]
            {
                new Studio("Ubisoft",1,"Yves Guillemot"),
                new Studio("Square Enix",2,"Yosuke Matsuda")

            });
            modelBuilder.Entity<MinRequirements>().HasData(new MinRequirements[]
           {
                new MinRequirements(1,"Intel Core i7-7820X Processor","GeForce RTX 2060"),
                new MinRequirements(2,"AMD Ryzen 7 5800H","GeForce GTX 1080"),
                new MinRequirements(3,"AMD Ryzen Threadripper 2950X","GeForce GTX 1070 Ti"),
                new MinRequirements(4,"Intel Core i7-10700F Processor","Radeon RX 6600"),
           });
        }
    }
}
