using NF.Website.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NF.Website.Controllers
{
    public class ProducerController : Controller
    {
        // GET: Producer
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

            List<ProducerVM> producersVM = new List<ProducerVM>();
            using (ProducersReference.ProducersClient service = new ProducersReference.ProducersClient())
            {
                service.ClientCredentials.UserName.UserName = "username";
                service.ClientCredentials.UserName.Password = "password";

                if (!String.IsNullOrEmpty(searchString))
                {
                    foreach (var item in service.GetProducersByName(searchString))
                    {
                        producersVM.Add(new ProducerVM(item));
                    }
                }
                else
                {
                    foreach (var item in service.GetProducers())
                    {
                        producersVM.Add(new ProducerVM(item));
                    }
                }
            }

            int pageSize = 7;
            int pageNumber = (page ?? 1);

            return View(producersVM.ToPagedList(pageNumber, pageSize));
        }

        // GET: Producer/Details/5
        public ActionResult Details(int id)
        {
            ProducerVM producerVM = new ProducerVM();
            using (ProducersReference.ProducersClient service = new ProducersReference.ProducersClient())
            {
                service.ClientCredentials.UserName.UserName = "username";
                service.ClientCredentials.UserName.Password = "password";

                var producerDto = service.GetProducerById(id);
                producerVM = new ProducerVM(producerDto);
            }
            return View(producerVM);
        }

        // GET: Producer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProducerVM producerVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ProducersReference.ProducersClient service = new ProducersReference.ProducersClient())
                    {
                        service.ClientCredentials.UserName.UserName = "username";
                        service.ClientCredentials.UserName.Password = "password";

                        ProducersReference.ProducerDto producerDto = new ProducersReference.ProducerDto
                        {
                            FirstName = producerVM.FirstName,
                            LastName = producerVM.LastName,
                            ProducerInfo = producerVM.ProducerInfo
                        };
                        service.PostProducer(producerDto);
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

        // GET: Producer/Edit/5
        public ActionResult Edit(int id)
        {
            ProducerVM producerVM = new ProducerVM();
            using (ProducersReference.ProducersClient service = new ProducersReference.ProducersClient())
            {
                service.ClientCredentials.UserName.UserName = "username";
                service.ClientCredentials.UserName.Password = "password";

                var producerDto = service.GetProducerById(id);
                producerVM = new ProducerVM(producerDto);
            }
            return View(producerVM);
        }

        // POST: Producer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProducerVM producerVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ProducersReference.ProducersClient service = new ProducersReference.ProducersClient())
                    {
                        service.ClientCredentials.UserName.UserName = "username";
                        service.ClientCredentials.UserName.Password = "password";

                        ProducersReference.ProducerDto producerDto = new ProducersReference.ProducerDto
                        {
                            Id = producerVM.Id,
                            FirstName = producerVM.FirstName,
                            LastName = producerVM.LastName,
                            ProducerInfo = producerVM.ProducerInfo
                        };
                        service.PutProducer(producerDto);
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

        // GET: Producer/Delete/5
        public ActionResult Delete(int id)
        {
            ProducerVM producerVM = new ProducerVM();

            using (ProducersReference.ProducersClient service = new ProducersReference.ProducersClient())
            {
                service.ClientCredentials.UserName.UserName = "username";
                service.ClientCredentials.UserName.Password = "password";

                ProducersReference.ProducerDto producerDto = service.GetProducerById(id);

                producerVM = new ProducerVM(producerDto);
            }
            return View(producerVM);
        }

        // POST: Producer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (ProducersReference.ProducersClient service = new ProducersReference.ProducersClient())
            {
                service.ClientCredentials.UserName.UserName = "username";
                service.ClientCredentials.UserName.Password = "password";

                service.DeleteProducer(id);
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