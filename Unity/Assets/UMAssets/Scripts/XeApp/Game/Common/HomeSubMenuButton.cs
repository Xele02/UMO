using System;
using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class HomeSubMenuButton : UGUIButton
	{
		//[HeaderAttribute] // RVA: 0x68ADB8 Offset: 0x68ADB8 VA: 0x68ADB8
		[SerializeField]
		private GameObject badgeIcon; // 0x38

		public Action onClickButton { private get; set; } // 0x3C

		//// RVA: 0xEB1ABC Offset: 0xEB1ABC VA: 0xEB1ABC
		public void Init()
		{
			ClearOnClickCallback();
			AddOnClickCallback(() =>
			{
				//0xEB2750
				if (onClickButton != null)
					onClickButton();
			});
		}

		//// RVA: 0xEB222C Offset: 0xEB222C VA: 0xEB222C
		//public void SetActive(bool active) { }

		//// RVA: 0xEB1E9C Offset: 0xEB1E9C VA: 0xEB1E9C
		//public void SetBadgeActive(bool enable) { }
	}
}
