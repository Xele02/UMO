
using System;
using System.Collections.Generic;
using XeSys;

public class NKFJNAANPNP : KLFDBFMNLBL_ServerSaveBlock
{
	public class IAEPMLKOHOB
	{
		public int MACLMNHOBLH; // 0x8
		public int CNGMGFCGLOK; // 0xC
		public int JECIEFEOBDO; // 0x10
		public int FBGGEFFJJHB_xor; // 0x14
		public int DJJOKAOHAML; // 0x18
		public int DADJGIPLGBK; // 0x1C

		public int INNILPKHEKL { get { return MACLMNHOBLH ^ FBGGEFFJJHB_xor; } set { MACLMNHOBLH = value ^ FBGGEFFJJHB_xor; } } //0xC1642C MHAFKCBKDOK 0xC1643C PCPKGMEGIBL
		public int PGPGPJNBIOH_uid { get { return CNGMGFCGLOK ^ FBGGEFFJJHB_xor; } set { CNGMGFCGLOK = value ^ FBGGEFFJJHB_xor; } } //0xC12FDC CJEDGLPDJBN 0xC14798 EKJKPIKJLJJ
		public int DOJDOLDDBPP_Hav { get { return DJJOKAOHAML ^ FBGGEFFJJHB_xor; } set { DJJOKAOHAML = value ^ FBGGEFFJJHB_xor; } } //0xC1447C FHJFILKDGGO 0xC147C8 DEEAELHLIEC
		public int DIAPHCJBPFD_get_date { get { return JECIEFEOBDO ^ FBGGEFFJJHB_xor; } set { JECIEFEOBDO = value ^ FBGGEFFJJHB_xor; } } //0xC12FCC EIEMCCANNJE 0xC147A8 JLGBEBCNDJN
		public int IOLJPHAOBOH_Use { get { return DADJGIPLGBK ^ FBGGEFFJJHB_xor; } set { DADJGIPLGBK = value ^ FBGGEFFJJHB_xor; } } //0xC1446C EHKEMJJNKKI 0xC147B8 GHMCNDFEFIF
		public int HNKFMAJIFJD_ExpireAt { get {
				DateTime date = Utility.GetLocalDateTime(INNILPKHEKL + DIAPHCJBPFD_get_date);
				return (int)Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, 23, 59, 59);
			} } //0xC12AC0 CEOIBKAGPAG

		//// RVA: 0xC12834 Offset: 0xC12834 VA: 0xC12834
		public bool NIENPFFLMCH(long _JHNMKKNEENE_Time)
		{
			return DOJDOLDDBPP_Hav == 1 && _JHNMKKNEENE_Time >= DIAPHCJBPFD_get_date && HNKFMAJIFJD_ExpireAt >= _JHNMKKNEENE_Time;
		}

		//// RVA: 0xC1644C Offset: 0xC1644C VA: 0xC1644C
		//public void DNBGDMBCLMI_ChangeKey(int KNEFBLHBDBG) { }

		//// RVA: 0xC13F2C Offset: 0xC13F2C VA: 0xC13F2C
		//public void LHPDDGIJKNB_Reset(int KNEFBLHBDBG, int _JKPPKAHPPKH_life) { }

		//// RVA: 0xC12FEC Offset: 0xC12FEC VA: 0xC12FEC
		public void HPFJOBPMNCP(int KNEFBLHBDBG, int _PGPGPJNBIOH_uid, long _JHNMKKNEENE_Time)
		{
			MACLMNHOBLH = MACLMNHOBLH ^ KNEFBLHBDBG ^ FBGGEFFJJHB_xor;
			CNGMGFCGLOK = KNEFBLHBDBG ^ _PGPGPJNBIOH_uid;
			JECIEFEOBDO = (int)(_JHNMKKNEENE_Time ^ KNEFBLHBDBG);
			FBGGEFFJJHB_xor = KNEFBLHBDBG;
			DJJOKAOHAML = KNEFBLHBDBG ^ 1;
			DADJGIPLGBK = KNEFBLHBDBG;
		}

		//// RVA: 0xC13348 Offset: 0xC13348 VA: 0xC13348
		public void PKAINJJBMMH_ChangeKeyAndSetTime(int KNEFBLHBDBG, long KNCKIJBOODM)
		{
			MACLMNHOBLH = MACLMNHOBLH ^ KNEFBLHBDBG ^ FBGGEFFJJHB_xor;
			CNGMGFCGLOK = CNGMGFCGLOK ^ KNEFBLHBDBG ^ FBGGEFFJJHB_xor;
			JECIEFEOBDO = JECIEFEOBDO ^ KNEFBLHBDBG ^ FBGGEFFJJHB_xor;
			FBGGEFFJJHB_xor = KNEFBLHBDBG;
			DJJOKAOHAML = KNEFBLHBDBG;
			DADJGIPLGBK = (int)(KNCKIJBOODM ^ KNEFBLHBDBG);
		}

