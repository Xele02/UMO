using System;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class ItemTextureCache : IconTextureCache
	{
		// RVA: 0x14BD444 Offset: 0x14BD444 VA: 0x14BD444
		public ItemTextureCache() : base(40)
		{
			return;
		}

		// // RVA: 0x14BD450 Offset: 0x14BD450 VA: 0x14BD450 Slot: 5
		public override void Terminated()
		{
			Clear();
		}

		// // RVA: 0x14BD458 Offset: 0x14BD458 VA: 0x14BD458 Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			ItemTexture tex = new ItemTexture();
			SetupForSplitTexture(info, tex);
			return tex;
		}

		// // RVA: 0x14BD4E0 Offset: 0x14BD4E0 VA: 0x14BD4E0
		public void Load(int id, Action<IiconTexture> callBack)
		{
			Load(MakeItemIconTexturePath(id, 0), callBack);
		}

		// // RVA: 0x14BD918 Offset: 0x14BD918 VA: 0x14BD918
		public void Load(int id, int subId, Action<IiconTexture> callBack)
		{
			Load(MakeItemIconTexturePath(id, subId), callBack);
		}

		// // RVA: 0x14BD94C Offset: 0x14BD94C VA: 0x14BD94C
		public void LoadEmblem(int emblemId, Action<IiconTexture> callback)
		{
			Load(MakeEmblemIconTexturePath(emblemId), callback);
		}

		// // RVA: 0x14BDA14 Offset: 0x14BDA14 VA: 0x14BDA14
		public void TryInstallEmblem(int emblemId)
		{
			KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(MakeEmblemIconTexturePath(emblemId));
		}

		// // RVA: 0x14BDAC4 Offset: 0x14BDAC4 VA: 0x14BDAC4
		public void TryInstall(int id, int subId = 0)
		{
			KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(MakeItemIconTexturePath(id, subId));
		}

		// // RVA: 0x14BDB7C Offset: 0x14BDB7C VA: 0x14BDB7C
		private static int ConvertDegreeTexId(int itemId)
		{
			int a = EKLNMHFCAOI.DEACAHNLMNI_getItemId(itemId);
			return EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.MNCJMDDAFJB_EmblemItem, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBNBNAFGMDE_Emblem.CDENCMNHNGA_EmblemList[a - 1].HANMDEBPBHG_Pic);
		}

		// // RVA: 0x14BD984 Offset: 0x14BD984 VA: 0x14BD984
		public static string MakeEmblemIconTexturePath(int emblemId)
		{
			return MakeItemIconTexturePath(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.MNCJMDDAFJB_EmblemItem, emblemId), 0);
		}

		// // RVA: 0x14BD514 Offset: 0x14BD514 VA: 0x14BD514
		public static string MakeItemIconTexturePath(int id, int subId = 0)
		{
			EKLNMHFCAOI.FKGCBLHOOCL_Category val = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(id);
			int val2 = 0;
			if ((int)val < 6)
			{
				if (val != EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene/*4*/)
				{
					val2 = id;
					//switchD_014bd6ec_caseD_f
				}
				else
				{
					int val3 = EKLNMHFCAOI.DEACAHNLMNI_getItemId(id);
					if(val3 < 1)
					{
						//LAB_014bd7d8
						val2 = 40000;
						//switchD_014bd6ec_caseD_e
					}
					else
					{
						MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[val3 - 1];
						if(!dbScene.FBJDHLGODPP_Sngl)
						{
							subId = Mathf.Min(dbScene.EKLIPGELKCL_Rarity - 3, 3);
							//LAB_014bd7d8
							val2 = 40000;
							//switchD_014bd6ec_caseD_e
						}
						else
						{
							subId = 3;
							val2 = 40000;
							//LAB_014bd800
							return string.Format("ct/im/{0:D5}_{1:D2}.xab", val2, subId);
						}
					}
				}
			}
			else
			{
				if (val >= EKLNMHFCAOI.FKGCBLHOOCL_Category.OCMIGPEOFEG_GachaLimit || val < EKLNMHFCAOI.FKGCBLHOOCL_Category.KNHFAHFCCBK_SnsItem)
				{
					if (val != EKLNMHFCAOI.FKGCBLHOOCL_Category.MNCJMDDAFJB_EmblemItem)
					{
						//switchD_014bd6ec_caseD_f
						val2 = id;
					}
					else
					{
						val2 = ConvertDegreeTexId(id);
						//switchD_014bd6ec_caseD_e
					}
				}
				else
				{
					val2 = 140000;
					switch (val)
					{
						case EKLNMHFCAOI.FKGCBLHOOCL_Category.KNHFAHFCCBK_SnsItem:
							break;
						default:
							//switchD_014bd6ec_caseD_f
							val2 = id;
							break;
						case EKLNMHFCAOI.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg:
						case EKLNMHFCAOI.FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj:
						case EKLNMHFCAOI.FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara:
						case EKLNMHFCAOI.FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif:
						case EKLNMHFCAOI.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp:
							return MakeDecoItemIconTexturePath(id, subId);
						case EKLNMHFCAOI.FKGCBLHOOCL_Category.OOMMOOIIPJE_DecoItemPoster:
							return MakeDecoPosterIconTexturePath(id, 0);
						case EKLNMHFCAOI.FKGCBLHOOCL_Category.AEFGOANHNMG_DecoItemPosterSceneBef:
							return MakeDecoPosterIconTexturePath(id, 1);
						case EKLNMHFCAOI.FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft:
							//LAB_014bd8ac ivar5 = subId
							return MakeDecoPosterIconTexturePath(id, 2);
						case EKLNMHFCAOI.FKGCBLHOOCL_Category.HEMGMACMGAB_DecoItemVFFigure:
							{
								return MakeDecoVFFigureIconTexturePath(id, 456); // ??
							}
						case EKLNMHFCAOI.FKGCBLHOOCL_Category.NNBMEEPOBIO_DecoItemCostumeTorso:
							return MakeDecoCostumeTorsoIconTexturePath(id, 0);
						case EKLNMHFCAOI.FKGCBLHOOCL_Category.HGDPIAFBCGA_HomeBg:
							val2 = 430000;
							break;
					}
				}
			}
			//switchD_014bd6ec_caseD_e
			if (subId < 1)
			{
				return string.Format("ct/im/{0:D5}.xab", val2);
			}
			else
			{
				//LAB_014bd800
				return string.Format("ct/im/{0:D5}_{1:D2}.xab", val2, subId);
			}
		}

		// // RVA: 0x14BDCF8 Offset: 0x14BDCF8 VA: 0x14BDCF8
		public static string MakeDecoItemIconTexturePath(int id, int subId = 0)
		{
			EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(id);
			string path = "ct/im/" + MakeDecoItemDirectoryPath(cat);
			if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif)
			{
				return string.Format("{0}{1:D5}.xab", path, EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp.DMKMNGELNAE_Serif[EKLNMHFCAOI.DEACAHNLMNI_getItemId(id) - 1].GBJFNGCDKPM_FrameId));
			}
			else
			{
				if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg)
				{
					return string.Format("{0}{1:D5}_{2:D2}.xab", path, id, subId);
				}
				else
				{
					if(subId < 1)
						return string.Format("{0}{1:D5}.xab", path, id);
					return string.Format("{0}{1:D5}_{2:D2}.xab", path, id, subId);
				}
			}
		}

		// // RVA: 0x14BDFFC Offset: 0x14BDFFC VA: 0x14BDFFC
		public static string MakeDecoPosterIconTexturePath(int id, int subId = 0)
		{
			EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(id);
			int itemId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(id);
			string path = "ct/im/" + MakeDecoItemDirectoryPath(cat);
			if(cat != EKLNMHFCAOI.FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft)
			{
				if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.OOMMOOIIPJE_DecoItemPoster)
				{
					return string.Format("{0}{1:D6}.xab", path, id);
				}
				if (cat != EKLNMHFCAOI.FKGCBLHOOCL_Category.AEFGOANHNMG_DecoItemPosterSceneBef)
					return "";
			}
			return string.Format("{0}{1:D6}_{2:D2}.xab", path, itemId, subId);
		}

		// // RVA: 0x14BE294 Offset: 0x14BE294 VA: 0x14BE294
		public static string MakeDecoCostumeTorsoIconTexturePath(int id, int subId = 0)
		{
			EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(id);
			string path = "ct/im/" + MakeDecoItemDirectoryPath(cat);
			if (subId == 0)
				return string.Format("{0}{1:D6}.xab", path, id);
			else
				return string.Format("{0}{1:D6}_{0:D2}.xab", path, id, subId);
		}

		// // RVA: 0x14BE194 Offset: 0x14BE194 VA: 0x14BE194
		public static string MakeDecoVFFigureIconTexturePath(int id, int subId = 0)
		{
			EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(id);
			return string.Format("{0}{1:D6}.xab", "ct/im/" + MakeDecoItemDirectoryPath(cat), id);
		}

		// // RVA: 0x14BE3FC Offset: 0x14BE3FC VA: 0x14BE3FC
		private static string MakeDecoItemDirectoryPath(EKLNMHFCAOI.FKGCBLHOOCL_Category type)
		{
			if (type < EKLNMHFCAOI.FKGCBLHOOCL_Category.CKCPFLDGILD_LimitedCompoItem && type >= EKLNMHFCAOI.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg)
				return new string[]
				{
					"dc/bg/",
					"dc/it/",
					"dc/ch/",
					"dc/sf/",
					"dc/sp/",
					"",
					"",
					"dc/ps/",
					"dc/ps/",
					"dc/ps/",
					"",
					"",
					"",
					"",
					"dc/vl/",
					"dc/cs/"
				}[type - EKLNMHFCAOI.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg];
			else
				return "";
		}

	}
}
