using Album.API.Business.BusinessModel;
using Album.API.Utility.ServiceObjects;
using System.Collections.Generic;

namespace Album.API.Business
{
    public interface IArtists
    {
        ResponseObject CreateArtists(ArtistsModel artistsModel);
        ResponseObject DeleteArtists(string id);
        ResponseObject UpdateArtists(ArtistsModel artistsModel);

        IEnumerable<ArtistsModel> GetAlbums();
        IEnumerable<ArtistsModel> GetArtist(string id);
    }
}
