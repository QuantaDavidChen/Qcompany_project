
namespace A97_Test
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SN_text = new System.Windows.Forms.TextBox();
            this.SN = new System.Windows.Forms.Label();
            this.OPID = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.選項ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.資料檢視DataViewingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compSN = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pass_fail = new System.Windows.Forms.Button();
            this.offlineSetting = new System.Windows.Forms.Label();
            this.offline = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.bntError = new System.Windows.Forms.Button();
            this.errortxt = new System.Windows.Forms.TextBox();
            this.bntReset = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFWRev = new System.Windows.Forms.TextBox();
            this.txtHWRev = new System.Windows.Forms.TextBox();
            this.HWRev = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboStation = new System.Windows.Forms.ComboBox();
            this.txtLine = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboModule = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDataBase = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CSNtxt = new System.Windows.Forms.TextBox();
            this.Start = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SN_text
            // 
            this.SN_text.Font = new System.Drawing.Font("新細明體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.SN_text.Location = new System.Drawing.Point(141, 111);
            this.SN_text.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SN_text.Name = "SN_text";
            this.SN_text.Size = new System.Drawing.Size(288, 59);
            this.SN_text.TabIndex = 1;
            this.SN_text.TextChanged += new System.EventHandler(this.SN_text_TextChanged);
            // 
            // SN
            // 
            this.SN.AutoSize = true;
            this.SN.BackColor = System.Drawing.Color.PeachPuff;
            this.SN.Font = new System.Drawing.Font("新細明體", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.SN.Location = new System.Drawing.Point(22, 114);
            this.SN.Name = "SN";
            this.SN.Size = new System.Drawing.Size(72, 43);
            this.SN.TabIndex = 2;
            this.SN.Text = "SN";
            // 
            // OPID
            // 
            this.OPID.AutoSize = true;
            this.OPID.BackColor = System.Drawing.Color.PeachPuff;
            this.OPID.Font = new System.Drawing.Font("新細明體", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.OPID.Location = new System.Drawing.Point(22, 47);
            this.OPID.Name = "OPID";
            this.OPID.Size = new System.Drawing.Size(116, 43);
            this.OPID.TabIndex = 3;
            this.OPID.Text = "OPID";
            this.OPID.Click += new System.EventHandler(this.OPID_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("新細明體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox1.Location = new System.Drawing.Point(141, 44);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(288, 59);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(29, 668);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 30);
            this.label6.TabIndex = 18;
            this.label6.Text = "Error Code";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.SlateGray;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.選項ToolStripMenuItem,
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1268, 38);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 選項ToolStripMenuItem
            // 
            this.選項ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.資料檢視DataViewingToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.選項ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.選項ToolStripMenuItem.Name = "選項ToolStripMenuItem";
            this.選項ToolStripMenuItem.Size = new System.Drawing.Size(124, 34);
            this.選項ToolStripMenuItem.Text = "Options";
            // 
            // 資料檢視DataViewingToolStripMenuItem
            // 
            this.資料檢視DataViewingToolStripMenuItem.Name = "資料檢視DataViewingToolStripMenuItem";
            this.資料檢視DataViewingToolStripMenuItem.Size = new System.Drawing.Size(278, 44);
            this.資料檢視DataViewingToolStripMenuItem.Text = "Switch User";
            this.資料檢視DataViewingToolStripMenuItem.Click += new System.EventHandler(this.DataViewingToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(278, 44);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(72, 34);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // compSN
            // 
            this.compSN.AutoSize = true;
            this.compSN.BackColor = System.Drawing.Color.PeachPuff;
            this.compSN.Font = new System.Drawing.Font("新細明體", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.compSN.Location = new System.Drawing.Point(22, 181);
            this.compSN.Name = "compSN";
            this.compSN.Size = new System.Drawing.Size(114, 43);
            this.compSN.TabIndex = 25;
            this.compSN.Text = "C-SN";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // pass_fail
            // 
            this.pass_fail.BackColor = System.Drawing.Color.AliceBlue;
            this.pass_fail.Location = new System.Drawing.Point(453, 41);
            this.pass_fail.Name = "pass_fail";
            this.pass_fail.Size = new System.Drawing.Size(313, 219);
            this.pass_fail.TabIndex = 22;
            this.pass_fail.UseVisualStyleBackColor = false;
            // 
            // offlineSetting
            // 
            this.offlineSetting.AutoSize = true;
            this.offlineSetting.Font = new System.Drawing.Font("微軟正黑體", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.offlineSetting.Location = new System.Drawing.Point(453, 672);
            this.offlineSetting.Name = "offlineSetting";
            this.offlineSetting.Size = new System.Drawing.Size(210, 34);
            this.offlineSetting.TabIndex = 23;
            this.offlineSetting.Text = "Offline Setting :";
            // 
            // offline
            // 
            this.offline.BackColor = System.Drawing.Color.Red;
            this.offline.Font = new System.Drawing.Font("微軟正黑體", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.offline.Location = new System.Drawing.Point(453, 719);
            this.offline.Name = "offline";
            this.offline.Size = new System.Drawing.Size(313, 78);
            this.offline.TabIndex = 24;
            this.offline.Text = "ONLINE";
            this.offline.UseVisualStyleBackColor = false;
            this.offline.Click += new System.EventHandler(this.offline_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(453, 263);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.ScrollAlwaysVisible = true;
            this.checkedListBox1.Size = new System.Drawing.Size(313, 328);
            this.checkedListBox1.TabIndex = 28;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(453, 609);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 52);
            this.button1.TabIndex = 27;
            this.button1.Text = "TestSFdata";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtLog.Location = new System.Drawing.Point(3, 42);
            this.txtLog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(444, 755);
            this.txtLog.TabIndex = 15;
            this.txtLog.TextChanged += new System.EventHandler(this.txtLog_TextChanged);
            // 
            // bntError
            // 
            this.bntError.BackColor = System.Drawing.Color.Tomato;
            this.bntError.FlatAppearance.BorderSize = 0;
            this.bntError.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bntError.Location = new System.Drawing.Point(336, 659);
            this.bntError.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bntError.Name = "bntError";
            this.bntError.Size = new System.Drawing.Size(93, 47);
            this.bntError.TabIndex = 17;
            this.bntError.Text = "Error";
            this.bntError.UseVisualStyleBackColor = false;
            this.bntError.Click += new System.EventHandler(this.bntError_Click);
            // 
            // errortxt
            // 
            this.errortxt.Location = new System.Drawing.Point(160, 665);
            this.errortxt.Name = "errortxt";
            this.errortxt.Size = new System.Drawing.Size(154, 39);
            this.errortxt.TabIndex = 19;
            // 
            // bntReset
            // 
            this.bntReset.BackColor = System.Drawing.Color.SlateGray;
            this.bntReset.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bntReset.Location = new System.Drawing.Point(336, 244);
            this.bntReset.Name = "bntReset";
            this.bntReset.Size = new System.Drawing.Size(100, 89);
            this.bntReset.TabIndex = 21;
            this.bntReset.Text = "ResetSN";
            this.bntReset.UseVisualStyleBackColor = false;
            this.bntReset.Click += new System.EventHandler(this.bntReset_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtFWRev);
            this.groupBox1.Controls.Add(this.txtHWRev);
            this.groupBox1.Controls.Add(this.HWRev);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cboStation);
            this.groupBox1.Controls.Add(this.txtLine);
            this.groupBox1.Controls.Add(this.txtIP);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboModule);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboCategory);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDataBase);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(21, 235);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(309, 413);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ProductLine";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 374);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 30);
            this.label9.TabIndex = 20;
            this.label9.Text = "FWRev";
            // 
            // txtFWRev
            // 
            this.txtFWRev.Location = new System.Drawing.Point(126, 366);
            this.txtFWRev.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFWRev.Name = "txtFWRev";
            this.txtFWRev.Size = new System.Drawing.Size(167, 39);
            this.txtFWRev.TabIndex = 19;
            // 
            // txtHWRev
            // 
            this.txtHWRev.Location = new System.Drawing.Point(126, 318);
            this.txtHWRev.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHWRev.Name = "txtHWRev";
            this.txtHWRev.Size = new System.Drawing.Size(167, 39);
            this.txtHWRev.TabIndex = 18;
            // 
            // HWRev
            // 
            this.HWRev.AutoSize = true;
            this.HWRev.Location = new System.Drawing.Point(11, 327);
            this.HWRev.Name = "HWRev";
            this.HWRev.Size = new System.Drawing.Size(96, 30);
            this.HWRev.TabIndex = 17;
            this.HWRev.Text = "HWRev";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 30);
            this.label7.TabIndex = 16;
            this.label7.Text = "Station";
            // 
            // cboStation
            // 
            this.cboStation.FormattingEnabled = true;
            this.cboStation.Location = new System.Drawing.Point(126, 33);
            this.cboStation.Name = "cboStation";
            this.cboStation.Size = new System.Drawing.Size(167, 38);
            this.cboStation.TabIndex = 15;
            this.cboStation.SelectedIndexChanged += new System.EventHandler(this.cboStation_SelectedIndexChanged);
            // 
            // txtLine
            // 
            this.txtLine.Location = new System.Drawing.Point(126, 132);
            this.txtLine.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLine.Name = "txtLine";
            this.txtLine.Size = new System.Drawing.Size(167, 39);
            this.txtLine.TabIndex = 6;
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(126, 85);
            this.txtIP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(167, 39);
            this.txtIP.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 280);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 30);
            this.label5.TabIndex = 14;
            this.label5.Text = "DataBase";
            // 
            // cboModule
            // 
            this.cboModule.FormattingEnabled = true;
            this.cboModule.Location = new System.Drawing.Point(126, 179);
            this.cboModule.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboModule.Name = "cboModule";
            this.cboModule.Size = new System.Drawing.Size(167, 38);
            this.cboModule.TabIndex = 7;
            this.cboModule.SelectedIndexChanged += new System.EventHandler(this.cboModule_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 30);
            this.label4.TabIndex = 13;
            this.label4.Text = "Catagory";
            // 
            // cboCategory
            // 
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(126, 225);
            this.cboCategory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(167, 38);
            this.cboCategory.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 30);
            this.label3.TabIndex = 12;
            this.label3.Text = "Module";
            // 
            // txtDataBase
            // 
            this.txtDataBase.Location = new System.Drawing.Point(126, 271);
            this.txtDataBase.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDataBase.Name = "txtDataBase";
            this.txtDataBase.Size = new System.Drawing.Size(167, 39);
            this.txtDataBase.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 30);
            this.label2.TabIndex = 11;
            this.label2.Text = "Line";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 30);
            this.label1.TabIndex = 10;
            this.label1.Text = "IP";
            // 
            // CSNtxt
            // 
            this.CSNtxt.Font = new System.Drawing.Font("新細明體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CSNtxt.Location = new System.Drawing.Point(142, 178);
            this.CSNtxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CSNtxt.Name = "CSNtxt";
            this.CSNtxt.Size = new System.Drawing.Size(287, 59);
            this.CSNtxt.TabIndex = 26;
            this.CSNtxt.TextChanged += new System.EventHandler(this.CSNtxt_TextChanged);
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.Color.SlateGray;
            this.Start.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.Start.FlatAppearance.BorderSize = 0;
            this.Start.Font = new System.Drawing.Font("微軟正黑體", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Start.Location = new System.Drawing.Point(21, 708);
            this.Start.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(408, 89);
            this.Start.TabIndex = 0;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = false;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.Start);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.compSN);
            this.splitContainer1.Panel1.Controls.Add(this.CSNtxt);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.SN);
            this.splitContainer1.Panel1.Controls.Add(this.OPID);
            this.splitContainer1.Panel1.Controls.Add(this.textBox1);
            this.splitContainer1.Panel1.Controls.Add(this.bntReset);
            this.splitContainer1.Panel1.Controls.Add(this.errortxt);
            this.splitContainer1.Panel1.Controls.Add(this.bntError);
            this.splitContainer1.Panel1.Controls.Add(this.SN_text);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtLog);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.checkedListBox1);
            this.splitContainer1.Panel2.Controls.Add(this.offline);
            this.splitContainer1.Panel2.Controls.Add(this.offlineSetting);
            this.splitContainer1.Panel2.Controls.Add(this.pass_fail);
            this.splitContainer1.Size = new System.Drawing.Size(1268, 799);
            this.splitContainer1.SplitterDistance = 475;
            this.splitContainer1.TabIndex = 29;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1268, 799);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(1400, 870);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox SN_text;
        private System.Windows.Forms.Label SN;
        private System.Windows.Forms.Label OPID;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 選項ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 資料檢視DataViewingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Label compSN;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button pass_fail;
        private System.Windows.Forms.Label offlineSetting;
        private System.Windows.Forms.Button offline;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button bntError;
        private System.Windows.Forms.TextBox errortxt;
        private System.Windows.Forms.Button bntReset;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtFWRev;
        private System.Windows.Forms.TextBox txtHWRev;
        private System.Windows.Forms.Label HWRev;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboStation;
        private System.Windows.Forms.TextBox txtLine;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboModule;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDataBase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CSNtxt;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}

