using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MvcBootcamp.Web.Models;

namespace MvcBootcamp.Web.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public string Index()
        {
            return "Hello World!";
        }

        public string Browse(string category)
        {
            return HttpUtility.HtmlEncode("Hello from " + category);
        }

        public string News(int year, int month, int day)
        {
            return HttpUtility.HtmlEncode("Hello from Store.news with year: " 
                + year.ToString() + ", month: " + month.ToString() + ", day: " + day.ToString());
        }

        public ActionResult Home()
        {
            //return View();
            //return View("About");
            return View("~/Views/Home/About.cshtml");
        }

        public ActionResult DataSample()
        {
            ViewData["event"] = "MSP Bootcamp";
            ViewData["place"] = "Hotel Neo";

            ViewBag.events = "MSP Bootcamp";
            ViewBag.places = "Hotel Neo";

            var books = new List<string>() { "ASP.NET", "SQL Server", "Windows 10" };
            ViewBag.booklist = books;

            return View();
        }

        public ViewResult StronglyTypeView()
        {
            //var newcust = new models.customer()
            //{
            //    companyname = "native enterprise",
            //    city = "bandung"
            //};

            //return view(newcust);

            var listCust = new List<Customer>();
            listCust.Add(new Customer
            {
                CompanyName = "Native Enterprise",
                City = "Bandung"
            });
            listCust.Add(new Customer
            {
                CompanyName = "Microsoft Indonesia",
                City = "Jakarta"
            });

            return View(listCust);
        }

        public ViewResult listStronglyTypeView()
        {
            List<Models.Customer> newCust = new List<Models.Customer>()
            {
                new Models.Customer() {CompanyName = "Microsoft", City = "USA" }

            };

            return View(newCust);
        }
        
    }
}