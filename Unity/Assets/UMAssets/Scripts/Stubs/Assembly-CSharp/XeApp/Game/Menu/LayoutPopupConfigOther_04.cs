using System.Collections;
using UnityEngine.UI;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutPopupConfigOther_04 : LayoutPopupConfigBase
	{
		public enum eTextType
		{
			UlWideTitle = 0,
			UlWideDetail = 1,
			UlWideCaution = 2,
			WideDesc = 3,
			LegacyDesc = 4,
			Num = 5,
		}

		private enum eToggleButton
		{
			UlWideAspect = 0,
		}

		private TextSet[] m_textTbl = new TextSet[5]
		{
			new TextSet() { index = 0, label = "config_text_88" },
			new TextSet() { index = 1, label = "config_text_89" },
			new TextSet() { index = 2, label = "config_text_92" },
			new TextSet() { index = 3, label = "config_text_90" },
			new TextSet() { index = 4, label = "config_text_91" }
		}; // 0x38

		// RVA: 0x1ECA0FC Offset: 0x1ECA0FC VA: 0x1ECA0FC Slot: 6
		public override int GetContentsHeight()
		{
			return 237;
		}

		// RVA: 0x1ECA104 Offset: 0x1ECA104 VA: 0x1ECA104 Slot: 7
		public override bool IsShow()
		{
			return SystemManager.CanWideScreenMenu;
		}

		// RVA: 0x1ECA180 Offset: 0x1ECA180 VA: 0x1ECA180 Slot: 8
		public override void SetStatus(ScrollRect scroll)
		{
			base.SetStatus(scroll);
			SetSelectToggleButton(0, ConfigManager.Instance.Option.HJPDHDHMOPF_IsNotForceWideScreen);
		}

		// RVA: 0x1ECA234 Offset: 0x1ECA234 VA: 0x1ECA234
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

		//[IteratorStateMachineAttribute] // RVA: 0x7018DC Offset: 0x7018DC VA: 0x7018DC
		// RVA: 0x1ECA43C Offset: 0x1ECA43C VA: 0x1ECA43C
		private IEnumerator Setup()
		{
			//0x1ECA9F0
			SetText();
			SetCallbackToggleButton(0, (int value) =>
			{
				//0x1ECA94C
				ConfigUtility.PlaySeToggleButton();
				ConfigManager.Instance.Option.HJPDHDHMOPF_IsNotForceWideScreen = value;
			});
			Loaded();
			yield break;
		}

		// RVA: 0x1ECA4E8 Offset: 0x1ECA4E8 VA: 0x1ECA4E8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			this.StartCoroutineWatched(Setup());
			return true;
		}
	}
}
