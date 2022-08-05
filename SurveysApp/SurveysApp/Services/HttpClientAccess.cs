using SurveysApp.Helpers;
using SurveysApp.Models;
using SurveysApp.Services.Interfaces;
using System; 
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.WebServices
{
    public class HttpClientAccess : IHttpClientAccess
    {

        private HttpClient HttpClientInstance;

        public HttpClientAccess()
        {
            HttpClientInstance = new HttpClient();
            HttpClientInstance.BaseAddress = new Uri(Constants.WebServicesAPI.API_URL);
        }

        /// <summary>
        ///     Helper para llamar a servicios Get y Post
        /// </summary>
        /// <param name="httpMethod"></param>
        /// <param name="uri"></param>
        /// <param name="contentType"></param>
        /// <param name="content"></param>
        /// <param name="sendProgress"></param>
        /// <returns></returns>
        private async Task<HttpResponseMessage> ExecuteService(HttpMethod httpMethod, string uri,
                                                               string contentType = null, object content = null)
        {
            // build service uri.
            var resource = new Uri(uri);

            // build request message.
            var request = new HttpRequestMessage(httpMethod, resource);

            // build content body.
            if (content != null && contentType != string.Empty)
            {
                request.Content = this.GetHttpContent(contentType, content);
            }

                return await this.HttpClientInstance.SendAsync(request);
        }




        /// <summary>
        ///     Retorna el http content body en base al content-type del mensaje.
        /// </summary>
        /// <param name="contentType"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        private HttpContent GetHttpContent(string contentType, object content = null)
        {
            // build content body.
            if (content != null)
            {
                switch (contentType.ToLower())
                {
                    case "application/octet-stream":
                        var data = content as byte[];
                        if (data != null)
                        {
                            var byteData = data;
                            Stream stream = new MemoryStream(byteData);
                            return new StreamContent(stream);
                        }
                        break;
                    case "application/json":
                    case "text/plain":
                    case "text/html":
                        var s = content as string;
                        if (s != null)
                        {
                            return new StringContent(s, Encoding.UTF8, contentType);
                        }
                        break;
                }
            }
            return null;
        }


        public async Task<IWebServiceResult> GetStringAsync(string uri)
        {
            try
            {
                var response = await this.ExecuteService(HttpMethod.Get, uri);
                return await this.GetWebServiceResultAsync(response); ;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IWebServiceResult> PostAsync(string uri, string contentType, object content)
        {
            try
            {
                var response = await this.ExecuteService(HttpMethod.Post, uri, contentType, content);
                
                return await this.GetWebServiceResultAsync(response);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private async Task<IWebServiceResult> GetWebServiceResultAsync(HttpResponseMessage response)
        {
            string content = await response.Content.ReadAsStringAsync();
            return new WebServiceResult { StatusCode = response.StatusCode, Content = content };
        }

        public async Task<IWebServiceResult> DeleteAsync(string uri)
        {
            try
            {
                var response = await this.HttpClientInstance.DeleteAsync(uri);
                return await this.GetWebServiceResultAsync(response);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
