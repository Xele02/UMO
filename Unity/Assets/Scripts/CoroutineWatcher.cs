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
		if(false)
		{
			return owner.StartCoroutine(coroutine);
		}
		else
		{
			Coroutine c_ = owner.StartCoroutine(coroutine);
			if(c_ == null)
			{
				// Coroutine immediately endend, return;
				return null;
			}
			IEnumerator s = CoroutineWatcher.Instance.Run(coroutine, c_);
			Coroutine c = CoroutineWatcher.Instance.StartCoroutine(s);
			CoroutineWatcher.Instance.SetWatcherInfo(coroutine, s, c, owner);
			return c;
		}
	}
	public static void StopCoroutineWatched(this MonoBehaviour owner, IEnumerator watcherEnumerator)
	{
		if(false)
		{
			owner.StopCoroutine(watcherEnumerator);
		}
		else
		{
			CoroutineWatcher.Instance.Stop(watcherEnumerator);
		}
	}
	public static void StopCoroutineWatched(this MonoBehaviour owner, Coroutine watcherCoroutine)
	{
		if(false)
		{
			owner.StopCoroutine(watcherCoroutine);
		}
		else
		{
			CoroutineWatcher.Instance.Stop(watcherCoroutine);
		}
	}
	public static void StopAllCoroutinesWatched(this MonoBehaviour owner)
	{
		if(false)
		{
			owner.StopAllCoroutines();
		}
		else
		{
			CoroutineWatcher.Instance.StopAll(owner);
			owner.StopAllCoroutines();
		}
	}
	public static Coroutine StartCoroutineWatched(this MonoBehaviour owner, string FuncName)
	{
		if(false)
		{
			return owner.StartCoroutine(FuncName);
		}
		else
		{
			Coroutine c = owner.StartCoroutine(FuncName);
			return c;
		}
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
        public Coroutine watcherCoroutine;
		public bool hasWatcherCoroutine = false;
        public IEnumerator ownerEnumerator;
		public Coroutine ownerCoroutine;
		public IEnumerator watcherEnumerator;
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
        i.ownerEnumerator = e;
		i.ownerCoroutine = c_;
		i.Id = cntRun++;
        TodoLogger.Log(998, ""+i.Id+" Begin "+e);
        coroutines.Add(i);
		if(c_ != null)
			yield return c_;
		else
        	yield return e;
        TodoLogger.Log(998, ""+i.Id+" End "+e);
        coroutines.Remove(i);
    }

	public void StopAll(MonoBehaviour owner)
	{
		List<Info> infos = coroutines.FindAll((Info info_) =>
		{
			return info_.owner == owner;
		});
		for(int i = 0; i < infos.Count; i++)
		{
			Stop(infos[i]);
		}
	}
	public void Stop(IEnumerator e)
	{
		Info i_ = coroutines.Find((Info info_) =>
		{
			return info_.watcherEnumerator == e;
		});
		if(i_ == null)
		{
			// Try to search in owner coroutine for some special cases
			i_ = coroutines.Find((Info info_) =>
			{
				return info_.ownerEnumerator == e;
			});
		}
		if (i_ != null)
		{
			Stop(i_);
		}
		else
		{
			if (RuntimeSettings.CurrentSettings.EnableDebugStopCoroutine)
			{
				UnityEngine.Debug.LogError("Cound not stop coroutine " + e);
				DumpCoroutineInfo();
				UnityEngine.Debug.LogError("=============");
			}
		}
	}

	public void Stop(Coroutine c)
	{
		Info i_ = coroutines.Find((Info info_) => 
		{ 
			return info_.watcherCoroutine == c;
		});
		if (i_ == null)
		{
			// Try to search in owner coroutine for some special cases
			i_ = coroutines.Find((Info info_) =>
			{
				return info_.ownerCoroutine == c;
			});
		}
		if (i_ != null)
		{
			Stop(i_);
		}
		else
		{
			if (RuntimeSettings.CurrentSettings.EnableDebugStopCoroutine)
			{
				UnityEngine.Debug.LogError("Cound not stop coroutine " + c);
				DumpCoroutineInfo();
				UnityEngine.Debug.LogError("=============");
			}
		}
	}

	public void Stop(Info i_)
	{
		if (i_.ownerCoroutine != null)
			i_.owner.StopCoroutine(i_.ownerCoroutine);
		else if (i_.ownerEnumerator != null)
			StopCoroutine(i_.ownerEnumerator);
		if(i_.hasWatcherCoroutine)
			StopCoroutine(i_.watcherCoroutine);
		else if(i_.watcherEnumerator != null)
			StopCoroutine(i_.watcherEnumerator);
		coroutines.Remove(i_);
	}

	public void SetWatcherInfo(IEnumerator ownerEnumerator_, IEnumerator watcherEnum, Coroutine watcherCoroutine_, MonoBehaviour owner)
	{
		Info info = coroutines.Find((Info _) =>
		{
			return _.ownerEnumerator == ownerEnumerator_;
		});
		if(info != null)
		{
			info.watcherEnumerator = watcherEnum;
			info.watcherCoroutine = watcherCoroutine_;
			info.hasWatcherCoroutine = watcherCoroutine_ != null;
			info.owner = owner;
		}
	}

	public Coroutine Find(IEnumerator e)
	{
		Info info = coroutines.Find((Info _) =>
		{
			return _.watcherEnumerator == e;
		});
		if (info != null)
			return info.ownerCoroutine;
		return null;
	}
	public Coroutine Find(Coroutine c)
	{
		Info info = coroutines.Find((Info _) =>
		{
			return _.watcherCoroutine == c;
		});
		if (info != null)
			return info.ownerCoroutine;
		return null;
	}

	public void Update()
	{
        List<Info> cs = Instance.coroutines;
		for (int i = cs.Count - 1; i >= 0; i--)
		{
			if((cs[i].hasWatcherCoroutine && (cs[i].owner == null || !cs[i].owner.gameObject.activeInHierarchy || cs[i].watcherCoroutine == null)))
			{
				//Debug.LogError("Removed info for "+cs[i].Id+" "+cs[i].e+". "+cs[i].owner+" - "+cs[i].hasCoroutine+" - "+cs[i].c);
				cs.RemoveAt(i);
			}
		}
		if(RuntimeSettings.CurrentSettings.EnableErrorLog)
		{
			if(lastUpdate == 0)
				lastUpdate = Time.realtimeSinceStartup;
			if(Time.realtimeSinceStartup - lastUpdate > 10)
			{
				DumpCoroutineInfo(false);
				lastUpdate = Time.realtimeSinceStartup;
			}
		}
	}
	float lastUpdate = 0;

