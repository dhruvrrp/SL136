namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using IRepository;

    using POCO;

    public class AdminRepository : BaseRepository, IAdminRepository
    {
        private const string InsertNewAdminProcedure = "spCreateNewAdmin";
        private const string DeleteAdminProcedure = "spDeleteAdmin";
        private const string UpdateAdminProcedure = "spUpdateAdmin";
        private const string ViewAdminProcedure = "spReadAdmin";

        void InsertAdmin(Admin admin, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(InsertNewAdminProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@admin_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@first_name", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@last_name", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 64));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 64));

                adapter.SelectCommand.Parameters["@admin_id"].Value = admin.Id;
                adapter.SelectCommand.Parameters["@first_name"].Value = admin.FirstName;
                adapter.SelectCommand.Parameters["@last_name"].Value = admin.LastName;
                adapter.SelectCommand.Parameters["@email"].Value = admin.Email;
                adapter.SelectCommand.Parameters["@password"].Value = admin.Password;

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

        void UpdateAdmin(Admin admin, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(UpdateAdminProcedure, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@admin_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@first_name", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@last_name", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 64));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 64));

                adapter.SelectCommand.Parameters["@admin_id"].Value = admin.Id;
                adapter.SelectCommand.Parameters["@first_name"].Value = admin.FirstName;
                adapter.SelectCommand.Parameters["@last_name"].Value = admin.LastName;
                adapter.SelectCommand.Parameters["@email"].Value = admin.Email;
                adapter.SelectCommand.Parameters["@password"].Value = admin.Password;
                

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

        void DeleteAdmin(int admin_id, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);

            try
            {
                var adapter = new SqlDataAdapter(DeleteAdminProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType =
                            CommandType
                            .StoredProcedure
                    }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@admin_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@admin_id"].Value = admin_id;

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

        Admin GetAdminInfo(int admin_id, ref List<string> errors)
        {

            var conn = new SqlConnection(ConnectionString);

            Admin admin = new Admin();

            try
            {
                var adapter = new SqlDataAdapter(ViewAdminProcedure, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@admin_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@admin_id"].Value = admin_id;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                admin.Id = admin_id;

                admin.FirstName = dataSet.Tables[0].Rows[0]["first_name"].ToString();
                admin.LastName = dataSet.Tables[0].Rows[0]["last_name"].ToString();
                admin.Email = dataSet.Tables[0].Rows[0]["email"].ToString();
                admin.Password = dataSet.Tables[0].Rows[0]["password"].ToString();
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }

            return admin;
        }
    }
}
