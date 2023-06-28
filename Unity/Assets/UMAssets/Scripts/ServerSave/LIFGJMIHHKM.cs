
using System;
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use LIFGJMIHHKM_LimitedItem", true)]
public class LIFGJMIHHKM { }
public class LIFGJMIHHKM_LimitedItem : KLFDBFMNLBL_ServerSaveBlock
{
	public class DOPNDKHMMGI
	{
		public class EFHFKNHFNID
		{
			public int LHKBIALMLCP; // 0x8
			public int CNGMGFCGLOK; // 0xC
			public int JECIEFEOBDO; // 0x10
			public int FBGGEFFJJHB; // 0x14
			public int DJJOKAOHAML; // 0x18
			public int DADJGIPLGBK; // 0x1C

			public int NLMAIPMAHMN { get { return LHKBIALMLCP ^ FBGGEFFJJHB; } set { LHKBIALMLCP = value ^ FBGGEFFJJHB; } } //0x1801E8C AFJLHNHNMKN 0x1801E9C HONPMOAKOGO
			public int PGPGPJNBIOH_Uid { get { return CNGMGFCGLOK ^ FBGGEFFJJHB; } set { CNGMGFCGLOK = value ^ FBGGEFFJJHB; } } //0x17FEB68 CJEDGLPDJBN 0x1800A9C EKJKPIKJLJJ
			public int DOJDOLDDBPP_Hav { get { return DJJOKAOHAML ^ FBGGEFFJJHB; } set { DJJOKAOHAML = value ^ FBGGEFFJJHB; } } //0x1800624 FHJFILKDGGO 0x1800ACC DEEAELHLIEC
			public int DIAPHCJBPFD_Get { get { return JECIEFEOBDO ^ FBGGEFFJJHB; } set { JECIEFEOBDO = value ^ FBGGEFFJJHB; } } //0x17FEB58 EIEMCCANNJE 0x1800AAC JLGBEBCNDJN
			public int IOLJPHAOBOH_Use { get { return DADJGIPLGBK ^ FBGGEFFJJHB; } set { DADJGIPLGBK = value ^ FBGGEFFJJHB; } } //0x1800614 EHKEMJJNKKI 0x1800ABC GHMCNDFEFIF
			public int HNKFMAJIFJD_ExpireAt { get {
					DateTime date = Utility.GetLocalDateTime(NLMAIPMAHMN + DIAPHCJBPFD_Get);
					return (int)Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, 23, 59, 59);
				} } //0x17FE608 CEOIBKAGPAG

			//// RVA: 0x17FE280 Offset: 0x17FE280 VA: 0x17FE280
			public bool NIENPFFLMCH(long JHNMKKNEENE)
			{
				return DOJDOLDDBPP_Hav == 1 && JHNMKKNEENE >= DIAPHCJBPFD_Get && HNKFMAJIFJD_ExpireAt >= JHNMKKNEENE;
			}

			//// RVA: 0x1801EAC Offset: 0x1801EAC VA: 0x1801EAC
			//public void DNBGDMBCLMI(int KNEFBLHBDBG) { }

			//// RVA: 0x17FFF90 Offset: 0x17FFF90 VA: 0x17FFF90
			//public void LHPDDGIJKNB(int KNEFBLHBDBG, int JKPPKAHPPKH) { }

			//// RVA: 0x17FEB78 Offset: 0x17FEB78 VA: 0x17FEB78
			public void HPFJOBPMNCP(int KNEFBLHBDBG, int PGPGPJNBIOH, long JHNMKKNEENE)
			{
				LHKBIALMLCP = LHKBIALMLCP ^ KNEFBLHBDBG ^ FBGGEFFJJHB;
				CNGMGFCGLOK = KNEFBLHBDBG ^ PGPGPJNBIOH;
				JECIEFEOBDO = (int)JHNMKKNEENE ^ KNEFBLHBDBG;
				FBGGEFFJJHB = KNEFBLHBDBG;
				DJJOKAOHAML = KNEFBLHBDBG ^ 1;
				DADJGIPLGBK = KNEFBLHBDBG;
			}

