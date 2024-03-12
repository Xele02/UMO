using XeApp.Game.Menu;
using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys;
using mcrs;

public class PopupItemListItemIcon : FlexibleListItemLayout
{
	[SerializeField]
	private RawImageEx[] m_itemIconImage; // 0x18
	[SerializeField]
	private Text[] m_countText; // 0x1C
	[SerializeField]
	private StayButton[] m_stayButton; // 0x20
	private PopupItemUseConfirmSetting m_limitedItemPopSetting = new PopupItemUseConfirmSetting(); // 0x24

	// RVA: 0xDFA040 Offset: 0xDFA040 VA: 0xDFA040 Slot: 5
	public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
	{
		for(int i = 0; i < m_countText.Length; i++)
		{
			m_countText[i].horizontalOverflow = HorizontalWrapMode.Wrap;
			m_countText[i].verticalOverflow = VerticalWrapMode.Truncate;
			m_countText[i].resizeTextForBestFit = true;
		}
		return true;
	}

	//// RVA: 0xDFA18C Offset: 0xDFA18C VA: 0xDFA18C
	public void UpdateContent(int id, int count, int index = 0)
	{
		MessageBank bk = MessageManager.Instance.GetBank("menu");
		MenuScene.Instance.ItemTextureCache.Load(id, (IiconTexture texture) =>
		{
			//0xDFB264
			texture.Set(m_itemIconImage[index]);
		});
		m_stayButton[index].ClearOnClickCallback();
		m_stayButton[index].AddOnClickCallback(() =>
		{
			//0xDFB390
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			ShowItemDetailBranch(id, count);
		});
		m_stayButton[index].ClearOnStayCallback();
		m_stayButton[index].AddOnStayCallback(() =>
		{
			//0xDFB418
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			ShowItemDetailBranch(id, count);
		});
		m_countText[index].text = string.Format(bk.GetMessageByLabel("item_popup_text_00"), count);
	}

	//// RVA: 0xDFA620 Offset: 0xDFA620 VA: 0xDFA620
	private void ShowItemDetailBranch(int id, int count)
	{
		EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem;
		if (count != 0)
			cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(id);
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		int limitTime = 0;
		if (cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.CIOGEKJNMBB_RareUpItem)
		{
			limitTime = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DPNKPPBEAGJ_RareUpItem.JCJKKMECCFI(time);
		}
		else if (cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.CKCPFLDGILD_LimitedCompoItem)
		{
			limitTime = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.GJCOJBDOOJG_LimitedCompoItem.BLKPKBICPKK(EKLNMHFCAOI.DEACAHNLMNI_getItemId(id), time);
			int t = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MBAGKLJDKMH_LimitedCompoItem.OCMMLAOEPIG[EKLNMHFCAOI.DEACAHNLMNI_getItemId(id) - 1].EMIJNAFJFJO;
			if (limitTime < time || t == 0)
				ShowItemDetail(id, count);
			else
				ShowLimitedItemDetali(id, limitTime, count);
			return;
		}
		else if (cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.DLOPEFGOAPD_LimitedItem)
		{
			limitTime = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.AFHFIPLOKMN_LimitedItem.BLKPKBICPKK(EKLNMHFCAOI.DEACAHNLMNI_getItemId(id), time);
		}
		else
		{
			ShowItemDetail(id, count);
			return;
		}
		if (limitTime < time)
			ShowItemDetail(id, count);
		else
			ShowLimitedItemDetali(id, limitTime, count);
	}

	//// RVA: 0xDF9B80 Offset: 0xDF9B80 VA: 0xDF9B80
	public static void ShowItemDetail(int itemId, int count)
	{
		ButtonInfo[] btns = new ButtonInfo[1]
		{
			new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
		};
		AODFBGCCBPE viewShopData = null;
		if (MenuScene.Instance != null)
		{
			if(MenuScene.Instance.GetCurrentScene().name == TransitionList.Type.OPTION_MENU)
			{
				if(CheckGrowItemData(itemId))
				{
					btns = new ButtonInfo[2]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative },
						new ButtonInfo() { Label = PopupButton.ButtonLabel.PlateGrowth, Type = PopupButton.ButtonType.Positive }
					};
				}
				else
				{
					viewShopData = CheckItemShopData(itemId);
					if(viewShopData != null)
					{
						btns = new ButtonInfo[2]
						{
							new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative },
							new ButtonInfo() { Label = PopupButton.ButtonLabel.ExchangeOffices, Type = PopupButton.ButtonType.Positive }
						};
					}
				}
			}
		}
		MenuScene.Instance.ShowItemDetail(itemId, count, btns, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
		{
			//0xDFB4A0
			if(label == PopupButton.ButtonLabel.ExchangeOffices)
			{
				PopupWindowManager.Close(control, null);
				MenuScene.Instance.Mount(TransitionUniqueId.OPTIONMENU_SHOP_SHOPPRODUCT, new ShopProductScene.ShopProductArgs() { view = viewShopData }, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
			}
			else if(label == PopupButton.ButtonLabel.PlateGrowth)
			{
				PopupWindowManager.Close(control, null);
				MenuScene.Instance.Mount(TransitionUniqueId.SETTINGMENU_SCENEABILITYRELEASELIST, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
			}
		});
	}

	//// RVA: 0xDFAA44 Offset: 0xDFAA44 VA: 0xDFAA44
	public void ShowLimitedItemDetali(int _itemId, int _limitTime, int _itemCount)
	{
		MessageBank bk = MessageManager.Instance.GetBank("menu");
		m_limitedItemPopSetting.SetParent(transform);
		m_limitedItemPopSetting.TypeItemId = _itemId;
		m_limitedItemPopSetting.Period = _limitTime;
		m_limitedItemPopSetting.OwnCount = _itemCount;
		m_limitedItemPopSetting.TitleText = bk.GetMessageByLabel("item_detail_popup_title_00");
		m_limitedItemPopSetting.OverrideText = EKLNMHFCAOI.INCKKODFJAP_GetItemName(_itemId);
		m_limitedItemPopSetting.WindowSize = SizeType.Middle;
		m_limitedItemPopSetting.HideUseNum = true;
		m_limitedItemPopSetting.Buttons = new ButtonInfo[1]
		{
			new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
		};
		PopupWindowManager.Show(m_limitedItemPopSetting, (PopupWindowControl cont, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
		{
			//0xDFB230
			return;
		}, null, null, null);
	}

	//// RVA: 0xDFAE94 Offset: 0xDFAE94 VA: 0xDFAE94
	private static bool CheckGrowItemData(int itemId)
	{
		return EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(itemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.HLCHKCJLEGK_GrowItem;
	}

	//// RVA: 0xDFAF28 Offset: 0xDFAF28 VA: 0xDFAF28
	private static AODFBGCCBPE CheckItemShopData(int costItemId)
	{
		AODFBGCCBPE d = AODFBGCCBPE.FKDIMODKKJD(false).Find((AODFBGCCBPE x) =>
		{
			//0xDFB234
			return x.INDDJNMPONH_Type == AODFBGCCBPE.NJMPLEENNPO.FNLODOLMLML_3;
		});
		if(d != null)
		{
			for(int i = 0; i < d.MHKCPJDNJKI.Count; i++)
			{
				if(d.MHKCPJDNJKI[i].JPJMHLNOIAJ_ItemCostFullId == costItemId)
					return d;
			}
		}
		return null;
	}
}
