using JHFilmSite.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JHFilmSite.Models
{
    public class JHFilmsDbContext : DbContext
    {
        public JHFilmsDbContext(DbContextOptions<JHFilmsDbContext> options) : base(options)
        {

        }
        public DbSet<Film> Films { get; set; }
    }
}
