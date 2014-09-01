namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface IScheduleRepository
    {
        public List<string> GetQuarterForYear(int year, ref List<string> errors);

        public List<int> GetScheduleYear(ref List<string> errors);

        List<Schedule> GetScheduleList(string year, string quarter, ref List<string> errors);

        void InsertCourseSchedule(Schedule schedule, ref List<string> errors);

        void UpdateCourseSchedule(Schedule schedule, ref List<string> errors);

        void DeleteCourseSchedule(string id, ref List<string> errors);
    }
}
