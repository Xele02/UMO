using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using XeSys;
using System;
using System.Collections;
using mcrs;

namespace XeApp.Game.Menu
{
	public class StorySelectStageIcon : LayoutUGUIScriptBase
	{
		[SerializeField]
		private bool m_is_large; // 0x11
		[SerializeField]
		private RawImageEx m_jacket; // 0x14
		[SerializeField]
		private ActionButton m_action_btn; // 0x18
		[SerializeField]
		private GameObject m_newPos; // 0x1C
		[SerializeField]
		private RawImageEx[] m_stamp; // 0x20
		[SerializeField]
		private RawImage m_noizeImage; // 0x24
		private AbsoluteLayout m_stage_icon; // 0x28
		private AbsoluteLayout m_base_type; // 0x2C
		private AbsoluteLayout m_icon_tbl; // 0x30
		private AbsoluteLayout m_effect_abs; // 0x34
		private AbsoluteLayout m_iconStatusTbl; // 0x38
		private AbsoluteLayout m_noiseAnim; // 0x3C
		private AbsoluteLayout m_stampAnim; // 0x40
		private TexUVList m_texUvList; // 0x48
		private CompatibleLayoutAnimeParam m_syncEmphasisAnimParam; // 0x4C
		private bool m_isPlayEmphasis; // 0x58

		public LIEJFHMGNIA viewStageData { get; set; } // 0x44

		//// RVA: 0x1A86410 Offset: 0x1A86410 VA: 0x1A86410
		public GameObject GetNewPos()
		{
			return m_newPos;
		}

		//// RVA: 0x1A94FD8 Offset: 0x1A94FD8 VA: 0x1A94FD8
		public RawImage GetNoizeImage()
		{
			return m_noizeImage;
		}

		// RVA: 0x1A94FE0 Offset: 0x1A94FE0 VA: 0x1A94FE0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			if(!m_is_large)
			{
				m_stage_icon = layout.FindViewByExId("root_story_musuc_sw_music") as AbsoluteLayout;
				m_iconStatusTbl = layout.FindViewByExId("sw_music_s_anim_swtbl_music_s") as AbsoluteLayout;
			}
			else
			{
				m_stage_icon = layout.FindViewByExId("root_story_musuc_l_sw_music_l") as AbsoluteLayout;
				m_icon_tbl = layout.FindViewByExId("sw_music_l_anim_swtbl_sel_st_icon") as AbsoluteLayout;
				m_effect_abs = layout.FindViewByExId("sw_music_l_anim_sw_music_glow_anim") as AbsoluteLayout;
				m_noiseAnim = layout.FindViewByExId("sw_music_l_anim_sw_music_l_noise_anim") as AbsoluteLayout;
				m_stampAnim = layout.FindViewByExId("sw_music_l_anim_sw_music_l_get_anim") as AbsoluteLayout;
				m_texUvList = uvMan.GetTexUVList("sel_story_pack");
			}
			m_base_type = layout.FindViewByExId("sel_st_music_swtbl_s_s_music_cd_jakt") as AbsoluteLayout;
			m_stage_icon.StartChildrenAnimGoStop("st_non");
			Loaded();
			return true;
		}

		// RVA: 0x1A95464 Offset: 0x1A95464 VA: 0x1A95464
		private void Update()
		{
			if (!m_isPlayEmphasis || m_effect_abs == null)
				return;
			int frame = m_syncEmphasisAnimParam.UpdateFrame(TimeWrapper.deltaTime);
			m_effect_abs.StartChildrenAnimGoStop(frame, frame);
		}

		//// RVA: 0x1A954D4 Offset: 0x1A954D4 VA: 0x1A954D4
		//private bool IsEffect(LIEJFHMGNIA viewData) { }

		//// RVA: 0x1A8AE14 Offset: 0x1A8AE14 VA: 0x1A8AE14
		public bool IsPlaying()
		{
			return m_stage_icon != null && m_stage_icon.IsPlayingChildren();
		}

		//// RVA: 0x1A8250C Offset: 0x1A8250C VA: 0x1A8250C
		public void SetStatus()
		{
			m_isPlayEmphasis = false;
			gameObject.SetActive(true);
			SetButtonEnable(false);
			bool enable = false;
			if (!viewStageData.BCGLDMKODLC_StatusCompleted)
			{
				if (!viewStageData.NDLKPJDHHCN_NotShown && !viewStageData.DHPNLACAGPG)
					enable = !viewStageData.PGCCOCKGCKO;
			}
			else
				enable = true;
			SetButtonEnable(enable);
			ChangeBaseType(viewStageData.FKDCCLPGKDK_JacketAttr - 1);
			SetTexture();
			ChangeIconType();
			SetWaitAnim(viewStageData);
		}

