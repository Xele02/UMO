using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using System.Collections;
using mcrs;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutPopupLoginBonusPackList : LayoutPopupLoginBonusPackListBase, IPopupContent
	{
		public enum Type
		{
			GetItem = 0,
			GetPack = 1,
			GetRarityUp = 2,
			GetGachaTicket = 3,
		}

		[SerializeField]
		private LayoutUGUIRuntime m_runtime; // 0x24
		[SerializeField]
		private RawImageEx m_imageItem; // 0x28
		[SerializeField]
		private RawImageEx m_imageFrameBtm; // 0x2C
		[SerializeField]
		private RawImageEx m_imageOmake; // 0x30
		[SerializeField]
		private NumberBase m_numberCount; // 0x34
		[SerializeField]
		private Text m_textName; // 0x38
		[SerializeField]
		private Text m_textDesc; // 0x3C
		[SerializeField]
		private Text m_textOmake; // 0x40
		private AbsoluteLayout m_layoutRoot; // 0x44
		private AbsoluteLayout[] m_layoutTelopTable = new AbsoluteLayout[2]; // 0x48
		private AbsoluteLayout m_layoutTelop; // 0x4C
		private AbsoluteLayout m_layoutOmake; // 0x50
		private bool m_isTelop; // 0x54
		private PopupLoginBonusPackSetting m_setting; // 0x58
		private Matrix23 m_identity; // 0x64

		public Type LayoutType { get; private set; } // 0x5C
		public Transform Parent { get; private set; } // 0x60

		// RVA: 0x17306B4 Offset: 0x17306B4 VA: 0x17306B4 Slot: 7
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			m_setting = setting as PopupLoginBonusPackSetting;
			Parent = setting.m_parent;
			(transform as RectTransform).sizeDelta = size;
			(transform as RectTransform).anchoredPosition = Vector2.zero;
			Setup(m_setting);
		}

		//// RVA: 0x17310E0 Offset: 0x17310E0 VA: 0x17310E0 Slot: 6
		protected override void OnUpdateListItem(int index, SwapScrollListContent content)
		{
			LayoutPopupLoginBonusPackItem l = content as LayoutPopupLoginBonusPackItem;
			if(l != null)
			{
				System.Collections.Generic.List<MFDJIFIIPJD> list = m_setting.Data.HBHMAKNGKFK_Items;
				l.Setup(m_setting.Data.HBHMAKNGKFK_Items[index]);
				l.OnClickButton = () =>
				{
					//0x1732708
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					OnShowItemDetails(list[index]);
				};
			}
		}

		//// RVA: 0x17312EC Offset: 0x17312EC VA: 0x17312EC
		private void OnShowItemDetails(MFDJIFIIPJD info)
		{
			if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(info.JJBGOIMEIPF_ItemId) != EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
			{
				MenuScene.Instance.ShowItemDetail(info.JJBGOIMEIPF_ItemId, info.MBJIFDBEDAC_Cnt, null);
			}
			else
			{
				GCIJNCFDNON_SceneInfo data = new GCIJNCFDNON_SceneInfo();
				data.KHEKNNFCAOI(EKLNMHFCAOI.DEACAHNLMNI_getItemId(info.JJBGOIMEIPF_ItemId), null, null, 0, 0, 0, false, 0, 0);
				MenuScene.Instance.ShowSceneStatusPopupWindow(data, GameManager.Instance.ViewPlayerData, false, TransitionList.Type.UNDEFINED, null, true, true, 0, false);
			}
		}

		// RVA: 0x1731588 Offset: 0x1731588 VA: 0x1731588 Slot: 8
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1731590 Offset: 0x1731590 VA: 0x1731590 Slot: 9
		public void Show()
		{
			gameObject.SetActive(true);
			this.StartCoroutineWatched(Co_Show());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70584C Offset: 0x70584C VA: 0x70584C
		//// RVA: 0x17315E4 Offset: 0x17315E4 VA: 0x17315E4
		private IEnumerator Co_Show()
		{
			//0x17327F8
			yield return null;
			ShowTelop();
		}

		// RVA: 0x1731690 Offset: 0x1731690 VA: 0x1731690 Slot: 10
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x17316C8 Offset: 0x17316C8 VA: 0x17316C8 Slot: 11
		public bool IsReady()
		{
			return !IsLoading();
		}

		// RVA: 0x1731798 Offset: 0x1731798 VA: 0x1731798 Slot: 12
		public void CallOpenEnd()
		{
			return;
		}

		// RVA: 0x173179C Offset: 0x173179C VA: 0x173179C
		public void InitLayoutType(CAEDGOPBDNK data)
		{
			LayoutType = Type.GetPack;
			if(data.HBHMAKNGKFK_Items.Count < 2)
			{
				LayoutType = Type.GetRarityUp;
				if(data.HBHMAKNGKFK_Items[0].NPPNDDMPFJJ_ItemCategory != EKLNMHFCAOI.FKGCBLHOOCL_Category.CIOGEKJNMBB_RareUpItem)
				{
					LayoutType = Type.GetItem;
					if (data.HBHMAKNGKFK_Items[0].NPPNDDMPFJJ_ItemCategory == EKLNMHFCAOI.FKGCBLHOOCL_Category.OBHECJMAEIO_GachaTicket)
						LayoutType = Type.GetGachaTicket;
				}
			}
		}

		//// RVA: 0x1730838 Offset: 0x1730838 VA: 0x1730838
		public void Setup(PopupLoginBonusPackSetting setting)
		{
			m_isTelop = setting.IsTelop;
			switch(LayoutType)
			{
				case Type.GetItem:
					m_layoutRoot.StartChildrenAnimGoStop("02");
					m_layoutTelop = m_layoutTelopTable[0];
					break;
				case Type.GetPack:
					m_layoutRoot.StartChildrenAnimGoStop("01");
					m_layoutTelop = m_layoutTelopTable[0];
					break;
				case Type.GetRarityUp:
					m_layoutRoot.StartChildrenAnimGoStop("03");
					m_layoutTelop = m_layoutTelopTable[1];
					break;
				case Type.GetGachaTicket:
					m_layoutRoot.StartChildrenAnimGoStop("06");
					m_layoutTelop = m_layoutTelopTable[0];
					break;
			}
			m_layoutRoot.UpdateAllAnimation(2 * TimeWrapper.deltaTime, false);
			m_layoutRoot.UpdateAll(m_identity, Color.white);
			SetupList(setting.Data.HBHMAKNGKFK_Items.Count, true);
			if(setting.Data.HBHMAKNGKFK_Items.Count == 1)
			{
				int itemId = setting.Data.HBHMAKNGKFK_Items[0].JJBGOIMEIPF_ItemId;
				GameManager.Instance.ItemTextureCache.Load(itemId, (IiconTexture image) =>
				{
					//0x1732500
					m_imageItem.enabled = true;
					image.Set(m_imageItem);
				});
				EKLNMHFCAOI.FKGCBLHOOCL_Category cat = setting.Data.HBHMAKNGKFK_Items[0].NPPNDDMPFJJ_ItemCategory;
				int id = setting.Data.HBHMAKNGKFK_Items[0].NNFNGLJOKKF_ItemId;
				m_textName.text = string.Format("{0}  {1}{2}", EKLNMHFCAOI.INCKKODFJAP_GetItemName(cat, id), setting.Data.HBHMAKNGKFK_Items[0].MBJIFDBEDAC_Cnt, EKLNMHFCAOI.NDBLEADIDLA(cat, id));
				m_textDesc.text = EKLNMHFCAOI.ILKGBGOCLAO_GetItemDesc(cat, id);
				m_numberCount.SetNumber(setting.Data.HBHMAKNGKFK_Items[0].MBJIFDBEDAC_Cnt, 0);
			}
			if (setting.SpItems == null || setting.SpItems.Count < 1)
			{
				m_layoutOmake.StartChildrenAnimGoStop("02");
			}
			else
			{
				int itemId = setting.SpItems[0].JJBGOIMEIPF_ItemId;
				GameManager.Instance.ItemTextureCache.Load(itemId, (IiconTexture image) =>
				{
					//0x1732604
					m_imageOmake.enabled = true;
					image.Set(m_imageOmake);
				});
				EKLNMHFCAOI.FKGCBLHOOCL_Category cat = setting.SpItems[0].NPPNDDMPFJJ_ItemCategory;
				int id = setting.SpItems[0].NNFNGLJOKKF_ItemId;
				m_textOmake.text = string.Format(MessageManager.Instance.GetMessage("menu", "pop_pass_loginbonus_caution"), EKLNMHFCAOI.INCKKODFJAP_GetItemName(cat, id), setting.SpItems[0].MBJIFDBEDAC_Cnt, EKLNMHFCAOI.NDBLEADIDLA(cat, id));
				m_textOmake.horizontalOverflow = HorizontalWrapMode.Wrap;
				m_textOmake.verticalOverflow = VerticalWrapMode.Truncate;
				m_textOmake.resizeTextForBestFit = true;
				m_layoutOmake.StartChildrenAnimGoStop("01");
			}
		}

		// RVA: 0x1731A60 Offset: 0x1731A60 VA: 0x1731A60
		public void SetScrollResize(Vector2 scrollSize)
		{
			SetScrollResize(scrollSize, m_imageFrameBtm);
		}

		//// RVA: 0x17316DC Offset: 0x17316DC VA: 0x17316DC
		public bool IsLoading()
		{
			return KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning || !IsLoaded();
		}

		//// RVA: 0x1731DF0 Offset: 0x1731DF0 VA: 0x1731DF0
		public void ShowTelop()
		{
			if (!m_isTelop)
				return;
			m_layoutTelop.StartChildrenAnimGoStop("go_in", "st_in");
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_004);
			m_runtime.StartCoroutineWatched(Co_ShowTelopAnim());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7058C4 Offset: 0x7058C4 VA: 0x7058C4
		//// RVA: 0x1731F04 Offset: 0x1731F04 VA: 0x1731F04
		private IEnumerator Co_ShowTelopAnim()
		{
			//0x17328F4
			yield return Co.R(Co_WaitAnim(m_layoutTelop));
			m_layoutTelop.StartChildrenAnimGoStop("logo_up", "loen_up");
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70593C Offset: 0x70593C VA: 0x70593C
		//// RVA: 0x1731FB0 Offset: 0x1731FB0 VA: 0x1731FB0
		private IEnumerator Co_WaitAnim(AbsoluteLayout layout)
		{
			//0x1732AA0
			while (layout.IsPlayingChildren())
				yield return null;
		}

		// RVA: 0x173205C Offset: 0x173205C VA: 0x173205C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.FindViewById("swtbl_adv_login_pop_ttl") as AbsoluteLayout;
			m_layoutTelopTable[0] = layout.FindViewById("sw_adv_login_pop_ttl_01_anim") as AbsoluteLayout;
			m_layoutTelopTable[0].StartChildrenAnimGoStop("st_wait");
			m_layoutTelopTable[1] = layout.FindViewById("sw_adv_login_pop_ttl_02_anim") as AbsoluteLayout;
			m_layoutTelopTable[1].StartChildrenAnimGoStop("st_wait");
			m_layoutOmake = layout.FindViewById("sw_skip_ticket_onoff_anim") as AbsoluteLayout;
			Loaded();
			return true;
		}
	}
}
