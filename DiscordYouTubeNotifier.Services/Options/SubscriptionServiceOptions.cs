using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordYouTubeNotifier.Services.Options
{
    public class SubscriptionServiceOptions
    {
        /// <summary>
        /// The local API url to which to refer the pubsubhubbub for sending notifications.
        /// </summary>
        public string CallbackUrl { get; set; }
        /// <summary>
        /// The lease time for notifications on YouTube topics.
        /// </summary>
        public int RefreshTime { get; set; }
    }
}
