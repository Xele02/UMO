using System.Collections.Generic;
using System;
using XeApp.Game.Common;
using Unity.IO.LowLevel.Unsafe;

[System.Obsolete("Use LPPGENBEECK_MusicMaster", true)]
public class LPPGENBEECK {}
[UMOClass(ReaderClass = "BMHPFEELLNP")]
public class LPPGENBEECK_MusicMaster : DIHHCBACKGG_DbSection
{
	[UMOMember(ReaderMember = "CDKOBOHBJHM")]
	private List<HMJHLLPBCLD> OHLOHGGCCMD; // 0x30
	[UMOMember(ReaderMember = "JEOOAMHEMJL")]
	private List<JPCKBFBCJKD> MGBKDJLEICI; // 0x34
	[UMOMember(ReaderMember = "LNNNCEAAIAM")]
	private List<HDNKOFNBCEO_RewardInfo> MGDLFOAKGGF; // 0x38
	[UMOMember(ReaderMember = "BJGDMLNFKKN")]
	public List<NONFIGBOJLN> NEIBEDCGDEM; // 0x3C
	[UMOMember(ReaderMember = "JNFKEOEGGLF")]
	public List<AIPEHINPIHC_ForcedSettingInfo> HBJDIFMCGAL_ForcedSettings; // 0x40
	[UMOMember(ReaderMember = "BOECDBOLGJN")]
	public List<AOJCMPIBFHD> DBBLKLCCHFC; // 0x44

	[UMOMember(ReaderMember = "MDFFJJKBDFC")]
	public List<EONOEHOKBEB_Music> EPMMNEFADAP_Music { get; private set; }// 0x20 // EONBIDEIFIA   HPBDACIJFEM DCLKBPALLLD
	[UMOMember(ReaderMember = "HDDGLOAECEK")]
	public List<KEODKEGFDLD_FreeMusicInfo> GEAANLPDJBP_FreeMusicData { get; private set; } // 0x24 BJHOBLKDBKK ONBBLMFKDMA IIGCCMELFCO
	[UMOMember(ReaderMember = "DBINAHBHDOC")]
	public List<DJNPIGEFPMF_StoryMusicInfo> CLHIABAKKJM_StoryMusicData { get; private set; } // 0x28 LECLIAKPOBM  PNNMFKPPDBI CHBJKIFMECH
	[UMOMember(ReaderMember = "DGEPOLGDKHA")]
	public List<KLBKPANJCPL_Score> CMPPNEFNGMK_Scores { get; private set; } // 0x2C // OLPOIIEPELN MPLAPBEGBOA PFDIMNJEMFF

	// // RVA: 0x10CF794 Offset: 0x10CF794 VA: 0x10CF794
	public EONOEHOKBEB_Music IAJLOELFHKC_GetMusicInfo(int _DLAEJOBELBH_MusicId)
	{
		if(_DLAEJOBELBH_MusicId > 0)
		{
			return EPMMNEFADAP_Music[_DLAEJOBELBH_MusicId - 1];
		}
		return null;
	}

	// // RVA: 0x10CF824 Offset: 0x10CF824 VA: 0x10CF824
	public KEODKEGFDLD_FreeMusicInfo NOBCLJIAMLC_GetFreeMusicData(int _GHBPLHBNMBK_FreeMusicId)
	{
		if(_GHBPLHBNMBK_FreeMusicId > 0)
		{
			return GEAANLPDJBP_FreeMusicData[_GHBPLHBNMBK_FreeMusicId - 1];
		}
		return null;
	}

	// // RVA: 0x10CF8B4 Offset: 0x10CF8B4 VA: 0x10CF8B4
	public DJNPIGEFPMF_StoryMusicInfo FLMLJIKBIMJ_GetStoryMusicData(int _KLCIIHKFPPO_StoryMusicId)
	{
		if (_KLCIIHKFPPO_StoryMusicId > 0)
		{
			return CLHIABAKKJM_StoryMusicData[_KLCIIHKFPPO_StoryMusicId - 1];
		}
		return null;
	}

	// // RVA: 0x10CF944 Offset: 0x10CF944 VA: 0x10CF944
	public HMJHLLPBCLD KCBOGEBCMMJ(int _LJNAKDMILMC_key)
	{
		HMJHLLPBCLD search = new HMJHLLPBCLD(_LJNAKDMILMC_key);
		int idx = OHLOHGGCCMD.BinarySearch(search);
		if(idx > -1)
		{
			return OHLOHGGCCMD[idx];
		}
		return null;
	}

	// // RVA: 0x10CFA30 Offset: 0x10CFA30 VA: 0x10CFA30
	public JPCKBFBCJKD LLJOPJMIGPD(int _GHBPLHBNMBK_FreeMusicId)
	{
		return MGBKDJLEICI.Find((JPCKBFBCJKD JPAEDJJFFOI) =>
		{
			//0xA0FA20
			return JPAEDJJFFOI.GHBPLHBNMBK_FreeMusicId == _GHBPLHBNMBK_FreeMusicId;
		});
	}

	// // RVA: 0x10CFB28 Offset: 0x10CFB28 VA: 0x10CFB28
	public bool IAAMKEJKPPL(JPCKBFBCJKD _KBOLNIBLIND_unlock, int _ADFIHAPELAN_PLevel)
	{
		if (_KBOLNIBLIND_unlock.ADBHJCDINFL_OpenPlRank < 1)
			return true;
		return _KBOLNIBLIND_unlock.ADBHJCDINFL_OpenPlRank <= _ADFIHAPELAN_PLevel;
	}

	// // RVA: 0x10CFB94 Offset: 0x10CFB94 VA: 0x10CFB94
	public HDNKOFNBCEO_RewardInfo NEJKJJPIGKD_GetRewardInfo(KEODKEGFDLD_FreeMusicInfo AOKGAGHGAEC_FreeMusicInfo, int _AKNELONELJK_difficulty, bool _GIKLNODJKFK_IsLine6)
	{
		if (!_GIKLNODJKFK_IsLine6)
			return MGDLFOAKGGF[AOKGAGHGAEC_FreeMusicInfo.EAEDODGPLEC_RewardBaseId + _AKNELONELJK_difficulty - 1];
		else
			return MGDLFOAKGGF[AOKGAGHGAEC_FreeMusicInfo.LOKLNBLBBFD_Reward6LineBaseId + _AKNELONELJK_difficulty - 1];
	}

	// // RVA: 0x10CFC50 Offset: 0x10CFC50 VA: 0x10CFC50
	public KLBKPANJCPL_Score ALJFMLEJEHH_GetMusicScore(int KKPAHLMJKIH_WavId, int _BKJGCEOEPFB_VariationId, int _NOAKHKMLPFK_Difficulty, bool _GIKLNODJKFK_IsLine6/* = false*/, bool IOOOMNMAGAH/* = true*/)
	{
		int a = 0;
		if (_GIKLNODJKFK_IsLine6)
			a = 1000;
		int b = _BKJGCEOEPFB_VariationId + KKPAHLMJKIH_WavId * 10000 + _NOAKHKMLPFK_Difficulty + 1;
		if(b+a != 0)
		{
			for(int i = 0; i < CMPPNEFNGMK_Scores.Count; i++)
			{
				if(CMPPNEFNGMK_Scores[i].GKNBCINLIJJ_Scid == (b+a))
				{
					return CMPPNEFNGMK_Scores[i];
				}
			}
			if (!_GIKLNODJKFK_IsLine6)
				return null;
			if (!IOOOMNMAGAH)
				return null;
			UnityEngine.Debug.LogWarning(string.Format("<color=red>not found Line6 Score Master:{0} -> use Line4:{1}</color>",b ,b+a));
			return ALJFMLEJEHH_GetMusicScore(KKPAHLMJKIH_WavId, _BKJGCEOEPFB_VariationId, _NOAKHKMLPFK_Difficulty, false, true);
		}
		return null;
	}

	// // RVA: 0x10CFE98 Offset: 0x10CFE98 VA: 0x10CFE98
	public int CHBLIEKBOLL_GetScoreId(int KKPAHLMJKIH_WavId, int _BKJGCEOEPFB_VariationId, int _NOAKHKMLPFK_Difficulty, bool _GIKLNODJKFK_IsLine6/* = false*/)
	{
		int val = 0;
		if (_GIKLNODJKFK_IsLine6)
			val = (int)((_NOAKHKMLPFK_Difficulty >> 0x1f) & 0xfffffc18) + 1000;
		return _BKJGCEOEPFB_VariationId + KKPAHLMJKIH_WavId * 10000 + _NOAKHKMLPFK_Difficulty + val + 1;
	}

	// // RVA: 0x10CFED0 Offset: 0x10CFED0 VA: 0x10CFED0
	public bool BHJKMPBACAC_IsFreeMusicAvaiable(int _GHBPLHBNMBK_FreeMusicId)
	{
		if (_GHBPLHBNMBK_FreeMusicId > 0 && _GHBPLHBNMBK_FreeMusicId <= GEAANLPDJBP_FreeMusicData.Count)
		{
			return NOBCLJIAMLC_GetFreeMusicData(_GHBPLHBNMBK_FreeMusicId).PPEGAKEIEGM_Enabled == 2;
		}
		return false;
	}

	// // RVA: 0x10CFFA0 Offset: 0x10CFFA0 VA: 0x10CFFA0
	public EONOEHOKBEB_Music INJDLHAEPEK_GetMusicInfo(int _GHBPLHBNMBK_FreeMusicId, int _DLAEJOBELBH_MusicId)
	{
		return IAJLOELFHKC_GetMusicInfo(CIKALPJDGMF_ResolveMusicId(_GHBPLHBNMBK_FreeMusicId, _DLAEJOBELBH_MusicId));
	}

