using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class SetDeckSkillIconControl : MonoBehaviour
	{
		public enum SkillType
		{
			Active = 0,
			Live = 1,
		}

		[SerializeField]
		//[TooltipAttribute] // RVA: 0x6834AC Offset: 0x6834AC VA: 0x6834AC
		private Image m_skillIconImage; // 0xC
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x683508 Offset: 0x683508 VA: 0x683508
		private Sprite m_lSkillSprite; // 0x10
		//[TooltipAttribute] // RVA: 0x683570 Offset: 0x683570 VA: 0x683570
		[SerializeField]
		private Sprite m_aSkillSprite; // 0x14
		//[TooltipAttribute] // RVA: 0x6835D8 Offset: 0x6835D8 VA: 0x6835D8
		[SerializeField]
		private SpriteAnime m_effectAnime; // 0x18
		private static readonly Color IconColorOn = Color.white; // 0x0
		private static readonly Color IconColorOff = Color.gray; // 0x10

		// RVA: 0xA6BF08 Offset: 0xA6BF08 VA: 0xA6BF08
		public void Set(int divaId, SkillType skillType, GCIJNCFDNON_SceneInfo sceneData, int musicId = 0)
		{
			m_skillIconImage.enabled = false;
			SetEffectEnable(false);
			if(sceneData != null)
			{
				if(skillType == SkillType.Live)
				{
					int a = sceneData.FILPDDHMKEJ(false, 0, 0);
					if(a > 0 && sceneData.DCLLIDMKNGO_IsDivaCompatible(divaId))
					{
						bool b = CheckMatchLiveSkill(sceneData, divaId, musicId);
						m_skillIconImage.enabled = true;
						if(!b)
						{
							m_skillIconImage.color = IconColorOff;
						}
						else
						{
							m_skillIconImage.color = IconColorOn;
						}
						m_skillIconImage.sprite = m_lSkillSprite;
						SetEffectEnable(b);
					}
				}
				else if(skillType == SkillType.Active && CheckMatchActiveSkill(sceneData))
				{
					m_skillIconImage.enabled = true;
					if(sceneData.HGONFBDIBPM_ActiveSkillId < 1)
					{
						m_skillIconImage.color = IconColorOff;
					}
					else
					{
						m_skillIconImage.color = IconColorOn;
					}
					m_skillIconImage.sprite = m_aSkillSprite;
					SetEffectEnable(sceneData.HGONFBDIBPM_ActiveSkillId > 0);
				}
			}
		}

		//// RVA: 0xA76570 Offset: 0xA76570 VA: 0xA76570
		public static bool CheckMatchActiveSkill(GCIJNCFDNON_SceneInfo sceneData)
		{
			return sceneData.HGONFBDIBPM_ActiveSkillId > 0;
		}

		//// RVA: 0xA765A0 Offset: 0xA765A0 VA: 0xA765A0
		public static bool CheckMatchLiveSkill(GCIJNCFDNON_SceneInfo sceneData, int divaId, int musicId)
		{
			if(sceneData.FILPDDHMKEJ(false, 0, 0) > 0)
			{
				if(sceneData.DCLLIDMKNGO_IsDivaCompatible(divaId))
				{
					if(musicId > 0)
					{
						if(sceneData.PKPCDAAHJGP_HasLiveSkillCondMusic())
						{
							if (!sceneData.ADDCCPKEFOC_IsMatchLiveSkillMusic(musicId))
								return false;
						}
						if(sceneData.GOEFBDNFNAA_HasLiveSkillCondAttr())
						{
							return sceneData.JEDMBJEICBB_IsLiveSkillMatchAttr(musicId, false);
						}
					}
					return true;
				}
			}
			return false;
		}

		//// RVA: 0xA76470 Offset: 0xA76470 VA: 0xA76470
		private void SetEffectEnable(bool isEnable)
		{
			if(!isEnable)
			{
				m_effectAnime.Stop(true);
				m_effectAnime.gameObject.SetActive(false);
			}
			else
			{
				m_effectAnime.Stop(true);
				m_effectAnime.Play(0, null);
			}
		}
	}
}
