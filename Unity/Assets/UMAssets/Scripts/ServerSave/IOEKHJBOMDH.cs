
using System.Collections.Generic;

[System.Obsolete("Use IOEKHJBOMDH_DecoStamp", true)]
public class IOEKHJBOMDH { }
public class IOEKHJBOMDH_DecoStamp : KLFDBFMNLBL_ServerSaveBlock
{
	public class PAFLFMFEOJD
	{
		private int ENOBDCFHELD; // 0x8
		private int FCEJCHGLFGN; // 0xC
		private int LNMDNLFFIDI; // 0x10
		private int HBPDJCFJNED; // 0x14
		private int DOCJJLGDBMB; // 0x18
		private int MEMDPDCJNNA; // 0x1C

		public int CNOHJPEHHCH_StampId { get { return LNMDNLFFIDI ^ ENOBDCFHELD; } set { LNMDNLFFIDI = value ^ ENOBDCFHELD; HBPDJCFJNED = value ^ FCEJCHGLFGN; } } //0xA03F24 LFIBGCJBHOF 0xA047BC LEIBBHPBKOF
		public int JBOCHIJAMFD_SerifId { get { return DOCJJLGDBMB ^ ENOBDCFHELD; } set { DOCJJLGDBMB = value ^ ENOBDCFHELD; MEMDPDCJNNA = value ^ FCEJCHGLFGN; } } //0xA03F34 AFHBJCEOOEI 0xA047D8 LCDHDMNKDKA
		//public bool IEDNAKOJNDE { get; } 0xA060F8 JCIMBGHEMOK

		// RVA: 0xA030EC Offset: 0xA030EC VA: 0xA030EC
		public PAFLFMFEOJD(int PPFNGGCBJKC = 0)
		{
			LHPDDGIJKNB(PPFNGGCBJKC);
		}

		//// RVA: 0xA06128 Offset: 0xA06128 VA: 0xA06128
		public void LHPDDGIJKNB(int PPFNGGCBJKC)
		{
			ENOBDCFHELD = LPDNKHAIOLH.CEIBAFOCNCA();
			FCEJCHGLFGN = LPDNKHAIOLH.CEIBAFOCNCA();
			CNOHJPEHHCH_StampId = PPFNGGCBJKC;
			JBOCHIJAMFD_SerifId = 0;
		}

		//// RVA: 0xA05038 Offset: 0xA05038 VA: 0xA05038
		public bool AGBOGBEOFME(PAFLFMFEOJD OIKJFMGEICL)
		{
			if(CNOHJPEHHCH_StampId != OIKJFMGEICL.CNOHJPEHHCH_StampId ||
				JBOCHIJAMFD_SerifId != OIKJFMGEICL.JBOCHIJAMFD_SerifId)
				return false;
			return true;
		}

		//// RVA: 0xA04BBC Offset: 0xA04BBC VA: 0xA04BBC
		public void ODDIHGPONFL(PAFLFMFEOJD OIKJFMGEICL)
		{
			CNOHJPEHHCH_StampId = OIKJFMGEICL.CNOHJPEHHCH_StampId;
			JBOCHIJAMFD_SerifId = OIKJFMGEICL.JBOCHIJAMFD_SerifId;
		}

		//// RVA: 0xA02CB0 Offset: 0xA02CB0 VA: 0xA02CB0
		//public FENCAJJBLBH PFAKPFKJJKA() { }

		//// RVA: 0xA05860 Offset: 0xA05860 VA: 0xA05860
		//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, IOEKHJBOMDH.PAFLFMFEOJD GJLFANGDGCL, bool EFOEPDLNLJG) { }
	}
 
	public class GFPPDCEPLCM
	{
		public int ENOBDCFHELD; // 0x8
		public int FCEJCHGLFGN; // 0xC
		private const sbyte JFOFMKBJBBE_False = 0x13;
		private const sbyte CNECJGKECHK_True = 0x57;
		private int EHOIENNDEDH; // 0x10
		public int INCHFKJOIEK; // 0x14
		private int IFEHKNJONPL; // 0x18
		public int ONFJFGFNGGD; // 0x1C
		private sbyte ACKPOCNHOOP; // 0x20
		public sbyte KCEAEOMJNFO; // 0x21

