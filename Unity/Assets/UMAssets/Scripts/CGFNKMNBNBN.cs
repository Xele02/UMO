using System.Collections.Generic;
using XeApp.Game;
using XeApp.Game.Common;
public class CGFNKMNBNBN
{
	public long PPFNGGCBJKC_id; // 0x8
	public long KJBGCLPMLCG_OpenedAt; // 0x10
	public long GJFPFFBAKGK_CloseAt; // 0x18
	public int GBJFNGCDKPM_typ; // 0x20
	public int KEFGPJBKAOD_BgId; // 0x24
	public int KLMAMIOBDHP_MusicId; // 0x28
	public string OPFGFINHFCE_name; // 0x2C
	public SeriesAttr.Type AIHCEGFANAM_SerieAttr; // 0x30

	// // RVA: 0x12B951C Offset: 0x12B951C VA: 0x12B951C
	public static List<CGFNKMNBNBN> KIONEGHMJIA()
	{
		List<CGFNKMNBNBN> res = new List<CGFNKMNBNBN>();
		res.Clear();
		List<int> l = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PFEKKPABPKL_HomeBg.NIJNOFHBKEB_GetAvaiableBgs();
		for (int i = 0; i < l.Count; i++)
		{
			ALJHJDHNFFB_HomeBg.ADLLAFIDFAM dbBg = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PFEKKPABPKL_HomeBg.NLPKHJDEDPI(l[i]);
			if(dbBg.OENPCNBFPDA_bg_id > 0)
			{
				CGFNKMNBNBN data = new CGFNKMNBNBN();
				data.PPFNGGCBJKC_id = dbBg.PPFNGGCBJKC_id;
				data.KJBGCLPMLCG_OpenedAt = dbBg.PDBPFJJCADD_open_at;
				data.GJFPFFBAKGK_CloseAt = dbBg.FDBNFFNFOND_close_at;
				data.GBJFNGCDKPM_typ = dbBg.GBJFNGCDKPM_typ;
				data.KEFGPJBKAOD_BgId = dbBg.OENPCNBFPDA_bg_id;
				data.KLMAMIOBDHP_MusicId = dbBg.KFNDHKFLPPK_mus_id;
				data.OPFGFINHFCE_name = dbBg.OPFGFINHFCE_name;
				data.AIHCEGFANAM_SerieAttr = dbBg.AIHCEGFANAM_SerieAttr;
				res.Add(data);
			}
		}
		return res;
	}

