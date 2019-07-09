using HCR_ServiceReminder_CD2.Business;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCR_ServiceReminder_CD2
{
    class Program
    {
        static void Main(string[] args)
        {
            HCRServiceReminderCD2Business business = new HCRServiceReminderCD2Business();
            business.InitiateHCR(Convert.ToDateTime(ConfigurationManager.AppSettings["RunDate"]));
        }
    }
}
