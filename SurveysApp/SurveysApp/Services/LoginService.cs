using Newtonsoft.Json;
using SurveysApp.Helpers;
using SurveysApp.Models;
using SurveysApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SurveysApp.Services
{
    public class LoginService : ILoginService
    {
        private readonly IHttpClientAccess httpClientInstance; 

        public LoginService()
        {

            httpClientInstance = DependencyService.Get<IHttpClientAccess>(); 
        }

        public async Task<User> DoLogin(string username, string password)
        {
            // TODO use Token for secure auth
            var body = JsonConvert.SerializeObject(new User {Username=username,Password=password});
            var response = await httpClientInstance.PostAsync(Constants.WebServicesAPI.Login, "application/json", body);
            if (response == null)
            {
                return null;
            }
            if (!response.Result)
            {
                return null;
            }

            var userResponse = JsonConvert.DeserializeObject<User>(response.Content as string);
             
            return userResponse;
        }

        public async Task<User> DoRegistration(string username, string password)
        {  
            var body = JsonConvert.SerializeObject(new User { Username = username, Password = password });
            var response = await httpClientInstance.PostAsync(Constants.WebServicesAPI.Register, "application/json", body);
            if (response == null)
            {
                return null;
            }
            if (!response.Result)
            {
                return null;
            }

            var userResponse = JsonConvert.DeserializeObject<User>(response.Content as string);

            return userResponse;
        }
    }
}
