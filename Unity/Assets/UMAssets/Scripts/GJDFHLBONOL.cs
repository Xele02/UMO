
public class GJDFHLBONOL
{
	private const int LMLBOHALKOM = 31536000;
	public long MDPJFPHOPCH_Id; // 0x8
	public string LJGOOOMOMMA_message; // 0x10
	public string HAAJGNCFNJM_item_name; // 0x14
	public int OCNINMIMHGC_item_value; // 0x18
	public int MBJIFDBEDAC_item_count; // 0x1C
	public int MJBKGOJBPAD_item_type; // 0x20
	public int INDDJNMPONH_type; // 0x24
	public long BIOGKIEECGN_created_at; // 0x28
	public long EGBOHDFBAPB_closed_at; // 0x30
	public bool BGOJPEJJJFB_IsAvaiable; // 0x38
	public long EILKGEADKGH_Order; // 0x40
	public long LNDEFMALKAN_received_at; // 0x48
	public int JJBGOIMEIPF_ItemId; // 0x50
	public EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category NPPNDDMPFJJ_ItemCategory; // 0x54
	public int NNFNGLJOKKF_ItemId; // 0x58
	public bool ILMMOGBDIME; // 0x5C
	public bool AIFBJHNBPMH; // 0x5D
	public bool MBFGLMEECOO; // 0x5E

	// // RVA: 0xAAB4C8 Offset: 0xAAB4C8 VA: 0xAAB4C8
	public bool JLFHLOCONEE()
	{
		return BGOJPEJJJFB_IsAvaiable;
	}

