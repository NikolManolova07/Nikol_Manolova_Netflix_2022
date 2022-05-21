using NF.Website.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NF.Website.Controllers
{
    public class RatingController : Controller
    {
        // GET: Rating
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

            List<RatingVM> ratingsVM = new List<RatingVM>();
            using (RatingsReference.RatingsClient service = new RatingsReference.RatingsClient())
            {
                service.ClientCredentials.UserName.UserName = "username";
                service.ClientCredentials.UserName.Password = "password";

                if (!String.IsNullOrEmpty(searchString))
                {
                    foreach (var item in service.GetRatingsByName(searchString))
                    {
                        ratingsVM.Add(new RatingVM(item));
                    }
                }
                else
                {
                    foreach (var item in service.GetRatings())
                    {
                        ratingsVM.Add(new RatingVM(item));
                    }
                }
            }

            int pageSize = 7;
            int pageNumber = (page ?? 1);

            return View(ratingsVM.ToPagedList(pageNumber, pageSize));
        }

        // GET: Rating/Details/5
        public ActionResult Details(int id)
        {
            RatingVM ratingVM = new RatingVM();
            using (RatingsReference.RatingsClient service = new RatingsReference.RatingsClient())
            {
                service.ClientCredentials.UserName.UserName = "username";
                service.ClientCredentials.UserName.Password = "password";

                var ratingDto = service.GetRatingById(id);
                ratingVM = new RatingVM(ratingDto);
            }
            return View(ratingVM);
        }

        // GET: Rating/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rating/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RatingVM ratingVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (RatingsReference.RatingsClient service = new RatingsReference.RatingsClient())
                    {
                        service.ClientCredentials.UserName.UserName = "username";
                        service.ClientCredentials.UserName.Password = "password";

                        RatingsReference.RatingDto ratingDto = new RatingsReference.RatingDto
                        {
                            Name = ratingVM.Name
                        };
                        service.PostRating(ratingDto);
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

        // GET: Rating/Edit/5
        public ActionResult Edit(int id)
        {
            RatingVM ratingVM = new RatingVM();
            using (RatingsReference.RatingsClient service = new RatingsReference.RatingsClient())
            {
                service.ClientCredentials.UserName.UserName = "username";
                service.ClientCredentials.UserName.Password = "password";

                var ratingDto = service.GetRatingById(id);
                ratingVM = new RatingVM(ratingDto);
            }
            return View(ratingVM);
        }

        // POST: Rating/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RatingVM ratingVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (RatingsReference.RatingsClient service = new RatingsReference.RatingsClient())
                    {
                        service.ClientCredentials.UserName.UserName = "username";
                        service.ClientCredentials.UserName.Password = "password";

                        RatingsReference.RatingDto ratingDto = new RatingsReference.RatingDto
                        {
                            Id = ratingVM.Id,
                            Name = ratingVM.Name
                        };
                        service.PutRating(ratingDto);
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

        // GET: Rating/Delete/5
        public ActionResult Delete(int id)
        {
            RatingVM ratingVM = new RatingVM();

            using (RatingsReference.RatingsClient service = new RatingsReference.RatingsClient())
            {
                service.ClientCredentials.UserName.UserName = "username";
                service.ClientCredentials.UserName.Password = "password";

                RatingsReference.RatingDto ratingDto = service.GetRatingById(id);

                ratingVM = new RatingVM(ratingDto);
            }
            return View(ratingVM);
        }

        // POST: Rating/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (RatingsReference.RatingsClient service = new RatingsReference.RatingsClient())
            {
                service.ClientCredentials.UserName.UserName = "username";
                service.ClientCredentials.UserName.Password = "password";

                service.DeleteRating(id);
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