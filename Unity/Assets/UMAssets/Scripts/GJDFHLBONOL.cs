
public class GJDFHLBONOL
{
	private const int LMLBOHALKOM = 31536000;
	public long MDPJFPHOPCH_Id; // 0x8
	public string LJGOOOMOMMA_Message; // 0x10
	public string HAAJGNCFNJM_ItemName; // 0x14
	public int OCNINMIMHGC_ItemValue; // 0x18
	public int MBJIFDBEDAC_ItemCount; // 0x1C
	public int MJBKGOJBPAD_ItemType; // 0x20
	public int INDDJNMPONH_Type; // 0x24
	public long BIOGKIEECGN_CreatedAt; // 0x28
	public long EGBOHDFBAPB_ClosedAt; // 0x30
	public bool BGOJPEJJJFB_IsAvaiable; // 0x38
	public long EILKGEADKGH_Order; // 0x40
	public long LNDEFMALKAN_ReceivedAt; // 0x48
	public int JJBGOIMEIPF_ItemFullId; // 0x50
	public EKLNMHFCAOI.FKGCBLHOOCL_Category NPPNDDMPFJJ_ItemCategory; // 0x54
	public int NNFNGLJOKKF_ItemId; // 0x58
	public bool ILMMOGBDIME; // 0x5C
	public bool AIFBJHNBPMH; // 0x5D
	public bool MBFGLMEECOO; // 0x5E

	// // RVA: 0xAAB4C8 Offset: 0xAAB4C8 VA: 0xAAB4C8
	// public bool JLFHLOCONEE() { }

