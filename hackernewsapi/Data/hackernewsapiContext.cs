using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using hackernews.Models;

namespace hackernewsapi.Models
{
    public class hackernewsapiContext : DbContext
    {
        public hackernewsapiContext (DbContextOptions<hackernewsapiContext> options)
            : base(options)
        {
        }

        public DbSet<hackernews.Models.PostType> PostType { get; set; }

        public DbSet<hackernews.Models.Post> Post { get; set; }
    }
}
