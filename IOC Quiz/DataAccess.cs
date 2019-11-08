using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_Quiz
{
    public interface IDataAccess
    {
        int? GetEmployeeSalary(int id);
        List<Employe> GetTopThreeEmployeeBySalary();

        Employe GetEmploye(int id);
    }
    class DataAccess: IDataAccess
    {
        EmployeeEntities db = new EmployeeEntities();

        public int? GetEmployeeSalary(int id)
        {
            return db.Employes.Find(id).Salary;
        }

        public List<Employe> GetTopThreeEmployeeBySalary()
        {
            return db.Employes.OrderByDescending(e => e.Salary).Take(3).ToList();
        }

        public Employe GetEmploye(int id)
        {
            return db.Employes.Find(id);
        }
    }
}
