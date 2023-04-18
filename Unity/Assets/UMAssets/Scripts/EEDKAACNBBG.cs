using XeApp.Game.Common;

[System.Obsolete("Use EEDKAACNBBG_MusicData", true)]
public class EEDKAACNBBG { }
public class EEDKAACNBBG_MusicData
{
	private const int FBGGEFFJJHB = 0x7daf3c5a;
	public int KOPBFHIBOJJ_MusicIdCrypted = FBGGEFFJJHB; // 0x8
	public int GBGHABAJPGJ_JacketIdCrypted = FBGGEFFJJHB; // 0xC
	public int PAAEGMPLLOD_CdCrypted = FBGGEFFJJHB; // 0x10
	public int NJHHGPGBEOF_SerieCrypted = FBGGEFFJJHB; // 0x14
	public int AHECDFEOOBF_SerieLogoIdCrypted = FBGGEFFJJHB; // 0x18
	public int BNJIMPADBAH_JacketAttrCrypted = FBGGEFFJJHB; // 0x1C
	public string NEDBBJDAFBH_MusicName; // 0x20
	public string NBKFBCLDGAL_OfficialName; // 0x24
	public string LJCEDBBNPBB_VocalName; // 0x28
	public string KLMPFGOCBHC_Description; // 0x2C
	public string OLLHCHDEHHM_StoryDesc; // 0x30
	public int EDDPAECJHHC_WavIdCrypted = FBGGEFFJJHB; // 0x34
	public int CALAEHJCPIC = FBGGEFFJJHB; // 0x38
	public byte BNCMJNMIDIN_AvaiableDivaModes; // 0x3C

	public int DLAEJOBELBH_MusicId { get { return KOPBFHIBOJJ_MusicIdCrypted ^ FBGGEFFJJHB; } set { KOPBFHIBOJJ_MusicIdCrypted = value ^ FBGGEFFJJHB; } }// 0x1C487F4 MPGNHBOBFBD 0x1C48808 EPEMOAEGPLI
	public int JNCPEGJGHOG_JacketId { get { return GBGHABAJPGJ_JacketIdCrypted ^ FBGGEFFJJHB; } set { GBGHABAJPGJ_JacketIdCrypted = value ^ FBGGEFFJJHB; } } //0x1C4881C HHEADMHBBPB 0x1C48830 GOFFKDDNACG
	public int NNHOBFBCIIJ_Cd { get { return PAAEGMPLLOD_CdCrypted ^ FBGGEFFJJHB; } set { PAAEGMPLLOD_CdCrypted = value ^ FBGGEFFJJHB; } } //0x1C48844 AOBMNDMGGIO 0x1C48858 NIMNBBDNJMC
	public int AIHCEGFANAM_Serie { get { return NJHHGPGBEOF_SerieCrypted ^ FBGGEFFJJHB; } set { NJHHGPGBEOF_SerieCrypted = value ^ FBGGEFFJJHB; } } //0x1C4886C ANEJPLENMAL 0x1C48880 HEHDOGFEIOL
	public int EMIKBGHIOMN_SerieLogoId { get { return AHECDFEOOBF_SerieLogoIdCrypted ^ FBGGEFFJJHB; } set { AHECDFEOOBF_SerieLogoIdCrypted = value ^ FBGGEFFJJHB; } } //0x1C48894 BJGJCKFOBCA 0x1C488A8 OAKIKBEEACC
	public int FKDCCLPGKDK_JacketAttr { get { return BNJIMPADBAH_JacketAttrCrypted ^ FBGGEFFJJHB; } set { BNJIMPADBAH_JacketAttrCrypted = value ^ FBGGEFFJJHB; } } //0x1C488BC FBADKBMGIBP 0x1C488D0 NCNMMABFHGN
	public int KKPAHLMJKIH_WavId { get { return EDDPAECJHHC_WavIdCrypted ^ FBGGEFFJJHB; } set { EDDPAECJHHC_WavIdCrypted = value ^ FBGGEFFJJHB; } } //0x1C488E4 ENODDPDBIPA 0x1C488F8 HOAKFLEAEOH
	public int BKJGCEOEPFB { get { return CALAEHJCPIC ^ FBGGEFFJJHB; } set { CALAEHJCPIC = value ^ FBGGEFFJJHB; } } //0x1C4890C FNEBPBJBIIP 0x1C48920 OIDGLNHNGJB
	public bool IFNPBIJEPBO_IsDlded { get; private set; } // 0x3D ODDANOKGMLN GNLBOEKONDC OCOEKEKKGGG

