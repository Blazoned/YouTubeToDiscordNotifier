using DiscordYouTubeNotifier.DataSchemes;
using DiscordYouTubeNotifier.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;

namespace DiscordYouTubeNotifier.YouTubeNotifier;

/// <summary>
/// Service to manage sending out notifications for YouTube channels to all webhooks having an active subscription to those specified YouTube channels.
/// </summary>
public class WebhookNotificationService: INotificationService
{
    private readonly IDataStoreFactory _dataStore;

    public WebhookNotificationService(IDataStoreFactory dataStore)
    {
        this._dataStore = dataStore;
    }

    public void ForwardTopicToWebhooks(VideoScheme<ChannelScheme> video)
    {
        try
        {
            using var dataStore = _dataStore.GetChannelDataStore();

            // Only execute if video hasn't been registered yet
            if (dataStore.GetVideo(video.VideoId) is null)
                return;

            // Get channel and register video to channel
            ChannelScheme channel = dataStore.GetChannel(video.Topic);
            dataStore.AddVideo(channel, video.VideoId, video.Title, video.Author, video.Date);

            // Get webhooks registered/subscribed to channel and process and send messages to each of them
            foreach (var subscription in dataStore.GetSubscriptions(channel))
            {
                ForwardTopicToWebhook(subscription, video);
            }
        }
        catch (AbandonedMutexException e)
        {
            // Channel Doesn't Exist
            Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            // Database not working
            Console.WriteLine(e.Message);
        }
    }

    public void TestWebhookSubscription(SubscriptionScheme<SubscriberScheme, ChannelScheme> subscription)
    {
        using var dataStore = _dataStore.GetChannelDataStore();
        ForwardTopicToWebhook(subscription, dataStore.GetVideos(subscription.Channel).FirstOrDefault());
    }

    private void ForwardTopicToWebhook(SubscriptionScheme<SubscriberScheme, ChannelScheme> subscription, VideoScheme<ChannelScheme> video)
    {
        try
        {
            // Parse saved message
            MessageProcessor messageProcessor = new(subscription.Message, new Dictionary<string, string>() { { "Title", "Hello there.\\n\\n" },
                                                                                                             { "Body", "Testing testing, I'm just suggesting you and I may just be the best thing." } });
            // TODO: Add actually features to the processor/parser. Include scenario where video is null (as can be the case for testing a subscription with 0 uploaded videos yet).


            // Send message to webhook
            string webhook = subscription.Webhook;

            HttpClient client = new();

            HttpRequestMessage message = new(HttpMethod.Post, webhook)
            {
                Content = new StringContent($"{{\"content\": \"{messageProcessor.Message}\"}}", Encoding.UTF8, "application/json"),
            };

            HttpResponseMessage response = client.Send(message);
            Console.WriteLine(response.StatusCode);
        }
        catch (AbandonedMutexException e)
        {
            // Message not processable
            Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            // Webhook not addressable
            Console.WriteLine(e.Message);
        }
    }
}
