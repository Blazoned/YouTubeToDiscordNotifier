using DiscordYouTubeNotifier.DataSchemes;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordYouTubeNotifier.YouTubeSubscriber
{
    /// <summary>
    /// Manages an active channel subscription request to the pubsubhubbub service.
    /// </summary>
    internal class Channel : ChannelScheme, IDisposable
    {
        // Constants required for communication with the youtube pubsubhubbub service.
        #region Constants
        private const string PUBSUB_ADDRESS = "https://pubsubhubbub.appspot.com/subscribe";
        private const string MODE = "subscribe";
        private const string TOPIC_BASE = "https://www.youtube.com/xml/feeds/videos.xml?channel_id=";
        private const string VERIFY = "sync";
        #endregion

        #region Fields
        /// <summary>
        /// The cancellation token source bound to the subscription service.
        /// </summary>
        private readonly CancellationTokenSource _ctSource;

        /// <summary>
        /// The lease time for this subscription in milliseconds.
        /// </summary>
        internal int LeaseTime { get; set; }
        #endregion

        #region Constructors
        internal Channel(string topic, int leaseTime, CancellationToken cancellationToken)
            : this(topic, Guid.NewGuid().ToString(), leaseTime, cancellationToken) { }

        internal Channel(ChannelScheme scheme, int leaseTime, CancellationToken cancellationToken)
            : this(scheme.Topic, scheme.Secret, leaseTime, cancellationToken) { }

        internal Channel(string topic, string token, int leaseTime, CancellationToken cancellationToken)
            : base(topic, token)
        {
            this.LeaseTime = leaseTime;
            this._ctSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            _ = StartSubscription(_ctSource.Token);
        }
        #endregion

        #region Methods
        // Starts this subscription request for the background service. Will be cancelled if subscription is cancelled, or if background services is being shutdown.
        private async Task StartSubscription(CancellationToken cancellationToken)
        {
            while(!cancellationToken.IsCancellationRequested)
            {
                Console.WriteLine(Topic + "; " +  LeaseTime + "; " + Secret);

                await Task.Delay(LeaseTime, cancellationToken);
            }
        }
        #endregion

        #region Functions
        public void Dispose()
        {
            _ctSource.Cancel();
        }
        #endregion
    }
}
