using EsportsBay.API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsportsBay.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<Stream> Stream {get; set;}
        public DbSet<Tournament> Tournament { get; set; }

        public DbSet<Match> Match { get; set; }

        public DbSet<Team> Team { get; set; }


    }
}
