using XeApp.Game.Common;

public class EEDKAACNBBG
{
	private const int FBGGEFFJJHB = 0x7daf3c5a;
	public int KOPBFHIBOJJ_MusicIdCrypted = FBGGEFFJJHB; // 0x8
	public int GBGHABAJPGJ_JacketIdCrypted = FBGGEFFJJHB; // 0xC
	public int PAAEGMPLLOD = FBGGEFFJJHB; // 0x10
	public int NJHHGPGBEOF_SerieCrypted = FBGGEFFJJHB; // 0x14
	public int AHECDFEOOBF = FBGGEFFJJHB; // 0x18
	public int BNJIMPADBAH_JacketAttrCrypted = FBGGEFFJJHB; // 0x1C
	public string NEDBBJDAFBH; // 0x20
	public string NBKFBCLDGAL; // 0x24
	public string LJCEDBBNPBB; // 0x28
	public string KLMPFGOCBHC; // 0x2C
	public string OLLHCHDEHHM; // 0x30
	public int EDDPAECJHHC = FBGGEFFJJHB; // 0x34
	public int CALAEHJCPIC = FBGGEFFJJHB; // 0x38
	public byte BNCMJNMIDIN_AvaiableDivaModes; // 0x3C

	public int DLAEJOBELBH_MusicId { get { return KOPBFHIBOJJ_MusicIdCrypted ^ FBGGEFFJJHB; } set { KOPBFHIBOJJ_MusicIdCrypted = value ^ FBGGEFFJJHB; } }// 0x1C487F4 MPGNHBOBFBD 0x1C48808 EPEMOAEGPLI
	public int JNCPEGJGHOG_JacketId { get { return GBGHABAJPGJ_JacketIdCrypted ^ FBGGEFFJJHB; } set { GBGHABAJPGJ_JacketIdCrypted = value ^ FBGGEFFJJHB; } } //0x1C4881C HHEADMHBBPB 0x1C48830 GOFFKDDNACG
	// public int NNHOBFBCIIJ { get; set; } 0x1C48844 AOBMNDMGGIO 0x1C48858 NIMNBBDNJMC
	public int AIHCEGFANAM_Serie { get { return NJHHGPGBEOF_SerieCrypted ^ FBGGEFFJJHB; } set { NJHHGPGBEOF_SerieCrypted = value ^ FBGGEFFJJHB; } } //0x1C4886C ANEJPLENMAL 0x1C48880 HEHDOGFEIOL
	// public int EMIKBGHIOMN { get; set; } 0x1C48894 BJGJCKFOBCA 0x1C488A8 OAKIKBEEACC
	public int FKDCCLPGKDK_JacketAttr { get { return BNJIMPADBAH_JacketAttrCrypted ^ FBGGEFFJJHB; } set { BNJIMPADBAH_JacketAttrCrypted = value ^ FBGGEFFJJHB; } } //0x1C488BC FBADKBMGIBP 0x1C488D0 NCNMMABFHGN
	// public int KKPAHLMJKIH { get; set; } 0x1C488E4 ENODDPDBIPA 0x1C488F8 HOAKFLEAEOH
	// public int BKJGCEOEPFB { get; set; } 0x1C4890C FNEBPBJBIIP 0x1C48920 OIDGLNHNGJB
	public bool IFNPBIJEPBO_IsDlded { get; private set; } // 0x3D ODDANOKGMLN GNLBOEKONDC OCOEKEKKGGG

	// // RVA: 0x1C48944 Offset: 0x1C48944 VA: 0x1C48944 Slot: 4
	public virtual void KHEKNNFCAOI(int DLAEJOBELBH)
	{
		UnityEngine.Debug.LogError("TODO KHEKNNFCAOI");
		this.DLAEJOBELBH_MusicId = DLAEJOBELBH;
		EONOEHOKBEB_Music musicInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.EPMMNEFADAP_Musics[DLAEJOBELBH - 1];
		BNCMJNMIDIN_AvaiableDivaModes = 0;
		AIHCEGFANAM_Serie = (int)SeriesAttr.ConvertFromLogoId((SeriesLogoId.Type)musicInfo.EMIKBGHIOMN_SerieLogoId);
		if (musicInfo.NJAOOMHCIHL_Dvs > 0)
			BNCMJNMIDIN_AvaiableDivaModes |= 1;
		if (musicInfo.PECMGDOMLAF_Dvm > 1)
			BNCMJNMIDIN_AvaiableDivaModes |= (byte)(1 << (musicInfo.PECMGDOMLAF_Dvm - 1));
	}

	// // RVA: 0x1C48F30 Offset: 0x1C48F30 VA: 0x1C48F30 Slot: 5
	public virtual bool DBIGDCOHOIC()
	{
		//return JFEEHOKLFPO() <= CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_Save.KCCLEHLLOFG.FBGGEFFJJHB;
		UnityEngine.Debug.LogError("TODO DBIGDCOHOIC");
		return true;
	}

	// // RVA: 0x1C49024 Offset: 0x1C49024 VA: 0x1C49024
	//public int JFEEHOKLFPO() { }

	// // RVA: 0x1C49124 Offset: 0x1C49124 VA: 0x1C49124
	public bool BENDFLDLIAG_IsAvaiableForNumDiva(int OFGIOBGAJPA_NumDiva)
	{
		return (BNCMJNMIDIN_AvaiableDivaModes & (1 << (OFGIOBGAJPA_NumDiva - 1))) != 0;
	}

	// // RVA: 0x1C49144 Offset: 0x1C49144 VA: 0x1C49144
	public bool KLOGLLFOAPL()
	{
		UnityEngine.Debug.LogError("TODO KLOGLLFOAPL");
		return false;
	}

	// // RVA: 0x1C49158 Offset: 0x1C49158 VA: 0x1C49158
	// public bool HAMPEDFMIAD() { }

	// // RVA: 0x1C4917C Offset: 0x1C4917C VA: 0x1C4917C
	// public int IOMLIADJJLD(bool FJNPMGBCBGJ = False) { }

	// // RVA: 0x1C491B4 Offset: 0x1C491B4 VA: 0x1C491B4
	// public bool JAPLKHPLOOF(OHCAABOMEOF.KGOGMKMBCPP JONPKLHMOBL) { }

	// // RVA: 0x1C48E2C Offset: 0x1C48E2C VA: 0x1C48E2C
	// public void OBGKIMDIAJF() { }

	// // RVA: 0x1C494DC Offset: 0x1C494DC VA: 0x1C494DC
	// public static byte FFJPJEMCGKK(EONOEHOKBEB KLCDFACOILE) { }
}
