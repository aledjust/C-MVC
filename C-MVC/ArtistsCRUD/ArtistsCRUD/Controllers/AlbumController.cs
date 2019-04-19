using ArtistsCRUD.Abstract;
using ArtistsCRUD.Models;
using ArtistsCRUD.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ArtistsCRUD.Controllers
{
    public class AlbumController : Controller
    {
        #region Private Variables
        private IAlbumRepository _iAlbumRepository;

        #endregion

        #region Methods

        /// <summary>
        /// <param name="iAlbumRepository"></param>
        /// </summary>
        public AlbumController(IAlbumRepository iAlbumRepository)
        {
            this._iAlbumRepository = iAlbumRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateArtists(AlbumModel items)
        {
            ResponseObject respObject = new ResponseObject();
            respObject = _iAlbumRepository.CreateArtists(items);

            return Json(respObject, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetAlbums()
        {
            object resultList = new object();

            resultList = _iAlbumRepository.GetAlbums();

            return Json(resultList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetArtist(string id)
        {
            object resultList = new object();

            resultList = _iAlbumRepository.GetArtist(id);

            return Json(resultList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteArtist(string id)
        {
            object resultList = new object();

            resultList = _iAlbumRepository.DeleteArtists(id);

            return Json(resultList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateArtist(AlbumModel items)
        {
            object resultList = new object();

            resultList = _iAlbumRepository.UpdateArtists(items);

            return Json(resultList, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}