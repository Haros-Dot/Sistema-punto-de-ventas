using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Library
{
    public class Ordenador
    {
        public static string Serial()
        {
            string HDD = Environment.CurrentDirectory.Substring(0, 1);
            ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"" + HDD + ":\"");
            disk.Get();
            return disk["volumeSerialNumber"].ToString(); 

        }
    }
}