	// // RVA: 0x10CFFC0 Offset: 0x10CFFC0 VA: 0x10CFFC0
	public int CIKALPJDGMF_ResolveMusicId(int _GHBPLHBNMBK_FreeMusicId, int _DLAEJOBELBH_MusicId)
	{
		if(_GHBPLHBNMBK_FreeMusicId != 0)
		{
			if(NOBCLJIAMLC_GetFreeMusicData(_GHBPLHBNMBK_FreeMusicId) != null)
			{
				if(NOBCLJIAMLC_GetFreeMusicData(_GHBPLHBNMBK_FreeMusicId).BLDDNEJDFON_ForcePrismId > 0)
				{
					if(NOBCLJIAMLC_GetFreeMusicData(_GHBPLHBNMBK_FreeMusicId).BLDDNEJDFON_ForcePrismId <= HBJDIFMCGAL_ForcedSettings.Count)
					{
						_DLAEJOBELBH_MusicId = HBJDIFMCGAL_ForcedSettings[NOBCLJIAMLC_GetFreeMusicData(_GHBPLHBNMBK_FreeMusicId).BLDDNEJDFON_ForcePrismId - 1].IOPCBBNHJIP_ForcedMusicId;
					}
				}
			}
		}
		return _DLAEJOBELBH_MusicId;
	}

	// // RVA: 0x10D00E8 Offset: 0x10D00E8 VA: 0x10D00E8
	public AOJCMPIBFHD OOKAOFJBCFD(int _DLAEJOBELBH_MusicId, int _OFGIOBGAJPA_NumDiva)
	{
		return DBBLKLCCHFC.FindAll((AOJCMPIBFHD _GHPLINIACBB_x) => {
			//0xA0FA6C
			return _GHPLINIACBB_x.DLAEJOBELBH_MusicId == _DLAEJOBELBH_MusicId;
		}).Find((AOJCMPIBFHD _GHPLINIACBB_x) => {
			//0xA0FAA4
			return _GHPLINIACBB_x.OFGIOBGAJPA_NumDiva == _OFGIOBGAJPA_NumDiva;
		});
	}

