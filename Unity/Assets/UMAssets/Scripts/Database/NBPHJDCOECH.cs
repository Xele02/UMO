using System.Collections.Generic;

public delegate int MMBLPLOGFLG();

public class NBPHJDCOECH { }
public class NBPHJDCOECH_Drop : DIHHCBACKGG_DbSection
{
	public static bool NLLKIMFBAEK; // 0x0
	public static bool FPBJKDHBAEB; // 0x1
	public const int CKGGOALFGPI = 20;

	public List<HNJKJCDDIMG_SetInfo> KPEOJPKLJBH_Set { get; set; } // 0x20 FOJMJKCMCED NEODOAEJINJ AMFOMLAFBED
	public List<OPGDJANLKBM_RateInfo> FDCBLEDPHBM_Rate { get; set; } // 0x24 APOHGMMKNOJ ALNCBMECJAN DGKIKDOLCMI
	public List<HNJKJCDDIMG_SetInfo> LMILCGIFPGC_RareSet { get; set; } // 0x28 DPBDLJDLIMJ FJBJELOLNCI OLGOKPCMNGM
	public List<OPGDJANLKBM_RateInfo> ABNFGCEDJIM_RareRate { get; set; } // 0x2C MKIAFMEMOJN CHBBOIPJLJJ BCDPIGEJELC
	public List<CEBFFLDKAEC_SecureInt> BNFPHOEFKBA_GameDropRate { get; set; } // 0x30 NHBDHAIBAJO NJBCHDJJOPN EMCEEEAGDPO
	public List<int> CFECAEBGLIH_GameDropMaNe { get; set; } // 0x34 PIJCEHMBFNE PFLDEOFEMPN LLHAMPBDIKM
	public List<int> BFNDKINIEOE_GameDropMaEq { get; set; } // 0x38 INHFABMFKKJ GNLAEACBOIB JPHGKDMLIIB
	public List<CEBFFLDKAEC_SecureInt> ENLMDHJIPLA_GameDropEvCnt { get; set; } // 0x3C DKPDFOKBOJM CJHADKDFMGO DKOGCBIPBDI
	public List<CEBFFLDKAEC_SecureInt> DGCBAFGBOCL_GameDropEvBns { get; set; } // 0x40 MNPELONMGFI DIIKFNBIKJF PPAMAOAGPHO

	//// RVA: 0x17C7B94 Offset: 0x17C7B94 VA: 0x17C7B94
	public HNJKJCDDIMG_SetInfo NMGAAKPJPLB(int LIHEBNPAIFI)
	{
		return KPEOJPKLJBH_Set.Find((HNJKJCDDIMG_SetInfo PKLPKMLGFGK) =>
		{
			//0x17CBA5C
			return LIHEBNPAIFI == PKLPKMLGFGK.LIHEBNPAIFI_SId;
		});
	}

	//// RVA: 0x17C7C94 Offset: 0x17C7C94 VA: 0x17C7C94
	public OPGDJANLKBM_RateInfo KPDHGNEILPO(int BFOLFCOBBJD)
	{
		return FDCBLEDPHBM_Rate.Find((OPGDJANLKBM_RateInfo PKLPKMLGFGK) =>
		{
			//0x17CBAA0
			return BFOLFCOBBJD == PKLPKMLGFGK.BFOLFCOBBJD_RId;
		});
	}

	//// RVA: 0x17C7D94 Offset: 0x17C7D94 VA: 0x17C7D94
	public HNJKJCDDIMG_SetInfo OHGDKJFDIKK(int LIHEBNPAIFI)
	{
		return LMILCGIFPGC_RareSet.Find((HNJKJCDDIMG_SetInfo PKLPKMLGFGK) =>
		{
			//0x17CBAD8
			return LIHEBNPAIFI == PKLPKMLGFGK.LIHEBNPAIFI_SId;
		});
	}

	//// RVA: 0x17C7E94 Offset: 0x17C7E94 VA: 0x17C7E94
	public OPGDJANLKBM_RateInfo OGBNNMOIBOP(int BFOLFCOBBJD)
	{
		return ABNFGCEDJIM_RareRate.Find((OPGDJANLKBM_RateInfo PKLPKMLGFGK) =>
		{
			//0x17CBB1C
			return PKLPKMLGFGK.BFOLFCOBBJD_RId == BFOLFCOBBJD;
		});
	}

