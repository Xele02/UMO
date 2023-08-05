using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutPopupMusicGradeGetRewardList : LayoutUGUIScriptBase
	{
		[SerializeField]
		private LayoutUGUIRuntime m_runtime; // 0x14
		[SerializeField]
		private ScrollRect m_scrollRect; // 0x18
		[SerializeField]
		private Transform m_ScrollContent; // 0x1C
		[SerializeField]
		private Text m_textDesc1; // 0x20
		[SerializeField]
		private Text m_textDesc2; // 0x24
		private FlexibleItemScrollView m_fxScrollView; // 0x28
		private AbsoluteLayout m_layoutTitleAnim; // 0x2C

		public Transform GetScrollContent { get { return m_ScrollContent; } } //0x1733738
		public FlexibleItemScrollView FxScrollView { get { return m_fxScrollView; } } //0x1733740

		// RVA: 0x1733748 Offset: 0x1733748 VA: 0x1733748 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutTitleAnim = layout.FindViewById("sw_pop_reward_ev_title_01_anim") as AbsoluteLayout;
			m_fxScrollView = new FlexibleItemScrollView();
			m_fxScrollView.Initialize(m_scrollRect);
			Loaded();
			return true;
		}

		//// RVA: 0x1733868 Offset: 0x1733868 VA: 0x1733868
		public void Setup()
		{
			m_textDesc1.text = MessageManager.Instance.GetMessage("menu", "popup_music_rate_get_reward_desc_01");
			m_textDesc2.text = MessageManager.Instance.GetMessage("menu", "popup_music_rate_get_reward_desc_02");
			m_layoutTitleAnim.StartAllAnimGoStop("go_in", "st_in");
		}

		//// RVA: 0x17339FC Offset: 0x17339FC VA: 0x17339FC
		public bool IsPlayTitleAnime()
		{
			return m_layoutTitleAnim.IsPlayingChildren();
		}

		//// RVA: 0x1733A28 Offset: 0x1733A28 VA: 0x1733A28
		public void StartTitleLoop()
		{
			m_layoutTitleAnim.StartAllAnimLoop("logo_up", "loen_up");
		}
	}
}
