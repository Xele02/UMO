using System;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class SetDeckUnitSetSelectButtons : MonoBehaviour
	{
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x684D64 Offset: 0x684D64 VA: 0x684D64
		private InOutAnime m_inOutLeft; // 0xC
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x684DC0 Offset: 0x684DC0 VA: 0x684DC0
		private InOutAnime m_inOutRight; // 0x10
		//[TooltipAttribute] // RVA: 0x684E1C Offset: 0x684E1C VA: 0x684E1C
		[SerializeField]
		private UGUIButton m_selectButtonLeft; // 0x14
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x684E78 Offset: 0x684E78 VA: 0x684E78
		private UGUIButton m_selectButtonRight; // 0x18
		public Action OnClickSelectButtonLeft; // 0x1C
		public Action OnClickSelectButtonRight; // 0x20

		public InOutAnime InOutLeft { get { return m_inOutLeft; } } //0xC39C64
		public InOutAnime InOutRight { get { return m_inOutRight; } } //0xC39C6C

		// RVA: 0xC39C74 Offset: 0xC39C74 VA: 0xC39C74
		private void Awake()
		{
			if(m_selectButtonLeft != null)
			{
				m_selectButtonLeft.AddOnClickCallback(() =>
				{
					//0xC39E10
					OnClickSelectButtonLeft();
				});
			}
			if(m_selectButtonRight != null)
			{
				m_selectButtonRight.AddOnClickCallback(() =>
				{
					//0xC39E3C
					OnClickSelectButtonRight();
				});
			}
		}
	}
}
