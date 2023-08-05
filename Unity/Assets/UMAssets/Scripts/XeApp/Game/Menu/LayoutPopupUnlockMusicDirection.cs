using XeSys.Gfx;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

namespace XeApp.Game.Menu
{
	public class LayoutPopupUnlockMusicDirection : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx m_musicJacket; // 0x14
		private AbsoluteLayout m_root; // 0x18
		private List<IEnumerator> m_animationList = new List<IEnumerator>(8); // 0x1C
		private bool m_isLoadingMusicJacket; // 0x2C

		public bool IsOpen { get; set; } // 0x20
		public bool IsClosed { get; set; } // 0x21
		public Action CallbackOpenEnd { get; set; } // 0x24
		public Action CallbackAnimEnd { get; set; } // 0x28

		//// RVA: 0x178BFAC Offset: 0x178BFAC VA: 0x178BFAC
		//public void SetStatus(PopupUnlock.UnlockInfo info) { }

		//// RVA: 0x178C090 Offset: 0x178C090 VA: 0x178C090
		//public bool IsLoading() { }

		//// RVA: 0x1791568 Offset: 0x1791568 VA: 0x1791568
		//public void SetMusicJacket(int jacketId) { }

		// RVA: 0x17916D0 Offset: 0x17916D0 VA: 0x17916D0
		private void Update()
		{
			if(m_animationList.Count > 0)
			{
				if(!m_animationList[0].MoveNext())
				{
					m_animationList.RemoveAt(0);
				}
			}
		}

		// RVA: 0x1791848 Offset: 0x1791848 VA: 0x1791848
		public void Reset()
		{
			return;
		}

		//// RVA: 0x178C13C Offset: 0x178C13C VA: 0x178C13C
		//public void Show() { }

		//// RVA: 0x178C290 Offset: 0x178C290 VA: 0x178C290
		//public void Hide() { }

		//[IteratorStateMachineAttribute] // RVA: 0x704A6C Offset: 0x704A6C VA: 0x704A6C
		//// RVA: 0x179184C Offset: 0x179184C VA: 0x179184C
		//private IEnumerator AnimInWait() { }

		//// RVA: 0x17918F8 Offset: 0x17918F8 VA: 0x17918F8
		public void Out()
		{
			m_root.StartChildrenAnimGoStop("go_out", "st_out");
			m_animationList.Add(AnimOutWait());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x704AE4 Offset: 0x704AE4 VA: 0x704AE4
		//// RVA: 0x17919B4 Offset: 0x17919B4 VA: 0x17919B4
		private IEnumerator AnimOutWait()
		{
			//0x1791DF4
			while (m_root.IsPlayingChildren())
				yield return null;
			if (CallbackAnimEnd != null)
				CallbackAnimEnd();
			IsOpen = false;
			IsClosed = true;
		}

		// RVA: 0x1791A60 Offset: 0x1791A60 VA: 0x1791A60 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_root = layout.Root[0] as AbsoluteLayout;
			Loaded();
			return true;
		}
		

		//[CompilerGeneratedAttribute] // RVA: 0x704B5C Offset: 0x704B5C VA: 0x704B5C
		//// RVA: 0x1791BDC Offset: 0x1791BDC VA: 0x1791BDC
		//private void <SetMusicJacket>b__22_0(IiconTexture texture) { }
	}
}
