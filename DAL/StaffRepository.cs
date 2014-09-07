namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using IRepository;

    using POCO;

    public class StaffRepository : BaseRepository, IStaffRepository
    {
        private const string UpdateStaffInfoProcedure = "spUpdateStaffInfo";
        private const string GetStaffInfoProcedure = "spGetStaffInfo";

        public void UpdateStaff(Staff staff, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(UpdateStaffInfoProcedure, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@staff_id", SqlDbType.VarChar, 20));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 64));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 64));


                adapter.SelectCommand.Parameters["@staff_id"].Value = staff.StaffId;
                adapter.SelectCommand.Parameters["@email"].Value = staff.Email;
                adapter.SelectCommand.Parameters["@password"].Value = staff.Password;


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

        public Staff GetStaff(string id, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            Staff staff = null;

            try
            {
                var adapter = new SqlDataAdapter(GetStaffInfoProcedure, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@staff_id", SqlDbType.VarChar, 20));

                adapter.SelectCommand.Parameters["@staff_id"].Value = id;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                staff = new Staff
                {
                    StaffId = dataSet.Tables[0].Rows[0]["staff_id"].ToString(),
                    Email = dataSet.Tables[0].Rows[0]["email"].ToString(),
                    Password = dataSet.Tables[0].Rows[0]["password"].ToString(),
                };
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }

            return staff;
        }
    }
}
