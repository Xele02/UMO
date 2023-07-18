using System.Collections.Generic;
using System;
using XeApp.Game.Common;

[System.Obsolete("Use LPPGENBEECK_musicMaster", true)]
public class LPPGENBEECK {}
public class LPPGENBEECK_MusicMaster : DIHHCBACKGG_DbSection
{
	private List<HMJHLLPBCLD> OHLOHGGCCMD; // 0x30
	private List<JPCKBFBCJKD> MGBKDJLEICI; // 0x34
	private List<HDNKOFNBCEO_RewardInfo> MGDLFOAKGGF; // 0x38
	public List<NONFIGBOJLN> NEIBEDCGDEM; // 0x3C
	public List<AIPEHINPIHC_ForcedSettingInfo> HBJDIFMCGAL_ForcedSettings; // 0x40
	public List<AOJCMPIBFHD> DBBLKLCCHFC; // 0x44

	public List<EONOEHOKBEB_Music> EPMMNEFADAP_Musics { get; private set; }// 0x20 // EONBIDEIFIA   HPBDACIJFEM DCLKBPALLLD
	public List<KEODKEGFDLD_FreeMusicInfo> GEAANLPDJBP_FreeMusicDatas { get; private set; } // 0x24 BJHOBLKDBKK ONBBLMFKDMA IIGCCMELFCO
	public List<DJNPIGEFPMF_StoryMusicInfo> CLHIABAKKJM_StoryMusicData { get; private set; } // 0x28 LECLIAKPOBM  PNNMFKPPDBI CHBJKIFMECH
	public List<KLBKPANJCPL_Score> CMPPNEFNGMK_Scores { get; private set; } // 0x2C // OLPOIIEPELN MPLAPBEGBOA PFDIMNJEMFF

	// // RVA: 0x10CF794 Offset: 0x10CF794 VA: 0x10CF794
	public EONOEHOKBEB_Music IAJLOELFHKC_GetMusicInfo(int DLAEJOBELBH_Id)
	{
		if(DLAEJOBELBH_Id > 0)
		{
			return EPMMNEFADAP_Musics[DLAEJOBELBH_Id - 1];
		}
		return null;
	}

	// // RVA: 0x10CF824 Offset: 0x10CF824 VA: 0x10CF824
	public KEODKEGFDLD_FreeMusicInfo NOBCLJIAMLC_GetFreeMusicData(int GHBPLHBNMBK)
	{
		if(GHBPLHBNMBK > 0)
		{
			return GEAANLPDJBP_FreeMusicDatas[GHBPLHBNMBK - 1];
		}
		return null;
	}

	// // RVA: 0x10CF8B4 Offset: 0x10CF8B4 VA: 0x10CF8B4
	public DJNPIGEFPMF_StoryMusicInfo FLMLJIKBIMJ_GetStoryMusicData(int KLCIIHKFPPO)
	{
		if (KLCIIHKFPPO > 0)
		{
			return CLHIABAKKJM_StoryMusicData[KLCIIHKFPPO - 1];
		}
		return null;
	}

	// // RVA: 0x10CF944 Offset: 0x10CF944 VA: 0x10CF944
	public HMJHLLPBCLD KCBOGEBCMMJ(int LJNAKDMILMC)
	{
		HMJHLLPBCLD search = new HMJHLLPBCLD(LJNAKDMILMC);
		int idx = OHLOHGGCCMD.BinarySearch(search);
		if(idx > -1)
		{
			return OHLOHGGCCMD[idx];
		}
		return null;
	}

	// // RVA: 0x10CFA30 Offset: 0x10CFA30 VA: 0x10CFA30
	public JPCKBFBCJKD LLJOPJMIGPD(int GHBPLHBNMBK_FreeMusicId)
	{
		return MGBKDJLEICI.Find((JPCKBFBCJKD JPAEDJJFFOI) =>
		{
			//0xA0FA20
			return JPAEDJJFFOI.GHBPLHBNMBK_FreeMusicId == GHBPLHBNMBK_FreeMusicId;
		});
	}

	// // RVA: 0x10CFB28 Offset: 0x10CFB28 VA: 0x10CFB28
	public bool IAAMKEJKPPL(JPCKBFBCJKD KBOLNIBLIND, int ADFIHAPELAN)
	{
		if (KBOLNIBLIND.ADBHJCDINFL < 1)
			return true;
		return KBOLNIBLIND.ADBHJCDINFL <= ADFIHAPELAN;
	}

	// // RVA: 0x10CFB94 Offset: 0x10CFB94 VA: 0x10CFB94
	public HDNKOFNBCEO_RewardInfo NEJKJJPIGKD_GetRewardInfo(KEODKEGFDLD_FreeMusicInfo AOKGAGHGAEC_FreeMusicInfo, int AKNELONELJK_Difficulty, bool GIKLNODJKFK_Is6Line)
	{
		if (!GIKLNODJKFK_Is6Line)
			return MGDLFOAKGGF[AOKGAGHGAEC_FreeMusicInfo.EAEDODGPLEC_RewardBaseId + AKNELONELJK_Difficulty - 1];
		else
			return MGDLFOAKGGF[AOKGAGHGAEC_FreeMusicInfo.LOKLNBLBBFD_Reward6LineBaseId + AKNELONELJK_Difficulty - 1];
	}

	// // RVA: 0x10CFC50 Offset: 0x10CFC50 VA: 0x10CFC50
	public KLBKPANJCPL_Score ALJFMLEJEHH_GetMusicScore(int KKPAHLMJKIH_WavId, int BKJGCEOEPFB_VariationId, int NOAKHKMLPFK_Difficulty, bool GIKLNODJKFK_Line6 = false, bool IOOOMNMAGAH = true)
	{
		int a = 0;
		if (GIKLNODJKFK_Line6)
			a = 1000;
		int b = BKJGCEOEPFB_VariationId + KKPAHLMJKIH_WavId * 10000 + NOAKHKMLPFK_Difficulty + 1;
		if(b+a != 0)
		{
			for(int i = 0; i < CMPPNEFNGMK_Scores.Count; i++)
			{
				if(CMPPNEFNGMK_Scores[i].GKNBCINLIJJ_Scid == (b+a))
				{
					return CMPPNEFNGMK_Scores[i];
				}
			}
			if (!GIKLNODJKFK_Line6)
				return null;
			if (!IOOOMNMAGAH)
				return null;
			UnityEngine.Debug.LogWarning(string.Format("<color=red>not found Line6 Score Master:{0} -> use Line4:{1}</color>",b ,b+a));
			return ALJFMLEJEHH_GetMusicScore(KKPAHLMJKIH_WavId, BKJGCEOEPFB_VariationId, NOAKHKMLPFK_Difficulty, false, true);
		}
		return null;
	}

	// // RVA: 0x10CFE98 Offset: 0x10CFE98 VA: 0x10CFE98
	public int CHBLIEKBOLL_GetScoreId(int KKPAHLMJKIH_WavId, int BKJGCEOEPFB_VariationId, int NOAKHKMLPFK_Difficulty, bool GIKLNODJKFK_Is6Line = false)
	{
		int val = 0;
		if (GIKLNODJKFK_Is6Line)
			val = (int)((NOAKHKMLPFK_Difficulty >> 0x1f) & 0xfffffc18) + 1000;
		return BKJGCEOEPFB_VariationId + KKPAHLMJKIH_WavId * 10000 + NOAKHKMLPFK_Difficulty + val + 1;
	}

	// // RVA: 0x10CFED0 Offset: 0x10CFED0 VA: 0x10CFED0
	public bool BHJKMPBACAC_IsFreeMusicAvaiable(int GHBPLHBNMBK)
	{
		if (GHBPLHBNMBK > 0 && GHBPLHBNMBK <= GEAANLPDJBP_FreeMusicDatas.Count)
		{
			return NOBCLJIAMLC_GetFreeMusicData(GHBPLHBNMBK).PPEGAKEIEGM_Enabled == 2;
		}
		return false;
	}

	// // RVA: 0x10CFFA0 Offset: 0x10CFFA0 VA: 0x10CFFA0
	public EONOEHOKBEB_Music INJDLHAEPEK_GetMusicInfo(int GHBPLHBNMBK_FreeMusicId, int DLAEJOBELBH_Id)
	{
		return IAJLOELFHKC_GetMusicInfo(CIKALPJDGMF_ResolveMusicId(GHBPLHBNMBK_FreeMusicId, DLAEJOBELBH_Id));
	}

