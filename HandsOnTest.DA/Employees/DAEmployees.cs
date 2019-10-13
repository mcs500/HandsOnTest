using HandsOnTest.DTO.Generic;
using HandsOnTest.DTO.Employees;
using HandsOnTest.DA.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HandsOnTest.DA.Employees
{
    public class DAEmployees
    {
        public DTOResult<List<DTOEmployees>> SearchEmployees() {
            DTOResult<List<DTOEmployees>> resultService = new DTOResult<List<DTOEmployees>>();
            List<DTOEmployees> listResultEmployees= new List<DTOEmployees>();

            string result = new ClientMASGLOBAL().SearchEmployees();

            listResultEmployees = JsonConvert.DeserializeObject<List<DTOEmployees>>(result);

            listResultEmployees.ForEach(e => e.CalculateSalary());

            resultService.Result = true;
            resultService.Response = listResultEmployees;


            return resultService;
        }
    }
}
