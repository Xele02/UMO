using CriWare.CriMana;
using UnityEngine;
using UnityEngine.Video;
using VGMToolbox.format;
using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using LibVLCSharp.Shared;
using System.Collections;
using UnityEditor;

public class StreamedMoviePlayback : MoviePlayback
{
    VideoPlayer _mediaPlayer;
    bool isValid = false;


    public override void Awake()
    {
        base.Awake();
        _mediaPlayer = gameObject.AddComponent<VideoPlayer>();
        _mediaPlayer.loopPointReached += (VideoPlayer vp) =>
        {
            if(!loop)
                state = VLCState.Ended;
        };
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        _mediaPlayer = null;
    }
    private string tmpPath = "";

#if UNITY_EDITOR_LINUX || UNITY_EDITOR_OSX
    [MenuItem("UMO/Convert all movies")]
    public static void ConvertAll()
    {
        string moviePath = Application.persistentDataPath + "/Movies/";
        if(!Directory.Exists(moviePath))
            Directory.CreateDirectory(moviePath);
        if(!string.IsNullOrEmpty(RuntimeSettings.CurrentSettings.DataDirectory))
        {
            List<string> movieList = new List<string>();
            RecursGetMovies(movieList, RuntimeSettings.CurrentSettings.DataDirectory);
            for(int i = 0; i < movieList.Count; i++)
            {
                if(EditorUtility.DisplayCancelableProgressBar("Converting movies", "["+i+"/"+movieList.Count+"] Convert "+movieList[i], i * 1.0f / movieList.Count))
                    break;
                string realPath = moviePath + Path.GetFileName(movieList[i]).Replace("usm", "webm");
                if(!File.Exists(realPath))
                {
                    CriUsmStream videoStream = new CriUsmStream(movieList[i]);
                    MpegStream.DemuxOptionsStruct demux = new MpegStream.DemuxOptionsStruct() { ExtractAudio = false };
                    if(!File.Exists(realPath))
                        demux.ExtractVideo = true;
                    demux.OutputPath = Path.GetTempPath();
                    demux.ExtractedFileList = new List<string>();
                    demux.Key1 = 0x44C5F5F5;
                    demux.Key2 = 0x0581B687;
                    videoStream.DemultiplexStreams(demux);
                    string tmpPath = "";
                    if(!File.Exists(realPath))
                    {
                        foreach(var s in demux.ExtractedFileList)
                        {
                            tmpPath = s;
                            break;
                        }
                    }
                    if(tmpPath != "")
                    {
                        ProcessStartInfo info = new ProcessStartInfo();
                        info.FileName = "ffmpeg";
                        info.Arguments = "-y -i "+tmpPath+" -c:v libvpx -crf 4 -b:v 10M "+realPath;
                        info.UseShellExecute = false;
                        Process p = new Process();
                        p.StartInfo = info;
                        TodoLogger.Log(TodoLogger.Movie, "Start converting " + tmpPath);
                        p.Start();
                        p.WaitForExit();
                        TodoLogger.Log(TodoLogger.Movie, "End converting " + tmpPath+" to "+realPath);
                        File.Delete(tmpPath);
                        tmpPath = "";
                    }
                }
            }
            EditorUtility.ClearProgressBar();
        }
    }
#endif

    public static void RecursGetMovies(List<string> list, string path)
    {
        string[] files = Directory.GetFiles(path, "*.usm");
        list.AddRange(files);
        string[] dirs = Directory.GetDirectories(path);
        for(int i = 0; i < dirs.Length; i++)
        {
            RecursGetMovies(list, dirs[i]);
        }
    }

    public override void Init(string path, bool loop, Action<MovieInfo> onReady)
    {
        string moviePath = Application.persistentDataPath + "/Movies/";
        if(!Directory.Exists(moviePath))
            Directory.CreateDirectory(moviePath);
        string realPath = moviePath + Path.GetFileName(path).Replace("usm", "webm");
        videoPath = realPath;

        CriUsmStream videoStream = new CriUsmStream(path);
        MpegStream.DemuxOptionsStruct demux = new MpegStream.DemuxOptionsStruct() { ExtractAudio = false };
        if(!File.Exists(realPath))
            demux.ExtractVideo = true;
        demux.OutputPath = Path.GetTempPath();
        demux.ExtractedFileList = new List<string>();
        demux.Key1 = 0x44C5F5F5;
        demux.Key2 = 0x0581B687;
        videoStream.DemultiplexStreams(demux);
        tmpPath = "";
        if(!File.Exists(realPath))
        {
            foreach(var s in demux.ExtractedFileList)
            {
                tmpPath = s;
                break;
            }
        }
        videoStream.movieInfo.codecType = CodecType.Theora;
        videoStream.movieInfo.alphaCodecType = CodecType.Theora;
        onReady(videoStream.movieInfo);

        this.StartCoroutineWatched(Prepare());
    }

