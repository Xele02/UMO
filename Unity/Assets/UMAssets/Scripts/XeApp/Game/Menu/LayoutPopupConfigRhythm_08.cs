using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutPopupConfigRhythm_08 : LayoutPopupConfigBase
	{
		public enum eTextType
		{
			Dimmer2DMax = 0,
			Dimmer2DMin = 1,
			Dimmer3DMax = 2,
			Dimmer3DMin = 3,
			DimmerDetail = 4,
			DimmerTitle = 5,
			Num = 6,
		}

		private enum eButtonType
		{
			DimmerDefault = 0,
			Dimmer2dPlus = 1,
			Dimmer2dMinus = 2,
			Dimmer3dPlus = 3,
			Dimmer3dMinus = 4,
			Num = 5,
		}

		private enum eSlider
		{
			Dimmer2D = 0,
			Dimmer3D = 1,
		}

		[SerializeField]
		private GameObject m_dimmer2dPos; // 0x38
		[SerializeField]
		private GameObject m_dimmer3dPos; // 0x3C
		private TextSet[] m_textTbl = new TextSet[6]
			{
				new TextSet() { index = 0, label = "config_text_55" },
				new TextSet() { index = 1, label = "config_text_54" },
				new TextSet() { index = 2, label = "config_text_55" },
				new TextSet() { index = 3, label = "config_text_54" },
				new TextSet() { index = 4, label = "config_text_53" },
				new TextSet() { index = 5, label = "config_text_52" }
			}; // 0x40

		// RVA: 0x1ED3578 Offset: 0x1ED3578 VA: 0x1ED3578 Slot: 6
		public override int GetContentsHeight()
		{
			return 368;
		}

		// RVA: 0x1ED3580 Offset: 0x1ED3580 VA: 0x1ED3580 Slot: 7
		public override bool IsShow()
		{
			return true;
		}

		//// RVA: 0x1ED3588 Offset: 0x1ED3588 VA: 0x1ED3588 Slot: 8
		public override void SetStatus(ScrollRect scroll)
		{
			base.SetStatus(scroll);
			m_changeSliderSePlay = false;
			SetValueSlider(0, ConfigManager.Instance.Option.FPFAMFOPJDJ_Dimmer2d);
			SetValueSlider(1, ConfigManager.Instance.Option.OLALFDCEHKJ_Dimmer3d);
			m_changeSliderSePlay = true;
		}

		//// RVA: 0x1ED36A0 Offset: 0x1ED36A0 VA: 0x1ED36A0
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

		//[IteratorStateMachineAttribute] // RVA: 0x702134 Offset: 0x702134 VA: 0x702134
		//// RVA: 0x1ED38A8 Offset: 0x1ED38A8 VA: 0x1ED38A8
		private IEnumerator Setup()
		{
			//0x1ED4910
			SetText();
			bool isSliderDimmer2D = false;
			ResourcesManager.Instance.Request("Menu/Prefab/Slider/slider_type001", (FileResultObject flo2) =>
			{
				//0x1ED3E84
				GameObject inst = Instantiate(flo2.unityObject) as GameObject;
				Slider s = inst.GetComponent<Slider>();
				s.transform.SetParent(m_dimmer2dPos.transform, false);
				m_sliders.Add(0, s);
				isSliderDimmer2D = true;
				return true;
			});
			bool isSliderDimmer3D = false;
			ResourcesManager.Instance.Request("Menu/Prefab/Slider/slider_type001", (FileResultObject flo2) =>
			{
				//0x1ED4074
				GameObject inst = Instantiate(flo2.unityObject) as GameObject;
				Slider s = inst.GetComponent<Slider>();
				s.transform.SetParent(m_dimmer3dPos.transform, false);
				m_sliders.Add(1, s);
				isSliderDimmer3D = true;
				return true;
			});
			ResourcesManager.Instance.Load();
			while (!isSliderDimmer3D || !isSliderDimmer2D)
				yield return null;
			SetCallbackSlider(0, (float value) =>
			{
				//0x1ED4264
				ConfigManager.Instance.SetDimmer2dValue(value);
				if (m_changeSliderSePlay)
					ConfigUtility.PlaySeSlider();
			});
			SetCallbackSlider(1, (float value) =>
			{
				//0x1ED4314
				ConfigManager.Instance.SetDimmer3dValue(value);
				if (m_changeSliderSePlay)
					ConfigUtility.PlaySeSlider();
			});
			SetLimitValueSlider(0, 0, 10);
			SetLimitValueSlider(1, 0, 10);
			SetCallbackButton(1, () =>
			{
				//0x1ED43C4
				SetValueSlider(0, ConfigManager.Instance.Dimmer2dPlus());
				ConfigUtility.PlaySeButton();
			});
			SetCallbackButton(2, () =>
			{
				//0x1ED4490
				SetValueSlider(0, ConfigManager.Instance.Dimmer2dMinus());
				ConfigUtility.PlaySeButton();
			});
			SetCallbackButton(3, () =>
			{
				//0x1ED455C
				SetValueSlider(1, ConfigManager.Instance.Dimmer3dPlus());
				ConfigUtility.PlaySeButton();
			});
			SetCallbackButton(4, () =>
			{
				//0x1ED4628
				SetValueSlider(1, ConfigManager.Instance.Dimmer3dMinus());
				ConfigUtility.PlaySeButton();
			});
			SetCallbackButton(0, () =>
			{
				//0x1ED46F4
				ConfigUtility.DimmerDefaultPopup((bool isDefault) =>
				{
					//0x1ED47BC
					float val1 = ConfigManager.Instance.ParamDefault(ConfigManager.eParamDefaultType.Dimmer2D);
					float val2 = ConfigManager.Instance.ParamDefault(ConfigManager.eParamDefaultType.Dimmer3D);
					m_changeSliderSePlay = false;
					SetValueSlider(0, val1);
					SetValueSlider(1, val2);
					m_changeSliderSePlay = true;
				});
				ConfigUtility.PlaySeButton();
			});
			Loaded();
		}

		// RVA: 0x1ED3954 Offset: 0x1ED3954 VA: 0x1ED3954 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			this.StartCoroutineWatched(Setup());
			return true;
		}
	}
}
