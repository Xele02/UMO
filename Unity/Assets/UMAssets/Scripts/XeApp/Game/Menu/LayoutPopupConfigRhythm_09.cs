using System.Collections;
using UnityEngine.UI;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutPopupConfigRhythm_09 : LayoutPopupConfigBase
	{
		public enum eTextType
		{
			ValModeOff = 0,
			ValModeOn = 1,
			ValModeDetail = 2,
			ValModeTitle = 3,
			Num = 4,
		}

		private enum eToggleButton
		{
			ValMode = 0,
		}

		private TextSet[] m_textTbl = new TextSet[4] {
			new TextSet() { index = 0, label = "config_text_60" },
			new TextSet() { index = 0, label = "config_text_60" },
			new TextSet() { index = 0, label = "config_text_60" },
			new TextSet() { index = 0, label = "config_text_60" }
		}; // 0x38

		// RVA: 0x1ED4FA8 Offset: 0x1ED4FA8 VA: 0x1ED4FA8 Slot: 6
		public override int GetContentsHeight()
		{
			return 224;
		}

		// RVA: 0x1ED4FB0 Offset: 0x1ED4FB0 VA: 0x1ED4FB0 Slot: 7
		public override bool IsShow()
		{
			return true;
		}

		//// RVA: 0x1ED4FB8 Offset: 0x1ED4FB8 VA: 0x1ED4FB8 Slot: 8
		public override void SetStatus(ScrollRect scroll)
		{
			base.SetStatus(scroll);
			SetSelectToggleButton(0, ConfigManager.Instance.Option.CDGKHMEOEMP_ValkyrieMode);
		}

		//// RVA: 0x1ED506C Offset: 0x1ED506C VA: 0x1ED506C
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

		//[IteratorStateMachineAttribute] // RVA: 0x7021FC Offset: 0x7021FC VA: 0x7021FC
		//// RVA: 0x1ED5274 Offset: 0x1ED5274 VA: 0x1ED5274
		private IEnumerator Setup()
		{
			//0x1ED5750
			SetText();
			SetCallbackToggleButton(0, (int value) =>
			{
				//0x1ED56C0
				ConfigUtility.PlaySeToggleButton();
				ConfigManager.Instance.SetValkyrieModeValue(value);
			});
			Loaded();
			yield break;
		}

		// RVA: 0x1ED5320 Offset: 0x1ED5320 VA: 0x1ED5320 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			this.StartCoroutineWatched(Setup());
			return true;
		}
	}
}
