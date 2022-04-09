using System.Net;

namespace DotStarkDemoApp.Models
{
    public class ServiceResponseModel
    {
        public bool IsSuccessStatusCode { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public string ReasonPhrase { get; set; }

        public string Message { get; set; }

        public dynamic Data { get; set; }
    }
}
