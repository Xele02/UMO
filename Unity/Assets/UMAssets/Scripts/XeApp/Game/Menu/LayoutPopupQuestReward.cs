using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutPopupQuestReward : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_itemName; // 0x14
		[SerializeField]
		private RawImageEx m_icon; // 0x18
		private bool m_isLoadingIcon; // 0x1C
		private AbsoluteLayout m_root; // 0x20
		private AbsoluteLayout m_changeHeader; // 0x24

		// RVA: 0x177822C Offset: 0x177822C VA: 0x177822C
		public void SetStatus(MFDJIFIIPJD itemInfo)
		{
			SetIcon(itemInfo.JJBGOIMEIPF_ItemId);
			ChangeHeader(itemInfo.NPPNDDMPFJJ_ItemCategory);
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(itemInfo.NPPNDDMPFJJ_ItemCategory == EKLNMHFCAOI.FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit)
			{
				SetItemText(itemInfo.MBJIFDBEDAC_Cnt.ToString() + EKLNMHFCAOI.NDBLEADIDLA(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(itemInfo.JJBGOIMEIPF_ItemId), 0));
			}
			else
			{
				SetItemText(EKLNMHFCAOI.INCKKODFJAP_GetItemName(itemInfo.JJBGOIMEIPF_ItemId) + JpStringLiterals.StringLiteral_12037 + itemInfo.MBJIFDBEDAC_Cnt.ToString() + EKLNMHFCAOI.NDBLEADIDLA(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(itemInfo.JJBGOIMEIPF_ItemId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(itemInfo.JJBGOIMEIPF_ItemId)));
			}
		}

		// RVA: 0x17786C4 Offset: 0x17786C4 VA: 0x17786C4
		public bool IsLoading()
		{
			return m_isLoadingIcon || KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning;
		}

		// RVA: 0x1778770 Offset: 0x1778770 VA: 0x1778770
		public void Reset()
		{
			return;
		}

		// RVA: 0x1778774 Offset: 0x1778774 VA: 0x1778774
		public void Show()
		{
			if(m_root != null)
				m_root.StartAllAnimGoStop("go_in", "st_in");
		}

		// RVA: 0x17787F4 Offset: 0x17787F4 VA: 0x17787F4
		public void Hide()
		{
			if(m_root != null)
				m_root.StartAllAnimGoStop("go_out", "st_out");
		}

		// // RVA: 0x1778400 Offset: 0x1778400 VA: 0x1778400
		public void SetIcon(int iconId)
		{
			m_isLoadingIcon = false;
			if(m_icon != null)
			{
				m_isLoadingIcon = true;
				GameManager.Instance.ItemTextureCache.Load(iconId, (IiconTexture texture) =>
				{
					//0x1778A24
					if(texture != null)
					{
						texture.Set(m_icon);
					}
					m_isLoadingIcon = false;
				});
			}
		}

		// // RVA: 0x1778604 Offset: 0x1778604 VA: 0x1778604
		public void SetItemText(string text)
		{
			if(m_itemName != null)
			{
				m_itemName.text = text;
			}
		}

		// // RVA: 0x1778568 Offset: 0x1778568 VA: 0x1778568
		public void ChangeHeader(EKLNMHFCAOI.FKGCBLHOOCL_Category itemType)
		{
			m_changeHeader.StartChildrenAnimGoStop(itemType > EKLNMHFCAOI.FKGCBLHOOCL_Category.HJNNKCMLGFL_None && itemType <= EKLNMHFCAOI.FKGCBLHOOCL_Category.OBHECJMAEIO_GachaTicket ? "02" : "01");
		}

		// RVA: 0x1778874 Offset: 0x1778874 VA: 0x1778874 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_root = layout.Root[0] as AbsoluteLayout;
			m_root.StartAllAnimGoStop("st_wait");
			SetItemText("");
			m_changeHeader = layout.FindViewByExId("sw_sel_que_achieve_swtbl_sel_que_get_fnt") as AbsoluteLayout;
			Loaded();
			return true;
		}
	}
}