	// // RVA: 0x1C48944 Offset: 0x1C48944 VA: 0x1C48944 Slot: 4
	public virtual void KHEKNNFCAOI(int DLAEJOBELBH)
	{
		this.DLAEJOBELBH_MusicId = DLAEJOBELBH;
		EONOEHOKBEB_Music musicInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.EPMMNEFADAP_Musics[DLAEJOBELBH - 1];
		JNCPEGJGHOG_JacketId = musicInfo.JNCPEGJGHOG_Cov;
		NNHOBFBCIIJ_Cd = musicInfo.NNHOBFBCIIJ_Cd;
		EMIKBGHIOMN_SerieLogoId = musicInfo.EMIKBGHIOMN_SerieLogoId;
		AIHCEGFANAM_Serie = (int)SeriesAttr.ConvertFromLogoId((SeriesLogoId.Type)musicInfo.EMIKBGHIOMN_SerieLogoId);
		FKDCCLPGKDK_JacketAttr = musicInfo.FKDCCLPGKDK_Ma;
		NEDBBJDAFBH_MusicName = Database.Instance.musicText.Get(musicInfo.KNMGEEFGDNI_Nam).musicName;
		NBKFBCLDGAL_OfficialName = Database.Instance.musicText.Get(musicInfo.KNMGEEFGDNI_Nam).officialName;
		LJCEDBBNPBB_VocalName = Database.Instance.musicText.Get(musicInfo.KNMGEEFGDNI_Nam).vocalName;
		KLMPFGOCBHC_Description = Database.Instance.musicText.Get(musicInfo.KNMGEEFGDNI_Nam).description;
		OLLHCHDEHHM_StoryDesc = Database.Instance.musicText.Get(musicInfo.KNMGEEFGDNI_Nam).storyDesc;
		KKPAHLMJKIH_WavId = musicInfo.KKPAHLMJKIH_WavId;
		BNCMJNMIDIN_AvaiableDivaModes = 0;
		if (musicInfo.NJAOOMHCIHL_DivaSolo > 0)
			BNCMJNMIDIN_AvaiableDivaModes |= 1;
		if (musicInfo.PECMGDOMLAF_DivaMulti > 1)
			BNCMJNMIDIN_AvaiableDivaModes |= (byte)(1 << (musicInfo.PECMGDOMLAF_DivaMulti - 1));
		OBGKIMDIAJF_CheckIsDlded();
	}

	// // RVA: 0x1C48F30 Offset: 0x1C48F30 VA: 0x1C48F30 Slot: 5
	public virtual bool DBIGDCOHOIC_IsMultiDanceUnlocked()
	{
		return JFEEHOKLFPO_GetMultiDanceMinLevel() <= CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KIECDDFNCAN_Level;
	}

	// // RVA: 0x1C49024 Offset: 0x1C49024 VA: 0x1C49024
	public int JFEEHOKLFPO_GetMultiDanceMinLevel()
	{
		return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("multi_dance_player_level", 3);
	}

	// // RVA: 0x1C49124 Offset: 0x1C49124 VA: 0x1C49124
	public bool BENDFLDLIAG_IsAvaiableForNumDiva(int OFGIOBGAJPA_NumDiva)
	{
		return (BNCMJNMIDIN_AvaiableDivaModes & (1 << (OFGIOBGAJPA_NumDiva - 1))) != 0;
	}

	// // RVA: 0x1C49144 Offset: 0x1C49144 VA: 0x1C49144
	public bool KLOGLLFOAPL_HasMultiDivaMode()
	{
		return BNCMJNMIDIN_AvaiableDivaModes > 1;
	}

	// // RVA: 0x1C49158 Offset: 0x1C49158 VA: 0x1C49158
	public bool HAMPEDFMIAD_HasOnlyMultiDivaMode()
	{
		return BNCMJNMIDIN_AvaiableDivaModes > 1 && (BNCMJNMIDIN_AvaiableDivaModes & 1) == 0;
	}

	// // RVA: 0x1C4917C Offset: 0x1C4917C VA: 0x1C4917C
	// public int IOMLIADJJLD(bool FJNPMGBCBGJ = False) { }

	// // RVA: 0x1C491B4 Offset: 0x1C491B4 VA: 0x1C491B4
	public bool JAPLKHPLOOF(OHCAABOMEOF.KGOGMKMBCPP_EventType JONPKLHMOBL)
	{
		int multi_dance_player_level = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("multi_dance_player_level", 3);
		if (JONPKLHMOBL != 0 || CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KIECDDFNCAN_Level >= multi_dance_player_level)
		{
			if(JONPKLHMOBL == OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL && BNCMJNMIDIN_AvaiableDivaModes > 1 && (BNCMJNMIDIN_AvaiableDivaModes & 1) == 0)
			{
				int numDiva = 1;
				for(int i = 1; i <= 31; i++)
				{
					if ((BNCMJNMIDIN_AvaiableDivaModes & (1 << i)) != 0)
					{
						numDiva = i + 1;
						break;
					}
				}
				int cnt = 0;
				for(int i = 0; i < CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList.Count; i++)
				{
					if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[i].CPGFPEDMDEH > 0)
						cnt++;
				}
				if (cnt < numDiva)
					return false;
			}
			if (BNCMJNMIDIN_AvaiableDivaModes > 1)
				return true;
		}
		return false;
	}

	// // RVA: 0x1C48E2C Offset: 0x1C48E2C VA: 0x1C48E2C
	public void OBGKIMDIAJF_CheckIsDlded()
	{
		string sheetName = "";
		BgmPlayer.ConvertBgmIdToCueSheetName(KKPAHLMJKIH_WavId, ref sheetName);
		IFNPBIJEPBO_IsDlded = SoundResource.IsInstalledCueSheet(sheetName);
	}

	// // RVA: 0x1C494DC Offset: 0x1C494DC VA: 0x1C494DC
	// public static byte FFJPJEMCGKK(EONOEHOKBEB KLCDFACOILE) { }
}
