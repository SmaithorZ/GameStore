using Microsoft.EntityFrameworkCore;
using GameStoreApp.Models;

namespace GameStoreApp.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        
        
        }

        public DbSet<GameEntry> GameEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GameEntry>().HasData(

                new GameEntry
                {
                    Id = 1,
                    Title = "Red Dead Redemption 2",
                    Description = "You play as Arthur Morgan, an outlaw back in the 1800's",
                    Created = new DateTime(2018, 10, 26)
                },

                new GameEntry
                {
                    Id = 2,
                    Title = "Valheim",
                    Description = "Valheim is a brutal exploration and survival game for 1-10 players set in a procedurally-generated world inspired by Norse mythology",
                    Created = new DateTime(2021, 2, 2)
                },

                new GameEntry
                {
                    Id = 3,
                    Title = "Grand Theft Auto V",
                    Description = "an action-adventure game played from either a third-person or first-person perspective. Players complete missions—linear scenarios with set objectives",
                    Created = new DateTime(2013, 9, 17)
                }




                );
        }
    }
}
