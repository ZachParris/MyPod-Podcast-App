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

namespace MyPod.Controllers
{
    public class EpisodesController : ApiController
    {
        private MyPodContext db = new MyPodContext();
        private MyPodRepository repo = new MyPodRepository();

        // GET: api/Episodes
        public IQueryable<Episode> GetEpisode()
        {
            return db.Episodes;
        }

        // GET: api/Episodes/5
        [ResponseType(typeof(Episode))]
        public IHttpActionResult GetEpisode(int id)
        {
            Episode episode = db.Episodes.Find(id);
            if (episode == null)
            {
                return NotFound();
            }

            return Ok(episode);
        }

        // PUT: api/Episodes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEpisode(int id, Episode episode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != episode.EpisodeId)
            {
                return BadRequest();
            }

            db.Entry(episode).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EpisodeExists(id))
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

        // POST: api/Episodes
        [ResponseType(typeof(Episode))]
        public IHttpActionResult PostEpisode(Episode episode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Episodes.Add(episode);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = episode.EpisodeId }, episode);
        }

        // DELETE: api/Episodes/5
        [ResponseType(typeof(Episode))]
        public IHttpActionResult DeleteEpisode(int id)
        {
            Episode episode = db.Episodes.Find(id);
            if (episode == null)
            {
                return NotFound();
            }

            db.Episodes.Remove(episode);
            db.SaveChanges();

            return Ok(episode);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EpisodeExists(int id)
        {
            return db.Episodes.Count(e => e.EpisodeId == id) > 0;
        }
    }
}