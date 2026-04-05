
using System.Collections.Generic;
using XeApp.Game;

public class CIKHPBBNEIM
{
    public class ODGCADPPIFA
    {
        public int FDLEABMKOGO_BonusBefore; // 0x8
        public int ALDAOOLPHCH_BonusAfter; // 0xC
        public int BCCHOBPJJKE_SceneId; // 0x10
        public int BPMAIEFLOPP; // 0x14
        public bool GKBNFLFEIOF_IsAssist; // 0x18
        public bool ONCKEDBOIDN_IsEvo; // 0x19
        public bool JKCLMIDAIMI_IsAssistEvo; // 0x1A
        public bool IADCHIFJHOJ_Unlocked; // 0x1B
        public bool CBLHLEKLLDE_IsSet; // 0x1C
        public bool ILOKENBBBAE_Available; // 0x1D
    }

    public class PBJEFDNBBCD
    {
        public List<ODGCADPPIFA> FLJNOOPOAGI = new List<ODGCADPPIFA>(); // 0x8
        public List<int> MLLPMJFOKEC_GachaIds = new List<int>(); // 0xC
        public int KELFCMEOPPM_EpisodeId; // 0x10
    }

	private List<PBJEFDNBBCD> EMCDEMHBFDB = new List<PBJEFDNBBCD>(); // 0x8

	// // RVA: 0xFF8418 Offset: 0xFF8418 VA: 0xFF8418
	public void OBKGEDCKHHE_Init(IKDICBBFBMI_NetEventBaseController OBMKLJFKAPH, bool _CMEOKJMCEBH_IsGoDiva)
    {
        OBKGEDCKHHE_Init(OBMKLJFKAPH, GameManager.Instance.ViewPlayerData.DPLBHAIKPGL_GetTeam(_CMEOKJMCEBH_IsGoDiva));
    }

	// // RVA: 0xFF9CE8 Offset: 0xFF9CE8 VA: 0xFF9CE8
	public void NFEECBNKKHD(IKDICBBFBMI_NetEventBaseController OBMKLJFKAPH, int CEHNJCIIKDN, bool _CMEOKJMCEBH_IsGoDiva)
    {
        OBKGEDCKHHE_Init(OBMKLJFKAPH, GameManager.Instance.ViewPlayerData.JKIJFGGMNAN_GetUnit(CEHNJCIIKDN, _CMEOKJMCEBH_IsGoDiva));
    }

