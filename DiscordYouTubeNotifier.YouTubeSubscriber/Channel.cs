using DiscordYouTubeNotifier.DataSchemes;
using System;

namespace DiscordYouTubeNotifier.YouTubeSubscriber
{
    internal class Channel:ChannelScheme
    {
        internal Channel(string topic)
            : this(topic, Guid.NewGuid().ToString()) { }

        internal Channel(string topic, string token)
        {
            this.Topic = topic;
            this.Secret = token;
        }
    }
}