	// // RVA: 0xAAB4D0 Offset: 0xAAB4D0 VA: 0xAAB4D0
	public void DPKCOKLMFMK(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
	{
		MDPJFPHOPCH_Id = CEDHHAGBIBA.NIKODNFGCEM_ReadLong(_IDLHJIOMJBK_data, AFEHLCGHAEE_Strings.PPFNGGCBJKC_id);
		LJGOOOMOMMA_message = CEDHHAGBIBA.BNCLNFJHEND_ReadString(_IDLHJIOMJBK_data, AFEHLCGHAEE_Strings.LJGOOOMOMMA_message);
		HAAJGNCFNJM_item_name = CEDHHAGBIBA.BNCLNFJHEND_ReadString(_IDLHJIOMJBK_data, AFEHLCGHAEE_Strings.HAAJGNCFNJM_item_name);
		OCNINMIMHGC_item_value = CEDHHAGBIBA.GNJBKANDLEE_ReadInt(_IDLHJIOMJBK_data, AFEHLCGHAEE_Strings.OCNINMIMHGC_item_value);
		MJBKGOJBPAD_item_type = CEDHHAGBIBA.GNJBKANDLEE_ReadInt(_IDLHJIOMJBK_data, AFEHLCGHAEE_Strings.MJBKGOJBPAD_item_type);
		MBJIFDBEDAC_item_count = CEDHHAGBIBA.GNJBKANDLEE_ReadInt(_IDLHJIOMJBK_data, AFEHLCGHAEE_Strings.MBJIFDBEDAC_item_count);
		INDDJNMPONH_type = CEDHHAGBIBA.GNJBKANDLEE_ReadInt(_IDLHJIOMJBK_data, AFEHLCGHAEE_Strings.INDDJNMPONH_type);
		BIOGKIEECGN_created_at = CEDHHAGBIBA.NIKODNFGCEM_ReadLong(_IDLHJIOMJBK_data, AFEHLCGHAEE_Strings.BIOGKIEECGN_created_at);
		EGBOHDFBAPB_closed_at = CEDHHAGBIBA.NIKODNFGCEM_ReadLong(_IDLHJIOMJBK_data, AFEHLCGHAEE_Strings.EGBOHDFBAPB_closed_at);
		LNDEFMALKAN_received_at = CEDHHAGBIBA.NIKODNFGCEM_ReadLong(_IDLHJIOMJBK_data, AFEHLCGHAEE_Strings.LNDEFMALKAN_received_at);
		EILKGEADKGH_Order = CEDHHAGBIBA.NIKODNFGCEM_ReadLong(_IDLHJIOMJBK_data, "order");
		BGOJPEJJJFB_IsAvaiable = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime() + 31536000 < EGBOHDFBAPB_closed_at;
		if(MJBKGOJBPAD_item_type == 2)
		{
			NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.HJNNKCMLGFL_0_None;
		}
		else
		{
			int val = OCNINMIMHGC_item_value;
			int id;
			EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category cat;
			if(MJBKGOJBPAD_item_type == 1)
			{
				if(val < 3001)
				{
					if(val < 2001 || val == 3000)
					{
						//LAB_00aabf7c
						id = 1;
						cat = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC;
						NNFNGLJOKKF_ItemId = 1;
						OCNINMIMHGC_item_value = 1;
						NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC;
					}
					else
					{
						if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.GKMAHADAAFI_GachaTicket.DHIACJMOEBH_vcIdsList.Contains(OCNINMIMHGC_item_value))
						{
							cat = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.OBHECJMAEIO_GachaTicket;
							NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.OBHECJMAEIO_GachaTicket;
							id = OCNINMIMHGC_item_value - 2000;
						}
						else
						{
							cat = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC;
							NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC;
							id = OCNINMIMHGC_item_value - 1996;
						}
						OCNINMIMHGC_item_value = id;
						NNFNGLJOKKF_ItemId = id;
					}
				}
				else if(val < 4000)
				{
					cat = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC;
					id = val - 3000;
					NNFNGLJOKKF_ItemId = id;
					OCNINMIMHGC_item_value = id;
					NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC;
				}
				else
				{
					if(val != 5001)
					{
						id = 1;
						cat = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC;
						NNFNGLJOKKF_ItemId = 1;
						OCNINMIMHGC_item_value = 1;
						NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC;
					}
					else
					{
						OCNINMIMHGC_item_value = 9;
						NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC;
						NNFNGLJOKKF_ItemId = 9;
						JJBGOIMEIPF_ItemId = EKLNMHFCAOI_ItemManager.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC, 9);
						id = OCNINMIMHGC_item_value;
						cat = NPPNDDMPFJJ_ItemCategory;
					}
				}
				JJBGOIMEIPF_ItemId = EKLNMHFCAOI_ItemManager.GJEEGMCBGGM_GetItemFullId(cat, id);
				return;
			}
			if(val > 9999)
			{
				JJBGOIMEIPF_ItemId = val;
				NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI_ItemManager.BKHFLDMOGBD_GetItemCategory(val);
				NNFNGLJOKKF_ItemId = EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(OCNINMIMHGC_item_value);
				return;
			}
			cat = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.HLCHKCJLEGK_GrowItem;
			if(!HAAJGNCFNJM_item_name.Contains(AFEHLCGHAEE_Strings.KBMDMEEMGLK_grow_item))
			{
				cat = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene;
				if(!HAAJGNCFNJM_item_name.Contains(AFEHLCGHAEE_Strings.COIODGJDJEJ_scene))
				{
					cat = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit;
					if(HAAJGNCFNJM_item_name != AFEHLCGHAEE_Strings.PJPGBPACBFA_uc_item)
					{
						cat = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.EMOLGEDEEJP_EventItem;
						if(HAAJGNCFNJM_item_name != "event_item")
						{
							cat = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.OBHECJMAEIO_GachaTicket;
							if(HAAJGNCFNJM_item_name != "gacha_ticket")
							{
								cat = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.MEDAKGBKIMO_EpisodeItem;
								if(HAAJGNCFNJM_item_name != AFEHLCGHAEE_Strings.GJODJNIHKKF_epi_item)
								{
									cat = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.PFIOMNHDHCO_6_Valkyrie;
									if(HAAJGNCFNJM_item_name != "valkyrie")
									{
										cat = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.KBHGPMNGALJ_5_Costume;
										if(HAAJGNCFNJM_item_name != "costume")
										{
											cat = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.JHGPNDLNPFA_DivaItem;
											if(HAAJGNCFNJM_item_name != "diva_item")
											{
												cat = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.MNCJMDDAFJB_EmblemItem;
												if(HAAJGNCFNJM_item_name != "emblem")
												{
													cat = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.GIMBFBNKPNO_CompoItem;
													if(HAAJGNCFNJM_item_name != "compo")
													{
														cat = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.KNHFAHFCCBK_SnsItem;
														if(HAAJGNCFNJM_item_name != "sns_item")
														{
															cat = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem;
															if(HAAJGNCFNJM_item_name != "energy_item")
															{
																cat = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.CLMIJKACELE_EventTicket;
																if(HAAJGNCFNJM_item_name != "event_ticket")
																{
																	cat = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal;
																	if(HAAJGNCFNJM_item_name != "medal")
																	{
																		cat = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.IGIFMNJADEC_MvTicket;
																		if(HAAJGNCFNJM_item_name != "mv_ticket")
																		{
																			cat = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.LLFAAOHPMIC_EventGachaTicket;
																			if(HAAJGNCFNJM_item_name != "event_gacha_ticket")
																			{
																				cat = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.DLBHNNOHLMM_PresentItem;
																				if(HAAJGNCFNJM_item_name != "present_item")
																				{
																					cat = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem;
																					if(HAAJGNCFNJM_item_name != "sp_item")
																					{
																						cat = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.NEIIGCODGBA_CostumeItem;
																						if(HAAJGNCFNJM_item_name != "cos_item")
																						{
																							cat = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.CIOGEKJNMBB_RareUpItem;
																							if(HAAJGNCFNJM_item_name != "rareup_item")
																							{
																								cat = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.DLOPEFGOAPD_24_LimitedItem;
																								if(HAAJGNCFNJM_item_name != "limited_item")
																								{
																									cat = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.PJCJEOECLBK_MonthlyPassItem;
																									if(HAAJGNCFNJM_item_name != "monthly_pass")
																									{
																										cat = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg;
																										if(HAAJGNCFNJM_item_name != "deco_bg")
																										{
																											cat = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj;
																											if(HAAJGNCFNJM_item_name != "deco_obj")
																											{
																												cat = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara;
																												if(HAAJGNCFNJM_item_name != "deco_chara")
																												{
																													cat = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif;
																													if(HAAJGNCFNJM_item_name != "deco_serif")
																													{
																														cat = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp;
																														if(HAAJGNCFNJM_item_name != "deco_sp")
																														{
																															cat = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.OOMMOOIIPJE_DecoItemPoster;
																															if (HAAJGNCFNJM_item_name != "deco_poster")
																															{
																																cat = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.MABCLBNIOFA_ValkyrieItem;
																																if(HAAJGNCFNJM_item_name != "val_item")
																																{
																																	cat = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.ICJOEDJECAP_DecoSetItem;
																																	if (HAAJGNCFNJM_item_name != "deco_set_item")
																																	{
																																		cat = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.CFLFPPDMFAE_RaidItem;
																																		if (HAAJGNCFNJM_item_name != "raid_item")
																																		{
																																			if (HAAJGNCFNJM_item_name != "event_raid_item")
																																			{
																																				cat = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.CKCPFLDGILD_LimitedCompoItem;
																																				if (HAAJGNCFNJM_item_name != "limited_compo_item")
																																				{
																																					if (HAAJGNCFNJM_item_name == "home_bg_item")
																																					{
																																						cat = EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.HGDPIAFBCGA_HomeBg;
																																					}
																																				}
																																			}
																																		}
																																	}
																																}
																															}
																														}
																													}
																												}
																											}
																										}
																									}
																								}
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			NPPNDDMPFJJ_ItemCategory = cat;
		}
		NNFNGLJOKKF_ItemId = EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(OCNINMIMHGC_item_value);
		JJBGOIMEIPF_ItemId = EKLNMHFCAOI_ItemManager.GJEEGMCBGGM_GetItemFullId(NPPNDDMPFJJ_ItemCategory, NNFNGLJOKKF_ItemId);
	}

	// // RVA: 0xAAC0E8 Offset: 0xAAC0E8 VA: 0xAAC0E8
	public void ODDIHGPONFL_Copy(GJDFHLBONOL GPBJHKLFCEP)
	{
		MDPJFPHOPCH_Id = GPBJHKLFCEP.MDPJFPHOPCH_Id;
		LJGOOOMOMMA_message = GPBJHKLFCEP.LJGOOOMOMMA_message;
		HAAJGNCFNJM_item_name = GPBJHKLFCEP.HAAJGNCFNJM_item_name;
		OCNINMIMHGC_item_value = GPBJHKLFCEP.OCNINMIMHGC_item_value;
		MBJIFDBEDAC_item_count = GPBJHKLFCEP.MBJIFDBEDAC_item_count;
		MJBKGOJBPAD_item_type = GPBJHKLFCEP.MJBKGOJBPAD_item_type;
		INDDJNMPONH_type = GPBJHKLFCEP.INDDJNMPONH_type;
		BIOGKIEECGN_created_at = GPBJHKLFCEP.BIOGKIEECGN_created_at;
		EGBOHDFBAPB_closed_at = GPBJHKLFCEP.EGBOHDFBAPB_closed_at;
		LNDEFMALKAN_received_at = GPBJHKLFCEP.LNDEFMALKAN_received_at;
		JJBGOIMEIPF_ItemId = GPBJHKLFCEP.JJBGOIMEIPF_ItemId;
		NPPNDDMPFJJ_ItemCategory = GPBJHKLFCEP.NPPNDDMPFJJ_ItemCategory;
		NNFNGLJOKKF_ItemId = GPBJHKLFCEP.NNFNGLJOKKF_ItemId;
		EILKGEADKGH_Order = GPBJHKLFCEP.EILKGEADKGH_Order;
	}

	// // RVA: 0xAAC2C4 Offset: 0xAAC2C4 VA: 0xAAC2C4
	// public void GELFIONIBEB(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) { }
	//MDPJFPHOPCH_Id = PPFNGGCBJKC_id
	//HAAJGNCFNJM_item_name = name
	//MBJIFDBEDAC_item_count = quantity
	//LJGOOOMOMMA_message = message
	//BIOGKIEECGN_created_at = BIOGKIEECGN_created_at
}
