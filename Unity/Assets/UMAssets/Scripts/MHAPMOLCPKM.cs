
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using XeApp.Game.Common;
using XeSys;

public class PKADMPNDMGP : AKIIJBEJOEP
{
	public int JONPKLHMOBL_Category; // 0x94
	public int MKNDAOHGOAK_Weight; // 0x98
	public int EIOFPIHABFC_Pts; // 0x9C
	public int IAGDDKLKGJN; // 0xA0
	public string DCOFJKBIOAH_Desc2; // 0xA4

	// // RVA: 0x938F0C Offset: 0x938F0C VA: 0x938F0C
	// public void KHEKNNFCAOI(string JOPOPMLFINI, int PPFNGGCBJKC, int KNEFBLHBDBG, EDOHBJAPLPF IDLHJIOMJBK) { }

	// // RVA: 0x9390C8 Offset: 0x9390C8 VA: 0x9390C8
	public new void KHEKNNFCAOI(string JOPOPMLFINI, int PPFNGGCBJKC, int KNEFBLHBDBG, HGHOHICGBEP JMHECKKKMLK)
    {
        base.IFMHPIGMJBC(JOPOPMLFINI, PPFNGGCBJKC, KNEFBLHBDBG, JMHECKKKMLK);
        JONPKLHMOBL_Category = JMHECKKKMLK.DGPHHJCPNOO[PPFNGGCBJKC - 1].JONPKLHMOBL;
        MKNDAOHGOAK_Weight = JMHECKKKMLK.DGPHHJCPNOO[PPFNGGCBJKC - 1].MKNDAOHGOAK;
        EIOFPIHABFC_Pts = JMHECKKKMLK.DGPHHJCPNOO[PPFNGGCBJKC - 1].EIOFPIHABFC;
        DCOFJKBIOAH_Desc2 = JMHECKKKMLK.DGPHHJCPNOO[PPFNGGCBJKC - 1].DCOFJKBIOAH;
        IAGDDKLKGJN = JMHECKKKMLK.DGPHHJCPNOO[PPFNGGCBJKC - 1].IAGDDKLKGJN;
    }

	// // RVA: 0x939218 Offset: 0x939218 VA: 0x939218
	// public uint CAOGDCBPBAN() { }
}

[System.Obsolete("Use MHAPMOLCPKM_EventQuest", true)]
public class MHAPMOLCPKM {}
public class MHAPMOLCPKM_EventQuest : IKDICBBFBMI_EventBase
{
    public class NEJFNBKMPFD
    {
        public int AMCCOGJACPK_CardId; // 0x8
        public int AKNELONELJK_Diff; // 0xC
        public int DCACDLIAJJK_Pts; // 0x10
        public int FPEOGFMKMKJ; // 0x14
        public int INDKDHNKFAB; // 0x18
        public int ANOCILKJGOJ_EpiCnt; // 0x1C
        public int ODCLHPGHDHA_EpiBonus; // 0x20
        public int JKFCHNEININ; // 0x24
        public int BPJEOPHAJPP_PrevPoint; // 0x28
        public int AHOKAPCGJMA_NewPoint; // 0x2C
        public string KLMPFGOCBHC_Desc; // 0x30
        public string NLEEDNLHBGP_Desc2; // 0x34
        public bool KIFJKGDBDBH; // 0x38
        public int GHBPLHBNMBK_FId; // 0x3C
        public int FCLGIPFPIPH; // 0x40
        public bool PHOPDCNFFEI; // 0x44
    }

    public class BPKELFJPFEB
    {
        public int AMCCOGJACPK; // 0x8
        public int FFECGHGBMIO; // 0xC
        public int KKECHANCHJO; // 0x10
        public int GHBPLHBNMBK; // 0x14
        public bool PHOPDCNFFEI; // 0x18
        public int FCLGIPFPIPH; // 0x1C
    }
 
    private class HBHLOOKPPHM
    {
        public int OIPCCBHIKIA_Idx; // 0x8
        public int MKNDAOHGOAK_Weight; // 0xC
        public int FCDKJAKLGMB_Sum; // 0x10
        public int GHBPLHBNMBK; // 0x14
    }

	private const int GHJHJDIDCFA = 3;
	private EECOJKDJIFG KBACNOCOANM; // 0xE8
	private bool GAKPAELDIKN; // 0xF4
	public bool KDDBNAIJKAD_ResetDisable; // 0xF5
	public bool FAJNDPEKHAA_LuckyDisable; // 0xF6
	public bool DBAEGNENPID_FailPointDisable; // 0xF7
	public bool KIBBLLADDPO; // 0xF8

	public override OHCAABOMEOF.KGOGMKMBCPP_EventType HIDHLFCBIDE_EventType { get { return OHCAABOMEOF.KGOGMKMBCPP_EventType.MKKOHBGHADL_EventQuest_2; } } //0x131A378 DKHCGLCNKCD  Slot: 4
	public NEJFNBKMPFD JMEHHJKCGNJ { get; set; } // 0xEC CEEFAJMOLEL CBJKEBHEING BHECNGDGKGE
	public BPKELFJPFEB PIBIGCIMJGC { get; set; } // 0xF0 FONBCBLHDOE JMIJMBFCKPI EBKMCGCHOMP

	// RVA: 0x131A3A0 Offset: 0x131A3A0 VA: 0x131A3A0 Slot: 32
	public override EECOJKDJIFG DAKMIKNKHMF_GetRankingInfoForIndex(int LHJCOPMMIGO/* = 0*/)
    {
        return KBACNOCOANM;
    }

	// RVA: 0x131A3A8 Offset: 0x131A3A8 VA: 0x131A3A8
	public MHAPMOLCPKM_EventQuest(string OPFGFINHFCE) : base(OPFGFINHFCE)
    {
        return;
    }

