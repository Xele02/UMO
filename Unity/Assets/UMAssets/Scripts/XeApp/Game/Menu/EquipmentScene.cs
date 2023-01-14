using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using XeSys;

namespace XeApp.Game.Menu
{
	public class EquipmentScene : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx m_centerIconImage; // 0x14
		[SerializeField]
		private RawImageEx m_divaIconImage; // 0x18
		[SerializeField]
		private RawImageEx[] m_skillIconImages; // 0x1C
		[SerializeField]
		private RawImageEx[] m_sceneIconImages; // 0x20
		[SerializeField]
		private StayButton[] m_sceneButtons; // 0x24
		[SerializeField]
		private Text[] m_episodeNameText; // 0x28
		[SerializeField]
		private Text m_assistNameText; // 0x2C
		[SerializeField]
		private SelectEquipmentSlotEvent m_onSelectSlotEvent; // 0x30
		[SerializeField]
		private SelectEquipmentSlotEvent m_onShowSceneStatusEvent; // 0x34
		private AbsoluteLayout[] m_sceneIconCursor; // 0x38
		private DivaIconDecoration m_divaIconDecoration; // 0x3C
		private SceneIconDecoration[] m_sceneIconDecoration; // 0x40
		private AbsoluteLayout[] m_compatibleAnimeLayout; // 0x44
		private AbsoluteLayout[] m_episodeNameLayout; // 0x48
		private AbsoluteLayout[] m_skillIconLayout; // 0x4C
		private AbsoluteLayout m_slotTypeLayout; // 0x50
		private AbsoluteLayout m_slotAttrLayout; // 0x54
		private AbsoluteLayout m_slotSceneLayout; // 0x58
		private sbyte m_compatibleFlag; // 0x5C
		private TexUVListManager m_uvManager; // 0x60
		private CompatibleLayoutAnimeParam m_comAnimeParam; // 0x64
		private static readonly string[] MusicAttributeUvTable = new string[4] {
			"cmn_zok_01", "cmn_zok_02", "cmn_zok_03", "cmn_zok_04"
		}; // 0x0

		public SelectEquipmentSlotEvent OnSelectSlotEvent { get { return m_onSelectSlotEvent;} } //0xF0AA8C
		public SelectEquipmentSlotEvent OnShowSceneStatusEvent { get { return m_onShowSceneStatusEvent; } } //0xF0AA94