	// // RVA: 0x10CFFC0 Offset: 0x10CFFC0 VA: 0x10CFFC0
	public int CIKALPJDGMF_ResolveMusicId(int GHBPLHBNMBK_FreeMusicId, int DLAEJOBELBH_Id)
	{
		if(GHBPLHBNMBK_FreeMusicId != 0)
		{
			if(NOBCLJIAMLC_GetFreeMusicData(GHBPLHBNMBK_FreeMusicId) != null)
			{
				if(NOBCLJIAMLC_GetFreeMusicData(GHBPLHBNMBK_FreeMusicId).BLDDNEJDFON_ForcePrismId > 0)
				{
					if(NOBCLJIAMLC_GetFreeMusicData(GHBPLHBNMBK_FreeMusicId).BLDDNEJDFON_ForcePrismId <= HBJDIFMCGAL_ForcedSettings.Count)
					{
						DLAEJOBELBH_Id = HBJDIFMCGAL_ForcedSettings[NOBCLJIAMLC_GetFreeMusicData(GHBPLHBNMBK_FreeMusicId).BLDDNEJDFON_ForcePrismId - 1].IOPCBBNHJIP_MusicId;
					}
				}
			}
		}
		return DLAEJOBELBH_Id;
	}

	// // RVA: 0x10D00E8 Offset: 0x10D00E8 VA: 0x10D00E8
	public AOJCMPIBFHD OOKAOFJBCFD(int DLAEJOBELBH_Id, int OFGIOBGAJPA)
	{
		return DBBLKLCCHFC.FindAll((AOJCMPIBFHD GHPLINIACBB) => {
			//0xA0FA6C
			return GHPLINIACBB.DLAEJOBELBH_Id == DLAEJOBELBH_Id;
		}).Find((AOJCMPIBFHD GHPLINIACBB) => {
			//0xA0FAA4
			return GHPLINIACBB.OFGIOBGAJPA == OFGIOBGAJPA;
		});
	}

	// // RVA: 0x10D0270 Offset: 0x10D0270 VA: 0x10D0270
	public int DCMGLKDJAKL(int JHNCAFBGOKA, int HKOHGJAIJMA, List<int> JFCDMNPDIGP)
	{
		foreach(var k in DBBLKLCCHFC)
		{
			if (k.PLALNIIBLOF != 2)
				break;
			if(k.DLAEJOBELBH_Id == JHNCAFBGOKA && k.OFGIOBGAJPA == HKOHGJAIJMA)
			{
				int[] a = k.AHHJLDLAPAN;
				bool valid = true;
				for(int i = 0; i < a.Length; i++)
				{
					if (HKOHGJAIJMA < 1)
					{
						valid = false;
						break;
					}
					for(int j = 0; j < JFCDMNPDIGP.Count; j++)
					{
						if (JFCDMNPDIGP[j] == a[i])
							break;
						if(HKOHGJAIJMA <= j + 1)
						{
							valid = false;
							break;
						}
					}
				}
				if(valid)
					return k.OEJOOMPKAOO;
			}
		}
		return 0;
	}

