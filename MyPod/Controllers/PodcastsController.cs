using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MyPod.DAL;
using MyPod.Models;
using System.Web.Routing;

namespace MyPod.Controllers
{
    public class PodcastsController : ApiController
    {
        private MyPodContext db = new MyPodContext();

        // GET: api/Podcasts
        public IQueryable<Podcast> GetPodcasts()
        {
            return db.Podcasts;
        }

        // GET: api/Podcasts/5
        [ResponseType(typeof(Podcast))]
        public IHttpActionResult GetPodcast(int id)
        {
            Podcast podcast = db.Podcasts.Find(id);
            if (podcast == null)
            {
                return NotFound();
            }

            return Ok(podcast);
        }

        // PUT: api/Podcasts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPodcast(int id, Podcast podcast)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != podcast.PodcastId)
            {
                return BadRequest();
            }

            db.Entry(podcast).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PodcastExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Podcasts
        [ResponseType(typeof(Podcast))]
        public IHttpActionResult PostPodcast(Podcast podcast)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Podcasts.Add(podcast);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = podcast.PodcastId }, podcast);
        }

        // DELETE: api/Podcasts/5
        [ResponseType(typeof(Podcast))]
        public IHttpActionResult DeletePodcast(int id)
        {
            Podcast podcast = db.Podcasts.Find(id);
            if (podcast == null)
            {
                return NotFound();
            }

            db.Podcasts.Remove(podcast);
            db.SaveChanges();

            return Ok(podcast);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PodcastExists(int id)
        {
            return db.Podcasts.Count(e => e.PodcastId == id) > 0;
        }

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}