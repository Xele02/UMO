using System.Collections;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutPopupConfigSimulation_02 : LayoutPopupConfigBase
	{
		public enum eTextType
		{
			CustomDetail = 0,
			Light3D = 1,
			Default3D = 2,
			MotionTitle = 3,
			Num = 4,
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

		private TextSet[] m_textTbl = new TextSet[4]
			{
				new TextSet() { index = 0, label = "config_text_15" },
				new TextSet() { index = 1, label = "config_text_17" },
				new TextSet() { index = 2, label = "config_text_18" },
				new TextSet() { index = 3, label = "config_text_14" },
			}; // 0x38

		// RVA: 0x1EDA170 Offset: 0x1EDA170 VA: 0x1EDA170 Slot: 6
		public override int GetContentsHeight()
		{
			return 302;
		}

		// RVA: 0x1EDA178 Offset: 0x1EDA178 VA: 0x1EDA178 Slot: 7
		public override bool IsShow()
		{
			return true;
		}

		// RVA: 0x1EDA180 Offset: 0x1EDA180 VA: 0x1EDA180 Slot: 8
		public override void SetStatus(ScrollRect scroll)
		{
			base.SetStatus(scroll);
			SetSelectToggleButton(0, ConfigManager.Instance.GetQualityValue(true));
		}

		//// RVA: 0x1EDA224 Offset: 0x1EDA224 VA: 0x1EDA224
		private void SetText()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			for(int i = 0; i < m_textTbl.Length; i++)
			{
				string s = "";
				int index = i;
				if(!string.IsNullOrEmpty(m_textTbl[i].label))
				{
					s = bk.GetMessageByLabel(m_textTbl[i].label);
					index = m_textTbl[i].index;
				}
				SetText(index, s);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x702654 Offset: 0x702654 VA: 0x702654
		//// RVA: 0x1EDA42C Offset: 0x1EDA42C VA: 0x1EDA42C
		private IEnumerator Setup()
		{
			//0x1EDAA28
			SetText();
			SetCallbackToggleButton(0, (int value) =>
			{
				//0x1EDA948
				ConfigUtility.PlaySeToggleButton();
				ConfigManager.Instance.SetQualityValue(value, true);
			});
			SetCallbackButton(0, () =>
			{
				//0x1EDA9D8
				this.StartCoroutineWatched(ShowPopupDetailInner());
				ConfigUtility.PlaySeButton();
			});
			Loaded();
			yield break;
		}

		//// RVA: 0x1EDA4D8 Offset: 0x1EDA4D8 VA: 0x1EDA4D8
		//protected void ShowPopupDetail() { }

		//[IteratorStateMachineAttribute] // RVA: 0x7026CC Offset: 0x7026CC VA: 0x7026CC
		//// RVA: 0x1EDA4FC Offset: 0x1EDA4FC VA: 0x1EDA4FC
		protected IEnumerator ShowPopupDetailInner()
		{
			int valueCustomDiva3D; 
			int valueCustomOther3D;

			//0x1EDAC28
			valueCustomDiva3D = ConfigManager.Instance.OptionSLive.HHMCIGLCBNG_QualityCustomDiva3D;
			valueCustomOther3D = ConfigManager.Instance.OptionSLive.AHLFOHJMGAI_QualityCustomOther3D;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			PopupConfigDetailSLiveSetting s = new PopupConfigDetailSLiveSetting();
			s.TitleText = bk.GetMessageByLabel("config_text_11");
			s.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive },
			};
			s.WindowSize = SizeType.Large;
			s.SetParent(Parent);
			bool isCancel = false;
			bool isWait = true;
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1EDAA0C
				if (label == PopupButton.ButtonLabel.Cancel)
					isCancel = true;
				isWait = false;
			}, null, null, null);
			while (isWait)
				yield return null;
			if(isCancel)
			{
				ConfigManager.Instance.OptionSLive.HHMCIGLCBNG_QualityCustomDiva3D = valueCustomDiva3D;
				ConfigManager.Instance.OptionSLive.AHLFOHJMGAI_QualityCustomOther3D = valueCustomOther3D;
			}
		}

		// RVA: 0x1EDA5A8 Offset: 0x1EDA5A8 VA: 0x1EDA5A8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			this.StartCoroutineWatched(Setup());
			return true;
		}
	}
}
