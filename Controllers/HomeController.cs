using JHFilmSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JHFilmSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private JHFilmsDbContext _context;
        private IJHFilmsRepository _repository;

        public HomeController(ILogger<HomeController> logger, JHFilmsDbContext context, IJHFilmsRepository repository)
        {
            _logger = logger;
            _context = context;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FilmList()
        {
            return View(_context.Films.Where(m => m.Title != "Independence Day"));
        }
        [HttpGet]
        public IActionResult EnterFilm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EnterFilm(Film film)
        {
            _context.Films.Add(film);
            _context.SaveChanges();
            return View("Confirmation", film);
        }
        public IActionResult EditFilm(int filmId)
        {
            Film film = _context.Films.Where(m => m.FilmId == filmId).FirstOrDefault();
            return View(film);
        }

        [HttpPost]
        public IActionResult EditConfirmation(Film film, int filmId)
        {
            //Update database
            Film targetFilm = _context.Films.Where(m => m.FilmId == filmId).FirstOrDefault();
            targetFilm.Category = film.Category;
            targetFilm.Title = film.Title;
            targetFilm.Year = film.Year;
            targetFilm.Director = film.Director;
            targetFilm.Rating = film.Rating;
            targetFilm.Edited = film.Edited;
            targetFilm.LentTo = film.LentTo;
            targetFilm.Notes = film.Notes;

            _context.SaveChanges();
            return View(film);
        }

        public IActionResult DeleteFilm(int filmId)
        {
            //  Delete from database
            Film targetFilm = _context.Films.Where(m => m.FilmId == filmId).FirstOrDefault();
            _context.Remove(targetFilm);
            _context.SaveChanges();
            return View("DeleteConfirmation", targetFilm);
        }

        public IActionResult Podcasts()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
