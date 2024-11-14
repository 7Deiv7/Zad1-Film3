using Film3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Film3.Controllers
{
    public class FilmController : Controller
    {
        private static IList<Film> films = new List<Film>
        {
            new Film(){ Id = 1, Name = "Film1", Description = "opis1", Price = 4},
            new Film(){ Id = 2, Name = "Film2", Description = "opis2", Price = 5},
            new Film(){ Id = 3, Name = "Film3", Description = "opis3", Price = 3},
        };
        // GET: FilmController
        public ActionResult Index()
        {
            return View(films);
        }

        // GET: FilmController/Details/5
        public ActionResult Details(int id)
        {
            return View(films.FirstOrDefault(x => x.Id == id));
        }

        // GET: FilmController/Create
        public ActionResult Create()
        {
            return View(new Film());
        }

        // POST: FilmController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Film film)
        {
            film.Id = films.Count + 1;
            films.Add(film);
            return RedirectToAction(nameof(Index));

        }

        // GET: FilmController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FilmController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Film film) 
        {
           Film filmExisting = films.FirstOrDefault(x => x.Id == id);

            if (filmExisting == null)
            {
                return NotFound();
            }
            filmExisting.Name = film.Name;
            filmExisting.Description = film.Description;
            filmExisting.Price = film.Price;
            return RedirectToAction(nameof(Index));
        }

        // GET: FilmController/Delete/5
        public ActionResult Delete(int id)
        {
            var film = films.FirstOrDefault(x => x.Id == id);
            if (film == null)
            {
                return NotFound();
            }
            return View("Delete", film);
        }

        // POST: FilmController/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmation(int id)
        {
            var film = films.FirstOrDefault(x => x.Id == id);
            if (film == null)
            {
                return NotFound();
            }
            films.Remove(film);
            return RedirectToAction(nameof(Index));
        }
    }
}