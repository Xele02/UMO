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
		IEnumerator s = CoroutineWatcher.Instance.Run(coroutine);
		Coroutine c = /*owner.*/CoroutineWatcher.Instance.StartCoroutine(s);
		CoroutineWatcher.Instance.SetSpawned(coroutine, s, c, owner);
		return c;
	}
	public static void StopCoroutineWatched(this MonoBehaviour owner, IEnumerator coroutine)
	{
		/*owner.*/CoroutineWatcher.Instance.StopCoroutine(CoroutineWatcher.Instance.Find(coroutine));
		owner.StopCoroutine(coroutine);
	}
	public static void StopCoroutineWatched(this MonoBehaviour owner, Coroutine coroutine)
	{
		CoroutineWatcher.Instance.StopCoroutine(coroutine);
		owner.StopCoroutine(coroutine);
	}
	public static Coroutine StartCoroutineWatched(this MonoBehaviour owner, string FuncName)
	{
		Coroutine c = owner.StartCoroutine(FuncName);
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
		public IEnumerator spawned;
		public MonoBehaviour owner;
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
        //UnityEngine.Debug.LogError("Begin"+e);
        coroutines.Add(i);
        yield return e;
        //UnityEngine.Debug.LogError("End"+e);
        coroutines.Remove(i);
    }

	public void SetSpawned(IEnumerator e, IEnumerator spawned, Coroutine c, MonoBehaviour owner)
	{
		Info info = coroutines.Find((Info _) =>
		{
			return _.e == e;
		});
		if(info != null)
		{
			info.spawned = spawned;
			info.c = c;
			info.owner = owner;
		}
	}

	public IEnumerator Find(IEnumerator e)
	{
		Info info = coroutines.Find((Info _) =>
		{
			return _.e == e;
		});
		if (info != null)
			return info.spawned;
		return e;
	}

#if UNITY_EDITOR
	[MenuItem("UMO/Dump Coroutines Info")]
#endif
    static public void DumpCoroutineInfo()
    {
        List<Info> cs = Instance.coroutines;
		for (int i = cs.Count - 1; i >= 0; i--)
		{
			if(cs[i].owner == null || cs[i].c == null)
			{
				cs.RemoveAt(i);
			}
		}
		for (int i = 0; i < cs.Count; i++)
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
