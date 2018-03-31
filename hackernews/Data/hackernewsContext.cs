using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using hackernews.Models;

namespace hackernews.Models
{
    public class hackernewsContext : DbContext
    {
        public hackernewsContext (DbContextOptions<hackernewsContext> options)
            : base(options)
        {
        }

        public DbSet<hackernews.Models.PostType> PostType { get; set; }

        public DbSet<hackernews.Models.Post> Post { get; set; }
    }
}
