
using System.Collections.Generic;
using XeApp.Game;
using XeApp.Game.Common;
using XeApp.Game.Menu;

public class BBOPDOIIOGM
{
	private const int FBGGEFFJJHB = 0x3f8d6a9b; //1066232475;
	private int CMCMKIBNIMO_SelDiva; // 0x8
	private int NMHLBCJHFCI_FId; // 0xC
	private List<FFHPBEPOMAK_DivaInfo> HDOIDHKIMNG_DivaList = new List<FFHPBEPOMAK_DivaInfo>(); // 0x10
	private List<MusicDataList> FONCNCLEFKA_Songs = new List<MusicDataList>(); // 0x14
	private List<MANPIONIGNO_EventGoDiva.IBNAEKMCIEO> NLBJOMFILIP = new List<MANPIONIGNO_EventGoDiva.IBNAEKMCIEO>(); // 0x18
	private int EPOAJCDDGBA_Crypted; // 0x1C
	private int HJOJJCKDPPJ_Crypted; // 0x20
	private int NNAEPFPHFMH_Crypted; // 0x24
	private List<LNELCMNJPIC_EventGoDiva.OPNEOOPNELG> AIJHALAENKH = new List<LNELCMNJPIC_EventGoDiva.OPNEOOPNELG>(); // 0x28

	public int EPCHEDJFAON_SelDiva { get { return CMCMKIBNIMO_SelDiva; } set { FJJBHOICNPO_SetSelDiva(value); } } //0xF2C72C BGMCHEIPJAO 0xF2C734 FBBAGJPGCME
	public int LEABGOOMOHI_FId { get { return NMHLBCJHFCI_FId; } set { KCDGGHBODKE_SetFId(value); } } //0xF2C77C PNDDDAPJINE 0xF2C784 PMKGEAGGKAI
	public List<FFHPBEPOMAK_DivaInfo> NBIGLBMHEDC_Divas { get { return HDOIDHKIMNG_DivaList; } } //0xF2C7CC DGMMMDMLCJF
	public List<MusicDataList> IPJKJBBDFKC { get { return FONCNCLEFKA_Songs; } } //0xF2C7D4 HGFJCDMLKGF
	public List<MANPIONIGNO_EventGoDiva.IBNAEKMCIEO> GEGAEDDGNMA_Bonuses { get { return NLBJOMFILIP; } } //0xF2C7DC EFPJMKGHDJG
	public int AFGCEMJEOJL_Rate { get { return EPOAJCDDGBA_Crypted ^ FBGGEFFJJHB; } set { EPOAJCDDGBA_Crypted = value ^ FBGGEFFJJHB; } } //0xF2C7E4 BOIEHDNBCPH 0xF2C7F8 MIGOFOPCMDF
	public int AHOKAPCGJMA_Point { get { return HJOJJCKDPPJ_Crypted ^ FBGGEFFJJHB; } set { HJOJJCKDPPJ_Crypted = value ^ FBGGEFFJJHB; } } //0xF2C80C GKLPFHEELGM 0xF2C820 EJPEPBGDDJM
	public int EIIOAPILKCP_MissingPoint { get { return NNAEPFPHFMH_Crypted ^ FBGGEFFJJHB; } set { NNAEPFPHFMH_Crypted = value ^ FBGGEFFJJHB; } } //0xF2C834 MOCECGJIKOF 0xF2C848 MAOMGPBIJLN
	public List<LNELCMNJPIC_EventGoDiva.OPNEOOPNELG> NJIKMDFPNDH { get { return AIJHALAENKH; } } //0xF2C85C LABKODOOBMN
	public bool EKJKEJJKEEK_HideBonusClosePopupFlag { get { return CCFENBAOPAG_LocalSaveData.KOGLAOFGHEN_GetHideBonusClosePopupFlag(); } set { LMENKAFNADG_SetHideBonusClosePopupFlag(value); } } //0xF2C864 HHHJLOICJDD 0xF2C97C CLAAEAPACCD
	public Difficulty.Type FCHBEILHFBC_Difficulty { get { return CCFENBAOPAG_LocalSaveData.FFACBDAJJJP_GetDifficulty(); } set { PNFDENHKMGK_SetDifficulty(value); } } //0xF2CA68 BDLOACHKGCE 0xF2CA98 CBNJPPLOEJK
	private ILDKBCLAFPB.APLMBKKCNKC_Select.CGAJFHFIGJG_GoDivaEvent CCFENBAOPAG_LocalSaveData { get
    {
        return GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.CECJBBEGOPG_GoDivaEvent;
    } } //0xF2C894 MBFPKEOKMGJ

