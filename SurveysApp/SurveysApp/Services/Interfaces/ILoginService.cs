using SurveysApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SurveysApp.Services.Interfaces
{
    public interface ILoginService
    {
        Task<User> DoLogin(string username, string password);
        Task<User> DoRegistration(string username, string password);
    }
}
