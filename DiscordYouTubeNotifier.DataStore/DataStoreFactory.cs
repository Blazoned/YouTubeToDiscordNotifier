using DiscordYouTubeNotifier.Services;
using DiscordYouTubeNotifier.Services.DataStoreService;

namespace DiscordYouTubeNotifier.DataStore
{
    public class DataStoreFactory : IDataStoreFactory
    {
        public IChannelDataStore GetChannelDataStore()
        {
            return new ChannelDataStore();
        }

        public ISubscriberDataStore GetSubscriberDataStore()
        {
            return new SubscriberDataStore();
        }
    }
}
