using NF.Website.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NF.Website.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
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

            List<MovieVM> moviesVM = new List<MovieVM>();
            using (MoviesReference.MoviesClient service = new MoviesReference.MoviesClient())
            {
                service.ClientCredentials.UserName.UserName = "username";
                service.ClientCredentials.UserName.Password = "password";

                if (!String.IsNullOrEmpty(searchString))
                {
                    foreach (var item in service.GetMoviesByReleaseCountry(searchString))
                    {
                        moviesVM.Add(new MovieVM(item));
                    }
                }
                else
                {
                    foreach (var item in service.GetMovies())
                    {
                        moviesVM.Add(new MovieVM(item));
                    }
                }
            }

            int pageSize = 7;
            int pageNumber = (page ?? 1);

            return View(moviesVM.ToPagedList(pageNumber, pageSize));
        }

        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            MovieVM movieVM = new MovieVM();
            using (MoviesReference.MoviesClient service = new MoviesReference.MoviesClient())
            {
                service.ClientCredentials.UserName.UserName = "username";
                service.ClientCredentials.UserName.Password = "password";

                var movieDto = service.GetMovieById(id);
                movieVM = new MovieVM(movieDto);
            }
            return View(movieVM);
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            ViewBag.Directors = Utils.LoadDataUtil.LoadDirectorData();
            ViewBag.Producers = Utils.LoadDataUtil.LoadProducerData();
            ViewBag.Genres = Utils.LoadDataUtil.LoadGenreData();
            ViewBag.Ratings = Utils.LoadDataUtil.LoadRatingData();
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieVM movieVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (MoviesReference.MoviesClient service = new MoviesReference.MoviesClient())
                    {
                        service.ClientCredentials.UserName.UserName = "username";
                        service.ClientCredentials.UserName.Password = "password";

                        MoviesReference.MovieDto movieDto = new MoviesReference.MovieDto
                        {
                            Title = movieVM.Title,
                            ReleaseDate = movieVM.ReleaseDate,
                            ReleaseCountry = movieVM.ReleaseCountry,
                            Director = new MoviesReference.DirectorDto
                            {
                                Id = movieVM.DirectorId
                            },
                            Producer = new MoviesReference.ProducerDto
                            {
                                Id = movieVM.ProducerId
                            },
                            Genre = new MoviesReference.GenreDto
                            {
                                Id = movieVM.GenreId
                            },
                            MovieInfo = movieVM.MovieInfo,
                            Rating = new MoviesReference.RatingDto
                            {
                                Id = movieVM.RatingId
                            }
                        };
                        service.PostMovie(movieDto);
                    }
                    return RedirectToAction("Index");
                }
                ViewBag.Directors = Utils.LoadDataUtil.LoadDirectorData();
                ViewBag.Producers = Utils.LoadDataUtil.LoadProducerData();
                ViewBag.Genres = Utils.LoadDataUtil.LoadGenreData();
                ViewBag.Ratings = Utils.LoadDataUtil.LoadRatingData();
                return View();
            }
            catch
            {
                ViewBag.Directors = Utils.LoadDataUtil.LoadDirectorData();
                ViewBag.Producers = Utils.LoadDataUtil.LoadProducerData();
                ViewBag.Genres = Utils.LoadDataUtil.LoadGenreData();
                ViewBag.Ratings = Utils.LoadDataUtil.LoadRatingData();
                return View();
            }
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {
            MovieVM movieVM = new MovieVM();
            using (MoviesReference.MoviesClient service = new MoviesReference.MoviesClient())
            {
                service.ClientCredentials.UserName.UserName = "username";
                service.ClientCredentials.UserName.Password = "password";

                var movieDto = service.GetMovieById(id);
                movieVM = new MovieVM(movieDto);
            }
            ViewBag.Directors = Utils.LoadDataUtil.LoadDirectorData();
            ViewBag.Producers = Utils.LoadDataUtil.LoadProducerData();
            ViewBag.Genres = Utils.LoadDataUtil.LoadGenreData();
            ViewBag.Ratings = Utils.LoadDataUtil.LoadRatingData();
            return View(movieVM);
        }

        // POST: Movie/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MovieVM movieVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (MoviesReference.MoviesClient service = new MoviesReference.MoviesClient())
                    {
                        service.ClientCredentials.UserName.UserName = "username";
                        service.ClientCredentials.UserName.Password = "password";

                        MoviesReference.MovieDto movieDto = new MoviesReference.MovieDto
                        {
                            Id = movieVM.Id,
                            Title = movieVM.Title,
                            ReleaseDate = movieVM.ReleaseDate,
                            ReleaseCountry = movieVM.ReleaseCountry,
                            Director = new MoviesReference.DirectorDto
                            {
                                Id = movieVM.DirectorId
                            },
                            Producer = new MoviesReference.ProducerDto
                            {
                                Id = movieVM.ProducerId
                            },
                            Genre = new MoviesReference.GenreDto
                            {
                                Id = movieVM.GenreId
                            },
                            MovieInfo = movieVM.MovieInfo,
                            Rating = new MoviesReference.RatingDto
                            {
                                Id = movieVM.RatingId
                            }
                        };
                        service.PutMovie(movieDto);
                    }

                    return RedirectToAction("Index");
                }
                ViewBag.Directors = Utils.LoadDataUtil.LoadDirectorData();
                ViewBag.Producers = Utils.LoadDataUtil.LoadProducerData();
                ViewBag.Genres = Utils.LoadDataUtil.LoadGenreData();
                ViewBag.Ratings = Utils.LoadDataUtil.LoadRatingData();
                return View();
            }
            catch
            {
                ViewBag.Directors = Utils.LoadDataUtil.LoadDirectorData();
                ViewBag.Producers = Utils.LoadDataUtil.LoadProducerData();
                ViewBag.Genres = Utils.LoadDataUtil.LoadGenreData();
                ViewBag.Ratings = Utils.LoadDataUtil.LoadRatingData();
                return View();
            }
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int id)
        {
            MovieVM movieVM = new MovieVM();

            using (MoviesReference.MoviesClient service = new MoviesReference.MoviesClient())
            {
                service.ClientCredentials.UserName.UserName = "username";
                service.ClientCredentials.UserName.Password = "password";

                MoviesReference.MovieDto movieDto = service.GetMovieById(id);

                movieVM = new MovieVM(movieDto);
            }
            return View(movieVM);
        }

        // POST: Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (MoviesReference.MoviesClient service = new MoviesReference.MoviesClient())
            {
                service.ClientCredentials.UserName.UserName = "username";
                service.ClientCredentials.UserName.Password = "password";

                service.DeleteMovie(id);
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