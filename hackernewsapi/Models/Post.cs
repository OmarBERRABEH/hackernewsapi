using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace hackernews.Models
{
    public class Post
    {
        public int ID { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("score")]
        public int Score { get; set; }
        public DateTime Created { get; set; }
        public string Url { get; set; }

        public int originid { get; set; }
        public int PostTypeID { get; set; }
        public virtual PostType PostType { get; set; }
    }
}