		//// RVA: 0x1A8FD84 Offset: 0x1A8FD84 VA: 0x1A8FD84
		public void SetNoiseEnable(bool enable)
		{
			if(m_noiseAnim != null)
				m_noiseAnim.enabled = enable;
		}

		//// RVA: 0x1A82DA4 Offset: 0x1A82DA4 VA: 0x1A82DA4
		public void SetPosition(Vector3 pos)
		{
			GetComponent<RectTransform>().anchoredPosition = pos;
		}

		//// RVA: 0x1A95514 Offset: 0x1A95514 VA: 0x1A95514
		public void ChangeBaseType(int type)
		{
			m_base_type.StartChildrenAnimGoStop(type, type);
		}

		//// RVA: 0x1A9579C Offset: 0x1A9579C VA: 0x1A9579C
		public void ChangeIconType()
		{
			if (m_icon_tbl == null)
				return;
			if(viewStageData.AHHJLDLAPAN_DivaId == 9)
			{
				m_icon_tbl.StartChildrenAnimGoStop("03");
			}
			else
			{
				if(viewStageData.MMEGDFPNONJ_HasDivaId)
					m_icon_tbl.StartChildrenAnimGoStop("02");
				else
					m_icon_tbl.StartChildrenAnimGoStop("01");
			}
		}