	// // RVA: 0x10D050C Offset: 0x10D050C VA: 0x10D050C
	public LPPGENBEECK_MusicMaster()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		EPMMNEFADAP_Musics = new List<EONOEHOKBEB_Music>(300);
		GEAANLPDJBP_FreeMusicDatas = new List<KEODKEGFDLD_FreeMusicInfo>(2000);
		CLHIABAKKJM_StoryMusicData = new List<DJNPIGEFPMF_StoryMusicInfo>(200);
		CMPPNEFNGMK_Scores = new List<KLBKPANJCPL_Score>(1000);
		OHLOHGGCCMD = new List<HMJHLLPBCLD>(2400);
		MGBKDJLEICI = new List<JPCKBFBCJKD>(2000);
		MGDLFOAKGGF = new List<HDNKOFNBCEO_RewardInfo>();
		NEIBEDCGDEM = new List<NONFIGBOJLN>();
		HBJDIFMCGAL_ForcedSettings = new List<AIPEHINPIHC_ForcedSettingInfo>();
		DBBLKLCCHFC = new List<AOJCMPIBFHD>();
		LMHMIIKCGPE = 62;
	}

	// // RVA: 0x10D07EC Offset: 0x10D07EC VA: 0x10D07EC Slot: 8
	protected override void KMBPACJNEOF()
	{
		EPMMNEFADAP_Musics.Clear();
		GEAANLPDJBP_FreeMusicDatas.Clear();
		CLHIABAKKJM_StoryMusicData.Clear();
		CMPPNEFNGMK_Scores.Clear();
		OHLOHGGCCMD.Clear();
		MGBKDJLEICI.Clear();
		MGDLFOAKGGF.Clear();
		NEIBEDCGDEM.Clear();
		HBJDIFMCGAL_ForcedSettings.Clear();
		DBBLKLCCHFC.Clear();
		for(int i = 1; i < 301; i++)
		{
			EONOEHOKBEB_Music data = new EONOEHOKBEB_Music();
			data.DLAEJOBELBH_Id = (short)i;
			EPMMNEFADAP_Musics.Add(data);
		}
		for(int i = 1; i < 2001; i++)
		{
			KEODKEGFDLD_FreeMusicInfo data = new KEODKEGFDLD_FreeMusicInfo();
			data.GHBPLHBNMBK_FreeMusicId = (short)i;
			GEAANLPDJBP_FreeMusicDatas.Add(data);
		}
	}

	// // RVA: 0x10D0B00 Offset: 0x10D0B00 VA: 0x10D0B00 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		BMHPFEELLNP reader = BMHPFEELLNP.HEGEKFMJNCC(DBBGALAPFGC);
		JJOLLBDMIJP_LoadScore(reader);
		NOGICBBHLNK_LoadFreeReward(reader);
		KANEJCIALLM_LoadStoryTh(reader);
		if(AOPNONMKCLC_LoadMusic(reader) && ANKANPOHJNM(reader))
		{
			AHNNMALAMFF(reader);
			CNCEJAKLNBL(reader);
			FKLPBNIFBNF(reader);
			DNCNGDFMMPI(reader);
			ALLLNNDHGLA(reader);
			return true;
		}
		return false;
	}

	// // RVA: 0x10D52EC Offset: 0x10D52EC VA: 0x10D52EC Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		TodoLogger.Log(0, "TODO");
		return true;
	}

	// // RVA: 0x10D0BB4 Offset: 0x10D0BB4 VA: 0x10D0BB4
	private bool JJOLLBDMIJP_LoadScore(BMHPFEELLNP FCLGPOPLDFL)
	{
		FMAFIIPNNEO[] array = FCLGPOPLDFL.DGEPOLGDKHA;
		for(int i = 0; i < array.Length; i++)
		{
			KLBKPANJCPL_Score data = new KLBKPANJCPL_Score();
			data.GKNBCINLIJJ_Scid = (int)array[i].GKHGCPODNEG;
			data.ANAJIAENLNB_F_pt = (int)array[i].ANAJIAENLNB;
			data.NLKEBAOBJCM_Cb = (int)array[i].OLKHBHLOKJI;
			data.KNIFCANOHOC_Ss = (int)array[i].EJOECKJNGPD;
			data.CKDPPJAHAIP_Dn = (int)array[i].HDBEJBBPPBK;
			data.NPKMKMBEOAG_Dnc = (int)array[i].HOPIMOECAFA;
			data.NPGCIDONKOP_Sp = (int)array[i].PIPCIMIALOO;
			data.MCMIPODICAN_length = (int)array[i].MOIECBABHNP;
			data.KIEHDJFCCNM = (int)array[i].AMGHCNHIFFG;
			data.GEIDIHCKDNO = (int)array[i].KKBPKNBLJCK;
			data.JJBOEMOJPEC_DivaNote = (int)array[i].GDHLEEJPNIJ;
			data.OABPNBLPHHP_ValkStartTime = (int)array[i].AOLENLGEJED;
			data.GIABDDFGHOK_DivaStartTime = (int)array[i].EPEBHGHKMBE;
			CMPPNEFNGMK_Scores.Add(data);
		}
		return true;
	}

	// // RVA: 0x10D5584 Offset: 0x10D5584 VA: 0x10D5584
	// private bool JJOLLBDMIJP(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int KAPMOPMDHJE) { }

	// // RVA: 0x10D1584 Offset: 0x10D1584 VA: 0x10D1584
	private bool AOPNONMKCLC_LoadMusic(BMHPFEELLNP FCLGPOPLDFL)
	{
		JPALGGIPGGN[] array = FCLGPOPLDFL.MDFFJJKBDFC;
		for(int i = 0; i < array.Length; i++)
		{
			EONOEHOKBEB_Music data = EPMMNEFADAP_Musics[i];
			data.DLAEJOBELBH_Id = (short)array[i].PPFNGGCBJKC;
			data.JNCPEGJGHOG_Cov = (short)array[i].JPHOOKPHBLD;
			data.NNHOBFBCIIJ_Cd = (short)array[i].DPBBFBFJCKG;
			data.KNMGEEFGDNI_Nam = (short)array[i].IIPIPIABGDG;
			data.NODKIFGGMGP_Div = (short)array[i].FNAEGLFKDBI;
			data.FKDCCLPGKDK_Ma = (sbyte)array[i].AOLLIMFKDAA;
			data.EMIKBGHIOMN_SerieLogoId = (sbyte)array[i].JPFMJHLCMJL;
			data.AIHCEGFANAM_SerieAttr = (sbyte)SeriesAttr.ConvertFromLogoId((SeriesLogoId.Type)data.EMIKBGHIOMN_SerieLogoId);
			data.KKPAHLMJKIH_WavId = (short)array[i].IKOFFIOMOME;
			data.BKJGCEOEPFB_VariationId = (short)array[i].PKLIPLFIDED;
			data.GHICLBNHNGJ_Dsc = (short)array[i].GJDKHDLKONI;
			data.AABILPMIOFN_Strt = (short)array[i].AJAGMMHPBBC;
			data.DMKCGNMOCCH_ValkyrieBattle = (short)array[i].DHCBIMHIPHB;
			data.EECJONKNHNK_ValkyrieIntro = (short)array[i].MGJJHHGDOFK;
			data.MNEFKDDCEHE_ValkyrieIntroSky = (short)array[i].FEJADFIALKK;
			data.NJAOOMHCIHL_DivaSolo = (short)array[i].FFKLLDKDEFP;
			data.PECMGDOMLAF_DivaMulti = (short)array[i].MIDEDJKGOED;
			data.ACPKFNNONMH_Exp = (short)array[i].LKIFDCEKDCK;
		}
		return true;
	}

	// // RVA: 0x10D6180 Offset: 0x10D6180 VA: 0x10D6180
	// private bool AOPNONMKCLC(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int KAPMOPMDHJE) { }

	// // RVA: 0x10D104C Offset: 0x10D104C VA: 0x10D104C
	private bool NOGICBBHLNK_LoadFreeReward(BMHPFEELLNP FCLGPOPLDFL)
	{
		KEBPMGGPLIF[] array = FCLGPOPLDFL.LNNNCEAAIAM;
		for (int i = 0; i < array.Length; i++)
		{
			HDNKOFNBCEO_RewardInfo data = new HDNKOFNBCEO_RewardInfo();
			data.EIHOBHDKCDB = (int)array[i].FCEJJEPFIPH;
			data.LLEILBEMEEJ = new List<int>(39);
			for(int j = 0; j < array[i].AIHOJKFNEEN.Length; j++)
			{
				data.LLEILBEMEEJ.Add((int)array[i].AIHOJKFNEEN[j]);
			}
			MGDLFOAKGGF.Add(data);
		}
		return true;
	}

	// // RVA: 0x10D5ACC Offset: 0x10D5ACC VA: 0x10D5ACC
	// private bool NOGICBBHLNK(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int KAPMOPMDHJE) { }

	// // RVA: 0x10D12E8 Offset: 0x10D12E8 VA: 0x10D12E8
	private bool KANEJCIALLM_LoadStoryTh(BMHPFEELLNP FCLGPOPLDFL)
	{
		EODMBJMOHBC[] array = FCLGPOPLDFL.BJGDMLNFKKN;
		for(int i = 0; i < array.Length; i++)
		{
			NONFIGBOJLN data = new NONFIGBOJLN();
			data.PDGEMDFHFIB = array[i].LBMELIONKKB;
			data.MNKDEFJFKGN = new List<int>(8);
			for(int j = 0; j < array[i].JBGEEPFKIGG.Length; j++)
			{
				data.MNKDEFJFKGN.Add((int)array[i].JBGEEPFKIGG[j]);
			}
			NEIBEDCGDEM.Add(data);
		}
		return true;
	}

	// // RVA: 0x10D5E30 Offset: 0x10D5E30 VA: 0x10D5E30
	// private bool KANEJCIALLM(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int KAPMOPMDHJE) { }

	// // RVA: 0x10D730C Offset: 0x10D730C VA: 0x10D730C
	private ADDHLABEFKH FEEODHDKLFH(int EJOECKJNGPD_Ss, int OLKHBHLOKJI_Combo, int OIPCCBHIKIA, HDNKOFNBCEO_RewardInfo IBOGLMCNFBK)
	{
		ADDHLABEFKH res = new ADDHLABEFKH();
		res.DJEEFNHADDJ = OIPCCBHIKIA;
		res.KNIFCANOHOC_RankScore.Add(IBOGLMCNFBK.GPBKAAMLIBF(4) * EJOECKJNGPD_Ss / 100);
		res.NLKEBAOBJCM_RankCombo.Add(IBOGLMCNFBK.GPBKAAMLIBF(8) * OLKHBHLOKJI_Combo / 100);
		res.KNIFCANOHOC_RankScore.Add(IBOGLMCNFBK.GPBKAAMLIBF(5) * EJOECKJNGPD_Ss / 100);
		res.NLKEBAOBJCM_RankCombo.Add(IBOGLMCNFBK.GPBKAAMLIBF(9) * OLKHBHLOKJI_Combo / 100);
		res.KNIFCANOHOC_RankScore.Add(IBOGLMCNFBK.GPBKAAMLIBF(6) * EJOECKJNGPD_Ss / 100);
		res.NLKEBAOBJCM_RankCombo.Add(IBOGLMCNFBK.GPBKAAMLIBF(10) * OLKHBHLOKJI_Combo / 100);
		res.KNIFCANOHOC_RankScore.Add(IBOGLMCNFBK.GPBKAAMLIBF(7) * EJOECKJNGPD_Ss / 100);
		res.NLKEBAOBJCM_RankCombo.Add(IBOGLMCNFBK.GPBKAAMLIBF(11) * OLKHBHLOKJI_Combo / 100);
		res.KNIFCANOHOC_RankScore.Add(999999999);
		res.NLKEBAOBJCM_RankCombo.Add(999999999);
		return res;
	}

	// // RVA: 0x10D7728 Offset: 0x10D7728 VA: 0x10D7728
	private ADDHLABEFKH FEEODHDKLFH(int EJOECKJNGPD, int OLKHBHLOKJI, int OIPCCBHIKIA, NONFIGBOJLN IBOGLMCNFBK)
	{
		ADDHLABEFKH res = new ADDHLABEFKH();
		res.DJEEFNHADDJ = OIPCCBHIKIA;
		res.KNIFCANOHOC_RankScore.Add(IBOGLMCNFBK.MNKDEFJFKGN[0] * EJOECKJNGPD / 100);
		res.NLKEBAOBJCM_RankCombo.Add(IBOGLMCNFBK.MNKDEFJFKGN[4] * OLKHBHLOKJI / 100);
		res.KNIFCANOHOC_RankScore.Add(IBOGLMCNFBK.MNKDEFJFKGN[1] * EJOECKJNGPD / 100);
		res.NLKEBAOBJCM_RankCombo.Add(IBOGLMCNFBK.MNKDEFJFKGN[5] * OLKHBHLOKJI / 100);
		res.KNIFCANOHOC_RankScore.Add(IBOGLMCNFBK.MNKDEFJFKGN[2] * EJOECKJNGPD / 100);
		res.NLKEBAOBJCM_RankCombo.Add(IBOGLMCNFBK.MNKDEFJFKGN[6] * OLKHBHLOKJI / 100);
		res.KNIFCANOHOC_RankScore.Add(IBOGLMCNFBK.MNKDEFJFKGN[3] * EJOECKJNGPD / 100);
		res.NLKEBAOBJCM_RankCombo.Add(IBOGLMCNFBK.MNKDEFJFKGN[7] * OLKHBHLOKJI / 100);
		res.KNIFCANOHOC_RankScore.Add(999999999);
		res.NLKEBAOBJCM_RankCombo.Add(999999999);
		return res;
	}

	// // RVA: 0x10D1FCC Offset: 0x10D1FCC VA: 0x10D1FCC
	private bool ANKANPOHJNM(BMHPFEELLNP FCLGPOPLDFL)
	{
		NLDAADHODFI[] array = FCLGPOPLDFL.HDDGLOAECEK;
		if (array.Length >= 2001)
			return false;
		for(int i = 0; i < array.Length; i++)
		{
			KEODKEGFDLD_FreeMusicInfo data = GEAANLPDJBP_FreeMusicDatas[i];
			data.GHBPLHBNMBK_FreeMusicId = (short)array[i].EHDDADDKMFI;
			data.PPEGAKEIEGM_Enabled = (sbyte)JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE, (int)array[i].PLALNIIBLOF, 0);
			data.IJEKNCDIIAE = array[i].IJEKNCDIIAE;
			data.DEPGBBJMFED_CategoryId = (sbyte)array[i].DMEDKJPOLCH;
			data.EKANGPODCEP = (int)array[i].LHKFKIKEJHN;
			data.DLAEJOBELBH_MusicId = (short)array[i].KLMIFEKNBLL;
			data.EEFLOOBOAGF = (short)array[i].FPOMEEJFBIG;
			data.KEFGPJBKAOD_WavId = (short)array[i].CBBLAMDGOGK;
			data.LOHABKAHNKD((short)array[i].GPNOEFHGOJG, (short)array[i].ECLGEFGJMAM);
			data.MGLDIOILOFF = (short)array[i].PAIIHEJIGKO;
			data.FEOLNFKIIJJ((short)array[i].NOHIMPJDOCK, (short)array[i].FABJJODPCIN);
			data.JCDKMICANJO = (short)array[i].DFELEPDHLBF;
			data.FNFKCHMPLAD((short)array[i].CAJKBDLCGOD, (short)array[i].CCHNGBLALEB);
			data.CCLIOBOGFHC = (short)array[i].LHBNIAJDIGA;
			data.EAEDODGPLEC_RewardBaseId = (short)array[i].FCEJJEPFIPH;
			data.LOKLNBLBBFD_Reward6LineBaseId = (short)array[i].PNIFJEENINF;
			data.ELOGNMFPAHJ = (sbyte)array[i].JJMMJGANPFI;
			data.BLDDNEJDFON_ForcePrismId = array[i].EIIOPABMJFJ;
			bool b = false;
			if(array[i].HHGPOOBOKHP > 0 && array[i].HHGPOOBOKHP <= DIHHCBACKGG_DbSection.IEFOPDOOLOK_MasterVersion)
				b = true;
			data.BHJNFBDNFEJ = b;
			b = false;
			if (array[i].OHDNJMJCGCJ > 0 && array[i].OHDNJMJCGCJ <= DIHHCBACKGG_DbSection.IEFOPDOOLOK_MasterVersion)
				b = true;
			data.GBNOALJPOBM = b;
			for(int j = 0; j < array[i].CFJKNAIOEAN.Length; j++)
			{
				data.OCOGIADDNDN_SpNoteByDiff[j] = (short)array[i].CFJKNAIOEAN[j];
				data.DPJDHKIIJIJ_SpNotesByDiff6Line[j] = (short)array[i].BODBNFFIOJN[j];
			}
			for (int j = 0; j < array[i].BKEIOLFMMDH.Length; j++)
			{
				data.LHICAKGHIGF[j] = (short)array[i].BKEIOLFMMDH[j];
				data.PJNFOCDANCE[j] = (short)array[i].KJLLNPFHEEL[j];
			}
			for (int j = 0; j < array[i].JGEIIONMJMI.Length; j++)
			{
				data.HLKHOFPAOMK_SubGoalFreeModeByDiff[j] = (int)array[i].JGEIIONMJMI[j];
				data.MAGILDGLOKD_SubGoalFreeModeL6ByDiff[j] = (int)array[i].DOAFFAGEHOM[j];
			}
			for (int j = 0; j < array[i].CMENIBCJJNF.Length; j++)
			{
				data.HLLJIICKNIP_GoalFreeModeByDiff[j] = (int)array[i].CMENIBCJJNF[j];
				data.JEANDFEBLIG_GoalFreeModeL6ByDiff[j] = (int)array[i].BIHJCIGKMBA[j];
			}
			for (int j = 0; j < array[i].KMFHHOANPFH.Length; j++)
			{
				data.FENOHOEIJOE_MaxValueFreeModeByDiff[j] = (int)array[i].KMFHHOANPFH[j];
				data.KFIDHFOGDPJ_MaxValueFreeModeL6ByDiff[j] = (int)array[i].OOBOCLOFPBF[j];
			}
			for (int j = 0; j < array[i].EHODALENBEL.Length; j++)
			{
				data.LJPKLMJPLAC[j] = (int)array[i].EHODALENBEL[j];
				data.ILCJOOPIILK[j] = (int)array[i].DKAIOCGKJLO[j];
			}
			for (int j = 0; j < array[i].ALJIHHGHCOG.Length; j++)
			{
				data.MALHPBKPIDE[j] = (int)array[i].ALJIHHGHCOG[j];
				data.BGILEHEJHHA[j] = (int)array[i].OIDAMEGDNOF[j];
			}
			for(int j = 0; j < 5; j++)
			{
				EONOEHOKBEB_Music m = IAJLOELFHKC_GetMusicInfo(data.DLAEJOBELBH_MusicId);
				KLBKPANJCPL_Score k = ALJFMLEJEHH_GetMusicScore(m.KKPAHLMJKIH_WavId, m.BKJGCEOEPFB_VariationId, j, false, true);
				int i1 = 0;
				int i2 = 0;
				int i3 = 0;
				if(k != null)
				{
					i1 = k.NLKEBAOBJCM_Cb;
					i2 = k.KNIFCANOHOC_Ss;
					i3 = k.OIPCCBHIKIA;
				}
				HDNKOFNBCEO_RewardInfo data2 = MGDLFOAKGGF[data.EAEDODGPLEC_RewardBaseId - 1];
				data.NHKABAGJCDM(FEEODHDKLFH(i2, i1, i3, data2));
				KLBKPANJCPL_Score k2 = ALJFMLEJEHH_GetMusicScore(m.KKPAHLMJKIH_WavId, m.BKJGCEOEPFB_VariationId, j, true, false);
				if(k2 != null)
				{
					data2 = MGDLFOAKGGF[data.LOKLNBLBBFD_Reward6LineBaseId - 1];
					data.IFABJEBEKPB(FEEODHDKLFH(k2.KNIFCANOHOC_Ss, k2.NLKEBAOBJCM_Cb, k2.OIPCCBHIKIA, data2));
				}
			}
		}
		return true;
	}

	// // RVA: 0x10D6D94 Offset: 0x10D6D94 VA: 0x10D6D94
	// private bool ANKANPOHJNM(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int KAPMOPMDHJE) { }

	// // RVA: 0x10D3D78 Offset: 0x10D3D78 VA: 0x10D3D78
	private bool AHNNMALAMFF(BMHPFEELLNP FCLGPOPLDFL)
	{
		FBAFBKNKENO[] array = FCLGPOPLDFL.DBINAHBHDOC;
		for(int i = 0; i < array.Length; i++)
		{
			DJNPIGEFPMF_StoryMusicInfo data = new DJNPIGEFPMF_StoryMusicInfo();
			data.KLCIIHKFPPO = (short)array[i].BDJMFDKLHPM;
			data.DEPGBBJMFED = (int)array[i].DMEDKJPOLCH;
			data.DLAEJOBELBH_Id = (int)array[i].KLMIFEKNBLL;
			data.KEFGPJBKAOD_WavId = (int)array[i].CBBLAMDGOGK;
			data.MHPAFEEPBNJ = (int)array[i].NHBLDIPBHNF;
			data.KCNHKNKNGNH = (int)array[i].GPNOEFHGOJG;
			data.MGLDIOILOFF = (int)array[i].PAIIHEJIGKO;
			data.PPEGAKEIEGM = (byte)JKAECBCNHAN_IsEnabled(1, (int)array[i].PLALNIIBLOF, 0);
			for(int j = 0; j < array[i].CFJKNAIOEAN.Length; j++)
			{
				data.OCOGIADDNDN[j] = (short)array[i].CFJKNAIOEAN[j];
			}
			for (int j = 0; j < array[i].BKEIOLFMMDH.Length; j++)
			{
				data.LHICAKGHIGF[j] = (short)array[i].BKEIOLFMMDH[j];
			}
			for (int j = 0; j < array[i].JGEIIONMJMI.Length; j++)
			{
				data.HLKHOFPAOMK_SubGoalByDiff[j] = (short)array[i].JGEIIONMJMI[j];
			}
			for (int j = 0; j < array[i].CMENIBCJJNF.Length; j++)
			{
				data.HLLJIICKNIP_GoalByDiff[j] = (short)array[i].CMENIBCJJNF[j];
			}
			for (int j = 0; j < array[i].KMFHHOANPFH.Length; j++)
			{
				data.FENOHOEIJOE_MaxValueByDiff[j] = (short)array[i].KMFHHOANPFH[j];
			}
			for (int j = 0; j < array[i].EHODALENBEL.Length; j++)
			{
				data.LJPKLMJPLAC[j] = (short)array[i].EHODALENBEL[j];
			}
			for (int j = 0; j < array[i].ALJIHHGHCOG.Length; j++)
			{
				data.MALHPBKPIDE[j] = (short)array[i].ALJIHHGHCOG[j];
			}
			for(int j = 0; j < 5; j++)
			{
				EONOEHOKBEB_Music music = IAJLOELFHKC_GetMusicInfo(data.DLAEJOBELBH_Id);
				KLBKPANJCPL_Score score = ALJFMLEJEHH_GetMusicScore(music.KKPAHLMJKIH_WavId, music.BKJGCEOEPFB_VariationId, j, false, true);
				if(score != null)
				{
					data.COGKJBAFBKN_ByDiff.Add(FEEODHDKLFH(score.KNIFCANOHOC_Ss, score.NLKEBAOBJCM_Cb, score.OIPCCBHIKIA, NEIBEDCGDEM[0]));
				}
			}
			CLHIABAKKJM_StoryMusicData.Add(data);
		}
		return true;
	}

	// // RVA: 0x10D6D9C Offset: 0x10D6D9C VA: 0x10D6D9C
	// private bool AHNNMALAMFF(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int KAPMOPMDHJE) { }

	// // RVA: 0x10D46D8 Offset: 0x10D46D8 VA: 0x10D46D8
	private bool CNCEJAKLNBL(BMHPFEELLNP FCLGPOPLDFL)
	{
		INDENDCNNHJ[] array = FCLGPOPLDFL.CDKOBOHBJHM;
		for(int i = 0; i < array.Length; i++)
		{
			HMJHLLPBCLD data = new HMJHLLPBCLD((int)array[i].LJNAKDMILMC);
			data.LHBDCGFOKCA_DivaId = (short)array[i].JBKMAPLCBMO[0];
			data.CEFHDLLAPDH_MusicId = (short)array[i].JBKMAPLCBMO[1];
			data.KDGIHMCBLND_MusicLevel = (short)array[i].JBKMAPLCBMO[2];
			OHLOHGGCCMD.Add(data);
		}
		return true;
	}

	// // RVA: 0x10D6DA4 Offset: 0x10D6DA4 VA: 0x10D6DA4
	// private bool CNCEJAKLNBL(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int KAPMOPMDHJE) { }

	// // RVA: 0x10D4950 Offset: 0x10D4950 VA: 0x10D4950
	private bool FKLPBNIFBNF(BMHPFEELLNP FCLGPOPLDFL)
	{
		NJBDNGAPLLI[] array = FCLGPOPLDFL.JEOOAMHEMJL;
		for (int i = 0; i < array.Length; i++)
		{
			JPCKBFBCJKD data = new JPCKBFBCJKD();
			data.GHBPLHBNMBK_FreeMusicId = (int)array[i].EHDDADDKMFI;
			data.ADBHJCDINFL = (int)array[i].NKAKDIEKAGL;
			MGBKDJLEICI.Add(data);
		}
		return true;
	}

	// // RVA: 0x10D70B0 Offset: 0x10D70B0 VA: 0x10D70B0
	// private bool FKLPBNIFBNF(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int KAPMOPMDHJE) { }

	// // RVA: 0x10D4B28 Offset: 0x10D4B28 VA: 0x10D4B28
	private bool DNCNGDFMMPI(BMHPFEELLNP FCLGPOPLDFL)
	{
		OIPFPLPMCMF[] array = FCLGPOPLDFL.JNFKEOEGGLF;
		for (int i = 0; i < array.Length; i++)
		{
			AIPEHINPIHC_ForcedSettingInfo data = new AIPEHINPIHC_ForcedSettingInfo();
			data.NMNDNFFJHPJ_Id = (int)array[i].EIIOPABMJFJ;
			data.GPPEFLKGGGJ_ValkyrieId = (int)array[i].FODKKJIDDKN;
			for(int j = 0; j < 3; j++)
			{
				data.AHHJLDLAPAN_DivaId[j] = (int)array[i].DIPKCALNIII[j];
				data.JPIDIENBGKH_CostumeId[j] = (int)array[i].BEEAIAAJOHD[j];
			}
			data.IOPCBBNHJIP_MusicId = (int)array[i].NBMPGOJBPMD;
			data.OOFEIPCLEKJ_DivaVoice = (int)array[i].OOFEIPCLEKJ;
			data.EDDLJBLJJOE_PilotVoice = (int)array[i].EDDLJBLJJOE;
			data.JIIOKINLOGM_NoteType = (int)array[i].JIIOKINLOGM;
			data.MDKNFOIMCJB_NoteSe = (int)array[i].MDKNFOIMCJB;
			data.OENPCNBFPDA_Bg = (int)array[i].OENPCNBFPDA;
			data.EGMIILFFHMI_DivaMode = (int)array[i].EGMIILFFHMI;
			data.HFMFGFHPBNB_ValkyrieMode = (int)array[i].HFMFGFHPBNB;
			data.ENAAKPKFBGN_EffectCutIn = (int)array[i].ENAAKPKFBGN;
			data.IHLDBMMOCHF_ForceSLiveResultSerifWindow = (int)array[i].IHLDBMMOCHF;
			HBJDIFMCGAL_ForcedSettings.Add(data);
		}
		return true;
	}

	// // RVA: 0x10D4FA0 Offset: 0x10D4FA0 VA: 0x10D4FA0
	private bool ALLLNNDHGLA(BMHPFEELLNP FCLGPOPLDFL)
	{
		MDCGKDDENNG[] array = FCLGPOPLDFL.BOECDBOLGJN;
		for (int i = 0; i < array.Length; i++)
		{
			AOJCMPIBFHD data = new AOJCMPIBFHD();
			data.IJEKNCDIIAE_AssetMasterVersion = (int)array[i].IJEKNCDIIAE;
			data.PLALNIIBLOF = JKAECBCNHAN_IsEnabled(data.IJEKNCDIIAE_AssetMasterVersion, (int)array[i].PLALNIIBLOF, 0);
			data.DLAEJOBELBH_Id = (int)array[i].KLMIFEKNBLL;
			for(int j = 0; j < array[i].DIPKCALNIII.Length; j++)
			{
				data.AHHJLDLAPAN[j] = (int)array[i].DIPKCALNIII[j];
			}
			data.OFGIOBGAJPA = (int)array[i].ELDPFJIDNAB;
			data.OEJOOMPKAOO = (int)array[i].NDIJPKPDOMG;
			DBBLKLCCHFC.Add(data);
		}
		return true;
	}

	// // RVA: 0x10D7BD4 Offset: 0x10D7BD4 VA: 0x10D7BD4 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(TodoLogger.DbIntegrityCheck, "LPPGENBEECK_MusicMaster.CAOGDCBPBAN");
		return 0;
	}
}

