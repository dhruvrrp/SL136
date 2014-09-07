namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using IRepository;

    using POCO;

    public class ScheduleRepository : BaseRepository, IScheduleRepository
    {
        private const string GetScheduleListProcedure = "spGetScheduleList";
        private const string DeleteCourseScheduleProcedure = "spDeleteCourseSchedule";
        private const string UpdateCourseScheduleProcedure = "spUpdateCourseSchedule";
        private const string InsertCourseScheduleProcedure = "spInsertCourseSchedule";
        private const string GetScheduleYearsProcedure = "spGetScheduleYears";
        private const string GetQuarterForYearProcedure = "spGetQuarterForYear";

        public List<int> GetScheduleYear(ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var yearList = new List<int>();
            try
            {
                var adapter = new SqlDataAdapter(GetScheduleYearsProcedure, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };

                var dataSet = new DataSet();
                adapter.Fill(dataSet);
                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                for (var i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    yearList.Add(Convert.ToInt32(dataSet.Tables[0].Rows[i]["year"].ToString()));
                }
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }

            return yearList;
        }

        public List<string> GetQuarterForYear(int year, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var quarterList = new List<string>();
            try
            {
                var adapter = new SqlDataAdapter(GetQuarterForYearProcedure, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@year", SqlDbType.Int));
                adapter.SelectCommand.Parameters["@year"].Value = year;
                var dataSet = new DataSet();
                adapter.Fill(dataSet);
                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                for (var i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    quarterList.Add(dataSet.Tables[0].Rows[i]["year"].ToString());
                }
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }

            return quarterList;
        }

        public void InsertCourseSchedule(Schedule schedule, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(InsertCourseScheduleProcedure, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.VarChar, 20));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@year", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@quarter", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@session", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_day_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_time_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@instructor_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters["@schedule_id"].Value = schedule.ScheduleId;
                adapter.SelectCommand.Parameters["@course_id"].Value = schedule.Course;
                adapter.SelectCommand.Parameters["@year"].Value = schedule.Year;
                adapter.SelectCommand.Parameters["@quarter"].Value = schedule.Quarter;
                adapter.SelectCommand.Parameters["@session"].Value = schedule.Session;
                /* adapter.SelectCommand.Parameters["@schedule_day_id"].Value = schedule.;
                 adapter.SelectCommand.Parameters["@schedule_time_id"].Value = schedule.CourseLevel;
                 adapter.SelectCommand.Parameters["@instructor_id"].Value = schedule.Description;
                 */
                var dataSet = new DataSet();
                adapter.Fill(dataSet);
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }
        }

        public void UpdateCourseSchedule(Schedule schedule, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(UpdateCourseScheduleProcedure, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.VarChar, 20));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@year", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@quarter", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@session", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_day_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_time_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@instructor_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters["@schedule_id"].Value = schedule.ScheduleId;
                adapter.SelectCommand.Parameters["@course_id"].Value = schedule.Course;
                adapter.SelectCommand.Parameters["@year"].Value = schedule.Year;
                adapter.SelectCommand.Parameters["@quarter"].Value = schedule.Quarter; 
                adapter.SelectCommand.Parameters["@session"].Value = schedule.Session;
               /* adapter.SelectCommand.Parameters["@schedule_day_id"].Value = schedule.;
                adapter.SelectCommand.Parameters["@schedule_time_id"].Value = schedule.CourseLevel;
                adapter.SelectCommand.Parameters["@instructor_id"].Value = schedule.Description;
                */
                var dataSet = new DataSet();
                adapter.Fill(dataSet);
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }
        }

        public void DeleteCourseSchedule(string id, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);

            try
            {
                var adapter = new SqlDataAdapter(DeleteCourseScheduleProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.VarChar, 20));
                adapter.SelectCommand.Parameters["@schedule_id"].Value = id;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }
        }
        
        public List<Schedule> GetScheduleList(string year, string quarter, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var scheduleList = new List<Schedule>();

            try
            {
                var adapter = new SqlDataAdapter(GetScheduleListProcedure, conn);

                if (year.Length > 0)
                {
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@year", SqlDbType.Int));
                    adapter.SelectCommand.Parameters["@year"].Value = year;
                }

                if (quarter.Length > 0)
                {
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@quarter", SqlDbType.VarChar, 25));
                    adapter.SelectCommand.Parameters["@quarter"].Value = quarter;
                }

                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                for (var i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    var schedule = new Schedule
                    {
                        ScheduleId = Convert.ToInt32(dataSet.Tables[0].Rows[i]["schedule_id"].ToString()), 
                        Year = dataSet.Tables[0].Rows[i]["year"].ToString(), 
                        Quarter = dataSet.Tables[0].Rows[i]["quarter"].ToString(), 
                        Session = dataSet.Tables[0].Rows[i]["session"].ToString(), 
                        Course = new Course
                        {
                            CourseId = dataSet.Tables[0].Rows[i]["course_id"].ToString(), 
                            Title = dataSet.Tables[0].Rows[i]["course_title"].ToString(), 
                            Description = dataSet.Tables[0].Rows[i]["course_description"].ToString(), 
                        }
                    };
                    scheduleList.Add(schedule);
                }
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }

            return scheduleList;
        }
    }
}
