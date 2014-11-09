using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using System.Data;
using System.Net;
//using System.Net.Sockets;
//using System.Net.Http;
//using System.IO;
//using System.Net.NetworkInformation;

namespace Connectivity
{
    class ExcelObject : NetTools, IdataObject
    {
        private string sheetName;
        private int columnHost = -1;
        private int columnPort = -1;
        private int columnUrl = -1;
        private const string url = "Intranet Access$";
        private const string host = "Conversation Map$";
        
        public ExcelObject(string fileName, string sheetNameAndTypeHostsOrUrls, int columnHost, int columnPort, int columnResult)
            : base(fileName)    //, typeHostsOrUrlsAndsheetName
        {
            this.sheetName = sheetNameAndTypeHostsOrUrls + "$";
            this.columnHost = columnHost;
            this.columnPort = columnPort;
            this.columnResult = columnResult;
            //this.hosts = new List<hostsSource>();
        }
        public ExcelObject(string fileName, string sheetNameAndTypeHostsOrUrls, int columnUrl, int columnResult)
            : base(fileName)    //, typeHostsOrUrlsAndsheetName
        {
            this.sheetName = sheetNameAndTypeHostsOrUrls + "$";
            this.columnUrl = columnUrl;
            this.columnResult = columnResult;
            //this.urls = new List<urlsSource>();
        }

        /*public void reassignToHosts(string fileName, string sheetNameAndTypeHostsOrUrls, int columnHost, int columnPort, int columnResult)
        {
            data = new List<Sources>();
            this.sheetName = sheetNameAndTypeHostsOrUrls + "$";
            this.columnHost = columnHost;
            this.columnPort = columnPort;
            this.columnResult = columnResult;
        }

        public void reassignToUrls(string fileName, string sheetNameAndTypeHostsOrUrls, int columnUrl, int columnResult)
        {
            data = new List<Sources>();
            this.sheetName = sheetNameAndTypeHostsOrUrls + "$";
            this.columnUrl = columnUrl;
            this.columnResult = columnResult;
        }*/
        
        public override string identifyIpBelongToSubnet(List<string> compareStatements)
        {
            return base.identifyIpBelongToSubnet(compareStatements);
        }

        private string getConnectionString(string aditionalParameters) //, string action
        {
            string connectionString = String.Empty;
            switch (fileInfo.Extension)    //https://www.connectionstrings.com/excel/  //https://www.connectionstrings.com/ace-oledb-12-0/
            {
                case ".xls":
                    connectionString = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=No", fileInfo.FullName);
                    break;
                case ".xlsm":
                    connectionString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Macro;HDR=No", fileInfo.FullName);
                    break;
                default:
                    connectionString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=No", fileInfo.FullName);
                    break;
            }
            connectionString += aditionalParameters;
            return connectionString;
        }

        public override bool readFile() //Sources type
        {
            string connectionString = getConnectionString(";ReadOnly=true\";"); //"IMEX=1; ReadOnly=true\";";
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                OleDbCommand cmd = new OleDbCommand();
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM [" + sheetName + "]";
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                dt.TableName = sheetName;
                da.Fill(dt);
                headers = new List<ColumnHeader>();
                ColumnHeader h;
                switch (sheetName)
                {
                    case url:
                        h = new ColumnHeader();
                        h.Name = dt.Columns[columnUrl].ColumnName;
                        h.Text = dt.Columns[columnUrl].ColumnName;
                        headers.Add(h);
                        h = new ColumnHeader();
                        h.Name = dt.Columns[columnResult].ColumnName;
                        h.Text = dt.Columns[columnResult].ColumnName;
                        headers.Add(h);
                        break;
                    case host:
                        h = new ColumnHeader();
                        h.Name = dt.Columns[columnHost].ColumnName;
                        h.Text = dt.Columns[columnHost].ColumnName;
                        headers.Add(h);
                        h = new ColumnHeader();
                        h.Name = dt.Columns[columnPort].ColumnName;
                        h.Text = dt.Columns[columnPort].ColumnName;
                        headers.Add(h);
                        h = new ColumnHeader();
                        h.Name = dt.Columns[columnResult].ColumnName;
                        h.Text = dt.Columns[columnResult].ColumnName;
                        headers.Add(h);
                        break;
                }
                foreach (DataRow row in dt.Rows)
                {
                    switch (sheetName)
                    {
                        case url:
                            Uri urlObj;
                            Uri.TryCreate(row[columnUrl].ToString().Trim(), UriKind.Absolute, out urlObj);
                            if (urlObj == null) continue;
                            data.Add(new urlsSource(row[columnResult].ToString().Trim(), urlObj));
                            break;
                        case host:
                            IPAddress ip;
                            IPAddress.TryParse(row[columnHost].ToString().Trim(), out ip);
                            int port;
                            int.TryParse(row[columnPort].ToString().Trim(), out port);
                            if (ip == null || port <= 0) continue;
                            data.Add(new hostsSource(row[columnResult].ToString().Trim(), ip, port));
                            break;
                    }
                }
            }
            if (data.Count > 0)
                return true;
            else
                return false;
        }

        public override ColumnHeader[] columnHeader    //string sheetName, List<int> choosenColumns
        {
            get
            {
                return this.headers.ToArray();
            }
        }

        public override void updateExistsFile()  //http://csharp.net-informations.com/   //string sheetName, List<int> choosenColumns
        {
            FileStream stream = null;
            try
            {
                stream = fileInfo.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch
            {
                throw;
            }  
            finally 
            {
                if (stream != null) { stream.Close(); stream = null; }
            }
            int numberOfRecords = 0;
            string connectionString = getConnectionString(";Mode=ReadWrite;\";");
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                foreach (Sources obj in data)
                {
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = String.Format("Update ['{0}'] set ", sheetName);
                    urlsSource urlObj;
                    hostsSource hostObj;
                    if (obj is urlsSource)
                    {
                        cmd.CommandText += String.Format("{0} = {1} where ", this.headers[1].Name, "?");
                        urlObj = obj as urlsSource;
                        cmd.Parameters.AddWithValue("@" + urlObj.result, urlObj.result);
                        cmd.CommandText += String.Format("{0} = {1};", this.headers[0].Name, "?");
                        cmd.Parameters.AddWithValue("@" + urlObj.url, urlObj.url.ToString());
                    }
                    else if (obj is hostsSource)
                    {
                        cmd.CommandText += String.Format("{0} = {1} where ", this.headers[2].Name, "?");
                        hostObj = obj as hostsSource;
                        cmd.Parameters.AddWithValue("@" + hostObj.result, hostObj.result);
                        cmd.CommandText += String.Format("{0} = {1} AND {2} = {3};", this.headers[0].Name, "?", this.headers[1].Name, "?");
                        cmd.Parameters.AddWithValue("@" + hostObj.IP, hostObj.IP.ToString());
                        cmd.Parameters.AddWithValue("@" + hostObj.port, hostObj.port.ToString());
                    }
                    if (!String.IsNullOrEmpty(cmd.CommandText))
                        numberOfRecords += cmd.ExecuteNonQuery();
                }
            }
        }
        public override void writeNewFile(string fileName)
        {
            try
            {
                File.Copy(fileInfo.FullName, fileName);
                fileInfo = new FileInfo(fileName);
                updateExistsFile();
            }
            catch
            {
                throw;
            }
        }
    }
}
