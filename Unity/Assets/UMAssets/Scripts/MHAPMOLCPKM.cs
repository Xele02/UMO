
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using XeApp.Game.Common;
using XeSys;

public class PKADMPNDMGP : AKIIJBEJOEP
{
	public int JONPKLHMOBL_Category; // 0x94
	public int MKNDAOHGOAK_weight; // 0x98
	public int EIOFPIHABFC_Pts; // 0x9C
	public int IAGDDKLKGJN; // 0xA0
	public string DCOFJKBIOAH_Desc2; // 0xA4

	// // RVA: 0x938F0C Offset: 0x938F0C VA: 0x938F0C
	// public void KHEKNNFCAOI_Init(string _JOPOPMLFINI_QuestName, int _PPFNGGCBJKC_id, int KNEFBLHBDBG, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) { }
    //JONPKLHMOBL_Category = category
    //MKNDAOHGOAK_weight = weight
    //EIOFPIHABFC_Pts = pts
    //DCOFJKBIOAH_Desc2 = desc2

	// // RVA: 0x9390C8 Offset: 0x9390C8 VA: 0x9390C8
	public new void KHEKNNFCAOI_Init(string _JOPOPMLFINI_QuestName, int _PPFNGGCBJKC_id, int KNEFBLHBDBG, HGHOHICGBEP JMHECKKKMLK)
    {
        base.IFMHPIGMJBC(_JOPOPMLFINI_QuestName, _PPFNGGCBJKC_id, KNEFBLHBDBG, JMHECKKKMLK);
        JONPKLHMOBL_Category = JMHECKKKMLK.DGPHHJCPNOO[_PPFNGGCBJKC_id - 1].JONPKLHMOBL_Category;
        MKNDAOHGOAK_weight = JMHECKKKMLK.DGPHHJCPNOO[_PPFNGGCBJKC_id - 1].MKNDAOHGOAK_weight;
        EIOFPIHABFC_Pts = JMHECKKKMLK.DGPHHJCPNOO[_PPFNGGCBJKC_id - 1].EIOFPIHABFC_Pts;
        DCOFJKBIOAH_Desc2 = JMHECKKKMLK.DGPHHJCPNOO[_PPFNGGCBJKC_id - 1].DCOFJKBIOAH_Desc2;
        IAGDDKLKGJN = JMHECKKKMLK.DGPHHJCPNOO[_PPFNGGCBJKC_id - 1].IAGDDKLKGJN;
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
        public int AKNELONELJK_difficulty; // 0xC
        public int DCACDLIAJJK_Pts; // 0x10
        public int FPEOGFMKMKJ_Point; // 0x14
        public int INDKDHNKFAB; // 0x18
        public int ANOCILKJGOJ_EpisodeCnt; // 0x1C
        public int ODCLHPGHDHA_EpisodeBonus; // 0x20
        public int JKFCHNEININ_GetPoint; // 0x24
        public int BPJEOPHAJPP_PrevTotalPoint; // 0x28
        public int AHOKAPCGJMA_TotalPoint; // 0x2C
        public string KLMPFGOCBHC_description; // 0x30
        public string NLEEDNLHBGP_Desc2; // 0x34
        public bool KIFJKGDBDBH_lucky; // 0x38
        public int GHBPLHBNMBK_FreeMusicId; // 0x3C
        public int FCLGIPFPIPH_DashBonus; // 0x40
        public bool PHOPDCNFFEI; // 0x44
    }

    public class BPKELFJPFEB
    {
        public int AMCCOGJACPK_CardId; // 0x8
        public int FFECGHGBMIO; // 0xC
        public int KKECHANCHJO; // 0x10
        public int GHBPLHBNMBK_FreeMusicId; // 0x14
        public bool PHOPDCNFFEI; // 0x18
        public int FCLGIPFPIPH_DashBonus; // 0x1C
    }
 
    private class HBHLOOKPPHM
    {
        public int OIPCCBHIKIA_index; // 0x8
        public int MKNDAOHGOAK_weight; // 0xC
        public int FCDKJAKLGMB_TargetValue; // 0x10
        public int GHBPLHBNMBK_FreeMusicId; // 0x14
    }