		public int PPFNGGCBJKC_Id { get { return EHOIENNDEDH ^ ENOBDCFHELD; } set { EHOIENNDEDH = value ^ ENOBDCFHELD; INCHFKJOIEK = value ^ FCEJCHGLFGN; } } //0xA03F70 DEMEPMAEJOO 0xA047F4 HIGKAIDMOKN
		public int BFINGCJHOHI_Cnt { get { return IFEHKNJONPL ^ ENOBDCFHELD; } set { IFEHKNJONPL = value ^ ENOBDCFHELD; ONFJFGFNGGD = value ^ FCEJCHGLFGN; } } //0xA03F80 LFMCLIDAPHB 0xA04810 EDAEPDGGFJJ
		public bool CADENLBDAEB_IsNew { get { return ACKPOCNHOOP == CNECJGKECHK_True; } set { ACKPOCNHOOP = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; KCEAEOMJNFO = value ? JFOFMKBJBBE_False : CNECJGKECHK_True; } } //0xA03F90 KJGFPPLHLAB 0xA0482C ILJHLPMDHPO

		// RVA: 0xA03114 Offset: 0xA03114 VA: 0xA03114
		public GFPPDCEPLCM(int PPFNGGCBJKC = 0)
		{
			ENOBDCFHELD = LPDNKHAIOLH.CEIBAFOCNCA();
			FCEJCHGLFGN = LPDNKHAIOLH.CEIBAFOCNCA();
			LHPDDGIJKNB(PPFNGGCBJKC);
		}

		//// RVA: 0xA06074 Offset: 0xA06074 VA: 0xA06074
		public void LHPDDGIJKNB(int PPFNGGCBJKC = 0)
		{
			this.PPFNGGCBJKC_Id = PPFNGGCBJKC;
			BFINGCJHOHI_Cnt = 0;
			CADENLBDAEB_IsNew = false;
		}

		//// RVA: 0xA04C38 Offset: 0xA04C38 VA: 0xA04C38
		public GFPPDCEPLCM ODDIHGPONFL(GFPPDCEPLCM GPBJHKLFCEP)
		{
			PPFNGGCBJKC_Id = GPBJHKLFCEP.PPFNGGCBJKC_Id;
			BFINGCJHOHI_Cnt = GPBJHKLFCEP.BFINGCJHOHI_Cnt;
			CADENLBDAEB_IsNew = GPBJHKLFCEP.CADENLBDAEB_IsNew;
			return this;
		}

		//// RVA: 0xA050A4 Offset: 0xA050A4 VA: 0xA050A4
		public bool AGBOGBEOFME(GFPPDCEPLCM OIKJFMGEICL)
		{
			if(PPFNGGCBJKC_Id != OIKJFMGEICL.PPFNGGCBJKC_Id ||
				BFINGCJHOHI_Cnt != OIKJFMGEICL.BFINGCJHOHI_Cnt ||
				CADENLBDAEB_IsNew != OIKJFMGEICL.CADENLBDAEB_IsNew)
				return false;
			return true;
		}

		//// RVA: 0xA03F44 Offset: 0xA03F44 VA: 0xA03F44
		//public bool DFIGPDCBAPB() { }

		//// RVA: 0xA05DB4 Offset: 0xA05DB4 VA: 0xA05DB4
		//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, IOEKHJBOMDH.GFPPDCEPLCM OHMCIEMIKCE, bool EFOEPDLNLJG) { }

		//// RVA: 0xA02DB0 Offset: 0xA02DB0 VA: 0xA02DB0
		//public FENCAJJBLBH PFAKPFKJJKA() { }

		//// RVA: 0xA06098 Offset: 0xA06098 VA: 0xA06098
		//public bool PPJAGFPBFHJ(int HMFFHLPNMPH) { }
	}

