﻿using _03.FootballBetting.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace _03.FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {
        }

        public DbSet<Bet> Bets { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=FootballBetting;Integrated Security=true");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerStatistic>()
                .HasKey(x => new { x.GameId, x.PlayerId });


            //Когато имам 2 колекции сочещи към един клас, за да не се бърка трябва .OnDelete да е DeleteBehavior.Restrict
            modelBuilder.Entity<Team>(x =>
                {
                    x.HasOne(x => x.PrimaryKitColor)
                     .WithMany(x => x.PrimaryKitTeams)
                     .HasForeignKey(x => x.PrimaryKitColorId)
                     .OnDelete(DeleteBehavior.Restrict);

                    x.HasOne(x => x.SecondaryKitColor)
                     .WithMany(x => x.SecondaryKitTeams)
                     .HasForeignKey(x => x.SecondaryKitColorId)
                     .OnDelete(DeleteBehavior.Restrict);
                });
            
            modelBuilder.Entity<Game>(
                x =>
                {
                    x.HasOne(x => x.HomeTeam)
                     .WithMany(x => x.HomeGames)
                     .HasForeignKey(x => x.HomeTeamId)
                     .OnDelete(DeleteBehavior.Restrict);

                    x.HasOne(x => x.AwayTeam)
                     .WithMany(x => x.AwayGames)
                     .HasForeignKey(x => x.AwayTeamId)
                     .OnDelete(DeleteBehavior.Restrict);
                });


        }
    }
}
