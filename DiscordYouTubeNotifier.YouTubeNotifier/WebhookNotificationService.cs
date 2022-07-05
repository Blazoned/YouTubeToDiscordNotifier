using DiscordYouTubeNotifier.DataSchemes;
using DiscordYouTubeNotifier.Services;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordYouTubeNotifier.YouTubeNotifier
{
    /// <summary>
    /// Service to manage sending out notifications for YouTube channels to all webhooks having an active subscription to those specified YouTube channels.
    /// </summary>
    public class WebhookNotificationService: INotificationService
    {
        private readonly IDataStoreFactory _dataStore;

        public WebhookNotificationService(IDataStoreFactory dataStore)
        {
            this._dataStore = dataStore;
        }

        public void ForwardTopicToWebhooks(string topic, VideoScheme<ChannelScheme> video)
        {
            throw new NotImplementedException();
        }
    }
}
