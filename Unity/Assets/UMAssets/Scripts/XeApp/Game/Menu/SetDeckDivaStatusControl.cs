using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class SetDeckDivaStatusControl : MonoBehaviour
	{
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x680B74 Offset: 0x680B74 VA: 0x680B74
		private List<SetDeckSkillIconControl> m_skillIcons; // 0xC
		//[TooltipAttribute] // RVA: 0x680BBC Offset: 0x680BBC VA: 0x680BBC
		[SerializeField]
		private Text m_statusTitleText; // 0x10
		//[TooltipAttribute] // RVA: 0x680C24 Offset: 0x680C24 VA: 0x680C24
		[SerializeField]
		private Image m_statusValueBackImage; // 0x14
		//[TooltipAttribute] // RVA: 0x680C84 Offset: 0x680C84 VA: 0x680C84
		[SerializeField]
		private Text m_statusValueText; // 0x18
		//[TooltipAttribute] // RVA: 0x680CCC Offset: 0x680CCC VA: 0x680CCC
		[SerializeField]
		private GameObject m_musicExpObject; // 0x1C
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x680D30 Offset: 0x680D30 VA: 0x680D30
		private Text m_musicExpLevelText; // 0x20
		//[TooltipAttribute] // RVA: 0x680D98 Offset: 0x680D98 VA: 0x680D98
		[SerializeField]
		private UGUIGauge m_musicExpGauge; // 0x24
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x680DF8 Offset: 0x680DF8 VA: 0x680DF8
		private GameObject m_musicExpGaugeBandObject; // 0x28
		//[TooltipAttribute] // RVA: 0x680E68 Offset: 0x680E68 VA: 0x680E68
		[SerializeField]
		private Image m_musicExpGaugeBandHeadImage; // 0x2C
		//[TooltipAttribute] // RVA: 0x680ED0 Offset: 0x680ED0 VA: 0x680ED0
		[SerializeField]
		private Image m_musicExpGaugeMaxImage; // 0x30
		private EDMIONMCICN m_calcStatusResult; // 0x34
		private StatusData m_status = new StatusData(); // 0x58

		//// RVA: 0xA6AE5C Offset: 0xA6AE5C VA: 0xA6AE5C
		public void SetSkill(FFHPBEPOMAK divaData, DFKGGBMFFGB playerData, bool isCenter, int musicId = 0)
		{
			if(divaData.FGFIBOBAPIA_SceneId < 1)
			{
				m_skillIcons[0].Set(divaData.AHHJLDLAPAN_DivaId, isCenter ? SetDeckSkillIconControl.SkillType.Active : SetDeckSkillIconControl.SkillType.Live, null, musicId);
			}
			else
			{
				m_skillIcons[0].Set(divaData.AHHJLDLAPAN_DivaId, isCenter ? SetDeckSkillIconControl.SkillType.Active : SetDeckSkillIconControl.SkillType.Live, playerData.OPIBAPEGCLA_Scenes[divaData.FGFIBOBAPIA_SceneId - 1], musicId);
			}
			for(int i = 0; i < divaData.DJICAKGOGFO_SubSceneIds.Count; i++)
			{
				if(divaData.DJICAKGOGFO_SubSceneIds[i] < 1)
				{
					m_skillIcons[i + 1].Set(divaData.AHHJLDLAPAN_DivaId, SetDeckSkillIconControl.SkillType.Live, null, musicId);
				}
				else
				{
					m_skillIcons[i + 1].Set(divaData.AHHJLDLAPAN_DivaId, SetDeckSkillIconControl.SkillType.Live, playerData.OPIBAPEGCLA_Scenes[divaData.DJICAKGOGFO_SubSceneIds[i] - 1], musicId);
				}
			}
		}

		//// RVA: 0xA6B7E0 Offset: 0xA6B7E0 VA: 0xA6B7E0
		public void SetDispType(DisplayType type, FFHPBEPOMAK divaData, DFKGGBMFFGB playerData, int musicId, bool isStory, bool isGoDivaSub)
		{
			SetStatusTextEnable(false);
			SetMusicExpEnable(false);
			if(type != DisplayType.Total)
			{
				if(type == DisplayType.MusicExp)
				{
					m_statusTitleText.text = MessageManager.Instance.GetBank("menu").GetMessageByLabel("unit_diva_status_titla_music_exp");
					SetMusicExpEnable(true);
					if(isStory ||isGoDivaSub)
					{
						SetInvalidMusicExp();
						return;
					}
					SetMusicExp(divaData, playerData, musicId);
				}
				else if(type == DisplayType.Level)
				{
					m_statusTitleText.text = MessageManager.Instance.GetBank("menu").GetMessageByLabel("unit_diva_status_titla_level");
					SetStatusTextEnable(true);
					if(isGoDivaSub)
					{
						SetInvalidStatusValue();
						return;
					}
					SetStatusValue(divaData.CIEOBFIIPLD_Level);
				}
				return;
			}
			CMMKCEPBIHI.AECDJDIJJKD(ref m_calcStatusResult, divaData, null, playerData, null, null, null);
			m_status.Clear();
			m_calcStatusResult.IMLOCECFHGK(ref m_status);
			m_status.Add(divaData.CMCKNKKCNDK_EquippedStatus);
			m_statusTitleText.text = MessageManager.Instance.GetBank("menu").GetMessageByLabel("unit_diva_status_titla_total");
			SetStatusTextEnable(true);
			SetStatusValue(m_status.Total);
		}

		//// RVA: 0xA6C378 Offset: 0xA6C378 VA: 0xA6C378
		private void SetStatusTextEnable(bool isEnable)
		{
			m_statusValueText.gameObject.SetActive(isEnable);
			m_statusValueBackImage.gameObject.SetActive(isEnable);
		}

		//// RVA: 0xA6C4CC Offset: 0xA6C4CC VA: 0xA6C4CC
		private void SetStatusValue(int value)
		{
			m_statusValueText.text = value.ToString();
		}

		//// RVA: 0xA6C448 Offset: 0xA6C448 VA: 0xA6C448
		private void SetInvalidStatusValue()
		{
			m_statusValueText.text = "StringLiteral_20367";
		}

		//// RVA: 0xA6C414 Offset: 0xA6C414 VA: 0xA6C414
		private void SetMusicExpEnable(bool isEnable)
		{
			m_musicExpObject.SetActive(isEnable);
		}

		//// RVA: 0xA6C630 Offset: 0xA6C630 VA: 0xA6C630
		private void SetMusicExp(FFHPBEPOMAK divaData, DFKGGBMFFGB playerData, int musicId)
		{
			if (musicId < 1)
				SetInvalidMusicExp();
			else
			{
				/*FFHPBEPOMAK f = playerData.NBIGLBMHEDC.Find(() =>
				{
					Method$XeApp.Game.Menu.SetDeckDivaStatusControl.<>c__DisplayClass18_0.<SetMusicExp>b__0()
				});
				KDOMGMCGHDC.HJNMIKNAMFH h = KDOMGMCGHDC.ODIAFJCPIFO(musicId, f.AHHJLDLAPAN_DivaId, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, f.PKLPGBKKFOL[musicId - 1]);
				if(h == null)
				{
					SetInvalidMusicExp();
				}
				else
				{

				}*/
				TodoLogger.Log(0, "SetMusicExp");
			}
		}

		//// RVA: 0xA6C520 Offset: 0xA6C520 VA: 0xA6C520
		private void SetInvalidMusicExp()
		{
			m_musicExpLevelText.text = "StringLiteral_20367";
			m_musicExpGauge.CurrentValue = 0;
			m_musicExpGaugeBandObject.SetActive(false);
			m_musicExpGaugeMaxImage.gameObject.SetActive(false);
		}
	}
}
