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
    public class TAServiceTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertTAErrorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<ITARepository>();
            var service = new TAService(mockRepository.Object);

            //// Act
            service.InsertTA(null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertTAErrorTest2()
        {
            //// Arranage
            var errors = new List<string>();
            var mockRepository = new Mock<ITARepository>();
            var service = new TAService(mockRepository.Object);
            var teachingAssistant = new TA { FirstName = string.Empty };

            //// Act
            service.InsertTA(teachingAssistant, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TAErrorTest()
        {
            //// Arranage
            var errors = new List<string>();
            var mockRepository = new Mock<ITARepository>();
            var service = new TAService(mockRepository.Object);

            //// Act
            service.GetTA(0, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateTAErrorTest2()
        {
            //// Arrange
            var errors = new List<string>();

            var mockRepository = new Mock<ITARepository>();
            var service = new TAService(mockRepository.Object);
            TA teachingAssistant = new TA { TAId = 0 };

            //// Act
            service.UpdateTA(teachingAssistant, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateTAErrorTest()
        {
            //// Arrange
            var errors = new List<string>();

            var mockRepository = new Mock<ITARepository>();
            var service = new TAService(mockRepository.Object);
            TA teachingAssistant = new TA();

            //// Act
            service.UpdateTA(teachingAssistant, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteTAErrorTest()
        {
            //// Arrange
            var errors = new List<string>();

            var mockRepository = new Mock<ITARepository>();
            var service = new TAService(mockRepository.Object);

            //// Act
            service.DeleteTA(0, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddTAtoClassErrorTest()
        {
            //// Arrange
            var errors = new List<string>();

            var mockRepository = new Mock<ITARepository>();
            var service = new TAService(mockRepository.Object);

            //// Act
            service.AddTAtoClass(0, 101, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddTAtoClassErrorTest2()
        {
            //// Arrange
            var errors = new List<string>();

            var mockRepository = new Mock<ITARepository>();
            var service = new TAService(mockRepository.Object);

            //// Act
            service.AddTAtoClass(101, 0, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveTAFromClassErrorTest()
        {
            //// Arrange
            var errors = new List<string>();

            var mockRepository = new Mock<ITARepository>();
            var service = new TAService(mockRepository.Object);

            //// Act
            service.RemoveTAFromClass(101, 0, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveTAFromClassErrorTest2()
        {
            //// Arrange
            var errors = new List<string>();

            var mockRepository = new Mock<ITARepository>();
            var service = new TAService(mockRepository.Object);

            //// Act
            service.RemoveTAFromClass(0, 101, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }
    }
}
