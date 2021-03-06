﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReTek_CarMechanical.Helpers;
using ReTek_CarMechanical.Models;
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

        [TestMethod()]
        public void GetAllCarByUserTest()
        {
            var clients = BusinessLayer.Instance.GetAllClient();
            Client whosecar = new Client();
            foreach (var item in clients)
            {
                if (item.FirstName == "Varga")
                {
                    whosecar = item;
                }
            }
            var cars = BusinessLayer.Instance.GetAllCarByUser(whosecar);
            Assert.IsNotNull(cars);
            Assert.IsTrue(cars.Count() > 0);
        }

        [TestMethod()]
        public void GetAllServiceTest()
        {
            var allService = BusinessLayer.Instance.GetAllClient();
            Assert.IsNotNull(allService);
            Assert.IsTrue(allService.Count() > 0);
        }

        [TestMethod()]
        public void AddPartTest()
        {
            var addPart = BusinessLayer.Instance.GetAllClient();
            Assert.IsNotNull(addPart);
            Assert.IsTrue(addPart.Count() > 0);
        }

        [TestMethod()]
        public void GetAllServiceTest2()
        {
            var allServices = BusinessLayer.Instance.GetAllService();
            Assert.IsNotNull(allServices);
            Assert.IsTrue(allServices.Count() > 0);
        }

        [TestMethod()]
        public void GetAllWorksheetTest()
        {
            var allWorksheets = BusinessLayer.Instance.GetAllWorksheet();
            Assert.IsNotNull(allWorksheets);
            Assert.IsTrue(allWorksheets.Count() > 0);
        }

        [TestMethod()]
        public void AddNewServiceTest()
        {
            var allservices = BusinessLayer.Instance.GetAllService();
            Service service = new Service();
            service.ServiceName = "Tesztszolgáltatás";
            service.ServicePrice = 2000;
            BusinessLayer.Instance.AddNewService(service);
            var newallservices = BusinessLayer.Instance.GetAllService();
            Assert.IsTrue(newallservices.Count() > allservices.Count());
        }
    }
}