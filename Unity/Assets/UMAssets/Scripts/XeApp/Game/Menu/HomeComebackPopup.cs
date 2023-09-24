using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using mcrs;
using System.Collections;
using XeSys;
using System.Text;
using System;

namespace XeApp.Game.Menu
{
	public class HomeComebackPopup : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_buttonClose; // 0x14
		[SerializeField]
		private Text m_textMissionCount; // 0x18
		[SerializeField]
		private RawImageEx m_image; // 0x1C
		[SerializeField]
		private LayoutUGUIHitOnly m_touchBlocker; // 0x20
		private AbsoluteLayout m_layoutRoot; // 0x24
		private bool m_isOpen; // 0x28

		public bool IsOpen { get; }

		//[IteratorStateMachineAttribute] // RVA: 0x6E21BC Offset: 0x6E21BC VA: 0x6E21BC
		//// RVA: 0x95FD98 Offset: 0x95FD98 VA: 0x95FD98
		public IEnumerator Co_Open(HomeBannerTextureCache textureCache, int imageId, int totalCount, int clearCount)
		{
			//0x960520
			if (m_isOpen)
				yield break;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			StringBuilder str = new StringBuilder();
			str.SetFormat(bk.GetMessageByLabel("popup_comeback_mission_count"), clearCount, totalCount);
			m_textMissionCount.text = str.ToString();
			textureCache.LoadForMission(imageId, (IiconTexture texture) =>
			{
				//0x9601C4
				texture.Set(m_image);
			});
			while (textureCache.IsLoading())
				yield return null;
			PopupWindowControl.PlayPopupWindowOpenSe(PopupWindowControl.SeType.WindowOpen, SoundManager.Instance.sePlayerBoot);
			m_layoutRoot.StartChildrenAnimGoStop("go_in", "st_in");
			yield return Co.R(WaitAnim(m_layoutRoot));
			m_isOpen = true;
			while (m_isOpen)
				yield return null;
			yield return Co.R(Co_Leave(null));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E2234 Offset: 0x6E2234 VA: 0x6E2234
		//// RVA: 0x95FEB0 Offset: 0x95FEB0 VA: 0x95FEB0
		private IEnumerator Co_Leave(Action callback)
		{
			//0x96030C
			m_layoutRoot.StartChildrenAnimGoStop("go_out", "st_out");
			yield return Co.R(WaitAnim(m_layoutRoot));
			PopupWindowControl.PlayPopupWindowOpenSe(PopupWindowControl.SeType.WindowClose, SoundManager.Instance.sePlayerBoot);
			if (callback != null)
				callback();
			m_isOpen = false;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E22AC Offset: 0x6E22AC VA: 0x6E22AC
		//// RVA: 0x95FF78 Offset: 0x95FF78 VA: 0x95FF78
		public IEnumerator WaitAnim(AbsoluteLayout layout)
		{
			//0x9609BC
			while (layout.IsPlayingChildren())
				yield return null;
		}

		// RVA: 0x960024 Offset: 0x960024 VA: 0x960024 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_layoutRoot = layout.FindViewById("sw_home_mission_window_inout_anim") as AbsoluteLayout;
			m_layoutRoot.StartChildrenAnimGoStop("st_out");
			m_buttonClose.ClearOnClickCallback();
			m_buttonClose.AddOnClickCallback(() =>
			{
				//0x9602A4
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				m_isOpen = false;
			});
			Loaded();
			return true;
		}
	}
}
