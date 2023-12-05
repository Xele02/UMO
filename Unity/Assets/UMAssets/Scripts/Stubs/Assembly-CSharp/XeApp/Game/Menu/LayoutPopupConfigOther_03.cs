using System.Collections;
using UnityEngine.UI;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutPopupConfigOther_03 : LayoutPopupConfigBase
	{
		public enum eTextType
		{
			SafeAreaTitle = 0,
			SafeAreaDetail = 1,
			Design1Desc = 2,
			Design2Desc = 3,
			Design3Desc = 4,
			Num = 5,
		}

		private enum eToggleButton
		{
			SafeAreaDesign = 0,
		}

		private TextSet[] m_textTbl = new TextSet[5]
		{
			new TextSet() { index = 0, label = "config_text_82" },
			new TextSet() { index = 1, label = "config_text_83" },
			new TextSet() { index = 2, label = "config_text_84" },
			new TextSet() { index = 3, label = "config_text_85" },
			new TextSet() { index = 4, label = "config_text_86" }
		}; // 0x38

		// RVA: 0x1EC95CC Offset: 0x1EC95CC VA: 0x1EC95CC Slot: 6
		public override int GetContentsHeight()
		{
			return 317;
		}

		// RVA: 0x1EC95D4 Offset: 0x1EC95D4 VA: 0x1EC95D4 Slot: 7
		public override bool IsShow()
		{
			return SystemManager.HasSafeArea;
		}

		// RVA: 0x1EC9690 Offset: 0x1EC9690 VA: 0x1EC9690 Slot: 8
		public override void SetStatus(ScrollRect scroll)
		{
			base.SetStatus(scroll);
			SetSelectToggleButton(0, ConfigManager.Instance.Option.HLABNEIEJPM_SafeAreaDesign);
		}

		// RVA: 0x1EC9744 Offset: 0x1EC9744 VA: 0x1EC9744
		private void SetText()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			for(int i = 0; i < m_textTbl.Length; i++)
			{
				if(!string.IsNullOrEmpty(m_textTbl[i].label))
				{
					SetText(m_textTbl[i].index, bk.GetMessageByLabel(m_textTbl[i].label));
				}
				else
				{
					SetText(i, "");
				}
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x701804 Offset: 0x701804 VA: 0x701804
		// RVA: 0x1EC994C Offset: 0x1EC994C VA: 0x1EC994C
		private IEnumerator Setup()
		{
			//0x1EC9F58
			SetText();
			SetCallbackToggleButton(0, (int value) =>
			{
				//0x1EC9E5C
				ConfigUtility.PlaySeToggleButton();
				ConfigManager.Instance.Option.HLABNEIEJPM_SafeAreaDesign = value;
				GameManager.Instance.SetLongScreenFrameColor(value);
			});
			Loaded();
			yield break;
		}

		// RVA: 0x1EC99F8 Offset: 0x1EC99F8 VA: 0x1EC99F8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			this.StartCoroutineWatched(Setup());
			return true;
		}
	}
}