	// // RVA: 0x10D0270 Offset: 0x10D0270 VA: 0x10D0270
	public int DCMGLKDJAKL(int JHNCAFBGOKA, int HKOHGJAIJMA, List<int> JFCDMNPDIGP)
	{
		foreach(var k in DBBLKLCCHFC)
		{
			if (k.PLALNIIBLOF_en != 2)
				break;
			if(k.DLAEJOBELBH_MusicId == JHNCAFBGOKA && k.OFGIOBGAJPA_NumDiva == HKOHGJAIJMA)
			{
				int[] a = k.AHHJLDLAPAN_DivaId;
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
		EPMMNEFADAP_Music = new List<EONOEHOKBEB_Music>(300);
		GEAANLPDJBP_FreeMusicData = new List<KEODKEGFDLD_FreeMusicInfo>(2000);
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
	protected override void KMBPACJNEOF_Reset()
	{
		EPMMNEFADAP_Music.Clear();
		GEAANLPDJBP_FreeMusicData.Clear();
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
			data.DLAEJOBELBH_MusicId = (short)i;
			EPMMNEFADAP_Music.Add(data);
		}
		for(int i = 1; i < 2001; i++)
		{
			KEODKEGFDLD_FreeMusicInfo data = new KEODKEGFDLD_FreeMusicInfo();
			data.GHBPLHBNMBK_FreeMusicId = (short)i;
			GEAANLPDJBP_FreeMusicData.Add(data);
		}
	}

	// // RVA: 0x10D0B00 Offset: 0x10D0B00 VA: 0x10D0B00 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
	{
		BMHPFEELLNP reader = BMHPFEELLNP.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		JJOLLBDMIJP_LoadScore(reader);
		NOGICBBHLNK_LoadFreeReward(reader);
		KANEJCIALLM_LoadStoryTh(reader);
		if(AOPNONMKCLC_LoadMusic(reader) && ANKANPOHJNM_LoadFreeMusic(reader))
		{
			AHNNMALAMFF_LoadStoryMusicData(reader);
			CNCEJAKLNBL(reader);
			FKLPBNIFBNF(reader);
			DNCNGDFMMPI(reader);
			ALLLNNDHGLA(reader);
			return true;
		}
		return false;
	}

	// // RVA: 0x10D52EC Offset: 0x10D52EC VA: 0x10D52EC Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		// = KNIFCANOHOC_score JJOLLBDMIJP_LoadScore
		// = EPEKGCONFFP_free_reward NOGICBBHLNK_LoadFreeReward
		// = KIOKIBGIHBM_story_th KANEJCIALLM_LoadStoryTh
		// = FFMHJIJBKEN_music AOPNONMKCLC_LoadMusic
		// = KOHMHBGOFFI_free_music
		TodoLogger.LogError(TodoLogger.DbJson, "TODO");
		return true;
	}

	// // RVA: 0x10D0BB4 Offset: 0x10D0BB4 VA: 0x10D0BB4
	private bool JJOLLBDMIJP_LoadScore(BMHPFEELLNP FCLGPOPLDFL)
	{
		FMAFIIPNNEO[] array = FCLGPOPLDFL.DGEPOLGDKHA;
		for(int i = 0; i < array.Length; i++)
		{
			KLBKPANJCPL_Score data = new KLBKPANJCPL_Score();
			data.GKNBCINLIJJ_Scid = (int)array[i].GKHGCPODNEG_scid;
			data.ANAJIAENLNB_lv = (int)array[i].ANAJIAENLNB_lv;
			data.NLKEBAOBJCM_combo = (int)array[i].OLKHBHLOKJI_cb;
			data.KNIFCANOHOC_score = (int)array[i].EJOECKJNGPD_ss;
			data.CKDPPJAHAIP_Dn = (int)array[i].HDBEJBBPPBK_dn;
			data.NPKMKMBEOAG_Dnc = (int)array[i].HOPIMOECAFA_dnc;
			data.NPGCIDONKOP_Sp = (int)array[i].PIPCIMIALOO_sp;
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
	// private bool JJOLLBDMIJP_LoadScore(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }
	//GKNBCINLIJJ_Scid = GKHGCPODNEG_scid
	//ANAJIAENLNB_lv = ANAJIAENLNB_lv
	//NLKEBAOBJCM_combo = OLKHBHLOKJI_cb
	//KNIFCANOHOC_score = EJOECKJNGPD_ss
	//CKDPPJAHAIP_Dn = HDBEJBBPPBK_dn
	//NPKMKMBEOAG_Dnc = HOPIMOECAFA_dnc
	//NPGCIDONKOP_Sp = PIPCIMIALOO_sp

	// // RVA: 0x10D1584 Offset: 0x10D1584 VA: 0x10D1584
	private bool AOPNONMKCLC_LoadMusic(BMHPFEELLNP FCLGPOPLDFL)
	{
		JPALGGIPGGN[] array = FCLGPOPLDFL.MDFFJJKBDFC;
		for(int i = 0; i < array.Length; i++)
		{
			EONOEHOKBEB_Music data = EPMMNEFADAP_Music[i];
			data.DLAEJOBELBH_MusicId = (short)array[i].PPFNGGCBJKC_id;
			data.JNCPEGJGHOG_JacketId = (short)array[i].JPHOOKPHBLD_cov;
			data.NNHOBFBCIIJ_Cd = (short)array[i].DPBBFBFJCKG;
			data.KNMGEEFGDNI_Name = (short)array[i].IIPIPIABGDG_nam;
			data.NODKIFGGMGP_Div = (short)array[i].FNAEGLFKDBI_div;
			data.FKDCCLPGKDK_JacketAttr = (sbyte)array[i].AOLLIMFKDAA_ma;
			data.EMIKBGHIOMN_SerieLogoId = (sbyte)array[i].JPFMJHLCMJL_sa;
			data.AIHCEGFANAM_SerieAttr = (sbyte)SeriesAttr.ConvertFromLogoId((SeriesLogoId.Type)data.EMIKBGHIOMN_SerieLogoId);
			data.KKPAHLMJKIH_WavId = (short)array[i].IKOFFIOMOME_wav;
			data.BKJGCEOEPFB_VariationId = (short)array[i].PKLIPLFIDED_sco;
			data.GHICLBNHNGJ_Dsc = (short)array[i].GJDKHDLKONI_dsc;
			data.AABILPMIOFN_Strt = (short)array[i].AJAGMMHPBBC_strt;
			data.DMKCGNMOCCH_ValkyrieBattle = (short)array[i].DHCBIMHIPHB;
			data.EECJONKNHNK_ValkyrieIntro = (short)array[i].MGJJHHGDOFK;
			data.MNEFKDDCEHE_ValkyrieIntroSky = (short)array[i].FEJADFIALKK;
			data.NJAOOMHCIHL_DivaSolo = (short)array[i].FFKLLDKDEFP;
			data.PECMGDOMLAF_DivaMulti = (short)array[i].MIDEDJKGOED;
			data.ACPKFNNONMH_Exp = (short)array[i].LKIFDCEKDCK_exp;
		}
		return true;
	}

	// // RVA: 0x10D6180 Offset: 0x10D6180 VA: 0x10D6180
	// private bool AOPNONMKCLC_LoadMusic(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }
	//DLAEJOBELBH_MusicId = PPFNGGCBJKC_id
	//JNCPEGJGHOG_JacketId = JPHOOKPHBLD_cov
	//NNHOBFBCIIJ_Cd = cd
	//KNMGEEFGDNI_Name = IIPIPIABGDG_nam
	//NODKIFGGMGP_Div = FNAEGLFKDBI_div
	//FKDCCLPGKDK_JacketAttr = AOLLIMFKDAA_ma
	//EMIKBGHIOMN_SerieLogoId = JPFMJHLCMJL_sa
	//KKPAHLMJKIH_WavId = IKOFFIOMOME_wav
	//BKJGCEOEPFB_VariationId = PKLIPLFIDED_sco
	//GHICLBNHNGJ_Dsc = GJDKHDLKONI_dsc
	//AABILPMIOFN_Strt = AJAGMMHPBBC_strt
	//DMKCGNMOCCH_ValkyrieBattle = vlb
	//EECJONKNHNK_ValkyrieIntro = vli
	//MNEFKDDCEHE_ValkyrieIntroSky = vlis
	//NJAOOMHCIHL_DivaSolo = dvs
	//PECMGDOMLAF_DivaMulti = dvm
	//ACPKFNNONMH_Exp = exp

	// // RVA: 0x10D104C Offset: 0x10D104C VA: 0x10D104C
	private bool NOGICBBHLNK_LoadFreeReward(BMHPFEELLNP FCLGPOPLDFL)
	{
		KEBPMGGPLIF[] array = FCLGPOPLDFL.LNNNCEAAIAM;
		for (int i = 0; i < array.Length; i++)
		{
			HDNKOFNBCEO_RewardInfo data = new HDNKOFNBCEO_RewardInfo();
			data.EIHOBHDKCDB_RewardId = (int)array[i].FCEJJEPFIPH_rwid;
			data.LLEILBEMEEJ_Itm = new List<int>(39);
			for(int j = 0; j < array[i].AIHOJKFNEEN_itm.Length; j++)
			{
				data.LLEILBEMEEJ_Itm.Add((int)array[i].AIHOJKFNEEN_itm[j]);
			}
			MGDLFOAKGGF.Add(data);
		}
		return true;
	}

	// // RVA: 0x10D5ACC Offset: 0x10D5ACC VA: 0x10D5ACC
	// private bool NOGICBBHLNK_LoadFreeReward(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }
	//EIHOBHDKCDB_RewardId = FCEJJEPFIPH_rwid
	//LLEILBEMEEJ_Itm = AIHOJKFNEEN_itm

	// // RVA: 0x10D12E8 Offset: 0x10D12E8 VA: 0x10D12E8
	private bool KANEJCIALLM_LoadStoryTh(BMHPFEELLNP FCLGPOPLDFL)
	{
		EODMBJMOHBC[] array = FCLGPOPLDFL.BJGDMLNFKKN;
		for(int i = 0; i < array.Length; i++)
		{
			NONFIGBOJLN data = new NONFIGBOJLN();
			data.PDGEMDFHFIB_ThId = array[i].LBMELIONKKB_thid;
			data.MNKDEFJFKGN_Val = new List<int>(8);
			for(int j = 0; j < array[i].JBGEEPFKIGG_val.Length; j++)
			{
				data.MNKDEFJFKGN_Val.Add((int)array[i].JBGEEPFKIGG_val[j]);
			}
			NEIBEDCGDEM.Add(data);
		}
		return true;
	}

	// // RVA: 0x10D5E30 Offset: 0x10D5E30 VA: 0x10D5E30
	// private bool KANEJCIALLM_LoadStoryTh(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }
	//PDGEMDFHFIB_ThId = LBMELIONKKB_thid
	//MNKDEFJFKGN_Val = JBGEEPFKIGG_val

	// // RVA: 0x10D730C Offset: 0x10D730C VA: 0x10D730C
	private ADDHLABEFKH FEEODHDKLFH(int _EJOECKJNGPD_ss, int _OLKHBHLOKJI_cb, int _OIPCCBHIKIA_index, HDNKOFNBCEO_RewardInfo _IBOGLMCNFBK_set)
	{
		ADDHLABEFKH res = new ADDHLABEFKH();
		res.DJEEFNHADDJ = _OIPCCBHIKIA_index;
		res.KNIFCANOHOC_score.Add(_IBOGLMCNFBK_set.GPBKAAMLIBF(4) * _EJOECKJNGPD_ss / 100);
		res.NLKEBAOBJCM_combo.Add(_IBOGLMCNFBK_set.GPBKAAMLIBF(8) * _OLKHBHLOKJI_cb / 100);
		res.KNIFCANOHOC_score.Add(_IBOGLMCNFBK_set.GPBKAAMLIBF(5) * _EJOECKJNGPD_ss / 100);
		res.NLKEBAOBJCM_combo.Add(_IBOGLMCNFBK_set.GPBKAAMLIBF(9) * _OLKHBHLOKJI_cb / 100);
		res.KNIFCANOHOC_score.Add(_IBOGLMCNFBK_set.GPBKAAMLIBF(6) * _EJOECKJNGPD_ss / 100);
		res.NLKEBAOBJCM_combo.Add(_IBOGLMCNFBK_set.GPBKAAMLIBF(10) * _OLKHBHLOKJI_cb / 100);
		res.KNIFCANOHOC_score.Add(_IBOGLMCNFBK_set.GPBKAAMLIBF(7) * _EJOECKJNGPD_ss / 100);
		res.NLKEBAOBJCM_combo.Add(_IBOGLMCNFBK_set.GPBKAAMLIBF(11) * _OLKHBHLOKJI_cb / 100);
		res.KNIFCANOHOC_score.Add(999999999);
		res.NLKEBAOBJCM_combo.Add(999999999);
		return res;
	}

	// // RVA: 0x10D7728 Offset: 0x10D7728 VA: 0x10D7728
	private ADDHLABEFKH FEEODHDKLFH(int _EJOECKJNGPD_ss, int _OLKHBHLOKJI_cb, int _OIPCCBHIKIA_index, NONFIGBOJLN _IBOGLMCNFBK_set)
	{
		ADDHLABEFKH res = new ADDHLABEFKH();
		res.DJEEFNHADDJ = _OIPCCBHIKIA_index;
		res.KNIFCANOHOC_score.Add(_IBOGLMCNFBK_set.MNKDEFJFKGN_Val[0] * _EJOECKJNGPD_ss / 100);
		res.NLKEBAOBJCM_combo.Add(_IBOGLMCNFBK_set.MNKDEFJFKGN_Val[4] * _OLKHBHLOKJI_cb / 100);
		res.KNIFCANOHOC_score.Add(_IBOGLMCNFBK_set.MNKDEFJFKGN_Val[1] * _EJOECKJNGPD_ss / 100);
		res.NLKEBAOBJCM_combo.Add(_IBOGLMCNFBK_set.MNKDEFJFKGN_Val[5] * _OLKHBHLOKJI_cb / 100);
		res.KNIFCANOHOC_score.Add(_IBOGLMCNFBK_set.MNKDEFJFKGN_Val[2] * _EJOECKJNGPD_ss / 100);
		res.NLKEBAOBJCM_combo.Add(_IBOGLMCNFBK_set.MNKDEFJFKGN_Val[6] * _OLKHBHLOKJI_cb / 100);
		res.KNIFCANOHOC_score.Add(_IBOGLMCNFBK_set.MNKDEFJFKGN_Val[3] * _EJOECKJNGPD_ss / 100);
		res.NLKEBAOBJCM_combo.Add(_IBOGLMCNFBK_set.MNKDEFJFKGN_Val[7] * _OLKHBHLOKJI_cb / 100);
		res.KNIFCANOHOC_score.Add(999999999);
		res.NLKEBAOBJCM_combo.Add(999999999);
		return res;
	}

	// // RVA: 0x10D1FCC Offset: 0x10D1FCC VA: 0x10D1FCC
	private bool ANKANPOHJNM_LoadFreeMusic(BMHPFEELLNP FCLGPOPLDFL)
	{
		NLDAADHODFI[] array = FCLGPOPLDFL.HDDGLOAECEK;
		if (array.Length >= 2001)
			return false;
		for(int i = 0; i < array.Length; i++)
		{
			KEODKEGFDLD_FreeMusicInfo data = GEAANLPDJBP_FreeMusicData[i];
			data.GHBPLHBNMBK_FreeMusicId = (short)array[i].EHDDADDKMFI_f_id;
			data.PPEGAKEIEGM_Enabled = (sbyte)JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE_mver, (int)array[i].PLALNIIBLOF_en, 0);
			data.IJEKNCDIIAE_mver = array[i].IJEKNCDIIAE_mver;
			data.DEPGBBJMFED_CategoryId = (sbyte)array[i].DMEDKJPOLCH_cat;
			data.EKANGPODCEP_EventId = (int)array[i].LHKFKIKEJHN_evnt;
			data.DLAEJOBELBH_MusicId = (short)array[i].KLMIFEKNBLL_m_id;
			data.EEFLOOBOAGF_ViewOrder = (short)array[i].FPOMEEJFBIG_odr;
			data.KEFGPJBKAOD_BgId = (short)array[i].CBBLAMDGOGK_bg;
			data.LOHABKAHNKD((short)array[i].GPNOEFHGOJG_dr, (short)array[i].ECLGEFGJMAM);
			data.MGLDIOILOFF_NormalSetId = (short)array[i].PAIIHEJIGKO_ds;
			data.FEOLNFKIIJJ((short)array[i].NOHIMPJDOCK_rdr1, (short)array[i].FABJJODPCIN);
			data.JCDKMICANJO_RareSetId = (short)array[i].DFELEPDHLBF_rds1;
			data.FNFKCHMPLAD((short)array[i].CAJKBDLCGOD_rdr2, (short)array[i].CCHNGBLALEB);
			data.CCLIOBOGFHC = (short)array[i].LHBNIAJDIGA_rds2;
			data.EAEDODGPLEC_RewardBaseId = (short)array[i].FCEJJEPFIPH_rwid;
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
			data.GBNOALJPOBM_IsLine6 = b;
			for(int j = 0; j < array[i].CFJKNAIOEAN_spn.Length; j++)
			{
				data.OCOGIADDNDN_SpNotes[j] = (short)array[i].CFJKNAIOEAN_spn[j];
				data.DPJDHKIIJIJ_SpNotesByDiff6Line[j] = (short)array[i].BODBNFFIOJN[j];
			}
			for (int j = 0; j < array[i].BKEIOLFMMDH_emy.Length; j++)
			{
				data.LHICAKGHIGF_EnemyIdByDiff[j] = (short)array[i].BKEIOLFMMDH_emy[j];
				data.PJNFOCDANCE_EnemyIdByDiffL6[j] = (short)array[i].KJLLNPFHEEL[j];
			}
			for (int j = 0; j < array[i].JGEIIONMJMI_v_in.Length; j++)
			{
				data.HLKHOFPAOMK_SubGoalByDiff[j] = (int)array[i].JGEIIONMJMI_v_in[j];
				data.MAGILDGLOKD_SubGoalFreeModeL6ByDiff[j] = (int)array[i].DOAFFAGEHOM[j];
			}
			for (int j = 0; j < array[i].CMENIBCJJNF_v_aw.Length; j++)
			{
				data.HLLJIICKNIP_GoalByDiff[j] = (int)array[i].CMENIBCJJNF_v_aw[j];
				data.JEANDFEBLIG_GoalFreeModeL6ByDiff[j] = (int)array[i].BIHJCIGKMBA[j];
			}
			for (int j = 0; j < array[i].KMFHHOANPFH_v_max.Length; j++)
			{
				data.FENOHOEIJOE_MaxValue[j] = (int)array[i].KMFHHOANPFH_v_max[j];
				data.KFIDHFOGDPJ_MaxValueFreeModeL6ByDiff[j] = (int)array[i].OOBOCLOFPBF[j];
			}
			for (int j = 0; j < array[i].EHODALENBEL_d_in.Length; j++)
			{
				data.LJPKLMJPLAC_DIn[j] = (int)array[i].EHODALENBEL_d_in[j];
				data.ILCJOOPIILK[j] = (int)array[i].DKAIOCGKJLO[j];
			}
			for (int j = 0; j < array[i].ALJIHHGHCOG_sd_in.Length; j++)
			{
				data.MALHPBKPIDE_SdIn[j] = (int)array[i].ALJIHHGHCOG_sd_in[j];
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
					i1 = k.NLKEBAOBJCM_combo;
					i2 = k.KNIFCANOHOC_score;
					i3 = k.OIPCCBHIKIA_index;
				}
				HDNKOFNBCEO_RewardInfo data2 = MGDLFOAKGGF[data.EAEDODGPLEC_RewardBaseId - 1];
				data.NHKABAGJCDM(FEEODHDKLFH(i2, i1, i3, data2));
				KLBKPANJCPL_Score k2 = ALJFMLEJEHH_GetMusicScore(m.KKPAHLMJKIH_WavId, m.BKJGCEOEPFB_VariationId, j, true, false);
				if(k2 != null)
				{
					data2 = MGDLFOAKGGF[data.LOKLNBLBBFD_Reward6LineBaseId - 1];
					data.IFABJEBEKPB(FEEODHDKLFH(k2.KNIFCANOHOC_score, k2.NLKEBAOBJCM_combo, k2.OIPCCBHIKIA_index, data2));
				}
			}
		}
		return true;
	}

	// // RVA: 0x10D6D94 Offset: 0x10D6D94 VA: 0x10D6D94
	// private bool ANKANPOHJNM_LoadFreeMusic(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }

	// // RVA: 0x10D3D78 Offset: 0x10D3D78 VA: 0x10D3D78
	private bool AHNNMALAMFF_LoadStoryMusicData(BMHPFEELLNP FCLGPOPLDFL)
	{
		FBAFBKNKENO[] array = FCLGPOPLDFL.DBINAHBHDOC;
		for(int i = 0; i < array.Length; i++)
		{
			DJNPIGEFPMF_StoryMusicInfo data = new DJNPIGEFPMF_StoryMusicInfo();
			data.KLCIIHKFPPO_StoryMusicId = (short)array[i].BDJMFDKLHPM_s_id;
			data.DEPGBBJMFED_CategoryId = (int)array[i].DMEDKJPOLCH_cat;
			data.DLAEJOBELBH_MusicId = (int)array[i].KLMIFEKNBLL_m_id;
			data.KEFGPJBKAOD_BgId = (int)array[i].CBBLAMDGOGK_bg;
			data.MHPAFEEPBNJ = (int)array[i].NHBLDIPBHNF_pg;
			data.KCNHKNKNGNH_NormalRateId = (int)array[i].GPNOEFHGOJG_dr;
			data.MGLDIOILOFF_NormalSetId = (int)array[i].PAIIHEJIGKO_ds;
			data.PPEGAKEIEGM_Enabled = (byte)JKAECBCNHAN_IsEnabled(1, (int)array[i].PLALNIIBLOF_en, 0);
			for(int j = 0; j < array[i].CFJKNAIOEAN_spn.Length; j++)
			{
				data.OCOGIADDNDN_SpNotes[j] = (short)array[i].CFJKNAIOEAN_spn[j];
			}
			for (int j = 0; j < array[i].BKEIOLFMMDH_emy.Length; j++)
			{
				data.LHICAKGHIGF_EnemyIdByDiff[j] = (short)array[i].BKEIOLFMMDH_emy[j];
			}
			for (int j = 0; j < array[i].JGEIIONMJMI_v_in.Length; j++)
			{
				data.HLKHOFPAOMK_SubGoalByDiff[j] = (short)array[i].JGEIIONMJMI_v_in[j];
			}
			for (int j = 0; j < array[i].CMENIBCJJNF_v_aw.Length; j++)
			{
				data.HLLJIICKNIP_GoalByDiff[j] = (short)array[i].CMENIBCJJNF_v_aw[j];
			}
			for (int j = 0; j < array[i].KMFHHOANPFH_v_max.Length; j++)
			{
				data.FENOHOEIJOE_MaxValue[j] = (short)array[i].KMFHHOANPFH_v_max[j];
			}
			for (int j = 0; j < array[i].EHODALENBEL_d_in.Length; j++)
			{
				data.LJPKLMJPLAC_DIn[j] = (short)array[i].EHODALENBEL_d_in[j];
			}
			for (int j = 0; j < array[i].ALJIHHGHCOG_sd_in.Length; j++)
			{
				data.MALHPBKPIDE_SdIn[j] = (short)array[i].ALJIHHGHCOG_sd_in[j];
			}
			for(int j = 0; j < 5; j++)
			{
				EONOEHOKBEB_Music music = IAJLOELFHKC_GetMusicInfo(data.DLAEJOBELBH_MusicId);
				KLBKPANJCPL_Score score = ALJFMLEJEHH_GetMusicScore(music.KKPAHLMJKIH_WavId, music.BKJGCEOEPFB_VariationId, j, false, true);
				if(score != null)
				{
					data.COGKJBAFBKN_ByDiff.Add(FEEODHDKLFH(score.KNIFCANOHOC_score, score.NLKEBAOBJCM_combo, score.OIPCCBHIKIA_index, NEIBEDCGDEM[0]));
				}
			}
			CLHIABAKKJM_StoryMusicData.Add(data);
		}
		return true;
	}

	// // RVA: 0x10D6D9C Offset: 0x10D6D9C VA: 0x10D6D9C
	// private bool AHNNMALAMFF_LoadStoryMusicData(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }

	// // RVA: 0x10D46D8 Offset: 0x10D46D8 VA: 0x10D46D8
	private bool CNCEJAKLNBL(BMHPFEELLNP FCLGPOPLDFL)
	{
		INDENDCNNHJ[] array = FCLGPOPLDFL.CDKOBOHBJHM;
		for(int i = 0; i < array.Length; i++)
		{
			HMJHLLPBCLD data = new HMJHLLPBCLD((int)array[i].LJNAKDMILMC_key);
			data.LHBDCGFOKCA_DivaId = (short)array[i].JBKMAPLCBMO_arg[0];
			data.CEFHDLLAPDH_MusicId = (short)array[i].JBKMAPLCBMO_arg[1];
			data.KDGIHMCBLND_MusicLevel = (short)array[i].JBKMAPLCBMO_arg[2];
			OHLOHGGCCMD.Add(data);
		}
		return true;
	}

	// // RVA: 0x10D6DA4 Offset: 0x10D6DA4 VA: 0x10D6DA4
	// private bool CNCEJAKLNBL(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }
	//LJNAKDMILMC_key = LJNAKDMILMC_key
	//JBKMAPLCBMO_arg

	// // RVA: 0x10D4950 Offset: 0x10D4950 VA: 0x10D4950
	private bool FKLPBNIFBNF(BMHPFEELLNP FCLGPOPLDFL)
	{
		NJBDNGAPLLI[] array = FCLGPOPLDFL.JEOOAMHEMJL;
		for (int i = 0; i < array.Length; i++)
		{
			JPCKBFBCJKD data = new JPCKBFBCJKD();
			data.GHBPLHBNMBK_FreeMusicId = (int)array[i].EHDDADDKMFI_f_id;
			data.ADBHJCDINFL_OpenPlRank = (int)array[i].NKAKDIEKAGL_open_pl_rank;
			MGBKDJLEICI.Add(data);
		}
		return true;
	}

	// // RVA: 0x10D70B0 Offset: 0x10D70B0 VA: 0x10D70B0
	// private bool FKLPBNIFBNF(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }
	//GHBPLHBNMBK_FreeMusicId = EHDDADDKMFI_f_id
	//ADBHJCDINFL_OpenPlRank = NKAKDIEKAGL_open_pl_rank

	// // RVA: 0x10D4B28 Offset: 0x10D4B28 VA: 0x10D4B28
	private bool DNCNGDFMMPI(BMHPFEELLNP FCLGPOPLDFL)
	{
		OIPFPLPMCMF[] array = FCLGPOPLDFL.JNFKEOEGGLF;
		for (int i = 0; i < array.Length; i++)
		{
			AIPEHINPIHC_ForcedSettingInfo data = new AIPEHINPIHC_ForcedSettingInfo();
			data.NMNDNFFJHPJ_Id = (int)array[i].EIIOPABMJFJ;
			data.GPPEFLKGGGJ_ValkyrieId = (int)array[i].FODKKJIDDKN_vf_Id;
			for(int j = 0; j < 3; j++)
			{
				data.AHHJLDLAPAN_DivaId[j] = (int)array[i].DIPKCALNIII_diva_id[j];
				data.JPIDIENBGKH_CostumeId[j] = (int)array[i].BEEAIAAJOHD_CostumeId[j];
			}
			data.IOPCBBNHJIP_ForcedMusicId = (int)array[i].NBMPGOJBPMD;
			data.OOFEIPCLEKJ_DivaVoice = (int)array[i].OOFEIPCLEKJ_DivaVoice;
			data.EDDLJBLJJOE_PilotVoice = (int)array[i].EDDLJBLJJOE_PilotVoice;
			data.JIIOKINLOGM_NoteType = (int)array[i].JIIOKINLOGM_NoteType;
			data.MDKNFOIMCJB_NoteSe = (int)array[i].MDKNFOIMCJB_NoteSe;
			data.OENPCNBFPDA_bg_id = (int)array[i].OENPCNBFPDA_bg_id;
			data.EGMIILFFHMI_DivaMode = (int)array[i].EGMIILFFHMI_DivaMode;
			data.HFMFGFHPBNB_ValkyrieMode = (int)array[i].HFMFGFHPBNB_ValkyrieMode;
			data.ENAAKPKFBGN_EffectCutIn = (int)array[i].ENAAKPKFBGN_EffectCutIn;
			data.IHLDBMMOCHF_ForceSLiveResultSerifWindow = (int)array[i].IHLDBMMOCHF_ForceSLiveResultSerifWindow;
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
			data.IJEKNCDIIAE_mver = (int)array[i].IJEKNCDIIAE_mver;
			data.PLALNIIBLOF_en = JKAECBCNHAN_IsEnabled(data.IJEKNCDIIAE_mver, (int)array[i].PLALNIIBLOF_en, 0);
			data.DLAEJOBELBH_MusicId = (int)array[i].KLMIFEKNBLL_m_id;
			for(int j = 0; j < array[i].DIPKCALNIII_diva_id.Length; j++)
			{
				data.AHHJLDLAPAN_DivaId[j] = (int)array[i].DIPKCALNIII_diva_id[j];
			}
			data.OFGIOBGAJPA_NumDiva = (int)array[i].ELDPFJIDNAB;
			data.OEJOOMPKAOO = (int)array[i].NDIJPKPDOMG;
			DBBLKLCCHFC.Add(data);
		}
		return true;
	}

	// // RVA: 0x10D7BD4 Offset: 0x10D7BD4 VA: 0x10D7BD4 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "LPPGENBEECK_MusicMaster.CAOGDCBPBAN");
		return 0;
	}
}

