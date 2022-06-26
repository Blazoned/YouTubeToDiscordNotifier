using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DiscordYouTubeNotifier.WebApp.Areas.API.Models;

namespace DiscordYouTubeNotifier.WebApp.Areas.API.Controllers
{
    public class BaseController : Controller
    {
        public IActionResult Ungreet([FromQuery]GreetingModel greeting)
        {
            return Ok(greeting);
        }

        public IActionResult Greet(string data)
        {
            return View(new GreetingModel { Username = data });
        }
    }
}
