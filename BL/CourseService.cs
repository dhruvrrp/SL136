namespace Service
{
    using System;
    using System.Collections.Generic;
    using IRepository;
    using POCO;

    public class CourseService
    {
        private readonly ICourseRepository repository;

        public CourseService(ICourseRepository repository)
        {
            this.repository = repository;
        }

        public void InsertCourse(Course course, ref List<string> errors)
        {
            if (course == null)
            {
                errors.Add("Course cannot be null");
                throw new ArgumentException();
            }

            this.repository.InsertCourse(course, ref errors);
        }

        public void UpdateCourse(Course course, ref List<string> errors)
        {
            if (course == null)
            {
                errors.Add("Course cannot be null");
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(course.CourseId))
            {
                errors.Add("Invalid course id");
                throw new ArgumentException();
            }

            this.repository.UpdateCourse(course, ref errors);
        }

        public void DeleteCourse(string id, ref List<string> errors)
        {
            if (string.IsNullOrEmpty(id))
            {
                errors.Add("Invalid course id");
                throw new ArgumentException();
            }

            this.repository.DeleteCourse(id, ref errors);
        }

        public List<Course> GetCourseList(ref List<string> errors)
        {
            return this.repository.GetCourseList(ref errors);
        }
    }
}
