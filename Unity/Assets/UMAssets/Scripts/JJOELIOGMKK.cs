
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XeApp.Game;
using XeSys;

[System.Obsolete("Use JJOELIOGMKK_DivaIntimacyInfo", true)]
public class JJOELIOGMKK { }
public class JJOELIOGMKK_DivaIntimacyInfo
{
	public enum LPBGKOJDNJK
	{
		HJNNKCMLGFL = 0,
		POBNHLKGMPF_1 = 1,
		EHJDMAOKHHP_2 = 2,
		JFEKIMDCKIH_3 = 3,
		GBINCMPKLOF_4 = 4,
	}

	public enum OAIBOODMLME
	{
		DBPDLIPKFAL = 1,
		NLELBHEHKHF = 2,
		CKPGGPDJCAL = 3,
	}

	public enum FAGMPBPFDLD
	{
		DBPDLIPKFAL = 1,
		NLELBHEHKHF = 2,
		CKPGGPDJCAL = 3,
	}

	public enum OPOEENHEJOC
	{
		FNGFADPFKOD = 0,
		EMIFDDHCOFB = 1,
	}

	public class POJEFNEMGNN
	{
		public int CIEOBFIIPLD; // 0x8
		public LPBGKOJDNJK GBJFNGCDKPM; // 0xC
		public int KDCMPJNGLBL; // 0x10
		public int KIJAPOFAGPN; // 0x14
	}

	public class MKGIDHAHAIK
	{
		public int JHOBMMMEJHH_SkillLevel; // 0x8
		public int IGNABALECPK; // 0xC
		public int ODHAIDDEFJL_GetExp; // 0x10
		public int HOMOKJEKKNK_Bonus; // 0x14
		public int NLFMNHGEADA; // 0x18
		public int BJHAMEJPGAJ_Exp; // 0x1C
		public int FGHMGNAMAND; // 0x20
		public int CPDEMMFGKED_Level; // 0x24
		public bool EDPNAEOKGNM; // 0x28
		public int EOIJEGJDLAN_AfterExp; // 0x2C
		public int GGAEHEIPGND; // 0x30
		public int KBHJOBKOOGC_NextLevel; // 0x34
		public bool PFIILLOIDIL; // 0x38
		public bool LDHOOPGDBJC; // 0x39
		public List<LPBGKOJDNJK> CKDNPHLDIEM; // 0x3C
		public List<int> EEIBCALKFFF; // 0x40
		public List<int> IELPCAEACLL; // 0x44
		public List<string> HBCBADBPNCJ; // 0x48
		public int IOCFPAAEFHM_FullItemId; // 0x4C
		public int LEAKFAFGEKK_Count; // 0x50
		public string CCJDPKBGJPH_Name; // 0x54
		public string JLKIADFKPFL_Desc; // 0x58

		//// RVA: 0x1351720 Offset: 0x1351720 VA: 0x1351720
		public void LHPDDGIJKNB_Reset()
		{
			KBHJOBKOOGC_NextLevel = 0;
			PFIILLOIDIL = false;
			LDHOOPGDBJC = false;
			EOIJEGJDLAN_AfterExp = 0;
			GGAEHEIPGND = 0;
			NLFMNHGEADA = 0;
			BJHAMEJPGAJ_Exp = 0;
			FGHMGNAMAND = 0;
			CPDEMMFGKED_Level = 0;
			EDPNAEOKGNM = false;
			JHOBMMMEJHH_SkillLevel = 0;
			IGNABALECPK = 0;
			ODHAIDDEFJL_GetExp = 0;
			HOMOKJEKKNK_Bonus = 0;
			CKDNPHLDIEM = new List<LPBGKOJDNJK>();
			EEIBCALKFFF = new List<int>();
			IELPCAEACLL = new List<int>();
			HBCBADBPNCJ = new List<string>();
			CKDNPHLDIEM.Clear();
			EEIBCALKFFF.Clear();
			IELPCAEACLL.Clear();
			HBCBADBPNCJ.Clear();
		}
	}

