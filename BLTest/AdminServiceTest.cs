namespace ServiceTest
{
    using System;
    using System.Collections.Generic;

    using IRepository;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using POCO;
    using Service;

    [TestClass]
    public class AdminServiceTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertAdminErrorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IAdminRepository>();
            var adminService = new AdminService(mockRepository.Object);

            //// Act
            adminService.InsertAdmin(null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertAdminErrorTest2()
        {
            //// Arranage
            var errors = new List<string>();
            var mockRepository = new Mock<IAdminRepository>();
            var adminService = new AdminService(mockRepository.Object);
            var admin = new Admin { FirstName = string.Empty };

            //// Act
            adminService.InsertAdmin(admin, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AdminErrorTest()
        {
            //// Arranage
            var errors = new List<string>();
            var mockRepository = new Mock<IAdminRepository>();
            var adminService = new AdminService(mockRepository.Object);

            //// Act
            adminService.GetAdmin(0, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateAdminErrorTest2()
        {
            //// Arrange
            var errors = new List<string>();

            var mockRepository = new Mock<IAdminRepository>();
            var adminService = new AdminService(mockRepository.Object);
            var admin = new Admin { Id = 0 };

            //// Act
            adminService.UpdateAdmin(admin, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateAdminErrorTest()
        {
            //// Arrange
            var errors = new List<string>();

            var mockRepository = new Mock<IAdminRepository>();
            var adminService = new AdminService(mockRepository.Object);
            Admin admin = new Admin();

            //// Act
            adminService.UpdateAdmin(admin, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteAdminErrorTest()
        {
            //// Arrange
            var errors = new List<string>();

            var mockRepository = new Mock<IAdminRepository>();
            var adminService = new AdminService(mockRepository.Object);

            //// Act
            adminService.DeleteAdmin(0, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }
    }
}
