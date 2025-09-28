
using System.Collections;
using System.Collections.Generic;
using System.Text;
using XeSys;

[System.Obsolete("Use CHHECNJBMLA_EventBoxGacha", true)]
public class CHHECNJBMLA { }
public class CHHECNJBMLA_EventBoxGacha : IKDICBBFBMI_EventBase
{
	public class MDBEKHIHBJM
	{
		public int IHLEPGEJNPM_Idx; // 0x8
		public int JBDBPCMMBIH_Id; // 0xC
		public int GLCLFMGPMAN_ItemId; // 0x10
		public int HMFFHLPNMPH_count; // 0x14
		public int AGKANHNHECE_Remain; // 0x18
		public int GCEANEOEGMD_Num; // 0x1C
		public bool AEDMJLGNDHN_IsSp; // 0x20
	}

	public class FMAHFJGBHMG
	{
		public int PPFNGGCBJKC_id; // 0x8
		public int JNGNONNJLBM; // 0xC
		public int KIJAPOFAGPN_ItemId; // 0x10
		public int HMFFHLPNMPH_count; // 0x14
		public bool AEDMJLGNDHN_IsSp; // 0x18
		public int CONGLCLANMP_Remain; // 0x1C
		public int FPFKNDKENIC; // 0x20
	}

	public class PCCHKHKKLPM
	{
		public int OIPCCBHIKIA_index; // 0x8
		public int MKNDAOHGOAK_weight; // 0xC
		public int FCDKJAKLGMB_TargetValue; // 0x10
	}

	private const int GHJHJDIDCFA = 3;
	private EECOJKDJIFG KBACNOCOANM_Ranking; // 0xE8
	public List<KDLFECOOANO> HNDKCBHOJEH = new List<KDLFECOOANO>(50); // 0xEC
	public bool EGOJLOEFMOH_IsUpdateLimitedMusic; // 0xF0
	public int BCBCODAKIDN_DescType; // 0xF4
	public bool KDDBNAIJKAD_ResetDisable; // 0xF8
	public bool KIBBLLADDPO; // 0xF9
	public bool AAODGCEBJCG; // 0xFA
	public List<MDBEKHIHBJM> JMLKAGOACAE = new List<MDBEKHIHBJM>(); // 0xFC
	public List<MDBEKHIHBJM> CKFCGDIJKKC = new List<MDBEKHIHBJM>(); // 0x100
	public List<FMAHFJGBHMG> PNLJHCDHKCP_LotResult = new List<FMAHFJGBHMG>(); // 0x104
	public new JKNGJFOBADP JANMJPOKLFL_InventoryUtil = new JKNGJFOBADP(); // 0x108
	private uint PMBEODGMMBB_y = 0x15ab17a1; // 0x10C
	private StringBuilder OGNKHBFKHIP; // 0x110

	public override OHCAABOMEOF.KGOGMKMBCPP_EventType HIDHLFCBIDE_EventType { get { return OHCAABOMEOF.KGOGMKMBCPP_EventType.OCCGDMDBCHK_8_EventGacha; } } //0x12BF064 DKHCGLCNKCD  Slot: 4

	// // RVA: 0x12BF06C Offset: 0x12BF06C VA: 0x12BF06C Slot: 32
	public override EECOJKDJIFG DAKMIKNKHMF_GetRankingInfoForIndex(int LHJCOPMMIGO/* = 0*/)
	{
		return KBACNOCOANM_Ranking;
	}

	// RVA: 0x12BF074 Offset: 0x12BF074 VA: 0x12BF074
	public CHHECNJBMLA_EventBoxGacha(string _OPFGFINHFCE_name) : base(_OPFGFINHFCE_name)
    {
        return;
    }

