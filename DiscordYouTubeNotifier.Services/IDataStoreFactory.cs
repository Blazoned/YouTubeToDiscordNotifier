namespace DiscordYouTubeNotifier.Services;

public interface IDataStoreFactory
{
    public ISubscriberDataStore GetSubscriberDataStore();
    public IChannelDataStore GetChannelDataStore();
}