	//// RVA: 0x17C7F94 Offset: 0x17C7F94 VA: 0x17C7F94
	private List<DNAEGJGAKEI> DGMNLKDEDDC(KEODKEGFDLD GEAANLPDJBP_MusicInfo, int EBBCGFOGKNE_Diff, int MNNHHJBBICA_GameEventType, int MFJKNCACBDG_OpenEventType, bool GIKLNODJKFK_IsLine6)
	{
		int a = GEAANLPDJBP_MusicInfo.NCCFJCDMBFO(GIKLNODJKFK_IsLine6);
		int b = GEAANLPDJBP_MusicInfo.CCLIOBOGFHC;
		if (MFJKNCACBDG_OpenEventType != 0)
		{
			TodoLogger.Log(0, "DGMNLKDEDDC event");
		}
		return DGMNLKDEDDC(GEAANLPDJBP_MusicInfo.JCDKMICANJO, GEAANLPDJBP_MusicInfo.ONLFLGPMAAN(GIKLNODJKFK_IsLine6) + EBBCGFOGKNE_Diff, b, a + EBBCGFOGKNE_Diff);
	}

	//// RVA: 0x17C8180 Offset: 0x17C8180 VA: 0x17C8180
	private List<DNAEGJGAKEI> DGMNLKDEDDC(int HECHAICHKAF, int PLLAIBDLKHB, int LHJGKGEOOPG, int MPEPBMCGEAI)
	{
		List<DNAEGJGAKEI> res = new List<DNAEGJGAKEI>();
		HNJKJCDDIMG_SetInfo s = OHGDKJFDIKK(HECHAICHKAF);
		OPGDJANLKBM_RateInfo r = OGBNNMOIBOP(PLLAIBDLKHB);
		HNJKJCDDIMG_SetInfo rs = OHGDKJFDIKK(LHJGKGEOOPG);
		OPGDJANLKBM_RateInfo rr = OGBNNMOIBOP(MPEPBMCGEAI);
		if(s != null && r != null)
		{
			for(int i = 0; i < 20; i++)
			{
				int a = s.FKNBLDPIPMC(i);
				int b = r.ADKDHKMPMHP_Rat[i];
				int c = a > 0 ? b : a;
				if(c > 0)
				{
					DNAEGJGAKEI data = new DNAEGJGAKEI();
					data.OIPCCBHIKIA = 0x10000000 | i;
					data.KIJAPOFAGPN = a;
					data.MKNDAOHGOAK = b;
					int d = r.DOOGFEGEKLG_Max[i];
					if(d == 0)
						d = 9999;
					data.OBKKLILJJFP = d;
					res.Add(data);
				}
			}
		}
		if(rs != null && rr != null)
		{
			for(int i = 0; i < 20; i++)
			{
				int a = rs.FKNBLDPIPMC(i);
				int b = rr.ADKDHKMPMHP_Rat[i];
				int c = a > 0 ? b : a;
				if (c > 0)
				{
					DNAEGJGAKEI data = new DNAEGJGAKEI();
					data.OIPCCBHIKIA = 0x20000000 | i;
					data.KIJAPOFAGPN = a;
					data.MKNDAOHGOAK = b;
					int d = r.DOOGFEGEKLG_Max[i];
					if (d == 0)
						d = 9999;
					data.OBKKLILJJFP = d;
					res.Add(data);
				}
			}
		}
		return res;
	}

	//// RVA: 0x17C863C Offset: 0x17C863C VA: 0x17C863C
	private int GOFELPFHNBP(List<DNAEGJGAKEI> CDENCMNHNGA, MMBLPLOGFLG JLDAJBCHMOC)
	{
		List<int> l = new List<int>();
		int res = 0;
		int sum = 0;
		for(int i = 0; i < CDENCMNHNGA.Count; i++)
		{
			sum += CDENCMNHNGA[i].MKNDAOHGOAK;
			l.Add(sum);
		}
		int a = JLDAJBCHMOC();
		int mod = a % sum;
		for(int i = 0; i < CDENCMNHNGA.Count; i++)
		{
			res = l[i];
			if (mod < res)
				return i;
		}
		return CDENCMNHNGA.Count - 1;
	}

