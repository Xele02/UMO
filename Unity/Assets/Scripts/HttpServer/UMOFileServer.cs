using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.PackageManager.Requests;
using UnityEditor.SceneManagement;
#endif
using UnityEngine;

public class UMOFileServer : MonoBehaviour
{
    public string Url = "http://*:8000/";

    HttpListener listener;
    Task listenTask;
    Task broadcastTask;
    bool runServer = true;


#if UNITY_EDITOR
	[MenuItem("UMO/Start File Server", priority = 2)]
#endif
	static void StartFileServer()
	{
        TryStartServer();
    }

    void Start()
    {
#if !UNITY_ANDROID
        if(!RuntimeSettings.CurrentSettings.IsPathValid())
        {
            if(!UMOStart.TrySelectDirectory(TryStartServer))
			{
#if UNITY_EDITOR
				EditorApplication.isPlaying = false;
#endif
				return;
            }
        }
#endif
        this.StartCoroutineWatched(StartCo());
    }

    static void StartFileServerEditor()
	{
#if UNITY_EDITOR
		if (EditorSceneManager.GetActiveScene().name != "StartFileServer")
            EditorSceneManager.OpenScene("Assets/Scenes/StartFileServer.unity", OpenSceneMode.Single);
		EditorApplication.isPlaying = true;
#endif
	}
    static bool TryStartServer()
    {
        if(!RuntimeSettings.CurrentSettings.IsPathValid())
        {
            return UMOStart.TrySelectDirectory(TryStartServer);
        }
        else
        {
#if UNITY_EDITOR
			if(!EditorApplication.isPlaying)
                StartFileServerEditor();
#endif
			return true;
        }
    }

    IEnumerator StartCo()
    {
        if(listener != null && listener.IsListening)
            yield break;

        yield return Co.R(FileSystemProxy.InitServerFileList());

        listener = new HttpListener();
        listener.Prefixes.Add(Url);
        listener.Start();

        listenTask = HandleIncomingConnections();
        this.StartCoroutineWatched(Broadcast());
    }

    public async Task HandleIncomingConnections()
    {
        while (runServer && listener != null)
        {
            Debug.Log("Start wait");

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
                    UnityEngine.Debug.Log("Received request on "+req.Url.AbsolutePath);
                    data = System.IO.File.ReadAllBytes(UnityEngine.Application.dataPath+"/../../Data/RequestGetFiles.json");
                }
                else
                {
                    string f = FileSystemProxy.ConvertPath(UnityEngine.Application.persistentDataPath + "/data" + req.Url.AbsolutePath);
                    UnityEngine.Debug.Log("Received request on "+req.Url.AbsolutePath+" for "+f);
                    if(File.Exists(f))
                    {
                        data = File.ReadAllBytes(f);
                    }
                }
                if(data == null)
                {
                    UnityEngine.Debug.LogError("not found");
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
                UnityEngine.Debug.Log(req.Url.AbsolutePath+"Sent");
            }//);
        }
    }

    IEnumerator Broadcast()
    {
        int PORT = 8001;
        UdpClient udpClient = new UdpClient();
        udpClient.Client.EnableBroadcast = true;
        udpClient.Client.Bind(new IPEndPoint(IPAddress.Broadcast, PORT));

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

        listener.Stop();
        listener.Close();
        listener = null;
    }
    
};