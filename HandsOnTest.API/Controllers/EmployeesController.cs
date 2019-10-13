using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HandsOnTest.DTO.Generic;
using HandsOnTest.DTO.Employees;
using HandsOnTest.BL.Employees;

namespace HandsOnTest.API.Controllers
{
    [RoutePrefix("api/Employees")]
    public class EmployeesController : ApiController
    {

        [HttpGet]
        [Route("SearchEmployees")]
        public HttpResponseMessage SearchEmployees()
        {
            DTOResult<List<DTOEmployees>> resultAPIEmployees = new DTOResult<List<DTOEmployees>>();

            try
            {
                resultAPIEmployees = new BLEmployees().SearchEmployees();
                return Request.CreateResponse(HttpStatusCode.OK, resultAPIEmployees);
            }
            catch (Exception ex)
            {
                resultAPIEmployees.Message = ex.Message.ToString();
                resultAPIEmployees.Result = false;
                return Request.CreateResponse(HttpStatusCode.InternalServerError, resultAPIEmployees);
            }
        }


        [HttpPost]
        [Route("SearchEmployeeId")]
        public HttpResponseMessage SearchEmployeeId([FromBody]int request)
        {
            if (request == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
               
            DTOResult<List<DTOEmployees>> resultAPIEmployees = new DTOResult<List<DTOEmployees>>();

            try
            {
                resultAPIEmployees = new BLEmployees().SearchEmployeeId(request);
                return Request.CreateResponse(HttpStatusCode.OK, resultAPIEmployees);
            }
            catch (Exception ex)
            {
                resultAPIEmployees.Message = ex.Message.ToString();
                resultAPIEmployees.Result = false;
                return Request.CreateResponse(HttpStatusCode.InternalServerError, resultAPIEmployees);
            }
        }
    }
}
