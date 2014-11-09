using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
//using System.Net;
//using System.Net.Http;
//using Windows.Web.Http;
using System.IO;
//using System.Net;
//using System.Net.Sockets;
//using System.Net.NetworkInformation;

namespace Connectivity
{
    public partial class Form1 : Form
    {
        private IdataObject dataObject;
        protected const string url = "Intranet Access";
        protected const string host = "Conversation Map";

        public Form1()
        {
            InitializeComponent();
            progressBar1.Visible = false;
            comboSheetName.Text = comboSheetName.Items[0].ToString(); //.SelectedIndex = 0; //
            this.openFileDialog1.InitialDirectory = Environment.GetEnvironmentVariable("USERPROFILE") + "\\Downloads\\";
            this.saveFileDialog1.InitialDirectory = Environment.GetEnvironmentVariable("USERPROFILE") + "\\Downloads\\";
            radioButtonExcel.Checked = true;
        }

        private void UpdateForm(object sender, EventArgs e)
        {
            try
            {
                if (e is EndEventArgs)
                {
                    EndEventArgs endEventArgs = e as EndEventArgs;
                    SetText(endEventArgs.rowIndex, endEventArgs.textValue, endEventArgs.progress);
                }
            }
            catch
            {
                return;
            }
        }

        delegate void SetTextCallback(int rowIndex, string textValue, int progress);
        private void SetText(int rowIndex, string textValue, int progress)
        {
            try
            {
                if (listView1.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetText);
                    this.Invoke(d, new object[] { rowIndex, textValue, progress });
                }
                else
                {
                    listView1.Items[rowIndex].SubItems[listView1.Items[rowIndex].SubItems.Count - 1].Text = textValue;
                    progressBar1.Value = progress;
                    if (progressBar1.Value == progressBar1.Maximum)
                        progressBar1.Visible = false;
                }
            }
            catch
            {
                return;
            }
        }      

        private void textFileName_TextChanged(object sender, EventArgs e)
        {
            //progressBar1.Visible = false;
            listView1.Items.Clear();
            listView1.Columns.Clear();
            //openFileDialog1.FileName = textFileName.Text;
            //saveFileDialog1.FileName = textFileName.Text;
            if (radioButtonExcel.Checked)
                radioButtonExcel_CheckedChanged(new object(), new EventArgs());
            else if (radioButtonText.Checked)
                radioButtonText_CheckedChanged(new object(), new EventArgs());
            //dataObject.fileReassign(textFileName.Text);
        }

