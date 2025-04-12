
using System;
using System.Collections.Generic;

public class JDMLEAOJAJO
{
	// // RVA: 0x1C332C8 Offset: 0x1C332C8 VA: 0x1C332C8
	public HAEDCCLHEMN_EventBattle GGBDCHMDCFA()
    {
        if(JEPBIIJDGEF_EventInfo.HHCJCDFCLOB != null)
        {
            return JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as HAEDCCLHEMN_EventBattle;
        }
        return null;
    }

	// // RVA: 0x1C336AC Offset: 0x1C336AC VA: 0x1C336AC
	public ICFLJACCIKF_EventBattle FFMBHIBHPBA(HAEDCCLHEMN_EventBattle MOHDLLIJELH)
    {
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(MOHDLLIJELH.JOPOPMLFINI_QuestId);
		if(db != null)
		{
			return db as ICFLJACCIKF_EventBattle;
        }
        return null;
    }
}

public class CDDODEHEKGB : JDMLEAOJAJO
{
    public class BIPCCMDIHKF
    {
        public List<EMGOCNMMPHC> MPALKPJIDPA; // 0x8
        private const long FBGGEFFJJHB = 160015421274; // 0x2541a98f5a
        public long PCLNFCNIECH_Crypted = FBGGEFFJJHB; // 0x10
        public long HHPIJHADAOB_Crypted = FBGGEFFJJHB; // 0x18

        public long PDBPFJJCADD_OpenAt { get { return PCLNFCNIECH_Crypted ^ FBGGEFFJJHB; } set { PCLNFCNIECH_Crypted = value ^ FBGGEFFJJHB; } } //0x12AFA0C FOACOMBHPAC 0x12AFA24 NBACOBCOJCA
        public long FDBNFFNFOND_CloseAt { get { return HHPIJHADAOB_Crypted ^ FBGGEFFJJHB; } set { HHPIJHADAOB_Crypted = value ^ FBGGEFFJJHB; } } //0x12AFA40 BPJOGHJCLDJ 0x12AFA58 NLJKMCHOCBK

        // RVA: 0x12AF7E0 Offset: 0x12AF7E0 VA: 0x12AF7E0
        public BIPCCMDIHKF()
        {
            KHEKNNFCAOI();
        }

        // RVA: 0x12AFA78 Offset: 0x12AFA78 VA: 0x12AFA78
        public void KHEKNNFCAOI()
        {
            MPALKPJIDPA = new List<EMGOCNMMPHC>();
            MPALKPJIDPA.Clear();
            PDBPFJJCADD_OpenAt = 0;
            FDBNFFNFOND_CloseAt = 0;
        }

        // // RVA: 0x12AF828 Offset: 0x12AF828 VA: 0x12AF828
        public void ODNEBIAFLJP(EMGOCNMMPHC LGCIECNGAIL)
        {
            MPALKPJIDPA.Add(LGCIECNGAIL);
            PDBPFJJCADD_OpenAt = LGCIECNGAIL.KJBGCLPMLCG_OpenAt;
            FDBNFFNFOND_CloseAt = LGCIECNGAIL.GJFPFFBAKGK_CloseAt;
        }
    }

	private const int CNEPIDPKILF = 3;
	private List<BIPCCMDIHKF> CJFMFAEINBG; // 0x8

	// RVA: 0x12AEDAC Offset: 0x12AEDAC VA: 0x12AEDAC
	public CDDODEHEKGB()
    {
        KHEKNNFCAOI();
    }

	// // RVA: 0x12AEDCC Offset: 0x12AEDCC VA: 0x12AEDCC
	public void KHEKNNFCAOI()
    {
        CJFMFAEINBG = new List<BIPCCMDIHKF>();
        CJFMFAEINBG.Clear();
        PJHMKEGKMGH();
    }

