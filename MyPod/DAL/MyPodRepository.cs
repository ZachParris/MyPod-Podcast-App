using MyPod.Models;
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


        public bool AddPodcastChannelToUser(string userId, string podcastId)
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

        public void AddBlogPost(string user, string blog_post)
        {
            ApplicationUser found_user = Context.Users.FirstOrDefault(u => u.Id == user);
            if (found_user != null)
            {
                Blog new_post = new Blog
                {
                    Post = blog_post,
                    BlogAuthor = found_user
                };
                Context.Posts.Add(new_post);
                Context.SaveChanges();
            }
        }

        public Blog RemoveBlogPost(int blogPost_id)
        {
            Blog found_post = Context.Posts.FirstOrDefault(p => p.PostId == blogPost_id);
            if (found_post != null)
            {
                Context.Posts.Remove(found_post);
                Context.SaveChanges();
            }
            return found_post;
        }

        public List<Blog> GetBlogPosts()
        {
            int i = 0;
            return Context.Posts.ToList();
        }

        public ApplicationUser GetAppUser(string user_id)
        {
            return Context.Users.SingleOrDefault(u => u.Id == user_id);
        }



    }
}