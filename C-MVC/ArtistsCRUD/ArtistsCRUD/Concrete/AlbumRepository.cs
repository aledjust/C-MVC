using ArtistsCRUD.Abstract;
using ArtistsCRUD.Common;
using ArtistsCRUD.Models;
using ArtistsCRUD.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace ArtistsCRUD.Concrete
{
    public class AlbumRepository : ArtistsAPIService, IAlbumRepository
    {
        #region Private Members
        private HttpContent _httpContent;
        private string _apiResource;
        private HttpResponseMessage _responseMessage;
        #endregion

        #region Constructor
        public AlbumRepository()
        {
            _apiResource = APIMethodsAddressConstants.ALBUM;
        }
        #endregion
        public ResponseObject CreateArtists(AlbumModel albumModel)
        {
            _httpContent = ServiceHelper.SerializeToJSON(albumModel);

            _responseMessage = ArtistsAPIService.SendAPIRequest(_apiResource + "/CreateAlbum/", _httpContent, ServiceHelper.Verbs.POST).Result;
            
            if (_responseMessage.IsSuccessStatusCode)
            {
                var responseData = _responseMessage.Content.ReadAsStringAsync().Result;

                return responseData == null ? null : JsonConvert.DeserializeObject<ResponseObject>(responseData);
            }
            else
            {
                return null;
            }
        }

        public ResponseObject DeleteArtists(string id)
        {
            Dictionary<string, object> queryString = new Dictionary<string, object>();
            queryString.Add("id", id);

            _responseMessage = ArtistsAPIService.SendAPIRequest(_apiResource + "/DeleteArtists/" + ServiceHelper.BuildQueryString(queryString), null, ServiceHelper.Verbs.GET).Result;

            if (_responseMessage.IsSuccessStatusCode)
            {
                var responseData = _responseMessage.Content.ReadAsStringAsync().Result;

                return responseData == null ? null : JsonConvert.DeserializeObject<ResponseObject>(responseData);
            }
            else
            {
                return null;
            }
        }       

        public ResponseObject UpdateArtists(AlbumModel albumModel)
        {
            _httpContent = ServiceHelper.SerializeToJSON(albumModel);

            _responseMessage = ArtistsAPIService.SendAPIRequest(_apiResource + "/UpdateArtists/", _httpContent, ServiceHelper.Verbs.POST).Result;

            if (_responseMessage.IsSuccessStatusCode)
            {
                var responseData = _responseMessage.Content.ReadAsStringAsync().Result;

                return responseData == null ? null : JsonConvert.DeserializeObject<ResponseObject>(responseData);
            }
            else
            {
                return null;
            }
        }

        public object GetAlbums()
        {
            _responseMessage = ArtistsAPIService.SendAPIRequest(_apiResource+"/GetAlbums/", null, ServiceHelper.Verbs.GET).Result;
            if (_responseMessage.IsSuccessStatusCode)
            {
                string responseData = _responseMessage.Content.ReadAsStringAsync().Result.ToString();

                if (responseData != null)
                {
                    return responseData;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public object GetArtist(string id)
        {
            Dictionary<string, object> queryString = new Dictionary<string, object>();
            queryString.Add("id", id);

            _responseMessage = ArtistsAPIService.SendAPIRequest(_apiResource + "/GetArtist/" + ServiceHelper.BuildQueryString(queryString), null, ServiceHelper.Verbs.GET).Result;
            if (_responseMessage.IsSuccessStatusCode)
            {
                string responseData = _responseMessage.Content.ReadAsStringAsync().Result.ToString();

                if (responseData != null)
                {
                    return responseData;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}