	// // RVA: 0x12AEE80 Offset: 0x12AEE80 VA: 0x12AEE80
	public void PJHMKEGKMGH()
    {
        HAEDCCLHEMN_EventBattle data = GGBDCHMDCFA();
        if(data != null)
        {
            DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(data.JOPOPMLFINI_QuestId);
            if(db != null)
            {
                ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
                BIPCCMDIHKF d = null;
                bool isSameOpenThanPrev = false;
                long prevOpenAt = 0;
                long prevCloseAt = 0;
                for(int i = 0; i < dbSection.GCFOLMHPDBG.Count; i++)
                {
                    ICFLJACCIKF_EventBattle.KGHHHPHBGGM d2 = dbSection.GCFOLMHPDBG[i];
                    EMGOCNMMPHC d3 = new EMGOCNMMPHC();
                    ICFLJACCIKF_EventBattle.OABJKIKLDKP song = dbSection.IJJHFGOIDOK_Songs[d2.KOJMEPJBOJM_EvMusicId - 1];
                    KEODKEGFDLD_FreeMusicInfo info = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(song.MPLGPBNJDJB_FMusicId);
                    if(info.PPEGAKEIEGM_Enabled == 2)
                    {
                        if(song.PLALNIIBLOF_Enabled == 2)
                        {
                            d3.KHEKNNFCAOI(i + 1, song.MPLGPBNJDJB_FMusicId);
                            d3.KJBGCLPMLCG_OpenAt = d2.PDBPFJJCADD_OpenAt;
                            d3.GJFPFFBAKGK_CloseAt = d2.FDBNFFNFOND_CloseAt;
                            isSameOpenThanPrev = d3.KJBGCLPMLCG_OpenAt == prevOpenAt;
                            if(prevOpenAt == 0 && prevCloseAt == 0)
                            {
                                d = new BIPCCMDIHKF();
                                d.KHEKNNFCAOI();
                                d.ODNEBIAFLJP(d3);
                            }
                            else
                            {
                                if(!isSameOpenThanPrev)
                                {
                                    for(int j = 0; j < 3 - d.MPALKPJIDPA.Count; j++)
                                    {
                                        d.MPALKPJIDPA.Add(new EMGOCNMMPHC());
                                    }
                                    CJFMFAEINBG.Add(d);
                                    d = new BIPCCMDIHKF();
                                    d.KHEKNNFCAOI();
                                    d.ODNEBIAFLJP(d3);
                                }
                                else
                                {
                                    d.MPALKPJIDPA.Add(d3);
                                    isSameOpenThanPrev = true;
                                }
                            }
                            prevOpenAt = d2.PDBPFJJCADD_OpenAt;
                            prevCloseAt = d2.FDBNFFNFOND_CloseAt;
                        }
                    }
                }
                if(d != null && isSameOpenThanPrev)
                {
                    for(int i = 0; i < 3 - d.MPALKPJIDPA.Count; i++)
                    {
                        d.MPALKPJIDPA.Add(new EMGOCNMMPHC());
                    }
                    CJFMFAEINBG.Add(d);
                }
                CJFMFAEINBG.Sort((BIPCCMDIHKF HKICMNAACDA, BIPCCMDIHKF BNKHBCBJBKI) =>
                {
                    //0x12AF988
                    return HKICMNAACDA.PDBPFJJCADD_OpenAt.CompareTo(BNKHBCBJBKI.PDBPFJJCADD_OpenAt);
                });
            }
        }
    }

	// // RVA: 0x12AF904 Offset: 0x12AF904 VA: 0x12AF904
	// public List<CDDODEHEKGB.BIPCCMDIHKF> LIHKAGGIBHO() { }
}

public class DCAKKIJODME : JDMLEAOJAJO
{
	public List<EMGOCNMMPHC> MPALKPJIDPA = new List<EMGOCNMMPHC>(); // 0x8
	private const int FBGGEFFJJHB = 625060239; // 0x2541a98f
	public int GEOGJLLKONC_Crypted = FBGGEFFJJHB; // 0xC
	public int PEKBNIPCGJB_Crypted = FBGGEFFJJHB; // 0x10

	public int IGIPKOJJIIA_TotalScore { get { return GEOGJLLKONC_Crypted ^ FBGGEFFJJHB; } set { GEOGJLLKONC_Crypted = value ^ FBGGEFFJJHB; } } //0x176EE50 NMEEMHPEIFG 0x176EE64 DOJPMEDBMGB
	public int FHBAEDLKEEN_Rank { get { return PEKBNIPCGJB_Crypted ^ FBGGEFFJJHB; } set { PEKBNIPCGJB_Crypted = value ^ FBGGEFFJJHB; } } //0x176EE78 GMMJFPPANLA 0x176EE8C EJCOLGLELOL

