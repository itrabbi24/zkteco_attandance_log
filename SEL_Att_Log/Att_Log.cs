using Microsoft.Win32;
using SEL_Att_Log.Others;
using System;
/**********************************************************
 // Devloper By RABBI-01955109710
 // RotexIT
***********************************************************/


using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zkemkeeper;

namespace SEL_Att_Log
{
    public partial class Att_Log : Form
    {




        SqlConnection conn = new SqlConnection(ServerConn.connetionString);

        public zkemkeeper.CZKEM ConnGetDevice = new zkemkeeper.CZKEM();
        private string sql;
        private int _timer_Tick;
        public string UserID;
        public string FullNameName;
        public int FingerIndex;
        public string FPTemp;
        public string UserMesignID { get; private set; }
        public string InOutTime { get; private set; }






        public Att_Log()
        {
            InitializeComponent();
        }

        private void Att_Log_Load(object sender, EventArgs e)
        {
            Initital_Load();
            //this.ControlBox = false;
            txtVerson.Text = "Verson: " + ServerConn.Verson;

            if (ServerConn.ServerPCName == ServerConn.ComName)
            {
                if (ServerConn.SoftStatus == true)
                {
                    if (ServerConn.ServerSoftVerson != ServerConn.Verson)
                    {

                        Close();
                        Process.Start("Att_Log_Updater.exe");
                    }
                    else
                    {
                        DeviceConnect();
                    }

                }
            }
        }
        public void DeviceConnect()
        {
            int idwErrorCode = 0;
            Cursor = Cursors.WaitCursor;
            if (lblState.Text == "DisConnect")
            {
                ConnGetDevice.Disconnect();
                ServerConn.bIsConnected = false;
                lblState.Text = "DisConnected";
                lblState.ForeColor = System.Drawing.Color.Red;
                Cursor = Cursors.Default;
                return;
            }

            ServerConn.bIsConnected = ConnGetDevice.Connect_Net(ServerConn.DeviceIP, ServerConn.DevicePort);
            if (ServerConn.bIsConnected == true)
            {
                lblState.Text = "Connected";
                lblState.ForeColor = System.Drawing.Color.Green;
                ServerConn.iMachineNumber = 1;
                ConnGetDevice.RegEvent(ServerConn.iMachineNumber, 65535);

                DeviceTotalLog();
                timer.Start();
            }
            else
            {
                ConnGetDevice.GetLastError(ref idwErrorCode);
                lblState.Text = "Unable to connect the device";
            }
            Cursor = Cursors.Default;
            //CountTotalDeviceUser();
        }
        public void Initital_Load()
        {
            txtPCIPAddress.Text = GetPCInfo.GetIPAddress();
            txtPCName.Text = GetPCInfo.GetPCName();
            

            sql = "select * from Device_Info where ";
            sql = sql + "PCName = '" + ServerConn.ComName + "' AND Status = 1 ";

            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows == true)
            {
                ServerConn.DeviceIP = reader["IPAddress"].ToString();
                ServerConn.DevicePort = Convert.ToInt32(reader["Port"].ToString());
                ServerConn.ServerPCName = reader["PCName"].ToString();
                ServerConn.BranchCode = reader["BranchCode"].ToString();
                ServerConn.SoftStatus = Convert.ToBoolean(reader["Status"].ToString());
                ServerConn.DataSourceTime = Convert.ToInt32(reader["DataSourceTime"].ToString());
                ServerConn.DeviceNumber = Convert.ToInt32(reader["DeviceNumber"].ToString());
                ServerConn.DeviceUserModify = Convert.ToBoolean(reader["Modify_Status"].ToString());



                string CheckLastOnline = reader["Last_Online"].ToString();
                if (CheckLastOnline != null)
                {
                    ServerConn.CheckLastOnline = Convert.ToDateTime(reader["Last_Online"].ToString());
                }
                else
                {
                    ServerConn.CheckLastOnline = null;
                }


                string Last_Download_Data = reader["Last_Download_Data"].ToString();

                if (Last_Download_Data != "")
                {
                    ServerConn.LastDownloadData = Convert.ToDateTime(reader["Last_Download_Data"].ToString());
                }
                else
                {
                    ServerConn.LastDownloadData = null;
                }



                tbxDeviceIP.Text = ServerConn.DeviceIP;
                tbxPort.Text = Convert.ToString(ServerConn.DevicePort);
                this.Text = "Attendance Log (" + ServerConn.BranchCode + ")";
            }

