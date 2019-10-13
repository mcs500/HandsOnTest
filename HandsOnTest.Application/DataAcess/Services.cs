using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HandsOnTest.Application.DataAcess
{
    public abstract class Services
    {
        public static async Task<string> ClientGet(string url, string method, object parameter)
        {
            string result = "";
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(url);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                try
                {
                    var httpResponse = await httpClient.GetAsync(method + parameter);
                    if (httpResponse.Content != null)
                    {
                        result = await httpResponse.Content.ReadAsStringAsync();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                return result;
            }
        }

        public static async Task<string> ClientPost(string url, string method, object parameter)
        {
            string result = "";
            var httpcont = new StringContent(await Task.Run(() => JsonConvert.SerializeObject(parameter)), Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var httpResponse = await httpClient.PostAsync(url +  method, httpcont);
                    if (httpResponse != null)
                    {
                        result = await httpResponse.Content.ReadAsStringAsync();
                    }
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}