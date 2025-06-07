
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
        public bool CBLHLEKLLDE; // 0x1C
        public bool ILOKENBBBAE_Available; // 0x1D
    }

    public class PBJEFDNBBCD
    {
        public List<ODGCADPPIFA> FLJNOOPOAGI = new List<ODGCADPPIFA>(); // 0x8
        public List<int> MLLPMJFOKEC_GachaIds = new List<int>(); // 0xC
        public int KELFCMEOPPM; // 0x10
    }

	private List<PBJEFDNBBCD> EMCDEMHBFDB = new List<PBJEFDNBBCD>(); // 0x8

	// // RVA: 0xFF8418 Offset: 0xFF8418 VA: 0xFF8418
	public void OBKGEDCKHHE(IKDICBBFBMI_EventBase OBMKLJFKAPH, bool CMEOKJMCEBH)
    {
        OBKGEDCKHHE(OBMKLJFKAPH, GameManager.Instance.ViewPlayerData.DPLBHAIKPGL_GetTeam(CMEOKJMCEBH));
    }

	// // RVA: 0xFF9CE8 Offset: 0xFF9CE8 VA: 0xFF9CE8
	public void NFEECBNKKHD(IKDICBBFBMI_EventBase OBMKLJFKAPH, int CEHNJCIIKDN, bool CMEOKJMCEBH)
    {
        OBKGEDCKHHE(OBMKLJFKAPH, GameManager.Instance.ViewPlayerData.JKIJFGGMNAN_GetUnit(CEHNJCIIKDN, CMEOKJMCEBH));
    }

	// // RVA: 0xFF84F4 Offset: 0xFF84F4 VA: 0xFF84F4
	private void OBKGEDCKHHE(IKDICBBFBMI_EventBase OBMKLJFKAPH, JLKEOGLJNOD_TeamInfo MLAFAACKKBG)
    {
        EMCDEMHBFDB.Clear();
        for(int i = 0; i < OBMKLJFKAPH.LHAKGDAGEMM_EpBonusInfos.Count; i++)
        {
            IKDICBBFBMI_EventBase.CEGDBNNIDIG d = OBMKLJFKAPH.LHAKGDAGEMM_EpBonusInfos[i];
            int KELFCMEOPPM = d.KELFCMEOPPM_EpId;
            List<MLIBEPGADJH_Scene.KKLDOOJBJMN> l = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList.FindAll((MLIBEPGADJH_Scene.KKLDOOJBJMN GHPLINIACBB) =>
            {
                //0xFFA128
                return KELFCMEOPPM == GHPLINIACBB.KELFCMEOPPM_Ep;
            });
            PBJEFDNBBCD p = new PBJEFDNBBCD();
            float f = 0;
            p.KELFCMEOPPM = KELFCMEOPPM;
            if(d.KELFCMEOPPM_EpId == KELFCMEOPPM)
            {
                f = d.MIHNKIHNBBL_BaseBonus;
            }
            p.MLLPMJFOKEC_GachaIds.AddRange(d.MLLPMJFOKEC_GachaIds);
            for(int j = 0; j < l.Count; j++)
            {
                if(l[j].PPEGAKEIEGM_En > 1)
                {
                    if(!l[j].MCCIFLKCNKO_Feed)
                    {
                        ODGCADPPIFA GJLFANGDGCL = new ODGCADPPIFA();
                        GJLFANGDGCL.BCCHOBPJJKE_SceneId = l[j].BCCHOBPJJKE_Id;
                        GJLFANGDGCL.BPMAIEFLOPP = l[j].EKLIPGELKCL_Rarity;
                        MMPBPOIFDAF_Scene.PMKOFEIONEG saveScene = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA[l[j].BCCHOBPJJKE_Id - 1];
                        GJLFANGDGCL.IADCHIFJHOJ_Unlocked = saveScene.IHIAFIHAAPO_Unlocked;
                        GJLFANGDGCL.CBLHLEKLLDE = false;
                        GJLFANGDGCL.ILOKENBBBAE_Available = false;
                        GJLFANGDGCL.GKBNFLFEIOF_IsAssist = false;
                        GJLFANGDGCL.ONCKEDBOIDN_IsEvo = saveScene.JPIPENJGGDD_Mlt > 0;
                        if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.OEEJKKFOBKD(l[j].BCCHOBPJJKE_Id))
                        {
                            GJLFANGDGCL.ONCKEDBOIDN_IsEvo = true;
                        }
                        IKDICBBFBMI_EventBase.MEBJJBHPMEO ik = OBMKLJFKAPH.DHOMAEOEFMJ_EpBonuByScene.Find((IKDICBBFBMI_EventBase.MEBJJBHPMEO GHPLINIACBB) =>
                        {
                            //0xFFA16C
                            return GHPLINIACBB.CNKFPJCGNFE_SceneId == GJLFANGDGCL.BCCHOBPJJKE_SceneId;
                        });
                        int a1, a2;
                        if(ik == null)
                        {
                            IKDICBBFBMI_EventBase.NJJDBBCHBNP nj = OBMKLJFKAPH.PGDAMNENGDA_EpBonusBySceneRarity[l[j].EKLIPGELKCL_Rarity - 1];
                            a1 = nj.IJKFFIKGLJM_BonusBefore;
                            a2 = nj.DCBMFNOIENM_BonusAfter;
                        }
                        else
                        {
                            a1 = ik.GNFBMCGMCFO_BonusBefore;
                            a2 = ik.BFFGFAMJAIG_BonusAfter;
                        }
                        GJLFANGDGCL.FDLEABMKOGO_BonusBefore = (int)(f * a1);
                        GJLFANGDGCL.ALDAOOLPHCH_BonusAfter = (int)(f * a2);
                        for(int k = 0; k < 3; k++)
                        {
                            if(MLAFAACKKBG.DJPFJGKGOOF_ScoreTeam.FDBOPFEOENF_MainDivas[k].DIPKCALNIII_Id != 0)
                            {
                                for(int kk = 0; kk < 3; kk++)
                                {
                                    if(GJLFANGDGCL.BCCHOBPJJKE_SceneId == MLAFAACKKBG.DJPFJGKGOOF_ScoreTeam.FDBOPFEOENF_MainDivas[k].EBDNICPAFLB_SSlot[kk])
                                    {
                                        GJLFANGDGCL.CBLHLEKLLDE = true;
                                    }
                                }
                            }
                        }
                        if(GameManager.Instance.SelectedGuestData != null && 
                            GameManager.Instance.SelectedGuestData.KHGKPKDBMOH_GetAssistScene() != null)
                        {
                            if(GameManager.Instance.SelectedGuestData.KHGKPKDBMOH_GetAssistScene().BCCHOBPJJKE_SceneId == GJLFANGDGCL.BCCHOBPJJKE_SceneId)
                            {
                                GJLFANGDGCL.JKCLMIDAIMI_IsAssistEvo = GameManager.Instance.SelectedGuestData.KHGKPKDBMOH_GetAssistScene().CGIELKDLHGE_GetEvolveId() > 1;
                                GJLFANGDGCL.GKBNFLFEIOF_IsAssist = true;
                                if(!GJLFANGDGCL.JKCLMIDAIMI_IsAssistEvo)
                                {
                                    if(GJLFANGDGCL.CBLHLEKLLDE)
                                    {
                                        GJLFANGDGCL.GKBNFLFEIOF_IsAssist = false;
                                        if(!GJLFANGDGCL.JKCLMIDAIMI_IsAssistEvo)
                                        {
                                            GJLFANGDGCL.GKBNFLFEIOF_IsAssist = !GJLFANGDGCL.ONCKEDBOIDN_IsEvo;
                                        }
                                    }
                                }
                                GJLFANGDGCL.CBLHLEKLLDE = true;
                                if(GJLFANGDGCL.GKBNFLFEIOF_IsAssist)
                                {
                                    GJLFANGDGCL.BPMAIEFLOPP = GameManager.Instance.SelectedGuestData.KHGKPKDBMOH_GetAssistScene().JKGFBFPIMGA_Rarity;
                                }
                            }
                        }
                        p.FLJNOOPOAGI.Add(GJLFANGDGCL);
                    }
                }
            }
            p.FLJNOOPOAGI.Sort((ODGCADPPIFA HKICMNAACDA, ODGCADPPIFA BNKHBCBJBKI) =>
            {
                //0xFFA0B4
                if(HKICMNAACDA.BPMAIEFLOPP == BNKHBCBJBKI.BPMAIEFLOPP)
                {
                    if(BNKHBCBJBKI.ALDAOOLPHCH_BonusAfter == HKICMNAACDA.ALDAOOLPHCH_BonusAfter)
                    {
                        return BNKHBCBJBKI.BCCHOBPJJKE_SceneId.CompareTo(HKICMNAACDA.BCCHOBPJJKE_SceneId);
                    }
                    return BNKHBCBJBKI.ALDAOOLPHCH_BonusAfter.CompareTo(HKICMNAACDA.ALDAOOLPHCH_BonusAfter);
                }
                return BNKHBCBJBKI.BPMAIEFLOPP.CompareTo(HKICMNAACDA.BPMAIEFLOPP);
            });
            int a3 = -1;
            int a4 = -1;
            for(int j = 0; j < p.FLJNOOPOAGI.Count; j++)
            {
                if(p.FLJNOOPOAGI[j].CBLHLEKLLDE)
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
	public PBJEFDNBBCD GGHMLFOFELH(int KELFCMEOPPM)
    {
        return EMCDEMHBFDB.Find((PBJEFDNBBCD GHPLINIACBB) =>
        {
            //0xFFA1B8
            return GHPLINIACBB.KELFCMEOPPM == KELFCMEOPPM;
        });
    }
}
