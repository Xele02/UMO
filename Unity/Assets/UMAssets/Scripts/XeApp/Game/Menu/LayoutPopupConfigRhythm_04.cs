using System.Collections;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutPopupConfigRhythm_04 : LayoutPopupConfigBase
	{
		public enum eTextType
		{
			CustomDetail = 0,
			Detail2D = 1,
			Light3D = 2,
			Default3D = 3,
			MotionTitle = 4,
			Num = 5,
		}

		private enum eButtonType
		{
			MotionDetail = 0,
			Num = 1,
		}

		private enum eToggleButton
		{
			Quality = 0,
		}

		private TextSet[] m_textTbl = new TextSet[5]
			{
				new TextSet() { index = 0, label = "config_text_15" },
				new TextSet() { index = 1, label = "config_text_16" },
				new TextSet() { index = 2, label = "config_text_17" },
				new TextSet() { index = 3, label = "config_text_18" },
				new TextSet() { index = 4, label = "config_text_14" }
			}; // 0x38

		// RVA: 0x1ECF8E8 Offset: 0x1ECF8E8 VA: 0x1ECF8E8 Slot: 6
		public override int GetContentsHeight()
		{
			return 382;
		}

		// RVA: 0x1ECF8F0 Offset: 0x1ECF8F0 VA: 0x1ECF8F0 Slot: 7
		public override bool IsShow()
		{
			return true;
		}

		//// RVA: 0x1ECF8F8 Offset: 0x1ECF8F8 VA: 0x1ECF8F8 Slot: 8
		public override void SetStatus(ScrollRect scroll)
		{
			base.SetStatus(scroll);
			SetSelectToggleButton(0, ConfigManager.Instance.GetQualityValue(false));
		}

		//// RVA: 0x1ECF99C Offset: 0x1ECF99C VA: 0x1ECF99C
		private void SetText()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			for (int i = 0; i < m_textTbl.Length; i++)
			{
				if (!string.IsNullOrEmpty(m_textTbl[i].label))
				{
					SetText(m_textTbl[i].index, bk.GetMessageByLabel(m_textTbl[i].label));
				}
				else
				{
					SetText(i, "");
				}
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x701CEC Offset: 0x701CEC VA: 0x701CEC
		//// RVA: 0x1ECFBA4 Offset: 0x1ECFBA4 VA: 0x1ECFBA4
		private IEnumerator Setup()
		{
			//0x1ED0264
			SetText();
			SetCallbackToggleButton(0, (int value) =>
			{
				//0x1ED0184
				ConfigUtility.PlaySeToggleButton();
				ConfigManager.Instance.SetQualityValue(value, false);
			});
			SetCallbackButton(0, () =>
			{
				//0x1ED0214
				ShowPopupDetail();
				ConfigUtility.PlaySeButton();
			});
			Loaded();
			yield break;
		}

		//// RVA: 0x1ECFC50 Offset: 0x1ECFC50 VA: 0x1ECFC50
		protected void ShowPopupDetail()
		{
			this.StartCoroutineWatched(ShowPopupDetailInner());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x701D64 Offset: 0x701D64 VA: 0x701D64
		//// RVA: 0x1ECFC74 Offset: 0x1ECFC74 VA: 0x1ECFC74
		protected IEnumerator ShowPopupDetailInner()
		{
			int valueCustomDiva3D; // 0x18
			int valueCustomOther3D; // 0x1C
			int valueCustom2D; // 0x20

			//0x1ED0464
			valueCustomDiva3D = ConfigManager.Instance.Option.HHMCIGLCBNG_QualityCustomDiva3D;
			valueCustomOther3D = ConfigManager.Instance.Option.AHLFOHJMGAI_QualityCustomOther3D;
			valueCustom2D = ConfigManager.Instance.Option.FPJHOLMLDGC_QualityCustom2D;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			PopupConfigDetailSetting s = new PopupConfigDetailSetting();
			s.TitleText = bk.GetMessageByLabel("config_text_11");
			s.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			s.WindowSize = SizeType.Large;
			s.m_parent = Parent;
			bool isCancel = false;
			bool isWait = true;
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1ED0248
				if (label == PopupButton.ButtonLabel.Cancel)
					isCancel = true;
				isWait = false;
			}, null, null, null);
			while (isWait)
				yield return null;
			if(isCancel)
			{
				ConfigManager.Instance.Option.HHMCIGLCBNG_QualityCustomDiva3D = valueCustomDiva3D;
				ConfigManager.Instance.Option.AHLFOHJMGAI_QualityCustomOther3D = valueCustomOther3D;
				ConfigManager.Instance.Option.FPJHOLMLDGC_QualityCustom2D = valueCustom2D;
			}
		}

		// RVA: 0x1ECFD20 Offset: 0x1ECFD20 VA: 0x1ECFD20 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			this.StartCoroutineWatched(Setup());
			return true;
		}
	}
}