			//// RVA: 0x17FEFC4 Offset: 0x17FEFC4 VA: 0x17FEFC4
			public void PKAINJJBMMH_ChangeKeyAndSetDate(int KNEFBLHBDBG, long KNCKIJBOODM)
			{
				LHKBIALMLCP = LHKBIALMLCP ^ KNEFBLHBDBG ^ FBGGEFFJJHB;
				CNGMGFCGLOK = CNGMGFCGLOK ^ KNEFBLHBDBG ^ FBGGEFFJJHB;
				JECIEFEOBDO = JECIEFEOBDO ^ KNEFBLHBDBG ^ FBGGEFFJJHB;
				FBGGEFFJJHB = KNEFBLHBDBG;
				DOJDOLDDBPP_Hav = 0;
				IOLJPHAOBOH_Use = KNEFBLHBDBG;
			}

			//// RVA: 0x1800ADC Offset: 0x1800ADC VA: 0x1800ADC
			public void ODDIHGPONFL(EFHFKNHFNID GPBJHKLFCEP)
			{
				PGPGPJNBIOH_Uid = GPBJHKLFCEP.PGPGPJNBIOH_Uid;
				DIAPHCJBPFD_Get = GPBJHKLFCEP.DIAPHCJBPFD_Get;
				IOLJPHAOBOH_Use = GPBJHKLFCEP.IOLJPHAOBOH_Use;
				DOJDOLDDBPP_Hav = GPBJHKLFCEP.DOJDOLDDBPP_Hav;
			}

			//// RVA: 0x180153C Offset: 0x180153C VA: 0x180153C
			public bool AGBOGBEOFME(EFHFKNHFNID OIKJFMGEICL)
			{
				if(PGPGPJNBIOH_Uid != OIKJFMGEICL.PGPGPJNBIOH_Uid ||
					DIAPHCJBPFD_Get != OIKJFMGEICL.DIAPHCJBPFD_Get ||
					IOLJPHAOBOH_Use != OIKJFMGEICL.IOLJPHAOBOH_Use ||
					DOJDOLDDBPP_Hav != OIKJFMGEICL.DOJDOLDDBPP_Hav)
					return false;
				return true;
			}

			//// RVA: 0x1801F0C Offset: 0x1801F0C VA: 0x1801F0C
			//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, LIFGJMIHHKM.DOPNDKHMMGI.EFHFKNHFNID OHMCIEMIKCE, bool KFCGIKHEEMB) { }
		}
		public int MAHLPMJFLLJ; // 0x8
		public int NLMAIPMAHMN; // 0xC
		public List<EFHFKNHFNID> PJADHDHKOEJ = new List<EFHFKNHFNID>(); // 0x10
		public List<EFHFKNHFNID> NPNNEDINOKC = new List<EFHFKNHFNID>(); // 0x14

