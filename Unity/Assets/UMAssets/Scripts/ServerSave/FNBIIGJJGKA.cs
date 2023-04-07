
using System;
using XeSys;

[System.Obsolete("Use FNBIIGJJGKA_Counter", true)]
public class FNBIIGJJGKA {}
public class FNBIIGJJGKA_Counter : KLFDBFMNLBL_ServerSaveBlock
{
	private const int ECFEMKGFDCE = 2;
	private const int MKINOABMBGM = 20;
	private const int FOBFLHIIJOM = 100;
	private const int PNFLFNNAAPL = 5;
	private const long EBABKJBHKDF = 9999999999;
	private const long GKIALDDPKNF = 99999;
	private const int AFHHHFICNIN = 12;
	public OHDCBNFDHLA EJFAEKPGKNJ_Day; // 0x24
	public NAKMCMEPAGH BDLNMOIOMHK_Total; // 0x28
	public byte[] NONMPJBNBNN_MClr = new byte[300]; // 0x2C
	public byte[] CFHOMPIKIGK_MFCb = new byte[300]; // 0x30
	public byte[] NDBEHBMEGGI_MClr16 = new byte[300]; // 0x34
	public byte[] DNKKDCHJJHF_MFCb16 = new byte[300]; // 0x38
	public long[] NJIDHLPGBFO_TTap = new long[5]; // 0x3C
	public long PCBJHBCNNGD_TClr; // 0x40

	// public override bool DMICHEJIAJL { get; }

	// // RVA: 0x119E81C Offset: 0x119E81C VA: 0x119E81C
	// public void BEJONIOEGCI(int DLAEJOBELBH_Id, int AKNELONELJK, bool BCGLDMKODLC, bool NANEGCHBEDN, List<int> PGPBALKFBNK, bool PMCGHPOGLGM, bool GIKLNODJKFK = False) { }

	// // RVA: 0x119EAD0 Offset: 0x119EAD0 VA: 0x119EAD0
	// private int GMKMEENIJFK(byte[] IDLHJIOMJBK, int AKNELONELJK) { }

	// // RVA: 0x119EB44 Offset: 0x119EB44 VA: 0x119EB44
	// public int MOEJDCPHJOH(int AKNELONELJK) { }

	// // RVA: 0x119EB50 Offset: 0x119EB50 VA: 0x119EB50
	// public int DGKBOGGIAKD(int AKNELONELJK) { }

	// // RVA: 0x119EB5C Offset: 0x119EB5C VA: 0x119EB5C
	// public int AMIPHDGAMLI(int AKNELONELJK) { }

	// // RVA: 0x119EB68 Offset: 0x119EB68 VA: 0x119EB68
	// public int CEPBENFKMFF(int AKNELONELJK) { }

	// // RVA: 0x119EB74 Offset: 0x119EB74 VA: 0x119EB74
	public FNBIIGJJGKA_Counter()
	{
		EJFAEKPGKNJ_Day = new OHDCBNFDHLA();
		BDLNMOIOMHK_Total = new NAKMCMEPAGH();
		KMBPACJNEOF();
	}

	// // RVA: 0x119EC90 Offset: 0x119EC90 VA: 0x119EC90 Slot: 4
	public override void KMBPACJNEOF()
	{
		EJFAEKPGKNJ_Day.LHPDDGIJKNB();
		BDLNMOIOMHK_Total.LHPDDGIJKNB();
		for(int i = 0; i < 300; i++)
		{
			NONMPJBNBNN_MClr[i] = 0;
			CFHOMPIKIGK_MFCb[i] = 0;
			NDBEHBMEGGI_MClr16[i] = 0;
			DNKKDCHJJHF_MFCb16[i] = 0;
		}
		for(int i = 0; i < 5; i++)
		{
			NJIDHLPGBFO_TTap[i] = 0;
		}
		PCBJHBCNNGD_TClr = 0;
	}

	// // RVA: 0x119EE28 Offset: 0x119EE28 VA: 0x119EE28 Slot: 5
	// public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH) { }

