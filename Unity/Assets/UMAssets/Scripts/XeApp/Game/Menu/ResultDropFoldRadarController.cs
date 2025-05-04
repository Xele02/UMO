using System;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class ResultDropFoldRadarController : MonoBehaviour
	{
		public class InitParam
		{
		}

		public Action onClickOkayButton; // 0xC
		private LayoutResultDropFoldRadar m_layoutDropFoldRadar; // 0x10

		// RVA: 0xD00EAC Offset: 0xD00EAC VA: 0xD00EAC
		private void Awake()
		{
			m_layoutDropFoldRadar = transform.Find("root_g_r_r02_pop_cc_layout_root").GetComponent<LayoutResultDropFoldRadar>();
		}

		// // RVA: 0xD00F64 Offset: 0xD00F64 VA: 0xD00F64
		// public bool IsReady() { }

		// // RVA: 0xD00F90 Offset: 0xD00F90 VA: 0xD00F90
		public void Setup(int num)
		{
			m_layoutDropFoldRadar.Setup(num);
			m_layoutDropFoldRadar.onClickOkayButton = OnClickOkayButton;
			GameManager.Instance.AddPushBackButtonHandler(OnClickOkayButton);
		}

		// // RVA: 0xD010E4 Offset: 0xD010E4 VA: 0xD010E4
		public void StartBeginAnim()
		{
			m_layoutDropFoldRadar.StartBeginAnim();
		}

		// // RVA: 0xD01110 Offset: 0xD01110 VA: 0xD01110
		// public void StartEndAnim(Action endAnimCallback) { }

		// // RVA: 0xD01144 Offset: 0xD01144 VA: 0xD01144
		public void OnClickOkayButton()
		{
			if(onClickOkayButton != null)
			{
				onClickOkayButton();
				GameManager.Instance.RemovePushBackButtonHandler(OnClickOkayButton);
			}
		}
	}
}
