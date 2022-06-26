namespace DiscordYouTubeNotifier.Services
{
    public interface ISubscriptionService
    {
        /// <summary>
        /// Start a listener for notifications on a YouTube channel.
        /// </summary>
        /// <param name="topic">The channel id of the YouTube channel.</param>
        void CreateListener(string topic);
        /// <summary>
        /// Load all listeners required for webhook subscriptions.
        /// </summary>
        void LoadListeners();
        /// <summary>
        /// Remove an active listener for YouTube channel notifications.
        /// </summary>
        /// <param name="topic">The channel id of the YouTube channel.</param>
        void RemoveListener(string topic);
    }
}
