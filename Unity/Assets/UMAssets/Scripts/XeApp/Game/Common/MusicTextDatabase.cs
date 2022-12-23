using System.Text;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class MusicTextDatabase
	{
		public class TextInfo
		{
			public int id; // 0x8
			public string musicName; // 0xC
			public string officialName; // 0x10
			public string vocalName; // 0x14
			public string vocalNameLF; // 0x18
			public string description; // 0x1C
			public string buyURL; // 0x20
			public string storyDesc; // 0x24
			public string storyTitle; // 0x28
			public string bannerId; // 0x2C
			public string dAnmStoreURL; // 0x30

			public bool isEnableBuyURL { get { return !string.IsNullOrEmpty(buyURL); } } //0xAECF24
		}

		private static string s_path = "message_music_jp"; // 0x0
		private List<MusicTextDatabase.TextInfo> table; // 0x8
		public bool isLoading; // 0xC
		private static string buy1 = "buy1"; // 0x4
		private static string buy2 = "buy2"; // 0x8
		private static string vn = "vn"; // 0xC
		private static string vnlf = "vnlf"; // 0x10
		private static string story = "story"; // 0x14
		private static string s_title = "s_title"; // 0x18
		private static string b_id = "b_id"; // 0x1C
		private static string ds_i = "ds_i"; // 0x20
		private static string ds_a = "ds_a"; // 0x24

		// // RVA: 0xAEBAF0 Offset: 0xAEBAF0 VA: 0xAEBAF0
		public MusicTextDatabase.TextInfo Get(int musicNameId)
		{
			if(table.Count <= musicNameId)
				return null;
			return table[musicNameId];
		}

		// // RVA: 0xAEBBAC Offset: 0xAEBBAC VA: 0xAEBBAC
		public void Init(byte[] dataBytes)
		{
			if(BOBCNJIPPJN.AGJJGJCIMKI(dataBytes))
			{
				dataBytes = BOBCNJIPPJN.JCBCBNFPJDH(dataBytes);
			}
			InitFormJSON(dataBytes);
		}

		// // RVA: 0xAEBBFC Offset: 0xAEBBFC VA: 0xAEBBFC
		public void InitFormJSON(byte[] dataByte)
		{
			string txt = Encoding.UTF8.GetString(dataByte);
			EDOHBJAPLPF_JsonData json = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(txt);
			EDOHBJAPLPF_JsonData text = json["text"];
			EDOHBJAPLPF_JsonData infos = json["info"];
			table = new List<MusicTextDatabase.TextInfo>(infos.HNBFOAJIIAL_Count);
			for(int i = 0; i < infos.HNBFOAJIIAL_Count; i++)
			{
				TextInfo textInfo = new TextInfo();
				EDOHBJAPLPF_JsonData info = infos[i];
				textInfo.id = (int)info[AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id/*id*/];
				textInfo.musicName = (string)text[(int)info[AFEHLCGHAEE_Strings.OPFGFINHFCE_name/*name*/]];
				if(info.BBAJPINMOEP_Contains("o_n"))
				{
					textInfo.officialName = (string)text[(int)info["o_n"]];
				}
				else
				{
					textInfo.officialName = textInfo.musicName;
				}
				textInfo.vocalName = (string)text[(int)info[vn]];
				if(info.BBAJPINMOEP_Contains(vnlf))
				{
					textInfo.vocalNameLF = (string)text[(int)info[vnlf]];
				}
				else
				{
					textInfo.vocalNameLF = textInfo.vocalName;
				}
				textInfo.description = (string)text[(int)info[AFEHLCGHAEE_Strings.GJDKHDLKONI_dsc/*dsc*/]];
				textInfo.buyURL = (string)text[(int)info[buy2]];
				string str = (string)text[(int)info[ds_a]].ToString();
				textInfo.dAnmStoreURL = "";
				if(str != "0" && str != "")
				{
					textInfo.dAnmStoreURL = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.JLJEEMEOPLE[str];
				}
				textInfo.storyDesc = (string)text[(int)info[story]];
				textInfo.storyTitle = (string)text[(int)info[s_title]];
				textInfo.bannerId = (string)text[(int)info[b_id]].ToString();
				table.Add(textInfo);
			}
		}

		// // RVA: 0xAEC834 Offset: 0xAEC834 VA: 0xAEC834
		// public void LoadFromResource() { }

		// RVA: 0xAECA5C Offset: 0xAECA5C VA: 0xAECA5C
		public void LoadFromTAR(CBBJHPBGBAJ_Archive tar)
		{
			StringBuilder str = new StringBuilder();
			str.AppendFormat("{0}_{1:D8}.bytes", s_path, 0);
			string name = str.ToString();
			CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File file = tar.KGHAJGGMPKL_Files.Find((CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File x) => {
				//0xAECED8
				return x.OPFGFINHFCE_Name.Contains(name);
			});
			if(file != null)
			{
				Init(file.DBBGALAPFGC_Data);
				isLoading = false;
			}
		}

		// [CompilerGeneratedAttribute] // RVA: 0x73A0FC Offset: 0x73A0FC VA: 0x73A0FC
		// // RVA: 0xAECDF4 Offset: 0xAECDF4 VA: 0xAECDF4
		// private bool <LoadFromResource>b__16_0(FileResultObject fro) { }
	}
}
