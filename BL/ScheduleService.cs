namespace Service
{
    using System;
    using System.Collections.Generic;
    using IRepository;
    using POCO;

    public class ScheduleService
    {
        private readonly IScheduleRepository repository;

        public ScheduleService(IScheduleRepository repository)
        {
            this.repository = repository;
        }

        public void InsertSchedule(Schedule schedule, ref List<string> errors)
        {
            if (schedule == null)
            {
                errors.Add("Schedule cannot be null");
                throw new ArgumentException();
            }

            this.repository.InsertCourseSchedule(schedule, ref errors);
        }

        public void UpdateSchedule(Schedule schedule, ref List<string> errors)
        {
            if (schedule == null)
            {
                errors.Add("Schedule cannot be null");
                throw new ArgumentException();
            }

            if (schedule.Course == null)
            {
                errors.Add("Invalid course id");
                throw new ArgumentException();
            }

            this.repository.UpdateCourseSchedule(schedule, ref errors);
        }

        public void DeleteSchedule(string id, ref List<string> errors)
        {
            if (string.IsNullOrEmpty(id))
            {
                errors.Add("Invalid course id");
                throw new ArgumentException();
            }

            this.repository.DeleteCourseSchedule(id, ref errors);
        }

        public List<Schedule> GetScheduleList(string year, string quarter, ref List<string> errors)
        {
            return this.repository.GetScheduleList(year, quarter, ref errors);
        }

        public List<string> GetScheduleYear(ref List<string> errors)
        {
            return this.repository.GetScheduleYear(ref errors);
        }

        public List<string> GetQuarterForYear(int year, ref List<string> errors)
        {
            return this.repository.GetQuarterForYear(year, ref errors);
        }

        public List<string> GetScheduleQuarters(ref List<string> errors)
        {
            return this.repository.GetScheduleQuarters(ref errors);
        }
    }
}
