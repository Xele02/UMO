
using System;
using System.Collections.Generic;
using UnityEngine;
using XeSys;

[System.Obsolete("Use GEGHOCKCKKA_LimitedCompoItem", true)]
public class GEGHOCKCKKA { }
public class GEGHOCKCKKA_LimitedCompoItem : KLFDBFMNLBL_ServerSaveBlock
{
	public class AIAPDPDOIKG
	{
		public class AGGJCJMIIMJ
		{
			public int CNGMGFCGLOK; // 0x8
			public int EHOIENNDEDH_IdCrypted; // 0xC
			public int JECIEFEOBDO; // 0x10
			public int FBGGEFFJJHB_xor; // 0x14
			public int DJJOKAOHAML; // 0x18
			public int DADJGIPLGBK; // 0x1C

			public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x16BB5F0 DEMEPMAEJOO 0x16BBAEC HIGKAIDMOKN
			public int PGPGPJNBIOH_uid { get { return CNGMGFCGLOK ^ FBGGEFFJJHB_xor; } set { CNGMGFCGLOK = value ^ FBGGEFFJJHB_xor; } } //0x16B98C4 CJEDGLPDJBN 0x16BBADC EKJKPIKJLJJ
			public int DOJDOLDDBPP_Hav { get { return DJJOKAOHAML ^ FBGGEFFJJHB_xor; } set { DJJOKAOHAML = value ^ FBGGEFFJJHB_xor; } } //0x16BB610 FHJFILKDGGO 0x16BBB1C DEEAELHLIEC
			public int DIAPHCJBPFD_Get { get { return JECIEFEOBDO ^ FBGGEFFJJHB_xor; } set { JECIEFEOBDO = value ^ FBGGEFFJJHB_xor; } } //0x16B98B4 EIEMCCANNJE 0x16BBAFC JLGBEBCNDJN
			public int IOLJPHAOBOH_Use { get { return DADJGIPLGBK ^ FBGGEFFJJHB_xor; } set { DADJGIPLGBK = value ^ FBGGEFFJJHB_xor; } } //0x16BB600 EHKEMJJNKKI 0x16BBB0C GHMCNDFEFIF
			public int HNKFMAJIFJD { get {
					DateTime date = Utility.GetLocalDateTime(EDLLKJAKIGO(PPFNGGCBJKC_id, DIAPHCJBPFD_Get) + DIAPHCJBPFD_Get);
					return (int)Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, 23, 59, 59);
				} } //0x16B91A4 CEOIBKAGPAG
			private long OLNKAECIGJH { get { return Utility.GetTargetUnixTime(2030, 1, 1, 0, 0, 0); } } //0x16BD4AC GBAOINLDCEM

			//// RVA: 0x16BD368 Offset: 0x16BD368 VA: 0x16BD368
			private int EDLLKJAKIGO(int _PPFNGGCBJKC_id, long _JHNMKKNEENE_Time)
			{
				int t = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MBAGKLJDKMH_LimitedCompoItem.OCMMLAOEPIG[_PPFNGGCBJKC_id - 1].EMIJNAFJFJO_Expir;
				if (t * 0x15180 != 0)
					return t * 0x15180;
				return (int)OLNKAECIGJH - (int)_JHNMKKNEENE_Time;
			}

			//// RVA: 0x16B88F4 Offset: 0x16B88F4 VA: 0x16B88F4
			public bool NIENPFFLMCH(long _JHNMKKNEENE_Time)
			{
				if(DOJDOLDDBPP_Hav == 1)
				{
					if (_JHNMKKNEENE_Time >= DIAPHCJBPFD_Get)
						return HNKFMAJIFJD >= _JHNMKKNEENE_Time;
				}
				return false;
			}

			//// RVA: 0x16BA81C Offset: 0x16BA81C VA: 0x16BA81C
			public bool GIBLKLLLHFP()
			{
				return HNKFMAJIFJD >= OLNKAECIGJH;
			}

