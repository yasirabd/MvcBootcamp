using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NorthwindRepository.Repositories;

namespace MvcBootcamp.Web.Controllers
{
    public class CustomerAjaxController : Controller
    {
        private CustomerRepository custRepo = new CustomerRepository();

        // GET: CustomerAjax
        public ActionResult Index()
        {
            return View(custRepo.GetAllData().Take(10));
        }

        public ActionResult Search(string name)
        {
            var cust = custRepo.GetAllData().Where(c => c.CompanyName.Contains(name));

            if (Request.IsAjaxRequest())
            {
                return PartialView("_search", cust);
            }
            else
            {
                return View(cust);
            }
        }

    }
}