	// // RVA: 0x12B98EC Offset: 0x12B98EC VA: 0x12B98EC
	public static void HHGLKFFKFAB(int HILIKOLBGEJ/* = -1*/)
	{
		List<DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo> listDiva = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList;
		for (int i = 0; i < listDiva.Count; i++)
		{
			if(listDiva[i].DIPKCALNIII_diva_id != HILIKOLBGEJ && listDiva[i].CPGFPEDMDEH_have == 1)
			{
				BJPLLEBHAGO_DivaInfo dbDiva = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.CDENCMNHNGA_table[listDiva[i].DIPKCALNIII_diva_id - 1];
				if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.POCPLFJCHDD_HomeBg[dbDiva.CMBCBNEODPD_HomeBgId - 1].BEBJKJKBOGH_date == 0)
				{
					DPMCLJMIBDK(dbDiva.CMBCBNEODPD_HomeBgId, NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime());
				}
			}
		}
	}

	// // RVA: 0x12B9FE0 Offset: 0x12B9FE0 VA: 0x12B9FE0
	public static bool CEJADGLBCPA()
	{
		List<DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo> listDiva = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList;
		for (int i = 0; i < listDiva.Count; i++)
		{
			BJPLLEBHAGO_DivaInfo dbDiva = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.CDENCMNHNGA_table[listDiva[i].DIPKCALNIII_diva_id - 1];
			if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.POCPLFJCHDD_HomeBg[dbDiva.CMBCBNEODPD_HomeBgId - 1].BEBJKJKBOGH_date != 0)
				return true;
		}
		return false;
	}

	// // RVA: 0x12BA33C Offset: 0x12BA33C VA: 0x12BA33C
	public static List<CGFNKMNBNBN> ABOLOPHFADL()
	{
		HHGLKFFKFAB(-1);
		List<CGFNKMNBNBN> res = new List<CGFNKMNBNBN>();
		res.Clear();
		res.AddRange(KIONEGHMJIA());
		List<ALJHJDHNFFB_HomeBg.ADLLAFIDFAM> l = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PFEKKPABPKL_HomeBg.CDENCMNHNGA_table;
		for(int i = 0; i < l.Count; i++)
		{
			if(l[i].OENPCNBFPDA_bg_id > 0)
			{
				if(l[i].PDBPFJJCADD_open_at == 0)
				{
					if(l[i].FDBNFFNFOND_close_at == 0)
					{
						if(JBNMNPMCIBM_HaveBg(l[i].PPFNGGCBJKC_id))
						{
							CGFNKMNBNBN data = new CGFNKMNBNBN();
							data.PPFNGGCBJKC_id = l[i].PPFNGGCBJKC_id;
							data.KJBGCLPMLCG_OpenedAt = l[i].PDBPFJJCADD_open_at;
							data.GJFPFFBAKGK_CloseAt = l[i].FDBNFFNFOND_close_at;
							data.GBJFNGCDKPM_typ = l[i].GBJFNGCDKPM_typ;
							data.KEFGPJBKAOD_BgId = l[i].OENPCNBFPDA_bg_id;
							data.KLMAMIOBDHP_MusicId = l[i].KFNDHKFLPPK_mus_id;
							data.OPFGFINHFCE_name = l[i].OPFGFINHFCE_name;
							data.AIHCEGFANAM_SerieAttr = l[i].AIHCEGFANAM_SerieAttr;
							res.Add(data);
						}
					}
				}
			}
		}
		return res;
	}

	// // RVA: 0x12BA9C4 Offset: 0x12BA9C4 VA: 0x12BA9C4
	public static bool JBNMNPMCIBM_HaveBg(int _PPFNGGCBJKC_id)
	{
		if((_PPFNGGCBJKC_id - 1) < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PFEKKPABPKL_HomeBg.CDENCMNHNGA_table.Count)
		{
			if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.POCPLFJCHDD_HomeBg[_PPFNGGCBJKC_id - 1].BEBJKJKBOGH_date != 0)
				return true;
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PFEKKPABPKL_HomeBg.CDENCMNHNGA_table[_PPFNGGCBJKC_id - 1].LEJOJFHKHIJ_Have == 1;
		}
		return false;
	}

	// // RVA: 0x12B9DD4 Offset: 0x12B9DD4 VA: 0x12B9DD4
	public static void DPMCLJMIBDK(int _PPFNGGCBJKC_id, long _BEBJKJKBOGH_date)
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PFEKKPABPKL_HomeBg.CDENCMNHNGA_table.Count > _PPFNGGCBJKC_id - 1)
		{
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.POCPLFJCHDD_HomeBg[_PPFNGGCBJKC_id - 1].BEBJKJKBOGH_date = _BEBJKJKBOGH_date;
		}
	}

	// // RVA: 0x12BACA8 Offset: 0x12BACA8 VA: 0x12BACA8
	public static void DPMCLJMIBDK(BBHNACPENDM_ServerSaveData _AHEFHIMGIBI_PlayerData, int _PPFNGGCBJKC_id, long _BEBJKJKBOGH_date)
	{
		if(_PPFNGGCBJKC_id - 1 < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PFEKKPABPKL_HomeBg.CDENCMNHNGA_table.Count)
		{
			_AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.POCPLFJCHDD_HomeBg[_PPFNGGCBJKC_id - 1].BEBJKJKBOGH_date = _BEBJKJKBOGH_date;
		}
	}

	// // RVA: 0x12BAE60 Offset: 0x12BAE60 VA: 0x12BAE60
	public static bool MHJBBLBFHIB_IsHomeBgDark()
    {
		return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.KFOCBNDNHDJ_home_bg_dark == 1;
	}

	// // RVA: 0x12BAF44 Offset: 0x12BAF44 VA: 0x12BAF44
	public static void LLAMCBGJNOG_SetHomeBgDark(bool BBIFHJGMAMJ)
	{
		CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.KFOCBNDNHDJ_home_bg_dark = BBIFHJGMAMJ ? 1 : 0;
	}

	// // RVA: 0x12BB028 Offset: 0x12BB028 VA: 0x12BB028
	public static CGFNKMNBNBN ELKDCEEPLKB(int _PPFNGGCBJKC_id)
	{
		if(_PPFNGGCBJKC_id > 0)
		{
			ALJHJDHNFFB_HomeBg.ADLLAFIDFAM bg = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PFEKKPABPKL_HomeBg.NLPKHJDEDPI(_PPFNGGCBJKC_id);
			if (bg != null)
			{
				CGFNKMNBNBN res = new CGFNKMNBNBN();
				res.PPFNGGCBJKC_id = bg.PPFNGGCBJKC_id;
				res.KJBGCLPMLCG_OpenedAt = bg.PDBPFJJCADD_open_at;
				res.GJFPFFBAKGK_CloseAt = bg.FDBNFFNFOND_close_at;
				res.GBJFNGCDKPM_typ = bg.GBJFNGCDKPM_typ;
				res.KEFGPJBKAOD_BgId = bg.OENPCNBFPDA_bg_id;
				res.KLMAMIOBDHP_MusicId = bg.KFNDHKFLPPK_mus_id;
				res.OPFGFINHFCE_name = bg.OPFGFINHFCE_name;
				res.AIHCEGFANAM_SerieAttr = bg.AIHCEGFANAM_SerieAttr;
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
			if(bg.KFNDHKFLPPK_mus_id > -1)
			{
				CGFNKMNBNBN data = new CGFNKMNBNBN();
				data.PPFNGGCBJKC_id = bg.PPFNGGCBJKC_id;
				data.KJBGCLPMLCG_OpenedAt = bg.PDBPFJJCADD_open_at;
				data.GJFPFFBAKGK_CloseAt = bg.FDBNFFNFOND_close_at;
				data.GBJFNGCDKPM_typ = bg.GBJFNGCDKPM_typ;
				data.KEFGPJBKAOD_BgId = bg.OENPCNBFPDA_bg_id;
				data.KLMAMIOBDHP_MusicId = bg.KFNDHKFLPPK_mus_id;
				data.OPFGFINHFCE_name = bg.OPFGFINHFCE_name;
				data.AIHCEGFANAM_SerieAttr = bg.AIHCEGFANAM_SerieAttr;
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
	public static bool CLBDFPACPKE(long OFCBCEKFAMJ, out CGFNKMNBNBN HJKPKPKINJP)
	{
		HJKPKPKINJP = null;
		List<CGFNKMNBNBN> l = KIONEGHMJIA();
		foreach(var b in l)
		{
			if(OFCBCEKFAMJ >= b.KJBGCLPMLCG_OpenedAt && b.GJFPFFBAKGK_CloseAt >= OFCBCEKFAMJ)
			{
				HJKPKPKINJP = b;
				return true;
			}
		}
		return false;
	}

	// // RVA: 0x12BB738 Offset: 0x12BB738 VA: 0x12BB738
	public static bool DELFEMBCFCO_GetFirstAvaiableMusicBg(long OFCBCEKFAMJ, out CGFNKMNBNBN HJKPKPKINJP)
	{
		HJKPKPKINJP = null;
		List<CGFNKMNBNBN> l = HANKPONIJNP_GetMusicBgs();
		if (l != null)
		{
			foreach(var c in l)
			{
				if(c.KJBGCLPMLCG_OpenedAt <= OFCBCEKFAMJ && c.GJFPFFBAKGK_CloseAt >= OFCBCEKFAMJ)
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
	// public static IEnumerator HIIJHIKDJCP_SetLimitBgTexture(Action<Texture2D> KBCBGIGOLHP) { }

	// [IteratorStateMachineAttribute] // RVA: 0x741064 Offset: 0x741064 VA: 0x741064
	// // RVA: 0x12BB99C Offset: 0x12BB99C VA: 0x12BB99C
	// public static IEnumerator PKMMMMFMCBE_SetBgTexture(int _KEFGPJBKAOD_BgId, Action<Texture2D> KBCBGIGOLHP) { }

	// // RVA: 0x12BBA64 Offset: 0x12BBA64 VA: 0x12BBA64
	public static bool DGCIHGPOMCI_CheckHomeBgExpire(long _JHNMKKNEENE_Time)
	{
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.MDKELFPNCDB_home_scene_evolveid == 0)
		{
			CGFNKMNBNBN g = ELKDCEEPLKB(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.GPHPNEGGGBG_home_scene_id);
			if(g != null)
			{
				if(g.GJFPFFBAKGK_CloseAt != 0 && g.GJFPFFBAKGK_CloseAt < _JHNMKKNEENE_Time)
				{
					CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.GPHPNEGGGBG_home_scene_id = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.CDENCMNHNGA_table[GameManager.Instance.GetHomeDiva().AHHJLDLAPAN_DivaId - 1].CMBCBNEODPD_HomeBgId;
					return true;
				}
			}
		}
		return false;
	}
}