	public int AHHJLDLAPAN_DivaId; // 0x8
	public int HEKJGCMNJAB_CurrentLevel = 1; // 0xC
	public int KPEAGFJHNDP_CurrentLevelExp; // 0x10
	public int KOKCFJDMJLI  = 65000; // 0x14
	public int NHCCINMHEAB_Tension; // 0x18
	public int MIKFKJKDOBI_TouchPoint = 100; // 0x1C
	public int JGLMDLKHFGG_FavBonus = 50; // 0x20
	public int MFFJEALABOG_TensionBonus = 50; // 0x24
	public int OMAEOHMDCLI_FirstPresentId; // 0x28
	private StringBuilder BAHOPFGBAHN = new StringBuilder(64); // 0x2C
	public int IOCFPAAEFHM; // 0x30
	public int LEAKFAFGEKK; // 0x34
	public List<int> GLLNLNDNIHM; // 0x38
	public List<int> DLNOIGEGLEA; // 0x3C
	public List<POJEFNEMGNN> LGPDCPDDECG; // 0x40
	public MKGIDHAHAIK HBODCMLFDOB = new MKGIDHAHAIK(); // 0x44

	//// RVA: 0x1351064 Offset: 0x1351064 VA: 0x1351064
	public void KHEKNNFCAOI(int AHHJLDLAPAN_DivaId)
	{
		if(AHHJLDLAPAN_DivaId > 0)
		{
			if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null && IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy != null)
			{
				this.AHHJLDLAPAN_DivaId = AHHJLDLAPAN_DivaId;
				HBODCMLFDOB.LHPDDGIJKNB_Reset();
				LGPDCPDDECG = new List<POJEFNEMGNN>();
				LGPDCPDDECG.Clear();
				for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.OOCKOCAACMD_DataByLevel.Count; i++)
				{
					GJALOMELEHD_Intimacy.MFMLEAMJJCH_LevelInfo m = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.OOCKOCAACMD_DataByLevel[i];
					if(m.DMEDKJPOLCH > 0)
					{
						POJEFNEMGNN data = new POJEFNEMGNN();
						data.CIEOBFIIPLD = m.ANAJIAENLNB;
						data.GBJFNGCDKPM = (LPBGKOJDNJK)m.DMEDKJPOLCH;
						data.KDCMPJNGLBL = m.EIIDPKCBKEK_SkillLevel;
						data.KIJAPOFAGPN = m.ECEKNKIDING(AHHJLDLAPAN_DivaId - 1);
						LGPDCPDDECG.Add(data);
					}
				}
				CEBFFLDKAEC_SecureInt v = new CEBFFLDKAEC_SecureInt();
				MIKFKJKDOBI_TouchPoint = 100;
				if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.OHJFBLFELNK_IntArray.TryGetValue("touch_point", out v))
				{
					MIKFKJKDOBI_TouchPoint = v.DNJEJEANJGL_Value;
				}
				JGLMDLKHFGG_FavBonus = 50;
				if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.OHJFBLFELNK_IntArray.TryGetValue("favorite_bonus", out v))
				{
					JGLMDLKHFGG_FavBonus = v.DNJEJEANJGL_Value;
				}
				MFFJEALABOG_TensionBonus = 50;
				if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.OHJFBLFELNK_IntArray.TryGetValue("tension_bonus", out v))
				{
					MFFJEALABOG_TensionBonus = v.DNJEJEANJGL_Value;
				}
				OMAEOHMDCLI_FirstPresentId = 0;
				if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.OHJFBLFELNK_IntArray.TryGetValue("first_present_id", out v))
				{
					OMAEOHMDCLI_FirstPresentId = v.DNJEJEANJGL_Value;
				}
				HCDGELDHFHB(false);
			}
		}
	}

	//// RVA: 0x1352560 Offset: 0x1352560 VA: 0x1352560
	private bool MOACIBEKLEN(int DNBFMLBNAEE)
	{
		if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy == null)
			return false;
		if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva == null)
			return false;
		DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo diva = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(AHHJLDLAPAN_DivaId);
		if (diva == null)
			return false;
		HBODCMLFDOB.BJHAMEJPGAJ_Exp = diva.BNDNNCHJGBB_IntimacyExp;
		HBODCMLFDOB.CPDEMMFGKED_Level = diva.KCCONFODCPN_IntimacyLevel;
		if (HBODCMLFDOB.CPDEMMFGKED_Level < 1)
			HBODCMLFDOB.CPDEMMFGKED_Level = 1;
		HBODCMLFDOB.FGHMGNAMAND = 0;
		if (HBODCMLFDOB.CPDEMMFGKED_Level > 0 && IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.GLHEHGGKILG_GetMaxLevel() > HBODCMLFDOB.CPDEMMFGKED_Level)
		{
			HBODCMLFDOB.FGHMGNAMAND = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.OOCKOCAACMD_DataByLevel[HBODCMLFDOB.CPDEMMFGKED_Level].IHGDLBBPKFI;
		}
		HBODCMLFDOB.KBHJOBKOOGC_NextLevel = HBODCMLFDOB.CPDEMMFGKED_Level;
		int gainLevel = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva.BJBKCMPCPME(AHHJLDLAPAN_DivaId, DNBFMLBNAEE, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy);
		HBODCMLFDOB.EOIJEGJDLAN_AfterExp = diva.BNDNNCHJGBB_IntimacyExp;
		HBODCMLFDOB.LDHOOPGDBJC = gainLevel > 0;
		if(HBODCMLFDOB.LDHOOPGDBJC)
		{
			HBODCMLFDOB.KBHJOBKOOGC_NextLevel += gainLevel;
		}
		HBODCMLFDOB.GGAEHEIPGND = 0;
		if (HBODCMLFDOB.KBHJOBKOOGC_NextLevel > 0)
		{
			if(HBODCMLFDOB.KBHJOBKOOGC_NextLevel < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.GLHEHGGKILG_GetMaxLevel())
			{
				HBODCMLFDOB.GGAEHEIPGND = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.OOCKOCAACMD_DataByLevel[HBODCMLFDOB.KBHJOBKOOGC_NextLevel].IHGDLBBPKFI;
			}
		}
		HCDGELDHFHB(false);
		CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.MJDMEKMGFJA_IntimacyTouchSaveTime = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		return true;
	}

	//// RVA: 0x1352ACC Offset: 0x1352ACC VA: 0x1352ACC
	public bool HNMJKLEJLPC(int ADJBIEOILPJ, int HMFFHLPNMPH)
	{
		if(ADJBIEOILPJ < 1)
			return false;
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null)
			{
				GJALOMELEHD_Intimacy.ELAIMNHBCFB dbIntmacy = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.CJAEGOMDICD[ADJBIEOILPJ - 1];
				EGOLBAPFHHD_Common.DEEGPPKGGLK saveIntimacy = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.DHJFHILPKLB_IntimacyPresent[ADJBIEOILPJ - 1];
				if(saveIntimacy.BFINGCJHOHI_Cnt - HMFFHLPNMPH > -1)
				{
					saveIntimacy.BFINGCJHOHI_Cnt -= HMFFHLPNMPH;
					CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva.IGFOFCEKIAM(AHHJLDLAPAN_DivaId, HMFFHLPNMPH);
					int a1 = dbIntmacy.JBGEEPFKIGG * HMFFHLPNMPH;
					if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.GLHEHGGKILG_GetMaxLevel() <= HEKJGCMNJAB_CurrentLevel)
					{
						if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.NJGEDPHNIKC_IsPresentLimitEnabled())
							a1 = 0;
					}
					HBODCMLFDOB.LHPDDGIJKNB_Reset();
					HBODCMLFDOB.ODHAIDDEFJL_GetExp = a1;
					HBODCMLFDOB.NLFMNHGEADA = a1;
					HBODCMLFDOB.HOMOKJEKKNK_Bonus = 0;
					if(GACANKEBLEE(ADJBIEOILPJ))
					{
						HBODCMLFDOB.NLFMNHGEADA += (JGLMDLKHFGG_FavBonus * a1) / 100;
						HBODCMLFDOB.HOMOKJEKKNK_Bonus += JGLMDLKHFGG_FavBonus;
					}
					if(ANJLEBDBEGF(ADJBIEOILPJ))
					{
						HBODCMLFDOB.NLFMNHGEADA += (MFFJEALABOG_TensionBonus * a1) / 100;
						HBODCMLFDOB.HOMOKJEKKNK_Bonus += MFFJEALABOG_TensionBonus;
					}
					if(MOACIBEKLEN(HBODCMLFDOB.NLFMNHGEADA))
					{
						CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.ANNIPKMMIAC_IntimacyPresentSaveDate = NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD;
                        IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived);
						if(ev != null)
						{
							TodoLogger.LogError(TodoLogger.EventSp_7, "Event");
						}
						if(GNGMCIAIKMA.HHCJCDFCLOB != null)
						{
							GNGMCIAIKMA.HHCJCDFCLOB.GJENEJOANEL(DKFJADMCNPI.NLKCMNHOBAI.DAOKJMHHKGP_8, AHHJLDLAPAN_DivaId, HMFFHLPNMPH, null);
							GNGMCIAIKMA.HHCJCDFCLOB.HEFIKPAHCIA_IsBingoValid(null, -1);
						}
						ILCCJNDFFOB.HHCJCDFCLOB.DNNLEIKNHKL(AHHJLDLAPAN_DivaId, NHCCINMHEAB_Tension, HBODCMLFDOB.ODHAIDDEFJL_GetExp, HBODCMLFDOB.EOIJEGJDLAN_AfterExp, HBODCMLFDOB.CPDEMMFGKED_Level, HBODCMLFDOB.KBHJOBKOOGC_NextLevel, JpStringLiterals.StringLiteral_12004, ADJBIEOILPJ, HMFFHLPNMPH, JGLMDLKHFGG_FavBonus, MFFJEALABOG_TensionBonus);
						return true;
                    }
				}
			}
		}
		return false;
	}

	//// RVA: 0x1353614 Offset: 0x1353614 VA: 0x1353614
	public bool FNGFADPFKOD()
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null)
			{
				DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo diva = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(AHHJLDLAPAN_DivaId);
				if(diva != null)
				{
					if(CIOECGOMILE.HHCJCDFCLOB != null)
					{
						if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy != null)
						{
							HBODCMLFDOB.LDHOOPGDBJC = false;
							if(HEKJGCMNJAB_CurrentLevel < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.GLHEHGGKILG_GetMaxLevel())
							{
								if(CIOECGOMILE.HHCJCDFCLOB.IOCLFHJLHLE_IntimacyUpdater.IGFMNMADJPP(1, false))
								{
									diva.NFDPLBOIDAB_IntimacyTouchCount++;
									diva.NEAADNDKGLG_IntimacyTouchTotal++;
									HBODCMLFDOB.LHPDDGIJKNB_Reset();
									HBODCMLFDOB.ODHAIDDEFJL_GetExp = MIKFKJKDOBI_TouchPoint;
									HBODCMLFDOB.NLFMNHGEADA = MIKFKJKDOBI_TouchPoint;
									HBODCMLFDOB.HOMOKJEKKNK_Bonus = 0;
									bool res = MOACIBEKLEN(MIKFKJKDOBI_TouchPoint);
									KNKDBNFMAKF_EventSp sp = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as KNKDBNFMAKF_EventSp;
									if(sp != null)
									{
										TodoLogger.LogError(TodoLogger.EventSp_7, "Event SP");
									}
									ILCCJNDFFOB.HHCJCDFCLOB.DNNLEIKNHKL(AHHJLDLAPAN_DivaId, NHCCINMHEAB_Tension, HBODCMLFDOB.ODHAIDDEFJL_GetExp, HBODCMLFDOB.EOIJEGJDLAN_AfterExp, HBODCMLFDOB.CPDEMMFGKED_Level, HBODCMLFDOB.KBHJOBKOOGC_NextLevel, JpStringLiterals.StringLiteral_12005, 0, 0, 0, 0);
									return res;
								}
							}
						}
					}
				}
			}
		}
		return false;
	}

	//// RVA: 0x1353B44 Offset: 0x1353B44 VA: 0x1353B44
	public int GMIEFBELJJH()
	{
		return CIOECGOMILE.HHCJCDFCLOB.IOCLFHJLHLE_IntimacyUpdater.DCLKMNGMIKC(false);
	}

	//// RVA: 0x1353C04 Offset: 0x1353C04 VA: 0x1353C04
	public long BPBIHCAMNBJ()
	{
		return CIOECGOMILE.HHCJCDFCLOB.IOCLFHJLHLE_IntimacyUpdater.CKEJFCLAOHP_GetRemainingTime();
	}

	//// RVA: 0x1353CC0 Offset: 0x1353CC0 VA: 0x1353CC0
	public bool NJAKNMGEKFB(JJOELIOGMKK_DivaIntimacyInfo.LPBGKOJDNJK GBJFNGCDKPM, int KDCMPJNGLBL)
	{
		for(int i = 0; i < LGPDCPDDECG.Count; i++)
		{
			if(LGPDCPDDECG[i].CIEOBFIIPLD <= HEKJGCMNJAB_CurrentLevel)
			{
				if(LGPDCPDDECG[i].GBJFNGCDKPM == GBJFNGCDKPM)
				{
					if(LGPDCPDDECG[i].KDCMPJNGLBL == KDCMPJNGLBL)
						return true;
				}
			}
		}
		return false;
	}

	//// RVA: 0x1353E74 Offset: 0x1353E74 VA: 0x1353E74
	public bool DOMNLGKLGEH_SetMaxSkillLevel(BBHNACPENDM_ServerSaveData LDEGEHAEALK_ServerSave, LPBGKOJDNJK GBJFNGCDKPM, int KDCMPJNGLBL_SkillLevel, bool FBBNPFFEJBN_SetValue)
	{
		if(GBJFNGCDKPM == LPBGKOJDNJK.JFEKIMDCKIH_3 /*3*/)
		{
			if(!FBBNPFFEJBN_SetValue)
			{
				if (KDCMPJNGLBL_SkillLevel <= LDEGEHAEALK_ServerSave.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(AHHJLDLAPAN_DivaId).JLEPLIHFPKD_IntimacySkillLevel)
					return false;
			}
			LDEGEHAEALK_ServerSave.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(AHHJLDLAPAN_DivaId).JLEPLIHFPKD_IntimacySkillLevel = KDCMPJNGLBL_SkillLevel;
			return true;
		}
		return false;
	}

	//// RVA: 0x1353F40 Offset: 0x1353F40 VA: 0x1353F40
	public bool COOGHGBNEMB(BBHNACPENDM_ServerSaveData LDEGEHAEALK_ServerSave, int KIJAPOFAGPN, int HMFFHLPNMPH, int CIEOBFIIPLD)
	{
		JKNGJFOBADP data = new JKNGJFOBADP();
		data.JCHLONCMPAJ();
		data.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.ACNGACBALGM/*20*/, AHHJLDLAPAN_DivaId.ToString() + ":" + 0); //?? unused r11 register instead of 0
		data.CPIICACGNBH_AddItem(LDEGEHAEALK_ServerSave, KIJAPOFAGPN, HMFFHLPNMPH, null, 0);
		return false;
	}

	//// RVA: 0x1354088 Offset: 0x1354088 VA: 0x1354088
	public bool AMHBDAMIAJM(BBHNACPENDM_ServerSaveData LDEGEHAEALK, int KIJAPOFAGPN, int HMFFHLPNMPH)
	{
		JKNGJFOBADP j = new JKNGJFOBADP();
		j.JCHLONCMPAJ();
		j.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.GHLEPCNBCNC/*19*/, "");
		j.CPIICACGNBH_AddItem(LDEGEHAEALK, KIJAPOFAGPN, HMFFHLPNMPH, null, 0);
		return false;
	}

	//// RVA: 0x1351904 Offset: 0x1351904 VA: 0x1351904
	public void HCDGELDHFHB(bool FBBNPFFEJBN = false)
	{
		if (AHHJLDLAPAN_DivaId < 0)
			return;
		DEKKMGAFJCG_Diva saveDiva = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva;
		GJALOMELEHD_Intimacy intimacyDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy;

		DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo divaInfo = saveDiva.LGKFMLIOPKL_GetDivaInfo(AHHJLDLAPAN_DivaId);
		int lvl = HBODCMLFDOB.CPDEMMFGKED_Level < 1 ? 1 : HBODCMLFDOB.CPDEMMFGKED_Level;
		GJALOMELEHD_Intimacy.MFMLEAMJJCH_LevelInfo info1 = intimacyDb.OOCKOCAACMD_DataByLevel[lvl - 1];
		int exp1 = info1.BDLNMOIOMHK_StartExp;

		HEKJGCMNJAB_CurrentLevel = divaInfo.KCCONFODCPN_IntimacyLevel;
		if (HEKJGCMNJAB_CurrentLevel < 1)
			HEKJGCMNJAB_CurrentLevel = 1;
		GJALOMELEHD_Intimacy.MFMLEAMJJCH_LevelInfo curLevelInfo = intimacyDb.OOCKOCAACMD_DataByLevel[HEKJGCMNJAB_CurrentLevel - 1];
		KPEAGFJHNDP_CurrentLevelExp = divaInfo.BNDNNCHJGBB_IntimacyExp - curLevelInfo.BDLNMOIOMHK_StartExp;

		int nextLevel = HEKJGCMNJAB_CurrentLevel;
		int maxLevel = intimacyDb.GLHEHGGKILG_GetMaxLevel();
		if (maxLevel < nextLevel + 1)
			nextLevel = 0;
		GJALOMELEHD_Intimacy.MFMLEAMJJCH_LevelInfo nextLevelInfo = intimacyDb.OOCKOCAACMD_DataByLevel[nextLevel];
		KOKCFJDMJLI = nextLevelInfo.IHGDLBBPKFI;
		HBODCMLFDOB.EDPNAEOKGNM = maxLevel <= lvl;
		HBODCMLFDOB.PFIILLOIDIL = maxLevel <= HEKJGCMNJAB_CurrentLevel;
		CIOECGOMILE.HHCJCDFCLOB.AMCJPIIFHCA();
		if (CIOECGOMILE.HHCJCDFCLOB.MAEKFHENDAA())
		{
			for(int i = 0; i < saveDiva.NBIGLBMHEDC_DivaList.Count; i++)
			{
				saveDiva.EGDJODNNKDE_SetIntimacyTension(i, UnityEngine.Random.Range(1, 4));
			}
		}
		if(saveDiva.BOOKOGDDJGM_GetIntimacyTension(AHHJLDLAPAN_DivaId) == 0)
		{
			saveDiva.EGDJODNNKDE_SetIntimacyTension(AHHJLDLAPAN_DivaId, UnityEngine.Random.Range(1, 4));
		}
		NHCCINMHEAB_Tension = saveDiva.BOOKOGDDJGM_GetIntimacyTension(AHHJLDLAPAN_DivaId);
		HBODCMLFDOB.BJHAMEJPGAJ_Exp -= exp1;
		HBODCMLFDOB.EOIJEGJDLAN_AfterExp -= curLevelInfo.BDLNMOIOMHK_StartExp;
		HBODCMLFDOB.CKDNPHLDIEM.Clear();
		HBODCMLFDOB.EEIBCALKFFF.Clear();
		HBODCMLFDOB.IELPCAEACLL.Clear();
		HBODCMLFDOB.HBCBADBPNCJ.Clear();
		for(int i = HBODCMLFDOB.CPDEMMFGKED_Level; i < HBODCMLFDOB.KBHJOBKOOGC_NextLevel; i++)
		{
			GJALOMELEHD_Intimacy.MFMLEAMJJCH_LevelInfo levelInfo = intimacyDb.OOCKOCAACMD_DataByLevel[i];
			if (levelInfo.DMEDKJPOLCH >= 1)
			{
				DOMNLGKLGEH_SetMaxSkillLevel(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, (LPBGKOJDNJK)levelInfo.DMEDKJPOLCH, levelInfo.EIIDPKCBKEK_SkillLevel, FBBNPFFEJBN);
				HBODCMLFDOB.CKDNPHLDIEM.Add((LPBGKOJDNJK)levelInfo.DMEDKJPOLCH);
				int c = levelInfo.EIIDPKCBKEK_SkillLevel;
				if (levelInfo.DMEDKJPOLCH == 3 && levelInfo.EIIDPKCBKEK_SkillLevel > 0)
				{
					if (levelInfo.EIIDPKCBKEK_SkillLevel < intimacyDb.COHLJLNLBKM.Count)
					{
						c = intimacyDb.COHLJLNLBKM[levelInfo.EIIDPKCBKEK_SkillLevel - 1].JBGEEPFKIGG / 100;
					}
				}
				HBODCMLFDOB.EEIBCALKFFF.Add(c);
				int a = levelInfo.ECEKNKIDING(AHHJLDLAPAN_DivaId - 1);
				if (a > 0)
				{
					COOGHGBNEMB(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, a, 1, levelInfo.ANAJIAENLNB);
				}
				HBODCMLFDOB.IELPCAEACLL.Add(levelInfo.ECEKNKIDING(AHHJLDLAPAN_DivaId - 1));
				HBODCMLFDOB.HBCBADBPNCJ.Add("");
			}
		}
		HBODCMLFDOB.JHOBMMMEJHH_SkillLevel = divaInfo.JLEPLIHFPKD_IntimacySkillLevel;
		HBODCMLFDOB.IGNABALECPK = HBODCMLFDOB.JHOBMMMEJHH_SkillLevel < 1 ? 0 : intimacyDb.COHLJLNLBKM[HBODCMLFDOB.JHOBMMMEJHH_SkillLevel - 1].JBGEEPFKIGG / 100;
		CIOECGOMILE.HHCJCDFCLOB.MJNHMCABCGH();
	}

	//// RVA: 0x135338C Offset: 0x135338C VA: 0x135338C
	public bool GACANKEBLEE(int ADJBIEOILPJ)
	{
		if(ADJBIEOILPJ > 0)
		{
			OJEGDIBEBHP o = new OJEGDIBEBHP();
			o.KHEKNNFCAOI(ADJBIEOILPJ);
			return o.MCLFHOABKGP(AHHJLDLAPAN_DivaId);
		}
		return false;
	}

	//// RVA: 0x1353460 Offset: 0x1353460 VA: 0x1353460
	public bool ANJLEBDBEGF(int ADJBIEOILPJ)
	{
		if(ADJBIEOILPJ > 0)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null)
			{
				if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva != null)
				{
					OJEGDIBEBHP o = new OJEGDIBEBHP();
					o.KHEKNNFCAOI(ADJBIEOILPJ);
					if(o.JONPKLHMOBL != 0)
					{
						return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(AHHJLDLAPAN_DivaId).GCGCFGJCLEL_IntimacyTension == o.JONPKLHMOBL;
					}
					return true;
				}
			}
		}
		return false;
	}

	//// RVA: 0x13541A8 Offset: 0x13541A8 VA: 0x13541A8
	public bool NCNAPMHEINJ()
	{
		if(AHHJLDLAPAN_DivaId > 0)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null)
			{
				if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.NJGEDPHNIKC_IsPresentLimitEnabled())
				{
					return CIOECGOMILE.HHCJCDFCLOB.PAAMLFNPJGJ_IntimacyDivaPresentLeft[AHHJLDLAPAN_DivaId - 1] > 0;
				}
				else
				{
					for(int i = 0; i < CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList.Count; i++)
					{
						if (CIOECGOMILE.HHCJCDFCLOB.PAAMLFNPJGJ_IntimacyDivaPresentLeft[i] == 0)
							return false;
					}
				}
				return true;
			}
		}
		return false;
	}

	//// RVA: 0x1354490 Offset: 0x1354490 VA: 0x1354490
	public bool MLEPCANKIIE(int HMFFHLPNMPH)
	{
		if(CIOECGOMILE.HHCJCDFCLOB != null)
		{
			return CIOECGOMILE.HHCJCDFCLOB.MLEPCANKIIE(AHHJLDLAPAN_DivaId, HMFFHLPNMPH);
		}
		return false;
	}

	//// RVA: 0x1354534 Offset: 0x1354534 VA: 0x1354534
	public int LLFDOKOMJAN_GetPresentLeft()
	{
		if (AHHJLDLAPAN_DivaId < 1)
			return 0;
		if(CIOECGOMILE.HHCJCDFCLOB != null)
		{
			return CIOECGOMILE.HHCJCDFCLOB.PAAMLFNPJGJ_IntimacyDivaPresentLeft[AHHJLDLAPAN_DivaId - 1];
		}
		return 0;
	}

	//// RVA: 0x1354620 Offset: 0x1354620 VA: 0x1354620
	public string IGLBKDDCKEJ()
	{
		BAHOPFGBAHN.SetFormat("diva_s_{0:D2}", AHHJLDLAPAN_DivaId);
		return MessageManager.Instance.GetMessage("master", BAHOPFGBAHN.ToString());
	}

	//// RVA: 0x135472C Offset: 0x135472C VA: 0x135472C
	public bool HFFOJIBDNOG()
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null)
			{
				return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("intimacy_player_level", 8) <= CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KIECDDFNCAN_Level;
			}
		}
		return false;
	}

	//// RVA: 0x13548B4 Offset: 0x13548B4 VA: 0x13548B4
	public int JCFAPAOLDOI(int CIEOBFIIPLD)
	{
		if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database == null || CIEOBFIIPLD < 1 || IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy == null || CIEOBFIIPLD > IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.GLHEHGGKILG_GetMaxLevel())
			return 0;
		return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.OOCKOCAACMD_DataByLevel[CIEOBFIIPLD - 1].IHGDLBBPKFI;
	}

	//// RVA: 0x13549E4 Offset: 0x13549E4 VA: 0x13549E4
	public bool KCJCJLNHMKI()
	{
		HBODCMLFDOB.IOCFPAAEFHM_FullItemId = 0;
		HBODCMLFDOB.LEAKFAFGEKK_Count = 0;
		HBODCMLFDOB.CCJDPKBGJPH_Name = "";
		HBODCMLFDOB.JLKIADFKPFL_Desc = "";
		if(DNJEMPANDNN() && OMAEOHMDCLI_FirstPresentId > 0)
		{
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
			{
				if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null)
				{
					GJALOMELEHD_Intimacy.ELAIMNHBCFB d = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.CJAEGOMDICD[OMAEOHMDCLI_FirstPresentId - 1];
					if(d.PLALNIIBLOF == 2)
					{
						DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo dinfo = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(AHHJLDLAPAN_DivaId);
						dinfo.DDODJCCIENF_IntimacyPresentTotal = 0;
						AMHBDAMIAJM(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, d.GLCLFMGPMAN_FullItemId, 1);
						HBODCMLFDOB.IOCFPAAEFHM_FullItemId = d.GLCLFMGPMAN_FullItemId;
						HBODCMLFDOB.LEAKFAFGEKK_Count = 1;
						HBODCMLFDOB.CCJDPKBGJPH_Name = OJEGDIBEBHP.DDICENAFJDP_GetName(EKLNMHFCAOI.DEACAHNLMNI_getItemId(d.GLCLFMGPMAN_FullItemId));
						HBODCMLFDOB.JLKIADFKPFL_Desc = OJEGDIBEBHP.LJKBBAGJLFP_GetDesc(EKLNMHFCAOI.DEACAHNLMNI_getItemId(d.GLCLFMGPMAN_FullItemId));
						return true;
					}
				}
			}
		}
		return false;
	}

	//// RVA: 0x1354D70 Offset: 0x1354D70 VA: 0x1354D70
	public bool DNJEMPANDNN()
	{
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null)
		{
			if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList.Count > 0)
			{
				int a = 0;
				for (int i = 0; i < CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList.Count; i++)
				{
					a |= (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva.MCIPCILAJIN(i + 1) - 1) ^ 1;
				}
				return a == 0;
			}
			return true;
		}
		return false;
	}

	//// RVA: 0x1354ED0 Offset: 0x1354ED0 VA: 0x1354ED0
	public int HHLEJPBEHNE()
	{
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null)
		{
			int res = 0;
			for(int i = 0; i < CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList.Count; i++)
			{
				res += CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva.KPJIMHGMAGN(i);
            }
			return res;
		}
		return 0;
	}
}
