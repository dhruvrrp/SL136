namespace Service
{
    using System;
    using System.Collections.Generic;
    using IRepository;
    using POCO;

    public class InstructorService
    {
        private readonly IInstructorRepository repository;

        public InstructorService(IInstructorRepository repository)
        {
            this.repository = repository;
        }

        public void InsertInstructor(Instructor Instructor, ref List<string> errors)
        {
            if (Instructor == null)
            {
                errors.Add("Instructor cannot be null");
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(Instructor.FirstName) || string.IsNullOrEmpty(Instructor.LastName))
            {
                errors.Add("Invalid Instructor name");
                throw new ArgumentException();
            }

            this.repository.InsertInstructor(Instructor, ref errors);
        }

        public void UpdateInstructor(Instructor Instructor, ref List<string> errors)
        {
            if (Instructor == null)
            {
                errors.Add("Instructor cannot be null");
                throw new ArgumentException();
            }

            if (Instructor.InstructorId == null || Instructor.InstructorId == 0)
            {
                errors.Add("Invalid Instructor id");
                throw new ArgumentException();
            }

            this.repository.UpdateInstructor(Instructor, ref errors);
        }

        public Instructor GetInstructor(int id, ref List<string> errors)
        {
            if (id == 0)
            {
                errors.Add("Invalid Instructor id");
                throw new ArgumentException();
            }

            return this.repository.GetInstructorInfo(id, ref errors);
        }

        public void DeleteInstructor(int id, ref List<string> errors)
        {
            if (id == 0)
            {
                errors.Add("Invalid Instructor id");
                throw new ArgumentException();
            }

            this.repository.DeleteInstructor(id, ref errors);
        }

        public void AssignInstructorToClass(int instructor_id, int schedule_id, ref List<string> errors)
        {
            if (instructor_id == 0)
            {
                errors.Add("Invalid Instructor id");
                throw new ArgumentException();
            }

            if (schedule_id == 0)
            {
                errors.Add("Invalid Instructor id");
                throw new ArgumentException();
            }

            this.repository.AssignInstructorToClass(instructor_id, schedule_id, ref errors);
        }



    }
}