            if (reader.HasRows == false)
            {
                ServerConn.SoftwarePermit = false;
            }
            else
            {
                ServerConn.SoftwarePermit = true;
                sql = "select * from Soft_Verson ";
                SqlCommand cmd1 = new SqlCommand(sql, conn);
                SqlDataReader reader1 = cmd1.ExecuteReader();
                reader1.Read();
                if (reader1.HasRows == true)
                {
                    ServerConn.ServerSoftVerson = reader1["Verson"].ToString();
                }

                reader1.Close();

                //====================== Startup File Setup ====================

                RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                key.SetValue("SEL_Att_Log", Application.ExecutablePath);

                //====================== Startup File Setup ====================
            }

            txtBranchCode.Text = ServerConn.BranchCode;

            reader.Close();
            conn.Close();
        }
        


        //============================== ********* Data Download to server *************** ==============================

        private void timer_Tick(object sender, EventArgs e)
        {
            if (ServerConn.ServerPCName == ServerConn.ComName)
            {

                Application.DoEvents();
                _timer_Tick++;
                txtTimerCount.Text = "Data Source :" + " " + _timer_Tick.ToString();
                //CheckLiveOnline();
                if (_timer_Tick == ServerConn.DataSourceTime)
                {
                    txtTimerCount.Text = "Done";
                    _timer_Tick = 0;
                    timer.Start();

                    Initital_Load();  // Load Start 
                    GenerateLogData(); // Generate & Download New Data from device
                    ServerConn.SoftRunTime = 0;
                    
                    if (ServerConn.DeviceUserModify == true)  // Get Device New ID
                    {
                        UpdateUserInfo();
                    }
                }


                txtRunTime.Text = "Run Time :" + " " + ServerConn.SoftRunTime++;
                if (txtRunTime.Text == "Run Time : 1")
                {
                    if (this.WindowState == FormWindowState.Minimized)
                    {
                        Hide();
                        notifyIcon.Visible = true;
                        notifyIcon.ShowBalloonTip(1000);
                    }
                }

            }
            if (ServerConn.SoftRunTime == 0)
            {
                ServerConn.SoftRunTime = 1;
                this.Hide();
                frmPcPermission frmPcPermission = new frmPcPermission();
                frmPcPermission.Show();
            }
        }

        public void CheckLiveOnline()
        {
            sql = "Update Device_Info SET Last_Online = '" + DateTime.Now + "'   ";
            sql = sql + "WHERE BranchCode = '" + ServerConn.BranchCode + "' AND PCName = '" + ServerConn.ComName + "' ";
            sql = sql + "AND DeviceNumber = '" + ServerConn.DeviceNumber + "' ";
            conn.Open();
            SqlCommand cmd2 = new SqlCommand(sql, conn);
            cmd2.ExecuteNonQuery();
            conn.Close();
        }

        public void GenerateLogData()
        {

            if (ServerConn.bIsConnected == false)
            {
                lblState.Text = "DisConnected";
                return;
            }

            int idwErrorCode = 0;

            string sdwEnrollNumber = "";
            int idwVerifyMode = 0;
            int idwInOutMode = 0;
            int idwYear = 0;
            int idwMonth = 0;
            int idwDay = 0;
            int idwHour = 0;
            int idwMinute = 0;
            int idwSecond = 0;
            int idwWorkcode = 0;


            Cursor = Cursors.WaitCursor;
            ConnGetDevice.EnableDevice(ServerConn.iMachineNumber, false);//disable the device
            if (ConnGetDevice.ReadGeneralLogData(ServerConn.iMachineNumber))//read all the attendance records to the memory
            {
                while (ConnGetDevice.SSR_GetGeneralLogData(ServerConn.iMachineNumber, out sdwEnrollNumber, out idwVerifyMode,
                            out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour,
                            out idwMinute, out idwSecond, ref idwWorkcode))//get records from the memory
                {

                    string inputDate = new DateTime(idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond).ToString();

                    inputDate = idwYear.ToString() + "-" + idwMonth.ToString() + "-" + idwDay.ToString() + " " + idwHour.ToString() + ":" + idwMinute.ToString() + ":" + idwSecond.ToString();
                    UserMesignID = sdwEnrollNumber;

                    //--------------------- Download Log data------------------


                    if (UserMesignID != "1")
                    {
                        UserMesignID = sdwEnrollNumber;
                        InOutTime = inputDate;

                        Download_Generate_Log_Data();
                    }


                    //--------------------- Download Log data------------------
                }
            }
            else
            {
                Cursor = Cursors.Default;
                ConnGetDevice.GetLastError(ref idwErrorCode);
            }
            ConnGetDevice.EnableDevice(ServerConn.iMachineNumber, true);//enable the device
            Cursor = Cursors.Default;
        }

