using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPod.Models
{
    public class Podcast
    {
        [Key]
        public int PodcastId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public virtual List<Episode> Episodes { get; set; }
    }
}