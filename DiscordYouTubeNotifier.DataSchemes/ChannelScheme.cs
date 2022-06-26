namespace DiscordYouTubeNotifier.DataSchemes
{
    public class ChannelScheme
    {
        /// <summary>
        /// The ID for a YouTube channel
        /// </summary>
        public string Topic { get; protected set; }
        /// <summary>
        /// A randomise secret to encode and decode traffic to pubsubhubbub
        /// </summary>
        public string Secret { get; protected set; }
    }
}
