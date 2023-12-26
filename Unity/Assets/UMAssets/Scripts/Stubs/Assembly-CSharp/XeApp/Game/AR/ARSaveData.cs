using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using XeSys;

namespace XeApp.Game.AR
{
	public class ARSaveData
	{
		private class StampData
		{
			public string markerId = ""; // 0x8
			public int haveFlag; // 0xC
		}

		private static ARSaveData sm_instance; // 0x0
		private const string KEY = "4hLrGAmYTFVtRcdbdZ9hnNnS6K5BeJVb";
		private const string IV = "9UaVcc4VStBWZLtj";
		private const string DIR_PATH = "/SaveData/";
		private const string FILE_NAME = "arsd.bin";
		private const int xor = 215;
		private bool isShowHelp = true; // 0x8
		private List<string> helpFlagList = new List<string>(); // 0xC
		private List<StampData> stampList = new List<StampData>(); // 0x10
		private Rijndael rijndale; // 0x14

		public static ARSaveData Instance { get
		{
			if(sm_instance == null)
			{
				sm_instance = new ARSaveData();
				sm_instance.Init();
			}
			return sm_instance;
		} } //0xBBC678

		// RVA: 0xBBC7D0 Offset: 0xBBC7D0 VA: 0xBBC7D0
		private ARSaveData()
		{
			//
		}

		// // RVA: 0xBBCA3C Offset: 0xBBCA3C VA: 0xBBCA3C
		// public void RemoveSaveFile() { }

		// RVA: 0xBBCAC4 Offset: 0xBBCAC4 VA: 0xBBCAC4
		private void Reset()
		{
			isShowHelp = true;
			helpFlagList.Clear();
			stampList.Clear();
		}

		// // RVA: 0xBBC898 Offset: 0xBBC898 VA: 0xBBC898
		public void Init()
		{
			rijndale = new RijndaelManaged();
			byte[] k, iv;
			GenerateKey("4hLrGAmYTFVtRcdbdZ9hnNnS6K5BeJVb", "9UaVcc4VStBWZLtj", rijndale.KeySize, out k, rijndale.BlockSize, out iv);
			rijndale.Key = k;
			rijndale.IV = iv;
			Load();
		}

		// // RVA: 0xBBCB70 Offset: 0xBBCB70 VA: 0xBBCB70
		private static void GenerateKey(string password, string salt, int keySize, out byte[] key, int blockSize, out byte[] iv)
		{
			if(salt.Length < 8)
			{
				throw new Exception("CipherRijndale.GenerateKeyFromPassword : salt is less than 8byte.");
			}
			Rfc2898DeriveBytes s = new Rfc2898DeriveBytes(password, Encoding.UTF8.GetBytes(salt));
			s.IterationCount = 52;
			key = s.GetBytes(keySize);
			iv = s.GetBytes(blockSize);
		}

		// // RVA: 0xBBCD40 Offset: 0xBBCD40 VA: 0xBBCD40
		public bool Load()
		{
			Reset();
			string p = Application.persistentDataPath + "/SaveData/arsd.bin";
			if(File.Exists(p))
			{
				byte[] bs = File.ReadAllBytes(p);
				ICryptoTransform t = rijndale.CreateDecryptor();
				byte[] bs2 = t.TransformFinalBlock(bs, 0, bs.Length);
				if(bs2 != null)
				{
					for(int i = 0; i < bs2.Length; i++)
					{
						bs2[i] ^= 215;
					}
					string str = Encoding.UTF8.GetString(bs2);
					EDOHBJAPLPF_JsonData json = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(str);
					isShowHelp = CEDHHAGBIBA.GNJBKANDLEE_ReadInt(json, "isShowHelp") != 0;
					EDOHBJAPLPF_JsonData json2 = json["StampData"];
					if(json2 != null && json2.EPNGJLOKGIF_IsArray)
					{
						for(int i = 0; i < json2.HNBFOAJIIAL_Count; i++)
						{
							StampData data = new StampData();
							data.markerId = CEDHHAGBIBA.BNCLNFJHEND_ReadString(json2[i], "markerId");
							data.haveFlag = CEDHHAGBIBA.GNJBKANDLEE_ReadInt(json2[i], "haveFlag");
							stampList.Add(data);
						}
					}
					helpFlagList.Clear();
					string s = CEDHHAGBIBA.BNCLNFJHEND_ReadString(json, "helpFlags");
					if(!string.IsNullOrEmpty(s))
					{
						string[] ss = s.Split(new char[] { ',' } );
						for(int i = 0; i < ss.Length; i++)
						{
							helpFlagList.Add(ss[i]);
						}
					}
				}
				return true;
			}
			return false;
		}

