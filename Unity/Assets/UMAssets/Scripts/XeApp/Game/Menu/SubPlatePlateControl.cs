using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys;
using System.Text;
using XeApp.Game.Common.uGUI;
using mcrs;

namespace XeApp.Game.Menu
{
	public class SubPlatePlateControl : LayoutUGUIScriptBase
	{
		public enum eDisplay
		{
			Normal = 0,
			Parameter = 1,
			Num = 2,
		}

		[SerializeField]
		private LayoutUGUIRuntime m_runtime; // 0x14
		[SerializeField]
		private GameObject m_baseObject; // 0x18
		[SerializeField]
		private Text m_rateText; // 0x1C
		[SerializeField]
		private Text m_addText; // 0x20
		[SerializeField]
		private int m_attribute; // 0x24
		[SerializeField]
		private int m_status; // 0x28
		[SerializeField]
		private GameObject m_lockIconObject; // 0x2C
		[SerializeField]
		private GameObject m_rateTextObject; // 0x30
		[SerializeField]
		private RawImageEx m_image; // 0x34
		[SerializeField]
		private StayButton m_detailButton; // 0x38
		[SerializeField]
		private RectTransform m_arrow; // 0x3C
		private Color m_buffColor; // 0x40
		private Color m_debuffColor; // 0x50
		private AbsoluteLayout m_abs; // 0x60
		private AbsoluteLayout m_arrowAbs; // 0x64
		private bool m_isClossFade; // 0x68
		private ViewBase m_lockIconView; // 0x6C
		private ViewBase m_rateTextView; // 0x70
		private CFHDKAFLNEP.OCNHGDCPJDG m_info; // 0x74
		public bool IsShowSceneDetail; // 0x94

		// RVA: 0x1A9F970 Offset: 0x1A9F970 VA: 0x1A9F970 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_abs = m_runtime.FindViewBase(m_baseObject.transform as RectTransform) as AbsoluteLayout;
			m_arrowAbs = m_runtime.FindViewBase(m_arrow) as AbsoluteLayout;
			m_lockIconView = m_runtime.FindViewBase(m_lockIconObject.transform as RectTransform) as AbsoluteLayout;
			m_rateTextView = m_runtime.FindViewBase(m_rateTextObject.transform as RectTransform) as AbsoluteLayout;
			return true;
		}

		//// RVA: 0x1A9FBE4 Offset: 0x1A9FBE4 VA: 0x1A9FBE4
		//private void ShowSceneDetailButton() { }

		//// RVA: 0x1A9FC48 Offset: 0x1A9FC48 VA: 0x1A9FC48
		private void ShowSceneDetail()
		{
			if (!m_info.DFIGPDCBAPB_IsInvalid)
			{
				IsShowSceneDetail = true;
				MenuScene.Instance.ShowSceneStatusPopupWindow(GameManager.Instance.ViewPlayerData.OPIBAPEGCLA_Scenes[m_info.PBPOLELIPJI_Id - 1], GameManager.Instance.ViewPlayerData, false, TransitionList.Type.UNDEFINED, () =>
				{
					//0x1A9FF24
					IsShowSceneDetail = false;
				}, false, false, SceneStatusParam.PageSave.Player, false);
			}
		}

		//// RVA: 0x1A9F05C Offset: 0x1A9F05C VA: 0x1A9F05C
		public void TryShowSceneDetail()
		{
			if (IsShowSceneDetail)
				ShowSceneDetail();
		}

