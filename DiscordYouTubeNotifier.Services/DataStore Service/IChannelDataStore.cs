using DiscordYouTubeNotifier.DataSchemes;
using System;
using System.Collections.Generic;

namespace DiscordYouTubeNotifier.Services.DataStoreService
{
    public interface IChannelDataStore
    {
        #region Channel
        // Create
        /// <summary>
        /// Adds a required channel listener.
        /// </summary>
        /// <param name="topic">The channel id which to subscribe on.</param>
        /// <param name="token">The secret used for message traffic to and from pubsubhubbub.</param>
        /// <returns>The newly created channel subscription information.</returns>
        ChannelScheme CreateChannel(string topic, string token);
        // Read
        /// <summary>
        /// Gets the channel data for a topic.
        /// </summary>
        /// <param name="topic">The topic for which to retrieve information.</param>
        /// <returns>The channel info.</returns>
        ChannelScheme GetChannel(string topic);
        /// <summary>
        /// Gets the channels that require an active listener to be active.
        /// </summary>
        /// <returns>A list of all required channel subscriptions.</returns>
        List<ChannelScheme> GetChannels();
        // Update
            // Channel should never have to be updated manually.
        // Delete
            // Should be handled automagically after no subscriptions are associated with the channel (not counting initial creation of channel).
        #endregion

        #region Subscriptions
            // Only requires to read subscriptions for channels. Subscriber data store is responsible for managing subscriptions.
        // Create

        // Read
        /// <summary>
        /// Gets the active subscriptions for a channel.
        /// </summary>
        /// <returns>The webhook channel subscriptions.</returns>
        List<SubscriptionScheme<SubscriberScheme, ChannelScheme>> GetSubscriptions(ChannelScheme channel);
        // Update

        // Delete

        #endregion

        #region Videos
        // Create
        /// <summary>
        /// Adds a new video to the data store.
        /// </summary>
        /// <param name="channel">The associated channel.</param>
        /// <param name="videoId">The video id.</param>
        /// <param name="title">The video title.</param>
        /// <param name="author">The channel owner.</param>
        /// <param name="date">The publishing date.</param>
        /// <returns>The video information.</returns>
        VideoScheme<ChannelScheme> AddVideo(ChannelScheme channel, string videoId, string title, string author, DateTime date);
        // Read
        /// <summary>
        /// Gets video data based on the video id.
        /// </summary>
        /// <param name="videoId">The video id for the video which to load.</param>
        /// <returns>The video information.</returns>
        VideoScheme<ChannelScheme> GetVideo(string videoId);
        /// <summary>
        /// Gets the last uploaded videos for a channel.
        /// </summary>
        /// <param name="channel">The channel for which to load videos.</param>
        /// <param name="amount">The amount of latest videos to retrieve (default should be 1).</param>
        /// <returns>A list of videos from the channel.</returns>
        List<VideoScheme<ChannelScheme>> GetVideos(ChannelScheme channel, int amount = 1);
        // Update
            // Videos should never have to be updated manually.
        // Delete
            // Should be handled automagically after no channel is associated with the video anymore.
        #endregion
    }
}