        public void Download_Generate_Log_Data()
        {

            Application.DoEvents();  //to make the UI responsive
            ServerConn.LogCountProcess = ServerConn.LogCountProcess + 1;
            txtProcessBar.Text = "Log Process: " + Convert.ToString(ServerConn.LogCountProcess);
            Application.DoEvents();  //to make the UI responsive


            if (ServerConn.LastDownloadData < Convert.ToDateTime(InOutTime) || ServerConn.LastDownloadData == null)
            {

                conn.Close();
                // Check between two month log record
                if (ServerConn.TwoMonthAgeDate < Convert.ToDateTime(InOutTime))
                {

                    sql = "select * from In_Out_Time where ";
                    sql = sql + "In_Out_Time = '" + Convert.ToDateTime(InOutTime) + "' ";
                    sql = sql + "AND Bag_Number = '" + UserMesignID + "' ";
                    sql = sql + "AND Branch_Code = '" + ServerConn.BranchCode + "' ";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows == true)
                    {
                        ServerConn.UserMesignID = reader["Bag_Number"].ToString();
                        ServerConn.InOutTime = Convert.ToDateTime(reader["In_Out_Time"].ToString());
                    }
                    else
                    {
                        ServerConn.UserMesignID = "";
                        ServerConn.InOutTime = DateTime.Now.AddYears(-100);
                    }
                    reader.Close();
                    conn.Close();

                    if (ServerConn.UserMesignID == "" || ServerConn.InOutTime == DateTime.Now.AddYears(-100))
                    {
                        sql = "INSERT INTO In_Out_Time (Bag_Number, In_Out_Time, PC_Name, Com_Reg, Branch_Code, Input_Date_Time, Device_ID, Version) ";
                        sql = sql + "VALUES('" + UserMesignID + "', '" + InOutTime + "', '" + ServerConn.ComName + "', '" + ServerConn.ComReg + "', '" + ServerConn.BranchCode + "',getdate(),'" + ServerConn.DeviceNumber + "', '" + ServerConn.Verson + "') ";
                        SqlCommand cmd1 = new SqlCommand(sql, conn);
                        conn.Open();
                        cmd1.ExecuteNonQuery();



                        sql = "Update Device_Info SET Last_Online = '" + DateTime.Now + "',   ";
                        sql = sql + "Last_Download_Data = '" + InOutTime + "'  ";
                        sql = sql + "WHERE BranchCode = '" + ServerConn.BranchCode + "' AND PCName = '" + ServerConn.ComName + "' ";
                        sql = sql + "AND DeviceNumber = '" + ServerConn.DeviceNumber + "' ";
                        SqlCommand cmd2 = new SqlCommand(sql, conn);
                        cmd2.ExecuteNonQuery();

                        conn.Close();

                        
                    }

                }
            }
        }


        //============================== ********* Data Download to server *************** ==============================


        //=============================Insert New && ALL User In Database==============================


        public void UpdateUserInfo()
        {
            btnDownloadLog.Enabled = false;
            btnDownloadUser.Enabled = false;

            string sdwEnrollNumber = string.Empty, sName = string.Empty, sPassword = string.Empty, sTmpData = string.Empty;
            int iPrivilege = 0, iTmpLength = 0, iFlag = 0, idwFingerIndex;
            bool bEnabled = false;

            while (ConnGetDevice.SSR_GetAllUserInfo(ServerConn.iMachineNumber, out sdwEnrollNumber, out sName, out sPassword, out iPrivilege, out bEnabled))
            {


                Application.DoEvents();  //to make the UI responsive
                ServerConn.UserCountProcess = ServerConn.UserCountProcess + 1;
                txtUserProcess.Text = "User Process: " + Convert.ToString(ServerConn.UserCountProcess);
                _timer_Tick = 0;
                Application.DoEvents();  //to make the UI responsive




                for (idwFingerIndex = 0; idwFingerIndex < 10; idwFingerIndex++)
                {
                    // Select ALL User Cross Check Database Available no
                    if (ConnGetDevice.GetUserTmpExStr(ServerConn.iMachineNumber, sdwEnrollNumber, idwFingerIndex, out iFlag, out sTmpData, out iTmpLength))
                    {
                        UserID = sdwEnrollNumber;
                        FullNameName = sName;
                        FingerIndex = idwFingerIndex;
                        FPTemp = sTmpData;
                        var MachineNumber = ServerConn.iMachineNumber;
                        var Privelage = iPrivilege;
                        var Password = sPassword;
                        var Enabled = bEnabled;
                        var iFlagS = iFlag.ToString();





                        Application.DoEvents();  //to make the UI responsive
                        ServerConn.UserCountProcess = ServerConn.UserCountProcess + 1;
                        txtUserProcess.Text = "User Process: " + Convert.ToString(ServerConn.UserCountProcess);
                        _timer_Tick = 0;
                        Application.DoEvents();  //to make the UI responsive




                        sql = "select * from User_Info where ";
                        sql = sql + "UserID = '" + UserID + "' ";
                        sql = sql + "AND BranchCode = '" + ServerConn.BranchCode + "' ";
                        sql = sql + "AND DeviceNumber = '" + ServerConn.DeviceNumber + "' ";

                        SqlCommand cmd1 = new SqlCommand(sql, conn);
                        conn.Open();
                        SqlDataReader reader1 = cmd1.ExecuteReader();
                        reader1.Read();
                        if (reader1.HasRows == true)
                        {

                            ServerConn.UserIDFromDB = reader1["UserID"].ToString();
                            ServerConn.FullName = reader1["FullName"].ToString();
                            ServerConn.FPTemp = reader1["FPTemp"].ToString();
                            ServerConn.IDStatus = reader1["ID_Status"].ToString();
                            ServerConn.Done_Status = reader1["Done_Status"].ToString();
                            ServerConn.TransferBranchCode = reader1["BranchCode"].ToString();

                            if (ServerConn.IDStatus == "Off" && ServerConn.Done_Status == "Pending")
                            {
                                ConnGetDevice.SSR_DeleteEnrollData(MachineNumber, UserID, idwFingerIndex);     // Detele User

                                sql = "update User_Info set Done_Status = 'Done' where UserID = '" + ServerConn.UserIDFromDB + "' AND BranchCode = '" + ServerConn.BranchCode + "'  ";
                                SqlCommand cmd2 = new SqlCommand(sql, conn);
                                cmd2.ExecuteNonQuery();
                            }

                        }
                        else
                        {
                            sql = "INSERT INTO User_Info (UserID, FullName, BranchCode, DeviceNumber, FPTemp, Input_Date, Input_PC, Status) ";
                            sql = sql + "VALUES('" + UserID + "', '" + FullNameName + "', '" + ServerConn.BranchCode + "', '" + ServerConn.DeviceNumber + "', '" + FPTemp + "' ,'" + DateTime.Now + "', '" + ServerConn.ComName + "',  '1') ";
                            SqlCommand cmd2 = new SqlCommand(sql, conn);
                            cmd2.ExecuteNonQuery();
                        }
                        conn.Close();
                        reader1.Close();
                    }
                }
            }





            sql = "select UserID, FullName, ID_Status, Done_Status, BranchCode, FPTemp from User_Info where ";
            sql = sql + "BranchCode = '" + ServerConn.BranchCode + "' AND Done_Status = 'Pending' ";

            SqlCommand cmd4 = new SqlCommand(sql, conn);
            conn.Open();

            SqlDataReader reader2 = cmd4.ExecuteReader();
            while (reader2.Read())
            {
                Application.DoEvents();  //to make the UI responsive
                ServerConn.UserCountProcess = ServerConn.UserCountProcess + 1;
                txtUserProcess.Text = "User Process: " + Convert.ToString(ServerConn.UserCountProcess);
                _timer_Tick = 0;
                Application.DoEvents();  //to make the UI responsive


                ServerConn.UserIDFromDB = reader2["UserID"].ToString();
                ServerConn.FullName = reader2["FullName"].ToString();
                ServerConn.FPTemp = reader2["FPTemp"].ToString();
                ServerConn.IDStatus = reader2["ID_Status"].ToString();
                ServerConn.Done_Status = reader2["Done_Status"].ToString();
                ServerConn.TransferBranchCode = reader2["BranchCode"].ToString();

                if (ServerConn.IDStatus == "On" && ServerConn.Done_Status == "Pending")
                {
                    ConnGetDevice.SSR_SetUserInfo(ServerConn.iMachineNumber, ServerConn.UserIDFromDB, ServerConn.FullName, sPassword, iPrivilege, false);    // Add new User In Device
                    ConnGetDevice.SetUserTmpExStr(ServerConn.iMachineNumber, ServerConn.UserIDFromDB, 1, iFlag, ServerConn.FPTemp);          // Add new User In Device


                    sql = "update User_Info set Done_Status = 'Done' where UserID = '" + ServerConn.UserIDFromDB + "' AND BranchCode = '" + ServerConn.BranchCode + "'  ";
                    SqlCommand cmd2 = new SqlCommand(sql, conn);
                    cmd2.ExecuteNonQuery();
                }
                else if (ServerConn.IDStatus == "Transfer" && ServerConn.Done_Status == "Pending")
                {
                    ConnGetDevice.SSR_SetUserInfo(ServerConn.iMachineNumber, ServerConn.UserIDFromDB, ServerConn.FullName, sPassword, iPrivilege, false);    // Add new User In Device
                    ConnGetDevice.SetUserTmpExStr(ServerConn.iMachineNumber, ServerConn.UserIDFromDB, 1, iFlag, ServerConn.FPTemp);          // Add new User In Device

                    sql = "update User_Info set Done_Status = 'Done', BranchCode = '" + ServerConn.TransferBranchCode + "' where UserID = '" + ServerConn.UserIDFromDB + "' AND BranchCode = '" + ServerConn.BranchCode + "'  ";
                    SqlCommand cmd2 = new SqlCommand(sql, conn);
                    cmd2.ExecuteNonQuery();
                }

            }
            conn.Close();



            btnDownloadLog.Enabled = true;
            btnDownloadUser.Enabled = true;
        }


        //=============================Insert New && ALL User In Database==============================



        private void btnDownloadLog_Click(object sender, EventArgs e)
        {
            btnDownloadLog.Enabled = false;
            btnDownloadUser.Enabled = false;

            GenerateLogData();

            btnDownloadLog.Enabled = true;
            btnDownloadUser.Enabled = true;
        }

        public void DeviceTotalLog()
        {
            if (ServerConn.bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }
            int idwErrorCode = 0;
            int iValue = 0;

            ConnGetDevice.EnableDevice(ServerConn.iMachineNumber, false);//disable the device
            if (ConnGetDevice.GetDeviceStatus(ServerConn.iMachineNumber, 6, ref iValue)) //Here we use the function "GetDeviceStatus" to get the record's count.The parameter "Status" is 6.
            {
                txtLogData.Text ="User Log: "+ iValue.ToString();
            }
            else
            {
                ConnGetDevice.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            ConnGetDevice.EnableDevice(ServerConn.iMachineNumber, true);//enable the device
        }


        //====================================Resize================================



        private void AttLogsMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(1000);
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void btnDownloadUser_Click(object sender, EventArgs e)
        {
            UpdateUserInfo();
        }

        private void btnLogClear_Click(object sender, EventArgs e)
        {
            if (ServerConn.bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }
            int idwErrorCode = 0;

            ConnGetDevice.EnableDevice(ServerConn.iMachineNumber, false);//disable the device
            if (ConnGetDevice.ClearGLog(ServerConn.iMachineNumber))
            {
                ConnGetDevice.RefreshData(ServerConn.iMachineNumber);//the data in the device should be refreshed
                MessageBox.Show("All att Logs have been cleared from teiminal!", "Success");
            }
            else
            {
                ConnGetDevice.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            ConnGetDevice.EnableDevice(ServerConn.iMachineNumber, true);//enable the device
        }

        private void btnRestartDevice_Click(object sender, EventArgs e)
        {
            if (ServerConn.bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }
            int idwErrorCode = 0;

            Cursor = Cursors.WaitCursor;
            if (ConnGetDevice.RestartDevice(ServerConn.iMachineNumber) == true)
            {
                MessageBox.Show("The device will restart!", "Success");
            }
            else
            {
                ConnGetDevice.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;

        }

        private void btnPowerOff_Click(object sender, EventArgs e)
        {
            if (ServerConn.bIsConnected == false)
            {
                MessageBox.Show("Please connect the device first", "Error");
                return;
            }
            int idwErrorCode = 0;

            Cursor = Cursors.WaitCursor;
            if (ConnGetDevice.PowerOffDevice(ServerConn.iMachineNumber))
            {
                MessageBox.Show("PowerOffDevice", "Success");
            }
            else
            {
                ConnGetDevice.GetLastError(ref idwErrorCode);
                MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }



        //====================================Resize================================


    }
}
