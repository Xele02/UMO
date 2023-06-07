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
		Coroutine c_ = owner.StartCoroutine(coroutine);
		if(c_ == null)
		{
			// Coroutine immediately endend, return;
			return null;
		}
		IEnumerator s = CoroutineWatcher.Instance.Run(coroutine, c_);
		Coroutine c = CoroutineWatcher.Instance.StartCoroutine(s);
		CoroutineWatcher.Instance.SetSpawned(coroutine, s, c, owner);
		return c;
	}
	public static void StopCoroutineWatched(this MonoBehaviour owner, IEnumerator coroutine)
	{
		//CoroutineWatcher.Instance.StopCoroutine(CoroutineWatcher.Instance.Find(coroutine));
		CoroutineWatcher.Instance.Stop(coroutine);
		owner.StopCoroutine(coroutine);
	}
	public static void StopCoroutineWatched(this MonoBehaviour owner, Coroutine coroutine)
	{
		//owner/*CoroutineWatcher.Instance*/.StopCoroutine(coroutine);
		CoroutineWatcher.Instance.Stop(coroutine);
		owner.StopCoroutine(coroutine);
	}
	public static void StopAllCoroutinesWatched(this MonoBehaviour owner)
	{
		CoroutineWatcher.Instance.StopAll(owner);
		owner.StopAllCoroutines();
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
        yield return CoroutineWatcher.Instance.Run(e);
    }
}

public class CoroutineWatcher : SingletonMonoBehaviour<CoroutineWatcher>
{
    public class Info
    {
        public Coroutine c;
		public bool hasCoroutine = false;
        public IEnumerator e;
		public IEnumerator spawned;
		public MonoBehaviour owner;
		public System.Diagnostics.StackTrace stackInfo;
		public int Id;
    }

    public List<Info> coroutines = new List<Info>();

    public bool GetStackTrace = false;

	static int cntRun = 0;
    public IEnumerator Run(IEnumerator e, Coroutine c_ = null)
    {
        Info i = new Info();
        if(GetStackTrace)
            i.stackInfo = new System.Diagnostics.StackTrace(true);
        i.e = e;
		i.Id = cntRun++;
        //UnityEngine.Debug.LogError(""+i.Id+" Begin "+e);
        coroutines.Add(i);
		if(c_ != null)
			yield return c_;
		else
        	yield return e;
        //UnityEngine.Debug.LogError(""+i.Id+" End "+e);
        coroutines.Remove(i);
    }

	public void Stop(IEnumerator e)
	{
		Info i_ = coroutines.Find((Info info_) => 
		{ 
			return info_.e == e;
		});
		if(i_ != null)
		{
			coroutines.Remove(i_);
		}
	}
	public void StopAll(MonoBehaviour owner)
	{
		coroutines.RemoveAll((Info info_) =>
		{
			return info_.owner == owner;
		});
	}
	public void Stop(Coroutine c)
	{
		Info i_ = coroutines.Find((Info info_) => 
		{ 
			return info_.c == c;
		});
		if(i_ != null)
		{
			coroutines.Remove(i_);
		}
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
			info.hasCoroutine = c != null;
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

	public void Update()
	{
        List<Info> cs = Instance.coroutines;
		for (int i = cs.Count - 1; i >= 0; i--)
		{
			if((cs[i].hasCoroutine && (cs[i].owner == null || !cs[i].owner.gameObject.activeInHierarchy || cs[i].c == null)))
			{
				//Debug.LogError("Removed info for "+cs[i].Id+" "+cs[i].e+". "+cs[i].owner+" - "+cs[i].hasCoroutine+" - "+cs[i].c);
				cs.RemoveAt(i);
			}
		}
	}

#if UNITY_EDITOR
	[MenuItem("UMO/Dump Coroutines Info")]
#endif
    static public void DumpCoroutineInfo()
    {
		Instance.Update();
        List<Info> cs = Instance.coroutines;
		List<int> displayed = new List<int>();
		for (int i = 0; i < cs.Count; i++)
        {
            DumpCoroutineInfo(cs[i], cs, displayed);
        }
    }

	static public object FindTarget(Info info)
	{
		object target = info.e.Current;
		IEnumerator waiting = info.e.Current as IEnumerator;
		if(waiting != null && waiting.ToString().Contains("Co+<R>") && waiting.Current != null)
		{
			waiting = waiting.Current as IEnumerator;
			if(waiting != null && waiting.ToString().Contains("CoroutineWatcher+<Run>") && waiting.Current != null)
			{
				target = waiting.Current;
			}
		}
		return target;
	}

	static public void DumpCoroutineInfo(Info info, List<Info> cs, List<int> displayed, string level = "")
	{
		if(displayed.Contains(info.Id))
			return;
		// Check we are not a child and parent is not displayed
		{
			Info i_ = cs.Find((Info info_) => 
			{ 
				object target_ = FindTarget(info_);
				return target_ != null && (target_ == info.e || info.c == target_); 
			});
			if(i_ != null && !displayed.Contains(i_.Id))
			{
				return;
			}
		}

		object target = FindTarget(info);

		string ownerInfo = "";
		if(info.owner != null)
			ownerInfo = " ["+(!info.owner.gameObject.activeInHierarchy ? "[Disabled] ": "")+""+info.owner+" : "+info.c+"]";
		UnityEngine.Debug.LogError(level+info.Id+" "+info.e+""+ownerInfo+" ===> "+target+"\n"+info.stackInfo);
		displayed.Add(info.Id);

		if(target != null)
		{
			Info i_ = cs.Find((Info info_) => { return info_.e == target || info_.c == target; });
			if(i_ != null)
			{
				DumpCoroutineInfo(i_, cs, displayed, level + "   ");
			}
		}
	}
}
