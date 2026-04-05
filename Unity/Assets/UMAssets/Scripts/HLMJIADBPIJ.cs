
using XeApp;

public class HLMJIADBPIJ
{
	public static int MKLHIENKAFA = 864000; // 0x0

	// RVA: 0x15F2314 Offset: 0x15F2314 VA: 0x15F2314
	public static bool IBHJAMDGGMC(NJLGICBHIOC.EOFJDIACFEC_UnlockType _INDDJNMPONH_type, long _DPIBHFNDJII_UnlockCond1, long _EKPBOLNFGJB_UnlockCond2, BBHNACPENDM_ServerSaveData _AHEFHIMGIBI_PlayerData, OKGLGHCBCJP_Database _NKEBMCIMJND_Database, long _JHNMKKNEENE_Time)
    {
        switch(_INDDJNMPONH_type)
		{
			case NJLGICBHIOC.EOFJDIACFEC_UnlockType.HIJCECJACBK_1_StoryCompleted/*1*/:
				{
					LAEGMENIEDB_Story.ALGOILKGAAH st = _NKEBMCIMJND_Database.OHCIFMDPAPD_Story.CDENCMNHNGA_table.Find((LAEGMENIEDB_Story.ALGOILKGAAH _GHPLINIACBB_x) =>
					{
						//0x15F3338
						return _GHPLINIACBB_x.KLCIIHKFPPO_StoryMusicId == _DPIBHFNDJII_UnlockCond1;
					});
					if (st == null)
						return false;
					if (_AHEFHIMGIBI_PlayerData.LNOOKHJBENO_StoryRecord == null)
						return false;
					NEKDCJKANAH_StoryRecord.HKDNILFKCFC saveSt = _AHEFHIMGIBI_PlayerData.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[st.LFLLLOPAKCO_StoryId - 1];
					return saveSt.HALOKFOJMLA_IsCompleted;
				}
			case NJLGICBHIOC.EOFJDIACFEC_UnlockType.NDGMFGMHCJM_2_Level/*2*/:
				{
					if (_AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common == null)
						return false;
					return _AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.KIECDDFNCAN_Level >= _DPIBHFNDJII_UnlockCond1;
				}
			case NJLGICBHIOC.EOFJDIACFEC_UnlockType.NEKIMLIDECE_3_MusicClear/*3*/:
				{
					if (_AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter == null)
						return false;
					return _AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.MILCBLJDADN_MusicClear >= _DPIBHFNDJII_UnlockCond1;
				}
			case NJLGICBHIOC.EOFJDIACFEC_UnlockType.NMPIGOJAENA_4_SerieClear/*4*/:
				{
					if (_AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter == null)
						return false;
					return _AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.LHOCOEOKFNO_SerieClear[_DPIBHFNDJII_UnlockCond1 - 1] >= _EKPBOLNFGJB_UnlockCond2;
				}
			case NJLGICBHIOC.EOFJDIACFEC_UnlockType.MCNJJOFADCD_5_DiffClear/*5*/:
				{
					if (_AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter == null)
						return false;
					return _AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.PHPPOGOEOAF_DiffClear[4] >= _DPIBHFNDJII_UnlockCond1;
				}
			case NJLGICBHIOC.EOFJDIACFEC_UnlockType.OKFIBPHHCNO_7_Combo/*7*/:
				{
					if (_AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter == null)
						return false;
					return _AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.FILFPNDEINH_Combo >= _DPIBHFNDJII_UnlockCond1;
				}
			case NJLGICBHIOC.EOFJDIACFEC_UnlockType.BADNCCCDDPO_8_DivaLevel/*8*/:
				{
					if (_AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva == null)
						return false;
					return _AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo((int)_DPIBHFNDJII_UnlockCond1).OKMELNIIMMO_GetDivaLevel() >= _EKPBOLNFGJB_UnlockCond2;
				}
			case NJLGICBHIOC.EOFJDIACFEC_UnlockType.MLPPDEEBBDM_9_EpisodeUnlocked/*9*/:
				{
					if (_AHEFHIMGIBI_PlayerData.NGHJPEIKLJL_Episode == null)
						return false;
					if(_DPIBHFNDJII_UnlockCond1 - 1 < _NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.BBAJKJPKOHD_EpisodeList.Count)
					{
						if (_NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.BBAJKJPKOHD_EpisodeList[(int)_DPIBHFNDJII_UnlockCond1 - 1].PPEGAKEIEGM_Enabled != 2)
							return false;
						return _AHEFHIMGIBI_PlayerData.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList[(int)_DPIBHFNDJII_UnlockCond1 - 1].EBIIIAELNAA_Step + 1 <= _NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.BBAJKJPKOHD_EpisodeList[(int)_DPIBHFNDJII_UnlockCond1 - 1].FGOGPCMHPIN_Count;
					}
					return false;
				}
			case NJLGICBHIOC.EOFJDIACFEC_UnlockType.FPFBDEOCDIO_10_SomeTime/*10*/:
				{
					if (AppEnv.IsCBT())
						return false;
					if (_DPIBHFNDJII_UnlockCond1 == 0)
						return false;
					if (_AHEFHIMGIBI_PlayerData.JHFIPCIHJNL_Base.IJHBIMNKOMC_tutorial_end != 2)
						return false;
					if (_JHNMKKNEENE_Time < (_DPIBHFNDJII_UnlockCond1 - MKLHIENKAFA))
						return false;
					return _EKPBOLNFGJB_UnlockCond2 >= _JHNMKKNEENE_Time;
				}
			case NJLGICBHIOC.EOFJDIACFEC_UnlockType.ILCMGKPAEOI_11_TotalUc/*11*/:
				{
					if (_AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter == null)
						return false;
					return _AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.HOHBKPPOLLA_Uc >= _DPIBHFNDJII_UnlockCond1;
				}
			case NJLGICBHIOC.EOFJDIACFEC_UnlockType.DKJIAKIPEJB_12_EventEntry/*12*/:
				{
					return JEPBIIJDGEF_NetEventManager.HHCJCDFCLOB_Instance.GPKMEOKPDIP((int)_DPIBHFNDJII_UnlockCond1);
				}
			case NJLGICBHIOC.EOFJDIACFEC_UnlockType.BILICHMCHIP_15_SnsItem/*15*/:
				return _AHEFHIMGIBI_PlayerData.FLHMJHBOBEA_Sns.HAJEJPFGILG[(int)_DPIBHFNDJII_UnlockCond1 - 1].PMKJFKJFDOC_Itm != 0;
			case NJLGICBHIOC.EOFJDIACFEC_UnlockType.PMMOLBAAHEM_16_Vop/*16*/:
				if (_DPIBHFNDJII_UnlockCond1 < 0)
					return false;
				return _EKPBOLNFGJB_UnlockCond2 <= _AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.GKOAPFJFKEJ_VOpC[_DPIBHFNDJII_UnlockCond1]; // ?
			case NJLGICBHIOC.EOFJDIACFEC_UnlockType.OHAGNHFOEKO_17_Dop/*17*/:
				if (_DPIBHFNDJII_UnlockCond1 < 1)
					return false;
				return _EKPBOLNFGJB_UnlockCond2 <= _AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.LOOAKNLDONN_DOpC[_DPIBHFNDJII_UnlockCond1 - 1]; // ?
			case NJLGICBHIOC.EOFJDIACFEC_UnlockType.LJHIFLMDGKE_18_ClearCount/*18*/:
				{
					JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo mi = _AHEFHIMGIBI_PlayerData.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo[(int)_DPIBHFNDJII_UnlockCond1 - 1];
					int r = 0;
					for(int i = 0; i < mi.JNLKJCDFFMM_clear.Count; i++)
					{
						r += mi.JNLKJCDFFMM_clear[i];
					}
					return r >= _EKPBOLNFGJB_UnlockCond2;
				}
			case NJLGICBHIOC.EOFJDIACFEC_UnlockType.OMPHECLBFEH_19_MusicUnlocked/*19*/:
				{
					JPCKBFBCJKD m = _NKEBMCIMJND_Database.IBPAFKKEKNK_Music.LLJOPJMIGPD((int)_DPIBHFNDJII_UnlockCond1);
					if (m == null)
						return false;
					if (!_AHEFHIMGIBI_PlayerData.LNOOKHJBENO_StoryRecord.EOHHFADHHBL_Complete)
						return false;
					if (!_NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAAMKEJKPPL(m, _AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.KIECDDFNCAN_Level))
						return false;
					return _AHEFHIMGIBI_PlayerData.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo[(int)_DPIBHFNDJII_UnlockCond1 - 1].DMANHOPOBMP_IsShowUnlock;
				}
			case NJLGICBHIOC.EOFJDIACFEC_UnlockType.OLAENAJCBIP_20_MinigameClear/*20*/:
				return JEPBIIJDGEF_NetEventManager.HHCJCDFCLOB_Instance.GJFBNJLOOPD((int)_DPIBHFNDJII_UnlockCond1);
		}
		return false;
    }
}
