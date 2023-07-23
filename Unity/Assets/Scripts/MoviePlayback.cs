using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using LibVLCSharp.Shared;
using CriWare.CriMana;
using System;
#if UNITY_EDITOR
using UnityEditor;

[InitializeOnLoadAttribute]
public static class MoviePauseStateChanged
{
    // register an event handler when the class is initialized
    static MoviePauseStateChanged()
    {
        EditorApplication.pauseStateChanged += LogPauseState;
    }

    public static List<MoviePlayback> playbacks = new List<MoviePlayback>();

    private static void LogPauseState(PauseState state)
    {
        if(Application.isPlaying)
        {
            for(int i = 0; i < playbacks.Count; i++)
            {
                playbacks[i].SetPauseEditor(state == PauseState.Paused);
            }
        }
    }
}
#endif

public abstract class MoviePlayback : MonoBehaviour
{
    protected const int seekTimeDelta = 5000;
    protected Texture tex = null;
    protected bool playing;
    protected string videoPath;
    
    protected uint width;
    protected uint height;
    protected uint pitch;
    protected uint lines;

    protected bool loop = false;

    protected bool pauseEditor = false;
    protected bool pause = false;

    protected float time = 0;
    protected VLCState state;

    public virtual void Awake()
    {
        #if UNITY_EDITOR
        MoviePauseStateChanged.playbacks.Add(this);
        #endif
    }
    public virtual void OnDestroy()
    {
        #if UNITY_EDITOR
        MoviePauseStateChanged.playbacks.Remove(this);
        #endif
        
    }

    public abstract void Init(string path, bool loop, Action<MovieInfo> onReady);

    protected bool isReady = false;

    public abstract IEnumerator Prepare(int _width = -1, int _height = -1);

    public VLCState GetState()
    {
        return state;
    }

    public bool IsReady()
    {
        return isReady;
    }

    public abstract void PlayPause();

    public virtual void SetLoop(bool loop)
    {
        this.loop = loop;
    }

    public abstract void StartPlay();

    public long GetTime()
    {
        return (long)(time * 1000 * 1000);
    }

    public abstract void Stop ();

    public abstract bool IsPlaying();

    public bool IsPaused()
    {
        return pause;
    }

    public void Pause(bool pause)
    {
        this.pause = pause;
        UpdatePause();
    }

    public void SetPauseEditor(bool pause)
    {
        pauseEditor = pause;
        UpdatePause();
    }

    protected abstract void UpdatePause();

    public void CleanAndDestroy()
    {
        Destroy(gameObject);
    }

    protected abstract void Update();

    public Texture GetTexture()
    {
        return tex;
    }

}
