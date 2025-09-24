
using System.Collections;
using System.Collections.Generic;
using System.Text;
using XeApp.Game;
using XeApp.Game.Menu;
using XeSys;

public class MOEALEGLGCH
{
	private Dictionary<int, string> KGNCCIDGGCC; // 0x10

	public List<int> NBIGLBMHEDC_DivaList { get; private set; } // 0x8 ELHJMCKHBBO DGMMMDMLCJF PICPPMMJAEH
	public List<LFAFJCNKLML> MGJKEJHEBPO_Blocks { get; private set; } // 0xC DPHOPMPKAHK BNPJIIPJJLJ HOKDNOFCDHM

	//// RVA: 0x17B2DC8 Offset: 0x17B2DC8 VA: 0x17B2DC8
	public void KHEKNNFCAOI_Init()
	{
		NBIGLBMHEDC_DivaList = new List<int>(10);
		MGJKEJHEBPO_Blocks = LFAFJCNKLML.FKDIMODKKJD(NBIGLBMHEDC_DivaList);
		JOMFNNJHNIJ();
	}

	//// RVA: 0x17B2E64 Offset: 0x17B2E64 VA: 0x17B2E64
	private void JOMFNNJHNIJ()
	{
		MessageBank bk = MessageManager.Instance.GetBank("master");
		StringBuilder str = new StringBuilder(32);
		KGNCCIDGGCC = new Dictionary<int, string>();
		for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.FDNBEPCEHBH_UnlocksConditions.Count; i++)
		{
			LCLCCHLDNHJ_Costume.JMEHNBGDEBD d = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.FDNBEPCEHBH_UnlocksConditions[i + 1];
			for(int j = 0; j < d.NKNBKLHCAFD_UnlocksConditions.Length; j++)
			{
				if(d.NKNBKLHCAFD_UnlocksConditions[j].INDDJNMPONH_type != 0)
				{
					if(!KGNCCIDGGCC.ContainsKey(d.NKNBKLHCAFD_UnlocksConditions[j].INDDJNMPONH_type))
					{
						str.SetFormat("cos_unlock_{0:D4}", d.NKNBKLHCAFD_UnlocksConditions[j].INDDJNMPONH_type);
						KGNCCIDGGCC.Add(d.NKNBKLHCAFD_UnlocksConditions[j].INDDJNMPONH_type, bk.GetMessageByLabel(str.ToString()));
					}
				}
			}
		}
	}

	//// RVA: 0x17B325C Offset: 0x17B325C VA: 0x17B325C
	public List<LFAFJCNKLML> NLLHENIPDDA(List<int> _NBIGLBMHEDC_DivaList)
	{
		if(_NBIGLBMHEDC_DivaList == null || _NBIGLBMHEDC_DivaList.Count < 1)
		{
			return MGJKEJHEBPO_Blocks;
		}
		else
		{
			List<LFAFJCNKLML> res = new List<LFAFJCNKLML>(MGJKEJHEBPO_Blocks.Count);
			for(int i = 0; i < MGJKEJHEBPO_Blocks.Count; i++)
			{
				if(_NBIGLBMHEDC_DivaList.Contains(MGJKEJHEBPO_Blocks[i].AHHJLDLAPAN_DivaId))
				{
					res.Add(MGJKEJHEBPO_Blocks[i]);
				}
			}
			return res;
		}
	}

	//// RVA: 0x17B3438 Offset: 0x17B3438 VA: 0x17B3438
	public static int LLCBDMCPBOD_GetHaveUc()
	{
		return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.NFHLDFJIBKI_have_uc;
	}

	//// RVA: 0x17B3514 Offset: 0x17B3514 VA: 0x17B3514
	//public static int LCLMFJOBPOK() { }

	//// RVA: 0x17B3604 Offset: 0x17B3604 VA: 0x17B3604
	public static int IGDOBKHKNJM_GetCostumeUpgradeOfferNum()
	{
		return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA_GetIntParam("costume_upgrade_complete_offer_num", 10);
	}

	//// RVA: 0x17B36F4 Offset: 0x17B36F4 VA: 0x17B36F4
	public static bool CDOCOLOKCJK()
	{
		return IGDOBKHKNJM_GetCostumeUpgradeOfferNum() <= KDHGBOOECKC.HHCJCDFCLOB.DEAIKHLFFCL_GetTotalVOp(0);
	}

	//// RVA: 0x17B3744 Offset: 0x17B3744 VA: 0x17B3744
	public static int FLGEJDKMNMI()
	{
		return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA_GetIntParam("costume_upgrade_vc_count", 5);
	}

	//// RVA: 0x17B3834 Offset: 0x17B3834 VA: 0x17B3834
	public int GJFJBGNCBAP(LFAFJCNKLML _IDLHJIOMJBK_data, int _ANAJIAENLNB_lv)
	{
		LFAFJCNKLML.FHLDDEKAJKI f = _IDLHJIOMJBK_data.OCOOHBINGBG_LevelInfo[_ANAJIAENLNB_lv];
		if(f.KBOLNIBLIND_unlock == null)
			return 0;
		return f.KBOLNIBLIND_unlock.Length;
	}

	//// RVA: 0x17B38E8 Offset: 0x17B38E8 VA: 0x17B38E8
	public int GJFJBGNCBAP(LFAFJCNKLML _IDLHJIOMJBK_data)
	{
		return GJFJBGNCBAP(_IDLHJIOMJBK_data, _IDLHJIOMJBK_data.GKIKAABHAAD_Level);
	}

	//// RVA: 0x17B3920 Offset: 0x17B3920 VA: 0x17B3920
	private int EBFFMJHDHIO(int _ANAJIAENLNB_lv)
	{
		int res = 0;
		for(int i = 0; i < MGJKEJHEBPO_Blocks.Count; i++)
		{
			if (MGJKEJHEBPO_Blocks[i].GKIKAABHAAD_Level >= _ANAJIAENLNB_lv)
				res++;
		}
		return res;
	}

	//// RVA: 0x17B3A18 Offset: 0x17B3A18 VA: 0x17B3A18
	public string EGFDDHPPFNE(LFAFJCNKLML _IDLHJIOMJBK_data, int _ANAJIAENLNB_lv, int _OIPCCBHIKIA_index)
	{
		LFAFJCNKLML.FHLDDEKAJKI f = _IDLHJIOMJBK_data.OCOOHBINGBG_LevelInfo[_ANAJIAENLNB_lv];
		if(f.KBOLNIBLIND_unlock[_OIPCCBHIKIA_index].INDDJNMPONH_type == LCLCCHLDNHJ_Costume.LKLGPLFNJBA_UnlockCondition.HJNNKCMLGFL_0_None)
			return null;
		StringBuilder str = new StringBuilder();
		if(f.KBOLNIBLIND_unlock[_OIPCCBHIKIA_index].INDDJNMPONH_type == LCLCCHLDNHJ_Costume.LKLGPLFNJBA_UnlockCondition.CALCHKAMIDB_3_DivaIntimacy)
		{
            DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo diva = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(_IDLHJIOMJBK_data.AHHJLDLAPAN_DivaId);
			str.SetFormat(KGNCCIDGGCC[(int)f.KBOLNIBLIND_unlock[_OIPCCBHIKIA_index].INDDJNMPONH_type], f.KBOLNIBLIND_unlock[_OIPCCBHIKIA_index].PIBLLGLCJEO_Param[0], diva.KCCONFODCPN_IntimacyLevel, FFHPBEPOMAK_DivaInfo.EJOJNFDHDHN_GetName(_IDLHJIOMJBK_data.AHHJLDLAPAN_DivaId));
        }
		else if(f.KBOLNIBLIND_unlock[_OIPCCBHIKIA_index].INDDJNMPONH_type == LCLCCHLDNHJ_Costume.LKLGPLFNJBA_UnlockCondition.BCJHILDCONA_2_UseItems)
		{
            PLPBJOFICEJ_CosItem.IBEMFIAFIKH_ItemInfo cosItem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GOGFKAECFIP_CosItem.LBDOLHGDIEB_FindItem(_IDLHJIOMJBK_data.AHHJLDLAPAN_DivaId, PLPBJOFICEJ_CosItem.DPNGHIDJCHA_Category.GLHANCMGNDM_2);
			str.SetFormat(KGNCCIDGGCC[(int)f.KBOLNIBLIND_unlock[_OIPCCBHIKIA_index].INDDJNMPONH_type], NIHHKCDHLNH.EJOJNFDHDHN(cosItem.PPFNGGCBJKC_id), f.KBOLNIBLIND_unlock[_OIPCCBHIKIA_index].PIBLLGLCJEO_Param[0]);
        }
		else if(f.KBOLNIBLIND_unlock[_OIPCCBHIKIA_index].INDDJNMPONH_type == LCLCCHLDNHJ_Costume.LKLGPLFNJBA_UnlockCondition.NBEFPGIMEGA_1_OwnedCostume)
		{
			str.SetFormat(KGNCCIDGGCC[(int)f.KBOLNIBLIND_unlock[_OIPCCBHIKIA_index].INDDJNMPONH_type], f.KBOLNIBLIND_unlock[_OIPCCBHIKIA_index].PIBLLGLCJEO_Param[0], f.KBOLNIBLIND_unlock[_OIPCCBHIKIA_index].PIBLLGLCJEO_Param[1], EBFFMJHDHIO(f.KBOLNIBLIND_unlock[_OIPCCBHIKIA_index].PIBLLGLCJEO_Param[0]));
		}
		return str.ToString();
	}

	//// RVA: 0x17B4034 Offset: 0x17B4034 VA: 0x17B4034
	public string EGFDDHPPFNE(LFAFJCNKLML _IDLHJIOMJBK_data, int _OIPCCBHIKIA_index)
	{
		return EGFDDHPPFNE(_IDLHJIOMJBK_data, _IDLHJIOMJBK_data.GKIKAABHAAD_Level, _OIPCCBHIKIA_index);
	}

	//// RVA: 0x17B4084 Offset: 0x17B4084 VA: 0x17B4084
	public bool HEOGHOIOHGI(LFAFJCNKLML _IDLHJIOMJBK_data, int _ANAJIAENLNB_lv, int _OIPCCBHIKIA_index, out int KOGEGJOOMIG, out int _JDLJPNMLFID_ItemCount)
	{
		_JDLJPNMLFID_ItemCount = 0;
		KOGEGJOOMIG = 0;
		LFAFJCNKLML.FHLDDEKAJKI f = _IDLHJIOMJBK_data.OCOOHBINGBG_LevelInfo[_ANAJIAENLNB_lv];
		if(f.KBOLNIBLIND_unlock != null)
		{
			if(f.KBOLNIBLIND_unlock[_OIPCCBHIKIA_index].INDDJNMPONH_type == LCLCCHLDNHJ_Costume.LKLGPLFNJBA_UnlockCondition.BCJHILDCONA_2_UseItems)
			{
				KOGEGJOOMIG = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.NEIIGCODGBA_CostumeItem, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GOGFKAECFIP_CosItem.LBDOLHGDIEB_FindItem(_IDLHJIOMJBK_data.GKIKAABHAAD_Level, PLPBJOFICEJ_CosItem.DPNGHIDJCHA_Category.GLHANCMGNDM_2).PPFNGGCBJKC_id);
				_JDLJPNMLFID_ItemCount = f.KBOLNIBLIND_unlock[_OIPCCBHIKIA_index].PIBLLGLCJEO_Param[0];
				return true;
			}
		}
		return false;
	}

	//// RVA: 0x17B42E0 Offset: 0x17B42E0 VA: 0x17B42E0
	public bool HEOGHOIOHGI(LFAFJCNKLML _IDLHJIOMJBK_data, int _OIPCCBHIKIA_index, out int KOGEGJOOMIG, out int _JDLJPNMLFID_ItemCount)
	{
		return HEOGHOIOHGI(_IDLHJIOMJBK_data, _IDLHJIOMJBK_data.GKIKAABHAAD_Level, _OIPCCBHIKIA_index, out KOGEGJOOMIG, out _JDLJPNMLFID_ItemCount);
	}

	//// RVA: 0x17B4334 Offset: 0x17B4334 VA: 0x17B4334
	public bool KFJHILDJCCB(LFAFJCNKLML _IDLHJIOMJBK_data, int _ANAJIAENLNB_lv)
	{
		LFAFJCNKLML.FHLDDEKAJKI d = _IDLHJIOMJBK_data.OCOOHBINGBG_LevelInfo[_ANAJIAENLNB_lv];
		if(d.KBOLNIBLIND_unlock != null)
		{
			for(int i = 0; i < d.KBOLNIBLIND_unlock.Length; i++)
			{
				bool b = true;
				if (d.KBOLNIBLIND_unlock[i].INDDJNMPONH_type < LCLCCHLDNHJ_Costume.LKLGPLFNJBA_UnlockCondition.AEFCOHJBLPO/*4*/)
				{
					switch(d.KBOLNIBLIND_unlock[i].INDDJNMPONH_type)
					{
						case LCLCCHLDNHJ_Costume.LKLGPLFNJBA_UnlockCondition.HJNNKCMLGFL_0_None/*0*/:
							continue;
						case LCLCCHLDNHJ_Costume.LKLGPLFNJBA_UnlockCondition.NBEFPGIMEGA_1_OwnedCostume/*1*/:
							b = d.KBOLNIBLIND_unlock[i].PIBLLGLCJEO_Param[1] <= EBFFMJHDHIO(d.KBOLNIBLIND_unlock[i].PIBLLGLCJEO_Param[0]);
							break;
						case LCLCCHLDNHJ_Costume.LKLGPLFNJBA_UnlockCondition.BCJHILDCONA_2_UseItems/*2*/:
							PLPBJOFICEJ_CosItem.IBEMFIAFIKH_ItemInfo dbCosItem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GOGFKAECFIP_CosItem.LBDOLHGDIEB_FindItem(_IDLHJIOMJBK_data.AHHJLDLAPAN_DivaId, PLPBJOFICEJ_CosItem.DPNGHIDJCHA_Category.GLHANCMGNDM_2/*2*/);
							b = d.KBOLNIBLIND_unlock[i].PIBLLGLCJEO_Param[0] <= CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.EFBKCNNFIPJ(dbCosItem.PPFNGGCBJKC_id).BFINGCJHOHI_cnt;
							break;
						case LCLCCHLDNHJ_Costume.LKLGPLFNJBA_UnlockCondition.CALCHKAMIDB_3_DivaIntimacy/*3*/:
							b = d.KBOLNIBLIND_unlock[i].PIBLLGLCJEO_Param[0] <= CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(_IDLHJIOMJBK_data.AHHJLDLAPAN_DivaId).KCCONFODCPN_IntimacyLevel;
							break;
					}
				}
				else
				{
					b = false;
				}
				if (!b)
					return false;
			}
		}
		return true;
	}

	//// RVA: 0x17B47F0 Offset: 0x17B47F0 VA: 0x17B47F0
	public bool KFJHILDJCCB(LFAFJCNKLML _IDLHJIOMJBK_data)
	{
		return KFJHILDJCCB(_IDLHJIOMJBK_data, _IDLHJIOMJBK_data.GKIKAABHAAD_Level);
	}

	//// RVA: 0x17B4830 Offset: 0x17B4830 VA: 0x17B4830
	//public bool EJOALPKJKIG(LFAFJCNKLML _IDLHJIOMJBK_data, int _ANAJIAENLNB_lv) { }

	//// RVA: 0x17B4918 Offset: 0x17B4918 VA: 0x17B4918
	//public bool EJOALPKJKIG(LFAFJCNKLML _IDLHJIOMJBK_data) { }

	//// RVA: 0x17B4950 Offset: 0x17B4950 VA: 0x17B4950
	public int DLJJACACBDI(int JBPCPCBLNDC, int _MHFBCINOJEE_Num, int _HMFFHLPNMPH_count)
	{
		if(_HMFFHLPNMPH_count > 0)
		{
            EBFLJMOCLNA_Costume.ILFJDCICIKN saveCos = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.BEKHNNCGIEL_Costume.EEOADCECNOM_GetCostume(JBPCPCBLNDC);
            if (saveCos.BEEAIAAJOHD_CostumeId == JBPCPCBLNDC)
			{
                PLPBJOFICEJ_CosItem.IBEMFIAFIKH_ItemInfo dbCos = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GOGFKAECFIP_CosItem.EEOADCECNOM_GetItemById(_MHFBCINOJEE_Num);
				if(dbCos.PPFNGGCBJKC_id == _MHFBCINOJEE_Num)
				{
					return _HMFFHLPNMPH_count <= CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.EFBKCNNFIPJ(_MHFBCINOJEE_Num).BFINGCJHOHI_cnt ? 1 : 0;
				}
            }
		}
		return -1;
	}

	//// RVA: 0x17B4BFC Offset: 0x17B4BFC VA: 0x17B4BFC
	public int JDLAFDBFLOM(LFAFJCNKLML _IDLHJIOMJBK_data, IMCBBOAFION _BHFHGFKBOHH_OnSuccess)
	{
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PFAKPFKJJKA(true) == null)
		{
			LFAFJCNKLML.FHLDDEKAJKI d = _IDLHJIOMJBK_data.OCOOHBINGBG_LevelInfo[_IDLHJIOMJBK_data.GKIKAABHAAD_Level];
			bool b = false;
			for(int i = 0; i < d.KBOLNIBLIND_unlock.Length; i++)
			{
				if(d.KBOLNIBLIND_unlock[i].INDDJNMPONH_type == LCLCCHLDNHJ_Costume.LKLGPLFNJBA_UnlockCondition.BCJHILDCONA_2_UseItems)
				{
                    PLPBJOFICEJ_CosItem.IBEMFIAFIKH_ItemInfo cosItem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GOGFKAECFIP_CosItem.LBDOLHGDIEB_FindItem(_IDLHJIOMJBK_data.AHHJLDLAPAN_DivaId, PLPBJOFICEJ_CosItem.DPNGHIDJCHA_Category.GLHANCMGNDM_2);
					int a = DLJJACACBDI(_IDLHJIOMJBK_data.JPIDIENBGKH_CostumeId, cosItem.PPFNGGCBJKC_id, d.KBOLNIBLIND_unlock[i].PIBLLGLCJEO_Param[0]);
					if(a < 1)
						return a;
					if(d.KBOLNIBLIND_unlock[i].PIBLLGLCJEO_Param[0] > 0)
					{
                        EGOLBAPFHHD_Common.PGENIOHDCDI saveCosItem = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.EFBKCNNFIPJ(cosItem.PPFNGGCBJKC_id);
						saveCosItem.BFINGCJHOHI_cnt -= d.KBOLNIBLIND_unlock[i].PIBLLGLCJEO_Param[0];
						if(saveCosItem.BFINGCJHOHI_cnt < 0)
							saveCosItem.BFINGCJHOHI_cnt = 0;
						b = true;
                    }
                }
			}
            EBFLJMOCLNA_Costume.ILFJDCICIKN cos = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.BEKHNNCGIEL_Costume.EEOADCECNOM_GetCostume(_IDLHJIOMJBK_data.JPIDIENBGKH_CostumeId);
			cos.GLHANCMGNDM_SetUnlockLevel(cos.ANAJIAENLNB_lv);
			if(!b)
			{
				CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.BEKHNNCGIEL_Costume.BEEJCDHCONE(_IDLHJIOMJBK_data.JPIDIENBGKH_CostumeId, cos.ANAJIAENLNB_lv);
			}
        }
		MenuScene.SaveWithAchievement(0, () =>
		{
			//0x17B5E04
			_BHFHGFKBOHH_OnSuccess();
		}, null);
		return 1;
	}

	//// RVA: 0x17B5320 Offset: 0x17B5320 VA: 0x17B5320
	public void COLOGGOJGAJ()
	{
		for(int i = 0; i < MGJKEJHEBPO_Blocks.Count; i++)
		{
			MGJKEJHEBPO_Blocks[i].AHLONCCGGHP();
		}
	}

	//// RVA: 0x17B53FC Offset: 0x17B53FC VA: 0x17B53FC
	public int CALNLFGDMEE(int JBPCPCBLNDC, int KOGEGJOOMIG, int _HMFFHLPNMPH_count, IMCBBOAFION _BHFHGFKBOHH_OnSuccess)
	{
		int a1 = DLJJACACBDI(JBPCPCBLNDC, KOGEGJOOMIG, _HMFFHLPNMPH_count);
		if(a1 > 0)
		{
			a1 = 0;
            EBFLJMOCLNA_Costume.ILFJDCICIKN saveCos = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.BEKHNNCGIEL_Costume.EEOADCECNOM_GetCostume(JBPCPCBLNDC);
			PLPBJOFICEJ_CosItem.IBEMFIAFIKH_ItemInfo dbCosItem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GOGFKAECFIP_CosItem.EEOADCECNOM_GetItemById(KOGEGJOOMIG);
			EBFLJMOCLNA_Costume.ILFJDCICIKN.PIHKHAKGNCN d;
			bool b1 = saveCos.EAMPKNCDCFM(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume, dbCosItem.JBGEEPFKIGG_val * _HMFFHLPNMPH_count, out d);
			int a2 = LLCBDMCPBOD_GetHaveUc();
			if(d.ACGLMKEBMDL_uc <= a2)
			{
				int diff = 0;
				FENCAJJBLBH f = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PFAKPFKJJKA(true);
				if(f == null)
				{
					EGOLBAPFHHD_Common.PGENIOHDCDI saveItem = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.EFBKCNNFIPJ(KOGEGJOOMIG);
					saveItem.BFINGCJHOHI_cnt -= _HMFFHLPNMPH_count;
					if(saveItem.BFINGCJHOHI_cnt < 0)
						saveItem.BFINGCJHOHI_cnt = 0;
					int prevPoint = saveCos.DNBFMLBNAEE_point;
					int prevLevel = saveCos.ANAJIAENLNB_lv;
					saveCos.MOACIBEKLEN(d);
					CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.LLEGCIMFPGD(d.ACGLMKEBMDL_uc);
					diff = saveCos.ANAJIAENLNB_lv - prevLevel;
					if(diff > 0)
					{
						if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null && 
							CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter != null && 
							CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total != null)
						{
							CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.KNCLIEBAPJD_Cosu += saveCos.ANAJIAENLNB_lv - prevLevel;
							if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.KNCLIEBAPJD_Cosu > 99999999)
								CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.KNCLIEBAPJD_Cosu = 99999999;
						}
						if(GNGMCIAIKMA.HHCJCDFCLOB != null)
							GNGMCIAIKMA.HHCJCDFCLOB.HEFIKPAHCIA_UpdateMission(null, -1);
					}
					JDDGPJDKHNE.HHCJCDFCLOB.NFNLGGHMEAM();
					JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = true;
					ILCCJNDFFOB.HHCJCDFCLOB.BABLKKLEPGD(JBPCPCBLNDC, prevLevel, saveCos.ANAJIAENLNB_lv, prevPoint, saveCos.DNBFMLBNAEE_point, EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.NEIIGCODGBA_CostumeItem, KOGEGJOOMIG), _HMFFHLPNMPH_count, d.ACGLMKEBMDL_uc);
				}
				LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo dbCos = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA_table[JBPCPCBLNDC - 1];
				int a3 = 0;
				if(dbCos != null)
				{
					a3 = dbCos.AHHJLDLAPAN_DivaId;
				}
				GameManager.Instance.StartCoroutineWatched(FOALKNNPKHG_Co_SaveAndUpdateRanking(a3, diff, _BHFHGFKBOHH_OnSuccess));
				a1 = 1;
			}
        }
		return a1;
	}

	//[IteratorStateMachineAttribute] // RVA: 0x740704 Offset: 0x740704 VA: 0x740704
	//// RVA: 0x17B5D1C Offset: 0x17B5D1C VA: 0x17B5D1C
	private IEnumerator FOALKNNPKHG_Co_SaveAndUpdateRanking(int _AHHJLDLAPAN_DivaId, int CBGMGJLLDOO, IMCBBOAFION _BHFHGFKBOHH_OnSuccess)
	{
		LAMCONGFONF DNJFBLPOBHE;

		//0x17B5E48
		bool BEKAMBBOLBO_Done = false;
		MenuScene.SaveWithAchievement(0x800000000, () =>
		{
			//0x17B5E38
			BEKAMBBOLBO_Done = true;
		}, null);
		while(!BEKAMBBOLBO_Done)
			yield return null;
		if(_AHHJLDLAPAN_DivaId >= 1 && CBGMGJLLDOO > 0)
		{
			DNJFBLPOBHE = LAMCONGFONF.HHCJCDFCLOB;
			if(DNJFBLPOBHE != null)
			{
				FFHPBEPOMAK_DivaInfo f = new FFHPBEPOMAK_DivaInfo();
				f.KHEKNNFCAOI_Init(_AHHJLDLAPAN_DivaId, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, false);
				DNJFBLPOBHE.FGMOMBKGCNF(_AHHJLDLAPAN_DivaId - 1, f.JLJGCBOHJID_Status.soul + f.JLJGCBOHJID_Status.vocal + f.JLJGCBOHJID_Status.charm, null, null, null);
				while(!DNJFBLPOBHE.PLOOEECNHFB_IsDone)
					yield return null;
			}
		}
		JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = false;
		_BHFHGFKBOHH_OnSuccess();
	}
}