	// // RVA: 0x12BF1E8 Offset: 0x12BF1E8 VA: 0x12BF1E8 Slot: 5
	public override string IFKKBHPMALH()
	{
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
			return evDb.NGHKJOEDLIP_Settings.OCDMGOGMHGE_KeyPrefix;
		}
		return null;
	}

	// // RVA: 0x12BF370 Offset: 0x12BF370 VA: 0x12BF370 Slot: 27
	public override int HLOGNJNGDJO_GetHelpId(int _OIPCCBHIKIA_index/* = 0*/)
	{
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
			return evDb.NGHKJOEDLIP_Settings.EJBGHLOOLBC_HelpIds[_OIPCCBHIKIA_index];
		}
		return 0;
	}

	// // RVA: 0x12BF52C Offset: 0x12BF52C VA: 0x12BF52C Slot: 28
	public override long FBGDBGKNKOD_GetCurrentPoint()
	{
		return 0;
	}

	// // RVA: 0x12BF538 Offset: 0x12BF538 VA: 0x12BF538 Slot: 29
	public override void MJFKJHJJLMN_GetRanks(int LHJCOPMMIGO/* = 0*/, bool _FBBNPFFEJBN_Force/* = false*/)
	{
		PLOOEECNHFB_IsDone = true;
	}

	// // RVA: 0x12BF544 Offset: 0x12BF544 VA: 0x12BF544 Slot: 30
	protected override bool JIHMLILFOPG_IsEventActive(long _JHNMKKNEENE_Time)
	{
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
			GDIPLANPCEI g = IMMAOANGPNK.HHCJCDFCLOB.ACEFBFLFKFD_GetScheduleEventData(evDb.JIKKNHIAEKG_BlockName, _JHNMKKNEENE_Time);
			if(g != null)
			{
				if(evDb.NGHKJOEDLIP_Settings.GMFNMNOIJHI < 1)
				{
					if(_JHNMKKNEENE_Time < evDb.NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart)
						return false;
					if(evDb.NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2 < _JHNMKKNEENE_Time)
						return false;
				}
				else
				{
					if(_JHNMKKNEENE_Time < evDb.NGHKJOEDLIP_Settings.OHGDNJLFDFF_Start)
						return false;
					if(evDb.NGHKJOEDLIP_Settings.PHKLJGNMFBL_End < _JHNMKKNEENE_Time)
						return false;
				}
				if(evDb.NGHKJOEDLIP_Settings.HKKNEAGCIEB_RankingSupport != 0)
				{
					if(KKLGENJKEBN.HHCJCDFCLOB.JPDPFGFMKHK_rankings.Find((EECOJKDJIFG PKLPKMLGFGK) =>
					{
						//0x12C67E8
						return evDb.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api == PKLPKMLGFGK.OCGFKMHNEOF_name_for_api;
					}) == null)
					{
						UnityEngine.Debug.LogError("Ranking Not found : "+evDb.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api);
						return false;
					}
				}
				return true;
			}
		}
		return false;
	}

	// // RVA: 0x12BF8A8 Offset: 0x12BF8A8 VA: 0x12BF8A8 Slot: 31
	protected override bool IMCMNOPNGHO(long _JHNMKKNEENE_Time)
	{
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
			ALIPBIMCAPN_EventBoxGacha.GLNFOMDKJJH save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MMAIJOCPJHP_EventBoxGacha.FBCJICEPLED[evDb.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			AGLILDLEFDK_Missions = null;
			OLDFFDMPEBM_Quests = null;
			NCEJOLLKDDF_InitRandList();
			long t = evDb.NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
			if(evDb.NGHKJOEDLIP_Settings.GMFNMNOIJHI > 0)
				t = evDb.NGHKJOEDLIP_Settings.OHGDNJLFDFF_Start;
			if((!RuntimeSettings.CurrentSettings.UnlimitedEvent && save.EGBOHDFBAPB_closed_at < t) || save.EGBOHDFBAPB_closed_at == 0)
			{
				save.LHPDDGIJKNB_Reset(false);
				save.EGBOHDFBAPB_closed_at = evDb.NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd;
				IDLMBIEAPIL(1);
			}
			return true;
		}
		return false;
	}

	// // RVA: 0x12C01A0 Offset: 0x12C01A0 VA: 0x12C01A0 Slot: 40
	protected override void KKFLDCBHFJA(long _JHNMKKNEENE_Time)
	{
		IMDBGDNPLJA_EventBoxGacha NENJCIMMEBC = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as IMDBGDNPLJA_EventBoxGacha;
		if(NENJCIMMEBC != null)
		{
			IBNKPMPFLGI_IsRankReward = NENJCIMMEBC.NGHKJOEDLIP_Settings.HKKNEAGCIEB_RankingSupport != 0;
			if(IBNKPMPFLGI_IsRankReward)
			{
				KBACNOCOANM_Ranking = KKLGENJKEBN.HHCJCDFCLOB.JPDPFGFMKHK_rankings.Find((EECOJKDJIFG PKLPKMLGFGK) =>
				{
					//0x12C6848
					return NENJCIMMEBC.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api == PKLPKMLGFGK.OCGFKMHNEOF_name_for_api;
				});
				GPHEKCNDDIK = true;
			}
			DGCOMDILAKM_EventName = NENJCIMMEBC.NGHKJOEDLIP_Settings.OPFGFINHFCE_name;
			DOLJEDAAKNN_RankingName = NENJCIMMEBC.NGHKJOEDLIP_Settings.HEDAGCNPHGD_RankingName;
			GLIMIGNNGGB_RankingStart = NENJCIMMEBC.NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
			DPJCPDKALGI_RankingEnd = NENJCIMMEBC.NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;
			LOLAANGCGDO_RankingEnd2 = NENJCIMMEBC.NGHKJOEDLIP_Settings.LNFKGHNHJKE_RankingEnd2;
			JDDFILGNGFH_RewardStart = NENJCIMMEBC.NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart;
			LJOHLEGGGMC_RewardEnd = NENJCIMMEBC.NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd;
			EMEKFFHCHMH_RewardEnd2 = NENJCIMMEBC.NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2;
			PGIIDPEGGPI_EventId = NENJCIMMEBC.NGHKJOEDLIP_Settings.OBGBAOLONDD_UniqueId;
			PBHNFNIHDJJ = NENJCIMMEBC.NGHKJOEDLIP_Settings.HFNIHKOAMGC;
			NHGPCLGPEHH_TicketType = NENJCIMMEBC.NGHKJOEDLIP_Settings.MJBKGOJBPAD_item_type;
			FBHONHONKGD_MusicSelectDesc = NENJCIMMEBC.NGHKJOEDLIP_Settings.FEMMDNIELFC_Desc;
			GFIBLLLHMPD_StartAdventureId = NENJCIMMEBC.NGHKJOEDLIP_Settings.HIOOGLEJBKM_StartAdventureId;
			CAKEOPLJDAF_EndAdventureId = NENJCIMMEBC.NGHKJOEDLIP_Settings.FJCADCDNPMP_EndAdventureId;
			LEPALMDKEOK_IsPointReward = true;
			AAODGCEBJCG = NENJCIMMEBC.NGHKJOEDLIP_Settings.GMFNMNOIJHI > 0 || RuntimeSettings.CurrentSettings.UnlimitedEvent;
			for(int i = 0; i < KPOMHFLKMKI_LastRankUpdateTime.Length; i++)
			{
				KPOMHFLKMKI_LastRankUpdateTime[i] = 0;
			}
			if(!string.IsNullOrEmpty(NENJCIMMEBC.NGHKJOEDLIP_Settings.OMCAOJJGOGG_Lb))
			{
				string[] strs = NENJCIMMEBC.NGHKJOEDLIP_Settings.OMCAOJJGOGG_Lb.Split(new char[]{','});
				MFDJIFIIPJD m = new MFDJIFIIPJD();
				m.KHEKNNFCAOI_Init(int.Parse(strs[0]), int.Parse(strs[1]));
				BHABCGJCGNO = m;
			}
			PIMFJALCIGK(EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene);
			GPHEKCNDDIK = true;
		}
	}

	// // RVA: 0x12C07B4 Offset: 0x12C07B4 VA: 0x12C07B4
	private void PIMFJALCIGK(EKLNMHFCAOI.FKGCBLHOOCL_Category _INDDJNMPONH_type/* = EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene*/)
	{
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
			HNDKCBHOJEH.Clear();
			Dictionary<int,int> d = new Dictionary<int, int>();
			d.Clear();
			for(int i = 0; i < evDb.PKPLOGBIDIG_Prizes.Count; i++)
			{
				if(evDb.PKPLOGBIDIG_Prizes[i].PLALNIIBLOF_en == 2)
				{
					if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(evDb.PKPLOGBIDIG_Prizes[i].GLCLFMGPMAN_ItemId) == _INDDJNMPONH_type)
					{
						int rId = evDb.PKPLOGBIDIG_Prizes[i].IMMDGJAOPCD_BoxId * 10000 + EKLNMHFCAOI.DEACAHNLMNI_getItemId(evDb.PKPLOGBIDIG_Prizes[i].GLCLFMGPMAN_ItemId);
						if(!d.ContainsKey(rId))
						{
							d.Add(rId, 0);
						}
						d[rId] += evDb.PKPLOGBIDIG_Prizes[i].ADPPAIPFHML_num * evDb.PKPLOGBIDIG_Prizes[i].JBGEEPFKIGG_val;
					}
				}
			}
			foreach(var it in d)
			{
				int k = it.Key / 10000;
				IMDBGDNPLJA_EventBoxGacha.NEFJBPECLKJ m = evDb.KGDBEMPMAIJ_Boxes.Find((IMDBGDNPLJA_EventBoxGacha.NEFJBPECLKJ JPAEDJJFFOI) =>
				{
					//0x12C68A8
					return JPAEDJJFFOI.PPFNGGCBJKC_id == k;
				});
				string s = JpStringLiterals.StringLiteral_9765;
				if(m != null)
					s = m.OPFGFINHFCE_name;
				KDLFECOOANO k_ = new KDLFECOOANO();
				k_.GLCLFMGPMAN_ItemId = it.Key % 10000;
				k_.IMMDGJAOPCD_BoxId = k;
				k_.MPEKFDKEKCG = s;
				k_.CLLKANEGGBJ_ItemCount = it.Value;
				HNDKCBHOJEH.Add(k_);
			}
		}
	}

	// // RVA: 0x12C0F84 Offset: 0x12C0F84 VA: 0x12C0F84 Slot: 46
	protected override void PJDGDNJNCNM_UpdateStatusImpl(long _JHNMKKNEENE_Time)
	{
		NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.HJNNKCMLGFL_0_None;
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
			KIBBLLADDPO = false;
			ALIPBIMCAPN_EventBoxGacha.GLNFOMDKJJH save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MMAIJOCPJHP_EventBoxGacha.FBCJICEPLED[evDb.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			IBLPKJJNNIG = false;
			BELBNINIOIE = false;
			long s = evDb.NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
			if(evDb.NGHKJOEDLIP_Settings.GMFNMNOIJHI > 0)
				s = evDb.NGHKJOEDLIP_Settings.OHGDNJLFDFF_Start;
			NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.FFLKPBPBPEP_1;
			if(_JHNMKKNEENE_Time >= s)
			{
				if(DPJCPDKALGI_RankingEnd >= _JHNMKKNEENE_Time)
				{
					if(MBHDIJJEOFL != null)
					{
						for(int i = 0; i < MBHDIJJEOFL.Count; i++)
						{
							if(MBHDIJJEOFL[i].MAFAIIHJAFG_spurt == 0)
							{
								IBLPKJJNNIG = true;
								break;
							}
						}
					}
					//LAB_012c12c0
					if(!save.IMFBCJOIJKJ_Entry)
					{
						NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2;
					}
					else
					{
						NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_ChallengePeriod_5;
						if(MBHDIJJEOFL != null)
						{
							for(int i = 0; i < MBHDIJJEOFL.Count; i++)
							{
								if(MBHDIJJEOFL[i].MAFAIIHJAFG_spurt == 1)
								{
									BELBNINIOIE = true;
									break;
								}
							}
						}
					}
				}
				else
				{
					NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_6_Counting;
					if(_JHNMKKNEENE_Time >= evDb.NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart)
					{
						NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived;
						if(_JHNMKKNEENE_Time >= evDb.NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd)
						{
							NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.DOAENCHBAEO_11;
							if(_JHNMKKNEENE_Time < evDb.NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2)
							{
								NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.HINPDNKNAHO_10;
							}
						}
					}
				}
			}
		}
		else
		{
			KIBBLLADDPO = false;
		}
	}

	// // RVA: 0x12C13E4 Offset: 0x12C13E4 VA: 0x12C13E4 Slot: 47
	public override void NBMDAOFPKGK(int _DNBFMLBNAEE_point)
	{
		return;
	}

	// // RVA: 0x12C13E8 Offset: 0x12C13E8 VA: 0x12C13E8 Slot: 49
	protected override void ODPJGHOJIOH(int LHJCOPMMIGO)
	{
		if(KBACNOCOANM_Ranking != null)
		{
			IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as IMDBGDNPLJA_EventBoxGacha;
			if(evDb != null)
			{
				PJDGDNJNCNM_UpdateStatusImpl(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime());
			}
			else
				return;
		}
		PLOOEECNHFB_IsDone = true;
	}

	// // RVA: 0x12C16D8 Offset: 0x12C16D8 VA: 0x12C16D8 Slot: 50
	protected override void MFJFBNPLFBE_OnReceieveTotalReward(bool GIPBIDFJFLL)
	{
		return;
	}

	// // RVA: 0x12C16DC Offset: 0x12C16DC VA: 0x12C16DC Slot: 52
	public override void FAMFKPBPIAA_GetRankingPlayerList(bool PFFJNEFNAMI, int _CJHEHIMLGGL_Position, int LHJCOPMMIGO, LIOLBKLMMIK _KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK _IDAEHNGOKAE_OnRankingError, DJBHIFLHJLK _JGKOLBLPMPG_OnFail)
	{
		NPNNPNAIONN_IsError = false;
		PLOOEECNHFB_IsDone = false;
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
			if(IBNKPMPFLGI_IsRankReward)
			{
				KKLGENJKEBN.HHCJCDFCLOB.FAMFKPBPIAA_GetRankingPlayerList(KBACNOCOANM_Ranking.OCGFKMHNEOF_name_for_api, PFFJNEFNAMI, _CJHEHIMLGGL_Position, LHJCOPMMIGO, (int NEFEFHBHFFF, List<IBIGBMDANNM> MAGKKPOFJIM) =>
				{
					//0x12C68E0
					PLOOEECNHFB_IsDone = true;
					_KLMFJJCNBIP_OnSuccess(NEFEFHBHFFF, MAGKKPOFJIM);
				}, () =>
				{
					//0x12C693C
					PLOOEECNHFB_IsDone = true;
					_IDAEHNGOKAE_OnRankingError();
				}, () =>
				{
					//0x12C6988
					PLOOEECNHFB_IsDone = true;
					NPNNPNAIONN_IsError = true;
					_JGKOLBLPMPG_OnFail();
				}, false);
				return;
			}
		}
		_IDAEHNGOKAE_OnRankingError();
		PLOOEECNHFB_IsDone = true;
	}

	// // RVA: 0x12C1A14 Offset: 0x12C1A14 VA: 0x12C1A14 Slot: 53
	public override void JPNACOLKHLB_AddRankingPlayerListSecond(int _CJHEHIMLGGL_Position, int NEFEFHBHFFF, LIOLBKLMMIK _KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK _IDAEHNGOKAE_OnRankingError, DJBHIFLHJLK _JGKOLBLPMPG_OnFail)
	{
		if(!IBNKPMPFLGI_IsRankReward)
		{
			_IDAEHNGOKAE_OnRankingError();
			PLOOEECNHFB_IsDone = true;
		}
		else
		{
			KKLGENJKEBN.HHCJCDFCLOB.JPNACOLKHLB_AddRankingPlayerListSecond(_CJHEHIMLGGL_Position, NEFEFHBHFFF, (int _JGNBPFCJLKI_d, List<IBIGBMDANNM> MAGKKPOFJIM) =>
			{
				//0x12C69EC
				PLOOEECNHFB_IsDone = true;
				_KLMFJJCNBIP_OnSuccess(_JGNBPFCJLKI_d, MAGKKPOFJIM);
			}, () =>
			{
				//0x12C6A48
				PLOOEECNHFB_IsDone = true;
				_IDAEHNGOKAE_OnRankingError();
			}, () =>
			{
				//0x12C6A94
				PLOOEECNHFB_IsDone = true;
				NPNNPNAIONN_IsError = true;
				_JGKOLBLPMPG_OnFail();
			}, false);
		}
	}

	// // RVA: 0x12C1C18 Offset: 0x12C1C18 VA: 0x12C1C18
	// private int APJDIPINLLK(List<int> HNLFPKNBOHE, int _PPFNGGCBJKC_id) { }

	// // RVA: 0x12C1D10 Offset: 0x12C1D10 VA: 0x12C1D10 Slot: 51
	public override IHAEIOAKEMG ILICNKILFKJ_GetNextReward()
	{
		for(int i = 0; i < PFPJHJJAGAG_Rewards.Count; i++)
		{
			if(!PFPJHJJAGAG_Rewards[i].HMEOAKCLKJE_IsReceived)
			{
				return PFPJHJJAGAG_Rewards[i];
			}
		}
		return null;
	}

	// // RVA: 0x12C1E24 Offset: 0x12C1E24 VA: 0x12C1E24 Slot: 58
	protected override void LMGMELPOGMH(int LHJCOPMMIGO)
	{
		return;
	}

	// // RVA: 0x12C1E28 Offset: 0x12C1E28 VA: 0x12C1E28 Slot: 59
	public override List<int> AEGDKBNNDBC_GetDrops()
	{
		return null;
	}

	// // RVA: 0x12C1E30 Offset: 0x12C1E30 VA: 0x12C1E30 Slot: 65
	protected override bool JLPDECMHLIM_CanShowStartAdventureInternal()
	{
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
			PJDGDNJNCNM_UpdateStatusImpl(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime());
		}
		return false;
	}

	// // RVA: 0x12C211C Offset: 0x12C211C VA: 0x12C211C Slot: 66
	public override void FGDDBFHGCGP_SetStartAdventureShown(bool _JKDJCFEBDHC_Enabled, long _JHNMKKNEENE_Time/* = 0*/)
	{
		if(_JKDJCFEBDHC_Enabled)
		{
			//
		}
	}

	// // RVA: 0x12C2360 Offset: 0x12C2360 VA: 0x12C2360 Slot: 70
	public override void ADACMHAHHKC_PreSetupEventHome(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		N.a.StartCoroutineWatched(NJIEIJJMAHK_Corotuine_PreSetupEventHome(_BHFHGFKBOHH_OnSuccess, _AOCANKOMKFG_OnError));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BC32C Offset: 0x6BC32C VA: 0x6BC32C
	// // RVA: 0x12C23B8 Offset: 0x12C23B8 VA: 0x12C23B8
	private IEnumerator NJIEIJJMAHK_Corotuine_PreSetupEventHome(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		IMDBGDNPLJA_EventBoxGacha KHGBJCFJGMA;

		//0x12C6E3C
		long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		EGOJLOEFMOH_IsUpdateLimitedMusic = false;
		LPFJADHHLHG = false;
		BCBCODAKIDN_DescType = 0;
		KHGBJCFJGMA = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as IMDBGDNPLJA_EventBoxGacha;
		if(KHGBJCFJGMA != null)
		{
			PJDGDNJNCNM_UpdateStatusImpl(t);
			MJFKJHJJLMN_GetRanks(0, false);
			while(!PLOOEECNHFB_IsDone)
				yield return null;
			if(!NPNNPNAIONN_IsError)
			{
				ALIPBIMCAPN_EventBoxGacha.GLNFOMDKJJH save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MMAIJOCPJHP_EventBoxGacha.FBCJICEPLED[KHGBJCFJGMA.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
				if(FKKDIDMGLMI_IsDroppedPlayer)
				{
					JHHBAFKMBDL.HHCJCDFCLOB.PEIONAKEPCN_ShowRankingBanPopup(_AOCANKOMKFG_OnError);
				}
				else
				{
					CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
					{
						//0x12C6B00
						if(_BHFHGFKBOHH_OnSuccess != null)
							_BHFHGFKBOHH_OnSuccess();
						PLOOEECNHFB_IsDone = true;
					}, () =>
					{
						//0x12C6B40
						if(_AOCANKOMKFG_OnError != null)
							_AOCANKOMKFG_OnError();
						PLOOEECNHFB_IsDone = true;
						NPNNPNAIONN_IsError = true;
					}, null);
				}
			}
			else
			{
				_AOCANKOMKFG_OnError();
			}
		}
		else
		{
			NPNNPNAIONN_IsError = true;
			PLOOEECNHFB_IsDone = true;
			if(_AOCANKOMKFG_OnError != null)
				_AOCANKOMKFG_OnError();
		}
	}

	// // RVA: 0x12C2498 Offset: 0x12C2498 VA: 0x12C2498 Slot: 33
	public override bool MPMKJNJGFEF_IsEntry()
	{
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
			ALIPBIMCAPN_EventBoxGacha.GLNFOMDKJJH save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MMAIJOCPJHP_EventBoxGacha.FBCJICEPLED[evDb.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			return save.IMFBCJOIJKJ_Entry;
		}
		return false;
	}

	// // RVA: 0x12C26F8 Offset: 0x12C26F8 VA: 0x12C26F8 Slot: 69
	public override void HAAEJDGMICH(LBNLAENLPNK.JEKODBEDOMM _INDDJNMPONH_type, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		string s = null;
		if(_INDDJNMPONH_type == 0)
		{
			s = JOPOPMLFINI_QuestName + "_rule";
		}
		if(string.IsNullOrEmpty(s))
		{
			_BHFHGFKBOHH_OnSuccess();
		}
		else
		{
			MBCPNPNMFHB.HHCJCDFCLOB.FLLLPBIECCP(s, _BHFHGFKBOHH_OnSuccess, _AOCANKOMKFG_OnError);
		}
	}

	// // RVA: 0x12C2820 Offset: 0x12C2820 VA: 0x12C2820 Slot: 71
	public override int BAEPGOAMBDK(string _LJNAKDMILMC_key, int MNCOAGOKNAO)
	{
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
			return evDb.LPJLEHAJADA_GetIntParam(_LJNAKDMILMC_key, MNCOAGOKNAO);
		}
		return MNCOAGOKNAO;
	}

	// // RVA: 0x12C29A0 Offset: 0x12C29A0 VA: 0x12C29A0 Slot: 72
	public override string MAICAKMIBEM(string _LJNAKDMILMC_key, string MNCOAGOKNAO)
	{
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
			return evDb.EFEGBHACJAL_GetStringParam(_LJNAKDMILMC_key, MNCOAGOKNAO);
		}
		return MNCOAGOKNAO;
	}

	// // RVA: 0x12C2B20 Offset: 0x12C2B20 VA: 0x12C2B20 Slot: 68
	public override bool GJMGKBDGMOP(long LPEKHFOMCAH)
	{
		return false;
	}

	// // RVA: 0x12C2B28 Offset: 0x12C2B28 VA: 0x12C2B28 Slot: 75
	public override string FEKEBPKINIM_GetSessionId()
	{
		return "";
	}

	// // RVA: 0x12C2B84 Offset: 0x12C2B84 VA: 0x12C2B84
	public void OGMDPOJNBHK()
	{
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
			ALIPBIMCAPN_EventBoxGacha.GLNFOMDKJJH save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MMAIJOCPJHP_EventBoxGacha.FBCJICEPLED[evDb.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			int boxId = 1;
			if(save.IMMDGJAOPCD_BoxId != 0)
				boxId = save.IMMDGJAOPCD_BoxId;
			IMDBGDNPLJA_EventBoxGacha.NEFJBPECLKJ box = evDb.KGDBEMPMAIJ_Boxes.Find((IMDBGDNPLJA_EventBoxGacha.NEFJBPECLKJ _GHPLINIACBB_x) =>
			{
				//0x12C6B98
				return _GHPLINIACBB_x.PPFNGGCBJKC_id == boxId;
			});
			if(box != null)
			{
				save.NNCCGILOOIE_Num++;
				if(save.NNCCGILOOIE_Num > 9999)
					save.NNCCGILOOIE_Num = 9999;
				IDLMBIEAPIL(box.IHGDLBBPKFI_Next != 0 ? box.IHGDLBBPKFI_Next : boxId);
			}
		}
	}

	// // RVA: 0x12BFC08 Offset: 0x12BFC08 VA: 0x12BFC08
	public void IDLMBIEAPIL(int KMGIPOILLDN)
	{
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
			ALIPBIMCAPN_EventBoxGacha.GLNFOMDKJJH save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MMAIJOCPJHP_EventBoxGacha.FBCJICEPLED[evDb.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			IMDBGDNPLJA_EventBoxGacha.NEFJBPECLKJ box = evDb.KGDBEMPMAIJ_Boxes.Find((IMDBGDNPLJA_EventBoxGacha.NEFJBPECLKJ _GHPLINIACBB_x) =>
			{
				//0x12C6BD0
				return _GHPLINIACBB_x.PPFNGGCBJKC_id == KMGIPOILLDN;
			});
			if(box != null)
			{
				save.IMMDGJAOPCD_BoxId = KMGIPOILLDN;
				for(int i = 0; i < save.PKPLOGBIDIG_Prizes.Count; i++)
				{
					save.PKPLOGBIDIG_Prizes[i].JBDBPCMMBIH_Id = 0;
					save.PKPLOGBIDIG_Prizes[i].AGKANHNHECE_Remain = 0;
				}
				int a = 0;
				for(int i = 0; i < evDb.PKPLOGBIDIG_Prizes.Count; i++)
				{
					if(evDb.PKPLOGBIDIG_Prizes[i].IMMDGJAOPCD_BoxId == KMGIPOILLDN)
					{
						save.PKPLOGBIDIG_Prizes[a].JBDBPCMMBIH_Id = evDb.PKPLOGBIDIG_Prizes[i].PPFNGGCBJKC_id;
						save.PKPLOGBIDIG_Prizes[a].AGKANHNHECE_Remain = evDb.PKPLOGBIDIG_Prizes[i].ADPPAIPFHML_num;
						a++;
					}
				}
				GALFOGJIDMK(ref JMLKAGOACAE, 0);
			}
		}
	}

	// // RVA: 0x12C2F80 Offset: 0x12C2F80 VA: 0x12C2F80
	public void AAIAADGEDDN()
	{
		GALFOGJIDMK(ref JMLKAGOACAE, 0);
	}

	// // RVA: 0x12C35B0 Offset: 0x12C35B0 VA: 0x12C35B0
	// public void POENJMJMDPM(int _IMMDGJAOPCD_BoxId) { }

	// // RVA: 0x12C2F8C Offset: 0x12C2F8C VA: 0x12C2F8C
	public void GALFOGJIDMK(ref List<MDBEKHIHBJM> HFNLAEHDODI, int _IMMDGJAOPCD_BoxId/* = 0*/)
	{
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
			ALIPBIMCAPN_EventBoxGacha.GLNFOMDKJJH save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MMAIJOCPJHP_EventBoxGacha.FBCJICEPLED[evDb.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			if(_IMMDGJAOPCD_BoxId < 1)
				_IMMDGJAOPCD_BoxId = save.IMMDGJAOPCD_BoxId;
			IMDBGDNPLJA_EventBoxGacha.NEFJBPECLKJ box = evDb.KGDBEMPMAIJ_Boxes.Find((IMDBGDNPLJA_EventBoxGacha.NEFJBPECLKJ _GHPLINIACBB_x) =>
			{
				//0x12C6C08
				return _GHPLINIACBB_x.PPFNGGCBJKC_id == _IMMDGJAOPCD_BoxId;
			});
			if(box != null)
			{
				HFNLAEHDODI.Clear();
				for(int i = 0; i < save.PKPLOGBIDIG_Prizes.Count; i++)
				{
					if(save.PKPLOGBIDIG_Prizes[i].JBDBPCMMBIH_Id > 0 && save.PKPLOGBIDIG_Prizes[i].JBDBPCMMBIH_Id < evDb.PKPLOGBIDIG_Prizes.Count + 1)
					{
						int idx = save.PKPLOGBIDIG_Prizes[i].JBDBPCMMBIH_Id - 1;
						if(_IMMDGJAOPCD_BoxId == evDb.PKPLOGBIDIG_Prizes[idx].IMMDGJAOPCD_BoxId && evDb.PKPLOGBIDIG_Prizes[idx].PLALNIIBLOF_en == 2)
						{
							MDBEKHIHBJM d = new MDBEKHIHBJM();
							d.JBDBPCMMBIH_Id = save.PKPLOGBIDIG_Prizes[i].JBDBPCMMBIH_Id;
							d.GLCLFMGPMAN_ItemId = evDb.PKPLOGBIDIG_Prizes[idx].GLCLFMGPMAN_ItemId;
							d.HMFFHLPNMPH_count = evDb.PKPLOGBIDIG_Prizes[idx].JBGEEPFKIGG_val;
							d.GCEANEOEGMD_Num = evDb.PKPLOGBIDIG_Prizes[idx].ADPPAIPFHML_num;
							d.AGKANHNHECE_Remain = save.PKPLOGBIDIG_Prizes[i].AGKANHNHECE_Remain;
							d.AEDMJLGNDHN_IsSp = evDb.PKPLOGBIDIG_Prizes[idx].AEDMJLGNDHN_IsSp != 0;
							d.IHLEPGEJNPM_Idx = i;
							HFNLAEHDODI.Add(d);
						}
					}
				}
			}
		}
	}

	// // RVA: 0x12C35BC Offset: 0x12C35BC VA: 0x12C35BC
	public void ELAGEGMIKKK(ref List<MDBEKHIHBJM> HFNLAEHDODI, int _IMMDGJAOPCD_BoxId/* = 0*/)
	{
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
			ALIPBIMCAPN_EventBoxGacha.GLNFOMDKJJH save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MMAIJOCPJHP_EventBoxGacha.FBCJICEPLED[evDb.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			if(_IMMDGJAOPCD_BoxId < 1)
				_IMMDGJAOPCD_BoxId = save.IMMDGJAOPCD_BoxId;
			IMDBGDNPLJA_EventBoxGacha.NEFJBPECLKJ box = evDb.KGDBEMPMAIJ_Boxes.Find((IMDBGDNPLJA_EventBoxGacha.NEFJBPECLKJ _GHPLINIACBB_x) =>
			{
				//0x12C6C40
				return _GHPLINIACBB_x.PPFNGGCBJKC_id == _IMMDGJAOPCD_BoxId;
			});
			if(box != null)
			{
				HFNLAEHDODI.Clear();
				for(int i = 0; i < evDb.PKPLOGBIDIG_Prizes.Count; i++)
				{
					if(_IMMDGJAOPCD_BoxId == evDb.PKPLOGBIDIG_Prizes[i].IMMDGJAOPCD_BoxId && evDb.PKPLOGBIDIG_Prizes[i].PLALNIIBLOF_en == 2)
					{
						MDBEKHIHBJM d = new MDBEKHIHBJM();
						d.JBDBPCMMBIH_Id = i;
						d.GLCLFMGPMAN_ItemId = evDb.PKPLOGBIDIG_Prizes[i].GLCLFMGPMAN_ItemId;
						d.HMFFHLPNMPH_count = evDb.PKPLOGBIDIG_Prizes[i].JBGEEPFKIGG_val;
						d.GCEANEOEGMD_Num = evDb.PKPLOGBIDIG_Prizes[i].ADPPAIPFHML_num;
						d.AGKANHNHECE_Remain = evDb.PKPLOGBIDIG_Prizes[i].ADPPAIPFHML_num;
						d.AEDMJLGNDHN_IsSp = evDb.PKPLOGBIDIG_Prizes[i].AEDMJLGNDHN_IsSp != 0;
						d.IHLEPGEJNPM_Idx = i;
						HFNLAEHDODI.Add(d);
					}
				}
			}
		}
	}

	// // RVA: 0x12BFB78 Offset: 0x12BFB78 VA: 0x12BFB78
	public void NCEJOLLKDDF_InitRandList()
	{
		PMBEODGMMBB_y = (uint)(Utility.GetCurrentUnixTime() ^ 0x15ab17a1);
	}

	// // RVA: 0x12C3B34 Offset: 0x12C3B34 VA: 0x12C3B34
	// private int HEPEDNJMCFA(int _HKICMNAACDA_a, int _BNKHBCBJBKI_b) { }

	// // RVA: 0x12C3B68 Offset: 0x12C3B68 VA: 0x12C3B68
	private void DLPHPGJCAAF_RandomizeList(List<PCCHKHKKLPM> NNDGIAEFMOG)
	{
		if(NNDGIAEFMOG != null)
		{
			for(int i = 0; i < NNDGIAEFMOG.Count; i++)
			{
				PMBEODGMMBB_y ^= PMBEODGMMBB_y << 0xd;
				PMBEODGMMBB_y ^= PMBEODGMMBB_y >> 0x11;
				PMBEODGMMBB_y ^= PMBEODGMMBB_y << 5;
				int idx = ((int)PMBEODGMMBB_y & 0x7fffffff) % NNDGIAEFMOG.Count;
				PCCHKHKKLPM d = NNDGIAEFMOG[i];
				NNDGIAEFMOG[i] = NNDGIAEFMOG[idx];
				NNDGIAEFMOG[idx] = d;
			}
		}
	}

	// // RVA: 0x12C3CC0 Offset: 0x12C3CC0 VA: 0x12C3CC0
	private bool KOCPLGOAKKG()
	{
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
			ALIPBIMCAPN_EventBoxGacha.GLNFOMDKJJH save /*NHLBKJCPLBL*/ = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MMAIJOCPJHP_EventBoxGacha.FBCJICEPLED[evDb.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			List<PCCHKHKKLPM> l = new List<PCCHKHKKLPM>();
			for(int i = 0; i < JMLKAGOACAE.Count; i++)
			{
                ALIPBIMCAPN_EventBoxGacha.EHDCAEHLLKF prize = save.PKPLOGBIDIG_Prizes.Find((ALIPBIMCAPN_EventBoxGacha.EHDCAEHLLKF _GHPLINIACBB_x) =>
				{
					//0x12C6C78
					return _GHPLINIACBB_x.JBDBPCMMBIH_Id == JMLKAGOACAE[i].JBDBPCMMBIH_Id;
				});
                if (prize != null && prize.AGKANHNHECE_Remain != 0)
				{
					PCCHKHKKLPM p = new PCCHKHKKLPM();
					p.MKNDAOHGOAK_weight = prize.AGKANHNHECE_Remain * 100;
					p.OIPCCBHIKIA_index = i;
					l.Add(p);
				}
            }
			DLPHPGJCAAF_RandomizeList(l);
			int t = 0;
			for(int i = 0; i < l.Count; i++)
			{
				t += l[i].MKNDAOHGOAK_weight;
				l[i].FCDKJAKLGMB_TargetValue = t;
			}
			PMBEODGMMBB_y = PMBEODGMMBB_y ^ (PMBEODGMMBB_y << 0xd);
			PMBEODGMMBB_y = PMBEODGMMBB_y ^ (PMBEODGMMBB_y >> 0x11);
			PMBEODGMMBB_y = PMBEODGMMBB_y ^ (PMBEODGMMBB_y << 5);
			int v = (int)(PMBEODGMMBB_y & 0x7fffffff) % t;
			int found = 0;
			for(int i = 0; i < l.Count; i++)
			{
				found = i;
				if(l[i].FCDKJAKLGMB_TargetValue > v)
					break;
			}
			int ticketId = evDb.KGDBEMPMAIJ_Boxes[save.IMMDGJAOPCD_BoxId - 1].GLCLFMGPMAN_ItemId;
			int num = EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(ticketId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(ticketId), null);
			num -= evDb.KGDBEMPMAIJ_Boxes[save.IMMDGJAOPCD_BoxId - 1].NDNHKMJPBCM_Cost;
			if(num < 0)
				num = 0;
			EKLNMHFCAOI.DPHGFMEPOCA_SetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(ticketId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(ticketId), num, null);
            MDBEKHIHBJM m = JMLKAGOACAE[l[found].OIPCCBHIKIA_index]; // PKPLOGBIDIG_Prizes
			ALIPBIMCAPN_EventBoxGacha.EHDCAEHLLKF savePrize = save.PKPLOGBIDIG_Prizes.Find((ALIPBIMCAPN_EventBoxGacha.EHDCAEHLLKF _GHPLINIACBB_x) =>
			{
				//0x12C6CD4
				return _GHPLINIACBB_x.JBDBPCMMBIH_Id == m.JBDBPCMMBIH_Id;
			});
			if(savePrize != null)
			{
				if(savePrize.AGKANHNHECE_Remain > 0)
					savePrize.AGKANHNHECE_Remain--;
                IMDBGDNPLJA_EventBoxGacha.BKGONBEMGED dbPrize = evDb.PKPLOGBIDIG_Prizes[m.JBDBPCMMBIH_Id - 1];
                OGNKHBFKHIP.Length = 0;
				OGNKHBFKHIP.Append(PGIIDPEGGPI_EventId);
				OGNKHBFKHIP.Append(':');
				OGNKHBFKHIP.Append(evDb.KGDBEMPMAIJ_Boxes[save.IMMDGJAOPCD_BoxId - 1].PPFNGGCBJKC_id);
				OGNKHBFKHIP.Append(':');
				OGNKHBFKHIP.Append(m.JBDBPCMMBIH_Id);
				OGNKHBFKHIP.Append(':');
				OGNKHBFKHIP.Append(savePrize.AGKANHNHECE_Remain);
				OGNKHBFKHIP.Append(':');
				OGNKHBFKHIP.Append(dbPrize.ADPPAIPFHML_num);
				JANMJPOKLFL_InventoryUtil.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.GMOLAHOIJHE_16, OGNKHBFKHIP.ToString());
				JANMJPOKLFL_InventoryUtil.CPIICACGNBH_AddItem(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, dbPrize.GLCLFMGPMAN_ItemId, dbPrize.JBGEEPFKIGG_val, null, 0);
				if(dbPrize.AEDMJLGNDHN_IsSp != 0)
				{
					save.FEFCFGNGPGC_Pickup++;
				}
				FMAHFJGBHMG f = new FMAHFJGBHMG();
				f.PPFNGGCBJKC_id = dbPrize.PPFNGGCBJKC_id;
				f.JNGNONNJLBM = l[found].OIPCCBHIKIA_index;
				f.KIJAPOFAGPN_ItemId = dbPrize.GLCLFMGPMAN_ItemId;
				f.HMFFHLPNMPH_count = dbPrize.JBGEEPFKIGG_val;
				f.AEDMJLGNDHN_IsSp = dbPrize.AEDMJLGNDHN_IsSp != 0;
				f.CONGLCLANMP_Remain = savePrize.AGKANHNHECE_Remain;
				f.FPFKNDKENIC = dbPrize.ADPPAIPFHML_num;
				PNLJHCDHKCP_LotResult.Add(f);
			}
			return true;
        }
		return false;
	}

	// // RVA: 0x12C49DC Offset: 0x12C49DC VA: 0x12C49DC
	public bool KOCPLGOAKKG(int _LAJNCHHNLBI_n)
	{
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
			ALIPBIMCAPN_EventBoxGacha.GLNFOMDKJJH save /*NHLBKJCPLBL*/ = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MMAIJOCPJHP_EventBoxGacha.FBCJICEPLED[evDb.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			IMDBGDNPLJA_EventBoxGacha.NEFJBPECLKJ box = evDb.KGDBEMPMAIJ_Boxes.Find((IMDBGDNPLJA_EventBoxGacha.NEFJBPECLKJ _GHPLINIACBB_x) =>
			{
				//0x12C6D30
				return _GHPLINIACBB_x.PPFNGGCBJKC_id == save.IMMDGJAOPCD_BoxId;
			});
			if(box != null)
			{
				PNLJHCDHKCP_LotResult.Clear();
				JANMJPOKLFL_InventoryUtil.JCHLONCMPAJ_Clear();
				OGNKHBFKHIP = new StringBuilder();
				if(box.NDNHKMJPBCM_Cost <= EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(box.GLCLFMGPMAN_ItemId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(box.GLCLFMGPMAN_ItemId), null))
				{
					int a = _LAJNCHHNLBI_n;
					if(_LAJNCHHNLBI_n > 0)
					{
						do
						{
							KOCPLGOAKKG();
							a--;
						} while(a != 0);
					}
					OGNKHBFKHIP = null;
					ILCCJNDFFOB.HHCJCDFCLOB.LIPHGGFEJFJ(box.PPFNGGCBJKC_id, _LAJNCHHNLBI_n, IPOENPPBFNK(), MPJNMBFIJMB(), box.GLCLFMGPMAN_ItemId, box.NDNHKMJPBCM_Cost * _LAJNCHHNLBI_n, EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(box.GLCLFMGPMAN_ItemId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(box.GLCLFMGPMAN_ItemId), null), this);
					return true;
				}
			}
		}
		return false;
	}

	// // RVA: 0x12C55D0 Offset: 0x12C55D0 VA: 0x12C55D0
	public bool BEDCLNJIEGF(long _JHNMKKNEENE_Time)
	{
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
			return evDb.NGHKJOEDLIP_Settings.PHKLJGNMFBL_End >= _JHNMKKNEENE_Time && _JHNMKKNEENE_Time >= evDb.NGHKJOEDLIP_Settings.OHGDNJLFDFF_Start;
		}
		return DPJCPDKALGI_RankingEnd >= _JHNMKKNEENE_Time && _JHNMKKNEENE_Time >= GLIMIGNNGGB_RankingStart;
	}

	// // RVA: 0x12C57C0 Offset: 0x12C57C0 VA: 0x12C57C0
	// public long ANFFEFDMOIL(long _JHNMKKNEENE_Time) { }

	// // RVA: 0x12C4F5C Offset: 0x12C4F5C VA: 0x12C4F5C
	public int IPOENPPBFNK()
	{
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
			ALIPBIMCAPN_EventBoxGacha.GLNFOMDKJJH save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MMAIJOCPJHP_EventBoxGacha.FBCJICEPLED[evDb.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			int res = 0;
			for(int i = 0; i < JMLKAGOACAE.Count; i++)
			{
				res += save.PKPLOGBIDIG_Prizes[JMLKAGOACAE[i].IHLEPGEJNPM_Idx].AGKANHNHECE_Remain;
			}
			return res;
		}
		return 0;
	}

	// // RVA: 0x12C52A0 Offset: 0x12C52A0 VA: 0x12C52A0
	public int MPJNMBFIJMB()
	{
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
            //ALIPBIMCAPN_EventBoxGacha.GLNFOMDKJJH save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MMAIJOCPJHP_EventBoxGacha.FBCJICEPLED[evDb.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			int res = 0;
			for(int i = 0; i < JMLKAGOACAE.Count; i++)
			{
				res += evDb.PKPLOGBIDIG_Prizes[JMLKAGOACAE[i].JBDBPCMMBIH_Id - 1].ADPPAIPFHML_num;
			}
			return res;
		}
		return 0;
	}

	// // RVA: 0x12C57F4 Offset: 0x12C57F4 VA: 0x12C57F4
	public int BCMFJLFDLND_GetNumUseItemForCurrentBox()
	{
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
            ALIPBIMCAPN_EventBoxGacha.GLNFOMDKJJH save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MMAIJOCPJHP_EventBoxGacha.FBCJICEPLED[evDb.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
            IMDBGDNPLJA_EventBoxGacha.NEFJBPECLKJ box = evDb.KGDBEMPMAIJ_Boxes.Find((IMDBGDNPLJA_EventBoxGacha.NEFJBPECLKJ _GHPLINIACBB_x) =>
			{
				//0x12C6D88
				return _GHPLINIACBB_x.PPFNGGCBJKC_id == save.IMMDGJAOPCD_BoxId;
			});
            if (box != null)
			{
				return EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(box.GLCLFMGPMAN_ItemId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(box.GLCLFMGPMAN_ItemId), null);
			}
		}
		return 0;
	}

	// // RVA: 0x12C5BB4 Offset: 0x12C5BB4 VA: 0x12C5BB4
	public IMDBGDNPLJA_EventBoxGacha.NEFJBPECLKJ DIACKBHMKEH_GetCurrentBoxInfo()
	{
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
            ALIPBIMCAPN_EventBoxGacha.GLNFOMDKJJH save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MMAIJOCPJHP_EventBoxGacha.FBCJICEPLED[evDb.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			return evDb.KGDBEMPMAIJ_Boxes.Find((IMDBGDNPLJA_EventBoxGacha.NEFJBPECLKJ _GHPLINIACBB_x) =>
			{
				//0x12C6DE0
				return _GHPLINIACBB_x.PPFNGGCBJKC_id == save.IMMDGJAOPCD_BoxId;
			});
		}
		return null;
	}

	// // RVA: 0x12C5F00 Offset: 0x12C5F00 VA: 0x12C5F00
	public int GOIJBILEHPD_GetSaveBoxCnt()
	{
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
            ALIPBIMCAPN_EventBoxGacha.GLNFOMDKJJH save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MMAIJOCPJHP_EventBoxGacha.FBCJICEPLED[evDb.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			return save.NNCCGILOOIE_Num;
		}
		return 0;
	}

	// // RVA: 0x12C61B0 Offset: 0x12C61B0 VA: 0x12C61B0
	public MDBEKHIHBJM DGBCMNLEDEI()
	{
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
            ALIPBIMCAPN_EventBoxGacha.GLNFOMDKJJH save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MMAIJOCPJHP_EventBoxGacha.FBCJICEPLED[evDb.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			List<IMDBGDNPLJA_EventBoxGacha.BKGONBEMGED> l = evDb.PKPLOGBIDIG_Prizes.FindAll((IMDBGDNPLJA_EventBoxGacha.BKGONBEMGED _GHPLINIACBB_x) =>
			{
				//0x12C67BC
				return _GHPLINIACBB_x.AEDMJLGNDHN_IsSp != 0;
			});
			MDBEKHIHBJM res = null;
			for(int i = 0; i < l.Count; i++)
			{
				if(l[i].PLALNIIBLOF_en == 2)
				{
					if(res == null)
					{
						res = new MDBEKHIHBJM();
						res.JBDBPCMMBIH_Id = l[i].PPFNGGCBJKC_id;
						res.GLCLFMGPMAN_ItemId = l[i].GLCLFMGPMAN_ItemId;
						res.HMFFHLPNMPH_count = l[i].JBGEEPFKIGG_val;
						res.GCEANEOEGMD_Num = l[i].ADPPAIPFHML_num;
						res.AGKANHNHECE_Remain = l[i].ADPPAIPFHML_num - save.FEFCFGNGPGC_Pickup;
						res.AEDMJLGNDHN_IsSp = true;
					}
					else if(res.GLCLFMGPMAN_ItemId == l[i].GLCLFMGPMAN_ItemId)
					{
						res.GCEANEOEGMD_Num += l[i].ADPPAIPFHML_num;
						res.AGKANHNHECE_Remain = res.GCEANEOEGMD_Num - save.FEFCFGNGPGC_Pickup;
					}
				}
			}
			return res;
        }
		return null;
	}
}
