using UnityEngine;
using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine.UI;
using System;

namespace XeApp.Game.Menu
{
	public class SetDeckSceneControl : MonoBehaviour
	{
		public enum SkillType
		{
			Active = 0,
			Live = 1,
		}

		//[TooltipAttribute] // RVA: 0x682870 Offset: 0x682870 VA: 0x682870
		//[HeaderAttribute] // RVA: 0x682870 Offset: 0x682870 VA: 0x682870
		[SerializeField]
		private UGUIStayButton m_sceneButton; // 0xC
		//[TooltipAttribute] // RVA: 0x6828F0 Offset: 0x6828F0 VA: 0x6828F0
		[SerializeField]
		private RawImageEx m_sceneImage; // 0x10
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x682944 Offset: 0x682944 VA: 0x682944
		private Image m_attrIconEffectImage; // 0x14
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x6829AC Offset: 0x6829AC VA: 0x6829AC
		private SpriteAnime m_attrIconEffectAnime; // 0x18
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x6829F4 Offset: 0x6829F4 VA: 0x6829F4
		private SetDeckSceneStatusControl m_statucControl; // 0x1C
		//[TooltipAttribute] // RVA: 0x682A50 Offset: 0x682A50 VA: 0x682A50
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x682A50 Offset: 0x682A50 VA: 0x682A50
		private MusicAttrIconScriptableObject m_attrIconEffectSprites; // 0x20
		public Action OnClickSceneButton; // 0x24
		public Action OnStaySceneButton; // 0x28
		private GCIJNCFDNON_SceneInfo m_sceneData; // 0x2C
		private int m_divaId; // 0x30
		private int m_musicId; // 0x34
		private SetDeckSceneControl.SkillType m_skillTyoe; // 0x38
		private int m_sceneTextureLoadingCount; // 0x3C

		public bool IsLoading { get { return m_sceneTextureLoadingCount > 0; } } //0xA6828C
		public GCIJNCFDNON_SceneInfo SceneData { get { return m_sceneData; } } //0xA74080
		public UGUIStayButton SceneButton { get { return m_sceneButton; } } //0xA74088
		//private bool IsEmpty { get; } 0xA74090

		// RVA: 0xA740A4 Offset: 0xA740A4 VA: 0xA740A4
		private void Awake()
		{
			if(m_sceneButton != null)
			{
				m_sceneButton.AddOnClickCallback(() =>
				{
					//0xA748B8
					if(OnClickSceneButton != null)
					{
						OnClickSceneButton();
					}
				});
				m_sceneButton.AddOnStayCallback(() =>
				{
					//0xA748CC
					if(OnStaySceneButton != null)
					{
						OnStaySceneButton();
					}
				});
			}
		}

		// RVA: 0xA741F0 Offset: 0xA741F0 VA: 0xA741F0
		private void Update()
		{
			return;
		}

		//// RVA: 0xA68F94 Offset: 0xA68F94 VA: 0xA68F94
		public void Set(int divaId, SkillType skillType, GCIJNCFDNON_SceneInfo sceneData, int musicId = 0)
		{
			m_divaId = divaId;
			m_sceneData = sceneData;
			m_musicId = musicId;
			m_skillTyoe = skillType;
			m_sceneTextureLoadingCount++;
			if(sceneData == null)
			{
				GameManager.Instance.SceneIconCache.Load(0, 0, (IiconTexture texture) =>
				{
					//0xA74A4C
					m_sceneTextureLoadingCount--;
					texture.Set(m_sceneImage);
					SceneIconTextureCache.ChangeKiraMaterial(m_sceneImage, texture as IconTexture, false);
				});
			}
			else
			{
				GameManager.Instance.SceneIconCache.Load(m_sceneData.BCCHOBPJJKE_SceneId, m_sceneData.CGIELKDLHGE_GetEvolveId(), (IiconTexture texture) =>
				{
					//0xA748E0
					m_sceneTextureLoadingCount--;
					texture.Set(m_sceneImage);
					SceneIconTextureCache.ChangeKiraMaterial(m_sceneImage, texture as IconTexture, m_sceneData.MBMFJILMOBP_IsKira());
				});
			}
			if(m_sceneData == null)
			{
				m_attrIconEffectImage.enabled = false;
				m_attrIconEffectAnime.Stop();
			}
			else
			{
				if (IsMatchMusicAttr(m_sceneData, musicId))
				{
					m_attrIconEffectImage.enabled = true;
					m_attrIconEffectImage.sprite = GetAttrIconSprite(m_sceneData.JGJFIJOCPAG_SceneAttr);
					m_attrIconEffectAnime.Stop(true);
					m_attrIconEffectAnime.Play(0, null);
				}
				else
				{
					m_attrIconEffectImage.enabled = false;
					m_attrIconEffectAnime.Stop();
				}
			}
			m_statucControl.SetOff();
		}

		//// RVA: 0xA743C0 Offset: 0xA743C0 VA: 0xA743C0
		public void SetEmpty()
		{
			Set(0, SkillType.Live, null, 0);
		}

		//// RVA: 0xA68CB8 Offset: 0xA68CB8 VA: 0xA68CB8
		public void SetStatusDisplayType(DisplayType type)
		{
			if(m_sceneData == null)
			{
				m_statucControl.SetOff();
			}
			else
			{
				m_statucControl.Set(m_sceneData, type, m_divaId, m_musicId);
			}
		}

		//// RVA: 0xA68D30 Offset: 0xA68D30 VA: 0xA68D30
		public void SetStatusDisplayForRival()
		{
			if(m_sceneData == null)
			{
				m_statucControl.SetOff();
			}
			else
			{
				m_statucControl.SetForRival(m_sceneData);
			}
		}

		//// RVA: 0xA74344 Offset: 0xA74344 VA: 0xA74344
		private Sprite GetAttrIconSprite(int attr)
		{
			return m_attrIconEffectSprites.GetMusicAttrIconSprite(attr);
		}

		//// RVA: 0xA741F4 Offset: 0xA741F4 VA: 0xA741F4
		private bool IsMatchMusicAttr(GCIJNCFDNON_SceneInfo sceneData, int musicId)
		{
			EONOEHOKBEB_Music m = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(musicId);
			return CMMKCEPBIHI.OJNOJNEKBKH(m != null ? m.FKDCCLPGKDK_Ma : 0, sceneData.JGJFIJOCPAG_SceneAttr);
		}
		
	}
}

