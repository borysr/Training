using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeoLib.Data;
using Moq;
using GeoLib.Contracts;
using GeoLib.Services;

namespace GeoLib.Tests
{
    [TestClass]
    public class ManagerTrests
    {
        [TestMethod]
        public void test_zip_code_retrival()
        {
            Mock<IZipCodeRepository> mockZipCodeRepository = new Mock<IZipCodeRepository>();
            ZipCode zipCode = new ZipCode()
            { 
                City = "LINCOLN PARK",
                State = new State() { Abbreviation = "NJ"},
                Zip = "07035"
            };
            mockZipCodeRepository.Setup(obj => obj.GetByZip("07035")).Returns(zipCode);

            IGeoService geoService = new GeoManager(mockZipCodeRepository.Object);

            ZipCodeData data = geoService.GetZipInfo("07035");

            Assert.IsTrue(data.City == "LINCOLN PARK");
            Assert.IsTrue(data.State == "NJ");
            Assert.IsTrue(data.Zip == "07035");
        }
    }
}
