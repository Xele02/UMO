using System;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeSys;

namespace XeApp.Game.Adv
{
	public class AdvScriptData
	{
		private NCFKBGFDBAG adv_script; // 0x8
		public bool isReady; // 0xC
		private int fileHash; // 0x10
		public GPCOJNLJJLE[] listEntry; // 0x14

		//// RVA: 0xE52244 Offset: 0xE52244 VA: 0xE52244
		//public int GetMessageCount() { }

		//// RVA: 0xE58220 Offset: 0xE58220 VA: 0xE58220
		//public int GetMessageId(int index) { }

		//// RVA: 0xE51FF8 Offset: 0xE51FF8 VA: 0xE51FF8
		public string GetMessage(int index)
		{
			return listEntry[index].IPBHCLIHAPG;
		}

		//// RVA: 0xE51F18 Offset: 0xE51F18 VA: 0xE51F18
		public int GetSpeakerId(int index)
		{
			return listEntry[index].PMJAGEJIOJE;
		}

		//// RVA: 0xE51F7C Offset: 0xE51F7C VA: 0xE51F7C
		public int GetCommandCount(int index)
		{
			return listEntry[index].PBOHDAFOEIA.Length;
		}

		//// RVA: 0xE58284 Offset: 0xE58284 VA: 0xE58284
		public AdvScriptCommand.Label GetCommandLabel(int index, int i)
		{
			if (listEntry[index].PBOHDAFOEIA.Length <= i)
				return AdvScriptCommand.Label.Nop;
			return (AdvScriptCommand.Label)listEntry[index].PBOHDAFOEIA[i].KAPMOPMDHJE;
		}

		//// RVA: 0xE583C0 Offset: 0xE583C0 VA: 0xE583C0
		public int GetCommandParam(int index, int i, int j)
		{
			if(i < listEntry[index].PBOHDAFOEIA.Length)
			{
				if(j < listEntry[index].PBOHDAFOEIA[i].PIBLLGLCJEO.Length)
				{
					int res = 0;
					if (int.TryParse(listEntry[index].PBOHDAFOEIA[i].PIBLLGLCJEO[j], out res))
					{
						return res;
					}
				}
			}
			return 0;
		}

		//// RVA: 0xE58634 Offset: 0xE58634 VA: 0xE58634
		public string GetStringCommandParam(int index, int i, int j)
		{
			if (i < listEntry[index].PBOHDAFOEIA.Length)
			{
				if (j < listEntry[index].PBOHDAFOEIA[i].PIBLLGLCJEO.Length)
				{
					return listEntry[index].PBOHDAFOEIA[i].PIBLLGLCJEO[j];
				}
			}
			return "";
		}

		//// RVA: 0xE588CC Offset: 0xE588CC VA: 0xE588CC
		public void Init(byte[] bytes)
		{
			adv_script = NCFKBGFDBAG.HEGEKFMJNCC(bytes);
			listEntry = adv_script.HEHPAMADHGC;
			isReady = true;
		}

		//// RVA: 0xE58918 Offset: 0xE58918 VA: 0xE58918
		public void TryInstall(int id)
		{
			if(!AssetBundleManager.isTutorialNow)
			{
				StringBuilder str = new StringBuilder(64);
				str.Append("adv/");
				str.AppendFormat("{0:D6}.dat", id);
				KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(str.ToString());
			}
		}

		//// RVA: 0xE51A5C Offset: 0xE51A5C VA: 0xE51A5C
		public void Load(int id, Action onFinish)
		{
			isReady = false;
			TryInstall(id);
			StringBuilder str = new StringBuilder(64);
			if (!AssetBundleManager.isTutorialNow)
				str.Append(KEHOJEJMGLJ.CGAHFOBGHIM_PersistentPlatformDataPath);
			else
			{
				str.Append(Application.streamingAssetsPath);
				str.Append("/android");
			}
			str.Append("/adv/");
			str.AppendFormat("{0:D6}.dat", id);
			StringBuilder str2 = new StringBuilder(64);
			str2.AppendFormat("adv/{0:D6}.dat", id);
			string withoutPath = str2.ToString();
			fileHash = 0;
			fileHash = FileLoader.Instance.Request(str.ToString(), withoutPath, (FileResultObject fro) =>
			{
				//0xE58BE8
				CBBJHPBGBAJ_Archive c = new CBBJHPBGBAJ_Archive();
				c.KHEKNNFCAOI_Load(fro.bytes);
				CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File f = c.KGHAJGGMPKL_Files.Find((CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File x) =>
				{
					//0xE58B5C
					return x.OPFGFINHFCE_Name.Contains("adv_script");
				});
				if(f != null)
				{
					Init(f.DBBGALAPFGC_Data);
				}
				if (onFinish != null)
					onFinish();
				return true;
			}, null, 0, true);
			FileLoader.Instance.Load();
		}

		//// RVA: 0xE51E7C Offset: 0xE51E7C VA: 0xE51E7C
		public void UnLoad()
		{
			if (fileHash == 0)
				return;
			FileLoader.Instance.Unload(fileHash);
			fileHash = 0;
		}
	}
}