		//// RVA: 0xC147D8 Offset: 0xC147D8 VA: 0xC147D8
		public void ODDIHGPONFL_Copy(IAEPMLKOHOB GPBJHKLFCEP)
		{
			PGPGPJNBIOH_uid = GPBJHKLFCEP.PGPGPJNBIOH_uid;
			DIAPHCJBPFD_get_date = GPBJHKLFCEP.DIAPHCJBPFD_get_date;
			IOLJPHAOBOH_Use = GPBJHKLFCEP.IOLJPHAOBOH_Use;
			DOJDOLDDBPP_Hav = GPBJHKLFCEP.DOJDOLDDBPP_Hav;
		}

		//// RVA: 0xC14DF0 Offset: 0xC14DF0 VA: 0xC14DF0
		public bool AGBOGBEOFME(IAEPMLKOHOB OIKJFMGEICL)
		{
			if(PGPGPJNBIOH_uid != OIKJFMGEICL.PGPGPJNBIOH_uid ||
				DIAPHCJBPFD_get_date != OIKJFMGEICL.DIAPHCJBPFD_get_date ||
				IOLJPHAOBOH_Use != OIKJFMGEICL.IOLJPHAOBOH_Use ||
				DOJDOLDDBPP_Hav != OIKJFMGEICL.DOJDOLDDBPP_Hav)
				return false;
			return true;
		}