	// // RVA: 0xAAB4D0 Offset: 0xAAB4D0 VA: 0xAAB4D0
	public void DPKCOKLMFMK(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
	{
		MDPJFPHOPCH_Id = CEDHHAGBIBA.NIKODNFGCEM_ReadLong(IDLHJIOMJBK, AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id);
		LJGOOOMOMMA_Message = CEDHHAGBIBA.BNCLNFJHEND_ReadString(IDLHJIOMJBK, AFEHLCGHAEE_Strings.LJGOOOMOMMA_message);
		HAAJGNCFNJM_ItemName = CEDHHAGBIBA.BNCLNFJHEND_ReadString(IDLHJIOMJBK, AFEHLCGHAEE_Strings.HAAJGNCFNJM_item_name);
		OCNINMIMHGC_ItemValue = CEDHHAGBIBA.GNJBKANDLEE_ReadInt(IDLHJIOMJBK, AFEHLCGHAEE_Strings.OCNINMIMHGC_item_value);
		MJBKGOJBPAD_ItemType = CEDHHAGBIBA.GNJBKANDLEE_ReadInt(IDLHJIOMJBK, AFEHLCGHAEE_Strings.MJBKGOJBPAD_item_type);
		MBJIFDBEDAC_ItemCount = CEDHHAGBIBA.GNJBKANDLEE_ReadInt(IDLHJIOMJBK, AFEHLCGHAEE_Strings.MBJIFDBEDAC_item_count);
		INDDJNMPONH_Type = CEDHHAGBIBA.GNJBKANDLEE_ReadInt(IDLHJIOMJBK, AFEHLCGHAEE_Strings.INDDJNMPONH_type);
		BIOGKIEECGN_CreatedAt = CEDHHAGBIBA.NIKODNFGCEM_ReadLong(IDLHJIOMJBK, AFEHLCGHAEE_Strings.BIOGKIEECGN_created_at);
		EGBOHDFBAPB_ClosedAt = CEDHHAGBIBA.NIKODNFGCEM_ReadLong(IDLHJIOMJBK, AFEHLCGHAEE_Strings.EGBOHDFBAPB_closed_at);
		LNDEFMALKAN_ReceivedAt = CEDHHAGBIBA.NIKODNFGCEM_ReadLong(IDLHJIOMJBK, AFEHLCGHAEE_Strings.LNDEFMALKAN_received_at);
		EILKGEADKGH_Order = CEDHHAGBIBA.NIKODNFGCEM_ReadLong(IDLHJIOMJBK, "order");
		BGOJPEJJJFB_IsAvaiable = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime() + 31536000 < EGBOHDFBAPB_ClosedAt;
		if(MJBKGOJBPAD_ItemType == 2)
		{
			NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.FKGCBLHOOCL_Category.HJNNKCMLGFL_None;
		}
		else
		{
			int val = OCNINMIMHGC_ItemValue;
			int id;
			EKLNMHFCAOI.FKGCBLHOOCL_Category cat;
			if(MJBKGOJBPAD_ItemType == 1)
			{
				if(val < 3001)
				{
					if(val < 2001 || val == 3000)
					{
						//LAB_00aabf7c
						id = 1;
						cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC;
						NNFNGLJOKKF_ItemId = 1;
						OCNINMIMHGC_ItemValue = 1;
						NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC;
					}
					else
					{
						if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GKMAHADAAFI_GachaTicket.DHIACJMOEBH.Contains(OCNINMIMHGC_ItemValue))
						{
							cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.OBHECJMAEIO_GachaTicket;
							NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.FKGCBLHOOCL_Category.OBHECJMAEIO_GachaTicket;
							id = OCNINMIMHGC_ItemValue - 2000;
						}
						else
						{
							cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC;
							NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC;
							id = OCNINMIMHGC_ItemValue - 1996;
						}
						OCNINMIMHGC_ItemValue = id;
						NNFNGLJOKKF_ItemId = id;
					}
				}
				else if(val < 4000)
				{
					cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC;
					id = val - 3000;
					NNFNGLJOKKF_ItemId = id;
					OCNINMIMHGC_ItemValue = id;
					NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC;
				}
				else
				{
					if(val != 5001)
					{
						id = 1;
						cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC;
						NNFNGLJOKKF_ItemId = 1;
						OCNINMIMHGC_ItemValue = 1;
						NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC;
					}
					else
					{
						OCNINMIMHGC_ItemValue = 9;
						NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC;
						NNFNGLJOKKF_ItemId = 9;
						JJBGOIMEIPF_ItemFullId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC, 9);
						id = OCNINMIMHGC_ItemValue;
						cat = NPPNDDMPFJJ_ItemCategory;
					}
				}
				JJBGOIMEIPF_ItemFullId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(cat, id);
				return;
			}
			if(val > 9999)
			{
				JJBGOIMEIPF_ItemFullId = val;
				NPPNDDMPFJJ_ItemCategory = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(val);
				NNFNGLJOKKF_ItemId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(OCNINMIMHGC_ItemValue);
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
								if(HAAJGNCFNJM_ItemName != AFEHLCGHAEE_Strings.GJODJNIHKKF_epi_item)
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
		NNFNGLJOKKF_ItemId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(OCNINMIMHGC_ItemValue);
		JJBGOIMEIPF_ItemFullId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(NPPNDDMPFJJ_ItemCategory, NNFNGLJOKKF_ItemId);
	}

	// // RVA: 0xAAC0E8 Offset: 0xAAC0E8 VA: 0xAAC0E8
	public void ODDIHGPONFL(GJDFHLBONOL GPBJHKLFCEP)
	{
		MDPJFPHOPCH_Id = GPBJHKLFCEP.MDPJFPHOPCH_Id;
		LJGOOOMOMMA_Message = GPBJHKLFCEP.LJGOOOMOMMA_Message;
		HAAJGNCFNJM_ItemName = GPBJHKLFCEP.HAAJGNCFNJM_ItemName;
		OCNINMIMHGC_ItemValue = GPBJHKLFCEP.OCNINMIMHGC_ItemValue;
		MBJIFDBEDAC_ItemCount = GPBJHKLFCEP.MBJIFDBEDAC_ItemCount;
		MJBKGOJBPAD_ItemType = GPBJHKLFCEP.MJBKGOJBPAD_ItemType;
		INDDJNMPONH_Type = GPBJHKLFCEP.INDDJNMPONH_Type;
		BIOGKIEECGN_CreatedAt = GPBJHKLFCEP.BIOGKIEECGN_CreatedAt;
		EGBOHDFBAPB_ClosedAt = GPBJHKLFCEP.EGBOHDFBAPB_ClosedAt;
		LNDEFMALKAN_ReceivedAt = GPBJHKLFCEP.LNDEFMALKAN_ReceivedAt;
		JJBGOIMEIPF_ItemFullId = GPBJHKLFCEP.JJBGOIMEIPF_ItemFullId;
		NPPNDDMPFJJ_ItemCategory = GPBJHKLFCEP.NPPNDDMPFJJ_ItemCategory;
		NNFNGLJOKKF_ItemId = GPBJHKLFCEP.NNFNGLJOKKF_ItemId;
		EILKGEADKGH_Order = GPBJHKLFCEP.EILKGEADKGH_Order;
	}

	// // RVA: 0xAAC2C4 Offset: 0xAAC2C4 VA: 0xAAC2C4
	// public void GELFIONIBEB(EDOHBJAPLPF IDLHJIOMJBK) { }
}
