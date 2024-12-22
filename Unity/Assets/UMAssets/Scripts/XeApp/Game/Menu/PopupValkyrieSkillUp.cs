using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupValkyrieSkillUp : UIBehaviour, IPopupContent
	{
		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x11614CC Offset: 0x11614CC VA: 0x11614CC Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			ValkyriePopupSetting s = setting as ValkyriePopupSetting;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			ValkyrieSkillUpWindow w = transform.GetComponent<ValkyrieSkillUpWindow>();
			int level = s.before_data.CIEOBFIIPLD_AbilityLevel;
			if(CheckNeedItem(s.after_data.PFIFFGHLCJJ()))
			{
				control.FindButton(PopupButton.ButtonLabel.Ok).Disable = true;
			}
			w.SetAbilityData(level != 0, s.before_data, s.after_data);
			Parent = setting.m_parent;
			gameObject.SetActive(true);
			transform.localPosition = Vector3.zero;
		}

		// RVA: 0x116185C Offset: 0x116185C VA: 0x116185C
		private bool CheckNeedItem(List<ALEKLHIANJN.HJBLCFPOFPO> list)
		{
			for(int i = 0; i < list.Count; i++)
			{
				int id = list[i].PPFNGGCBJKC;
                EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(id);
				int cnt = 0;
				if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.MABCLBNIOFA_ValkyrieItem)
				{
					cnt = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.MJAIFKFOPPI_ValItem[EKLNMHFCAOI.DEACAHNLMNI_getItemId(id) - 1].BFINGCJHOHI_Cnt;
				}
				else if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.HLCHKCJLEGK_GrowItem)
				{
					cnt = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KBMDMEEMGLK_GrowItem[EKLNMHFCAOI.DEACAHNLMNI_getItemId(id) - 1].BFINGCJHOHI_Cnt;
				}
				if(cnt < list[i].NANNGLGOFKH)
					return true;
            }
			return false;
		}

		// RVA: 0x1161CB4 Offset: 0x1161CB4 VA: 0x1161CB4 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1161CBC Offset: 0x1161CBC VA: 0x1161CBC Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x1161CF4 Offset: 0x1161CF4 VA: 0x1161CF4 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x1161D2C Offset: 0x1161D2C VA: 0x1161D2C Slot: 21
		public bool IsReady()
		{
			return transform.GetComponent<ValkyrieSkillUpWindow>().IsLoaded();
		}

		// RVA: 0x1161DD0 Offset: 0x1161DD0 VA: 0x1161DD0 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
