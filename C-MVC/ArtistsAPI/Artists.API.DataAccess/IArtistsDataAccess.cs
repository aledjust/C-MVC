using Album.API.DataAccess.EntityModel;
using Album.API.Utility.ServiceObjects;
using System.Collections.Generic;

namespace Album.API.DataAccess
{
    public interface IArtistsDataAccess
    {
        ResponseObject CreateArtists(Artist artist);
        ResponseObject DeleteArtists(string id);
        ResponseObject UpdateArtists(Artist artist);

        IEnumerable<Artist> GetAlbums();
        IEnumerable<Artist> GetArtist(string id);
    }
}
