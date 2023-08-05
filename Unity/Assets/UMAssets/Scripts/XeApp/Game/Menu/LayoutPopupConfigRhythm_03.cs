using System.Collections;
using UnityEngine.UI;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutPopupConfigRhythm_03 : LayoutPopupConfigBase
	{
		public enum eTextType
		{
			ExcellentDetail = 0,
			EffectTitle = 1,
			SlideNoteEffect = 2,
			Num = 3,
		}

		private enum eToggleButton
		{
			EffectCutin = 0,
			Notes = 1,
			Excellent = 2,
			SkillCutin = 3,
			SlideEffect = 4,
		}

		private TextSet[] m_textTbl = new TextSet[3]
			{
				new TextSet() { index = 0, label = "config_text_71" },
				new TextSet() { index = 1, label = "config_text_09" },
				new TextSet() { index = 2, label = "config_text_87" }
			}; // 0x38

		// RVA: 0x1ECEBD4 Offset: 0x1ECEBD4 VA: 0x1ECEBD4 Slot: 6
		public override int GetContentsHeight()
		{
			return 446;
		}

		// RVA: 0x1ECEBDC Offset: 0x1ECEBDC VA: 0x1ECEBDC Slot: 7
		public override bool IsShow()
		{
			return true;
		}

		//// RVA: 0x1ECEBE4 Offset: 0x1ECEBE4 VA: 0x1ECEBE4 Slot: 8
		public override void SetStatus(ScrollRect scroll)
		{
			base.SetStatus(scroll);
			SetSelectToggleButton(0, ConfigManager.Instance.Option.DADIPGPHLDD_EffectCutin);
			SetSelectToggleButton(3, ConfigManager.Instance.Option.NAGJLEIPAAC_Cutin);
			SetSelectToggleButton(1, ConfigManager.Instance.Option.NFMEIILKACN_NotesRoute);
			SetSelectToggleButton(2, ConfigManager.Instance.Option.EDDMJEMOAGM_IsNotExcellentDisplaySetting ? 0 : 1);
			SetSelectToggleButton(4, ConfigManager.Instance.Option.MJHEPGIEDDL_IsSlideNoteEffect ? 0 : 1);
		}

		//// RVA: 0x1ECED60 Offset: 0x1ECED60 VA: 0x1ECED60
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

		//[IteratorStateMachineAttribute] // RVA: 0x701BD4 Offset: 0x701BD4 VA: 0x701BD4
		//// RVA: 0x1ECEF68 Offset: 0x1ECEF68 VA: 0x1ECEF68
		private IEnumerator Setup()
		{
			//0x1ECF5B4
			SetText();
			SetCallbackToggleButton(0, (int value) =>
			{
				//0x1ECF2F0
				ConfigUtility.PlaySeToggleButton();
				ConfigManager.Instance.SetEffectCutinValue(value, false);
			});
			SetCallbackToggleButton(3, (int value) =>
			{
				//0x1ECF380
				ConfigUtility.PlaySeToggleButton();
				ConfigManager.Instance.SetSkillCutinValue(value);
			});
			SetCallbackToggleButton(1, (int value) =>
			{
				//0x1ECF40C
				ConfigUtility.PlaySeToggleButton();
				ConfigManager.Instance.SetNotesRouteValue(value);
			});
			SetCallbackToggleButton(2, (int value) =>
			{
				//0x1ECF498
				ConfigUtility.PlaySeToggleButton();
				ConfigManager.Instance.SetExcellentValue(value);
			});
			SetCallbackToggleButton(4, (int value) =>
			{
				//0x1ECF524
				ConfigUtility.PlaySeToggleButton();
				ConfigManager.Instance.SetSlideNoteValue(value);
			});
			Loaded();
			yield break;
		}

		// RVA: 0x1ECF014 Offset: 0x1ECF014 VA: 0x1ECF014 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			this.StartCoroutineWatched(Setup());
			return true;
		}
	}
}
