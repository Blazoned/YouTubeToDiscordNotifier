using DiscordYouTubeNotifier.DataSchemes;
using DiscordYouTubeNotifier.Services.DataStoreService;
using System;
using System.Collections.Generic;

namespace DiscordYouTubeNotifier.DataStore
{
    public class ChannelDataStore : IChannelDataStore
    {
        public VideoScheme<ChannelScheme> AddVideo(ChannelScheme channel, string videoId, string title, string author, DateTime date)
        {
            throw new NotImplementedException();
        }

        public ChannelScheme CreateChannel(string topic, string token)
        {
            throw new NotImplementedException();
        }

        public ChannelScheme GetChannel(string topic)
        {
            throw new NotImplementedException();
        }

        public List<ChannelScheme> GetChannels()
        {
            throw new NotImplementedException();
        }

        public List<SubscriptionScheme<SubscriberScheme, ChannelScheme>> GetSubscriptions(ChannelScheme channel)
        {
            throw new NotImplementedException();
        }

        public VideoScheme<ChannelScheme> GetVideo(string videoId)
        {
            throw new NotImplementedException();
        }

        public List<VideoScheme<ChannelScheme>> GetVideos(ChannelScheme channel, int amount = 1)
        {
            throw new NotImplementedException();
        }
    }
}
