using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutResultRaidHeaderTitle : LayoutUGUIScriptBase
	{
		public enum TitleType
		{
			Raid = 0,
		}

		private AbsoluteLayout layoutRoot; // 0x14
		public Action onFinished; // 0x18
		private Rect m_titleUv; // 0x1C
		private RawImageEx[] m_titleImage; // 0x2C

		// RVA: 0x1D0EA3C Offset: 0x1D0EA3C VA: 0x1D0EA3C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			layoutRoot = layout.FindViewById("sw_midasi_in_anim") as AbsoluteLayout;
			m_titleUv = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData("g_r_midasi_03"));
			RawImageEx[] imgs = transform.GetComponentsInChildren<RawImageEx>(true);
			m_titleImage = imgs.Where((RawImageEx _) =>
			{
				//0x1D0F028
				return _.name.StartsWith("g_r_midasi (ImageView)");
			}).ToArray();
			for(int i = 0; i < m_titleImage.Length; i++)
			{
				m_titleImage[i].uvRect = m_titleUv;
			}
			Loaded();
			return true;
		}

		// // RVA: 0x1D0ED98 Offset: 0x1D0ED98 VA: 0x1D0ED98
		public void StartBeginAnim()
		{
			layoutRoot.StartChildrenAnimGoStop("go_in", "st_in");
			this.StartCoroutineWatched(Co_PlayingStartPopupAnim());
		}

		// RVA: 0x1D0EEC8 Offset: 0x1D0EEC8 VA: 0x1D0EEC8
		public void StartAlreadyAnim()
		{
			layoutRoot.StartChildrenAnimLoop("logo_act", "loen_act");
		}

		// // RVA: 0x1D0EF54 Offset: 0x1D0EF54 VA: 0x1D0EF54
		// public void SkipAnim() { }

		// [IteratorStateMachineAttribute] // RVA: 0x71D66C Offset: 0x71D66C VA: 0x71D66C
		// // RVA: 0x1D0EE3C Offset: 0x1D0EE3C VA: 0x1D0EE3C
		private IEnumerator Co_PlayingStartPopupAnim()
		{
			//0x1D0F0C4
			yield return new WaitWhile(() =>
			{
				//0x1D0EF80
				return layoutRoot.IsPlayingChildren();
			});
			StartAlreadyAnim();
			if(onFinished != null)
				onFinished();
		}
	}
}
