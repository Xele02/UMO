using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using XeApp.Game;
using XeApp.Game.Common;
using XeSys;

public class LFAFJCNKLML : CKFGMNAIBNG
{	
	public class FHLDDEKAJKI
	{
		public class LKICDEKECIH
		{
			public LCLCCHLDNHJ_Costume.LKLGPLFNJBA_UnlockCondition INDDJNMPONH_type; // 0x8
			public int[] PIBLLGLCJEO_Param; // 0xC UnlockValue
		}

		public LCLCCHLDNHJ_Costume.FPDJGDGEBNG_UnlockType PEEAGFNOFFO_UnlockType; // 0x8
		public int[] KJNAHLOODKD_Value; // 0xC
		public LKICDEKECIH[] KBOLNIBLIND_unlock; // 0x10
		public int FBGGEFFJJHB_xor; // 0x14
		public int AADPAJOLEEF_PointCrypted; // 0x18
		public int DNLHENCICKD_UcCrypted; // 0x1C
		public int GLOPONEBHFG_Crypted; // 0x20

		public int DNBFMLBNAEE_Point { get { return AADPAJOLEEF_PointCrypted ^ FBGGEFFJJHB_xor; } set { AADPAJOLEEF_PointCrypted = value ^ FBGGEFFJJHB_xor; } } //0xD6A204 JKHIIAEMMDE 0xD68E94 PFFKLBLEPKB
		public int ACGLMKEBMDL_Uc { get { return DNLHENCICKD_UcCrypted ^ FBGGEFFJJHB_xor; } set { DNLHENCICKD_UcCrypted = value ^ FBGGEFFJJHB_xor; } } //0xD6A214 ALOLFIJOOHG 0xD68EA4 JDPCOMJIMHG
		public int DACOCNLBMAG_UnlockCondIdx { get { return GLOPONEBHFG_Crypted ^ FBGGEFFJJHB_xor; } set { GLOPONEBHFG_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xD6A564 ALECNGGCBOO 0xD68EB4 GBHPKCNAIJA

		// RVA: 0xD68DFC Offset: 0xD68DFC VA: 0xD68DFC
		public FHLDDEKAJKI()
		{
			FBGGEFFJJHB_xor = LPDNKHAIOLH.CEIBAFOCNCA();
			DNBFMLBNAEE_Point = 0;
			ACGLMKEBMDL_Uc = 0;
			DACOCNLBMAG_UnlockCondIdx = 0;
		}
	}

	public enum EJOEMKJOCMH
	{
		CCAPCGPIIPF = 0,
		HHJFDNIPODD_1 = 1,
		LLCLFAACPLH = 2,
	}

	public struct GFIPDFPIKIJ
	{
		public int GLCLFMGPMAN_ItemId; // 0x0
		public string AKNGHELNIHO_ItemName; // 0x4
		public string BONMCBFDMJE_ItemNum; // 0x8
		public string GKBNAKIDHPC; // 0xC
		public string IDCPALBPNFB_Explanation; // 0x10
		public int OHMGPDPKGLF_ValueCrypted; // 0x14

		public int NANNGLGOFKH_value { get { return OHMGPDPKGLF_ValueCrypted ^ 0x130963; } set { OHMGPDPKGLF_ValueCrypted = value ^ 0x130963; } } //0x7FB358 EDFAHCMGHKM 0x7FB36C BKPDFNKGNHA
	}

	public List<FHLDDEKAJKI> OCOOHBINGBG_LevelInfo; // 0x44
	public int GNOPCJKEIIN_LevelMaxCrypted; // 0x48
	public int PNHBJJCBMOF; // 0x4C
	public int ADOCCJMAHDE; // 0x50
	public int NGCCBMIJHFF; // 0x54

	public int LLLCMHENKKN_LevelMax { get { return FBGGEFFJJHB_xor ^ GNOPCJKEIIN_LevelMaxCrypted; } set { GNOPCJKEIIN_LevelMaxCrypted = value ^ FBGGEFFJJHB_xor; } } // 0xD6833C NEBKEFLJPDI 0xD6834C AOCHKIMBJPE
	public int HGBJODBCJDA { get { return FBGGEFFJJHB_xor ^ PNHBJJCBMOF; } set { PNHBJJCBMOF = value ^ FBGGEFFJJHB_xor; } } // 0xD6835C EEEJDDFGNGP 0xD6836C IBPCBFIDHPH
	public int IBIJFBELLBH_Unlock { get { return FBGGEFFJJHB_xor ^ ADOCCJMAHDE; } set { ADOCCJMAHDE = value ^ FBGGEFFJJHB_xor; } } // 0xD6837C ONFKCLAPAEJ 0xD6838C KKMGKIDCCHE
	public int ABLHIAEDJAI_CurrentValue { get { return FBGGEFFJJHB_xor ^ NGCCBMIJHFF; } set { NGCCBMIJHFF = value ^ FBGGEFFJJHB_xor; } } // 0xD6839C HHANNDEOIAK 0xD683AC IFFMNEEHIOM

	// RVA: 0xD683BC Offset: 0xD683BC VA: 0xD683BC
	public LFAFJCNKLML()
	{
		LLLCMHENKKN_LevelMax = 0;
		HGBJODBCJDA = 0;
		IBIJFBELLBH_Unlock = 0;
		ABLHIAEDJAI_CurrentValue = 0;
	}

	//// RVA: 0xD683E4 Offset: 0xD683E4 VA: 0xD683E4
	public static List<LFAFJCNKLML> HEGEKFMJNCC(int _AHHJLDLAPAN_DivaId)
	{
		List<LFAFJCNKLML> res = new List<LFAFJCNKLML>(50);
		List<FFHPBEPOMAK_DivaInfo> l = FFHPBEPOMAK_DivaInfo.DNAIGDHCILM_GetCostumeList(_AHHJLDLAPAN_DivaId, false);
		for(int i = 0; i < l.Count; i++)
		{
			if(l[i].JLKPGDEKPEO_IsHave)
			{
				LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cosInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.LBDOLHGDIEB_GetUnlockedCostumeOrDefault(_AHHJLDLAPAN_DivaId, l[i].JPIDIENBGKH_CostumeId);
				if (cosInfo.LLLCMHENKKN_LevelMax > 0)
				{
					LFAFJCNKLML data = new LFAFJCNKLML();
					EBFLJMOCLNA_Costume.ILFJDCICIKN saveCostume = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.BEKHNNCGIEL_Costume.EEOADCECNOM_GetCostume(l[i].JPIDIENBGKH_CostumeId);
					data.KHEKNNFCAOI_Init(_AHHJLDLAPAN_DivaId, l[i].JPIDIENBGKH_CostumeId, saveCostume.ANAJIAENLNB_Level, false);
					data.ABLHIAEDJAI_CurrentValue = saveCostume.DNBFMLBNAEE_Point;
					data.IBIJFBELLBH_Unlock = saveCostume.KBOLNIBLIND_unlock;
					data.LLLCMHENKKN_LevelMax = cosInfo.LLLCMHENKKN_LevelMax;
					data.HGBJODBCJDA = cosInfo.HGBJODBCJDA;
					data.OCOOHBINGBG_LevelInfo = new List<FHLDDEKAJKI>(cosInfo.BJGNGNPHCBA_LevelsInfo.Length);
					int[] i1 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.MBLNIECELNK_UnlockPoints[cosInfo.AGBPBDODKBK_UnlockPointIdx];
					int[] i2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.AKKDOIJNMBH_UcCostByPoint[cosInfo.HMCOGDICFNB_UcCostByPointIdx];
					for(int j = 0; j < cosInfo.BJGNGNPHCBA_LevelsInfo.Length; j++)
					{
						FHLDDEKAJKI data2 = new FHLDDEKAJKI();
						data2.PEEAGFNOFFO_UnlockType = (LCLCCHLDNHJ_Costume.FPDJGDGEBNG_UnlockType)cosInfo.BJGNGNPHCBA_LevelsInfo[j].INDDJNMPONH_type;
						data2.KJNAHLOODKD_Value = cosInfo.BJGNGNPHCBA_LevelsInfo[j].PIBLLGLCJEO_Param;
						data2.DNBFMLBNAEE_Point = i1[j];
						data2.ACGLMKEBMDL_Uc = i2[j];
						data2.DACOCNLBMAG_UnlockCondIdx = cosInfo.BJGNGNPHCBA_LevelsInfo[j].KBOLNIBLIND_unlock;
						if(cosInfo.BJGNGNPHCBA_LevelsInfo[j].KBOLNIBLIND_unlock != 0)
						{
							LCLCCHLDNHJ_Costume.JMEHNBGDEBD unlock = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.FDNBEPCEHBH_UnlocksConditions[cosInfo.BJGNGNPHCBA_LevelsInfo[j].KBOLNIBLIND_unlock];
							List<FHLDDEKAJKI.LKICDEKECIH> lu = new List<FHLDDEKAJKI.LKICDEKECIH>(unlock.NKNBKLHCAFD_UnlocksConditions.Length);
							for(int k = 0; k < unlock.NKNBKLHCAFD_UnlocksConditions.Length; k++)
							{
								if(unlock.NKNBKLHCAFD_UnlocksConditions[k].INDDJNMPONH_type > 0)
								{
									FHLDDEKAJKI.LKICDEKECIH data3 = new FHLDDEKAJKI.LKICDEKECIH();
									data3.INDDJNMPONH_type = (LCLCCHLDNHJ_Costume.LKLGPLFNJBA_UnlockCondition)unlock.NKNBKLHCAFD_UnlocksConditions[k].INDDJNMPONH_type;
									data3.PIBLLGLCJEO_Param = unlock.NKNBKLHCAFD_UnlocksConditions[k].PIBLLGLCJEO_Param;
									lu.Add(data3);
								}
							}
							data2.KBOLNIBLIND_unlock = lu.ToArray();
						}
						data.OCOOHBINGBG_LevelInfo.Add(data2);
					}
					data.FJODMPGPDDD_Unlocked = true;
					res.Add(data);
				}
			}
		}
		return res;
	}

	//// RVA: 0xD68ECC Offset: 0xD68ECC VA: 0xD68ECC
	public static List<LFAFJCNKLML> FKDIMODKKJD(List<int> _NBIGLBMHEDC_DivaList)
	{
		List<LFAFJCNKLML> res = new List<LFAFJCNKLML>(500);
		for(int i = 0; i < GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_DivaList.Count; i++)
		{
			if(GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_DivaList[i].FJODMPGPDDD_Unlocked && GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_DivaList[i].IPJMPBANBPP_Enabled)
			{
				res.AddRange(HEGEKFMJNCC(GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_DivaList[i].AHHJLDLAPAN_DivaId));
				if(_NBIGLBMHEDC_DivaList != null)
				{
					_NBIGLBMHEDC_DivaList.Add(GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_DivaList[i].AHHJLDLAPAN_DivaId);
				}
			}
		}
		return res;
	}

	//// RVA: 0xD690C8 Offset: 0xD690C8 VA: 0xD690C8
	public static void HKKKKFLBFJN(LFAFJCNKLML _IDLHJIOMJBK_Data, int _FJOLNJLLJEJ_Rank, out GFIPDFPIKIJ _NGHKJOEDLIP_Settings, EJOEMKJOCMH OJBOEMCJPHJ/* = 0*/)
	{
		MessageBank masterBk = MessageManager.Instance.GetBank("master");
		MessageBank menuBk = MessageManager.Instance.GetBank("menu");
		_NGHKJOEDLIP_Settings = new GFIPDFPIKIJ();
		StringBuilder str = new StringBuilder(32);
		FHLDDEKAJKI data = _IDLHJIOMJBK_Data.OCOOHBINGBG_LevelInfo[_FJOLNJLLJEJ_Rank];
		str.SetFormat("cos_reward_{0:D4}", (int)data.PEEAGFNOFFO_UnlockType);
		string rewardStr = masterBk.GetMessageByLabel(str.ToString());
		StringBuilder str2 = new StringBuilder(32);
		switch (data.PEEAGFNOFFO_UnlockType)
		{
			case LCLCCHLDNHJ_Costume.FPDJGDGEBNG_UnlockType.NKKIKONDGPF_1_CostumeEffect/*1*/:
				_NGHKJOEDLIP_Settings.NANNGLGOFKH_value = data.KJNAHLOODKD_Value[1];
				string s = "";
				string s2 = "";
				_IDLHJIOMJBK_Data.OHGOPFEOJOG_GetSkillInfo(_FJOLNJLLJEJ_Rank + 1, ref s, ref s2);
				string t = "";
				string t2 = "";
				_IDLHJIOMJBK_Data.OHGOPFEOJOG_GetSkillInfo(_FJOLNJLLJEJ_Rank, ref t, ref t2);
				string[] s2_ = Regex.Split(s2, "[0-9][0-9]|[0-9]");
				if (OJBOEMCJPHJ == EJOEMKJOCMH.HHJFDNIPODD_1/*1*/)
				{
					_NGHKJOEDLIP_Settings.AKNGHELNIHO_ItemName = s2;
					_NGHKJOEDLIP_Settings.BONMCBFDMJE_ItemNum = "";
					_NGHKJOEDLIP_Settings.IDCPALBPNFB_Explanation = "";
				}
				else
				{
					if (s2_.Length < 2)
					{
						_NGHKJOEDLIP_Settings.AKNGHELNIHO_ItemName = rewardStr + JpStringLiterals.StringLiteral_12297;
						_NGHKJOEDLIP_Settings.BONMCBFDMJE_ItemNum = s2;
						_NGHKJOEDLIP_Settings.IDCPALBPNFB_Explanation = "";
					}
					else
					{
						if (t == TextConstant.InvalidText)
						{
							_NGHKJOEDLIP_Settings.AKNGHELNIHO_ItemName = rewardStr + JpStringLiterals.StringLiteral_12298;
							_NGHKJOEDLIP_Settings.BONMCBFDMJE_ItemNum = s2_[0] + "\n" + s.Substring(s2_[0].Length);
							str2.SetFormat(menuBk.GetMessageByLabel("costume_upgrade_item_detail_costume_skillup"), s2);
							_NGHKJOEDLIP_Settings.IDCPALBPNFB_Explanation = str2.ToString();
						}
						else
						{
							_NGHKJOEDLIP_Settings.AKNGHELNIHO_ItemName = rewardStr + JpStringLiterals.StringLiteral_12300;
							_NGHKJOEDLIP_Settings.BONMCBFDMJE_ItemNum = "";
							str2.SetFormat(menuBk.GetMessageByLabel("costume_upgrade_item_detail_costume_skillget"), s2);
							_NGHKJOEDLIP_Settings.IDCPALBPNFB_Explanation = str2.ToString();
						}
					}
				}
				_NGHKJOEDLIP_Settings.GLCLFMGPMAN_ItemId = 50000;
				break;
			case LCLCCHLDNHJ_Costume.FPDJGDGEBNG_UnlockType.DDGNLCJGFJF_Object/*2*/:
			case LCLCCHLDNHJ_Costume.FPDJGDGEBNG_UnlockType.AJKDOLDGHOP_Object2/*3*/:
				_NGHKJOEDLIP_Settings.GLCLFMGPMAN_ItemId = data.KJNAHLOODKD_Value[0];
				_NGHKJOEDLIP_Settings.NANNGLGOFKH_value = data.KJNAHLOODKD_Value[1];
				_NGHKJOEDLIP_Settings.AKNGHELNIHO_ItemName = EKLNMHFCAOI.INCKKODFJAP_GetItemName(_NGHKJOEDLIP_Settings.GLCLFMGPMAN_ItemId);
				_NGHKJOEDLIP_Settings.BONMCBFDMJE_ItemNum = _NGHKJOEDLIP_Settings.NANNGLGOFKH_value.ToString() + EKLNMHFCAOI.NDBLEADIDLA(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(_NGHKJOEDLIP_Settings.GLCLFMGPMAN_ItemId), _NGHKJOEDLIP_Settings.NANNGLGOFKH_value);
				_NGHKJOEDLIP_Settings.IDCPALBPNFB_Explanation = EKLNMHFCAOI.ILKGBGOCLAO_GetItemDesc(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(_NGHKJOEDLIP_Settings.GLCLFMGPMAN_ItemId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(_NGHKJOEDLIP_Settings.GLCLFMGPMAN_ItemId));
				break;
			case LCLCCHLDNHJ_Costume.FPDJGDGEBNG_UnlockType.CFOEMAAKOMC_4_CostumeColor/*4*/:
				_NGHKJOEDLIP_Settings.GLCLFMGPMAN_ItemId = 50000;
				_NGHKJOEDLIP_Settings.NANNGLGOFKH_value = data.KJNAHLOODKD_Value[1];
				if(OJBOEMCJPHJ == EJOEMKJOCMH.HHJFDNIPODD_1/*1*/)
				{
					_NGHKJOEDLIP_Settings.AKNGHELNIHO_ItemName = "";
					_NGHKJOEDLIP_Settings.BONMCBFDMJE_ItemNum = _IDLHJIOMJBK_Data.HCPCHEPCFEA_GetCostumeName(1);
					_NGHKJOEDLIP_Settings.IDCPALBPNFB_Explanation = "";
				}
				else
				{
					_NGHKJOEDLIP_Settings.AKNGHELNIHO_ItemName = rewardStr;
					_NGHKJOEDLIP_Settings.BONMCBFDMJE_ItemNum = "";
					str2.SetFormat(menuBk.GetMessageByLabel("costume_upgrade_item_detail_costume_color"), _IDLHJIOMJBK_Data.HCPCHEPCFEA_GetCostumeName(1), _IDLHJIOMJBK_Data.HCPCHEPCFEA_GetCostumeName(0));
					_NGHKJOEDLIP_Settings.IDCPALBPNFB_Explanation = str2.ToString();
					if(OJBOEMCJPHJ == 0)
					{
						_NGHKJOEDLIP_Settings.AKNGHELNIHO_ItemName = _NGHKJOEDLIP_Settings.AKNGHELNIHO_ItemName + "\n" + _IDLHJIOMJBK_Data.HCPCHEPCFEA_GetCostumeName(1);
					}
				}
				break;
			case LCLCCHLDNHJ_Costume.FPDJGDGEBNG_UnlockType.PJJJGFBLIAP_5_Stat/*5*/:
				str.SetFormat("cos_reward_status_{0:D4}", data.KJNAHLOODKD_Value[0]);
				_NGHKJOEDLIP_Settings.GLCLFMGPMAN_ItemId = 10001;
				_NGHKJOEDLIP_Settings.NANNGLGOFKH_value = data.KJNAHLOODKD_Value[1];
				_NGHKJOEDLIP_Settings.BONMCBFDMJE_ItemNum = "+" + data.KJNAHLOODKD_Value[1].ToString();
				str2.SetFormat(menuBk.GetMessageByLabel("costume_upgrade_item_detail_diva_status_up"), masterBk.GetMessageByLabel("diva_s_" + _IDLHJIOMJBK_Data.AHHJLDLAPAN_DivaId.ToString("D2")), masterBk.GetMessageByLabel(str.ToString()), _NGHKJOEDLIP_Settings.BONMCBFDMJE_ItemNum);
				_NGHKJOEDLIP_Settings.IDCPALBPNFB_Explanation = str2.ToString();
				if(OJBOEMCJPHJ == EJOEMKJOCMH.LLCLFAACPLH/*2*/)
				{
					_NGHKJOEDLIP_Settings.AKNGHELNIHO_ItemName = menuBk.GetMessageByLabel("costume_upgrade_item_detail_diva_status_up_title");
				}
				else
				{
					if(OJBOEMCJPHJ != EJOEMKJOCMH.HHJFDNIPODD_1/*1*/)
					{
						if (OJBOEMCJPHJ != EJOEMKJOCMH.CCAPCGPIIPF/*0*/)
							return;
						_NGHKJOEDLIP_Settings.AKNGHELNIHO_ItemName = rewardStr;
						_NGHKJOEDLIP_Settings.BONMCBFDMJE_ItemNum = masterBk.GetMessageByLabel(str.ToString()) + "\n" + _NGHKJOEDLIP_Settings.BONMCBFDMJE_ItemNum;
					}
					else
					{
						_NGHKJOEDLIP_Settings.AKNGHELNIHO_ItemName = masterBk.GetMessageByLabel(str.ToString());
					}
				}
				break;
			case LCLCCHLDNHJ_Costume.FPDJGDGEBNG_UnlockType.JDPFMDOMMJE_6_Support/*6*/:
				_NGHKJOEDLIP_Settings.GLCLFMGPMAN_ItemId = 10001;
				_NGHKJOEDLIP_Settings.AKNGHELNIHO_ItemName = rewardStr;
				_NGHKJOEDLIP_Settings.NANNGLGOFKH_value = data.KJNAHLOODKD_Value[1];
				str.SetFormat("cos_subplate_attr_{0:D4}", data.KJNAHLOODKD_Value[0]);
				str2.SetFormat("cos_subplate_status_{0:D4}", _NGHKJOEDLIP_Settings.NANNGLGOFKH_value);
				_NGHKJOEDLIP_Settings.BONMCBFDMJE_ItemNum = masterBk.GetMessageByLabel(str.ToString()) + "\n" + masterBk.GetMessageByLabel(str2.ToString());
				str2.SetFormat(menuBk.GetMessageByLabel("costume_upgrade_item_detail_sub_plate"), masterBk.GetMessageByLabel(str.ToString()) + " " + masterBk.GetMessageByLabel(str2.ToString()), 2);
				_NGHKJOEDLIP_Settings.IDCPALBPNFB_Explanation = str2.ToString();
				if (OJBOEMCJPHJ == EJOEMKJOCMH.HHJFDNIPODD_1/*1*/)
					_NGHKJOEDLIP_Settings.AKNGHELNIHO_ItemName = "";
				break;
		}
	}

	//// RVA: 0xD6A0C0 Offset: 0xD6A0C0 VA: 0xD6A0C0
	public FHLDDEKAJKI JHLKLPEHHCD_GetCurrentLevelInfo()
	{
		if(GKIKAABHAAD_Level < OCOOHBINGBG_LevelInfo.Count)
		{
			return OCOOHBINGBG_LevelInfo[GKIKAABHAAD_Level];
		}
		return null;
	}

	//// RVA: 0xD6A19C Offset: 0xD6A19C VA: 0xD6A19C
	public int KPJJLJLJDIA_GetUcCost(int _DNBFMLBNAEE_Point)
	{
		FHLDDEKAJKI data = JHLKLPEHHCD_GetCurrentLevelInfo();
		if(data.DNBFMLBNAEE_Point < ABLHIAEDJAI_CurrentValue + _DNBFMLBNAEE_Point)
		{
			_DNBFMLBNAEE_Point = data.DNBFMLBNAEE_Point - ABLHIAEDJAI_CurrentValue;
		}
		return data.ACGLMKEBMDL_Uc * _DNBFMLBNAEE_Point;
	}

	//// RVA: 0xD6A224 Offset: 0xD6A224 VA: 0xD6A224
	public bool CDOCOLOKCJK(int _ANAJIAENLNB_Level)
	{
		if (_ANAJIAENLNB_Level <= IBIJFBELLBH_Unlock)
			return true;
		return OCOOHBINGBG_LevelInfo[_ANAJIAENLNB_Level].KBOLNIBLIND_unlock == null;
	}

	//// RVA: 0xD6A2E0 Offset: 0xD6A2E0 VA: 0xD6A2E0
	public bool CDOCOLOKCJK()
	{
		return CDOCOLOKCJK(GKIKAABHAAD_Level);
	}

	//// RVA: 0xD6A304 Offset: 0xD6A304 VA: 0xD6A304
	//public string HNCKIMOGCAH(int GHDGALFNGFJ) { }

	//// RVA: 0xD6A3D8 Offset: 0xD6A3D8 VA: 0xD6A3D8
	public void AHLONCCGGHP()
	{
		EBFLJMOCLNA_Costume.ILFJDCICIKN cos = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.BEKHNNCGIEL_Costume.EEOADCECNOM_GetCostume(JPIDIENBGKH_CostumeId);
		GKIKAABHAAD_Level = cos.ANAJIAENLNB_Level;
		ABLHIAEDJAI_CurrentValue = cos.DNBFMLBNAEE_Point;
		IBIJFBELLBH_Unlock = cos.KBOLNIBLIND_unlock;
	}
}
