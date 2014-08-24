namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface IInstructorRepository
    {
        void InsertInstructor(Instructor instructor, ref List<string> errors);

        void UpdateInstructor(Instructor instructor, ref List<string> errors);

        void DeleteInstructor(int instructor_id, ref List<string> errors);

        Instructor GetInstructorInfo(int instructor_id, ref List<string> errors);

        void AssignInstructorToClass(int instructor_id, int scheduleID, ref List<string> errors);
    }
}
