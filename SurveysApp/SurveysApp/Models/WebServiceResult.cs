using SurveysApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveysApp.Models
{ 
    public class WebServiceResult : IWebServiceResult
    {
        public System.Net.HttpStatusCode StatusCode { get; set; }

        public bool Result { get { return StatusCode == System.Net.HttpStatusCode.OK; } }

        public object Content { get; set; }
    }
}