#if UNITY_EDITOR
	[MenuItem("UMO/Dump Coroutines Info")]
#endif
    static public void DumpCoroutineInfo2()
    {
		DumpCoroutineInfo();
	}
    static public void DumpCoroutineInfo(bool canUpdate = true)
    {
		if(canUpdate)
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
		object target = info.ownerEnumerator.Current;
		IEnumerator waiting = info.ownerEnumerator.Current as IEnumerator;
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
				return target_ != null && (target_ == info.ownerEnumerator || info.watcherCoroutine == target_); 
			});
			if(i_ != null && !displayed.Contains(i_.Id))
			{
				return;
			}
		}

		object target = FindTarget(info);

		string ownerInfo = "";
		if(info.owner != null)
			ownerInfo = " ["+(!info.owner.gameObject.activeInHierarchy ? "[Disabled] ": "")+""+info.owner+" : "+info.watcherCoroutine+"]";
		UnityEngine.Debug.LogError(level+info.Id+" "+info.ownerEnumerator+""+ownerInfo+" ===> "+target+"\n"+info.stackInfo);
		displayed.Add(info.Id);

		if(target != null)
		{
			Info i_ = cs.Find((Info info_) => { return info_.ownerEnumerator == target || info_.watcherCoroutine == target; });
			if(i_ != null)
			{
				DumpCoroutineInfo(i_, cs, displayed, level + "   ");
			}
		}
	}
}