		//// RVA: 0xC15328 Offset: 0xC15328 VA: 0xC15328
		//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string _JIKKNHIAEKG_BlockName, string MJBACHKCIHA, int _OIPCCBHIKIA_index, NKFJNAANPNP.IAEPMLKOHOB _OHMCIEMIKCE_t, bool KFCGIKHEEMB) { }
	}
	
	public class MOJLCADLMKH
	{
		private int FBGGEFFJJHB_xor; // 0x8
		private int PIOJIJEDDJP; // 0xC
		private int HLMAFFLCCKD_CountCrypted; // 0x10

		public int HNKFMAJIFJD_ExpireAt { get { return PIOJIJEDDJP ^ FBGGEFFJJHB_xor; } set { PIOJIJEDDJP = FBGGEFFJJHB_xor ^ value; } } //0xC13BD0 CEOIBKAGPAG 0xC13BA8 DLHBCINBDFI
		public int HMFFHLPNMPH_count { get { return HLMAFFLCCKD_CountCrypted ^ FBGGEFFJJHB_xor; } set { HLMAFFLCCKD_CountCrypted = FBGGEFFJJHB_xor ^ value; } } //0xC13BE0 NJOGDDPICKG 0xC13BB8 NBBGMMBICNA

		//// RVA: 0xC13B98 Offset: 0xC13B98 VA: 0xC13B98
		public void LHPDDGIJKNB_Reset(int KNEFBLHBDBG)
		{
			FBGGEFFJJHB_xor = KNEFBLHBDBG;
			PIOJIJEDDJP = KNEFBLHBDBG;
			HLMAFFLCCKD_CountCrypted = KNEFBLHBDBG;
		}
	}
	protected int DALBFCKKGGA_Version = 2; // 0x24
	protected int FIBFMLMHOGN = 9; // 0x28
	protected int KOICDJCMKEC = 0x76a6ff; // 0x2C
	private const int HAKDOMMLLJP = 99999999;
	private List<IAEPMLKOHOB> IDJIDAPJCBE; // 0x30
	private List<IAEPMLKOHOB> NPNNEDINOKC; // 0x34
	private ulong NEJBNCHLMNJ_Type = 1; // 0x38
	private string IHGIDOFLDBD = "pd.limited_tikcet"; // 0x40

	public override bool DMICHEJIAJL { get { return true; } } // 0xC15D58 NFKFOODCJJB

	// // RVA: 0xC126EC Offset: 0xC126EC VA: 0xC126EC
	public int LDLCGGACHGA(long _JHNMKKNEENE_Time)
	{
		int res = 0;
		for(int i = 0; i < FIBFMLMHOGN; i++)
		{
			res += (IDJIDAPJCBE[i].NIENPFFLMCH(_JHNMKKNEENE_Time) && NPNNEDINOKC[i].NIENPFFLMCH(_JHNMKKNEENE_Time)) ? 1 : 0;
		}
		return res;
	}

	// // RVA: 0xC12890 Offset: 0xC12890 VA: 0xC12890
	// public int BBHIGOOBGID(long _JHNMKKNEENE_Time) { }

	// // RVA: 0xC128B0 Offset: 0xC128B0 VA: 0xC128B0
	public int JCJKKMECCFI(long _JHNMKKNEENE_Time)
	{
		if (FIBFMLMHOGN < 1)
			return -1;
		int res = -1;
		for (int i = 0; i < FIBFMLMHOGN; i++)
		{
			if(IDJIDAPJCBE[i].NIENPFFLMCH(_JHNMKKNEENE_Time) && NPNNEDINOKC[i].NIENPFFLMCH(_JHNMKKNEENE_Time))
			{
				if(IDJIDAPJCBE[i].HNKFMAJIFJD_ExpireAt < res)
				{
					res = IDJIDAPJCBE[i].HNKFMAJIFJD_ExpireAt;
				}
			}
		}
		return res;
	}

	// // RVA: 0xC12BD4 Offset: 0xC12BD4 VA: 0xC12BD4
	public int APIEKGBMBPA(long _JHNMKKNEENE_Time, bool _DDGFCOPPBBN_test/* = false*/)
	{
		int a = -1;
		int b = int.MaxValue;
		int c = 0;
		for(int index = FIBFMLMHOGN - 1; index > -1; index--)
		{
			if(!IDJIDAPJCBE[index].NIENPFFLMCH(_JHNMKKNEENE_Time))
			{
				if(IDJIDAPJCBE[index].DIAPHCJBPFD_get_date <= b)
				{
					b = IDJIDAPJCBE[index].DIAPHCJBPFD_get_date;
					c = index;
				}
			}
			if(IDJIDAPJCBE[index].PGPGPJNBIOH_uid > a)
			{
				a = IDJIDAPJCBE[index].PGPGPJNBIOH_uid;
			}
		}
		if (c < 0)
			return 0;
		a++;
		if (a > 99999999)
			a = 1;
		if(!_DDGFCOPPBBN_test)
		{
			IDJIDAPJCBE[c].HPFJOBPMNCP((int)(_JHNMKKNEENE_Time * 0x2e7), a, _JHNMKKNEENE_Time);
			NPNNEDINOKC[c].HPFJOBPMNCP((int)(_JHNMKKNEENE_Time * 0x2e7), a, _JHNMKKNEENE_Time);
			return IDJIDAPJCBE[c].HNKFMAJIFJD_ExpireAt;
		}
		return KOICDJCMKEC + (int)_JHNMKKNEENE_Time;
	}

	// // RVA: 0xC13030 Offset: 0xC13030 VA: 0xC13030
	public List<int> ALGMLEPBEGA(long _JHNMKKNEENE_Time)
	{
		List<int> res = new List<int>();
		for(int i = 0; i < FIBFMLMHOGN; i++)
		{
			if (IDJIDAPJCBE[i].NIENPFFLMCH(_JHNMKKNEENE_Time))
				res.Add(i);
		}
		res.Sort((int _HKICMNAACDA_a, int _BNKHBCBJBKI_b) =>
		{
			//0xC15EE4
			return IDJIDAPJCBE[_HKICMNAACDA_a].PGPGPJNBIOH_uid.CompareTo(IDJIDAPJCBE[_BNKHBCBJBKI_b].PGPGPJNBIOH_uid);
		});
		return res;
	}

	// // RVA: 0xC131E8 Offset: 0xC131E8 VA: 0xC131E8
	public void GKFMCICFEFI(int _OIPCCBHIKIA_index, long KNCKIJBOODM)
	{
		IDJIDAPJCBE[_OIPCCBHIKIA_index].PKAINJJBMMH_ChangeKeyAndSetTime((int)(KNCKIJBOODM * 0x2e5), KNCKIJBOODM);
		NPNNEDINOKC[_OIPCCBHIKIA_index].PKAINJJBMMH_ChangeKeyAndSetTime((int)(KNCKIJBOODM * 0x100b57), KNCKIJBOODM);
	}

	// // RVA: 0xC13390 Offset: 0xC13390 VA: 0xC13390
	public List<MOJLCADLMKH> MCPIBDPKBBD(long _JHNMKKNEENE_Time)
	{
		List<MOJLCADLMKH> res = new List<MOJLCADLMKH>();
		for(int i = 0; i < IDJIDAPJCBE.Count; i++)
		{
			if(IDJIDAPJCBE[i].NIENPFFLMCH(_JHNMKKNEENE_Time))
			{
				MOJLCADLMKH data = new MOJLCADLMKH();
				data.LHPDDGIJKNB_Reset((int)(_JHNMKKNEENE_Time * 0x227));
				data.HNKFMAJIFJD_ExpireAt = IDJIDAPJCBE[i].HNKFMAJIFJD_ExpireAt;
				data.HMFFHLPNMPH_count = 1;
				res.Add(data);
			}
		}
		List<MOJLCADLMKH> res2 = new List<MOJLCADLMKH>();
		for(int i = 0; i < res.Count; i++)
		{
			DateTime date = Utility.GetLocalDateTime(res[i].HNKFMAJIFJD_ExpireAt);
			string[] strs = new string[5] { date.Year.ToString(), date.Month.ToString(), date.Day.ToString(), date.Hour.ToString(), date.Minute.ToString() };
			string str = string.Concat(strs);
			MOJLCADLMKH r = res2.Find((MOJLCADLMKH JPAEDJJFFOI) =>
			{
				//0xC160E0
				DateTime date_ = Utility.GetLocalDateTime(JPAEDJJFFOI.HNKFMAJIFJD_ExpireAt);
				string[] strs_ = new string[5] { date_.Year.ToString(), date_.Month.ToString(), date_.Day.ToString(), date_.Hour.ToString(), date_.Minute.ToString() };
				string str_ = string.Concat(strs_);
				return str == str_;
			});
			if (r == null)
			{
				res2.Add(res[i]);
			}
			else
			{
				r.HMFFHLPNMPH_count += res[i].HMFFHLPNMPH_count;
			}
		}
		res.Sort((MOJLCADLMKH _HKICMNAACDA_a, MOJLCADLMKH _BNKHBCBJBKI_b) =>
		{
			//0xC16074
			return _HKICMNAACDA_a.HNKFMAJIFJD_ExpireAt.CompareTo(_BNKHBCBJBKI_b.HNKFMAJIFJD_ExpireAt);
		});
		return res;
	}

	// // RVA: 0xC13BF0 Offset: 0xC13BF0 VA: 0xC13BF0
	public NKFJNAANPNP()
	{
		IDJIDAPJCBE = new List<IAEPMLKOHOB>(FIBFMLMHOGN);
		NPNNEDINOKC = new List<IAEPMLKOHOB>(FIBFMLMHOGN);
		KMBPACJNEOF_Reset();
	}

	// // RVA: 0xC13CF8 Offset: 0xC13CF8 VA: 0xC13CF8 Slot: 4
	public override void KMBPACJNEOF_Reset()
	{
		IDJIDAPJCBE.Clear();
		NPNNEDINOKC.Clear();
		int k = (int)Utility.GetCurrentUnixTime() * 0x6f;
		for(int i = 0; i < FIBFMLMHOGN; i++)
		{
			IAEPMLKOHOB data = new IAEPMLKOHOB();
			data.FBGGEFFJJHB_xor = k;
			data.PGPGPJNBIOH_uid = 0;
			data.DIAPHCJBPFD_get_date = 0;
			data.DOJDOLDDBPP_Hav = 0;
			data.IOLJPHAOBOH_Use = 0;
			data.INNILPKHEKL = KOICDJCMKEC;
			IDJIDAPJCBE.Add(data);
			k *= 0xb;
		}
		for(int i = 0; i < FIBFMLMHOGN; i++)
		{
			IAEPMLKOHOB data = new IAEPMLKOHOB();
			data.FBGGEFFJJHB_xor = k;
			data.PGPGPJNBIOH_uid = 0;
			data.DIAPHCJBPFD_get_date = 0;
			data.DOJDOLDDBPP_Hav = 0;
			data.IOLJPHAOBOH_Use = 0;
			data.INNILPKHEKL = KOICDJCMKEC;
			NPNNEDINOKC.Add(data);
			k *= 0xb;
		}
	}

	// // RVA: 0xC13F48 Offset: 0xC13F48 VA: 0xC13F48 Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long _MCKEOKFMLAH_SaveId)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
		for(int i = 0; i < IDJIDAPJCBE.Count; i++)
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2["uid"] = IDJIDAPJCBE[i].PGPGPJNBIOH_uid;
			data2["get"] = IDJIDAPJCBE[i].DIAPHCJBPFD_get_date;
			data2["use"] = IDJIDAPJCBE[i].IOLJPHAOBOH_Use;
			data2["hav"] = IDJIDAPJCBE[i].DOJDOLDDBPP_Hav;
			data.Add(data2);
		}
		if(!EMBGIDLFKGM)
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = _MCKEOKFMLAH_SaveId;
			data2[JIKKNHIAEKG_BlockName] = data;
			data2[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] = DALBFCKKGGA_Version;
			data = data2;
		}
		else
		{
			OILEIIEIBHP = OILEIIEIBHP[AFEHLCGHAEE_Strings.JCIBKDHKNFH_alldata];
		}
		OILEIIEIBHP[JIKKNHIAEKG_BlockName] = data;
	}

	// // RVA: 0xC1448C Offset: 0xC1448C VA: 0xC1448C Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool blockMissing = false;
		bool isInvalid = false;
		EDOHBJAPLPF_JsonData block = LGPBAKLCFHI_FindAndCheckBlock(OILEIIEIBHP, ref blockMissing, ref isInvalid, DALBFCKKGGA_Version);
		if (!blockMissing)
		{
			if (block == null || !block.EPNGJLOKGIF_IsArray)
			{
				isInvalid = true;
			}
			else
			{
				if (block.HNBFOAJIIAL_Count != FIBFMLMHOGN)
					isInvalid = true;
				int cnt = block.HNBFOAJIIAL_Count;
				if (FIBFMLMHOGN < cnt)
					cnt = FIBFMLMHOGN;
				for(int i = 0; i < cnt; i++)
				{
					EDOHBJAPLPF_JsonData b = block[i];
					IAEPMLKOHOB data = IDJIDAPJCBE[i];
					data.PGPGPJNBIOH_uid = CJAENOMGPDA_GetInt(b, "uid", 0, ref isInvalid);
					data.DIAPHCJBPFD_get_date = CJAENOMGPDA_GetInt(b, "get", 0, ref isInvalid);
					data.IOLJPHAOBOH_Use = CJAENOMGPDA_GetInt(b, "use", 0, ref isInvalid);
					data.DOJDOLDDBPP_Hav = CJAENOMGPDA_GetInt(b, "hav", 0, ref isInvalid);
					NPNNEDINOKC[i].ODDIHGPONFL_Copy(data);
				}
			}
			KFKDMBPNLJK_BlockInvalid = isInvalid;
			return true;
		}
		return false;
	}

	// // RVA: 0xC148A0 Offset: 0xC148A0 VA: 0xC148A0 Slot: 7
	public override void BMGGKONLFIC_Copy(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		NKFJNAANPNP n = GPBJHKLFCEP as NKFJNAANPNP;
		for(int i = 0; i < IDJIDAPJCBE.Count; i++)
		{
			IDJIDAPJCBE[i].ODDIHGPONFL_Copy(n.IDJIDAPJCBE[i]);
			NPNNEDINOKC[i].ODDIHGPONFL_Copy(n.NPNNEDINOKC[i]);
		}
	}

	// // RVA: 0xC14B04 Offset: 0xC14B04 VA: 0xC14B04 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		NKFJNAANPNP other = GPBJHKLFCEP as NKFJNAANPNP;
		if(IDJIDAPJCBE.Count != other.IDJIDAPJCBE.Count)
			return false;
		for(int i = 0; i < IDJIDAPJCBE.Count; i++)
		{
			if(!IDJIDAPJCBE[i].AGBOGBEOFME(other.IDJIDAPJCBE[i]))
				return false;
			if(!NPNNEDINOKC[i].AGBOGBEOFME(other.NPNNEDINOKC[i]))
				return false;
		}
		return true;
	}

	// // RVA: 0xC14F18 Offset: 0xC14F18 VA: 0xC14F18 Slot: 10
	//public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock _GJLFANGDGCL_Target, long _MCKEOKFMLAH_SaveId);

	// // RVA: 0xC15D60 Offset: 0xC15D60 VA: 0xC15D60
	public void JKGBOCBNIIG(ulong _PPFNGGCBJKC_id, string _EBBJPBGHJOL_text)
	{
		NEJBNCHLMNJ_Type = _PPFNGGCBJKC_id;
		IHGIDOFLDBD = _EBBJPBGHJOL_text;
	}

	// // RVA: 0xC15D74 Offset: 0xC15D74 VA: 0xC15D74 Slot: 11
	public override FENCAJJBLBH PFAKPFKJJKA()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "TODO");
		return null;
	}
}