	//// RVA: 0x17C883C Offset: 0x17C883C VA: 0x17C883C
	//private bool ABNDDDNPOED(List<DNAEGJGAKEI> CDENCMNHNGA, EKLNMHFCAOI.FKGCBLHOOCL OKOOPFAGBKO, out int OIPCCBHIKIA) { }

	//// RVA: 0x17C8978 Offset: 0x17C8978 VA: 0x17C8978
	public List<DNAEGJGAKEI> JMHHEPMILHA(KEODKEGFDLD GEAANLPDJBP_MusicInfo, int EBBCGFOGKNE_Diff, int MNNHHJBBICA_GameEventType, int MFJKNCACBDG_OpenEventType, int HMFFHLPNMPH, MMBLPLOGFLG JLDAJBCHMOC_Delegate, bool GIKLNODJKFK_IsLine6 = false)
	{
		List<DNAEGJGAKEI> l = DGMNLKDEDDC(GEAANLPDJBP_MusicInfo, EBBCGFOGKNE_Diff, MNNHHJBBICA_GameEventType, MFJKNCACBDG_OpenEventType, GIKLNODJKFK_IsLine6);
		List<DNAEGJGAKEI> res = new List<DNAEGJGAKEI>(HMFFHLPNMPH);
		for(int i = HMFFHLPNMPH + 1; i > 1; i--)
		{
			if (l.Count == 0)
				return res;
			int idx = GOFELPFHNBP(l, JLDAJBCHMOC_Delegate);
			DNAEGJGAKEI d = l[idx];
			res.Add(d);
			d.OBKKLILJJFP = d.OBKKLILJJFP - 1;
			if(d.OBKKLILJJFP < 1)
			{
				l.RemoveAt(idx);
			}
		}
		return res;
	}

	//// RVA: 0x17C8C14 Offset: 0x17C8C14 VA: 0x17C8C14
	public NBPHJDCOECH_Drop()
	{
		JIKKNHIAEKG_BlockName = "";
		KPEOJPKLJBH_Set = new List<HNJKJCDDIMG_SetInfo>();
		FDCBLEDPHBM_Rate = new List<OPGDJANLKBM_RateInfo>();
		LMILCGIFPGC_RareSet = new List<HNJKJCDDIMG_SetInfo>();
		ABNFGCEDJIM_RareRate = new List<OPGDJANLKBM_RateInfo>();
		BNFPHOEFKBA_GameDropRate = new List<CEBFFLDKAEC_SecureInt>(6);
		CFECAEBGLIH_GameDropMaNe = new List<int>(4);
		BFNDKINIEOE_GameDropMaEq = new List<int>(4);
		ENLMDHJIPLA_GameDropEvCnt = new List<CEBFFLDKAEC_SecureInt>(5);
		LMHMIIKCGPE = 21;
		DGCBAFGBOCL_GameDropEvBns = new List<CEBFFLDKAEC_SecureInt>(5);
		LNIMEIMBCMF = false;
	}

	//// RVA: 0x17C8E30 Offset: 0x17C8E30 VA: 0x17C8E30 Slot: 8
	protected override void KMBPACJNEOF() { }

