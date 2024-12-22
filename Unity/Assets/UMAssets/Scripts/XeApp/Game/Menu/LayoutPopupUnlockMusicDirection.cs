using XeSys.Gfx;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using XeApp.Game.Common;
using mcrs;

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
		public void SetStatus(PopupUnlock.UnlockInfo info)
		{
			EEDKAACNBBG_MusicData data = new EEDKAACNBBG_MusicData();
			data.KHEKNNFCAOI(info.param.id);
			SetMusicJacket(data.JNCPEGJGHOG_JacketId);
		}

		//// RVA: 0x178C090 Offset: 0x178C090 VA: 0x178C090
		public bool IsLoading()
		{
			return KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning || m_isLoadingMusicJacket;
		}

		//// RVA: 0x1791568 Offset: 0x1791568 VA: 0x1791568
		public void SetMusicJacket(int jacketId)
		{
			m_isLoadingMusicJacket = false;
			if(m_musicJacket == null)
				return;
			m_isLoadingMusicJacket = true;
			GameManager.Instance.MusicJacketTextureCache.Load(jacketId, (IiconTexture texture) =>
			{
				//0x1791BDC
				if(texture != null)
					texture.Set(m_musicJacket);
				m_isLoadingMusicJacket = false;
			});
		}

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
		public void Show()
		{
			if(m_root == null)
				return;
			if(IsOpen)
				return;
			IsOpen = true;
			IsClosed = false;
			m_root.StartChildrenAnimGoStop("go_in", "st_in");
			SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_STORY_003);
			m_animationList.Clear();
			m_animationList.Add(AnimInWait());
		}

		//// RVA: 0x178C290 Offset: 0x178C290 VA: 0x178C290
		public void Hide()
		{
			if(m_root != null && IsOpen)
			{
				IsOpen = false;
				m_root.StartChildrenAnimGoStop("st_wait");
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x704A6C Offset: 0x704A6C VA: 0x704A6C
		//// RVA: 0x179184C Offset: 0x179184C VA: 0x179184C
		private IEnumerator AnimInWait()
		{
			//0x1791CC0
			while(m_root.IsPlayingChildren())
				yield return null;
			if(CallbackOpenEnd != null)
				CallbackOpenEnd();
		}

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
	}
}
