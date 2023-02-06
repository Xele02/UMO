using UnityEngine;
using System.Collections;
using XeSys;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif

public static class MonoBehaviourExtensions
{
    public static Coroutine StartCoroutineWatched(this MonoBehaviour owner, IEnumerator coroutine)
    {
        Coroutine c = owner.StartCoroutine(CoroutineWatcher.Instance.Run(coroutine));
        return c;
    }
}

public static class Co
{
    public static IEnumerator R(IEnumerator e)
    {
        return CoroutineWatcher.Instance.Run(e);
    }
}

public class CoroutineWatcher : SingletonMonoBehaviour<CoroutineWatcher>
{
    public class Info
    {
        public Coroutine c;
        public IEnumerator e;
        public System.Diagnostics.StackTrace stackInfo;
    }

    public List<Info> coroutines = new List<Info>();

    public bool GetStackTrace = false;

    public IEnumerator Run(IEnumerator e)
    {
        Info i = new Info();
        if(GetStackTrace)
            i.stackInfo = new System.Diagnostics.StackTrace(true);
        i.e = e;
        UnityEngine.Debug.LogError("Begin"+e);
        coroutines.Add(i);
        yield return e;
        UnityEngine.Debug.LogError("End"+e);
        coroutines.Remove(i);
    }
#if UNITY_EDITOR
	[MenuItem("UMO/Dump Coroutines Info")]
#endif
    static public void DumpCoroutineInfo()
    {
        List<Info> cs = Instance.coroutines;
        for(int i = 0; i < cs.Count; i++)
        {
            object target = cs[i].e.Current;
            IEnumerator waiting = cs[i].e.Current as IEnumerator;
            if(waiting != null && waiting.ToString().Contains("CoroutineWatcher+<Run>") && waiting.Current != null)
            {
                Info i_ = cs.Find((Info info) => { return info.e == waiting.Current; });
                if(i_ != null)
                {
                    target = i_.e;
                }
            }
            UnityEngine.Debug.LogError(""+i+" "+cs[i].e+" "+target+"\n"+cs[i].stackInfo);
        }
    }
}