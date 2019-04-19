using System.Collections.Generic;

namespace Album.API.Utility.ServiceObjects
{
    public class ResponseObject
    {
        public int CommandStatus{ get; set; }
        public ICollection<string> ValidationMessages { get; set; }
    }
}
