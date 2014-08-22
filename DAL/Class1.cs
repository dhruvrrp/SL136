namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using IRepository;

    using POCO;

    public class TaRepository : BaseRepository, IStudentRepository
    {
        private const string InsertNewTaProcedure = "insert_ta";
        private const string DeleteTaProcedure = "delete_ta";
        private const string UpdateTaInformationProcedure = "update_ta";
        private const string ViewTaProcedure = "view_ta";
        private const string AssignTaToClassProcedure = "assign_ta_to_class";
        private const string RemoveTaFromClassProcedure = "remove_ta_from_class";
        private const string ViewTasForClassProcedure = "view_tas_for_class";

        public void InsertTA(int TAiD, String FirstName, String LastName, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(InsertNewTaProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@taID", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@first_name", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@last_name", SqlDbType.VarChar, 50));

                adapter.SelectCommand.Parameters["@taID"].Value = TAiD;
                adapter.SelectCommand.Parameters["@first_name"].Value = FirstName;
                adapter.SelectCommand.Parameters["@last_name"].Value = LastName;

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

        public void UpdateTaInfomation(int TAiD, String FirstName, String LastName, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(UpdateTaInformationProcedure, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@taID", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@first_name", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@last_name", SqlDbType.VarChar, 50));

                adapter.SelectCommand.Parameters["@taID"].Value = TAiD;
                adapter.SelectCommand.Parameters["@first_name"].Value = FirstName;
                adapter.SelectCommand.Parameters["@last_name"].Value = LastName;

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

        public void DeleteTa(int id, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);

            try
            {
                var adapter = new SqlDataAdapter(DeleteTaProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType =
                            CommandType
                            .StoredProcedure
                    }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@taID", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@taID"].Value = id;

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

        public Tuple<String, String> GetTaInfo(int id, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            String FirstName = "", LastName = "";
            try
            {
                var adapter = new SqlDataAdapter(ViewTaProcedure, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@taID", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@taID"].Value = id;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                FirstName = dataSet.Tables[0].Rows[0]["first_name"].ToString();
                LastName = dataSet.Tables[0].Rows[0]["last_name"].ToString();

            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }

            return Tuple.Create(FirstName, LastName);
        }

        public void AssignTaToClass(int taID, int scheduleID, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);


            try
            {
                var adapter = new SqlDataAdapter(AssignTaToClassProcedure, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@taID", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@scheduleID", SqlDbType.Int));
                adapter.SelectCommand.Parameters["@taID"].Value = taID;

                adapter.SelectCommand.Parameters["@scheduleID"].Value = scheduleID;
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




        public void RemoveTaFromClass(int taID, int scheduleID, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);

            try
            {
                var adapter = new SqlDataAdapter(RemoveTaFromClassProcedure, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@taID", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@scheduleID", SqlDbType.Int));
                adapter.SelectCommand.Parameters["@taID"].Value = taID;

                adapter.SelectCommand.Parameters["@scheduleID"].Value = scheduleID;
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
        public List<Tuple<String, String>> ViewTasForClass(int scheduleId, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var TaList = new List<Tuple<String, String>>();
            String FirstName = "", LastName = "";
            try
            {
                var adapter = new SqlDataAdapter(ViewTasForClassProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType
                            =
                            CommandType
                            .StoredProcedure
                    }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@scheduleID", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@scheduleID"].Value = scheduleId;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);


                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                for (var i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    FirstName = dataSet.Tables[0].Rows[0]["first_name"].ToString();
                    LastName = dataSet.Tables[0].Rows[0]["last_name"].ToString();

                    TaList.Add(Tuple.Create(FirstName, LastName));
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
            return TaList;
        }
    }
}