	// RVA: 0x131A434 Offset: 0x131A434 VA: 0x131A434 Slot: 5
	public override string IFKKBHPMALH()
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            return ev.NGHKJOEDLIP_Settings.OCDMGOGMHGE;
        }
        return null;
    }

	// RVA: 0x131A5BC Offset: 0x131A5BC VA: 0x131A5BC Slot: 27
	public override int HLOGNJNGDJO_GetHelpId(int OIPCCBHIKIA/* = 0*/)
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            return ev.NGHKJOEDLIP_Settings.EJBGHLOOLBC_HelpIds[OIPCCBHIKIA];
        }
        return 0;
    }

	// RVA: 0x131A778 Offset: 0x131A778 VA: 0x131A778 Slot: 67
	//public override int LBNKDKDMMOK() { }

	// RVA: 0x131A8FC Offset: 0x131A8FC VA: 0x131A8FC Slot: 28
	public override long FBGDBGKNKOD_GetCurrentPoint()
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LMBBEGIAKAD_EventQuest;
        if(ev != null && GPHEKCNDDIK)
        {
            OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
            return save.DNBFMLBNAEE_Point;
        }
        return 0;
    }

	// RVA: 0x131AB5C Offset: 0x131AB5C VA: 0x131AB5C Slot: 29
	public override void MJFKJHJJLMN_GetRanks(int LHJCOPMMIGO/* = 0*/, bool FBBNPFFEJBN/* = False*/)
    {
        NPNNPNAIONN = false;
        PLOOEECNHFB = false;
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LMBBEGIAKAD_EventQuest;
        if(ev != null && GPHEKCNDDIK)
        {
            if(FBBNPFFEJBN || NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime() - KPOMHFLKMKI_LastRankUpdateTime[LHJCOPMMIGO] >= IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("get_rank_cooling_time", 60))
            {
                KKLGENJKEBN.HHCJCDFCLOB.HEOKADCEAGL_GetRanks(ev.NGHKJOEDLIP_Settings.OCGFKMHNEOF, () =>
                {
                    //0x1326FBC
                    CDINKAANIAA_Rank[LHJCOPMMIGO] = (int)KKLGENJKEBN.HHCJCDFCLOB.LPPCNCMEDFA_Rank;
                    KPOMHFLKMKI_LastRankUpdateTime[LHJCOPMMIGO] = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
                    PLOOEECNHFB = true;
                }, () =>
                {
                    //0x1327180
                    KPOMHFLKMKI_LastRankUpdateTime[LHJCOPMMIGO] = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
                    CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
                    PLOOEECNHFB = true;
                }, () =>
                {
                    //0x1327328
                    CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
                    PLOOEECNHFB = true;
                    NPNNPNAIONN = true;
                }, () =>
                {
                    //0x13273C0
                    CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
                    PLOOEECNHFB = true;
                    FKKDIDMGLMI = true;
                });
                return;
            }
        }
        else
            CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
        PLOOEECNHFB = true;
    }

	// RVA: 0x131B03C Offset: 0x131B03C VA: 0x131B03C Slot: 30
	protected override bool JIHMLILFOPG_IsEventActive(long JHNMKKNEENE)
    {
        LMBBEGIAKAD_EventQuest ev/*DBIHIEBCMNC*/ = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            GDIPLANPCEI g = IMMAOANGPNK.HHCJCDFCLOB.ACEFBFLFKFD_GetScheduleEventData(ev.JIKKNHIAEKG_BlockName, JHNMKKNEENE);
            if(g != null)
            {
                if(JHNMKKNEENE >= ev.NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart)
                {
                    if(ev.NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2 >= JHNMKKNEENE)
                    {
                        if(ev.NGHKJOEDLIP_Settings.HKKNEAGCIEB != 0)
                        {
                            if(KKLGENJKEBN.HHCJCDFCLOB.JPDPFGFMKHK.Find((EECOJKDJIFG PKLPKMLGFGK) =>
                            {
                                //0x1327458
                                return ev.NGHKJOEDLIP_Settings.OCGFKMHNEOF == PKLPKMLGFGK.OCGFKMHNEOF_NameForApi;
                            }) == null)
                            {
                                UnityEngine.Debug.LogError("Missing event ranking "+ev.NGHKJOEDLIP_Settings.OCGFKMHNEOF);
                                return false;
                            }
                        }
                        return true;
                    }
                }
            }
        }
        return false;
    }

	// RVA: 0x131B360 Offset: 0x131B360 VA: 0x131B360 Slot: 31
	protected override bool IMCMNOPNGHO(long JHNMKKNEENE)
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
            AGLILDLEFDK_Missions = ev.NNMPGOAGEOL_Missions;
            OLDFFDMPEBM_Quests = save.NNMPGOAGEOL_Quests;
            if(save.MPCAGEPEJJJ_Key != ev.NGHKJOEDLIP_Settings.OCGFKMHNEOF || save.EGBOHDFBAPB_End == 0 || (!RuntimeSettings.CurrentSettings.UnlimitedEvent && save.EGBOHDFBAPB_End < ev.NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart))
            {
                save.LHPDDGIJKNB();
                save.MPCAGEPEJJJ_Key = ev.NGHKJOEDLIP_Settings.OCGFKMHNEOF;
                save.EGBOHDFBAPB_End = ev.NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd;
                save.LGADCGFMLLD_Step = 1;
                save.BEBJKJKBOGH_Date = JHNMKKNEENE;
                KOMAHOAEMEK(true);
            }
            KOMAHOAEMEK(false);
            return true;
        }
        return false;
    }

	// RVA: 0x131B6BC Offset: 0x131B6BC VA: 0x131B6BC Slot: 40
	protected override void KKFLDCBHFJA(long JHNMKKNEENE)
    {
        LMBBEGIAKAD_EventQuest ev/*DBIHIEBCMNC*/ = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            IBNKPMPFLGI_IsRankReward = ev.NGHKJOEDLIP_Settings.HKKNEAGCIEB != 0;
            if(IBNKPMPFLGI_IsRankReward)
            {
                KBACNOCOANM = KKLGENJKEBN.HHCJCDFCLOB.JPDPFGFMKHK.Find((EECOJKDJIFG PKLPKMLGFGK) =>
                {
                    //0x13274B8
                    return ev.NGHKJOEDLIP_Settings.OCGFKMHNEOF == PKLPKMLGFGK.OCGFKMHNEOF_NameForApi;
                });
                GPHEKCNDDIK = true;
            }
            DGCOMDILAKM_EventName = ev.NGHKJOEDLIP_Settings.OPFGFINHFCE_Name;
            DOLJEDAAKNN_RankingName = ev.NGHKJOEDLIP_Settings.HEDAGCNPHGD_RankingName;
            GLIMIGNNGGB_RankingStart = ev.NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
            DPJCPDKALGI_RankingEnd = ev.NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;
            LOLAANGCGDO_RankingEnd2 = ev.NGHKJOEDLIP_Settings.LNFKGHNHJKE_RankingEnd2;
            JDDFILGNGFH_RewardStart = ev.NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart;
            LJOHLEGGGMC_RewardEnd = ev.NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd;
            EMEKFFHCHMH_RewardEnd2 = ev.NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2;
            PGIIDPEGGPI_EventId = ev.NGHKJOEDLIP_Settings.OBGBAOLONDD_EventId;
            NHGPCLGPEHH_TicketType = ev.NGHKJOEDLIP_Settings.MJBKGOJBPAD_TicketType;
            FBHONHONKGD_MusicSelectDesc = ev.NGHKJOEDLIP_Settings.FEMMDNIELFC_MusicSelectDesc;
            HGLAFGHHFKP = ev.NGHKJOEDLIP_Settings.JHPCPNJJHLI;
            GFIBLLLHMPD_StartAdventureId = ev.NGHKJOEDLIP_Settings.HIOOGLEJBKM_StartAdventureId;
            CAKEOPLJDAF_EndAdventureId = ev.NGHKJOEDLIP_Settings.FJCADCDNPMP_EndAdventureId;
            KDDBNAIJKAD_ResetDisable = BAEPGOAMBDK("reset_disable", 0) != 0;
            DBAEGNENPID_FailPointDisable = BAEPGOAMBDK("fail_point_disable", 0) != 0;
            FAJNDPEKHAA_LuckyDisable = BAEPGOAMBDK("lucky_disable", 0) != 0;
            LHAKGDAGEMM_EpBonusInfos.Clear();
            for(int i = 0; i < ev.LHAKGDAGEMM_EpBonusInfo.Count; i++)
            {
                CEGDBNNIDIG c = new CEGDBNNIDIG();
                c.KELFCMEOPPM_EpId = ev.LHAKGDAGEMM_EpBonusInfo[i].KHPHAAMGMJP_EpId;
                c.MIHNKIHNBBL_BaseBonus = ev.LHAKGDAGEMM_EpBonusInfo[i].OFIAENKCJME_BaseBonus / 100.0f;
                c.MLLPMJFOKEC_GachaIds.AddRange(ev.LHAKGDAGEMM_EpBonusInfo[i].KDNMBOBEGJM_GachaIds);
                LHAKGDAGEMM_EpBonusInfos.Add(c);
            }
            PGDAMNENGDA_EpBonusBySceneRarity.Clear();
            for(int i = 0; i < ev.OGMHMAGDNAM_EpBonusBySceneRarity.Count; i++)
            {
                NJJDBBCHBNP n = new NJJDBBCHBNP();
                n.GJEADBKFAPA = ev.OGMHMAGDNAM_EpBonusBySceneRarity[i].PPFNGGCBJKC;
                n.IJKFFIKGLJM_BonusBefore = ev.OGMHMAGDNAM_EpBonusBySceneRarity[i].GNFBMCGMCFO_BonusBefore;
                n.DCBMFNOIENM_BonusAfter = ev.OGMHMAGDNAM_EpBonusBySceneRarity[i].BFFGFAMJAIG_BonusAfter;
                PGDAMNENGDA_EpBonusBySceneRarity.Add(n);
            }
            DHOMAEOEFMJ_EpBonuByScene.Clear();
            for(int i = 0; i < ev.GEGAEDDGNMA_EpBonusByScene.Count; i++)
            {
                MEBJJBHPMEO m = new MEBJJBHPMEO();
                m.PPFNGGCBJKC = ev.GEGAEDDGNMA_EpBonusByScene[i].PPFNGGCBJKC;
                m.GNFBMCGMCFO_BonusBefore = ev.GEGAEDDGNMA_EpBonusByScene[i].GNFBMCGMCFO_BonusBefore;
                m.BFFGFAMJAIG_BonusAfter = ev.GEGAEDDGNMA_EpBonusByScene[i].BFFGFAMJAIG_BonusAfter;
                m.CNKFPJCGNFE_SceneId = ev.GEGAEDDGNMA_EpBonusByScene[i].CNKFPJCGNFE_SceneId;
                DHOMAEOEFMJ_EpBonuByScene.Add(m);
            }
            MBHDIJJEOFL = ev.MBHDIJJEOFL;
            LEPALMDKEOK_IsPointReward = true;
            PJLNJJIBFBN = ev.NGHKJOEDLIP_Settings.AHKPNPNOAMO != 0;
            for(int i = 0; i < KPOMHFLKMKI_LastRankUpdateTime.Length; i++)
            {
                KPOMHFLKMKI_LastRankUpdateTime[i] = 0;
            }
            if(!string.IsNullOrEmpty(ev.NGHKJOEDLIP_Settings.OMCAOJJGOGG))
            {
                string[] strs = ev.NGHKJOEDLIP_Settings.OMCAOJJGOGG.Split(new char[]{','});
                MFDJIFIIPJD m = new MFDJIFIIPJD();
                m.KHEKNNFCAOI(int.Parse(strs[0]), int.Parse(strs[1]));
                BHABCGJCGNO = m;
            }
            GPHEKCNDDIK = true;
        }
    }

	// RVA: 0x131C440 Offset: 0x131C440 VA: 0x131C440 Slot: 43
	protected override void FCHGHAAPIBH()
    {
        LMBBEGIAKAD_EventQuest ev/*NDFIEMPPMLF*/ = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            Dictionary<string,int> DBEKEBNDMBH = new Dictionary<string, int>();
            List<string> ls = new List<string>(20);
            string str = ev.NGHKJOEDLIP_Settings.OCDMGOGMHGE;
            for(int i = 0; i < ev.FCIPEDFHFEM.Count; i++)
            {
                for(int j = 0; j < ev.FCIPEDFHFEM[i].AHJNPEAMCCH.Count; j++)
                {
                    if(ev.FCIPEDFHFEM[i].AHJNPEAMCCH[j].NMKEOMCMIPP > 0)
                    {
                        string s = str + ev.FCIPEDFHFEM[i].AHJNPEAMCCH[j].NMKEOMCMIPP.ToString();
                        ls.Add(s);
                        DBEKEBNDMBH.Add(s, i);
                    }
                }
            }
            if(ls.Count == 0)
            {
                PIMFJALCIGK();
                PLOOEECNHFB = true;
            }
            else
            {
                JGMEFHJCNHP_GetAchievementRecords req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new JGMEFHJCNHP_GetAchievementRecords());
                req.KMOBDLBKAAA_Repeatable = true;
                req.MIDAMHNABAJ_Keys = ls;
                req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request NHECPMNKEFK) =>
                {
                    //0x1327518
                    JGMEFHJCNHP_GetAchievementRecords r = NHECPMNKEFK as JGMEFHJCNHP_GetAchievementRecords;
                    OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
                    for(int i = 0; i < r.NFEAMMJIMPG.CEDLLCCONJP.Count; i++)
                    {
                        if(DBEKEBNDMBH.ContainsKey(r.NFEAMMJIMPG.CEDLLCCONJP[i].LJNAKDMILMC_Key))
                        {
                            if(r.NFEAMMJIMPG.CEDLLCCONJP[i].OOIJCMLEAJP_IsReceived)
                            {
                                save.LCDIGDMGPGO_TRcv[DBEKEBNDMBH[r.NFEAMMJIMPG.CEDLLCCONJP[i].LJNAKDMILMC_Key]] = 1;
                            }
                        }
                    }
                    PIMFJALCIGK();
                    PLOOEECNHFB = true;
                };
                req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request NHECPMNKEFK) =>
                {
                    //0x13279D0
                    PLOOEECNHFB = true;
                    NPNNPNAIONN = true;
                };
            }
        }
        else
        {
            PLOOEECNHFB = true;
        }
    }

	// RVA: 0x131CAFC Offset: 0x131CAFC VA: 0x131CAFC Slot: 46
	protected override void PJDGDNJNCNM_UpdateStatusImpl(long JHNMKKNEENE)
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            KIBBLLADDPO = false;
            OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
            IBLPKJJNNIG = false;
            BELBNINIOIE = false;
            if(JHNMKKNEENE >= ev.NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart)
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
                    if(!save.IMFBCJOIJKJ_Entry)
                    {
                        NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2;
                        if(JHNMKKNEENE < ev.NGHKJOEDLIP_Settings.EHHFFKAFOMC)
                            return;
                        KIBBLLADDPO = true;
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
                        return;
                    }
                    if(!save.ABBJBPLHFHA_Spurt)
                    {
                        if(JHNMKKNEENE >= ev.NGHKJOEDLIP_Settings.EHHFFKAFOMC)
                        {
                            NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.GDOPLACICFE_4;
                            KIBBLLADDPO = true;
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
                            return;
                        }
                        NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MINDIGBAJFG_3;
                    }
                    else
                    {
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
                        NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_ChallengePeriod_5;
                    }
                }
                else
                {
                    if(JHNMKKNEENE >= ev.NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart)
                    {
                        if(JHNMKKNEENE >= ev.NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd)
                        {
                            if(JHNMKKNEENE >= ev.NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2)
                            {
                                NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.DOAENCHBAEO_11;
                            }
                            else
                            {
                                NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.HINPDNKNAHO_10;
                            }
                        }
                        else
                        {
                            if(!save.HPLMECLKFID_RRcv)
                                NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.DDEODFNANDO_8_ResultRewardToReceive;
                            else
                                NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived;
                        }
                    }
                    else
                    {
                        NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6;
                    }
                }
            }
            else
            {
                NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.FFLKPBPBPEP_1;
            }
        }
        else
        {
            NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.HJNNKCMLGFL_0;
            KIBBLLADDPO = false;
        }
    }

	// RVA: 0x131D150 Offset: 0x131D150 VA: 0x131D150 Slot: 47
	public override void NBMDAOFPKGK(int DNBFMLBNAEE)
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
            save.DNBFMLBNAEE_Point += DNBFMLBNAEE;
            save.NFIOKIBPJCJ_Uptime = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
        }
    }

	// RVA: 0x131D4A0 Offset: 0x131D4A0 VA: 0x131D4A0 Slot: 49
	protected override void ODPJGHOJIOH(int LHJCOPMMIGO)
    {
        if(KBACNOCOANM != null)
        {
            LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LMBBEGIAKAD_EventQuest;
            if(ev != null)
            {
                OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
                PJDGDNJNCNM_UpdateStatusImpl(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
                if(IBNKPMPFLGI_IsRankReward || NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2 ||
					NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MINDIGBAJFG_3 ||
					NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_ChallengePeriod_5 ||
					NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6) //0x6cU
				{
                    KKLGENJKEBN.HHCJCDFCLOB.LDOBHAAIDEJ_UpdateRankingScore(KBACNOCOANM.OCGFKMHNEOF_NameForApi, LHJCOPMMIGO, BOAGCEOHJEO.GOAOBNBGDBJ(GLIMIGNNGGB_RankingStart, LOLAANGCGDO_RankingEnd2, save.NFIOKIBPJCJ_Uptime, save.DNBFMLBNAEE_Point), () =>
                    {
                        //0x1327A14
                        CDINKAANIAA_Rank[LHJCOPMMIGO] = (int)KKLGENJKEBN.HHCJCDFCLOB.LPPCNCMEDFA_Rank;
                        PLOOEECNHFB = true;
                        int ranking_point_max = ev.LPJLEHAJADA("ranking_point_max", 1000000);
                        ILCCJNDFFOB.HHCJCDFCLOB.NNFGBBCHLPC(PGIIDPEGGPI_EventId, "StringLiteral_10929", EJDJIBPKKNO, save.DNBFMLBNAEE_Point, ranking_point_max, KKLGENJKEBN.HHCJCDFCLOB.DFBALJAPHMC_DroppedPlayer);
                    }, () =>
                    {
                        //0x1327C4C
                        PLOOEECNHFB = true;
                    }, () =>
                    {
                        //0x1327C74
                        PLOOEECNHFB = true;
                        NPNNPNAIONN = true;
                    });
                    return;
                }
            }
        }
        PLOOEECNHFB = true;
    }

	// RVA: 0x131D9C8 Offset: 0x131D9C8 VA: 0x131D9C8 Slot: 50
	protected override void MFJFBNPLFBE_OnReceieveTotalReward(bool GIPBIDFJFLL)
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PMMENILLJJE_EventQuest.PFAKPFKJJKA() == null)
            {
                OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
                JANMJPOKLFL_InventoryUtil.JCHLONCMPAJ();
                JOFBHHHLBBN_Rewards.Clear();
                long point = FBGDBGKNKOD_GetCurrentPoint();
                List<string> ls = new List<string>(3);
                StringBuilder str = new StringBuilder();
                for(int i = 0; i < ev.FCIPEDFHFEM.Count; i++)
                {
                    if(point >= ev.FCIPEDFHFEM[i].DNBFMLBNAEE_Point)
                    {
                        if(!save.BHIAKGKHKGD(i))
                        {
                            str.Length = 0;
                            str.Append(PGIIDPEGGPI_EventId);
                            str.Append(':');
                            str.Append(i);
                            str.Append(':');
                            str.Append(ev.FCIPEDFHFEM[i].DNBFMLBNAEE_Point);
                            JANMJPOKLFL_InventoryUtil.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.MGEFPKOJKBL_9, str.ToString());
                            for(int j = 0; j < ev.FCIPEDFHFEM[i].AHJNPEAMCCH.Count; j++)
                            {
                                if(ev.FCIPEDFHFEM[i].AHJNPEAMCCH[j].NMKEOMCMIPP > 0)
                                {
                                    ls.Add(ev.NGHKJOEDLIP_Settings.OCDMGOGMHGE + ev.FCIPEDFHFEM[i].AHJNPEAMCCH[j].NMKEOMCMIPP.ToString());
                                }
                                JANMJPOKLFL_InventoryUtil.CPIICACGNBH_AddItem(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, ev.FCIPEDFHFEM[i].AHJNPEAMCCH[j].GLCLFMGPMAN, ev.FCIPEDFHFEM[i].AHJNPEAMCCH[j].HMFFHLPNMPH, null, 0);
                                save.IPNLHCLFIDB(i, true);
                            }
                            JOFBHHHLBBN_Rewards.Add(i);
                        }
                    }
                }
                if(ls.Count > 0)
                {
                    FLONELKGABJ_ClaimAchievementPrizes req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new FLONELKGABJ_ClaimAchievementPrizes());
                    req.KMOBDLBKAAA_Repeatable = true;
                    req.MIDAMHNABAJ_Keys = null;
                    req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request NHECPMNKEFK) =>
                    {
                        //0x1326EF4
                        PLOOEECNHFB = true;
                        DENHAAGACPD();
                    };
                    req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request NHECPMNKEFK) =>
                    {
                        //0x1326F00
                        NPNNPNAIONN = true;
                        PLOOEECNHFB = true;
                    };
                    return;
                }
                DENHAAGACPD();
            }
            else
            {
                NPNNPNAIONN = true;
            }
        }
        PLOOEECNHFB = true;
    }

	// RVA: 0x131E800 Offset: 0x131E800 VA: 0x131E800 Slot: 52
	public override void FAMFKPBPIAA_GetRankingPlayerList(bool PFFJNEFNAMI, int CJHEHIMLGGL, int LHJCOPMMIGO, LIOLBKLMMIK KLMFJJCNBIP, DJBHIFLHJLK IDAEHNGOKAE, DJBHIFLHJLK JGKOLBLPMPG)
    {
        NPNNPNAIONN = false;
        PLOOEECNHFB = false;
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            if(IBNKPMPFLGI_IsRankReward)
            {
                KKLGENJKEBN.HHCJCDFCLOB.FAMFKPBPIAA_GetRankingPlayerList(KBACNOCOANM.OCGFKMHNEOF_NameForApi, PFFJNEFNAMI, CJHEHIMLGGL, LHJCOPMMIGO, (int NEFEFHBHFFF, List<IBIGBMDANNM> MAGKKPOFJIM) =>
                {
                    //0x1327CB8
                    PLOOEECNHFB = true;
                    KLMFJJCNBIP(NEFEFHBHFFF, MAGKKPOFJIM);
                }, () =>
                {
                    //0x1327D14
                    PLOOEECNHFB = true;
                    IDAEHNGOKAE();
                }, () =>
                {
                    //0x1327D60
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

	// RVA: 0x131EB38 Offset: 0x131EB38 VA: 0x131EB38 Slot: 53
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
                //0x1327DC4
                PLOOEECNHFB = true;
                KLMFJJCNBIP(JGNBPFCJLKI, MAGKKPOFJIM);
            }, () =>
            {
                //0x1327E20
                PLOOEECNHFB = true;
                IDAEHNGOKAE();
            }, () =>
            {
                //0x1327E6C
                PLOOEECNHFB = true;
                NPNNPNAIONN = true;
                JGKOLBLPMPG();
            }, false);
        }
    }

	// RVA: 0x131ED3C Offset: 0x131ED3C VA: 0x131ED3C
	// private int APJDIPINLLK(List<int> HNLFPKNBOHE, int PPFNGGCBJKC) { }

	// // RVA: 0x131CAAC Offset: 0x131CAAC VA: 0x131CAAC
	private void PIMFJALCIGK()
    {
        int a = NGIHFKHOJOK_GetRankingMax(true);
        for(int i = 0; i < a; i++)
        {
            BJEOAOACMGG(i);
        }
    }

	// // RVA: 0x131EE34 Offset: 0x131EE34 VA: 0x131EE34
	private void BJEOAOACMGG(int LHJCOPMMIGO)
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
            PFPJHJJAGAG_Rewards.Clear();
            EGIPGHCDMII_RankData[LHJCOPMMIGO].Clear();
            if(KBACNOCOANM != null)
            {
                for(int i = 0; i < KBACNOCOANM.AHJNPEAMCCH_Rewards.Count; i++)
                {
                    MAOCCKFAOPC m = new MAOCCKFAOPC();
                    m.JBDGBPAAAEF_HighRank = KBACNOCOANM.AHJNPEAMCCH_Rewards[i].JPHDGGNAKMO_HighRank;
                    m.GHANKNIBALB_LowRank = KBACNOCOANM.AHJNPEAMCCH_Rewards[i].FGCAJEAIABA_LowRank;
                    m.MJGAMDBOMHD_InventoryMessage = KBACNOCOANM.AHJNPEAMCCH_Rewards[i].IPFEKNMBEBI_InventoryMessage;
                    m.HBHMAKNGKFK_Items = KBACNOCOANM.AHJNPEAMCCH_Rewards[i].HBHMAKNGKFK_Items;
                    EGIPGHCDMII_RankData[LHJCOPMMIGO].Add(m);
                }
            }
            for(int i = 0; i < ev.FCIPEDFHFEM.Count; i++)
            {
                IHAEIOAKEMG ih = new IHAEIOAKEMG();
                for(int j = 0; j < ev.FCIPEDFHFEM[i].AHJNPEAMCCH.Count; j++)
                {
                    MFDJIFIIPJD m = new MFDJIFIIPJD();
                    m.KHEKNNFCAOI(ev.FCIPEDFHFEM[i].AHJNPEAMCCH[j].GLCLFMGPMAN, ev.FCIPEDFHFEM[i].AHJNPEAMCCH[j].HMFFHLPNMPH);
                    m.JOPPFEHKNFO_IsGold = ev.FCIPEDFHFEM[i].JOPPFEHKNFO;
                    ih.HBHMAKNGKFK_Items.Add(m);
                }
                ih.HMEOAKCLKJE_IsReceived = save.BHIAKGKHKGD(i);
                ih.FIOIKMOIJGK_Point = ev.FCIPEDFHFEM[i].DNBFMLBNAEE_Point;
                ih.OJELCGDDAOM_MissingPoint = (int)(ih.FIOIKMOIJGK_Point - save.DNBFMLBNAEE_Point);
                PFPJHJJAGAG_Rewards.Add(ih);
            }
        }
    }

	// // RVA: 0x131E4D4 Offset: 0x131E4D4 VA: 0x131E4D4
	private void DENHAAGACPD()
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
            for(int i = 0; i < PFPJHJJAGAG_Rewards.Count; i++)
            {
                PFPJHJJAGAG_Rewards[i].HMEOAKCLKJE_IsReceived = save.BHIAKGKHKGD(i);
                PFPJHJJAGAG_Rewards[i].OJELCGDDAOM_MissingPoint = (int)(PFPJHJJAGAG_Rewards[i].FIOIKMOIJGK_Point - save.DNBFMLBNAEE_Point);
                if(PFPJHJJAGAG_Rewards[i].OJELCGDDAOM_MissingPoint < 0)
                    PFPJHJJAGAG_Rewards[i].OJELCGDDAOM_MissingPoint = 0;
            }
        }
    }

	// RVA: 0x131F68C Offset: 0x131F68C VA: 0x131F68C Slot: 51
	public override IHAEIOAKEMG ILICNKILFKJ_GetNextReward()
    {
        for(int i = 0; i < PFPJHJJAGAG_Rewards.Count; i++)
        {
            if(!PFPJHJJAGAG_Rewards[i].HMEOAKCLKJE_IsReceived)
                return PFPJHJJAGAG_Rewards[i];
        }
        return null;
    }

	// RVA: 0x131F7A0 Offset: 0x131F7A0 VA: 0x131F7A0 Slot: 58
	protected override void LMGMELPOGMH(int LHJCOPMMIGO)
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            if(IBNKPMPFLGI_IsRankReward)
            {
                HLFHJIDHJMP = null;
                OKPEFAPPFDH_GetRanksAroundSelf req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new OKPEFAPPFDH_GetRanksAroundSelf());
                req.EMPNJPMAKBF_Id = KBACNOCOANM.PPFNGGCBJKC_Id;
                req.MJGOBEGONON_Type = 0;
                req.NHPCKCOPKAM_From = 0;
                req.PJFKNNNDMIA_To = 0;
                req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request KCFBGMKDIMI) =>
                {
                    //0x1327ED0
                    if(JGJFFKPFMDB.BDGBCCGLLAJ_IsRankingError(KCFBGMKDIMI.CJMFJOMECKI_ErrorId))
                    {
                        if(KCFBGMKDIMI.CJMFJOMECKI_ErrorId == SakashoErrorId.RANKING_DROPPED_PLAYER)
                        {
                            FKKDIDMGLMI = true;
                        }
                        OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
                        save.HPLMECLKFID_RRcv = true;
                        PJDGDNJNCNM_UpdateStatusImpl(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
                        PLOOEECNHFB = true;
                    }
                    else
                    {
                        PLOOEECNHFB = true;
                        NPNNPNAIONN = true;
                    }
                };
                req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request KCFBGMKDIMI) =>
                {
                    //0x13281FC
                    OKPEFAPPFDH_GetRanksAroundSelf r = KCFBGMKDIMI as OKPEFAPPFDH_GetRanksAroundSelf;
                    if(r.NFEAMMJIMPG.EJDEDOJFOOK.Count == 0)
                    {
                        OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
                        save.HPLMECLKFID_RRcv = true;
                        PJDGDNJNCNM_UpdateStatusImpl(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
                        PLOOEECNHFB = true;
                    }
                    else
                    {
                        HLFHJIDHJMP = new NHGEHCMPDAI();
                        OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
                        save.DNBFMLBNAEE_Point = r.NFEAMMJIMPG.EJDEDOJFOOK[0].KNIFCANOHOC_Score;
                        HLFHJIDHJMP.FJOLNJLLJEJ_Rank = r.NFEAMMJIMPG.EJDEDOJFOOK[0].FJOLNJLLJEJ_Rank;
                        KKLGENJKEBN.HHCJCDFCLOB.DNJKPPCBINA(KBACNOCOANM.OCGFKMHNEOF_NameForApi, () =>
                        {
                            //0x13288D0
                            for(int i = 0; i < KKLGENJKEBN.HHCJCDFCLOB.PHOPJDPEHJA.Count; i++)
                            {
                                MFDJIFIIPJD m = new MFDJIFIIPJD();
                                m.KHEKNNFCAOI(KKLGENJKEBN.HHCJCDFCLOB.PHOPJDPEHJA[i].JJBGOIMEIPF_ItemFullId, KKLGENJKEBN.HHCJCDFCLOB.PHOPJDPEHJA[i].MBJIFDBEDAC_ItemCount);
                                HLFHJIDHJMP.HBHMAKNGKFK.Add(m);
                            }
                            ILCCJNDFFOB.HHCJCDFCLOB.GIBLHFKIMDA(this);
                            OFNLIBDEIFA_EventQuest.GCCDGBBDICM save_ = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
                            save_.HPLMECLKFID_RRcv = true;
                            PLOOEECNHFB = true;
                        }, () =>
                        {
                            //0x1328C48
                            HLFHJIDHJMP = null;
                            ILCCJNDFFOB.HHCJCDFCLOB.GIBLHFKIMDA(this);
                            OFNLIBDEIFA_EventQuest.GCCDGBBDICM save_ = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
                            save_.HPLMECLKFID_RRcv = true;
                            PLOOEECNHFB = true;
                        }, () =>
                        {
                            //0x1328E30
                            OFNLIBDEIFA_EventQuest.GCCDGBBDICM save_ = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
                            save_.HPLMECLKFID_RRcv = true;
                            PLOOEECNHFB = true;
                            HLFHJIDHJMP = null;
                        }, () =>
                        {
                            //0x1328FBC
                            PLOOEECNHFB = true;
                            HLFHJIDHJMP = null;
                        }, () =>
                        {
                            //0x1329004
                            PLOOEECNHFB = true;
                            NPNNPNAIONN = true;
                        }, 0, -1);
                    }
                };
                return;
            }
        }
        PLOOEECNHFB = true;
    }

	// RVA: 0x131FB38 Offset: 0x131FB38 VA: 0x131FB38 Slot: 59
	public override List<int> AEGDKBNNDBC_GetDrops()
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            return ev.NGHKJOEDLIP_Settings.EEOGPJJCKHH_Drops;
        }
        return null;
    }

	// // RVA: 0x131FCBC Offset: 0x131FCBC VA: 0x131FCBC
	// public int NOODJNMIDPN() { }

	// // RVA: 0x131FF18 Offset: 0x131FF18 VA: 0x131FF18
	// public void PNFDENHKMGK(int AKNELONELJK, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG) { }

	// // RVA: 0x13202DC Offset: 0x13202DC VA: 0x13202DC
	// public ALPMEPDDDIP.FDDIFOGNJEF MHPFJFDNILM() { }

	// RVA: 0x1320538 Offset: 0x1320538 VA: 0x1320538 Slot: 65
	protected override bool JLPDECMHLIM_CanShowStartAdventureInternal()
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
            PJDGDNJNCNM_UpdateStatusImpl(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
            if(GFIBLLLHMPD_StartAdventureId != 0)
            {
                if(NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2)
                {
                    return (save.INLNJOGHLJE_Show & 1) == 0;
                }
            }
        }
        return false;
    }

	// RVA: 0x1320874 Offset: 0x1320874 VA: 0x1320874 Slot: 66
	public override void FGDDBFHGCGP_SetStartAdventureShown(bool JKDJCFEBDHC, long JHNMKKNEENE/* = 0*/)
    {
        if(JKDJCFEBDHC)
        {
            LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LMBBEGIAKAD_EventQuest;
            if(ev != null)
            {
                OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
                if(NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2)
                {
                    save.INLNJOGHLJE_Show |= 1;
                }
            }
        }
    }

	// RVA: 0x1320AF4 Offset: 0x1320AF4 VA: 0x1320AF4 Slot: 70
	public override void ADACMHAHHKC_PreSetupEventHome(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
    {
        N.a.StartCoroutineWatched(NJIEIJJMAHK_Corotuine_PreSetupEventHome(BHFHGFKBOHH, AOCANKOMKFG));
    }

	// [IteratorStateMachineAttribute] // RVA: 0x6BD1B4 Offset: 0x6BD1B4 VA: 0x6BD1B4
	// // RVA: 0x1320B4C Offset: 0x1320B4C VA: 0x1320B4C
	private IEnumerator NJIEIJJMAHK_Corotuine_PreSetupEventHome(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
    {
        long IBCGNDADAEE; // 0x20
        LMBBEGIAKAD_EventQuest KEHCNBNPJHB; // 0x28
        OFNLIBDEIFA_EventQuest.GCCDGBBDICM AIPLGDHHAJI; // 0x2C
        int JEKGKAPLIHO; // 0x30

        //0x1329834
        IBCGNDADAEE = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
        JMEHHJKCGNJ = null;
        PIBIGCIMJGC = null;
        LPFJADHHLHG = false;
        KEHCNBNPJHB = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LMBBEGIAKAD_EventQuest;
        if(KEHCNBNPJHB != null)
        {
            PJDGDNJNCNM_UpdateStatusImpl(IBCGNDADAEE);
            MJFKJHJJLMN_GetRanks(0, false);
            while(!PLOOEECNHFB)
                yield return null;
            if(!NPNNPNAIONN)
            {
                AIPLGDHHAJI = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PMMENILLJJE_EventQuest.FBCJICEPLED[KEHCNBNPJHB.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
                if(FKKDIDMGLMI)
                {
                    JHHBAFKMBDL.HHCJCDFCLOB.PEIONAKEPCN_ShowRankingBanPopup(AOCANKOMKFG);
                    yield break;
                }
                DateTime d1 = Utility.GetLocalDateTime(IBCGNDADAEE);
                DateTime d2 = Utility.GetLocalDateTime(AIPLGDHHAJI.BEBJKJKBOGH_Date);
                if(d1.Year != d2.Year || d1.Month != d2.Month || d1.Day != d2.Day)
                {
                    AIPLGDHHAJI.POENMEGPHCG_Reset = 0;
                    AIPLGDHHAJI.BEBJKJKBOGH_Date = IBCGNDADAEE;
                }
                if(NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.GDOPLACICFE_4)
                {
                    AIPLGDHHAJI.ABBJBPLHFHA_Spurt = true;
                    LPFJADHHLHG = true;
                    PJDGDNJNCNM_UpdateStatusImpl(IBCGNDADAEE);
                }
                JEKGKAPLIHO = (int)NGOFCFJHOMI_Status;
                switch(AIPLGDHHAJI.LGADCGFMLLD_Step)
                {
                    case 0:
                    case 1:
                        if(JEKGKAPLIHO < 6)
                        {
                            CMPEJEHCOEI = true;
                            FDHDENLJLOL();
                            AIPLGDHHAJI.LGADCGFMLLD_Step = 3;
                            AIPLGDHHAJI.IMFBCJOIJKJ_Entry = true;
                            if(KIBBLLADDPO)
                            {
                                AIPLGDHHAJI.ABBJBPLHFHA_Spurt = true;
                                LPFJADHHLHG = true;
                            }
                            FGDDBFHGCGP_SetStartAdventureShown(true, 0);
                            //switchD_01329fec_caseD_6
                        }
                        else
                        {
                            AIPLGDHHAJI.LGADCGFMLLD_Step = 6;
                        }
                        break;
                    case 2:
                    case 3:
                    case 4:
                        if(JEKGKAPLIHO < 6)
                        {
                            //switchD_01329fec_caseD_6
                        }
                        else
                            AIPLGDHHAJI.LGADCGFMLLD_Step = 6;
                        break;
                    case 5:
                        {
                            PKADMPNDMGP ci = GAPOCIFPDDO_GetSelectedCardInfo();
                            OFNLIBDEIFA_EventQuest.AGFEALDEJOL ci2 = FPILJDOPPJC_GetSelectedCardSaveInfo();
                            if(!DBAEGNENPID_FailPointDisable || EGKODECGHNM())
                            {
                                ADFLCMBBNHH();
                                long v = AIPLGDHHAJI.DNBFMLBNAEE_Point;
                                if(ci != null)
                                {
                                    JMEHHJKCGNJ = new NEJFNBKMPFD();
                                    JMEHHJKCGNJ.PHOPDCNFFEI = !EGKODECGHNM();
                                    JMEHHJKCGNJ.DCACDLIAJJK_Pts = ci.EIOFPIHABFC_Pts;
                                    JMEHHJKCGNJ.AMCCOGJACPK_CardId = ci.PPFNGGCBJKC_Id;
                                    JMEHHJKCGNJ.AKNELONELJK_Diff = ci.DGMIADAEGAI_TargetDifficultyType - 1;
                                    if(!JMEHHJKCGNJ.PHOPDCNFFEI)
                                    {
                                        JMEHHJKCGNJ.FPEOGFMKMKJ = ci.EIOFPIHABFC_Pts;
                                    }
                                    else
                                    {
                                        JMEHHJKCGNJ.FPEOGFMKMKJ = ci.IAGDDKLKGJN;
                                    }
                                    JMEHHJKCGNJ.FCLGIPFPIPH = AIPLGDHHAJI.CCABNCGIHNI_Rslt / 100;
                                    if(JMEHHJKCGNJ.FCLGIPFPIPH < 1)
                                    {
                                        JMEHHJKCGNJ.FCLGIPFPIPH = 1;
                                    }
                                    int l = ci2.KIFJKGDBDBH_Lucky;
                                    if(l == 0)
                                    {
                                        l = 100;
                                    }
                                    else
                                    {
                                        l = KEHCNBNPJHB.NGHKJOEDLIP_Settings.HEABAENHIDE[JMEHHJKCGNJ.AKNELONELJK_Diff];
                                    }
                                    JMEHHJKCGNJ.INDKDHNKFAB = l;
                                    JMEHHJKCGNJ.ANOCILKJGOJ_EpiCnt = AIPLGDHHAJI.JNAHAJFKKCB_EpiCnt;
                                    JMEHHJKCGNJ.ODCLHPGHDHA_EpiBonus = AIPLGDHHAJI.NBNFHHLCMDH_EpiBo;
                                    JMEHHJKCGNJ.ODCLHPGHDHA_EpiBonus += 100;
                                    OOOOCFAFGCP o = new OOOOCFAFGCP();
                                    o.LJGOOOMOMMA_Desc = ci.FEMMDNIELFC_Desc;
                                    o.DNBFMLBNAEE = JMEHHJKCGNJ.FCLGIPFPIPH * (JMEHHJKCGNJ.ODCLHPGHDHA_EpiBonus * JMEHHJKCGNJ.FPEOGFMKMKJ * JMEHHJKCGNJ.INDKDHNKFAB * 10 / 100 / 1000);
                                    NBMDAOFPKGK(o.DNBFMLBNAEE);
                                    JMEHHJKCGNJ.JKFCHNEININ = o.DNBFMLBNAEE;
                                    JMEHHJKCGNJ.BPJEOPHAJPP_PrevPoint = (int)v;
                                    JMEHHJKCGNJ.AHOKAPCGJMA_NewPoint = (int)AIPLGDHHAJI.DNBFMLBNAEE_Point;
                                    JMEHHJKCGNJ.KLMPFGOCBHC_Desc = ci.FEMMDNIELFC_Desc;
                                    JMEHHJKCGNJ.NLEEDNLHBGP_Desc2 = ci.DCOFJKBIOAH_Desc2;
                                    JMEHHJKCGNJ.GHBPLHBNMBK_FId = ci2.DELDCIMOBCE_FId;
                                    JMEHHJKCGNJ.KIFJKGDBDBH = ci2.KIFJKGDBDBH_Lucky != 0;
                                }
                                FGMOMBKGCNF(0);
                                //LAB_01329a00
                                while(!PLOOEECNHFB)
                                    yield return null;
                                if(!NPNNPNAIONN)
                                {
                                    MFJFBNPLFBE_OnReceieveTotalReward(false);
                                    while(!PLOOEECNHFB)
                                        yield return null;
                                    if(!NPNNPNAIONN)
                                    {
                                        FDHDENLJLOL();
                                        if(JEKGKAPLIHO < 6)
                                        {
                                            //2
                                            //LAB_0132a040
                                            AIPLGDHHAJI.LGADCGFMLLD_Step = 2;
                                        }
                                        else
                                        {
                                            //LAB_0132a038
                                            AIPLGDHHAJI.LGADCGFMLLD_Step = 6;
                                        }
                                    }
                                    else
                                    {
                                        //LAB_01329c6c
                                        if(AOCANKOMKFG != null)
                                            AOCANKOMKFG();
                                        yield break;
                                    }
                                }
                                else
                                {
                                    //LAB_01329c6c
                                    if(AOCANKOMKFG != null)
                                        AOCANKOMKFG();
                                    yield break;
                                }
                            }
                            if(JEKGKAPLIHO > 5)
                                break;
                            if(ci != null && ci2 != null)
                            {
                                PIBIGCIMJGC = new BPKELFJPFEB();
                                PIBIGCIMJGC.AMCCOGJACPK = ci.PPFNGGCBJKC_Id;
                                PIBIGCIMJGC.KKECHANCHJO = GBNDFCEDNMG.NKGDIBMNLNO(ci);
                                if(PIBIGCIMJGC.KKECHANCHJO == 1)
                                {
                                    PIBIGCIMJGC.FFECGHGBMIO = ci.JJECMJFDEEP_ClearConditionValue - ci2.OLDAGCNLJOI_Prog;
                                }
                                else
                                {
                                    PIBIGCIMJGC.FFECGHGBMIO = ci.GLDIGCJNOBO_ClearCount - ci2.OLDAGCNLJOI_Prog;
                                }
                                PIBIGCIMJGC.GHBPLHBNMBK = ci2.DELDCIMOBCE_FId;
                                PIBIGCIMJGC.PHOPDCNFFEI = false;
                                PIBIGCIMJGC.FCLGIPFPIPH = AIPLGDHHAJI.CCABNCGIHNI_Rslt > 99 ? AIPLGDHHAJI.CCABNCGIHNI_Rslt / 100 : 1;
                                if(AIPLGDHHAJI.CCABNCGIHNI_Rslt % 100 == 3)
                                {
                                    PIBIGCIMJGC.PHOPDCNFFEI = true;
                                }
                            }
                            //AIPLGDHHAJI
                            //4
                            //LAB_0132a040
                            AIPLGDHHAJI.LGADCGFMLLD_Step = 4;
                        }
                        break;
                    default:
                        //switchD_01329fec_caseD_6
                        break;
                }
                //AIPLGDHHAJI
                //LAB_0132a038
                //6
                //LAB_0132a040
                //AIPLGDHHAJI.LGADCGFMLLD_Step = 6;
                //switchD_01329fec_caseD_6
                OIMGJLOLPHK = false;
                if(JEKGKAPLIHO < 6)
                {
                    CEBFFLDKAEC_SecureInt v;
                    if(KEHCNBNPJHB.OHJFBLFELNK.TryGetValue(HOEKCEJINNA, out v))
                    {
                        bool b = DLHEEOIELBA(v.DNJEJEANJGL_Value);
                        if(NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2)
                        {
                            if(!b)
                            {
                                AIPLGDHHAJI.INLNJOGHLJE_Show |= 4;
                            }
                        }
                        else
                        {
                            if(b && KEHCNBNPJHB.OHJFBLFELNK.TryGetValue(FOKNMOMNHHD, out v))
                            {
                                if((AIPLGDHHAJI.INLNJOGHLJE_Show & 4) != 0)
                                {
                                    GFHKFKHBIGM = true;
                                    OGPMLMDPGJA = v.DNJEJEANJGL_Value;
                                }
                            }
                        }
                        OIMGJLOLPHK = b;
                    }
                }
                CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
                {
                    //0x13291B8
                    if(BHFHGFKBOHH != null)
                        BHFHGFKBOHH();
                    PLOOEECNHFB = true;
                }, () =>
                {
                    //0x13291F8
                    if(AOCANKOMKFG != null)
                        AOCANKOMKFG();
                    PLOOEECNHFB = true;
                    NPNNPNAIONN = true;
                }, null);
            }
            else
            {
                //LAB_01329c6c
                if(AOCANKOMKFG != null)
                    AOCANKOMKFG();
                yield break;
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

	// // RVA: 0x1320C28 Offset: 0x1320C28 VA: 0x1320C28
	private void FDHDENLJLOL()
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            OFNLIBDEIFA_EventQuest.GCCDGBBDICM save/*NHLBKJCPLBL*/ = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
            save.MDADLCOCEBN_SessionId = JDDGPJDKHNE.GPLMOKEIOLE();
            int maxDiff = PJLNJJIBFBN ? 4 : 3;
            List<int> l = IBJAKJJICBC.CJHOOLJFGFB();
            int r = UnityEngine.Random.Range(0, int.MaxValue);
            int diff = 0;
            for(int i = 0; i <= maxDiff; i++)
            {
                List<int> l4 = ev.GEFEGEHCFNE(i);
                List<int> l2 = new List<int>(3);
                for(int j = 0; j < 3; j++)
                {
                    int AOENBGCCFCO = diff + j;
                    int idx = ev.HKODBHPMLCP_Cards.FindIndex((PKADMPNDMGP GHPLINIACBB) =>
                    {
                        //0x1329250
                        return GHPLINIACBB.PPFNGGCBJKC_Id == save.HKODBHPMLCP_Cards[AOENBGCCFCO].PBEEPMLJGJC_Cid;
                    });
                    if(idx > -1)
                    {
                        l2.Add(idx);
                    }
                }
                List<HBHLOOKPPHM> l3 = new List<HBHLOOKPPHM>(l4.Count);
                for(int j = 0; j < 3; j++)
                {
                    l3.Clear();
                    for(int k = 0; k < l4.Count; k++)
                    {
                        int OIPCCBHIKIA = l4[k];
                        int idx = l2.FindIndex((int GHPLINIACBB) =>
                        {
                            //0x132934C
                            return ev.HKODBHPMLCP_Cards[GHPLINIACBB].JONPKLHMOBL_Category == ev.HKODBHPMLCP_Cards[OIPCCBHIKIA].JONPKLHMOBL_Category;
                        });
                        if(idx < 0)
                        {
                            int v1 = GBNDFCEDNMG.GHAJJNPENFI(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, ev.HKODBHPMLCP_Cards[OIPCCBHIKIA], l);
                            if(v1 != 0)
                            {
                                if(ev.HKODBHPMLCP_Cards[OIPCCBHIKIA].MKNDAOHGOAK_Weight > 0)
                                {
                                    HBHLOOKPPHM h = new HBHLOOKPPHM();
                                    h.OIPCCBHIKIA_Idx = OIPCCBHIKIA;
                                    h.GHBPLHBNMBK = v1;
                                    h.MKNDAOHGOAK_Weight = ev.HKODBHPMLCP_Cards[OIPCCBHIKIA].MKNDAOHGOAK_Weight;
                                    l3.Add(h);
                                }
                            }
                        }
                    }
                    for(int k = 0; k < l3.Count; k++)
                    {
                        HBHLOOKPPHM h = l3[k];
                        int r2 = UnityEngine.Random.Range(0, l3.Count);
                        l3[k] = l3[r2];
                        l3[r2] = h;
                    }
                    int max = 0;
                    for(int k = 0; k < l3.Count; k++)
                    {
                        max += l3[k].MKNDAOHGOAK_Weight;
                        l3[k].FCDKJAKLGMB_Sum = max;
                    }
                    int r3 = UnityEngine.Random.Range(0, max);
                    int found = 0;
                    for(int k = 0; k < l3.Count; k++)
                    {
                        found = k;
                        if(r3 <= l3[k].FCDKJAKLGMB_Sum)
                            break;
                    }
                    PKADMPNDMGP c = ev.HKODBHPMLCP_Cards[l3[found].OIPCCBHIKIA_Idx];
                    l2.Add(l3[found].OIPCCBHIKIA_Idx);
                    int r4 = UnityEngine.Random.Range(0, 1000);
                    int idx2 = j + i * 3;
                    save.HKODBHPMLCP_Cards[idx2].LHPDDGIJKNB(r);
                    save.HKODBHPMLCP_Cards[idx2].PBEEPMLJGJC_Cid = c.PPFNGGCBJKC_Id;
                    save.HKODBHPMLCP_Cards[idx2].DELDCIMOBCE_FId = c.HBJJCDIMOPO_TargetMusicConditionId;
                    if(!FAJNDPEKHAA_LuckyDisable)
                    {
                        int r5 = UnityEngine.Random.Range(0, 1000);
                        save.HKODBHPMLCP_Cards[idx2].KIFJKGDBDBH_Lucky = ((r5 < ev.NGHKJOEDLIP_Settings.EPHAKDAPAHE[i]) ? 1 : 0) << (save.ABBJBPLHFHA_Spurt ? 1 : 0);
                    }
                    else
                    {
                        save.HKODBHPMLCP_Cards[idx2].KIFJKGDBDBH_Lucky = 0;
                    }
                    r *= 0x2c19;
                }
                diff += 3;
            }
        }
    }

	// // RVA: 0x1321E30 Offset: 0x1321E30 VA: 0x1321E30
	public int BOLHIMADLBN(int AKNELONELJK)
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            return ev.NGHKJOEDLIP_Settings.HEABAENHIDE[AKNELONELJK];
        }
        return 0;
    }

	// // RVA: 0x1321FE0 Offset: 0x1321FE0 VA: 0x1321FE0
	// public PKADMPNDMGP NPCMANKMGCJ(int AKNELONELJK, int IKPIDCFOFEA) { }

	// // RVA: 0x1322328 Offset: 0x1322328 VA: 0x1322328
	// public OFNLIBDEIFA.AGFEALDEJOL ALDHOIEBGNM(int AKNELONELJK, int IKPIDCFOFEA) { }

	// // RVA: 0x13225BC Offset: 0x13225BC VA: 0x13225BC
	// public void DPBLJLFKMPL(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG) { }

	// // RVA: 0x1322934 Offset: 0x1322934 VA: 0x1322934
	// public void LLCMINJNADH(int AKNELONELJK, int IKPIDCFOFEA, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG) { }

	// // RVA: 0x1322CE4 Offset: 0x1322CE4 VA: 0x1322CE4
	public PKADMPNDMGP GAPOCIFPDDO_GetSelectedCardInfo()
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
            OFNLIBDEIFA_EventQuest.AGFEALDEJOL card = save.HKODBHPMLCP_Cards[save.BACCOJIDFJE_SelCard];
            return ev.HKODBHPMLCP_Cards.Find((PKADMPNDMGP GHPLINIACBB) =>
            {
                //0x13296AC
                return GHPLINIACBB.PPFNGGCBJKC_Id == card.PBEEPMLJGJC_Cid;
            });
        }
        return null;
    }

	// // RVA: 0x1323044 Offset: 0x1323044 VA: 0x1323044
	public OFNLIBDEIFA_EventQuest.AGFEALDEJOL FPILJDOPPJC_GetSelectedCardSaveInfo()
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
            return save.HKODBHPMLCP_Cards[save.BACCOJIDFJE_SelCard];
        }
        return null;
    }

	// // RVA: 0x13232F0 Offset: 0x13232F0 VA: 0x13232F0
	// public int BFEKPKAGGMH() { }

	// // RVA: 0x1323350 Offset: 0x1323350 VA: 0x1323350
	// public int CDKDCKOAEMA() { }

	// // RVA: 0x13235E0 Offset: 0x13235E0 VA: 0x13235E0
	public int KGIIPFJIAGB_GetPlayCost(int AKNELONELJK)
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
            return ev.NGHKJOEDLIP_Settings.HIAMHLLHAON_PlayCostByDiff[AKNELONELJK];
        }
        return 0;
    }

	// // RVA: 0x1323850 Offset: 0x1323850 VA: 0x1323850
	// public void NPFGIPABOMC(IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP HDOKKIGGAEI, DJBHIFLHJLK AOCANKOMKFG, bool JDPGHNKKGNE = True) { }

	// // RVA: 0x1323F70 Offset: 0x1323F70 VA: 0x1323F70
	public void OAIBHKLKFKB(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, int FCLGIPFPIPH, int LCCGDFGGIHI, int ANOPDAGJIKG, int MHADLGMJKGK)
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            PKADMPNDMGP d = GAPOCIFPDDO_GetSelectedCardInfo();
            OFNLIBDEIFA_EventQuest.AGFEALDEJOL a = FPILJDOPPJC_GetSelectedCardSaveInfo();
            OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
            if(GBNDFCEDNMG.EIJIGDCMJLB(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, d, OMNOFMEBLAD, this, true))
            {
                GBNDFCEDNMG.BBEKHCGKIAJ(d, a, OMNOFMEBLAD);
                int v = d.PPFNGGCBJKC_Id;
                if(GBNDFCEDNMG.EGKODECGHNM(d, a))
                {
                    UnityEngine.Debug.Log(string.Format("StringLiteral_12472 {0} {1}", v, d.FEMMDNIELFC_Desc));
                    save.CCABNCGIHNI_Rslt = (FCLGIPFPIPH * LCCGDFGGIHI * 100) | 1;
                }
                else
                {
                    UnityEngine.Debug.Log(string.Format("StringLiteral_12473 {0} {1}", v, d.FEMMDNIELFC_Desc));
                    save.CCABNCGIHNI_Rslt = (FCLGIPFPIPH * LCCGDFGGIHI * 100) | 2;
                }
            }
            else
            {
                save.CCABNCGIHNI_Rslt = (FCLGIPFPIPH * LCCGDFGGIHI * 100) | 3;
            }
            save.LGADCGFMLLD_Step = 5;
            save.JNAHAJFKKCB_EpiCnt = LEPNPBIMHGM_GetEquippedEpisodesWithBonus(ANOPDAGJIKG).Count;
            save.NBNFHHLCMDH_EpiBo = CEICDKGEONG_GetEquippedEpisodesBonusValue(ANOPDAGJIKG, MHADLGMJKGK);
        }
    }

	// // RVA: 0x1324600 Offset: 0x1324600 VA: 0x1324600
	public bool EGKODECGHNM()
    {
        PKADMPNDMGP p = GAPOCIFPDDO_GetSelectedCardInfo();
        OFNLIBDEIFA_EventQuest.AGFEALDEJOL a = FPILJDOPPJC_GetSelectedCardSaveInfo();
        if(p != null && a != null)
        {
            return GBNDFCEDNMG.EGKODECGHNM(p, a);
        }
        return false;
    }

	// // RVA: 0x13246B4 Offset: 0x13246B4 VA: 0x13246B4
	public bool OADIALAGKGM()
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            if(NGOFCFJHOMI_Status < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6)
            {
                OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
                return save.LGADCGFMLLD_Step == 5 && EGKODECGHNM();
            }
        }
        return false;
    }

	// // RVA: 0x1324944 Offset: 0x1324944 VA: 0x1324944
	// public bool AGBLHCGKAIO() { }

	// RVA: 0x1324BCC Offset: 0x1324BCC VA: 0x1324BCC Slot: 33
	public override bool MPMKJNJGFEF_IsEntry()
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
            return save.IMFBCJOIJKJ_Entry;
        }
        return false;
    }

	// RVA: 0x1324E2C Offset: 0x1324E2C VA: 0x1324E2C Slot: 69
	public override void HAAEJDGMICH(LBNLAENLPNK.JEKODBEDOMM INDDJNMPONH, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
    {
        string v = null;
        if(INDDJNMPONH == 0)
        {
            v = JOPOPMLFINI_QuestId + "_rule";
        }
        if(string.IsNullOrEmpty(v))
        {
            BHFHGFKBOHH();
        }
        MBCPNPNMFHB.HHCJCDFCLOB.FLLLPBIECCP(v, BHFHGFKBOHH, AOCANKOMKFG);
    }

	// RVA: 0x1324F54 Offset: 0x1324F54 VA: 0x1324F54 Slot: 71
	public override int BAEPGOAMBDK(string LJNAKDMILMC, int MNCOAGOKNAO)
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            return ev.LPJLEHAJADA(LJNAKDMILMC, MNCOAGOKNAO);
        }
        return MNCOAGOKNAO;
    }

	// RVA: 0x13250D4 Offset: 0x13250D4 VA: 0x13250D4 Slot: 72
	public override string MAICAKMIBEM(string LJNAKDMILMC, string MNCOAGOKNAO)
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            return ev.EFEGBHACJAL(LJNAKDMILMC, MNCOAGOKNAO);
        }
        return MNCOAGOKNAO;
    }

	// RVA: 0x1325254 Offset: 0x1325254 VA: 0x1325254 Slot: 68
	public override bool GJMGKBDGMOP(long LPEKHFOMCAH)
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            if(BHABCGJCGNO != null)
            {
                if(LPEKHFOMCAH < DPJCPDKALGI_RankingEnd)
                {
                    OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
                    if(save.OMCAOJJGOGG_Lb != NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD)
                    {
                        save.OMCAOJJGOGG_Lb = NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD;
                        if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(BHABCGJCGNO.JJBGOIMEIPF_ItemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem)
                        {
                            int itId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(BHABCGJCGNO.JJBGOIMEIPF_ItemId);
                            EGOLBAPFHHD_Common.FKLHGOGJOHH enIt = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KFEBOFKAHAJ_EngItem[itId - 1];
                            enIt.BFINGCJHOHI_Cnt += BHABCGJCGNO.MBJIFDBEDAC_Cnt;
                            enIt.BEBJKJKBOGH_Date = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
                            ILCCJNDFFOB.HHCJCDFCLOB.JAHALBMOANH(BHABCGJCGNO.JJBGOIMEIPF_ItemId, OAGBCBBHMPF.COIIJOEKBDH.IGAJCMKNLDL_14, PGIIDPEGGPI_EventId.ToString(), BHABCGJCGNO.MBJIFDBEDAC_Cnt, enIt.BFINGCJHOHI_Cnt, 1);
                        }
                        return true;
                    }
                }
            }
        }
        return false;
    }

	// // RVA: 0x1325A3C Offset: 0x1325A3C VA: 0x1325A3C
	// public bool IHHJDIAOENO() { }

	// // RVA: 0x1325CA8 Offset: 0x1325CA8 VA: 0x1325CA8
	// public void NEFIHNLPHCH() { }

	// RVA: 0x1325F10 Offset: 0x1325F10 VA: 0x1325F10 Slot: 75
	public override string FEKEBPKINIM_GetSessionId()
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
            return save.MDADLCOCEBN_SessionId;
        }
        return "";
    }

	// RVA: 0x132617C Offset: 0x132617C VA: 0x132617C Slot: 73
	public override List<string> IJCPBPFEGDM_GetResourcesFilePathList(long JHNMKKNEENE)
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            if(MNNNLDFNNCD(JHNMKKNEENE))
            {
                KEODKEGFDLD_FreeMusicInfo fInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(ev.NGHKJOEDLIP_Settings.JKFPADIAKCK);
                return SoundResource.CreateBgmFilePathList(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(fInfo.DLAEJOBELBH_MusicId).KKPAHLMJKIH_WavId);
            }
        }
        return null;
    }

	// RVA: 0x1326460 Offset: 0x1326460 VA: 0x1326460 Slot: 74
	public override int EDNMFMBLCGF_GetWavId()
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            KEODKEGFDLD_FreeMusicInfo fInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(ev.NGHKJOEDLIP_Settings.JKFPADIAKCK);
            return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(fInfo.DLAEJOBELBH_MusicId).KKPAHLMJKIH_WavId;
        }
        return 0;
    }

	// RVA: 0x13266E8 Offset: 0x13266E8 VA: 0x13266E8 Slot: 38
	public override void EMEPJNLHJHJ(int GJEADBKFAPA, int AKNELONELJK, bool GIKLNODJKFK, ref int APMGOLOPLFP, ref int FBBDNLAMPMH)
    {
        APMGOLOPLFP = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.JJIBDCAIBIO_LuckCoef0;
        FBBDNLAMPMH = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.AMNBEMCJCHF_LuckCoef1;
    }

	// // RVA: 0x13267FC Offset: 0x13267FC VA: 0x13267FC
	public OFNLIBDEIFA_EventQuest.HGCEGAAJFBC JIPPHOKGLIH(int GOIKCKHMBDL, bool HOENAFAJMGI/* = False*/)
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            OFNLIBDEIFA_EventQuest.GCCDGBBDICM save;
            if(HOENAFAJMGI)
            {
                save = CIOECGOMILE.HHCJCDFCLOB.MNJHBCIIHED_PrevServerData.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
            }
            else
            {
                save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
            }
            OFNLIBDEIFA_EventQuest.HGCEGAAJFBC m = save.FFMHJIJBKEN_Musics.Find((OFNLIBDEIFA_EventQuest.HGCEGAAJFBC GHPLINIACBB) =>
            {
                //0x13297F8
                return GHPLINIACBB.GOIKCKHMBDL_FId == GOIKCKHMBDL;
            });
            if(m == null)
            {
                return save.FFMHJIJBKEN_Musics.Find((OFNLIBDEIFA_EventQuest.HGCEGAAJFBC GHPLINIACBB) =>
                {
                    //0x1326F8C
                    return GHPLINIACBB.GOIKCKHMBDL_FId == 0;
                });
            }
            return m;
        }
        return null;
    }

	// RVA: 0x1326C78 Offset: 0x1326C78 VA: 0x1326C78 Slot: 76
	public override void MMIMJPNLKBK()
    {
        if(GFHKFKHBIGM)
        {
            LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LMBBEGIAKAD_EventQuest;
            if(ev != null)
            {
                OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
                save.INLNJOGHLJE_Show = (int)(save.INLNJOGHLJE_Show & 0xfffffffb);
                GFHKFKHBIGM = false;
            }
        }
    }
}
