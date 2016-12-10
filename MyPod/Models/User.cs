using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyPod.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public ApplicationUser BaseUser { get; set; }
        public virtual List<Podcast> Subscriptions { get; set; }
        public virtual List<Message> Messages { get; set; }

    }
}