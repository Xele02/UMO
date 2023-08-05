using System.Collections.Generic;
using System;
using XeSys;
using XeSys.File;
using CriWare;

namespace XeSys
{
	public delegate BEEINMBNKNM_Encryption FindDecryptor(string path);

	public class FileLoader : Singleton<FileLoader>, IDisposable, ILoader
	{
		private const int FILE_REQUEST_QUEUE_ID = 0;
		public FindDecryptor findDecryptor; // 0x24

		public bool isLoading { get; set; } // 0x8
		public string bytesExtention { get; set; } // 0xC
		public string textureExtention { get; set; } // 0x10
		public string assetBundleExtention { get; set; } // 0x14
		public string secureExtention { get; set; } // 0x18
		public string cpkExtention { get; set; } // 0x1C
		public CriFsBinder binder { get; set; } // 0x20
		private Dictionary<int, FileLoadInfo> fileLoadedDic { get; set; } // 0x28
		private Dictionary<int, FileLoadInfo> fileLoadingDic { get; set; } // 0x2C

		// // RVA: 0x203AB14 Offset: 0x203AB14 VA: 0x203AB14
		public FileLoader()
		{
			fileLoadedDic = new Dictionary<int, FileLoadInfo>();
			fileLoadingDic = new Dictionary<int, FileLoadInfo>();
			bytesExtention = ".bytes";
			textureExtention = ".png";
			assetBundleExtention = ".xab";
			isLoading = false;
			secureExtention = ".dat";
			cpkExtention = ".cpk";
		}

		// // RVA: 0x203AC38 Offset: 0x203AC38 VA: 0x203AC38 Slot: 4
		public void Dispose()
		{
			TodoLogger.LogError(0, "TODO");
		}

		// // RVA: 0x203AD10 Offset: 0x203AD10 VA: 0x203AD10
		public void Update()
		{
			if(!isLoading)
				return;
			
			isLoading = CriFileRequestManager.HHCJCDFCLOB.NFABHMNAODN == CriFileRequestManager.IFDILJEGCLD.IADCGKMLFFE_Execute;
		}

		// // RVA: 0x203ADA0 Offset: 0x203ADA0 VA: 0x203ADA0
		// public void UnloadAll() { }

		// // RVA: 0x203B05C Offset: 0x203B05C VA: 0x203B05C
		// public bool Unload(string path) { }

		// // RVA: 0x203AF2C Offset: 0x203AF2C VA: 0x203AF2C
		public bool Unload(int pathHashCode)
		{
			if(!fileLoadedDic.ContainsKey(pathHashCode))
				return false;
			fileLoadedDic[pathHashCode].request.JNDNHPEIMEI();
			fileLoadedDic.Remove(pathHashCode);
			return true;
		}

		// // RVA: 0x203B0A0 Offset: 0x203B0A0 VA: 0x203B0A0
		// public int Request(string path, string withoutPlarformPath, FileLoadedPostProcess succeeded) { }

		// // RVA: 0x203B0CC Offset: 0x203B0CC VA: 0x203B0CC
		public int Request(string path, string withoutPlarformPath, FileLoadedPostProcess succeeded, Dictionary<string, string> args, int argValue, bool loadedDispose)
		{
			return Request(path, withoutPlarformPath, succeeded, null, args, argValue, loadedDispose);
		}

		// // RVA: 0x203B3C4 Offset: 0x203B3C4 VA: 0x203B3C4
		public int Request(string path, string withoutPlarformPath, FileLoadedPostProcess succeeded, Dictionary<string, string> args, int argValue)
		{
			return Request(path, withoutPlarformPath, succeeded, null, args, argValue, false);
		}

		// // RVA: 0x203B0FC Offset: 0x203B0FC VA: 0x203B0FC
		public int Request(string path, string withoutPlarformPath, FileLoadedPostProcess succeeded, FileLoadedPostProcess failed, Dictionary<string, string> args, int argValue, bool loadedDispose)
		{
			TodoLogger.Log(TodoLogger.Filesystem, "Request file "+path);
			FileLoadInfo item = null;
			int hash = path.GetHashCode();
			if(fileLoadedDic.ContainsKey(hash))
			{
				item = fileLoadedDic[hash];
			}
			else
			{
				if(fileLoadingDic.ContainsKey(hash))
				{
					item = fileLoadingDic[hash];
					if(!item.request.PHOPDCNFFEI)
					{
						return item.pathHashCode;
					}
				}
			}
			LBHFILLFAGA request = CreateFileRequest(path, withoutPlarformPath, args, argValue, item, loadedDispose);
			CriFileRequestManager.HHCJCDFCLOB.ELFMKCOKNHK_AddRequest(request);
			if(item == null)
			{
				item = new FileLoadInfo(path, succeeded, failed, request);
			}
			fileLoadingDic.Add(hash, item);
			return item.pathHashCode;
		}

