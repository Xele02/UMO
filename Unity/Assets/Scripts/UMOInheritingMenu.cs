using mcrs;
using System;
using System.Collections;
using UnityEngine;
using XeApp.Game.AR;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class UMOInheritingMenu : InheritingMenu
	{
		// // RVA: 0x13DE1B8 Offset: 0x13DE1B8 VA: 0x13DE1B8
		public static new UMOInheritingMenu Create(Transform parent)
		{
			GameObject go = new GameObject("InheritingMenu");
			go.transform.SetParent(parent, false);
			return go.AddComponent<UMOInheritingMenu>();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E588C Offset: 0x6E588C VA: 0x6E588C
		// // RVA: 0x13DE4EC Offset: 0x13DE4EC VA: 0x13DE4EC
		protected override IEnumerator Co_MainFlow(bool isPreparation, Action inheritingSuccess, Action closeCallback, LayoutMonthlyPassTakeover monthlylayout)
		{
			UMOPopupAccountPickerSetting s = new UMOPopupAccountPickerSetting();
			s.WindowSize = SizeType.Large;
			s.TitleText = "Account Picker";
			s.m_parent = transform;
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative }
			};
			bool done = false;
			int AccountSelection = -1;
			PopupWindowControl c = null;
			c = PopupWindowManager.Show(s, null, null, null, null, endCallBaack:() =>
			{
				done = true;
				AccountSelection = (c.Content as UMOPopupAccountPicker).AccountSelected;
			});
			while(!done)
				yield return null;
			if(AccountSelection > 0)
				NKGJPJPHLIF.HHCJCDFCLOB.IJMGMJHLGDG(AccountSelection);
			else
			{
				if(AccountSelection == -1)
				{
					// Request new number
					NKGJPJPHLIF.HHCJCDFCLOB.IJMGMJHLGDG(0);
					UMO_PlayerPrefs.SetInt("cpid", 0);
					UMO_PlayerPrefs.Save();

					bool BEKAMBBOLBO = false;
					NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.OLBAIKLLIFE = true;
					NKGJPJPHLIF.HHCJCDFCLOB.HGJKAEOLMJN_InitializePlayerToken(() => {
						//0xA08F1C
						BEKAMBBOLBO = true;
					}, () => {
						// 0xA08F28
						BEKAMBBOLBO = true;
					}, true, false);
					while(!BEKAMBBOLBO)
					{
						yield return null;
					}
					NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.OLBAIKLLIFE = false;
					NKGJPJPHLIF.HHCJCDFCLOB.IJMGMJHLGDG(NKGJPJPHLIF.HHCJCDFCLOB.CAFHLEFMMGD_GetPlayerId());
				}
				else if(AccountSelection == -2)
					NKGJPJPHLIF.HHCJCDFCLOB.IJMGMJHLGDG(999999999);
				
			}
			if(inheritingSuccess != null)
				inheritingSuccess();
			if (closeCallback != null)
				closeCallback();
		}

	}
}
