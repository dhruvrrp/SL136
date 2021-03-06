﻿namespace Service
{
    using System;
    using System.Collections.Generic;
    using IRepository;
    using POCO;

    public class TAService
    {
        private readonly ITARepository repository;

        public TAService(ITARepository repository)
        {
            this.repository = repository;
        }

        public void InsertTA(TA ta, ref List<string> errors)
        {
            if (ta == null)
            {
                errors.Add("Ta cannot be null");
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(ta.FirstName) || string.IsNullOrEmpty(ta.LastName))
            {
                errors.Add("Invalid TA name");
                throw new ArgumentException();
            }

            this.repository.InsertTA(ta, ref errors);
        }

        public void UpdateTA(TA ta, ref List<string> errors)
        {
            if (ta == null)
            {
                errors.Add("Ta cannot be null");
                throw new ArgumentException();
            }

            if (ta.TAId == 0)
            {
                errors.Add("Invalid TA id");
                throw new ArgumentException();
            }

            this.repository.UpdateTA(ta, ref errors);
        }

        public TA GetTA(int id, ref List<string> errors)
        {
            if (id == 0)
            {
                errors.Add("Invalid TA id");
                throw new ArgumentException();
            }

            return this.repository.GetTaInfo(id, ref errors);
        }

        public void DeleteTA(int id, ref List<string> errors)
        {
            if (id == 0)
            {
                errors.Add("Invalid TA id");
                throw new ArgumentException();
            }

            this.repository.DeleteTA(id, ref errors);
        }

        public List<TA> GetTAsForClass(int scheduleId, ref List<string> errors)
        {
            return this.repository.ViewTasForClass(scheduleId, ref errors);
        }

        public void AddTAtoClass(int idOfTA, int scheduleId, ref List<string> errors)
        {
            if (idOfTA == 0)
            {
                errors.Add("Invalid TA id");
                throw new ArgumentException();
            }

            if (scheduleId == 0)
            {
                errors.Add("Invalid scheduleId id");
                throw new ArgumentException();
            }

            this.repository.AssignTaToClass(idOfTA, scheduleId, ref errors);
        }

        public void RemoveTAFromClass(int idOfTA, int scheduleId, ref List<string> errors)
        {
            if (idOfTA == 0)
            {
                errors.Add("Invalid TA id");
                throw new ArgumentException();
            }

            if (scheduleId == 0)
            {
                errors.Add("Invalid scheduleId id");
                throw new ArgumentException();
            }

            this.repository.RemoveTaFromClass(idOfTA, scheduleId, ref errors);
        }
    }
}
