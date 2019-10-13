using Spring.Http;
using Spring.Rest.Client;
using System;
using System.Configuration;
using HandsOnTest.Support.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spring.Http.Converters.Json;
using Spring.Http.Client;
using System.Net;

namespace HandsOnTest.DA.Services
{
    internal class ClientMASGLOBAL
    {
        public string SearchEmployees()
        {
            RestTemplate _RestTemplate = StartTemplate();

            string response = _RestTemplate.GetForObjectAsync<string>(ClientHelper.UrlSearchEmployeess).Result;
            return response;
        }

        private RestTemplate StartTemplate()
        {
            RestTemplate template = new RestTemplate(ConfigurationManager.AppSettings.Get("UrlServicesMASGLOBAL"));

            template.MessageConverters.Add(new DataContractJsonHttpMessageConverter());
            WebClientHttpRequestFactory requestFactory = new WebClientHttpRequestFactory();
            requestFactory.Timeout = Convert.ToInt32(ConfigurationManager.AppSettings.Get("TimeOutMASGLOBAL"));

            template.RequestFactory = requestFactory;

            return template;
        }
    }
}
