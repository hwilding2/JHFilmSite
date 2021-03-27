using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JHFilmSite.Models
{
    public class EFJHFilmsRepository : IJHFilmsRepository
    {
        private JHFilmsDbContext _context;

        //Constructor
        public EFJHFilmsRepository(JHFilmsDbContext context)
        {
            _context = context;
        }

        public IQueryable<Film> Films => _context.Films;

    }
}
