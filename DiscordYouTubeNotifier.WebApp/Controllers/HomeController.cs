using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscordYouTubeNotifier.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Ok("Hello world from a controller");
        }        
    }
}