		//// RVA: 0x1A95EC0 Offset: 0x1A95EC0 VA: 0x1A95EC0
		public void SetStamp(int divaId)
		{
			if (m_stamp == null)
				return;
			if (m_texUvList == null)
				return;
			FFHPBEPOMAK_DivaInfo dinfo = GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas.Find((FFHPBEPOMAK_DivaInfo _) =>
			{
				//0x1A969C4
				return _.AHHJLDLAPAN_DivaId == divaId;
			});
			int a = 1;
			if(dinfo != null)
			{
				if(dinfo.AIHCEGFANAM_Serie == 2)
				{
					a = 2;
					if(divaId != 6)
					{
						a = 1;
						if (divaId == 7)
							a = 3;
					}
				}
				if (dinfo.AIHCEGFANAM_Serie == 3)
					a = 4;
				if (dinfo.AIHCEGFANAM_Serie == 4)
					a = 5;
			}
			string k = string.Format("sel_st_get_icon_{0:d2}", a);
			for(int i = 0; i < m_stamp.Length; i++)
			{
				m_stamp[i].uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_texUvList.GetUVData(k));
			}
		}

		//// RVA: 0x1A8A9FC Offset: 0x1A8A9FC VA: 0x1A8A9FC
		public void SetButtonEnable(bool enable)
		{
			if (m_action_btn != null)
				m_action_btn.enabled = enable;
		}

		//// RVA: 0x1A908E4 Offset: 0x1A908E4 VA: 0x1A908E4
		//public void SetButtonStatus() { }

		//// RVA: 0x1A8261C Offset: 0x1A8261C VA: 0x1A8261C
		public void SetCallback(Action callback)
		{
			if (m_action_btn == null)
				return;
			m_action_btn.ClearOnClickCallback();
			m_action_btn.AddOnClickCallback(() =>
			{
				//0x1A969FC
				GameManager.Instance.CloseSnsNotice();
				ButtonDecide();
				if (callback != null)
					callback();
			});
		}

		//// RVA: 0x1A9554C Offset: 0x1A9554C VA: 0x1A9554C
		public void SetTexture()
		{
			if(viewStageData.MMEGDFPNONJ_HasDivaId)
			{
				GameManager.Instance.DivaIconCache.LoadStoryIcon(viewStageData.AHHJLDLAPAN_DivaId, 1, (IiconTexture icon) =>
				{
					//0x1A96804
					icon.Set(m_jacket);
				});
				return;
			}
			GameManager.Instance.MusicJacketTextureCache.Load(viewStageData.JNCPEGJGHOG_JacketId, (IiconTexture icon) =>
			{
				//0x1A968E4
				icon.Set(m_jacket);
			});
		}

		//// RVA: 0x1A863B8 Offset: 0x1A863B8 VA: 0x1A863B8
		public void ButtonEmphasis()
		{
			if (!m_is_large)
				return;
			if(m_effect_abs != null && viewStageData != null)
			{
				if(!viewStageData.PGCCOCKGCKO && !viewStageData.BCGLDMKODLC_StatusCompleted)
				{
					m_isPlayEmphasis = true;
					m_syncEmphasisAnimParam.Initialize(1, 74);
				}
			}
		}

		//// RVA: 0x1A96214 Offset: 0x1A96214 VA: 0x1A96214
		public void ButtonDecide()
		{
			if(m_is_large && viewStageData != null)
			{
				if (viewStageData.BCGLDMKODLC_StatusCompleted)
					return;
				if(m_effect_abs != null)
				{
					m_isPlayEmphasis = false;
					m_effect_abs.StartChildrenAnimGoStop("go_act_decide");
					this.StartCoroutineWatched(ButtonDecideWait());
				}
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72D0F4 Offset: 0x72D0F4 VA: 0x72D0F4
		//// RVA: 0x1A962C8 Offset: 0x1A962C8 VA: 0x1A962C8
		private IEnumerator ButtonDecideWait()
		{
			//0x1A96AD0
			yield return null;
			while (m_effect_abs.IsPlayingChildren())
				yield return null;
			m_isPlayEmphasis = true;
		}

		//// RVA: 0x1A95468 Offset: 0x1A95468 VA: 0x1A95468
		//private void UpdateEmphasis() { }

		//// RVA: 0x1A88254 Offset: 0x1A88254 VA: 0x1A88254
		public void In(StorySelectStageCreater.EffectType effectType)
		{
			PlayAnimInner(effectType, viewStageData);
		}

		//// RVA: 0x1A966D4 Offset: 0x1A966D4 VA: 0x1A966D4
		//public void Out() { }

		//// RVA: 0x1A8800C Offset: 0x1A8800C VA: 0x1A8800C
		public void Show()
		{
			gameObject.SetActive(true);
		}

		//// RVA: 0x1A83B40 Offset: 0x1A83B40 VA: 0x1A83B40
		public void Hide(bool isNone = true)
		{
			if (m_stage_icon != null && isNone)
				m_stage_icon.StartChildrenAnimGoStop("st_non");
			gameObject.SetActive(false);
		}

		//// RVA: 0x1A958A4 Offset: 0x1A958A4 VA: 0x1A958A4
		private void SetWaitAnim(LIEJFHMGNIA viewData)
		{
			if(m_stage_icon != null && viewData != null)
			{
				if (m_noiseAnim != null)
					m_noiseAnim.enabled = false;
				if (m_stampAnim != null)
					m_stampAnim.enabled = false;
				if (m_effect_abs != null)
					m_effect_abs.enabled = true;
				if(!viewData.NDLKPJDHHCN_NotShown)
				{
					if (!viewData.DHPNLACAGPG)
					{
						if (!viewData.BCGLDMKODLC_StatusCompleted)
						{
							if(!viewData.PGCCOCKGCKO)
							{
								UnityEngine.Debug.LogError(viewData.NDFOAINJPIN_Pos + "st_wait");
								m_stage_icon.StartChildrenAnimGoStop("st_wait");
								if(viewData.HHBJAEOIGIH_IsLocked)
								{
									if (m_iconStatusTbl != null)
										m_iconStatusTbl.StartChildrenAnimGoStop("02");
									if(m_noiseAnim != null)
									{
										m_noiseAnim.enabled = true;
										m_noiseAnim.StartChildrenAnimGoStop("st_wait");
									}
								}
							}
							else
							{
								if(viewData.MMEGDFPNONJ_HasDivaId)
								{
									UnityEngine.Debug.LogError(viewData.NDFOAINJPIN_Pos + "st_wait");
									m_stage_icon.StartChildrenAnimGoStop("st_wait");
									if(m_noiseAnim != null)
									{
										m_noiseAnim.enabled = true;
										m_noiseAnim.StartChildrenAnimGoStop("st_wait");
									}
									if(m_stampAnim != null)
									{
										m_stampAnim.enabled = true;
										m_stampAnim.StartChildrenAnimGoStop("st_non");
									}
								}
							}
						}
						else
						{
							UnityEngine.Debug.LogError(viewData.NDFOAINJPIN_Pos + "st_wait");
							m_stage_icon.StartChildrenAnimGoStop("st_wait");
							if (m_iconStatusTbl != null)
								m_iconStatusTbl.StartChildrenAnimGoStop("01");
							if (viewData.MMEGDFPNONJ_HasDivaId)
							{
								SetStamp(viewData.AHHJLDLAPAN_DivaId);
								UnityEngine.Debug.LogError(viewData.NDFOAINJPIN_Pos + "st_get_wait");
								m_stage_icon.StartChildrenAnimGoStop("st_get_wait");
								if(m_stampAnim != null)
								{
									m_stampAnim.enabled = true;
									m_stampAnim.StartChildrenAnimGoStop("st_get_wait");
								}
								if (m_effect_abs != null)
									m_effect_abs.enabled = false;
							}
						}
					}
					else
					{
						if(viewData.MMEGDFPNONJ_HasDivaId)
						{
							UnityEngine.Debug.LogError(viewData.NDFOAINJPIN_Pos + "st_wait");
							m_stage_icon.StartChildrenAnimGoStop("st_wait");
							if(m_noiseAnim != null)
							{
								m_noiseAnim.enabled = true;
								m_noiseAnim.StartChildrenAnimGoStop("st_wait");
							}
							if(m_stampAnim != null)
							{
								m_stampAnim.enabled = true;
								m_stampAnim.StartChildrenAnimGoStop("st_non");
							}
						}
						else
						{
							UnityEngine.Debug.LogError(viewData.NDFOAINJPIN_Pos + "st_lock");
							m_stage_icon.StartChildrenAnimGoStop("st_lock");
							if(m_noiseAnim != null)
							{
								m_noiseAnim.enabled = true;
								m_noiseAnim.StartChildrenAnimGoStop("st_lock");
							}
						}
					}
				}
				else
				{
					UnityEngine.Debug.LogError(viewData.NDFOAINJPIN_Pos + "st_non");
					m_stage_icon.StartChildrenAnimGoStop("st_non");
					if (m_iconStatusTbl != null)
						m_iconStatusTbl.StartChildrenAnimGoStop("02");
					if(m_noiseAnim != null)
					{
						m_noiseAnim.enabled = viewData.HHBJAEOIGIH_IsLocked;
						m_noiseAnim.StartChildrenAnimGoStop("st_non");
					}
					if(m_stampAnim != null && viewData.MMEGDFPNONJ_HasDivaId)
					{
						m_stampAnim.enabled = !viewData.HHBJAEOIGIH_IsLocked;
						m_stampAnim.StartChildrenAnimGoStop("st_non");
					}
				}
			}
		}

		//// RVA: 0x1A96374 Offset: 0x1A96374 VA: 0x1A96374
		private void PlayAnimInner(StorySelectStageCreater.EffectType effectType, LIEJFHMGNIA viewData)
		{
			if (viewData == null || m_stage_icon == null)
				return;
			if(effectType == StorySelectStageCreater.EffectType.RELEASE)
			{
				m_stage_icon.StartChildrenAnimGoStop("go_bot_act_02", "st_bot_act_02");
				if(m_noiseAnim != null)
				{
					m_noiseAnim.StartChildrenAnimGoStop("go_bot_act_02", "st_bot_act_02");
				}
				if(m_stampAnim != null)
				{
					m_stampAnim.StartChildrenAnimGoStop("go_bot_act_02", "go_bot_act_02");
				}
				SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_SETTING_002);
			}
			else if(effectType == StorySelectStageCreater.EffectType.UNLOCK)
			{
				if (viewStageData.MMEGDFPNONJ_HasDivaId)
					return;
				m_stage_icon.StartChildrenAnimGoStop("go_bot_act_01", "st_bot_act_01");
				if(m_noiseAnim != null)
				{
					m_noiseAnim.StartChildrenAnimGoStop("go_bot_act_01", "st_bot_act_01");
				}
				if(m_stampAnim != null)
				{
					m_stampAnim.StartChildrenAnimGoStop("go_bot_act_01", "st_bot_act_01");
				}
				SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_SETTING_002);
			}
			else if(effectType == StorySelectStageCreater.EffectType.APPEAR)
			{
				if(viewStageData.MMEGDFPNONJ_HasDivaId)
				{
					m_stage_icon.StartChildrenAnimGoStop("go_bot_act_02", "st_bot_act_02");
					if (m_noiseAnim != null)
					{
						m_noiseAnim.StartChildrenAnimGoStop("go_bot_act_02", "st_bot_act_02");
					}
					if(m_stampAnim != null)
					{
						m_stampAnim.StartChildrenAnimGoStop("go_bot_act_02", "st_bot_act_02");
					}
				}
				else
				{
					UnityEngine.Debug.LogError(viewData.NDFOAINJPIN_Pos + "go_bot_act > st_bot_act");
					m_stage_icon.StartChildrenAnimGoStop("go_bot_act", "st_bot_act");
				}
				SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_STORY_000);
			}
		}

		//// RVA: 0x1A83F24 Offset: 0x1A83F24 VA: 0x1A83F24
		public void NoneIcon()
		{
			m_stage_icon.StartChildrenAnimGoStop("st_non");
			if(m_noiseAnim != null)
				m_noiseAnim.StartChildrenAnimGoStop("st_non");
			if(m_stampAnim != null)
				m_stampAnim.StartChildrenAnimGoStop("st_non");
		}

		//// RVA: 0x1A83E60 Offset: 0x1A83E60 VA: 0x1A83E60
		public void LockIcon()
		{
			m_stage_icon.StartChildrenAnimGoStop("st_lock");
			if(m_noiseAnim != null)
				m_noiseAnim.StartChildrenAnimGoStop("st_lock");
			if(m_stampAnim != null)
				m_stampAnim.StartChildrenAnimGoStop("st_lock");
			SetButtonEnable(false);
		}

		//// RVA: 0x1A94AEC Offset: 0x1A94AEC VA: 0x1A94AEC
		public void LockAppearIn()
		{
			if(m_stage_icon != null)
			{
				m_stage_icon.StartChildrenAnimGoStop("go_bot_act", "st_bot_act");
				m_stage_icon.UpdateAllAnimation(TimeWrapper.deltaTime * 2, false);
				m_stage_icon.UpdateAll(new Matrix23(), Color.white);
			}
		}

		//// RVA: 0x1A94C18 Offset: 0x1A94C18 VA: 0x1A94C18
		public void AppearIn()
		{
			if(m_stage_icon != null)
			{
				m_stage_icon.StartChildrenAnimGoStop("go_bot_act_02", "st_bot_act_02");
				if(m_noiseAnim != null)
					m_noiseAnim.StartChildrenAnimGoStop("go_bot_act_02", "st_bot_act_02");
				if(m_stampAnim != null)
					m_stampAnim.StartChildrenAnimGoStop("go_bot_act_02", "go_bot_act_02");
			}
		}

		//// RVA: 0x1A94A00 Offset: 0x1A94A00 VA: 0x1A94A00
		public void ShrinkingIn()
		{
			m_stage_icon.StartChildrenAnimGoStop("go_bot_act_03", "st_bot_act_03");
			if(m_noiseAnim != null)
				m_noiseAnim.StartChildrenAnimGoStop("go_bot_act_03", "st_bot_act_03");
			if(m_stampAnim != null)
				m_stampAnim.StartChildrenAnimGoStop("go_bot_act_03", "st_bot_act_03");
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72D16C Offset: 0x72D16C VA: 0x72D16C
		//// RVA: 0x1A93814 Offset: 0x1A93814 VA: 0x1A93814
		public IEnumerator StampPressAnim()
		{
			//0x1A96C18
			SetStamp(viewStageData.AHHJLDLAPAN_DivaId);
			m_stage_icon.StartChildrenAnimGoStop("go_bot_act_04", "st_bot_act_04");
			if(m_noiseAnim != null)
				m_noiseAnim.StartChildrenAnimGoStop("go_bot_act_04", "st_bot_act_04");
			if(m_stampAnim != null)
				m_stampAnim.StartChildrenAnimGoStop("go_bot_act_04", "st_bot_act_04");
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_LOGIN_000);
			while(m_stage_icon.IsPlayingChildren())
				yield return null;
			SetStampDiva();
		}

		//// RVA: 0x1A966F8 Offset: 0x1A966F8 VA: 0x1A966F8
		private void SetStampDiva()
		{
			if(viewStageData != null)
			{
				if(!viewStageData.MMEGDFPNONJ_HasDivaId)
					return;
				SetStamp(viewStageData.AHHJLDLAPAN_DivaId);
				m_stage_icon.StartChildrenAnimGoStop("st_get_wait");
				if(m_noiseAnim != null)
					m_noiseAnim.StartChildrenAnimGoStop("st_get_wait");
				if(m_stampAnim != null)
					m_stampAnim.StartChildrenAnimGoStop("st_get_wait");
			}
		}
	}
}