[System.Obsolete("Use KLBKPANJCPL_Score", true)]
public class KLBKPANJCPL {}
[UMOClass(ReaderClass = "FMAFIIPNNEO")]
public class KLBKPANJCPL_Score
{
	public int OIPCCBHIKIA_index; // 0x8

	[UMOMember(ReaderMember = "GKHGCPODNEG_scid")]
	public int GKNBCINLIJJ_Scid { get; set; } // 0xC  // PIEBLLLAAEF ECBOBCJLLOD LFMJPMIHHBF
	[UMOMember(ReaderMember = "ANAJIAENLNB_lv")]
	// Level
	public int ANAJIAENLNB_lv { get; set; } // 0x10 // IKMILCFHBGA MMOMNMBKHJF FEHNFGPFINK
	[UMOMember(ReaderMember = "OLKHBHLOKJI_cb")]
	public int NLKEBAOBJCM_combo { get; set; }   // 0x14 // ABLBDMPGEHA AECNKGBNKHH ECHLKFHOJFP
	[UMOMember(ReaderMember = "EJOECKJNGPD_ss")]
	public int KNIFCANOHOC_score { get; set; }   // 0x18 // DKDLLFCBBCE EOJEPLIPOMJ AEEMBPAEAAI
	[UMOMember(ReaderMember = "HDBEJBBPPBK_dn")]
	public int CKDPPJAHAIP_Dn { get; set; }   // 0x1C // MBBGDHGPJDM DBMNFCDGGEC JEFJBPPGBOK
	[UMOMember(ReaderMember = "HOPIMOECAFA_dnc")]
	public int NPKMKMBEOAG_Dnc { get; set; }  // 0x20 // AKAEHHAHFDM GHJDKBCAGLL IIEJNMBABCK
	[UMOMember(ReaderMember = "PIPCIMIALOO_sp")]
	public int NPGCIDONKOP_Sp { get; set; }   // 0x24 // AHONHAIELEA GKHINHNGCKE LLPNJHACHEB
	[UMOMember(ReaderMember = "MOIECBABHNP")]
	public int MCMIPODICAN_length { get; set; }      // 0x28 // IFGANBEKEAE DAGDLFMEAKG FNGANMMAACC
	[UMOMember(ReaderMember = "AMGHCNHIFFG")]
	public int KIEHDJFCCNM { get; set; }      // 0x2C // EGKCBOHGFBA LNPKNMONEFI CEPCIKJKLLF
	[UMOMember(ReaderMember = "KKBPKNBLJCK")]
	public int GEIDIHCKDNO { get; set; }      // 0x30 // DDIGBBJDNLF JAOFBBKGCHP IBIPFCNGHFF
	[UMOMember(ReaderMember = "GDHLEEJPNIJ")]
	public int JJBOEMOJPEC_DivaNote { get; set; }      // 0x34 // BAGPHOPPPPC FGMMNEIIHKM MFKGPCOLFLA
	[UMOMember(ReaderMember = "AOLENLGEJED")]
	public int OABPNBLPHHP_ValkStartTime { get; set; }      // 0x38 // GJJGLNLOGHN BMCLOFLOPLO IABNMIBLHAA
	[UMOMember(ReaderMember = "EPEBHGHKMBE")]
	public int GIABDDFGHOK_DivaStartTime { get; set; }      // 0x3C // COGAGDDAEFD EHAGPCANMCN FMJMCAEJMPG

