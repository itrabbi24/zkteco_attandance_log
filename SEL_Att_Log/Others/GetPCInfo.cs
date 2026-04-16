using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEL_Att_Log.Others
{
    class GetPCInfo
    {
        private static string volInfo;

        private static void GetProcessStatus()
        {
            try
            {
                //If you know the name of the process
                Process[] myProcesses = Process.GetProcessesByName("mspaint");
                //If you know the PID of the process use the commented line below
                //Process[] myProcesses = Process.GetProcessById("2341");
                //Check to see if the process array length is greater than 0
                if (myProcesses.Length > 0)
                {
                    MessageBox.Show("The Process Microsoft Paint(mspaint) is currently running.", "Process Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("The Process Microsoft Paint(mspaint) is currently NOT running.", "Process Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Exception Occoured: " + ex.Message, "Process Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        internal static string GetProcessorId()
        {
            try
            {
                string volInfo = string.Empty;
                string strProcessorId = string.Empty;
                SelectQuery query = new SelectQuery("Win32_processor");
                ManagementObjectSearcher search = new ManagementObjectSearcher(query);
                //INSTANT C# NOTE: Commented this declaration since looping variables in 'foreach' loops are declared in the 'foreach' header in C#:
                //			Dim info As ManagementObject

                foreach (ManagementObject info in search.Get())
                {
                    strProcessorId = info["processorId"].ToString();
                }
                return strProcessorId;

                //return null;

            }
            catch
            {
                goto locerr;
            }
        locerr:
            volInfo = GetVolumeSerial();
            return volInfo;

        }

        internal static string GetMACAddress()
        {

            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            string MACAddress = string.Empty;
            foreach (ManagementObject mo in moc)
            {

                if (MACAddress.Equals(string.Empty))
                {
                    if (Convert.ToBoolean(mo["IPEnabled"]))
                    {
                        MACAddress = mo["MacAddress"].ToString();
                    }

                    mo.Dispose();
                }
                MACAddress = MACAddress.Replace(":", string.Empty);

            }
            return MACAddress;
        }


        public static string GetIPAddress()
        {

            string strHostName = null;

            string strIPAddress = "";


            strHostName = System.Net.Dns.GetHostName();
            IPAddress[] addresses = Dns.GetHostEntry(strHostName).AddressList;

            foreach (IPAddress address in addresses)
            {
                if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) //for class 4 ip address
                {
                    if (!string.IsNullOrEmpty(strIPAddress))
                    {
                        strIPAddress = strIPAddress + ", ";
                    }
                    strIPAddress = strIPAddress + address.ToString();

                }
            }


            return strIPAddress;
        }

        internal static string GetVolumeSerial(string strDriveLetter = "C")
        {

            ManagementObject disk = new ManagementObject(string.Format("win32_logicaldisk.deviceid=\"{0}:\"", strDriveLetter));
            disk.Get();
            return disk["VolumeSerialNumber"].ToString();
        }

        internal static string GetMotherBoardID()
        {

            string strMotherBoardID = string.Empty;
            SelectQuery query = new SelectQuery("Win32_BaseBoard");
            ManagementObjectSearcher search = new ManagementObjectSearcher(query);
            //INSTANT C# NOTE: Commented this declaration since looping variables in 'foreach' loops are declared in the 'foreach' header in C#:
            //		Dim info As ManagementObject
            foreach (ManagementObject info in search.Get())
            {

                strMotherBoardID = info["SerialNumber"].ToString();

            }
            return strMotherBoardID;

        }

        internal static string GetPCName()
        {
            return Environment.MachineName;
        }




    }
}
