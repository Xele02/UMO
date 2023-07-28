using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using XeSys;

namespace XeApp.Game.Menu
{
	public class DivaGrowthTabListWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton[] m_tabButtons; // 0x14
		[SerializeField]
		private SwapScrollList m_scrollList; // 0x18
		[SerializeField]
		private RawImageEx[] m_logImages; // 0x1C
		[SerializeField]
		private OnDivaGrowthPushTabActionEvent m_onPushTabActionEvent; // 0x20
		[SerializeField]
		private Text m_noClearText; // 0x24
		private StringBuilder m_strBuilder = new StringBuilder(64); // 0x28
		private AbsoluteLayout[] m_tabButtonAnimeLayout; // 0x2C

		//public OnDivaGrowthPushTabActionEvent OnPushTabActionEvent { get; } 0x17E07D0

		// RVA: 0x17E07D8 Offset: 0x17E07D8 VA: 0x17E07D8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_tabButtonAnimeLayout = new AbsoluteLayout[m_tabButtons.Length];
			for(int i = 0; i < m_tabButtons.Length; i++)
			{
				m_strBuilder.Clear();
				m_strBuilder.AppendFormat("sw_chk_diva_sres_tab_all_tab_{0:D2}", i + 1);
				m_tabButtonAnimeLayout[i] = layout.FindViewByExId(m_strBuilder.ToString()) as AbsoluteLayout;
				int index = i;
				m_tabButtons[i].AddOnClickCallback(() =>
				{
					//0x17E12C0
					OnTabButton(index);
					m_onPushTabActionEvent.Invoke(index);
				});
			}
			int a = 4;
			for(int i = 0; i < m_logImages.Length / 2; i++)
			{
				if (a < 1)
					a = 11;
				int index = i;
				MenuScene.Instance.MenuResidentTextureCache.LoadLogo(a, (IiconTexture texture) =>
				{
					//0x17E1378
					texture.Set(m_logImages[index * 2]);
					texture.Set(m_logImages[index * 2 + 1]);
				});
				a--;
			}
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_noClearText.text = bk.GetMessageByLabel("diva_musiclevel_nocleartext");
			RawImageEx[] imgs = GetComponentsInChildren<RawImageEx>();
			for(int i = 0; i < imgs.Length; i++)
			{
				if (imgs[i].name == "cmn_winl_list_grad (ImageView)")
				{
					imgs[i].raycastTarget = false;
				}
			}
			ClearLoadedCallback();
			return true;
		}

		//// RVA: 0x17E0E80 Offset: 0x17E0E80 VA: 0x17E0E80
		//public void ScrollUpdateEvent(UnityAction<int, SwapScrollListContent> updateEvent) { }

		//// RVA: 0x17E0F60 Offset: 0x17E0F60 VA: 0x17E0F60
		//public void AddScrollItem(DivaGrowthListItem item) { }

		//// RVA: 0x17E0F94 Offset: 0x17E0F94 VA: 0x17E0F94
		//public void ResetScrollItem() { }

		//// RVA: 0x17E0FE8 Offset: 0x17E0FE8 VA: 0x17E0FE8
		public void SetItemCount(int count)
		{
			TodoLogger.Log(0, "SetItemCount");
		}

		//// RVA: 0x17E10A8 Offset: 0x17E10A8 VA: 0x17E10A8
		private void ResetTabButton()
		{
			for(int i = 0; i < m_tabButtonAnimeLayout.Length; i++)
			{
				m_tabButtonAnimeLayout[i].StartChildrenAnimGoStop("01");
			}
		}

		//// RVA: 0x17E1184 Offset: 0x17E1184 VA: 0x17E1184
		public void OnTabButton(int index)
		{
			ResetTabButton();
			m_tabButtonAnimeLayout[index].StartChildrenAnimGoStop("02");
		}
	}
}
