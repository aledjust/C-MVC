namespace Album.API.Utility.ServiceObjects
{
    public class Response<T> : ResponseObject
    {
        public T Records { get; set; }
    }
}
