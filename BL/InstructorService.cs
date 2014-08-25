﻿namespace Service
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

        public void InsertInstructor(Instructor instructor, ref List<string> errors)
        {
            if (instructor == null)
            {
                errors.Add("Instructor cannot be null");
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

        public void DeleteInstructor(int id, ref List<string> errors)
        {
            if (id == 0)
            {
                errors.Add("Invalid Instructor id");
                throw new ArgumentException();
            }

            this.repository.DeleteInstructor(id, ref errors);
        }
    }
}