namespace DiscordYouTubeNotifier.Services;

public interface ISubscriptionService
{
    /// <summary>
    /// Start a listener for notifications on a YouTube channel.
    /// </summary>
    /// <param name="topic">The channel id of the YouTube channel.</param>
    void CreateSubscription(string topic);
    /// <summary>
    /// Load all listeners required for webhook subscriptions.
    /// </summary>
    void LoadChannelSubscriptions();
    /// <summary>
    /// Remove an active listener for YouTube channel notifications.
    /// </summary>
    /// <param name="topic">The channel id of the YouTube channel.</param>
    void RemoveSubscription(string topic);
}
