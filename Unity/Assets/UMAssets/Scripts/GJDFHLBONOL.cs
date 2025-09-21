
public class GJDFHLBONOL
{
	private const int LMLBOHALKOM = 31536000;
	public long MDPJFPHOPCH_Id; // 0x8
	public string LJGOOOMOMMA_message; // 0x10
	public string HAAJGNCFNJM_ItemName; // 0x14
	public int OCNINMIMHGC_item_value; // 0x18
	public int MBJIFDBEDAC_item_count; // 0x1C
	public int MJBKGOJBPAD_item_type; // 0x20
	public int INDDJNMPONH_Type; // 0x24
	public long BIOGKIEECGN_CreatedAt; // 0x28
	public long EGBOHDFBAPB_ClosedAt; // 0x30
	public bool BGOJPEJJJFB_IsAvaiable; // 0x38
	public long EILKGEADKGH_Order; // 0x40
	public long LNDEFMALKAN_received_at; // 0x48
	public int JJBGOIMEIPF_ItemId; // 0x50
	public EKLNMHFCAOI.FKGCBLHOOCL_Category NPPNDDMPFJJ_ItemCategory; // 0x54
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
	public void DPKCOKLMFMK(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_Data)
	{
		MDPJFPHOPCH_Id = CEDHHAGBIBA.NIKODNFGCEM_ReadLong(_IDLHJIOMJBK_Data, AFEHLCGHAEE_Strings.PPFNGGCBJKC_id);
		LJGOOOMOMMA_message = CEDHHAGBIBA.BNCLNFJHEND_ReadString(_IDLHJIOMJBK_Data, AFEHLCGHAEE_Strings.LJGOOOMOMMA_message);
		HAAJGNCFNJM_ItemName = CEDHHAGBIBA.BNCLNFJHEND_ReadString(_IDLHJIOMJBK_Data, AFEHLCGHAEE_Strings.HAAJGNCFNJM_ItemName);
		OCNINMIMHGC_item_value = CEDHHAGBIBA.GNJBKANDLEE_ReadInt(_IDLHJIOMJBK_Data, AFEHLCGHAEE_Strings.OCNINMIMHGC_item_value);
		MJBKGOJBPAD_item_type = CEDHHAGBIBA.GNJBKANDLEE_ReadInt(_IDLHJIOMJBK_Data, AFEHLCGHAEE_Strings.MJBKGOJBPAD_item_type);
		MBJIFDBEDAC_item_count = CEDHHAGBIBA.GNJBKANDLEE_ReadInt(_IDLHJIOMJBK_Data, AFEHLCGHAEE_Strings.MBJIFDBEDAC_item_count);
		INDDJNMPONH_Type = CEDHHAGBIBA.GNJBKANDLEE_ReadInt(_IDLHJIOMJBK_Data, AFEHLCGHAEE_Strings.INDDJNMPONH_Type);
		BIOGKIEECGN_CreatedAt = CEDHHAGBIBA.NIKODNFGCEM_ReadLong(_IDLHJIOMJBK_Data, AFEHLCGHAEE_Strings.BIOGKIEECGN_CreatedAt);
		EGBOHDFBAPB_ClosedAt = CEDHHAGBIBA.NIKODNFGCEM_ReadLong(_IDLHJIOMJBK_Data, AFEHLCGHAEE_Strings.EGBOHDFBAPB_CloseAt);
		LNDEFMALKAN_received_at = CEDHHAGBIBA.NIKODNFGCEM_ReadLong(_IDLHJIOMJBK_Data, AFEHLCGHAEE_Strings.LNDEFMALKAN_received_at);
		EILKGEADKGH_Order = CEDHHAGBIBA.NIKODNFGCEM_ReadLong(_IDLHJIOMJBK_Data, "order");
		BGOJPEJJJFB_IsAvaiable = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime() + 31536000 < EGBOHDFBAPB_ClosedAt;
		if(MJBKGOJBPAD_item_type == 2)
		{
			NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.FKGCBLHOOCL_Category.HJNNKCMLGFL_0_None;
		}
		else
		{
			int val = OCNINMIMHGC_item_value;
			int id;
			EKLNMHFCAOI.FKGCBLHOOCL_Category cat;
			if(MJBKGOJBPAD_item_type == 1)
			{
				if(val < 3001)
				{
					if(val < 2001 || val == 3000)
					{
						//LAB_00aabf7c
						id = 1;
						cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC;
						NNFNGLJOKKF_ItemId = 1;
						OCNINMIMHGC_item_value = 1;
						NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC;
					}
					else
					{
						if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GKMAHADAAFI_GachaTicket.DHIACJMOEBH.Contains(OCNINMIMHGC_item_value))
						{
							cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.OBHECJMAEIO_GachaTicket;
							NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.FKGCBLHOOCL_Category.OBHECJMAEIO_GachaTicket;
							id = OCNINMIMHGC_item_value - 2000;
						}
						else
						{
							cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC;
							NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC;
							id = OCNINMIMHGC_item_value - 1996;
						}
						OCNINMIMHGC_item_value = id;
						NNFNGLJOKKF_ItemId = id;
					}
				}
				else if(val < 4000)
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC;
					id = val - 3000;
					NNFNGLJOKKF_ItemId = id;
					OCNINMIMHGC_item_value = id;
					NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC;
				}
				else
				{
					if(val != 5001)
					{
						id = 1;
						cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC;
						NNFNGLJOKKF_ItemId = 1;
						OCNINMIMHGC_item_value = 1;
						NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC;
					}
					else
					{
						OCNINMIMHGC_item_value = 9;
						NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC;
						NNFNGLJOKKF_ItemId = 9;
						JJBGOIMEIPF_ItemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC, 9);
						id = OCNINMIMHGC_item_value;
						cat = NPPNDDMPFJJ_ItemCategory;
					}
				}
				JJBGOIMEIPF_ItemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(cat, id);
				return;
			}
			if(val > 9999)
			{
				JJBGOIMEIPF_ItemId = val;
				NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(val);
				NNFNGLJOKKF_ItemId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(OCNINMIMHGC_item_value);
				return;
			}
			cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.HLCHKCJLEGK_GrowItem;
			if(!HAAJGNCFNJM_ItemName.Contains(AFEHLCGHAEE_Strings.KBMDMEEMGLK_grow_item))
			{
				cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene;
				if(!HAAJGNCFNJM_ItemName.Contains(AFEHLCGHAEE_Strings.COIODGJDJEJ_scene))
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit;
					if(HAAJGNCFNJM_ItemName != AFEHLCGHAEE_Strings.PJPGBPACBFA_uc_item)
					{
						cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.EMOLGEDEEJP_EventItem;
						if(HAAJGNCFNJM_ItemName != "event_item")
						{
							cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.OBHECJMAEIO_GachaTicket;
							if(HAAJGNCFNJM_ItemName != "gacha_ticket")
							{
								cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.MEDAKGBKIMO_EpisodeItem;
								if(HAAJGNCFNJM_ItemName != AFEHLCGHAEE_Strings.GJODJNIHKKF_EpiItem)
								{
									cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.PFIOMNHDHCO_Valkyrie;
									if(HAAJGNCFNJM_ItemName != "valkyrie")
									{
										cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume;
										if(HAAJGNCFNJM_ItemName != "costume")
										{
											cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.JHGPNDLNPFA_DivaItem;
											if(HAAJGNCFNJM_ItemName != "diva_item")
											{
												cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.MNCJMDDAFJB_EmblemItem;
												if(HAAJGNCFNJM_ItemName != "emblem")
												{
													cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.GIMBFBNKPNO_CompoItem;
													if(HAAJGNCFNJM_ItemName != "compo")
													{
														cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.KNHFAHFCCBK_SnsItem;
														if(HAAJGNCFNJM_ItemName != "sns_item")
														{
															cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem;
															if(HAAJGNCFNJM_ItemName != "energy_item")
															{
																cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.CLMIJKACELE_EventTicket;
																if(HAAJGNCFNJM_ItemName != "event_ticket")
																{
																	cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal;
																	if(HAAJGNCFNJM_ItemName != "medal")
																	{
																		cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.IGIFMNJADEC_MvTicket;
																		if(HAAJGNCFNJM_ItemName != "mv_ticket")
																		{
																			cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.LLFAAOHPMIC_EventGachaTicket;
																			if(HAAJGNCFNJM_ItemName != "event_gacha_ticket")
																			{
																				cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.DLBHNNOHLMM_PresentItem;
																				if(HAAJGNCFNJM_ItemName != "present_item")
																				{
																					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem;
																					if(HAAJGNCFNJM_ItemName != "sp_item")
																					{
																						cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.NEIIGCODGBA_CostumeItem;
																						if(HAAJGNCFNJM_ItemName != "cos_item")
																						{
																							cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.CIOGEKJNMBB_RareUpItem;
																							if(HAAJGNCFNJM_ItemName != "rareup_item")
																							{
																								cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.DLOPEFGOAPD_LimitedItem;
																								if(HAAJGNCFNJM_ItemName != "limited_item")
																								{
																									cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.PJCJEOECLBK_MonthlyPassItem;
																									if(HAAJGNCFNJM_ItemName != "monthly_pass")
																									{
																										cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg;
																										if(HAAJGNCFNJM_ItemName != "deco_bg")
																										{
																											cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj;
																											if(HAAJGNCFNJM_ItemName != "deco_obj")
																											{
																												cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara;
																												if(HAAJGNCFNJM_ItemName != "deco_chara")
																												{
																													cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif;
																													if(HAAJGNCFNJM_ItemName != "deco_serif")
																													{
																														cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp;
																														if(HAAJGNCFNJM_ItemName != "deco_sp")
																														{
																															cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.OOMMOOIIPJE_DecoItemPoster;
																															if (HAAJGNCFNJM_ItemName != "deco_poster")
																															{
																																cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.MABCLBNIOFA_ValkyrieItem;
																																if(HAAJGNCFNJM_ItemName != "val_item")
																																{
																																	cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.ICJOEDJECAP_DecoSetItem;
																																	if (HAAJGNCFNJM_ItemName != "deco_set_item")
																																	{
																																		cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.CFLFPPDMFAE_RaidItem;
																																		if (HAAJGNCFNJM_ItemName != "raid_item")
																																		{
																																			if (HAAJGNCFNJM_ItemName != "event_raid_item")
																																			{
																																				cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.CKCPFLDGILD_LimitedCompoItem;
																																				if (HAAJGNCFNJM_ItemName != "limited_compo_item")
																																				{
																																					if (HAAJGNCFNJM_ItemName == "home_bg_item")
																																					{
																																						cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.HGDPIAFBCGA_HomeBg;
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
		NNFNGLJOKKF_ItemId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(OCNINMIMHGC_item_value);
		JJBGOIMEIPF_ItemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(NPPNDDMPFJJ_ItemCategory, NNFNGLJOKKF_ItemId);
	}

	// // RVA: 0xAAC0E8 Offset: 0xAAC0E8 VA: 0xAAC0E8
	public void ODDIHGPONFL_Copy(GJDFHLBONOL GPBJHKLFCEP)
	{
		MDPJFPHOPCH_Id = GPBJHKLFCEP.MDPJFPHOPCH_Id;
		LJGOOOMOMMA_message = GPBJHKLFCEP.LJGOOOMOMMA_message;
		HAAJGNCFNJM_ItemName = GPBJHKLFCEP.HAAJGNCFNJM_ItemName;
		OCNINMIMHGC_item_value = GPBJHKLFCEP.OCNINMIMHGC_item_value;
		MBJIFDBEDAC_item_count = GPBJHKLFCEP.MBJIFDBEDAC_item_count;
		MJBKGOJBPAD_item_type = GPBJHKLFCEP.MJBKGOJBPAD_item_type;
		INDDJNMPONH_Type = GPBJHKLFCEP.INDDJNMPONH_Type;
		BIOGKIEECGN_CreatedAt = GPBJHKLFCEP.BIOGKIEECGN_CreatedAt;
		EGBOHDFBAPB_ClosedAt = GPBJHKLFCEP.EGBOHDFBAPB_ClosedAt;
		LNDEFMALKAN_received_at = GPBJHKLFCEP.LNDEFMALKAN_received_at;
		JJBGOIMEIPF_ItemId = GPBJHKLFCEP.JJBGOIMEIPF_ItemId;
		NPPNDDMPFJJ_ItemCategory = GPBJHKLFCEP.NPPNDDMPFJJ_ItemCategory;
		NNFNGLJOKKF_ItemId = GPBJHKLFCEP.NNFNGLJOKKF_ItemId;
		EILKGEADKGH_Order = GPBJHKLFCEP.EILKGEADKGH_Order;
	}

	// // RVA: 0xAAC2C4 Offset: 0xAAC2C4 VA: 0xAAC2C4
	// public void GELFIONIBEB(EDOHBJAPLPF _IDLHJIOMJBK_Data) { }
}