[System.Obsolete("Use KLBKPANJCPL_Score", true)]
public class KLBKPANJCPL {}
public class KLBKPANJCPL_Score
{
	public int OIPCCBHIKIA; // 0x8

	public int GKNBCINLIJJ_Scid { get; set; } // 0xC  // PIEBLLLAAEF ECBOBCJLLOD LFMJPMIHHBF
	public int ANAJIAENLNB_F_pt { get; set; } // 0x10 // IKMILCFHBGA MMOMNMBKHJF FEHNFGPFINK
	public int NLKEBAOBJCM_Cb { get; set; }   // 0x14 // ABLBDMPGEHA AECNKGBNKHH ECHLKFHOJFP
	public int KNIFCANOHOC_Ss { get; set; }   // 0x18 // DKDLLFCBBCE EOJEPLIPOMJ AEEMBPAEAAI
	public int CKDPPJAHAIP_Dn { get; set; }   // 0x1C // MBBGDHGPJDM DBMNFCDGGEC JEFJBPPGBOK
	public int NPKMKMBEOAG_Dnc { get; set; }  // 0x20 // AKAEHHAHFDM GHJDKBCAGLL IIEJNMBABCK
	public int NPGCIDONKOP_Sp { get; set; }   // 0x24 // AHONHAIELEA GKHINHNGCKE LLPNJHACHEB
	public int MCMIPODICAN_length { get; set; }      // 0x28 // IFGANBEKEAE DAGDLFMEAKG FNGANMMAACC
	public int KIEHDJFCCNM { get; set; }      // 0x2C // EGKCBOHGFBA LNPKNMONEFI CEPCIKJKLLF
	public int GEIDIHCKDNO { get; set; }      // 0x30 // DDIGBBJDNLF JAOFBBKGCHP IBIPFCNGHFF
	public int JJBOEMOJPEC_DivaNote { get; set; }      // 0x34 // BAGPHOPPPPC FGMMNEIIHKM MFKGPCOLFLA
	public int OABPNBLPHHP_ValkStartTime { get; set; }      // 0x38 // GJJGLNLOGHN BMCLOFLOPLO IABNMIBLHAA
	public int GIABDDFGHOK_DivaStartTime { get; set; }      // 0x3C // COGAGDDAEFD EHAGPCANMCN FMJMCAEJMPG

