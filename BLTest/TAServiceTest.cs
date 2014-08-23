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
            var taService = new TAService(mockRepository.Object);

            //// Act
            taService.InsertTA(null, ref errors);

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
            var taService = new TAService(mockRepository.Object);
            var TA = new TA { FirstName = string.Empty };

            //// Act
            taService.InsertTA(TA, ref errors);

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
            var taService = new TAService(mockRepository.Object);

            //// Act
            taService.GetTA(0, ref errors);

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
            var taService = new TAService(mockRepository.Object);
            TA ta = new TA {TAId = 0; };

            //// Act
            taService.UpdateTA(ta, ref errors);

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
            var taService = new TAService(mockRepository.Object);
            TA ta = new TA();

            //// Act
            taService.UpdateTA(ta, ref errors);

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
            var taService = new TAService(mockRepository.Object);

            //// Act
            taService.DeleteTA(0, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void addTAtoClassErrorTest()
        {
            //// Arrange
            var errors = new List<string>();

            var mockRepository = new Mock<ITARepository>();
            var taService = new TAService(mockRepository.Object);

            //// Act
            taService.AddTAtoClass(0, 101, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void addTAtoClassErrorTest2()
        {
            //// Arrange
            var errors = new List<string>();

            var mockRepository = new Mock<ITARepository>();
            var taService = new TAService(mockRepository.Object);

            //// Act
            taService.AddTAtoClass(101, 0, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void removeTAFromClassErrorTest()
        {
            //// Arrange
            var errors = new List<string>();

            var mockRepository = new Mock<ITARepository>();
            var taService = new TAService(mockRepository.Object);

            //// Act
            taService.RemoveTAFromClass(101, 0, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void removeTAFromClassErrorTest2()
        {
            //// Arrange
            var errors = new List<string>();

            var mockRepository = new Mock<ITARepository>();
            var taService = new TAService(mockRepository.Object);

            //// Act
            taService.RemoveTAFromClass(0, 101, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }
    }
}