	// // RVA: 0x11A05F4 Offset: 0x11A05F4 VA: 0x11A05F4 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		if(OILEIIEIBHP.BBAJPINMOEP_Contains(JIKKNHIAEKG_BlockName))
		{
			OILEIIEIBHP = OILEIIEIBHP[JIKKNHIAEKG_BlockName];
		}
		bool isInvalid = true;
		if(OILEIIEIBHP.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev))
		{
			if ((int)OILEIIEIBHP[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] == 2)
				isInvalid = false;
		}
		if(OILEIIEIBHP.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.BAOFEFFADPD_day))
		{
			EDOHBJAPLPF_JsonData b = OILEIIEIBHP[AFEHLCGHAEE_Strings.BAOFEFFADPD_day];
			EJFAEKPGKNJ_Day.BEBJKJKBOGH_Date = DKMPHAPBDLH_ReadLong(b, AFEHLCGHAEE_Strings.BEBJKJKBOGH_Date, 0, ref isInvalid);
			EJFAEKPGKNJ_Day.MILCBLJDADN_MClr = CJAENOMGPDA_ReadInt(b, AFEHLCGHAEE_Strings.EJKHAFIALGK_mclr, 0, ref isInvalid);
			EJFAEKPGKNJ_Day.NDNHHGJKJGM_Gach = CJAENOMGPDA_ReadInt(b, AFEHLCGHAEE_Strings.LAALIAKBNIB_gach, 0, ref isInvalid);
			EJFAEKPGKNJ_Day.GACBDCLPOCD_Sdv = CJAENOMGPDA_ReadInt(b, AFEHLCGHAEE_Strings.KHPFMNAKBKE_sdv, 0, ref isInvalid);
			EJFAEKPGKNJ_Day.MPHFGEPJOGL_AS = CJAENOMGPDA_ReadInt(b, AFEHLCGHAEE_Strings.ELBJIFCDJGO_a_s, 0, ref isInvalid);
			IBCGPBOGOGP_ReadIntArray(b, AFEHLCGHAEE_Strings.GPNPBHLLHDI_srnk, 0, EJFAEKPGKNJ_Day.GEIONHDKGEB_SRnk.Length, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
			{
				//0x11A3928
				EJFAEKPGKNJ_Day.GEIONHDKGEB_SRnk[OIPCCBHIKIA] = JBGEEPFKIGG;
			}, ref isInvalid);
		}
		if(OILEIIEIBHP.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.BDLNMOIOMHK_total))
		{
			EDOHBJAPLPF_JsonData b = OILEIIEIBHP[AFEHLCGHAEE_Strings.BDLNMOIOMHK_total];
			BDLNMOIOMHK_Total.MILCBLJDADN_MusicClear = CJAENOMGPDA_ReadInt(b, AFEHLCGHAEE_Strings.EJKHAFIALGK_mclr, 0, ref isInvalid);
			BDLNMOIOMHK_Total.HLNOELCIBPH_Perf = CJAENOMGPDA_ReadInt(b, AFEHLCGHAEE_Strings.NJDCEFLEPEG_perf, 0, ref isInvalid);
			BDLNMOIOMHK_Total.FILFPNDEINH_Fcb = CJAENOMGPDA_ReadInt(b, AFEHLCGHAEE_Strings.IBOHALOCJDL_fcb, 0, ref isInvalid);
			BDLNMOIOMHK_Total.KOONLNKCIJC_SS = CJAENOMGPDA_ReadInt(b, AFEHLCGHAEE_Strings.EJOECKJNGPD_ss, 0, ref isInvalid);
			BDLNMOIOMHK_Total.HOHBKPPOLLA_Uc = DKMPHAPBDLH_ReadLong(b, AFEHLCGHAEE_Strings.ACGLMKEBMDL_uc, 0, ref isInvalid);
			BDLNMOIOMHK_Total.EDLBLCGHECJ_Max = CJAENOMGPDA_ReadInt(b, "max", 0, ref isInvalid);
			BDLNMOIOMHK_Total.GACBDCLPOCD_Sdv = CJAENOMGPDA_ReadInt(b, AFEHLCGHAEE_Strings.KHPFMNAKBKE_sdv, 0, ref isInvalid);
			BDLNMOIOMHK_Total.IMIEPNOECFD_Vk = CJAENOMGPDA_ReadInt(b, AFEHLCGHAEE_Strings.GGGFIKIHJCM_vk, 0, ref isInvalid);
			BDLNMOIOMHK_Total.BENEAPDMALA_Mk = CJAENOMGPDA_ReadInt(b, "mv", 0, ref isInvalid);
			BDLNMOIOMHK_Total.PDGJIJOMAKO_Medl = CJAENOMGPDA_ReadInt(b, "medl", 0, ref isInvalid);
			BDLNMOIOMHK_Total.PFOMECFACLL_Shp = CJAENOMGPDA_ReadInt(b, "shp", 0, ref isInvalid);
			BDLNMOIOMHK_Total.DHNOLFBEHKN_Dcshp = CJAENOMGPDA_ReadInt(b, "dcshp", 0, ref isInvalid);
			BDLNMOIOMHK_Total.NALPJPKDNGH_Dp = CJAENOMGPDA_ReadInt(b, "dp", 0, ref isInvalid);
			BDLNMOIOMHK_Total.KNCLIEBAPJD_Cosu = CJAENOMGPDA_ReadInt(b, "cosu", 0, ref isInvalid);
			BDLNMOIOMHK_Total.MJBCBJDMODC_Valu = CJAENOMGPDA_ReadInt(b, "valu", 0, ref isInvalid);
			BDLNMOIOMHK_Total.BJDKMJFCOOM_LCnt = CJAENOMGPDA_ReadInt(b, "lcnt", 0, ref isInvalid);
			BDLNMOIOMHK_Total.BKEKKFPEPBG_LDt = CJAENOMGPDA_ReadInt(b, "ldt", 0, ref isInvalid);
			IBCGPBOGOGP_ReadIntArray(b, "vopc", 0, BDLNMOIOMHK_Total.GKOAPFJFKEJ_VOpC.Length, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
			{
				//0x11A3988
				BDLNMOIOMHK_Total.GKOAPFJFKEJ_VOpC[OIPCCBHIKIA] = JBGEEPFKIGG;
			}, ref isInvalid);
			IBCGPBOGOGP_ReadIntArray(b, "dopc", 0, BDLNMOIOMHK_Total.LOOAKNLDONN_DOpC.Length, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
			{
				//0x11A39E8
				BDLNMOIOMHK_Total.LOOAKNLDONN_DOpC[OIPCCBHIKIA] = JBGEEPFKIGG;
			}, ref isInvalid);
			IBCGPBOGOGP_ReadIntArray(b, AFEHLCGHAEE_Strings.BGBKGFDLCME_sclr, 0, BDLNMOIOMHK_Total.LHOCOEOKFNO_SerieClear.Length, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
			{
				//0x11A3A48
				BDLNMOIOMHK_Total.LHOCOEOKFNO_SerieClear[OIPCCBHIKIA] = JBGEEPFKIGG;
			}, ref isInvalid);
			IBCGPBOGOGP_ReadIntArray(b, AFEHLCGHAEE_Strings.HPGEGOONHGD_dclr, 0, BDLNMOIOMHK_Total.PHPPOGOEOAF_DiffClear.Length, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
			{
				//0x11A3AA8
				BDLNMOIOMHK_Total.PHPPOGOEOAF_DiffClear[OIPCCBHIKIA] = JBGEEPFKIGG;
			}, ref isInvalid);
			IBCGPBOGOGP_ReadIntArray(b, "dclr_l6", 0, BDLNMOIOMHK_Total.IAFPEPABGJJ_DiffClear16.Length, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
			{
				//0x11A3B08
				BDLNMOIOMHK_Total.IAFPEPABGJJ_DiffClear16[OIPCCBHIKIA] = JBGEEPFKIGG;
			}, ref isInvalid);
		}
		if(OILEIIEIBHP.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.NONMPJBNBNN_m_clr))
		{
			EDOHBJAPLPF_JsonData b = OILEIIEIBHP[AFEHLCGHAEE_Strings.NONMPJBNBNN_m_clr];
			int cnt = 300;
			if(b.HNBFOAJIIAL_Count < 300)
			{
				isInvalid = true;
				cnt = b.HNBFOAJIIAL_Count;
			}
			for(int i = 0; i < cnt; i++)
			{
				NONMPJBNBNN_MClr[i] = (byte)(int)b[i];
			}
		}
		else
		{
			isInvalid = true;
		}
		if (OILEIIEIBHP.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.CFHOMPIKIGK_m_fcb))
		{
			EDOHBJAPLPF_JsonData b = OILEIIEIBHP[AFEHLCGHAEE_Strings.CFHOMPIKIGK_m_fcb];
			int cnt = 300;
			if (b.HNBFOAJIIAL_Count < 300)
			{
				isInvalid = true;
				cnt = b.HNBFOAJIIAL_Count;
			}
			for (int i = 0; i < cnt; i++)
			{
				CFHOMPIKIGK_MFCb[i] = (byte)(int)b[i];
			}
		}
		else
		{
			isInvalid = true;
		}
		if (OILEIIEIBHP.BBAJPINMOEP_Contains("m_clr_l6"))
		{
			EDOHBJAPLPF_JsonData b = OILEIIEIBHP["m_clr_l6"];
			int cnt = 300;
			if (b.HNBFOAJIIAL_Count < 300)
			{
				isInvalid = true;
				cnt = b.HNBFOAJIIAL_Count;
			}
			for (int i = 0; i < cnt; i++)
			{
				NDBEHBMEGGI_MClr16[i] = (byte)(int)b[i];
			}
		}
		else
		{
			isInvalid = true;
		}
		if (OILEIIEIBHP.BBAJPINMOEP_Contains("m_fcb_l6"))
		{
			EDOHBJAPLPF_JsonData b = OILEIIEIBHP["m_fcb_l6"];
			int cnt = 300;
			if (b.HNBFOAJIIAL_Count < 300)
			{
				isInvalid = true;
				cnt = b.HNBFOAJIIAL_Count;
			}
			for (int i = 0; i < cnt; i++)
			{
				DNKKDCHJJHF_MFCb16[i] = (byte)(int)b[i];
			}
		}
		else
		{
			isInvalid = true;
		}
		if (OILEIIEIBHP.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.NJIDHLPGBFO_t_tap))
		{
			EDOHBJAPLPF_JsonData b = OILEIIEIBHP[AFEHLCGHAEE_Strings.NJIDHLPGBFO_t_tap];
			int cnt = 5;
			if (b.HNBFOAJIIAL_Count < 5)
			{
				isInvalid = true;
				cnt = b.HNBFOAJIIAL_Count;
			}
			for (int i = 0; i < cnt; i++)
			{
				if(b[i].MDDJBLEDMBJ_IsInt)
				{
					NJIDHLPGBFO_TTap[i] = (int)b[i];
				}
				else if (b[i].DCPEFFOMOOK_IsLong)
				{
					NJIDHLPGBFO_TTap[i] = (long)b[i];
				}
			}
		}
		else
		{
			isInvalid = true;
		}
		PCBJHBCNNGD_TClr = CJAENOMGPDA_ReadInt(OILEIIEIBHP, AFEHLCGHAEE_Strings.PCBJHBCNNGD_t_clr, 0, ref isInvalid);
		KFKDMBPNLJK_BlockInvalid = isInvalid;
		return true;
	}

	// // RVA: 0x11A1E0C Offset: 0x11A1E0C VA: 0x11A1E0C Slot: 7
	public override void BMGGKONLFIC(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		FNBIIGJJGKA_Counter c = GPBJHKLFCEP as FNBIIGJJGKA_Counter;
		EJFAEKPGKNJ_Day.ODDIHGPONFL(c.EJFAEKPGKNJ_Day);
		BDLNMOIOMHK_Total.ODDIHGPONFL(c.BDLNMOIOMHK_Total);
		for(int i = 0; i < 300; i++)
		{
			NONMPJBNBNN_MClr[i] = c.NONMPJBNBNN_MClr[i];
			CFHOMPIKIGK_MFCb[i] = c.CFHOMPIKIGK_MFCb[i];
			NDBEHBMEGGI_MClr16[i] = c.NDBEHBMEGGI_MClr16[i];
			DNKKDCHJJHF_MFCb16[i] = c.DNKKDCHJJHF_MFCb16[i];
		}
		for(int i = 0; i < NJIDHLPGBFO_TTap.Length; i++)
		{
			NJIDHLPGBFO_TTap[i] = c.NJIDHLPGBFO_TTap[i];
		}
		PCBJHBCNNGD_TClr = c.PCBJHBCNNGD_TClr;
	}

	// // RVA: 0x11A21D0 Offset: 0x11A21D0 VA: 0x11A21D0 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		TodoLogger.Log(0, "AGBOGBEOFME");
		return true;
	}

	// // RVA: 0x11A25E8 Offset: 0x11A25E8 VA: 0x11A25E8 Slot: 10
	// public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL GJLFANGDGCL, long MCKEOKFMLAH) { }

	// // RVA: 0x11A3920 Offset: 0x11A3920 VA: 0x11A3920 Slot: 9
	// public override bool NFKFOODCJJB() { }
}