	// RVA: 0x1A0B9C0 Offset: 0x1A0B9C0 VA: 0x1A0B9C0
	//public uint CAOGDCBPBAN() { }
}

[System.Obsolete("Use EONOEHOKBEB_Music", true)]
public class EONOEHOKBEB{}
public class EONOEHOKBEB_Music
{
	public short DLAEJOBELBH_Id { get; set; } // CKJALIDGGOH // 0x8 MPGNHBOBFBD EPEMOAEGPLI
	public short JNCPEGJGHOG_Cov { get; set; } // LABOODIMOII // 0xA HHEADMHBBPB GOFFKDDNACG
	public short NNHOBFBCIIJ_Cd { get; set; } // GKMKHKHFBEI // 0xC AOBMNDMGGIO NIMNBBDNJMC
	public short KNMGEEFGDNI_Nam { get; set; } // JELJHGCOAFJ // 0xE HKEFEIOCKLP OCOGGADKEHD
	public short NODKIFGGMGP_Div { get; set; } // PNBJIFJHCBL // 0x10 APAOBAGKCPC LKDECIOADPO
	public sbyte FKDCCLPGKDK_Ma { get; set; } // KLMKEFEMHOC // 0x12 FBADKBMGIBP NCNMMABFHGN
	public sbyte AIHCEGFANAM_SerieAttr { get; set; } // FJOGAAMLJMA // 0x13 ANEJPLENMAL HEHDOGFEIOL
	public sbyte EMIKBGHIOMN_SerieLogoId { get; set; } // CCEIEDMCHLA // 0x14 BJGJCKFOBCA OAKIKBEEACC
	public short KKPAHLMJKIH_WavId { get; set; } // EOPNGHAFEMB // 0x16 ENODDPDBIPA HOAKFLEAEOH
	public short BKJGCEOEPFB_VariationId { get; set; } // PJKCKOJHKEM // 0x18 FNEBPBJBIIP OIDGLNHNGJB
	public short GHICLBNHNGJ_Dsc { get; set; } // IHIHAAJLBHK // 0x1A OLKANNICFLL MHEEIDDKIJH
	public short AABILPMIOFN_Strt { get; set; } // HJBLBCKELMF // 0x1C GACMKBLPOIB LKFFBLEIPIP
	public short DMKCGNMOCCH_ValkyrieBattle { get; set; } // LKKNIADKGAE // 0x1E PEBOPIIJCOM NOGOFLKEEMP
	public short EECJONKNHNK_ValkyrieIntro { get; set; } // GEOMFEFKOLF // 0x20 KJKNOCBOHFC DONMAGEIEJF
	public short MNEFKDDCEHE_ValkyrieIntroSky { get; set; } // EDBCILCIAEL // 0x22 MCDMIOFGCDF KIECJGPAHGO
	public short NJAOOMHCIHL_DivaSolo { get; set; } // GHHLJOCPEAE // 0x24 OJBDKKDLFDD CMMJPNDAJDG
	public short PECMGDOMLAF_DivaMulti { get; set; } // ADLPNCIONGK // 0x26 MDIFJJACKBC JKMNGNMPONF
	public short ACPKFNNONMH_Exp { get; set; } // LEDNEEKHDPM // 0x28 IOOMEBAFGFK DPMAFCKJJPM