		// RVA: 0xF0AA9C Offset: 0xF0AA9C VA: 0xF0AA9C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			ClearLoadedCallback();
			m_divaIconDecoration = new DivaIconDecoration();
			m_sceneIconDecoration = new SceneIconDecoration[3]
			{
				new SceneIconDecoration(),
				new SceneIconDecoration(),
				new SceneIconDecoration()
			};
			m_sceneIconCursor = new AbsoluteLayout[3]
			{
				layout.FindViewByExId("sw_sel_card_window03_cmn_scene_icon_main") as AbsoluteLayout,
				layout.FindViewByExId("sw_sel_card_window03_cmn_scene_icon_sab01") as AbsoluteLayout,
				layout.FindViewByExId("sw_sel_card_window03_cmn_scene_icon_sab02") as AbsoluteLayout
			};
			m_compatibleAnimeLayout = new AbsoluteLayout[3];
			m_episodeNameLayout = new AbsoluteLayout[3];
			m_skillIconLayout = new AbsoluteLayout[3];
			for(int i = 0; i < 3; i++)
			{
				m_compatibleAnimeLayout[i] = m_sceneIconCursor[i].FindViewByExId("swtbl_sel_card_skill_sw_sel_card_skill_ef_anim") as AbsoluteLayout;
				m_episodeNameLayout[i] = m_sceneIconCursor[i].FindViewByExId("sw_cmn_scene_icon_anim_swtbl_sel_card_epi_frm_s") as AbsoluteLayout;
				m_skillIconLayout[i] = m_sceneIconCursor[i].FindViewByExId("sw_cmn_scene_icon_anim_sw_sel_card_skill_ef_anim") as AbsoluteLayout;
			}
			m_slotTypeLayout = layout.FindViewById("sw_sel_card_window03") as AbsoluteLayout;
			m_slotAttrLayout = layout.FindViewById("swtbl_zoku") as AbsoluteLayout;
			m_slotSceneLayout = m_sceneIconCursor[0].FindViewByExId("sw_cmn_scene_icon_anim_cmn_scene_icon01") as AbsoluteLayout;
			float t = m_compatibleAnimeLayout[0][0].FrameAnimation.SearchLabelFrame("loen_act");
			float t2 = m_compatibleAnimeLayout[0][0].FrameAnimation.SearchLabelFrame("logo_act");
			m_comAnimeParam.Initialize(t2, t);
			m_uvManager = uvMan;
			m_compatibleFlag = 0;
			return true;
		}

		// // RVA: 0xF0B778 Offset: 0xF0B778 VA: 0xF0B778
		public void InitializeDecoration()
		{
			m_divaIconDecoration.Initialize(m_divaIconImage.gameObject, DivaIconDecoration.Size.S, null, null);
			for(int i = 0; i < m_sceneIconDecoration.Length; i++)
			{
				m_sceneIconDecoration[i].Initialize(m_sceneIconImages[i].gameObject, SceneIconDecoration.Size.M, null, null);
			}
		}

		// // RVA: 0xF0B8CC Offset: 0xF0B8CC VA: 0xF0B8CC
		public void ReleaseDecoration()
		{
			m_divaIconDecoration.Release();
			for(int i = 0; i < m_sceneIconDecoration.Length; i++)
			{
				m_sceneIconDecoration[i].Release();
			}
		}

		// // RVA: 0xF0B97C Offset: 0xF0B97C VA: 0xF0B97C
		public void UpdateContent(DFKGGBMFFGB playerData, FFHPBEPOMAK divaData, bool isCenter, int musicId, bool isGoDiva)
		{
			m_slotTypeLayout.StartChildrenAnimGoStop("01");
			m_centerIconImage.enabled = isCenter;
			int divaId = 12;
			if(divaData != null)
			{
				if(!isGoDiva || isCenter)
				{
					MenuScene.Instance.DivaIconCache.Load(divaData.AHHJLDLAPAN_DivaId, divaData.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId, divaData.EKFONBFDAAP_ColorId, (IiconTexture texture) => {
						//0xF0E21C
						texture.Set(m_divaIconImage);
					});
				}
				else
				{
					MenuScene.Instance.DivaIconCache.LoadEventGoDivaIcon(divaData.AHHJLDLAPAN_DivaId, (IiconTexture texture) => {
						//0xF0E13C
						texture.Set(m_divaIconImage);
					});
				}
				divaId = divaData.AHHJLDLAPAN_DivaId;
			}
			for(int i = 0; i < divaData.DJICAKGOGFO_SubSceneIds.Count + 1; i++)
			{
				m_skillIconLayout[i].StartChildrenAnimGoStop("01");
				m_sceneButtons[i].ClearOnClickCallback();
				m_sceneButtons[i].ClearOnStayCallback();
				int loopIndex = i;
				m_sceneButtons[i].AddOnClickCallback(() => {
					//0xF0E2FC
					OnSelectSlot(loopIndex);
				});
				int sceneId = 0;
				if(i == 0)
				{
					sceneId = divaData.FGFIBOBAPIA_SceneId;
				}
				else
				{
					sceneId = divaData.DJICAKGOGFO_SubSceneIds[i - 1];
				}
				GCIJNCFDNON sceneInfo = null;
				if(sceneId > 0)
				{
					sceneInfo = playerData.OPIBAPEGCLA_Scenes[sceneId - 1];
				}
				if(sceneInfo == null)
				{
					MenuScene.Instance.SceneIconCache.Load(0, 0, (IiconTexture texture) => {
						//0xF0E554
						texture.Set(m_sceneIconImages[loopIndex]);
						SceneIconTextureCache.ChangeKiraMaterial(m_sceneIconImages[loopIndex], texture as IconTexture, false);
					});
					m_sceneIconDecoration[i].SetActive(false);
					m_compatibleFlag &= (sbyte)~((0x1000000 << i) >> 0x18);
					m_skillIconLayout[i].StartChildrenAnimGoStop("01");
					m_compatibleAnimeLayout[i].StartChildrenAnimGoStop("st_non");
				}
				else
				{
					MenuScene.Instance.SceneIconCache.Load(sceneInfo.BCCHOBPJJKE_SceneId, sceneInfo.CGIELKDLHGE_GetEvolveId(), (IiconTexture texture) => {
						//0xF0E32C
						texture.Set(m_sceneIconImages[loopIndex]);
						SceneIconTextureCache.ChangeKiraMaterial(m_sceneIconImages[loopIndex], texture as IconTexture, sceneInfo.MBMFJILMOBP());
					});
					m_sceneIconDecoration[i].SetActive(true);
					m_sceneButtons[i].AddOnStayCallback(() => {
						//0xF0E524
						OnShowSceneStatus(loopIndex);
					});
					if(i == 0 && isCenter)
					{
						SetSkillTypeIcon(SceneIconScrollContent.SkillIconType.Active, 0);
						if(!SetDeckSkillIconControl.CheckMatchActiveSkill(sceneInfo))
						{
							m_skillIconLayout[0].StartChildrenAnimGoStop("02");
						}
						if(sceneInfo.HGONFBDIBPM_ActiveSkillId > 0)
							m_compatibleFlag |= (sbyte)((0x1000000 << i) >> 0x18);
						else
						{
							m_skillIconLayout[i].StartChildrenAnimGoStop("01");
							m_compatibleAnimeLayout[i].StartChildrenAnimGoStop("st_non");
							m_compatibleFlag &= (sbyte)~((0x1000000 << i) >> 0x18);
						}
					}
					else
					{
						if(!sceneInfo.DCLLIDMKNGO_IsDivaCompatible(divaId))
						{
							SetSkillTypeIcon(SceneIconScrollContent.SkillIconType.Live, i * 2);
							m_skillIconLayout[i].StartChildrenAnimGoStop("01");
							m_compatibleAnimeLayout[i].StartChildrenAnimGoStop("st_non");
							m_compatibleFlag &= (sbyte)~((0x1000000 << i) >> 0x18);
						}
						else
						{
							int liveSkillId = sceneInfo.FILPDDHMKEJ(false, 0, 0);
							if(musicId > 0 && liveSkillId > 0)
							{
								if(!SetDeckSkillIconControl.CheckMatchLiveSkill(sceneInfo, divaId, musicId))
								{
									m_skillIconLayout[i].StartChildrenAnimGoStop("02");
								}
							}
							SetSkillTypeIcon(SceneIconScrollContent.SkillIconType.Live, i * 2);
							if(liveSkillId > 0)
								m_compatibleFlag |= (sbyte)((0x1000000 << i) >> 0x18);
							else
							{
								m_skillIconLayout[i].StartChildrenAnimGoStop("01");
								m_compatibleAnimeLayout[i].StartChildrenAnimGoStop("st_non");
								m_compatibleFlag &= (sbyte)~((0x1000000 << i) >> 0x18);
							}
						}
					}
				}
			}
		}

		// // RVA: 0xF0CA8C Offset: 0xF0CA8C VA: 0xF0CA8C
		public void UpdateAssistContent(DFKGGBMFFGB playerData, GCIJNCFDNON sceneData, int slot)
		{
			m_slotTypeLayout.StartChildrenAnimGoStop("02");
			switch(slot)
			{
				case 0:
					m_slotAttrLayout.StartChildrenAnimGoStop("04");
					m_assistNameText.text = MessageManager.Instance.GetMessage("menu", "assistselect_attribute_other");
					break;
				case 1:
					m_slotAttrLayout.StartChildrenAnimGoStop("01");
					m_assistNameText.text = MessageManager.Instance.GetMessage("menu", "assistselect_attribute_yellow");
					break;
				case 2:
					m_slotAttrLayout.StartChildrenAnimGoStop("02");
					m_assistNameText.text = MessageManager.Instance.GetMessage("menu", "assistselect_attribute_red");
					break;
				case 3:
					m_slotAttrLayout.StartChildrenAnimGoStop("03");
					m_assistNameText.text = MessageManager.Instance.GetMessage("menu", "assistselect_attribute_blue");
					break;
			}
			m_sceneButtons[0].ClearOnStayCallback();
			int loopIndex = 0;
			if(sceneData == null || sceneData.BCCHOBPJJKE_SceneId < 1)
			{
				MenuScene.Instance.SceneIconCache.Load(0, 0, (IiconTexture texture) => {
					//0xF0E94C
					texture.Set(m_sceneIconImages[loopIndex]);
				});
				m_sceneIconDecoration[0].SetActive(false);
			}
			else
			{
				MenuScene.Instance.SceneIconCache.Load(sceneData.BCCHOBPJJKE_SceneId, sceneData.CGIELKDLHGE_GetEvolveId(), (IiconTexture texture) => {
					//0xF0E724
					texture.Set(m_sceneIconImages[loopIndex]);
					SceneIconTextureCache.ChangeKiraMaterial(m_sceneIconImages[loopIndex], texture as IconTexture, sceneData.MBMFJILMOBP());
				});
				m_sceneIconDecoration[0].SetActive(true);
				m_sceneButtons[0].AddOnStayCallback(() => {
					//0xF0E91C
					OnShowSceneStatus(loopIndex);
				});
				m_compatibleFlag = (sbyte)(m_compatibleFlag & 0xfe);
				m_skillIconLayout[0].StartChildrenAnimGoStop("01");
				m_compatibleAnimeLayout[0].StartChildrenAnimGoStop("st_non");
			}
		}

		// // RVA: 0xF0D1FC Offset: 0xF0D1FC VA: 0xF0D1FC
		public void UpdateHomeBgSceneContent(GCIJNCFDNON sceneData, int evolveId)
		{
			m_slotTypeLayout.StartChildrenAnimGoStop("02");
			m_slotAttrLayout.StartChildrenAnimGoStop("05");
			m_assistNameText.text = MessageManager.Instance.GetMessage("menu", "homebgselect_title");
			m_sceneButtons[0].ClearOnClickCallback();
			m_sceneButtons[0].ClearOnStayCallback();
			if(sceneData == null || sceneData.BCCHOBPJJKE_SceneId < 1)
			{
				m_slotSceneLayout.StartAllAnimGoStop("02");
				MenuScene.Instance.SceneIconCache.Load(0, 0, (IiconTexture texture) => {
					//0xF0EC48
					texture.Set(m_sceneIconImages[0]);
				});
			}
			else
			{
				m_slotSceneLayout.StartAllAnimGoStop("01");
				MenuScene.Instance.SceneIconCache.Load(sceneData.BCCHOBPJJKE_SceneId, evolveId, (IiconTexture texture) => {
					//0xF0EB1C
					texture.Set(m_sceneIconImages[0]);
				});
			}
			m_sceneIconDecoration[0].SetActive(false);
			m_compatibleFlag = (sbyte)(m_compatibleFlag & 0xfe);
			m_skillIconLayout[0].StartChildrenAnimGoStop("01");
			m_compatibleAnimeLayout[0].StartChildrenAnimGoStop("st_non");
		}

		// // RVA: 0xF0D744 Offset: 0xF0D744 VA: 0xF0D744
		public void ChangeIcon(DFKGGBMFFGB playerData, FFHPBEPOMAK divaData, DisplayType type, bool isCenter, bool isGoDiva)
		{
			m_divaIconDecoration.Change(divaData, playerData, type);
			bool isActive = true;
			if(isGoDiva && !isCenter)
			{
				isActive = false;
				for(int i = 0; i < FFHPBEPOMAK.HBBPOMBJJNG.Length; i++)
				{
					if(FFHPBEPOMAK.HBBPOMBJJNG[i] == type)
					{
						isActive = true;
						break;
					}
				}
			}
			m_divaIconDecoration.SetActive(isActive);
			for(int i = 0; i < divaData.DJICAKGOGFO_SubSceneIds.Count + 1; i++)
			{
				GCIJNCFDNON sceneInfo = null;
				if(i == 0)
				{
					if(divaData.FGFIBOBAPIA_SceneId > 0)
						sceneInfo = playerData.OPIBAPEGCLA_Scenes[divaData.FGFIBOBAPIA_SceneId - 1];
				}
				else
				{
					if(divaData.DJICAKGOGFO_SubSceneIds[i - 1] > 0)
						sceneInfo = playerData.OPIBAPEGCLA_Scenes[divaData.DJICAKGOGFO_SubSceneIds[i - 1] - 1];
				}
				m_sceneIconDecoration[i].Change(sceneInfo, type);
			}
		}

		// // RVA: 0xF0DB8C Offset: 0xF0DB8C VA: 0xF0DB8C
		public void ChangeIcon(GCIJNCFDNON sceneData, DisplayType type, int index)
		{
			if(sceneData == null)
				return;
			if(sceneData.BCCHOBPJJKE_SceneId < 1)
				return;
			m_sceneIconDecoration[index].Change(sceneData, type);
		}

		// // RVA: 0xF0DC18 Offset: 0xF0DC18 VA: 0xF0DC18
		public void SelectSlot(int slotIndex)
		{
			for(int i = 0; i < m_sceneIconCursor.Length; i++)
			{
				m_sceneIconCursor[i].StartChildrenAnimGoStop(slotIndex == i ? "logo_on" : "st_wait");
			}
		}

		// // RVA: 0xF0DD0C Offset: 0xF0DD0C VA: 0xF0DD0C
		public void UpdateCompatibleAnime(float dt)
		{
			if(m_compatibleAnimeLayout != null)
			{
				int t = m_comAnimeParam.UpdateFrame(dt);
				for(int i = 0; i < m_compatibleAnimeLayout.Length; i++)
				{
					if((m_compatibleFlag & (1 << i)) != 0)
					{
						m_compatibleAnimeLayout[i].StartChildrenAnimGoStop(t, t);
					}
				}
			}
		}

		// RVA: 0xF0DDD4 Offset: 0xF0DDD4 VA: 0xF0DDD4
		private void Update()
		{
			UpdateCompatibleAnime(TimeWrapper.deltaTime);
		}

		// // RVA: 0xF0DDF8 Offset: 0xF0DDF8 VA: 0xF0DDF8
		private void OnSelectSlot(int slotIndex)
		{
			m_onSelectSlotEvent.Invoke(slotIndex);
		}

		// // RVA: 0xF0DE78 Offset: 0xF0DE78 VA: 0xF0DE78
		private void OnShowSceneStatus(int slotIndex)
		{
			TodoLogger.LogNotImplemented("OnShowSceneStatus");
		}

		// // RVA: 0xF0C878 Offset: 0xF0C878 VA: 0xF0C878
		private void SetSkillTypeIcon(SceneIconScrollContent.SkillIconType type, int index)
		{
			m_skillIconImages[index].uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvManager.GetUVData(type == SceneIconScrollContent.SkillIconType.Active ? "sel_card_icon_skill_01" : "sel_card_icon_skill_02"));
			m_skillIconImages[index + 1].uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvManager.GetUVData(type == SceneIconScrollContent.SkillIconType.Active ? "sel_card_icon_skill_01" : "sel_card_icon_skill_02"));
		}
	}
}