		// RVA: 0xBBD4B4 Offset: 0xBBD4B4 VA: 0xBBD4B4
		public void Save()
		{
			EDOHBJAPLPF_JsonData json = ToJsonData();
			byte[] bs = Encoding.UTF8.GetBytes(json.EJCOJCGIBNG_ToJson());
			for(int i = 0; i < bs.Length; i++)
			{
				bs[i] ^= 215;
			}
			string p = Application.persistentDataPath + "/SaveData/arsd.bin";
			byte[] buffer = new byte[bs.Length];
			using(MemoryStream ms = new MemoryStream(buffer))
			{
				using(BinaryWriter bw = new BinaryWriter(ms))
				{
					bw.Write(bs);
					bw.Close();
					ICryptoTransform t = rijndale.CreateEncryptor();
					byte[] bs2 = t.TransformFinalBlock(buffer, 0, buffer.Length);
					for(int i = 0; i < buffer.Length; i++)
						buffer[i] = 0;
					Utility.SaveToStorage(p, bs2, true);
				}
			}
		}

		// // RVA: 0xBBDBD8 Offset: 0xBBDBD8 VA: 0xBBDBD8
		private EDOHBJAPLPF_JsonData ToJsonData()
		{
			EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
			res["isShowHelp"] = isShowHelp ? 1 : 0;
			EDOHBJAPLPF_JsonData l = new EDOHBJAPLPF_JsonData();
			l.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int i = 0; i < stampList.Count; i++)
			{
				EDOHBJAPLPF_JsonData d = new EDOHBJAPLPF_JsonData();
				d["markerId"] = stampList[i].markerId;
				d["haveFlag"] = stampList[i].haveFlag;
				l.Add(d);
			}
			res["StampData"] = l;
			StringBuilder str = new StringBuilder();
			for(int i = 0; i < helpFlagList.Count; i++)
			{
				if(i > 0)
					str.Append(',');
				str.Append(helpFlagList[i]);
			}
			res["helpFlags"] = str.ToString();
			return res;
		}

		// RVA: 0xBBE088 Offset: 0xBBE088 VA: 0xBBE088
		public void SetShowHelp(bool isShow)
		{
			isShowHelp = isShow;
		}

		// RVA: 0xBBE090 Offset: 0xBBE090 VA: 0xBBE090
		public void SetHaveStamp(string markerId, bool isHave)
		{
			StampData data = stampList.Find((StampData _) =>
			{
				//0xBBE8E8
				return _.markerId == markerId;
			});
			if(data == null)
			{
				data = new StampData();
				data.markerId = markerId;
				data.haveFlag = isHave ? 1 : 0;
				stampList.Add(data);
			}
			else
			{
				data.haveFlag = isHave ? 1 : 0;
			}
		}

		// RVA: 0xBBE218 Offset: 0xBBE218 VA: 0xBBE218
		public bool IsShowHelp()
		{
			return isShowHelp;
		}

		// RVA: 0xBBE220 Offset: 0xBBE220 VA: 0xBBE220
		public bool IsNotSeeingMarkerHelp(List<AREventMasterData.Data> eventList)
		{
			for(int i = 0; i < eventList.Count; i++)
			{
				if(eventList[i].enable == 2)
				{
					if(IsShowMarkerHelp(eventList[i].eventId))
						return true;
				}
			}
			return false;
		}

		// RVA: 0xBBE360 Offset: 0xBBE360 VA: 0xBBE360
		public bool IsShowMarkerHelp(string eventId)
		{
			return helpFlagList.IndexOf(eventId) < 0;
		}

		// RVA: 0xBBE3E4 Offset: 0xBBE3E4 VA: 0xBBE3E4
		public void SetMarkerHelpShowFlag(string eventId)
		{
			int idx = helpFlagList.IndexOf(eventId);
			if(idx > -1)
				return;
			helpFlagList.Add(eventId);
		}

		// RVA: 0xBBE49C Offset: 0xBBE49C VA: 0xBBE49C
		public bool IsHaveStamp(string markerId)
		{
			StampData data = stampList.Find((StampData _) =>
			{
				//0xBBE91C
				return _.markerId == markerId;
			});
			if(data != null)
			{
				return data.haveFlag != 0;
			}
			return false;
		}

		// // RVA: 0xBBE5B8 Offset: 0xBBE5B8 VA: 0xBBE5B8
		// public bool SyncToPlayerData(BBHNACPENDM_ServerSaveData playerData) { }
	}
}
