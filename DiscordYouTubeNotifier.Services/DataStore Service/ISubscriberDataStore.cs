namespace DiscordYouTubeNotifier.Services.DataStoreService;

public interface ISubscriberDataStore: IDisposable
{
    #region Subscriber
    // Create
    /// <summary>
    /// Creates a new webhook to subscribe to notifications.
    /// </summary>
    /// <param name="url">The address of the webhook.</param>
    void CreateWebhook(string url);
    // Read
    /// <summary>
    /// Signs into a webhook.
    /// </summary>
    /// <param name="url">The webhook address.</param>
    /// <param name="secret">The optional password for the webhook.</param>
    /// <returns>A session token.</returns>
    Guid MakeSession(string url, string secret = null);
    /// <summary>
    /// Get the webhook details.
    /// </summary>
    /// <param name="session">The session token.</param>
    /// <returns>The session details.</returns>
    SubscriberScheme GetWebhook(ref Guid session);
    // Update
    /// <summary>
    /// Lock the account with a secret, or update an existing one.
    /// </summary>
    /// <param name="secret">The new password for the webhook.</param>
    /// <param name="session">The session token.</param>
    void LockWebhook(string secret, ref Guid session);
    /// <summary>
    /// Add a human readable name to the webhook.
    /// </summary>
    /// <param name="name">The webhook to update.</param>
    /// <param name="session">The session token.</param>
    void AddPseudonym(SubscriberScheme subscriber, ref Guid session);
    // Delete
    /// <summary>
    /// Purges the webhook and its subscriptions.
    /// </summary>
    /// <param name="subscriber">The webhook to remove.</param>
    /// <param name="session">The session token.</param>
    void DeleteWebhook(SubscriberScheme subscriber, ref Guid session);
    #endregion

    #region Subscriptions
    // Create
    /// <summary>
    /// Add a new channel subscription to the webhook.
    /// </summary>
    /// <param name="topic">The channel id to which to listen.</param>
    /// <param name="session">The session token.</param>
    /// <returns>The newly created subscription.</returns>
    SubscriptionScheme<SubscriberScheme, ChannelScheme> Subscribe(string topic, ref Guid session);
    // Read
    /// <summary>
    /// Get a webhook's associated subscriptions.
    /// </summary>
    /// <param name="session">The session token.</param>
    /// <returns>A list of subscriptions associated with the webhook.</returns>
    List<SubscriptionScheme<SubscriberScheme,ChannelScheme>> GetSubscriptions(ref Guid session);
    // Update
    /// <summary>
    /// Set or update the name for a subscription.
    /// </summary>
    /// <param name="subscription">The subscription to update.</param>
    /// <param name="session">The session token.</param>
    void SetSubscriptionPseudonym(SubscriptionScheme<SubscriberScheme, ChannelScheme> subscription, ref Guid session);
    /// <summary>
    /// Set or update the message for a subscription.
    /// </summary>
    /// <param name="subscription">The subscription to update.</param>
    /// <param name="session">The session token.</param>
    void SetSubscriptionMessage(SubscriptionScheme<SubscriberScheme,ChannelScheme> subscription, ref Guid session);
    // Delete
    /// <summary>
    /// Removes the subscription for the associated webhook.
    /// </summary>
    /// <param name="subscription">The subscription which to remove.</param>
    /// <param name="session">The session token.</param>
    void RemoveSubscription(SubscriptionScheme<SubscriberScheme, ChannelScheme> subscription, ref Guid session);
    #endregion
}
