using XeSys.Gfx;
using UnityEngine;
using System.Collections;
using XeApp.Game.Common;
using mcrs;
using System;

namespace XeApp.Game.Menu
{
	public class OfferSortieLayout : LayoutUGUIScriptBase
	{
		private AbsoluteLayout m_layoutRoot; // 0x14
		[SerializeField]
		private RectTransform m_ValAnimRect; // 0x18
		private bool IsLeave; // 0x1C
		public bool IsSortieEnd; // 0x1D

		// RVA: 0x1710A34 Offset: 0x1710A34 VA: 0x1710A34
		private void Start()
		{
			return;
		}

		// RVA: 0x1710A38 Offset: 0x1710A38 VA: 0x1710A38
		private void Update()
		{
			return;
		}

		// RVA: 0x1710A3C Offset: 0x1710A3C VA: 0x1710A3C
		public void AnimStart()
		{ 
			IsLeave = false;
			IsSortieEnd = false;
			m_layoutRoot.StartChildrenAnimGoStop("go_act", "st_act");
			this.StartCoroutineWatched(ValkyrieAnimObservation());
			this.StartCoroutineWatched(StartAnimEnd(() =>
			{
				//0x1710F58
				AnimLoop();
			}));
		}

		// // RVA: 0x1710C70 Offset: 0x1710C70 VA: 0x1710C70
		public void AnimLoop()
		{
			IsSortieEnd = true;
			m_layoutRoot.StartChildrenAnimGoStop("logo_act");
		}

		// RVA: 0x1710CF4 Offset: 0x1710CF4 VA: 0x1710CF4
		public void AnimLeave()
		{
			IsLeave = true;
			m_layoutRoot.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6FC64C Offset: 0x6FC64C VA: 0x6FC64C
		// // RVA: 0x1710BC8 Offset: 0x1710BC8 VA: 0x1710BC8
		private IEnumerator StartAnimEnd(Action act)
		{
			//0x1710F60
			yield return null;
			while(m_layoutRoot.IsPlayingChildren())
			{
				if(IsLeave)
					yield break;
				yield return null;
			}
			yield return null;
			act();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6FC6C4 Offset: 0x6FC6C4 VA: 0x6FC6C4
		// // RVA: 0x1710B3C Offset: 0x1710B3C VA: 0x1710B3C
		private IEnumerator ValkyrieAnimObservation()
		{
			//0x17110F4
			yield return null;
			while(!m_ValAnimRect.gameObject.activeInHierarchy)
				yield return null;
			SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_UNLOCK_002);
		}

		// RVA: 0x1710DC8 Offset: 0x1710DC8 VA: 0x1710DC8
		public void Hide()
		{
			m_layoutRoot.StartChildrenAnimGoStop("st_wait");
		}

		// RVA: 0x1710E44 Offset: 0x1710E44 VA: 0x1710E44
		public bool IsPlaying()
		{
			return m_layoutRoot.IsPlayingChildren();
		}

		// RVA: 0x1710E70 Offset: 0x1710E70 VA: 0x1710E70 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.FindViewByExId("root_sortie_vfo_sw_sortie_vfo_anim") as AbsoluteLayout;
			Hide();
			Loaded();
			return true;
		}
	}
}
