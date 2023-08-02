using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

namespace XeSys
{
	public class ResourcesManager : SingletonMonoBehaviour<ResourcesManager>, ILoader
	{
		[Tooltip("")] // RVA: 0x6530EC Offset: 0x6530EC VA: 0x6530EC
		[Range(1, 250)]
		[SerializeField]
		private int concurrentLimit = 50; // 0x1C
		private IEnumerator m_delayLoad; // 0x20

		private List<ResourcesInfo> requestList { get; set; } // 0xC
		private List<ResourcesInfo> loadingList { get; set; } // 0x10
		private List<ResourcesInfo> loadedEraseList { get; set; } // 0x14
		private bool callUnload { get; set; } // 0x18
		public bool isUnloaded { get; set; } // 0x19
		public bool isLoading { get; set; } // 0x1A
		public int loadingCount { get { return loadingList.Count; } } // get_loadingCount 0x239B288

		// // RVA: 0x239B300 Offset: 0x239B300 VA: 0x239B300
		private void Awake()
		{
			requestList = new List<ResourcesInfo>(64);
			loadingList = new List<ResourcesInfo>(64);
			loadedEraseList = new List<ResourcesInfo>(64);
			isLoading = false;
			callUnload = false;
			isUnloaded = false;
		}

		// // RVA: 0x239B3C8 Offset: 0x239B3C8 VA: 0x239B3C8
		private void Update()
		{
			if(isLoading && m_delayLoad != null)
			{
				if(!m_delayLoad.MoveNext())
					m_delayLoad = null;
			}
		}

		// // RVA: 0x239B4AC Offset: 0x239B4AC VA: 0x239B4AC
		private void EraseInfo(ResourcesInfo info)
		{
			loadingList.Remove(info);
		}

		// // RVA: 0x239B52C Offset: 0x239B52C VA: 0x239B52C
		private void UpdateInfo(ResourcesInfo info)
		{
			info.Update();
			if(!info.isLoaded)
				return;
			loadedEraseList.Add(info);
		}

		// // RVA: 0x239B5E4 Offset: 0x239B5E4 VA: 0x239B5E4
		public void Initialize()
		{
			SystemManager.Instance.AddToSystemGroup(gameObject);
		}

		// // RVA: 0x239B860 Offset: 0x239B860 VA: 0x239B860
		public void Request(string path, FileLoadedPostProcess callback)
		{
			Request(path, callback, null, 0);
		}

		// // RVA: 0x239B884 Offset: 0x239B884 VA: 0x239B884
		public void Request(string path, FileLoadedPostProcess callback, Dictionary<string, string> args, int argValue)
		{
			string newPath = ConvertResourcesPath(path);
			ResourcesInfo ri = new ResourcesInfo(path, callback, args, argValue);
			requestList.Add(ri);
		}

		// // RVA: 0x239BA2C Offset: 0x239BA2C VA: 0x239BA2C
		public void Load()
		{
			isLoading = true;
			if(m_delayLoad != null)
				return;
			m_delayLoad = DelayLoad();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x69171C Offset: 0x69171C VA: 0x69171C
		// // RVA: 0x239BA5C Offset: 0x239BA5C VA: 0x239BA5C
		private IEnumerator DelayLoad()
		{
			//0x239BE54
			while(true)
			{
				int countToDo = System.Math.Min(requestList.Count, concurrentLimit - loadingList.Count);
				if(countToDo > 0)
				{
					for(int i = 0; i < countToDo; i++)
					{
						Load(requestList[i]);
					}
					requestList.RemoveRange(0, countToDo);
				}
				for(int i = 0; i < loadingList.Count; i++)
				{
					UpdateInfo(loadingList[i]);
				}
				if(loadedEraseList.Count > 0)
				{
					for(int i = 0; i < loadedEraseList.Count; i++)
					{
						EraseInfo(loadedEraseList[i]);
					}
					loadedEraseList.Clear();
				}
				int remain = requestList.Count;
				if(remain == 0)
					remain = loadingList.Count;
				if(remain == 0)
					break;
				yield return null;
			}
			isLoading = false;

		}

		// // RVA: 0x239BB08 Offset: 0x239BB08 VA: 0x239BB08
		private void Load(ResourcesInfo info)
		{
			info.LoadAsync();
			loadingList.Add(info);
		}

		// // RVA: 0x239BBB8 Offset: 0x239BBB8 VA: 0x239BBB8 Slot: 4
		public int Load(string path, FileLoadedPostProcess callback)
		{
			Load(path, callback, null, 0);
			return 0;
		}

		// // RVA: 0x239BBE0 Offset: 0x239BBE0 VA: 0x239BBE0 Slot: 5
		public int Load(string path, FileLoadedPostProcess callback, Dictionary<string, string> args, int argValue)
		{
			Request(path, callback, args, argValue);
			isLoading = true;
			if(m_delayLoad == null)
			{
				m_delayLoad = DelayLoad();
			}
			return 0;
		}

		// // RVA: 0x239BC2C Offset: 0x239BC2C VA: 0x239BC2C
		// public void Unload(Object obj) { }

		// // RVA: 0x239BC38 Offset: 0x239BC38 VA: 0x239BC38
		// public void UnloadUnusedAssets() { }

		// [IteratorStateMachineAttribute] // RVA: 0x691794 Offset: 0x691794 VA: 0x691794
		// // RVA: 0x239BD0C Offset: 0x239BD0C VA: 0x239BD0C
		// private IEnumerator Unload() { }

		// // RVA: 0x239B960 Offset: 0x239B960 VA: 0x239B960
		private string ConvertResourcesPath(string path)
		{
			string ext = Path.GetExtension(path);
			if(!string.IsNullOrEmpty(ext))
			{
				return path.Replace(ext, "");
			}
			return path;
		}
	}
}
