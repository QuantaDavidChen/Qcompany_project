using System;
using INIDLL;
using Microsoft.Win32;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Security.Permissions;
using System.Diagnostics;
using upload_shopfloor;
using System.Text.RegularExpressions;
using System.IO.Compression;//zip功能




namespace A97_Test
{
 
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //comboBox建立清單
            cboModule.Items.AddRange(moduleName);
            cboStation.Items.AddRange(A92stationName);
            cboCategory.Items.AddRange(CategoryName);

            Form1.CheckForIllegalCrossThreadCalls = false;
        }

        //system.ini 檔案路徑
        string ini_path = Application.StartupPath + Path.DirectorySeparatorChar + "ini\\";


        StoreINI ini = new StoreINI();
        upload upload = new upload();

        //監控
        StringBuilder sb;
        DirectoryInfo dirInfo;
        FileSystemWatcher _watch = new FileSystemWatcher();
        //建立Json file 資料與路徑
        jFileconfig Data = new jFileconfig();
        //檔案位置
        string jfilePath = @"C:\TEST92\FATP\FA_9_Sensors_Calibration\temp_local_dir\devicesn.json";

        string[] moduleName = new string[] {"A92" ,"V61"};
        string[] A92stationName = new string[] { "T11", "T12", "T13","T14", "T20", "T21", "T22", "T23", "T24", "T25","T24&T25", "T26" };
        //string[] V61stationName = new string[] { "LCOS1", "LCOS2" };
        string[] CategoryName = new string[] { "OE" };

        //卡控 SN 位數 --313、344行
        int checkESN_lenth = 12;
        int checkCSN_lenth = 14;



        //建立json
        

        private string lastTitle = string.Empty;
        private string sLastMessage = string.Empty;
        string name = "system";
        string TestCount = "TestCount";


        private void Form1_Load(object sender, EventArgs e)
        {
            txtIP.Text = ini.IniReadValue("SF_dataIP", "QC3", ini_path, name);
            txtLine.Text = ini.IniReadValue("Default", "Line", ini_path, name);
            txtDataBase.Text = ini.IniReadValue("Default", "DB_NAME", ini_path, name);
            //textBox1.Text = ini.IniReadValue("Default", "OprID", ini_path, name);
            cboStation.Text = ini.IniReadValue("Default", "station", ini_path, name);
            cboCategory.Text = ini.IniReadValue("Default", "Category", ini_path, name);
            cboModule.Text = ini.IniReadValue("Default", "model", ini_path, name);
            txtHWRev.Text = ini.IniReadValue("Default", "HWRev", ini_path, name);
            txtFWRev.Text = ini.IniReadValue("Default", "FWRev", ini_path, name);

            ini.IniWriteValue("Offlinesetting", "offline", "off", ini_path, name);
            ini.IniWriteValue("checkStatus", "result", "PASS", ini_path, name);
            ini.IniWriteValue("TestCount", "SN", "CountNumber", ini_path, TestCount);
            ini.IniWriteValue("Offlinesetting", "offline", "off", ini_path, name);

            if (cboStation.Text == "T23" || cboStation.Text == "T14" || cboStation.Text == "T21" || cboStation.Text == "T11")
            {
                ini.IniWriteValue("Default", "OutPutPath", "C:\\A92\\TestCSV\\ ", ini_path, name);
            }
            else 
            {
                ini.IniWriteValue("Default", "OutPutPath", "D:\\A92\\TestCSV\\ ", ini_path, name);
            }




            // checklistbox 新增項目
            if (cboStation.Text == "T11")
            {
                checkedListBox1.Items.Insert(0, "Touch pad and touch controller");
                checkedListBox1.Items.Insert(1, "Battery voltage under load");
            }
            else if (cboStation.Text == "T12")
            {
                checkedListBox1.Items.Insert(0, "ON/OFF button test");
                checkedListBox1.Items.Insert(1, "Status LED test");
                checkedListBox1.Items.Insert(2, "battery voltage under load test");
                checkedListBox1.Items.Insert(3, "USB VBUS voltage under load test");
            }
            else if (cboStation.Text == "T13")
            {
                checkedListBox1.Items.Insert(0, "Leakage Current");
                checkedListBox1.Items.Insert(1, "Power-UP");
                checkedListBox1.Items.Insert(2, "MAXIM MCU Flashing");
                checkedListBox1.Items.Insert(3, "Chip Revision");
                checkedListBox1.Items.Insert(4, "RGB LED test");
                checkedListBox1.Items.Insert(5, "OLED Display");
                checkedListBox1.Items.Insert(6, "Input GPIO test");
                checkedListBox1.Items.Insert(7, "Proximity test");
                checkedListBox1.Items.Insert(8, "AMBIENT test");
                checkedListBox1.Items.Insert(9, "Voltage/Current test");
                checkedListBox1.Items.Insert(10, "I2C test");
                checkedListBox1.Items.Insert(11, "Charger");
                checkedListBox1.Items.Insert(12, "RTC test");
            }
            else if (cboStation.Text == "T14")
            {
                checkedListBox1.Items.Insert(0, "Battery voltage");
                checkedListBox1.Items.Insert(1, "Touch pad and touch controller");
            }
            else if (cboStation.Text == "T20")
            {
                checkedListBox1.Items.Insert(0, "Power-UP");
                checkedListBox1.Items.Insert(1, "MAXIM & ST MCU Flashing");
                checkedListBox1.Items.Insert(2, "Chip Revision");
                checkedListBox1.Items.Insert(3, "RGB LED test");
                checkedListBox1.Items.Insert(4, "Proximity test");
                checkedListBox1.Items.Insert(5, "AMBIENT test");
                checkedListBox1.Items.Insert(6, "Touch pad and touch controller");
                checkedListBox1.Items.Insert(7, "Charger and fuel gauge");
                checkedListBox1.Items.Insert(8, "I2C test");
                checkedListBox1.Items.Insert(9, "OLED Display");
                checkedListBox1.Items.Insert(10, "Fuel Gauge reset (Rework) test");
            }
            else if (cboStation.Text == "T21")
            {
                checkedListBox1.Items.Insert(0, "Bluetooth output power");
            }
            else if (cboStation.Text == "T22")
            {
                checkedListBox1.Items.Insert(0, "Optical performance test");
                checkedListBox1.Items.Insert(1, "Dirt & Double image (Optional)");
                checkedListBox1.Items.Insert(2, "Display FOV test");
            }
            else if (cboStation.Text == "T23")
            {
                checkedListBox1.Items.Insert(0, "Inertial sensors calibration");
            }
            else if (cboStation.Text == "T24&T25")
            {
                checkedListBox1.Items.Insert(0, "battery capacity adjustment");
                checkedListBox1.Items.Insert(1, "MAXIM MCU Flashing");
                checkedListBox1.Items.Insert(2, "Reset ETI");
                checkedListBox1.Items.Insert(3, "ST MCU Flashing");
            }
            else if (cboStation.Text == "T26")
            {
                checkedListBox1.Items.Insert(0, "Final Functional test");
            }



            //開啟監控
            MyFileSystemWatcher();

            //鎖定groupBox1
            groupBox1.Enabled = false;
            CSNtxt.Enabled =false;
            button1.Visible = false;

            
            //txtLog 設定唯讀
            txtLog.ReadOnly = true;


            this.WindowState = System.Windows.Forms.FormWindowState.Normal;


        }

        public class jFileconfig
        {
            public string dev_size;
        }
        private void MyFileSystemWatcher()
        {
            //監控路徑
            //string sMonitorPath = Application.StartupPath + Path.DirectorySeparatorChar;
            //string sMonitorPath = @"D:\" + cboModule +"\\" + cboStation.Text + "\\" + SN_text.Text ;
            string sMonitorPath = ini.IniReadValue("Default", "InputPath", ini_path, name);
            
            /*判斷路徑下有沒有監控的資料夾
            if (Directory.Exists(sMonitorPath) == false)
            {
                //如果不存在就建立日期資料夾
                DirectoryInfo di = Directory.CreateDirectory(sMonitorPath);
            }
            */

            //設定所要監控的資料夾
            _watch.Path = sMonitorPath;

            //設定所要監控的變更類型
            _watch.NotifyFilter = NotifyFilters.LastWrite; // NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;

            //設定所要監控的檔案
            _watch.Filter = "ready.txt";

            //設定是否監控子資料夾
            _watch.IncludeSubdirectories = false;

            //是否開啟監控
            _watch.EnableRaisingEvents = true;

            //設定觸發事件         
            _watch.Changed += new FileSystemEventHandler(_watch_Changed);
        }

        private void _watch_Changed(object sender, FileSystemEventArgs e)
        {
            string sPath;       //儲存路徑
            string sFloderName; //資料夾名稱
            string sFullPath;   //完整路徑
            string sDate;       //目前日期
            

            /*
            string sRoutingResult = upload.CheckRouting(txtIP.Text, txtDataBase.Text, SN_text.Text, txtLine.Text, cboStation.Text, textBox1.Text);

            if (sRoutingResult != "Result=OK;$;Message=OK;$;")
            {
                _watch.EnableRaisingEvents = false;
                log("Routing Fail !" + "\r\n" + sRoutingResult, txtLog);
                SN.Text = "";
             
                return;
            }
            */
            try
            {

                sb = new StringBuilder();

                dirInfo = new DirectoryInfo(e.FullPath.ToString());

                //檔案儲存路徑                
                //string sOutputPath = ini.IniReadValue("Default", "OutPutPath", ini_path, name);

                //檔案名稱                
                //string sOutputFileName = ini.IniReadValue("Default", "OutPutName", ini_path, name);

                //檔案路徑
                //string sOutputFullPath = sOutputPath + sOutputFileName + ".txt";


                sPath = ini.IniReadValue("Default", "OutPutPath", ini_path, name);
                string server_Path = ini.IniReadValue("Default", "ServerPath", ini_path, name);
                sFloderName = cboStation.Text; //Station 在路徑下新增資料夾
                sFullPath = sPath + sFloderName; //公用存放路徑
                sDate = DateTime.Now.ToString("yyyMMdd");

                //判斷資料夾是否存在
                if (Directory.Exists(sFullPath) == false)
                {
                    //如果不存在就建立資料夾
                    DirectoryInfo di = Directory.CreateDirectory(sFullPath);
                }

                //判斷資料夾下是否存在該日期的資料夾
                if (Directory.Exists(sFullPath + "\\" + sDate) == false)
                {
                    //如果不存在就建立日期資料夾
                    DirectoryInfo di = Directory.CreateDirectory(sFullPath + "\\" + sDate);
                }

                //判斷資料夾是否存在
                if (Directory.Exists(server_Path + sFloderName ) == false)
                {
                    //如果不存在就建立資料夾
                    DirectoryInfo di = Directory.CreateDirectory(server_Path + sFloderName);
                }

                //判斷資料夾是否存在
                if (Directory.Exists(server_Path + sFloderName + "\\" + sDate) == false)
                {
                    //如果不存在就建立資料夾
                    DirectoryInfo di = Directory.CreateDirectory(server_Path + sFloderName + "\\" + sDate);
                }

                outputCSV();

                /*
                using (StreamReader stReader = new StreamReader(Application.StartupPath + Path.DirectorySeparatorChar + "\\" + SN_text.Text + ".txt"))
                {
                    sData = stReader.ReadLine();
                    sData = sData.Replace(" ","");
                    log(sData, txtLog);
                    stReader.Close();
                }
                */
            }
            catch (Exception d)
            {
                //_watch.EnableRaisingEvents = false; //20210305  //20210309
                log("The _watch_Changed failed: " + d.ToString(), txtLog);
                //MessageBox.Show("The _watch_Changed failed: " + d.ToString());
                return;
            }
            finally
            {

            }
        }

        //--------------------------------程式執行--------------------------------
        private void Start_Click(object sender, EventArgs e)
        {
            ini.IniWriteValue("checkStatus", "result", "PASS", ini_path, name);

            log(ini.IniReadValue("Default", "connect", ini_path, name), txtLog);
            if (int.Parse(ini.IniReadValue("Default", "connect", ini_path, name)) > 400)
            {
                if (MessageBox.Show("請更換FPC !!!" + "\r\n" + "請更換FPC !!!" + "\r\n" + "請更換FPC !!!" + "\r\n" + "請通知指導員!!!" + "\r\n" + "請通知DAVID!!!", "問題", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SN_text.Enabled = true;
                    SN_text.Text = "";
                    string swapDate = DateTime.Now.ToString("yyyMMdd");
                    ini.IniWriteValue("Default", "connect", "0", ini_path, name);
                    ini.IniWriteValue("SwapFPC", swapDate, "Done", ini_path, "SwapTestFPC");
                    return;
                }
                else
                {
                    SN_text.Enabled = true;
                    SN_text.Text = "";
                    return;
                }
            }

            int countFPC_num = int.Parse(ini.IniReadValue("Default", "connect", ini_path, name));
            log("FPC Connect Time → " + countFPC_num.ToString(), txtLog);



            if (checktheData())
            {

                if (ini.IniReadValue("OfflineSetting", "offline", ini_path, name) == "on")
                {
                    log("********Offline Testing********" + "\r\n", txtLog);
                }
                log("----------Test Start----------" + "\r\n", txtLog);


                _watch.EnableRaisingEvents = true;

                //
                Count();

                //-----upload 指令-----
                //string data = upload.GetData("10.228.24.38", "SWH", "LRU0354", "E3", "SPS", "" , textBox1.Text);
                //string data2 = upload.XXXX("10.228.24.38", "SWH", "40603A0X12310011", "OE");
                //string data1 = upload.SNInfo("10.228.24.38", "SWH", "LRU0354", "WAVEGUIDER");
                //string data3 = upload.GetSMTmac("10.228.24.38", "SWH", "40603A0X12320007", "E3", "SFR");
                //string macData = upload.Getbtmac("10.228.24.38", "SWH", SN_text.Text); //抓取藍芽
                


                writeBat();

                //-----執行Bat檔

                ProcessStartInfo testInfo = new ProcessStartInfo();
                testInfo.FileName = "TEST.bat";
                //testInfo.WorkingDirectory = Application.StartupPath + Path.DirectorySeparatorChar;
                testInfo.WorkingDirectory = ini.IniReadValue("Default", "InputPath", ini_path, name); 
                Process.Start(testInfo);

            }
            else
            {
                log("Error! Please Check The DataInfo!", txtLog);
            }
        }

        //--------------------------------程式結束--------------------------------






        //寫入ERROR_CODE
        private void bntError_Click(object sender, EventArgs e)
        {
            string sSFdata;
            string sError;

            if (SN_text.Text != "")
            {
                if (errortxt.Text.Length == 5)
                {
                    sSFdata = SN_text.Text.ToUpper() + errortxt.Text + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
                               + "," + cboStation.Text + "," + textBox1.Text;
                    sError = upload.SaveResult(txtIP.Text, txtDataBase.Text, SN_text.Text, txtLine.Text, cboStation.Text, errortxt.Text, textBox1.Text.ToString());
                    log(sError, txtLog);
                    upload.TestDataSave(txtIP.Text, txtDataBase.Text, SN_text.Text, txtLine.Text, cboStation.Text, sSFdata, textBox1.Text.ToString());
                }
                else
                {
                    log(errortxt.Text + " Error! Please Check The Error_Code!", txtLog);
                }
            }
            else
            {
                log("SN format ERROR! ", txtLog);
            }

        }


        //----------------------------------------Form切換----------------------------------------
        public Form1(string opidMsg)
        {
            InitializeComponent();
            textBox1.Text = opidMsg;
            
        }

        public string textboxMSG
        {
            set
            {
                SN_text.Focus();
                textBox1.Text = value;
            }
            get
            {
                return textBox1.Text;
            }
        }
        //----------------------------------------Form切換----------------------------------------

        private Boolean checktheData()
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("請輸入 作業員 OPID", "提示");
                return false;
            }
            if (txtIP.Text == "")
            {
                log("請輸入IP", txtLog);
                return false;
            }
            if (cboStation.Text == "")
            {
                MessageBox.Show("請輸入 Station", "提示");
                return false;
            }
            if (SN_text.Text == "" || SN_text.Text.Length != checkESN_lenth)
            {
                MessageBox.Show("請確認SN是否正確", "提示");
                return false;
            }
            if (txtLine.Text == "")
            {
                log("請輸入Line", txtLog);
                return false;
            }
            if (cboModule.Text == "")
            {
                log("請選擇Module", txtLog);
                return false;
            }
            if (cboCategory.Text == "")
            {
                log("請選擇Category", txtLog);
                return false;
            }
            if (txtDataBase.Text == "")
            {
                log("請輸入Database", txtLog);
                return false;
            }

            return true;
        }

        private void SN_text_TextChanged(object sender, EventArgs e)
        {


            if (SN_text.Text.Length == checkESN_lenth)
            {

                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }

                //確認SN Rounting

                string qStation = ini.IniReadValue("station", cboStation.Text, ini_path, name);
                string sResult = upload.CheckRouting(txtIP.Text, txtDataBase.Text, SN_text.Text,txtLine.Text, qStation, textBox1.Text);
                if (ini.IniReadValue("Offlinesetting", "offline", ini_path, name) == "off")
                {
                    if (sResult != "Result=OK;$;Message=OK;$;" && SN.Text != "")
                    {

                        MessageBox.Show("Routing NG\r\n" + sResult, "提示");
                        log("Routing NG", txtLog);
                        log(sResult, txtLog);
                        SN_text.Enabled = true;
                        SN_text.Text = "";
                        return;
                    }
                    else
                    {
                        txtLog.AppendText("Routing Sucessful" + "\r\n");

                        log("--------------------", txtLog);
                        log("ESN Length OK", txtLog);
                        log("--------------------" + "\r\n", txtLog);

                        SN_text.Enabled = false;
                        pass_fail.Text = "";
                        pass_fail.BackColor = Color.AliceBlue;
                    }
                }
                else
                {
                    log("--------------------", txtLog);
                    log("ESN Length OK", txtLog);
                    log("--------------------" + "\r\n", txtLog);

                    SN_text.Enabled = false;
                    pass_fail.Text = "";
                    pass_fail.BackColor = Color.AliceBlue;
                }
                

            }

        }

        //CSV檔 輸出模組
        private void outputCSV()
        {
            _watch.EnableRaisingEvents = false;


            string sPath;       //儲存路徑
            string sFloderName; //資料夾名稱
            string sFullPath;   //完整路徑
            string sDate;       //目前日期
            string sInputPath;  //程式路徑

            List<string> lFailitem = new List<string>();

            sPath = ini.IniReadValue("Default", "OutPutPath", ini_path, name);
            sFloderName = cboStation.Text; //Station 在路徑下新增資料夾
            sFullPath = sPath + sFloderName; //公用存放路徑
            sDate = DateTime.Now.ToString("yyyMMdd");
            sInputPath = ini.IniReadValue("Default", "InputPath", ini_path, name);

            string csvPath = sFullPath + "\\" + sDate;
            string serverPath = ini.IniReadValue("Default", "ServerPath", ini_path, name) + sFloderName + "\\" + sDate;

            if (File.Exists(csvPath + "\\" + SN_text.Text + "_" + DateTime.Now.ToString("HHmmss") + ".csv"))
            {
                using (StreamWriter Writelog = new StreamWriter(csvPath + "\\" + SN_text.Text + "_" + DateTime.Now.ToString("HHmmss") + ".csv"))
                {//檔案如果不存在，使用StreamWriter就會自動建立文件，使用Create 會有資料殘留現象
                 //關閉檔案
                    Writelog.Close();
                }
            }

            if (File.Exists(serverPath + "\\" + SN_text.Text + "_" + DateTime.Now.ToString("HHmmss") + ".csv"))
            {
                using (StreamWriter Writelog = new StreamWriter(serverPath + "\\" + SN_text.Text + "_" + DateTime.Now.ToString("HHmmss") + ".csv"))
                {//檔案如果不存在，使用StreamWriter就會自動建立文件，使用Create 會有資料殘留現象
                 //關閉檔案
                    Writelog.Close();
                }
            }

            if (!File.Exists(serverPath + "\\" + "Summary.csv"))
            {
                using (StreamWriter Writelog = new StreamWriter(serverPath + "\\" + "Summary.csv"))
                {//檔案如果不存在，使用StreamWriter就會自動建立文件，使用Create 會有資料殘留現象
                 //關閉檔案
                    Writelog.Close();
                }
            }


            try
            {
                string strNowDate = DateTime.Now.ToString("HHmmss");
                log(strNowDate, txtLog);
                //StreamReader txtRead = new StreamReader(Application.StartupPath + Path.DirectorySeparatorChar + "20211206_11_output.log");
                StreamReader txtRead = new StreamReader(sInputPath+ "\\" + "testresult.log");
                //StreamWriter csvWrite = new StreamWriter(csvPath+ "\\" + DateTime.Now.ToString("yyMMdd") + "_tests" + ".csv");
                StreamWriter csvWrite = new StreamWriter(csvPath + "\\" + SN_text.Text + "_" + strNowDate + ".csv");
                StreamWriter serverWrite = new StreamWriter(serverPath + "\\" + SN_text.Text + "_" + strNowDate + ".csv");
                StreamWriter sumWrite = File.AppendText(serverPath + "\\" + "Summary.csv");

                string csvTitle = "";
                string[] testCSV_titleData = { "Updata Time", "ESN", "SN", "Test start time", "Test end time", "Tester No.", "Tester ID", "Tester HW version", "Tester SW version", "Operator ID", "testCategory", "testName", "testCount", "testDuration", "testResult", "details", "comments", "lowerLimit", "upperLimit" };
                //ESN → 代表整機SN


                for (int numtitle = 0; numtitle < testCSV_titleData.Length; numtitle++)
                {
                    csvTitle += testCSV_titleData[numtitle] + ",";
                }

                csvWrite.WriteLine(csvTitle);
                

                while (!txtRead.EndOfStream)
                {
                    string txtData = txtRead.ReadLine();
                    string[] splitData = txtData.Split(';');
                    string csvData = "";

                    for (int i = 0; i < splitData.Length; i++)
                    {

                        if (i == 5 | i == 6)
                        {
                            // 在csv欄位中呈現 兩位數 的數字 → 例如: 01, 02, 03...等等
                            string numTwodigit = string.Format("{0}" + splitData[i], ((char)(9)).ToString());
                            csvData += (numTwodigit + ",");
                        }
                        else if (i == 9)
                        {
                            //寫入OPID
                            csvData += (textBox1.Text.ToString() + ",");
                        }
                        else if (i == 11)
                        {
                            
                            //splitData[i] = splitData[i].Replace(',', ';');
                            csvData += ("\"" + splitData[i] + "\"" + ",");

                            string checknum = ini.IniReadValue(cboStation.Text, splitData[i], ini_path, "checkitem");
                            
                            //檢查每個checkitem 是否有測試到
                            if (checknum == "0")
                            {
                                //txtLog.AppendText(splitData[i]+ "......Check" + "\r\n");
                                log(splitData[i] + "......Check", txtLog);
                                for (int checklistNum = 0; checklistNum < checkedListBox1.Items.Count; checklistNum++)
                                {
                                    if (splitData[i] == checkedListBox1.GetItemText(checkedListBox1.Items[checklistNum]))
                                    {
                                        checkedListBox1.SetItemCheckState(checklistNum, CheckState.Checked);
                                    }
                                }

                            }

                        }
                        else if (i == 12)
                        {
                            //寫入測試次數
                            csvData += (ini.IniReadValue("TestCount", SN_text.Text.ToUpper(), ini_path, TestCount) + ",");
                            //--------csvData += (splitData[i] + ",");
                        }
                        else if (i == 14)
                        {
                            //確認test result → PASS/FAIL

                            log(splitData[11] + "......" + splitData[i], txtLog);
                            if (splitData[i].ToUpper() == "FAIL" && checkedListBox1.Items.Contains(splitData[11]))
                            {
                                lFailitem.Add(splitData[11]);
                                ini.IniWriteValue("checkStatus", "result", "FAIL", ini_path, name);
                            }
                            csvData += ("\"" + splitData[i] + "\"" + ",");
 
                        }
                        else
                        {
                            //splitData[i] = splitData[i].Replace(",", ";");
                            csvData += ("\"" + splitData[i] + "\"" + ",");
                        }

                    }

                    csvWrite.WriteLine(csvData.TrimEnd(','));
                    sumWrite.WriteLine(csvData.TrimEnd(','));
                    if (ini.IniReadValue("OfflineSetting", "offline", ini_path, name) == "off")
                    {
                        serverWrite.WriteLine(csvData.TrimEnd(','));
                    }
                    
                }

                txtRead.Close();
                csvWrite.Close();
                File.Move(csvPath + "\\" + SN_text.Text + "_" + strNowDate + ".csv",  csvPath + "\\" + SN_text.Text + "_" + strNowDate+ "_" + ini.IniReadValue("checkStatus", "result", ini_path, name).ToUpper() + ".csv");
                File.Copy(csvPath + "\\" + SN_text.Text + "_" + strNowDate + "_" + ini.IniReadValue("checkStatus", "result", ini_path, name).ToUpper() + ".csv", serverPath + "\\" + SN_text.Text + "_" + strNowDate + "_" + ini.IniReadValue("checkStatus", "result", ini_path, name).ToUpper() + ".csv");
                sumWrite.Close();
                

                log("---------Test END-----------" + "\r\n", txtLog);
                log("----------------------------" + "\r\n", txtLog);
                log("----------------------------" + "\r\n", txtLog);
                log("----------------------------" + "\r\n", txtLog);
                log("----------------------------" + "\r\n", txtLog);
                log("----------------------------" + "\r\n", txtLog);
                log("----------------------------" + "\r\n", txtLog);
                log("---------FAIL ITEM----------" + "\r\n", txtLog);

                foreach (string item in lFailitem)
                {
                    log(item, txtLog);
                }

                //檢查checkitem 裡面是不是有測項沒測到
                for (int checklistNum = 0; checklistNum < checkedListBox1.Items.Count; checklistNum++) 
                {
                    if (checkedListBox1.GetItemCheckState(checklistNum) != CheckState.Checked)
                    {
                        log(checkedListBox1.GetItemText(checkedListBox1.Items[checklistNum]) + " ----> No Item", txtLog);
                        ini.IniWriteValue("checkStatus", "result", "FAIL", ini_path, name);
                    }
                }
                

                //設定 Button → 顯示結果PASS/FAIL -------- 並上傳SF
                if (ini.IniReadValue("checkStatus", "result", ini_path, name).ToUpper() == "PASS")
                {
                    string qStation = ini.IniReadValue("Station", cboStation.Text, ini_path, name);
                    string sSFdata = SN_text.Text.ToUpper() + ",PASS," + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
                           + "," + cboStation.Text + "," + textBox1.Text + "," + txtHWRev.Text + "," + txtFWRev.Text;
                    pass_fail.BackColor = Color.Lime;
                    pass_fail.Text = "PASS";
                    pass_fail.Font = new Font(pass_fail.Font.FontFamily, 60);
                    //如果button為off 表示為要上傳至SF
                    if (ini.IniReadValue("OfflineSetting", "offline", ini_path, name) == "off")
                    {
                        upload.SaveResult(txtIP.Text, txtDataBase.Text, SN_text.Text, txtLine.Text, qStation, "PASS", textBox1.Text.ToString());
                        upload.TestDataSave(txtIP.Text, txtDataBase.Text, SN_text.Text, txtLine.Text, qStation, sSFdata, textBox1.Text.ToString());
                    }                    
                }
                else
                {
                    string qStation = ini.IniReadValue("Station", cboStation.Text, ini_path, name);
                    string sSFdata = SN_text.Text.ToUpper() + ",FAIL," + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
                           + "," + cboStation.Text + "," + textBox1.Text + "," + txtHWRev.Text + "," + txtFWRev.Text;
                    pass_fail.BackColor = Color.Red;
                    pass_fail.Text = "FAIL";
                    pass_fail.Font = new Font(pass_fail.Font.FontFamily, 60);
                    /*
                    if (ini.IniReadValue("OfflineSetting", "offline", ini_path, name) == "off")
                    {
                        upload.SaveResult(txtIP.Text, txtDataBase.Text, SN_text.Text, txtLine.Text, qStation, "FAIL", textBox1.Text.ToString());
                        upload.TestDataSave(txtIP.Text, txtDataBase.Text, SN_text.Text, txtLine.Text, qStation, sSFdata, textBox1.Text.ToString());
                    }
                    */
                }

                SN_text.Enabled = true;
                SN_text.Text = string.Empty;
                SN_text.Focus();
            }
            catch (Exception d)
            {
                Console.WriteLine("Exception: " + d.Message);
            }
            finally
            {
                _watch.EnableRaisingEvents = false;
            }

        }

        //----------------------------------------------------寫入Log檔-------------------------------------------------------
        private void log(string sContent, TextBox Text)
        {
            Text.Text = Text.Text + "\r\n" + DateTime.Now.ToString("yyy/MM/dd hh:mm:ss") + " " + sContent;
            //自動捲到底部 ==Start
            Text.SelectionStart = Text.Text.Length;
            Text.ScrollToCaret();
            //自動捲到底部 ==End

            string sTraceFileName;
            sTraceFileName = DateTime.Now.ToString("yyyMMdd");

            string sPath = Application.StartupPath + Path.DirectorySeparatorChar;
            string sFullPath = sPath + "Log\\";                         //log存放路徑
            string sDate = DateTime.Now.ToString("yyy/MM/dd hh:mm:ss"); //log內的時間
            //判斷資料夾是否存在

            if (Directory.Exists(sFullPath) == false)
            {
                DirectoryInfo di = Directory.CreateDirectory(sFullPath);
            }
            if (Directory.Exists(sFullPath + sTraceFileName) == false)
            {
                DirectoryInfo di = Directory.CreateDirectory(sFullPath + sTraceFileName);
            }

            if (File.Exists(sFullPath + sTraceFileName + "\\" + SN_text.Text + ".txt") == false)
            {//判斷檔案是否存在，不存在就建立
                using (StreamWriter WriteLog = new StreamWriter(sFullPath + sTraceFileName + "\\" + SN_text.Text + ".txt"))
                {//檔案如果不存在，使用StreamWriter就會自動建立文件，使用Create 會有資料殘留現象
                    //關閉檔案
                    WriteLog.Close();
                }
            }

            try
            {
                string sRead;
                using (StreamReader Read = new StreamReader(sFullPath + sTraceFileName + "\\" + SN_text.Text + ".txt"))
                {
                    sRead = Read.ReadToEnd();
                    Read.Close();
                }


                using (StreamWriter WriteLog = new StreamWriter(sFullPath + sTraceFileName + "\\" + SN_text.Text + ".txt"))
                {
                    //將結果寫入
                    WriteLog.WriteLine(sRead + sDate + " " + sContent);

                    //關閉檔案
                    WriteLog.Close();
                }
            }
            catch (Exception d)
            {
                MessageBox.Show("Exception: " + d.Message);
            }

        }
        //----------------------------------------------------寫入Log檔-------------------------------------------------------

        //----------------------------------------------------寫入BAT檔-------------------------------------------------------
        private void writeBat()
        {
            string sInputPath = ini.IniReadValue("Default", "InputPath", ini_path, name);
            try
            {
                StreamWriter sw = new StreamWriter(sInputPath + "\\"+ "TEST.bat");
                if (cboStation.Text == "T11")
                {
                    //echo.| 是自動Enter
                    sw.WriteLine("python T11_Right_Temple_Test.py " + SN_text.Text);
                    sw.Close();
                }
                else if (cboStation.Text == "T12")
                {
                    //echo.| 是自動Enter
                    sw.WriteLine("T12_Left_Temple_Test.bat " + SN_text.Text);
                    sw.Close();
                }
                else if (cboStation.Text == "T13")
                {
                    string macData = upload.SNInfo("10.228.24.38", "SWH", SN_text.Text, "MAC");
                    string[] splitMac = macData.Split(new string[] { ";$;", "=" }, StringSplitOptions.None);

                    //echo.| 是自動Enter
                    if (ini.IniReadValue("Offlinesetting", "offline", ini_path, name) == "on")
                    {
                        sw.WriteLine("T13_Main_HW_Assembly_Test.bat" + " " + SN_text.Text + " " + "testing.max32.12.bin" + " " + splitMac[1]);
                        sw.Close();
                    }
                    else
                    {
                        sw.WriteLine("T13_Main_HW_Assembly_Test.bat" + " " + SN_text.Text + " " + "testing.max32.12.bin" + " " + splitMac[1]);
                        sw.Close();
                    }

                }
                else if (cboStation.Text == "T14")
                {
                    log("T14", txtLog);
                    sw.WriteLine("T14_Right_Temple_Battery_Test_PVT.bat " + SN_text.Text);
                    sw.Close();
                }
                else if (cboStation.Text == "T20")
                {
                    string macData = upload.SNInfo("10.228.24.38", "SWH", SN_text.Text, "MAC");

                    string[] splitMac = macData.Split(new string[] { ";$;", "=" }, StringSplitOptions.None);
                    if (ini.IniReadValue("Offlinesetting", "offline", ini_path, name) == "on")
                    {
                        sw.WriteLine("T20_Functional_Test.bat " + SN_text.Text + " " + "testing.max32.12.bin" + " " + splitMac[1]);
                        sw.Close();
                    }
                    else
                    {
                        sw.WriteLine("T20_Functional_Test.bat " + SN_text.Text + " " + "testing.max32.12.bin" + " " + splitMac[1]);
                        sw.Close();
                    }

                }
                else if (cboStation.Text == "T21")
                {
                    if (SN_text.Text.Substring(6, 1) == "1" | SN_text.Text.Substring(6, 1) == "3" | SN_text.Text.Substring(6, 1) == "5" | SN_text.Text.Substring(6, 1) == "7")
                    {
                        log("M-Size MODE", txtLog);
                        sw.WriteLine("T21_RF_Test_M.bat " + SN_text.Text);
                        sw.Close();
                    }
                    else if (SN_text.Text.Substring(6, 1) == "2" | SN_text.Text.Substring(6, 1) == "4" | SN_text.Text.Substring(6, 1) == "6" | SN_text.Text.Substring(6, 1) == "8")
                    {
                        log("L-Size MODE", txtLog);
                        sw.WriteLine("T21_RF_Test_L.bat " + SN_text.Text);
                        sw.Close();
                    }
                    else
                    {
                        log("NO MODE!!!!!", txtLog);
                        log("WRONG SN!!!", txtLog);
                        log("CHECK SKU!!!", txtLog);
                        sw.WriteLine("T21_RF_Test.bat " + SN_text.Text);
                        sw.Close();
                    }

                }
                else if (cboStation.Text == "T22")
                {
                    //echo.| 是自動Enter
                    sw.WriteLine("NA " + SN_text.Text);
                    sw.Close();
                }
                else if (cboStation.Text == "T23")
                {
                    //echo.| 是自動Enter

                    log("T23", txtLog);

                    if (SN_text.Text.Substring(6, 1) == "1" | SN_text.Text.Substring(6, 1) == "3" | SN_text.Text.Substring(6, 1) == "5" | SN_text.Text.Substring(6, 1) == "7")
                    {
                        log("M-Size MODE", txtLog);
                        Data.dev_size = "medium";
                        SavejFileConfig();

                    }
                    else if (SN_text.Text.Substring(6, 1) == "2" | SN_text.Text.Substring(6, 1) == "4" | SN_text.Text.Substring(6, 1) == "6" | SN_text.Text.Substring(6, 1) == "8")
                    {
                        log("L-Size MODE", txtLog);
                        Data.dev_size = "large";
                        SavejFileConfig();

                    }

                    sw.WriteLine("python T23_IMU_calibration.py " + SN_text.Text);
                    sw.Close();
                    

                }
                else if (cboStation.Text == "T24&T25")
                {
                    if (ini.IniReadValue("Offlinesetting", "offline", ini_path, name) == "on")
                    {
                        string macData = upload.SNInfo("10.228.24.38", "SWH", SN_text.Text, "MAC");
                        string[] splitMac = macData.Split(new string[] { ";$;", "=" }, StringSplitOptions.None);
                        if (SN_text.Text.Substring(6, 1) == "3" | SN_text.Text.Substring(6, 1) == "4" | SN_text.Text.Substring(6, 1) == "7" | SN_text.Text.Substring(6, 1) == "8")
                        {
                            log("EVS sku", txtLog);
                            sw.WriteLine("python T25_Final_Image_Download_SKU.py " + SN_text.Text + " " + splitMac[1] + " " + "EVS");
                            sw.Close();
                        }
                        else
                        {
                            log("BMW sku", txtLog);
                            sw.WriteLine("python T25_Final_Image_Download_SKU.py " + SN_text.Text + " " + splitMac[1] + " " + "BMW");
                            sw.Close();
                        }
                        
                    }
                    else
                    {
                        string macData = upload.SNInfo("10.228.24.38", "SWH", SN_text.Text, "MAC");
                        string[] splitMac = macData.Split(new string[] { ";$;", "=" }, StringSplitOptions.None);
                        //echo.| 是自動Enter
                        if (SN_text.Text.Substring(6, 1) == "3" | SN_text.Text.Substring(6, 1) == "4" | SN_text.Text.Substring(6, 1) == "7" | SN_text.Text.Substring(6, 1) == "8")
                        {
                            log("EVS sku", txtLog);
                            sw.WriteLine("python T25_Final_Image_Download_SKU.py " + SN_text.Text + " " + splitMac[1] + " " + "EVS");
                            sw.Close();
                        }
                        else
                        {
                            log("BMW sku", txtLog);
                            sw.WriteLine("python T25_Final_Image_Download_SKU.py " + SN_text.Text + " " + splitMac[1] + " " + "BMW");
                            sw.Close();
                        }
                    }

                }
                /*
                else if (cboStation.Text == "T24")
                {
                    //echo.| 是自動Enter
                    sw.WriteLine("T24_Charging_Station.bat " + SN_text.Text);
                    sw.Close();
                }
                else if (cboStation.Text == "T25")
                {
                    //echo.| 是自動Enter
                    if (SN_text.Text.Substring(6, 1) == "3" | SN_text.Text.Substring(6, 1) == "4")
                    {
                        sw.WriteLine("python T25_Final_Image_Download_EVS.py " + SN_text.Text);
                        sw.Close();
                    }
                    else 
                    {
                        sw.WriteLine("python T25_Final_Image_Download_BMW.py " + SN_text.Text);
                        sw.Close();
                    }

                }
                */
                else if (cboStation.Text == "T26")
                {
                    sw.WriteLine("python T26_Final_Functional_test.py " + SN_text.Text);
                    sw.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

        }

        //----------------------------------------------------寫入BAT檔-------------------------------------------------------

        //----------------------------------------------------寫入JSON檔------------------------------------------------------
        public void SavejFileConfig()
        {
            string output = JsonConvert.SerializeObject(Data);
            File.WriteAllText(jfilePath, output);
            log("Json File Save OK", txtLog);
        }
        //----------------------------------------------------寫入JSON檔------------------------------------------------------

        private void copyFile()
        {
            string sPath;       //儲存路徑
            string sFloderName; //資料夾名稱
            string sFullPath;   //完整路徑
            string sDate;       //目前日期

            sPath = ini.IniReadValue("Default", "OutPutPath", ini_path, name);

            sFloderName = ini.IniReadValue("Default", "station", ini_path, name); //Station 在路徑下新增資料夾
            sFullPath = sPath + sFloderName; //公用存放路徑
            sDate = DateTime.Now.ToString("yyyMMdd");
            //@"C:\Users\11001005\Desktop\A97\AMT\Test" + "\\" + SN_text.Text ;

            string targetFile = @"D:\TEST92\FATP\FA_1_Right Temple Tester\" + "testresult.log";
            string destinationFile = sFullPath + "\\" + sDate + "\\" + "result.txt";


            System.IO.File.Copy(targetFile, destinationFile);

        }

        //計算SN測試次數 在 TestCount.ini
        private void Count()
        {
            int num = 1;
            int countData;
            if (ini.IniReadValue("TestCount", SN_text.Text.ToUpper(), ini_path, TestCount) == "")
            {
                ini.IniWriteValue("TestCount", SN_text.Text.ToUpper(), num.ToString(), ini_path, TestCount);
            }
            else
            {                
                countData = Int32.Parse(ini.IniReadValue("TestCount", SN_text.Text.ToUpper(), ini_path, TestCount)) + 1 ;
                ini.IniWriteValue("TestCount", SN_text.Text.ToUpper(), countData.ToString(), ini_path, TestCount);
            }                    
        }


        //----------------------------------------介面設定----------------------------------------
        private void DataViewingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //切換使用者 返回登入介面
            Login loginProgram = new Login();
            this.Visible = false;

            loginProgram.Visible = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //關閉程式

            //MessageBox 顯示 yes/no選項判斷
            DialogResult messageResult = MessageBox.Show("是否確定要關閉程式?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (messageResult == DialogResult.Yes)
            {
                this.Close();
                Environment.Exit(Environment.ExitCode);

                InitializeComponent();
            }
            else if (messageResult == DialogResult.No)
            return;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //OPID卡控 確認是否進入"管理模式"
            if (textBox1.Text.ToUpper() == "ADMIN")
            {
                textBox1.Text = "ADMIN MODE";
                textBox1.Enabled = false;
                textBox1.BackColor = Color.Red;
                groupBox1.Enabled = true;
                CSNtxt.Enabled = true;
                button1.Visible = true;
            }
            else
            {
                textBox1.Enabled = false;
                groupBox1.Enabled = false;
            }
            
        }

        private void cboStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            //更動ini檔中 station 的值
            ini.IniWriteValue("Default", "station", cboStation.Text, ini_path, name);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //關閉介面 將程式完全關閉
            Environment.Exit(Environment.ExitCode);

            InitializeComponent();
        }

        private void cboModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            //更動ini檔中 Model 的值
            ini.IniWriteValue("Default", "model", cboModule.Text, ini_path, name);
        }

        private void txtLog_TextChanged(object sender, EventArgs e)
        { 
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.SelectionStart = txtLog.Text.Length;
            txtLog.ScrollToCaret();
        }


        private void bntReset_Click(object sender, EventArgs e)
        {
            //重製SN
            
            SN_text.Enabled = true;
            SN_text.Text = string.Empty;

            log("----------Reset SN----------", txtLog);
        }


        //設定 OfflieTest
        private void offline_Click(object sender, EventArgs e)
        {
            string checkOffline = ini.IniReadValue("Offlinesetting", "offline", ini_path, name);

            if (checkOffline == "off")
            {
                CSNtxt.Enabled = true;

                if (cboStation.Text == "T23" || cboStation.Text == "T14" || cboStation.Text == "T21" || cboStation.Text == "T11")
                {
                    MessageBox.Show("開啟OffLine", "提示");
                    offline.BackColor = Color.Lime;
                    offline.Text = "OFFLINE";
                    ini.IniWriteValue("Default", "OutPutPath", "C:\\A92\\OfflineData\\", ini_path, name);
                    ini.IniWriteValue("Offlinesetting", "offline", "on", ini_path, name);
                    log("------OFFLINE MODE------", txtLog);
                }
                else 
                {
                    MessageBox.Show("開啟OffLine", "提示");
                    offline.BackColor = Color.Lime;
                    offline.Text = "OFFLINE";
                    ini.IniWriteValue("Default", "OutPutPath", "D:\\A92\\OfflineData\\", ini_path, name);
                    ini.IniWriteValue("Offlinesetting", "offline", "on", ini_path, name);
                    log("------OFFLINE MODE------", txtLog);
                }
                
            }
            else
            {
                CSNtxt.Enabled = false;

                if (cboStation.Text == "T23" || cboStation.Text == "T14" || cboStation.Text == "T21" || cboStation.Text == "T11")
                {
                    MessageBox.Show("關閉OffLine", "提示");
                    offline.BackColor = Color.Red;
                    offline.Text = "ONLINE";
                    ini.IniWriteValue("Default", "OutPutPath", "C:\\A92\\TestCSV\\ ", ini_path, name);
                    ini.IniWriteValue("Offlinesetting", "offline", "off", ini_path, name);
                    log("------ONLINE MODE------", txtLog);
                }
                else
                {
                    MessageBox.Show("關閉OffLine", "提示");
                    offline.BackColor = Color.Red;
                    offline.Text = "ONLINE";
                    ini.IniWriteValue("Default", "OutPutPath", "D:\\A92\\TestCSV\\ ", ini_path, name);
                    ini.IniWriteValue("Offlinesetting", "offline", "off", ini_path, name);
                    log("------ONLINE MODE------", txtLog);
                }
                
            }
        }

        //用不到
        private void CSNtxt_TextChanged(object sender, EventArgs e)
        {
            if (CSNtxt.Text.Length == checkCSN_lenth)
            { 

                log("--------------------", txtLog);
                log("CSN Length OK", txtLog);
                log("--------------------" + "\r\n", txtLog);


                CSNtxt.Enabled = false;
                pass_fail.Text = "";
                pass_fail.BackColor = Color.AliceBlue;
            }
        }


        //實驗按鈕
        private void button1_Click(object sender, EventArgs e)
        {
            Data.dev_size = "Medium";
            SavejFileConfig();
        }

        private void OPID_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //----------------------------------------介面設定----------------------------------------

    }
}