	// RVA: 0xFBDFFC Offset: 0xFBDFFC VA: 0xFBDFFC
	//public uint CAOGDCBPBAN() { }
}


public class KEODKEGFDLD_FreeMusicInfo
{
	public short[] OCOGIADDNDN_SpNoteByDiff = new short[5]; // 0x34
	public short[] LHICAKGHIGF = new short[5]; // 0x38
	public int[] HLKHOFPAOMK_SubGoalFreeModeByDiff = new int[5]; // 0x3C
	public int[] HLLJIICKNIP_GoalFreeModeByDiff = new int[5]; // 0x40
	public int[] FENOHOEIJOE_MaxValueFreeModeByDiff = new int[5]; // 0x44
	public int[] LJPKLMJPLAC = new int[5]; // 0x48
	public int[] MALHPBKPIDE = new int[5]; // 0x4C
	public short[] DPJDHKIIJIJ_SpNotesByDiff6Line = new short[5]; // 0x50
	public short[] PJNFOCDANCE = new short[5]; // 0x54
	public int[] MAGILDGLOKD_SubGoalFreeModeL6ByDiff = new int[5]; // 0x58
	public int[] JEANDFEBLIG_GoalFreeModeL6ByDiff = new int[5]; // 0x5C
	public int[] KFIDHFOGDPJ_MaxValueFreeModeL6ByDiff = new int[5]; // 0x60
	public int[] ILCJOOPIILK = new int[5]; // 0x64
	public int[] BGILEHEJHHA = new int[5]; // 0x68
	private List<ADDHLABEFKH> COGKJBAFBKN_ByDiff = new List<ADDHLABEFKH>(); // 0x6C
	private List<ADDHLABEFKH> IPFHDCEFLDE_ByDiffLine6 = new List<ADDHLABEFKH>(); // 0x70

