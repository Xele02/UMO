using System.Collections;
using UnityEngine.UI;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutPopupConfigRhythm_11 : LayoutPopupConfigBase
	{
		public enum eTextType
		{
			DivaModeTitle = 0,
			DivaModeDetail = 1,
			DivaModeCaution = 2,
			StandardDesc = 3,
			DivaDesc = 4,
			VideoDesc = 5,
			Num = 6,
		}

		private enum eToggleButton
		{
			DivaMode = 0,
		}

		private TextSet[] m_textTbl = new TextSet[6]
			{
				new TextSet() { index = 0, label = "config_text_72" },
				new TextSet() { index = 1, label = "config_text_73" },
				new TextSet() { index = 2, label = "config_text_74" },
				new TextSet() { index = 3, label = "config_text_75" },
				new TextSet() { index = 4, label = "config_text_76" },
				new TextSet() { index = 5, label = "config_text_77" }
			}; // 0x38

		// RVA: 0x1ED6394 Offset: 0x1ED6394 VA: 0x1ED6394 Slot: 6
		public override int GetContentsHeight()
		{
			return 324;
		}

		// RVA: 0x1ED639C Offset: 0x1ED639C VA: 0x1ED639C Slot: 7
		public override bool IsShow()
		{
			return true;
		}

		//// RVA: 0x1ED63A4 Offset: 0x1ED63A4 VA: 0x1ED63A4 Slot: 8
		public override void SetStatus(ScrollRect scroll)
		{
			base.SetStatus(scroll);
			int a = 2;
			if (ConfigManager.Instance.Option.CJKKALFPMLA_IsNotDivaModeDivaVisible)
				a = 0;
			if (ConfigManager.Instance.Option.PMGMMMGCEEI_Video != 0)
				a = ConfigManager.Instance.Option.CJKKALFPMLA_IsNotDivaModeDivaVisible ? 1 : 0;
			SetSelectToggleButton(0, a);
		}

		//// RVA: 0x1ED6484 Offset: 0x1ED6484 VA: 0x1ED6484
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

		//[IteratorStateMachineAttribute] // RVA: 0x7023BC Offset: 0x7023BC VA: 0x7023BC
		//// RVA: 0x1ED668C Offset: 0x1ED668C VA: 0x1ED668C
		private IEnumerator Setup()
		{
			//0x1ED6DF4
			SetText();
			SetCallbackToggleButton(0, (int value) =>
			{
				//0x1ED6C60
				ConfigUtility.PlaySeToggleButton();
				if(value == 2)
				{
					ConfigManager.Instance.SetVideoVisibleValue(0);
					ConfigManager.Instance.SetDivaVisibleValue(false);
				}
				else if(value == 1)
				{
					ConfigManager.Instance.SetVideoVisibleValue(1);
					ConfigManager.Instance.SetDivaVisibleValue(true);
				}
				else if (value == 0)
				{
					ConfigManager.Instance.SetVideoVisibleValue(0);
					ConfigManager.Instance.SetDivaVisibleValue(true);
				}
			});
			Loaded();
			yield break;
		}

		// RVA: 0x1ED6738 Offset: 0x1ED6738 VA: 0x1ED6738 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			this.StartCoroutineWatched(Setup());
			return true;
		}
	}
}
