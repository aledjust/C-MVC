using System.Collections.Generic;
using System.Net.Http;
using ArtistsCRUD.Common;
using Newtonsoft.Json;

namespace ArtistsCRUD.Services
{
    /// <summary>
    /// To create  Http client set up to consume Webapi servie
    /// </summary>
    public class ServiceHelper
    {
        #region Public Properties
        public enum Verbs
        {
            GET, HEAD, POST, PUT, PATCH, DELETE, OPTIONS, TRACE
        }

        #endregion
        
        #region Service Utility Methods
        /// <summary>
        /// this method wil initize basic set up of api service
        /// </summary>
        /// <returns></returns>
        

        /// <summary>
        /// To serialize the objects in JSON formats
        /// </summary>
        /// <param name="modelObject"></param>
        /// <returns></returns>

        public static HttpContent SerializeToJSON(dynamic modelObject)
        {
            string jsonObject = JsonConvert.SerializeObject(modelObject);

            var contentData = new StringContent(jsonObject, System.Text.Encoding.UTF8, Constants.MEDIA_TYPE_HEADERVALUE);
            return contentData;
        }

        /// <summary>
        /// Query String Builder
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        public static string BuildQueryString(IDictionary<string, object> queryString)
        {
            var list = new List<string>();
            foreach (var item in queryString)
            {
                list.Add(item.Key + "=" + item.Value);
            }
            return "?" + string.Join("&", list);
        }

        #endregion
    }
}