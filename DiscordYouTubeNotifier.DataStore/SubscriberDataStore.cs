namespace DiscordYouTubeNotifier.DataStore;

public class SubscriberDataStore : ISubscriberDataStore
{
    public void AddPseudonym(SubscriberScheme subscriber, ref Guid session)
    {
        throw new NotImplementedException();
    }

    public void CreateWebhook(string url)
    {
        throw new NotImplementedException();
    }

    public void DeleteWebhook(SubscriberScheme subscriber, ref Guid session)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        Console.WriteLine("Subscriber Datastore not disposed.");
        GC.SuppressFinalize(this);
    }

    public List<SubscriptionScheme<SubscriberScheme, ChannelScheme>> GetSubscriptions(ref Guid session)
    {
        throw new NotImplementedException();
    }

    public SubscriberScheme GetWebhook(ref Guid session)
    {
        throw new NotImplementedException();
    }

    public void LockWebhook(string secret, ref Guid session)
    {
        throw new NotImplementedException();
    }

    public Guid MakeSession(string url, string secret = null)
    {
        throw new NotImplementedException();
    }

    public void RemoveSubscription(SubscriptionScheme<SubscriberScheme, ChannelScheme> subscription, ref Guid session)
    {
        throw new NotImplementedException();
    }

    public void SetSubscriptionMessage(SubscriptionScheme<SubscriberScheme, ChannelScheme> subscription, ref Guid session)
    {
        throw new NotImplementedException();
    }

    public void SetSubscriptionPseudonym(SubscriptionScheme<SubscriberScheme, ChannelScheme> subscription, ref Guid session)
    {
        throw new NotImplementedException();
    }

    public SubscriptionScheme<SubscriberScheme, ChannelScheme> Subscribe(string topic, ref Guid session)
    {
        throw new NotImplementedException();
    }
}
