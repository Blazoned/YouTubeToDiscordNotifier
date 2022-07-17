using DiscordYouTubeNotifier.DataSchemes;
using DiscordYouTubeNotifier.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscordYouTubeNotifier.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index([FromServices]INotificationService notificationService)
        {
            notificationService.ForwardTopicToWebhooks(new VideoScheme<ChannelScheme>("", new ChannelScheme("", ""), "", "", DateTime.Now));
            return Ok("Hello world from a controller");
        }        
    }
}
