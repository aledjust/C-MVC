using System;
using System.Collections.Generic;
using System.Linq;
using Album.API.DataAccess.EntityModel;
using Album.API.Utility;
using Album.API.Utility.ServiceObjects;

namespace Album.API.DataAccess
{
    public class ArtistsDataAccess : CommonDataAccess, IArtistsDataAccess
    {
        public ResponseObject CreateArtists(Artist artist)
        {
            ResponseObject responseObject = new ResponseObject();

            IList<string> adjMessages = new List<string>();
            using (dbmusicEntities Dbc = DBSessionFactory)
            {
                try
                {
                    Dbc.Artists.Add(artist);
                    responseObject.CommandStatus = Dbc.SaveChanges();
                    adjMessages.Add(Constant.Success_Message);
                }
                catch (Exception ex)
                {
                    adjMessages.Add(Constant.Failure_Message);
                    adjMessages.Add(ex.Message);
                }

                responseObject.ValidationMessages = adjMessages;
            }

            return responseObject;
        }

        public ResponseObject DeleteArtists(string id)
        {
            ResponseObject responseObject = new ResponseObject();

            IList<string> adjMessages = new List<string>();
            using (dbmusicEntities Dbc = DBSessionFactory)
            {
                try
                {
                    int idD = Convert.ToInt32(id);
                    Dbc.Artists.Remove(Dbc.Artists.Single(x => x.ArtistID == idD));
                    responseObject.CommandStatus = Dbc.SaveChanges();
                    adjMessages.Add(Constant.Success_Message);
                }
                catch (Exception ex)
                {
                    adjMessages.Add(Constant.Failure_Message);
                    adjMessages.Add(ex.Message);
                }

                responseObject.ValidationMessages = adjMessages;
            }

            return responseObject;
        }

        public ResponseObject UpdateArtists(Artist artist)
        {
            ResponseObject responseObject = new ResponseObject();

            IList<string> adjMessages = new List<string>();
            using (dbmusicEntities Dbc = DBSessionFactory)
            {
                try
                {
                    var result = Dbc.Artists.SingleOrDefault(x => x.ArtistID == artist.ArtistID);

                    if(result == null)
                    {
                        adjMessages.Add(Constant.Failure_Message);
                        adjMessages.Add("Data Not Found");
                    }

                    result.AlbumName = artist.AlbumName;
                    result.ArtistName = artist.ArtistName;
                    result.ImageURL = artist.ImageURL;
                    result.Price = artist.Price;
                    result.ReleaseDate = artist.ReleaseDate;
                    result.SampleURL = artist.SampleURL;

                    responseObject.CommandStatus = Dbc.SaveChanges();
                    adjMessages.Add(Constant.Success_Message);
                }
                catch (Exception ex)
                {
                    adjMessages.Add(Constant.Failure_Message);
                    adjMessages.Add(ex.Message);
                }

                responseObject.ValidationMessages = adjMessages;
            }

            return responseObject;
        }

        public IEnumerable<Artist> GetAlbums()
        {
            IEnumerable<Artist> objs = null;

            using (dbmusicEntities Dbc = DBSessionFactory)
            {
                try
                {
                    objs = Dbc.Artists.Select(x => x).ToList();
                }
                catch (Exception ex)
                {
                    
                }
            }

            return objs;
        }

        public IEnumerable<Artist> GetArtist(string id)
        {
            IEnumerable<Artist> objs = null;

            using (dbmusicEntities Dbc = DBSessionFactory)
            {
                try
                {
                    int idD = Convert.ToInt32(id);
                    objs = Dbc.Artists.Where(x => x.ArtistID == idD).Select(y => y).ToList();
                }
                catch (Exception ex)
                {

                }
            }

            return objs;
        }
    }
}
