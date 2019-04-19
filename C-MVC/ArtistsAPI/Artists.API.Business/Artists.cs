using System.Collections.Generic;
using System.Linq;
using Album.API.Business.BusinessModel;
using Album.API.DataAccess;
using Album.API.DataAccess.EntityModel;
using Album.API.Utility.ServiceObjects;
using Newtonsoft.Json;

namespace Album.API.Business
{
    public class Artists : IArtists
    {
        private IArtistsDataAccess _ArtistsDataAccess;

        public Artists(IArtistsDataAccess artistsDataAccess)
        {
            _ArtistsDataAccess = artistsDataAccess;
        }
        public ResponseObject CreateArtists(ArtistsModel artistsModel)
        {
            var obj = JsonConvert.SerializeObject(artistsModel);
            Artist res = JsonConvert.DeserializeObject<Artist>(obj);

            var result = _ArtistsDataAccess.CreateArtists(res);

            return result;
        }

        public ResponseObject DeleteArtists(string id)
        {
            var result = _ArtistsDataAccess.DeleteArtists(id);

            return result;
        }

        public ResponseObject UpdateArtists(ArtistsModel artistsModel)
        {
            var obj = JsonConvert.SerializeObject(artistsModel);
            Artist res = JsonConvert.DeserializeObject<Artist>(obj);

            var result = _ArtistsDataAccess.UpdateArtists(res);

            return result;
        }

        public IEnumerable<ArtistsModel> GetAlbums()
        {
            IEnumerable<ArtistsModel> objs = null;

            var result = _ArtistsDataAccess.GetAlbums();

            if(result != null)
            {
                objs = result.Select(x => new ArtistsModel()
                {
                    ArtistID = x.ArtistID,
                    ArtistName = x.ArtistName,
                    AlbumName = x.AlbumName,
                    ImageURL = x.ImageURL,
                    ReleaseDate = x.ReleaseDate,
                    Price = x.Price,
                    SampleURL = x.SampleURL
                });
            }

            return objs;
        }

        public IEnumerable<ArtistsModel> GetArtist(string id)
        {
            IEnumerable<ArtistsModel> objs = null;

            var result = _ArtistsDataAccess.GetArtist(id);

            if (result != null)
            {
                objs = result.Select(x => new ArtistsModel()
                {
                    ArtistID = x.ArtistID,
                    ArtistName = x.ArtistName,
                    AlbumName = x.AlbumName,
                    ImageURL = x.ImageURL,
                    ReleaseDate = x.ReleaseDate,
                    Price = x.Price,
                    SampleURL = x.SampleURL
                });
            }

            return objs;
        }
    }
}