	// RVA: 0x1A0B9C0 Offset: 0x1A0B9C0 VA: 0x1A0B9C0
	//public uint CAOGDCBPBAN() { }
}

[System.Obsolete("Use EONOEHOKBEB_Music", true)]
public class EONOEHOKBEB{}
[UMOClass(ReaderClass = "JPALGGIPGGN")]
public class EONOEHOKBEB_Music
{
	[UMOMember(ReaderMember = "PPFNGGCBJKC_id")]
	public short DLAEJOBELBH_MusicId { get; set; } // CKJALIDGGOH // 0x8 MPGNHBOBFBD EPEMOAEGPLI
	[UMOMember(ReaderMember = "JPHOOKPHBLD_cov")]
	public short JNCPEGJGHOG_JacketId { get; set; } // LABOODIMOII // 0xA HHEADMHBBPB GOFFKDDNACG
	[UMOMember(ReaderMember = "DPBBFBFJCKG")]
	public short NNHOBFBCIIJ_Cd { get; set; } // GKMKHKHFBEI // 0xC AOBMNDMGGIO NIMNBBDNJMC
	[UMOMember(ReaderMember = "IIPIPIABGDG_nam")]
	public short KNMGEEFGDNI_Name { get; set; } // JELJHGCOAFJ // 0xE HKEFEIOCKLP OCOGGADKEHD
	[UMOMember(ReaderMember = "FNAEGLFKDBI_div")]
	public short NODKIFGGMGP_Div { get; set; } // PNBJIFJHCBL // 0x10 APAOBAGKCPC LKDECIOADPO
	[UMOMember(ReaderMember = "AOLLIMFKDAA_ma")]
	public sbyte FKDCCLPGKDK_JacketAttr { get; set; } // KLMKEFEMHOC // 0x12 FBADKBMGIBP NCNMMABFHGN
	[UMOMember(ReaderMember = "JPFMJHLCMJL_sa")]
	public sbyte AIHCEGFANAM_SerieAttr { get; set; } // FJOGAAMLJMA // 0x13 ANEJPLENMAL HEHDOGFEIOL
	[UMOMember(ReaderMember = "JPFMJHLCMJL_sa")]
	public sbyte EMIKBGHIOMN_SerieLogoId { get; set; } // CCEIEDMCHLA // 0x14 BJGJCKFOBCA OAKIKBEEACC
	[UMOMember(ReaderMember = "IKOFFIOMOME_wav")]
	public short KKPAHLMJKIH_WavId { get; set; } // EOPNGHAFEMB // 0x16 ENODDPDBIPA HOAKFLEAEOH
	[UMOMember(ReaderMember = "PKLIPLFIDED_sco")]
	public short BKJGCEOEPFB_VariationId { get; set; } // PJKCKOJHKEM // 0x18 FNEBPBJBIIP OIDGLNHNGJB
	[UMOMember(ReaderMember = "GJDKHDLKONI_dsc")]
	public short GHICLBNHNGJ_Dsc { get; set; } // IHIHAAJLBHK // 0x1A OLKANNICFLL MHEEIDDKIJH
	[UMOMember(ReaderMember = "AJAGMMHPBBC_strt")]
	public short AABILPMIOFN_Strt { get; set; } // HJBLBCKELMF // 0x1C GACMKBLPOIB LKFFBLEIPIP
	[UMOMember(ReaderMember = "DHCBIMHIPHB")]
	public short DMKCGNMOCCH_ValkyrieBattle { get; set; } // LKKNIADKGAE // 0x1E PEBOPIIJCOM NOGOFLKEEMP
	[UMOMember(ReaderMember = "MGJJHHGDOFK")]
	public short EECJONKNHNK_ValkyrieIntro { get; set; } // GEOMFEFKOLF // 0x20 KJKNOCBOHFC DONMAGEIEJF
	[UMOMember(ReaderMember = "FEJADFIALKK")]
	public short MNEFKDDCEHE_ValkyrieIntroSky { get; set; } // EDBCILCIAEL // 0x22 MCDMIOFGCDF KIECJGPAHGO
	[UMOMember(ReaderMember = "FFKLLDKDEFP")]
	public short NJAOOMHCIHL_DivaSolo { get; set; } // GHHLJOCPEAE // 0x24 OJBDKKDLFDD CMMJPNDAJDG
	[UMOMember(ReaderMember = "MIDEDJKGOED")]
	public short PECMGDOMLAF_DivaMulti { get; set; } // ADLPNCIONGK // 0x26 MDIFJJACKBC JKMNGNMPONF
	[UMOMember(ReaderMember = "LKIFDCEKDCK_exp")]
	public short ACPKFNNONMH_Exp { get; set; } // LEDNEEKHDPM // 0x28 IOOMEBAFGFK DPMAFCKJJPM

