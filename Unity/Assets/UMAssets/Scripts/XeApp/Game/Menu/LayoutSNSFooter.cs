using System.Collections;
using System.Collections.Generic;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutSNSFooter : LayoutUGUIScriptBase
	{
		public enum eIconType
		{
			Dummy = 0,
			Hyphen = 1,
			Writing = 2,
			End = 3,
			None = 4,
		}

		private AbsoluteLayout m_root; // 0x14
		private AbsoluteLayout m_iconTbl; // 0x18
		private AbsoluteLayout m_writingAnim; // 0x1C
		private AbsoluteLayout m_endAnim; // 0x20
		private List<IEnumerator> m_animList = new List<IEnumerator>(4); // 0x24

		//// RVA: 0x1D1D520 Offset: 0x1D1D520 VA: 0x1D1D520
		//public void SetStatus() { }

		//// RVA: 0x1D1D524 Offset: 0x1D1D524 VA: 0x1D1D524
		public void SetIconEnd(bool isPlayAnim = false)
		{
			SwitchIcon(eIconType.End);
			if(m_endAnim != null)
			{
				if(isPlayAnim)
				{
					m_endAnim.StartAllAnimGoStop("go_in", "st_in");
				}
				else
				{
					m_endAnim.StartAllAnimGoStop("st_stop");
				}
			}
		}

		//// RVA: 0x1D1D690 Offset: 0x1D1D690 VA: 0x1D1D690
		public void SetIconNone()
		{
			SwitchIcon(eIconType.None);
		}

		//// RVA: 0x1D1D698 Offset: 0x1D1D698 VA: 0x1D1D698
		public void SetIconHyphen()
		{
			SwitchIcon(eIconType.Hyphen);
		}

		//// RVA: 0x1D1D5D8 Offset: 0x1D1D5D8 VA: 0x1D1D5D8
		public void SwitchIcon(eIconType type)
		{
			if(m_iconTbl != null)
			{
				string s = ((int)type).ToString("D2");
				m_iconTbl.StartChildrenAnimGoStop(s, s);
			}
		}

		// RVA: 0x1D1D6A0 Offset: 0x1D1D6A0 VA: 0x1D1D6A0
		public void Update()
		{
			for(int i = 0; i < m_animList.Count; i++)
			{
				if(m_animList[i] != null)
				{
					if(m_animList[i].MoveNext() == false)
					{
						m_animList[i] = null;
					}
				}
			}
		}

		//// RVA: 0x1D1D884 Offset: 0x1D1D884 VA: 0x1D1D884
		public bool IsPlayingWriting()
		{
			if (m_writingAnim != null)
				return m_writingAnim.IsPlaying();
			return false;
		}

		//// RVA: 0x1D1D89C Offset: 0x1D1D89C VA: 0x1D1D89C
		public void WritingWait()
		{
			SwitchIcon(eIconType.Writing);
			if (m_writingAnim != null)
				m_writingAnim.StartChildrenAnimGoStop("st_wait");
		}

		//// RVA: 0x1D1D918 Offset: 0x1D1D918 VA: 0x1D1D918
		public void WritingIn()
		{
			if (m_writingAnim == null)
				return;
			m_writingAnim.StartChildrenAnimGoStop("go_in", "st_in");
			m_animList.Clear();
			m_animList.Add(WaitAnimWritingIn());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x727A44 Offset: 0x727A44 VA: 0x727A44
		//// RVA: 0x1D1DA00 Offset: 0x1D1DA00 VA: 0x1D1DA00
		private IEnumerator WaitAnimWritingIn()
		{
			//0x1932528
			while (IsPlayingWriting())
				yield return null;
			Loop();
		}

		//// RVA: 0x1D1DA88 Offset: 0x1D1DA88 VA: 0x1D1DA88
		public void WritingOut()
		{
			if (m_writingAnim == null)
				return;
			m_animList.Clear();
			m_writingAnim.StartChildrenAnimGoStop("go_out", "st_out");
			m_animList.Add(WaitAnimWritingOut());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x727ABC Offset: 0x727ABC VA: 0x727ABC
		//// RVA: 0x1D1DB88 Offset: 0x1D1DB88 VA: 0x1D1DB88
		private IEnumerator WaitAnimWritingOut()
		{
			//0x193266C
			while (IsPlayingWriting())
				yield return null;
		}

		//// RVA: 0x1D1DC10 Offset: 0x1D1DC10 VA: 0x1D1DC10
		private void Loop()
		{
			m_writingAnim.StartChildrenAnimLoop("logo_act", "loen_act");
		}

		// RVA: 0x1D1DC90 Offset: 0x1D1DC90 VA: 0x1D1DC90
		public void Reset()
		{
			return;
		}

		//// RVA: 0x1D1DC94 Offset: 0x1D1DC94 VA: 0x1D1DC94
		public void In()
		{
			if (m_root == null)
				return;
			gameObject.SetActive(true);
			m_root.StartChildrenAnimGoStop("go_in", "st_in");
			SwitchIcon(eIconType.None);
		}

		//// RVA: 0x1D1DD68 Offset: 0x1D1DD68 VA: 0x1D1DD68
		public void Out()
		{
			if (m_root == null)
				return;
			m_root.StartChildrenAnimGoStop("go_out", "st_out");
			m_animList.Clear();
			m_animList.Add(WaitAnimOut());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x727B34 Offset: 0x727B34 VA: 0x727B34
		//// RVA: 0x1D1DE50 Offset: 0x1D1DE50 VA: 0x1D1DE50
		private IEnumerator WaitAnimOut()
		{
			//0x19323E0
			while (IsPlaying())
				yield return null;
			SwitchIcon(eIconType.None);
		}

		//// RVA: 0x1D1DED8 Offset: 0x1D1DED8 VA: 0x1D1DED8
		//public void Hide() { }

		//// RVA: 0x1D1DF4C Offset: 0x1D1DF4C VA: 0x1D1DF4C
		public bool IsPlaying()
		{
			if (m_root != null)
				return m_root.IsPlayingChildren();
			return false;
		}

		// RVA: 0x1D1DF64 Offset: 0x1D1DF64 VA: 0x1D1DF64 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_root = layout.Root[0] as AbsoluteLayout;
			m_iconTbl = layout.FindViewByExId("sw_sns_btm_grad_transition_anim_swtbl_sns_btm_msg") as AbsoluteLayout;
			m_writingAnim = layout.FindViewByExId("swtbl_sns_btm_msg_sw_sns_writing_anim") as AbsoluteLayout;
			m_endAnim = layout.FindViewByExId("swtbl_sns_btm_msg_sw_sns_end_anim") as AbsoluteLayout;
			m_root.StartChildrenAnimGoStop("st_out");
			Loaded();
			return true;
		}
	}
}
