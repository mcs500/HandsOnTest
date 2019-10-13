using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandsOnTest.DTO.Generic;
using HandsOnTest.DTO.Employees;
using HandsOnTest.DA.Employees;

namespace HandsOnTest.BL.Employees
{
    public class BLEmployees
    {
        public DTOResult<List<DTOEmployees>> SearchEmployees()
        {
            DTOResult<List<DTOEmployees>> resultService = new DTOResult<List<DTOEmployees>>();
            DAEmployees _DAEmployees = new DAEmployees();

            try
            {
                resultService = _DAEmployees.SearchEmployees();
                resultService.Result = true;
                resultService.Message = "Successful serch";
            }
            catch (Exception e)
            {
                resultService.Message = e.Message.ToString();
                resultService.Result = false;
            }
            return resultService;
        }

        public DTOResult<List<DTOEmployees>> SearchEmployeeId(int request)
        {
            DTOResult<List<DTOEmployees>> resultService = new DTOResult<List<DTOEmployees>>();
            List<DTOEmployees> listResultEmployees = new List<DTOEmployees>();
            DAEmployees _DAEmployees= new DAEmployees();

            try
            {
                listResultEmployees = _DAEmployees.SearchEmployees().Response;
                if (listResultEmployees.Count>0)
                {
                    resultService.Response = (from _Employee in listResultEmployees
                                              where _Employee.Id == request
                                              select new DTOEmployees()
                                              {
                                                  Id = _Employee.Id,
                                                  Name = _Employee.Name,
                                                  RoleId = _Employee.RoleId,
                                                  RoleName = _Employee.RoleName,
                                                  RoleDescription = _Employee.RoleDescription,
                                                  HourlySalary = _Employee.HourlySalary,
                                                  MonthlySalary = _Employee.MonthlySalary,
                                                  ContractTypeName = _Employee.ContractTypeName,
                                                  AnnualSalary=_Employee.AnnualSalary
                                              }).ToList();

                    
                    if (resultService.Response.Count>0)
                    {
                        resultService.Result = true;
                        resultService.Message = "Successful serch";
                    }
                    else
                    {
                        resultService.Result = false;
                        resultService.Message = "No data fount";
                    }
                }
                else
                {
                    resultService.Result = false;
                    resultService.Message = "No data fount";
                }
            }
            catch (Exception e)
            {
                resultService.Message = e.Message.ToString();
                resultService.Result = false;
            }

            return resultService;
        }

    }
}