	// RVA: 0xFBDFFC Offset: 0xFBDFFC VA: 0xFBDFFC
	//public uint CAOGDCBPBAN() { }
}

[UMOClass(ReaderClass = "NLDAADHODFI")]
public class KEODKEGFDLD_FreeMusicInfo
{
	[UMOMember(ReaderMember = "CFJKNAIOEAN_spn")]
	public short[] OCOGIADDNDN_SpNotes = new short[5]; // 0x34
	[UMOMember(ReaderMember = "BKEIOLFMMDH_emy")]
	public short[] LHICAKGHIGF_EnemyIdByDiff = new short[5]; // 0x38
	[UMOMember(ReaderMember = "JGEIIONMJMI_v_in")]
	public int[] HLKHOFPAOMK_SubGoalByDiff = new int[5]; // 0x3C
	[UMOMember(ReaderMember = "CMENIBCJJNF_v_aw")]
	public int[] HLLJIICKNIP_GoalByDiff = new int[5]; // 0x40
	[UMOMember(ReaderMember = "KMFHHOANPFH_v_max")]
	public int[] FENOHOEIJOE_MaxValue = new int[5]; // 0x44 // MaxValueFreeModeByDiff
	[UMOMember(ReaderMember = "EHODALENBEL_d_in")]
	public int[] LJPKLMJPLAC_DIn = new int[5]; // 0x48
	[UMOMember(ReaderMember = "ALJIHHGHCOG_sd_in")]
	public int[] MALHPBKPIDE_SdIn = new int[5]; // 0x4C
	[UMOMember(ReaderMember = "BODBNFFIOJN")]
	public short[] DPJDHKIIJIJ_SpNotesByDiff6Line = new short[5]; // 0x50
	[UMOMember(ReaderMember = "KJLLNPFHEEL")]
	public short[] PJNFOCDANCE_EnemyIdByDiffL6 = new short[5]; // 0x54
	[UMOMember(ReaderMember = "DOAFFAGEHOM")]
	public int[] MAGILDGLOKD_SubGoalFreeModeL6ByDiff = new int[5]; // 0x58
	[UMOMember(ReaderMember = "BIHJCIGKMBA")]
	public int[] JEANDFEBLIG_GoalFreeModeL6ByDiff = new int[5]; // 0x5C
	[UMOMember(ReaderMember = "OOBOCLOFPBF")]
	public int[] KFIDHFOGDPJ_MaxValueFreeModeL6ByDiff = new int[5]; // 0x60
	[UMOMember(ReaderMember = "DKAIOCGKJLO")]
	public int[] ILCJOOPIILK = new int[5]; // 0x64
	[UMOMember(ReaderMember = "OIDAMEGDNOF")]
	public int[] BGILEHEJHHA = new int[5]; // 0x68
	[UMOMember]
	private List<ADDHLABEFKH> COGKJBAFBKN_ByDiff = new List<ADDHLABEFKH>(); // 0x6C
	[UMOMember]
	private List<ADDHLABEFKH> IPFHDCEFLDE_ByDiffLine6 = new List<ADDHLABEFKH>(); // 0x70

	[UMOMember(ReaderMember = "EHDDADDKMFI_f_id")]
	public short GHBPLHBNMBK_FreeMusicId { get; set; } // 0x8 JHHAKBMGFEN HKFCFPFPMBN IFMPBFAAKNN
	[UMOMember(ReaderMember = "KLMIFEKNBLL_m_id")]
	public short DLAEJOBELBH_MusicId { get; set; } // 0xA CKJALIDGGOH MPGNHBOBFBD EPEMOAEGPLI
	[UMOMember(ReaderMember = "DMEDKJPOLCH_cat")]
	public sbyte DEPGBBJMFED_CategoryId { get; set; } // 0xC OGKJCKOPEPM FNMFOBJIIIC OBEDPJLBBEG // Serie
	[UMOMember(ReaderMember = "IJEKNCDIIAE_mver|PLALNIIBLOF_en", Desc = "Availabe in game if value = 2")]
	public sbyte PPEGAKEIEGM_Enabled { get; set; } // 0xD NEKLJCCBECB KPOEEPIMMJP NCIEAFEDPBH
	[UMOMember(ReaderMember = "JJMMJGANPFI")]
	public sbyte ELOGNMFPAHJ { get; set; } // 0xE NGMLLJPEBPB PIICIAMECHP MHEBLIAMCAC
	[UMOMember(ReaderMember = "IJEKNCDIIAE_mver")]
	public int IJEKNCDIIAE_mver { get; set; } // 0x10 FAHNCMHNFCG KJIMMIBDCIL DMEGNOKIKCD
	[UMOMember(ReaderMember = "LHKFKIKEJHN_evnt")]
	public int EKANGPODCEP_EventId { get; set; } // 0x14 MBOEJOMMKCK EBLAFEMDFGD AHEFELNFBDM
	[UMOMember(ReaderMember = "CBBLAMDGOGK_bg")]
	public short KEFGPJBKAOD_BgId { get; set; } // 0x18 CFNDJLELGFP MKJJKNIMMBC NACMHHKKBCJ WavId
	[UMOMember(ReaderMember = "FPOMEEJFBIG_odr")]
	public short EEFLOOBOAGF_ViewOrder { get; set; } // 0x1A BKNCCIILLPJ NLDELFLNODF PEHLMNDKOEE
	[UMOMember(ReaderMember = "GPNOEFHGOJG_dr")]
	private short KCNHKNKNGNH_NormalRateId { get; set; } // 0x1C APIBHBGLOCI BPPHFJDPDJO FGPEKMCHDKK
	[UMOMember(ReaderMember = "ECLGEFGJMAM")]
	private short CNEMDPMKCPA_NormalRateIdLine6 { get; set; } // 0x1E ACECKLDHLHN OBCBGGMIHIG AELNGOGMECL
	[UMOMember(ReaderMember = "PAIIHEJIGKO_ds")]
	public short MGLDIOILOFF_NormalSetId { get; set; } // 0x20 HGCANNFGBJK JCCNFABDFGA LPONDIIPEDN
	[UMOMember(ReaderMember = "NOHIMPJDOCK_rdr1")]
	private short LGNMFFMDIJP_RareRateId { get; set; } // 0x22 PINOBFJAMKP GOELDFINKPG DOPEOGFPFPN
	[UMOMember(ReaderMember = "FABJJODPCIN")]
	private short AOKEOELIAMH_RareRateIdLine6 { get; set; } // 0x24 IEFOAKGGOGB DJMKMADIFCN DBCDHPEOKKD
	[UMOMember(ReaderMember = "DFELEPDHLBF_rds1")]
	public short JCDKMICANJO_RareSetId { get; set; } // 0x26 NONHMBMDBKM ODFMHJFFILL DCDFFHHMHEL
	[UMOMember(ReaderMember = "CAJKBDLCGOD_rdr2")]
	private short EFNKJFCJGBB { get; set; } // 0x28 HHBCGAKHPMG EMEFKAIBMFJ LDCPINNLDDN
	[UMOMember(ReaderMember = "CCHNGBLALEB")]
	private short PNILIOGELFK { get; set; } // 0x2A ODCMCKBNJEL FJHBDENFDAJ DELONBFLKPM
	[UMOMember(ReaderMember = "LHBNIAJDIGA_rds2")]
	public short CCLIOBOGFHC { get; set; } // 0x2C DDDFCKCLGPD JMGOABJPFJO LJMBPNDJCOO
	[UMOMember(ReaderMember = "FCEJJEPFIPH_rwid")]
	public short EAEDODGPLEC_RewardBaseId { get; set; } // 0x2E MJPMALLKMJJ EOGPNADNBFO OGLPGIKKFLK
	[UMOMember(ReaderMember = "PNIFJEENINF")]
	public short LOKLNBLBBFD_Reward6LineBaseId { get; set; } // 0x30 CLFFNMKCEOE IHPAHIEIHMH LNCFBKJDBEK
	[UMOMember(ReaderMember = "EIIOPABMJFJ")]
	public int BLDDNEJDFON_ForcePrismId { get; set; } // 0x74 PHGFINLGEPL JLDOLKKPJMP ADMEDIKMAPD
	[UMOMember(ReaderMember = "HHGPOOBOKHP", Desc = "Value < Master version")]
	public bool BHJNFBDNFEJ { get; set; } // 0x78 NADBEMIAIJA JCELPEBCMAG GCCCGMBALMC
	[UMOMember(ReaderMember = "OHDNJMJCGCJ", Desc = "Value < Master version")]
	public bool GBNOALJPOBM_IsLine6 { get; set; } // 0x79 KNDGBCJKPMC PALLMADFFMA BEDKPPHDHAA

