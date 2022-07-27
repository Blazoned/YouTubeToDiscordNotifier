namespace DiscordYouTubeNotifier.Services;

public interface INotificationService
{
    /// <summary>
    /// Forward new YouTube notifications for a video to interested webhooks.
    /// </summary>
    /// <param name="video">The video meta-data</param>
    void ForwardTopicToWebhooks(VideoScheme<ChannelScheme> video);
    /// <summary>
    /// Send a test message to a webhook subscription.
    /// </summary>
    /// <param name="subscription">The subscription to test for.</param>
    void TestWebhookSubscription(SubscriptionScheme<SubscriberScheme, ChannelScheme> subscription);
}
