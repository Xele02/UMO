using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;

namespace XeApp.Game.Menu
{
	public class MusicSelectLineButton : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton[] m_buttons; // 0x14
		[SerializeField]
		private RawImageEx[] m_frameImages; // 0x18
		[SerializeField]
		private RawImageEx[] m_textImages; // 0x1C
		[SerializeField]
		private RawImageEx[] m_bgImages; // 0x20
		[SerializeField]
		private NumberBase m_unlockNumber; // 0x24
		// private MusicSelectLineButton.Style m_style; // 0x28
		// private AbsoluteLayout m_rootAnim; // 0x2C
		// private AbsoluteLayout m_changeAnim; // 0x30
		// private AbsoluteLayout m_unlockAnim; // 0x34
		// private bool m_isEntered; // 0x38
		// private bool m_isUnlock; // 0x39

		public Action<int> onClickButton { private get; set; } // 0x3C

		// // RVA: 0x16780A0 Offset: 0x16780A0 VA: 0x16780A0
		// public void TryEnter(bool line6Mode) { }

		// // RVA: 0x1678154 Offset: 0x1678154 VA: 0x1678154
		public void TryLeave()
		{
			UnityEngine.Debug.LogError("TODO MusicSelectLineButton TryLeave");
		}

		// // RVA: 0x16780B0 Offset: 0x16780B0 VA: 0x16780B0
		public void Enter(bool line6Mode)
		{
			UnityEngine.Debug.LogError("TODO MusicSelectLineButton Enter");
		}

		// // RVA: 0x1678164 Offset: 0x1678164 VA: 0x1678164
		// public void Leave() { }

		// // RVA: 0x16782B8 Offset: 0x16782B8 VA: 0x16782B8
		// public void Show() { }

		// // RVA: 0x167833C Offset: 0x167833C VA: 0x167833C
		public void Hide()
		{
			UnityEngine.Debug.LogError("TODO MusicSelectLineButton Hide");
		}

		// // RVA: 0x16783C0 Offset: 0x16783C0 VA: 0x16783C0
		public bool IsPlaying()
		{
			UnityEngine.Debug.LogError("TODO MusicSelectLineButton IsPlaying");
			return false;
		}

		// // RVA: 0x167841C Offset: 0x167841C VA: 0x167841C
		public void SetUnlockNumber(int number)
		{
			UnityEngine.Debug.LogError("TODO MusicSelectLineButton SetUnlockNumber");
		}

		// // RVA: 0x167845C Offset: 0x167845C VA: 0x167845C
		public void SetUnlock(bool isUnlock)
		{
			UnityEngine.Debug.LogError("TODO MusicSelectLineButton SetUnlock");
		}

		// // RVA: 0x1678504 Offset: 0x1678504 VA: 0x1678504
		// private void SetOptionStyle(MusicSelectLineButton.Style style) { }

		// // RVA: 0x16781F8 Offset: 0x16781F8 VA: 0x16781F8
		// private void SetStyleAnim(MusicSelectLineButton.Style style) { }

		// // RVA: 0x167888C Offset: 0x167888C VA: 0x167888C
		// private void OnClickButton() { }

		// // RVA: 0x16789F4 Offset: 0x16789F4 VA: 0x16789F4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			UnityEngine.Debug.LogError("TODO InitializeFromLayout MusicSelectLineButton");
			return true;
		}
	}
}
