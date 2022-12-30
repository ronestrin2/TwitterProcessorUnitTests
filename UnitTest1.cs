using System.Text.Json;
using REstrin_Demo2;
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.Distributed;

namespace TwitterProcessorUnitTests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public async Task TestMethod1()
    {
        string line = "{\"data\":{\"edit_history_tweet_ids\":[\"1608842924271497216\"],\"entities\":{\"urls\":[{\"start\":6,\"end\":29,\"url\":\"https://t.co/4tRJw8plcg\",\"expanded_url\":\"https://twitter.com/Furola_/status/1608842924271497216/photo/1\",\"display_url\":\"pic.twitter.com/4tRJw8plcg\",\"media_key\":\"3_1608842913336950785\"},{\"start\":6,\"end\":29,\"url\":\"https://t.co/4tRJw8plcg\",\"expanded_url\":\"https://twitter.com/Furola_/status/1608842924271497216/photo/1\",\"display_url\":\"pic.twitter.com/4tRJw8plcg\",\"media_key\":\"3_1608842913311764481\"},{\"start\":6,\"end\":29,\"url\":\"https://t.co/4tRJw8plcg\",\"expanded_url\":\"https://twitter.com/Furola_/status/1608842924271497216/photo/1\",\"display_url\":\"pic.twitter.com/4tRJw8plcg\",\"media_key\":\"3_1608842913315971073\"}]},\"id\":\"1608842924271497216\",\"text\":\"待ってるよ https://t.co/4tRJw8plcg\"}}";
        TwitterMessage? tweet = JsonSerializer.Deserialize(line, typeof(TwitterMessage)) as TwitterMessage;
        var clientFactory = new Mock<IHttpClientFactory>();
        var logger = new Mock<ILogger<TwitterStreamProcessor>>();
        var distributedCache = new Mock<IDistributedCache>();
        var twitterProcessor = new TwitterStreamProcessor(clientFactory.Object, logger.Object, distributedCache.Object, CancellationToken.None);
        await twitterProcessor.ProcessTweet(tweet);

    }
}
