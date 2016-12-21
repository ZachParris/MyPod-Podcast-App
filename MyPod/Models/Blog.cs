using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyPod.Models
{
    public class Blog
    {
        [Key]
        public int PostId { get; set; }
        public string Post { get; set; }
        public ApplicationUser BlogAuthor { get; set; }

    }
}