        private void validateButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(textFileName.Text))
                MessageBox.Show(textFileName.Text + "\n" + File.GetLastAccessTimeUtc(textFileName.Text));
            else
                MessageBox.Show("File unreachable or doesn't exist");
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textFileName.Text = openFileDialog1.FileName;
               // dataObject.fileReassign(openFileDialog1.FileName);
            }
        }

        private void buttonRead_Click(object sender, EventArgs e)
        {
            //progressBar1.Visible = false;
            //progressBar1.Maximum = dataObject.listItem.Length;
            //progressBar1.Minimum = 0;
            //progressBar1.Value = 0;
            if (File.Exists(textFileName.Text))
            {
                textFileName_TextChanged(new object(), new EventArgs());
                try
                {
                    //dataObject.fileReassign(openFileDialog1.FileName);
                    dataObject.readFile();
                    listView1.Columns.AddRange(dataObject.columnHeader);
                    listView1.Items.AddRange(dataObject.listItem);
                    listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                }
                catch (InvalidOperationException ex)
                {
                    if (MessageBox.Show(ex.Message, "Office System Driver: Data Connectivity Components", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start("http://www.microsoft.com/en-us/download/details.aspx?id=23734");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else MessageBox.Show("File " + textFileName.Text + " doesn't exist.");
        }

        private void radioButtonText_CheckedChanged(object sender, EventArgs e)
        {
            //this.openFileDialog1.FileName = "ConnectivityStatus.txt";
            //this.saveFileDialog1.FileName = "ConnectivityStatus.txt";
            this.openFileDialog1.Filter = "Text File|*.txt|All Files|*.*";
            this.saveFileDialog1.Filter = "Text File|*.txt|All Files|*.*";
            textFileName.Text = Path.Combine(openFileDialog1.InitialDirectory, openFileDialog1.FileName);
            labelColumnIP.Visible = false;
            numericColumnIP.Visible = false;
            labelColumnPort.Visible = false;
            numericColumnPort.Visible = false;
            labelColumnUrl.Visible = false;
            numericColumnURL.Visible = false;
            labelResult.Visible = false;
            numericColumnResult.Visible = false;
            comboSheetName.Visible = false;
            labelSheetName.Visible = false;
            subnetBox.Visible = false;
            labelSubnets.Visible = false;
            dataObject = new NetTools(textFileName.Text);   // TextObject
            dataObject.End += UpdateForm;
        }

        private void radioButtonExcel_CheckedChanged(object sender, EventArgs e)
        {
            //this.openFileDialog1.FileName = "Connectivity Status.xlsm";
            //this.saveFileDialog1.FileName = "Connectivity Status.xlsm";
            this.openFileDialog1.Filter = "Excel Sheet|*.xls;*.xlt;*.xlm;*.xlsx;*.xlsm;*.xltx;*.xltm;*.xlsb;*.xla;*.xlam;*.x" +
    "ll;*.xlw|Text File|*.txt|All Files|*.*";
            this.saveFileDialog1.Filter = "Excel Sheet|*.xls;*.xlt;*.xlm;*.xlsx;*.xlsm;*.xltx;*.xltm;*.xlsb;*.xla;*.xlam;*.x" +
    "ll;*.xlw|Text File|*.txt|All Files|*.*";
            textFileName.Text = Path.Combine(openFileDialog1.InitialDirectory, openFileDialog1.FileName);
            labelColumnIP.Visible = true;
            numericColumnIP.Visible = true;
            labelColumnPort.Visible = true;
            numericColumnPort.Visible = true;
            labelColumnUrl.Visible = true;
            numericColumnURL.Visible = true;
            labelResult.Visible = true;
            numericColumnResult.Visible = true;
            comboSheetName.Visible = true;
            labelSheetName.Visible = true;
            subnetBox.Visible = true;
            labelSubnets.Visible = true;
            sheetName_SelectedIndexChanged(new object(), new EventArgs());
        }

        private void sheetName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //dataObject.End
            progressBar1.Value = 0;
            progressBar1.Visible = false;
            reCreateExcelInstance();
            switch (comboSheetName.Text)    // if (type == "url")  //(columnUrl >= 0)
            {
                case url:
                    proxyCheckBox.Visible = true;
                    numericColumnURL.Visible = true;
                    labelColumnUrl.Visible = true;
                    numericColumnIP.Visible = false;
                    labelColumnIP.Visible = false;
                    numericColumnPort.Visible = false;
                    labelColumnPort.Visible = false;
                    labelSheetName.Text = "Sheet Name / URL's";
                    break;
                case host:
                    proxyCheckBox.Visible = false;
                    numericColumnURL.Visible = false;
                    labelColumnUrl.Visible = false;
                    numericColumnIP.Visible = true;
                    labelColumnIP.Visible = true;
                    numericColumnPort.Visible = true;
                    labelColumnPort.Visible = true;
                    labelSheetName.Text = "Sheet Name / HOSTs'";
                    break;
                //default: labelSheetName.Text = "Sheet Name / N.A.";;
            }
            subnetBox_SelectedIndexChangedAuto(comboSheetName.Text);
        }

        private void reCreateExcelInstance()
        {
            listView1.Items.Clear();
            listView1.Columns.Clear();
            switch (comboSheetName.Text)    // if (type == "url")  //(columnUrl >= 0)
            {
                case url:
                    dataObject = new ExcelObject(Path.Combine(openFileDialog1.InitialDirectory, openFileDialog1.FileName), comboSheetName.Text, (int)numericColumnURL.Value - 1,
                      (int)numericColumnResult.Value - 1);
                    break;
                case host:
                    dataObject = new ExcelObject(Path.Combine(openFileDialog1.InitialDirectory, openFileDialog1.FileName), comboSheetName.Text, (int)numericColumnIP.Value - 1,
                            (int)numericColumnPort.Value - 1, (int)numericColumnResult.Value - 1);
                    break;

            }
            dataObject.End += UpdateForm;
        }

        private void subnetBox_SelectedIndexChangedAuto(string sheetName)
        {
            try
            {
                switch (dataObject.identifyIpBelongToSubnet(subnetBox.Items.OfType<string>().ToList()))
                {
                    case "10.249.128.0/20":
                        switch (comboSheetName.Text)
                        {
                            case url:
                                numericColumnResult.Value = 3;
                                break;
                            case host:
                                numericColumnResult.Value = 7;
                                break;
                        }
                        break;
                    default:
                        switch (comboSheetName.Text)
                        {
                            case url:
                                numericColumnResult.Value = 4;
                                break;
                            case host:
                                numericColumnResult.Value = 8;
                                break;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void subnetBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (subnetBox.Text)
            {
                case "10.249.128.0/20":
                    if (comboSheetName.Text == host) 
                        numericColumnResult.Value = 8;
                    if (comboSheetName.Text == url)
                        numericColumnResult.Value = 3;
                    break;
            }

        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            progressBar1.Maximum = dataObject.listItem.Length;
            progressBar1.Minimum = 0;
            progressBar1.Value = 0;
            if (dataObject.listItem.Length > 0)
            {
                foreach (ListViewItem item in listView1.Items)
                    item.SubItems[item.SubItems.Count - 1].Text = String.Empty;
                try
                {
                    dataObject.testConnectivity((int)numericTimeOut.Value, proxyCheckBox.Checked);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else MessageBox.Show("First you should read file");
        }
        private void subnetBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                subnetBox.Items.Add(subnetBox.Text);
        }
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataObject.listItem.Length > 0)
            {
                if (File.Exists(textFileName.Text))
                {
                    DialogResult dialogResult = MessageBox.Show("File " + textFileName.Text + " exist, do you want to rewrite/update it?", "File exist", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            dataObject.updateExistsFile(); //.writeFile(saveFileDialog1.FileName);  comboSheetName.Text, choosenColumns
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            else MessageBox.Show("First you should read file");
        }
        private void buttonSaveAs_Click(object sender, EventArgs e)
        {
            if (dataObject.listItem.Length > 0)
            {
                try
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        dataObject.writeNewFile(saveFileDialog1.FileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else MessageBox.Show("First you should read file");
        }

        private void numericColumnResult_ValueChanged(object sender, EventArgs e)
        {
            textFileName_TextChanged(new object(), new EventArgs());
            //dataObject.columnResult = (int)numericColumnResult.Value;
        }

        private void numericColumnIP_ValueChanged(object sender, EventArgs e)
        {
            textFileName_TextChanged(new object(), new EventArgs());
            //reCreateExcelInstance();
        }

        private void numericColumnPort_ValueChanged(object sender, EventArgs e)
        {
            textFileName_TextChanged(new object(), new EventArgs());
            //reCreateExcelInstance();
        }

        private void numericColumnURL_ValueChanged(object sender, EventArgs e)
        {
            textFileName_TextChanged(new object(), new EventArgs());
            //reCreateExcelInstance();
        }

        private void buttonSaveAsText_Click(object sender, EventArgs e)
        {
            if (dataObject.listItem.Length > 0)
            {
                try
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        dataObject.writeNewFile(saveFileDialog1.FileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else MessageBox.Show("First you should read file");
        }
    }
}
