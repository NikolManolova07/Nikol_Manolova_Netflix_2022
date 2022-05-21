using NF.Website.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NF.Website.Controllers
{
    public class GenreController : Controller
    {
        // GET: Genre
        public ActionResult Index(string currentFilter, string searchString, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            List<GenreVM> genresVM = new List<GenreVM>();
            using (GenresReference.GenresClient service = new GenresReference.GenresClient())
            {
                service.ClientCredentials.UserName.UserName = "username";
                service.ClientCredentials.UserName.Password = "password";

                if (!String.IsNullOrEmpty(searchString))
                {
                    foreach (var item in service.GetGenresByName(searchString))
                    {
                        genresVM.Add(new GenreVM(item));
                    }
                }
                else
                {
                    foreach (var item in service.GetGenres())
                    {
                        genresVM.Add(new GenreVM(item));
                    }
                }
            }

            int pageSize = 7;
            int pageNumber = (page ?? 1);

            return View(genresVM.ToPagedList(pageNumber, pageSize));
        }

        // GET: Genre/Details/5
        public ActionResult Details(int id)
        {
            GenreVM genreVM = new GenreVM();
            using (GenresReference.GenresClient service = new GenresReference.GenresClient())
            {
                service.ClientCredentials.UserName.UserName = "username";
                service.ClientCredentials.UserName.Password = "password";

                var genreDto = service.GetGenreById(id);
                genreVM = new GenreVM(genreDto);
            }
            return View(genreVM);
        }

        // GET: Genre/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Genre/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GenreVM genreVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (GenresReference.GenresClient service = new GenresReference.GenresClient())
                    {
                        service.ClientCredentials.UserName.UserName = "username";
                        service.ClientCredentials.UserName.Password = "password";

                        GenresReference.GenreDto genreDto = new GenresReference.GenreDto
                        {
                            Name = genreVM.Name,
                            GenreInfo = genreVM.GenreInfo
                        };
                        service.PostGenre(genreDto);
                    }
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Genre/Edit/5
        public ActionResult Edit(int id)
        {
            GenreVM genreVM = new GenreVM();
            using (GenresReference.GenresClient service = new GenresReference.GenresClient())
            {
                service.ClientCredentials.UserName.UserName = "username";
                service.ClientCredentials.UserName.Password = "password";

                var genreDto = service.GetGenreById(id);
                genreVM = new GenreVM(genreDto);
            }
            return View(genreVM);
        }

        // POST: Genre/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GenreVM genreVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (GenresReference.GenresClient service = new GenresReference.GenresClient())
                    {
                        service.ClientCredentials.UserName.UserName = "username";
                        service.ClientCredentials.UserName.Password = "password";

                        GenresReference.GenreDto genreDto = new GenresReference.GenreDto
                        {
                            Id = genreVM.Id,
                            Name = genreVM.Name,
                            GenreInfo = genreVM.GenreInfo
                        };
                        service.PutGenre(genreDto);
                    }

                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Genre/Delete/5
        public ActionResult Delete(int id)
        {
            GenreVM genreVM = new GenreVM();

            using (GenresReference.GenresClient service = new GenresReference.GenresClient())
            {
                service.ClientCredentials.UserName.UserName = "username";
                service.ClientCredentials.UserName.Password = "password";

                GenresReference.GenreDto genreDto = service.GetGenreById(id);

                genreVM = new GenreVM(genreDto);
            }
            return View(genreVM);
        }

        // POST: Genre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (GenresReference.GenresClient service = new GenresReference.GenresClient())
            {
                service.ClientCredentials.UserName.UserName = "username";
                service.ClientCredentials.UserName.Password = "password";

                service.DeleteGenre(id);
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}