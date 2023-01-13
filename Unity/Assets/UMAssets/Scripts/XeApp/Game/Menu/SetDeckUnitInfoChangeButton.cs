using System;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class SetDeckUnitInfoChangeButton : MonoBehaviour
	{
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x68447C Offset: 0x68447C VA: 0x68447C
		private InOutAnime m_inOut; // 0xC
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x6844C4 Offset: 0x6844C4 VA: 0x6844C4
		private UGUIButton m_changeButton; // 0x10
		public Action OnClickChangeButton; // 0x14

		public InOutAnime InOut { get { return m_inOut; } } //0xC359C4
		//public UGUIButton ChangeButton { get; } 0xC359CC

		// RVA: 0xC359D4 Offset: 0xC359D4 VA: 0xC359D4
		private void Awake()
		{
			if(m_changeButton != null)
			{
				m_changeButton.AddOnClickCallback(() =>
				{
					//0xC35ACC
					if(OnClickChangeButton != null)
					{
						OnClickChangeButton();
					}
				});
			}
		}
	}
}
