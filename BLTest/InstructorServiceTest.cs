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
    public class InstructorServiceTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertInstructorErrorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IInstructorRepository>();
            var instructorService = new InstructorService(mockRepository.Object);

            //// Act
            instructorService.InsertInstructor(null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertInstructorErrorTest2()
        {
            //// Arranage
            var errors = new List<string>();
            var mockRepository = new Mock<IInstructorRepository>();
            var instructorService = new InstructorService(mockRepository.Object);
            var instructor = new Instructor { FirstName = string.Empty };

            //// Act
            instructorService.InsertInstructor(instructor, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InstructorErrorTest()
        {
            //// Arranage
            var errors = new List<string>();
            var mockRepository = new Mock<IInstructorRepository>();
            var instructorService = new InstructorService(mockRepository.Object);

            //// Act
            instructorService.GetInstructor(0, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateInstructorErrorTest2()
        {
            //// Arrange
            var errors = new List<string>();

            var mockRepository = new Mock<IInstructorRepository>();
            var instructorService = new InstructorService(mockRepository.Object);
            Instructor instructor = new Instructor { InstructorId = 0 };

            //// Act
            instructorService.UpdateInstructor(instructor, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateInstructorErrorTest()
        {
            //// Arrange
            var errors = new List<string>();

            var mockRepository = new Mock<IInstructorRepository>();
            var instructorService = new InstructorService(mockRepository.Object);
            Instructor instructor = new Instructor();

            //// Act
            instructorService.UpdateInstructor(instructor, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteInstructorErrorTest()
        {
            //// Arrange
            var errors = new List<string>();

            var mockRepository = new Mock<IInstructorRepository>();
            var instructorService = new InstructorService(mockRepository.Object);

            //// Act
            instructorService.DeleteInstructor(0, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }
    }
}
