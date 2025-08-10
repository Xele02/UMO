
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
		public int JBDBPCMMBIH; // 0xC
		public int GLCLFMGPMAN_ItemId; // 0x10
		public int HMFFHLPNMPH_Val; // 0x14
		public int AGKANHNHECE_Remain; // 0x18
		public int GCEANEOEGMD_Num; // 0x1C
		public bool AEDMJLGNDHN_IsSp; // 0x20
	}

	public class FMAHFJGBHMG
	{
		public int PPFNGGCBJKC; // 0x8
		public int JNGNONNJLBM; // 0xC
		public int KIJAPOFAGPN_ItemId; // 0x10
		public int HMFFHLPNMPH_Cnt; // 0x14
		public bool AEDMJLGNDHN; // 0x18
		public int CONGLCLANMP_Remain; // 0x1C
		public int FPFKNDKENIC; // 0x20
	}

	public class PCCHKHKKLPM
	{
		public int OIPCCBHIKIA; // 0x8
		public int MKNDAOHGOAK; // 0xC
		public int FCDKJAKLGMB; // 0x10
	}

	private const int GHJHJDIDCFA = 3;
	private EECOJKDJIFG KBACNOCOANM; // 0xE8
	public List<KDLFECOOANO> HNDKCBHOJEH = new List<KDLFECOOANO>(50); // 0xEC
	public bool EGOJLOEFMOH; // 0xF0
	public int BCBCODAKIDN; // 0xF4
	public bool KDDBNAIJKAD; // 0xF8
	public bool KIBBLLADDPO; // 0xF9
	public bool AAODGCEBJCG; // 0xFA
	public List<MDBEKHIHBJM> JMLKAGOACAE = new List<MDBEKHIHBJM>(); // 0xFC
	public List<MDBEKHIHBJM> CKFCGDIJKKC = new List<MDBEKHIHBJM>(); // 0x100
	public List<FMAHFJGBHMG> PNLJHCDHKCP_LotResult = new List<FMAHFJGBHMG>(); // 0x104
	public JKNGJFOBADP JANMJPOKLFL_InventoryUtil = new JKNGJFOBADP(); // 0x108
	private uint PMBEODGMMBB = 0x15ab17a1; // 0x10C
	private StringBuilder OGNKHBFKHIP; // 0x110

	public override OHCAABOMEOF.KGOGMKMBCPP_EventType HIDHLFCBIDE_EventType { get { return OHCAABOMEOF.KGOGMKMBCPP_EventType.OCCGDMDBCHK_EventGacha; } } //0x12BF064 DKHCGLCNKCD  Slot: 4

	// // RVA: 0x12BF06C Offset: 0x12BF06C VA: 0x12BF06C Slot: 32
	public override EECOJKDJIFG DAKMIKNKHMF_GetRankingInfoForIndex(int LHJCOPMMIGO = 0)
	{
		return KBACNOCOANM;
	}

	// RVA: 0x12BF074 Offset: 0x12BF074 VA: 0x12BF074
	public CHHECNJBMLA_EventBoxGacha(string OPFGFINHFCE) : base(OPFGFINHFCE)
    {
        return;
    }

	// // RVA: 0x12BF1E8 Offset: 0x12BF1E8 VA: 0x12BF1E8 Slot: 5
	public override string IFKKBHPMALH()
	{
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
			return evDb.NGHKJOEDLIP.OCDMGOGMHGE;
		}
		return null;
	}

	// // RVA: 0x12BF370 Offset: 0x12BF370 VA: 0x12BF370 Slot: 27
	public override int HLOGNJNGDJO_GetHelpId(int OIPCCBHIKIA = 0)
	{
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
			return evDb.NGHKJOEDLIP.EJBGHLOOLBC_HelpIds[OIPCCBHIKIA];
		}
		return 0;
	}

	// // RVA: 0x12BF52C Offset: 0x12BF52C VA: 0x12BF52C Slot: 28
	public override long FBGDBGKNKOD_GetCurrentPoint()
	{
		return 0;
	}

	// // RVA: 0x12BF538 Offset: 0x12BF538 VA: 0x12BF538 Slot: 29
	public override void MJFKJHJJLMN_GetRanks(int LHJCOPMMIGO = 0, bool FBBNPFFEJBN = false)
	{
		PLOOEECNHFB = true;
	}

	// // RVA: 0x12BF544 Offset: 0x12BF544 VA: 0x12BF544 Slot: 30
	protected override bool JIHMLILFOPG_IsEventActive(long JHNMKKNEENE)
	{
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
			GDIPLANPCEI g = IMMAOANGPNK.HHCJCDFCLOB.ACEFBFLFKFD_GetScheduleEventData(evDb.JIKKNHIAEKG_BlockName, JHNMKKNEENE);
			if(g != null)
			{
				if(evDb.NGHKJOEDLIP.GMFNMNOIJHI < 1)
				{
					if(JHNMKKNEENE < evDb.NGHKJOEDLIP.BONDDBOFBND_Start)
						return false;
					if(evDb.NGHKJOEDLIP.KNLGKBBIBOH_End < JHNMKKNEENE)
						return false;
				}
				else
				{
					if(JHNMKKNEENE < evDb.NGHKJOEDLIP.OHGDNJLFDFF)
						return false;
					if(evDb.NGHKJOEDLIP.PHKLJGNMFBL < JHNMKKNEENE)
						return false;
				}
				if(evDb.NGHKJOEDLIP.HKKNEAGCIEB != 0)
				{
					if(KKLGENJKEBN.HHCJCDFCLOB.JPDPFGFMKHK.Find((EECOJKDJIFG PKLPKMLGFGK) =>
					{
						//0x12C67E8
						return evDb.NGHKJOEDLIP.OCGFKMHNEOF_RankNameForApi == PKLPKMLGFGK.OCGFKMHNEOF_NameForApi;
					}) == null)
					{
						UnityEngine.Debug.LogError("Ranking Not found : "+evDb.NGHKJOEDLIP.OCGFKMHNEOF_RankNameForApi);
						return false;
					}
				}
				return true;
			}
		}
		return false;
	}

	// // RVA: 0x12BF8A8 Offset: 0x12BF8A8 VA: 0x12BF8A8 Slot: 31
	protected override bool IMCMNOPNGHO(long JHNMKKNEENE)
	{
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
			ALIPBIMCAPN_EventBoxGacha.GLNFOMDKJJH save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MMAIJOCPJHP_EventBoxGacha.FBCJICEPLED[evDb.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			AGLILDLEFDK_Missions = null;
			OLDFFDMPEBM_Quests = null;
			NCEJOLLKDDF();
			long t = evDb.NGHKJOEDLIP.BONDDBOFBND_Start;
			if(evDb.NGHKJOEDLIP.GMFNMNOIJHI > 0)
				t = evDb.NGHKJOEDLIP.OHGDNJLFDFF;
			if((!RuntimeSettings.CurrentSettings.UnlimitedEvent && save.EGBOHDFBAPB_End < t) || save.EGBOHDFBAPB_End == 0)
			{
				save.LHPDDGIJKNB(false);
				save.EGBOHDFBAPB_End = evDb.NGHKJOEDLIP.IDDBFFBPNGI;
				IDLMBIEAPIL(1);
			}
			return true;
		}
		return false;
	}

	// // RVA: 0x12C01A0 Offset: 0x12C01A0 VA: 0x12C01A0 Slot: 40
	protected override void KKFLDCBHFJA(long JHNMKKNEENE)
	{
		IMDBGDNPLJA_EventBoxGacha NENJCIMMEBC = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as IMDBGDNPLJA_EventBoxGacha;
		if(NENJCIMMEBC != null)
		{
			IBNKPMPFLGI_IsRankReward = NENJCIMMEBC.NGHKJOEDLIP.HKKNEAGCIEB != 0;
			if(IBNKPMPFLGI_IsRankReward)
			{
				KBACNOCOANM = KKLGENJKEBN.HHCJCDFCLOB.JPDPFGFMKHK.Find((EECOJKDJIFG PKLPKMLGFGK) =>
				{
					//0x12C6848
					return NENJCIMMEBC.NGHKJOEDLIP.OCGFKMHNEOF_RankNameForApi == PKLPKMLGFGK.OCGFKMHNEOF_NameForApi;
				});
				GPHEKCNDDIK = true;
			}
			DGCOMDILAKM_EventName = NENJCIMMEBC.NGHKJOEDLIP.OPFGFINHFCE_EventName;
			DOLJEDAAKNN_RankingName = NENJCIMMEBC.NGHKJOEDLIP.HEDAGCNPHGD;
			GLIMIGNNGGB_RankingStart = NENJCIMMEBC.NGHKJOEDLIP.BONDDBOFBND_Start;
			DPJCPDKALGI_RankingEnd = NENJCIMMEBC.NGHKJOEDLIP.HPNOGLIFJOP_End1;
			LOLAANGCGDO_RankingEnd2 = NENJCIMMEBC.NGHKJOEDLIP.LNFKGHNHJKE;
			JDDFILGNGFH_RewardStart = NENJCIMMEBC.NGHKJOEDLIP.JGMDAOACOJF;
			LJOHLEGGGMC_RewardEnd = NENJCIMMEBC.NGHKJOEDLIP.IDDBFFBPNGI;
			EMEKFFHCHMH_RewardEnd2 = NENJCIMMEBC.NGHKJOEDLIP.KNLGKBBIBOH_End;
			PGIIDPEGGPI_EventId = NENJCIMMEBC.NGHKJOEDLIP.OBGBAOLONDD_EventId;
			PBHNFNIHDJJ = NENJCIMMEBC.NGHKJOEDLIP.HFNIHKOAMGC;
			NHGPCLGPEHH_TicketType = NENJCIMMEBC.NGHKJOEDLIP.MJBKGOJBPAD_TicketType;
			FBHONHONKGD_MusicSelectDesc = NENJCIMMEBC.NGHKJOEDLIP.FEMMDNIELFC_MusicSelectDesc;
			GFIBLLLHMPD_StartAdventureId = NENJCIMMEBC.NGHKJOEDLIP.HIOOGLEJBKM_StartAdventureId;
			CAKEOPLJDAF_EndAdventureId = NENJCIMMEBC.NGHKJOEDLIP.FJCADCDNPMP_EndAdventureId;
			LEPALMDKEOK_IsPointReward = true;
			AAODGCEBJCG = NENJCIMMEBC.NGHKJOEDLIP.GMFNMNOIJHI > 0 || RuntimeSettings.CurrentSettings.UnlimitedEvent;
			for(int i = 0; i < KPOMHFLKMKI_LastRankUpdateTime.Length; i++)
			{
				KPOMHFLKMKI_LastRankUpdateTime[i] = 0;
			}
			if(!string.IsNullOrEmpty(NENJCIMMEBC.NGHKJOEDLIP.OMCAOJJGOGG))
			{
				string[] strs = NENJCIMMEBC.NGHKJOEDLIP.OMCAOJJGOGG.Split(new char[]{','});
				MFDJIFIIPJD m = new MFDJIFIIPJD();
				m.KHEKNNFCAOI(int.Parse(strs[0]), int.Parse(strs[1]));
				BHABCGJCGNO = m;
			}
			PIMFJALCIGK(EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene);
			GPHEKCNDDIK = true;
		}
	}

	// // RVA: 0x12C07B4 Offset: 0x12C07B4 VA: 0x12C07B4
	private void PIMFJALCIGK(EKLNMHFCAOI.FKGCBLHOOCL_Category INDDJNMPONH = EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
	{
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
			HNDKCBHOJEH.Clear();
			Dictionary<int,int> d = new Dictionary<int, int>();
			d.Clear();
			for(int i = 0; i < evDb.PKPLOGBIDIG_Prizes.Count; i++)
			{
				if(evDb.PKPLOGBIDIG_Prizes[i].PLALNIIBLOF_Enabled == 2)
				{
					if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(evDb.PKPLOGBIDIG_Prizes[i].GLCLFMGPMAN_ItemId) == INDDJNMPONH)
					{
						int rId = evDb.PKPLOGBIDIG_Prizes[i].IMMDGJAOPCD_BoxId * 10000 + EKLNMHFCAOI.DEACAHNLMNI_getItemId(evDb.PKPLOGBIDIG_Prizes[i].GLCLFMGPMAN_ItemId);
						if(!d.ContainsKey(rId))
						{
							d.Add(rId, 0);
						}
						d[rId] += evDb.PKPLOGBIDIG_Prizes[i].ADPPAIPFHML_Num * evDb.PKPLOGBIDIG_Prizes[i].JBGEEPFKIGG_Val;
					}
				}
			}
			foreach(var it in d)
			{
				int k = it.Key / 10000;
				IMDBGDNPLJA_EventBoxGacha.NEFJBPECLKJ m = evDb.KGDBEMPMAIJ_Boxes.Find((IMDBGDNPLJA_EventBoxGacha.NEFJBPECLKJ JPAEDJJFFOI) =>
				{
					//0x12C68A8
					return JPAEDJJFFOI.PPFNGGCBJKC_Id == k;
				});
				string s = JpStringLiterals.StringLiteral_9765;
				if(m != null)
					s = m.OPFGFINHFCE_Name;
				KDLFECOOANO k_ = new KDLFECOOANO();
				k_.GLCLFMGPMAN = it.Key % 10000;
				k_.IMMDGJAOPCD = k;
				k_.MPEKFDKEKCG = s;
				k_.CLLKANEGGBJ = it.Value;
				HNDKCBHOJEH.Add(k_);
			}
		}
	}

	// // RVA: 0x12C0F84 Offset: 0x12C0F84 VA: 0x12C0F84 Slot: 46
	protected override void PJDGDNJNCNM_UpdateStatusImpl(long JHNMKKNEENE)
	{
		NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.HJNNKCMLGFL_0;
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
			KIBBLLADDPO = false;
			ALIPBIMCAPN_EventBoxGacha.GLNFOMDKJJH save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MMAIJOCPJHP_EventBoxGacha.FBCJICEPLED[evDb.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			IBLPKJJNNIG = false;
			BELBNINIOIE = false;
			long s = evDb.NGHKJOEDLIP.BONDDBOFBND_Start;
			if(evDb.NGHKJOEDLIP.GMFNMNOIJHI > 0)
				s = evDb.NGHKJOEDLIP.OHGDNJLFDFF;
			NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.FFLKPBPBPEP_1;
			if(JHNMKKNEENE >= s)
			{
				if(DPJCPDKALGI_RankingEnd >= JHNMKKNEENE)
				{
					if(MBHDIJJEOFL != null)
					{
						for(int i = 0; i < MBHDIJJEOFL.Count; i++)
						{
							if(MBHDIJJEOFL[i].MAFAIIHJAFG == 0)
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
								if(MBHDIJJEOFL[i].MAFAIIHJAFG == 1)
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
					NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6;
					if(JHNMKKNEENE >= evDb.NGHKJOEDLIP.JGMDAOACOJF)
					{
						NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived;
						if(JHNMKKNEENE >= evDb.NGHKJOEDLIP.IDDBFFBPNGI)
						{
							NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.DOAENCHBAEO_11;
							if(JHNMKKNEENE < evDb.NGHKJOEDLIP.KNLGKBBIBOH_End)
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
	public override void NBMDAOFPKGK(int DNBFMLBNAEE)
	{
		return;
	}

	// // RVA: 0x12C13E8 Offset: 0x12C13E8 VA: 0x12C13E8 Slot: 49
	protected override void ODPJGHOJIOH(int LHJCOPMMIGO)
	{
		if(KBACNOCOANM != null)
		{
			IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as IMDBGDNPLJA_EventBoxGacha;
			if(evDb != null)
			{
				PJDGDNJNCNM_UpdateStatusImpl(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
			}
			else
				return;
		}
		PLOOEECNHFB = true;
	}

	// // RVA: 0x12C16D8 Offset: 0x12C16D8 VA: 0x12C16D8 Slot: 50
	protected override void MFJFBNPLFBE_OnReceieveTotalReward(bool GIPBIDFJFLL)
	{
		return;
	}

	// // RVA: 0x12C16DC Offset: 0x12C16DC VA: 0x12C16DC Slot: 52
	public override void FAMFKPBPIAA_GetRankingPlayerList(bool PFFJNEFNAMI, int CJHEHIMLGGL, int LHJCOPMMIGO, LIOLBKLMMIK KLMFJJCNBIP, DJBHIFLHJLK IDAEHNGOKAE, DJBHIFLHJLK JGKOLBLPMPG)
	{
		NPNNPNAIONN = false;
		PLOOEECNHFB = false;
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
			if(IBNKPMPFLGI_IsRankReward)
			{
				KKLGENJKEBN.HHCJCDFCLOB.FAMFKPBPIAA_GetRankingPlayerList(KBACNOCOANM.OCGFKMHNEOF_NameForApi, PFFJNEFNAMI, CJHEHIMLGGL, LHJCOPMMIGO, (int NEFEFHBHFFF, List<IBIGBMDANNM> MAGKKPOFJIM) =>
				{
					//0x12C68E0
					PLOOEECNHFB = true;
					KLMFJJCNBIP(NEFEFHBHFFF, MAGKKPOFJIM);
				}, () =>
				{
					//0x12C693C
					PLOOEECNHFB = true;
					IDAEHNGOKAE();
				}, () =>
				{
					//0x12C6988
					PLOOEECNHFB = true;
					NPNNPNAIONN = true;
					JGKOLBLPMPG();
				}, false);
				return;
			}
		}
		IDAEHNGOKAE();
		PLOOEECNHFB = true;
	}

	// // RVA: 0x12C1A14 Offset: 0x12C1A14 VA: 0x12C1A14 Slot: 53
	public override void JPNACOLKHLB_AddRankingPlayerListSecond(int CJHEHIMLGGL, int NEFEFHBHFFF, LIOLBKLMMIK KLMFJJCNBIP, DJBHIFLHJLK IDAEHNGOKAE, DJBHIFLHJLK JGKOLBLPMPG)
	{
		if(!IBNKPMPFLGI_IsRankReward)
		{
			IDAEHNGOKAE();
			PLOOEECNHFB = true;
		}
		else
		{
			KKLGENJKEBN.HHCJCDFCLOB.JPNACOLKHLB_AddRankingPlayerListSecond(CJHEHIMLGGL, NEFEFHBHFFF, (int JGNBPFCJLKI, List<IBIGBMDANNM> MAGKKPOFJIM) =>
			{
				//0x12C69EC
				PLOOEECNHFB = true;
				KLMFJJCNBIP(JGNBPFCJLKI, MAGKKPOFJIM);
			}, () =>
			{
				//0x12C6A48
				PLOOEECNHFB = true;
				IDAEHNGOKAE();
			}, () =>
			{
				//0x12C6A94
				PLOOEECNHFB = true;
				NPNNPNAIONN = true;
				JGKOLBLPMPG();
			}, false);
		}
	}

	// // RVA: 0x12C1C18 Offset: 0x12C1C18 VA: 0x12C1C18
	// private int APJDIPINLLK(List<int> HNLFPKNBOHE, int PPFNGGCBJKC_Id) { }

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
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
			PJDGDNJNCNM_UpdateStatusImpl(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
		}
		return false;
	}

	// // RVA: 0x12C211C Offset: 0x12C211C VA: 0x12C211C Slot: 66
	public override void FGDDBFHGCGP_SetStartAdventureShown(bool JKDJCFEBDHC, long JHNMKKNEENE = 0)
	{
		if(JKDJCFEBDHC)
		{
			//
		}
	}

	// // RVA: 0x12C2360 Offset: 0x12C2360 VA: 0x12C2360 Slot: 70
	public override void ADACMHAHHKC_PreSetupEventHome(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
	{
		N.a.StartCoroutineWatched(NJIEIJJMAHK_Corotuine_PreSetupEventHome(BHFHGFKBOHH, AOCANKOMKFG));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BC32C Offset: 0x6BC32C VA: 0x6BC32C
	// // RVA: 0x12C23B8 Offset: 0x12C23B8 VA: 0x12C23B8
	private IEnumerator NJIEIJJMAHK_Corotuine_PreSetupEventHome(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
	{
		IMDBGDNPLJA_EventBoxGacha KHGBJCFJGMA;

		//0x12C6E3C
		long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		EGOJLOEFMOH = false;
		LPFJADHHLHG = false;
		BCBCODAKIDN = 0;
		KHGBJCFJGMA = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as IMDBGDNPLJA_EventBoxGacha;
		if(KHGBJCFJGMA != null)
		{
			PJDGDNJNCNM_UpdateStatusImpl(t);
			MJFKJHJJLMN_GetRanks(0, false);
			while(!PLOOEECNHFB)
				yield return null;
			if(!NPNNPNAIONN)
			{
				ALIPBIMCAPN_EventBoxGacha.GLNFOMDKJJH save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MMAIJOCPJHP_EventBoxGacha.FBCJICEPLED[KHGBJCFJGMA.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
				if(FKKDIDMGLMI)
				{
					JHHBAFKMBDL.HHCJCDFCLOB.PEIONAKEPCN_ShowRankingBanPopup(AOCANKOMKFG);
				}
				else
				{
					CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
					{
						//0x12C6B00
						if(BHFHGFKBOHH != null)
							BHFHGFKBOHH();
						PLOOEECNHFB = true;
					}, () =>
					{
						//0x12C6B40
						if(AOCANKOMKFG != null)
							AOCANKOMKFG();
						PLOOEECNHFB = true;
						NPNNPNAIONN = true;
					}, null);
				}
			}
			else
			{
				AOCANKOMKFG();
			}
		}
		else
		{
			NPNNPNAIONN = true;
			PLOOEECNHFB = true;
			if(AOCANKOMKFG != null)
				AOCANKOMKFG();
		}
	}

	// // RVA: 0x12C2498 Offset: 0x12C2498 VA: 0x12C2498 Slot: 33
	public override bool MPMKJNJGFEF_IsEntry()
	{
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
			ALIPBIMCAPN_EventBoxGacha.GLNFOMDKJJH save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MMAIJOCPJHP_EventBoxGacha.FBCJICEPLED[evDb.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			return save.IMFBCJOIJKJ_Entry;
		}
		return false;
	}

	// // RVA: 0x12C26F8 Offset: 0x12C26F8 VA: 0x12C26F8 Slot: 69
	public override void HAAEJDGMICH(LBNLAENLPNK.JEKODBEDOMM INDDJNMPONH, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
	{
		string s = null;
		if(INDDJNMPONH == 0)
		{
			s = JOPOPMLFINI_QuestId + "_rule";
		}
		if(string.IsNullOrEmpty(s))
		{
			BHFHGFKBOHH();
		}
		else
		{
			MBCPNPNMFHB.HHCJCDFCLOB.FLLLPBIECCP(s, BHFHGFKBOHH, AOCANKOMKFG);
		}
	}

	// // RVA: 0x12C2820 Offset: 0x12C2820 VA: 0x12C2820 Slot: 71
	public override int BAEPGOAMBDK(string LJNAKDMILMC, int MNCOAGOKNAO)
	{
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
			return evDb.LPJLEHAJADA(LJNAKDMILMC, MNCOAGOKNAO);
		}
		return MNCOAGOKNAO;
	}

	// // RVA: 0x12C29A0 Offset: 0x12C29A0 VA: 0x12C29A0 Slot: 72
	public override string MAICAKMIBEM(string LJNAKDMILMC, string MNCOAGOKNAO)
	{
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
			return evDb.EFEGBHACJAL(LJNAKDMILMC, MNCOAGOKNAO);
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
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
			ALIPBIMCAPN_EventBoxGacha.GLNFOMDKJJH save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MMAIJOCPJHP_EventBoxGacha.FBCJICEPLED[evDb.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			int boxId = 1;
			if(save.IMMDGJAOPCD_BoxId != 0)
				boxId = save.IMMDGJAOPCD_BoxId;
			IMDBGDNPLJA_EventBoxGacha.NEFJBPECLKJ box = evDb.KGDBEMPMAIJ_Boxes.Find((IMDBGDNPLJA_EventBoxGacha.NEFJBPECLKJ GHPLINIACBB) =>
			{
				//0x12C6B98
				return GHPLINIACBB.PPFNGGCBJKC_Id == boxId;
			});
			if(box != null)
			{
				save.NNCCGILOOIE_BoxCnt++;
				if(save.NNCCGILOOIE_BoxCnt > 9999)
					save.NNCCGILOOIE_BoxCnt = 9999;
				IDLMBIEAPIL(box.IHGDLBBPKFI_Next != 0 ? box.IHGDLBBPKFI_Next : boxId);
			}
		}
	}

	// // RVA: 0x12BFC08 Offset: 0x12BFC08 VA: 0x12BFC08
	public void IDLMBIEAPIL(int KMGIPOILLDN)
	{
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
			ALIPBIMCAPN_EventBoxGacha.GLNFOMDKJJH save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MMAIJOCPJHP_EventBoxGacha.FBCJICEPLED[evDb.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			IMDBGDNPLJA_EventBoxGacha.NEFJBPECLKJ box = evDb.KGDBEMPMAIJ_Boxes.Find((IMDBGDNPLJA_EventBoxGacha.NEFJBPECLKJ GHPLINIACBB) =>
			{
				//0x12C6BD0
				return GHPLINIACBB.PPFNGGCBJKC_Id == KMGIPOILLDN;
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
						save.PKPLOGBIDIG_Prizes[a].JBDBPCMMBIH_Id = evDb.PKPLOGBIDIG_Prizes[i].PPFNGGCBJKC_Id;
						save.PKPLOGBIDIG_Prizes[a].AGKANHNHECE_Remain = evDb.PKPLOGBIDIG_Prizes[i].ADPPAIPFHML_Num;
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
	// public void POENJMJMDPM(int IMMDGJAOPCD) { }

	// // RVA: 0x12C2F8C Offset: 0x12C2F8C VA: 0x12C2F8C
	public void GALFOGJIDMK(ref List<MDBEKHIHBJM> HFNLAEHDODI, int IMMDGJAOPCD/* = 0*/)
	{
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
			ALIPBIMCAPN_EventBoxGacha.GLNFOMDKJJH save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MMAIJOCPJHP_EventBoxGacha.FBCJICEPLED[evDb.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			if(IMMDGJAOPCD < 1)
				IMMDGJAOPCD = save.IMMDGJAOPCD_BoxId;
			IMDBGDNPLJA_EventBoxGacha.NEFJBPECLKJ box = evDb.KGDBEMPMAIJ_Boxes.Find((IMDBGDNPLJA_EventBoxGacha.NEFJBPECLKJ GHPLINIACBB) =>
			{
				//0x12C6C08
				return GHPLINIACBB.PPFNGGCBJKC_Id == IMMDGJAOPCD;
			});
			if(box != null)
			{
				HFNLAEHDODI.Clear();
				for(int i = 0; i < save.PKPLOGBIDIG_Prizes.Count; i++)
				{
					if(save.PKPLOGBIDIG_Prizes[i].JBDBPCMMBIH_Id > 0 && save.PKPLOGBIDIG_Prizes[i].JBDBPCMMBIH_Id < evDb.PKPLOGBIDIG_Prizes.Count + 1)
					{
						int idx = save.PKPLOGBIDIG_Prizes[i].JBDBPCMMBIH_Id - 1;
						if(IMMDGJAOPCD == evDb.PKPLOGBIDIG_Prizes[idx].IMMDGJAOPCD_BoxId && evDb.PKPLOGBIDIG_Prizes[idx].PLALNIIBLOF_Enabled == 2)
						{
							MDBEKHIHBJM d = new MDBEKHIHBJM();
							d.JBDBPCMMBIH = save.PKPLOGBIDIG_Prizes[i].JBDBPCMMBIH_Id;
							d.GLCLFMGPMAN_ItemId = evDb.PKPLOGBIDIG_Prizes[idx].GLCLFMGPMAN_ItemId;
							d.HMFFHLPNMPH_Val = evDb.PKPLOGBIDIG_Prizes[idx].JBGEEPFKIGG_Val;
							d.GCEANEOEGMD_Num = evDb.PKPLOGBIDIG_Prizes[idx].ADPPAIPFHML_Num;
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
	public void ELAGEGMIKKK(ref List<MDBEKHIHBJM> HFNLAEHDODI, int IMMDGJAOPCD = 0)
	{
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
			ALIPBIMCAPN_EventBoxGacha.GLNFOMDKJJH save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MMAIJOCPJHP_EventBoxGacha.FBCJICEPLED[evDb.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			if(IMMDGJAOPCD < 1)
				IMMDGJAOPCD = save.IMMDGJAOPCD_BoxId;
			IMDBGDNPLJA_EventBoxGacha.NEFJBPECLKJ box = evDb.KGDBEMPMAIJ_Boxes.Find((IMDBGDNPLJA_EventBoxGacha.NEFJBPECLKJ GHPLINIACBB) =>
			{
				//0x12C6C40
				return GHPLINIACBB.PPFNGGCBJKC_Id == IMMDGJAOPCD;
			});
			if(box != null)
			{
				HFNLAEHDODI.Clear();
				for(int i = 0; i < evDb.PKPLOGBIDIG_Prizes.Count; i++)
				{
					if(IMMDGJAOPCD == evDb.PKPLOGBIDIG_Prizes[i].IMMDGJAOPCD_BoxId && evDb.PKPLOGBIDIG_Prizes[i].PLALNIIBLOF_Enabled == 2)
					{
						MDBEKHIHBJM d = new MDBEKHIHBJM();
						d.JBDBPCMMBIH = i;
						d.GLCLFMGPMAN_ItemId = evDb.PKPLOGBIDIG_Prizes[i].GLCLFMGPMAN_ItemId;
						d.HMFFHLPNMPH_Val = evDb.PKPLOGBIDIG_Prizes[i].JBGEEPFKIGG_Val;
						d.GCEANEOEGMD_Num = evDb.PKPLOGBIDIG_Prizes[i].ADPPAIPFHML_Num;
						d.AGKANHNHECE_Remain = evDb.PKPLOGBIDIG_Prizes[i].ADPPAIPFHML_Num;
						d.AEDMJLGNDHN_IsSp = evDb.PKPLOGBIDIG_Prizes[i].AEDMJLGNDHN_IsSp != 0;
						d.IHLEPGEJNPM_Idx = i;
						HFNLAEHDODI.Add(d);
					}
				}
			}
		}
	}

	// // RVA: 0x12BFB78 Offset: 0x12BFB78 VA: 0x12BFB78
	public void NCEJOLLKDDF()
	{
		PMBEODGMMBB = (uint)(Utility.GetCurrentUnixTime() ^ 0x15ab17a1);
	}

	// // RVA: 0x12C3B34 Offset: 0x12C3B34 VA: 0x12C3B34
	// private int HEPEDNJMCFA(int HKICMNAACDA, int BNKHBCBJBKI) { }

	// // RVA: 0x12C3B68 Offset: 0x12C3B68 VA: 0x12C3B68
	private void DLPHPGJCAAF(List<PCCHKHKKLPM> NNDGIAEFMOG)
	{
		if(NNDGIAEFMOG != null)
		{
			for(int i = 0; i < NNDGIAEFMOG.Count; i++)
			{
				PMBEODGMMBB ^= PMBEODGMMBB << 0xd;
				PMBEODGMMBB ^= PMBEODGMMBB >> 0x11;
				PMBEODGMMBB ^= PMBEODGMMBB << 5;
				int idx = ((int)PMBEODGMMBB & 0x7fffffff) % NNDGIAEFMOG.Count;
				PCCHKHKKLPM d = NNDGIAEFMOG[i];
				NNDGIAEFMOG[i] = NNDGIAEFMOG[idx];
				NNDGIAEFMOG[idx] = d;
			}
		}
	}

	// // RVA: 0x12C3CC0 Offset: 0x12C3CC0 VA: 0x12C3CC0
	private bool KOCPLGOAKKG()
	{
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
			ALIPBIMCAPN_EventBoxGacha.GLNFOMDKJJH save /*NHLBKJCPLBL*/ = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MMAIJOCPJHP_EventBoxGacha.FBCJICEPLED[evDb.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			List<PCCHKHKKLPM> l = new List<PCCHKHKKLPM>();
			for(int i = 0; i < JMLKAGOACAE.Count; i++)
			{
                ALIPBIMCAPN_EventBoxGacha.EHDCAEHLLKF prize = save.PKPLOGBIDIG_Prizes.Find((ALIPBIMCAPN_EventBoxGacha.EHDCAEHLLKF GHPLINIACBB) =>
				{
					//0x12C6C78
					return GHPLINIACBB.JBDBPCMMBIH_Id == JMLKAGOACAE[i].JBDBPCMMBIH;
				});
                if (prize != null && prize.AGKANHNHECE_Remain != 0)
				{
					PCCHKHKKLPM p = new PCCHKHKKLPM();
					p.MKNDAOHGOAK = prize.AGKANHNHECE_Remain * 100;
					p.OIPCCBHIKIA = i;
					l.Add(p);
				}
            }
			DLPHPGJCAAF(l);
			int t = 0;
			for(int i = 0; i < l.Count; i++)
			{
				t += l[i].MKNDAOHGOAK;
				l[i].FCDKJAKLGMB = t;
			}
			PMBEODGMMBB = PMBEODGMMBB ^ (PMBEODGMMBB << 0xd);
			PMBEODGMMBB = PMBEODGMMBB ^ (PMBEODGMMBB >> 0x11);
			PMBEODGMMBB = PMBEODGMMBB ^ (PMBEODGMMBB << 5);
			int v = (int)(PMBEODGMMBB & 0x7fffffff) % t;
			int found = 0;
			for(int i = 0; i < l.Count; i++)
			{
				found = i;
				if(l[i].FCDKJAKLGMB > v)
					break;
			}
			int ticketId = evDb.KGDBEMPMAIJ_Boxes[save.IMMDGJAOPCD_BoxId - 1].GLCLFMGPMAN_ItemId;
			int num = EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(ticketId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(ticketId), null);
			num -= evDb.KGDBEMPMAIJ_Boxes[save.IMMDGJAOPCD_BoxId - 1].NDNHKMJPBCM_Cost;
			if(num < 0)
				num = 0;
			EKLNMHFCAOI.DPHGFMEPOCA_SetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(ticketId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(ticketId), num, null);
            MDBEKHIHBJM m = JMLKAGOACAE[l[found].OIPCCBHIKIA]; // PKPLOGBIDIG
			ALIPBIMCAPN_EventBoxGacha.EHDCAEHLLKF savePrize = save.PKPLOGBIDIG_Prizes.Find((ALIPBIMCAPN_EventBoxGacha.EHDCAEHLLKF GHPLINIACBB) =>
			{
				//0x12C6CD4
				return GHPLINIACBB.JBDBPCMMBIH_Id == m.JBDBPCMMBIH;
			});
			if(savePrize != null)
			{
				if(savePrize.AGKANHNHECE_Remain > 0)
					savePrize.AGKANHNHECE_Remain--;
                IMDBGDNPLJA_EventBoxGacha.BKGONBEMGED dbPrize = evDb.PKPLOGBIDIG_Prizes[m.JBDBPCMMBIH - 1];
                OGNKHBFKHIP.Length = 0;
				OGNKHBFKHIP.Append(PGIIDPEGGPI_EventId);
				OGNKHBFKHIP.Append(':');
				OGNKHBFKHIP.Append(evDb.KGDBEMPMAIJ_Boxes[save.IMMDGJAOPCD_BoxId - 1].PPFNGGCBJKC_Id);
				OGNKHBFKHIP.Append(':');
				OGNKHBFKHIP.Append(m.JBDBPCMMBIH);
				OGNKHBFKHIP.Append(':');
				OGNKHBFKHIP.Append(savePrize.AGKANHNHECE_Remain);
				OGNKHBFKHIP.Append(':');
				OGNKHBFKHIP.Append(dbPrize.ADPPAIPFHML_Num);
				JANMJPOKLFL_InventoryUtil.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.GMOLAHOIJHE_16, OGNKHBFKHIP.ToString());
				JANMJPOKLFL_InventoryUtil.CPIICACGNBH_AddItem(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, dbPrize.GLCLFMGPMAN_ItemId, dbPrize.JBGEEPFKIGG_Val, null, 0);
				if(dbPrize.AEDMJLGNDHN_IsSp != 0)
				{
					save.FEFCFGNGPGC_Pickup++;
				}
				FMAHFJGBHMG f = new FMAHFJGBHMG();
				f.PPFNGGCBJKC = dbPrize.PPFNGGCBJKC_Id;
				f.JNGNONNJLBM = l[found].OIPCCBHIKIA;
				f.KIJAPOFAGPN_ItemId = dbPrize.GLCLFMGPMAN_ItemId;
				f.HMFFHLPNMPH_Cnt = dbPrize.JBGEEPFKIGG_Val;
				f.AEDMJLGNDHN = dbPrize.AEDMJLGNDHN_IsSp != 0;
				f.CONGLCLANMP_Remain = savePrize.AGKANHNHECE_Remain;
				f.FPFKNDKENIC = dbPrize.ADPPAIPFHML_Num;
				PNLJHCDHKCP_LotResult.Add(f);
			}
			return true;
        }
		return false;
	}

	// // RVA: 0x12C49DC Offset: 0x12C49DC VA: 0x12C49DC
	public bool KOCPLGOAKKG(int LAJNCHHNLBI)
	{
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
			ALIPBIMCAPN_EventBoxGacha.GLNFOMDKJJH save /*NHLBKJCPLBL*/ = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MMAIJOCPJHP_EventBoxGacha.FBCJICEPLED[evDb.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			IMDBGDNPLJA_EventBoxGacha.NEFJBPECLKJ box = evDb.KGDBEMPMAIJ_Boxes.Find((IMDBGDNPLJA_EventBoxGacha.NEFJBPECLKJ GHPLINIACBB) =>
			{
				//0x12C6D30
				return GHPLINIACBB.PPFNGGCBJKC_Id == save.IMMDGJAOPCD_BoxId;
			});
			if(box != null)
			{
				PNLJHCDHKCP_LotResult.Clear();
				JANMJPOKLFL_InventoryUtil.JCHLONCMPAJ();
				OGNKHBFKHIP = new StringBuilder();
				if(box.NDNHKMJPBCM_Cost <= EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(box.GLCLFMGPMAN_ItemId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(box.GLCLFMGPMAN_ItemId), null))
				{
					int a = LAJNCHHNLBI;
					if(LAJNCHHNLBI > 0)
					{
						do
						{
							KOCPLGOAKKG();
							a--;
						} while(a != 0);
					}
					OGNKHBFKHIP = null;
					ILCCJNDFFOB.HHCJCDFCLOB.LIPHGGFEJFJ(box.PPFNGGCBJKC_Id, LAJNCHHNLBI, IPOENPPBFNK(), MPJNMBFIJMB(), box.GLCLFMGPMAN_ItemId, box.NDNHKMJPBCM_Cost * LAJNCHHNLBI, EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(box.GLCLFMGPMAN_ItemId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(box.GLCLFMGPMAN_ItemId), null), this);
					return true;
				}
			}
		}
		return false;
	}

	// // RVA: 0x12C55D0 Offset: 0x12C55D0 VA: 0x12C55D0
	public bool BEDCLNJIEGF(long JHNMKKNEENE)
	{
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
			return evDb.NGHKJOEDLIP.PHKLJGNMFBL >= JHNMKKNEENE && JHNMKKNEENE >= evDb.NGHKJOEDLIP.OHGDNJLFDFF;
		}
		return DPJCPDKALGI_RankingEnd >= JHNMKKNEENE && JHNMKKNEENE >= GLIMIGNNGGB_RankingStart;
	}

	// // RVA: 0x12C57C0 Offset: 0x12C57C0 VA: 0x12C57C0
	// public long ANFFEFDMOIL(long JHNMKKNEENE) { }

	// // RVA: 0x12C4F5C Offset: 0x12C4F5C VA: 0x12C4F5C
	public int IPOENPPBFNK()
	{
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
			ALIPBIMCAPN_EventBoxGacha.GLNFOMDKJJH save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MMAIJOCPJHP_EventBoxGacha.FBCJICEPLED[evDb.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
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
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
            //ALIPBIMCAPN_EventBoxGacha.GLNFOMDKJJH save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MMAIJOCPJHP_EventBoxGacha.FBCJICEPLED[evDb.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			int res = 0;
			for(int i = 0; i < JMLKAGOACAE.Count; i++)
			{
				res += evDb.PKPLOGBIDIG_Prizes[JMLKAGOACAE[i].JBDBPCMMBIH - 1].ADPPAIPFHML_Num;
			}
			return res;
		}
		return 0;
	}

	// // RVA: 0x12C57F4 Offset: 0x12C57F4 VA: 0x12C57F4
	public int BCMFJLFDLND_GetNumUseItemForCurrentBox()
	{
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
            ALIPBIMCAPN_EventBoxGacha.GLNFOMDKJJH save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MMAIJOCPJHP_EventBoxGacha.FBCJICEPLED[evDb.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
            IMDBGDNPLJA_EventBoxGacha.NEFJBPECLKJ box = evDb.KGDBEMPMAIJ_Boxes.Find((IMDBGDNPLJA_EventBoxGacha.NEFJBPECLKJ GHPLINIACBB) =>
			{
				//0x12C6D88
				return GHPLINIACBB.PPFNGGCBJKC_Id == save.IMMDGJAOPCD_BoxId;
			});
            if (box != null)
			{
				return EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(box.GLCLFMGPMAN_ItemId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(box.GLCLFMGPMAN_ItemId), null);
			}
		}
		return 0;
	}

	// // RVA: 0x12C5BB4 Offset: 0x12C5BB4 VA: 0x12C5BB4
	public IMDBGDNPLJA_EventBoxGacha.NEFJBPECLKJ DIACKBHMKEH_GetCurrentBoxInfo()
	{
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
            ALIPBIMCAPN_EventBoxGacha.GLNFOMDKJJH save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MMAIJOCPJHP_EventBoxGacha.FBCJICEPLED[evDb.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			return evDb.KGDBEMPMAIJ_Boxes.Find((IMDBGDNPLJA_EventBoxGacha.NEFJBPECLKJ GHPLINIACBB) =>
			{
				//0x12C6DE0
				return GHPLINIACBB.PPFNGGCBJKC_Id == save.IMMDGJAOPCD_BoxId;
			});
		}
		return null;
	}

	// // RVA: 0x12C5F00 Offset: 0x12C5F00 VA: 0x12C5F00
	public int GOIJBILEHPD_GetSaveBoxCnt()
	{
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
            ALIPBIMCAPN_EventBoxGacha.GLNFOMDKJJH save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MMAIJOCPJHP_EventBoxGacha.FBCJICEPLED[evDb.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			return save.NNCCGILOOIE_BoxCnt;
		}
		return 0;
	}

	// // RVA: 0x12C61B0 Offset: 0x12C61B0 VA: 0x12C61B0
	public MDBEKHIHBJM DGBCMNLEDEI()
	{
		IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as IMDBGDNPLJA_EventBoxGacha;
		if(evDb != null)
		{
            ALIPBIMCAPN_EventBoxGacha.GLNFOMDKJJH save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MMAIJOCPJHP_EventBoxGacha.FBCJICEPLED[evDb.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			List<IMDBGDNPLJA_EventBoxGacha.BKGONBEMGED> l = evDb.PKPLOGBIDIG_Prizes.FindAll((IMDBGDNPLJA_EventBoxGacha.BKGONBEMGED GHPLINIACBB) =>
			{
				//0x12C67BC
				return GHPLINIACBB.AEDMJLGNDHN_IsSp != 0;
			});
			MDBEKHIHBJM res = null;
			for(int i = 0; i < l.Count; i++)
			{
				if(l[i].PLALNIIBLOF_Enabled == 2)
				{
					if(res == null)
					{
						res = new MDBEKHIHBJM();
						res.JBDBPCMMBIH = l[i].PPFNGGCBJKC_Id;
						res.GLCLFMGPMAN_ItemId = l[i].GLCLFMGPMAN_ItemId;
						res.HMFFHLPNMPH_Val = l[i].JBGEEPFKIGG_Val;
						res.GCEANEOEGMD_Num = l[i].ADPPAIPFHML_Num;
						res.AGKANHNHECE_Remain = l[i].ADPPAIPFHML_Num - save.FEFCFGNGPGC_Pickup;
						res.AEDMJLGNDHN_IsSp = true;
					}
					else if(res.GLCLFMGPMAN_ItemId == l[i].GLCLFMGPMAN_ItemId)
					{
						res.GCEANEOEGMD_Num += l[i].ADPPAIPFHML_Num;
						res.AGKANHNHECE_Remain = res.GCEANEOEGMD_Num - save.FEFCFGNGPGC_Pickup;
					}
				}
			}
			return res;
        }
		return null;
	}
}
