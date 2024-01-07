using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using mcrs;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class LayoutPopupAddEpisodeScrollItemList : LayoutUGUIScriptBase
	{
		[SerializeField]
		private SwapScrollList m_scrollList; // 0x14
		private AbsoluteLayout m_fontAnim; // 0x18
		private PopupAddEpisodeContentSetting m_setting; // 0x1C
		private bool m_isOpenItemPopup; // 0x20

		public SwapScrollList ScrollList { get { return m_scrollList; } } //0x15E7C88

		// RVA: 0x15E7C90 Offset: 0x15E7C90 VA: 0x15E7C90 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_fontAnim = layout.FindViewByExId("sw_pop_ep2_all_sw_pop_ep_fnt_03_anim") as AbsoluteLayout;
			Loaded();
			ClearLoadedCallback();
			return true;
		}

		// RVA: 0x15E7D74 Offset: 0x15E7D74 VA: 0x15E7D74
		public void Setup(PopupAddEpisodeContentSetting setting)
		{
			m_setting = setting;
			for(int i = 0; i < m_scrollList.ScrollObjects.Count; i++)
			{
				(m_scrollList.ScrollObjects[i] as LayoutPopupAddEpisodeScrollItem).OnclickAddEpisode += (int episodeId, LayoutPopupAddEpisode.Type type) =>
				{
					//0x15E83E0
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					m_setting.EpisodeId = episodeId;
					m_setting.Type = type;
					ShowPopupAddEpisode();
				};
			}
		}

		// RVA: 0x15E8048 Offset: 0x15E8048 VA: 0x15E8048
		public void Show()
		{
			StringIn();
			this.StartCoroutineWatched(Co_AnimInWait());
		}

		// // RVA: 0x15E8074 Offset: 0x15E8074 VA: 0x15E8074
		private void StringIn()
		{
			m_fontAnim.StartAllAnimGoStop("go_in", "st_in");
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_003);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x70B87C Offset: 0x70B87C VA: 0x70B87C
		// // RVA: 0x15E8140 Offset: 0x15E8140 VA: 0x15E8140
		private IEnumerator Co_AnimInWait()
		{
			//0x15E8524
			while(m_fontAnim.IsPlayingChildren())
				yield return null;
			m_fontAnim.StartAllAnimLoop("logo_up", "loen_up");
		}

		// // RVA: 0x15E81EC Offset: 0x15E81EC VA: 0x15E81EC
		private void ShowPopupAddEpisode()
		{
			if(!m_isOpenItemPopup)
			{
				m_isOpenItemPopup = true;
				PopupWindowManager.Show(m_setting, (PopupWindowControl control, PopupButton.ButtonType buttonType, PopupButton.ButtonLabel buttonLabel) =>
				{
					//0x15E8494
					m_isOpenItemPopup = false;
				}, null, () =>
				{
					//0x15E851C
					return;
				}, null);
			}
		}
	}
}
