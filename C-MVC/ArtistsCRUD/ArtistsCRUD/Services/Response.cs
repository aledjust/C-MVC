namespace ArtistsCRUD.Services
{
    public class Response <T> : ResponseObject
    {
        public T Records { get; set; }
    }
}