namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface ICourseRepository
    {
        List<Course> GetCourseList(ref List<string> errors);

        void InsertCourse(Course course, ref List<string> errors);

        void UpdateCourse(Course course, ref List<string> errors);

        void DeleteCourse(string id, ref List<string> errors);
    }
}
