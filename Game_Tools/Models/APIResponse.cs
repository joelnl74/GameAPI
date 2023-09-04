using System.Net;

namespace Tools.Models
{
    public class APIResponse
    {
        public HttpStatusCode statusCode { get; set; }
        public bool isSucces { get; set; }
        public List<string> errorMessages { get; set; }
        public object result { get; set; }
    }
}