			//// RVA: 0x16BD54C Offset: 0x16BD54C VA: 0x16BD54C
			public void DNBGDMBCLMI_ChangeKey(int KNEFBLHBDBG)
			{
				CNGMGFCGLOK = CNGMGFCGLOK ^ KNEFBLHBDBG ^ FBGGEFFJJHB_xor;
				EHOIENNDEDH_IdCrypted = EHOIENNDEDH_IdCrypted ^ KNEFBLHBDBG ^ FBGGEFFJJHB_xor;
				JECIEFEOBDO = JECIEFEOBDO ^ KNEFBLHBDBG ^ FBGGEFFJJHB_xor;
				DADJGIPLGBK = DADJGIPLGBK ^ KNEFBLHBDBG ^ FBGGEFFJJHB_xor;
				DJJOKAOHAML = DJJOKAOHAML ^ KNEFBLHBDBG ^ FBGGEFFJJHB_xor;
				FBGGEFFJJHB_xor = KNEFBLHBDBG;
			}

			//// RVA: 0x16BAF20 Offset: 0x16BAF20 VA: 0x16BAF20
			//public void LHPDDGIJKNB_Reset(int KNEFBLHBDBG) { }

			//// RVA: 0x16B98D4 Offset: 0x16B98D4 VA: 0x16B98D4
			//public void HPFJOBPMNCP(int KNEFBLHBDBG, int _PGPGPJNBIOH_uid, int _PPFNGGCBJKC_id, long _JHNMKKNEENE_Time) { }

			//// RVA: 0x16B9DE8 Offset: 0x16B9DE8 VA: 0x16B9DE8
			public void PKAINJJBMMH_ChangeKeyAndSetTime(int KNEFBLHBDBG, long KNCKIJBOODM)
			{
				CNGMGFCGLOK = CNGMGFCGLOK ^ KNEFBLHBDBG ^ FBGGEFFJJHB_xor;
				EHOIENNDEDH_IdCrypted = EHOIENNDEDH_IdCrypted ^ KNEFBLHBDBG ^ FBGGEFFJJHB_xor;
				JECIEFEOBDO = JECIEFEOBDO ^ KNEFBLHBDBG ^ FBGGEFFJJHB_xor;
				FBGGEFFJJHB_xor = KNEFBLHBDBG;
				DADJGIPLGBK = 0;
				DJJOKAOHAML = (int)KNCKIJBOODM;
			}

			//// RVA: 0x16BBB2C Offset: 0x16BBB2C VA: 0x16BBB2C
			public void ODDIHGPONFL_Copy(AGGJCJMIIMJ GPBJHKLFCEP)
			{
				PGPGPJNBIOH_uid = GPBJHKLFCEP.PGPGPJNBIOH_uid;
				PPFNGGCBJKC_id = GPBJHKLFCEP.PPFNGGCBJKC_id;
				DIAPHCJBPFD_Get = GPBJHKLFCEP.DIAPHCJBPFD_Get;
				IOLJPHAOBOH_Use = GPBJHKLFCEP.IOLJPHAOBOH_Use;
				DOJDOLDDBPP_Hav = GPBJHKLFCEP.DOJDOLDDBPP_Hav;
			}

			//// RVA: 0x16BC5C8 Offset: 0x16BC5C8 VA: 0x16BC5C8
			public bool AGBOGBEOFME(AGGJCJMIIMJ OIKJFMGEICL)
			{
				if(PGPGPJNBIOH_uid != OIKJFMGEICL.PGPGPJNBIOH_uid ||
					PPFNGGCBJKC_id != OIKJFMGEICL.PPFNGGCBJKC_id ||
					DIAPHCJBPFD_Get != OIKJFMGEICL.DIAPHCJBPFD_Get ||
					IOLJPHAOBOH_Use != OIKJFMGEICL.IOLJPHAOBOH_Use ||
					DOJDOLDDBPP_Hav != OIKJFMGEICL.DOJDOLDDBPP_Hav)
					return false;
				return true;
			}

