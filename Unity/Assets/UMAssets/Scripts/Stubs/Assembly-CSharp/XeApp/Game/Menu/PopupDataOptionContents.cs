using mcrs;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupDataOptionContents : UIBehaviour, IPopupContent
	{
		private RectTransform m_rectTransform; // 0x10
		private LayoutPopupDataOption m_dataOption; // 0x14
		private PopupWindowControl m_popupControl; // 0x18

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x1345008 Offset: 0x1345008 VA: 0x1345008
		private void Awake()
		{
			m_rectTransform = transform as RectTransform;
		}

		// RVA: 0x1345090 Offset: 0x1345090 VA: 0x1345090 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupDataOptionSetting setup = setting as PopupDataOptionSetting;
			m_popupControl = control;
			Parent = setting.m_parent;
			m_dataOption = GetComponent<LayoutPopupDataOption>();
			if(m_dataOption != null)
			{
				m_dataOption.CallbackCacheClear = () =>
				{
					//0x13456B0
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					PopupWindowManager.OpenCacheClearWindow(() =>
					{
						//0x134584C
						MenuScene.Instance.GotoTitle();
					});
				};
				m_dataOption.CallbackBunchInstall = () =>
				{
					//0x13458E8
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					if (setup.OnClickBunchInstall != null)
						setup.OnClickBunchInstall(m_popupControl);
				};
				m_dataOption.SetStatus();
			}
			PopupWindowControl.GetContentSize2(setting.WindowSize, setting.IsCaption);
			gameObject.SetActive(true);
		}

		// RVA: 0x1345450 Offset: 0x1345450 VA: 0x1345450 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1345458 Offset: 0x1345458 VA: 0x1345458 Slot: 19
		public void Show()
		{
			if (m_dataOption != null)
				m_dataOption.Show();
			gameObject.SetActive(true);
		}

		// RVA: 0x134553C Offset: 0x134553C VA: 0x134553C Slot: 20
		public void Hide()
		{
			if (m_dataOption != null)
				m_dataOption.Hide();
			gameObject.SetActive(false);
		}

		// RVA: 0x1345620 Offset: 0x1345620 VA: 0x1345620 Slot: 21
		public bool IsReady()
		{
			return true;
		}

		// RVA: 0x1345628 Offset: 0x1345628 VA: 0x1345628 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
