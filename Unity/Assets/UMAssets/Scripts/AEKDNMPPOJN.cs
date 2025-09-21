
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;
using XeSys;

public class AEKDNMPPOJN
{
	public LimitOverStatusData CMCKNKKCNDK_Status = new LimitOverStatusData(); // 0x8
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
	public int MJNOAMAFNHA_CostItemId; // 0x38
	public bool EOBACDCDGOF_IsTerminate; // 0x3C
	public bool JMHIDPKHELB; // 0x3D
	public int DBKCPIPNKEP; // 0x40
	public bool PPIFEOJOEMO; // 0x44
	public List<LimitOverTypeId.Type> CJLNHKNLBGH; // 0x48
	public List<string> ONABNIGCGJK_AddLeafEffect; // 0x4C
	public int EKLIPGELKCL_Rarity; // 0x50

	// RVA: 0x15BB8C8 Offset: 0x15BB8C8 VA: 0x15BB8C8
	public void KHEKNNFCAOI_Init(int _JKGFBFPIMGA_Rarity, int _DMNIMMGGJJJ_Leaf, int _MJBODMOLOBC_luck)
	{
		EKLIPGELKCL_Rarity = _JKGFBFPIMGA_Rarity;
		DJEHLEJCPEL_LeafNum = _DMNIMMGGJJJ_Leaf;
		LJHOOPJACPI_LeafMax = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.JNLLKKHJCAD(_JKGFBFPIMGA_Rarity, _MJBODMOLOBC_luck);
		if(_JKGFBFPIMGA_Rarity < 4)
		{
			if(LJHOOPJACPI_LeafMax != 0)
			{
				Debug.LogError(JpStringLiterals.StringLiteral_8676);
			}
			LJHOOPJACPI_LeafMax = 0;
		}
		else
		{
			int a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.ELFPIODODFF(_JKGFBFPIMGA_Rarity);
			if (a <= LJHOOPJACPI_LeafMax)
				LJHOOPJACPI_LeafMax = a;
			IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.MNHPPJFNPCG(ref CMCKNKKCNDK_Status, _JKGFBFPIMGA_Rarity, _MJBODMOLOBC_luck, _DMNIMMGGJJJ_Leaf);
			OBMGLMLCGJC_ExcellentRate = CMCKNKKCNDK_Status.excellentRate;
			NJGBLBNALKM_ExcellentEffect = CMCKNKKCNDK_Status.excellentEffect;
			LAAPJKFEFHK_CenterLiveSkillRate = CMCKNKKCNDK_Status.centerLiveSkillRate;
			if(_DMNIMMGGJJJ_Leaf == a)
			{
				IJEOIMGILCK = 0;
				GNKGDDMMJPF = 0;
				MJNOAMAFNHA_CostItemId = 0;
				EOBACDCDGOF_IsTerminate = true;
				JMHIDPKHELB = false;
			}
			else
			{
				int found = -1;
				for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.PIPHIPNEJCM.Count; i++)
				{
					LLKLAKGKNLD_LimitOver.ENKHACHPPFA item = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.PIPHIPNEJCM[i];
					if (item.EKLIPGELKCL_Rarity == _JKGFBFPIMGA_Rarity && item.GNFJOONKCFH == _DMNIMMGGJJJ_Leaf + 1)
					{
						found = i;
						break;
					}
				}
				{
					LLKLAKGKNLD_LimitOver.ENKHACHPPFA item = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.PIPHIPNEJCM[found];
					MJNOAMAFNHA_CostItemId = item.GLCLFMGPMAN_ItemId;
					IJEOIMGILCK = item.ADPPAIPFHML_Num;
					GNKGDDMMJPF = item.ACGLMKEBMDL_Uc;
					EOBACDCDGOF_IsTerminate = false;
					JMHIDPKHELB = false;
					JMHIDPKHELB = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.JNLLKKHJCAD(_JKGFBFPIMGA_Rarity, _MJBODMOLOBC_luck) < DJEHLEJCPEL_LeafNum + 1;
					int c = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.BKCAECPCELG();
					if (c > -1)
					{
						for(int i = 0; i < c; i++)
						{
							if(DJEHLEJCPEL_LeafNum + 1 <= IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.JNLLKKHJCAD(_JKGFBFPIMGA_Rarity, i))
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
		ABKCMICDHLN_LeafEffectExcellentRate = MHLLBIGMHFM_GetExcellentRateEffect(CMCKNKKCNDK_Status);
		JFNHGLGIEMF = JpStringLiterals.StringLiteral_8686;
		ACKDDGKFNIJ_LeafEffectCenterSkillRate = KHMBJLKFNPH_GetCenterSkillRateEffect(CMCKNKKCNDK_Status);
		EDNMJHBMDBK();
		IBKNFJLAGIH_UnlockCond = string.Format(MessageManager.Instance.GetMessage("menu", JMHIDPKHELB ? "limit_over_unlock_02" : "limit_over_unlock_01"), DBKCPIPNKEP);
	}

	// RVA: 0x15BC7A0 Offset: 0x15BC7A0 VA: 0x15BC7A0
	public void EDNMJHBMDBK()
	{
		CJLNHKNLBGH = new List<LimitOverTypeId.Type>();
		ONABNIGCGJK_AddLeafEffect = new List<string>();
		if(!EOBACDCDGOF_IsTerminate)
		{
			LLKLAKGKNLD_LimitOver.PBMKLFCEAAA dbLimit = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.GPPJBOCJOFI[DJEHLEJCPEL_LeafNum];
			LLKLAKGKNLD_LimitOver.PBMKLFCEAAA dbLimitNext = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.GPPJBOCJOFI[DJEHLEJCPEL_LeafNum + 1];
			for (int i = 0; i < 6; i++)
			{
				if (dbLimit.DEACAHNLMNI(i) == 0 && dbLimitNext.DEACAHNLMNI(i) == 1)
				{
					CJLNHKNLBGH.Add((LimitOverTypeId.Type)(i + 1));
					LLKLAKGKNLD_LimitOver.PBMKLFCEAAA dbLimit2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.BODDKCKFLJF[EKLIPGELKCL_Rarity - 1];
					ONABNIGCGJK_AddLeafEffect.Add(JLJOPOFHAPJ((LimitOverTypeId.Type)i + 1, dbLimit2.DEACAHNLMNI(i)));
				}
			}
		}
	}

	// RVA: 0x15BCB24 Offset: 0x15BCB24 VA: 0x15BCB24
	private string JLJOPOFHAPJ(LimitOverTypeId.Type _PPFNGGCBJKC_id, int _JBGEEPFKIGG_val)
	{
		string res = JpStringLiterals.StringLiteral_8686;
		switch(_PPFNGGCBJKC_id)
		{
			case LimitOverTypeId.Type.ExcellentRate:
				return string.Format(MessageManager.Instance.GetMessage("menu", "limit_over_excellent_rate_01"), _JBGEEPFKIGG_val);
			case LimitOverTypeId.Type.CenterLiveSkillRate:
				return string.Format(MessageManager.Instance.GetMessage("menu", "limit_over_center_live_skill_01"), _JBGEEPFKIGG_val);
			case LimitOverTypeId.Type.ExcellentRate_SameMusicAttr:
				return string.Format(MessageManager.Instance.GetMessage("menu", "limit_over_excellent_rate_04"), _JBGEEPFKIGG_val);
			case LimitOverTypeId.Type.CenterLiveSkillRate_SameMusicAttr:
				return string.Format(MessageManager.Instance.GetMessage("menu", "limit_over_center_live_skill_04"), _JBGEEPFKIGG_val);
			case LimitOverTypeId.Type.ExcellentRate_SameSeriesAttr:
				return string.Format(MessageManager.Instance.GetMessage("menu", "limit_over_excellent_rate_05"), _JBGEEPFKIGG_val);
			case LimitOverTypeId.Type.CenterLiveSkillRate_SameSeriesAttr:
				return string.Format(MessageManager.Instance.GetMessage("menu", "limit_over_center_live_skill_05"), _JBGEEPFKIGG_val);
			default:
				break;
		}
		return res;
	}

	// RVA: 0x15BBFDC Offset: 0x15BBFDC VA: 0x15BBFDC
	public static string MHLLBIGMHFM_GetExcellentRateEffect(LimitOverStatusData _CMCKNKKCNDK_Status)
	{
		if (_CMCKNKKCNDK_Status.excellentRate == 0)
			return JpStringLiterals.StringLiteral_8686;
		if(_CMCKNKKCNDK_Status.excellentRate_SameSeriesAttr < 1 && _CMCKNKKCNDK_Status.excellentEffect_SameMusicAttr < 1)
		{
			return string.Format(MessageManager.Instance.GetMessage("menu", "limit_over_excellent_rate_01").Replace("{ma}", _CMCKNKKCNDK_Status.excellentEffect_SameMusicAttr.ToString()).Replace("{sa}", _CMCKNKKCNDK_Status.excellentRate_SameSeriesAttr.ToString()), _CMCKNKKCNDK_Status.excellentRate);
		}
		else if(_CMCKNKKCNDK_Status.excellentEffect_SameMusicAttr > 0)
		{
			return string.Format(MessageManager.Instance.GetMessage("menu", "limit_over_excellent_rate_03").Replace("{ma}", _CMCKNKKCNDK_Status.excellentEffect_SameMusicAttr.ToString()).Replace("{sa}", _CMCKNKKCNDK_Status.excellentRate_SameSeriesAttr.ToString()), _CMCKNKKCNDK_Status.excellentRate);
		}
		else
		{
			return string.Format(MessageManager.Instance.GetMessage("menu", "limit_over_excellent_rate_02").Replace("{ma}", _CMCKNKKCNDK_Status.excellentEffect_SameMusicAttr.ToString()).Replace("{sa}", _CMCKNKKCNDK_Status.excellentRate_SameSeriesAttr.ToString()), _CMCKNKKCNDK_Status.excellentRate);
		}
	}

	// RVA: 0x15BC390 Offset: 0x15BC390 VA: 0x15BC390
	//public static string INONJIHPOJM(LimitOverStatusData _CMCKNKKCNDK_Status) { }

	// RVA: 0x15BC3EC Offset: 0x15BC3EC VA: 0x15BC3EC
	public static string KHMBJLKFNPH_GetCenterSkillRateEffect(LimitOverStatusData _CMCKNKKCNDK_Status)
	{
		if (_CMCKNKKCNDK_Status.centerLiveSkillRate == 0)
			return JpStringLiterals.StringLiteral_8686;
		if (_CMCKNKKCNDK_Status.centerLiveSkillRate_SameMusicAttr < 1 && _CMCKNKKCNDK_Status.centerLiveSkillRate_SameSeriesAttr < 1)
		{
			return string.Format(MessageManager.Instance.GetMessage("menu", "limit_over_center_live_skill_01").Replace("{ma}", _CMCKNKKCNDK_Status.centerLiveSkillRate_SameMusicAttr.ToString()).Replace("{sa}", _CMCKNKKCNDK_Status.centerLiveSkillRate_SameSeriesAttr.ToString()), _CMCKNKKCNDK_Status.centerLiveSkillRate);
		}
		else if (_CMCKNKKCNDK_Status.centerLiveSkillRate_SameSeriesAttr > 0)
		{
			return string.Format(MessageManager.Instance.GetMessage("menu", "limit_over_center_live_skill_03").Replace("{ma}", _CMCKNKKCNDK_Status.centerLiveSkillRate_SameMusicAttr.ToString()).Replace("{sa}", _CMCKNKKCNDK_Status.centerLiveSkillRate_SameSeriesAttr.ToString()), _CMCKNKKCNDK_Status.centerLiveSkillRate);
		}
		else
		{
			return string.Format(MessageManager.Instance.GetMessage("menu", "limit_over_center_live_skill_02").Replace("{ma}", _CMCKNKKCNDK_Status.centerLiveSkillRate_SameMusicAttr.ToString()).Replace("{sa}", _CMCKNKKCNDK_Status.centerLiveSkillRate_SameSeriesAttr.ToString()), _CMCKNKKCNDK_Status.centerLiveSkillRate);
		}
	}

	// RVA: 0x15BCE50 Offset: 0x15BCE50 VA: 0x15BCE50
	//public void NMIPOICAIEA(int _CIEOBFIIPLD_Level, int _MJBODMOLOBC_luck) { }

	// RVA: 0x15BD0B8 Offset: 0x15BD0B8 VA: 0x15BD0B8
	public static int AHKFPJJKHFL(int _BCCHOBPJJKE_SceneId, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		MMPBPOIFDAF_Scene.PMKOFEIONEG IBDJFHFIIHN = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PNLOINMCCKH_Scene.OPIBAPEGCLA_Scenes[_BCCHOBPJJKE_SceneId - 1];
		if(IBDJFHFIIHN.OFNNNEMCJNN())
		{
			_AOCANKOMKFG_OnError();
			return -100;
		}
		else
		{
			MLIBEPGADJH_Scene.KKLDOOJBJMN MABBBOEAPAA_p = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_table[_BCCHOBPJJKE_SceneId - 1];
			int mltMax = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.GENHLFPKOEE(MABBBOEAPAA_p.EKLIPGELKCL_Rarity, MABBBOEAPAA_p.MCCIFLKCNKO_Feed);
			int MJBODMOLOBC_luck = MABBBOEAPAA_p.AGOEDLNOHND(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board, IBDJFHFIIHN.EMOJHJGHJLN_Sb, IBDJFHFIIHN.JPIPENJGGDD_NumBoard, mltMax);
			AEKDNMPPOJN PLOEDFHCGFA = new AEKDNMPPOJN();
			PLOEDFHCGFA.KHEKNNFCAOI_Init(MABBBOEAPAA_p.EKLIPGELKCL_Rarity, IBDJFHFIIHN.DMNIMMGGJJJ_Leaf, MJBODMOLOBC_luck);
			if(!PLOEDFHCGFA.EOBACDCDGOF_IsTerminate)
			{
				if(!PLOEDFHCGFA.JMHIDPKHELB)
				{
					if(MJBODMOLOBC_luck < PLOEDFHCGFA.DBKCPIPNKEP)
					{
						Debug.LogError("StringLiteral_8694" + PLOEDFHCGFA.DBKCPIPNKEP + "StringLiteral_8695");
						_AOCANKOMKFG_OnError();
						return PLOEDFHCGFA.DBKCPIPNKEP;
					}
					else
					{
						if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(PLOEDFHCGFA.MJNOAMAFNHA_CostItemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.HLCHKCJLEGK_GrowItem)
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
								ILCCJNDFFOB.HHCJCDFCLOB.EEOLHMGNJGO(_BCCHOBPJJKE_SceneId, MABBBOEAPAA_p.EKLIPGELKCL_Rarity, MJBODMOLOBC_luck, PLOEDFHCGFA.MJNOAMAFNHA_CostItemId, PLOEDFHCGFA.IJEOIMGILCK, PLOEDFHCGFA.GNKGDDMMJPF, ICPDDMIBEIL, IBDJFHFIIHN.DMNIMMGGJJJ_Leaf);
								_BHFHGFKBOHH_OnSuccess();
							}, _AOCANKOMKFG_OnError, null);
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
					_AOCANKOMKFG_OnError();
					return -3;
				}
			}
			else
			{
				Debug.LogError("StringLiteral_8693");
				_AOCANKOMKFG_OnError();
				return -1;
			}
		}
	}

	// RVA: 0x15BDA5C Offset: 0x15BDA5C VA: 0x15BDA5C
	//public static void LCHJNEOAMGJ(FFHPBEPOMAK_DivaInfo JCFNFJJKPAM, DFKGGBMFFGB_PlayerInfo DJLNOAMJECI, ref int OBMGLMLCGJC, ref int NJGBLBNALKM, ref int HONONDFIICC) { }
}