			//// RVA: 0x16BD5AC Offset: 0x16BD5AC VA: 0x16BD5AC
			//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int _OIPCCBHIKIA_index, GEGHOCKCKKA.AIAPDPDOIKG.AGGJCJMIIMJ _OHMCIEMIKCE_t, bool KFCGIKHEEMB) { }
		}

		public int HFAHJPBLCHK; // 0x8
		private int PENIOLJHIPK; // 0xC
		public List<AGGJCJMIIMJ> PJADHDHKOEJ = new List<AGGJCJMIIMJ>(); // 0x10
		public List<AGGJCJMIIMJ> NPNNEDINOKC = new List<AGGJCJMIIMJ>(); // 0x14

		// RVA: 0x16BAAE4 Offset: 0x16BAAE4 VA: 0x16BAAE4
		public AIAPDPDOIKG(int HFAHJPBLCHK, int PENIOLJHIPK)
		{
			this.HFAHJPBLCHK = HFAHJPBLCHK;
			this.PENIOLJHIPK = PENIOLJHIPK;
		}

		//// RVA: 0x16B8950 Offset: 0x16B8950 VA: 0x16B8950
		//public int HHBLKNMLOPO() { }

		//// RVA: 0x16B8AE0 Offset: 0x16B8AE0 VA: 0x16B8AE0
		public int OPCIHPEIFFE()
		{
            JHAAHJNEBOG_LimitedCompoItem.JMJKJFKAFCJ item = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MBAGKLJDKMH_LimitedCompoItem.CDENCMNHNGA_table[PENIOLJHIPK - 1];
            if (item.DODGLIDGBBC == 1)
			{
				if(NHPDPKHMFEP.HHCJCDFCLOB != null && 
					NHPDPKHMFEP.HHCJCDFCLOB.GBCPDBJEDHL(false) && 
					NHPDPKHMFEP.HHCJCDFCLOB.ENAAHAPDMCO())
				{
					return item.HHGFOIMIGED;
				}
			}
			return item.DOOGFEGEKLG_Max;
		}

		//// RVA: 0x16BCF64 Offset: 0x16BCF64 VA: 0x16BCF64
		public int LFOEBPPAAFJ(int _PPFNGGCBJKC_id, long _JHNMKKNEENE_Time)
		{
			int cnt = 0;
			for(int i = 0; i < PJADHDHKOEJ.Count; i++)
			{
				if(PJADHDHKOEJ[i].PPFNGGCBJKC_id == _PPFNGGCBJKC_id)
				{
					cnt += PJADHDHKOEJ[i].NIENPFFLMCH(_JHNMKKNEENE_Time) ? 1 : 0;
				}
			}
			return cnt;
		}

