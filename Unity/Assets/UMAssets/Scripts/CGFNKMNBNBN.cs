using System.Collections.Generic;
using XeApp.Game.Common;
public class CGFNKMNBNBN
{
	public long PPFNGGCBJKC_Id; // 0x8
	public long KJBGCLPMLCG_OpenAt; // 0x10
	public long GJFPFFBAKGK_CloseAt; // 0x18
	public int GBJFNGCDKPM_Type; // 0x20
	public int KEFGPJBKAOD_BgId; // 0x24
	public int KLMAMIOBDHP_MusicId; // 0x28
	public string OPFGFINHFCE_Name; // 0x2C
	public SeriesAttr.Type AIHCEGFANAM_Attr; // 0x30

	// // RVA: 0x12B951C Offset: 0x12B951C VA: 0x12B951C
	// public static List<CGFNKMNBNBN> KIONEGHMJIA() { }

	// // RVA: 0x12B98EC Offset: 0x12B98EC VA: 0x12B98EC
	public static void HHGLKFFKFAB(int HILIKOLBGEJ = -1)
	{
		List<DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo> listDiva = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList;
		for (int i = 0; i < listDiva.Count; i++)
		{
			if(listDiva[i].DIPKCALNIII_DivaId != HILIKOLBGEJ && listDiva[i].CPGFPEDMDEH == 1)
			{
				BJPLLEBHAGO_DivaInfo dbDiva = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.CDENCMNHNGA_Divas[listDiva[i].DIPKCALNIII_DivaId - 1];
				if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.POCPLFJCHDD_HomeBg[dbDiva.CMBCBNEODPD_HomeBgId - 1].BEBJKJKBOGH_Date == 0)
				{
					DPMCLJMIBDK(dbDiva.CMBCBNEODPD_HomeBgId, NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
				}
			}
		}
	}

