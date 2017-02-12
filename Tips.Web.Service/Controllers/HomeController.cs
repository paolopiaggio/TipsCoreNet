using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace Tip.Web.Service.Controllers
{
    public class HomeController : Controller
    {
        // 
        // GET: /Home/

        public IActionResult Index()
        {
            return View();
        }

        // 
        // GET: /Home/Welcome/ 

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}