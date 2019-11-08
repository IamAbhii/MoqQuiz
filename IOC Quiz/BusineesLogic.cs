using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_Quiz
{
    public class BusineesLogic
    {
        IDataAccess dta;
        public BusineesLogic(IDataAccess dta)
        {
            this.dta = dta;
        }
        public DateTime? GetEmployeeHiringDate(int id)
        {
            return dta.GetEmploye(id).HiringDate;
        }
        public int? GetEmployeeSalary(int id)
        {
            return dta.GetEmployeeSalary(id);
        }
        public List<Employe> GetTopThreeEmployeeBySalary()
        {
            return dta.GetTopThreeEmployeeBySalary();
        }

        public double GetBonus(int id)
        {
            var employeJoiningDate = dta.GetEmploye(id).HiringDate;
            var yearsOfEmployed = DateTime.Now.Year - employeJoiningDate.Value.Year;        
            int years = Convert.ToInt32(yearsOfEmployed);

            var bouns = Convert.ToDouble(dta.GetEmployeeSalary(id) * years * 0.1);
            return bouns;
        }
        public string PrintTopThreeEmployeesalaryInfo()
        {
            var employees = GetTopThreeEmployeeBySalary();
            var result = String.Format("The 1st top paid employee name {0} and salary {1} The 2nd top paid employee name {2} and salary {3} The 3rd top paid employee name {4} and salary {5}",employees[0].Name, employees[0].Salary, employees[1].Name, employees[1].Salary, employees[2].Name, employees[2].Salary);
            return result;
        }
    }
}
