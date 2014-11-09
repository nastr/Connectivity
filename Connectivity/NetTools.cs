using System;
using System.Linq;
using System.Collections.Generic;
//using System.Data;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace Connectivity
{
    public interface IdataObject
    {
        event EventHandler<EndEventArgs> End;
        //void fileReassign(string fileName);
        //string fileDetails { get; }
        bool readFile();
        ColumnHeader[] columnHeader { get; }
        ListViewItem[] listItem { get; }
        void updateExistsFile();
        void writeNewFile(string fileName);
        void testConnectivity(int timeOut, bool useProxyFromIE);
        string identifyIpBelongToSubnet(List<string> compareStatements);
        //bool sourcesExists { get; }
        //int columnResult { get; set; }
    }

    public class EndEventArgs : EventArgs
    {
        public int rowIndex { get; private set; }
        public string textValue { get; private set; }
        public int progress { get; private set; }
        public EndEventArgs(int rowIndex, string textValue, int progress)
        {
            this.rowIndex = rowIndex;
            this.textValue = textValue;
            this.progress = progress;
        }
    }

    public class NetTools : IdataObject
    {
        protected class Sources
        {
            public string result { get; set; }
            public Sources(string result)
            {
                this.result = result;
            }
        }
        protected class hostsSource : Sources
        {
            public IPAddress IP { get; set; }
            public int port { get; set; }
            public hostsSource(string result, IPAddress IP, int port)
                : base(result)
            {
                this.IP = IP;
                this.port = port;
            }
        }
        protected class urlsSource : Sources
        {
            public Uri url { get; set; }
            public urlsSource(string result, Uri url)
                : base(result)
            {
                this.url = url;
            }
        }

        public event EventHandler<EndEventArgs> End;
        public int progress { get; private set; }
        protected int columnResult { get; set; }
        private CancellationTokenSource cts;
        protected FileInfo fileInfo;
        protected List<Sources> data;
        protected List<ColumnHeader> headers;


        public NetTools(string fileName)    //, string typeHostsOrUrlsAndsheetName
        {
            progress = 0;
            data = new List<Sources>();
            fileInfo = new FileInfo(fileName);
            //this.type = typeHostsOrUrlsAndsheetName.ToLower();
        }

        /*public virtual bool sourcesExists
        {
            get { if (data != null && data.Count > 0) return true; else return false; }
        }
        
        public virtual void fileReassign(string fileName)
        {
            fileInfo = new FileInfo(fileName);
            data.Clear();
        }

        public string fileDetails
        {
            get
            {
                if (fileInfo.Exists)
                    return fileInfo.FullName + "\n" + fileInfo.LastAccessTimeUtc;
                else
                    return "File unreachable or doesn't exist";
            }
        }*/
        public virtual ColumnHeader[] columnHeader    //string sheetName, List<int> choosenColumns
        {
            get
            {
                headers = new List<ColumnHeader>();
                ColumnHeader h;
                if (data[0] is urlsSource)
                {
                    h = new ColumnHeader();
                    h.Text = "URL";
                    headers.Add(h);
                    h = new ColumnHeader();
                    h.Text = "Result";
                    headers.Add(h);
                }
                else if (data[0] is hostsSource)
                {
                    h = new ColumnHeader();
                    h.Text = "IP";
                    headers.Add(h);
                    h = new ColumnHeader();
                    h.Text = "Port";
                    headers.Add(h);
                    h = new ColumnHeader();
                    h.Text = "Result";
                    headers.Add(h);
                }
                else return null;
                return headers.ToArray(); 
            }
        }
        public virtual ListViewItem[] listItem
        {
            get
            {
                List<ListViewItem> items = new List<ListViewItem>();
                foreach (Sources obj in data)
                {
                    ListViewItem item;
                    if (obj is urlsSource)
                    {
                        urlsSource urlObj;
                        urlObj = obj as urlsSource;
                        item = new ListViewItem(urlObj.url.ToString());
                        item.SubItems.Add(urlObj.result);
                    }
                    else if (obj is hostsSource)
                    {
                        hostsSource hostObj;
                        hostObj = obj as hostsSource;
                        item = new ListViewItem(hostObj.IP.ToString());
                        item.SubItems.Add(hostObj.port.ToString());
                        item.SubItems.Add(hostObj.result);
                    }
                    else return null;
                    items.Add(item);
                }
                return items.ToArray();
            }
        }

        public virtual string identifyIpBelongToSubnet(List<string> compareStatements)
        {
            try
            {
                foreach (string str in compareStatements)
                {
                    if (str.Split('/').Length == 2)
                    {
                        IPAddress network = IPAddress.Parse(str.Split('/')[0]);
                        IPAddress subnet = null;
                        if (str.Split('/')[1].Length == 2)
                            subnet = IPAddress.Parse(CIDR2DECIMAL(Convert.ToInt32(str.Split('/')[1])));
                        else
                            subnet = IPAddress.Parse(str.Split('/')[1]);
                        foreach (IPAddress localIP in Dns.GetHostAddresses(Dns.GetHostName()))
                            if (IPv4InNetwork(localIP, subnet, network))
                                return str;
                    }
                }
            }
            catch
            {
                throw;
            }
            return null;
        }

        private bool IPv4InNetwork(IPAddress address, IPAddress subnet, IPAddress network)
        {
            if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) // IPv4
            {
                Byte[] addressOctets = address.GetAddressBytes();
                Byte[] subnetOctets = subnet.GetAddressBytes();
                Byte[] networkOctets = network.GetAddressBytes();
                return
                    (networkOctets[0] == (addressOctets[0] & subnetOctets[0])) &&
                    (networkOctets[1] == (addressOctets[1] & subnetOctets[1])) &&
                    (networkOctets[2] == (addressOctets[2] & subnetOctets[2])) &&
                    (networkOctets[3] == (addressOctets[3] & subnetOctets[3]));
            }
            else // IPv6
                return false;
        }

        private string CIDR2DECIMAL(int cidr)
        {
            string[] decim = new string[4];
            for (int i = 0; i < 4; i++)
            {
                if (cidr > 8)
                {
                    decim[i] = "255";
                    cidr -= 8;
                }
                else
                {
                    int temp = 0;
                    for (int a = 7; cidr > 0; a--, cidr--)
                    {
                        temp += (int)Math.Pow(2, a);
                    }
                    decim[i] = temp.ToString();
                }
            }
            return decim[0] + "." + decim[1] + "." + decim[2] + "." + decim[3];
        }

        /*public virtual void testConnectivity1(int timeOut, bool useProxyFromIE)    //string sheetName, int ipColumnNumber, int portColumnNumber
        {
            ThreadStart ts = delegate
            {
                  testConnectivity(timeOut, useProxyFromIE);
            };
            new Thread(ts).Start();
        }*/

        private class TaskInfo
        {
            public int index;
            public Uri url;
            public int timeOut;
            public bool useProxyFromIE;
            public TaskInfo(int index, Uri url, int timeOut, bool useProxyFromIE)
            {
                this.index = index;
                this.url = url;
                this.timeOut = timeOut;
                this.useProxyFromIE = useProxyFromIE;
            }
        }

        public virtual void testConnectivity(int timeOut, bool useProxyFromIE)    //string sheetName, int ipColumnNumber, int portColumnNumber
        {

            try
            {
                progress = 0;
                foreach (Sources obj in data)
                {
                    if (obj is urlsSource)
                    {
                        if (data.IndexOf(obj) == data.Count) 
                            progress = data.Count;
                        urlsSource urlObj;
                        urlObj = obj as urlsSource;
                        /*int workerThreads, cmpThreads;
                        ThreadPool.GetMaxThreads(out workerThreads, out cmpThreads);
                        if (workerThreads < 32)
                        {
                            workerThreads = 32;
                        }
                        ThreadPool.SetMaxThreads(workerThreads, cmpThreads);

                        ThreadPool.GetMinThreads(out workerThreads, out cmpThreads);
                        if (workerThreads < 4)
                        {
                            workerThreads = 4;
                        }
                        ThreadPool.SetMinThreads(workerThreads, cmpThreads);


                        //WaitCallback callback = delegate(object state) { DoCall((string)state); };
                        //ThreadPool.QueueUserWorkItem(callback, urlObj.url);
                        /*ThreadStart ts = delegate
                        {
                            testUrlAvailability(data.IndexOf(obj), urlObj.url, timeOut, useProxyFromIE);
                        };
                        new Thread(ts).Start();*/
                        TaskInfo ti = new TaskInfo(data.IndexOf(obj), urlObj.url, timeOut, useProxyFromIE);

                        ThreadPool.QueueUserWorkItem(
                            new WaitCallback(testUrlAvailability), ti
                            //new WaitCallback(delegate(object state) { testUrlAvailability(data.IndexOf(obj), urlObj.url, timeOut, useProxyFromIE); })
                            );

                    }
                    else if (obj is hostsSource)
                    {
                        hostsSource hostObj;
                        hostObj = obj as hostsSource;
                        testHostAvailability(data.IndexOf(obj), hostObj.IP, hostObj.port, timeOut);
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        async Task AccessTheWebAsync(CancellationToken ct)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)");

            List<string> URLList = new List<string>();
            foreach (Sources obj in data)
            {
                urlsSource urlObj;
                urlObj = obj as urlsSource;
                URLList.Add(urlObj.url.ToString());
            }

            IEnumerable<Task<string>> downloadTasksQuery = from url in URLList select ProcessURL(url, client, ct);

            List<Task<string>> downloadTasks = downloadTasksQuery.ToList();

            while (downloadTasks.Count > 0)
            {
                Task<string> firstFinishedTask = await Task.WhenAny(downloadTasks);
                data[downloadTasks.IndexOf(firstFinishedTask)].result = firstFinishedTask;
                downloadTasks.Remove(firstFinishedTask);

                string length = await firstFinishedTask;  //this is the data of the first finished download
                int refPoint = length.IndexOf("Download (Save as...): <a href=\"") + 32;
                data[ti.index].result = res;
                //progress++;
                EndEventArgs endEventArgs = new EndEventArgs(ti.index, res, ++progress);   //- delta
                EventHandler<EndEventArgs> end = End;
                if (end != null) end(this, endEventArgs);
                //VideoList.Add(length.Substring(refPoint, length.IndexOf("\">", refPoint) - refPoint));
            }
        }

        async Task<string> ProcessURL(string url, HttpClient client, CancellationToken ct)
        {
            HttpResponseMessage response = await client.GetAsync(url, ct);
            string urlContents = await response.Content.ReadAsStringAsync();
            return urlContents;
        }


        async void testUrlAvailability1(Object stateInfo)   //int index, Uri url, int timeOut, bool useProxyFromIE)
        {
            TaskInfo ti = (TaskInfo)stateInfo;
            try
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(ti.url);
                string res = (int)response.StatusCode + " - " + response.StatusCode.ToString();
                data[ti.index].result = res;
                //progress++;
                EndEventArgs endEventArgs = new EndEventArgs(ti.index, res, ++progress);   //- delta
                EventHandler<EndEventArgs> end = End;
                if (end != null) end(this, endEventArgs);
            }
            catch (HttpRequestException ex)
            {
                data[ti.index].result = ex.InnerException.Message;
                //progress++;
                EndEventArgs endEventArgs = new EndEventArgs(ti.index, ex.InnerException.Message, ++progress);   //- delta
                EventHandler<EndEventArgs> end = End;
                if (end != null) end(this, endEventArgs);
            }
            catch (TaskCanceledException ex)    //TaskCanceledException await GetAsync
            {
                data[ti.index].result = ex.Message;
                //progress++;
                EndEventArgs endEventArgs = new EndEventArgs(ti.index, ex.Message, ++progress);   //- delta
                EventHandler<EndEventArgs> end = End;
                if (end != null) end(this, endEventArgs);
             }
        }

        protected async void testUrlAvailability(Object stateInfo)   //int index, Uri url, int timeOut, bool useProxyFromIE)
        {
            TaskInfo ti = (TaskInfo)stateInfo;
            try
            {
                cts = new CancellationTokenSource();
                await AccessTheWebAsync(cts.Token, ti.url, ti.index, ti.timeOut, ti.useProxyFromIE);
                cts = null;
            }
            catch (HttpRequestException ex)
            {
                data[ti.index].result = ex.InnerException.Message;
                //progress++;
                EndEventArgs endEventArgs = new EndEventArgs(ti.index, ex.InnerException.Message, ++progress);   //- delta
                EventHandler<EndEventArgs> end = End;
                if (end != null) end(this, endEventArgs);
            }
            /*catch (WebException ex) //HttpRequestException
            {
                data[index].result = (int)((HttpWebResponse)ex.Response).StatusCode + " - " + ((HttpWebResponse)ex.Response).StatusCode;
                //progress++;
                EndEventArgs endEventArgs = new EndEventArgs(index, data[index].result, ++progress);   //- delta
                EventHandler<EndEventArgs> end = End;
                if (end != null) end(this, endEventArgs);
            }*/
            catch (TaskCanceledException ex)    //TaskCanceledException await GetAsync
            {
                data[ti.index].result = ex.Message;
                //progress++;
                EndEventArgs endEventArgs = new EndEventArgs(ti.index, ex.Message, ++progress);   //- delta
                EventHandler<EndEventArgs> end = End;
                if (end != null) end(this, endEventArgs);
                /*if (ex.CancellationToken == cts.Token)
                {
                    // a real cancellation, triggered by the caller
                }
                else
                {
                    // a web request timeout (possibly other things!?)
                    //+
                }*/
            }
            catch (NullReferenceException ex)    //TaskCanceledException await GetAsync
            {
                data[ti.index].result = ex.Message;
                //progress++;
                EndEventArgs endEventArgs = new EndEventArgs(ti.index, ex.Message, ++progress);   //- delta
                EventHandler<EndEventArgs> end = End;
                if (end != null) end(this, endEventArgs);
            }
            catch
            {
                throw;
            }
        }
        //C# HttpResponseMessage Task<string> await Task.WhenAny
        //http://stackoverflow.com/questions/19338454/downloadstringasync-multiple-urls-maintaining-order
        private async Task AccessTheWebAsync(CancellationToken ct, Uri url, int index, int timeOut, bool useProxyFromIE)
        {
            HttpClient client;
            //if (useProxyFromIE)
            //{
                IWebProxy webProxy = WebRequest.DefaultWebProxy;
                webProxy.Credentials = CredentialCache.DefaultNetworkCredentials;
                var httpClientHandler = new HttpClientHandler
                {
                    Proxy = webProxy,
                    UseProxy = true
                };
                client = new HttpClient(httpClientHandler);
            //}
            //else
            //    client = new HttpClient();
            //IgnoreBadCertificates();
            System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
            client.Timeout = TimeSpan.FromSeconds(1000000000000);

            //Task<string> downloadTasks = ProcessURL(url, client, ct, index);

            Task<string> firstFinishedTask = await Task.WhenAny(ProcessURL(url, client, ct, index)); //, Task.Delay(client.Timeout)); // Task.WhenAny(downloadTasks);
            data[index].result = await firstFinishedTask;
            //progress++;
            EndEventArgs endEventArgs = new EndEventArgs(index, await firstFinishedTask, ++progress);   //- delta
            EventHandler<EndEventArgs> end = End;
            if (end != null) end(this, endEventArgs);
        }



        //Task<string> ProcessURL
        private async Task<string> ProcessURL(Uri url, HttpClient client, CancellationToken ct, int index)
        {
            HttpResponseMessage response = await client.GetAsync(url, ct);
            string res = (int)response.StatusCode + " - " + response.StatusCode.ToString();
            return res;
        }

        /*private static void IgnoreBadCertificates()
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
        }*/
        private static bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        protected virtual void testHostAvailability(int index, IPAddress hostAddress, int port, int timeOut)
        {
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //clientSocket.SendTimeout = 1;// *100000;
            //clientSocket.ReceiveTimeout = 1;// *100000;timeOut
            SocketAsyncEventArgs telnetSocketAsyncEventArgs = new SocketAsyncEventArgs();
            telnetSocketAsyncEventArgs.RemoteEndPoint = new IPEndPoint(hostAddress, port);
            telnetSocketAsyncEventArgs.UserToken = index;
            telnetSocketAsyncEventArgs.Completed += new EventHandler<SocketAsyncEventArgs>(telnetSocketAsyncEventArgs_Completed);
            clientSocket.ConnectAsync(telnetSocketAsyncEventArgs);
        }

        private void telnetSocketAsyncEventArgs_Completed(object sender, SocketAsyncEventArgs e)
        {
            try
            {
                data[Convert.ToInt32(e.UserToken)].result = e.SocketError.ToString();
                progress++;
                EndEventArgs endEventArgs = new EndEventArgs(Convert.ToInt32(e.UserToken), e.SocketError.ToString(), progress);   //- delta
                EventHandler<EndEventArgs> end = End;
                if (end != null) 
                    end(this, endEventArgs);
            }
            catch
            {
                throw; 
            }
        }
        public virtual bool readFile()
        {
            foreach (string s in File.ReadAllLines(fileInfo.FullName))
            {
                if (s.Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Count() > 3) continue;
                Uri urlObj;
                Uri.TryCreate(s.Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)[0], UriKind.Absolute, out urlObj);
                if (urlObj != null && s.Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Count() == 1)
                    data.Add(new urlsSource(String.Empty, urlObj));
                else if (urlObj != null && s.Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Count() == 2)
                    data.Add(new urlsSource(s.Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)[1], urlObj));
                if (s.Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Count() > 1)
                {
                    IPAddress ip;
                    IPAddress.TryParse(s.Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)[0], out ip);
                    int port;
                    int.TryParse(s.Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)[1], out port);
                    if (ip != null && port > 0 && s.Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Count() == 2)
                        data.Add(new hostsSource(String.Empty, ip, port));
                    else if (ip != null && port > 0 && s.Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Count() == 3)
                        data.Add(new hostsSource(s.Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)[2], ip, port));
                }
            }
            if (data.Count > 0)
                return true;
            else
                return false;
        }
        public virtual void updateExistsFile()
        {
            List<string> tmp = new List<string>();
            foreach (Sources obj in data)
            {
                if (obj is urlsSource)
                {
                    urlsSource urlObj;
                    urlObj = obj as urlsSource;
                    tmp.Add(urlObj.url + "\t" + urlObj.result);
                }
                else if (obj is hostsSource)
                {
                    hostsSource hostObj;
                    hostObj = obj as hostsSource;
                    tmp.Add(hostObj.IP + "\t" + hostObj.port + "\t" + hostObj.result);
                }
            }
            try
            {
                File.WriteAllLines(fileInfo.FullName, tmp);
            }
            catch
            {
                throw;
            }
        }
        public virtual void writeNewFile(string fileName)
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
