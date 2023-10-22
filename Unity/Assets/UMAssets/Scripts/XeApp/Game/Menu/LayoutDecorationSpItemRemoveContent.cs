using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using XeSys;
using System.Collections.Generic;
using mcrs;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationSpItemRemoveContent : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text[] m_texts; // 0x14
		[SerializeField]
		private RawImageEx[] m_iconImage; // 0x18
		[SerializeField]
		private StayButton[] m_stayButton; // 0x1C
		private AbsoluteLayout m_iconPatternLayout; // 0x20

		// RVA: 0x18BB000 Offset: 0x18BB000 VA: 0x18BB000 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_iconPatternLayout = layout.FindViewByExId("deco_pop_m_03_all_swtbl_cmn_item_pop_03") as AbsoluteLayout;
			ClearLoadedCallback();
			return true;
		}

		// RVA: 0x18BB0D8 Offset: 0x18BB0D8 VA: 0x18BB0D8
		public void SetMessage(bool isReplaceRoom)
		{
			m_texts[0].text = MessageManager.Instance.GetMessage("menu", isReplaceRoom ? "pop_deco_sp_item_remove_message_001" : "pop_deco_sp_item_remove_message_002");
			m_texts[1].text = MessageManager.Instance.GetMessage("menu", "pop_deco_sp_item_remove_message_003");
		}

		// RVA: 0x18BB2A8 Offset: 0x18BB2A8 VA: 0x18BB2A8
		public void SetIcon(List<int> itemList)
		{
			for(int i = 0; i < itemList.Count && i <= 2; i++)
			{
				int index = i;
				int itemId = itemList[i];
				MenuScene.Instance.ItemTextureCache.Load(itemList[i], (IiconTexture texture) =>
				{
					//0x18BB860
					texture.Set(m_iconImage[index]);
				});
				m_stayButton[i].ClearOnClickCallback();
				m_stayButton[i].ClearOnStayCallback();
				m_stayButton[i].AddOnClickCallback(() =>
				{
					//0x18BB98C
					ShowItemDetails(itemId);
				});
				m_stayButton[i].AddOnStayCallback(() =>
				{
					//0x18BB9B8
					ShowItemDetails(itemId);
				});
			}
			m_iconPatternLayout.StartChildrenAnimGoStop(itemList.Count.ToString("00"));
		}

		// RVA: 0x18BB754 Offset: 0x18BB754 VA: 0x18BB754
		private void ShowItemDetails(int itemId)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			MenuScene.Instance.ShowItemDetail(itemId, 0, null);
		}
	}
}
