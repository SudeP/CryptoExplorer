using BTC.BlockChainAPI;
using BTC.BlockChainAPI.LatestBlocksModels;
using BTC.Tools;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace BlockControl_Manage
{
    public partial class WFMain : Form
    {
        public WFMain()
        {
            InitializeComponent();
            long threadCount = long.Parse(ConfigurationManager.AppSettings["threadCount"]);
            string jsonPath = ConfigurationManager.AppSettings["jsonPath"];
            string appPath = ConfigurationManager.AppSettings["appPath"];
            Thread thread = new Thread(() =>
            {
                socketListener = new SocketListener(SocketListener.DefaultEncoding);
                socketListener.Receive += SocketListener_Receive;
                socketListener.Start();

                string json = APIBlockChain.GetLatestBlocks(out HttpStatusCode httpStatusCode);

                if (httpStatusCode == HttpStatusCode.OK)
                {

                    Invoke(new Action(() =>
                    {
                        dataGridView = new DataGridView()
                        {
                            Dock = DockStyle.Fill,
                            ReadOnly = true
                        };
                        Controls.Add(dataGridView);
                        dataGridView.Columns.Add("Id", "Id");
                        dataGridView.Columns.Add("currentHeight", "Current Height");
                        dataGridView.Columns.Add("currentHash", "Current Hash");
                        dataGridView.Columns.Add("startHeight", "Start Height");
                        dataGridView.Columns.Add("finishHeight", "Finish Height");
                        dataGridView.Columns.Add("docPath", "PATH");
                        dataGridView.Columns.Add("Time", "Time");
                        dataGridView.Columns.Add("state", "State");
                    }));


                    APILatestBlocks latestBlocks = APILatestBlocks.FromJson(json);

                    APILatestBlock apiLatestBlock = latestBlocks.Blocks[0];

                    long latestHeight = apiLatestBlock.Height;

                    long remaining = latestHeight % threadCount;

                    long workCount = latestHeight / threadCount;

                    for (long i = 0; i < threadCount; i++)
                    {

                        long starter = workCount * i;
                        long finisher = workCount * (i + 1);

                        if ((i + 1) == threadCount)
                            finisher += remaining;

                        Invoke(new Action(() =>
                        {
                            dataGridView.Rows.Add(
                                new object[]
                                {
                                    i,
                                    -1,
                                    "Empty",
                                    starter,
                                    finisher,
                                    "",
                                    -1,
                                    "Waiting"
                                });
                        }));

                        Process.Start(new ProcessStartInfo(appPath, $@"{jsonPath} {i} {starter} {finisher}"));
                    }
                }
                else
                {
                    MessageBox.Show($@"HttpStatusCode : {httpStatusCode}");
                    Environment.Exit(0);
                }
            });
            thread.Start();
        }
        private DataGridView dataGridView;
        private SocketListener socketListener;
        private void SocketListener_Receive(object sender, EventArgs e)
        {
            WriterJson(((string)sender));
        }
        public void WriterJson(string json)
        {
            Client client = JsonConvert.DeserializeObject<Client>(json);
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells["Id"].Value.ToString() == client.Id)
                {
                    row.Cells["Time"].Value = client.Time;
                    row.Cells["currentHeight"].Value = client.Height;
                    row.Cells["currentHash"].Value = client.Hash;
                    row.Cells["state"].Value = client.State;
                    row.Cells["docPath"].Value = client.DocPath;
                }
            }
        }
        private void WFMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process[] processes = Process.GetProcessesByName(ConfigurationManager.AppSettings["appName"]);
            foreach (Process process in processes)
                process.Kill();
            processes = Process.GetProcessesByName(ConfigurationManager.AppSettings["BlockControl_Manage"]);
            foreach (Process process in processes)
                process.Kill();
            try
            {
                socketListener.Stop();
            }
            catch { }
        }
    }
}
