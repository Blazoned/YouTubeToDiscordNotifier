namespace DiscordYouTubeNotifier.DataStore;

public class ChannelDataStore : IChannelDataStore
{
    public VideoScheme<ChannelScheme> AddVideo(ChannelScheme channel, string videoId, string title, string author, DateTime date)
    {
        Console.WriteLine("Video not added.");  // TODO: Implement
        return new VideoScheme<ChannelScheme>("", new ChannelScheme("", ""), "", "", DateTime.Now);
    }

    public ChannelScheme CreateChannel(string topic, string token)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        // TODO: Implement
        Console.WriteLine("Channel Datastore not disposed.");
    }

    public ChannelScheme GetChannel(string topic)
    {
        Console.WriteLine("Channel not retrieved.");  // TODO: Implement
        return new ChannelScheme("", "");
    }

    public List<ChannelScheme> GetChannels()
    {
        Console.WriteLine("Channels not retrieved.");  // TODO: Implement
        return new List<ChannelScheme>() { new ChannelScheme("17735p34k", "PotatoSalad") };
    }

    public List<SubscriptionScheme<SubscriberScheme, ChannelScheme>> GetSubscriptions(ChannelScheme channel)
    {
        Console.WriteLine("Subscriptions not retrieved");  // TODO: Implement
        return new List<SubscriptionScheme<SubscriberScheme, ChannelScheme>>() { new SubscriptionScheme<SubscriberScheme, ChannelScheme>(new SubscriberScheme("https://discord.com/api/webhooks/994734936034639943/dN6-36g1v49MqKDADZ3ccq11-ICLR3l851SR-kzDTj7J1m6vbiC-U-6vg5VtQpROvYO0", ""), new ChannelScheme("", ""), "", "[[title]] [title][body]") };
    }

    public VideoScheme<ChannelScheme> GetVideo(string videoId)
    {
        Console.WriteLine("Video not retrieved.");  // TODO: Implement
        return new VideoScheme<ChannelScheme>("", new ChannelScheme("", ""), "", "", DateTime.Now);
    }

    public List<VideoScheme<ChannelScheme>> GetVideos(ChannelScheme channel, int amount = 1)
    {
        throw new NotImplementedException();
    }
}
