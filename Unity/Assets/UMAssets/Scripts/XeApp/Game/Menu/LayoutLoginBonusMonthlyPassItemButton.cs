using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class LayoutLoginBonusMonthlyPassItemButton : ActionButton
	{
		[SerializeField]
		private RawImageEx m_imageItem; // 0x80
		[SerializeField]
		private RawImageEx m_imageStamp; // 0x84
		[SerializeField]
		private NumberBase m_numberCount; // 0x88
		private GJFMKMJOFMB.OJIMKCKABGE m_info; // 0x8C

		public Action<List<MFDJIFIIPJD>, List<MFDJIFIIPJD>> OnClickButton { get; set; } // 0x90

		// // RVA: 0x1D5B88C Offset: 0x1D5B88C VA: 0x1D5B88C
		// public void Setup(GJFMKMJOFMB.OJIMKCKABGE info, bool isAvailableTopplan) { }

		// // RVA: 0x1D5E24C Offset: 0x1D5E24C VA: 0x1D5E24C
		// public void SetStamp(bool enable) { }

		// // RVA: 0x1D5CC24 Offset: 0x1D5CC24 VA: 0x1D5CC24
		// public bool IsReady() { }

		// RVA: 0x1D5EE24 Offset: 0x1D5EE24 VA: 0x1D5EE24 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			AddOnClickCallback(() =>
			{
				//0x1D5EFF0
				if(OnClickButton != null)
				{
					OnClickButton(m_info.HBHMAKNGKFK, m_info.OBGHDLKKMLJ);
				}
			});
			Loaded();
			return true;
		}

		// [CompilerGeneratedAttribute] // RVA: 0x7061D4 Offset: 0x7061D4 VA: 0x7061D4
		// // RVA: 0x1D5EEEC Offset: 0x1D5EEEC VA: 0x1D5EEEC
		// private void <Setup>b__8_0(IiconTexture image) { }
	}
}