	// // RVA: 0x19F2E68 Offset: 0x19F2E68 VA: 0x19F2E68
	public void LOHABKAHNKD(short IGCLOFPOABH, short ACMOFHKGJLG)
	{
		CNEMDPMKCPA_NormalRateIdLine6 = ACMOFHKGJLG;
		KCNHKNKNGNH_NormalRateId = IGCLOFPOABH;
	}

	// // RVA: 0x19F2E74 Offset: 0x19F2E74 VA: 0x19F2E74
	public void FEOLNFKIIJJ(short IGCLOFPOABH, short ACMOFHKGJLG)
	{
		AOKEOELIAMH_RareRateIdLine6 = ACMOFHKGJLG;
		LGNMFFMDIJP_RareRateId = IGCLOFPOABH;
	}

	// // RVA: 0x19F2E80 Offset: 0x19F2E80 VA: 0x19F2E80
	public void FNFKCHMPLAD(short IGCLOFPOABH, short ACMOFHKGJLG)
	{
		PNILIOGELFK = ACMOFHKGJLG;
		EFNKJFCJGBB = IGCLOFPOABH;
	}

	// // RVA: 0x19F2E8C Offset: 0x19F2E8C VA: 0x19F2E8C
	public short KDIKCKEEPDA_GetNormalRateId(bool _GIKLNODJKFK_IsLine6)
	{
		return _GIKLNODJKFK_IsLine6 ? CNEMDPMKCPA_NormalRateIdLine6 : KCNHKNKNGNH_NormalRateId;
	}

	// // RVA: 0x19F2EA0 Offset: 0x19F2EA0 VA: 0x19F2EA0
	public short ONLFLGPMAAN_GetRareRateId(bool _GIKLNODJKFK_IsLine6)
	{
		return _GIKLNODJKFK_IsLine6 ? AOKEOELIAMH_RareRateIdLine6 : LGNMFFMDIJP_RareRateId;
	}

	// // RVA: 0x19F2EB4 Offset: 0x19F2EB4 VA: 0x19F2EB4
	public short NCCFJCDMBFO(bool _GIKLNODJKFK_IsLine6)
	{
		return _GIKLNODJKFK_IsLine6 ? PNILIOGELFK : EFNKJFCJGBB;
	}

	// // RVA: 0x19F2EC8 Offset: 0x19F2EC8 VA: 0x19F2EC8
	// public uint CAOGDCBPBAN() { }

	// // RVA: 0x19F31FC Offset: 0x19F31FC VA: 0x19F31FC
	public void NHKABAGJCDM(ADDHLABEFKH _ANAJIAENLNB_lv)
	{
		COGKJBAFBKN_ByDiff.Add(_ANAJIAENLNB_lv);
	}

	// // RVA: 0x19F327C Offset: 0x19F327C VA: 0x19F327C
	public void IFABJEBEKPB(ADDHLABEFKH _ANAJIAENLNB_lv)
	{
		IPFHDCEFLDE_ByDiffLine6.Add(_ANAJIAENLNB_lv);
	}

	// // RVA: 0x19F32FC Offset: 0x19F32FC VA: 0x19F32FC
	public ADDHLABEFKH EMJCHPDJHEI(bool _GIKLNODJKFK_IsLine6, int _AKNELONELJK_difficulty)
	{
		if (IPFHDCEFLDE_ByDiffLine6.Count < 1 || !_GIKLNODJKFK_IsLine6)
		{
			if(_AKNELONELJK_difficulty >= COGKJBAFBKN_ByDiff.Count)
				UnityEngine.Debug.LogError("diffculty error : "+_AKNELONELJK_difficulty+" "+COGKJBAFBKN_ByDiff.Count);
			return COGKJBAFBKN_ByDiff[_AKNELONELJK_difficulty];
		}
		return IPFHDCEFLDE_ByDiffLine6[_AKNELONELJK_difficulty];
	}

}

[UMOClass(ReaderClass = "FBAFBKNKENO")]
public class DJNPIGEFPMF_StoryMusicInfo
{
	[UMOMember(ReaderMember = "CFJKNAIOEAN_spn")]
	public short[] OCOGIADDNDN_SpNotes = new short[3]; // 0x24
	[UMOMember(ReaderMember = "BKEIOLFMMDH_emy")]
	public short[] LHICAKGHIGF_EnemyIdByDiff = new short[3]; // 0x28
	[UMOMember(ReaderMember = "JGEIIONMJMI_v_in")]
	public int[] HLKHOFPAOMK_SubGoalByDiff = new int[3]; // 0x2C
	[UMOMember(ReaderMember = "CMENIBCJJNF_v_aw")]
	public int[] HLLJIICKNIP_GoalByDiff = new int[3]; // 0x30
	[UMOMember(ReaderMember = "KMFHHOANPFH_v_max")]
	public int[] FENOHOEIJOE_MaxValue = new int[3]; // 0x34 // MaxValueByDiff
	[UMOMember(ReaderMember = "EHODALENBEL_d_in")]
	public int[] LJPKLMJPLAC_DIn = new int[3]; // 0x38
	[UMOMember(ReaderMember = "ALJIHHGHCOG_sd_in")]
	public int[] MALHPBKPIDE_SdIn = new int[3]; // 0x3C
	[UMOMember()]
	public List<ADDHLABEFKH> COGKJBAFBKN_ByDiff = new List<ADDHLABEFKH>(); // 0x40
	[UMOMember(ReaderMember = "PLALNIIBLOF_en", Desc = "Availabe in game if value = 2")]
	public byte PPEGAKEIEGM_Enabled; // 0x44

	[UMOMember(ReaderMember = "BDJMFDKLHPM_s_id")]
	public short KLCIIHKFPPO_StoryMusicId { get; set; }  // 0x8 GBNPEKLEHPH CPDGCNILCII IILKMGEKOBG
	[UMOMember(ReaderMember = "KLMIFEKNBLL_m_id")]
	public int DLAEJOBELBH_MusicId { get; set; }  // 0xC CKJALIDGGOH MPGNHBOBFBD EPEMOAEGPLI
	[UMOMember(ReaderMember = "DMEDKJPOLCH_cat")]
	public int DEPGBBJMFED_CategoryId { get; set; } // 0x10 OGKJCKOPEPM FNMFOBJIIIC OBEDPJLBBEG
	[UMOMember(ReaderMember = "NHBLDIPBHNF_pg")]
	public int MHPAFEEPBNJ { get; set; } // 0x14 OHACHFCDBOF NODKIDEKNGJ CHFBEINBPKA
	[UMOMember(ReaderMember = "CBBLAMDGOGK_bg")]
	public int KEFGPJBKAOD_BgId { get; set; } // 0x18 CFNDJLELGFP MKJJKNIMMBC NACMHHKKBCJ WavId
	[UMOMember(ReaderMember = "GPNOEFHGOJG_dr")]
	public int KCNHKNKNGNH_NormalRateId { get; set; } // 0x1C APIBHBGLOCI BPPHFJDPDJO FGPEKMCHDKK
	[UMOMember(ReaderMember = "PAIIHEJIGKO_ds")]
	public int MGLDIOILOFF_NormalSetId { get; set; } // 0x20 HGCANNFGBJK JCCNFABDFGA LPONDIIPEDN

	// // RVA: 0x198D598 Offset: 0x198D598 VA: 0x198D598
	// public uint CAOGDCBPBAN() { }
}


[UMOClass(ReaderClass = "INDENDCNNHJ")]
public class HMJHLLPBCLD : IComparable<HMJHLLPBCLD>
{
	[UMOMember(ReaderMember = "LJNAKDMILMC_key")]
	public int LJNAKDMILMC_key { get; set; } // 0x8 KNJIHALCKLN LIIHHICIBKM OACJGKPBHIK
	// public int ANAJIAENLNB_lv { get; } 0x15F6920 MMOMNMBKHJF
	// public int AHHJLDLAPAN_DivaId { get; } 0x15F6944 IPKDLMIDMHH
	// public int DLAEJOBELBH_MusicId { get; } 0x15F6974 MPGNHBOBFBD
	[UMOMember(ReaderMember = "JBKMAPLCBMO_arg/0")]
	public short LHBDCGFOKCA_DivaId { get; set; } // 0xC HHBMOFEAFKC OLHHGEIKLDM DOOHFPHPMPF
	[UMOMember(ReaderMember = "JBKMAPLCBMO_arg/1")]
	public short CEFHDLLAPDH_MusicId { get; set; } // 0xE BDIBNPFLIED BKFIIGCINNL BNJMJMNLMEA
	// public short CIIIELDHDEP { get; set; } 0x15F69B0 NAMNBEJFNFN 0x15F69D0 BGOEGAOOHIE
	// public short LDCJDIAOKGD { get; set; } 0x15F69E0 DBJGHGEJOAH 0x15F69E8 HEDOJDJALID
	[UMOMember(ReaderMember = "JBKMAPLCBMO_arg/2")]
	public short KDGIHMCBLND_MusicLevel { get; set; } // 0x10 CDLBEODBHLK GLDGPMFEKGM BJIBDJAOFJJ

	// // RVA: 0x15F68F8 Offset: 0x15F68F8 VA: 0x15F68F8
	public static int ABDFBABHIHJ_GetId(int DLAEJOBELBH_MusicId, int AHHJLDLAPAN_DivaId, int _BAKLKJLPLOJ_MusicLevel)
	{
		return AHHJLDLAPAN_DivaId * 100 + DLAEJOBELBH_MusicId * 10000 + _BAKLKJLPLOJ_MusicLevel;
	}