public class OHDCBNFDHLA
{
	private const int MNHALNODIPI = 99999999;
	public long BEBJKJKBOGH_Date; // 0x8
	public int MILCBLJDADN_MClr; // 0x10
	public int[] GEIONHDKGEB_SRnk = new int[5]; // 0x14
	public int NDNHHGJKJGM_Gach; // 0x18
	public int GACBDCLPOCD_Sdv; // 0x1C
	public int MPHFGEPJOGL_AS; // 0x20

	public long AAFMGJHLLCD_EndOfDay { get
		{
			DateTime date = Utility.GetLocalDateTime(BEBJKJKBOGH_Date);
			return Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, 23, 59, 59);
		} } //0x1DE0750 KMKOHJDPKGL

	//// RVA: 0x1DE0894 Offset: 0x1DE0894 VA: 0x1DE0894
	public void FHPENOLOPKI_CheckEndOfDay(long JHNMKKNEENE_Time, bool FBBNPFFEJBN)
	{
		if (AAFMGJHLLCD_EndOfDay >= JHNMKKNEENE_Time)
			return;
		NDNHHGJKJGM_Gach = 0;
		GACBDCLPOCD_Sdv = 0;
		MPHFGEPJOGL_AS = 0;
		BEBJKJKBOGH_Date = JHNMKKNEENE_Time;
		MILCBLJDADN_MClr = 0;
		for(int i = 0; i < GEIONHDKGEB_SRnk.Length; i++)
		{
			GEIONHDKGEB_SRnk[i] = 0;
		}
	}

	//// RVA: 0x1DE0948 Offset: 0x1DE0948 VA: 0x1DE0948
	//public void FBKAPLHEACL() { }

	//// RVA: 0x1DE0964 Offset: 0x1DE0964 VA: 0x1DE0964
	//public void DPKJNIPGGMJ(int FJOLNJLLJEJ) { }

	//// RVA: 0x1DE0A00 Offset: 0x1DE0A00 VA: 0x1DE0A00
	//public void BFAJMALBALG(int HMFFHLPNMPH) { }

	//// RVA: 0x1DE0A20 Offset: 0x1DE0A20 VA: 0x1DE0A20
	//public void MAFAKCMFHEE() { }

	//// RVA: 0x1DE0A40 Offset: 0x1DE0A40 VA: 0x1DE0A40
	//public void CIGILPOKMAN(int HMFFHLPNMPH) { }

	//// RVA: 0x1DE0A60 Offset: 0x1DE0A60 VA: 0x1DE0A60
	public void LHPDDGIJKNB()
	{
		BEBJKJKBOGH_Date = 0;
		MILCBLJDADN_MClr = 0;
		for(int i = 0; i < GEIONHDKGEB_SRnk.Length; i++)
		{
			GEIONHDKGEB_SRnk[i] = 0;
		}
		NDNHHGJKJGM_Gach = 0;
		GACBDCLPOCD_Sdv = 0;
		MPHFGEPJOGL_AS = 0;
	}

	//// RVA: 0x1DE0AF4 Offset: 0x1DE0AF4 VA: 0x1DE0AF4
	//public bool AGBOGBEOFME(OHDCBNFDHLA OIKJFMGEICL) { }

	//// RVA: 0x1DE0CD4 Offset: 0x1DE0CD4 VA: 0x1DE0CD4
	public void ODDIHGPONFL(OHDCBNFDHLA GPBJHKLFCEP)
	{
		BEBJKJKBOGH_Date = GPBJHKLFCEP.BEBJKJKBOGH_Date;
		MILCBLJDADN_MClr = GPBJHKLFCEP.MILCBLJDADN_MClr;
		NDNHHGJKJGM_Gach = GPBJHKLFCEP.NDNHHGJKJGM_Gach;
		GACBDCLPOCD_Sdv = GPBJHKLFCEP.GACBDCLPOCD_Sdv;
		MPHFGEPJOGL_AS = GPBJHKLFCEP.MPHFGEPJOGL_AS;
		for(int i = 0; i < GEIONHDKGEB_SRnk.Length; i++)
		{
			GEIONHDKGEB_SRnk[i] = GPBJHKLFCEP.GEIONHDKGEB_SRnk[i];
		}
	}

	//// RVA: 0x1DE0E1C Offset: 0x1DE0E1C VA: 0x1DE0E1C
	//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, OHDCBNFDHLA OHMCIEMIKCE, bool EFOEPDLNLJG) { }
}