		//// RVA: 0x1A9E608 Offset: 0x1A9E608 VA: 0x1A9E608
		public void InitializeFromContent(PopupSubPlateContent content, UnitWindowConstant.OperationMode opMode)
		{
			m_buffColor = ColorConvert.Convert(StatusTextColor.UpColor);
			m_isClossFade = false;
			m_debuffColor = ColorConvert.Convert(StatusTextColor.DebuffColor);
			m_info = content.subPlateResult.KOGBMDOONFA[m_attribute, m_status];
			if (m_info.CDOCOLOKCJK_HasRate)
			{
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				StringBuilder str = new StringBuilder(16);
				str.SetFormat(bk.GetMessageByLabel("subplate_rate_text"), m_info.ADKDHKMPMHP_Rate);
				m_rateText.text = str.ToString();
				if(!m_info.DFIGPDCBAPB_IsInvalid)
				{
					str.SetFormat("{0}", m_info.OEOIHIIIMCK_Add);
					m_addText.text = str.ToString();
					if(m_info.IKEJLHJEANO == 1)
					{
						RichTextUtility.ChangeColor(m_addText, StatusTextColor.UpColor);
						m_arrowAbs.StartChildrenAnimGoStop("st_wait_01");
					}
					else if(m_info.IKEJLHJEANO == 2)
					{
						RichTextUtility.ChangeColor(m_addText, StatusTextColor.DownColor);
						m_arrowAbs.StartChildrenAnimGoStop("st_wait_02");
					}
					else if (m_info.IKEJLHJEANO == 3)
					{
						ResetClossFade();
					}
					else
					{
						m_arrowAbs.StartChildrenAnimGoStop("st_non");
					}
					m_detailButton.ClearOnStayCallback();
					if(opMode != UnitWindowConstant.OperationMode.Detail)
					{
						m_detailButton.AddOnStayCallback(() =>
						{
							//0x1A9FF30
							SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
							ShowSceneDetail();
						});
					}
					MenuScene.Instance.SceneIconCache.Load(m_info.PBPOLELIPJI_Id, m_info.IFFKEMEOFAE_EvolveId, (IiconTexture texture) =>
					{
						//0x1A9FF94
						texture.Set(m_image);
						SceneIconTextureCache.ChangeKiraMaterial(m_image, texture as IconTexture, m_info.OGHIOHAACIB_IsKira);
					});
				}
			}
			//LAB_01a9ec00
			SwitchDisplay(eDisplay.Normal);
		}

		//// RVA: 0x1A9ED78 Offset: 0x1A9ED78 VA: 0x1A9ED78
		public void SwitchDisplay(eDisplay display)
		{
			if(!m_info.CDOCOLOKCJK_HasRate || m_info.DFIGPDCBAPB_IsInvalid)
			{
				StringBuilder str = new StringBuilder(8);
				str.SetFormat("{0:D2}", m_attribute + 1);
				m_abs.StartChildrenAnimGoStop(str.ToString());
				if (!m_info.CDOCOLOKCJK_HasRate)
				{
					m_lockIconView.enabled = true;
					m_rateTextView.enabled = false;
				}
				else
				{
					m_lockIconView.enabled = false;
					m_rateTextView.enabled = true;
				}
				return;
			}
			m_rateTextView.enabled = true;
			m_abs.StartChildrenAnimGoStop(display == eDisplay.Normal ? "04" : "05");
		}

		//// RVA: 0x1A9F404 Offset: 0x1A9F404 VA: 0x1A9F404
		public void ClossFade(AnimeCurveScriptableObject animeCurve)
		{
			if(m_isClossFade)
			{
				m_addText.color = Color.Lerp(m_buffColor, m_debuffColor, animeCurve[0].Evaluate(GetIconLoopAnimeTime()));
			}
		}

		//// RVA: 0x1A9FE14 Offset: 0x1A9FE14 VA: 0x1A9FE14
		public void ResetClossFade()
		{
			m_arrowAbs.StartChildrenAnimLoop("logo_act");
			m_isClossFade = true;
		}

		//// RVA: 0x1A9FE98 Offset: 0x1A9FE98 VA: 0x1A9FE98
		public float GetIconLoopAnimeTime()
		{
			return m_arrowAbs[0].FrameAnimation.AnimCount - 0.1f;
		}
	}
}
