﻿namespace ServiceTest
{
    using System;
    using System.Collections.Generic;

    using IRepository;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using POCO;
    using Service;

    [TestClass]
    public class CourseServiceTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertCourseErrorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<ICourseRepository>();
            var courseService = new CourseService(mockRepository.Object);

            //// Act
            courseService.InsertCourse(null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertCourseErrorTest2()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<ICourseRepository>();
            var courseService = new CourseService(mockRepository.Object);
            
            var course = new Course();

            //// Act
            courseService.InsertCourse(course, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertCourseErrorTest3()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<ICourseRepository>();
            var courseService = new CourseService(mockRepository.Object);

            var course = new Course();
            course.CourseId = string.Empty;

            //// Act
            courseService.InsertCourse(course, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertCourseErrorTest4()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<ICourseRepository>();
            var courseService = new CourseService(mockRepository.Object);

            var course = new Course();
            course.CourseId = "testNotNumeric";

            //// Act
            courseService.InsertCourse(course, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertCourseErrorTest5()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<ICourseRepository>();
            var courseService = new CourseService(mockRepository.Object);

            var course = new Course();
            course.CourseId = "123sortaNumeric123";

            //// Act
            courseService.InsertCourse(course, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void InsertCourseSuccessTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<ICourseRepository>();
            var courseService = new CourseService(mockRepository.Object);
            
            var course = new Course();
            course.CourseId = "3";

            System.Diagnostics.Debug.WriteLine("test"); // TODO

            //// Act
            courseService.InsertCourse(course, ref errors);
            
            //// Assert
            Assert.AreEqual(0, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateCourseErrorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<ICourseRepository>();
            var courseService = new CourseService(mockRepository.Object);

            //// Act
            courseService.UpdateCourse(null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateCourseErrorTest2()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<ICourseRepository>();
            var courseService = new CourseService(mockRepository.Object);
            var course = new Course();
            course.CourseId = string.Empty;

            //// Act
            courseService.UpdateCourse(course, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateCourseErrorTest3()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<ICourseRepository>();
            var courseService = new CourseService(mockRepository.Object);
            var course = new Course();
            course.CourseId = "notnumeric";

            //// Act
            courseService.UpdateCourse(course, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteCourseErrorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<ICourseRepository>();
            var courseService = new CourseService(mockRepository.Object);

            //// Act
            courseService.DeleteCourse("fffds", ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }
    }
}
