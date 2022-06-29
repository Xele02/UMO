using XeSys.Gfx;
using System.Collections;

namespace XeApp.Game.Title
{
	public class LayoutTitleScreen : LayoutUGUIScriptBase
	{
		private AbsoluteLayout m_root; // 0x14
		private IEnumerator m_animUpdate; // 0x18

		// // RVA: 0xE3A874 Offset: 0xE3A874 VA: 0xE3A874
		// public void SetStatus() { }

		// // RVA: 0xE3A878 Offset: 0xE3A878 VA: 0xE3A878
		// public void Reset() { }

		// // RVA: 0xE3A87C Offset: 0xE3A87C VA: 0xE3A87C
		public void TapAnim()
		{
			m_root.StartAllAnimGoStop("go_bot_decide", "st_bot_decide");
		}

		// // RVA: 0xE365F0 Offset: 0xE365F0 VA: 0xE365F0
		public void Show()
		{
			m_root.StartAllAnimGoStop("go_in_logo", "st_in_logo");
			m_animUpdate = WaitEnterAnim();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6B3AB8 Offset: 0x6B3AB8 VA: 0x6B3AB8
		// // RVA: 0xE3A8FC Offset: 0xE3A8FC VA: 0xE3A8FC
		private IEnumerator WaitEnterAnim()
		{
			//0xE3AC28
			while(true)
			{
				if(!m_root.IsPlayingChildren())
				{
					m_root.StartAllAnimLoop("logo_act_01", "loen_act_01");
					m_root.StartAllAnimLoop("logo_bot", "loen_bot");
					yield break;
				}
				yield return null;
			}
		}

		// // RVA: 0xE3A9A8 Offset: 0xE3A9A8 VA: 0xE3A9A8
		// public void Hide() { }

		// // RVA: 0xE3AA28 Offset: 0xE3AA28 VA: 0xE3AA28
		private void Update()
		{
			if(m_animUpdate != null)
			{
				if(!m_animUpdate.MoveNext())
				{
					m_animUpdate = null;
				}
			}
		}

		// // RVA: 0xE3AB04 Offset: 0xE3AB04 VA: 0xE3AB04 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_root = layout.Root[0] as AbsoluteLayout;
			m_root.StartAllAnimGoStop("st_wait_logo");
			Loaded();
			return true;
		}
	}
}
