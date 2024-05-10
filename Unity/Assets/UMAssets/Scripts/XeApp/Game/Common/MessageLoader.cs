using XeSys;
using System;
using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class MessageLoader : Singleton<MessageLoader>, IDisposable
	{
		public enum InstallSource
		{
			Resource = 0,
			LocalStorage = 1,
		}
		
		public enum eSheet
		{
			common = 0,
			data_ = 1,
			menu = 2,
			master = 3,
			diva001 = 4,
			diva002 = 5,
			diva003 = 6,
			diva004 = 7,
			diva005 = 8,
			diva006 = 9,
			diva007 = 10,
			diva008 = 11,
			diva009 = 12,
			diva010 = 13,
		}

		public static string[] s_path = new string[14] {
			"message_common_jp", "message_data_jp", "message_menu_jp", "message_master_jp", "message_diva001_jp", 
			"message_diva002_jp", "message_diva003_jp", "message_diva004_jp", "message_diva005_jp", "message_diva006_jp",
			"message_diva007_jp", "message_diva008_jp", "message_diva009_jp", "message_diva010_jp"
		}; // 0x8
		private bool m_isLoading; // 0xC
		public MessageLoader.InstallSource defaultInstallSource; // 0x10


		// public bool IsLoading { get; } 0x1115A74

		// // RVA: 0x1115A7C Offset: 0x1115A7C VA: 0x1115A7C
		public void Request(eSheet sheet, int version)
		{
			Release(sheet);
			if(!string.IsNullOrEmpty(RuntimeSettings.CurrentSettings.Language))
			{
				StringBuilder str = new StringBuilder(64);
				str.AppendFormat("Localizations/Database/{0}", RuntimeSettings.CurrentSettings.Language);
				Dictionary<string,string> dic = new Dictionary<string, string>(1);
				dic.Add("sheet", ((int)sheet).ToString());
				dic.Add("bankName", sheet.ToString());
				dic.Add("ver", version.ToString());
				m_isLoading = true;
				ResourcesManager.Instance.Request(str.ToString(), this.LoadCallbackStorage2, dic, 0);
				ResourcesManager.Instance.Load();
			}
			else
			{
				if(defaultInstallSource == InstallSource.LocalStorage)
				{
					string str = BBGDKLLEPIB.OGCDNCDMLCA_MxDir + BBGDKLLEPIB.HHCJCDFCLOB.OCOGBOHOGGE_DbFileName;
					Dictionary<string,string> dic = new Dictionary<string, string>(1);
					dic.Add("sheet", ((int)sheet).ToString());
					dic.Add("bankName", sheet.ToString());
					dic.Add("ver", version.ToString());
					m_isLoading = true;
					IIEDOGCMCIE data = new IIEDOGCMCIE();
					data.MCDJJPAKBLH(str);
					N.a.StartCoroutineWatched(Coroutine_SecureFileLoad(data, sheet, version));
				}
				else
				{
					if(sheet != MessageLoader.eSheet.common && sheet != MessageLoader.eSheet.menu)
					{
						TodoLogger.LogError(TodoLogger.Filesystem, "cant load from resource = "+sheet);
					}
					StringBuilder str = new StringBuilder(64);
					str.AppendFormat("Message/{0}_{1:D8}", s_path[(int)sheet], version);
					m_isLoading = true;
					Dictionary<string, string> dict = new Dictionary<string, string>(1);
					dict.Add("bankName", sheet.ToString());
					ResourcesManager.Instance.Request(str.ToString(), this.LoadCallback, dict, 0);
					ResourcesManager.Instance.Load();
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x739A3C Offset: 0x739A3C VA: 0x739A3C
		// // RVA: 0x1116178 Offset: 0x1116178 VA: 0x1116178
		private IEnumerator Coroutine_SecureFileLoad(IIEDOGCMCIE tar, MessageLoader.eSheet sheet, int version)
		{
			//0x11179A4
			while(!tar.PLOOEECNHFB)
				yield return null;
			StringBuilder str = new StringBuilder(64);
			str.AppendFormat("{0}_{1:D8}.bytes", s_path[(int)sheet], version);
			string name = str.ToString();
			CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File file = tar.KGHAJGGMPKL_Files.Find((CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File x) =>
			{
				//0x1117860
				return x.OPFGFINHFCE_Name.Contains(name);
			});
			if(file != null)
			{
				Release(sheet);
				MessageManager.Instance.RegisterBank(sheet.ToString(), file.DBBGALAPFGC_Data);
			}
			m_isLoading = false;
		}

		// // RVA: 0x111626C Offset: 0x111626C VA: 0x111626C
		// public void Request(string bankName, string fileName) { }

		// // RVA: 0x11166C4 Offset: 0x11166C4 VA: 0x11166C4
		public bool Request(CBBJHPBGBAJ_Archive tar, eSheet sheet, int version)
		{
			if(!string.IsNullOrEmpty(RuntimeSettings.CurrentSettings.Language))
			{
				StringBuilder str = new StringBuilder(64);
				str.AppendFormat("Localizations/Database/{0}", RuntimeSettings.CurrentSettings.Language);
				Dictionary<string,string> dic = new Dictionary<string, string>(1);
				dic.Add("sheet", ((int)sheet).ToString());
				dic.Add("bankName", sheet.ToString());
				dic.Add("ver", version.ToString());
				m_isLoading = true;
				ResourcesManager.Instance.Request(str.ToString(), this.LoadCallbackStorage2, dic, 0);
				ResourcesManager.Instance.Load();
				return true;
			}
			else
			{
				StringBuilder str = new StringBuilder(64);
				str.AppendFormat("{0}_{1:D8}.bytes", s_path[(int)sheet], version);
				string name = str.ToString();
				CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File file = tar.KGHAJGGMPKL_Files.Find((CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File x) => {
					//0x11177C0
					return x.OPFGFINHFCE_Name.Contains(name);
				});
				if(file == null)
					return false;
				Release(sheet);
				MessageManager.Instance.RegisterBank(sheet.ToString(), file.DBBGALAPFGC_Data);
				return true;
			}
		}

		// // RVA: 0x11169AC Offset: 0x11169AC VA: 0x11169AC
		private bool LoadCallback(FileResultObject fro)
		{
			TextAsset text = fro.unityObject as TextAsset;
			MessageManager.Instance.RegisterBank(fro.args["bankName"], text.bytes);
			m_isLoading = false;
			return true;
		}

		// // RVA: 0x1116B24 Offset: 0x1116B24 VA: 0x1116B24
		// private bool LoadCallbackStorage(FileResultObject fro) { }

		// // RVA: 0x1116C38 Offset: 0x1116C38 VA: 0x1116C38
		private bool LoadCallbackStorage2(FileResultObject fro)
		{
			int sheet = int.Parse(fro.args["sheet"]);
			int version = int.Parse(fro.args["ver"]);
			StringBuilder str = new StringBuilder(64);
			str.AppendFormat("{0}_{1:D8}.bytes", s_path[(int)sheet], version);
			string name = str.ToString();
			CBBJHPBGBAJ_Archive tar = new CBBJHPBGBAJ_Archive();
			tar.KHEKNNFCAOI_Load((fro.unityObject as TextAsset).bytes);
			CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File file = tar.KGHAJGGMPKL_Files.Find((CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File x) => {
				//Method$XeApp.Game.Common.MessageLoader.<>c__DisplayClass13_0.<LoadCallbackStorage2>b__0()
				return x.OPFGFINHFCE_Name.Contains(name);
			});
			if(file != null)
			{
				Release((eSheet)sheet);
				MessageManager.Instance.RegisterBank(((eSheet)sheet).ToString(), file.DBBGALAPFGC_Data);
			}
			m_isLoading = false;
			return true;
		}

		// // RVA: 0x1117054 Offset: 0x1117054 VA: 0x1117054 Slot: 4
		public void Dispose()
		{
			return;
		}

		// // RVA: 0x1116088 Offset: 0x1116088 VA: 0x1116088
		public void Release(MessageLoader.eSheet sheet)
		{
			MessageManager.Instance.ReleaseBank(sheet.ToString());
		}

		// // RVA: 0x1117058 Offset: 0x1117058 VA: 0x1117058
		public YieldInstruction WaitForDone(MonoBehaviour mb)
		{
			return mb.StartCoroutineWatched(CheckDone());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x739AB4 Offset: 0x739AB4 VA: 0x739AB4
		// // RVA: 0x1117090 Offset: 0x1117090 VA: 0x1117090
		private IEnumerator CheckDone()
		{
			//0x11178B0
			while(m_isLoading)
				yield return null;
		}

		// // RVA: 0x111713C Offset: 0x111713C VA: 0x111713C
		public static MessageLoader.eSheet DivaIdToSheet(int divaId)
		{
			return (MessageLoader.eSheet)(divaId + 3);
		}
	}
}