	private const int ECFEMKGFDCE = 3;
	private const string POFDDFCGEGP = "_";
	public const int EDFABKBBOFI = 1;
	public const int FJEDMPPIGAM = 30;
	public const int NNEODMHAPGP = 900;
	public const int BNGDHECNKFF = 400;
	public List<PAFLFMFEOJD> GNKJGECHLNE_CustomList; // 0x24
	public List<GFPPDCEPLCM> FHBIIONKIDI_Stamps; // 0x28
	public List<GFPPDCEPLCM> DMKMNGELNAE_Serif; // 0x2C

	public override bool DMICHEJIAJL { get { TodoLogger.Log(0, "DMICHEJIAJL"); return false; } } // 0xA0606C NFKFOODCJJB

	// // RVA: 0xA027AC Offset: 0xA027AC VA: 0xA027AC
	public bool DDKEJHIGBGK_IsStampEnabled(IHFIAFDLAAK_DecoStamp GAPONCJOKAC, int PPFNGGCBJKC)
	{
		if(PPFNGGCBJKC > 0 && PPFNGGCBJKC <= GAPONCJOKAC.FHBIIONKIDI_Stamps.Count)
		{
			return GAPONCJOKAC.FHBIIONKIDI_Stamps[PPFNGGCBJKC - 1].PLALNIIBLOF_Enabled == 2;
		}
		return false;
	}

	// // RVA: 0xA028B0 Offset: 0xA028B0 VA: 0xA028B0
	public bool HOAKPBBIGPK_IsSerifEnabled(IHFIAFDLAAK_DecoStamp GAPONCJOKAC, int PPFNGGCBJKC)
	{
		if(PPFNGGCBJKC > 0 && PPFNGGCBJKC < GAPONCJOKAC.DMKMNGELNAE_Serif.Count)
		{
			return GAPONCJOKAC.DMKMNGELNAE_Serif[PPFNGGCBJKC - 1].PLALNIIBLOF_Enabled == 2;
		}
		return false;
	}

	// // RVA: 0xA029B4 Offset: 0xA029B4 VA: 0xA029B4
	public IOEKHJBOMDH_DecoStamp()
	{
		GNKJGECHLNE_CustomList = new List<PAFLFMFEOJD>(30);
		FHBIIONKIDI_Stamps = new List<GFPPDCEPLCM>();
		DMKMNGELNAE_Serif = new List<GFPPDCEPLCM>();
		KMBPACJNEOF();
	}

	// // RVA: 0xA02AA4 Offset: 0xA02AA4 VA: 0xA02AA4 Slot: 11
	public override FENCAJJBLBH PFAKPFKJJKA()
	{
		TodoLogger.Log(TodoLogger.DbIntegrityCheck, "TODO");
		return null;
	}

	// // RVA: 0xA02EE4 Offset: 0xA02EE4 VA: 0xA02EE4 Slot: 4
	public override void KMBPACJNEOF()
	{
		GNKJGECHLNE_CustomList.Clear();
		FHBIIONKIDI_Stamps.Clear();
		DMKMNGELNAE_Serif.Clear();
		for(int i = 0; i < 30; i++)
		{
			GNKJGECHLNE_CustomList.Add(new PAFLFMFEOJD());
		}
		for(int i = 0; i < 900; i++)
		{
			FHBIIONKIDI_Stamps.Add(new GFPPDCEPLCM());
		}
		for (int i = 0; i < 400; i++)
		{
			DMKMNGELNAE_Serif.Add(new GFPPDCEPLCM());
		}
	}

