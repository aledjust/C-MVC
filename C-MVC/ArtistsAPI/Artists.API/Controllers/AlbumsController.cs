using Album.API.Business;
using Album.API.Business.BusinessModel;
using System.Collections.Generic;
using System.Web.Http;

namespace Album.API.Controllers
{
    public class AlbumsController : ApiController
    {
        #region Private Members
        private IArtists _Artists;
        #endregion

        public AlbumsController(IArtists artists)
        {
            this._Artists = artists;
        }

        #region Method
        // GET api/<controller>
        public IHttpActionResult GetAlbums()
        {
            var result = _Artists.GetAlbums();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/Albums/GetArtist")]
        public IHttpActionResult GetArtist(string id)
        {
            var result = _Artists.GetArtist(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("api/Albums/CreateAlbum")]
        public IHttpActionResult CreateAlbum([FromBody]ArtistsModel ArtistsModel)
        {
            var result = _Artists.CreateArtists(ArtistsModel);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("api/Albums/UpdateArtists")]
        public IHttpActionResult UpdateArtists([FromBody]ArtistsModel ArtistsModel)
        {
            var result = _Artists.UpdateArtists(ArtistsModel);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/Albums/DeleteArtists")]
        public IHttpActionResult DeleteArtists(string id)
        {
            var result = _Artists.DeleteArtists(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        #endregion
    }
}