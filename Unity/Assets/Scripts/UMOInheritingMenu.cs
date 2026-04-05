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
			c = PopupWindowManager.Show(s, null, null, null, null, true, true, false, null, () =>
			{
				done = true;
				AccountSelection = (c.Content as UMOPopupAccountPicker).AccountSelected;
			}, null, null, null);
			while(!done)
				yield return null;
			if(AccountSelection > 0)
				NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IJMGMJHLGDG(AccountSelection);
			else
			{
				if(AccountSelection == -1)
				{
					// Request new number
					NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IJMGMJHLGDG(0);
					UMO_PlayerPrefs.SetInt("cpid", 0);
					UMO_PlayerPrefs.Save();

					bool BEKAMBBOLBO_Done = false;
					NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.OLBAIKLLIFE = true;
					NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.HGJKAEOLMJN_InitializePlayerToken(() => {
						//0xA08F1C
						BEKAMBBOLBO_Done = true;
					}, () => {
						// 0xA08F28
						BEKAMBBOLBO_Done = true;
					}, true, false);
					while(!BEKAMBBOLBO_Done)
					{
						yield return null;
					}
					NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.OLBAIKLLIFE = false;
					NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IJMGMJHLGDG(NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.CAFHLEFMMGD_GetPlayerId());
				}
				else if(AccountSelection == -2)
					NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IJMGMJHLGDG(999999999);
				
			}
			if(inheritingSuccess != null)
				inheritingSuccess();
			if (closeCallback != null)
				closeCallback();
		}

	}
}
