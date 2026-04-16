using SEL_Att_Log.Others;
using SEL_Att_Log.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Att_Log
{
    class ServerConn
    {

        private static string ServerName = Settings.Default.ServerName;
        private static string UserID = Settings.Default.UserID;
        private static string Password = Settings.Default.Password;
        private static string Database = Settings.Default.Database;



        public static string connetionString = "Data Source=" + ServerName + "; Initial Catalog=" + Database + "; MultipleActiveResultSets=True; Connection Timeout=20; User ID=" + UserID + "; Password=" + Password;




        public static bool bIsConnected = false;
        public static int iMachineNumber = 1; // Device Number

        public static string DeviceIP = "";
        public static int DevicePort = 0;
        public static string ServerPCName = "";



        public static int CountTotalUser = 0;



        public static string ComReg = GetPCInfo.GetMotherBoardID();
        public static string ComName = GetPCInfo.GetPCName();
        public static string IPAddress = "";
        public static string BranchCode = "";
        public static int DataSourceTime;
        public static int DeviceNumber;
        public static int SoftRunTime;
        public static bool SoftStatus;
        public static bool SoftwarePermit;
        public static bool DeviceUserModify;

        public static DateTime? CheckLastOnline;
        public static DateTime? LastDownloadData;


        public static string UserMesignID = "";
        public static DateTime InOutTime;



        public static string UserIDFromDB;
        public static string FPTemp;
        public static string IDStatus;
        //public static int UseableID;
        public static string FullName;
        public static string Done_Status;
        public static string TransferBranchCode;


        public static string Verson = "4";

        public static string ServerSoftVerson;

        public static int LogCountProcess = 0;
        public static int UserCountProcess = 0;

        public static DateTime TwoMonthAgeDate = DateTime.Now.AddMonths(-2);





        //========Count Total User Device==========

        //public void CountTotalDeviceUser()
        //{
        //    string sdwEnrollNumber = string.Empty, sName = string.Empty, sPassword = string.Empty, sTmpData = string.Empty;
        //    int iPrivilege = 0, iTmpLength = 0, iFlag = 0, idwFingerIndex;
        //    bool bEnabled = false;

        //    ICollection<UserInfo> lstFPTemplates = new List<UserInfo>();

        //    while (ConnGetDevice.SSR_GetAllUserInfo(ServerConn.iMachineNumber, out sdwEnrollNumber, out sName, out sPassword, out iPrivilege, out bEnabled))
        //    {
        //        for (idwFingerIndex = 0; idwFingerIndex < 10; idwFingerIndex++)
        //        {
        //            if (ConnGetDevice.GetUserTmpExStr(ServerConn.iMachineNumber, sdwEnrollNumber, idwFingerIndex, out iFlag, out sTmpData, out iTmpLength))
        //            {
        //                UserInfo fpInfo = new UserInfo();
        //                fpInfo.MachineNumber = ServerConn.iMachineNumber;
        //                fpInfo.EnrollNumber = sdwEnrollNumber;
        //                fpInfo.Name = sName;
        //                fpInfo.FingerIndex = idwFingerIndex;
        //                fpInfo.TmpData = sTmpData;
        //                ServerConn.CountTotalUser++;
        //                Application.DoEvents();
        //            }
        //        }

        //    }

        //    txtTotalUser.Text = "Total User " + Convert.ToString(ServerConn.CountTotalUser);
        //}

        //========Count Total User Device==========


    }
}
