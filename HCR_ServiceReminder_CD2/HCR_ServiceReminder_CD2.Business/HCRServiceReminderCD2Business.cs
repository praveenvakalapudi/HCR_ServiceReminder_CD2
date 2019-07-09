using HCR_ServiceReminder_CD2.Common.Helpers;
using HCR_ServiceReminder_CD2.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCR_ServiceReminder_CD2.Business
{
    public class HCRServiceReminderCD2Business
    {
        #region variables

        readonly HCRServiceReminderCD2Dao _hcrDao;
        readonly LogFileHelper _log;
        #endregion

        #region CONSTRUCTOR
        public HCRServiceReminderCD2Business()
        {
            _log = new LogFileHelper();
            _hcrDao = new HCRServiceReminderCD2Dao();
        }
        #endregion

        #region HCR
        public void InitiateHCR(DateTime myRunDate)
        {
            string msg = "Starting to execute, RunDate : " + myRunDate.ToString();
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(msg + myRunDate.ToString());
            Console.WriteLine(Environment.NewLine);
            _log.WriteToFile(Environment.NewLine, Convert.ToString(ConfigurationManager.AppSettings["LogFilePath"]));
            _log.WriteToFile(msg, Convert.ToString(ConfigurationManager.AppSettings["LogFilePath"]));

            List<int> incHospitals = new List<int>();
            List<int> excHospitals = new List<int>();
            DataTable dt = _hcrDao.GetTargetedHospitals(incHospitals, excHospitals, true, myRunDate);
        }
        #endregion
    }
}
