using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.AR
{
	public enum ARDivaPatternId
	{
		None = -1,
		Miniature = 0,
		LifeSize = 1,
		Present = 2,
		Num = 3,
	}

	public class ARMarkerMasterData : ARMasterData
	{
		public class Stamp
		{
			public string stampId = ""; // 0x8
			public bool isHave; // 0xC
		}

		public class CueSheetData
		{
			public int no; // 0x8
			public int enable; // 0xC
			public int markerNo; // 0x10
			public string cueSheetId = ""; // 0x14
			public long soundStart; // 0x18
			public long soundEnd; // 0x20
		}

		public class Data
		{
			public int no; // 0x8
			public int enable; // 0xC
			public string markerId = ""; // 0x10
			public string eventId = ""; // 0x14
			public ARDivaPatternId pattern = ARDivaPatternId.None; // 0x18
			public int divaId; // 0x1C
			public int costumeId; // 0x20
			public Vector3 position = Vector3.zero; // 0x24
			public Vector3 rotation = Vector3.zero; // 0x30
			public float imageWidth; // 0x3C
			public float divaHeight; // 0x40
			public int stampId; // 0x44
			public float angleLimit; // 0x48
			public long markerStart; // 0x50
			public long markerEnd; // 0x58
			public int emblemId; // 0x60
			public int trackingType; // 0x64
			public ARDivaMotionId motionId; // 0x68
			public List<CueSheetData> cueSheetList; // 0x6C
			public bool haveFlag; // 0x70

			public string cueSheetId { get 
			{
				long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
				for(int i = 0; i < cueSheetList.Count; i++)
				{
					if(cueSheetList[i].soundStart <= t && t < cueSheetList[i].soundEnd)
						return cueSheetList[i].cueSheetId;
				}
				return "";
			} } //0x11DADA4
			public int wavId { get 
			{
				if(!string.IsNullOrEmpty(cueSheetId))
				{
					if(!cueSheetId.StartsWith("cs_ar_diva_"))
					{
						string[] strs = cueSheetId.Split(new char[] { '_' });
						int a;
						if(int.TryParse(strs[strs.Length - 1], out a))
							return a;
					}
				}
				return 0;
			} } //0x11CE608
		}

		private static ARMarkerMasterData sm_instance; // 0x0
		public List<Data> m_markerList = new List<ARMarkerMasterData.Data>(); // 0x18

		public static ARMarkerMasterData Instance { get {
			if(sm_instance == null)
			{
				sm_instance = new ARMarkerMasterData();
				sm_instance.name = "ar_marker";
			}
			return sm_instance;
		} } // 0x11D28D8

		// // RVA: 0x11D9A84 Offset: 0x11D9A84 VA: 0x11D9A84
		// public static void Release() { }

		// RVA: 0x11D9B14 Offset: 0x11D9B14 VA: 0x11D9B14 Slot: 4
		protected override void Initialize(byte[] bytes)
		{
			LPKFACLGIMO data = LPKFACLGIMO.HEGEKFMJNCC(bytes);
			List<CueSheetData> l = new List<CueSheetData>();
			{
				BBJJIIOLGCE[] array = data.PLIKHNFGBLO;
				for(int i = 0; i < array.Length; i++)
				{
					CueSheetData d = new CueSheetData();
					d.no = array[i].IKPIDCFOFEA;
					d.enable = array[i].PLALNIIBLOF;
					d.markerNo = array[i].HIEKBDMHKLP;
					d.cueSheetId = array[i].BLOIKEAGFED;
					d.soundStart = array[i].IOCAJMALMLJ;
					d.soundEnd = array[i].BEBCANGAMAK;
					// UMO
					d.soundStart = 0;
					d.soundEnd = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime() + 360000;
					// UMO
					l.Add(d);
				}
			}
			m_markerList.Clear();
			{
				BMPAGNNCFEC[] array = data.BFKBNEAMHEB;
				for(int i = 0; i < array.Length; i++)
				{
					Data nd = new Data();
					nd.no = array[i].IKPIDCFOFEA;
					nd.enable = array[i].PLALNIIBLOF;
					nd.markerId = array[i].FILGCAEHBAC;
					nd.eventId = array[i].DNJLJMKKDNA.ToLower();
					nd.pattern = (ARDivaPatternId)array[i].BFGNMDGOEID;
					nd.divaId = array[i].DIPKCALNIII;
					nd.costumeId = array[i].BEEAIAAJOHD;
					float.TryParse(array[i].FPLEBCKDCBE, out nd.position.x);
					float.TryParse(array[i].MDLMHEDHPHA, out nd.position.y);
					float.TryParse(array[i].CDKLKKKGAMB, out nd.position.z);
					float.TryParse(array[i].OAPEIEHMIJD, out nd.rotation.x);
					float.TryParse(array[i].IMGHEKMHHPC, out nd.rotation.y);
					float.TryParse(array[i].GJEEMHGGDKD, out nd.rotation.z);
					float.TryParse(array[i].AELANGEHIPP, out nd.imageWidth);
					float.TryParse(array[i].EHDNFJOMMJJ, out nd.divaHeight);
					nd.stampId = (int)float.Parse(array[i].LNKDMOBAHDA);
					float.TryParse(array[i].LNMKDNMJLOE, out nd.angleLimit);
					long.TryParse(array[i].MPCKINJNGJH, out nd.markerStart);
					long.TryParse(array[i].JIDKMIHGOHI, out nd.markerEnd);
					// UMO
					nd.markerStart = 0;
					nd.markerEnd = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime() + 360000;
					// UMO
					nd.emblemId = array[i].APGKOJKNNGP;
					nd.trackingType = array[i].DCNFOHHNAEF;
					nd.motionId = (ARDivaMotionId)array[i].BEHGCAMHJIE;
					nd.cueSheetList = l.FindAll((CueSheetData _) =>
					{
						//0x11DAD58
						return _.markerNo == nd.no;
					});
					nd.haveFlag = false;
					m_markerList.Add(nd);
				}
			}
		}

		// RVA: 0x11D2A3C Offset: 0x11D2A3C VA: 0x11D2A3C
		public List<Data> GetMarkerList(bool isAll = false)
		{
			List<Data> res = new List<Data>();
			for(int i = 0; i < m_markerList.Count; i++)
			{
				if(isAll)
				{
					res.Add(m_markerList[i]);
				}
				else
				{
					if(m_markerList[i].enable > 1)
					{
						long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
						if(m_markerList[i].markerStart <= t && t < m_markerList[i].markerEnd)
						{
							res.Add(m_markerList[i]);
						}
					}
				}
			}
			return res;
		}

		// // RVA: 0x11DA83C Offset: 0x11DA83C VA: 0x11DA83C
		public List<Data> GetStartingMarkerList()
		{
			List<Data> res = new List<Data>();
			long l = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			for(int i = 0; i < m_markerList.Count; i++)
			{
				if(m_markerList[i].enable != 0 && l >= m_markerList[i].markerStart)
					res.Add(m_markerList[i]);
			}
			return res;
		}

		// RVA: 0x11DAA34 Offset: 0x11DAA34 VA: 0x11DAA34
		public List<Data> GetEventMarkerList(string eventId, bool isAll = false)
		{
			List<Data> l = GetMarkerList(isAll);
			if(l.Count > 0)
			{
				return l.FindAll((Data _) =>
				{
					//0x11DACC0
					return _.eventId.Contains(eventId);
				});
			}
			return null;
		}

		// // RVA: 0x11DAB7C Offset: 0x11DAB7C VA: 0x11DAB7C
		public List<Data> GetEventStartingMarkerList(string eventId)
		{
			List<Data> l = GetStartingMarkerList();
			if(l.Count != 0)
			{
				return l.FindAll((Data _) =>
				{
					//0x11DAD0C
					return _.eventId.Contains(eventId);
				});
			}
			return null;
		}
	}
}
