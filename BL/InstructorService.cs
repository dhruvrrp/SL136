﻿namespace Service
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using IRepository;
    using POCO;

    public class InstructorService
    {
        private readonly IInstructorRepository repository;
        private Regex nameCheck = new Regex(@"^[a-zA-Z]+$");

        public InstructorService(IInstructorRepository repository)
        {
            this.repository = repository;
        }

        public void InsertInstructor(Instructor instructor, ref List<string> errors)
        {
            if (instructor == null)
            {
                errors.Add("Instructor cannot be null");
                throw new ArgumentException();
            }

            if (this.nameCheck.IsMatch(instructor.FirstName))
            {
                errors.Add("Invalid first name");
                throw new ArgumentException();
            }

            if (this.nameCheck.IsMatch(instructor.LastName))
            {
                errors.Add("Invalid last name");
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(instructor.FirstName) || string.IsNullOrEmpty(instructor.LastName))
            {
                errors.Add("Invalid Instructor name");
                throw new ArgumentException();
            }

            this.repository.InsertInstructor(instructor, ref errors);
        }

        public void UpdateInstructor(Instructor instructor, ref List<string> errors)
        {
            if (instructor == null)
            {
                errors.Add("Instructor cannot be null");
                throw new ArgumentException();
            }

            if (this.nameCheck.IsMatch(instructor.FirstName))
            {
                errors.Add("Invalid first name");
                throw new ArgumentException();
            }

            if (this.nameCheck.IsMatch(instructor.LastName))
            {
                errors.Add("Invalid last name");
                throw new ArgumentException();
            }

            if (instructor.InstructorId == 0)
            {
                errors.Add("Invalid Instructor id");
                throw new ArgumentException();
            }

            this.repository.UpdateInstructor(instructor, ref errors);
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

        public List<Instructor> GetInstructorList(ref List<string> errors)
        {
            return this.repository.GetInstructorList(ref errors);
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
                errors.Add("Instructor cannot be null");
                throw new ArgumentException();
            }

            if (schedule_id == 0)
            {
                errors.Add("Schedule id cannot be null");
                throw new ArgumentException();
            }

            this.repository.AssignInstructorToClass(instructor_id, schedule_id, ref errors);
        }
    }
}