	public short GHBPLHBNMBK_FreeMusicId { get; set; } // 0x8 JHHAKBMGFEN HKFCFPFPMBN IFMPBFAAKNN
	public short DLAEJOBELBH_MusicId { get; set; } // 0xA CKJALIDGGOH MPGNHBOBFBD EPEMOAEGPLI
	public sbyte DEPGBBJMFED_CategoryId { get; set; } // 0xC OGKJCKOPEPM FNMFOBJIIIC OBEDPJLBBEG
	public sbyte PPEGAKEIEGM_Enabled { get; set; } // 0xD NEKLJCCBECB KPOEEPIMMJP NCIEAFEDPBH
	public sbyte ELOGNMFPAHJ { get; set; } // 0xE NGMLLJPEBPB PIICIAMECHP MHEBLIAMCAC
	public int IJEKNCDIIAE { get; set; } // 0x10 FAHNCMHNFCG KJIMMIBDCIL DMEGNOKIKCD
	public int EKANGPODCEP { get; set; } // 0x14 MBOEJOMMKCK EBLAFEMDFGD AHEFELNFBDM
	public short KEFGPJBKAOD_WavId { get; set; } // 0x18 CFNDJLELGFP MKJJKNIMMBC NACMHHKKBCJ
	public short EEFLOOBOAGF { get; set; } // 0x1A BKNCCIILLPJ NLDELFLNODF PEHLMNDKOEE
	private short KCNHKNKNGNH { get; set; } // 0x1C APIBHBGLOCI BPPHFJDPDJO FGPEKMCHDKK
	private short CNEMDPMKCPA { get; set; } // 0x1E ACECKLDHLHN OBCBGGMIHIG AELNGOGMECL
	public short MGLDIOILOFF { get; set; } // 0x20 HGCANNFGBJK JCCNFABDFGA LPONDIIPEDN
	private short LGNMFFMDIJP { get; set; } // 0x22 PINOBFJAMKP GOELDFINKPG DOPEOGFPFPN
	private short AOKEOELIAMH { get; set; } // 0x24 IEFOAKGGOGB DJMKMADIFCN DBCDHPEOKKD
	public short JCDKMICANJO { get; set; } // 0x26 NONHMBMDBKM ODFMHJFFILL DCDFFHHMHEL
	private short EFNKJFCJGBB { get; set; } // 0x28 HHBCGAKHPMG EMEFKAIBMFJ LDCPINNLDDN
	private short PNILIOGELFK { get; set; } // 0x2A ODCMCKBNJEL FJHBDENFDAJ DELONBFLKPM
	public short CCLIOBOGFHC { get; set; } // 0x2C DDDFCKCLGPD JMGOABJPFJO LJMBPNDJCOO
	public short EAEDODGPLEC_RewardBaseId { get; set; } // 0x2E MJPMALLKMJJ EOGPNADNBFO OGLPGIKKFLK
	public short LOKLNBLBBFD_Reward6LineBaseId { get; set; } // 0x30 CLFFNMKCEOE IHPAHIEIHMH LNCFBKJDBEK
	public int BLDDNEJDFON_ForcePrismId { get; set; } // 0x74 PHGFINLGEPL JLDOLKKPJMP ADMEDIKMAPD
	public bool BHJNFBDNFEJ { get; set; } // 0x78 NADBEMIAIJA JCELPEBCMAG GCCCGMBALMC
	public bool GBNOALJPOBM { get; set; } // 0x79 KNDGBCJKPMC PALLMADFFMA BEDKPPHDHAA

	// // RVA: 0x19F2E68 Offset: 0x19F2E68 VA: 0x19F2E68
	public void LOHABKAHNKD(short IGCLOFPOABH, short ACMOFHKGJLG)
	{
		CNEMDPMKCPA = ACMOFHKGJLG;
		KCNHKNKNGNH = IGCLOFPOABH;
	}

	// // RVA: 0x19F2E74 Offset: 0x19F2E74 VA: 0x19F2E74
	public void FEOLNFKIIJJ(short IGCLOFPOABH, short ACMOFHKGJLG)
	{
		AOKEOELIAMH = ACMOFHKGJLG;
		LGNMFFMDIJP = IGCLOFPOABH;
	}

	// // RVA: 0x19F2E80 Offset: 0x19F2E80 VA: 0x19F2E80
	public void FNFKCHMPLAD(short IGCLOFPOABH, short ACMOFHKGJLG)
	{
		PNILIOGELFK = ACMOFHKGJLG;
		EFNKJFCJGBB = IGCLOFPOABH;
	}

	// // RVA: 0x19F2E8C Offset: 0x19F2E8C VA: 0x19F2E8C
	public short KDIKCKEEPDA(bool GIKLNODJKFK)
	{
		return GIKLNODJKFK ? CNEMDPMKCPA : KCNHKNKNGNH;
	}

	// // RVA: 0x19F2EA0 Offset: 0x19F2EA0 VA: 0x19F2EA0
	public short ONLFLGPMAAN(bool GIKLNODJKFK)
	{
		return GIKLNODJKFK ? AOKEOELIAMH : LGNMFFMDIJP;
	}

	// // RVA: 0x19F2EB4 Offset: 0x19F2EB4 VA: 0x19F2EB4
	public short NCCFJCDMBFO(bool GIKLNODJKFK)
	{
		return GIKLNODJKFK ? PNILIOGELFK : EFNKJFCJGBB;
	}

	// // RVA: 0x19F2EC8 Offset: 0x19F2EC8 VA: 0x19F2EC8
	// public uint CAOGDCBPBAN() { }

	// // RVA: 0x19F31FC Offset: 0x19F31FC VA: 0x19F31FC
	public void NHKABAGJCDM(ADDHLABEFKH ANAJIAENLNB)
	{
		COGKJBAFBKN_ByDiff.Add(ANAJIAENLNB);
	}

	// // RVA: 0x19F327C Offset: 0x19F327C VA: 0x19F327C
	public void IFABJEBEKPB(ADDHLABEFKH ANAJIAENLNB)
	{
		IPFHDCEFLDE_ByDiffLine6.Add(ANAJIAENLNB);
	}

	// // RVA: 0x19F32FC Offset: 0x19F32FC VA: 0x19F32FC
	public ADDHLABEFKH EMJCHPDJHEI(bool GIKLNODJKFK_Is6Line, int AKNELONELJK_Difficulty)
	{
		if (IPFHDCEFLDE_ByDiffLine6.Count < 1 || !GIKLNODJKFK_Is6Line)
			return COGKJBAFBKN_ByDiff[AKNELONELJK_Difficulty];
		return IPFHDCEFLDE_ByDiffLine6[AKNELONELJK_Difficulty];
	}

}

public class DJNPIGEFPMF_StoryMusicInfo
{
	public short[] OCOGIADDNDN = new short[3]; // 0x24
	public short[] LHICAKGHIGF = new short[3]; // 0x28
	public int[] HLKHOFPAOMK_SubGoalByDiff = new int[3]; // 0x2C
	public int[] HLLJIICKNIP_GoalByDiff = new int[3]; // 0x30
	public int[] FENOHOEIJOE_MaxValueByDiff = new int[3]; // 0x34
	public int[] LJPKLMJPLAC = new int[3]; // 0x38
	public int[] MALHPBKPIDE = new int[3]; // 0x3C
	public List<ADDHLABEFKH> COGKJBAFBKN_ByDiff = new List<ADDHLABEFKH>(); // 0x40
	public byte PPEGAKEIEGM; // 0x44

	public short KLCIIHKFPPO { get; set; }  // 0x8 GBNPEKLEHPH CPDGCNILCII IILKMGEKOBG
	public int DLAEJOBELBH_Id { get; set; }  // 0xC CKJALIDGGOH MPGNHBOBFBD EPEMOAEGPLI
	public int DEPGBBJMFED { get; set; } // 0x10 OGKJCKOPEPM FNMFOBJIIIC OBEDPJLBBEG
	public int MHPAFEEPBNJ { get; set; } // 0x14 OHACHFCDBOF NODKIDEKNGJ CHFBEINBPKA
	public int KEFGPJBKAOD_WavId { get; set; } // 0x18 CFNDJLELGFP MKJJKNIMMBC NACMHHKKBCJ
	public int KCNHKNKNGNH { get; set; } // 0x1C APIBHBGLOCI BPPHFJDPDJO FGPEKMCHDKK
	public int MGLDIOILOFF { get; set; } // 0x20 HGCANNFGBJK JCCNFABDFGA LPONDIIPEDN

	// // RVA: 0x198D598 Offset: 0x198D598 VA: 0x198D598
	// public uint CAOGDCBPBAN() { }
}


