using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SurveysApp.Services.Interfaces
{
    public interface IHttpClientAccess
    {

        /// <summary>
        /// Exec Http POST Method and return content as string
        /// </summary>
        /// <param name="uri">
        /// </param>
        /// <param name="contentType">
        /// </param>
        /// <param name="content">
        /// </param>
        /// <returns></returns>
        Task<IWebServiceResult> PostAsync(string uri, string contentType, object content);

        /// <summary>
        /// Exec Http GET Method and return content as string
        /// </summary>
        /// <param name="uri">
        /// </param>
        /// <returns></returns>
        Task<IWebServiceResult> GetStringAsync(string uri);

        /// <summary>
        /// Exec Http DELETE  Method
        /// </summary>
        /// <param name="uri">
        /// </param>
        /// <returns></returns>
        Task<IWebServiceResult> DeleteAsync(string uri);

    }
}
