
using XeApp;

public class HLMJIADBPIJ
{
	public static int MKLHIENKAFA = 864000; // 0x0

	// RVA: 0x15F2314 Offset: 0x15F2314 VA: 0x15F2314
	public static bool IBHJAMDGGMC(NJLGICBHIOC.EOFJDIACFEC INDDJNMPONH, long DPIBHFNDJII, long EKPBOLNFGJB, BBHNACPENDM_ServerSaveData AHEFHIMGIBI, OKGLGHCBCJP_Database NKEBMCIMJND, long JHNMKKNEENE)
    {
        switch(INDDJNMPONH)
		{
			case NJLGICBHIOC.EOFJDIACFEC.HIJCECJACBK/*1*/:
				{
					LAEGMENIEDB_Story.ALGOILKGAAH st = NKEBMCIMJND.OHCIFMDPAPD_Story.CDENCMNHNGA.Find((LAEGMENIEDB_Story.ALGOILKGAAH GHPLINIACBB) =>
					{
						//0x15F3338
						return GHPLINIACBB.KLCIIHKFPPO_StoryMusicId == DPIBHFNDJII;
					});
					if (st == null)
						return false;
					if (AHEFHIMGIBI.LNOOKHJBENO_StoryRecord == null)
						return false;
					NEKDCJKANAH_StoryRecord.HKDNILFKCFC saveSt = AHEFHIMGIBI.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[st.LFLLLOPAKCO_Id - 1];
					return saveSt.HALOKFOJMLA_IsCompleted;
				}
			case NJLGICBHIOC.EOFJDIACFEC.NDGMFGMHCJM/*2*/:
				{
					if (AHEFHIMGIBI.KCCLEHLLOFG_Common == null)
						return false;
					return AHEFHIMGIBI.KCCLEHLLOFG_Common.KIECDDFNCAN_Level >= DPIBHFNDJII;
				}
			case NJLGICBHIOC.EOFJDIACFEC.NEKIMLIDECE/*3*/:
				{
					if (AHEFHIMGIBI.OEKEIGFAIGN_Counter == null)
						return false;
					return AHEFHIMGIBI.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.MILCBLJDADN_MusicClear >= DPIBHFNDJII;
				}
			case NJLGICBHIOC.EOFJDIACFEC.NMPIGOJAENA/*4*/:
				{
					if (AHEFHIMGIBI.OEKEIGFAIGN_Counter == null)
						return false;
					return AHEFHIMGIBI.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.LHOCOEOKFNO_SerieClear[DPIBHFNDJII - 1] >= EKPBOLNFGJB;
				}
			case NJLGICBHIOC.EOFJDIACFEC.MCNJJOFADCD/*5*/:
				{
					if (AHEFHIMGIBI.OEKEIGFAIGN_Counter == null)
						return false;
					return AHEFHIMGIBI.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.PHPPOGOEOAF_DiffClear[4] >= DPIBHFNDJII;
				}
			case NJLGICBHIOC.EOFJDIACFEC.OKFIBPHHCNO/*7*/:
				{
					if (AHEFHIMGIBI.OEKEIGFAIGN_Counter == null)
						return false;
					return AHEFHIMGIBI.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.FILFPNDEINH_Fcb >= DPIBHFNDJII;
				}
			case NJLGICBHIOC.EOFJDIACFEC.BADNCCCDDPO/*8*/:
				{
					if (AHEFHIMGIBI.DGCJCAHIAPP_Diva == null)
						return false;
					return AHEFHIMGIBI.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo((int)DPIBHFNDJII).OKMELNIIMMO_GetDivaLevel() >= EKPBOLNFGJB;
				}
			case NJLGICBHIOC.EOFJDIACFEC.MLPPDEEBBDM/*9*/:
				{
					if (AHEFHIMGIBI.NGHJPEIKLJL_Episode == null)
						return false;
					if(DPIBHFNDJII - 1 < NKEBMCIMJND.MOLEPBNJAGE_Episode.BBAJKJPKOHD_EpisodeList.Count)
					{
						if (NKEBMCIMJND.MOLEPBNJAGE_Episode.BBAJKJPKOHD_EpisodeList[(int)DPIBHFNDJII - 1].PPEGAKEIEGM != 2)
							return false;
						return AHEFHIMGIBI.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList[(int)DPIBHFNDJII - 1].EBIIIAELNAA_Step + 1 <= NKEBMCIMJND.MOLEPBNJAGE_Episode.BBAJKJPKOHD_EpisodeList[(int)DPIBHFNDJII - 1].FGOGPCMHPIN_Count;
					}
					return false;
				}
			case NJLGICBHIOC.EOFJDIACFEC.FPFBDEOCDIO/*10*/:
				{
					if (AppEnv.IsCBT())
						return false;
					if (DPIBHFNDJII == 0)
						return false;
					if (AHEFHIMGIBI.JHFIPCIHJNL_Base.IJHBIMNKOMC_TutorialEnd != 2)
						return false;
					if (JHNMKKNEENE < (DPIBHFNDJII - MKLHIENKAFA))
						return false;
					return EKPBOLNFGJB >= JHNMKKNEENE;
				}
			case NJLGICBHIOC.EOFJDIACFEC.ILCMGKPAEOI/*11*/:
				{
					if (AHEFHIMGIBI.OEKEIGFAIGN_Counter == null)
						return false;
					return AHEFHIMGIBI.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.HOHBKPPOLLA_Uc >= DPIBHFNDJII;
				}
			case NJLGICBHIOC.EOFJDIACFEC.DKJIAKIPEJB/*12*/:
				{
					return JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.GPKMEOKPDIP((int)DPIBHFNDJII);
				}
			case NJLGICBHIOC.EOFJDIACFEC.BILICHMCHIP/*15*/:
				return AHEFHIMGIBI.FLHMJHBOBEA_Sns.HAJEJPFGILG[(int)DPIBHFNDJII - 1].PMKJFKJFDOC_Itm != 0;
			case NJLGICBHIOC.EOFJDIACFEC.PMMOLBAAHEM/*16*/:
				if (DPIBHFNDJII < 0)
					return false;
				return EKPBOLNFGJB <= AHEFHIMGIBI.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.GKOAPFJFKEJ_VOpC[DPIBHFNDJII]; // ?
			case NJLGICBHIOC.EOFJDIACFEC.OHAGNHFOEKO/*17*/:
				if (DPIBHFNDJII < 1)
					return false;
				return EKPBOLNFGJB <= AHEFHIMGIBI.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.LOOAKNLDONN_DOpC[DPIBHFNDJII - 1]; // ?
			case NJLGICBHIOC.EOFJDIACFEC.LJHIFLMDGKE/*18*/:
				{
					JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo mi = AHEFHIMGIBI.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo[(int)DPIBHFNDJII - 1];
					int r = 0;
					for(int i = 0; i < mi.JNLKJCDFFMM_Clear.Count; i++)
					{
						r += mi.JNLKJCDFFMM_Clear[i];
					}
					return r >= EKPBOLNFGJB;
				}
			case NJLGICBHIOC.EOFJDIACFEC.OMPHECLBFEH/*19*/:
				{
					JPCKBFBCJKD m = NKEBMCIMJND.IBPAFKKEKNK_Music.LLJOPJMIGPD((int)DPIBHFNDJII);
					if (m == null)
						return false;
					if (!AHEFHIMGIBI.LNOOKHJBENO_StoryRecord.EOHHFADHHBL_Complete)
						return false;
					if (!NKEBMCIMJND.IBPAFKKEKNK_Music.IAAMKEJKPPL(m, AHEFHIMGIBI.KCCLEHLLOFG_Common.KIECDDFNCAN_Level))
						return false;
					return AHEFHIMGIBI.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo[(int)DPIBHFNDJII - 1].DMANHOPOBMP_IsShowUnlock;
				}
			case NJLGICBHIOC.EOFJDIACFEC.OLAENAJCBIP/*20*/:
				return JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.GJFBNJLOOPD((int)DPIBHFNDJII);
		}
		return false;
    }
}
