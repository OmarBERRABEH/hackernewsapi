using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System.Text;
using hackernews.Models;
using Microsoft.EntityFrameworkCore;

namespace hackernews.services
{
    public class HackerNewsService
    {
        HackerNewsApiConfiguration configuration;
        IConfiguration appConfiguration;
        hackernewsContext context;

        public HackerNewsService(IConfiguration appConfiguration,  hackernewsContext context, HackerNewsApiConfiguration hackerNewsApiConfiguration)
        {
            this.appConfiguration = appConfiguration;
            this.configuration = hackerNewsApiConfiguration;
            this.context = context;
        }
        public async void getNews()
        {

            string url = urlBuild("top");
            string content =  await this.makeRequest(url);
            string[] ids = toJson<string[]>(content);
            if(ids.Length > 0)
            {
                PostType postType =  await this.context.PostType.FirstOrDefaultAsync(pt => pt.Name == "story");

                // get url of the detail
                string detailUrl = this.urlBuild("detail");

                // get post type
                foreach (string id in  ids)
                {
                    this.getDetail(string.Format(detailUrl, id), postType);
                }
            }
           
        }
        private async void getDetail(string url, PostType postType)
        {
           string content =  await this.makeRequest(url);
           Post post = toJson<Post>(content);
           post.PostType = postType;
            this.context.Post.Add(post);
            this.context.SaveChanges();
        }
        private async Task<string> makeRequest(string url)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }
        private T toJson<T>(string content)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(content);
        }
        private string urlBuild(string type)
        {
            string urlSuffix;
            switch(type)
            {
                case "top":
                    urlSuffix = "topstories.json";
                    break;
                case "detail":
                    urlSuffix = "item/{0}.json";
                    break;
                default:
                    urlSuffix = "jobstories.json";
                    break;
            }
            return this.configuration.Url + urlSuffix;
        }
       
    }
}
