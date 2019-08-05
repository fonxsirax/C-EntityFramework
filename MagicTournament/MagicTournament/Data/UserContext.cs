using MagicTournament.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagicTournament.ViewModel;
namespace MagicTournament.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options) { }

        public DbSet<UserModel> usertable { get; set; } //referencia da entidade
        public DbSet<Deck> deck { get; set; }
        public DbSet<MagicTournament.ViewModel.CreateLoginVMcs> CreateLoginVMcs { get; set; }
        public DbSet<MagicTournament.ViewModel.CreateDeckVM> CreateDeckVM { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // configuração do mapeamento da entidade
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.ApplyConfiguration(new UserMap());
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //        IConfigurationRoot configuration = new ConfigurationBuilder()
        //        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        //        .AddJsonFile("appsettings.json")
        //        .Build();
        //    optionsBuilder.UseSqlServer(configuration.GetConnectionString("CardContext"));
        //}
    }
}