	// // RVA: 0x176EEA0 Offset: 0x176EEA0 VA: 0x176EEA0
	public void KHEKNNFCAOI(bool PDEFINMIIDE = false)
    {
        IGIPKOJJIIA_TotalScore = 0;
        FHBAEDLKEEN_Rank = 0;
        PJHMKEGKMGH(PDEFINMIIDE);
    }

	// // RVA: 0x176F77C Offset: 0x176F77C VA: 0x176F77C
	public List<int> BIJJHHFMODA()
    {
        List<int> res = new List<int>();
        res.Clear();
        HAEDCCLHEMN_EventBattle ev = GGBDCHMDCFA();
        if(ev != null)
        {
            ICFLJACCIKF_EventBattle dbEvent = FFMBHIBHPBA(ev);
            if(dbEvent != null)
            {
                for(int i = 0; i < dbEvent.GCFOLMHPDBG.Count; i++)
                {
                    if(dbEvent.GCFOLMHPDBG[i].PLALNIIBLOF_Enabled == 2)
                    {
                        int evSongId = dbEvent.GCFOLMHPDBG[i].KOJMEPJBOJM_EvMusicId;
                        if(!res.Exists((int GHPLINIACBB) =>
                        {
                            //0x177019C
                            return evSongId == GHPLINIACBB;
                        }))
                        {
                            res.Add(evSongId);
                        }
                    }
                }
            }
        }
        return res;
    }