		// RVA: 0x17FFBB8 Offset: 0x17FFBB8 VA: 0x17FFBB8
		public DOPNDKHMMGI(int DOOGFEGEKLG, int JKPPKAHPPKH)
		{
			MAHLPMJFLLJ = DOOGFEGEKLG;
			NLMAIPMAHMN = JKPPKAHPPKH;
		}
	}

	private const int ECFEMKGFDCE = 2;
	public const int HAKDOMMLLJP = 99999999;
	public List<DOPNDKHMMGI> ODHBHOGFNAA = new List<DOPNDKHMMGI>(); // 0x24

	public override bool DMICHEJIAJL { get { return false; } } // 0x1801664 NFKFOODCJJB

	// // RVA: 0x17FE0E8 Offset: 0x17FE0E8 VA: 0x17FE0E8
	public int HPPKOGKNKMH(int PPFNGGCBJKC, long JHNMKKNEENE)
	{
		if (PPFNGGCBJKC < 1)
			return 0;
		int res = 0;
		for(int i = 0; i < ODHBHOGFNAA[PPFNGGCBJKC - 1].MAHLPMJFLLJ; i++)
		{
			res += (ODHBHOGFNAA[PPFNGGCBJKC - 1].PJADHDHKOEJ[i].NIENPFFLMCH(JHNMKKNEENE) && ODHBHOGFNAA[PPFNGGCBJKC - 1].NPNNEDINOKC[i].NIENPFFLMCH(JHNMKKNEENE)) ? 1 : 0;
		}
		return res;
	}

	// // RVA: 0x17FE2DC Offset: 0x17FE2DC VA: 0x17FE2DC
	// public int MOAPEHACGDN(int PPFNGGCBJKC, long JHNMKKNEENE) { }

	// // RVA: 0x17FE3AC Offset: 0x17FE3AC VA: 0x17FE3AC
	public int BLKPKBICPKK(int PPFNGGCBJKC, long JHNMKKNEENE)
	{
		if (PPFNGGCBJKC < 1)
			return 0;
		DOPNDKHMMGI l = ODHBHOGFNAA[PPFNGGCBJKC - 1];
		int res = -1;
		for(int i = 0; i < l.MAHLPMJFLLJ; i++)
		{
			if(l.PJADHDHKOEJ[i].NIENPFFLMCH(JHNMKKNEENE) || l.NPNNEDINOKC[i].NIENPFFLMCH(JHNMKKNEENE))
			{
				if(l.PJADHDHKOEJ[i].HNKFMAJIFJD_ExpireAt < res)
				{
					res = l.PJADHDHKOEJ[i].HNKFMAJIFJD_ExpireAt;
				}
			}
		}
		if (res == -1)
			res = 0;
		return res;
	}

	// // RVA: 0x17FE71C Offset: 0x17FE71C VA: 0x17FE71C
	public int CPIICACGNBH(int PPFNGGCBJKC, long JHNMKKNEENE, bool DDGFCOPPBBN = false)
	{
		if(PPFNGGCBJKC > 0)
		{
			int index = ODHBHOGFNAA[PPFNGGCBJKC - 1].MAHLPMJFLLJ;
			int b = int.MaxValue;
			int c = -1;
			int d = -1;
			for(; index > -1; index--)
			{
				if(!ODHBHOGFNAA[PPFNGGCBJKC - 1].PJADHDHKOEJ[index].NIENPFFLMCH(JHNMKKNEENE))
				{
					if(ODHBHOGFNAA[PPFNGGCBJKC - 1].PJADHDHKOEJ[index].DIAPHCJBPFD_Get <= b)
					{
						b = ODHBHOGFNAA[PPFNGGCBJKC - 1].PJADHDHKOEJ[index].DIAPHCJBPFD_Get;
						d = index;
					}
				}
				if(ODHBHOGFNAA[PPFNGGCBJKC - 1].PJADHDHKOEJ[index].PGPGPJNBIOH_Uid > c)
				{
					c = ODHBHOGFNAA[PPFNGGCBJKC - 1].PJADHDHKOEJ[index].PGPGPJNBIOH_Uid;
				}
			}
			if(d > -1)
			{
				c++;
				if (c > 99999999)
					c = 1;
				if (DDGFCOPPBBN)
					return (int)(ODHBHOGFNAA[PPFNGGCBJKC - 1].NLMAIPMAHMN + JHNMKKNEENE);
				ODHBHOGFNAA[PPFNGGCBJKC - 1].PJADHDHKOEJ[d].HPFJOBPMNCP((int)(JHNMKKNEENE * 0x2e7), c, JHNMKKNEENE);
				ODHBHOGFNAA[PPFNGGCBJKC - 1].NPNNEDINOKC[d].HPFJOBPMNCP((int)(JHNMKKNEENE * 0x540545), c, JHNMKKNEENE);
				return ODHBHOGFNAA[PPFNGGCBJKC - 1].PJADHDHKOEJ[d].HNKFMAJIFJD_ExpireAt;
			}
		}
		return 0;
	}

	// // RVA: 0x17FEBBC Offset: 0x17FEBBC VA: 0x17FEBBC
	public List<int> BHNDPHCBCKN(int PPFNGGCBJKC, long JHNMKKNEENE)
	{
		List<int> res = new List<int>();
		if (PPFNGGCBJKC > 0)
		{
			DOPNDKHMMGI COCEIPAKJKF = ODHBHOGFNAA[PPFNGGCBJKC - 1];
			for(int i = 0; i < COCEIPAKJKF.MAHLPMJFLLJ; i++)
			{
				if(COCEIPAKJKF.PJADHDHKOEJ[i].NIENPFFLMCH(JHNMKKNEENE))
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

	// // RVA: 0x17FEE08 Offset: 0x17FEE08 VA: 0x17FEE08
	public bool LLOAMEOCJEO(int PPFNGGCBJKC, int OIPCCBHIKIA, long KNCKIJBOODM)
	{
		if (PPFNGGCBJKC < 1)
			return false;
		DOPNDKHMMGI d = ODHBHOGFNAA[PPFNGGCBJKC - 1];
		d.PJADHDHKOEJ[OIPCCBHIKIA].PKAINJJBMMH_ChangeKeyAndSetDate((int)(KNCKIJBOODM * 0x2e5), KNCKIJBOODM);
		d.NPNNEDINOKC[OIPCCBHIKIA].PKAINJJBMMH_ChangeKeyAndSetDate((int)(KNCKIJBOODM * 0x100b57), KNCKIJBOODM);
		return true;
	}

	// // RVA: 0x17FF00C Offset: 0x17FF00C VA: 0x17FF00C
	public List<NKFJNAANPNP.MOJLCADLMKH> BNGLMLIMFDM(int PPFNGGCBJKC, long JHNMKKNEENE)
	{
		List<NKFJNAANPNP.MOJLCADLMKH> res = new List<NKFJNAANPNP.MOJLCADLMKH>();
		if(PPFNGGCBJKC > 0)
		{
			List<NKFJNAANPNP.MOJLCADLMKH> l2 = new List<NKFJNAANPNP.MOJLCADLMKH>();
			for(int i = 0; i < ODHBHOGFNAA[PPFNGGCBJKC - 1].PJADHDHKOEJ.Count; i++)
			{
				DOPNDKHMMGI.EFHFKNHFNID item = ODHBHOGFNAA[PPFNGGCBJKC - 1].PJADHDHKOEJ[i];
				if (item.NIENPFFLMCH(JHNMKKNEENE))
				{
					NKFJNAANPNP.MOJLCADLMKH data = new NKFJNAANPNP.MOJLCADLMKH();
					data.LHPDDGIJKNB((int)JHNMKKNEENE * 0x227);
					data.HNKFMAJIFJD_ExpireAt = item.HNKFMAJIFJD_ExpireAt;
					data.HMFFHLPNMPH_Remaining = 1;
					l2.Add(data);
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
					//0x1801A00
					DateTime date2 = Utility.GetLocalDateTime(JPAEDJJFFOI.HNKFMAJIFJD_ExpireAt);
					string str2 = string.Concat(new string[]
					{
						date2.Year.ToString(), date2.Month.ToString(), date2.Day.ToString(), date2.Hour.ToString(),
						date2.Minute.ToString()
					});
					return str == str2;
				});
				if(r == null)
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
				//0x1801990
				return HKICMNAACDA.HNKFMAJIFJD_ExpireAt.CompareTo(BNKHBCBJBKI.HNKFMAJIFJD_ExpireAt);
			});
		}
		return res;
	}

	// // RVA: 0x17FF8F4 Offset: 0x17FF8F4 VA: 0x17FF8F4
	public LIFGJMIHHKM_LimitedItem()
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			EGLOKAEIHCB_LimitedItem limitedDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IHPFCIJKFIC_LimitedItem;
			if(limitedDb.CDENCMNHNGA != null)
			{
				if(limitedDb.CDENCMNHNGA.Count == 0)
				{
					DOPNDKHMMGI data = new DOPNDKHMMGI(9, 0x278d00);
					ODHBHOGFNAA.Add(data);
					return;
				}
				for(int i = 0; i < limitedDb.CDENCMNHNGA.Count; i++)
				{
					DOPNDKHMMGI data = new DOPNDKHMMGI(limitedDb.CDENCMNHNGA[i].DOOGFEGEKLG_Max, limitedDb.CDENCMNHNGA[i].EMIJNAFJFJO * 0x15180);
					ODHBHOGFNAA.Add(data);
				}
			}
		}
	}

	// // RVA: 0x17FFC6C Offset: 0x17FFC6C VA: 0x17FFC6C Slot: 4
	public override void KMBPACJNEOF()
	{
		for(int i = 0; i < ODHBHOGFNAA.Count; i++)
		{
			DOPNDKHMMGI data = ODHBHOGFNAA[i];
			data.PJADHDHKOEJ.Clear();
			data.NPNNEDINOKC.Clear();
			int k = (int)Utility.GetCurrentUnixTime() * 0x6f;
			for(int j = 0; j < data.MAHLPMJFLLJ; j++)
			{
				DOPNDKHMMGI.EFHFKNHFNID data2 = new DOPNDKHMMGI.EFHFKNHFNID();
				data2.FBGGEFFJJHB = k;
				data2.IOLJPHAOBOH_Use = 0;
				data2.NLMAIPMAHMN = data.NLMAIPMAHMN;
				data2.PGPGPJNBIOH_Uid = 0;
				data2.DIAPHCJBPFD_Get = 0;
				data2.DOJDOLDDBPP_Hav = 0;
				data.PJADHDHKOEJ.Add(data2);
				k *= 0xb;
			}
			for (int j = 0; j < data.MAHLPMJFLLJ; j++)
			{
				DOPNDKHMMGI.EFHFKNHFNID data2 = new DOPNDKHMMGI.EFHFKNHFNID();
				data2.FBGGEFFJJHB = k;
				data2.IOLJPHAOBOH_Use = 0;
				data2.NLMAIPMAHMN = data.NLMAIPMAHMN;
				data2.PGPGPJNBIOH_Uid = 0;
				data2.DIAPHCJBPFD_Get = 0;
				data2.DOJDOLDDBPP_Hav = 0;
				data.NPNNEDINOKC.Add(data2);
				k *= 0xb;
			}
		}
	}

	// // RVA: 0x17FFFAC Offset: 0x17FFFAC VA: 0x17FFFAC Slot: 5
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
			data2[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] = 2;
			data = data2;
		}
		else
		{
			OILEIIEIBHP = OILEIIEIBHP[AFEHLCGHAEE_Strings.JCIBKDHKNFH_alldata];
		}
		OILEIIEIBHP[JIKKNHIAEKG_BlockName] = data;
	}

	// // RVA: 0x1800634 Offset: 0x1800634 VA: 0x1800634 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool blockMissing = false;
		bool isInvalid = false;
		EDOHBJAPLPF_JsonData block = LGPBAKLCFHI_FindAndCheckBlock(OILEIIEIBHP, ref blockMissing, ref isInvalid, 2);
		if (!blockMissing)
		{
			if (block == null)
			{
				isInvalid = true;
			}
			else
			{
				for(int i = 0; i < ODHBHOGFNAA.Count; i++)
				{
					string str = "_" + (i + 1).ToString();
					if(block.BBAJPINMOEP_Contains(str))
					{
						EDOHBJAPLPF_JsonData b = block[str];
						DOPNDKHMMGI data = ODHBHOGFNAA[i];
						if (b.HNBFOAJIIAL_Count != data.MAHLPMJFLLJ)
							isInvalid = true;
						int cnt = b.HNBFOAJIIAL_Count;
						if (data.MAHLPMJFLLJ < cnt)
							cnt = data.MAHLPMJFLLJ;
						for(int j = 0; j < cnt; j++)
						{
							EDOHBJAPLPF_JsonData b2 = b[j];
							data.PJADHDHKOEJ[j].PGPGPJNBIOH_Uid = CJAENOMGPDA_ReadInt(b2, "uid", 0, ref isInvalid);
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

	// // RVA: 0x1800BA4 Offset: 0x1800BA4 VA: 0x1800BA4 Slot: 7
	public override void BMGGKONLFIC(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		LIFGJMIHHKM_LimitedItem l = GPBJHKLFCEP as LIFGJMIHHKM_LimitedItem;
		for(int i = 0; i < ODHBHOGFNAA.Count; i++)
		{
			for(int j = 0; j < ODHBHOGFNAA[i].PJADHDHKOEJ.Count; j++)
			{
				ODHBHOGFNAA[i].PJADHDHKOEJ[j].ODDIHGPONFL(l.ODHBHOGFNAA[i].PJADHDHKOEJ[j]);
				ODHBHOGFNAA[i].NPNNEDINOKC[j].ODDIHGPONFL(l.ODHBHOGFNAA[i].NPNNEDINOKC[j]);
			}
		}
	}

	// // RVA: 0x1800FD4 Offset: 0x1800FD4 VA: 0x1800FD4 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		LIFGJMIHHKM_LimitedItem other = GPBJHKLFCEP as LIFGJMIHHKM_LimitedItem;
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

	// // RVA: 0x180166C Offset: 0x180166C VA: 0x180166C Slot: 11
	public override FENCAJJBLBH PFAKPFKJJKA()
	{
		TodoLogger.Log(TodoLogger.DbIntegrityCheck, "TODO");
		return null;
	}
}
