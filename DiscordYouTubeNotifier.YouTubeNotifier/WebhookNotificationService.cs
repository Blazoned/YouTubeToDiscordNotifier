using DiscordYouTubeNotifier.DataSchemes;
using DiscordYouTubeNotifier.Services;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordYouTubeNotifier.YouTubeNotifier
{
    public class WebhookNotificationService: INotificationService
    {
        private IDataStoreFactory _dataStore;

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
