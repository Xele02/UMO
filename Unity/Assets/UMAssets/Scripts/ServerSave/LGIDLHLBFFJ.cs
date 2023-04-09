
using System;
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use LGIDLHLBFFJ_MonthlyPass", true)]
public class LGIDLHLBFFJ { }
public class LGIDLHLBFFJ_MonthlyPass : KLFDBFMNLBL_ServerSaveBlock
{
	public class LCDJCBAPAML
	{
		public long OILIPGICBIK; // 0x8
		public long NJKMDELFJGE; // 0x10
		public long AOMKDIEDDHH; // 0x18
		public long LFCBBOPEGDP; // 0x20
		public long GDKODEGAAPA; // 0x28
		public long CBGEGLCNOLB; // 0x30
		public int EHOIENNDEDH; // 0x38
		public int INCHFKJOIEK; // 0x3C

		public int PPFNGGCBJKC_Id { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; INCHFKJOIEK = value; } } //0x17F12D0 DEMEPMAEJOO 0x17F1368 HIGKAIDMOKN
		public long FDFGEMODIIF_StartedAt { get { return OILIPGICBIK ^ BBEGLBMOBOF; } set { OILIPGICBIK = value ^ BBEGLBMOBOF; LFCBBOPEGDP = value; } } //0x17F1408 CBDHPDMLJKB 0x17F14A4 OPBOAMBLLDF
		public long NKMNFPMMJND_ExpiredAt { get { return NJKMDELFJGE ^ BBEGLBMOBOF; } set { NJKMDELFJGE = value ^ BBEGLBMOBOF; GDKODEGAAPA = value; } } //0x17F154C JCDIJBHKGMA 0x17F15E8 FDMBGEAJNPK
		public long EMOHDABPCHD_CheckAt { get { return AOMKDIEDDHH ^ BBEGLBMOBOF; } set { AOMKDIEDDHH = value ^ BBEGLBMOBOF; CBGEGLCNOLB = value; } } //0x17F1690 KNPJCIBDBJC 0x17F172C BDFIIDDKKCE

		//// RVA: 0x17F17D4 Offset: 0x17F17D4 VA: 0x17F17D4
		public void LHPDDGIJKNB(int PPFNGGCBJKC)
		{
			this.PPFNGGCBJKC_Id = PPFNGGCBJKC;
			FDFGEMODIIF_StartedAt = 0;
			NKMNFPMMJND_ExpiredAt = 0;
			EMOHDABPCHD_CheckAt = 0;
		}

		//// RVA: 0x17F1820 Offset: 0x17F1820 VA: 0x17F1820
		//public bool AGBOGBEOFME(LGIDLHLBFFJ.LCDJCBAPAML OIKJFMGEICL) { }

		//// RVA: 0x17F1940 Offset: 0x17F1940 VA: 0x17F1940
		public void ODDIHGPONFL(LCDJCBAPAML GPBJHKLFCEP)
		{
			FDFGEMODIIF_StartedAt = GPBJHKLFCEP.FDFGEMODIIF_StartedAt;
			NKMNFPMMJND_ExpiredAt = GPBJHKLFCEP.NKMNFPMMJND_ExpiredAt;
			EMOHDABPCHD_CheckAt = GPBJHKLFCEP.EMOHDABPCHD_CheckAt;
			PPFNGGCBJKC_Id = GPBJHKLFCEP.PPFNGGCBJKC_Id;
		}

		//// RVA: 0x17F1A20 Offset: 0x17F1A20 VA: 0x17F1A20
		//public bool CHFOOMPEABN() { }

