using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using FinalProject.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FinalProject.Data
{
    public class RestService
    {
        HttpClient client;
        string grant_type = "password";

        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-wwww-form-urlencoded"));

        }

        public async Task<Token> Login (User user)
        {
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("gran_type", grant_type));
            postData.Add(new KeyValuePair<string, string>("username", user.Username));
            postData.Add(new KeyValuePair<string, string>("password", user.Password));
            var content = new FormUrlEncodedContent(postData);
           
            var response = await PostResponseLogin<Token>(Constants.LoginUrl,content);
            DateTime dt = new DateTime();
            dt = DateTime.Today;
            response.Expire_date = dt.AddSeconds(response.expire_in);
            return response;
            
        }

        public async Task<T> PostResponseLogin<T>(string weburl, FormUrlEncodedContent content) where T:class
        {
            
            var response = await client.PostAsync(weburl, content);
            var jsonResult = response.Content.ReadAsStringAsync().Result;
            var responseObject = JsonConvert.DeserializeObject<T>(jsonResult);
            return responseObject;
        }

        public async Task<T> PostResponse<T>(string weburl, string jsonstring) where T: class
        {
            var Token = App.TokenDatabase.GetToken();
            string ContentType = "application/json";
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token.Access_Token);
            try
            {
                var result = await client.PostAsync(weburl, new StringContent(jsonstring, Encoding.UTF8, ContentType));

                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var JsonResult = result.Content.ReadAsStringAsync().Result;
                    try
                    {
                        var contentResp = JsonConvert.DeserializeObject<T>(JsonResult);
                        return contentResp;
                    }
                    catch { return null; }
                }
            }
            catch { return null; }
            return null;
        }

        public async Task<T> GetResponse<T>(String weburl) where T : class
        {
            var Token = App.TokenDatabase.GetToken();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token.Access_Token);

            try
            {
                var response = await client.GetAsync(weburl);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    var JsonResult = response.Content.ReadAsStringAsync().Result;
                    
                    try
                    {
                        var contentResp = JsonConvert.DeserializeObject<T>(JsonResult);
                        return contentResp;
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
            catch
            {
                return null;
            }
            
            return null;
        }
    }
}
