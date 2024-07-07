using System.Collections;
using System;
using System.IO;
using UnityEngine;
using System.Security.Cryptography;
using XeApp.Game.Common;

namespace XeApp.Game.AR
{
	public abstract class ARMasterData
	{
		private const string LIST_NAME = "db";
		private const string DATA_PATH = "/db/{0}.dat";
		private bool m_isReady; // 0x8
		private string m_name = "ar"; // 0xC
		public bool ignoreError; // 0x10
		public float timeoutTime = 6.0f; // 0x14
		private const int RETRY_LIMIT = 1;

		public string name { get { return m_name; } set { m_name = value; } } //0xBBA77C 0xBB6E94

		// // RVA: -1 Offset: -1 Slot: 4
		protected abstract void Initialize(byte[] bytes);

		// RVA: 0xBBA784 Offset: 0xBBA784 VA: 0xBBA784
		public bool IsReady()
		{
			return m_isReady;
		}

		// // RVA: 0xBBA78C Offset: 0xBBA78C VA: 0xBBA78C
		public void StartInstall(IMCBBOAFION onSuccess, DJBHIFLHJLK onError)
		{
			N.a.StartCoroutineWatched(Coroutine_Install(onSuccess, onError));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x741AC4 Offset: 0x741AC4 VA: 0x741AC4
		// // RVA: 0xBBA7E4 Offset: 0xBBA7E4 VA: 0xBBA7E4
		private IEnumerator Coroutine_Install(IMCBBOAFION onSuccess, DJBHIFLHJLK onError)
		{
			// private ARMasterData.<>c__DisplayClass13_0 <>8__1; // 0x14
				// public bool isError; // 0x8
				// public byte[] dataBytes; // 0xC
				// RVA: 0xBBB36C Offset: 0xBBB36C VA: 0xBBB36C
				// internal void <Coroutine_Install>b__0() { }
				// RVA: 0xBBB378 Offset: 0xBBB378 VA: 0xBBB378
				// internal void <Coroutine_Install>b__1(byte[] data) { }
			// public DJBHIFLHJLK onError; // 0x18
			// public IMCBBOAFION onSuccess; // 0x1C
			// private ARMasterData.<>c__DisplayClass13_1 <>8__2; // 0x20
				// public bool done; // 0x8
				// // RVA: 0xBBB388 Offset: 0xBBB388 VA: 0xBBB388
				// internal void <Coroutine_Install>b__2() { }
			// 0xBBBD8C
			m_isReady = false;
			bool isError = false;
			yield return Co.R(Coroutine_Download(() => {
				//0xBBB36C
				isError = true;
			}));
			if(isError)
			{
				if(onError != null)
					onError();
    			TodoLogger.LogError(TodoLogger.Coroutine, "Exit  Error Coroutine_Install");
				yield break;
			}
			
			byte[] dataBytes = null;
			yield return Co.R(Coroutine_LoadTarFile(BBGDKLLEPIB.OGCDNCDMLCA_MxDir + string.Format(DATA_PATH, m_name), (byte[] data) => {
				//0xBBB378
				dataBytes = data;
			} ));

			if(dataBytes != null)
			{
				Initialize(dataBytes);
				if(onSuccess != null)
					onSuccess();
				m_isReady = true;
				yield break;
			}
			if(ignoreError)
			{
				if(onError != null)
					onError();
    			TodoLogger.LogError(TodoLogger.Coroutine, "Exit  Error Coroutine_Install");
				yield break;
			}

			bool done = false;
			
			JHHBAFKMBDL.HHCJCDFCLOB.LIBDGGBAINI(() => {
				//0xBBB388
				done = true;
			});
			while(!done)
				yield return null;

			if(onError != null)
				onError();

    		TodoLogger.LogError(TodoLogger.Coroutine, "Exit  Error Coroutine_Install");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x741B3C Offset: 0x741B3C VA: 0x741B3C
		// // RVA: 0xBBA8C4 Offset: 0xBBA8C4 VA: 0xBBA8C4
		private IEnumerator Coroutine_LoadTarFile(string path, Action<byte[]> onFinished)
		{
			// private byte[] <dataBytes>5__2; // 0x1C
			// private IIEDOGCMCIE <tar>5__3; // 0x20
			//0xBBC28C

			byte[] dataBytes = null;
			IIEDOGCMCIE tar = new IIEDOGCMCIE();
			tar.MCDJJPAKBLH(path);
			while(!tar.PLOOEECNHFB)
			{
				yield return null;
			}
			if(tar.NPNNPNAIONN == false)
			{
				CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File file = tar.KGHAJGGMPKL_Files.Find((CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File _) => {
					//0xBBB2D0
					return _.OPFGFINHFCE_Name.Contains("schema_hash.bytes");
				});
				if(file != null)
				{
					if(ValidateSchemaHash(file.DBBGALAPFGC_Data, m_name))
					{
						CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File db_file = tar.KGHAJGGMPKL_Files.Find((CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File _) => {
							//0xBBB100
							return _.OPFGFINHFCE_Name.Contains(string.Format("{0}.bytes", m_name));
						});
						if(db_file != null)
						{
							dataBytes = db_file.DBBGALAPFGC_Data;
						}
						if(onFinished != null)
						{
							onFinished(dataBytes);
						}
					}
					else
					{
						TodoLogger.LogError(TodoLogger.Coroutine, "Error validating schema");
					}
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x741BB4 Offset: 0x741BB4 VA: 0x741BB4
		// // RVA: 0xBBA9A4 Offset: 0xBBA9A4 VA: 0xBBA9A4
		private IEnumerator Coroutine_Download(DJBHIFLHJLK onError)
		{
			// private ARMasterData.<>c__DisplayClass15_0 <>8__1; // 0x18
				// public string dest; // 0x8
				// public byte[] dataBytes; // 0xC
			// private ARMasterData.<>c__DisplayClass15_1 <>8__2; // 0x1C
				// public bool fin; // 0x8
				// public ARMasterData.<>c__DisplayClass15_0 CS$<>8__locals1; // 0xC
				// // RVA: 0xBBB3A4 Offset: 0xBBB3A4 VA: 0xBBB3A4
				// internal void <Coroutine_Download>b__2() { }
			// private PJKLMCGEJMK <am>5__2; // 0x20
			// private JPAPJLIPNOK <req>5__3; // 0x24
			// private string <src>5__4; // 0x28
			// private bool <loop>5__5; // 0x2C
			// private int <retryCount>5__6; // 0x30
			// private WWW <www>5__7; // 0x34
			// private float <endTime>5__8; // 0x38
			// 0xBBB400

			PJKLMCGEJMK am = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester;
			JPAPJLIPNOK_RequestAssetList req = am.IFFNCAFNEAG_AddRequest<JPAPJLIPNOK_RequestAssetList>(new JPAPJLIPNOK_RequestAssetList());
			req.FPCIBJLJOFI_Type = "db";

			if(ignoreError)
			{
				req.AILPHBMCCGP = true;
				req.NBFDEFGFLPJ = (SakashoErrorId e) => {
					//0xBBB35C
					return true;
				};
			}
			yield return req.GDPDELLNOBO_WaitDone(N.a);

			if(req.NPNNPNAIONN_IsError)
			{
				if(onError != null)
					onError();
    			TodoLogger.LogError(TodoLogger.Coroutine, "Exit  Error Coroutine_Download");
				yield break;
			}

			GCGNICILKLD_AssetFileInfo found = req.NFEAMMJIMPG.KGHAJGGMPKL_Files.Find((GCGNICILKLD_AssetFileInfo _) => {
				// 0xBBB1A4
				return _.OIEAICNAMNB_LocalFileName.Contains(string.Format("/db/{0}.dat", m_name));
			});
			if(found == null)
			{
    			TodoLogger.LogError(TodoLogger.Coroutine, "Exit  Error Coroutine_Download");
				yield break;
			}

			string dest = FileSystemProxy.ConvertPath(BBGDKLLEPIB.OGCDNCDMLCA_MxDir + found.OIEAICNAMNB_LocalFileName);

			string dir = Path.GetDirectoryName(dest);
			if(!Directory.Exists(dir))
			{
				Directory.CreateDirectory(dir);
			}
			byte[] dataBytes = null;
			while(true)
			{
				if(File.Exists(dest))
				{
					if(CalcMD5(dest) == found.POEGMFKLFJG_Hash)
					{
						TodoLogger.Log(TodoLogger.Filesystem, "File match, don't dld");
						yield break;
					}
				}
#if UNITY_ANDROID || DEBUG_ANDROID_FILESYSTEM
				bool retry = false;
				yield return Co.R(FileSystemProxy.WaitServerInfo("Missing file :\n"+dest, true, true, (PopupButton.ButtonLabel btn) =>
				{
					if(btn == PopupButton.ButtonLabel.Retry)
						retry = true;
				}));
				if(retry)
					continue;
#endif
				string src = FileSystemProxy.ConvertURL(req.NFEAMMJIMPG.GLMGHMCOMEC_BaseUrl + found.MFBMBPJAADA_FileName);
				TodoLogger.Log(TodoLogger.Filesystem, "Dld from " + src+" to "+dest);

				int retryCount = 0;
				bool loop = true;
				while(loop)
				{
					WWW www = new WWW(src);
					float endTime = Time.realtimeSinceStartup + timeoutTime;
					//LAB_00bbba10:
					while(!www.isDone)
					{
						if(Time.realtimeSinceStartup < endTime)
						{
							yield return null;
						}
						else
						{
							break;
						}
					}
					if(www.isDone)
					{
						if(www.error == null)
						{
							dataBytes = www.bytes;
							break;
						}
					}
					retryCount = retryCount + 1;
#if UNITY_ANDROID || DEBUG_ANDROID_FILESYSTEM
					break;
#else
					if(retryCount > 1)
					{
						if(onError != null)
						{
							onError();
						}
						www = null;
						TodoLogger.LogError(TodoLogger.Coroutine, "Exit  Error Coroutine_Download");
						yield break;
					}
#endif
				}
				if(dataBytes != null)
				{
					bool fin = false;
					am.BNJPAKLNOPA_WorkerThreadQueue.Add(() => {
						//0xBBB3A4
						TodoLogger.Log(TodoLogger.Filesystem, "Write file " + dest);
						File.WriteAllBytes(dest, dataBytes);
						fin = true;
					});
					while(!fin)
						yield return null;
				}
				src = null;
#if UNITY_ANDROID || DEBUG_ANDROID_FILESYSTEM
#else
				break;
#endif
			}
		}

		// // RVA: 0xBBAA6C Offset: 0xBBAA6C VA: 0xBBAA6C
		private string CalcMD5(string path)
		{
			MD5 md5 = MD5.Create();
			FileStream f = File.OpenRead(path);
			byte[] hash = md5.ComputeHash(f);
			string res = "";
			for(int i = 0; i < hash.Length; i++)
			{
				res += string.Format("{0:x2}", (byte)hash[i]);
			}
			if(f != null)
			{
				f.Dispose();
			}
			return res;
		}

		// // RVA: 0xBBADA4 Offset: 0xBBADA4 VA: 0xBBADA4
		private bool ValidateSchemaHash(byte[] hashBytes, string name)
		{
			BNBONBECPKB b = BNBONBECPKB.HEGEKFMJNCC(hashBytes);
			LPMLJGGJGGK[] l = b.GMLFFMJMPCC;
			for(int i = 0; i < l.Length; i++)
			{
				if(l[i].OPFGFINHFCE == name)
				{
					for(int j = 0; j < LIGPJAIDNOA.MHDFCBBFMOA.Length; j++)
					{
						if(LIGPJAIDNOA.MHDFCBBFMOA[j] == name)
						{
							if(LIGPJAIDNOA.INPAHCHFIHM[j] == l[i].IOIMHJAOKOO)
								return true;
							else
								return false;
						}
					}
				}
			}
			return false;
		}
	}
}
