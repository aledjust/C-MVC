using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ArtistsCRUD.Services
{
    /// <summary>
    /// Generic class To handle all Web service call -Get/Post/Put/Delete
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ArtistsAPIService
    {        
        /// <summary>
        /// Properties to get Srvice client
        /// </summary>
        public static HttpClient ArtistsHttpClient
        {
            get
            {                
                return new ServiceClient().HttpClient();               
            }
        }

        /// <summary>
        /// To make Api call based on api verb
        /// </summary>
        /// <param name="apiResource"></param>
        /// <param name="contentData"></param>
        /// <param name="verb"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> SendAPIRequest(string apiResource, HttpContent contentData, ServiceHelper.Verbs requestVerb)
        {

            string url = apiResource;

            switch (requestVerb)
            {
                case ServiceHelper.Verbs.GET:
                    var result = await ArtistsHttpClient.GetAsync(url).ConfigureAwait(false);
                    if (result.StatusCode == HttpStatusCode.Unauthorized)
                        return null;
                    else
                        return result;
                case ServiceHelper.Verbs.POST:
                    return await ArtistsHttpClient.PostAsync(url, contentData).ConfigureAwait(false);
                case ServiceHelper.Verbs.PUT:
                    return await ArtistsHttpClient.PutAsync(url, contentData).ConfigureAwait(false);
                case ServiceHelper.Verbs.DELETE:
                    return await ArtistsHttpClient.DeleteAsync(url).ConfigureAwait(false);
            }

            return null;

        }





    }
}