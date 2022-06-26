using DiscordYouTubeNotifier.DataSchemes;
using DiscordYouTubeNotifier.Services.DataStoreService;
using System;
using System.Collections.Generic;

namespace DiscordYouTubeNotifier.DataStore
{
    public class SubscriberDataStore : ISubscriberDataStore
    {
        public void AddPseudonym(SubscriberScheme subscriber, Guid session)
        {
            throw new NotImplementedException();
        }

        public void CreateWebhook(string url)
        {
            throw new NotImplementedException();
        }

        public void DeleteWebhook(SubscriberScheme subscriber, Guid session)
        {
            throw new NotImplementedException();
        }

        public List<SubscriptionScheme<SubscriberScheme, ChannelScheme>> GetSubscriptions(Guid session)
        {
            throw new NotImplementedException();
        }

        public SubscriberScheme GetWebhook(Guid session)
        {
            throw new NotImplementedException();
        }

        public void LockWebhook(string secret, Guid session)
        {
            throw new NotImplementedException();
        }

        public Guid MakeSession(string url, string secret = null)
        {
            throw new NotImplementedException();
        }

        public void RemoveSubscription(SubscriptionScheme<SubscriberScheme, ChannelScheme> subscription, Guid session)
        {
            throw new NotImplementedException();
        }

        public void SetSubscriptionMessage(SubscriptionScheme<SubscriberScheme, ChannelScheme> subscription, Guid session)
        {
            throw new NotImplementedException();
        }

        public void SetSubscriptionPseudonym(SubscriptionScheme<SubscriberScheme, ChannelScheme> subscription, Guid session)
        {
            throw new NotImplementedException();
        }

        public SubscriptionScheme<SubscriberScheme, ChannelScheme> Subscribe(string topic, Guid session)
        {
            throw new NotImplementedException();
        }
    }
}
