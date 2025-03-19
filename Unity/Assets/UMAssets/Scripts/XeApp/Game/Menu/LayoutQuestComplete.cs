using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;
using mcrs;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class LayoutQuestComplete : LayoutUGUIScriptBase
	{
		[SerializeField]
		private NumberBase m_mol; // 0x14
		[SerializeField]
		private NumberBase m_den; // 0x18
		[SerializeField]
		private NumberBase m_itemNum; // 0x1C
		[SerializeField]
		private RawImageEx m_iconImage; // 0x20
		private AbsoluteLayout m_root; // 0x24
		private AbsoluteLayout m_gauge; // 0x28
		private bool m_isLoadingIconImage; // 0x2C
		public Action OnFadeOut; // 0x30

		public bool IsOpen { get; private set; } // 0x34

		// RVA: 0x18706A8 Offset: 0x18706A8 VA: 0x18706A8
		public void SetStatus(FKMOKDCJFEN viewData)
		{
			int v = (int)(viewData.ABLHIAEDJAI_CurrentValue * 1.0f / viewData.HLDGMMDFNHB_TargetValue);
			if(m_gauge != null)
				m_gauge.StartAllAnimGoStop(v, v);
			if(viewData.GOOIIPFHOIG != null)
				SetIconImage(viewData.GOOIIPFHOIG.JJBGOIMEIPF_ItemId);
			SetNumber(viewData.ABLHIAEDJAI_CurrentValue, viewData.HLDGMMDFNHB_TargetValue);
			SetRewardNum(viewData.GOOIIPFHOIG == null ? 0 : viewData.GOOIIPFHOIG.MBJIFDBEDAC_Cnt);
		}

		// RVA: 0x1870B58 Offset: 0x1870B58 VA: 0x1870B58
		public void Reset()
		{
			return;
		}

		// RVA: 0x1870B5C Offset: 0x1870B5C VA: 0x1870B5C
		public bool IsReady()
		{
			return !m_isLoadingIconImage;
		}

		// // RVA: 0x18708E4 Offset: 0x18708E4 VA: 0x18708E4
		public void SetNumber(int mol, int den)
		{
			if(m_den != null)
			{
				for(int i = 0; i < m_den.DigitMax; i++)
				{
					m_den.SetDigitNuber(i + 1, 0);
				}
				m_den.SetNumber(den, 0);
			}
			if(m_mol != null)
			{
				m_mol.SetNumber(mol, 0);
			}
		}

		// // RVA: 0x1870A90 Offset: 0x1870A90 VA: 0x1870A90
		public void SetRewardNum(int num)
		{
			if(m_itemNum != null)
				m_itemNum.SetNumber(num, 0);
		}

		// // RVA: 0x187077C Offset: 0x187077C VA: 0x187077C
		public void SetIconImage(int iconId)
		{
			m_isLoadingIconImage = false;
			if(m_iconImage != null)
			{
				m_isLoadingIconImage = true;
				MenuScene.Instance.ItemTextureCache.Load(iconId, (IiconTexture texture) =>
				{
					//0x187105C
					if(texture != null)
					{
						texture.Set(m_iconImage);
					}
					m_isLoadingIconImage = false;
				});
			}
		}

		// // RVA: 0x1870764 Offset: 0x1870764 VA: 0x1870764
		// public void SetGauge(int val) { }

		// RVA: 0x1870B70 Offset: 0x1870B70 VA: 0x1870B70
		public void In()
		{
			if(m_root != null && !IsOpen)
			{
				IsOpen = true;
				m_root.StartChildrenAnimGoStop("go_in", "st_in");
				SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_SETTING_007);
			}
		}

		// // RVA: 0x1870C54 Offset: 0x1870C54 VA: 0x1870C54
		// public void Show() { }

		// RVA: 0x1870CE0 Offset: 0x1870CE0 VA: 0x1870CE0
		public void Out()
		{
			if(m_root != null && IsOpen)
			{
				IsOpen = false;
				m_root.StartChildrenAnimGoStop("go_out", "st_non");
				this.StartCoroutineWatched(Co_OutAnim());
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71005C Offset: 0x71005C VA: 0x71005C
		// // RVA: 0x1870D8C Offset: 0x1870D8C VA: 0x1870D8C
		private IEnumerator Co_OutAnim()
		{
			//0x1871140
			while(m_root.GetView(0).FrameAnimation.FrameCount < m_root.GetView(0).FrameAnimation.SearchLabelFrame("st_out"))
				yield return null;
			if(OnFadeOut != null)
				OnFadeOut();
		}

		// // RVA: 0x1870E38 Offset: 0x1870E38 VA: 0x1870E38
		// public void Hide() { }

		// RVA: 0x1870EC0 Offset: 0x1870EC0 VA: 0x1870EC0
		public bool IsPlaying()
		{
			return m_root != null && m_root.IsPlayingChildren();
		}

		// // RVA: 0x1870ED8 Offset: 0x1870ED8 VA: 0x1870ED8
		// private bool IsPlayingAnim() { }

		// RVA: 0x1870EF0 Offset: 0x1870EF0 VA: 0x1870EF0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_root = layout.Root[0] as AbsoluteLayout;
			m_gauge = layout.FindViewByExId("sw_sel_que_items_list_01_sw_sel_que_progress_anim") as AbsoluteLayout;
			Loaded();
			return true;
		}
	}
}
