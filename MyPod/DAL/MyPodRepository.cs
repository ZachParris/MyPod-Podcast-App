﻿using MyPod.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPod.DAL
{
    public class MyPodRepository
    {
        public MyPodContext Context { get; set; }

        public MyPodRepository(MyPodContext _context)
        {
            Context = _context;
        }

        public MyPodRepository()
        {
            Context = new MyPodContext();
        }

        public object GetPodcasts()
        {
            return Context.Users.Select(u => u.Id);
        }

        public void AddPodcast(Podcast new_podcast)
        {
            Context.Podcasts.Add(new_podcast);
            Context.SaveChanges();
        }

        public bool AddPodcastToUser(string userId, string podcastId)
        {
            Podcast found_podcast = Context.Podcasts.FirstOrDefault(p => p.Title == podcastId);
            ApplicationUser found_user = Context.Users.FirstOrDefault(u => u.Id == userId);
            if (found_podcast != null && found_user != null)
            {
                found_user.Subscriptions.Add(found_podcast);
                Context.SaveChanges();
                return true;
            }else
            {
                return false;   
            }
           
        }
    }
}