using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Videos.Models;

namespace Videos.Controllers
{ 
    public class VideosController : ApiController
    {
        private VideoDb _db;

        public VideosController()
        {
            _db = new VideoDb();
            _db.Configuration.ProxyCreationEnabled = false;
        }
        // GET: api/Video
        public IEnumerable<Video> GetAllVideos()
        {
            return _db.Videos;
        }

        // GET: api/Video/5
        public Video GetVideo(int id)
        {
            var video = _db.Videos.Find(id);

            if (video == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return video;
        }

        // POST: api/Video
        public HttpResponseMessage PostVideo(Video video)
        {
            if(ModelState.IsValid)
            {
                _db.Videos.Add(video);
                _db.SaveChanges();
                var response = Request.CreateResponse(HttpStatusCode.Created, video);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = video.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // PUT: api/Video/5
        public HttpResponseMessage PutVideo(int id, Video video)
        {
            if (ModelState.IsValid && id == video.Id)
            {
                _db.Entry(video).State = EntityState.Modified;
                try
                {
                    _db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                return Request.CreateResponse(HttpStatusCode.OK, video);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE: api/Video/5
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage response = null;
            Video video = _db.Videos.Find(id);
            if (video == null)
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            }
            _db.Videos.Remove(video);
            try
            {
                _db.SaveChanges();
                response = Request.CreateResponse(HttpStatusCode.OK, video);
            }
            catch (DbUpdateConcurrencyException)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return response;
        }
    }
}
