
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
			public int EHOIENNDEDH; // 0xC
			public int JECIEFEOBDO; // 0x10
			public int FBGGEFFJJHB; // 0x14
			public int DJJOKAOHAML; // 0x18
			public int DADJGIPLGBK; // 0x1C

			public int PPFNGGCBJKC_Id { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0x16BB5F0 DEMEPMAEJOO 0x16BBAEC HIGKAIDMOKN
			public int PGPGPJNBIOH_Uid { get { return CNGMGFCGLOK ^ FBGGEFFJJHB; } set { CNGMGFCGLOK = value ^ FBGGEFFJJHB; } } //0x16B98C4 CJEDGLPDJBN 0x16BBADC EKJKPIKJLJJ
			public int DOJDOLDDBPP_Hav { get { return DJJOKAOHAML ^ FBGGEFFJJHB; } set { DJJOKAOHAML = value ^ FBGGEFFJJHB; } } //0x16BB610 FHJFILKDGGO 0x16BBB1C DEEAELHLIEC
			public int DIAPHCJBPFD_Get { get { return JECIEFEOBDO ^ FBGGEFFJJHB; } set { JECIEFEOBDO = value ^ FBGGEFFJJHB; } } //0x16B98B4 EIEMCCANNJE 0x16BBAFC JLGBEBCNDJN
			public int IOLJPHAOBOH_Use { get { return DADJGIPLGBK ^ FBGGEFFJJHB; } set { DADJGIPLGBK = value ^ FBGGEFFJJHB; } } //0x16BB600 EHKEMJJNKKI 0x16BBB0C GHMCNDFEFIF
			public int HNKFMAJIFJD { get {
					DateTime date = Utility.GetLocalDateTime(EDLLKJAKIGO(PPFNGGCBJKC_Id, DIAPHCJBPFD_Get) + DIAPHCJBPFD_Get);
					return (int)Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, 23, 59, 59);
				} } //0x16B91A4 CEOIBKAGPAG
			private long OLNKAECIGJH { get { return Utility.GetTargetUnixTime(2030, 1, 1, 0, 0, 0); } } //0x16BD4AC GBAOINLDCEM

			//// RVA: 0x16BD368 Offset: 0x16BD368 VA: 0x16BD368
			private int EDLLKJAKIGO(int PPFNGGCBJKC, long JHNMKKNEENE)
			{
				int t = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MBAGKLJDKMH_LimitedCompoItem.OCMMLAOEPIG[PPFNGGCBJKC - 1].EMIJNAFJFJO;
				if (t * 0x15180 != 0)
					return t * 0x15180;
				return (int)OLNKAECIGJH - (int)JHNMKKNEENE;
			}

			//// RVA: 0x16B88F4 Offset: 0x16B88F4 VA: 0x16B88F4
			public bool NIENPFFLMCH(long JHNMKKNEENE)
			{
				if(DOJDOLDDBPP_Hav == 1)
				{
					if (JHNMKKNEENE >= DIAPHCJBPFD_Get)
						return HNKFMAJIFJD >= JHNMKKNEENE;
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
				CNGMGFCGLOK = CNGMGFCGLOK ^ KNEFBLHBDBG ^ FBGGEFFJJHB;
				EHOIENNDEDH = EHOIENNDEDH ^ KNEFBLHBDBG ^ FBGGEFFJJHB;
				JECIEFEOBDO = JECIEFEOBDO ^ KNEFBLHBDBG ^ FBGGEFFJJHB;
				DADJGIPLGBK = DADJGIPLGBK ^ KNEFBLHBDBG ^ FBGGEFFJJHB;
				DJJOKAOHAML = DJJOKAOHAML ^ KNEFBLHBDBG ^ FBGGEFFJJHB;
				FBGGEFFJJHB = KNEFBLHBDBG;
			}

			//// RVA: 0x16BAF20 Offset: 0x16BAF20 VA: 0x16BAF20
			//public void LHPDDGIJKNB(int KNEFBLHBDBG) { }

			//// RVA: 0x16B98D4 Offset: 0x16B98D4 VA: 0x16B98D4
			//public void HPFJOBPMNCP(int KNEFBLHBDBG, int PGPGPJNBIOH, int PPFNGGCBJKC, long JHNMKKNEENE) { }

			//// RVA: 0x16B9DE8 Offset: 0x16B9DE8 VA: 0x16B9DE8
			public void PKAINJJBMMH_ChangeKeyAndSetTime(int KNEFBLHBDBG, long KNCKIJBOODM)
			{
				CNGMGFCGLOK = CNGMGFCGLOK ^ KNEFBLHBDBG ^ FBGGEFFJJHB;
				EHOIENNDEDH = EHOIENNDEDH ^ KNEFBLHBDBG ^ FBGGEFFJJHB;
				JECIEFEOBDO = JECIEFEOBDO ^ KNEFBLHBDBG ^ FBGGEFFJJHB;
				FBGGEFFJJHB = KNEFBLHBDBG;
				DADJGIPLGBK = 0;
				DJJOKAOHAML = (int)KNCKIJBOODM;
			}

			//// RVA: 0x16BBB2C Offset: 0x16BBB2C VA: 0x16BBB2C
			public void ODDIHGPONFL(AGGJCJMIIMJ GPBJHKLFCEP)
			{
				PGPGPJNBIOH_Uid = GPBJHKLFCEP.PGPGPJNBIOH_Uid;
				PPFNGGCBJKC_Id = GPBJHKLFCEP.PPFNGGCBJKC_Id;
				DIAPHCJBPFD_Get = GPBJHKLFCEP.DIAPHCJBPFD_Get;
				IOLJPHAOBOH_Use = GPBJHKLFCEP.IOLJPHAOBOH_Use;
				DOJDOLDDBPP_Hav = GPBJHKLFCEP.DOJDOLDDBPP_Hav;
			}

			//// RVA: 0x16BC5C8 Offset: 0x16BC5C8 VA: 0x16BC5C8
			public bool AGBOGBEOFME(AGGJCJMIIMJ OIKJFMGEICL)
			{
				if(PGPGPJNBIOH_Uid != OIKJFMGEICL.PGPGPJNBIOH_Uid ||
					PPFNGGCBJKC_Id != OIKJFMGEICL.PPFNGGCBJKC_Id ||
					DIAPHCJBPFD_Get != OIKJFMGEICL.DIAPHCJBPFD_Get ||
					IOLJPHAOBOH_Use != OIKJFMGEICL.IOLJPHAOBOH_Use ||
					DOJDOLDDBPP_Hav != OIKJFMGEICL.DOJDOLDDBPP_Hav)
					return false;
				return true;
			}

			//// RVA: 0x16BD5AC Offset: 0x16BD5AC VA: 0x16BD5AC
			//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, GEGHOCKCKKA.AIAPDPDOIKG.AGGJCJMIIMJ OHMCIEMIKCE, bool KFCGIKHEEMB) { }
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
            JHAAHJNEBOG_LimitedCompoItem.JMJKJFKAFCJ item = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MBAGKLJDKMH_LimitedCompoItem.CDENCMNHNGA[PENIOLJHIPK - 1];
            if (item.DODGLIDGBBC == 1)
			{
				if(NHPDPKHMFEP.HHCJCDFCLOB != null && 
					NHPDPKHMFEP.HHCJCDFCLOB.GBCPDBJEDHL(false) && 
					NHPDPKHMFEP.HHCJCDFCLOB.ENAAHAPDMCO())
				{
					return item.HHGFOIMIGED;
				}
			}
			return item.DOOGFEGEKLG;
		}

		//// RVA: 0x16BCF64 Offset: 0x16BCF64 VA: 0x16BCF64
		public int LFOEBPPAAFJ(int PPFNGGCBJKC, long JHNMKKNEENE)
		{
			int cnt = 0;
			for(int i = 0; i < PJADHDHKOEJ.Count; i++)
			{
				if(PJADHDHKOEJ[i].PPFNGGCBJKC_Id == PPFNGGCBJKC)
				{
					cnt += PJADHDHKOEJ[i].NIENPFFLMCH(JHNMKKNEENE) ? 1 : 0;
				}
			}
			return cnt;
		}

		//// RVA: 0x16BD0C4 Offset: 0x16BD0C4 VA: 0x16BD0C4
		//public void PKAINJJBMMH(int PPFNGGCBJKC, long KNCKIJBOODM) { }
	}


	private const int ECFEMKGFDCE = 1;
	public const int HAKDOMMLLJP = 99999999;
	public List<AIAPDPDOIKG> ODHBHOGFNAA = new List<AIAPDPDOIKG>(); // 0x24

	public override bool DMICHEJIAJL { get { return false; } } // 0x16BC740 NFKFOODCJJB

	// // RVA: 0x16B869C Offset: 0x16B869C VA: 0x16B869C
	public int HPPKOGKNKMH(int PPFNGGCBJKC, long JHNMKKNEENE)
	{
		if (PPFNGGCBJKC < 1)
			return 0;
		int res = 0;
		int a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MBAGKLJDKMH_LimitedCompoItem.OCMMLAOEPIG[PPFNGGCBJKC - 1].PENIOLJHIPK;
		for(int i = 0; i < ODHBHOGFNAA[a - 1].HFAHJPBLCHK; i++)
		{
			res += (ODHBHOGFNAA[a - 1].PJADHDHKOEJ[i].NIENPFFLMCH(JHNMKKNEENE) && ODHBHOGFNAA[a - 1].NPNNEDINOKC[i].NIENPFFLMCH(JHNMKKNEENE)) ? 1 : 0;
		}
		return res;
	}

	// // RVA: 0x16B8958 Offset: 0x16B8958 VA: 0x16B8958
	public int OPCIHPEIFFE(int PPFNGGCBJKC)
	{
		if(PPFNGGCBJKC < 1)
			return 0;
		int a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MBAGKLJDKMH_LimitedCompoItem.OCMMLAOEPIG[PPFNGGCBJKC - 1].PENIOLJHIPK;
		return ODHBHOGFNAA[a - 1].OPCIHPEIFFE();
	}

	// // RVA: 0x16B8CB8 Offset: 0x16B8CB8 VA: 0x16B8CB8
	// public int MOAPEHACGDN(int PPFNGGCBJKC, long JHNMKKNEENE) { }

	// // RVA: 0x16B8E6C Offset: 0x16B8E6C VA: 0x16B8E6C
	public int BLKPKBICPKK(int PPFNGGCBJKC, long JHNMKKNEENE)
	{
		if (PPFNGGCBJKC < 1)
			return 0;
		AIAPDPDOIKG a = ODHBHOGFNAA[IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MBAGKLJDKMH_LimitedCompoItem.OCMMLAOEPIG[PPFNGGCBJKC - 1].PENIOLJHIPK - 1];
		int c = int.MaxValue;
		for(int i = 0; i < a.HFAHJPBLCHK; i++)
		{
			if(a.PJADHDHKOEJ[i].NIENPFFLMCH(JHNMKKNEENE) && a.PJADHDHKOEJ[i].NIENPFFLMCH(JHNMKKNEENE))
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
	public int CPIICACGNBH(int PPFNGGCBJKC, long JHNMKKNEENE, bool DDGFCOPPBBN = false)
	{
		if(PPFNGGCBJKC > 0)
		{
			JHAAHJNEBOG_LimitedCompoItem limitedDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MBAGKLJDKMH_LimitedCompoItem;
			int a = limitedDb.OCMMLAOEPIG[PPFNGGCBJKC - 1].PENIOLJHIPK;
			AIAPDPDOIKG data = ODHBHOGFNAA[a - 1];
			int MinGet = int.MaxValue;
			int MaxUid = int.MinValue;
			int MinGetIdx = -1;
			for(int i = 0; i < data.HFAHJPBLCHK; i++)
			{
				if(!data.PJADHDHKOEJ[i].NIENPFFLMCH(JHNMKKNEENE))
				{
					if(data.PJADHDHKOEJ[i].DIAPHCJBPFD_Get <= MinGet)
					{
						MinGet = data.PJADHDHKOEJ[i].DIAPHCJBPFD_Get;
						MinGetIdx = i;
					}
				}
				if(data.PJADHDHKOEJ[i].PGPGPJNBIOH_Uid > MaxUid)
				{
					MaxUid = data.PJADHDHKOEJ[i].PGPGPJNBIOH_Uid;
				}
			}
			if(MinGetIdx > -1)
			{
				MaxUid++;
				if (MaxUid > 99999999)
					MaxUid = 1;
				if (DDGFCOPPBBN)
				{
					return limitedDb.OCMMLAOEPIG[PPFNGGCBJKC - 1].EMIJNAFJFJO + (int)JHNMKKNEENE;
				}
				AIAPDPDOIKG.AGGJCJMIIMJ data2 = data.PJADHDHKOEJ[MinGetIdx];
				data2.FBGGEFFJJHB = (int)JHNMKKNEENE * 0x2e7;
				data2.PGPGPJNBIOH_Uid = MaxUid;
				data2.PPFNGGCBJKC_Id = PPFNGGCBJKC;
				data2.DIAPHCJBPFD_Get = (int)JHNMKKNEENE;
				data2.DOJDOLDDBPP_Hav = 1;
				data2.IOLJPHAOBOH_Use = 0;

				data2 = data.NPNNEDINOKC[MinGetIdx];
				data2.FBGGEFFJJHB = (int)JHNMKKNEENE * 0x540545;
				data2.PGPGPJNBIOH_Uid = MaxUid;
				data2.PPFNGGCBJKC_Id = PPFNGGCBJKC;
				data2.DIAPHCJBPFD_Get = (int)JHNMKKNEENE;
				data2.DOJDOLDDBPP_Hav = 1;
				data2.IOLJPHAOBOH_Use = 0;

				return data.PJADHDHKOEJ[MinGetIdx].HNKFMAJIFJD;
			}
		}
		return 0;
	}

	// // RVA: 0x16B990C Offset: 0x16B990C VA: 0x16B990C
	public List<int> BHNDPHCBCKN(int PPFNGGCBJKC, long JHNMKKNEENE)
	{
		List<int> res = new List<int>();
		if(PPFNGGCBJKC > 0)
		{
			JHAAHJNEBOG_LimitedCompoItem.AOBHKONKIPF c = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MBAGKLJDKMH_LimitedCompoItem.OCMMLAOEPIG[PPFNGGCBJKC - 1];
			AIAPDPDOIKG COCEIPAKJKF = ODHBHOGFNAA[c.PENIOLJHIPK - 1];
			for(int i = 0; i < COCEIPAKJKF.HFAHJPBLCHK; i++)
			{
				AIAPDPDOIKG.AGGJCJMIIMJ a2 = COCEIPAKJKF.PJADHDHKOEJ[i];
				if(a2.NIENPFFLMCH(JHNMKKNEENE))
				{
					res.Add(i);
				}
			}
			res.Sort((int HKICMNAACDA, int BNKHBCBJBKI) =>
			{
				//0x1801D50
				return COCEIPAKJKF.PJADHDHKOEJ[HKICMNAACDA].PGPGPJNBIOH_Uid.CompareTo(COCEIPAKJKF.PJADHDHKOEJ[BNKHBCBJBKI].PGPGPJNBIOH_Uid);
			});
		}
		return res;
	}

	// // RVA: 0x16B9C2C Offset: 0x16B9C2C VA: 0x16B9C2C
	public bool LLOAMEOCJEO(int PENIOLJHIPK, int OIPCCBHIKIA, long KNCKIJBOODM)
	{
		if (PENIOLJHIPK < 1)
			return false;
		AIAPDPDOIKG a = ODHBHOGFNAA[PENIOLJHIPK - 1];
		a.PJADHDHKOEJ[OIPCCBHIKIA].PKAINJJBMMH_ChangeKeyAndSetTime((int)(KNCKIJBOODM * 0x2e5), KNCKIJBOODM);
		a.NPNNEDINOKC[OIPCCBHIKIA].PKAINJJBMMH_ChangeKeyAndSetTime((int)(KNCKIJBOODM * 0x100b57), KNCKIJBOODM);
		return true;
	}

	// // RVA: 0x16B9E30 Offset: 0x16B9E30 VA: 0x16B9E30
	public List<NKFJNAANPNP.MOJLCADLMKH> BNGLMLIMFDM(int PPFNGGCBJKC, long JHNMKKNEENE)
	{
		List<NKFJNAANPNP.MOJLCADLMKH> res = new List<NKFJNAANPNP.MOJLCADLMKH>();
		if (PPFNGGCBJKC > 0)
		{
			JHAAHJNEBOG_LimitedCompoItem.AOBHKONKIPF litem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MBAGKLJDKMH_LimitedCompoItem.OCMMLAOEPIG[PPFNGGCBJKC - 1];
			List<NKFJNAANPNP.MOJLCADLMKH> l2 = new List<NKFJNAANPNP.MOJLCADLMKH>();
			for(int i = 0; i < ODHBHOGFNAA[litem.PENIOLJHIPK].PJADHDHKOEJ.Count; i++)
			{
				AIAPDPDOIKG.AGGJCJMIIMJ item = ODHBHOGFNAA[litem.PENIOLJHIPK].PJADHDHKOEJ[i];
				if(item.NIENPFFLMCH(JHNMKKNEENE))
				{
					if(!item.GIBLKLLLHFP())
					{
						NKFJNAANPNP.MOJLCADLMKH data = new NKFJNAANPNP.MOJLCADLMKH();
						data.LHPDDGIJKNB((int)(JHNMKKNEENE * 0x227));
						data.HNKFMAJIFJD_ExpireAt = item.HNKFMAJIFJD;
						data.HMFFHLPNMPH_Remaining = 1;
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
					r.HMFFHLPNMPH_Remaining += l2[i].HMFFHLPNMPH_Remaining;
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
			for(int i = 0; i < limitedDb.CDENCMNHNGA.Count; i++)
			{
				JHAAHJNEBOG_LimitedCompoItem.JMJKJFKAFCJ info = limitedDb.CDENCMNHNGA[i];
				AIAPDPDOIKG data = new AIAPDPDOIKG(Mathf.Max(info.DOOGFEGEKLG, info.HHGFOIMIGED), i + 1);
				ODHBHOGFNAA.Add(data);
			}
		}
	}

	// // RVA: 0x16BAB98 Offset: 0x16BAB98 VA: 0x16BAB98 Slot: 4
	public override void KMBPACJNEOF()
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
				data2.FBGGEFFJJHB = k;
				data2.DOJDOLDDBPP_Hav = 0;
				data2.IOLJPHAOBOH_Use = 0;
				data2.PGPGPJNBIOH_Uid = 0;
				data2.PPFNGGCBJKC_Id = 0;
				data2.DIAPHCJBPFD_Get = 0;
				data.PJADHDHKOEJ.Add(data2);
				k *= 0xb;
			}
			for (int j = 0; j < data.HFAHJPBLCHK; j++)
			{
				AIAPDPDOIKG.AGGJCJMIIMJ data2 = new AIAPDPDOIKG.AGGJCJMIIMJ();
				data2.FBGGEFFJJHB = k;
				data2.DOJDOLDDBPP_Hav = 0;
				data2.IOLJPHAOBOH_Use = 0;
				data2.PGPGPJNBIOH_Uid = 0;
				data2.PPFNGGCBJKC_Id = 0;
				data2.DIAPHCJBPFD_Get = 0;
				data.NPNNEDINOKC.Add(data2);
				k *= 0xb;
			}
		}
	}

	// // RVA: 0x16BAF38 Offset: 0x16BAF38 VA: 0x16BAF38 Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		for(int i = 0; i < ODHBHOGFNAA.Count; i++)
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			for(int j = 0; j < ODHBHOGFNAA[i].PJADHDHKOEJ.Count; j++)
			{
				EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
				data3["uid"] = ODHBHOGFNAA[i].PJADHDHKOEJ[j].PGPGPJNBIOH_Uid;
				data3["id"] = ODHBHOGFNAA[i].PJADHDHKOEJ[j].PPFNGGCBJKC_Id;
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
			data2[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = MCKEOKFMLAH;
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
							data.PJADHDHKOEJ[j].PGPGPJNBIOH_Uid = CJAENOMGPDA_ReadInt(b2, "uid", 0, ref isInvalid);
							data.PJADHDHKOEJ[j].PPFNGGCBJKC_Id = CJAENOMGPDA_ReadInt(b2, "id", 0, ref isInvalid);
							data.PJADHDHKOEJ[j].DIAPHCJBPFD_Get = CJAENOMGPDA_ReadInt(b2, "get", 0, ref isInvalid);
							data.PJADHDHKOEJ[j].IOLJPHAOBOH_Use = CJAENOMGPDA_ReadInt(b2, "use", 0, ref isInvalid);
							data.PJADHDHKOEJ[j].DOJDOLDDBPP_Hav = CJAENOMGPDA_ReadInt(b2, "hav", 0, ref isInvalid);
							data.NPNNEDINOKC[j].ODDIHGPONFL(data.PJADHDHKOEJ[j]);
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
	public override void BMGGKONLFIC(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		GEGHOCKCKKA_LimitedCompoItem l = GPBJHKLFCEP as GEGHOCKCKKA_LimitedCompoItem;
		for(int i = 0; i < ODHBHOGFNAA.Count; i++)
		{
			for(int j = 0; j < ODHBHOGFNAA[i].PJADHDHKOEJ.Count; j++)
			{
				ODHBHOGFNAA[i].PJADHDHKOEJ[j].ODDIHGPONFL(l.ODHBHOGFNAA[i].PJADHDHKOEJ[j]);
				ODHBHOGFNAA[i].NPNNEDINOKC[j].ODDIHGPONFL(l.ODHBHOGFNAA[i].NPNNEDINOKC[j]);
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
