using System.Net;

namespace SurveysApp.Services.Interfaces
{ 
    public interface IWebServiceResult
    {
        object Content { get; set; }
        HttpStatusCode StatusCode { get; set; }

        bool Result { get; }
    }
}