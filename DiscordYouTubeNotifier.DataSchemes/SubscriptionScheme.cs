namespace DiscordYouTubeNotifier.DataSchemes
{
    public class SubscriptionScheme<TSubscriber, TChannel>
        where TSubscriber:SubscriberScheme
        where TChannel:ChannelScheme
    {
        /// <summary>
        /// The webhook connected to the subscription.
        /// </summary>
        public TSubscriber Subscriber { get; protected set; }
        /// <summary>
        /// The channel connected to the subscription.
        /// </summary>
        public TChannel Channel { get; protected set; }
        /// <summary>
        /// A pseudonym for the subscription. Default should be the channel name associated with the subscription.
        /// </summary>
        public string Name { get; protected set; }
        /// <summary>
        /// The custom message body.
        /// </summary>
        public string Message { get; protected set; }

        public SubscriptionScheme(TSubscriber subscriber, TChannel channel, string name, string message)
        {
            this.Subscriber = subscriber;
            this.Channel = channel;
            this.Name = name;
            this.Message = message;
        }
    }
}
