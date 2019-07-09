using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCR_ServiceReminder_CD2.Data
{
    public class HCRServiceReminderCD2Dao
    {
        NpgsqlConnection conn;
        string _connectionString;
        public HCRServiceReminderCD2Dao()
        {
            _connectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["HD.LOCALHOST"]);
            //conn = new NpgsqlConnection(connectionString);
        }
        public DataTable GetTargetedHospitals(List<int> included_hids, List<int> excluded_hids, bool no_sms, DateTime runDate)
        {
            DataSet ds = new DataSet();
            DataTable dtResult = new DataTable();
            var connString = new NpgsqlConnectionStringBuilder(_connectionString) { CommandTimeout = 0 };
            conn = new NpgsqlConnection(connString);
            string queryString = "select * from emailreminder.get_targeted_hospitals_cd2(@incHids,@excHids,@noSMS,@rDate)";
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand(queryString, conn);
            command.Parameters.AddWithValue("@incHids", included_hids);
            command.Parameters.AddWithValue("@excHids", excluded_hids);
            command.Parameters.AddWithValue("@noSMS", no_sms);
            command.Parameters.AddWithValue("@rDate", runDate);

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
            ds.Reset();
            da.Fill(ds);
            dtResult = ds.Tables[0];
            conn.Close();
            return dtResult;
        }
    }
}
