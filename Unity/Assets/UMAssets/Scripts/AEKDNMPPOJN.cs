
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;
using XeSys;

public class AEKDNMPPOJN
{
	public LimitOverStatusData CMCKNKKCNDK = new LimitOverStatusData(); // 0x8
	public int OBMGLMLCGJC_ExcellentRate; // 0xC
	public int NJGBLBNALKM_ExcellentEffect; // 0x10
	public int LAAPJKFEFHK_CenterLiveSkillRate; // 0x14
	public string ABKCMICDHLN_LeafEffectExcellentRate; // 0x18
	public string JFNHGLGIEMF; // 0x1C
	public string ACKDDGKFNIJ_LeafEffectCenterSkillRate; // 0x20
	public string IBKNFJLAGIH_UnlockCond; // 0x24
	public int DJEHLEJCPEL_LeafNum; // 0x28
	public int LJHOOPJACPI_LeafMax; // 0x2C
	public int IJEOIMGILCK; // 0x30
	public int GNKGDDMMJPF; // 0x34
	public int MJNOAMAFNHA; // 0x38
	public bool EOBACDCDGOF; // 0x3C
	public bool JMHIDPKHELB; // 0x3D
	public int DBKCPIPNKEP; // 0x40
	public bool PPIFEOJOEMO; // 0x44
	public List<LimitOverTypeId.Type> CJLNHKNLBGH; // 0x48
	public List<string> ONABNIGCGJK_AddLeafEffect; // 0x4C
	public int EKLIPGELKCL; // 0x50

