
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
		HJNNKCMLGFL_0_None = 0,
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
		FNGFADPFKOD_0_DivaIntimacy = 0,
		EMIFDDHCOFB_1_DivaPresent = 1,
	}

	public class POJEFNEMGNN
	{
		public int CIEOBFIIPLD_Level; // 0x8
		public LPBGKOJDNJK GBJFNGCDKPM_Type; // 0xC
		public int KDCMPJNGLBL_SkillLevel; // 0x10
		public int KIJAPOFAGPN_ItemId; // 0x14
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
		public bool LDHOOPGDBJC_IsLevelUp; // 0x39
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
			LDHOOPGDBJC_IsLevelUp = false;
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
	public int IOCFPAAEFHM_FullItemId; // 0x30
	public int LEAKFAFGEKK_Count; // 0x34
	public List<int> GLLNLNDNIHM; // 0x38
	public List<int> DLNOIGEGLEA; // 0x3C
	public List<POJEFNEMGNN> LGPDCPDDECG; // 0x40
	public MKGIDHAHAIK HBODCMLFDOB_Result = new MKGIDHAHAIK(); // 0x44

	//// RVA: 0x1351064 Offset: 0x1351064 VA: 0x1351064
	public void KHEKNNFCAOI_Init(int _AHHJLDLAPAN_DivaId)
	{
		if(_AHHJLDLAPAN_DivaId > 0)
		{
			if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null && IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy != null)
			{
				this.AHHJLDLAPAN_DivaId = _AHHJLDLAPAN_DivaId;
				HBODCMLFDOB_Result.LHPDDGIJKNB_Reset();
				LGPDCPDDECG = new List<POJEFNEMGNN>();
				LGPDCPDDECG.Clear();
				for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.OOCKOCAACMD_DataByLevel.Count; i++)
				{
					GJALOMELEHD_Intimacy.MFMLEAMJJCH_LevelInfo m = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.OOCKOCAACMD_DataByLevel[i];
					if(m.DMEDKJPOLCH_Category > 0)
					{
						POJEFNEMGNN data = new POJEFNEMGNN();
						data.CIEOBFIIPLD_Level = m.ANAJIAENLNB_Level;
						data.GBJFNGCDKPM_Type = (LPBGKOJDNJK)m.DMEDKJPOLCH_Category;
						data.KDCMPJNGLBL_SkillLevel = m.EIIDPKCBKEK_prm;
						data.KIJAPOFAGPN_ItemId = m.ECEKNKIDING(_AHHJLDLAPAN_DivaId - 1);
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
	private bool MOACIBEKLEN(int _DNBFMLBNAEE_Point)
	{
		if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy == null)
			return false;
		if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva == null)
			return false;
		DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo diva = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(AHHJLDLAPAN_DivaId);
		if (diva == null)
			return false;
		HBODCMLFDOB_Result.BJHAMEJPGAJ_Exp = diva.BNDNNCHJGBB_IntimacyExp;
		HBODCMLFDOB_Result.CPDEMMFGKED_Level = diva.KCCONFODCPN_IntimacyLevel;
		if (HBODCMLFDOB_Result.CPDEMMFGKED_Level < 1)
			HBODCMLFDOB_Result.CPDEMMFGKED_Level = 1;
		HBODCMLFDOB_Result.FGHMGNAMAND = 0;
		if (HBODCMLFDOB_Result.CPDEMMFGKED_Level > 0 && IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.GLHEHGGKILG_GetMaxLevel() > HBODCMLFDOB_Result.CPDEMMFGKED_Level)
		{
			HBODCMLFDOB_Result.FGHMGNAMAND = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.OOCKOCAACMD_DataByLevel[HBODCMLFDOB_Result.CPDEMMFGKED_Level].IHGDLBBPKFI_Next;
		}
		HBODCMLFDOB_Result.KBHJOBKOOGC_NextLevel = HBODCMLFDOB_Result.CPDEMMFGKED_Level;
		int gainLevel = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva.BJBKCMPCPME(AHHJLDLAPAN_DivaId, _DNBFMLBNAEE_Point, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy);
		HBODCMLFDOB_Result.EOIJEGJDLAN_AfterExp = diva.BNDNNCHJGBB_IntimacyExp;
		HBODCMLFDOB_Result.LDHOOPGDBJC_IsLevelUp = gainLevel > 0;
		if(HBODCMLFDOB_Result.LDHOOPGDBJC_IsLevelUp)
		{
			HBODCMLFDOB_Result.KBHJOBKOOGC_NextLevel += gainLevel;
		}
		HBODCMLFDOB_Result.GGAEHEIPGND = 0;
		if (HBODCMLFDOB_Result.KBHJOBKOOGC_NextLevel > 0)
		{
			if(HBODCMLFDOB_Result.KBHJOBKOOGC_NextLevel < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.GLHEHGGKILG_GetMaxLevel())
			{
				HBODCMLFDOB_Result.GGAEHEIPGND = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.OOCKOCAACMD_DataByLevel[HBODCMLFDOB_Result.KBHJOBKOOGC_NextLevel].IHGDLBBPKFI_Next;
			}
		}
		HCDGELDHFHB(false);
		CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.MJDMEKMGFJA_IntimacyTouchSaveTime = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		return true;
	}

	//// RVA: 0x1352ACC Offset: 0x1352ACC VA: 0x1352ACC
	public bool HNMJKLEJLPC(int _ADJBIEOILPJ_ItemPresentId, int _HMFFHLPNMPH_Count)
	{
		if(_ADJBIEOILPJ_ItemPresentId < 1)
			return false;
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
			{
				GJALOMELEHD_Intimacy.ELAIMNHBCFB dbIntmacy = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.CJAEGOMDICD[_ADJBIEOILPJ_ItemPresentId - 1];
				EGOLBAPFHHD_Common.DEEGPPKGGLK saveIntimacy = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.DHJFHILPKLB_IntimacyPresent[_ADJBIEOILPJ_ItemPresentId - 1];
				if(saveIntimacy.BFINGCJHOHI_Count - _HMFFHLPNMPH_Count > -1)
				{
					saveIntimacy.BFINGCJHOHI_Count -= _HMFFHLPNMPH_Count;
					CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva.IGFOFCEKIAM(AHHJLDLAPAN_DivaId, _HMFFHLPNMPH_Count);
					int a1 = dbIntmacy.JBGEEPFKIGG_val * _HMFFHLPNMPH_Count;
					if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.GLHEHGGKILG_GetMaxLevel() <= HEKJGCMNJAB_CurrentLevel)
					{
						if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.NJGEDPHNIKC_IsPresentLimitEnabled())
							a1 = 0;
					}
					HBODCMLFDOB_Result.LHPDDGIJKNB_Reset();
					HBODCMLFDOB_Result.ODHAIDDEFJL_GetExp = a1;
					HBODCMLFDOB_Result.NLFMNHGEADA = a1;
					HBODCMLFDOB_Result.HOMOKJEKKNK_Bonus = 0;
					if(GACANKEBLEE(_ADJBIEOILPJ_ItemPresentId))
					{
						HBODCMLFDOB_Result.NLFMNHGEADA += (JGLMDLKHFGG_FavBonus * a1) / 100;
						HBODCMLFDOB_Result.HOMOKJEKKNK_Bonus += JGLMDLKHFGG_FavBonus;
					}
					if(ANJLEBDBEGF(_ADJBIEOILPJ_ItemPresentId))
					{
						HBODCMLFDOB_Result.NLFMNHGEADA += (MFFJEALABOG_TensionBonus * a1) / 100;
						HBODCMLFDOB_Result.HOMOKJEKKNK_Bonus += MFFJEALABOG_TensionBonus;
					}
					if(MOACIBEKLEN(HBODCMLFDOB_Result.NLFMNHGEADA))
					{
						CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.ANNIPKMMIAC_IntimacyPresentSaveDate = NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD;
                        KNKDBNFMAKF_EventSp ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as KNKDBNFMAKF_EventSp;
						if(ev != null)
						{
							ev.POHBAGJLOLI_IncDivaCount(OPOEENHEJOC.EMIFDDHCOFB_1_DivaPresent);
						}
						if(GNGMCIAIKMA.HHCJCDFCLOB != null)
						{
							GNGMCIAIKMA.HHCJCDFCLOB.GJENEJOANEL(DKFJADMCNPI.NLKCMNHOBAI.DAOKJMHHKGP_8, AHHJLDLAPAN_DivaId, _HMFFHLPNMPH_Count, null);
							GNGMCIAIKMA.HHCJCDFCLOB.HEFIKPAHCIA_UpdateMission(null, -1);
						}
						ILCCJNDFFOB.HHCJCDFCLOB.DNNLEIKNHKL(AHHJLDLAPAN_DivaId, NHCCINMHEAB_Tension, HBODCMLFDOB_Result.ODHAIDDEFJL_GetExp, HBODCMLFDOB_Result.EOIJEGJDLAN_AfterExp, HBODCMLFDOB_Result.CPDEMMFGKED_Level, HBODCMLFDOB_Result.KBHJOBKOOGC_NextLevel, JpStringLiterals.StringLiteral_12004, _ADJBIEOILPJ_ItemPresentId, _HMFFHLPNMPH_Count, JGLMDLKHFGG_FavBonus, MFFJEALABOG_TensionBonus);
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
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
			{
				DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo diva = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(AHHJLDLAPAN_DivaId);
				if(diva != null)
				{
					if(CIOECGOMILE.HHCJCDFCLOB != null)
					{
						if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy != null)
						{
							HBODCMLFDOB_Result.LDHOOPGDBJC_IsLevelUp = false;
							if(HEKJGCMNJAB_CurrentLevel < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.GLHEHGGKILG_GetMaxLevel())
							{
								if(CIOECGOMILE.HHCJCDFCLOB.IOCLFHJLHLE_IntimacyUpdater.IGFMNMADJPP(1, false))
								{
									diva.NFDPLBOIDAB_IntimacyTouchCount++;
									diva.NEAADNDKGLG_IntimacyTouchTotal++;
									HBODCMLFDOB_Result.LHPDDGIJKNB_Reset();
									HBODCMLFDOB_Result.ODHAIDDEFJL_GetExp = MIKFKJKDOBI_TouchPoint;
									HBODCMLFDOB_Result.NLFMNHGEADA = MIKFKJKDOBI_TouchPoint;
									HBODCMLFDOB_Result.HOMOKJEKKNK_Bonus = 0;
									bool res = MOACIBEKLEN(MIKFKJKDOBI_TouchPoint);
									KNKDBNFMAKF_EventSp sp = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as KNKDBNFMAKF_EventSp;
									if(sp != null)
									{
										sp.POHBAGJLOLI_IncDivaCount(OPOEENHEJOC.FNGFADPFKOD_0_DivaIntimacy);
									}
									ILCCJNDFFOB.HHCJCDFCLOB.DNNLEIKNHKL(AHHJLDLAPAN_DivaId, NHCCINMHEAB_Tension, HBODCMLFDOB_Result.ODHAIDDEFJL_GetExp, HBODCMLFDOB_Result.EOIJEGJDLAN_AfterExp, HBODCMLFDOB_Result.CPDEMMFGKED_Level, HBODCMLFDOB_Result.KBHJOBKOOGC_NextLevel, JpStringLiterals.StringLiteral_12005, 0, 0, 0, 0);
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
		return CIOECGOMILE.HHCJCDFCLOB.IOCLFHJLHLE_IntimacyUpdater.DCLKMNGMIKC_GetCurrentValue(false);
	}

	//// RVA: 0x1353C04 Offset: 0x1353C04 VA: 0x1353C04
	public long BPBIHCAMNBJ()
	{
		return CIOECGOMILE.HHCJCDFCLOB.IOCLFHJLHLE_IntimacyUpdater.CKEJFCLAOHP_GetRemainingTime();
	}

	//// RVA: 0x1353CC0 Offset: 0x1353CC0 VA: 0x1353CC0
	public bool NJAKNMGEKFB(JJOELIOGMKK_DivaIntimacyInfo.LPBGKOJDNJK _GBJFNGCDKPM_Type, int _KDCMPJNGLBL_SkillLevel)
	{
		for(int i = 0; i < LGPDCPDDECG.Count; i++)
		{
			if(LGPDCPDDECG[i].CIEOBFIIPLD_Level <= HEKJGCMNJAB_CurrentLevel)
			{
				if(LGPDCPDDECG[i].GBJFNGCDKPM_Type == _GBJFNGCDKPM_Type)
				{
					if(LGPDCPDDECG[i].KDCMPJNGLBL_SkillLevel == _KDCMPJNGLBL_SkillLevel)
						return true;
				}
			}
		}
		return false;
	}

	//// RVA: 0x1353E74 Offset: 0x1353E74 VA: 0x1353E74
	public bool DOMNLGKLGEH_SetMaxSkillLevel(BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData, LPBGKOJDNJK _GBJFNGCDKPM_Type, int _KDCMPJNGLBL_SkillLevel, bool _FBBNPFFEJBN_Force)
	{
		if(_GBJFNGCDKPM_Type == LPBGKOJDNJK.JFEKIMDCKIH_3 /*3*/)
		{
			if(!_FBBNPFFEJBN_Force)
			{
				if (_KDCMPJNGLBL_SkillLevel <= _LDEGEHAEALK_ServerData.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(AHHJLDLAPAN_DivaId).JLEPLIHFPKD_IntimacySkillLevel)
					return false;
			}
			_LDEGEHAEALK_ServerData.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(AHHJLDLAPAN_DivaId).JLEPLIHFPKD_IntimacySkillLevel = _KDCMPJNGLBL_SkillLevel;
			return true;
		}
		return false;
	}

	//// RVA: 0x1353F40 Offset: 0x1353F40 VA: 0x1353F40
	public bool COOGHGBNEMB(BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData, int _KIJAPOFAGPN_ItemId, int _HMFFHLPNMPH_Count, int _CIEOBFIIPLD_Level)
	{
		JKNGJFOBADP data = new JKNGJFOBADP();
		data.JCHLONCMPAJ();
		data.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.ACNGACBALGM/*20*/, AHHJLDLAPAN_DivaId.ToString() + ":" + 0); //?? unused r11 register instead of 0
		data.CPIICACGNBH_AddItem(_LDEGEHAEALK_ServerData, _KIJAPOFAGPN_ItemId, _HMFFHLPNMPH_Count, null, 0);
		return false;
	}

	//// RVA: 0x1354088 Offset: 0x1354088 VA: 0x1354088
	public bool AMHBDAMIAJM(BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData, int _KIJAPOFAGPN_ItemId, int _HMFFHLPNMPH_Count)
	{
		JKNGJFOBADP j = new JKNGJFOBADP();
		j.JCHLONCMPAJ();
		j.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.GHLEPCNBCNC/*19*/, "");
		j.CPIICACGNBH_AddItem(_LDEGEHAEALK_ServerData, _KIJAPOFAGPN_ItemId, _HMFFHLPNMPH_Count, null, 0);
		return false;
	}

	//// RVA: 0x1351904 Offset: 0x1351904 VA: 0x1351904
	public void HCDGELDHFHB(bool _FBBNPFFEJBN_Force/* = false*/)
	{
		if (AHHJLDLAPAN_DivaId < 0)
			return;
		DEKKMGAFJCG_Diva saveDiva = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva;
		GJALOMELEHD_Intimacy intimacyDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy;

		DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo divaInfo = saveDiva.LGKFMLIOPKL_GetDivaInfo(AHHJLDLAPAN_DivaId);
		int lvl = HBODCMLFDOB_Result.CPDEMMFGKED_Level < 1 ? 1 : HBODCMLFDOB_Result.CPDEMMFGKED_Level;
		GJALOMELEHD_Intimacy.MFMLEAMJJCH_LevelInfo info1 = intimacyDb.OOCKOCAACMD_DataByLevel[lvl - 1];
		int exp1 = info1.BDLNMOIOMHK_Total;

		HEKJGCMNJAB_CurrentLevel = divaInfo.KCCONFODCPN_IntimacyLevel;
		if (HEKJGCMNJAB_CurrentLevel < 1)
			HEKJGCMNJAB_CurrentLevel = 1;
		GJALOMELEHD_Intimacy.MFMLEAMJJCH_LevelInfo curLevelInfo = intimacyDb.OOCKOCAACMD_DataByLevel[HEKJGCMNJAB_CurrentLevel - 1];
		KPEAGFJHNDP_CurrentLevelExp = divaInfo.BNDNNCHJGBB_IntimacyExp - curLevelInfo.BDLNMOIOMHK_Total;

		int nextLevel = HEKJGCMNJAB_CurrentLevel;
		int maxLevel = intimacyDb.GLHEHGGKILG_GetMaxLevel();
		if (maxLevel < nextLevel + 1)
			nextLevel = 0;
		GJALOMELEHD_Intimacy.MFMLEAMJJCH_LevelInfo nextLevelInfo = intimacyDb.OOCKOCAACMD_DataByLevel[nextLevel];
		KOKCFJDMJLI = nextLevelInfo.IHGDLBBPKFI_Next;
		HBODCMLFDOB_Result.EDPNAEOKGNM = maxLevel <= lvl;
		HBODCMLFDOB_Result.PFIILLOIDIL = maxLevel <= HEKJGCMNJAB_CurrentLevel;
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
		HBODCMLFDOB_Result.BJHAMEJPGAJ_Exp -= exp1;
		HBODCMLFDOB_Result.EOIJEGJDLAN_AfterExp -= curLevelInfo.BDLNMOIOMHK_Total;
		HBODCMLFDOB_Result.CKDNPHLDIEM.Clear();
		HBODCMLFDOB_Result.EEIBCALKFFF.Clear();
		HBODCMLFDOB_Result.IELPCAEACLL.Clear();
		HBODCMLFDOB_Result.HBCBADBPNCJ.Clear();
		for(int i = HBODCMLFDOB_Result.CPDEMMFGKED_Level; i < HBODCMLFDOB_Result.KBHJOBKOOGC_NextLevel; i++)
		{
			GJALOMELEHD_Intimacy.MFMLEAMJJCH_LevelInfo levelInfo = intimacyDb.OOCKOCAACMD_DataByLevel[i];
			if (levelInfo.DMEDKJPOLCH_Category >= 1)
			{
				DOMNLGKLGEH_SetMaxSkillLevel(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, (LPBGKOJDNJK)levelInfo.DMEDKJPOLCH_Category, levelInfo.EIIDPKCBKEK_prm, _FBBNPFFEJBN_Force);
				HBODCMLFDOB_Result.CKDNPHLDIEM.Add((LPBGKOJDNJK)levelInfo.DMEDKJPOLCH_Category);
				int c = levelInfo.EIIDPKCBKEK_prm;
				if (levelInfo.DMEDKJPOLCH_Category == 3 && levelInfo.EIIDPKCBKEK_prm > 0)
				{
					if (levelInfo.EIIDPKCBKEK_prm < intimacyDb.COHLJLNLBKM.Count)
					{
						c = intimacyDb.COHLJLNLBKM[levelInfo.EIIDPKCBKEK_prm - 1].JBGEEPFKIGG_val / 100;
					}
				}
				HBODCMLFDOB_Result.EEIBCALKFFF.Add(c);
				int a = levelInfo.ECEKNKIDING(AHHJLDLAPAN_DivaId - 1);
				if (a > 0)
				{
					COOGHGBNEMB(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, a, 1, levelInfo.ANAJIAENLNB_Level);
				}
				HBODCMLFDOB_Result.IELPCAEACLL.Add(levelInfo.ECEKNKIDING(AHHJLDLAPAN_DivaId - 1));
				HBODCMLFDOB_Result.HBCBADBPNCJ.Add("");
			}
		}
		HBODCMLFDOB_Result.JHOBMMMEJHH_SkillLevel = divaInfo.JLEPLIHFPKD_IntimacySkillLevel;
		HBODCMLFDOB_Result.IGNABALECPK = HBODCMLFDOB_Result.JHOBMMMEJHH_SkillLevel < 1 ? 0 : intimacyDb.COHLJLNLBKM[HBODCMLFDOB_Result.JHOBMMMEJHH_SkillLevel - 1].JBGEEPFKIGG_val / 100;
		CIOECGOMILE.HHCJCDFCLOB.MJNHMCABCGH();
	}

	//// RVA: 0x135338C Offset: 0x135338C VA: 0x135338C
	public bool GACANKEBLEE(int _ADJBIEOILPJ_ItemPresentId)
	{
		if(_ADJBIEOILPJ_ItemPresentId > 0)
		{
			OJEGDIBEBHP o = new OJEGDIBEBHP();
			o.KHEKNNFCAOI_Init(_ADJBIEOILPJ_ItemPresentId);
			return o.MCLFHOABKGP(AHHJLDLAPAN_DivaId);
		}
		return false;
	}

	//// RVA: 0x1353460 Offset: 0x1353460 VA: 0x1353460
	public bool ANJLEBDBEGF(int _ADJBIEOILPJ_ItemPresentId)
	{
		if(_ADJBIEOILPJ_ItemPresentId > 0)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
			{
				if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva != null)
				{
					OJEGDIBEBHP o = new OJEGDIBEBHP();
					o.KHEKNNFCAOI_Init(_ADJBIEOILPJ_ItemPresentId);
					if(o.JONPKLHMOBL_Category != 0)
					{
						return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(AHHJLDLAPAN_DivaId).GCGCFGJCLEL_IntimacyTension == o.JONPKLHMOBL_Category;
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
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
			{
				if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.NJGEDPHNIKC_IsPresentLimitEnabled())
				{
					return CIOECGOMILE.HHCJCDFCLOB.PAAMLFNPJGJ_IntimacyDivaPresentLeft[AHHJLDLAPAN_DivaId - 1] > 0;
				}
				else
				{
					for(int i = 0; i < CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList.Count; i++)
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
	public bool MLEPCANKIIE(int _HMFFHLPNMPH_Count)
	{
		if(CIOECGOMILE.HHCJCDFCLOB != null)
		{
			return CIOECGOMILE.HHCJCDFCLOB.MLEPCANKIIE(AHHJLDLAPAN_DivaId, _HMFFHLPNMPH_Count);
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
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
			{
				return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("intimacy_player_level", 8) <= CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.KIECDDFNCAN_Level;
			}
		}
		return false;
	}

	//// RVA: 0x13548B4 Offset: 0x13548B4 VA: 0x13548B4
	public int JCFAPAOLDOI(int _CIEOBFIIPLD_Level)
	{
		if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database == null || _CIEOBFIIPLD_Level < 1 || IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy == null || _CIEOBFIIPLD_Level > IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.GLHEHGGKILG_GetMaxLevel())
			return 0;
		return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.OOCKOCAACMD_DataByLevel[_CIEOBFIIPLD_Level - 1].IHGDLBBPKFI_Next;
	}

	//// RVA: 0x13549E4 Offset: 0x13549E4 VA: 0x13549E4
	public bool KCJCJLNHMKI()
	{
		HBODCMLFDOB_Result.IOCFPAAEFHM_FullItemId = 0;
		HBODCMLFDOB_Result.LEAKFAFGEKK_Count = 0;
		HBODCMLFDOB_Result.CCJDPKBGJPH_Name = "";
		HBODCMLFDOB_Result.JLKIADFKPFL_Desc = "";
		if(DNJEMPANDNN() && OMAEOHMDCLI_FirstPresentId > 0)
		{
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
			{
				if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
				{
					GJALOMELEHD_Intimacy.ELAIMNHBCFB d = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.CJAEGOMDICD[OMAEOHMDCLI_FirstPresentId - 1];
					if(d.PLALNIIBLOF_en == 2)
					{
						DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo dinfo = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(AHHJLDLAPAN_DivaId);
						dinfo.DDODJCCIENF_IntimacyPresentTotal = 0;
						AMHBDAMIAJM(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, d.GLCLFMGPMAN_ItemId, 1);
						HBODCMLFDOB_Result.IOCFPAAEFHM_FullItemId = d.GLCLFMGPMAN_ItemId;
						HBODCMLFDOB_Result.LEAKFAFGEKK_Count = 1;
						HBODCMLFDOB_Result.CCJDPKBGJPH_Name = OJEGDIBEBHP.DDICENAFJDP_GetName(EKLNMHFCAOI.DEACAHNLMNI_getItemId(d.GLCLFMGPMAN_ItemId));
						HBODCMLFDOB_Result.JLKIADFKPFL_Desc = OJEGDIBEBHP.LJKBBAGJLFP_GetDesc(EKLNMHFCAOI.DEACAHNLMNI_getItemId(d.GLCLFMGPMAN_ItemId));
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
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
		{
			if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList.Count > 0)
			{
				int a = 0;
				for (int i = 0; i < CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList.Count; i++)
				{
					a |= (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva.MCIPCILAJIN(i + 1) - 1) ^ 1;
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
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
		{
			int res = 0;
			for(int i = 0; i < CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList.Count; i++)
			{
				res += CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva.KPJIMHGMAGN(i);
            }
			return res;
		}
		return 0;
	}
}
