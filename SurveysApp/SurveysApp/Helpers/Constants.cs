using System;
using System.Collections.Generic;
using System.Text;

namespace SurveysApp.Helpers
{
    public partial class Constants
    {
        public struct WebServicesAPI
        {
            /// <summary>
            /// URI
            /// </summary>
            public const string API_URL = "http://localhost/api/";
            /// <summary>
            /// Login User EndPoint
            /// </summary>
            public const string Login = "User/login";
            /// <summary>
            /// Register User EndPoint
            /// </summary>
            public const string Register= "User/register";
        }
    }
}
