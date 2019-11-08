using System;
using System.Collections.Generic;
using IOC_Quiz;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        Mock<IDataAccess> fakeEmployeDataAccess;
        BusineesLogic ebl ;
        [TestInitialize]

        public void Setup()
        {
            Employe DummyEmploye = new Employe() { Id = 1, HiringDate = new System.DateTime(2000, 1, 1), Name = "Abhi", Salary = 3000 };
            List<Employe> DummyThreeEmployeeList = new List<Employe>()
            {
            new Employe() { Id = 2, HiringDate = new System.DateTime(2003, 1, 1), Name = "purvi", Salary = 4500 },
            new Employe() { Id = 1, HiringDate = new System.DateTime(2001, 1, 1), Name = "paurav", Salary = 2500 },
            new Employe() { Id = 3, HiringDate = new System.DateTime(2004, 1, 1), Name = "looser", Salary = 1500 }
            };

            fakeEmployeDataAccess = new Mock<IDataAccess>();
            fakeEmployeDataAccess.Setup(m => m.GetEmployeeSalary(It.IsAny<int>())).Returns(4000);
            fakeEmployeDataAccess.Setup(m => m.GetTopThreeEmployeeBySalary()).Returns(DummyThreeEmployeeList);
            fakeEmployeDataAccess.Setup(m => m.GetEmploye(It.IsAny<int>())).Returns(DummyEmploye);
            ebl = new BusineesLogic(fakeEmployeDataAccess.Object);
        }
        [TestMethod]
        public void CalculateBonus()
        {
            var BonusResult = ebl.GetBonus(1);
            Assert.AreEqual(BonusResult, 7600);
        }
        [TestMethod]
        public void PrintEmployeSalaryInfo_test_WithMoq()
        {

            var printResult = ebl.PrintTopThreeEmployeesalaryInfo();
            Assert.AreEqual(printResult, "The 1st top paid employee name purvi and salary 4500 The 2nd top paid employee name paurav and salary 2500 The 3rd top paid employee name looser and salary 1500");
        }
    }
}
