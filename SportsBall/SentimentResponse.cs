using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SportsBall
{
    public class SentimentResponse
    {
        [JsonProperty(PropertyName = "documents")]
        public List<Sentiment> Sentiments { get; set; }
    }

    public class Sentiment
    {
        [JsonProperty(PropertyName = "score")]
        public string Score { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
    }
}