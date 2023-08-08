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
			public LCLCCHLDNHJ_Costume.LKLGPLFNJBA INDDJNMPONH_Unlock; // 0x8
			public int[] PIBLLGLCJEO; // 0xC
		}

		public LCLCCHLDNHJ_Costume.FPDJGDGEBNG PEEAGFNOFFO_UnlockType; // 0x8
		public int[] KJNAHLOODKD_Value; // 0xC
		public LKICDEKECIH[] KBOLNIBLIND; // 0x10
		public int FBGGEFFJJHB; // 0x14
		public int AADPAJOLEEF; // 0x18
		public int DNLHENCICKD; // 0x1C
		public int GLOPONEBHFG_Unlock; // 0x20

		public int DNBFMLBNAEE { get { return AADPAJOLEEF ^ FBGGEFFJJHB; } set { AADPAJOLEEF = value ^ FBGGEFFJJHB; } } //0xD6A204 JKHIIAEMMDE 0xD68E94 PFFKLBLEPKB
		public int ACGLMKEBMDL { get { return DNLHENCICKD ^ FBGGEFFJJHB; } set { DNLHENCICKD = value ^ FBGGEFFJJHB; } } //0xD6A214 ALOLFIJOOHG 0xD68EA4 JDPCOMJIMHG
		public int DACOCNLBMAG { get { return GLOPONEBHFG_Unlock ^ FBGGEFFJJHB; } set { GLOPONEBHFG_Unlock = value ^ FBGGEFFJJHB; } } //0xD6A564 ALECNGGCBOO 0xD68EB4 GBHPKCNAIJA

		// RVA: 0xD68DFC Offset: 0xD68DFC VA: 0xD68DFC
		public FHLDDEKAJKI()
		{
			FBGGEFFJJHB = LPDNKHAIOLH.CEIBAFOCNCA();
			DNBFMLBNAEE = 0;
			ACGLMKEBMDL = 0;
			DACOCNLBMAG = 0;
		}
	}

	public enum EJOEMKJOCMH
	{
		CCAPCGPIIPF = 0,
		HHJFDNIPODD = 1,
		LLCLFAACPLH = 2,
	}

	public struct GFIPDFPIKIJ
	{
		public int GLCLFMGPMAN_ItemId; // 0x0
		public string AKNGHELNIHO_ItemName; // 0x4
		public string BONMCBFDMJE_ItemNum; // 0x8
		public string GKBNAKIDHPC; // 0xC
		public string IDCPALBPNFB_Explanation; // 0x10
		public int OHMGPDPKGLF; // 0x14

		public int NANNGLGOFKH_Value { get { return OHMGPDPKGLF ^ 0x130963; } set { OHMGPDPKGLF = value ^ 0x130963; } } //0x7FB358 EDFAHCMGHKM 0x7FB36C BKPDFNKGNHA
	}

	public List<FHLDDEKAJKI> OCOOHBINGBG; // 0x44
	public int GNOPCJKEIIN; // 0x48
	public int PNHBJJCBMOF; // 0x4C
	public int ADOCCJMAHDE; // 0x50
	public int NGCCBMIJHFF; // 0x54

	public int LLLCMHENKKN_LevelMax { get { return FBGGEFFJJHB ^ GNOPCJKEIIN; } set { GNOPCJKEIIN = value ^ FBGGEFFJJHB; } } // 0xD6833C NEBKEFLJPDI 0xD6834C AOCHKIMBJPE
	public int HGBJODBCJDA { get { return FBGGEFFJJHB ^ PNHBJJCBMOF; } set { PNHBJJCBMOF = value ^ FBGGEFFJJHB; } } // 0xD6835C EEEJDDFGNGP 0xD6836C IBPCBFIDHPH
	public int IBIJFBELLBH_Unlock { get { return FBGGEFFJJHB ^ ADOCCJMAHDE; } set { ADOCCJMAHDE = value ^ FBGGEFFJJHB; } } // 0xD6837C ONFKCLAPAEJ 0xD6838C KKMGKIDCCHE
	public int ABLHIAEDJAI_Point { get { return FBGGEFFJJHB ^ NGCCBMIJHFF; } set { NGCCBMIJHFF = value ^ FBGGEFFJJHB; } } // 0xD6839C HHANNDEOIAK 0xD683AC IFFMNEEHIOM

	// RVA: 0xD683BC Offset: 0xD683BC VA: 0xD683BC
	public LFAFJCNKLML()
	{
		LLLCMHENKKN_LevelMax = 0;
		HGBJODBCJDA = 0;
		IBIJFBELLBH_Unlock = 0;
		ABLHIAEDJAI_Point = 0;
	}

	//// RVA: 0xD683E4 Offset: 0xD683E4 VA: 0xD683E4
	public static List<LFAFJCNKLML> HEGEKFMJNCC(int AHHJLDLAPAN)
	{
		List<LFAFJCNKLML> res = new List<LFAFJCNKLML>(50);
		List<FFHPBEPOMAK_DivaInfo> l = FFHPBEPOMAK_DivaInfo.DNAIGDHCILM_GetCostumeList(AHHJLDLAPAN, false);
		for(int i = 0; i < l.Count; i++)
		{
			if(l[i].JLKPGDEKPEO_IsHave)
			{
				LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cosInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.LBDOLHGDIEB_GetUnlockedCostumeOrDefault(AHHJLDLAPAN, l[i].JPIDIENBGKH_CostumeId);
				if (cosInfo.LLLCMHENKKN_LevelMax > 0)
				{
					LFAFJCNKLML data = new LFAFJCNKLML();
					EBFLJMOCLNA_Costume.ILFJDCICIKN saveCostume = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.BEKHNNCGIEL_Costume.EEOADCECNOM_GetCostume(l[i].JPIDIENBGKH_CostumeId);
					data.KHEKNNFCAOI(AHHJLDLAPAN, l[i].JPIDIENBGKH_CostumeId, saveCostume.ANAJIAENLNB_Level, false);
					data.ABLHIAEDJAI_Point = saveCostume.DNBFMLBNAEE_Point;
					data.IBIJFBELLBH_Unlock = saveCostume.KBOLNIBLIND_Unlock;
					data.LLLCMHENKKN_LevelMax = cosInfo.LLLCMHENKKN_LevelMax;
					data.HGBJODBCJDA = cosInfo.HGBJODBCJDA;
					data.OCOOHBINGBG = new List<FHLDDEKAJKI>(cosInfo.BJGNGNPHCBA_LevelsInfo.Length);
					int[] i1 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.MBLNIECELNK[cosInfo.AGBPBDODKBK];
					int[] i2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.AKKDOIJNMBH[cosInfo.HMCOGDICFNB];
					for(int j = 0; j < cosInfo.BJGNGNPHCBA_LevelsInfo.Length; j++)
					{
						FHLDDEKAJKI data2 = new FHLDDEKAJKI();
						data2.PEEAGFNOFFO_UnlockType = (LCLCCHLDNHJ_Costume.FPDJGDGEBNG)cosInfo.BJGNGNPHCBA_LevelsInfo[j].INDDJNMPONH_UnlockType;
						data2.KJNAHLOODKD_Value = cosInfo.BJGNGNPHCBA_LevelsInfo[j].PIBLLGLCJEO_Value;
						data2.DNBFMLBNAEE = i1[j];
						data2.ACGLMKEBMDL = i2[j];
						data2.GLOPONEBHFG_Unlock = cosInfo.BJGNGNPHCBA_LevelsInfo[j].KBOLNIBLIND;
						if(cosInfo.BJGNGNPHCBA_LevelsInfo[j].KBOLNIBLIND != 0)
						{
							LCLCCHLDNHJ_Costume.JMEHNBGDEBD unlock = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.FDNBEPCEHBH[cosInfo.BJGNGNPHCBA_LevelsInfo[j].KBOLNIBLIND];
							List<FHLDDEKAJKI.LKICDEKECIH> lu = new List<FHLDDEKAJKI.LKICDEKECIH>(unlock.NKNBKLHCAFD.Length);
							for(int k = 0; k < unlock.NKNBKLHCAFD.Length; k++)
							{
								if(unlock.NKNBKLHCAFD[k].INDDJNMPONH > 0)
								{
									FHLDDEKAJKI.LKICDEKECIH data3 = new FHLDDEKAJKI.LKICDEKECIH();
									data3.INDDJNMPONH_Unlock = (LCLCCHLDNHJ_Costume.LKLGPLFNJBA)unlock.NKNBKLHCAFD[k].INDDJNMPONH;
									data3.PIBLLGLCJEO = unlock.NKNBKLHCAFD[k].PIBLLGLCJEO;
									lu.Add(data3);
								}
							}
							data2.KBOLNIBLIND = lu.ToArray();
						}
						data.OCOOHBINGBG.Add(data2);
					}
					data.FJODMPGPDDD_Possessed = true;
					res.Add(data);
				}
			}
		}
		return res;
	}

	//// RVA: 0xD68ECC Offset: 0xD68ECC VA: 0xD68ECC
	public static List<LFAFJCNKLML> FKDIMODKKJD(List<int> NBIGLBMHEDC)
	{
		List<LFAFJCNKLML> res = new List<LFAFJCNKLML>(500);
		for(int i = 0; i < GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas.Count; i++)
		{
			if(GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas[i].FJODMPGPDDD && GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas[i].IPJMPBANBPP)
			{
				res.AddRange(HEGEKFMJNCC(GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas[i].AHHJLDLAPAN_DivaId));
				if(NBIGLBMHEDC != null)
				{
					NBIGLBMHEDC.Add(GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas[i].AHHJLDLAPAN_DivaId);
				}
			}
		}
		return res;
	}

	//// RVA: 0xD690C8 Offset: 0xD690C8 VA: 0xD690C8
	public static void HKKKKFLBFJN(LFAFJCNKLML IDLHJIOMJBK, int FJOLNJLLJEJ, out GFIPDFPIKIJ NGHKJOEDLIP, EJOEMKJOCMH OJBOEMCJPHJ = 0)
	{
		MessageBank masterBk = MessageManager.Instance.GetBank("master");
		MessageBank menuBk = MessageManager.Instance.GetBank("menu");
		NGHKJOEDLIP = new GFIPDFPIKIJ();
		StringBuilder str = new StringBuilder(32);
		FHLDDEKAJKI data = IDLHJIOMJBK.OCOOHBINGBG[FJOLNJLLJEJ];
		str.SetFormat("cos_reward_{0:D4}", (int)data.PEEAGFNOFFO_UnlockType);
		string rewardStr = masterBk.GetMessageByLabel(str.ToString());
		StringBuilder str2 = new StringBuilder(32);
		switch (data.PEEAGFNOFFO_UnlockType)
		{
			case LCLCCHLDNHJ_Costume.FPDJGDGEBNG.NKKIKONDGPF/*1*/:
				NGHKJOEDLIP.NANNGLGOFKH_Value = data.KJNAHLOODKD_Value[1];
				string s = "";
				string s2 = "";
				IDLHJIOMJBK.OHGOPFEOJOG_GetSkillInfo(FJOLNJLLJEJ + 1, ref s, ref s2);
				string t = "";
				string t2 = "";
				IDLHJIOMJBK.OHGOPFEOJOG_GetSkillInfo(FJOLNJLLJEJ, ref t, ref t2);
				string[] s2_ = Regex.Split(s2, "[0-9][0-9]|[0-9]");
				if (OJBOEMCJPHJ == EJOEMKJOCMH.HHJFDNIPODD/*1*/)
				{
					NGHKJOEDLIP.AKNGHELNIHO_ItemName = s2;
					NGHKJOEDLIP.BONMCBFDMJE_ItemNum = t2;
					NGHKJOEDLIP.IDCPALBPNFB_Explanation = "";
				}
				else
				{
					if (s2_.Length < 2)
					{
						NGHKJOEDLIP.AKNGHELNIHO_ItemName = rewardStr + JpStringLiterals.StringLiteral_12297;
						NGHKJOEDLIP.BONMCBFDMJE_ItemNum = s2;
						NGHKJOEDLIP.IDCPALBPNFB_Explanation = "";
					}
					else
					{
						if (t == TextConstant.InvalidText)
						{
							NGHKJOEDLIP.AKNGHELNIHO_ItemName = rewardStr + JpStringLiterals.StringLiteral_12298;
							NGHKJOEDLIP.BONMCBFDMJE_ItemNum = s2_[0] + "\n" + s.Substring(s2_[0].Length);
							str2.SetFormat(menuBk.GetMessageByLabel("costume_upgrade_item_detail_costume_skillup"), s2);
							NGHKJOEDLIP.IDCPALBPNFB_Explanation = str2.ToString();
						}
						else
						{
							NGHKJOEDLIP.AKNGHELNIHO_ItemName = rewardStr + JpStringLiterals.StringLiteral_12300;
							NGHKJOEDLIP.BONMCBFDMJE_ItemNum = "";
							str2.SetFormat(menuBk.GetMessageByLabel("costume_upgrade_item_detail_costume_skillget"), s2);
							NGHKJOEDLIP.IDCPALBPNFB_Explanation = str2.ToString();
						}
					}
				}
				NGHKJOEDLIP.GLCLFMGPMAN_ItemId = 50000;
				break;
			case LCLCCHLDNHJ_Costume.FPDJGDGEBNG.DDGNLCJGFJF/*2*/:
			case LCLCCHLDNHJ_Costume.FPDJGDGEBNG.AJKDOLDGHOP/*3*/:
				NGHKJOEDLIP.GLCLFMGPMAN_ItemId = data.KJNAHLOODKD_Value[0];
				NGHKJOEDLIP.NANNGLGOFKH_Value = data.KJNAHLOODKD_Value[1];
				NGHKJOEDLIP.AKNGHELNIHO_ItemName = EKLNMHFCAOI.INCKKODFJAP_GetItemName(NGHKJOEDLIP.GLCLFMGPMAN_ItemId);
				NGHKJOEDLIP.BONMCBFDMJE_ItemNum = NGHKJOEDLIP.NANNGLGOFKH_Value.ToString() + EKLNMHFCAOI.NDBLEADIDLA(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(NGHKJOEDLIP.GLCLFMGPMAN_ItemId), NGHKJOEDLIP.NANNGLGOFKH_Value);
				NGHKJOEDLIP.IDCPALBPNFB_Explanation = EKLNMHFCAOI.ILKGBGOCLAO(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(NGHKJOEDLIP.GLCLFMGPMAN_ItemId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(NGHKJOEDLIP.GLCLFMGPMAN_ItemId));
				break;
			case LCLCCHLDNHJ_Costume.FPDJGDGEBNG.CFOEMAAKOMC/*4*/:
				NGHKJOEDLIP.GLCLFMGPMAN_ItemId = 50000;
				NGHKJOEDLIP.NANNGLGOFKH_Value = data.KJNAHLOODKD_Value[1];
				if(OJBOEMCJPHJ == EJOEMKJOCMH.HHJFDNIPODD/*1*/)
				{
					NGHKJOEDLIP.AKNGHELNIHO_ItemName = "";
					NGHKJOEDLIP.BONMCBFDMJE_ItemNum = IDLHJIOMJBK.HCPCHEPCFEA_GetCostumeName(1);
					NGHKJOEDLIP.IDCPALBPNFB_Explanation = "";
				}
				else
				{
					NGHKJOEDLIP.AKNGHELNIHO_ItemName = rewardStr;
					NGHKJOEDLIP.BONMCBFDMJE_ItemNum = "";
					str2.SetFormat(menuBk.GetMessageByLabel("costume_upgrade_item_detail_costume_color"), IDLHJIOMJBK.HCPCHEPCFEA_GetCostumeName(1), IDLHJIOMJBK.HCPCHEPCFEA_GetCostumeName(0));
					NGHKJOEDLIP.IDCPALBPNFB_Explanation = str2.ToString();
					if(OJBOEMCJPHJ == 0)
					{
						NGHKJOEDLIP.AKNGHELNIHO_ItemName = NGHKJOEDLIP.AKNGHELNIHO_ItemName + "\n" + IDLHJIOMJBK.HCPCHEPCFEA_GetCostumeName(1);
					}
				}
				break;
			case LCLCCHLDNHJ_Costume.FPDJGDGEBNG.PJJJGFBLIAP/*5*/:
				str.SetFormat("cos_reward_status_{0:D4}", data.KJNAHLOODKD_Value[0]);
				NGHKJOEDLIP.GLCLFMGPMAN_ItemId = 10001;
				NGHKJOEDLIP.NANNGLGOFKH_Value = data.KJNAHLOODKD_Value[1];
				NGHKJOEDLIP.BONMCBFDMJE_ItemNum = "+" + data.KJNAHLOODKD_Value[1].ToString();
				str2.SetFormat(menuBk.GetMessageByLabel("costume_upgrade_item_detail_diva_status_up"), masterBk.GetMessageByLabel("diva_s_" + IDLHJIOMJBK.AHHJLDLAPAN_DivaId.ToString("D2")), masterBk.GetMessageByLabel(str.ToString()), NGHKJOEDLIP.BONMCBFDMJE_ItemNum);
				NGHKJOEDLIP.IDCPALBPNFB_Explanation = str2.ToString();
				if(OJBOEMCJPHJ == EJOEMKJOCMH.LLCLFAACPLH/*2*/)
				{
					NGHKJOEDLIP.AKNGHELNIHO_ItemName = menuBk.GetMessageByLabel("costume_upgrade_item_detail_diva_status_up_title");
				}
				else
				{
					if(OJBOEMCJPHJ != EJOEMKJOCMH.HHJFDNIPODD/*1*/)
					{
						if (OJBOEMCJPHJ != EJOEMKJOCMH.CCAPCGPIIPF/*0*/)
							return;
						NGHKJOEDLIP.AKNGHELNIHO_ItemName = rewardStr;
						NGHKJOEDLIP.BONMCBFDMJE_ItemNum = masterBk.GetMessageByLabel(str.ToString()) + "\n" + NGHKJOEDLIP.BONMCBFDMJE_ItemNum;
					}
					else
					{
						NGHKJOEDLIP.AKNGHELNIHO_ItemName = masterBk.GetMessageByLabel(str.ToString());
					}
				}
				break;
			case LCLCCHLDNHJ_Costume.FPDJGDGEBNG.JDPFMDOMMJE/*6*/:
				NGHKJOEDLIP.GLCLFMGPMAN_ItemId = 10001;
				NGHKJOEDLIP.AKNGHELNIHO_ItemName = rewardStr;
				NGHKJOEDLIP.NANNGLGOFKH_Value = data.KJNAHLOODKD_Value[1];
				str.SetFormat("cos_subplate_attr_{0:D4}", data.KJNAHLOODKD_Value[0]);
				str2.SetFormat("cos_subplate_status_{0:D4}", NGHKJOEDLIP.NANNGLGOFKH_Value);
				NGHKJOEDLIP.BONMCBFDMJE_ItemNum = masterBk.GetMessageByLabel(str.ToString()) + "\n" + masterBk.GetMessageByLabel(str2.ToString());
				str2.SetFormat(menuBk.GetMessageByLabel("costume_upgrade_item_detail_sub_plate"), masterBk.GetMessageByLabel(str.ToString()) + " " + masterBk.GetMessageByLabel(str2.ToString()), 2);
				NGHKJOEDLIP.IDCPALBPNFB_Explanation = str2.ToString();
				if (OJBOEMCJPHJ == EJOEMKJOCMH.HHJFDNIPODD/*1*/)
					NGHKJOEDLIP.AKNGHELNIHO_ItemName = "";
				break;
		}
	}

	//// RVA: 0xD6A0C0 Offset: 0xD6A0C0 VA: 0xD6A0C0
	public FHLDDEKAJKI JHLKLPEHHCD()
	{
		if(GKIKAABHAAD_Level < OCOOHBINGBG.Count)
		{
			return OCOOHBINGBG[GKIKAABHAAD_Level];
		}
		return null;
	}

	//// RVA: 0xD6A19C Offset: 0xD6A19C VA: 0xD6A19C
	//public int KPJJLJLJDIA(int DNBFMLBNAEE) { }

	//// RVA: 0xD6A224 Offset: 0xD6A224 VA: 0xD6A224
	public bool CDOCOLOKCJK(int ANAJIAENLNB)
	{
		if (ANAJIAENLNB <= IBIJFBELLBH_Unlock)
			return true;
		return OCOOHBINGBG[ANAJIAENLNB].KBOLNIBLIND == null;
	}

	//// RVA: 0xD6A2E0 Offset: 0xD6A2E0 VA: 0xD6A2E0
	public bool CDOCOLOKCJK()
	{
		return CDOCOLOKCJK(GKIKAABHAAD_Level);
	}

	//// RVA: 0xD6A304 Offset: 0xD6A304 VA: 0xD6A304
	//public string HNCKIMOGCAH(int GHDGALFNGFJ) { }

	//// RVA: 0xD6A3D8 Offset: 0xD6A3D8 VA: 0xD6A3D8
	//public void AHLONCCGGHP() { }
}
