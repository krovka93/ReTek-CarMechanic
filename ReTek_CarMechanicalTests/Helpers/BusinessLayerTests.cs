using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReTek_CarMechanical.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReTek_CarMechanical.Helpers.Tests
{
    [TestClass()]
    public class BusinessLayerTests
    {
        [TestMethod()]
        public void GetAllCarTest()
        {
            var allCars = BusinessLayer.Instance.GetAllCar();
            Assert.IsNotNull(allCars);
        }

        [TestMethod()]
        public void GetAllClients()
        {
            var allClients = BusinessLayer.Instance.GetAllClient();
            Assert.IsNotNull(allClients);
            Assert.IsTrue(allClients.Count() > 0);
        }
    }
}