    public override IEnumerator Prepare(int _width = -1, int _height = -1)
    {
        if(tmpPath != "")
        {
            //UnityEngine.Debug.LogError(s);
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "ffmpeg";
            //info.Arguments = "-y -i "+tmpPath+" -c:v libtheora -q:v 10 "+videoPath;
            info.Arguments = "-y -i "+tmpPath+" -c:v libvpx -crf 4 -b:v 10M "+videoPath;
            //info.RedirectStandardError = true;
            //info.RedirectStandardOutput = true;
            info.UseShellExecute = false;
            Process p = new Process();
            p.StartInfo = info;
            //p.OutputDataReceived += (s_, e) => UnityEngine.Debug.LogError(e.Data);
            //p.ErrorDataReceived += (s_, e) => UnityEngine.Debug.LogError(e.Data);
            TodoLogger.Log(TodoLogger.Movie, "Start converting " + tmpPath);
            p.Start();
            //p.BeginErrorReadLine();
            //p.BeginOutputReadLine();
            while(!p.HasExited)
                yield return null;
            TodoLogger.Log(TodoLogger.Movie, "End converting " + tmpPath+" to "+videoPath);
            File.Delete(tmpPath);
            tmpPath = "";
        }

        if(File.Exists(videoPath))
        {
            _mediaPlayer.source = VideoSource.Url;
            _mediaPlayer.url = videoPath;
            _mediaPlayer.playOnAwake = false;
            isValid = true;
        }
        else
        {
            time = 0;
            state = VLCState.NothingSpecial;
            isReady = true;
            tex = new Texture2D((int)1,
                        (int)1,
                        TextureFormat.RGBA32,
                        false,
                        true);
            (tex as Texture2D).SetPixel(0, 0, Color.black);
        }
        SetLoop(loop);
        
        if(isValid)
        {
            bool isPrepared = false;
            VideoPlayer.EventHandler cb = (VideoPlayer source) =>
            {
                isPrepared = true;
            };
            _mediaPlayer.errorReceived += (VideoPlayer vp, string message) =>
            {
                TodoLogger.LogError(TodoLogger.Movie, "Video Error : "+message);
            };
            _mediaPlayer.prepareCompleted += cb;
            _mediaPlayer.Prepare();
            while(!isPrepared)
                yield return null;
            _mediaPlayer.prepareCompleted -= cb;
            _mediaPlayer.renderMode = VideoRenderMode.RenderTexture;
            _mediaPlayer.Pause();
            _mediaPlayer.frame = 0;  
            if(_width == -1 || _height == -1)
            {
                _mediaPlayer.targetTexture = new RenderTexture((int)_mediaPlayer.width, (int)_mediaPlayer.height, 0);
            }
            else
            {
                _mediaPlayer.targetTexture = new RenderTexture((int)_width, (int)_height, 0);
            }
            tex = _mediaPlayer.targetTexture;
            time = 0;

            state = VLCState.NothingSpecial;
            isReady = true;
        }
        else
        {
            time = 0;
            state = VLCState.NothingSpecial;
            isReady = true;
            tex = new Texture2D((int)1,
                        (int)1,
                        TextureFormat.RGBA32,
                        false,
                        true);
            (tex as Texture2D).SetPixel(0, 0, Color.black);
        }
    }

    public override void PlayPause()
    {
        if(isValid)
        {
            if (_mediaPlayer.isPlaying)
            {
                _mediaPlayer.Pause();
                state = VLCState.Paused;
            }
            else
            {
                if(playing)
                    StartPlay();
            }
        }
        else
        {
            if(playing)
            {
                if(state != VLCState.Paused)
                    state = VLCState.Playing;
                else
                    state = VLCState.Paused;
            }
        }
    }

    public override void StartPlay()
    {
        playing = true;
        if(isValid)
        {
            state = VLCState.Playing;
            _mediaPlayer.Play();
        }
        else
        {
            state = VLCState.Playing;
        }
    }

    public override void Stop ()
    {
        playing = false;
        if(isValid)
        {
            _mediaPlayer?.Pause();
            _mediaPlayer.frame = 0;
            time = 0;
            state = VLCState.Stopped;
            
        }
        else
        {
            time = 0;
            state = VLCState.Stopped;
        }
    }
    public override void SetLoop(bool loop)
    {
        base.SetLoop(loop);
        _mediaPlayer.isLooping = loop;
    }
    
    public override bool IsPlaying()
    {
        if(isValid)
            return _mediaPlayer.isPlaying;
        else
            return false;
    }

    protected override void UpdatePause()
    {
        if(!playing)
            return;
        if(isValid)
        {
            if(pause || pauseEditor)
            {
                _mediaPlayer?.Pause();
                state = VLCState.Paused;
            }
            else
            {
                _mediaPlayer?.Play();
                state = VLCState.Playing;
            }
        }
        else
            state = pause ? VLCState.Paused : VLCState.Playing;
    }

    protected override void Update()
    {
        if(!playing) return;
        if(!isReady) return;

        if(!isValid)
        {
            if(state == VLCState.Playing)
            {
                time += Time.deltaTime;
                if(time > 10 && !loop)
                    state = VLCState.Ended;
            }
            return;
        }

        if(state == VLCState.Playing)
        {
            time = (float)_mediaPlayer.time;
        }
    }


}
