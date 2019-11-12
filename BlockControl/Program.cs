using BTC.BlockChainAPI;
using BTC.BlockChainAPI.LatestBlocksModels;
using BTC.Tools;
using MongoDB.Bson;
using System;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;

namespace BlockControl
{
    public class Program
    {
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int SW_HIDE = 0;
        private const int SW_SHOW = 5;

        private static string jsonPath;
        private static string id;
        private static long startHeight;
        private static long finishHeight;

        private static void Main(string[] args)
        {
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);//hide
                                        //ShowWindow(handle, SW_SHOW);//show

            SocketClient socketClient = new SocketClient(SocketClient.DefaultEncoding);


            jsonPath = args[0];
            id = args[1];
            startHeight = long.Parse(args[2]);
            finishHeight = long.Parse(args[3]);

            Client client = new Client
            {
                Id = id,
            };

            for (; startHeight <= finishHeight; startHeight++)
            {
                string docPath = Path.Combine(jsonPath, $"{startHeight}.txt");
                if (File.Exists(docPath))
                    continue;
                client.Hash = "";
                client.Height = -1;
                client.Time = -1;
                client.DocPath = docPath;
                client.State = "Working";
                string json = APIBlockChain.GetBlockToHeight(startHeight, out HttpStatusCode httpStatusCode);
                if (httpStatusCode == HttpStatusCode.OK)
                {
                    dynamic apiBlockDetails = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<dynamic>(json);
                    if (apiBlockDetails.blocks.Count > 0)
                    {
                        string blockHash = apiBlockDetails.blocks[0].hash;
                        client.Hash = apiBlockDetails.blocks[0].hash;
                        client.Height = apiBlockDetails.blocks[0].height;
                        client.Time = apiBlockDetails.blocks[0].time;
                        socketClient.Send(client.ToString());
                        json = APIBlockChain.GetBlockDetailToHash(blockHash, out httpStatusCode);
                        if (httpStatusCode == HttpStatusCode.OK)
                        {

                            StreamWriter writer = File.CreateText(docPath);
                            writer.Write(json);
                            writer.Close();
                            socketClient.Send(client.ToString());
                        }
                        else
                        {
                            client.State = httpStatusCode.ToString();
                            socketClient.Send(client.ToString());
                            return;
                        }
                    }
                }
                else
                {
                    client.State = httpStatusCode.ToString();
                    socketClient.Send(client.ToString());
                    return;
                }
            }
            client.Hash = "Finish";
            client.Height = -1;
            client.Time = -1;
            client.DocPath = "Finish";
            client.State = "Finish";
            socketClient.Send(client.ToString());
            return;
        }
    }
}