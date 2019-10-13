using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnTest.DTO.Employees
{
    public abstract class DTOContractType
    {
        private string contractTypeName;
        private decimal hourlySalary;
        private decimal monthlySalary;
        private decimal annualSalary;

        public string ContractTypeName { get => contractTypeName; set => contractTypeName = value; }
        public decimal HourlySalary { get => hourlySalary; set => hourlySalary = value; }
        public decimal MonthlySalary { get => monthlySalary; set => monthlySalary = value; }
        public decimal AnnualSalary { get => annualSalary; set => annualSalary = value; }

        public abstract void CalculateSalary();
    }
}
