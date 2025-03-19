using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System;
using mcrs;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutPopupDivaSkillInfoItem : LayoutUGUIScriptBase
	{
		public enum eGaugeStatus
		{
			Normal = 0,
			Max = 1,
			Lock = 2,
		}

		[SerializeField]
		private NumberBase m_level; // 0x14
		[SerializeField]
		private NumberBase m_nowExp; // 0x18
		[SerializeField]
		private NumberBase m_maxExp; // 0x1C
		[SerializeField]
		private Text m_divaName; // 0x20
		[SerializeField]
		private Text m_unlockText; // 0x24
		[SerializeField]
		private GameObject m_divaIcon; // 0x28
		[SerializeField]
		private ActionButton m_conditionsButton; // 0x2C
		[SerializeField]
		private NumberBase m_levelLock; // 0x30
		private AbsoluteLayout m_gauge; // 0x34
		private AbsoluteLayout m_status; // 0x38
		private AbsoluteLayout m_conditionsIconLayout; // 0x3C
		private AbsoluteLayout m_boostExpIcon; // 0x40
		private RawImageEx m_divaIconImage; // 0x44
		private RectTransform m_rtTransform; // 0x48
		private GameObject m_base; // 0x4C
		private string m_unlockMessage = ""; // 0x50
		private Action m_conditionsCallback; // 0x54
		private Action m_conditionsCloseCallback; // 0x58

		//// RVA: 0x171EB78 Offset: 0x171EB78 VA: 0x171EB78
		public void SetStatus(FFHPBEPOMAK_DivaInfo divaData, int musicId, bool isBoostExp)
		{
			if (musicId == 0)
				return;
			KDOMGMCGHDC.HJNMIKNAMFH a = KDOMGMCGHDC.ODIAFJCPIFO(musicId, divaData.AHHJLDLAPAN_DivaId, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, divaData.PKLPGBKKFOL_DivaLevels[musicId - 1]);
			if (a == null)
				Reset();
			else
			{
				SetDivaName(divaData.OPFGFINHFCE_Name);
				SetDivaSkillLevel(divaData.PKLPGBKKFOL_DivaLevels[musicId - 1]);
				int now = divaData.HMBECPGHPOE_DivaExps[musicId - 1] - a.PMBFNFOCNAJ_CurLevelMusicExp;
				int max = a.PBGFIOONCMB_NextLevelMusicExp - a.PMBFNFOCNAJ_CurLevelMusicExp;
				SetDivaExp(now, max);
				m_boostExpIcon.enabled = isBoostExp;
				SetGaugeValue(max < 1 ? 0 : (int)(now * 100.0f / max));
				if (a.NBHEBLNHOJO_IsMax)
				{
					SwitchBarStatus(eGaugeStatus.Max);
					SetUnlockText("");
				}
				else if(!a.HHBJAEOIGIH_IsLocked)
				{
					SwitchBarStatus(eGaugeStatus.Normal);
					SetUnlockText("");
				}
				else
				{
					SwitchBarStatus(eGaugeStatus.Lock);
					SetUnlockText(a.ONIAMNAJLKI_LockMessage);
				}
				SetDivaIcon(divaData.AHHJLDLAPAN_DivaId, divaData.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId, divaData.EKFONBFDAAP_ColorId);
			}
		}

		//// RVA: 0x171F704 Offset: 0x171F704 VA: 0x171F704
		public void SetConditionsCallback(Action prevCallback, Action closeCallback)
		{
			m_conditionsCallback = prevCallback;
			m_conditionsCloseCallback = closeCallback;
		}

		//// RVA: 0x171F264 Offset: 0x171F264 VA: 0x171F264
		public void SetGaugeValue(int value)
		{
			if (m_gauge == null)
				return;
			int v = Mathf.Clamp(value, 0, 100);
			m_gauge.StartAllAnimGoStop(v, v);
		}

		//// RVA: 0x171F32C Offset: 0x171F32C VA: 0x171F32C
		public void SwitchBarStatus(eGaugeStatus status)
		{
			switch(status)
			{
				case eGaugeStatus.Normal:
					m_status.StartChildrenAnimGoStop("01");
					break;
				case eGaugeStatus.Max:
					m_status.StartChildrenAnimGoStop("02");
					break;
				case eGaugeStatus.Lock:
					m_status.StartChildrenAnimGoStop("03");
					break;
				default:
					break;
			}
		}

		//// RVA: 0x171EF04 Offset: 0x171EF04 VA: 0x171EF04
		public void SetDivaName(string text)
		{
			if (m_divaName == null)
				return;
			m_divaName.text = text;
		}

		//// RVA: 0x171F710 Offset: 0x171F710 VA: 0x171F710
		public void SetConditionsIcon(bool enable)
		{
			if (m_conditionsIconLayout == null)
				return;
			m_conditionsIconLayout.enabled = enable;
			SetConditionsButtonEnable(enable);
		}

		//// RVA: 0x171F750 Offset: 0x171F750 VA: 0x171F750
		public void SetConditionsButtonEnable(bool enable)
		{
			if (m_conditionsButton == null)
				return;
			if (m_conditionsIconLayout == null)
				return;
			m_conditionsButton.enabled = m_conditionsIconLayout.enabled && enable;
		}

		//// RVA: 0x171F83C Offset: 0x171F83C VA: 0x171F83C
		private void OnClickCallbackConditionsButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			if(m_conditionsCallback != null)
				m_conditionsCallback();
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			PopupWindowManager.Show(PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("growth_popup_title_01"), SizeType.Small, m_unlockMessage, new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			}, false, true), (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1720188
				if(m_conditionsCloseCallback != null)
					m_conditionsCloseCallback();
			}, null, null, null);
		}

		//// RVA: 0x171F3DC Offset: 0x171F3DC VA: 0x171F3DC
		public void SetUnlockText(string text)
		{
			m_unlockMessage = "";
			SetConditionsIcon(false);
			if (m_unlockText != null)
			{
				m_unlockText.text = text;
				if(DivaGrowthListItem.SetConditionsText(m_unlockText, text))
				{
					m_unlockMessage = text;
					SetConditionsIcon(true);
				}
			}
		}

		//// RVA: 0x171EFC4 Offset: 0x171EFC4 VA: 0x171EFC4
		public void SetDivaSkillLevel(int level)
		{
			if(m_level != null)
			{
				m_level.SetNumber(level, 0);
			}
			if(m_levelLock != null)
			{
				m_levelLock.SetNumber(level, 0);
			}
		}

		//// RVA: 0x171F104 Offset: 0x171F104 VA: 0x171F104
		public void SetDivaExp(int now, int max)
		{
			if(m_nowExp != null)
			{
				m_nowExp.SetNumber(now, 0);
			}
			if(m_maxExp != null)
			{
				m_maxExp.SetNumber(max, 0);
			}
		}

		//// RVA: 0x171F248 Offset: 0x171F248 VA: 0x171F248
		//public void SetBoostExpIcon(bool enable) { }

		//// RVA: 0x171F518 Offset: 0x171F518 VA: 0x171F518
		public void SetDivaIcon(int divaId, int modelId, int colorId)
		{
			if(m_divaIconImage != null)
			{
				if(MenuScene.Instance != null)
				{
					MenuScene.Instance.DivaIconCache.Load(divaId, modelId, colorId, (IiconTexture texture) =>
					{
						//0x172019C
						texture.Set(m_divaIconImage);
					});
				}
			}
		}

		//// RVA: 0x171FAD0 Offset: 0x171FAD0 VA: 0x171FAD0
		public void SetPosition(int x, int y)
		{
			if(m_rtTransform != null)
			{
				m_rtTransform.anchoredPosition = new Vector2(x, -y);
			}
		}

		//// RVA: 0x171FBCC Offset: 0x171FBCC VA: 0x171FBCC
		public void Show()
		{
			gameObject.SetActive(true);
		}

		//// RVA: 0x171FC04 Offset: 0x171FC04 VA: 0x171FC04
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x171EE4C Offset: 0x171EE4C VA: 0x171EE4C
		public void Reset()
		{
			SetGaugeValue(0);
			SetDivaName("");
			SetUnlockText("");
			SetDivaExp(0, 0);
			SetDivaName("");
			SetDivaSkillLevel(0);
			DeleteImage(ref m_divaIconImage);
			m_conditionsCallback = null;
			m_conditionsCloseCallback = null;
		}

		//// RVA: 0x171FC3C Offset: 0x171FC3C VA: 0x171FC3C
		private void DeleteImage(ref RawImageEx image)
		{
			if (image == null)
				return;
			image.material = null;
			image.MaterialMul = null;
			image.MaterialAdd = null;
			image.texture = null;
			image.alphaTexture = null;
		}

		// RVA: 0x171FD8C Offset: 0x171FD8C VA: 0x171FD8C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_base = gameObject;
			m_status = layout.FindViewByExId("sw_pop_diva_exp_info_swtbl_s_m_popup_diva_bar") as AbsoluteLayout;
			m_gauge = layout.FindViewByExId("swfrm_pop_diva_exp_bar_anim_s_m_popup_diva_bar_under") as AbsoluteLayout;
			m_conditionsIconLayout = layout.FindViewByExId("sw_pop_diva_exp_info_pop_diva_exp_icon") as AbsoluteLayout;
			m_boostExpIcon = layout.FindViewByExId("sw_pop_diva_exp_info_cmn_status_icon_up") as AbsoluteLayout;
			if(m_divaIcon != null)
			{
				m_divaIconImage = m_divaIcon.GetComponent<RawImageEx>();
			}
			if(m_conditionsButton != null)
			{
				m_conditionsButton.AddOnClickCallback(OnClickCallbackConditionsButton);
			}
			m_rtTransform = GetComponent<RectTransform>();
			Loaded();
			return true;
		}

		//// RVA: 0x1720114 Offset: 0x1720114 VA: 0x1720114
		public GameObject GetBase()
		{
			return m_base;
		}
	}
}
