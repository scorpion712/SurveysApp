using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveysApp.Models
{
    public class User
    {
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