		//// RVA: 0x17F1A64 Offset: 0x17F1A64 VA: 0x17F1A64
		//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, LGIDLHLBFFJ.LCDJCBAPAML OHMCIEMIKCE, bool EFOEPDLNLJG) { }
	}
	
	public class ODHIHCNALDL
	{
		private List<long> GIJFDNOIHCL_Dates = new List<long>(20); // 0x8
		public int JJPDPNJFBHN_TableId; // 0xC
		public long MMPCPKODGKI_ResetAt; // 0x10

		// RVA: 0x17F2BF0 Offset: 0x17F2BF0 VA: 0x17F2BF0
		public void LHPDDGIJKNB()
		{
			GIJFDNOIHCL_Dates.Clear();
			for(int i = 0; i < 20; i++)
			{
				GIJFDNOIHCL_Dates.Add(BBEGLBMOBOF);
			}
			JJPDPNJFBHN_TableId = 0;
			MMPCPKODGKI_ResetAt = 0;
		}

		// RVA: 0x17F2D10 Offset: 0x17F2D10 VA: 0x17F2D10
		public long LPGIECKPBDK(int OIPCCBHIKIA)
		{
			return GIJFDNOIHCL_Dates[OIPCCBHIKIA] ^ BBEGLBMOBOF;
		}

		// RVA: 0x17F11F0 Offset: 0x17F11F0 VA: 0x17F11F0
		public void ACCIBAABEPN(int OIPCCBHIKIA, long JGNBPFCJLKI)
		{
			GIJFDNOIHCL_Dates[OIPCCBHIKIA] = JGNBPFCJLKI ^ BBEGLBMOBOF;
		}

		// RVA: 0x17F2DE4 Offset: 0x17F2DE4 VA: 0x17F2DE4
		//public bool AGBOGBEOFME(LGIDLHLBFFJ.ODHIHCNALDL OIKJFMGEICL) { }

		// RVA: 0x17F2E68 Offset: 0x17F2E68 VA: 0x17F2E68
		public void ODDIHGPONFL(ODHIHCNALDL GPBJHKLFCEP)
		{
			for(int i = 0; i < 20; i++)
			{
				ACCIBAABEPN(i, GPBJHKLFCEP.LPGIECKPBDK(i));
			}
			JJPDPNJFBHN_TableId = GPBJHKLFCEP.JJPDPNJFBHN_TableId;
			MMPCPKODGKI_ResetAt = GPBJHKLFCEP.MMPCPKODGKI_ResetAt;
		}

		// RVA: 0x17F2EE8 Offset: 0x17F2EE8 VA: 0x17F2EE8
		//public bool CHFOOMPEABN() { }

		// RVA: 0x17F2FA0 Offset: 0x17F2FA0 VA: 0x17F2FA0
		public int KNIOACKGGHI()
		{
			int res = 0;
			for(int i = 0; i < GIJFDNOIHCL_Dates.Count; i++)
			{
				if (LPGIECKPBDK(i) != 0)
					res++;
			}
			return res;
		}

		// RVA: 0x17F3048 Offset: 0x17F3048 VA: 0x17F3048
		//public bool NFOKMHEIMBI() { }

		// RVA: 0x17F30F0 Offset: 0x17F30F0 VA: 0x17F30F0
		public void DOMFHDPMCCO(int BIHELPHMCCA, long EOLFJGMAJAB)
		{
			JJPDPNJFBHN_TableId = BIHELPHMCCA;
			MMPCPKODGKI_ResetAt = EOLFJGMAJAB;
			for(int i = 0; i < GIJFDNOIHCL_Dates.Count; i++)
			{
				ACCIBAABEPN(i, 0);
			}
		}

		// RVA: 0x17F31B0 Offset: 0x17F31B0 VA: 0x17F31B0
		//public EDOHBJAPLPF OKJPIBHMKMJ() { }

		// RVA: 0x17F33A0 Offset: 0x17F33A0 VA: 0x17F33A0
		//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, LGIDLHLBFFJ.ODHIHCNALDL OHMCIEMIKCE, bool EFOEPDLNLJG) { }
	}

	private const int ECFEMKGFDCE = 2;
	public const int KCFBAOJKKHH = 2;
	public const int JOMJMHGMGFO = 20;
	public const int GIDIDCDCDEM = 2;
	public static string POFDDFCGEGP = "_"; // 0x0
	public static int FBGGEFFJJHB = 0x1741f74; // 0x4
	public static long BBEGLBMOBOF = 0x725731f; // 0x8
	public const int BNLBENOIHAO = 31;
	public const int HMAMANIPLCD = 99;
	private int HCPMMDELCDC; // 0x24
	private int CDKBOHDFJKG; // 0x28
	private int AFMHNALKGNC; // 0x2C
	private int PLPIEGNDIGG; // 0x30
	private int KJDIBKHGMKO; // 0x34
	private int POAGOKLJCNF; // 0x38
	private int PHJODLGIEJA; // 0x3C
	private int JJCMEHFOCED; // 0x40
	private int CEFBCMKNPKB; // 0x44
	private long FLMJPPIPMGP; // 0x48
	private long FDGICFBLMKO; // 0x50
	public int KJBOIGIDKIF_Platform; // 0x58
	public int PMCKOEGANFB_Status; // 0x5C
	public int MPLPHLAHJOC_StampHosei; // 0x60
	public List<LCDJCBAPAML> FMPLMFLMJNE_Last; // 0x64
	public List<LCDJCBAPAML> DNKJAIHCDFN_First; // 0x68
	public List<LCDJCBAPAML> AOHBAOAPGDM_Raw; // 0x6C
	public NNJFKLBPBNK_SecureString CPENFPEPDFC_Lguk; // 0x70
	public NNJFKLBPBNK_SecureString BPMLNLPDCAJ_Lauk; // 0x74
	public List<ODHIHCNALDL> EOHPPNNLBNH_Stamp; // 0x78

	public int PCBLFLDMCJA_StampDay { get { return HCPMMDELCDC ^ FBGGEFFJJHB; } set { HCPMMDELCDC = value ^ FBGGEFFJJHB; } } // CJPCEIPEIOB 0xD8403C GIJHJLEGKPG 0xD840D4
	public int FADAJDBCBJK_TopPlanDay { get { return CDKBOHDFJKG ^ FBGGEFFJJHB; } set { CDKBOHDFJKG = value ^ FBGGEFFJJHB; } } // FHNELMGCLLA 0xD84170 AKFPDEMMBKM 0xD84208
	public int FLBJKACKNOI_CurStamp { get { return AFMHNALKGNC ^ FBGGEFFJJHB; } set { AFMHNALKGNC = value ^ FBGGEFFJJHB; } } //CPKDPLPJIMI 0xD842A4 NBMJIIHOMHH 0xD8433C
	public int FCPHDFKFDCK_LoginCnt { get { return PLPIEGNDIGG ^ FBGGEFFJJHB; } set { PLPIEGNDIGG = value ^ FBGGEFFJJHB; KJDIBKHGMKO = value; } } // EKJKOALHDAH 0xD843D8  BLKCKIEOFOH 0xD84470
	public int HKABHJKHFKL_RareGetCnt { get { return POAGOKLJCNF ^ FBGGEFFJJHB; } set { POAGOKLJCNF = value ^ FBGGEFFJJHB; PHJODLGIEJA = value; } } //IDKLGKKOHII 0xD84510 LHCMKDALNEE 0xD845A8
	public int JAMCDEDFHHK_HotenCnt { get { return JJCMEHFOCED ^ FBGGEFFJJHB; } set { JJCMEHFOCED = value ^ FBGGEFFJJHB; CEFBCMKNPKB = value; } } //CHGOJFDDCEG 0xD84648 ABJLDAFNEOJ 0xD846E0
	public long BKONHFNBHKL_Aextm { get { return FLMJPPIPMGP ^ BBEGLBMOBOF; } set { FLMJPPIPMGP = value ^ BBEGLBMOBOF; FDGICFBLMKO = value; } } //ADJIEHKCCCN 0xD84780 CPDDIJHNBCJ 0xD8481C
	public override bool DMICHEJIAJL { get { TodoLogger.Log(0, "DMICHEJIAJL"); return false; } } // 0xD8AC0C NFKFOODCJJB

	// // RVA: 0xD848C8 Offset: 0xD848C8 VA: 0xD848C8
	// public KBCCGHLCFNO.JKGFAIPDNDL LOGJJALCFPF() { }

	// // RVA: 0xD84C84 Offset: 0xD84C84 VA: 0xD84C84
	// public int PKGCIBGBAOO() { }

	// // RVA: 0xD84E34 Offset: 0xD84E34 VA: 0xD84E34
	public int HGEJHKCHBNB()
	{
		int a = HKABHJKHFKL_RareGetCnt == 0 ? 30 : 90;
		string str = HKABHJKHFKL_RareGetCnt == 0 ? "rareup_1st_day" : "rareup_2nd_day";
		int b = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MEGJDBJCEOC_MonthlyPass.LPJLEHAJADA_GetValue(str, a);
		int c = FCPHDFKFDCK_LoginCnt;
		if(b - c > 0)
			return b - c;
		return 0;
	}

	// // RVA: 0xD84F68 Offset: 0xD84F68 VA: 0xD84F68
	public int HEOIMMMJKIP()
	{
		int rareup_2nd_day = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MEGJDBJCEOC_MonthlyPass.LPJLEHAJADA_GetValue("rareup_2nd_day", 90);
		if(rareup_2nd_day <= HKABHJKHFKL_RareGetCnt)
		{
			return (HKABHJKHFKL_RareGetCnt - 1) * rareup_2nd_day + FCPHDFKFDCK_LoginCnt;
		}
		return FCPHDFKFDCK_LoginCnt;
	}

	// // RVA: 0xD85094 Offset: 0xD85094 VA: 0xD85094
	// public KBCCGHLCFNO.JKGFAIPDNDL ECBMDDGPKGN() { }

	// // RVA: 0xD8528C Offset: 0xD8528C VA: 0xD8528C
	public void AFGLHGNKOFC()
	{
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		DateTime date = Utility.GetLocalDateTime(time + 86400);
		BKONHFNBHKL_Aextm = Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, 0, 0, 0);
	}

	// // RVA: 0xD85444 Offset: 0xD85444 VA: 0xD85444
	// public int AIGKHDMFFMO() { }

	// // RVA: 0xD8547C Offset: 0xD8547C VA: 0xD8547C
	public int ACPKOAAPHJM()
	{
		int res = 0;
		for(int i = 0; i < EOHPPNNLBNH_Stamp.Count; i++)
		{
			if(EOHPPNNLBNH_Stamp[i].JJPDPNJFBHN_TableId != 0)
			{
				res += EOHPPNNLBNH_Stamp[i].KNIOACKGGHI();
			}
		}
		return res;
	}

	// // RVA: 0xD855BC Offset: 0xD855BC VA: 0xD855BC
	public bool HMAHFMHPBBC()
	{
		int stamp_hosei_ver = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MEGJDBJCEOC_MonthlyPass.LPJLEHAJADA_GetValue("stamp_hosei_ver", 1);
		if (stamp_hosei_ver == MPLPHLAHJOC_StampHosei)
			return false;
		int a = HEOIMMMJKIP();
		int b = a % 20;
		if (a > 19)
			b += 20;
		return ACPKOAAPHJM() != b;
	}

	// // RVA: 0xD85708 Offset: 0xD85708 VA: 0xD85708
	public KBCCGHLCFNO_MonthlyPass.JKGFAIPDNDL BGANHMCJIIC()
	{
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		ODHIHCNALDL savePass = EOHPPNNLBNH_Stamp[FLBJKACKNOI_CurStamp - 1];
		if(savePass.JJPDPNJFBHN_TableId == 0)
		{
			savePass.JJPDPNJFBHN_TableId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MEGJDBJCEOC_MonthlyPass.IPAOPMEFJKD_StartTableId;
			savePass.DOMFHDPMCCO(savePass.JJPDPNJFBHN_TableId, time);
		}
		int a = savePass.KNIOACKGGHI();
		KBCCGHLCFNO_MonthlyPass.JKGFAIPDNDL res = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MEGJDBJCEOC_MonthlyPass.DHBEKJNJOMC(savePass.JJPDPNJFBHN_TableId, a + 1);
		if(a < 19)
		{
			savePass.ACCIBAABEPN(a, time);
		}
		else
		{
			savePass.ACCIBAABEPN(19, time);
			FLBJKACKNOI_CurStamp = FLBJKACKNOI_CurStamp + 1;
			if (EOHPPNNLBNH_Stamp.Count < FLBJKACKNOI_CurStamp)
				FLBJKACKNOI_CurStamp = 1;
			EOHPPNNLBNH_Stamp[FLBJKACKNOI_CurStamp - 1].DOMFHDPMCCO(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MEGJDBJCEOC_MonthlyPass.MAOBENAPFNI(savePass.JJPDPNJFBHN_TableId), time);
		}
		return res;
	}

	// // RVA: 0xD85AA4 Offset: 0xD85AA4 VA: 0xD85AA4
	// public bool MBPPILOJOBK(int LJACHJCFMJH) { }

	// // RVA: 0xD85AC4 Offset: 0xD85AC4 VA: 0xD85AC4
	// public void HAEOIGABDDM(int LJACHJCFMJH) { }

	// // RVA: 0xD85B00 Offset: 0xD85B00 VA: 0xD85B00
	// public void DGIBOADNFOI(int ADPPAIPFHML) { }

	// // RVA: 0xD85B2C Offset: 0xD85B2C VA: 0xD85B2C
	public LGIDLHLBFFJ_MonthlyPass()
	{
		FMPLMFLMJNE_Last = new List<LCDJCBAPAML>();
		DNKJAIHCDFN_First = new List<LCDJCBAPAML>();
		AOHBAOAPGDM_Raw = new List<LCDJCBAPAML>();
		CPENFPEPDFC_Lguk = new NNJFKLBPBNK_SecureString();
		BPMLNLPDCAJ_Lauk = new NNJFKLBPBNK_SecureString();
		EOHPPNNLBNH_Stamp = new List<ODHIHCNALDL>(2);
		KMBPACJNEOF();
	}

	// // RVA: 0xD85C70 Offset: 0xD85C70 VA: 0xD85C70 Slot: 4
	public override void KMBPACJNEOF()
	{
		PCBLFLDMCJA_StampDay = 0;
		FADAJDBCBJK_TopPlanDay = 0;
		FLBJKACKNOI_CurStamp = 0;
		FCPHDFKFDCK_LoginCnt = 0;
		HKABHJKHFKL_RareGetCnt = 0;
		JAMCDEDFHHK_HotenCnt = 0;
		KJBOIGIDKIF_Platform = 0;
		PMCKOEGANFB_Status = 0;
		MPLPHLAHJOC_StampHosei = 0;
		BKONHFNBHKL_Aextm = 0;
		BPMLNLPDCAJ_Lauk.DNJEJEANJGL_Value = "";
		CPENFPEPDFC_Lguk.DNJEJEANJGL_Value = "";
		FMPLMFLMJNE_Last.Clear();
		DNKJAIHCDFN_First.Clear();
		for(int i = 0; i < 2; i++)
		{
			LCDJCBAPAML data = new LCDJCBAPAML();
			data.LHPDDGIJKNB(i + 1);
			FMPLMFLMJNE_Last.Add(data);
		}
		for(int i = 0; i < 2; i++)
		{
			LCDJCBAPAML data = new LCDJCBAPAML();
			data.LHPDDGIJKNB(i + 1);
			DNKJAIHCDFN_First.Add(data);
		}
		for(int i = 0; i < 2; i++)
		{
			LCDJCBAPAML data = new LCDJCBAPAML();
			data.LHPDDGIJKNB(i + 1);
			AOHBAOAPGDM_Raw.Add(data);
		}
		EOHPPNNLBNH_Stamp.Clear();
		for(int i = 0; i < 2; i++)
		{
			ODHIHCNALDL data = new ODHIHCNALDL();
			data.LHPDDGIJKNB();
			EOHPPNNLBNH_Stamp.Add(data);
		}
	}

	// // RVA: 0xD86020 Offset: 0xD86020 VA: 0xD86020 Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH)
	{
		TodoLogger.Log(0, "OKJPIBHMKMJ");
	}

	// // RVA: 0xD87544 Offset: 0xD87544 VA: 0xD87544 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool isInvalid = false;
		if (!OILEIIEIBHP.BBAJPINMOEP_Contains(JIKKNHIAEKG_BlockName))
			isInvalid = true;
		else
		{
			if (!OILEIIEIBHP[JIKKNHIAEKG_BlockName].BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev))
				isInvalid = true;
			else
			{
				if ((int)OILEIIEIBHP[JIKKNHIAEKG_BlockName][AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] != 2)
					isInvalid = true;
			}
			EDOHBJAPLPF_JsonData block = OILEIIEIBHP[JIKKNHIAEKG_BlockName];
			PCBLFLDMCJA_StampDay = CJAENOMGPDA_ReadInt(block, "stamp_day", 0, ref isInvalid);
			FADAJDBCBJK_TopPlanDay = CJAENOMGPDA_ReadInt(block, "topplan_day", 0, ref isInvalid);
			FLBJKACKNOI_CurStamp = CJAENOMGPDA_ReadInt(block, "cur_stamp", 0, ref isInvalid);
			FCPHDFKFDCK_LoginCnt = CJAENOMGPDA_ReadInt(block, "login_cnt", 0, ref isInvalid);
			HKABHJKHFKL_RareGetCnt = CJAENOMGPDA_ReadInt(block, "rare_get_cnt", 0, ref isInvalid);
			JAMCDEDFHHK_HotenCnt = CJAENOMGPDA_ReadInt(block, "hoten_cnt", 0, ref isInvalid);
			KJBOIGIDKIF_Platform = CJAENOMGPDA_ReadInt(block, "platform", 0, ref isInvalid);
			PMCKOEGANFB_Status = CJAENOMGPDA_ReadInt(block, "status", 0, ref isInvalid);
			BKONHFNBHKL_Aextm = DKMPHAPBDLH_ReadLong(block, "aextm", 0, ref isInvalid);
			CPENFPEPDFC_Lguk.DNJEJEANJGL_Value = FGCNMLBACGO_ReadString(block, "lguk", "", ref isInvalid);
			BPMLNLPDCAJ_Lauk.DNJEJEANJGL_Value = FGCNMLBACGO_ReadString(block, "lauk", "", ref isInvalid);
			if (block.BBAJPINMOEP_Contains("first"))
			{
				EDOHBJAPLPF_JsonData b = block["first"];
				for (int i = 0; i < DNKJAIHCDFN_First.Count; i++)
				{
					string str = POFDDFCGEGP + (i + 1).ToString();
					if (b.BBAJPINMOEP_Contains(str))
					{
						EDOHBJAPLPF_JsonData b2 = b[str];
						LCDJCBAPAML data = DNKJAIHCDFN_First[i];
						data.PPFNGGCBJKC_Id = CJAENOMGPDA_ReadInt(block, AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id, i + 1, ref isInvalid);
						data.FDFGEMODIIF_StartedAt = DKMPHAPBDLH_ReadLong(block, "started_at", 0, ref isInvalid);
						data.NKMNFPMMJND_ExpiredAt = DKMPHAPBDLH_ReadLong(block, "expired_at", 0, ref isInvalid);
						data.EMOHDABPCHD_CheckAt = DKMPHAPBDLH_ReadLong(block, "checked_at", 0, ref isInvalid);
					}
				}
			}
			else
			{
				isInvalid = true;
			}
			if (block.BBAJPINMOEP_Contains("last"))
			{
				EDOHBJAPLPF_JsonData b = block["last"];
				for (int i = 0; i < FMPLMFLMJNE_Last.Count; i++)
				{
					string str = POFDDFCGEGP + (i + 1).ToString();
					if (b.BBAJPINMOEP_Contains(str))
					{
						EDOHBJAPLPF_JsonData b2 = b[str];
						LCDJCBAPAML data = FMPLMFLMJNE_Last[i];
						data.PPFNGGCBJKC_Id = CJAENOMGPDA_ReadInt(block, AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id, i + 1, ref isInvalid);
						data.FDFGEMODIIF_StartedAt = DKMPHAPBDLH_ReadLong(block, "started_at", 0, ref isInvalid);
						data.NKMNFPMMJND_ExpiredAt = DKMPHAPBDLH_ReadLong(block, "expired_at", 0, ref isInvalid);
						data.EMOHDABPCHD_CheckAt = DKMPHAPBDLH_ReadLong(block, "checked_at", 0, ref isInvalid);
					}
				}
			}
			else
			{
				isInvalid = true;
			}
			if (block.BBAJPINMOEP_Contains("raw"))
			{
				EDOHBJAPLPF_JsonData b = block["raw"];
				for (int i = 0; i < AOHBAOAPGDM_Raw.Count; i++)
				{
					string str = POFDDFCGEGP + (i + 1).ToString();
					if (b.BBAJPINMOEP_Contains(str))
					{
						EDOHBJAPLPF_JsonData b2 = b[str];
						LCDJCBAPAML data = AOHBAOAPGDM_Raw[i];
						data.PPFNGGCBJKC_Id = CJAENOMGPDA_ReadInt(block, AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id, i + 1, ref isInvalid);
						data.FDFGEMODIIF_StartedAt = DKMPHAPBDLH_ReadLong(block, "started_at", 0, ref isInvalid);
						data.NKMNFPMMJND_ExpiredAt = DKMPHAPBDLH_ReadLong(block, "expired_at", 0, ref isInvalid);
						data.EMOHDABPCHD_CheckAt = DKMPHAPBDLH_ReadLong(block, "checked_at", 0, ref isInvalid);
					}
				}
			}
			else
			{
				isInvalid = true;
			}
			if (block.BBAJPINMOEP_Contains("stamp"))
			{
				EDOHBJAPLPF_JsonData b = block["stamp"];
				for (int i = 0; i < EOHPPNNLBNH_Stamp.Count; i++)
				{
					string str = POFDDFCGEGP + (i + 1).ToString();
					if (b.BBAJPINMOEP_Contains(str))
					{
						EDOHBJAPLPF_JsonData b2 = b[str];
						ODHIHCNALDL data = EOHPPNNLBNH_Stamp[i];
						data.JJPDPNJFBHN_TableId = CJAENOMGPDA_ReadInt(b2, "table_id", 0, ref isInvalid);
						data.MMPCPKODGKI_ResetAt = DKMPHAPBDLH_ReadLong(b2, "reset_at", 0, ref isInvalid);
						IEKHEAMPLDA_ReadLongArray(b2, "dates", 0, 20, (int OIPCCBHIKIA, long JBGEEPFKIGG) =>
						{
							//0x17F1120
							data.ACCIBAABEPN(OIPCCBHIKIA, JBGEEPFKIGG);
						}, ref isInvalid);
					}
				}
			}
			else
			{
				isInvalid = true;
			}
			MPLPHLAHJOC_StampHosei = CJAENOMGPDA_ReadInt(block, "stamp_hosei", 0, ref isInvalid);
		}
		KFKDMBPNLJK_BlockInvalid = isInvalid;
		return true;
	}

	// // RVA: 0xD88AD4 Offset: 0xD88AD4 VA: 0xD88AD4 Slot: 7
	public override void BMGGKONLFIC(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		LGIDLHLBFFJ_MonthlyPass m = GPBJHKLFCEP as LGIDLHLBFFJ_MonthlyPass;
		PCBLFLDMCJA_StampDay = m.PCBLFLDMCJA_StampDay;
		FADAJDBCBJK_TopPlanDay = m.FADAJDBCBJK_TopPlanDay;
		FLBJKACKNOI_CurStamp = m.FLBJKACKNOI_CurStamp;
		FCPHDFKFDCK_LoginCnt = m.FCPHDFKFDCK_LoginCnt;
		HKABHJKHFKL_RareGetCnt = m.HKABHJKHFKL_RareGetCnt;
		JAMCDEDFHHK_HotenCnt = m.JAMCDEDFHHK_HotenCnt;
		KJBOIGIDKIF_Platform = m.KJBOIGIDKIF_Platform;
		PMCKOEGANFB_Status = m.PMCKOEGANFB_Status;
		MPLPHLAHJOC_StampHosei = m.MPLPHLAHJOC_StampHosei;
		BKONHFNBHKL_Aextm = m.BKONHFNBHKL_Aextm;
		CPENFPEPDFC_Lguk.DNJEJEANJGL_Value = m.CPENFPEPDFC_Lguk.DNJEJEANJGL_Value;
		BPMLNLPDCAJ_Lauk.DNJEJEANJGL_Value = m.BPMLNLPDCAJ_Lauk.DNJEJEANJGL_Value;
		for(int i = 0; i < DNKJAIHCDFN_First.Count; i++)
		{
			DNKJAIHCDFN_First[i].ODDIHGPONFL(m.DNKJAIHCDFN_First[i]);
		}
		for(int i = 0; i < FMPLMFLMJNE_Last.Count; i++)
		{
			FMPLMFLMJNE_Last[i].ODDIHGPONFL(m.FMPLMFLMJNE_Last[i]);
		}
		for(int i = 0; i < AOHBAOAPGDM_Raw.Count; i++)
		{
			AOHBAOAPGDM_Raw[i].ODDIHGPONFL(m.AOHBAOAPGDM_Raw[i]);
		}
		for(int i = 0; i < EOHPPNNLBNH_Stamp.Count; i++)
		{
			EOHPPNNLBNH_Stamp[i].ODDIHGPONFL(m.EOHPPNNLBNH_Stamp[i]);
		}
	}

	// // RVA: 0xD89128 Offset: 0xD89128 VA: 0xD89128 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		TodoLogger.Log(0, "AGBOGBEOFME");
		return true;
	}

	// // RVA: 0xD897EC Offset: 0xD897EC VA: 0xD897EC Slot: 10
	public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock GJLFANGDGCL, long MCKEOKFMLAH)
	{
		TodoLogger.Log(0, "AGHKODFKOJI");
	}

	// // RVA: 0xD8A954 Offset: 0xD8A954 VA: 0xD8A954 Slot: 11
	public override FENCAJJBLBH PFAKPFKJJKA()
	{
		TodoLogger.Log(0, "TODO");
		return null;
	}

	// // RVA: 0xD8AC14 Offset: 0xD8AC14 VA: 0xD8AC14
	public string POGHKGLHHFL()
	{
		return CPENFPEPDFC_Lguk.DNJEJEANJGL_Value;
	}

	// // RVA: 0xD8AC40 Offset: 0xD8AC40 VA: 0xD8AC40
	// public string KIHJLOGLAGI() { }
}
