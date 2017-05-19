using System;
using System.Collections.Generic;
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
        public string Get(int id)
        {
            return "value " + id.ToString();
        }

        // POST: api/Video
        public Video Post(Video video)
        {
            return video;
        }

        // PUT: api/Video/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Video/5
        public void Delete(int id)
        {
        }
    }
}