	// // RVA: 0x176EEB4 Offset: 0x176EEB4 VA: 0x176EEB4
	public void PJHMKEGKMGH(bool MCBICECCNGO = false)
    {
        MPALKPJIDPA.Clear();
        HAEDCCLHEMN_EventBattle ev = GGBDCHMDCFA();
        if(ev != null)
        {
            ICFLJACCIKF_EventBattle dbEvent = FFMBHIBHPBA(ev);
            if(dbEvent != null)
            {
                CCPKHBECNLH_EventBattle.BHIDLKBIJFK saveEv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DKJBALDICBG_EventBattle.FBCJICEPLED[dbEvent.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
                List<int> l = BIJJHHFMODA();
                int min = Math.Min(l.Count, saveEv.PCNOCBANFOO_ExResult.Count);
                for(int i = 0; i < min; i++)
                {
                    EMGOCNMMPHC data = new EMGOCNMMPHC();
                    data.KHEKNNFCAOI(i + 1, dbEvent.IJJHFGOIDOK_Songs[l[i] - 1].MPLGPBNJDJB_FMusicId);
                    BAJFMCIDGOK data2 = saveEv.PCNOCBANFOO_ExResult[i];
                    data.KNIFCANOHOC_Sc = data2.KNIFCANOHOC_Sc;
                    data.OHBNMGEKPNF_HasC = data2.EPKDHJLMKLF_C > 0;
                    data.DPCFADCFMOA_Wl = data2.PFGLKPNGKLN_Wl;
                    data.EKHAFFFELCO_CSkill = dbEvent.IJJHFGOIDOK_Songs[l[i] - 1].CPBFAMJEODF_CSkill;
                    data.EDHAJJHIKHE_LSkill = dbEvent.IJJHFGOIDOK_Songs[l[i] - 1].MGHPJNNDCIG_LSkill;
                    data.BGJDHCEOIDB_ClassRank = 1;
                    if(data.OHBNMGEKPNF_HasC)
                    {
                        data.BGJDHCEOIDB_ClassRank = data2.EPKDHJLMKLF_C;
                    }
                    data.IOOBNLAHLEJ_WinBonus = data2.LJLCKFLJNPC_Bn;
                    data.FOFJCOHAFCG_Ec = data2.CEAEKLNDENC_Ec;
                    data.CLEFJPKPOGB_Ep = data2.FAKIHAPMADE_Ep;
                    if(MCBICECCNGO && i == ev.CKCPAMDDNPF.BOLHMCFBGBP_SongIdx)
                    {
                        data.KDNCMJBDCLE_ExBattleScore = ev.CKCPAMDDNPF.OOEKGFAIFPK_ExBattleMusicScore;
                        data.LDIODNEADGG_Hs = ev.CKCPAMDDNPF.JCCABPBHJPA_ExHighScore;
                        data.FFHMPNGJCLK_IsHighScore = ev.CKCPAMDDNPF.FFHMPNGJCLK;
                    }
                    else
                    {
                        //LAB_0176f5f8
                        data.KDNCMJBDCLE_ExBattleScore = ((data.IOOBNLAHLEJ_WinBonus + data.KNIFCANOHOC_Sc) * 10) / 10;
                        data.LDIODNEADGG_Hs = data2.JKAMFMNGEBB_Hs;
                        data.FFHMPNGJCLK_IsHighScore = false;
                    }
                    MPALKPJIDPA.Add(data);
                }
                IGIPKOJJIIA_TotalScore = ev.GFNODPDPNMJ_GetSumExHighScore();
                FHBAEDLKEEN_Rank = ev.CDINKAANIAA_Rank[1];
            }
        }
    }

	// // RVA: 0x176FB5C Offset: 0x176FB5C VA: 0x176FB5C
	public bool FNHNJNEJFLF(int GOBMOGJNEFA, bool DPCFADCFMOA)
    {
        HAEDCCLHEMN_EventBattle ev = GGBDCHMDCFA();
        if(ev != null)
        {
            ICFLJACCIKF_EventBattle dbSection = FFMBHIBHPBA(ev);
            if(dbSection != null)
            {
                bool res = false;
                CCPKHBECNLH_EventBattle.BHIDLKBIJFK saveEv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DKJBALDICBG_EventBattle.FBCJICEPLED[dbSection.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
                if(saveEv.PCNOCBANFOO_ExResult[GOBMOGJNEFA].JKAMFMNGEBB_Hs < ev.CKCPAMDDNPF.OOEKGFAIFPK_ExBattleMusicScore)
                {
                    saveEv.PCNOCBANFOO_ExResult[GOBMOGJNEFA].JKAMFMNGEBB_Hs = ev.CKCPAMDDNPF.OOEKGFAIFPK_ExBattleMusicScore;
                    res = true;
                }
                saveEv.PCNOCBANFOO_ExResult[GOBMOGJNEFA].KNIFCANOHOC_Sc = ev.CKCPAMDDNPF.GCAPLLEIAAI_Score;
                saveEv.PCNOCBANFOO_ExResult[GOBMOGJNEFA].LJLCKFLJNPC_Bn = ev.CKCPAMDDNPF.KOOMDFGADKH_ExBattleWinBonus;
                saveEv.PCNOCBANFOO_ExResult[GOBMOGJNEFA].PFGLKPNGKLN_Wl = DPCFADCFMOA;
                saveEv.PCNOCBANFOO_ExResult[GOBMOGJNEFA].EPKDHJLMKLF_C = ev.CKCPAMDDNPF.EIMCIBOANHE_CurrentClass;
                saveEv.PCNOCBANFOO_ExResult[GOBMOGJNEFA].CEAEKLNDENC_Ec = ev.CKCPAMDDNPF.ANOCILKJGOJ_EpisodeCnt;
                saveEv.PCNOCBANFOO_ExResult[GOBMOGJNEFA].FAKIHAPMADE_Ep = ev.CKCPAMDDNPF.ODCLHPGHDHA_EpisodeCntBns;
                return res;
            }
        }
        return false;
    }

	// // RVA: 0x176FF04 Offset: 0x176FF04 VA: 0x176FF04
	public List<EMGOCNMMPHC> JNALKFEADEM()
    {
        return MPALKPJIDPA;
    }

	// // RVA: 0x176FF0C Offset: 0x176FF0C VA: 0x176FF0C
	public EMGOCNMMPHC KLMPGMPHNOP(int GOBMOGJNEFA)
    {
        if(MPALKPJIDPA.Count <= GOBMOGJNEFA)
            return null;
        return MPALKPJIDPA[GOBMOGJNEFA];
    }

	// // RVA: 0x176FFC8 Offset: 0x176FFC8 VA: 0x176FFC8
	public int AJBHLNMPIPD_GetIdxByMusicId(int GHBPLHBNMBK)
    {
        EMGOCNMMPHC em = MPALKPJIDPA.Find((EMGOCNMMPHC GHPLINIACBB) =>
        {
            //0x17701B0
            return GHPLINIACBB.GHBPLHBNMBK_FreeMusicId == GHBPLHBNMBK;
        });
        if(em != null && em.NPHNPEAGFFM_Id > 0)
        {
            return em.NPHNPEAGFFM_Id - 1;
        }
        return -1;
    }
}