public class HMJHLLPBCLD : IComparable<HMJHLLPBCLD>
{
	public int LJNAKDMILMC { get; set; } // 0x8 KNJIHALCKLN LIIHHICIBKM OACJGKPBHIK
	// public int ANAJIAENLNB { get; } 0x15F6920 MMOMNMBKHJF
	// public int AHHJLDLAPAN { get; } 0x15F6944 IPKDLMIDMHH
	// public int DLAEJOBELBH_Id { get; } 0x15F6974 MPGNHBOBFBD
	 public short LHBDCGFOKCA_DivaId { get; set; } // 0xC HHBMOFEAFKC OLHHGEIKLDM DOOHFPHPMPF
	 public short CEFHDLLAPDH_MusicId { get; set; } // 0xE BDIBNPFLIED BKFIIGCINNL BNJMJMNLMEA
	// public short CIIIELDHDEP { get; set; } 0x15F69B0 NAMNBEJFNFN 0x15F69D0 BGOEGAOOHIE
	// public short LDCJDIAOKGD { get; set; } 0x15F69E0 DBJGHGEJOAH 0x15F69E8 HEDOJDJALID
	 public short KDGIHMCBLND_MusicLevel { get; set; } // 0x10 CDLBEODBHLK GLDGPMFEKGM BJIBDJAOFJJ

	// // RVA: 0x15F68F8 Offset: 0x15F68F8 VA: 0x15F68F8
	public static int ABDFBABHIHJ_GetId(int DLAEJOBELBH_MusicId, int AHHJLDLAPAN_DivaId, int BAKLKJLPLOJ_Level)
	{
		return AHHJLDLAPAN_DivaId * 100 + DLAEJOBELBH_MusicId * 10000 + BAKLKJLPLOJ_Level;
	}

	// // RVA: 0x15F69F0 Offset: 0x15F69F0 VA: 0x15F69F0
	public HMJHLLPBCLD(int LJNAKDMILMC)
	{
		this.LJNAKDMILMC = LJNAKDMILMC;
	}

	// // RVA: 0x15F6A10 Offset: 0x15F6A10 VA: 0x15F6A10 Slot: 4
	public int CompareTo(HMJHLLPBCLD EAIPIMCBNJN)
	{
		if (EAIPIMCBNJN == null)
			return 1;
		return LJNAKDMILMC.CompareTo(EAIPIMCBNJN.LJNAKDMILMC);
	}

	// // RVA: 0x15F6A54 Offset: 0x15F6A54 VA: 0x15F6A54
	// public uint CAOGDCBPBAN() { }
}

public class JPCKBFBCJKD
{
	public int GHBPLHBNMBK_FreeMusicId { get; set; } // 0x8 JHHAKBMGFEN HKFCFPFPMBN IFMPBFAAKNN
	public int ADBHJCDINFL { get; set; }  // 0xC PLIPNHDDIFP NKIPIGNMFGK NNPOJPDCEHE

	// // RVA: 0x1BA5440 Offset: 0x1BA5440 VA: 0x1BA5440
	// public uint CAOGDCBPBAN() { }
}

public class NONFIGBOJLN
{
	public int PDGEMDFHFIB; // 0x8
	public List<int> MNKDEFJFKGN; // 0xC
}

public class AJIKMKFGNCJ
{
	// public short JOMGCCBFKEF { get; set; } // 0x8 JIHJGFNPPIL GGFGMDFOFLG JCJBHJOOIDP
	// public byte INDDJNMPONH { get; set; } // 0xA JDIGGEBNOPK GHAILOLPHPF BACGOKIGMBC
	// public byte AHHJLDLAPAN { get; set; } // 0xB AMALMGIALDF IPKDLMIDMHH IENNENMKEFO
	// public int JBGEEPFKIGG { get; set; } // 0xC AHPLCJAKAOP OLOCMINKGON ABAFHIBFKCE
}

[System.Obsolete("Use AIPEHINPIHC_ForcedSettingInfo", true)]
public class AIPEHINPIHC { }
public class AIPEHINPIHC_ForcedSettingInfo
{
	public int NMNDNFFJHPJ_Id; // 0x8
	public int GPPEFLKGGGJ_ValkyrieId; // 0xC
	public int[] AHHJLDLAPAN_DivaId = new int[3]; // 0x10
	public int[] JPIDIENBGKH_CostumeId = new int[3]; // 0x14
	public int IOPCBBNHJIP_MusicId; // 0x18
	public int OOFEIPCLEKJ_DivaVoice; // 0x1C
	public int EDDLJBLJJOE_PilotVoice; // 0x20
	public int JIIOKINLOGM_NoteType; // 0x24
	public int MDKNFOIMCJB_NoteSe; // 0x28
	public int OENPCNBFPDA_Bg; // 0x2C
	public int EGMIILFFHMI_DivaMode; // 0x30
	public int HFMFGFHPBNB_ValkyrieMode; // 0x34
	public int ENAAKPKFBGN_EffectCutIn; // 0x38
	public int IHLDBMMOCHF_ForceSLiveResultSerifWindow; // 0x3C
}

public class AOJCMPIBFHD
{
	public int IJEKNCDIIAE_AssetMasterVersion; // 0x8
	public int PLALNIIBLOF; // 0xC
	public int DLAEJOBELBH_Id; // 0x10
	public int[] AHHJLDLAPAN = new int[5]; // 0x14
	public int OFGIOBGAJPA; // 0x18
	public int OEJOOMPKAOO; // 0x1C
}

[System.Obsolete("Use HDNKOFNBCEO_RewardInfo", true)]
public class HDNKOFNBCEO { }
public class HDNKOFNBCEO_RewardInfo
{
	public const int JIEBOLHLFOC = 0;
	public const int GJPKDHHKPPE = 4;
	public const int AKADJOKMIEN = 8;
	public const int HGFDJJPJNNG = 12;
	public int EIHOBHDKCDB; // 0x8
	public List<int> LLEILBEMEEJ; // 0xC

	// // RVA: 0x1742A5C Offset: 0x1742A5C VA: 0x1742A5C
	public int FKNBLDPIPMC_GetGlobalId(int OIPCCBHIKIA)
	{
		return LLEILBEMEEJ[OIPCCBHIKIA * 3];
	}

	// // RVA: 0x1742ADC Offset: 0x1742ADC VA: 0x1742ADC
	public int KAINPNMMAEK(int OIPCCBHIKIA)
	{
		return LLEILBEMEEJ[OIPCCBHIKIA * 3 + 1];
	}

	// // RVA: 0x1742B60 Offset: 0x1742B60 VA: 0x1742B60
	public int GPBKAAMLIBF(int OIPCCBHIKIA)
	{
		return LLEILBEMEEJ[OIPCCBHIKIA * 3 + 2];
	}

	// // RVA: 0x1742BE4 Offset: 0x1742BE4 VA: 0x1742BE4
	public int MEBHFJPMCIF(int HMFFHLPNMPH)
	{
		int res = -1;
		for(int i = 0; i < 4; i++)
		{
			res = i - 1;
			if (HMFFHLPNMPH < GPBKAAMLIBF(i))
				return i;
		}
		return res + 2;
	}

	// // RVA: 0x1742C2C Offset: 0x1742C2C VA: 0x1742C2C
	// public uint CAOGDCBPBAN() { }
}

public class ADDHLABEFKH
{
	// Fields
	public int DJEEFNHADDJ; // 0x8
	public List<int> KNIFCANOHOC_RankScore = new List<int>(); // 0xC
	public List<int> NLKEBAOBJCM_RankCombo = new List<int>(); // 0x10

	//// RVA: 0x15B9E74 Offset: 0x15B9E74 VA: 0x15B9E74
	public int DLPBHJALHCK_GetScoreRank(int JBGEEPFKIGG_Score)
	{
		for(int i = 0; i < KNIFCANOHOC_RankScore.Count; i++)
		{
			if (KNIFCANOHOC_RankScore[i] > JBGEEPFKIGG_Score)
				return i;
		}
		//return KNIFCANOHOC_RankScore.Count;
		return KNIFCANOHOC_RankScore.Count - 1; // UMO fix for very high score
	}

	//// RVA: 0x15B9F40 Offset: 0x15B9F40 VA: 0x15B9F40
	public int CCFAAPPKILD_GetRankCombo(int JBGEEPFKIGG_Combo)
	{
		for (int i = 0; i < NLKEBAOBJCM_RankCombo.Count; i++)
		{
			if (NLKEBAOBJCM_RankCombo[i] > JBGEEPFKIGG_Combo)
				return i;
		}
		return NLKEBAOBJCM_RankCombo.Count;
	}

	//// RVA: 0x15BA00C Offset: 0x15BA00C VA: 0x15BA00C
	//public uint CAOGDCBPBAN() { }
}
