using System.Collections.Generic;

namespace ArtistsCRUD.Services
{
    public class ResponseObject
    {
        public int CommandStatus { get; set; }       

        public ICollection<string> ValidationMessages { get; set; }
    }
}