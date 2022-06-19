using UnityEngine;
using System.Collections.Generic;

namespace XeSys
{
	public class ResourcesInfo
	{
		private ResourceRequest mResReq; // 0x20
		private bool mAsyncMode; // 0x24

		public Object resourceObject { get; private set; } // 0x8
		public string path { get; private set; } // 0xC
		public FileLoadedPostProcess loadedPostProcess { get; set; } // 0x10
		public bool isLoaded { get; private set; } // 0x14
		public Dictionary<string, string> args { get; private set; } // 0x18
		public int argValue { get; private set; } // 0x1C

		// RVA: 0x239AF8C Offset: 0x239AF8C VA: 0x239AF8C
		public ResourcesInfo(string path_, FileLoadedPostProcess loadedPostProcess_)
		{
			resourceObject = null;
			path = path_;
			loadedPostProcess = loadedPostProcess_;
			isLoaded = false;
			args = null;
			argValue = 0;
		}

		// RVA: 0x239AFC8 Offset: 0x239AFC8 VA: 0x239AFC8
		public ResourcesInfo(string path_, FileLoadedPostProcess loadedPostProcess_, Dictionary<string, string> args_, int argValue_)
		{
			resourceObject = null;
			path = path_;
			loadedPostProcess = loadedPostProcess_;
			isLoaded = false;
			args = args_;
			argValue = argValue_;
		}

		// // RVA: 0x239B00C Offset: 0x239B00C VA: 0x239B00C
		public void Load()
		{
			isLoaded = false;
			mAsyncMode = false;
			resourceObject = Resources.Load(path);
		}

		// // RVA: 0x239B038 Offset: 0x239B038 VA: 0x239B038
		public void LoadAsync()
		{
			isLoaded = false;
			mAsyncMode = true;
			mResReq = Resources.LoadAsync(path);
		}

		// // RVA: 0x239B068 Offset: 0x239B068 VA: 0x239B068
		public void Update()
		{
			if(isLoaded)
				return;
			if(mAsyncMode)
			{
				if(!mResReq.isDone)
					return;
				resourceObject = mResReq.asset;
			}
			isLoaded = true;
			CallLoadedPostProcess();
		}

		// // RVA: 0x239B0F0 Offset: 0x239B0F0 VA: 0x239B0F0
		public void CallLoadedPostProcess()
		{
			if(resourceObject != null)
			{
				if(loadedPostProcess != null && isLoaded)
				{
					FileResultObject result = new FileResultObject(path, args, argValue);
					result.unityObject = resourceObject;
					loadedPostProcess(result);
				}
			}
		}
	}
}
