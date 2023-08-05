using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using System;
using XeApp.Game.Common;
using XeApp.Game.Common.uGUI;

namespace XeApp.Game.Menu
{
	public class SubPlatePanel : LayoutUGUIScriptBase
	{
		[SerializeField]
		private LayoutUGUIRuntime m_runtime; // 0x14
		[SerializeField]
		private PopupSubPlateContent m_content; // 0x18
		[SerializeField]
		private InfoButton m_infoButton; // 0x1C
		[SerializeField]
		private Text[] m_statusText; // 0x20
		[SerializeField]
		private RectTransform[] m_statusArrow; // 0x24
		[SerializeField]
		private SubPlatePlateControl[] m_plateControl; // 0x28
		[SerializeField]
		private AnimeCurveScriptableObject m_animeCurve; // 0x2C
		private Color m_buffColor; // 0x30
		private Color m_debuffColor; // 0x40
		private AbsoluteLayout[] m_statusArrowAbs; // 0x50
		private bool[] m_isClossFade; // 0x54
		private int m_infoState; // 0x58
		private static Func<StatusData, int>[] s_funcGetStatus = new Func<StatusData, int>[4]
			{
				(StatusData s) =>
				{
					//0x1A9F8D8
					return s.Total;
				},
				(StatusData s) =>
				{
					//0x1A9F904
					return s.soul;
				},
				(StatusData s) =>
				{
					//0x1A9F928
					return s.vocal;
				},
				(StatusData s) =>
				{
					//0x1A9F94C
					return s.charm;
				}
			}; // 0x0

		// RVA: 0x1A9DA5C Offset: 0x1A9DA5C VA: 0x1A9DA5C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_statusArrowAbs = new AbsoluteLayout[m_statusArrow.Length];
			for(int i = 0; i < m_statusArrow.Length; i++)
			{
				m_statusArrowAbs[i] = m_runtime.FindViewBase(m_statusArrow[i]) as AbsoluteLayout;
			}
			m_infoButton.OnClickButton = OnInfoButton;
			return true;
		}

		// RVA: 0x1A9DCB4 Offset: 0x1A9DCB4 VA: 0x1A9DCB4
		public void InitializeFromContent(UnitWindowConstant.OperationMode opMode)
		{
			m_buffColor = ColorConvert.Convert(StatusTextColor.UpColor);
			m_debuffColor = ColorConvert.Convert(StatusTextColor.DebuffColor);
			m_isClossFade = new bool[m_statusArrow.Length];
			int cnt = 0;
			for(int i = 0; i < m_statusText.Length; i++)
			{
				m_isClossFade[i] = false;
				int val = s_funcGetStatus[i](m_content.subPlateResult.CMCKNKKCNDK);
				m_statusText[i].text = val.ToString();
				if(i < 1)
				{
					m_statusArrowAbs[i].StartChildrenAnimGoStop("st_non");
				}
				else
				{
					if(m_content.subPlateResult.CDOCOLOKCJK())
					{
						cnt |= m_content.subPlateResult.IKEJLHJEANO(i - 1);
						if (m_content.subPlateResult.IKEJLHJEANO(i - 1) == 1)
						{
							RichTextUtility.ChangeColor(m_statusText[i], StatusTextColor.UpColor);
							m_statusArrowAbs[i].StartChildrenAnimGoStop("st_wait_01");
						}
						else if (m_content.subPlateResult.IKEJLHJEANO(i - 1) == 2)
						{
							RichTextUtility.ChangeColor(m_statusText[i], StatusTextColor.DownColor);
							m_statusArrowAbs[i].StartChildrenAnimGoStop("st_wait_02");
						}
						else if (m_content.subPlateResult.IKEJLHJEANO(i - 1) == 3)
						{
							ResetClossFade(i);
						}
						else
						{
							m_statusArrowAbs[i].StartChildrenAnimGoStop("st_non");
						}
					}
					else
					{
						m_statusArrowAbs[i].StartChildrenAnimGoStop("st_non");
					}
				}
			}
			if(cnt > 0)
			{
				if (cnt == 1)
				{
					RichTextUtility.ChangeColor(m_statusText[0], StatusTextColor.UpColor);
					m_statusArrowAbs[0].StartChildrenAnimGoStop("st_wait_01");
				}
				else if(cnt == 2)
				{
					RichTextUtility.ChangeColor(m_statusText[0], StatusTextColor.DownColor);
					m_statusArrowAbs[0].StartChildrenAnimGoStop("st_wait_02");
				}
				else if(cnt == 3)
				{
					ResetClossFade(0);
				}
				else
				{
					m_statusArrowAbs[0].StartChildrenAnimGoStop("st_non");
				}
			}
			for(int i = 0; i < m_plateControl.Length; i++)
			{
				m_plateControl[i].InitializeFromContent(m_content, opMode);
			}
			m_infoState = 0;
			m_infoButton.SetPage(1, 2);
		}

		//// RVA: 0x1A9EC84 Offset: 0x1A9EC84 VA: 0x1A9EC84
		public void OnInfoButton(int page)
		{
			TodoLogger.LogNotImplemented("OnInfoButton");
		}

		//// RVA: 0x1A9EFC8 Offset: 0x1A9EFC8 VA: 0x1A9EFC8
		public void TryShowSceneDetail()
		{
			for(int i = 0; i < m_plateControl.Length; i++)
			{
				m_plateControl[i].TryShowSceneDetail();
			}
		}

		//// RVA: 0x1A9F06C Offset: 0x1A9F06C VA: 0x1A9F06C
		public void DisableTryShowSceneDetail()
		{
			for(int i = 0; i < m_plateControl.Length; i++)
			{
				m_plateControl[i].IsShowSceneDetail = false;
			}
		}

		//// RVA: 0x1A9F0F8 Offset: 0x1A9F0F8 VA: 0x1A9F0F8
		public void ClossFade(int index, AnimeCurveScriptableObject animeCurve)
		{
			if(m_isClossFade[index])
			{
				m_statusText[index].color = Color.Lerp(m_buffColor, m_debuffColor, animeCurve[0].Evaluate(GetIconLoopAnimeTime(index)));
			}
		}

		//// RVA: 0x1A9E518 Offset: 0x1A9E518 VA: 0x1A9E518
		public void ResetClossFade(int index)
		{
			m_statusArrowAbs[index].StartChildrenAnimLoop("logo_act");
			m_isClossFade[index] = true;
		}

		//// RVA: 0x1A9F258 Offset: 0x1A9F258 VA: 0x1A9F258
		public float GetIconLoopAnimeTime(int index)
		{
			return m_statusArrowAbs[index][0].FrameAnimation.AnimCount - 0.1f;
		}

		// RVA: 0x1A9F314 Offset: 0x1A9F314 VA: 0x1A9F314
		private void LateUpdate()
		{
			if(m_statusArrowAbs != null && m_isClossFade != null)
			{
				for(int i = 0; i < m_statusArrowAbs.Length; i++)
				{
					ClossFade(i, m_animeCurve);
				}
			}
			if(m_plateControl != null)
			{
				for(int i = 0; i < m_plateControl.Length; i++)
				{
					m_plateControl[i].ClossFade(m_animeCurve);
				}
			}
		}
	}
}