		// // RVA: 0x203B904 Offset: 0x203B904 VA: 0x203B904
		public void Load()
		{
			isLoading = true;
			CriFileRequestManager.HHCJCDFCLOB.LFBFKKKCMNM_TryExecute();
		}

		// // RVA: 0x203B980 Offset: 0x203B980 VA: 0x203B980
		// public int Load(string path, string withoutPlarformPath, FileLoadedPostProcess callback) { }

		// // RVA: 0x203B9C4 Offset: 0x203B9C4 VA: 0x203B9C4
		// public int Load(string path, string withoutPlarformPath, FileLoadedPostProcess callback, Dictionary<string, string> args, int argValue) { }

		// // RVA: 0x203BA0C Offset: 0x203BA0C VA: 0x203BA0C Slot: 5
		public int Load(string path, FileLoadedPostProcess callback)
		{
			TodoLogger.LogError(0, "TODO");
			return -1;
		}

		// // RVA: 0x203BA14 Offset: 0x203BA14 VA: 0x203BA14 Slot: 6
		public int Load(string path, FileLoadedPostProcess callback, Dictionary<string, string> args, int argValue)
		{
			TodoLogger.LogError(0, "TODO");
			return -1;
		}

		// // RVA: 0x203BA1C Offset: 0x203BA1C VA: 0x203BA1C
		// public void Cancel() { }

		// // RVA: 0x203BB00 Offset: 0x203BB00 VA: 0x203BB00
		private bool FailedCallback(FileResultObject fro)
		{
			TodoLogger.LogError(0, "Failed to load "+fro.path);
			return false;
		}

		// // RVA: 0x203BC10 Offset: 0x203BC10 VA: 0x203BC10
		private bool FileLoadedCallback(FileResultObject fro)
		{
			FileLoadInfo info = fileLoadingDic[fro.pathHashCode];
			fileLoadingDic.Remove(fro.pathHashCode);
			if(!info.Succeeded(fro))
				return false;
			if(!fro.dispose)
			{
				if(!fileLoadedDic.ContainsKey(fro.pathHashCode))
				{
					fileLoadedDic.Add(fro.pathHashCode, info);
				}
			}
			else
			{
				info.request.PEFNBFCMIBL();
			}
			return true;
		}

		// // RVA: 0x203B3F0 Offset: 0x203B3F0 VA: 0x203B3F0
		private LBHFILLFAGA CreateFileRequest(string path, string withoutPlarformPath, Dictionary<string, string> args, int argValue, FileLoadInfo fi, bool loadedDispose)
		{
			CriFsBinder binder_ = null;
			LBHFILLFAGA request = null;
			if(path.Contains(textureExtention))
			{
				request = new HMHBDNGJIGL(path, withoutPlarformPath, this.FileLoadedCallback, this.FailedCallback, args, argValue, fi, loadedDispose);
			}
			else if(path.Contains(cpkExtention))
			{
				request = new PLKCJJECNCK(path, withoutPlarformPath, this.FileLoadedCallback, this.FailedCallback, args, argValue, fi, loadedDispose);
				if(binder == null)
					binder = new CriFsBinder();
				binder_ = binder;
			}
			else if(path.Contains(assetBundleExtention))
			{
				request = new BDFPCPHIJCN(path, withoutPlarformPath, this.FileLoadedCallback, this.FailedCallback, args, argValue, fi, loadedDispose);
			}
			else if(path.Contains(secureExtention))
			{
				request = new IPGPAGNBBIK(path, withoutPlarformPath, this.FileLoadedCallback, this.FailedCallback, args, argValue, fi, loadedDispose);
			}
			else
			{
				request = new PFHMOOFJMIM(path, withoutPlarformPath, this.FileLoadedCallback, this.FailedCallback, args, argValue, fi, loadedDispose);
			}
			request.COIBJNACMFK = binder_;
			if(findDecryptor != null)
			{
				request.DMKAFCEJFDG_decryptor = findDecryptor(path);
			}
			return request;
		}

		// // RVA: 0x203C61C Offset: 0x203C61C VA: 0x203C61C
		// public void DebugLogLoadedList() { }
	}
}