	// // RVA: 0xF2CB84 Offset: 0xF2CB84 VA: 0xF2CB84
	public bool KHEKNNFCAOI()
    {
        MANPIONIGNO_EventGoDiva ev = OEGDCBLNNFF_GetEvent();
        if(ev != null)
        {
            long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
            LNELCMNJPIC_EventGoDiva dbSection = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(ev.JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
            CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveSection = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[dbSection.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
            FJJBHOICNPO_SetSelDiva(saveSection.AFKMGCLEPGA_SelDiva);
            KCDGGHBODKE_SetFId(saveSection.LEPHEGEHHOD_SelFId);
            AFGCEMJEOJL_Rate = saveSection.ADKDHKMPMHP_Rate;
            AHOKAPCGJMA_Point = saveSection.DNBFMLBNAEE_Point;
            EIIOAPILKCP_MissingPoint = 0;
            AIJHALAENKH.Clear();
            for(int i = 0; i < dbSection.FCIPEDFHFEM_Rewards.Count; i++)
            {
                if(AHOKAPCGJMA_Point < saveSection.DNBFMLBNAEE_Point)
                {
                    EIIOAPILKCP_MissingPoint = saveSection.DNBFMLBNAEE_Point - AHOKAPCGJMA_Point;
                    AIJHALAENKH.AddRange(dbSection.FCIPEDFHFEM_Rewards[i].AHJNPEAMCCH_Items);
                    break;
                }
            }
            HDOIDHKIMNG_DivaList.Clear();
            for(int i = 0; i < CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList.Count; i++)
            {
                FFHPBEPOMAK_DivaInfo diva = new FFHPBEPOMAK_DivaInfo();
                DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo saveDiva = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[i];
                diva.KHEKNNFCAOI(saveDiva.DIPKCALNIII_DivaId, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, false);
                HDOIDHKIMNG_DivaList.Add(diva);
            }
            FONCNCLEFKA_Songs.Clear();
            if(ev.NGOFCFJHOMI_Status < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6)
            {
                for(int i = 1; i < 7; i++)
                {
                    FONCNCLEFKA_Songs.Add(new MusicDataList(IBJAKJJICBC.ONHHIHBHKPK(i, t, false), IBJAKJJICBC.ONHHIHBHKPK(i, t, true)));
                }
            }
            else
            {
                for(int i = 1; i < 7; i++)
                {
                    FONCNCLEFKA_Songs.Add(new MusicDataList(IBJAKJJICBC.GCCBCAKFJMF(i, t, ev.PGIIDPEGGPI_EventId, false), IBJAKJJICBC.GCCBCAKFJMF(i, t, ev.PGIIDPEGGPI_EventId, true)));
                }
            }
            NLBJOMFILIP.Clear();
            NLBJOMFILIP.AddRange(ev.IHELCODOPJF());
            EKKFCEJECFK(ev.PGIIDPEGGPI_EventId);
            return true;
        }
        return false;
    }

	// // RVA: 0xF2D6E8 Offset: 0xF2D6E8 VA: 0xF2D6E8
	public int APFJJLFMIGN(int GHBPLHBNMBK, int AKNELONELJK, long JHNMKKNEENE)
    {
        LNELCMNJPIC_EventGoDiva.DPKGKNJBFBJ d = NJGBKGKFOED(GHBPLHBNMBK, JHNMKKNEENE);
        int v = OCLKNJELBFO(GHBPLHBNMBK, AKNELONELJK);
        int v2 = 100;
        if(HODCLEPALGP(0) < 100)
        {
            v2 = d.LJELGFAFGAB;
        }
        return (v * v2) / 100;
    }

	// // RVA: 0xF2D96C Offset: 0xF2D96C VA: 0xF2D96C
	public int PKGGEBBLJIN(int GHBPLHBNMBK, int AKNELONELJK, long JHNMKKNEENE)
    {
        LNELCMNJPIC_EventGoDiva.DPKGKNJBFBJ d = NJGBKGKFOED(GHBPLHBNMBK, JHNMKKNEENE);
        int v = OCLKNJELBFO(GHBPLHBNMBK, AKNELONELJK);
        int v2 = 100;
        if(HODCLEPALGP(1) < 100)
        {
            v2 = d.KNEDJFLCCLN;
        }
        return (v * v2) / 100;
    }

	// // RVA: 0xF2DA08 Offset: 0xF2DA08 VA: 0xF2DA08
	public int HLDLLGJIIJJ(int GHBPLHBNMBK, int AKNELONELJK, long JHNMKKNEENE)
    {
        LNELCMNJPIC_EventGoDiva.DPKGKNJBFBJ d = NJGBKGKFOED(GHBPLHBNMBK, JHNMKKNEENE);
        int v = OCLKNJELBFO(GHBPLHBNMBK, AKNELONELJK);
        int v2 = 100;
        if(HODCLEPALGP(2) < 100)
        {
            v2 = d.MBAMIOJNGBD;
        }
        return (v * v2) / 100;
    }

	// // RVA: 0xF2D818 Offset: 0xF2D818 VA: 0xF2D818
	public float HODCLEPALGP(int INDDJNMPONH)
    {
        if(NLBJOMFILIP.Count > 0)
        {
            if(INDDJNMPONH == 2)
                return NLBJOMFILIP[0].DGAELGEJPNA / 100.0f;
            if(INDDJNMPONH == 1)
                return NLBJOMFILIP[0].PKDAEFIGMLI / 100.0f;
            if(INDDJNMPONH == 0)
                return NLBJOMFILIP[0].NOEFINFEMBM / 100.0f;
        }
        return 0;
    }

	// // RVA: 0xF2DAA4 Offset: 0xF2DAA4 VA: 0xF2DAA4
	public int DDDKOKOPCGG()
    {
        MANPIONIGNO_EventGoDiva ev = OEGDCBLNNFF_GetEvent();
        if(ev != null)
            return ev.CLELOGKMNCE_GetEventSaveData().PFPGHILKGIG_BnsCnt;
        return 0;
    }

	// // RVA: 0xF2D784 Offset: 0xF2D784 VA: 0xF2D784
	public LNELCMNJPIC_EventGoDiva.DPKGKNJBFBJ NJGBKGKFOED(int GHBPLHBNMBK, long JHNMKKNEENE)
    {
        return OEGDCBLNNFF_GetEvent().NJGBKGKFOED(GHBPLHBNMBK, JHNMKKNEENE);
    }

	// // RVA: 0xF2D7D8 Offset: 0xF2D7D8 VA: 0xF2D7D8
	public int OCLKNJELBFO(int GHBPLHBNMBK, int AKNELONELJK)
    {
        return OEGDCBLNNFF_GetEvent().BDIJPOGEGNB(GHBPLHBNMBK, AKNELONELJK);
    }

	// // RVA: 0xF2DAEC Offset: 0xF2DAEC VA: 0xF2DAEC
	public long KBKGHDFBHAP_GetBonusEndTime(long JHNMKKNEENE)
    {
        MANPIONIGNO_EventGoDiva ev = OEGDCBLNNFF_GetEvent();
        if(ev != null)
        {
            return ev.KBKGHDFBHAP_GetBonusEndTime(JHNMKKNEENE);
        }
        return 0;
    }

	// // RVA: 0xF2DB38 Offset: 0xF2DB38 VA: 0xF2DB38
	public int GNDOGPBIGIL_GetCurrentBonusRate(long JHNMKKNEENE)
    {
        MANPIONIGNO_EventGoDiva ev = OEGDCBLNNFF_GetEvent();
        if(ev != null)
        {
            return ev.GNDOGPBIGIL_GetCurrentBonusRate(JHNMKKNEENE);
        }
        return 0;
    }

	// // RVA: 0xF2DB80 Offset: 0xF2DB80 VA: 0xF2DB80
	// public int AELBIEDNPGB() { }

	// // RVA: 0xF2DBBC Offset: 0xF2DBBC VA: 0xF2DBBC
	public bool HHAGNMOIENH_UseFeverTicket(out long PCCFAKEOBIC)
    {
        return OEGDCBLNNFF_GetEvent().HHAGNMOIENH_UseFeverTicket(out PCCFAKEOBIC);
    }

	// // RVA: 0xF2DBF4 Offset: 0xF2DBF4 VA: 0xF2DBF4
	public int GGOHAGALIGB_GetDivaSoulExp(int AHHJLDLAPAN)
    {
        MANPIONIGNO_EventGoDiva ev = OEGDCBLNNFF_GetEvent();
        if(ev != null)
        {
            return ev.CLELOGKMNCE_GetEventSaveData().FDBOPFEOENF_Divas[AHHJLDLAPAN - 1].DMDLAIOJKPM_SoExp;
        }
        return 0;
    }

	// // RVA: 0xF2DCC0 Offset: 0xF2DCC0 VA: 0xF2DCC0
	public int DFKNGEIBBAJ_GetDivaVoiceExp(int AHHJLDLAPAN)
    {
        MANPIONIGNO_EventGoDiva ev = OEGDCBLNNFF_GetEvent();
        if(ev != null)
        {
            return ev.CLELOGKMNCE_GetEventSaveData().FDBOPFEOENF_Divas[AHHJLDLAPAN - 1].GNBEKAELDMM_VoExp;
        }
        return 0;
    }

	// // RVA: 0xF2DD8C Offset: 0xF2DD8C VA: 0xF2DD8C
	public int HDGGPOIHMPF_GetDivaCharmExp(int AHHJLDLAPAN)
    {
        MANPIONIGNO_EventGoDiva ev = OEGDCBLNNFF_GetEvent();
        if(ev != null)
        {
            return ev.CLELOGKMNCE_GetEventSaveData().FDBOPFEOENF_Divas[AHHJLDLAPAN - 1].BCANABIAIIP_ChExp;
        }
        return 0;
    }

	// // RVA: 0xF2DE58 Offset: 0xF2DE58 VA: 0xF2DE58
	public int DFONMIHHAGB_GetDivaSoulMExp(int AHHJLDLAPAN)
    {
        MANPIONIGNO_EventGoDiva ev = OEGDCBLNNFF_GetEvent();
        if(ev != null)
        {
            return ev.CLELOGKMNCE_GetEventSaveData().FDBOPFEOENF_Divas[AHHJLDLAPAN - 1].JDHJEINPJLL_SoMExp;
        }
        return 0;
    }

	// // RVA: 0xF2DF24 Offset: 0xF2DF24 VA: 0xF2DF24
	public int LPGFBLBEJNF_GetDivaVoiceMExp(int AHHJLDLAPAN)
    {
        MANPIONIGNO_EventGoDiva ev = OEGDCBLNNFF_GetEvent();
        if(ev != null)
        {
            return ev.CLELOGKMNCE_GetEventSaveData().FDBOPFEOENF_Divas[AHHJLDLAPAN - 1].OIMLBHPAMGD_VoMExp;
        }
        return 0;
    }

	// // RVA: 0xF2DFF0 Offset: 0xF2DFF0 VA: 0xF2DFF0
	public int GIAJCLKEONO_GetDivaCharmMExp(int AHHJLDLAPAN)
    {
        MANPIONIGNO_EventGoDiva ev = OEGDCBLNNFF_GetEvent();
        if(ev != null)
        {
            return ev.CLELOGKMNCE_GetEventSaveData().FDBOPFEOENF_Divas[AHHJLDLAPAN - 1].PFDDNKEOKBF_ChMExp;
        }
        return 0;
    }

	// // RVA: 0xF2D4D4 Offset: 0xF2D4D4 VA: 0xF2D4D4
	private MANPIONIGNO_EventGoDiva OEGDCBLNNFF_GetEvent()
    {
        return JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as MANPIONIGNO_EventGoDiva;
    }

	// // RVA: 0xF2C738 Offset: 0xF2C738 VA: 0xF2C738
	private void FJJBHOICNPO_SetSelDiva(int AHHJLDLAPAN)
    {
        MANPIONIGNO_EventGoDiva ev = OEGDCBLNNFF_GetEvent();
        if(ev != null)
        {
            CMCMKIBNIMO_SelDiva = AHHJLDLAPAN;
            ev.CLELOGKMNCE_GetEventSaveData().AFKMGCLEPGA_SelDiva = AHHJLDLAPAN;
        }
    }

	// // RVA: 0xF2C788 Offset: 0xF2C788 VA: 0xF2C788
	private void KCDGGHBODKE_SetFId(int GHBPLHBNMBK)
    {
        MANPIONIGNO_EventGoDiva ev = OEGDCBLNNFF_GetEvent();
        if(ev != null)
        {
            NMHLBCJHFCI_FId = GHBPLHBNMBK;
            ev.CLELOGKMNCE_GetEventSaveData().LEPHEGEHHOD_SelFId = GHBPLHBNMBK;
        }
    }

	// // RVA: 0xF2D5F8 Offset: 0xF2D5F8 VA: 0xF2D5F8
	private void EKKFCEJECFK(int EKANGPODCEP)
    {
        if(CCFENBAOPAG_LocalSaveData.FKEJBAHCMGC_SetEventId(EKANGPODCEP))
        {
            GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
        }
    }

	// // RVA: 0xF2C980 Offset: 0xF2C980 VA: 0xF2C980
	private void LMENKAFNADG_SetHideBonusClosePopupFlag(bool LPJJLOIFCID)
    {
        CCFENBAOPAG_LocalSaveData.LMENKAFNADG_SetHideBonusClosePopupFlag(LPJJLOIFCID);
        GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
    }

	// // RVA: 0xF2CA9C Offset: 0xF2CA9C VA: 0xF2CA9C
	private void PNFDENHKMGK_SetDifficulty(Difficulty.Type AKNELONELJK)
    {
        CCFENBAOPAG_LocalSaveData.HJHBGHMNGKL_SetDifficulty(AKNELONELJK);
        GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
    }

	// // RVA: 0xF2E0BC Offset: 0xF2E0BC VA: 0xF2E0BC
	public void ADPFOJMHFMH_SetFreeMusicId(FreeCategoryId.Type DEPGBBJMFED, int GHBPLHBNMBK)
    {
        CCFENBAOPAG_LocalSaveData.ACGKEJKPFIA_SetFreeMusicId(DEPGBBJMFED, GHBPLHBNMBK);
        GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
    }

	// // RVA: 0xF2E1AC Offset: 0xF2E1AC VA: 0xF2E1AC
	public int DGCPCBFDAPC_GetFreeMusicId(FreeCategoryId.Type DEPGBBJMFED)
    {
        int v = 0;
        CCFENBAOPAG_LocalSaveData.FKJBADIPKHK_GetFreeMusicId(DEPGBBJMFED, out v);
        return v;
    }
}
