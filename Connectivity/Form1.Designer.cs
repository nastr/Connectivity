using System;
namespace Connectivity
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonSaveAs = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonValidate = new System.Windows.Forms.Button();
            this.buttonTest = new System.Windows.Forms.Button();
            this.buttonRead = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.listView1 = new System.Windows.Forms.ListView();
            this.tapPage2 = new System.Windows.Forms.TabPage();
            this.labelTimeOut = new System.Windows.Forms.Label();
            this.numericTimeOut = new System.Windows.Forms.NumericUpDown();
            this.proxyCheckBox = new System.Windows.Forms.CheckBox();
            this.numericColumnResult = new System.Windows.Forms.NumericUpDown();
            this.labelResult = new System.Windows.Forms.Label();
            this.numericColumnURL = new System.Windows.Forms.NumericUpDown();
            this.numericColumnPort = new System.Windows.Forms.NumericUpDown();
            this.numericColumnIP = new System.Windows.Forms.NumericUpDown();
            this.labelColumnUrl = new System.Windows.Forms.Label();
            this.labelColumnPort = new System.Windows.Forms.Label();
            this.labelColumnIP = new System.Windows.Forms.Label();
            this.radioButtonText = new System.Windows.Forms.RadioButton();
            this.radioButtonExcel = new System.Windows.Forms.RadioButton();
            this.labelSubnets = new System.Windows.Forms.Label();
            this.subnetBox = new System.Windows.Forms.ComboBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.labelFileName = new System.Windows.Forms.Label();
            this.textFileName = new System.Windows.Forms.TextBox();
            this.labelSheetName = new System.Windows.Forms.Label();
            this.comboSheetName = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tapPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericTimeOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericColumnResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericColumnURL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericColumnPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericColumnIP)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "Connectivity status.xlsm";
            this.openFileDialog1.Filter = "Excel Sheet|*.xls;*.xlt;*.xlm;*.xlsx;*.xlsm;*.xltx;*.xltm;*.xlsb;*.xla;*.xlam;*.x" +
    "ll;*.xlw|Text File|*.txt|All Files|*.*";
            this.openFileDialog1.InitialDirectory = "C:\\Users\\Mishchenko\\Downloads\\";
            this.openFileDialog1.Title = "Select dataObject";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "Connectivity status.xlsm";
            this.saveFileDialog1.Filter = "Excel Sheet|*.xls;*.xlt;*.xlm;*.xlsx;*.xlsm;*.xltx;*.xltm;*.xlsb;*.xla;*.xlam;*.x" +
    "ll;*.xlw|Text File|*.txt|All Files|*.*";
            this.saveFileDialog1.InitialDirectory = "C:\\Users\\Mishchenko\\Downloads\\";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tapPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(584, 462);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(576, 436);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.buttonSaveAs);
            this.splitContainer1.Panel1.Controls.Add(this.buttonUpdate);
            this.splitContainer1.Panel1.Controls.Add(this.buttonValidate);
            this.splitContainer1.Panel1.Controls.Add(this.buttonTest);
            this.splitContainer1.Panel1.Controls.Add(this.buttonRead);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.progressBar1);
            this.splitContainer1.Panel2.Controls.Add(this.listView1);
            this.splitContainer1.Size = new System.Drawing.Size(570, 430);
            this.splitContainer1.SplitterDistance = 43;
            this.splitContainer1.TabIndex = 7;
            // 
            // buttonSaveAs
            // 
            this.buttonSaveAs.Location = new System.Drawing.Point(429, 3);
            this.buttonSaveAs.Name = "buttonSaveAs";
            this.buttonSaveAs.Size = new System.Drawing.Size(100, 23);
            this.buttonSaveAs.TabIndex = 7;
            this.buttonSaveAs.Text = "Save As";
            this.buttonSaveAs.UseVisualStyleBackColor = true;
            this.buttonSaveAs.Click += new System.EventHandler(this.buttonSaveAs_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(323, 3);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(100, 23);
            this.buttonUpdate.TabIndex = 1;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonValidate
            // 
            this.buttonValidate.Location = new System.Drawing.Point(5, 3);
            this.buttonValidate.Name = "buttonValidate";
            this.buttonValidate.Size = new System.Drawing.Size(100, 23);
            this.buttonValidate.TabIndex = 6;
            this.buttonValidate.Text = "Validate File";
            this.buttonValidate.UseVisualStyleBackColor = true;
            this.buttonValidate.Click += new System.EventHandler(this.validateButton_Click);
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(217, 3);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(100, 23);
            this.buttonTest.TabIndex = 0;
            this.buttonTest.Text = "Test";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // buttonRead
            // 
            this.buttonRead.Location = new System.Drawing.Point(111, 3);
            this.buttonRead.Name = "buttonRead";
            this.buttonRead.Size = new System.Drawing.Size(100, 23);
            this.buttonRead.TabIndex = 5;
            this.buttonRead.Text = "Read";
            this.buttonRead.UseVisualStyleBackColor = true;
            this.buttonRead.Click += new System.EventHandler(this.buttonRead_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 370);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(570, 13);
            this.progressBar1.TabIndex = 7;
            // 
            // listView1
            // 
            this.listView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(570, 383);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // tapPage2
            // 
            this.tapPage2.Controls.Add(this.labelTimeOut);
            this.tapPage2.Controls.Add(this.numericTimeOut);
            this.tapPage2.Controls.Add(this.proxyCheckBox);
            this.tapPage2.Controls.Add(this.numericColumnResult);
            this.tapPage2.Controls.Add(this.labelResult);
            this.tapPage2.Controls.Add(this.numericColumnURL);
            this.tapPage2.Controls.Add(this.numericColumnPort);
            this.tapPage2.Controls.Add(this.numericColumnIP);
            this.tapPage2.Controls.Add(this.labelColumnUrl);
            this.tapPage2.Controls.Add(this.labelColumnPort);
            this.tapPage2.Controls.Add(this.labelColumnIP);
            this.tapPage2.Controls.Add(this.radioButtonText);
            this.tapPage2.Controls.Add(this.radioButtonExcel);
            this.tapPage2.Controls.Add(this.labelSubnets);
            this.tapPage2.Controls.Add(this.subnetBox);
            this.tapPage2.Controls.Add(this.buttonBrowse);
            this.tapPage2.Controls.Add(this.labelFileName);
            this.tapPage2.Controls.Add(this.textFileName);
            this.tapPage2.Controls.Add(this.labelSheetName);
            this.tapPage2.Controls.Add(this.comboSheetName);
            this.tapPage2.Location = new System.Drawing.Point(4, 22);
            this.tapPage2.Name = "tapPage2";
            this.tapPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tapPage2.Size = new System.Drawing.Size(576, 436);
            this.tapPage2.TabIndex = 1;
            this.tapPage2.Text = "Settings";
            this.tapPage2.UseVisualStyleBackColor = true;
            // 
            // labelTimeOut
            // 
            this.labelTimeOut.AutoSize = true;
            this.labelTimeOut.Location = new System.Drawing.Point(329, 38);
            this.labelTimeOut.Name = "labelTimeOut";
            this.labelTimeOut.Size = new System.Drawing.Size(99, 13);
            this.labelTimeOut.TabIndex = 23;
            this.labelTimeOut.Text = "Time Out (seconds)";
            // 
            // numericTimeOut
            // 
            this.numericTimeOut.Location = new System.Drawing.Point(431, 35);
            this.numericTimeOut.Name = "numericTimeOut";
            this.numericTimeOut.Size = new System.Drawing.Size(46, 20);
            this.numericTimeOut.TabIndex = 22;
            this.numericTimeOut.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // proxyCheckBox
            // 
            this.proxyCheckBox.AutoSize = true;
            this.proxyCheckBox.Checked = true;
            this.proxyCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.proxyCheckBox.Location = new System.Drawing.Point(384, 71);
            this.proxyCheckBox.Name = "proxyCheckBox";
            this.proxyCheckBox.Size = new System.Drawing.Size(110, 17);
            this.proxyCheckBox.TabIndex = 21;
            this.proxyCheckBox.Text = "Use Proxy from IE";
            this.proxyCheckBox.UseVisualStyleBackColor = true;
            // 
            // numericColumnResult
            // 
            this.numericColumnResult.Location = new System.Drawing.Point(298, 136);
            this.numericColumnResult.Name = "numericColumnResult";
            this.numericColumnResult.Size = new System.Drawing.Size(46, 20);
            this.numericColumnResult.TabIndex = 20;
            this.numericColumnResult.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numericColumnResult.ValueChanged += new System.EventHandler(this.numericColumnResult_ValueChanged);
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(215, 143);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(74, 13);
            this.labelResult.TabIndex = 19;
            this.labelResult.Text = "column Result";
            // 
            // numericColumnURL
            // 
            this.numericColumnURL.Location = new System.Drawing.Point(77, 191);
            this.numericColumnURL.Name = "numericColumnURL";
            this.numericColumnURL.Size = new System.Drawing.Size(46, 20);
            this.numericColumnURL.TabIndex = 18;
            this.numericColumnURL.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericColumnURL.ValueChanged += new System.EventHandler(this.numericColumnURL_ValueChanged);
            // 
            // numericColumnPort
            // 
            this.numericColumnPort.Location = new System.Drawing.Point(77, 165);
            this.numericColumnPort.Name = "numericColumnPort";
            this.numericColumnPort.Size = new System.Drawing.Size(46, 20);
            this.numericColumnPort.TabIndex = 17;
            this.numericColumnPort.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericColumnPort.ValueChanged += new System.EventHandler(this.numericColumnPort_ValueChanged);
            // 
            // numericColumnIP
            // 
            this.numericColumnIP.Location = new System.Drawing.Point(77, 139);
            this.numericColumnIP.Name = "numericColumnIP";
            this.numericColumnIP.Size = new System.Drawing.Size(46, 20);
            this.numericColumnIP.TabIndex = 16;
            this.numericColumnIP.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericColumnIP.ValueChanged += new System.EventHandler(this.numericColumnIP_ValueChanged);
            // 
            // labelColumnUrl
            // 
            this.labelColumnUrl.AutoSize = true;
            this.labelColumnUrl.Location = new System.Drawing.Point(11, 193);
            this.labelColumnUrl.Name = "labelColumnUrl";
            this.labelColumnUrl.Size = new System.Drawing.Size(57, 13);
            this.labelColumnUrl.TabIndex = 15;
            this.labelColumnUrl.Text = "column Url";
            // 
            // labelColumnPort
            // 
            this.labelColumnPort.AutoSize = true;
            this.labelColumnPort.Location = new System.Drawing.Point(11, 168);
            this.labelColumnPort.Name = "labelColumnPort";
            this.labelColumnPort.Size = new System.Drawing.Size(63, 13);
            this.labelColumnPort.TabIndex = 14;
            this.labelColumnPort.Text = "column Port";
            // 
            // labelColumnIP
            // 
            this.labelColumnIP.AutoSize = true;
            this.labelColumnIP.Location = new System.Drawing.Point(11, 143);
            this.labelColumnIP.Name = "labelColumnIP";
            this.labelColumnIP.Size = new System.Drawing.Size(54, 13);
            this.labelColumnIP.TabIndex = 13;
            this.labelColumnIP.Text = "column IP";
            // 
            // radioButtonText
            // 
            this.radioButtonText.AutoSize = true;
            this.radioButtonText.Checked = true;
            this.radioButtonText.Location = new System.Drawing.Point(256, 36);
            this.radioButtonText.Name = "radioButtonText";
            this.radioButtonText.Size = new System.Drawing.Size(46, 17);
            this.radioButtonText.TabIndex = 12;
            this.radioButtonText.TabStop = true;
            this.radioButtonText.Text = "Text";
            this.radioButtonText.UseVisualStyleBackColor = true;
            this.radioButtonText.CheckedChanged += new System.EventHandler(this.radioButtonText_CheckedChanged);
            // 
            // radioButtonExcel
            // 
            this.radioButtonExcel.AutoSize = true;
            this.radioButtonExcel.Location = new System.Drawing.Point(199, 37);
            this.radioButtonExcel.Name = "radioButtonExcel";
            this.radioButtonExcel.Size = new System.Drawing.Size(51, 17);
            this.radioButtonExcel.TabIndex = 11;
            this.radioButtonExcel.Text = "Excel";
            this.radioButtonExcel.UseVisualStyleBackColor = true;
            this.radioButtonExcel.CheckedChanged += new System.EventHandler(this.radioButtonExcel_CheckedChanged);
            // 
            // labelSubnets
            // 
            this.labelSubnets.AutoSize = true;
            this.labelSubnets.Location = new System.Drawing.Point(8, 37);
            this.labelSubnets.Name = "labelSubnets";
            this.labelSubnets.Size = new System.Drawing.Size(46, 13);
            this.labelSubnets.TabIndex = 10;
            this.labelSubnets.Text = "Subnets";
            // 
            // subnetBox
            // 
            this.subnetBox.FormattingEnabled = true;
            this.subnetBox.Items.AddRange(new object[] {
            "10.249.128.0/20",
            "10.249.141.131/24",
            "10.246.64.192/26",
            "10.246.64.224/27",
            "10.246.69.32/24",
            "10.246.74.96/24",
            "10.246.76.0/24",
            "10.246.230.0/24"});
            this.subnetBox.Location = new System.Drawing.Point(60, 32);
            this.subnetBox.Name = "subnetBox";
            this.subnetBox.Size = new System.Drawing.Size(121, 21);
            this.subnetBox.TabIndex = 9;
            this.subnetBox.Text = "10.249.128.0/20";
            this.subnetBox.SelectedIndexChanged += new System.EventHandler(this.subnetBox_SelectedIndexChanged);
            this.subnetBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.subnetBox_KeyDown);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(491, 6);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 20);
            this.buttonBrowse.TabIndex = 8;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.Location = new System.Drawing.Point(8, 9);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(23, 13);
            this.labelFileName.TabIndex = 7;
            this.labelFileName.Text = "File";
            // 
            // textFileName
            // 
            this.textFileName.Location = new System.Drawing.Point(36, 6);
            this.textFileName.Name = "textFileName";
            this.textFileName.Size = new System.Drawing.Size(449, 20);
            this.textFileName.TabIndex = 6;
            this.textFileName.TextChanged += new System.EventHandler(this.textFileName_TextChanged);
            // 
            // labelSheetName
            // 
            this.labelSheetName.AutoSize = true;
            this.labelSheetName.Location = new System.Drawing.Point(6, 75);
            this.labelSheetName.Name = "labelSheetName";
            this.labelSheetName.Size = new System.Drawing.Size(153, 13);
            this.labelSheetName.TabIndex = 1;
            this.labelSheetName.Text = "Sheet Name / typeHostsOrUrls";
            // 
            // comboSheetName
            // 
            this.comboSheetName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboSheetName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboSheetName.FormattingEnabled = true;
            this.comboSheetName.Items.AddRange(new object[] {
            "Intranet Access",
            "Conversation Map"});
            this.comboSheetName.Location = new System.Drawing.Point(183, 71);
            this.comboSheetName.Name = "comboSheetName";
            this.comboSheetName.Size = new System.Drawing.Size(161, 21);
            this.comboSheetName.TabIndex = 0;
            this.comboSheetName.SelectedIndexChanged += new System.EventHandler(this.sheetName_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 462);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "Form1";
            this.Text = "Connectivity";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tapPage2.ResumeLayout(false);
            this.tapPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericTimeOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericColumnResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericColumnURL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericColumnPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericColumnIP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button buttonRead;
        private System.Windows.Forms.TabPage tapPage2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        //private System.Windows.Forms.SplitContainer splitContainer2;
        //private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ComboBox comboSheetName;
        private System.Windows.Forms.Label labelSheetName;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.TextBox textFileName;
        private System.Windows.Forms.Button buttonValidate;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.ComboBox subnetBox;
        private System.Windows.Forms.Label labelSubnets;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.RadioButton radioButtonText;
        private System.Windows.Forms.RadioButton radioButtonExcel;
        private System.Windows.Forms.Label labelColumnUrl;
        private System.Windows.Forms.Label labelColumnPort;
        private System.Windows.Forms.Label labelColumnIP;
        private System.Windows.Forms.NumericUpDown numericColumnURL;
        private System.Windows.Forms.NumericUpDown numericColumnPort;
        private System.Windows.Forms.NumericUpDown numericColumnIP;
        private System.Windows.Forms.NumericUpDown numericColumnResult;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Button buttonSaveAs;
        private System.Windows.Forms.CheckBox proxyCheckBox;
        private System.Windows.Forms.Label labelTimeOut;
        private System.Windows.Forms.NumericUpDown numericTimeOut;
        private System.Windows.Forms.ProgressBar progressBar1;

    }
}

