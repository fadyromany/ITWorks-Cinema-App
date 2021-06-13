using ITWorks.ELcinema.Data.EF;
using ItworksElcenima.Domain.Models;
using ItworksElcenima.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ITworks.Elcinema.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieService _movieservice;
        private readonly CountryService _countryService;


        public MoviesController(MovieService movieService, CountryService countryService)
        {
            _movieservice = movieService;
            _countryService = countryService;
        }

        public MoviesController() // dh el constructor eli el MVC hatndaho
        {
            var uof = new EfUniOfWork();
            var repo = new Efrepository<Movie>(uof);
            var counteryrepo = new Efrepository<Country>(uof);
            _movieservice = new MovieService(repo);
            _countryService = new CountryService(counteryrepo);

        }
        // GET: Movies
        public ActionResult Index()
        {
            var movies = _movieservice.GetALL();
            return View(movies);
        }

        public ActionResult Delete(int id)
        {
            _movieservice.Remove(new Movie {Id=id });
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            
            ViewBag.countryid = new SelectList(_countryService.GetALL(),"Id","Name");
            var movie = _movieservice.Get(id);

            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if(ModelState.IsValid)
            {
                _movieservice.Modify(movie);
                return RedirectToAction("Index");
            }
            ViewBag.countryid = new SelectList(_countryService.GetALL(), "Id", "Name");
            return View(movie);
        }

        [HttpGet]
        public ActionResult Create()
        {

            ViewBag.countryid = new SelectList(_countryService.GetALL(), "Id", "Name");

            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {

            if (ModelState.IsValid)
            {
                _movieservice.Add(movie);
                return RedirectToAction("Index");
            }
            ViewBag.countryid = new SelectList(_countryService.GetALL(), "Id", "Name");

            return View(movie);
        }
    }
}