	// RVA: 0x15BB8C8 Offset: 0x15BB8C8 VA: 0x15BB8C8
	public void KHEKNNFCAOI(int JKGFBFPIMGA, int DMNIMMGGJJJ, int MJBODMOLOBC)
	{
		EKLIPGELKCL = JKGFBFPIMGA;
		DJEHLEJCPEL_LeafNum = DMNIMMGGJJJ;
		LJHOOPJACPI_LeafMax = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.JNLLKKHJCAD(JKGFBFPIMGA, MJBODMOLOBC);
		if(JKGFBFPIMGA < 4)
		{
			if(LJHOOPJACPI_LeafMax != 0)
			{
				Debug.LogError(JpStringLiterals.StringLiteral_8676);
			}
			LJHOOPJACPI_LeafMax = 0;
		}
		else
		{
			int a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.ELFPIODODFF(JKGFBFPIMGA);
			if (a <= LJHOOPJACPI_LeafMax)
				LJHOOPJACPI_LeafMax = a;
			IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.MNHPPJFNPCG(ref CMCKNKKCNDK, JKGFBFPIMGA, MJBODMOLOBC, DMNIMMGGJJJ);
			OBMGLMLCGJC_ExcellentRate = CMCKNKKCNDK.excellentRate;
			NJGBLBNALKM_ExcellentEffect = CMCKNKKCNDK.excellentEffect;
			LAAPJKFEFHK_CenterLiveSkillRate = CMCKNKKCNDK.centerLiveSkillRate;
			if(DMNIMMGGJJJ == a)
			{
				IJEOIMGILCK = 0;
				GNKGDDMMJPF = 0;
				MJNOAMAFNHA = 0;
				EOBACDCDGOF = true;
				JMHIDPKHELB = false;
			}
			else
			{
				int found = -1;
				for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.PIPHIPNEJCM.Count; i++)
				{
					LLKLAKGKNLD_LimitOver.ENKHACHPPFA item = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.PIPHIPNEJCM[i];
					if (item.EKLIPGELKCL == JKGFBFPIMGA && item.GNFJOONKCFH == DMNIMMGGJJJ + 1)
					{
						found = i;
						break;
					}
				}
				{
					LLKLAKGKNLD_LimitOver.ENKHACHPPFA item = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.PIPHIPNEJCM[found];
					MJNOAMAFNHA = item.GLCLFMGPMAN;
					IJEOIMGILCK = item.ADPPAIPFHML;
					GNKGDDMMJPF = item.ACGLMKEBMDL;
					EOBACDCDGOF = false;
					JMHIDPKHELB = false;
					JMHIDPKHELB = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.JNLLKKHJCAD(JKGFBFPIMGA, MJBODMOLOBC) < DJEHLEJCPEL_LeafNum + 1;
					int c = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.BKCAECPCELG();
					if (c > -1)
					{
						for(int i = 0; i < c; i++)
						{
							if(DJEHLEJCPEL_LeafNum + 1 <= IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.JNLLKKHJCAD(JKGFBFPIMGA, i))
							{
								DBKCPIPNKEP = i;
								break;
							}
						}
					}
				}
				PPIFEOJOEMO = true;
			}
		}
	}

	// RVA: 0x15BBE70 Offset: 0x15BBE70 VA: 0x15BBE70
	public void OPBFFEMJBFH()
	{
		ABKCMICDHLN_LeafEffectExcellentRate = MHLLBIGMHFM_GetExcellentRateEffect(CMCKNKKCNDK);
		JFNHGLGIEMF = JpStringLiterals.StringLiteral_8686;
		ACKDDGKFNIJ_LeafEffectCenterSkillRate = KHMBJLKFNPH_GetCenterSkillRateEffect(CMCKNKKCNDK);
		EDNMJHBMDBK();
		IBKNFJLAGIH_UnlockCond = string.Format(MessageManager.Instance.GetMessage("menu", JMHIDPKHELB ? "limit_over_unlock_02" : "limit_over_unlock_01"), DBKCPIPNKEP);
	}

	// RVA: 0x15BC7A0 Offset: 0x15BC7A0 VA: 0x15BC7A0
	public void EDNMJHBMDBK()
	{
		CJLNHKNLBGH = new List<LimitOverTypeId.Type>();
		ONABNIGCGJK_AddLeafEffect = new List<string>();
		if(!EOBACDCDGOF)
		{
			LLKLAKGKNLD_LimitOver.PBMKLFCEAAA dbLimit = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.GPPJBOCJOFI[DJEHLEJCPEL_LeafNum];
			LLKLAKGKNLD_LimitOver.PBMKLFCEAAA dbLimitNext = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.GPPJBOCJOFI[DJEHLEJCPEL_LeafNum + 1];
			for (int i = 0; i < 6; i++)
			{
				if (dbLimit.DEACAHNLMNI(i) == 0 && dbLimitNext.DEACAHNLMNI(i) == 1)
				{
					CJLNHKNLBGH.Add((LimitOverTypeId.Type)(i + 1));
					LLKLAKGKNLD_LimitOver.PBMKLFCEAAA dbLimit2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.BODDKCKFLJF[EKLIPGELKCL - 1];
					ONABNIGCGJK_AddLeafEffect.Add(JLJOPOFHAPJ((LimitOverTypeId.Type)i + 1, dbLimit2.DEACAHNLMNI(i)));
				}
			}
		}
	}

	// RVA: 0x15BCB24 Offset: 0x15BCB24 VA: 0x15BCB24
	private string JLJOPOFHAPJ(LimitOverTypeId.Type PPFNGGCBJKC, int JBGEEPFKIGG)
	{
		string res = JpStringLiterals.StringLiteral_8686;
		switch(PPFNGGCBJKC)
		{
			case LimitOverTypeId.Type.ExcellentRate:
				return string.Format(MessageManager.Instance.GetMessage("menu", "limit_over_excellent_rate_01"), JBGEEPFKIGG);
			case LimitOverTypeId.Type.CenterLiveSkillRate:
				return string.Format(MessageManager.Instance.GetMessage("menu", "limit_over_center_live_skill_01"), JBGEEPFKIGG);
			case LimitOverTypeId.Type.ExcellentRate_SameMusicAttr:
				return string.Format(MessageManager.Instance.GetMessage("menu", "limit_over_excellent_rate_04"), JBGEEPFKIGG);
			case LimitOverTypeId.Type.CenterLiveSkillRate_SameMusicAttr:
				return string.Format(MessageManager.Instance.GetMessage("menu", "limit_over_center_live_skill_04"), JBGEEPFKIGG);
			case LimitOverTypeId.Type.ExcellentRate_SameSeriesAttr:
				return string.Format(MessageManager.Instance.GetMessage("menu", "limit_over_excellent_rate_05"), JBGEEPFKIGG);
			case LimitOverTypeId.Type.CenterLiveSkillRate_SameSeriesAttr:
				return string.Format(MessageManager.Instance.GetMessage("menu", "limit_over_center_live_skill_05"), JBGEEPFKIGG);
			default:
				break;
		}
		return res;
	}

	// RVA: 0x15BBFDC Offset: 0x15BBFDC VA: 0x15BBFDC
	public static string MHLLBIGMHFM_GetExcellentRateEffect(LimitOverStatusData CMCKNKKCNDK)
	{
		if (CMCKNKKCNDK.excellentRate == 0)
			return JpStringLiterals.StringLiteral_8686;
		if(CMCKNKKCNDK.excellentRate_SameSeriesAttr < 1 && CMCKNKKCNDK.excellentEffect_SameMusicAttr < 1)
		{
			return string.Format(MessageManager.Instance.GetMessage("menu", "limit_over_excellent_rate_01").Replace("{ma}", CMCKNKKCNDK.excellentEffect_SameMusicAttr.ToString()).Replace("{sa}", CMCKNKKCNDK.excellentRate_SameSeriesAttr.ToString()), CMCKNKKCNDK.excellentRate);
		}
		else if(CMCKNKKCNDK.excellentEffect_SameMusicAttr > 0)
		{
			return string.Format(MessageManager.Instance.GetMessage("menu", "limit_over_excellent_rate_03").Replace("{ma}", CMCKNKKCNDK.excellentEffect_SameMusicAttr.ToString()).Replace("{sa}", CMCKNKKCNDK.excellentRate_SameSeriesAttr.ToString()), CMCKNKKCNDK.excellentRate);
		}
		else
		{
			return string.Format(MessageManager.Instance.GetMessage("menu", "limit_over_excellent_rate_02").Replace("{ma}", CMCKNKKCNDK.excellentEffect_SameMusicAttr.ToString()).Replace("{sa}", CMCKNKKCNDK.excellentRate_SameSeriesAttr.ToString()), CMCKNKKCNDK.excellentRate);
		}
	}

	// RVA: 0x15BC390 Offset: 0x15BC390 VA: 0x15BC390
	//public static string INONJIHPOJM(LimitOverStatusData CMCKNKKCNDK) { }

	// RVA: 0x15BC3EC Offset: 0x15BC3EC VA: 0x15BC3EC
	public static string KHMBJLKFNPH_GetCenterSkillRateEffect(LimitOverStatusData CMCKNKKCNDK)
	{
		if (CMCKNKKCNDK.centerLiveSkillRate == 0)
			return JpStringLiterals.StringLiteral_8686;
		if (CMCKNKKCNDK.centerLiveSkillRate_SameMusicAttr < 1 && CMCKNKKCNDK.centerLiveSkillRate_SameSeriesAttr < 1)
		{
			return string.Format(MessageManager.Instance.GetMessage("menu", "limit_over_center_live_skill_01").Replace("{ma}", CMCKNKKCNDK.centerLiveSkillRate_SameMusicAttr.ToString()).Replace("{sa}", CMCKNKKCNDK.centerLiveSkillRate_SameSeriesAttr.ToString()), CMCKNKKCNDK.centerLiveSkillRate);
		}
		else if (CMCKNKKCNDK.centerLiveSkillRate_SameSeriesAttr > 0)
		{
			return string.Format(MessageManager.Instance.GetMessage("menu", "limit_over_center_live_skill_03").Replace("{ma}", CMCKNKKCNDK.centerLiveSkillRate_SameMusicAttr.ToString()).Replace("{sa}", CMCKNKKCNDK.centerLiveSkillRate_SameSeriesAttr.ToString()), CMCKNKKCNDK.centerLiveSkillRate);
		}
		else
		{
			return string.Format(MessageManager.Instance.GetMessage("menu", "limit_over_center_live_skill_02").Replace("{ma}", CMCKNKKCNDK.centerLiveSkillRate_SameMusicAttr.ToString()).Replace("{sa}", CMCKNKKCNDK.centerLiveSkillRate_SameSeriesAttr.ToString()), CMCKNKKCNDK.centerLiveSkillRate);
		}
	}

	// RVA: 0x15BCE50 Offset: 0x15BCE50 VA: 0x15BCE50
	//public void NMIPOICAIEA(int CIEOBFIIPLD, int MJBODMOLOBC) { }

	// RVA: 0x15BD0B8 Offset: 0x15BD0B8 VA: 0x15BD0B8
	public static int AHKFPJJKHFL(int BCCHOBPJJKE, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
	{
		MMPBPOIFDAF_Scene.PMKOFEIONEG IBDJFHFIIHN = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA[BCCHOBPJJKE - 1];
		if(IBDJFHFIIHN.OFNNNEMCJNN())
		{
			AOCANKOMKFG();
			return -100;
		}
		else
		{
			MLIBEPGADJH_Scene.KKLDOOJBJMN MABBBOEAPAA = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[BCCHOBPJJKE - 1];
			int mltMax = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.GENHLFPKOEE(MABBBOEAPAA.EKLIPGELKCL_Rarity, MABBBOEAPAA.MCCIFLKCNKO_Feed);
			int MJBODMOLOBC = MABBBOEAPAA.AGOEDLNOHND(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board, IBDJFHFIIHN.EMOJHJGHJLN_Sb, IBDJFHFIIHN.JPIPENJGGDD_Mlt, mltMax);
			AEKDNMPPOJN PLOEDFHCGFA = new AEKDNMPPOJN();
			PLOEDFHCGFA.KHEKNNFCAOI(MABBBOEAPAA.EKLIPGELKCL_Rarity, IBDJFHFIIHN.DMNIMMGGJJJ_Leaf, MJBODMOLOBC);
			if(!PLOEDFHCGFA.EOBACDCDGOF)
			{
				if(!PLOEDFHCGFA.JMHIDPKHELB)
				{
					if(MJBODMOLOBC < PLOEDFHCGFA.DBKCPIPNKEP)
					{
						Debug.LogError("StringLiteral_8694" + PLOEDFHCGFA.DBKCPIPNKEP + "StringLiteral_8695");
						AOCANKOMKFG();
						return PLOEDFHCGFA.DBKCPIPNKEP;
					}
					else
					{
						if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(PLOEDFHCGFA.MJNOAMAFNHA) == EKLNMHFCAOI.FKGCBLHOOCL_Category.HLCHKCJLEGK_GrowItem)
						{
							int ICPDDMIBEIL = IBDJFHFIIHN.DMNIMMGGJJJ_Leaf;
							IBDJFHFIIHN.DMNIMMGGJJJ_Leaf++;
							if(IBDJFHFIIHN.DMNIMMGGJJJ_Leaf < 0)
								IBDJFHFIIHN.DMNIMMGGJJJ_Leaf = 0;
							if(IBDJFHFIIHN.DMNIMMGGJJJ_Leaf > 5)
								IBDJFHFIIHN.DMNIMMGGJJJ_Leaf = 5;
							CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
							{
								//0x15BE164
								ILCCJNDFFOB.HHCJCDFCLOB.EEOLHMGNJGO(BCCHOBPJJKE, MABBBOEAPAA.EKLIPGELKCL_Rarity, MJBODMOLOBC, PLOEDFHCGFA.MJNOAMAFNHA, PLOEDFHCGFA.IJEOIMGILCK, PLOEDFHCGFA.GNKGDDMMJPF, ICPDDMIBEIL, IBDJFHFIIHN.DMNIMMGGJJJ_Leaf);
								BHFHGFKBOHH();
							}, AOCANKOMKFG, null);
							return 0;
						}
						else
						{
							Debug.LogError("StringLiteral_8697");
							return -2;
						}
					}
				}
				else
				{
					Debug.LogError("StringLiteral_8696");
					AOCANKOMKFG();
					return -3;
				}
			}
			else
			{
				Debug.LogError("StringLiteral_8693");
				AOCANKOMKFG();
				return -1;
			}
		}
	}

	// RVA: 0x15BDA5C Offset: 0x15BDA5C VA: 0x15BDA5C
	//public static void LCHJNEOAMGJ(FFHPBEPOMAK JCFNFJJKPAM, DFKGGBMFFGB DJLNOAMJECI, ref int OBMGLMLCGJC, ref int NJGBLBNALKM, ref int HONONDFIICC) { }
}
