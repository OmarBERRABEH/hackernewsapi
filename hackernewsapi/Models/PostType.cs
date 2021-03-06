﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace hackernews.Models
{
    public class PostType
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public DateTime Created { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