	private const int GHJHJDIDCFA = 3;
	private EECOJKDJIFG KBACNOCOANM_Ranking; // 0xE8
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
        return KBACNOCOANM_Ranking;
    }

	// RVA: 0x131A3A8 Offset: 0x131A3A8 VA: 0x131A3A8
	public MHAPMOLCPKM_EventQuest(string _OPFGFINHFCE_name) : base(_OPFGFINHFCE_name)
    {
        return;
    }

	// RVA: 0x131A434 Offset: 0x131A434 VA: 0x131A434 Slot: 5
	public override string IFKKBHPMALH()
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            return ev.NGHKJOEDLIP_Settings.OCDMGOGMHGE_KeyPrefix;
        }
        return null;
    }

	// RVA: 0x131A5BC Offset: 0x131A5BC VA: 0x131A5BC Slot: 27
	public override int HLOGNJNGDJO_GetHelpId(int _OIPCCBHIKIA_index/* = 0*/)
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            return ev.NGHKJOEDLIP_Settings.EJBGHLOOLBC_HelpIds[_OIPCCBHIKIA_index];
        }
        return 0;
    }

	// RVA: 0x131A778 Offset: 0x131A778 VA: 0x131A778 Slot: 67
	//public override int LBNKDKDMMOK() { }

	// RVA: 0x131A8FC Offset: 0x131A8FC VA: 0x131A8FC Slot: 28
	public override long FBGDBGKNKOD_GetCurrentPoint()
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LMBBEGIAKAD_EventQuest;
        if(ev != null && GPHEKCNDDIK)
        {
            OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
            return save.DNBFMLBNAEE_point;
        }
        return 0;
    }

	// RVA: 0x131AB5C Offset: 0x131AB5C VA: 0x131AB5C Slot: 29
	public override void MJFKJHJJLMN_GetRanks(int LHJCOPMMIGO/* = 0*/, bool _FBBNPFFEJBN_Force/* = False*/)
    {
        NPNNPNAIONN_IsError = false;
        PLOOEECNHFB_IsDone = false;
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LMBBEGIAKAD_EventQuest;
        if(ev != null && GPHEKCNDDIK)
        {
            if(_FBBNPFFEJBN_Force || NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime() - KPOMHFLKMKI_LastRankUpdateTime[LHJCOPMMIGO] >= IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA_GetIntParam("get_rank_cooling_time", 60))
            {
                KKLGENJKEBN.HHCJCDFCLOB.HEOKADCEAGL_GetRanks(ev.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api, () =>
                {
                    //0x1326FBC
                    CDINKAANIAA_Rank[LHJCOPMMIGO] = (int)KKLGENJKEBN.HHCJCDFCLOB.LPPCNCMEDFA_Rank;
                    KPOMHFLKMKI_LastRankUpdateTime[LHJCOPMMIGO] = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
                    PLOOEECNHFB_IsDone = true;
                }, () =>
                {
                    //0x1327180
                    KPOMHFLKMKI_LastRankUpdateTime[LHJCOPMMIGO] = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
                    CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
                    PLOOEECNHFB_IsDone = true;
                }, () =>
                {
                    //0x1327328
                    CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
                    PLOOEECNHFB_IsDone = true;
                    NPNNPNAIONN_IsError = true;
                }, () =>
                {
                    //0x13273C0
                    CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
                    PLOOEECNHFB_IsDone = true;
                    FKKDIDMGLMI_IsDroppedPlayer = true;
                });
                return;
            }
        }
        else
            CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
        PLOOEECNHFB_IsDone = true;
    }

	// RVA: 0x131B03C Offset: 0x131B03C VA: 0x131B03C Slot: 30
	protected override bool JIHMLILFOPG_IsEventActive(long _JHNMKKNEENE_Time)
    {
        LMBBEGIAKAD_EventQuest ev/*DBIHIEBCMNC*/ = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            GDIPLANPCEI g = IMMAOANGPNK.HHCJCDFCLOB.ACEFBFLFKFD_GetScheduleEventData(ev.JIKKNHIAEKG_BlockName, _JHNMKKNEENE_Time);
            if(g != null)
            {
                if(_JHNMKKNEENE_Time >= ev.NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart)
                {
                    if(ev.NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2 >= _JHNMKKNEENE_Time)
                    {
                        if(ev.NGHKJOEDLIP_Settings.HKKNEAGCIEB_RankingSupport != 0)
                        {
                            if(KKLGENJKEBN.HHCJCDFCLOB.JPDPFGFMKHK_rankings.Find((EECOJKDJIFG PKLPKMLGFGK) =>
                            {
                                //0x1327458
                                return ev.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api == PKLPKMLGFGK.OCGFKMHNEOF_name_for_api;
                            }) == null)
                            {
                                UnityEngine.Debug.LogError("Missing event ranking "+ev.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api);
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
	protected override bool IMCMNOPNGHO(long _JHNMKKNEENE_Time)
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
            AGLILDLEFDK_Missions = ev.NNMPGOAGEOL_quests;
            OLDFFDMPEBM_Quests = save.NNMPGOAGEOL_quests;
            if(save.MPCAGEPEJJJ_Key != ev.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api || save.EGBOHDFBAPB_closed_at == 0 || (!RuntimeSettings.CurrentSettings.UnlimitedEvent && save.EGBOHDFBAPB_closed_at < ev.NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart))
            {
                save.LHPDDGIJKNB_Reset();
                save.MPCAGEPEJJJ_Key = ev.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api;
                save.EGBOHDFBAPB_closed_at = ev.NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd;
                save.LGADCGFMLLD_step = 1;
                save.BEBJKJKBOGH_date = _JHNMKKNEENE_Time;
                KOMAHOAEMEK(true);
            }
            KOMAHOAEMEK(false);
            return true;
        }
        return false;
    }

	// RVA: 0x131B6BC Offset: 0x131B6BC VA: 0x131B6BC Slot: 40
	protected override void KKFLDCBHFJA(long _JHNMKKNEENE_Time)
    {
        LMBBEGIAKAD_EventQuest ev/*DBIHIEBCMNC*/ = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            IBNKPMPFLGI_IsRankReward = ev.NGHKJOEDLIP_Settings.HKKNEAGCIEB_RankingSupport != 0;
            if(IBNKPMPFLGI_IsRankReward)
            {
                KBACNOCOANM_Ranking = KKLGENJKEBN.HHCJCDFCLOB.JPDPFGFMKHK_rankings.Find((EECOJKDJIFG PKLPKMLGFGK) =>
                {
                    //0x13274B8
                    return ev.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api == PKLPKMLGFGK.OCGFKMHNEOF_name_for_api;
                });
                GPHEKCNDDIK = true;
            }
            DGCOMDILAKM_EventName = ev.NGHKJOEDLIP_Settings.OPFGFINHFCE_name;
            DOLJEDAAKNN_RankingName = ev.NGHKJOEDLIP_Settings.HEDAGCNPHGD_RankingName;
            GLIMIGNNGGB_RankingStart = ev.NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
            DPJCPDKALGI_RankingEnd = ev.NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;
            LOLAANGCGDO_RankingEnd2 = ev.NGHKJOEDLIP_Settings.LNFKGHNHJKE_RankingEnd2;
            JDDFILGNGFH_RewardStart = ev.NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart;
            LJOHLEGGGMC_RewardEnd = ev.NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd;
            EMEKFFHCHMH_RewardEnd2 = ev.NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2;
            PGIIDPEGGPI_EventId = ev.NGHKJOEDLIP_Settings.OBGBAOLONDD_UniqueId;
            NHGPCLGPEHH_TicketType = ev.NGHKJOEDLIP_Settings.MJBKGOJBPAD_item_type;
            FBHONHONKGD_MusicSelectDesc = ev.NGHKJOEDLIP_Settings.FEMMDNIELFC_Desc;
            HGLAFGHHFKP = ev.NGHKJOEDLIP_Settings.JHPCPNJJHLI_RankingThreshold;
            GFIBLLLHMPD_StartAdventureId = ev.NGHKJOEDLIP_Settings.HIOOGLEJBKM_StartAdventureId;
            CAKEOPLJDAF_EndAdventureId = ev.NGHKJOEDLIP_Settings.FJCADCDNPMP_EndAdventureId;
            KDDBNAIJKAD_ResetDisable = BAEPGOAMBDK("reset_disable", 0) != 0;
            DBAEGNENPID_FailPointDisable = BAEPGOAMBDK("fail_point_disable", 0) != 0;
            FAJNDPEKHAA_LuckyDisable = BAEPGOAMBDK("lucky_disable", 0) != 0;
            LHAKGDAGEMM_EpBonusInfos.Clear();
            for(int i = 0; i < ev.LHAKGDAGEMM_EpBonusInfos.Count; i++)
            {
                CEGDBNNIDIG c = new CEGDBNNIDIG();
                c.KELFCMEOPPM_EpisodeId = ev.LHAKGDAGEMM_EpBonusInfos[i].KHPHAAMGMJP_EpId;
                c.MIHNKIHNBBL_BaseBonus = ev.LHAKGDAGEMM_EpBonusInfos[i].OFIAENKCJME_BaseBonus / 100.0f;
                c.MLLPMJFOKEC_GachaIds.AddRange(ev.LHAKGDAGEMM_EpBonusInfos[i].KDNMBOBEGJM_GachaIds);
                LHAKGDAGEMM_EpBonusInfos.Add(c);
            }
            PGDAMNENGDA_EpBonusBySceneRarity.Clear();
            for(int i = 0; i < ev.OGMHMAGDNAM_EpBonusBySceneRarity.Count; i++)
            {
                NJJDBBCHBNP n = new NJJDBBCHBNP();
                n.GJEADBKFAPA = ev.OGMHMAGDNAM_EpBonusBySceneRarity[i].PPFNGGCBJKC_id;
                n.IJKFFIKGLJM_BonusBefore = ev.OGMHMAGDNAM_EpBonusBySceneRarity[i].GNFBMCGMCFO_BonusBefore;
                n.DCBMFNOIENM_BonusAfter = ev.OGMHMAGDNAM_EpBonusBySceneRarity[i].BFFGFAMJAIG_BonusAfter;
                PGDAMNENGDA_EpBonusBySceneRarity.Add(n);
            }
            DHOMAEOEFMJ_EpBonuByScene.Clear();
            for(int i = 0; i < ev.GEGAEDDGNMA_Bonuses.Count; i++)
            {
                MEBJJBHPMEO m = new MEBJJBHPMEO();
                m.PPFNGGCBJKC_id = ev.GEGAEDDGNMA_Bonuses[i].PPFNGGCBJKC_id;
                m.GNFBMCGMCFO_BonusBefore = ev.GEGAEDDGNMA_Bonuses[i].GNFBMCGMCFO_BonusBefore;
                m.BFFGFAMJAIG_BonusAfter = ev.GEGAEDDGNMA_Bonuses[i].BFFGFAMJAIG_BonusAfter;
                m.CNKFPJCGNFE_SceneId = ev.GEGAEDDGNMA_Bonuses[i].CNKFPJCGNFE_SceneId;
                DHOMAEOEFMJ_EpBonuByScene.Add(m);
            }
            MBHDIJJEOFL = ev.MBHDIJJEOFL;
            LEPALMDKEOK_IsPointReward = true;
            PJLNJJIBFBN_HasExtremeDiff = ev.NGHKJOEDLIP_Settings.AHKPNPNOAMO_ExtreamOpen != 0;
            for(int i = 0; i < KPOMHFLKMKI_LastRankUpdateTime.Length; i++)
            {
                KPOMHFLKMKI_LastRankUpdateTime[i] = 0;
            }
            if(!string.IsNullOrEmpty(ev.NGHKJOEDLIP_Settings.OMCAOJJGOGG_Lb))
            {
                string[] strs = ev.NGHKJOEDLIP_Settings.OMCAOJJGOGG_Lb.Split(new char[]{','});
                MFDJIFIIPJD m = new MFDJIFIIPJD();
                m.KHEKNNFCAOI_Init(int.Parse(strs[0]), int.Parse(strs[1]));
                BHABCGJCGNO = m;
            }
            GPHEKCNDDIK = true;
        }
    }

	// RVA: 0x131C440 Offset: 0x131C440 VA: 0x131C440 Slot: 43
	protected override void FCHGHAAPIBH()
    {
        LMBBEGIAKAD_EventQuest ev/*NDFIEMPPMLF_master*/ = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            Dictionary<string,int> DBEKEBNDMBH_SaveIdx = new Dictionary<string, int>();
            List<string> ls = new List<string>(20);
            string str = ev.NGHKJOEDLIP_Settings.OCDMGOGMHGE_KeyPrefix;
            for(int i = 0; i < ev.FCIPEDFHFEM_TotalRewards.Count; i++)
            {
                for(int j = 0; j < ev.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards.Count; j++)
                {
                    if(ev.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards[j].NMKEOMCMIPP_RewardId > 0)
                    {
                        string s = str + ev.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards[j].NMKEOMCMIPP_RewardId.ToString();
                        ls.Add(s);
                        DBEKEBNDMBH_SaveIdx.Add(s, i);
                    }
                }
            }
            if(ls.Count == 0)
            {
                PIMFJALCIGK();
                PLOOEECNHFB_IsDone = true;
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
                    OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
                    for(int i = 0; i < r.NFEAMMJIMPG_Result.CEDLLCCONJP_achievement_prizes.Count; i++)
                    {
                        if(DBEKEBNDMBH_SaveIdx.ContainsKey(r.NFEAMMJIMPG_Result.CEDLLCCONJP_achievement_prizes[i].LJNAKDMILMC_key))
                        {
                            if(r.NFEAMMJIMPG_Result.CEDLLCCONJP_achievement_prizes[i].OOIJCMLEAJP_is_received)
                            {
                                save.LCDIGDMGPGO_TRcv[DBEKEBNDMBH_SaveIdx[r.NFEAMMJIMPG_Result.CEDLLCCONJP_achievement_prizes[i].LJNAKDMILMC_key]] = 1;
                            }
                        }
                    }
                    PIMFJALCIGK();
                    PLOOEECNHFB_IsDone = true;
                };
                req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request NHECPMNKEFK) =>
                {
                    //0x13279D0
                    PLOOEECNHFB_IsDone = true;
                    NPNNPNAIONN_IsError = true;
                };
            }
        }
        else
        {
            PLOOEECNHFB_IsDone = true;
        }
    }

	// RVA: 0x131CAFC Offset: 0x131CAFC VA: 0x131CAFC Slot: 46
	protected override void PJDGDNJNCNM_UpdateStatusImpl(long _JHNMKKNEENE_Time)
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            KIBBLLADDPO = false;
            OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
            IBLPKJJNNIG = false;
            BELBNINIOIE = false;
            if(_JHNMKKNEENE_Time >= ev.NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart)
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
                    if(!save.IMFBCJOIJKJ_Entry)
                    {
                        NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2;
                        if(_JHNMKKNEENE_Time < ev.NGHKJOEDLIP_Settings.EHHFFKAFOMC)
                            return;
                        KIBBLLADDPO = true;
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
                        return;
                    }
                    if(!save.ABBJBPLHFHA_Spurt)
                    {
                        if(_JHNMKKNEENE_Time >= ev.NGHKJOEDLIP_Settings.EHHFFKAFOMC)
                        {
                            NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.GDOPLACICFE_4;
                            KIBBLLADDPO = true;
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
                                if(MBHDIJJEOFL[i].MAFAIIHJAFG_spurt == 1)
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
                    if(_JHNMKKNEENE_Time >= ev.NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart)
                    {
                        if(_JHNMKKNEENE_Time >= ev.NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd)
                        {
                            if(_JHNMKKNEENE_Time >= ev.NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2)
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
                        NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_6_Counting;
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
            NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.HJNNKCMLGFL_0_None;
            KIBBLLADDPO = false;
        }
    }

	// RVA: 0x131D150 Offset: 0x131D150 VA: 0x131D150 Slot: 47
	public override void NBMDAOFPKGK(int _DNBFMLBNAEE_point)
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
            save.DNBFMLBNAEE_point += _DNBFMLBNAEE_point;
            save.NFIOKIBPJCJ_uptime = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
        }
    }

	// RVA: 0x131D4A0 Offset: 0x131D4A0 VA: 0x131D4A0 Slot: 49
	protected override void ODPJGHOJIOH(int LHJCOPMMIGO)
    {
        if(KBACNOCOANM_Ranking != null)
        {
            LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LMBBEGIAKAD_EventQuest;
            if(ev != null)
            {
                OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
                PJDGDNJNCNM_UpdateStatusImpl(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime());
                if(IBNKPMPFLGI_IsRankReward || NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2 ||
					NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MINDIGBAJFG_3 ||
					NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_ChallengePeriod_5 ||
					NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_6_Counting) //0x6cU
				{
                    KKLGENJKEBN.HHCJCDFCLOB.LDOBHAAIDEJ_UpdateRankingScore(KBACNOCOANM_Ranking.OCGFKMHNEOF_name_for_api, LHJCOPMMIGO, BOAGCEOHJEO.GOAOBNBGDBJ(GLIMIGNNGGB_RankingStart, LOLAANGCGDO_RankingEnd2, save.NFIOKIBPJCJ_uptime, save.DNBFMLBNAEE_point), () =>
                    {
                        //0x1327A14
                        CDINKAANIAA_Rank[LHJCOPMMIGO] = (int)KKLGENJKEBN.HHCJCDFCLOB.LPPCNCMEDFA_Rank;
                        PLOOEECNHFB_IsDone = true;
                        int ranking_point_max = ev.LPJLEHAJADA_GetIntParam("ranking_point_max", 1000000);
                        ILCCJNDFFOB.HHCJCDFCLOB.NNFGBBCHLPC(PGIIDPEGGPI_EventId, "StringLiteral_10929", EJDJIBPKKNO_BasePoint, save.DNBFMLBNAEE_point, ranking_point_max, KKLGENJKEBN.HHCJCDFCLOB.DFBALJAPHMC_DroppedPlayer);
                    }, () =>
                    {
                        //0x1327C4C
                        PLOOEECNHFB_IsDone = true;
                    }, () =>
                    {
                        //0x1327C74
                        PLOOEECNHFB_IsDone = true;
                        NPNNPNAIONN_IsError = true;
                    });
                    return;
                }
            }
        }
        PLOOEECNHFB_IsDone = true;
    }

	// RVA: 0x131D9C8 Offset: 0x131D9C8 VA: 0x131D9C8 Slot: 50
	protected override void MFJFBNPLFBE_OnReceieveTotalReward(bool GIPBIDFJFLL)
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PMMENILLJJE_EventQuest.PFAKPFKJJKA() == null)
            {
                OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
                JANMJPOKLFL_InventoryUtil.JCHLONCMPAJ_Clear();
                JOFBHHHLBBN_Rewards.Clear();
                long point = FBGDBGKNKOD_GetCurrentPoint();
                List<string> ls = new List<string>(3);
                StringBuilder str = new StringBuilder();
                for(int i = 0; i < ev.FCIPEDFHFEM_TotalRewards.Count; i++)
                {
                    if(point >= ev.FCIPEDFHFEM_TotalRewards[i].DNBFMLBNAEE_point)
                    {
                        if(!save.BHIAKGKHKGD_IsReceived(i))
                        {
                            str.Length = 0;
                            str.Append(PGIIDPEGGPI_EventId);
                            str.Append(':');
                            str.Append(i);
                            str.Append(':');
                            str.Append(ev.FCIPEDFHFEM_TotalRewards[i].DNBFMLBNAEE_point);
                            JANMJPOKLFL_InventoryUtil.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.MGEFPKOJKBL_9, str.ToString());
                            for(int j = 0; j < ev.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards.Count; j++)
                            {
                                if(ev.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards[j].NMKEOMCMIPP_RewardId > 0)
                                {
                                    ls.Add(ev.NGHKJOEDLIP_Settings.OCDMGOGMHGE_KeyPrefix + ev.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards[j].NMKEOMCMIPP_RewardId.ToString());
                                }
                                JANMJPOKLFL_InventoryUtil.CPIICACGNBH_AddItem(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, ev.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards[j].GLCLFMGPMAN_ItemId, ev.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards[j].HMFFHLPNMPH_count, null, 0);
                                save.IPNLHCLFIDB_SetRewardReceived(i, true);
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
                        PLOOEECNHFB_IsDone = true;
                        DENHAAGACPD();
                    };
                    req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request NHECPMNKEFK) =>
                    {
                        //0x1326F00
                        NPNNPNAIONN_IsError = true;
                        PLOOEECNHFB_IsDone = true;
                    };
                    return;
                }
                DENHAAGACPD();
            }
            else
            {
                NPNNPNAIONN_IsError = true;
            }
        }
        PLOOEECNHFB_IsDone = true;
    }

	// RVA: 0x131E800 Offset: 0x131E800 VA: 0x131E800 Slot: 52
	public override void FAMFKPBPIAA_GetRankingPlayerList(bool PFFJNEFNAMI, int _CJHEHIMLGGL_Position, int LHJCOPMMIGO, LIOLBKLMMIK _KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK _IDAEHNGOKAE_OnRankingError, DJBHIFLHJLK _JGKOLBLPMPG_OnFail)
    {
        NPNNPNAIONN_IsError = false;
        PLOOEECNHFB_IsDone = false;
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            if(IBNKPMPFLGI_IsRankReward)
            {
                KKLGENJKEBN.HHCJCDFCLOB.FAMFKPBPIAA_GetRankingPlayerList(KBACNOCOANM_Ranking.OCGFKMHNEOF_name_for_api, PFFJNEFNAMI, _CJHEHIMLGGL_Position, LHJCOPMMIGO, (int NEFEFHBHFFF, List<IBIGBMDANNM> MAGKKPOFJIM) =>
                {
                    //0x1327CB8
                    PLOOEECNHFB_IsDone = true;
                    _KLMFJJCNBIP_OnSuccess(NEFEFHBHFFF, MAGKKPOFJIM);
                }, () =>
                {
                    //0x1327D14
                    PLOOEECNHFB_IsDone = true;
                    _IDAEHNGOKAE_OnRankingError();
                }, () =>
                {
                    //0x1327D60
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

	// RVA: 0x131EB38 Offset: 0x131EB38 VA: 0x131EB38 Slot: 53
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
                //0x1327DC4
                PLOOEECNHFB_IsDone = true;
                _KLMFJJCNBIP_OnSuccess(_JGNBPFCJLKI_d, MAGKKPOFJIM);
            }, () =>
            {
                //0x1327E20
                PLOOEECNHFB_IsDone = true;
                _IDAEHNGOKAE_OnRankingError();
            }, () =>
            {
                //0x1327E6C
                PLOOEECNHFB_IsDone = true;
                NPNNPNAIONN_IsError = true;
                _JGKOLBLPMPG_OnFail();
            }, false);
        }
    }

	// RVA: 0x131ED3C Offset: 0x131ED3C VA: 0x131ED3C
	// private int APJDIPINLLK(List<int> HNLFPKNBOHE, int _PPFNGGCBJKC_id) { }

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
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
            PFPJHJJAGAG_Rewards.Clear();
            EGIPGHCDMII_RankData[LHJCOPMMIGO].Clear();
            if(KBACNOCOANM_Ranking != null)
            {
                for(int i = 0; i < KBACNOCOANM_Ranking.AHJNPEAMCCH_rewards.Count; i++)
                {
                    MAOCCKFAOPC m = new MAOCCKFAOPC();
                    m.JBDGBPAAAEF_HighRank = KBACNOCOANM_Ranking.AHJNPEAMCCH_rewards[i].JPHDGGNAKMO_high_rank;
                    m.GHANKNIBALB_LowRank = KBACNOCOANM_Ranking.AHJNPEAMCCH_rewards[i].FGCAJEAIABA_low_rank;
                    m.MJGAMDBOMHD_InventoryMessage = KBACNOCOANM_Ranking.AHJNPEAMCCH_rewards[i].IPFEKNMBEBI_inventory_message;
                    m.HBHMAKNGKFK_items = KBACNOCOANM_Ranking.AHJNPEAMCCH_rewards[i].HBHMAKNGKFK_items;
                    EGIPGHCDMII_RankData[LHJCOPMMIGO].Add(m);
                }
            }
            for(int i = 0; i < ev.FCIPEDFHFEM_TotalRewards.Count; i++)
            {
                IHAEIOAKEMG ih = new IHAEIOAKEMG();
                for(int j = 0; j < ev.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards.Count; j++)
                {
                    MFDJIFIIPJD m = new MFDJIFIIPJD();
                    m.KHEKNNFCAOI_Init(ev.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards[j].GLCLFMGPMAN_ItemId, ev.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards[j].HMFFHLPNMPH_count);
                    m.JOPPFEHKNFO_Pickup = ev.FCIPEDFHFEM_TotalRewards[i].JOPPFEHKNFO_Pickup;
                    ih.HBHMAKNGKFK_items.Add(m);
                }
                ih.HMEOAKCLKJE_IsReceived = save.BHIAKGKHKGD_IsReceived(i);
                ih.FIOIKMOIJGK_Point = ev.FCIPEDFHFEM_TotalRewards[i].DNBFMLBNAEE_point;
                ih.OJELCGDDAOM_MissingPoint = (int)(ih.FIOIKMOIJGK_Point - save.DNBFMLBNAEE_point);
                PFPJHJJAGAG_Rewards.Add(ih);
            }
        }
    }

	// // RVA: 0x131E4D4 Offset: 0x131E4D4 VA: 0x131E4D4
	private void DENHAAGACPD()
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
            for(int i = 0; i < PFPJHJJAGAG_Rewards.Count; i++)
            {
                PFPJHJJAGAG_Rewards[i].HMEOAKCLKJE_IsReceived = save.BHIAKGKHKGD_IsReceived(i);
                PFPJHJJAGAG_Rewards[i].OJELCGDDAOM_MissingPoint = (int)(PFPJHJJAGAG_Rewards[i].FIOIKMOIJGK_Point - save.DNBFMLBNAEE_point);
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
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            if(IBNKPMPFLGI_IsRankReward)
            {
                HLFHJIDHJMP = null;
                OKPEFAPPFDH_GetRanksAroundSelf req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new OKPEFAPPFDH_GetRanksAroundSelf(false));
                req.EMPNJPMAKBF_Id = KBACNOCOANM_Ranking.PPFNGGCBJKC_id;
                req.MJGOBEGONON_Type = 0;
                req.NHPCKCOPKAM_from = 0;
                req.PJFKNNNDMIA_to = 0;
                req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request KCFBGMKDIMI) =>
                {
                    //0x1327ED0
                    if(JGJFFKPFMDB.BDGBCCGLLAJ_IsRankingError(KCFBGMKDIMI.CJMFJOMECKI_ErrorId))
                    {
                        if(KCFBGMKDIMI.CJMFJOMECKI_ErrorId == SakashoErrorId.RANKING_DROPPED_PLAYER)
                        {
                            FKKDIDMGLMI_IsDroppedPlayer = true;
                        }
                        OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
                        save.HPLMECLKFID_RRcv = true;
                        PJDGDNJNCNM_UpdateStatusImpl(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime());
                        PLOOEECNHFB_IsDone = true;
                    }
                    else
                    {
                        PLOOEECNHFB_IsDone = true;
                        NPNNPNAIONN_IsError = true;
                    }
                };
                req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request KCFBGMKDIMI) =>
                {
                    //0x13281FC
                    OKPEFAPPFDH_GetRanksAroundSelf r = KCFBGMKDIMI as OKPEFAPPFDH_GetRanksAroundSelf;
                    if(r.NFEAMMJIMPG_Result.EJDEDOJFOOK_Ranks.Count == 0)
                    {
                        OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
                        save.HPLMECLKFID_RRcv = true;
                        PJDGDNJNCNM_UpdateStatusImpl(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime());
                        PLOOEECNHFB_IsDone = true;
                    }
                    else
                    {
                        HLFHJIDHJMP = new NHGEHCMPDAI();
                        OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
                        save.DNBFMLBNAEE_point = r.NFEAMMJIMPG_Result.EJDEDOJFOOK_Ranks[0].KNIFCANOHOC_score;
                        HLFHJIDHJMP.FJOLNJLLJEJ_rank = r.NFEAMMJIMPG_Result.EJDEDOJFOOK_Ranks[0].FJOLNJLLJEJ_rank;
                        KKLGENJKEBN.HHCJCDFCLOB.DNJKPPCBINA(KBACNOCOANM_Ranking.OCGFKMHNEOF_name_for_api, () =>
                        {
                            //0x13288D0
                            for(int i = 0; i < KKLGENJKEBN.HHCJCDFCLOB.PHOPJDPEHJA.Count; i++)
                            {
                                MFDJIFIIPJD m = new MFDJIFIIPJD();
                                m.KHEKNNFCAOI_Init(KKLGENJKEBN.HHCJCDFCLOB.PHOPJDPEHJA[i].JJBGOIMEIPF_ItemId, KKLGENJKEBN.HHCJCDFCLOB.PHOPJDPEHJA[i].MBJIFDBEDAC_item_count);
                                HLFHJIDHJMP.HBHMAKNGKFK_items.Add(m);
                            }
                            ILCCJNDFFOB.HHCJCDFCLOB.GIBLHFKIMDA(this);
                            OFNLIBDEIFA_EventQuest.GCCDGBBDICM save_ = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
                            save_.HPLMECLKFID_RRcv = true;
                            PLOOEECNHFB_IsDone = true;
                        }, () =>
                        {
                            //0x1328C48
                            HLFHJIDHJMP = null;
                            ILCCJNDFFOB.HHCJCDFCLOB.GIBLHFKIMDA(this);
                            OFNLIBDEIFA_EventQuest.GCCDGBBDICM save_ = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
                            save_.HPLMECLKFID_RRcv = true;
                            PLOOEECNHFB_IsDone = true;
                        }, () =>
                        {
                            //0x1328E30
                            OFNLIBDEIFA_EventQuest.GCCDGBBDICM save_ = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
                            save_.HPLMECLKFID_RRcv = true;
                            PLOOEECNHFB_IsDone = true;
                            HLFHJIDHJMP = null;
                        }, () =>
                        {
                            //0x1328FBC
                            PLOOEECNHFB_IsDone = true;
                            HLFHJIDHJMP = null;
                        }, () =>
                        {
                            //0x1329004
                            PLOOEECNHFB_IsDone = true;
                            NPNNPNAIONN_IsError = true;
                        }, 0, -1);
                    }
                };
                return;
            }
        }
        PLOOEECNHFB_IsDone = true;
    }

	// RVA: 0x131FB38 Offset: 0x131FB38 VA: 0x131FB38 Slot: 59
	public override List<int> AEGDKBNNDBC_GetDrops()
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            return ev.NGHKJOEDLIP_Settings.EEOGPJJCKHH_Drops;
        }
        return null;
    }

	// // RVA: 0x131FCBC Offset: 0x131FCBC VA: 0x131FCBC
	// public int NOODJNMIDPN() { }

	// // RVA: 0x131FF18 Offset: 0x131FF18 VA: 0x131FF18
	// public void PNFDENHKMGK_SetDifficulty(int _AKNELONELJK_difficulty, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError) { }

	// // RVA: 0x13202DC Offset: 0x13202DC VA: 0x13202DC
	// public ALPMEPDDDIP.FDDIFOGNJEF MHPFJFDNILM() { }

	// RVA: 0x1320538 Offset: 0x1320538 VA: 0x1320538 Slot: 65
	protected override bool JLPDECMHLIM_CanShowStartAdventureInternal()
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
            PJDGDNJNCNM_UpdateStatusImpl(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime());
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
	public override void FGDDBFHGCGP_SetStartAdventureShown(bool _JKDJCFEBDHC_Enabled, long _JHNMKKNEENE_Time/* = 0*/)
    {
        if(_JKDJCFEBDHC_Enabled)
        {
            LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LMBBEGIAKAD_EventQuest;
            if(ev != null)
            {
                OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
                if(NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2)
                {
                    save.INLNJOGHLJE_Show |= 1;
                }
            }
        }
    }

	// RVA: 0x1320AF4 Offset: 0x1320AF4 VA: 0x1320AF4 Slot: 70
	public override void ADACMHAHHKC_PreSetupEventHome(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
    {
        N.a.StartCoroutineWatched(NJIEIJJMAHK_Corotuine_PreSetupEventHome(_BHFHGFKBOHH_OnSuccess, _AOCANKOMKFG_OnError));
    }

	// [IteratorStateMachineAttribute] // RVA: 0x6BD1B4 Offset: 0x6BD1B4 VA: 0x6BD1B4
	// // RVA: 0x1320B4C Offset: 0x1320B4C VA: 0x1320B4C
	private IEnumerator NJIEIJJMAHK_Corotuine_PreSetupEventHome(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
    {
        long IBCGNDADAEE_Time; // 0x20
        LMBBEGIAKAD_EventQuest KEHCNBNPJHB; // 0x28
        OFNLIBDEIFA_EventQuest.GCCDGBBDICM AIPLGDHHAJI; // 0x2C
        int JEKGKAPLIHO; // 0x30

        //0x1329834
        IBCGNDADAEE_Time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
        JMEHHJKCGNJ = null;
        PIBIGCIMJGC = null;
        LPFJADHHLHG = false;
        KEHCNBNPJHB = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LMBBEGIAKAD_EventQuest;
        if(KEHCNBNPJHB != null)
        {
            PJDGDNJNCNM_UpdateStatusImpl(IBCGNDADAEE_Time);
            MJFKJHJJLMN_GetRanks(0, false);
            while(!PLOOEECNHFB_IsDone)
                yield return null;
            if(!NPNNPNAIONN_IsError)
            {
                AIPLGDHHAJI = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PMMENILLJJE_EventQuest.FBCJICEPLED[KEHCNBNPJHB.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
                if(FKKDIDMGLMI_IsDroppedPlayer)
                {
                    JHHBAFKMBDL.HHCJCDFCLOB.PEIONAKEPCN_ShowRankingBanPopup(_AOCANKOMKFG_OnError);
                    yield break;
                }
                DateTime d1 = Utility.GetLocalDateTime(IBCGNDADAEE_Time);
                DateTime d2 = Utility.GetLocalDateTime(AIPLGDHHAJI.BEBJKJKBOGH_date);
                if(d1.Year != d2.Year || d1.Month != d2.Month || d1.Day != d2.Day)
                {
                    AIPLGDHHAJI.POENMEGPHCG_reset = 0;
                    AIPLGDHHAJI.BEBJKJKBOGH_date = IBCGNDADAEE_Time;
                }
                if(NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.GDOPLACICFE_4)
                {
                    AIPLGDHHAJI.ABBJBPLHFHA_Spurt = true;
                    LPFJADHHLHG = true;
                    PJDGDNJNCNM_UpdateStatusImpl(IBCGNDADAEE_Time);
                }
                JEKGKAPLIHO = (int)NGOFCFJHOMI_Status;
                switch(AIPLGDHHAJI.LGADCGFMLLD_step)
                {
                    case 0:
                    case 1:
                        if(JEKGKAPLIHO < 6)
                        {
                            CMPEJEHCOEI = true;
                            FDHDENLJLOL();
                            AIPLGDHHAJI.LGADCGFMLLD_step = 3;
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
                            AIPLGDHHAJI.LGADCGFMLLD_step = 6;
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
                            AIPLGDHHAJI.LGADCGFMLLD_step = 6;
                        break;
                    case 5:
                        {
                            PKADMPNDMGP ci = GAPOCIFPDDO_GetSelectedCardInfo();
                            OFNLIBDEIFA_EventQuest.AGFEALDEJOL ci2 = FPILJDOPPJC_GetSelectedCardSaveInfo();
                            if(!DBAEGNENPID_FailPointDisable || EGKODECGHNM())
                            {
                                ADFLCMBBNHH();
                                long v = AIPLGDHHAJI.DNBFMLBNAEE_point;
                                if(ci != null)
                                {
                                    JMEHHJKCGNJ = new NEJFNBKMPFD();
                                    JMEHHJKCGNJ.PHOPDCNFFEI = !EGKODECGHNM();
                                    JMEHHJKCGNJ.DCACDLIAJJK_Pts = ci.EIOFPIHABFC_Pts;
                                    JMEHHJKCGNJ.AMCCOGJACPK_CardId = ci.PPFNGGCBJKC_id;
                                    JMEHHJKCGNJ.AKNELONELJK_difficulty = ci.DGMIADAEGAI_TargetDifficultyType - 1;
                                    if(!JMEHHJKCGNJ.PHOPDCNFFEI)
                                    {
                                        JMEHHJKCGNJ.FPEOGFMKMKJ_Point = ci.EIOFPIHABFC_Pts;
                                    }
                                    else
                                    {
                                        JMEHHJKCGNJ.FPEOGFMKMKJ_Point = ci.IAGDDKLKGJN;
                                    }
                                    JMEHHJKCGNJ.FCLGIPFPIPH_DashBonus = AIPLGDHHAJI.CCABNCGIHNI_Rslt / 100;
                                    if(JMEHHJKCGNJ.FCLGIPFPIPH_DashBonus < 1)
                                    {
                                        JMEHHJKCGNJ.FCLGIPFPIPH_DashBonus = 1;
                                    }
                                    int l = ci2.KIFJKGDBDBH_lucky;
                                    if(l == 0)
                                    {
                                        l = 100;
                                    }
                                    else
                                    {
                                        l = KEHCNBNPJHB.NGHKJOEDLIP_Settings.HEABAENHIDE[JMEHHJKCGNJ.AKNELONELJK_difficulty];
                                    }
                                    JMEHHJKCGNJ.INDKDHNKFAB = l;
                                    JMEHHJKCGNJ.ANOCILKJGOJ_EpisodeCnt = AIPLGDHHAJI.JNAHAJFKKCB_EpiCount;
                                    JMEHHJKCGNJ.ODCLHPGHDHA_EpisodeBonus = AIPLGDHHAJI.NBNFHHLCMDH_EpiBo;
                                    JMEHHJKCGNJ.ODCLHPGHDHA_EpisodeBonus += 100;
                                    OOOOCFAFGCP o = new OOOOCFAFGCP();
                                    o.LJGOOOMOMMA_message = ci.FEMMDNIELFC_Desc;
                                    o.DNBFMLBNAEE_point = JMEHHJKCGNJ.FCLGIPFPIPH_DashBonus * (JMEHHJKCGNJ.ODCLHPGHDHA_EpisodeBonus * JMEHHJKCGNJ.FPEOGFMKMKJ_Point * JMEHHJKCGNJ.INDKDHNKFAB * 10 / 100 / 1000);
                                    NBMDAOFPKGK(o.DNBFMLBNAEE_point);
                                    JMEHHJKCGNJ.JKFCHNEININ_GetPoint = o.DNBFMLBNAEE_point;
                                    JMEHHJKCGNJ.BPJEOPHAJPP_PrevTotalPoint = (int)v;
                                    JMEHHJKCGNJ.AHOKAPCGJMA_TotalPoint = (int)AIPLGDHHAJI.DNBFMLBNAEE_point;
                                    JMEHHJKCGNJ.KLMPFGOCBHC_description = ci.FEMMDNIELFC_Desc;
                                    JMEHHJKCGNJ.NLEEDNLHBGP_Desc2 = ci.DCOFJKBIOAH_Desc2;
                                    JMEHHJKCGNJ.GHBPLHBNMBK_FreeMusicId = ci2.DELDCIMOBCE_FId;
                                    JMEHHJKCGNJ.KIFJKGDBDBH_lucky = ci2.KIFJKGDBDBH_lucky != 0;
                                }
                                FGMOMBKGCNF_UpdateRankingValue(0);
                                //LAB_01329a00
                                while(!PLOOEECNHFB_IsDone)
                                    yield return null;
                                if(!NPNNPNAIONN_IsError)
                                {
                                    MFJFBNPLFBE_OnReceieveTotalReward(false);
                                    while(!PLOOEECNHFB_IsDone)
                                        yield return null;
                                    if(!NPNNPNAIONN_IsError)
                                    {
                                        FDHDENLJLOL();
                                        if(JEKGKAPLIHO < 6)
                                        {
                                            //2
                                            //LAB_0132a040
                                            AIPLGDHHAJI.LGADCGFMLLD_step = 2;
                                        }
                                        else
                                        {
                                            //LAB_0132a038
                                            AIPLGDHHAJI.LGADCGFMLLD_step = 6;
                                        }
                                    }
                                    else
                                    {
                                        //LAB_01329c6c
                                        if(_AOCANKOMKFG_OnError != null)
                                            _AOCANKOMKFG_OnError();
                                        yield break;
                                    }
                                }
                                else
                                {
                                    //LAB_01329c6c
                                    if(_AOCANKOMKFG_OnError != null)
                                        _AOCANKOMKFG_OnError();
                                    yield break;
                                }
                            }
                            if(JEKGKAPLIHO > 5)
                                break;
                            if(ci != null && ci2 != null)
                            {
                                PIBIGCIMJGC = new BPKELFJPFEB();
                                PIBIGCIMJGC.AMCCOGJACPK_CardId = ci.PPFNGGCBJKC_id;
                                PIBIGCIMJGC.KKECHANCHJO = GBNDFCEDNMG.NKGDIBMNLNO(ci);
                                if(PIBIGCIMJGC.KKECHANCHJO == 1)
                                {
                                    PIBIGCIMJGC.FFECGHGBMIO = ci.JJECMJFDEEP_ClearConditionValue - ci2.OLDAGCNLJOI_progress;
                                }
                                else
                                {
                                    PIBIGCIMJGC.FFECGHGBMIO = ci.GLDIGCJNOBO_ClearCount - ci2.OLDAGCNLJOI_progress;
                                }
                                PIBIGCIMJGC.GHBPLHBNMBK_FreeMusicId = ci2.DELDCIMOBCE_FId;
                                PIBIGCIMJGC.PHOPDCNFFEI = false;
                                PIBIGCIMJGC.FCLGIPFPIPH_DashBonus = AIPLGDHHAJI.CCABNCGIHNI_Rslt > 99 ? AIPLGDHHAJI.CCABNCGIHNI_Rslt / 100 : 1;
                                if(AIPLGDHHAJI.CCABNCGIHNI_Rslt % 100 == 3)
                                {
                                    PIBIGCIMJGC.PHOPDCNFFEI = true;
                                }
                            }
                            //AIPLGDHHAJI
                            //4
                            //LAB_0132a040
                            AIPLGDHHAJI.LGADCGFMLLD_step = 4;
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
                //AIPLGDHHAJI.LGADCGFMLLD_step = 6;
                //switchD_01329fec_caseD_6
                OIMGJLOLPHK = false;
                if(JEKGKAPLIHO < 6)
                {
                    CEBFFLDKAEC_SecureInt v;
                    if(KEHCNBNPJHB.OHJFBLFELNK_m_intParam.TryGetValue(HOEKCEJINNA_new_episode_mver, out v))
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
                            if(b && KEHCNBNPJHB.OHJFBLFELNK_m_intParam.TryGetValue(FOKNMOMNHHD_new_episode_help_pict_id, out v))
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
                    if(_BHFHGFKBOHH_OnSuccess != null)
                        _BHFHGFKBOHH_OnSuccess();
                    PLOOEECNHFB_IsDone = true;
                }, () =>
                {
                    //0x13291F8
                    if(_AOCANKOMKFG_OnError != null)
                        _AOCANKOMKFG_OnError();
                    PLOOEECNHFB_IsDone = true;
                    NPNNPNAIONN_IsError = true;
                }, null);
            }
            else
            {
                //LAB_01329c6c
                if(_AOCANKOMKFG_OnError != null)
                    _AOCANKOMKFG_OnError();
                yield break;
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

	// // RVA: 0x1320C28 Offset: 0x1320C28 VA: 0x1320C28
	private void FDHDENLJLOL()
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            OFNLIBDEIFA_EventQuest.GCCDGBBDICM save/*NHLBKJCPLBL*/ = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
            save.MDADLCOCEBN_session_id = JDDGPJDKHNE.GPLMOKEIOLE();
            int maxDiff = PJLNJJIBFBN_HasExtremeDiff ? 4 : 3;
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
                    int idx = ev.HKODBHPMLCP_cards.FindIndex((PKADMPNDMGP _GHPLINIACBB_x) =>
                    {
                        //0x1329250
                        return _GHPLINIACBB_x.PPFNGGCBJKC_id == save.HKODBHPMLCP_cards[AOENBGCCFCO].PBEEPMLJGJC_Cid;
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
                        int OIPCCBHIKIA_index = l4[k];
                        int idx = l2.FindIndex((int _GHPLINIACBB_x) =>
                        {
                            //0x132934C
                            return ev.HKODBHPMLCP_cards[_GHPLINIACBB_x].JONPKLHMOBL_Category == ev.HKODBHPMLCP_cards[OIPCCBHIKIA_index].JONPKLHMOBL_Category;
                        });
                        if(idx < 0)
                        {
                            int v1 = GBNDFCEDNMG.GHAJJNPENFI(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, ev.HKODBHPMLCP_cards[OIPCCBHIKIA_index], l);
                            if(v1 != 0)
                            {
                                if(ev.HKODBHPMLCP_cards[OIPCCBHIKIA_index].MKNDAOHGOAK_weight > 0)
                                {
                                    HBHLOOKPPHM h = new HBHLOOKPPHM();
                                    h.OIPCCBHIKIA_index = OIPCCBHIKIA_index;
                                    h.GHBPLHBNMBK_FreeMusicId = v1;
                                    h.MKNDAOHGOAK_weight = ev.HKODBHPMLCP_cards[OIPCCBHIKIA_index].MKNDAOHGOAK_weight;
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
                        max += l3[k].MKNDAOHGOAK_weight;
                        l3[k].FCDKJAKLGMB_TargetValue = max;
                    }
                    int r3 = UnityEngine.Random.Range(0, max);
                    int found = 0;
                    for(int k = 0; k < l3.Count; k++)
                    {
                        found = k;
                        if(r3 <= l3[k].FCDKJAKLGMB_TargetValue)
                            break;
                    }
                    PKADMPNDMGP c = ev.HKODBHPMLCP_cards[l3[found].OIPCCBHIKIA_index];
                    l2.Add(l3[found].OIPCCBHIKIA_index);
                    int r4 = UnityEngine.Random.Range(0, 1000);
                    int idx2 = j + i * 3;
                    save.HKODBHPMLCP_cards[idx2].LHPDDGIJKNB_Reset(r);
                    save.HKODBHPMLCP_cards[idx2].PBEEPMLJGJC_Cid = c.PPFNGGCBJKC_id;
                    save.HKODBHPMLCP_cards[idx2].DELDCIMOBCE_FId = c.HBJJCDIMOPO_TargetMusicConditionId;
                    if(!FAJNDPEKHAA_LuckyDisable)
                    {
                        int r5 = UnityEngine.Random.Range(0, 1000);
                        save.HKODBHPMLCP_cards[idx2].KIFJKGDBDBH_lucky = ((r5 < ev.NGHKJOEDLIP_Settings.EPHAKDAPAHE[i]) ? 1 : 0) << (save.ABBJBPLHFHA_Spurt ? 1 : 0);
                    }
                    else
                    {
                        save.HKODBHPMLCP_cards[idx2].KIFJKGDBDBH_lucky = 0;
                    }
                    r *= 0x2c19;
                }
                diff += 3;
            }
        }
    }

	// // RVA: 0x1321E30 Offset: 0x1321E30 VA: 0x1321E30
	public int BOLHIMADLBN(int _AKNELONELJK_difficulty)
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            return ev.NGHKJOEDLIP_Settings.HEABAENHIDE[_AKNELONELJK_difficulty];
        }
        return 0;
    }

	// // RVA: 0x1321FE0 Offset: 0x1321FE0 VA: 0x1321FE0
	// public PKADMPNDMGP NPCMANKMGCJ(int _AKNELONELJK_difficulty, int _IKPIDCFOFEA_no) { }

	// // RVA: 0x1322328 Offset: 0x1322328 VA: 0x1322328
	// public OFNLIBDEIFA_EventQuest.AGFEALDEJOL ALDHOIEBGNM(int _AKNELONELJK_difficulty, int _IKPIDCFOFEA_no) { }

	// // RVA: 0x13225BC Offset: 0x13225BC VA: 0x13225BC
	// public void DPBLJLFKMPL(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError) { }

	// // RVA: 0x1322934 Offset: 0x1322934 VA: 0x1322934
	// public void LLCMINJNADH(int _AKNELONELJK_difficulty, int _IKPIDCFOFEA_no, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError) { }

	// // RVA: 0x1322CE4 Offset: 0x1322CE4 VA: 0x1322CE4
	public PKADMPNDMGP GAPOCIFPDDO_GetSelectedCardInfo()
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
            OFNLIBDEIFA_EventQuest.AGFEALDEJOL card = save.HKODBHPMLCP_cards[save.BACCOJIDFJE_SelCard];
            return ev.HKODBHPMLCP_cards.Find((PKADMPNDMGP _GHPLINIACBB_x) =>
            {
                //0x13296AC
                return _GHPLINIACBB_x.PPFNGGCBJKC_id == card.PBEEPMLJGJC_Cid;
            });
        }
        return null;
    }

	// // RVA: 0x1323044 Offset: 0x1323044 VA: 0x1323044
	public OFNLIBDEIFA_EventQuest.AGFEALDEJOL FPILJDOPPJC_GetSelectedCardSaveInfo()
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
            return save.HKODBHPMLCP_cards[save.BACCOJIDFJE_SelCard];
        }
        return null;
    }

	// // RVA: 0x13232F0 Offset: 0x13232F0 VA: 0x13232F0
	// public int BFEKPKAGGMH() { }

	// // RVA: 0x1323350 Offset: 0x1323350 VA: 0x1323350
	// public int CDKDCKOAEMA() { }

	// // RVA: 0x13235E0 Offset: 0x13235E0 VA: 0x13235E0
	public int KGIIPFJIAGB_GetPlayCost(int _AKNELONELJK_difficulty)
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
            return ev.NGHKJOEDLIP_Settings.HIAMHLLHAON_PlayCost[_AKNELONELJK_difficulty];
        }
        return 0;
    }

	// // RVA: 0x1323850 Offset: 0x1323850 VA: 0x1323850
	// public void NPFGIPABOMC(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP HDOKKIGGAEI, DJBHIFLHJLK _AOCANKOMKFG_OnError, bool JDPGHNKKGNE = True) { }

	// // RVA: 0x1323F70 Offset: 0x1323F70 VA: 0x1323F70
	public void OAIBHKLKFKB(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, int _FCLGIPFPIPH_DashBonus, int _LCCGDFGGIHI_PlayCount, int _ANOPDAGJIKG_FriendSceneId, int MHADLGMJKGK)
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            PKADMPNDMGP d = GAPOCIFPDDO_GetSelectedCardInfo();
            OFNLIBDEIFA_EventQuest.AGFEALDEJOL a = FPILJDOPPJC_GetSelectedCardSaveInfo();
            OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
            if(GBNDFCEDNMG.EIJIGDCMJLB(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, d, OMNOFMEBLAD, this, true))
            {
                GBNDFCEDNMG.BBEKHCGKIAJ(d, a, OMNOFMEBLAD);
                int v = d.PPFNGGCBJKC_id;
                if(GBNDFCEDNMG.EGKODECGHNM(d, a))
                {
                    UnityEngine.Debug.Log(string.Format("StringLiteral_12472 {0} {1}", v, d.FEMMDNIELFC_Desc));
                    save.CCABNCGIHNI_Rslt = (_FCLGIPFPIPH_DashBonus * _LCCGDFGGIHI_PlayCount * 100) | 1;
                }
                else
                {
                    UnityEngine.Debug.Log(string.Format("StringLiteral_12473 {0} {1}", v, d.FEMMDNIELFC_Desc));
                    save.CCABNCGIHNI_Rslt = (_FCLGIPFPIPH_DashBonus * _LCCGDFGGIHI_PlayCount * 100) | 2;
                }
            }
            else
            {
                save.CCABNCGIHNI_Rslt = (_FCLGIPFPIPH_DashBonus * _LCCGDFGGIHI_PlayCount * 100) | 3;
            }
            save.LGADCGFMLLD_step = 5;
            save.JNAHAJFKKCB_EpiCount = LEPNPBIMHGM_GetEquippedEpisodesWithBonus(_ANOPDAGJIKG_FriendSceneId).Count;
            save.NBNFHHLCMDH_EpiBo = CEICDKGEONG_GetEquippedEpisodesBonusValue(_ANOPDAGJIKG_FriendSceneId, MHADLGMJKGK);
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
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            if(NGOFCFJHOMI_Status < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_6_Counting)
            {
                OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
                return save.LGADCGFMLLD_step == 5 && EGKODECGHNM();
            }
        }
        return false;
    }

	// // RVA: 0x1324944 Offset: 0x1324944 VA: 0x1324944
	// public bool AGBLHCGKAIO() { }

	// RVA: 0x1324BCC Offset: 0x1324BCC VA: 0x1324BCC Slot: 33
	public override bool MPMKJNJGFEF_IsEntry()
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
            return save.IMFBCJOIJKJ_Entry;
        }
        return false;
    }

	// RVA: 0x1324E2C Offset: 0x1324E2C VA: 0x1324E2C Slot: 69
	public override void HAAEJDGMICH(LBNLAENLPNK.JEKODBEDOMM _INDDJNMPONH_type, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
    {
        string v = null;
        if(_INDDJNMPONH_type == 0)
        {
            v = JOPOPMLFINI_QuestName + "_rule";
        }
        if(string.IsNullOrEmpty(v))
        {
            _BHFHGFKBOHH_OnSuccess();
        }
        MBCPNPNMFHB.HHCJCDFCLOB.FLLLPBIECCP(v, _BHFHGFKBOHH_OnSuccess, _AOCANKOMKFG_OnError);
    }

	// RVA: 0x1324F54 Offset: 0x1324F54 VA: 0x1324F54 Slot: 71
	public override int BAEPGOAMBDK(string _LJNAKDMILMC_key, int MNCOAGOKNAO)
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            return ev.LPJLEHAJADA_GetIntParam(_LJNAKDMILMC_key, MNCOAGOKNAO);
        }
        return MNCOAGOKNAO;
    }

	// RVA: 0x13250D4 Offset: 0x13250D4 VA: 0x13250D4 Slot: 72
	public override string MAICAKMIBEM(string _LJNAKDMILMC_key, string MNCOAGOKNAO)
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            return ev.EFEGBHACJAL_GetStringParam(_LJNAKDMILMC_key, MNCOAGOKNAO);
        }
        return MNCOAGOKNAO;
    }

	// RVA: 0x1325254 Offset: 0x1325254 VA: 0x1325254 Slot: 68
	public override bool GJMGKBDGMOP(long LPEKHFOMCAH)
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            if(BHABCGJCGNO != null)
            {
                if(LPEKHFOMCAH < DPJCPDKALGI_RankingEnd)
                {
                    OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
                    if(save.OMCAOJJGOGG_Lb != NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD)
                    {
                        save.OMCAOJJGOGG_Lb = NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD;
                        if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(BHABCGJCGNO.JJBGOIMEIPF_ItemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem)
                        {
                            int itId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(BHABCGJCGNO.JJBGOIMEIPF_ItemId);
                            EGOLBAPFHHD_Common.FKLHGOGJOHH enIt = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.KFEBOFKAHAJ_EngItem[itId - 1];
                            enIt.BFINGCJHOHI_cnt += BHABCGJCGNO.MBJIFDBEDAC_item_count;
                            enIt.BEBJKJKBOGH_date = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
                            ILCCJNDFFOB.HHCJCDFCLOB.JAHALBMOANH(BHABCGJCGNO.JJBGOIMEIPF_ItemId, OAGBCBBHMPF.COIIJOEKBDH.IGAJCMKNLDL_14, PGIIDPEGGPI_EventId.ToString(), BHABCGJCGNO.MBJIFDBEDAC_item_count, enIt.BFINGCJHOHI_cnt, 1);
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
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
            return save.MDADLCOCEBN_session_id;
        }
        return "";
    }

	// RVA: 0x132617C Offset: 0x132617C VA: 0x132617C Slot: 73
	public override List<string> IJCPBPFEGDM_GetResourcesFilePathList(long _JHNMKKNEENE_Time)
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            if(MNNNLDFNNCD(_JHNMKKNEENE_Time))
            {
                KEODKEGFDLD_FreeMusicInfo fInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(ev.NGHKJOEDLIP_Settings.JKFPADIAKCK_Songs);
                return SoundResource.CreateBgmFilePathList(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(fInfo.DLAEJOBELBH_MusicId).KKPAHLMJKIH_WavId);
            }
        }
        return null;
    }

	// RVA: 0x1326460 Offset: 0x1326460 VA: 0x1326460 Slot: 74
	public override int EDNMFMBLCGF_GetWavId()
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            KEODKEGFDLD_FreeMusicInfo fInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(ev.NGHKJOEDLIP_Settings.JKFPADIAKCK_Songs);
            return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(fInfo.DLAEJOBELBH_MusicId).KKPAHLMJKIH_WavId;
        }
        return 0;
    }

	// RVA: 0x13266E8 Offset: 0x13266E8 VA: 0x13266E8 Slot: 38
	public override void EMEPJNLHJHJ(int GJEADBKFAPA, int _AKNELONELJK_difficulty, bool _GIKLNODJKFK_IsLine6, ref int APMGOLOPLFP, ref int FBBDNLAMPMH)
    {
        APMGOLOPLFP = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.JJIBDCAIBIO_LuckCoef0;
        FBBDNLAMPMH = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.AMNBEMCJCHF_LuckCoef1;
    }

	// // RVA: 0x13267FC Offset: 0x13267FC VA: 0x13267FC
	public OFNLIBDEIFA_EventQuest.HGCEGAAJFBC JIPPHOKGLIH_GetMusicSaveData(int _GOIKCKHMBDL_FreeMusicId, bool HOENAFAJMGI/* = False*/)
    {
        LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LMBBEGIAKAD_EventQuest;
        if(ev != null)
        {
            OFNLIBDEIFA_EventQuest.GCCDGBBDICM save;
            if(HOENAFAJMGI)
            {
                save = CIOECGOMILE.HHCJCDFCLOB.MNJHBCIIHED_PrevServerData.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
            }
            else
            {
                save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
            }
            OFNLIBDEIFA_EventQuest.HGCEGAAJFBC m = save.FFMHJIJBKEN_music.Find((OFNLIBDEIFA_EventQuest.HGCEGAAJFBC _GHPLINIACBB_x) =>
            {
                //0x13297F8
                return _GHPLINIACBB_x.GOIKCKHMBDL_FreeMusicId == _GOIKCKHMBDL_FreeMusicId;
            });
            if(m == null)
            {
                return save.FFMHJIJBKEN_music.Find((OFNLIBDEIFA_EventQuest.HGCEGAAJFBC _GHPLINIACBB_x) =>
                {
                    //0x1326F8C
                    return _GHPLINIACBB_x.GOIKCKHMBDL_FreeMusicId == 0;
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
            LMBBEGIAKAD_EventQuest ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LMBBEGIAKAD_EventQuest;
            if(ev != null)
            {
                OFNLIBDEIFA_EventQuest.GCCDGBBDICM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PMMENILLJJE_EventQuest.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
                save.INLNJOGHLJE_Show = (int)(save.INLNJOGHLJE_Show & 0xfffffffb);
                GFHKFKHBIGM = false;
            }
        }
    }
}
