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
    public class StaffServiceTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertStaffErrorTest()
        {
            //// Arrange
            var errors = new List<string>();
       //     var mockRepository = new Mock<IStaffRepository>();
       //     var service = new StaffService(mockRepository.Object);

            //// Act
       //     service.InsertStaff(null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertStaffErrorTest2()
        {
            //// Arranage
            var errors = new List<string>();
       //     var mockRepository = new Mock<IStaffRepository>();
       //     var service = new StaffService(mockRepository.Object);
       //     var teachingAssistant = new Staff { Email = string.Empty };

            //// Act
        //    service.InsertStaff(teachingAssistant, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StaffErrorTest()
        {
            //// Arranage
            var errors = new List<string>();
         //   var mockRepository = new Mock<IStaffRepository>();
        //    var service = new StaffService(mockRepository.Object);

            //// Act
       //     service.GetStaff(0, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateStaffErrorTest2()
        {
            //// Arrange
            var errors = new List<string>();

     //       var mockRepository = new Mock<IStaffRepository>();
       //     var service = new StaffService(mockRepository.Object);
     //       Staff teachingAssistant = new Staff { StaffId = 0 };

            //// Act
     //       service.UpdateStaff(teachingAssistant, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateStaffErrorTest()
        {
            //// Arrange
            var errors = new List<string>();

 //           var mockRepository = new Mock<IStaffRepository>();
   //         var service = new StaffService(mockRepository.Object);
     //       Staff teachingAssistant = new Staff();

            //// Act
     //       service.UpdateStaff(teachingAssistant, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteStaffErrorTest()
        {
            //// Arrange
            var errors = new List<string>();

  //          var mockRepository = new Mock<IStaffRepository>();
    //        var service = new StaffService(mockRepository.Object);

            //// Act
     //       service.DeleteStaff(0, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }
    }
}