	// // RVA: 0xA031DC Offset: 0xA031DC VA: 0xA031DC Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int i = 0; i < GNKJGECHLNE_CustomList.Count; i++)
			{
				EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
				data3[AFEHLCGHAEE_Strings.FDGBLNFGBPJ_stamp_id] = GNKJGECHLNE_CustomList[i].CNOHJPEHHCH_StampId;
				data3[AFEHLCGHAEE_Strings.HPPHKHBPFMJ_serif_id] = GNKJGECHLNE_CustomList[i].JBOCHIJAMFD_SerifId;
				data2.Add(data3);
			}
			data[AFEHLCGHAEE_Strings.CBACMMCDGEM_custom_list] = data2;
		}
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2["_"] = "";
			for(int i = 0; i < FHBIIONKIDI_Stamps.Count; i++)
			{
				if (FHBIIONKIDI_Stamps[i].BFINGCJHOHI_Cnt != 0 || FHBIIONKIDI_Stamps[i].CADENLBDAEB_IsNew)
				{
					EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
					data3[AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id] = FHBIIONKIDI_Stamps[i].PPFNGGCBJKC_Id;
					data3[AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt] = FHBIIONKIDI_Stamps[i].BFINGCJHOHI_Cnt;
					data3[AFEHLCGHAEE_Strings.LHMOAJAIJCO_is_new] = FHBIIONKIDI_Stamps[i].CADENLBDAEB_IsNew;
					data2["_" + (i + 1)] = data3;
				}
			}
			data[AFEHLCGHAEE_Strings.GNKMHCKFADN_stamp] = data2;
		}
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2["_"] = "";
			for (int i = 0; i < DMKMNGELNAE_Serif.Count; i++)
			{
				if(DMKMNGELNAE_Serif[i].BFINGCJHOHI_Cnt != 0 || DMKMNGELNAE_Serif[i].CADENLBDAEB_IsNew)
				{
					EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
					data3[AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id] = DMKMNGELNAE_Serif[i].PPFNGGCBJKC_Id;
					data3[AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt] = DMKMNGELNAE_Serif[i].BFINGCJHOHI_Cnt;
					data3[AFEHLCGHAEE_Strings.LHMOAJAIJCO_is_new] = DMKMNGELNAE_Serif[i].CADENLBDAEB_IsNew;
					data2["_" + (i + 1)] = data3;
				}
			}
			data[AFEHLCGHAEE_Strings.HELBHEPKBJF_serif] = data2;
		}
		if(!EMBGIDLFKGM)
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = MCKEOKFMLAH;
			data2[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] = 3;
			data2[JIKKNHIAEKG_BlockName] = data;
			data = data2;
		}
		else
		{
			OILEIIEIBHP = OILEIIEIBHP[AFEHLCGHAEE_Strings.JCIBKDHKNFH_alldata];
		}
		OILEIIEIBHP[JIKKNHIAEKG_BlockName] = data;
	}

	// // RVA: 0xA03FA4 Offset: 0xA03FA4 VA: 0xA03FA4 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool blockMissing = false;
		bool isInvalid = false;
		EDOHBJAPLPF_JsonData block = LGPBAKLCFHI_FindAndCheckBlock(OILEIIEIBHP, ref blockMissing, ref isInvalid, 3);
		if (!blockMissing)
		{
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database == null)
				return false;
			IHFIAFDLAAK_DecoStamp dbStamp = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp;
			if (block == null)
			{
				isInvalid = true;
			}
			else
			{
				EDOHBJAPLPF_JsonData b = block[AFEHLCGHAEE_Strings.CBACMMCDGEM_custom_list];
				int cnt = b.HNBFOAJIIAL_Count;
				if (cnt >= 31)
				{
					cnt = 30;
					isInvalid = true;
				}
				for (int i = 0; i < cnt; i++)
				{
					PAFLFMFEOJD data = GNKJGECHLNE_CustomList[i];
					EDOHBJAPLPF_JsonData b2 = b[i];
					int stampId = CJAENOMGPDA_ReadInt(b2, AFEHLCGHAEE_Strings.FDGBLNFGBPJ_stamp_id, 0, ref isInvalid);
					int serifId = CJAENOMGPDA_ReadInt(b2, AFEHLCGHAEE_Strings.HPPHKHBPFMJ_serif_id, 0, ref isInvalid);
					if (!DDKEJHIGBGK_IsStampEnabled(dbStamp, stampId) || !HOAKPBBIGPK_IsSerifEnabled(dbStamp, serifId))
					{
						stampId = 0;
					}
					data.CNOHJPEHHCH_StampId = stampId;
					data.JBOCHIJAMFD_SerifId = serifId;
				}
				b = block[AFEHLCGHAEE_Strings.GNKMHCKFADN_stamp];
				for(int i = 0; i < 900; i++)
				{
					string str = "_" + (i + 1).ToString();
					if(b.BBAJPINMOEP_Contains(str))
					{
						EDOHBJAPLPF_JsonData b2 = b[str];
						GFPPDCEPLCM data = FHBIIONKIDI_Stamps[i];
						data.PPFNGGCBJKC_Id = i + 1;
						data.BFINGCJHOHI_Cnt = CJAENOMGPDA_ReadInt(b2, AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt, 0, ref isInvalid);
						data.CADENLBDAEB_IsNew = CJAENOMGPDA_ReadInt(b2, AFEHLCGHAEE_Strings.LHMOAJAIJCO_is_new, 0, ref isInvalid) != 0;
					}
				}
				b = block[AFEHLCGHAEE_Strings.HELBHEPKBJF_serif];
				for(int i = 0; i < 500; i++)
				{
					string str = "_" + (i + 1).ToString();
					if (b.BBAJPINMOEP_Contains(str))
					{
						EDOHBJAPLPF_JsonData b2 = b[str];
						GFPPDCEPLCM data = DMKMNGELNAE_Serif[i];
						data.PPFNGGCBJKC_Id = i + 1;
						data.BFINGCJHOHI_Cnt = CJAENOMGPDA_ReadInt(b2, AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt, 0, ref isInvalid);
						data.CADENLBDAEB_IsNew = CJAENOMGPDA_ReadInt(b2, AFEHLCGHAEE_Strings.LHMOAJAIJCO_is_new, 0, ref isInvalid) != 0;
					}
				}
			}
			KFKDMBPNLJK_BlockInvalid = isInvalid;
			return true;
		}
		return false;
	}

	// // RVA: 0xA04884 Offset: 0xA04884 VA: 0xA04884 Slot: 7
	public override void BMGGKONLFIC(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		IOEKHJBOMDH_DecoStamp d = GPBJHKLFCEP as IOEKHJBOMDH_DecoStamp;
		for(int i = 0; i < GNKJGECHLNE_CustomList.Count; i++)
		{
			GNKJGECHLNE_CustomList[i].ODDIHGPONFL(d.GNKJGECHLNE_CustomList[i]);
		}
		for(int i = 0; i < FHBIIONKIDI_Stamps.Count; i++)
		{
			FHBIIONKIDI_Stamps[i].ODDIHGPONFL(d.FHBIIONKIDI_Stamps[i]);
		}
		for(int i = 0; i < DMKMNGELNAE_Serif.Count; i++)
		{
			DMKMNGELNAE_Serif[i].ODDIHGPONFL(d.DMKMNGELNAE_Serif[i]);
		}
	}

	// // RVA: 0xA04CE0 Offset: 0xA04CE0 VA: 0xA04CE0 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		IOEKHJBOMDH_DecoStamp other = GPBJHKLFCEP as IOEKHJBOMDH_DecoStamp;
		for(int i = 0; i < GNKJGECHLNE_CustomList.Count; i++)
		{
			if(!GNKJGECHLNE_CustomList[i].AGBOGBEOFME(other.GNKJGECHLNE_CustomList[i]))
				return false;
		}
		for(int i = 0; i < FHBIIONKIDI_Stamps.Count; i++)
		{
			if(!FHBIIONKIDI_Stamps[i].AGBOGBEOFME(other.FHBIIONKIDI_Stamps[i]))
				return false;
		}
		for(int i = 0; i < DMKMNGELNAE_Serif.Count; i++)
		{
			if(!DMKMNGELNAE_Serif[i].AGBOGBEOFME(other.DMKMNGELNAE_Serif[i]))
				return false;
		}
		return true;
	}

	// // RVA: 0xA0516C Offset: 0xA0516C VA: 0xA0516C Slot: 10
	public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock GJLFANGDGCL, long MCKEOKFMLAH)
	{
		TodoLogger.Log(0, "AGHKODFKOJI");
	}
}
