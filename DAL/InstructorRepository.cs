namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using IRepository;

    using POCO;

    public class InstructorRepository : BaseRepository, IInstructorRepository
    {
        private const string InsertNewInstructorProcedure = "spInsertInstructor";
        private const string DeleteInstructorProcedure = "spDeleteInstructor";
        private const string UpdateInstructorProcedure = "spUpdateInstructor";
        private const string ViewInstructorProcedure = "spViewInstructor";
        private const string AssignInstructorToClassProcedure = "spAssignInstructorToSchedule";

        public void InsertInstructor(Instructor instructor, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(InsertNewInstructorProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@instructor_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@first_name", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@last_name", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@title", SqlDbType.VarChar, 50));

                adapter.SelectCommand.Parameters["@instructor_id"].Value = instructor.InstructorId;
                adapter.SelectCommand.Parameters["@first_name"].Value = instructor.FirstName;
                adapter.SelectCommand.Parameters["@last_name"].Value = instructor.LastName;
                adapter.SelectCommand.Parameters["@title"].Value = instructor.Title;

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

        public void UpdateInstructor(Instructor instructor, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(UpdateInstructorProcedure, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@instructor_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@first_name", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@last_name", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@title", SqlDbType.VarChar, 50));

                adapter.SelectCommand.Parameters["@instructor_id"].Value = instructor.InstructorId;
                adapter.SelectCommand.Parameters["@first_name"].Value = instructor.FirstName;
                adapter.SelectCommand.Parameters["@last_name"].Value = instructor.LastName;
                adapter.SelectCommand.Parameters["@title"].Value = instructor.Title;

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

        public void DeleteInstructor(int id, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);

            try
            {
                var adapter = new SqlDataAdapter(DeleteInstructorProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType =
                            CommandType
                            .StoredProcedure
                    }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@instructor_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@instructor_id"].Value = id;

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

        public Instructor GetInstructorInfo(int id, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            Instructor instructor = new Instructor();
            try
            {
                var adapter = new SqlDataAdapter(ViewInstructorProcedure, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@instructor_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@instructor_id"].Value = id;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                instructor.InstructorId = id;
                instructor.FirstName = dataSet.Tables[0].Rows[0]["first_name"].ToString();
                instructor.LastName = dataSet.Tables[0].Rows[0]["last_name"].ToString();
                instructor.Title = dataSet.Tables[0].Rows[0]["title"].ToString();
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }

            return instructor;
        }

        public void AssignInstructorToClass(int instructor_id, int scheduleID, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);

            try
            {
                var adapter = new SqlDataAdapter(AssignInstructorToClassProcedure, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@instructor_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters["@instructor_id"].Value = instructor_id;
                adapter.SelectCommand.Parameters["@schedule_id"].Value = scheduleID;

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
    }
}
