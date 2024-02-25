using System.Collections;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class UnlockValkyrieLogo : LayoutUGUIScriptBase
	{
		private AbsoluteLayout m_Anim; // 0x14
		private bool m_IsEntered; // 0x18
		private Transform m_Mask; // 0x1C

		// RVA: 0x164D6C4 Offset: 0x164D6C4 VA: 0x164D6C4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_Anim = layout.FindViewById("sw_ul_logo_anim") as AbsoluteLayout;
			m_Mask = transform.Find("sw_ul_logo_anim (AbsoluteLayout)/mask (MaskView)");
			Loaded();
			return true;
		}

		// // RVA: 0x164D7DC Offset: 0x164D7DC VA: 0x164D7DC
		// public bool IsPlaying() { }

		// RVA: 0x164D808 Offset: 0x164D808 VA: 0x164D808
		public bool IsEntered()
		{
			return m_IsEntered;
		}

		// RVA: 0x164D810 Offset: 0x164D810 VA: 0x164D810
		public void ResetAnim()
		{
			m_IsEntered = false;
			m_Anim.StartAllAnimGoStop("st_wait");
			m_Mask.gameObject.SetActive(false);
		}

		// RVA: 0x164D8D8 Offset: 0x164D8D8 VA: 0x164D8D8
		public void Enter()
		{
			m_Mask.gameObject.SetActive(true);
			this.StartCoroutineWatched(Co_Enter());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x732884 Offset: 0x732884 VA: 0x732884
		// // RVA: 0x164D944 Offset: 0x164D944 VA: 0x164D944
		private IEnumerator Co_Enter()
		{
			//0x164DA04
			m_IsEntered = false;
			m_Anim.StartAllAnimGoStop("go_in", "st_in");
			yield return null;
			yield return new WaitWhile(() =>
			{
				//0x164D9FC
				return m_Anim.IsPlayingAll();
			});
			m_Anim.StartAllAnimLoop("logo_up", "loen_up");
			m_IsEntered = true;
		}

		// RVA: 0x164D9F0 Offset: 0x164D9F0 VA: 0x164D9F0
		public void Update()
		{
			return;
		}
	}
}
