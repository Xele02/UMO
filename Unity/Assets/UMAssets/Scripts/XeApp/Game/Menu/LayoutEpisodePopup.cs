using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System;

namespace XeApp.Game.Menu
{
	public class LayoutEpisodePopup : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_EpisodeTitleText; // 0x14
		[SerializeField]
		private Text m_EpisodeDescText; // 0x18
		[SerializeField]
		private ActionButton m_EpisodeButton; // 0x1C
		[SerializeField]
		private RawImageEx m_EpisodeValkyrieImage; // 0x20
		private AbsoluteLayout m_EpisodePopAnim; // 0x24

		// RVA: 0x18C95D8 Offset: 0x18C95D8 VA: 0x18C95D8
		private void Start()
		{
			return;
		}

		// RVA: 0x18C95DC Offset: 0x18C95DC VA: 0x18C95DC
		private void Update()
		{
			return;
		}

		// // RVA: 0x18C95E0 Offset: 0x18C95E0 VA: 0x18C95E0
		public void SetEpisodeText(string title, string desc)
		{
			m_EpisodeTitleText.text = title;
			m_EpisodeDescText.text = desc;
		}

		// // RVA: 0x18C9650 Offset: 0x18C9650 VA: 0x18C9650
		public void SetEpisodeButtonCallback(Action callback)
		{
			m_EpisodeButton.AddOnClickCallback(() => {
				//0x18C9BB0
				callback();
			});
		}

		// // RVA: 0x18C9738 Offset: 0x18C9738 VA: 0x18C9738
		public void SetEpisodeValkyrieImage(int vfId, int Valform)
		{
			m_EpisodeValkyrieImage.enabled = false;
			MenuScene.Instance.ValkyrieIconCache.LoadPortraitIcon(vfId, Valform, (IiconTexture texture) => {
				//0x18C9AAC
				texture.Set(m_EpisodeValkyrieImage);
				m_EpisodeValkyrieImage.enabled = true;
			});
		}

		// // RVA: 0x18C9880 Offset: 0x18C9880 VA: 0x18C9880
		public void Enter()
		{
			m_EpisodePopAnim.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// // RVA: 0x18C990C Offset: 0x18C990C VA: 0x18C990C
		public void Leave()
		{
			m_EpisodePopAnim.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// // RVA: 0x18C9998 Offset: 0x18C9998 VA: 0x18C9998
		public bool IsPlaying()
		{
			return m_EpisodePopAnim.IsPlayingChildren();
		}

		// RVA: 0x18C99C4 Offset: 0x18C99C4 VA: 0x18C99C4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_EpisodePopAnim = layout.FindViewByExId("sw_val_terms_window_all_sw_val_terms_window_anim") as AbsoluteLayout;
			return base.InitializeFromLayout(layout, uvMan);
		}
	}
}