	//// RVA: 0x17C9008 Offset: 0x17C9008 VA: 0x17C9008 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		MGOOKLACCAB parser = MGOOKLACCAB.HEGEKFMJNCC(DBBGALAPFGC);
		CBJFAAOIHHJ(parser);
		KFHCBHNEHKO(parser);
		KGFJBMIDNKD(parser);
		DLEALKELBFF(parser);
		LAFIHNNCCOA_Deserialize_GameDrop(parser);
		return true;
	}

	// RVA: 0x17CA22C Offset: 0x17CA22C VA: 0x17CA22C Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		TodoLogger.Log(0, "Deserialize NBPHJDCOECH_Drop");
		return false;
	}

	//// RVA: 0x17C9068 Offset: 0x17C9068 VA: 0x17C9068
	private bool CBJFAAOIHHJ(MGOOKLACCAB DPMMILMCLLB) // rate
	{
		JOBPCOAEJEI[] array = DPMMILMCLLB.EPNKMPDCNJM;
		for(int i = 0; i < array.Length; i++)
		{
			OPGDJANLKBM_RateInfo data = new OPGDJANLKBM_RateInfo();
			data.BFOLFCOBBJD_RId = (int)array[i].INJIPPBFMIG;
			{
				uint[] array2 = array[i].EHKJFNAABMC;
				for(int j = 0; j < array2.Length; j++)
				{
					data.ADKDHKMPMHP_Rat[j] = (int)array2[j];
				}
			}
			{
				uint[] array2 = array[i].BFINGCJHOHI;
				for (int j = 0; j < array2.Length; j++)
				{
					data.HMFFHLPNMPH_Cnt[j] = (int)array2[j];
				}
			}
			{
				uint[] array2 = array[i].DOOGFEGEKLG;
				for (int j = 0; j < array2.Length; j++)
				{
					data.DOOGFEGEKLG_Max[j] = (int)array2[j];
				}
			}
			FDCBLEDPHBM_Rate.Add(data);
		}
		return true;
	}

	//// RVA: 0x17CA400 Offset: 0x17CA400 VA: 0x17CA400
	//private bool CBJFAAOIHHJ(EDOHBJAPLPF OBHAFLMHAKG, int KAPMOPMDHJE) { }

	//// RVA: 0x17C948C Offset: 0x17C948C VA: 0x17C948C
	private bool KFHCBHNEHKO(MGOOKLACCAB DPMMILMCLLB)
	{
		PPAILKPGOHE[] array = DPMMILMCLLB.NLLEGNEHGFO;
		for(int i = 0; i < array.Length; i++)
		{
			HNJKJCDDIMG_SetInfo data = new HNJKJCDDIMG_SetInfo();
			data.LIHEBNPAIFI_SId = (int)array[i].BDJMFDKLHPM;
			uint[] array2 = array[i].AIHOJKFNEEN;
			for(int j = 0; j < array2.Length; j++)
			{
				data.OEFHMMJFEKC(j, (int)array2[j]);
			}
			KPEOJPKLJBH_Set.Add(data);
		}
		return true;
	}

	//// RVA: 0x17CA7C8 Offset: 0x17CA7C8 VA: 0x17CA7C8
	//private bool KFHCBHNEHKO(EDOHBJAPLPF OBHAFLMHAKG, int KAPMOPMDHJE) { }

	//// RVA: 0x17C96EC Offset: 0x17C96EC VA: 0x17C96EC
	private bool KGFJBMIDNKD(MGOOKLACCAB DPMMILMCLLB) // rare_rate
	{
		ENDMPLADFDI[] array = DPMMILMCLLB.GFFKLDFECOD;
		for(int i = 0; i < array.Length; i++)
		{
			OPGDJANLKBM_RateInfo data = new OPGDJANLKBM_RateInfo();
			data.BFOLFCOBBJD_RId = (int)array[i].INJIPPBFMIG;
			{
				uint[] array2 = array[i].EHKJFNAABMC;
				for (int j = 0; j < array2.Length; j++)
				{
					data.ADKDHKMPMHP_Rat[j] = (int)array2[j];
					if (data.ADKDHKMPMHP_Rat[j] > 0)
						data.HMFFHLPNMPH_Cnt[j] = 1;
				}
			}
			{
				uint[] array2 = array[i].DOOGFEGEKLG;
				for (int j = 0; j < array2.Length; j++)
				{
					data.DOOGFEGEKLG_Max[j] = (int)array2[j];
				}
			}
			ABNFGCEDJIM_RareRate.Add(data);
		}
		return true;
	}

	//// RVA: 0x17CAABC Offset: 0x17CAABC VA: 0x17CAABC
	//private bool KGFJBMIDNKD(EDOHBJAPLPF OBHAFLMHAKG, int KAPMOPMDHJE) { }

	//// RVA: 0x17C9AB4 Offset: 0x17C9AB4 VA: 0x17C9AB4
	private bool DLEALKELBFF(MGOOKLACCAB DPMMILMCLLB)
	{
		HPCDKBLCICB[] array = DPMMILMCLLB.FCKIKCOMCGA;
		for (int i = 0; i < array.Length; i++)
		{
			HNJKJCDDIMG_SetInfo data = new HNJKJCDDIMG_SetInfo();
			data.LIHEBNPAIFI_SId = (int)array[i].BDJMFDKLHPM;
			uint[] array2 = array[i].AIHOJKFNEEN;
			for (int j = 0; j < array2.Length; j++)
			{
				data.OEFHMMJFEKC(j, (int)array2[j]);
			}
			LMILCGIFPGC_RareSet.Add(data);
		}
		return true;
	}

	//// RVA: 0x17CAF3C Offset: 0x17CAF3C VA: 0x17CAF3C
	//private bool DLEALKELBFF(EDOHBJAPLPF OBHAFLMHAKG, int KAPMOPMDHJE) { }

	//// RVA: 0x17CB230 Offset: 0x17CB230 VA: 0x17CB230
	//private bool LAFIHNNCCOA(EDOHBJAPLPF OBHAFLMHAKG, int KAPMOPMDHJE) { }

	//// RVA: 0x17C9D14 Offset: 0x17C9D14 VA: 0x17C9D14
	private bool LAFIHNNCCOA_Deserialize_GameDrop(MGOOKLACCAB DPMMILMCLLB)
	{
		{
			int[] array = DPMMILMCLLB.CHPPGDIEJPK;
			for(int i = 0; i < array.Length; i++)
			{
				CEBFFLDKAEC_SecureInt data = new CEBFFLDKAEC_SecureInt();
				data.DNJEJEANJGL_Value = array[i];
				BNFPHOEFKBA_GameDropRate.Add(data);
			}
		}
		{
			int[] array = DPMMILMCLLB.DPBLNJLNMOF;
			for (int i = 0; i < array.Length; i++)
			{
				BFNDKINIEOE_GameDropMaEq.Add(array[i]);
			}
		}
		{
			int[] array = DPMMILMCLLB.JLDHMJLGGDO;
			for (int i = 0; i < array.Length; i++)
			{
				CFECAEBGLIH_GameDropMaNe.Add(array[i]);
			}
		}
		{
			int[] array = DPMMILMCLLB.FHPCBBOAHLJ;
			for (int i = 0; i < array.Length; i++)
			{
				CEBFFLDKAEC_SecureInt data = new CEBFFLDKAEC_SecureInt();
				data.DNJEJEANJGL_Value = array[i];
				ENLMDHJIPLA_GameDropEvCnt.Add(data);
			}
		}
		{
			int[] array = DPMMILMCLLB.IFJHGKNBGIC;
			for (int i = 0; i < array.Length; i++)
			{
				CEBFFLDKAEC_SecureInt data = new CEBFFLDKAEC_SecureInt();
				data.DNJEJEANJGL_Value = array[i];
				DGCBAFGBOCL_GameDropEvBns.Add(data);
			}
		}
		return true;
	}

	//// RVA: 0x17CB474 Offset: 0x17CB474 VA: 0x17CB474 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(0, "NBPHJDCOECH_Drop CAOGDCBPBAN");
		return 0;
	}

	//[CompilerGeneratedAttribute] // RVA: 0x6C0010 Offset: 0x6C0010 VA: 0x6C0010
	//// RVA: 0x17CB71C Offset: 0x17CB71C VA: 0x17CB71C
	//private void <Deserialize_GameDrop>b__60_0(int OIPCCBHIKIA, int JBGEEPFKIGG) { }

	//[CompilerGeneratedAttribute] // RVA: 0x6C0020 Offset: 0x6C0020 VA: 0x6C0020
	//// RVA: 0x17CB7DC Offset: 0x17CB7DC VA: 0x17CB7DC
	//private void <Deserialize_GameDrop>b__60_1(int OIPCCBHIKIA, int JBGEEPFKIGG) { }

	//[CompilerGeneratedAttribute] // RVA: 0x6C0030 Offset: 0x6C0030 VA: 0x6C0030
	//// RVA: 0x17CB85C Offset: 0x17CB85C VA: 0x17CB85C
	//private void <Deserialize_GameDrop>b__60_2(int OIPCCBHIKIA, int JBGEEPFKIGG) { }

	//[CompilerGeneratedAttribute] // RVA: 0x6C0040 Offset: 0x6C0040 VA: 0x6C0040
	//// RVA: 0x17CB8DC Offset: 0x17CB8DC VA: 0x17CB8DC
	//private void <Deserialize_GameDrop>b__60_3(int OIPCCBHIKIA, int JBGEEPFKIGG) { }

	//[CompilerGeneratedAttribute] // RVA: 0x6C0050 Offset: 0x6C0050 VA: 0x6C0050
	//// RVA: 0x17CB99C Offset: 0x17CB99C VA: 0x17CB99C
	//private void <Deserialize_GameDrop>b__60_4(int OIPCCBHIKIA, int JBGEEPFKIGG) { }
}
