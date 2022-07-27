using DiscordYouTubeNotifier.Services;
using DiscordYouTubeNotifier.Services.Options;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace DiscordYouTubeNotifier.YouTubeSubscriber;

/// <summary>
/// Service to manage active subscriptions on YouTube channels via the YouTube pubsubhubbub service.
/// </summary>
public class PubsubhubbubService : BackgroundService, ISubscriptionService
{
    #region Fields
    /// <summary>
    /// The parent cancellation token for all subscription request handlers (see <see cref="Channel"/>).
    /// </summary>
    private CancellationToken _cancellationToken;

    /// <summary>
    /// The central data store system.
    /// </summary>
    private readonly IDataStoreFactory _dataStore;
    /// <summary>
    /// The lease time for individual subscriptions in milliseconds.
    /// </summary>
    private int _leaseTime;
    /// <summary>
    /// The list of active channel subscription requesting notifications from YouTube's pubsubhubbub.
    /// </summary>
    internal Dictionary<string, Channel> _channels;
    
    /// <summary>
    /// The url which onto the listener is available where the YouTube pubsubhubbub should send its notifications.
    /// </summary>
    public string CallbackUrl { get; private set; }
    /// <summary>
    /// The lease time for individual subscriptions in seconds.
    /// </summary>
    public int LeaseTime { get { return _leaseTime / 1000; } private set { _leaseTime = value * 1000;  } }
    #endregion

    public PubsubhubbubService(IDataStoreFactory dataStoreFactory, SubscriptionServiceOptions options)
    {
        this._dataStore = dataStoreFactory;
        this._channels = new Dictionary<string, Channel>();

        this.CallbackUrl = options.CallbackUrl;
        this.LeaseTime = options.RefreshTime;
    }

    // Save cancellation token, load channel subscriptions, link service token to all channel subscription managers.
    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        this._cancellationToken = cancellationToken;
        LoadChannelSubscriptions();

        while (!cancellationToken.IsCancellationRequested)
            await Task.Delay(_leaseTime, cancellationToken);
    }

    // Create new channel subscription for a topic (channel id) if it doesn't exist yet within this subscription request service.
    public void CreateSubscription(string topic)
    {
        if (!_channels.ContainsKey(topic))
        {
            Channel channel = new(topic, _leaseTime, _cancellationToken);
            _channels.Add(topic, channel);

            using var dataStore = _dataStore.GetChannelDataStore();
            dataStore.CreateChannel(channel.Topic, channel.Secret);
        }
    }

    // Load or reset channel subscriptions. Allows for a soft reboot if required.
    public void LoadChannelSubscriptions()
    {
        _channels.Clear();

        using var dataStore = _dataStore.GetChannelDataStore();
        dataStore.GetChannels().ForEach(channel => _channels.Add(channel.Topic, new Channel(channel, _leaseTime, _cancellationToken)));
    }

    // Deactivate a channel subscription (use if not needed anymore).
    public void RemoveSubscription(string topic)
    {
        if (_channels.Remove(topic, out Channel channel))
            channel.Dispose();
    }
}