		//// RVA: 0x16BD0C4 Offset: 0x16BD0C4 VA: 0x16BD0C4
		//public void PKAINJJBMMH(int _PPFNGGCBJKC_id, long KNCKIJBOODM) { }
	}


	private const int ECFEMKGFDCE = 1;
	public const int HAKDOMMLLJP = 99999999;
	public List<AIAPDPDOIKG> ODHBHOGFNAA = new List<AIAPDPDOIKG>(); // 0x24

	public override bool DMICHEJIAJL { get { return false; } } // 0x16BC740 NFKFOODCJJB

	// // RVA: 0x16B869C Offset: 0x16B869C VA: 0x16B869C
	public int HPPKOGKNKMH(int _PPFNGGCBJKC_id, long _JHNMKKNEENE_Time)
	{
		if (_PPFNGGCBJKC_id < 1)
			return 0;
		int res = 0;
		int a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MBAGKLJDKMH_LimitedCompoItem.OCMMLAOEPIG[_PPFNGGCBJKC_id - 1].PENIOLJHIPK;
		for(int i = 0; i < ODHBHOGFNAA[a - 1].HFAHJPBLCHK; i++)
		{
			res += (ODHBHOGFNAA[a - 1].PJADHDHKOEJ[i].NIENPFFLMCH(_JHNMKKNEENE_Time) && ODHBHOGFNAA[a - 1].NPNNEDINOKC[i].NIENPFFLMCH(_JHNMKKNEENE_Time)) ? 1 : 0;
		}
		return res;
	}

	// // RVA: 0x16B8958 Offset: 0x16B8958 VA: 0x16B8958
	public int OPCIHPEIFFE(int _PPFNGGCBJKC_id)
	{
		if(_PPFNGGCBJKC_id < 1)
			return 0;
		int a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MBAGKLJDKMH_LimitedCompoItem.OCMMLAOEPIG[_PPFNGGCBJKC_id - 1].PENIOLJHIPK;
		return ODHBHOGFNAA[a - 1].OPCIHPEIFFE();
	}

	// // RVA: 0x16B8CB8 Offset: 0x16B8CB8 VA: 0x16B8CB8
	// public int MOAPEHACGDN(int _PPFNGGCBJKC_id, long _JHNMKKNEENE_Time) { }

	// // RVA: 0x16B8E6C Offset: 0x16B8E6C VA: 0x16B8E6C
	public int BLKPKBICPKK(int _PPFNGGCBJKC_id, long _JHNMKKNEENE_Time)
	{
		if (_PPFNGGCBJKC_id < 1)
			return 0;
		AIAPDPDOIKG a = ODHBHOGFNAA[IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MBAGKLJDKMH_LimitedCompoItem.OCMMLAOEPIG[_PPFNGGCBJKC_id - 1].PENIOLJHIPK - 1];
		int c = int.MaxValue;
		for(int i = 0; i < a.HFAHJPBLCHK; i++)
		{
			if(a.PJADHDHKOEJ[i].NIENPFFLMCH(_JHNMKKNEENE_Time) && a.PJADHDHKOEJ[i].NIENPFFLMCH(_JHNMKKNEENE_Time))
			{
				if(a.PJADHDHKOEJ[i].HNKFMAJIFJD < c)
				{
					c = a.PJADHDHKOEJ[i].HNKFMAJIFJD;
				}
			}
		}
		if (c == int.MaxValue)
			return 0;
		return c;
	}

	// // RVA: 0x16B92C8 Offset: 0x16B92C8 VA: 0x16B92C8
	public int CPIICACGNBH(int _PPFNGGCBJKC_id, long _JHNMKKNEENE_Time, bool _DDGFCOPPBBN_test/* = false*/)
	{
		if(_PPFNGGCBJKC_id > 0)
		{
			JHAAHJNEBOG_LimitedCompoItem limitedDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MBAGKLJDKMH_LimitedCompoItem;
			int a = limitedDb.OCMMLAOEPIG[_PPFNGGCBJKC_id - 1].PENIOLJHIPK;
			AIAPDPDOIKG data = ODHBHOGFNAA[a - 1];
			int MinGet = int.MaxValue;
			int MaxUid = int.MinValue;
			int MinGetIdx = -1;
			for(int i = 0; i < data.HFAHJPBLCHK; i++)
			{
				if(!data.PJADHDHKOEJ[i].NIENPFFLMCH(_JHNMKKNEENE_Time))
				{
					if(data.PJADHDHKOEJ[i].DIAPHCJBPFD_Get <= MinGet)
					{
						MinGet = data.PJADHDHKOEJ[i].DIAPHCJBPFD_Get;
						MinGetIdx = i;
					}
				}
				if(data.PJADHDHKOEJ[i].PGPGPJNBIOH_uid > MaxUid)
				{
					MaxUid = data.PJADHDHKOEJ[i].PGPGPJNBIOH_uid;
				}
			}
			if(MinGetIdx > -1)
			{
				MaxUid++;
				if (MaxUid > 99999999)
					MaxUid = 1;
				if (_DDGFCOPPBBN_test)
				{
					return limitedDb.OCMMLAOEPIG[_PPFNGGCBJKC_id - 1].EMIJNAFJFJO_Expir + (int)_JHNMKKNEENE_Time;
				}
				AIAPDPDOIKG.AGGJCJMIIMJ data2 = data.PJADHDHKOEJ[MinGetIdx];
				data2.FBGGEFFJJHB_xor = (int)_JHNMKKNEENE_Time * 0x2e7;
				data2.PGPGPJNBIOH_uid = MaxUid;
				data2.PPFNGGCBJKC_id = _PPFNGGCBJKC_id;
				data2.DIAPHCJBPFD_Get = (int)_JHNMKKNEENE_Time;
				data2.DOJDOLDDBPP_Hav = 1;
				data2.IOLJPHAOBOH_Use = 0;

				data2 = data.NPNNEDINOKC[MinGetIdx];
				data2.FBGGEFFJJHB_xor = (int)_JHNMKKNEENE_Time * 0x540545;
				data2.PGPGPJNBIOH_uid = MaxUid;
				data2.PPFNGGCBJKC_id = _PPFNGGCBJKC_id;
				data2.DIAPHCJBPFD_Get = (int)_JHNMKKNEENE_Time;
				data2.DOJDOLDDBPP_Hav = 1;
				data2.IOLJPHAOBOH_Use = 0;

				return data.PJADHDHKOEJ[MinGetIdx].HNKFMAJIFJD;
			}
		}
		return 0;
	}

	// // RVA: 0x16B990C Offset: 0x16B990C VA: 0x16B990C
	public List<int> BHNDPHCBCKN(int _PPFNGGCBJKC_id, long _JHNMKKNEENE_Time)
	{
		List<int> res = new List<int>();
		if(_PPFNGGCBJKC_id > 0)
		{
			JHAAHJNEBOG_LimitedCompoItem.AOBHKONKIPF c = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MBAGKLJDKMH_LimitedCompoItem.OCMMLAOEPIG[_PPFNGGCBJKC_id - 1];
			AIAPDPDOIKG COCEIPAKJKF_Item = ODHBHOGFNAA[c.PENIOLJHIPK - 1];
			for(int i = 0; i < COCEIPAKJKF_Item.HFAHJPBLCHK; i++)
			{
				AIAPDPDOIKG.AGGJCJMIIMJ a2 = COCEIPAKJKF_Item.PJADHDHKOEJ[i];
				if(a2.NIENPFFLMCH(_JHNMKKNEENE_Time))
				{
					res.Add(i);
				}
			}
			res.Sort((int HKICMNAACDA, int BNKHBCBJBKI) =>
			{
				//0x1801D50
				return COCEIPAKJKF_Item.PJADHDHKOEJ[HKICMNAACDA].PGPGPJNBIOH_uid.CompareTo(COCEIPAKJKF_Item.PJADHDHKOEJ[BNKHBCBJBKI].PGPGPJNBIOH_uid);
			});
		}
		return res;
	}

	// // RVA: 0x16B9C2C Offset: 0x16B9C2C VA: 0x16B9C2C
	public bool LLOAMEOCJEO(int PENIOLJHIPK, int _OIPCCBHIKIA_index, long KNCKIJBOODM)
	{
		if (PENIOLJHIPK < 1)
			return false;
		AIAPDPDOIKG a = ODHBHOGFNAA[PENIOLJHIPK - 1];
		a.PJADHDHKOEJ[_OIPCCBHIKIA_index].PKAINJJBMMH_ChangeKeyAndSetTime((int)(KNCKIJBOODM * 0x2e5), KNCKIJBOODM);
		a.NPNNEDINOKC[_OIPCCBHIKIA_index].PKAINJJBMMH_ChangeKeyAndSetTime((int)(KNCKIJBOODM * 0x100b57), KNCKIJBOODM);
		return true;
	}

	// // RVA: 0x16B9E30 Offset: 0x16B9E30 VA: 0x16B9E30
	public List<NKFJNAANPNP.MOJLCADLMKH> BNGLMLIMFDM(int _PPFNGGCBJKC_id, long _JHNMKKNEENE_Time)
	{
		List<NKFJNAANPNP.MOJLCADLMKH> res = new List<NKFJNAANPNP.MOJLCADLMKH>();
		if (_PPFNGGCBJKC_id > 0)
		{
			JHAAHJNEBOG_LimitedCompoItem.AOBHKONKIPF litem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MBAGKLJDKMH_LimitedCompoItem.OCMMLAOEPIG[_PPFNGGCBJKC_id - 1];
			List<NKFJNAANPNP.MOJLCADLMKH> l2 = new List<NKFJNAANPNP.MOJLCADLMKH>();
			for(int i = 0; i < ODHBHOGFNAA[litem.PENIOLJHIPK].PJADHDHKOEJ.Count; i++)
			{
				AIAPDPDOIKG.AGGJCJMIIMJ item = ODHBHOGFNAA[litem.PENIOLJHIPK].PJADHDHKOEJ[i];
				if(item.NIENPFFLMCH(_JHNMKKNEENE_Time))
				{
					if(!item.GIBLKLLLHFP())
					{
						NKFJNAANPNP.MOJLCADLMKH data = new NKFJNAANPNP.MOJLCADLMKH();
						data.LHPDDGIJKNB_Reset((int)(_JHNMKKNEENE_Time * 0x227));
						data.HNKFMAJIFJD_ExpireAt = item.HNKFMAJIFJD;
						data.HMFFHLPNMPH_Count = 1;
						l2.Add(data);
					}
				}
			}
			for(int i = 0; i < l2.Count; i++)
			{
				DateTime date = Utility.GetLocalDateTime(l2[i].HNKFMAJIFJD_ExpireAt);
				string str = string.Concat(new string[]
				{
					date.Year.ToString(), date.Month.ToString(), date.Day.ToString(), date.Hour.ToString(),
					date.Minute.ToString()
				});
				NKFJNAANPNP.MOJLCADLMKH r = res.Find((NKFJNAANPNP.MOJLCADLMKH JPAEDJJFFOI) =>
				{
					//0x16BCADC
					DateTime date2 = Utility.GetLocalDateTime(JPAEDJJFFOI.HNKFMAJIFJD_ExpireAt);
					string str2 = string.Concat(new string[]
					{
						date2.Year.ToString(), date2.Month.ToString(), date2.Day.ToString(), date2.Hour.ToString(),
						date2.Minute.ToString()
					});
					return str == str2;
				});
				if (r == null)
				{
					res.Add(l2[i]);
				}
				else
				{
					r.HMFFHLPNMPH_Count += l2[i].HMFFHLPNMPH_Count;
				}
			}
			res.Sort((NKFJNAANPNP.MOJLCADLMKH HKICMNAACDA, NKFJNAANPNP.MOJLCADLMKH BNKHBCBJBKI) =>
			{
				//0x16BCA6C
				return HKICMNAACDA.HNKFMAJIFJD_ExpireAt.CompareTo(BNKHBCBJBKI.HNKFMAJIFJD_ExpireAt);
			});
		}
		return res;
	}

	// // RVA: 0x16BA850 Offset: 0x16BA850 VA: 0x16BA850
	public GEGHOCKCKKA_LimitedCompoItem()
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			JHAAHJNEBOG_LimitedCompoItem limitedDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MBAGKLJDKMH_LimitedCompoItem;
			for(int i = 0; i < limitedDb.CDENCMNHNGA_table.Count; i++)
			{
				JHAAHJNEBOG_LimitedCompoItem.JMJKJFKAFCJ info = limitedDb.CDENCMNHNGA_table[i];
				AIAPDPDOIKG data = new AIAPDPDOIKG(Mathf.Max(info.DOOGFEGEKLG_Max, info.HHGFOIMIGED), i + 1);
				ODHBHOGFNAA.Add(data);
			}
		}
	}

	// // RVA: 0x16BAB98 Offset: 0x16BAB98 VA: 0x16BAB98 Slot: 4
	public override void KMBPACJNEOF_Reset()
	{
		JHAAHJNEBOG_LimitedCompoItem limitedDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MBAGKLJDKMH_LimitedCompoItem;
		for(int i = 0; i < ODHBHOGFNAA.Count; i++)
		{
			AIAPDPDOIKG data = ODHBHOGFNAA[i];
			data.PJADHDHKOEJ.Clear();
			data.NPNNEDINOKC.Clear();
			int k = (int)Utility.GetCurrentUnixTime() * 0x6f;
			for(int j = 0; j < data.HFAHJPBLCHK; j++)
			{
				AIAPDPDOIKG.AGGJCJMIIMJ data2 = new AIAPDPDOIKG.AGGJCJMIIMJ();
				data2.FBGGEFFJJHB_xor = k;
				data2.DOJDOLDDBPP_Hav = 0;
				data2.IOLJPHAOBOH_Use = 0;
				data2.PGPGPJNBIOH_uid = 0;
				data2.PPFNGGCBJKC_id = 0;
				data2.DIAPHCJBPFD_Get = 0;
				data.PJADHDHKOEJ.Add(data2);
				k *= 0xb;
			}
			for (int j = 0; j < data.HFAHJPBLCHK; j++)
			{
				AIAPDPDOIKG.AGGJCJMIIMJ data2 = new AIAPDPDOIKG.AGGJCJMIIMJ();
				data2.FBGGEFFJJHB_xor = k;
				data2.DOJDOLDDBPP_Hav = 0;
				data2.IOLJPHAOBOH_Use = 0;
				data2.PGPGPJNBIOH_uid = 0;
				data2.PPFNGGCBJKC_id = 0;
				data2.DIAPHCJBPFD_Get = 0;
				data.NPNNEDINOKC.Add(data2);
				k *= 0xb;
			}
		}
	}

	// // RVA: 0x16BAF38 Offset: 0x16BAF38 VA: 0x16BAF38 Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long _MCKEOKFMLAH_SaveId)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		for(int i = 0; i < ODHBHOGFNAA.Count; i++)
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			for(int j = 0; j < ODHBHOGFNAA[i].PJADHDHKOEJ.Count; j++)
			{
				EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
				data3["uid"] = ODHBHOGFNAA[i].PJADHDHKOEJ[j].PGPGPJNBIOH_uid;
				data3["id"] = ODHBHOGFNAA[i].PJADHDHKOEJ[j].PPFNGGCBJKC_id;
				data3["get"] = ODHBHOGFNAA[i].PJADHDHKOEJ[j].DIAPHCJBPFD_Get;
				data3["use"] = ODHBHOGFNAA[i].PJADHDHKOEJ[j].IOLJPHAOBOH_Use;
				data3["hav"] = ODHBHOGFNAA[i].PJADHDHKOEJ[j].DOJDOLDDBPP_Hav;
				data2.Add(data3);
			}
			data["_" + (i + 1)] = data2;
		}
		if(!EMBGIDLFKGM)
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = _MCKEOKFMLAH_SaveId;
			data2[JIKKNHIAEKG_BlockName] = data;
			data2[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] = 1;
			data = data2;
		}
		else
		{
			OILEIIEIBHP = OILEIIEIBHP[AFEHLCGHAEE_Strings.JCIBKDHKNFH_alldata];
		}
		OILEIIEIBHP[JIKKNHIAEKG_BlockName] = data;
	}

	// // RVA: 0x16BB620 Offset: 0x16BB620 VA: 0x16BB620 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool blockMissing = false;
		bool isInvalid = false;
		EDOHBJAPLPF_JsonData block = LGPBAKLCFHI_FindAndCheckBlock(OILEIIEIBHP, ref blockMissing, ref isInvalid, 1);
		if (!blockMissing)
		{
			if (block == null)
			{
				isInvalid = true;
			}
			else
			{
				for (int i = 0; i < ODHBHOGFNAA.Count; i++)
				{
					string str = "_" + (i + 1).ToString();
					if(block.BBAJPINMOEP_Contains(str))
					{
						EDOHBJAPLPF_JsonData b = block[str];
						AIAPDPDOIKG data = ODHBHOGFNAA[i];
						if (b.HNBFOAJIIAL_Count != data.HFAHJPBLCHK)
							isInvalid = true;
						int cnt = b.HNBFOAJIIAL_Count;
						if (data.HFAHJPBLCHK < cnt)
							cnt = data.HFAHJPBLCHK;
						for(int j = 0; j < cnt; j++)
						{
							EDOHBJAPLPF_JsonData b2 = b[j];
							data.PJADHDHKOEJ[j].PGPGPJNBIOH_uid = CJAENOMGPDA_ReadInt(b2, "uid", 0, ref isInvalid);
							data.PJADHDHKOEJ[j].PPFNGGCBJKC_id = CJAENOMGPDA_ReadInt(b2, "id", 0, ref isInvalid);
							data.PJADHDHKOEJ[j].DIAPHCJBPFD_Get = CJAENOMGPDA_ReadInt(b2, "get", 0, ref isInvalid);
							data.PJADHDHKOEJ[j].IOLJPHAOBOH_Use = CJAENOMGPDA_ReadInt(b2, "use", 0, ref isInvalid);
							data.PJADHDHKOEJ[j].DOJDOLDDBPP_Hav = CJAENOMGPDA_ReadInt(b2, "hav", 0, ref isInvalid);
							data.NPNNEDINOKC[j].ODDIHGPONFL_Copy(data.PJADHDHKOEJ[j]);
						}
					}
				}
			}
			KFKDMBPNLJK_BlockInvalid = isInvalid;
			return true;
		}
		return false;
	}

	// // RVA: 0x16BBC30 Offset: 0x16BBC30 VA: 0x16BBC30 Slot: 7
	public override void BMGGKONLFIC_Copy(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		GEGHOCKCKKA_LimitedCompoItem l = GPBJHKLFCEP as GEGHOCKCKKA_LimitedCompoItem;
		for(int i = 0; i < ODHBHOGFNAA.Count; i++)
		{
			for(int j = 0; j < ODHBHOGFNAA[i].PJADHDHKOEJ.Count; j++)
			{
				ODHBHOGFNAA[i].PJADHDHKOEJ[j].ODDIHGPONFL_Copy(l.ODHBHOGFNAA[i].PJADHDHKOEJ[j]);
				ODHBHOGFNAA[i].NPNNEDINOKC[j].ODDIHGPONFL_Copy(l.ODHBHOGFNAA[i].NPNNEDINOKC[j]);
			}
		}
	}

	// // RVA: 0x16BC060 Offset: 0x16BC060 VA: 0x16BC060 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		GEGHOCKCKKA_LimitedCompoItem other = GPBJHKLFCEP as GEGHOCKCKKA_LimitedCompoItem;
		for(int i = 0; i < ODHBHOGFNAA.Count; i++)
		{
			if(ODHBHOGFNAA[i].PJADHDHKOEJ.Count != other.ODHBHOGFNAA[i].PJADHDHKOEJ.Count)
				return false;
			for(int j = 0; j < ODHBHOGFNAA[i].PJADHDHKOEJ.Count; j++)
			{
				if(!ODHBHOGFNAA[i].PJADHDHKOEJ[j].AGBOGBEOFME(other.ODHBHOGFNAA[i].PJADHDHKOEJ[j]))
					return false;
				if(!ODHBHOGFNAA[i].NPNNEDINOKC[j].AGBOGBEOFME(other.ODHBHOGFNAA[i].NPNNEDINOKC[j]))
					return false;
			}
		}
		return true;
	}

	// // RVA: 0x16BC748 Offset: 0x16BC748 VA: 0x16BC748 Slot: 11
	public override FENCAJJBLBH PFAKPFKJJKA()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "TODO");
		return null;
	}
}
