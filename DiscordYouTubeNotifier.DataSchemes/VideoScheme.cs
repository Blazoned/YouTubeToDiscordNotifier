using System;

namespace DiscordYouTubeNotifier.DataSchemes
{
    public class VideoScheme<TChannel> where TChannel:ChannelScheme
    {
        /// <summary>
        /// ID of a published video.
        /// </summary>
        public string VideoId { get; protected set; }
        /// <summary>
        /// ID of the channel to which the video belongs.
        /// </summary>
        public TChannel Channel { get; protected set; }
        /// <summary>
        /// Title of the video.
        /// </summary>
        public string Title { get; protected set; }
        /// <summary>
        /// Author of the video.
        /// </summary>
        public string Author { get; protected set; }
        /// <summary>
        /// Date the video was published on.
        /// </summary>
        public DateTime Date { get; protected set; }

        /// <summary>
        /// The channel id of the channel to which the video belongs.
        /// </summary>
        public string Topic { get { return Channel.Topic; } }

        public VideoScheme(string videoId, TChannel channel, string title, string author, DateTime date)
        {
            this.VideoId = videoId;
            this.Channel = channel;
            this.Title = title;
            this.Author = author;
            this.Date = date;
        }
    }
}
