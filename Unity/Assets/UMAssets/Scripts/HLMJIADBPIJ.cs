
using XeApp;

public class HLMJIADBPIJ
{
	public static int MKLHIENKAFA = 864000; // 0x0

	// RVA: 0x15F2314 Offset: 0x15F2314 VA: 0x15F2314
	public static bool IBHJAMDGGMC(NJLGICBHIOC.EOFJDIACFEC INDDJNMPONH, long _DPIBHFNDJII_UnlockCond1, long _EKPBOLNFGJB_UnlockCond2, BBHNACPENDM_ServerSaveData _AHEFHIMGIBI_PlayerData, OKGLGHCBCJP_Database NKEBMCIMJND, long JHNMKKNEENE)
    {
        switch(INDDJNMPONH)
		{
			case NJLGICBHIOC.EOFJDIACFEC.HIJCECJACBK/*1*/:
				{
					LAEGMENIEDB_Story.ALGOILKGAAH st = NKEBMCIMJND.OHCIFMDPAPD_Story.CDENCMNHNGA_table.Find((LAEGMENIEDB_Story.ALGOILKGAAH _GHPLINIACBB_x) =>
					{
						//0x15F3338
						return _GHPLINIACBB_x.KLCIIHKFPPO_StoryMusicId == _DPIBHFNDJII_UnlockCond1;
					});
					if (st == null)
						return false;
					if (_AHEFHIMGIBI_PlayerData.LNOOKHJBENO_StoryRecord == null)
						return false;
					NEKDCJKANAH_StoryRecord.HKDNILFKCFC saveSt = _AHEFHIMGIBI_PlayerData.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[st.LFLLLOPAKCO_Id - 1];
					return saveSt.HALOKFOJMLA_IsCompleted;
				}
			case NJLGICBHIOC.EOFJDIACFEC.NDGMFGMHCJM/*2*/:
				{
					if (_AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common == null)
						return false;
					return _AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.KIECDDFNCAN_Level >= _DPIBHFNDJII_UnlockCond1;
				}
			case NJLGICBHIOC.EOFJDIACFEC.NEKIMLIDECE/*3*/:
				{
					if (_AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter == null)
						return false;
					return _AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.MILCBLJDADN_MusicClear >= _DPIBHFNDJII_UnlockCond1;
				}
			case NJLGICBHIOC.EOFJDIACFEC.NMPIGOJAENA/*4*/:
				{
					if (_AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter == null)
						return false;
					return _AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.LHOCOEOKFNO_SerieClear[_DPIBHFNDJII_UnlockCond1 - 1] >= _EKPBOLNFGJB_UnlockCond2;
				}
			case NJLGICBHIOC.EOFJDIACFEC.MCNJJOFADCD/*5*/:
				{
					if (_AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter == null)
						return false;
					return _AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.PHPPOGOEOAF_DiffClear[4] >= _DPIBHFNDJII_UnlockCond1;
				}
			case NJLGICBHIOC.EOFJDIACFEC.OKFIBPHHCNO/*7*/:
				{
					if (_AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter == null)
						return false;
					return _AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.FILFPNDEINH_Combo >= _DPIBHFNDJII_UnlockCond1;
				}
			case NJLGICBHIOC.EOFJDIACFEC.BADNCCCDDPO/*8*/:
				{
					if (_AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva == null)
						return false;
					return _AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo((int)_DPIBHFNDJII_UnlockCond1).OKMELNIIMMO_GetDivaLevel() >= _EKPBOLNFGJB_UnlockCond2;
				}
			case NJLGICBHIOC.EOFJDIACFEC.MLPPDEEBBDM/*9*/:
				{
					if (_AHEFHIMGIBI_PlayerData.NGHJPEIKLJL_Episode == null)
						return false;
					if(_DPIBHFNDJII_UnlockCond1 - 1 < NKEBMCIMJND.MOLEPBNJAGE_Episode.BBAJKJPKOHD_EpisodeList.Count)
					{
						if (NKEBMCIMJND.MOLEPBNJAGE_Episode.BBAJKJPKOHD_EpisodeList[(int)_DPIBHFNDJII_UnlockCond1 - 1].PPEGAKEIEGM != 2)
							return false;
						return _AHEFHIMGIBI_PlayerData.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList[(int)_DPIBHFNDJII_UnlockCond1 - 1].EBIIIAELNAA_Step + 1 <= NKEBMCIMJND.MOLEPBNJAGE_Episode.BBAJKJPKOHD_EpisodeList[(int)_DPIBHFNDJII_UnlockCond1 - 1].FGOGPCMHPIN_Count;
					}
					return false;
				}
			case NJLGICBHIOC.EOFJDIACFEC.FPFBDEOCDIO/*10*/:
				{
					if (AppEnv.IsCBT())
						return false;
					if (_DPIBHFNDJII_UnlockCond1 == 0)
						return false;
					if (_AHEFHIMGIBI_PlayerData.JHFIPCIHJNL_Base.IJHBIMNKOMC_TutorialEnd != 2)
						return false;
					if (JHNMKKNEENE < (_DPIBHFNDJII_UnlockCond1 - MKLHIENKAFA))
						return false;
					return _EKPBOLNFGJB_UnlockCond2 >= JHNMKKNEENE;
				}
			case NJLGICBHIOC.EOFJDIACFEC.ILCMGKPAEOI/*11*/:
				{
					if (_AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter == null)
						return false;
					return _AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.HOHBKPPOLLA_Uc >= _DPIBHFNDJII_UnlockCond1;
				}
			case NJLGICBHIOC.EOFJDIACFEC.DKJIAKIPEJB/*12*/:
				{
					return JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.GPKMEOKPDIP((int)_DPIBHFNDJII_UnlockCond1);
				}
			case NJLGICBHIOC.EOFJDIACFEC.BILICHMCHIP/*15*/:
				return _AHEFHIMGIBI_PlayerData.FLHMJHBOBEA_Sns.HAJEJPFGILG[(int)_DPIBHFNDJII_UnlockCond1 - 1].PMKJFKJFDOC_Itm != 0;
			case NJLGICBHIOC.EOFJDIACFEC.PMMOLBAAHEM/*16*/:
				if (_DPIBHFNDJII_UnlockCond1 < 0)
					return false;
				return _EKPBOLNFGJB_UnlockCond2 <= _AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.GKOAPFJFKEJ_VOpC[_DPIBHFNDJII_UnlockCond1]; // ?
			case NJLGICBHIOC.EOFJDIACFEC.OHAGNHFOEKO/*17*/:
				if (_DPIBHFNDJII_UnlockCond1 < 1)
					return false;
				return _EKPBOLNFGJB_UnlockCond2 <= _AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.LOOAKNLDONN_DOpC[_DPIBHFNDJII_UnlockCond1 - 1]; // ?
			case NJLGICBHIOC.EOFJDIACFEC.LJHIFLMDGKE/*18*/:
				{
					JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo mi = _AHEFHIMGIBI_PlayerData.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo[(int)_DPIBHFNDJII_UnlockCond1 - 1];
					int r = 0;
					for(int i = 0; i < mi.JNLKJCDFFMM_Clear.Count; i++)
					{
						r += mi.JNLKJCDFFMM_Clear[i];
					}
					return r >= _EKPBOLNFGJB_UnlockCond2;
				}
			case NJLGICBHIOC.EOFJDIACFEC.OMPHECLBFEH/*19*/:
				{
					JPCKBFBCJKD m = NKEBMCIMJND.IBPAFKKEKNK_Music.LLJOPJMIGPD((int)_DPIBHFNDJII_UnlockCond1);
					if (m == null)
						return false;
					if (!_AHEFHIMGIBI_PlayerData.LNOOKHJBENO_StoryRecord.EOHHFADHHBL_Complete)
						return false;
					if (!NKEBMCIMJND.IBPAFKKEKNK_Music.IAAMKEJKPPL(m, _AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.KIECDDFNCAN_Level))
						return false;
					return _AHEFHIMGIBI_PlayerData.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo[(int)_DPIBHFNDJII_UnlockCond1 - 1].DMANHOPOBMP_IsShowUnlock;
				}
			case NJLGICBHIOC.EOFJDIACFEC.OLAENAJCBIP/*20*/:
				return JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.GJFBNJLOOPD((int)_DPIBHFNDJII_UnlockCond1);
		}
		return false;
    }
}
