using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Configuration;
using ArtistsCRUD.Common;

namespace ArtistsCRUD.Services
{
    public sealed class ServiceClient
    {
        #region Private Variables

        private  HttpClient _httpClient = null;
        private string _baseApiAddress = ConfigurationManager.AppSettings[Constants.BASE_ArtistsAPI_ADDRESS];
        private readonly int _timeOut = Convert.ToInt32(ConfigurationManager.AppSettings[Constants.BASE_ArtistsAPI_TIMEOUT]);
        private string _mediaType = Constants.MEDIA_TYPE_HEADERVALUE;
        private readonly HttpClientHandler _handler = new HttpClientHandler();

        #endregion

        public HttpClient HttpClient()
        {
            try
            {
                _httpClient = new HttpClient(_handler);
                _httpClient.BaseAddress = new Uri(_baseApiAddress);
                _httpClient.Timeout = TimeSpan.FromMilliseconds(_timeOut);
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_mediaType));               
                return _httpClient;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}