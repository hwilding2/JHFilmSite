using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JHFilmSite.Models
{
    public interface IJHFilmsRepository
    {
        IQueryable<Film> Films { get; }
    }
}
