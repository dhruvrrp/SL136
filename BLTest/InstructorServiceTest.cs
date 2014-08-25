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
            var InstructorService = new InstructorService(mockRepository.Object);

            //// Act
            InstructorService.InsertInstructor(null, ref errors);

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
            var InstructorService = new InstructorService(mockRepository.Object);
            var Instructor = new Instructor { FirstName = string.Empty };

            //// Act
            InstructorService.InsertInstructor(Instructor, ref errors);

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
            var InstructorService = new InstructorService(mockRepository.Object);

            //// Act
            InstructorService.GetInstructor(0, ref errors);

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
            var InstructorService = new InstructorService(mockRepository.Object);
            Instructor Instructor = new Instructor { InstructorId = 0 };

            //// Act
            InstructorService.UpdateInstructor(Instructor, ref errors);

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
            var InstructorService = new InstructorService(mockRepository.Object);
            Instructor Instructor = new Instructor();

            //// Act
            InstructorService.UpdateInstructor(Instructor, ref errors);

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
            var InstructorService = new InstructorService(mockRepository.Object);

            //// Act
            InstructorService.DeleteInstructor(0, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AssignInstructorErrorTest()
        {
            //// Arrange
            var errors = new List<string>();

            var mockRepository = new Mock<IInstructorRepository>();
            var InstructorService = new InstructorService(mockRepository.Object);
            var ScheduleService = new ScheduleService(); // new ScheduleService(mockRepository.Object);

            //// Act
            InstructorService.AssignInstructorToClass(0, 0, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

    }
}