	// // RVA: 0x15F69F0 Offset: 0x15F69F0 VA: 0x15F69F0
	public HMJHLLPBCLD(int _LJNAKDMILMC_key)
	{
		this.LJNAKDMILMC_key = _LJNAKDMILMC_key;
	}

	// // RVA: 0x15F6A10 Offset: 0x15F6A10 VA: 0x15F6A10 Slot: 4
	public int CompareTo(HMJHLLPBCLD EAIPIMCBNJN)
	{
		if (EAIPIMCBNJN == null)
			return 1;
		return LJNAKDMILMC_key.CompareTo(EAIPIMCBNJN.LJNAKDMILMC_key);
	}

	// // RVA: 0x15F6A54 Offset: 0x15F6A54 VA: 0x15F6A54
	// public uint CAOGDCBPBAN() { }
}

[UMOClass(ReaderClass = "NJBDNGAPLLI")]
public class JPCKBFBCJKD
{
	[UMOMember(ReaderMember = "EHDDADDKMFI_f_id")]
	public int GHBPLHBNMBK_FreeMusicId { get; set; } // 0x8 JHHAKBMGFEN HKFCFPFPMBN IFMPBFAAKNN
	[UMOMember(ReaderMember = "NKAKDIEKAGL_open_pl_rank")]
	public int ADBHJCDINFL_OpenPlRank { get; set; }  // 0xC PLIPNHDDIFP NKIPIGNMFGK NNPOJPDCEHE

	// // RVA: 0x1BA5440 Offset: 0x1BA5440 VA: 0x1BA5440
	// public uint CAOGDCBPBAN() { }
}

[UMOClass(ReaderClass = "EODMBJMOHBC")]
public class NONFIGBOJLN
{
	[UMOMember(ReaderMember = "LBMELIONKKB_thid")]
	public int PDGEMDFHFIB_ThId; // 0x8
	[UMOMember(ReaderMember = "JBGEEPFKIGG_val")]
	public List<int> MNKDEFJFKGN_Val; // 0xC
}

public class AJIKMKFGNCJ
{
	// public short JOMGCCBFKEF_MissionId { get; set; } // 0x8 JIHJGFNPPIL GGFGMDFOFLG JCJBHJOOIDP
	// public byte INDDJNMPONH_type { get; set; } // 0xA JDIGGEBNOPK GHAILOLPHPF BACGOKIGMBC
	// public byte AHHJLDLAPAN_DivaId { get; set; } // 0xB AMALMGIALDF IPKDLMIDMHH IENNENMKEFO
	// public int JBGEEPFKIGG_val { get; set; } // 0xC AHPLCJAKAOP OLOCMINKGON ABAFHIBFKCE
}

[System.Obsolete("Use AIPEHINPIHC_ForcedSettingInfo", true)]
public class AIPEHINPIHC { }
[UMOClass(ReaderClass = "OIPFPLPMCMF")]
public class AIPEHINPIHC_ForcedSettingInfo
{
	[UMOMember(ReaderMember = "EIIOPABMJFJ")]
	public int NMNDNFFJHPJ_Id; // 0x8
	[UMOMember(ReaderMember = "FODKKJIDDKN_vf_Id")]
	public int GPPEFLKGGGJ_ValkyrieId; // 0xC
	[UMOMember(ReaderMember = "DIPKCALNIII_diva_id")]
	public int[] AHHJLDLAPAN_DivaId = new int[3]; // 0x10
	[UMOMember(ReaderMember = "BEEAIAAJOHD_CostumeId")]
	public int[] JPIDIENBGKH_CostumeId = new int[3]; // 0x14
	[UMOMember(ReaderMember = "NBMPGOJBPMD")]
	public int IOPCBBNHJIP_ForcedMusicId; // 0x18
	[UMOMember(ReaderMember = "OOFEIPCLEKJ_DivaVoice")]
	public int OOFEIPCLEKJ_DivaVoice; // 0x1C
	[UMOMember(ReaderMember = "EDDLJBLJJOE_PilotVoice")]
	public int EDDLJBLJJOE_PilotVoice; // 0x20
	[UMOMember(ReaderMember = "JIIOKINLOGM_NoteType")]
	public int JIIOKINLOGM_NoteType; // 0x24
	[UMOMember(ReaderMember = "MDKNFOIMCJB_NoteSe")]
	public int MDKNFOIMCJB_NoteSe; // 0x28
	[UMOMember(ReaderMember = "OENPCNBFPDA_bg_id")]
	public int OENPCNBFPDA_bg_id; // 0x2C
	[UMOMember(ReaderMember = "EGMIILFFHMI_DivaMode")]
	public int EGMIILFFHMI_DivaMode; // 0x30
	[UMOMember(ReaderMember = "HFMFGFHPBNB_ValkyrieMode")]
	public int HFMFGFHPBNB_ValkyrieMode; // 0x34
	[UMOMember(ReaderMember = "ENAAKPKFBGN_EffectCutIn")]
	public int ENAAKPKFBGN_EffectCutIn; // 0x38
	[UMOMember(ReaderMember = "IHLDBMMOCHF_ForceSLiveResultSerifWindow")]
	public int IHLDBMMOCHF_ForceSLiveResultSerifWindow; // 0x3C
}

[UMOClass(ReaderClass = "MDCGKDDENNG")]
public class AOJCMPIBFHD
{
	[UMOMember(ReaderMember = "IJEKNCDIIAE_mver")]
	public int IJEKNCDIIAE_mver; // 0x8
	[UMOMember(ReaderMember = "IJEKNCDIIAE_mver|PLALNIIBLOF_en", Desc = "Availabe in game if value = 2")]
	public int PLALNIIBLOF_en; // 0xC
	[UMOMember(ReaderMember = "KLMIFEKNBLL_m_id")]
	public int DLAEJOBELBH_MusicId; // 0x10
	[UMOMember(ReaderMember = "DIPKCALNIII_diva_id")]
	public int[] AHHJLDLAPAN_DivaId = new int[5]; // 0x14
	[UMOMember(ReaderMember = "ELDPFJIDNAB")]
	public int OFGIOBGAJPA_NumDiva; // 0x18
	[UMOMember(ReaderMember = "NDIJPKPDOMG")]
	public int OEJOOMPKAOO; // 0x1C
}

[System.Obsolete("Use HDNKOFNBCEO_RewardInfo", true)]
public class HDNKOFNBCEO { }
[UMOClass(ReaderClass = "KEBPMGGPLIF")]
public class HDNKOFNBCEO_RewardInfo
{
	public const int JIEBOLHLFOC = 0;
	public const int GJPKDHHKPPE = 4;
	public const int AKADJOKMIEN = 8;
	public const int HGFDJJPJNNG = 12;
	[UMOMember(ReaderMember = "FCEJJEPFIPH_rwid")]
	public int EIHOBHDKCDB_RewardId; // 0x8
	[UMOMember(ReaderMember = "AIHOJKFNEEN_itm")]
	public List<int> LLEILBEMEEJ_Itm; // 0xC

	// // RVA: 0x1742A5C Offset: 0x1742A5C VA: 0x1742A5C
	public int FKNBLDPIPMC_GetItemCode(int _OIPCCBHIKIA_index)
	{
		return LLEILBEMEEJ_Itm[_OIPCCBHIKIA_index * 3];
	}

	// // RVA: 0x1742ADC Offset: 0x1742ADC VA: 0x1742ADC
	public int KAINPNMMAEK_GetItemCount(int _OIPCCBHIKIA_index)
	{
		return LLEILBEMEEJ_Itm[_OIPCCBHIKIA_index * 3 + 1];
	}

	// // RVA: 0x1742B60 Offset: 0x1742B60 VA: 0x1742B60
	public int GPBKAAMLIBF(int _OIPCCBHIKIA_index)
	{
		return LLEILBEMEEJ_Itm[_OIPCCBHIKIA_index * 3 + 2];
	}

	// // RVA: 0x1742BE4 Offset: 0x1742BE4 VA: 0x1742BE4
	public int MEBHFJPMCIF(int _HMFFHLPNMPH_count)
	{
		int res = -1;
		for(int i = 0; i < 4; i++)
		{
			res = i - 1;
			if (_HMFFHLPNMPH_count < GPBKAAMLIBF(i))
				return i;
		}
		return res + 2;
	}

	// // RVA: 0x1742C2C Offset: 0x1742C2C VA: 0x1742C2C
	// public uint CAOGDCBPBAN() { }
}

[UMOClass]
public class ADDHLABEFKH
{
	// Fields
	[UMOMember]
	public int DJEEFNHADDJ; // 0x8
	[UMOMember]
	public List<int> KNIFCANOHOC_score = new List<int>(); // 0xC RankScore
	[UMOMember]
	public List<int> NLKEBAOBJCM_combo = new List<int>(); // 0x10

	//// RVA: 0x15B9E74 Offset: 0x15B9E74 VA: 0x15B9E74
	public int DLPBHJALHCK_GetScoreRank(int _JBGEEPFKIGG_val)
	{
		for(int i = 0; i < KNIFCANOHOC_score.Count; i++)
		{
			if (KNIFCANOHOC_score[i] > _JBGEEPFKIGG_val)
				return i;
		}
		//return KNIFCANOHOC_score.Count;
		return KNIFCANOHOC_score.Count - 1; // UMO fix for very high score
	}

	//// RVA: 0x15B9F40 Offset: 0x15B9F40 VA: 0x15B9F40
	public int CCFAAPPKILD_GetRankCombo(int _JBGEEPFKIGG_val)
	{
		for (int i = 0; i < NLKEBAOBJCM_combo.Count; i++)
		{
			if (NLKEBAOBJCM_combo[i] > _JBGEEPFKIGG_val)
				return i;
		}
		return NLKEBAOBJCM_combo.Count;
	}

	//// RVA: 0x15BA00C Offset: 0x15BA00C VA: 0x15BA00C
	//public uint CAOGDCBPBAN() { }
}
