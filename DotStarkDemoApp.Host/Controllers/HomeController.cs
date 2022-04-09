using DotStarkDemoApp.Services.Abstract;
using DotStarkDemoApp.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotStarkDemoApp.Host.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductServices productService = null;

        public HomeController() : this(new ProductServices()) { }

        public HomeController(IProductServices productService)
        {
            this.productService = productService;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
