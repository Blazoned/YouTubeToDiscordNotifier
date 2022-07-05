namespace DiscordYouTubeNotifier.DataSchemes
{
    public class SubscriberScheme
    {
        /// <summary>
        /// The webhook address. Presumed to be from Discord, but purposefully left ambiguous.
        /// </summary>
        public string Webhook { get; protected set; }
        /// <summary>
        /// Custom name for webhook, for the user to more easily identify which webhook they are editting.
        /// </summary>
        public string Name { get; protected set; }

        public SubscriberScheme(string webhook, string name)
        {
            this.Webhook = webhook;
            this.Name = name;
        }
    }
}
