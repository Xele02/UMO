using UnityEngine;
using System.Collections;
using XeSys;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif

public static class MonoBehaviourExtensions
{
    public static Coroutine StartCoroutineWatched(this MonoBehaviour owner, IEnumerator enumerator)
    {
		if(false)
		{
			return owner.StartCoroutine(enumerator);
		}
		else
		{
			Coroutine c_ = owner.StartCoroutine(enumerator);
			if(c_ == null)
			{
				// Coroutine immediately endend, return;
				return null;
			}
			IEnumerator s = CoroutineWatcher.Instance.Run(owner, enumerator, c_);
			Coroutine c = CoroutineWatcher.Instance.StartCoroutine(s);
			CoroutineWatcher.Instance.SetWatcherInfo(enumerator, s, c, CoroutineWatcher.Instance);
			return c;
		}
	}
	public static void StopCoroutineWatched(this MonoBehaviour owner, IEnumerator enumerator)
	{
		if(false)
		{
			owner.StopCoroutine(enumerator);
		}
		else
		{
			CoroutineWatcher.Instance.Stop(owner, enumerator);
		}
	}
	public static void StopCoroutineWatched(this MonoBehaviour owner, Coroutine coroutine)
	{
		if(false)
		{
			owner.StopCoroutine(coroutine);
		}
		else
		{
			CoroutineWatcher.Instance.Stop(owner, coroutine);
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
        yield return CoroutineWatcher.Instance.Run(null, e);
    }
}

public class CoroutineWatcher : SingletonMonoBehaviour<CoroutineWatcher>
{
    public class Info
    {
        public Coroutine watcherCoroutine;
		public IEnumerator watcherEnumerator;
		public MonoBehaviour watcherBehaviour;
		public bool hasWatcherCoroutine = false;
        public IEnumerator originalEnumerator;
		public Coroutine originalCoroutine;
		public MonoBehaviour originalBehaviour;
		public System.Diagnostics.StackTrace stackInfo;
		public int Id;
    }

    public List<Info> coroutines = new List<Info>();

    public bool GetStackTrace = false;

	static int cntRun = 0;
    public IEnumerator Run(MonoBehaviour originalBehaviour, IEnumerator originalEnumerator_, Coroutine originalCoroutine_ = null)
    {
        Info i = new Info();
        if(GetStackTrace)
            i.stackInfo = new System.Diagnostics.StackTrace(true);
        i.originalEnumerator = originalEnumerator_;
		i.originalCoroutine = originalCoroutine_;
		i.originalBehaviour = originalBehaviour;
		i.Id = cntRun++;
        TodoLogger.Log(998, ""+i.Id+" Begin "+originalEnumerator_);
        coroutines.Add(i);
		if(originalCoroutine_ != null)
			yield return originalCoroutine_;
		else
        	yield return originalEnumerator_;
        TodoLogger.Log(998, ""+i.Id+" End "+originalEnumerator_);
        coroutines.Remove(i);
    }

	public void StopAll(MonoBehaviour owner)
	{
		List<Info> infos = coroutines.FindAll((Info info_) =>
		{
			return info_.originalBehaviour == owner;
		});
		for(int i = 0; i < infos.Count; i++)
		{
			Stop(owner, infos[i]);
		}
	}
	public void Stop(MonoBehaviour owner, IEnumerator e)
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
				return info_.originalEnumerator == e;
			});
		}
		if (i_ != null)
		{
			Stop(owner, i_);
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

	public void Stop(MonoBehaviour owner, Coroutine c)
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
				return info_.originalCoroutine == c;
			});
		}
		if (i_ != null)
		{
			Stop(owner, i_);
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

	public void Stop(MonoBehaviour owner, Info i_)
	{
		if (RuntimeSettings.CurrentSettings.EnableDebugStopCoroutine)
		{
			if(owner != i_.originalBehaviour)
			{
				UnityEngine.Debug.LogError("Behaviour differs : "+owner.name+" "+i_.originalBehaviour.name);
			}
		}
		if (i_.originalCoroutine != null)
			owner.StopCoroutine(i_.originalCoroutine);
		else if (i_.originalEnumerator != null)
			owner.StopCoroutine(i_.originalEnumerator);
		if(i_.hasWatcherCoroutine)
			i_.watcherBehaviour.StopCoroutine(i_.watcherCoroutine);
		else if(i_.watcherEnumerator != null)
			i_.watcherBehaviour.StopCoroutine(i_.watcherEnumerator);
		coroutines.Remove(i_);
	}

	public void SetWatcherInfo(IEnumerator originalEnumerator_, IEnumerator watcherEnum, Coroutine watcherCoroutine_, MonoBehaviour watcherBehaviour_)
	{
		Info info = coroutines.Find((Info _) =>
		{
			return _.originalEnumerator == originalEnumerator_;
		});
		if(info != null)
		{
			info.watcherEnumerator = watcherEnum;
			info.watcherCoroutine = watcherCoroutine_;
			info.hasWatcherCoroutine = watcherCoroutine_ != null;
			info.watcherBehaviour = watcherBehaviour_;
		}
	}

	public Coroutine FindOriginalCoroutineFromWatcher(IEnumerator e)
	{
		Info info = coroutines.Find((Info _) =>
		{
			return _.watcherEnumerator == e;
		});
		if (info != null)
			return info.originalCoroutine;
		return null;
	}
	public Coroutine FindOriginalCoroutineFromWatcher(Coroutine c)
	{
		Info info = coroutines.Find((Info _) =>
		{
			return _.watcherCoroutine == c;
		});
		if (info != null)
			return info.originalCoroutine;
		return null;
	}

	public void Update()
	{
        List<Info> cs = Instance.coroutines;
		for (int i = cs.Count - 1; i >= 0; i--)
		{
			if((cs[i].hasWatcherCoroutine && (cs[i].originalBehaviour == null || !cs[i].originalBehaviour.gameObject.activeInHierarchy || cs[i].watcherCoroutine == null)))
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
		object target = info.originalEnumerator.Current;
		IEnumerator waiting = info.originalEnumerator.Current as IEnumerator;
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
				return target_ != null && (target_ == info.originalEnumerator || info.watcherCoroutine == target_); 
			});
			if(i_ != null && !displayed.Contains(i_.Id))
			{
				return;
			}
		}

		object target = FindTarget(info);

		string ownerInfo = "";
		if(info.originalBehaviour != null)
			ownerInfo = " ["+(!info.originalBehaviour.gameObject.activeInHierarchy ? "[Disabled] ": "")+""+info.originalBehaviour+" : "+info.watcherCoroutine+"]";
		UnityEngine.Debug.LogError(level+info.Id+" "+info.originalEnumerator+""+ownerInfo+" ===> "+target+"\n"+info.stackInfo);
		displayed.Add(info.Id);

		if(target != null)
		{
			Info i_ = cs.Find((Info info_) => { return info_.originalEnumerator == target || info_.watcherCoroutine == target; });
			if(i_ != null)
			{
				DumpCoroutineInfo(i_, cs, displayed, level + "   ");
			}
		}
	}
}
