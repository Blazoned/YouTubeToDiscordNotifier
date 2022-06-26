using DiscordYouTubeNotifier.DataSchemes;

namespace DiscordYouTubeNotifier.Services
{
    public interface INotificationService
    {
        void ForwardTopicToWebhooks(string topic, VideoScheme<ChannelScheme> video);
    }
}
