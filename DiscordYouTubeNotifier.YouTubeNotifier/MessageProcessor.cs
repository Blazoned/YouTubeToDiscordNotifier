namespace DiscordYouTubeNotifier.YouTubeNotifier;

/// <summary>
/// A message processor used to replace features in a message or otherwise manipulate such messages.
/// </summary>
internal class MessageProcessor
{
    /// <summary>
    /// The message being processed.
    /// </summary>
    internal string Message { get; private set; }
    /// <summary>
    /// The feature set being replaced in the message.
    /// </summary>
    internal Dictionary<string, string> FeatureSet { get; private set; }

    /// <summary>
    /// Instantiate a message processor to replace features in a message.
    /// </summary>
    /// <param name="message">The message to process.</param>
    internal MessageProcessor(string message)
    {
        this.Message = message;
    }

    /// <summary>
    /// Instantiate a message processor to replace features in a message. Processes on instantiation.
    /// </summary>
    /// <param name="message">The message to process.</param>
    /// <param name="featureSet">The set of features used in processing.</param>
    internal MessageProcessor(string message, Dictionary<string, string> featureSet) 
        : this(message)
    {
        this.FeatureSet = featureSet;
        this.ProcessesFeatures();
    }

    /// <summary>
    /// Process the message with a pre-defined set of features.
    /// </summary>
    /// <returns>Returns the processed message.</returns>
    private void ProcessesFeatures()
    {
        ProcessesFeatures(FeatureSet);
    }

    /// <summary>
    /// Process the message with a set of features.
    /// </summary>
    /// <param name="featureSet">The features to replace in the message.</param>
    /// <returns>Returns the processed message.</returns>
    internal string ProcessesFeatures(Dictionary<string, string> featureSet)
    {
        foreach (KeyValuePair<string, string> feature in featureSet) {
            // Use special escape for case-incensitive replace method
            //      No one could possibly need to use this set of characters in a human readable message to Discord webhook, 
            //      unless they want to smitten down by the heavens would they'd complain about it. Death shall befall on them.
            string leftFeatureEscape = "{{{{{{{{{{";
            string rightFeatureEscape = "}}}}}}}}}}";

            Message = Message.Replace("[[", leftFeatureEscape)
                             .Replace("]]", rightFeatureEscape)
                             .Replace($"[{feature.Key}]", feature.Value, StringComparison.InvariantCultureIgnoreCase)
                             .Replace(leftFeatureEscape, "[")
                             .Replace(rightFeatureEscape, "]");
        }

        foreach (string feature in featureSet.Keys)
        {
            if (FeatureSet.ContainsKey(feature)) 
                FeatureSet[feature] = featureSet[feature];
            else 
                FeatureSet.Add(feature, featureSet[feature]);
        }

        return Message;
    }
}