	// // RVA: 0xFF84F4 Offset: 0xFF84F4 VA: 0xFF84F4
	private void OBKGEDCKHHE_Init(IKDICBBFBMI_NetEventBaseController OBMKLJFKAPH, JLKEOGLJNOD_TeamInfo _MLAFAACKKBG_Unit)
    {
        EMCDEMHBFDB.Clear();
        for(int i = 0; i < OBMKLJFKAPH.LHAKGDAGEMM_EpBonusInfos.Count; i++)
        {
            IKDICBBFBMI_NetEventBaseController.CEGDBNNIDIG d = OBMKLJFKAPH.LHAKGDAGEMM_EpBonusInfos[i];
            int KELFCMEOPPM_EpisodeId = d.KELFCMEOPPM_EpisodeId;
            List<MLIBEPGADJH_Scene.KKLDOOJBJMN> l = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_table.FindAll((MLIBEPGADJH_Scene.KKLDOOJBJMN _GHPLINIACBB_x) =>
            {
                //0xFFA128
                return KELFCMEOPPM_EpisodeId == _GHPLINIACBB_x.KELFCMEOPPM_EpisodeId;
            });
            PBJEFDNBBCD p = new PBJEFDNBBCD();
            float f = 0;
            p.KELFCMEOPPM_EpisodeId = KELFCMEOPPM_EpisodeId;
            if(d.KELFCMEOPPM_EpisodeId == KELFCMEOPPM_EpisodeId)
            {
                f = d.MIHNKIHNBBL_BaseBonus;
            }
            p.MLLPMJFOKEC_GachaIds.AddRange(d.MLLPMJFOKEC_GachaIds);
            for(int j = 0; j < l.Count; j++)
            {
                if(l[j].PPEGAKEIEGM_Enabled > 1)
                {
                    if(!l[j].MCCIFLKCNKO_Feed)
                    {
                        ODGCADPPIFA GJLFANGDGCL_Target = new ODGCADPPIFA();
                        GJLFANGDGCL_Target.BCCHOBPJJKE_SceneId = l[j].BCCHOBPJJKE_SceneId;
                        GJLFANGDGCL_Target.BPMAIEFLOPP = l[j].EKLIPGELKCL_Rarity;
                        MMPBPOIFDAF_Scene.PMKOFEIONEG saveScene = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.PNLOINMCCKH_Scene.OPIBAPEGCLA_Scenes[l[j].BCCHOBPJJKE_SceneId - 1];
                        GJLFANGDGCL_Target.IADCHIFJHOJ_Unlocked = saveScene.IHIAFIHAAPO_Unlocked;
                        GJLFANGDGCL_Target.CBLHLEKLLDE_IsSet = false;
                        GJLFANGDGCL_Target.ILOKENBBBAE_Available = false;
                        GJLFANGDGCL_Target.GKBNFLFEIOF_IsAssist = false;
                        GJLFANGDGCL_Target.ONCKEDBOIDN_IsEvo = saveScene.JPIPENJGGDD_NumBoard > 0;
                        if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.OEEJKKFOBKD(l[j].BCCHOBPJJKE_SceneId))
                        {
                            GJLFANGDGCL_Target.ONCKEDBOIDN_IsEvo = true;
                        }
                        IKDICBBFBMI_NetEventBaseController.MEBJJBHPMEO ik = OBMKLJFKAPH.DHOMAEOEFMJ_EpBonuByScene.Find((IKDICBBFBMI_NetEventBaseController.MEBJJBHPMEO _GHPLINIACBB_x) =>
                        {
                            //0xFFA16C
                            return _GHPLINIACBB_x.CNKFPJCGNFE_SceneId == GJLFANGDGCL_Target.BCCHOBPJJKE_SceneId;
                        });
                        int a1, a2;
                        if(ik == null)
                        {
                            IKDICBBFBMI_NetEventBaseController.NJJDBBCHBNP nj = OBMKLJFKAPH.PGDAMNENGDA_EpBonusBySceneRarity[l[j].EKLIPGELKCL_Rarity - 1];
                            a1 = nj.IJKFFIKGLJM_BonusBefore;
                            a2 = nj.DCBMFNOIENM_BonusAfter;
                        }
                        else
                        {
                            a1 = ik.GNFBMCGMCFO_BonusBefore;
                            a2 = ik.BFFGFAMJAIG_BonusAfter;
                        }
                        GJLFANGDGCL_Target.FDLEABMKOGO_BonusBefore = (int)(f * a1);
                        GJLFANGDGCL_Target.ALDAOOLPHCH_BonusAfter = (int)(f * a2);
                        for(int k = 0; k < 3; k++)
                        {
                            if(_MLAFAACKKBG_Unit.DJPFJGKGOOF_Setting.FDBOPFEOENF_diva[k].DIPKCALNIII_diva_id != 0)
                            {
                                for(int kk = 0; kk < 3; kk++)
                                {
                                    if(GJLFANGDGCL_Target.BCCHOBPJJKE_SceneId == _MLAFAACKKBG_Unit.DJPFJGKGOOF_Setting.FDBOPFEOENF_diva[k].EBDNICPAFLB_s_slot[kk])
                                    {
                                        GJLFANGDGCL_Target.CBLHLEKLLDE_IsSet = true;
                                    }
                                }
                            }
                        }
                        if(GameManager.Instance.SelectedGuestData != null && 
                            GameManager.Instance.SelectedGuestData.KHGKPKDBMOH_GetAssistScene() != null)
                        {
                            if(GameManager.Instance.SelectedGuestData.KHGKPKDBMOH_GetAssistScene().BCCHOBPJJKE_SceneId == GJLFANGDGCL_Target.BCCHOBPJJKE_SceneId)
                            {
                                GJLFANGDGCL_Target.JKCLMIDAIMI_IsAssistEvo = GameManager.Instance.SelectedGuestData.KHGKPKDBMOH_GetAssistScene().CGIELKDLHGE_GetEvolveId() > 1;
                                GJLFANGDGCL_Target.GKBNFLFEIOF_IsAssist = true;
                                if(!GJLFANGDGCL_Target.JKCLMIDAIMI_IsAssistEvo)
                                {
                                    if(GJLFANGDGCL_Target.CBLHLEKLLDE_IsSet)
                                    {
                                        GJLFANGDGCL_Target.GKBNFLFEIOF_IsAssist = false;
                                        if(!GJLFANGDGCL_Target.JKCLMIDAIMI_IsAssistEvo)
                                        {
                                            GJLFANGDGCL_Target.GKBNFLFEIOF_IsAssist = !GJLFANGDGCL_Target.ONCKEDBOIDN_IsEvo;
                                        }
                                    }
                                }
                                GJLFANGDGCL_Target.CBLHLEKLLDE_IsSet = true;
                                if(GJLFANGDGCL_Target.GKBNFLFEIOF_IsAssist)
                                {
                                    GJLFANGDGCL_Target.BPMAIEFLOPP = GameManager.Instance.SelectedGuestData.KHGKPKDBMOH_GetAssistScene().JKGFBFPIMGA_Rarity;
                                }
                            }
                        }
                        p.FLJNOOPOAGI.Add(GJLFANGDGCL_Target);
                    }
                }
            }
            p.FLJNOOPOAGI.Sort((ODGCADPPIFA _HKICMNAACDA_a, ODGCADPPIFA _BNKHBCBJBKI_b) =>
            {
                //0xFFA0B4
                if(_HKICMNAACDA_a.BPMAIEFLOPP == _BNKHBCBJBKI_b.BPMAIEFLOPP)
                {
                    if(_BNKHBCBJBKI_b.ALDAOOLPHCH_BonusAfter == _HKICMNAACDA_a.ALDAOOLPHCH_BonusAfter)
                    {
                        return _BNKHBCBJBKI_b.BCCHOBPJJKE_SceneId.CompareTo(_HKICMNAACDA_a.BCCHOBPJJKE_SceneId);
                    }
                    return _BNKHBCBJBKI_b.ALDAOOLPHCH_BonusAfter.CompareTo(_HKICMNAACDA_a.ALDAOOLPHCH_BonusAfter);
                }
                return _BNKHBCBJBKI_b.BPMAIEFLOPP.CompareTo(_HKICMNAACDA_a.BPMAIEFLOPP);
            });
            int a3 = -1;
            int a4 = -1;
            for(int j = 0; j < p.FLJNOOPOAGI.Count; j++)
            {
                if(p.FLJNOOPOAGI[j].CBLHLEKLLDE_IsSet)
                {
                    bool a5 = true;
                    if(a3 < 0)
                    {
                        p.FLJNOOPOAGI[j].ILOKENBBBAE_Available = true;
                        if(!p.FLJNOOPOAGI[j].ONCKEDBOIDN_IsEvo)
                        {
                            a5 = p.FLJNOOPOAGI[j].JKCLMIDAIMI_IsAssistEvo;
                        }
                    }
                    else
                    {
                        int a6;
                        if(!p.FLJNOOPOAGI[j].ONCKEDBOIDN_IsEvo && !p.FLJNOOPOAGI[j].JKCLMIDAIMI_IsAssistEvo)
                        {
                            a6 = p.FLJNOOPOAGI[j].FDLEABMKOGO_BonusBefore;
                        }
                        else
                        {
                            a6 = p.FLJNOOPOAGI[j].ALDAOOLPHCH_BonusAfter;
                        }
                        if(a6 <= a4)
                        {
                            if(a6 < a4 || !p.FLJNOOPOAGI[j].GKBNFLFEIOF_IsAssist)
                                continue;
                        }
                        p.FLJNOOPOAGI[a3].ILOKENBBBAE_Available = true;
                        a5 = p.FLJNOOPOAGI[j].ONCKEDBOIDN_IsEvo;
                    }
                    a3 = j;
                    if(!a5)
                        a4 = p.FLJNOOPOAGI[j].FDLEABMKOGO_BonusBefore;
                    else
                        a4 = p.FLJNOOPOAGI[j].ALDAOOLPHCH_BonusAfter;
                }
            }
            EMCDEMHBFDB.Add(p);
        }
    }

	// // RVA: 0xFF9F38 Offset: 0xFF9F38 VA: 0xFF9F38
	public PBJEFDNBBCD GGHMLFOFELH(int _KELFCMEOPPM_EpisodeId)
    {
        return EMCDEMHBFDB.Find((PBJEFDNBBCD _GHPLINIACBB_x) =>
        {
            //0xFFA1B8
            return _GHPLINIACBB_x.KELFCMEOPPM_EpisodeId == _KELFCMEOPPM_EpisodeId;
        });
    }
}
