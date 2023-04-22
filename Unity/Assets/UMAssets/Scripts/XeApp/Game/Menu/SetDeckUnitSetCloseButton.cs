using System;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class SetDeckUnitSetCloseButton : MonoBehaviour
	{
		//[TooltipAttribute] // RVA: 0x6847B8 Offset: 0x6847B8 VA: 0x6847B8
		[SerializeField]
		private InOutAnime m_inOut; // 0xC
		//[TooltipAttribute] // RVA: 0x684800 Offset: 0x684800 VA: 0x684800
		[SerializeField]
		private UGUIButton m_closeButton; // 0x10
		public Action OnClickCloseButton; // 0x14

		public InOutAnime InOut { get { return m_inOut; } } //0xC37F0C

		// RVA: 0xC37F14 Offset: 0xC37F14 VA: 0xC37F14
		private void Awake()
		{
			if(m_closeButton != null)
			{
				m_closeButton.AddOnClickCallback(() =>
				{
					//0xC3800C
					if (OnClickCloseButton != null)
						OnClickCloseButton();
				});
			}
		}
	}
}
