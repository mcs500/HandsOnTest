using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnTest.DTO.Employees
{
    public class DTOEmployees:DTOContractType
    {
        private int id;
        private string name;
        private int roleId;
        private string roleName;
        private string roleDescription;
        
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int RoleId { get => roleId; set => roleId = value; }
        public string RoleName { get => roleName; set => roleName = value; }
        public string RoleDescription { get => roleDescription; set => roleDescription = value; }

        public override void CalculateSalary()
        {
            if (ContractTypeName == "HourlySalaryEmployee")
            {
                AnnualSalary = 120 * HourlySalary * 12;
            }
            else
            {
                AnnualSalary = MonthlySalary * 12;
            }
        }
    }
}
