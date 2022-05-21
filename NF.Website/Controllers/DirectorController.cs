using NF.Website.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NF.Website.Controllers
{
    public class DirectorController : Controller
    {
        // GET: Director
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

            List<DirectorVM> directorsVM = new List<DirectorVM>();
            using (DirectorsReference.DirectorsClient service = new DirectorsReference.DirectorsClient())
            {
                service.ClientCredentials.UserName.UserName = "username";
                service.ClientCredentials.UserName.Password = "password";

                if (!String.IsNullOrEmpty(searchString))
                {
                    foreach (var item in service.GetDirectorsByName(searchString))
                    {
                        directorsVM.Add(new DirectorVM(item));
                    }
                }
                else
                {
                    foreach (var item in service.GetDirectors())
                    {
                        directorsVM.Add(new DirectorVM(item));
                    }
                }
            }

            int pageSize = 7;
            int pageNumber = (page ?? 1);

            return View(directorsVM.ToPagedList(pageNumber, pageSize));
        }

        // GET: Director/Details/5
        public ActionResult Details(int id)
        {
            DirectorVM directorVM = new DirectorVM();
            using (DirectorsReference.DirectorsClient service = new DirectorsReference.DirectorsClient())
            {
                service.ClientCredentials.UserName.UserName = "username";
                service.ClientCredentials.UserName.Password = "password";

                var directorDto = service.GetDirectorById(id);
                directorVM = new DirectorVM(directorDto);
            }
            return View(directorVM);
        }

        // GET: Director/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Director/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DirectorVM directorVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DirectorsReference.DirectorsClient service = new DirectorsReference.DirectorsClient())
                    {
                        service.ClientCredentials.UserName.UserName = "username";
                        service.ClientCredentials.UserName.Password = "password";

                        DirectorsReference.DirectorDto directorDto = new DirectorsReference.DirectorDto
                        {
                            FirstName = directorVM.FirstName,
                            LastName = directorVM.LastName,
                            DirectorInfo = directorVM.DirectorInfo
                        };
                        service.PostDirector(directorDto);
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

        // GET: Director/Edit/5
        public ActionResult Edit(int id)
        {
            DirectorVM directorVM = new DirectorVM();
            using (DirectorsReference.DirectorsClient service = new DirectorsReference.DirectorsClient())
            {
                service.ClientCredentials.UserName.UserName = "username";
                service.ClientCredentials.UserName.Password = "password";

                var directorDto = service.GetDirectorById(id);
                directorVM = new DirectorVM(directorDto);
            }
            return View(directorVM);
        }

        // POST: Director/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DirectorVM directorVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DirectorsReference.DirectorsClient service = new DirectorsReference.DirectorsClient())
                    {
                        service.ClientCredentials.UserName.UserName = "username";
                        service.ClientCredentials.UserName.Password = "password";

                        DirectorsReference.DirectorDto directorDto = new DirectorsReference.DirectorDto
                        {
                            Id = directorVM.Id,
                            FirstName = directorVM.FirstName,
                            LastName = directorVM.LastName,
                            DirectorInfo = directorVM.DirectorInfo
                        };
                        service.PutDirector(directorDto);
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

        // GET: Director/Delete/5
        public ActionResult Delete(int id)
        {
            DirectorVM directorVM = new DirectorVM();

            using (DirectorsReference.DirectorsClient service = new DirectorsReference.DirectorsClient())
            {
                service.ClientCredentials.UserName.UserName = "username";
                service.ClientCredentials.UserName.Password = "password";

                DirectorsReference.DirectorDto directorDto = service.GetDirectorById(id);

                directorVM = new DirectorVM(directorDto);
            }
            return View(directorVM);
        }

        // POST: Director/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (DirectorsReference.DirectorsClient service = new DirectorsReference.DirectorsClient())
            {
                service.ClientCredentials.UserName.UserName = "username";
                service.ClientCredentials.UserName.Password = "password";

                service.DeleteDirector(id);
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