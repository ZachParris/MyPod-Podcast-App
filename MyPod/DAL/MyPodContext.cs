﻿using MyPod.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyPod.DAL
{
    public class MyPodContext : ApplicationDbContext
    {
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Podcast> Podcasts { get; set; }
        public virtual DbSet<Episode> Episode { get; set; }
    }
}