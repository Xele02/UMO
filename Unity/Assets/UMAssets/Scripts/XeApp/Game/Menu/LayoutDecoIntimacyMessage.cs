using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutDecoIntimacyMessage : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_textInfo; // 0x14
		[SerializeField]
		private Text m_textInfoLocked; // 0x18
		[SerializeField]
		private RawImageEx m_imageTipsWindow; // 0x1C
		[SerializeField]
		private RawImageEx m_imageTipsWindowLocked; // 0x20
		private AbsoluteLayout m_layoutRoot; // 0x24
		private AbsoluteLayout m_layoutInfo; // 0x28
		private AbsoluteLayout m_layoutInfoLocked; // 0x2C
		private AbsoluteLayout m_layoutColor; // 0x30
		private AbsoluteLayout m_layoutColorLocked; // 0x34
		private AbsoluteLayout m_layoutUsing; // 0x38
		private bool m_isOpen; // 0x3C
		private Coroutine m_coroutine; // 0x40

		// RVA: 0x19EAFD0 Offset: 0x19EAFD0 VA: 0x19EAFD0
		private void OnDisable()
		{
			if(m_coroutine != null)
			{
				this.StopCoroutineWatched(m_coroutine);
				m_coroutine = null;
				Hide();
			}
		}

		// // RVA: 0x19EB0B0 Offset: 0x19EB0B0 VA: 0x19EB0B0
		// public void SetTextLevelUpBonus(int divaId, string name, JJOELIOGMKK.LPBGKOJDNJK type, int param) { }

		// // RVA: 0x19EB34C Offset: 0x19EB34C VA: 0x19EB34C
		// public void SetTextSystem(int divaId, string text) { }

		// // RVA: 0x19EB420 Offset: 0x19EB420 VA: 0x19EB420
		// public void SetTextLock(int divaId, string text) { }

		// // RVA: 0x19EB528 Offset: 0x19EB528 VA: 0x19EB528
		// public void SetTextUnlock(int divaId, string text) { }

		// // RVA: 0x19EB630 Offset: 0x19EB630 VA: 0x19EB630
		// public void Enter() { }

		// // RVA: 0x19EB7FC Offset: 0x19EB7FC VA: 0x19EB7FC
		// public void Leave() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6D1284 Offset: 0x6D1284 VA: 0x6D1284
		// // RVA: 0x19EB864 Offset: 0x19EB864 VA: 0x19EB864
		// private IEnumerator Co_Leave() { }

		// // RVA: 0x19EB910 Offset: 0x19EB910 VA: 0x19EB910
		// public bool IsOpenWindow() { }

		// // RVA: 0x19EB918 Offset: 0x19EB918 VA: 0x19EB918
		// public void Show() { }

		// // RVA: 0x19EB008 Offset: 0x19EB008 VA: 0x19EB008
		public void Hide()
		{
			if(m_layoutUsing != null)
				m_layoutUsing.StartChildrenAnimGoStop("st_out");
			gameObject.SetActive(false);
			m_isOpen = false;
		}

		// RVA: 0x19EB9C0 Offset: 0x19EB9C0 VA: 0x19EB9C0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			TodoLogger.Log(0, "InitializeFromLayout");
			return true;
		}

		// [CompilerGeneratedAttribute] // RVA: 0x6D12FC Offset: 0x6D12FC VA: 0x6D12FC
		// // RVA: 0x19EBD08 Offset: 0x19EBD08 VA: 0x19EBD08
		// private bool <Co_Leave>b__19_0() { }
	}
}
