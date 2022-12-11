using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;
using UnityEngine.Events;
using System.Text;

namespace XeApp.Game.Menu
{
	public class DivaSelectListIcon : SwapScrollListContent
	{
		[SerializeField]
		private RawImageEx m_divaIconImage; // 0x20
		[SerializeField]
		private RawImageEx[] m_skillIconImages; // 0x24
		[SerializeField]
		private RawImageEx[] m_sceneIconImages; // 0x28
		[SerializeField]
		private RawImageEx m_centerIcon; // 0x2C
		[SerializeField]
		private RawImageEx m_setIcon; // 0x30
		[SerializeField]
		private StayButton m_stayButton; // 0x34
		[SerializeField]
		private UnityEvent m_onPushEvent; // 0x38
		[SerializeField]
		private UnityEvent m_onStayEvent; // 0x3C
		private AbsoluteLayout m_colorFrameAnimeLayout; // 0x40
		private AbsoluteLayout[] m_affinityEffect; // 0x44
		private AbsoluteLayout[] m_skillIconLayout; // 0x48
		private DivaIconDecoration m_divaIconDecoration = new DivaIconDecoration(); // 0x4C
		private SceneIconDecoration[] m_sceneIconDecoration = new SceneIconDecoration[3]; // 0x50
		private short m_divaId; // 0x54
		private byte m_modelId; // 0x56
		private sbyte m_compatibleFlags; // 0x57
		private CompatibleLayoutAnimeParam m_comAnimeParam; // 0x58
		private TexUVListManager m_uvManager; // 0x64

		public UnityEvent OnPushEvent { get { return m_onPushEvent; } } //0x17EBA40
		public UnityEvent OnStayEvent { get { return m_onStayEvent; } } //0x17EBA48
		public StayButton StayButton { get { return m_stayButton; } } //0x17EC36C

		// RVA: 0x17ED184 Offset: 0x17ED184 VA: 0x17ED184 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_colorFrameAnimeLayout = layout.FindViewByExId("sw_chara01_swtbl_sel_card_dvsel_frm_01") as AbsoluteLayout;
			for(int i = 0; i < m_sceneIconDecoration.Length; i++)
			{
				m_sceneIconDecoration[i] = new SceneIconDecoration();
			}
			StringBuilder str = new StringBuilder();
			m_affinityEffect = new AbsoluteLayout[3];
			m_skillIconLayout = new AbsoluteLayout[3];
			for(int i = 0; i < 3; i++)
			{
				str.Clear();
				if (i == 0)
					str.Append("cmn_diva_icon_sw_sel_card_skill_ef_anim_main");
				else
					str.AppendFormat("cmn_diva_icon_sw_sel_card_skill_ef_anim_sab{0:D2}", i);
				m_skillIconLayout[i] = layout.FindViewByExId(str.ToString()) as AbsoluteLayout;
				m_affinityEffect[i] = m_skillIconLayout[i].FindViewByExId("swtbl_sel_card_skill_sw_sel_card_skill_ef_anim") as AbsoluteLayout;
			}
			m_comAnimeParam.Initialize(m_affinityEffect[0][0].FrameAnimation.SearchLabelFrame("loen_act"), m_affinityEffect[0][0].FrameAnimation.SearchLabelFrame("logo_act"));
			m_stayButton.AddOnClickCallback(OnPushButton);
			m_stayButton.AddOnStayCallback(OnStayButton);
			m_uvManager = uvMan;
			ClearLoadedCallback();
			return true;
		}

		//// RVA: 0x17ED900 Offset: 0x17ED900 VA: 0x17ED900
		public void OnPushButton()
		{
			if (m_onPushEvent != null)
				m_onPushEvent.Invoke();
		}

		//// RVA: 0x17ED92C Offset: 0x17ED92C VA: 0x17ED92C
		public void OnStayButton()
		{
			if (m_onStayEvent != null)
				m_onStayEvent.Invoke();
		}

		//// RVA: 0x17E87AC Offset: 0x17E87AC VA: 0x17E87AC
		public void InitializeDecoration()
		{
			for(int i = 0; i < m_sceneIconDecoration.Length; i++)
			{
				m_sceneIconDecoration[i].Initialize(m_sceneIconImages[i].gameObject, SceneIconDecoration.Size.M, null, null);
			}
			m_divaIconDecoration.Initialize(m_divaIconImage.gameObject, DivaIconDecoration.Size.M, true, false, null, null);
		}

		//// RVA: 0x17E8A7C Offset: 0x17E8A7C VA: 0x17E8A7C
		public void ReleaseDecoration()
		{
			for(int i = 0; i < m_sceneIconDecoration.Length; i++)
			{
				m_sceneIconDecoration[i].Release();
			}
			m_divaIconDecoration.Release();
		}

