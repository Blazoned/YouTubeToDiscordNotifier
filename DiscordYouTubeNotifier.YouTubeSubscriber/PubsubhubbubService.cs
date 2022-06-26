using DiscordYouTubeNotifier.DataSchemes;
using DiscordYouTubeNotifier.Services;
using DiscordYouTubeNotifier.Services.Options;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordYouTubeNotifier.YouTubeSubscriber
{
    public class PubsubhubbubService : BackgroundService, ISubscriptionService
    {
        #region Constants
        private const string PUBSUB_ADDRESS = "https://pubsubhubbub.appspot.com/subscribe";
        private const string MODE = "subscribe";
        private const string TOPIC_BASE = "https://www.youtube.com/xml/feeds/videos.xml?channel_id=";
        private const string VERIFY = "sync";
        #endregion

        #region Fields
        private IDataStoreFactory _dataStore;
        internal Dictionary<string, Channel> channels;
        

        public string CallbackUrl { get; private set; }
        private int _RefreshTime { get; set; }
        private int _LeaseTime { get => (int)(_RefreshTime*1.05); }
        #endregion

        public PubsubhubbubService(IDataStoreFactory dataStoreFactory, SubscriptionServiceOptions options)
        {
            this._dataStore = dataStoreFactory;
            this.channels = new Dictionary<string, Channel>();

            this.CallbackUrl = options.CallbackUrl;
            this._RefreshTime = options.RefreshTime;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            LoadListeners();

            while (!cancellationToken.IsCancellationRequested)
            {
                Console.WriteLine("Hellooooo.");
                await Task.Delay(5000, cancellationToken);
            }
        }

        public void CreateListener(string topic)
        {
            throw new NotImplementedException();
        }

        public void LoadListeners()
        {
            // throw new NotImplementedException();
            Console.WriteLine("Load..");
        }

        public void RemoveListener(string topic)
        {
            throw new NotImplementedException();
        }
    }
}
