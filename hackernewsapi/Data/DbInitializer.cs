using hackernews.Models;
using hackernewsapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hackernews.Data
{
   public static class DbInitializer
    {
      
        public static  void Initialize(hackernewsapiContext context) {
            seedPostType(context);
        }


        public static void seedPostType(hackernewsapiContext context) {
            
            if(context.PostType.Any())
            {
                return;
            }

            string[] types = { "story", "comment", "poll", "job", "pollopt" };

            foreach (string type in types)
            {
                context.PostType.Add(new PostType { Name = type });
            }
            context.SaveChanges();
        }

    }
}
