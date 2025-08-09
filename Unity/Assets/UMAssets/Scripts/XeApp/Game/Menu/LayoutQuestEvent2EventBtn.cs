using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class LayoutQuestEvent2EventBtn : LayoutUGUIScriptBase
	{
		private AbsoluteLayout m_Anim; // 0x14
		[SerializeField]
		private ActionButton m_btn; // 0x18
		//[CompilerGeneratedAttribute] // RVA: 0x672EB4 Offset: 0x672EB4 VA: 0x672EB4
		public Action PushButtonListener; // 0x1C

		// RVA: 0x187158C Offset: 0x187158C VA: 0x187158C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_Anim = layout.FindViewById("sw_s_m_e_b_btn_inout_anim") as AbsoluteLayout;
			this.StartCoroutineWatched(Co_Initialize());
			m_btn.AddOnClickCallback(OnPushButton);
			return true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F1994 Offset: 0x6F1994 VA: 0x6F1994
		// // RVA: 0x18716CC Offset: 0x18716CC VA: 0x18716CC
		private IEnumerator Co_Initialize()
		{
			//0x18719D4
			m_Anim.StartChildrenAnimGoStop("st_wait");
			yield return null;
			Loaded();
		}

		// RVA: 0x1871778 Offset: 0x1871778 VA: 0x1871778
		public void Enter()
		{
			m_Anim.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// RVA: 0x1871804 Offset: 0x1871804 VA: 0x1871804
		public void Leave()
		{
			m_Anim.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// // RVA: 0x1871890 Offset: 0x1871890 VA: 0x1871890
		public void Hide()
		{
			m_Anim.StartChildrenAnimGoStop("st_out");
		}

		// RVA: 0x187190C Offset: 0x187190C VA: 0x187190C
		public bool IsPlaying()
		{
			return m_Anim.IsPlayingChildren();
		}

		// // RVA: 0x1871938 Offset: 0x1871938 VA: 0x1871938
		// public void Skip() { }

		// RVA: 0x18719B4 Offset: 0x18719B4 VA: 0x18719B4
		private void OnPushButton()
		{
			if(PushButtonListener != null)
				PushButtonListener();
		}
	}
}
