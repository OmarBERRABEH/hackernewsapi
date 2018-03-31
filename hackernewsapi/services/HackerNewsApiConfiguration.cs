using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hackernews.services
{
    public class HackerNewsApiConfiguration
    {

        public string Url { get; }
        public HackerNewsApiConfiguration(IConfiguration configuration)
        {
            this.Url = configuration.GetSection("hackernewapi:url").Value;
        }
        
    }
}
