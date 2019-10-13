using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HandsOnTest.DTO.Employees;
using HandsOnTest.DTO.Generic;
using Newtonsoft.Json;

namespace HandsOnTest.Application.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult SearchEmployee()
        {
            return View();
        }


        public JsonResult Search(string data)
        {
            DTOResult<List<DTOEmployees>> resultApi = new DTOResult<List<DTOEmployees>>();
            try
            {
                Task<string> TaskSearch;
                if (data=="")
                {
                    TaskSearch =
                   Task.Run(async () =>
                   await DataAcess.Services.ClientGet(ConfigurationManager.AppSettings.Get("UrlServiceInternal"), "/api/Employees/SearchEmployees", ""));
                }
                else
                {
                   TaskSearch =
                   Task.Run(async () =>
                   await DataAcess.Services.ClientPost(ConfigurationManager.AppSettings.Get("UrlServiceInternal"), "/api/Employees/SearchEmployeeId", data));
                }
               

                TaskSearch.Wait();

                resultApi = JsonConvert.DeserializeObject<DTOResult<List<DTOEmployees>>>(TaskSearch.Result);
                    
            }
            catch (Exception e)
            {
                resultApi.Message = e.Message.ToString();
                resultApi.Result = false;
            }
            return Json(resultApi, JsonRequestBehavior.AllowGet);
        }

        
    }
}