		//// RVA: 0x17EAD78 Offset: 0x17EAD78 VA: 0x17EAD78
		public void SetDivaIcon(int divaId, int modelId, int colorId, bool isCenter, bool isSet)
		{
			m_divaId = (byte)divaId;
			m_modelId = (byte)modelId;
			MenuScene.Instance.DivaIconCache.SetStatusLoadingIcon(m_divaIconImage);
			MenuScene.Instance.DivaIconCache.LoadStateIcon(divaId, modelId, colorId, (IiconTexture texture) =>
			{
				//0x17EDC18
				if(texture != null)
				{
					if(divaId == m_divaId)
					{
						if(modelId == m_modelId)
						{
							texture.Set(m_divaIconImage);
						}
					}
				}
			});
			m_centerIcon.enabled = isCenter;
			m_setIcon.enabled = isSet;
			m_colorFrameAnimeLayout.StartChildrenAnimGoStop(divaId.ToString("00"));
		}

		//// RVA: 0x17EB07C Offset: 0x17EB07C VA: 0x17EB07C
		public void SetMainSceneIcon(int id, int runk, bool isCompatible, bool isKira, SceneIconScrollContent.SkillIconType iconType, bool isActivate)
		{
			m_skillIconLayout[0].StartChildrenAnimGoStop("01");
			GameManager.Instance.SceneIconCache.Load(id,runk, (IiconTexture texture) =>
			{
				//0x17EDD50
				texture.Set(m_sceneIconImages[0]);
				SceneIconTextureCache.ChangeKiraMaterial(m_sceneIconImages[0], texture as IconTexture, isKira);
			});
			if(isCompatible)
			{
				m_compatibleFlags = (sbyte)(m_compatibleFlags | 1);
				SetSkillTypeIcon(iconType, 0);
				if (isActivate)
					return;
				m_skillIconLayout[0].StartChildrenAnimGoStop("02");
			}
			else
			{
				m_compatibleFlags = (sbyte)(m_compatibleFlags & 0xfe);
				m_affinityEffect[0].StartChildrenAnimGoStop("st_non");
			}
		}

		//// RVA: 0x17EB35C Offset: 0x17EB35C VA: 0x17EB35C
		public void SetSubSceneIcon(int index, int id, int runk, bool isCompatible, bool isKira, bool isActivate)
		{
			m_skillIconLayout[index + 1].StartChildrenAnimGoStop("01");
			GameManager.Instance.SceneIconCache.Load(id, runk, (IiconTexture texture) =>
			{
				//0x17EDF18
				texture.Set(m_sceneIconImages[index + 1]);
				SceneIconTextureCache.ChangeKiraMaterial(m_sceneIconImages[index + 1], texture as IconTexture, isKira);
			});
			int val = (0x1000000 << (index + 1)) >> 0x18;
			if (isCompatible)
			{
				m_compatibleFlags |= (sbyte)val;
				SetSkillTypeIcon(SceneIconScrollContent.SkillIconType.Live, index * 2 + 2);
				if (isActivate)
					return;
				m_skillIconLayout[index + 1].StartChildrenAnimGoStop("02");
			}
			else
			{
				m_compatibleFlags &= (sbyte)~val;
				m_affinityEffect[index + 1].StartChildrenAnimGoStop("st_non");
			}
		}

		//// RVA: 0x17EB710 Offset: 0x17EB710 VA: 0x17EB710
		public void UpdateDocoration(FFHPBEPOMAK divaData, DFKGGBMFFGB playerData, DisplayType type)
		{
			m_divaIconDecoration.Change(divaData, playerData, type);
			for(int i = 0; i < m_sceneIconDecoration.Length; i++)
			{
				GCIJNCFDNON scene = null;
				if (i == 0)
				{
					if(divaData.FGFIBOBAPIA_SceneId > 0)
					{
						scene = playerData.OPIBAPEGCLA_Scenes[divaData.FGFIBOBAPIA_SceneId - 1];
					}
				}
				else
				{
					if(divaData.DJICAKGOGFO[i - 1] > 0)
					{
						scene = playerData.OPIBAPEGCLA_Scenes[divaData.DJICAKGOGFO[i - 1] - 1];
					}
				}
				if (scene == null)
					m_sceneIconDecoration[i].SetActive(false);
				else
				{
					m_sceneIconDecoration[i].SetActive(true);
					m_sceneIconDecoration[i].Change(scene, type);
				}
			}
		}

		//// RVA: 0x17E8C24 Offset: 0x17E8C24 VA: 0x17E8C24
		public void UpdateCompatibleAnime(float dt)
		{
			if(m_affinityEffect != null)
			{
				int val = m_comAnimeParam.UpdateFrame(dt);
				for(int i = 0; i < m_affinityEffect.Length; i++)
				{
					if((m_compatibleFlags & (1 << i)) != 0)
					{
						m_affinityEffect[i].StartChildrenAnimGoStop(val, val);
					}
				}
			}
		}

		//// RVA: 0x17ED968 Offset: 0x17ED968 VA: 0x17ED968
		private void SetSkillTypeIcon(SceneIconScrollContent.SkillIconType type, int index)
		{
			m_skillIconImages[index].uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvManager.GetUVData(type == SceneIconScrollContent.SkillIconType.Active ? "sel_card_icon_skill_01" : "sel_card_icon_skill_02"));
			m_skillIconImages[index + 1].uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvManager.GetUVData(type == SceneIconScrollContent.SkillIconType.Active ? "sel_card_icon_skill_01" : "sel_card_icon_skill_02"));
		}
	}
}
