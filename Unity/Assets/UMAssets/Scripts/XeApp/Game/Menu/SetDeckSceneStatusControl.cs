using UnityEngine;
using XeApp.Game.Common;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class SetDeckSceneStatusControl : MonoBehaviour
	{

		//[TooltipAttribute] // RVA: 0x682C7C Offset: 0x682C7C VA: 0x682C7C
		//[HeaderAttribute] // RVA: 0x682C7C Offset: 0x682C7C VA: 0x682C7C
		[SerializeField]
		private GameObject m_paramObject; // 0xC
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x682D0C Offset: 0x682D0C VA: 0x682D0C
		private UGUICrossFader m_paramCrossFader; // 0x10
		//[TooltipAttribute] // RVA: 0x682D54 Offset: 0x682D54 VA: 0x682D54
		[SerializeField]
		private TextMeshProUGUI m_paramText; // 0x14
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x682DBC Offset: 0x682DBC VA: 0x682DBC
		private GameObject m_luckyLeafObject; // 0x18
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x682E18 Offset: 0x682E18 VA: 0x682E18
		private UGUIPositionTable m_luckyLeafPosTbl; // 0x1C
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x682E70 Offset: 0x682E70 VA: 0x682E70
		private TextMeshProUGUI m_luckyLeafText; // 0x20
		//[TooltipAttribute] // RVA: 0x682ECC Offset: 0x682ECC VA: 0x682ECC
		[SerializeField]
		private GameObject m_levelObject; // 0x24
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x682F28 Offset: 0x682F28 VA: 0x682F28
		private UGUICrossFader m_levelCrossFader; // 0x28
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x682F90 Offset: 0x682F90 VA: 0x682F90
		private GameObject m_levelMaxObject; // 0x2C
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x682FF0 Offset: 0x682FF0 VA: 0x682FF0
		private TextMeshProUGUI m_levelText; // 0x30
		//[TooltipAttribute] // RVA: 0x68304C Offset: 0x68304C VA: 0x68304C
		[SerializeField]
		private GameObject m_skillIconObject; // 0x34
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x6830B4 Offset: 0x6830B4 VA: 0x6830B4
		private UGUICrossFader m_skillIconCrossFader; // 0x38
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x683128 Offset: 0x683128 VA: 0x683128
		private List<Image> m_skillIconImages; // 0x3C
		//[TooltipAttribute] // RVA: 0x683188 Offset: 0x683188 VA: 0x683188
		[SerializeField]
		private Image m_activeIconImage; // 0x40
		//[TooltipAttribute] // RVA: 0x683204 Offset: 0x683204 VA: 0x683204
		[SerializeField]
		private GameObject m_episodeNameObject; // 0x44
		//[TooltipAttribute] // RVA: 0x68326C Offset: 0x68326C VA: 0x68326C
		[SerializeField]
		private Text m_episodeNameText; // 0x48
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x6832CC Offset: 0x6832CC VA: 0x6832CC
		private Image m_episodeNameBackImage; // 0x4C
		//[HeaderAttribute] // RVA: 0x68332C Offset: 0x68332C VA: 0x68332C
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x68332C Offset: 0x68332C VA: 0x68332C
		private SkillIconScriptableObject m_skillIconSprites; // 0x50
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x6833C0 Offset: 0x6833C0 VA: 0x6833C0
		private Sprite m_episodeNameBackSpriteNormal; // 0x54
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x683434 Offset: 0x683434 VA: 0x683434
		private Sprite m_episodeNameBackSpriteBonus; // 0x58
		private static readonly Color IconColorOn = Color.white; // 0x0
		private static readonly Color IconColorOff = Color.gray; // 0x10

		// RVA: 0xA74D3C Offset: 0xA74D3C VA: 0xA74D3C
		private void Awake()
		{
			return;
		}

		// RVA: 0xA74D40 Offset: 0xA74D40 VA: 0xA74D40
		private void Update()
		{
			return;
		}

		// // RVA: 0xA743EC Offset: 0xA743EC VA: 0xA743EC
		public void Set(GCIJNCFDNON sceneData, DisplayType type, int divaId, int musicId)
		{
			SetOff();
			switch(type)
			{
				case DisplayType.Total:
					SetParamEnable(true);
					ApplyParam(sceneData.CMCKNKKCNDK_Status.Total.ToString());
					break;
				case DisplayType.Soul:
					SetParamEnable(true);
					ApplyParam(sceneData.CMCKNKKCNDK_Status.soul.ToString());
					break;
				case DisplayType.Vocal:
					SetParamEnable(true);
					ApplyParam(sceneData.CMCKNKKCNDK_Status.vocal.ToString());
					break;
				case DisplayType.Charm:
					SetParamEnable(true);
					ApplyParam(sceneData.CMCKNKKCNDK_Status.charm.ToString());
					break;
				default:
					break;
				case DisplayType.Level:
					SetLevelEnable(true);
					ApplyLevel(sceneData.CIEOBFIIPLD_SceneLevel, IsMaxLevel(sceneData));
					break;
				case DisplayType.Life:
					SetParamEnable(true);
					ApplyParam(sceneData.CMCKNKKCNDK_Status.life.ToString());
					break;
				case DisplayType.Luck:
					SetParamEnable(true);
					ApplyParam(string.Format("+{0}", sceneData.MJBODMOLOBC_Luck));
					break;
				case DisplayType.Support:
					SetParamEnable(true);
					ApplyParam(sceneData.CMCKNKKCNDK_Status.support.ToString());
					break;
				case DisplayType.Fold:
					SetParamEnable(true);
					ApplyParam(sceneData.CMCKNKKCNDK_Status.fold.ToString());
					break;
				case DisplayType.ActiveSkill:
					SetSkillIconEnable(true);
					ApplySkillIconActive(sceneData);
					return;
				case DisplayType.LiveSkill:
					SetSkillIconEnable(true);
					ApplySkillIconLive(sceneData, divaId, musicId);
					return;
				case DisplayType.RecoveryNotes:
					SetEpisodeNameEnable(true);
					ApplyEpisodeName(sceneData.KELFCMEOPPM_EpisodeId);
					return;
			}
			if(sceneData.MKHFCGPJPFI_LimitOverCount > 0)
			{
				if (type != DisplayType.Level)
					SetParamEnable(true);
				SetLuckyLeafEnable(true);
				ApplyLuckyLeaf(sceneData.MKHFCGPJPFI_LimitOverCount, false);
			}
		}

		// // RVA: 0xA74800 Offset: 0xA74800 VA: 0xA74800
		public void SetForRival(GCIJNCFDNON sceneData)
		{
			SetOff();
			SetLevelEnable(true);
			ApplyLevel(sceneData.CIEOBFIIPLD_SceneLevel, IsMaxLevel(sceneData));
			if (sceneData.MKHFCGPJPFI_LimitOverCount < 1)
				return;
			SetParamEnable(true);
			SetLuckyLeafEnable(true);
			ApplyLuckyLeaf(sceneData.MKHFCGPJPFI_LimitOverCount, false);
		}

		// // RVA: 0xA74378 Offset: 0xA74378 VA: 0xA74378
		public void SetOff()
		{
			SetParamEnable(false);
			SetLevelEnable(false);
			SetSkillIconEnable(false);
			SetEpisodeNameEnable(false);
			SetLuckyLeafEnable(false);
		}

		// // RVA: 0xA74D44 Offset: 0xA74D44 VA: 0xA74D44
		private void SetParamEnable(bool isEnable)
		{
			if(m_paramObject != null)
				m_paramObject.SetActive(isEnable);
		}

		// // RVA: 0xA74E00 Offset: 0xA74E00 VA: 0xA74E00
		private void ApplyParam(string text)
		{
			if(m_paramObject != null)
			{
				m_paramText.text = text;
				m_paramCrossFader.Stop(0);
			}
		}

		// // RVA: 0xA74EE0 Offset: 0xA74EE0 VA: 0xA74EE0
		private void SetLevelEnable(bool isEnable)
		{
			if(m_levelObject != null)
				m_levelObject.SetActive(isEnable);
		}

		// // RVA: 0xA750D8 Offset: 0xA750D8 VA: 0xA750D8
		private void ApplyLevel(int level, bool isMax)
		{
			if(m_levelObject != null)
			{
				m_levelText.text = level.ToString();
				m_levelText.enableVertexGradient = isMax;
				m_levelMaxObject.SetActive(isMax);
				if (isMax)
					m_levelCrossFader.StartCrossFade();
				else
					m_levelCrossFader.Stop(0);
			}
		}

		// // RVA: 0xA7522C Offset: 0xA7522C VA: 0xA7522C
		private void SetSkillIconEnable(bool isEnable)
		{
			if(m_skillIconObject != null)
				m_skillIconObject.SetActive(isEnable);
		}

		// // RVA: 0xA752E8 Offset: 0xA752E8 VA: 0xA752E8
		private void ApplySkillIconActive(GCIJNCFDNON sceneData)
		{
			if(m_skillIconObject != null)
			{
				int a = 0;
				Color col = IconColorOff;
				if(sceneData.HGONFBDIBPM >= 1)
				{
					a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PABCHCAAEAA[sceneData.HGONFBDIBPM - 1].MKPJBDFDHOL[0];
					col = IconColorOn;
				}
				m_activeIconImage.enabled = true;
				m_activeIconImage.color = col;
				m_skillIconImages[0].sprite = GetSkilIconSprite(a);
				m_skillIconImages[0].color = col;
				m_skillIconCrossFader.Stop(0);
			}
		}

		// // RVA: 0xA756E8 Offset: 0xA756E8 VA: 0xA756E8
		private void ApplySkillIconLive(GCIJNCFDNON sceneData, int divaId, int musicId)
		{
			if(m_skillIconObject != null)
			{
				int a = 0;
				int iconId = 0;
				if (sceneData.FILPDDHMKEJ(false, 0, 0) > 0)
				{
					iconId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML[sceneData.FILPDDHMKEJ(false, 0, 0) - 1].MKPJBDFDHOL[0];
					a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML[sceneData.FILPDDHMKEJ(false, 0, 0) - 1].MKPJBDFDHOL[1];
				}
				Color col = IconColorOn;
				if(!CheckMatchLiveSkill(sceneData, divaId, musicId))
				{
					col = IconColorOff;
				}
				m_activeIconImage.enabled = false;
				m_skillIconImages[0].sprite = GetSkilIconSprite(iconId);
				m_skillIconImages[0].color = col;
				if(a < 1)
				{
					m_skillIconCrossFader.Stop(0);
					return;
				}
				m_skillIconImages[1].sprite = GetSkilIconSprite(a);
				m_skillIconImages[1].color = col;
				m_skillIconCrossFader.StartCrossFade();
			}
		}

		// // RVA: 0xA75CCC Offset: 0xA75CCC VA: 0xA75CCC
		private void SetEpisodeNameEnable(bool isEnable)
		{
			if(m_episodeNameObject != null)
			{
				m_episodeNameObject.SetActive(isEnable);
			}
		}

		// // RVA: 0xA75D88 Offset: 0xA75D88 VA: 0xA75D88
		private void ApplyEpisodeName(int episodeId)
		{
			if(m_episodeNameObject != null)
			{
				if(episodeId < 1)
				{
					m_episodeNameText.text = TextConstant.InvalidText;
				}
				else
				{
					m_episodeNameText.text = PIGBBNDPPJC.EJOJNFDHDHN(episodeId);
				}
				if(episodeId < 1)
				{
					m_episodeNameBackImage.sprite = m_episodeNameBackSpriteNormal;
				}
				else
				{
					m_episodeNameBackImage.sprite = Database.Instance.bonusData.EffectiveEpisodeBonus.FindIndex((IKDICBBFBMI_EventBase.GNPOABJANKO x) =>
					{
						//0xA76438
						return x.KELFCMEOPPM_EpisodeId == episodeId;
					}) > -1 ? m_episodeNameBackSpriteBonus : m_episodeNameBackSpriteNormal;
				}
			}
		}

		// // RVA: 0xA75FE4 Offset: 0xA75FE4 VA: 0xA75FE4
		private void SetLuckyLeafEnable(bool isEnable)
		{
			if(m_luckyLeafObject != null)
			{
				m_luckyLeafObject.SetActive(isEnable);
			}
		}

		// // RVA: 0xA760A0 Offset: 0xA760A0 VA: 0xA760A0
		private void ApplyLuckyLeaf(int count, bool isCrossFade = true)
		{
			if(m_luckyLeafObject != null)
			{
				m_luckyLeafText.text = string.Format("StringLiteral_14007 {0}", count);
				m_luckyLeafPosTbl.SetPosition(0);
				m_paramCrossFader.Stop(0);
			}
		}

		// // RVA: 0xA74F9C Offset: 0xA74F9C VA: 0xA74F9C
		private bool IsMaxLevel(GCIJNCFDNON sceneData)
		{
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.LAGGGIEIPEG(sceneData.JKGFBFPIMGA, true, sceneData.MCCIFLKCNKO) < sceneData.CIEOBFIIPLD_SceneLevel;
		}

		// // RVA: 0xA76218 Offset: 0xA76218 VA: 0xA76218
		private Sprite GetSkilIconSprite(int iconId)
		{
			return m_skillIconSprites.GetSkillIconSprite(iconId);
		}

		// // RVA: 0xA761E8 Offset: 0xA761E8 VA: 0xA761E8
		// private bool CheckMatchActiveSkill(GCIJNCFDNON sceneData) { }

		// // RVA: 0xA7624C Offset: 0xA7624C VA: 0xA7624C
		private bool CheckMatchLiveSkill(GCIJNCFDNON sceneData, int divaId, int musicId)
		{
			if (sceneData.FILPDDHMKEJ(false, 0, 0) > 0)
			{
				if(sceneData.DCLLIDMKNGO(divaId))
				{
					if(musicId > 0)
					{
						if(sceneData.PKPCDAAHJGP())
						{
							if (sceneData.ADDCCPKEFOC(musicId))
								return false;
						}
						if (sceneData.GOEFBDNFNAA())
						{
							return sceneData.JEDMBJEICBB(musicId, false);
						}
					}
					return true;
				}
			}
			return false;
		}
	}
}
