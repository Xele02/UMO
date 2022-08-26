using System.Collections.Generic;
using XeApp.Game.Common;
public class CGFNKMNBNBN
{
	public long PPFNGGCBJKC; // 0x8
	public long KJBGCLPMLCG; // 0x10
	public long GJFPFFBAKGK; // 0x18
	public int GBJFNGCDKPM; // 0x20
	public int KEFGPJBKAOD; // 0x24
	public int KLMAMIOBDHP; // 0x28
	public string OPFGFINHFCE; // 0x2C
	public SeriesAttr.Type AIHCEGFANAM; // 0x30

	// // RVA: 0x12B951C Offset: 0x12B951C VA: 0x12B951C
	// public static List<CGFNKMNBNBN> KIONEGHMJIA() { }

	// // RVA: 0x12B98EC Offset: 0x12B98EC VA: 0x12B98EC
	public static void HHGLKFFKFAB(int HILIKOLBGEJ = -1)
	{
		List<DEKKMGAFJCG_Diva.MNNLOBDPCCH> listDiva = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva.NBIGLBMHEDC;
		for (int i = 0; i < listDiva.Count; i++)
		{
			if(listDiva[i].DIPKCALNIII != HILIKOLBGEJ && listDiva[i].CPGFPEDMDEH == 1)
			{
				BJPLLEBHAGO dbDiva = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.CDENCMNHNGA[listDiva[i].DIPKCALNIII - 1];
				if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.POCPLFJCHDD[dbDiva.CMBCBNEODPD - 1].BEBJKJKBOGH_Time == 0)
				{
					DPMCLJMIBDK(dbDiva.CMBCBNEODPD, NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
				}
			}
		}
	}

	// // RVA: 0x12B9FE0 Offset: 0x12B9FE0 VA: 0x12B9FE0
	public static bool CEJADGLBCPA()
	{
		List<DEKKMGAFJCG_Diva.MNNLOBDPCCH> listDiva = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva.NBIGLBMHEDC;
		for (int i = 0; i < listDiva.Count; i++)
		{
			BJPLLEBHAGO dbDiva = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.CDENCMNHNGA[listDiva[i].DIPKCALNIII - 1];
			if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.POCPLFJCHDD[dbDiva.CMBCBNEODPD - 1].BEBJKJKBOGH_Time != 0)
				return true;
		}
		return false;
	}

	// // RVA: 0x12BA33C Offset: 0x12BA33C VA: 0x12BA33C
	// public static List<CGFNKMNBNBN> ABOLOPHFADL() { }

	// // RVA: 0x12BA9C4 Offset: 0x12BA9C4 VA: 0x12BA9C4
	// public static bool JBNMNPMCIBM(int PPFNGGCBJKC) { }

	// // RVA: 0x12B9DD4 Offset: 0x12B9DD4 VA: 0x12B9DD4
	public static void DPMCLJMIBDK(int PPFNGGCBJKC, long BEBJKJKBOGH_Time)
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.CDENCMNHNGA.Count > PPFNGGCBJKC - 1)
		{
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.POCPLFJCHDD[PPFNGGCBJKC - 1].BEBJKJKBOGH_Time = BEBJKJKBOGH_Time;
		}
	}

	// // RVA: 0x12BACA8 Offset: 0x12BACA8 VA: 0x12BACA8
	// public static void DPMCLJMIBDK(BBHNACPENDM AHEFHIMGIBI, int PPFNGGCBJKC, long BEBJKJKBOGH) { }

	// // RVA: 0x12BAE60 Offset: 0x12BAE60 VA: 0x12BAE60
	public static bool MHJBBLBFHIB()
    {
        TodoLogger.Log(0, "TODO");
        return false;
    }

	// // RVA: 0x12BAF44 Offset: 0x12BAF44 VA: 0x12BAF44
	// public static void LLAMCBGJNOG(bool BBIFHJGMAMJ) { }

	// // RVA: 0x12BB028 Offset: 0x12BB028 VA: 0x12BB028
	// public static CGFNKMNBNBN ELKDCEEPLKB(int PPFNGGCBJKC) { }

	// // RVA: 0x12BB1E4 Offset: 0x12BB1E4 VA: 0x12BB1E4
	// public static List<CGFNKMNBNBN> HANKPONIJNP() { }

	// // RVA: 0x12B98D0 Offset: 0x12B98D0 VA: 0x12B98D0
	// public static bool FEDEDAOCJEG(int OFGAFPOFKOG) { }

	// // RVA: 0x12BB598 Offset: 0x12BB598 VA: 0x12BB598
	// public static bool ADLMEEFKPOM(int OFGAFPOFKOG) { }

	// // RVA: 0x12BB5AC Offset: 0x12BB5AC VA: 0x12BB5AC
	// public static bool CLBDFPACPKE(long OFCBCEKFAMJ, out CGFNKMNBNBN HJKPKPKINJP) { }

	// // RVA: 0x12BB738 Offset: 0x12BB738 VA: 0x12BB738
	// public static bool DELFEMBCFCO(long OFCBCEKFAMJ, out CGFNKMNBNBN HJKPKPKINJP) { }

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
