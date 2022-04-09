using DotStarkDemoApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace DotStarkDemoApp.Host.Controllers.Api
{
    [RoutePrefix("api/demo")]
    public class DemoController : ApiController
    {
        /// <summary>
        /// Get the user list having minima word in body.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-minima-users")]
        [ResponseType(typeof(List<UserDetailModel>))]
        public async Task<IHttpActionResult> GetMinimaUsersAsync()
        {
            var userList = new List<UserDetailModel>();

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync("https://jsonplaceholder.typicode.com/posts").Result;
                if (response.IsSuccessStatusCode)
                {
                    var customerJsonString = await response.Content.ReadAsStringAsync();
                    userList = JsonConvert.DeserializeObject<List<UserDetailModel>>(custome‌​rJsonString);

                    if (userList != null && userList.Any())
                    {
                        userList = userList.Where(u => u.Body.ToLower().Contains("minima")).ToList();

                        return Ok(new ServiceResponseModel()
                        {
                            IsSuccessStatusCode = true,
                            Message = string.Format("{0} records found with minima word in body.", userList.Count),
                            StatusCode = HttpStatusCode.OK,
                            ReasonPhrase = "Data Found",
                            Data = userList
                        });

                    }
                    else
                    {
                        return Ok(new ServiceResponseModel()
                        {
                            IsSuccessStatusCode = false,
                            Message = "Unable to find users with minima word.",
                            StatusCode = HttpStatusCode.NoContent,
                            ReasonPhrase = "No Data Found"
                        });
                    }
                }

                return null;
            }

            }

        /// <summary>
        /// Get the server time in ISO8601 format
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-server-time")]
        [ResponseType(typeof(ProductModel))]
        public IHttpActionResult GetserverTime()
        {
            // Universal Format Specifier (“u”)
            string serverTime = DateTime.UtcNow.ToUniversalTime().ToString("u").Replace(" ", "T");

            serverTime = serverTime.Split('T')[1];

            return Ok(new ServiceResponseModel()
            {
                IsSuccessStatusCode = true,
                Message = string.Concat("Current Server Time is: ", serverTime),
                StatusCode = HttpStatusCode.OK,
                Data = serverTime
            });
        }
    }
}