	// // RVA: 0x12B9FE0 Offset: 0x12B9FE0 VA: 0x12B9FE0
	public static bool CEJADGLBCPA()
	{
		List<DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo> listDiva = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList;
		for (int i = 0; i < listDiva.Count; i++)
		{
			BJPLLEBHAGO_DivaInfo dbDiva = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.CDENCMNHNGA_Divas[listDiva[i].DIPKCALNIII_DivaId - 1];
			if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.POCPLFJCHDD_HomeBg[dbDiva.CMBCBNEODPD_HomeBgId - 1].BEBJKJKBOGH_Date != 0)
				return true;
		}
		return false;
	}

	// // RVA: 0x12BA33C Offset: 0x12BA33C VA: 0x12BA33C
	// public static List<CGFNKMNBNBN> ABOLOPHFADL() { }

	// // RVA: 0x12BA9C4 Offset: 0x12BA9C4 VA: 0x12BA9C4
	public static bool JBNMNPMCIBM_HaveBg(int PPFNGGCBJKC)
	{
		if((PPFNGGCBJKC - 1) < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PFEKKPABPKL_HomeBg.CDENCMNHNGA.Count)
		{
			if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.POCPLFJCHDD_HomeBg[PPFNGGCBJKC - 1].BEBJKJKBOGH_Date != 0)
				return true;
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PFEKKPABPKL_HomeBg.CDENCMNHNGA[PPFNGGCBJKC - 1].LEJOJFHKHIJ_Have == 1;
		}
		return false;
	}

	// // RVA: 0x12B9DD4 Offset: 0x12B9DD4 VA: 0x12B9DD4
	public static void DPMCLJMIBDK(int PPFNGGCBJKC, long BEBJKJKBOGH_Time)
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.CDENCMNHNGA_Divas.Count > PPFNGGCBJKC - 1)
		{
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.POCPLFJCHDD_HomeBg[PPFNGGCBJKC - 1].BEBJKJKBOGH_Date = BEBJKJKBOGH_Time;
		}
	}

	// // RVA: 0x12BACA8 Offset: 0x12BACA8 VA: 0x12BACA8
	// public static void DPMCLJMIBDK(BBHNACPENDM AHEFHIMGIBI, int PPFNGGCBJKC, long BEBJKJKBOGH) { }

	// // RVA: 0x12BAE60 Offset: 0x12BAE60 VA: 0x12BAE60
	public static bool MHJBBLBFHIB_IsHomeBgDark()
    {
		return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KFOCBNDNHDJ_HomeBgDark == 1;
	}

	// // RVA: 0x12BAF44 Offset: 0x12BAF44 VA: 0x12BAF44
	// public static void LLAMCBGJNOG(bool BBIFHJGMAMJ) { }

	// // RVA: 0x12BB028 Offset: 0x12BB028 VA: 0x12BB028
	public static CGFNKMNBNBN ELKDCEEPLKB(int PPFNGGCBJKC)
	{
		if(PPFNGGCBJKC > 0)
		{
			ALJHJDHNFFB_HomeBg.ADLLAFIDFAM bg = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PFEKKPABPKL_HomeBg.NLPKHJDEDPI(PPFNGGCBJKC);
			if (bg != null)
			{
				CGFNKMNBNBN res = new CGFNKMNBNBN();
				res.PPFNGGCBJKC_Id = bg.PPFNGGCBJKC_Id;
				res.KJBGCLPMLCG_OpenAt = bg.PDBPFJJCADD_OpenAt;
				res.GJFPFFBAKGK_CloseAt = bg.FDBNFFNFOND_CloseAt;
				res.GBJFNGCDKPM_Type = bg.GBJFNGCDKPM_Typ;
				res.KEFGPJBKAOD_BgId = bg.OENPCNBFPDA_BgId;
				res.KLMAMIOBDHP_MusicId = bg.KFNDHKFLPPK_MusId;
				res.OPFGFINHFCE_Name = bg.OPFGFINHFCE_Name;
				res.AIHCEGFANAM_Attr = bg.AIHCEGFANAM_Sa;
				return res;
			}
		}
		return null;
	}

	// // RVA: 0x12BB1E4 Offset: 0x12BB1E4 VA: 0x12BB1E4
	public static List<CGFNKMNBNBN> HANKPONIJNP_GetMusicBgs()
	{
		List<CGFNKMNBNBN> res = new List<CGFNKMNBNBN>();
		res.Clear();
		List<int> bgs = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PFEKKPABPKL_HomeBg.NIJNOFHBKEB_GetAvaiableBgs();
		for (int i = 0; i < bgs.Count; i++)
		{
			ALJHJDHNFFB_HomeBg.ADLLAFIDFAM bg = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PFEKKPABPKL_HomeBg.NLPKHJDEDPI(bgs[i]);
			if(bg.KFNDHKFLPPK_MusId > -1)
			{
				CGFNKMNBNBN data = new CGFNKMNBNBN();
				data.PPFNGGCBJKC_Id = bg.PPFNGGCBJKC_Id;
				data.KJBGCLPMLCG_OpenAt = bg.PDBPFJJCADD_OpenAt;
				data.GJFPFFBAKGK_CloseAt = bg.FDBNFFNFOND_CloseAt;
				data.GBJFNGCDKPM_Type = bg.GBJFNGCDKPM_Typ;
				data.KEFGPJBKAOD_BgId = bg.OENPCNBFPDA_BgId;
				data.KLMAMIOBDHP_MusicId = bg.KFNDHKFLPPK_MusId;
				data.OPFGFINHFCE_Name = bg.OPFGFINHFCE_Name;
				data.AIHCEGFANAM_Attr = bg.AIHCEGFANAM_Sa;
				res.Add(data);
			}
		}
		return res;
	}

	// // RVA: 0x12B98D0 Offset: 0x12B98D0 VA: 0x12B98D0
	// public static bool FEDEDAOCJEG(int OFGAFPOFKOG) { }

	// // RVA: 0x12BB598 Offset: 0x12BB598 VA: 0x12BB598
	// public static bool ADLMEEFKPOM(int OFGAFPOFKOG) { }

	// // RVA: 0x12BB5AC Offset: 0x12BB5AC VA: 0x12BB5AC
	// public static bool CLBDFPACPKE(long OFCBCEKFAMJ, out CGFNKMNBNBN HJKPKPKINJP) { }

	// // RVA: 0x12BB738 Offset: 0x12BB738 VA: 0x12BB738
	public static bool DELFEMBCFCO_GetFirstAvaiableMusicBg(long OFCBCEKFAMJ, out CGFNKMNBNBN HJKPKPKINJP)
	{
		HJKPKPKINJP = null;
		List<CGFNKMNBNBN> l = HANKPONIJNP_GetMusicBgs();
		if (l != null)
		{
			foreach(var c in l)
			{
				if(c.KJBGCLPMLCG_OpenAt < OFCBCEKFAMJ && c.GJFPFFBAKGK_CloseAt > OFCBCEKFAMJ)
				{
					HJKPKPKINJP = c;
					return true;
				}
			}
		}
		return false;
	}

	// [IteratorStateMachineAttribute] // RVA: 0x740FEC Offset: 0x740FEC VA: 0x740FEC
	// // RVA: 0x12BB8F0 Offset: 0x12BB8F0 VA: 0x12BB8F0
	// public static IEnumerator HIIJHIKDJCP(Action<Texture2D> KBCBGIGOLHP) { }

	// [IteratorStateMachineAttribute] // RVA: 0x741064 Offset: 0x741064 VA: 0x741064
	// // RVA: 0x12BB99C Offset: 0x12BB99C VA: 0x12BB99C
	// public static IEnumerator PKMMMMFMCBE(int KEFGPJBKAOD, Action<Texture2D> KBCBGIGOLHP) { }

	// // RVA: 0x12BBA64 Offset: 0x12BBA64 VA: 0x12BBA64
	public static bool DGCIHGPOMCI(long JHNMKKNEENE)
	{
		TodoLogger.Log(5, "DGCIHGPOMCI");
		return false;
	}
}
