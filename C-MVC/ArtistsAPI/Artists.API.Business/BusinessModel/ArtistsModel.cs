namespace Album.API.Business.BusinessModel
{
    public class ArtistsModel
    {
        public int ArtistID { get; set; }
        public string ArtistName { get; set; }
        public string AlbumName { get; set; }
        public string ImageURL { get; set; }
        public System.DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public string SampleURL { get; set; }
    }
}
