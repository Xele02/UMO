using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;

namespace XeApp.Game.Menu
{
	public class LayoutGachaHeaderInfo : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_buttonVC; // 0x14
		[SerializeField]
		private NumberBase m_numberVC; // 0x18
		private AbsoluteLayout m_layoutInOut; // 0x1C

		public Action OnClickVCButton { private get; set; } // 0x20

		// RVA: 0x19B0880 Offset: 0x19B0880 VA: 0x19B0880
		public void Setup(BEPHBEGDFFK view)
		{
			m_numberVC.SetNumber(view.BJLPJAAIMKC(), 0);
			m_buttonVC.Disable = view.DPBDFPPMIPH_Gacha.INDDJNMPONH_Category == GCAHJLOGMCI.KNMMOMEHDON_GachaType.ANFKBNLLJFN_7;
		}

		// RVA: 0x19B0944 Offset: 0x19B0944 VA: 0x19B0944
		public void Enter()
		{
			m_layoutInOut.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// RVA: 0x19B09D0 Offset: 0x19B09D0 VA: 0x19B09D0
		public void Leave()
		{
			m_layoutInOut.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// RVA: 0x19B0A5C Offset: 0x19B0A5C VA: 0x19B0A5C
		public bool IsPlaying()
		{
			return m_layoutInOut.IsPlayingChildren();
		}

		// RVA: 0x19B0A88 Offset: 0x19B0A88 VA: 0x19B0A88 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutInOut = layout.FindViewById("sw_gacha_stone_inout_anim") as AbsoluteLayout;
			m_buttonVC.AddOnClickCallback(() =>
			{
				//0x19B0BC4
				if (OnClickVCButton != null)
					OnClickVCButton();
			});
			Loaded();
			return true;
		}
	}
}
