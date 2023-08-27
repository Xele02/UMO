using mcrs;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Menu;

namespace XeApp.Game.Common
{
	public class PopupLuckyLeafTerminate : UIBehaviour, IPopupContent
	{
		private Transform parent; // 0xC
		private LuckyLeafTerminate luckyLeafTerminateLayout; // 0x10

		public Transform Parent { get { return parent; } } //0x1BAF654

		// RVA: 0x1BAF3C4 Offset: 0x1BAF3C4 VA: 0x1BAF3C4 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			luckyLeafTerminateLayout = GetComponent<LuckyLeafTerminate>();
			PopupLuckyLeafTerminateSetting s = setting as PopupLuckyLeafTerminateSetting;
			parent = s.m_parent;
			luckyLeafTerminateLayout.OnClickHelpButton = HelpButtonEvent;
			luckyLeafTerminateLayout.Setup(s.SceneData);
			GetComponent<RectTransform>().sizeDelta = PopupWindowControl.GetContentSize2(s.WindowSize, s.IsCaption);
		}

		// RVA: 0x1BAF5D0 Offset: 0x1BAF5D0 VA: 0x1BAF5D0 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1BAF5D8 Offset: 0x1BAF5D8 VA: 0x1BAF5D8 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x1BAF610 Offset: 0x1BAF610 VA: 0x1BAF610 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x1BAF648 Offset: 0x1BAF648 VA: 0x1BAF648 Slot: 21
		public bool IsReady()
		{
			return true;
		}

		// RVA: 0x1BAF650 Offset: 0x1BAF650 VA: 0x1BAF650 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}

		// // RVA: 0x1BAF65C Offset: 0x1BAF65C VA: 0x1BAF65C
		private void HelpButtonEvent()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			int id = HelpButton.FindHelpUniqueId(113);
			if(id > -1)
			{
				GameManager.Instance.CloseSnsNotice();
				MenuScene.Instance.InputDisable();
				MenuScene.Instance.HelpPopupWindowControl.Show(MenuScene.Instance, id, () =>
				{
					//0x1BAF970
					MenuScene.Instance.InputEnable();
				});
			}
		}
	}
}
