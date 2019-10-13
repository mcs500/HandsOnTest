using System;
using HandsOnTest.BL.Employees;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HandsOnTest.DTO.Employees;
using HandsOnTest.DTO.Generic;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class BLEmployeesTest
    {
        [TestMethod]    
        public void parameterNegative_Test()
        {
            var _SearchEmployees = new BLEmployees();
            DTOResult<List<DTOEmployees>> resultExpected = new DTOResult<List<DTOEmployees>>();

            int _id = -1;

            var result = _SearchEmployees.SearchEmployeeId(_id);            
        }
    }
}
