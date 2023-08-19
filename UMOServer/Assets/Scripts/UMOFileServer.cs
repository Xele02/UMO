using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class UMOFileServer : MonoBehaviour
{
    public string Url = "http://*:8000/";

    HttpListener listener;
    Task listenTask;
    Task broadcastTask;
    bool runServer = true;

    public Button startButton;
    public InputField fileDataPath;

    public TextAsset json;

    public static string filePath;

    public VerticalLayoutGroup logPanel;

    public Font font;

    void Start()
    {
        startButton.onClick.AddListener(StartServer);
    }

    public bool IsPathValid()
	{
		if (!string.IsNullOrEmpty(filePath))
		{
			if (Directory.Exists(filePath))
			{
				if (Directory.Exists(Path.Combine(filePath, "android")) && Directory.Exists(Path.Combine(filePath, "db")))
					return true;
			}
		}
		return false;
	}


    void StartServer()
    {
        filePath = fileDataPath.text;
        if(!IsPathValid())
        {
            Log("Path invalid");
        }
        else
        {
            startButton.interactable = false;
            this.StartCoroutine(StartCo());
        }
    }

    IEnumerator StartCo()
    {
        if(listener != null && listener.IsListening)
            yield break;

        Log("Initialize file list");
        yield return null;

        yield return FileSystemProxy.InitServerFileList(json);

        Log("Starting server");

        listener = new HttpListener();
        listener.Prefixes.Add(Url);
        listener.Start();

        listenTask = HandleIncomingConnections();
        this.StartCoroutine(Broadcast());
    }
    public void Log(string txt)
    {
        GameObject line = new GameObject();
        line.transform.SetParent(logPanel.transform, false);
        ContentSizeFitter c = line.AddComponent<ContentSizeFitter>();
        c.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        c.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        Text t = line.AddComponent<Text>();
        t.text = txt;
        t.font = font;
        line.transform.SetAsFirstSibling();
        if(logPanel.transform.childCount > 50)
            Destroy(logPanel.transform.GetChild(logPanel.transform.childCount - 1).gameObject);
    }

    public async Task HandleIncomingConnections()
    {
        Log("Ready");

        while (runServer && listener != null)
        {
            HttpListenerContext ctx = await listener.GetContextAsync();
            HttpListenerRequest req = ctx.Request;
            HttpListenerResponse resp = ctx.Response;
            //await Task.Run(async () =>
            {
                //foreach(var k in req.Headers)
                //    UnityEngine.Debug.LogError(k.ToString()+" "+req.Headers[k.ToString()].ToString());

                byte[] data = null;
                if(req.Url.AbsolutePath == "/RequestGetFiles.json")
                {
                    Log("Received request on "+req.Url.AbsolutePath);
                    data = json.bytes;
                }
                else
                {
                    string f = FileSystemProxy.ConvertPath(UnityEngine.Application.persistentDataPath + "/data" + req.Url.AbsolutePath);
                    Log("Received request on "+req.Url.AbsolutePath+" for "+f);
                    if(File.Exists(f))
                    {
                        data = File.ReadAllBytes(f);
                    }
                }
                if(data == null)
                {
                    Log("Not found");
                    resp.StatusCode = 404;
                }
                else
                {
                    resp.ContentType = "binary/octet-stream";
                    resp.AddHeader("Connection", "keep-alive");
                    resp.AddHeader("Accept-Ranges", "bytes");
                    resp.ContentLength64 = data.Length;
                    //resp.AddHeader("Content-Range", string.Format("bytes {0}-{1}/{2}", 0, data.Length - 1, data.Length));
                    await resp.OutputStream.WriteAsync(data, 0, data.Length);
                    resp.OutputStream.Flush();
                    resp.OutputStream.Close();
                }
                resp.Close();
                Log(req.Url.AbsolutePath+" Sent");
            }//);
        }
    }

    IEnumerator Broadcast()
    {
        int PORT = 8001;
        UdpClient udpClient = new UdpClient();
        udpClient.Client.EnableBroadcast = true;
        udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, PORT));

        while(true)
        {
            yield return new WaitForSeconds(1);
            var data = Encoding.UTF8.GetBytes("UMO");
            udpClient.Send(data, data.Length, "255.255.255.255", PORT);
        }
        udpClient.Close();
    }

    void OnDestroy()
    {
        runServer = false;

        listener?.Stop();
        listener?.Close();
        listener = null;
    }
    
};