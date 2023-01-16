using System.Text;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class DivaComparisonParam : ComparisonParamBase
	{
		protected enum SkillDiapIndex
		{
			MainSlotCenter = 0,
			MainSlotActive = 1,
			MainSlotLive = 2,
			SubSlotLive1 = 3,
			SubSlotLive2 = 4,
			Max = 5,
		}

		protected DivaIconDecoration m_divaIconDecoration = new DivaIconDecoration(); // 0x50
		protected FFHPBEPOMAK_DivaInfo m_divaData; // 0x54
		protected DFKGGBMFFGB m_playerData; // 0x58
		protected EEDKAACNBBG m_musicData; // 0x5C
		protected StringBuilder m_strBuilder = new StringBuilder(64); // 0x60
		private bool m_isDisp2ndCenterSkill; // 0x64
		private bool m_isDisp2ndLiveSkill; // 0x65

		// RVA: 0x17D2AB4 Offset: 0x17D2AB4 VA: 0x17D2AB4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			OnPushDetailsEvent -= OnShowSkillDetials;
			OnPushDetailsEvent += OnShowSkillDetials;
			return base.InitializeFromLayout(layout, uvMan);
		}

		//// RVA: 0x17D2BA4 Offset: 0x17D2BA4 VA: 0x17D2BA4 Slot: 7
		public override void InitializeDecoration()
		{
			m_divaIconDecoration.Initialize(m_iconImage.gameObject, DivaIconDecoration.Size.M, true, false, null, null);
		}

		//// RVA: 0x17D2C40 Offset: 0x17D2C40 VA: 0x17D2C40 Slot: 8
		public override void ReleaseDecoration()
		{
			m_divaIconDecoration.Release();
		}

		//// RVA: 0x17D2E70 Offset: 0x17D2E70 VA: 0x17D2E70 Slot: 9
		public override void UpdateDecoration(DisplayType type)
		{
			if(m_divaData != null)
				m_divaIconDecoration.Change(m_divaData, m_playerData, type);
		}

		//// RVA: 0x17D3390 Offset: 0x17D3390 VA: 0x17D3390
		public void UpdateContent(FFHPBEPOMAK_DivaInfo divaData, FFHPBEPOMAK_DivaInfo comparisonDiva, DFKGGBMFFGB playerData, EEDKAACNBBG musicData, bool isCenterDiva)
		{
			m_divaData = divaData;
			m_playerData = playerData;
			m_musicData = musicData;
			for(int i = 0; i < m_arrowImages.Length; i++)
			{
				m_arrowImages[i].enabled = false;
			}
			m_skillDispIndex = isCenterDiva ? 0 : 2;
			m_skillDispMax = 5;
			int luck = 0;
			if(divaData == null)
			{
				for(int i = 0; i < m_paramTexts.Length; i++)
				{
					m_paramTexts[i].text = "0";
				}
			}
			else
			{
				luck = DivaIconDecoration.GetEquipmentLuck(divaData, playerData);
				m_paramTexts[0].text = divaData.CMCKNKKCNDK_EquippedStatus.Total.ToString();
				m_paramTexts[1].text = divaData.CMCKNKKCNDK_EquippedStatus.soul.ToString();
				m_paramTexts[2].text = divaData.CMCKNKKCNDK_EquippedStatus.vocal.ToString();
				m_paramTexts[3].text = divaData.CMCKNKKCNDK_EquippedStatus.charm.ToString();
				m_paramTexts[4].text = divaData.CMCKNKKCNDK_EquippedStatus.life.ToString();
				UnitWindowConstant.SetLuckText(m_paramTexts[5], luck);
				m_paramTexts[6].text = divaData.CMCKNKKCNDK_EquippedStatus.support.ToString();
				m_paramTexts[7].text = divaData.CMCKNKKCNDK_EquippedStatus.fold.ToString();
			}
			if(m_arrowImages.Length != 0)
			{
				if(comparisonDiva != null)
				{
					int compLuck = DivaIconDecoration.GetEquipmentLuck(comparisonDiva, playerData);
				}
				if(divaData == null || comparisonDiva == null)
				{
					if(comparisonDiva == null)
					{
						if(divaData != null)
						{
							ComparisonValue(m_paramTexts[0], 0, divaData.CMCKNKKCNDK_EquippedStatus.Total, 0);
							ComparisonValue(m_paramTexts[1], 0, divaData.CMCKNKKCNDK_EquippedStatus.soul, 1);
							ComparisonValue(m_paramTexts[2], 0, divaData.CMCKNKKCNDK_EquippedStatus.vocal, 2);
							ComparisonValue(m_paramTexts[3], 0, divaData.CMCKNKKCNDK_EquippedStatus.charm, 3);
							ComparisonValue(m_paramTexts[4], 0, divaData.CMCKNKKCNDK_EquippedStatus.life, 4);
							ComparisonValue(m_paramTexts[5], 0, luck, 5);
							ComparisonValue(m_paramTexts[6], 0, divaData.CMCKNKKCNDK_EquippedStatus.support, 6);
							ComparisonValue(m_paramTexts[7], 0, divaData.CMCKNKKCNDK_EquippedStatus.fold, 7);
						}
					}
					else
					{
						ComparisonValue(m_paramTexts[0], comparisonDiva.CMCKNKKCNDK_EquippedStatus.Total, 0, 0);
						ComparisonValue(m_paramTexts[1], comparisonDiva.CMCKNKKCNDK_EquippedStatus.soul, 0, 1);
						ComparisonValue(m_paramTexts[2], comparisonDiva.CMCKNKKCNDK_EquippedStatus.vocal, 0, 2);
						ComparisonValue(m_paramTexts[3], comparisonDiva.CMCKNKKCNDK_EquippedStatus.charm, 0, 3);
						ComparisonValue(m_paramTexts[4], comparisonDiva.CMCKNKKCNDK_EquippedStatus.life, 0, 4);
						ComparisonValue(m_paramTexts[5], 0, 0, 5);
						ComparisonValue(m_paramTexts[6], comparisonDiva.CMCKNKKCNDK_EquippedStatus.support, 0, 6);
						ComparisonValue(m_paramTexts[7], comparisonDiva.CMCKNKKCNDK_EquippedStatus.fold, 0, 7);
					}
				}
				else
				{
					ComparisonValue(m_paramTexts[0], comparisonDiva.CMCKNKKCNDK_EquippedStatus.Total, divaData.CMCKNKKCNDK_EquippedStatus.Total, 0);
					ComparisonValue(m_paramTexts[1], comparisonDiva.CMCKNKKCNDK_EquippedStatus.soul, divaData.CMCKNKKCNDK_EquippedStatus.soul, 1);
					ComparisonValue(m_paramTexts[2], comparisonDiva.CMCKNKKCNDK_EquippedStatus.vocal, divaData.CMCKNKKCNDK_EquippedStatus.vocal, 2);
					ComparisonValue(m_paramTexts[3], comparisonDiva.CMCKNKKCNDK_EquippedStatus.charm, divaData.CMCKNKKCNDK_EquippedStatus.charm, 3);
					ComparisonValue(m_paramTexts[4], comparisonDiva.CMCKNKKCNDK_EquippedStatus.life, divaData.CMCKNKKCNDK_EquippedStatus.life, 4);
					ComparisonValue(m_paramTexts[5], 0, luck, 5);
					ComparisonValue(m_paramTexts[6], comparisonDiva.CMCKNKKCNDK_EquippedStatus.support, divaData.CMCKNKKCNDK_EquippedStatus.support, 6);
					ComparisonValue(m_paramTexts[7], comparisonDiva.CMCKNKKCNDK_EquippedStatus.fold, divaData.CMCKNKKCNDK_EquippedStatus.fold, 7);
				}
			}
			m_flags = 0;
			if(divaData == null)
			{
				MenuScene.Instance.DivaIconCache.LoadStateIcon(0, 0, 0, (IiconTexture texture) => {
					//0x17D612C
					texture.Set(m_iconImage);
					SetLoaded();
				});
				m_divaIconDecoration.SetActive(false);
				UnitWindowConstant.SetInvalidText(m_nameText);
				for(int i = 0; i < m_notes.Length; i++)
				{
					m_notes[i].SetNotesInvalid();
				}
			}
			else
			{
				MenuScene.Instance.DivaIconCache.LoadStateIcon(divaData.AHHJLDLAPAN_DivaId, divaData.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId, divaData.EKFONBFDAAP_ColorId, (IiconTexture texture) => {
					//0x17D6218
					texture.Set(m_iconImage);
					SetLoaded();
				});
				m_divaIconDecoration.SetActive(true);
				m_nameText.text = divaData.OPFGFINHFCE_DivaName;
				m_nameText.alignment = UnityEngine.TextAnchor.MiddleLeft;
				for(int i = 0; i < m_paramTexts.Length; i++)
				{
					m_paramTexts[i].alignment = UnityEngine.TextAnchor.MiddleRight;
				}
				{
					int j = 0;
					for(int i = 0; i < divaData.CMCKNKKCNDK_EquippedStatus.spNoteExpected.Length && i < m_notes.Length && j < m_notes.Length; i++)
					{
						if(divaData.CMCKNKKCNDK_EquippedStatus.spNoteExpected[i] > 0)
						{
							m_notes[j].SetNotesValue(divaData.CMCKNKKCNDK_EquippedStatus.spNoteExpected[i]);
							m_notes[j].SetNotesIcon((SpecialNoteAttribute.Type)i);
							j++;
						}
					}
					for(; j < m_notes.Length; j++)
					{
						m_notes[j].SetNotesInvalid();
					}
				}
				if(divaData.FGFIBOBAPIA_SceneId > 0)
				{
					//playerData.OPIBAPEGCLA_Scenes[divaData.FGFIBOBAPIA_SceneId - 1];
				}
				m_strBuilder.Clear();
				m_strBuilder.AppendFormat("{0:D2}", divaData.AHHJLDLAPAN_DivaId);
				m_isCenterDiva = isCenterDiva;
			}
			UpdateText(0, m_skillDispIndex);
			UpdateSkillText(0, m_skillDispIndex);
		}

		//// RVA: 0x17D5054 Offset: 0x17D5054 VA: 0x17D5054 Slot: 6
		protected override void UpdateSkillText(int pos, int index)
		{
			int musicId = m_musicData != null ? m_musicData.DLAEJOBELBH_MusicId : 0;
			SetSkillCrossFade(pos, false);
			ComparisonSkillInfo.SkillMask mask = ComparisonSkillInfo.SkillMask.None;
			if(m_divaData != null)
			{
				GCIJNCFDNON sceneInfo = GetSlotSceneData((SkillDiapIndex)index);
				switch(index)
				{
					case (int)SkillDiapIndex.MainSlotCenter:
						m_isDisp2ndCenterSkill = false;
						if(sceneInfo == null)
							break;
						bool resetDisplay = true;
						int skillId = sceneInfo.MEOOLHNNMHL_GetSkillId(false, 0, 0);
						int skillId2 = sceneInfo.MEOOLHNNMHL_GetSkillId(true, 0, 0);
						if(skillId2 == skillId)
							skillId2 = 0;
						if(m_musicData == null)
						{
							//sceneInfo.MEOOLHNNMHL(false, 0, 0);
							if(skillId > 0)
							{
								SetSkillLevel(pos, sceneInfo.DDEDANKHHPN_SkillLevel, 0);
								SetSkillRank(pos, (SkillRank.Type)sceneInfo.DHEFMEGKKDN_CenterSkillRank, 0);
								SetSkillDescription(pos, sceneInfo.IHLINMFMCDN_GetCenterSkillDesc(false));
								m_skillInfos[pos].RegulationButton.Setup(musicId, RegulationButton.Type.Center, sceneInfo);
								resetDisplay = false;
								if(skillId2 > 0)
								{
									SetSkillLevel(pos, sceneInfo.DDEDANKHHPN_SkillLevel, 1);
									SetSkillRank(pos, (SkillRank.Type)sceneInfo.FFDCGHDNDFJ_CenterSkillRank2, 1);
									SetSkillDescription(pos, sceneInfo.IHLINMFMCDN_GetCenterSkillDesc(true));
									SetSkillCrossFade(pos, true);
								}
							}
						}
						else
						{
							skillId = sceneInfo.MEOOLHNNMHL_GetSkillId(false, m_musicData.FKDCCLPGKDK_JacketAttr, m_musicData.AIHCEGFANAM_Serie);
							if(skillId < 1)
								resetDisplay = true;
							else
							{
								m_isDisp2ndCenterSkill = skillId == skillId2;
								SetSkillLevel(pos, sceneInfo.DDEDANKHHPN_SkillLevel, 0);
								SetSkillRank(pos, (SkillRank.Type)(m_isDisp2ndCenterSkill ? sceneInfo.FFDCGHDNDFJ_CenterSkillRank2 : sceneInfo.DHEFMEGKKDN_CenterSkillRank), 0);
								SetSkillDescription(pos, sceneInfo.IHLINMFMCDN_GetCenterSkillDesc(false));
								resetDisplay = false;
								m_skillInfos[pos].RegulationButton.Setup(musicId, RegulationButton.Type.Center, sceneInfo);
							}
						}
						mask = ComparisonSkillInfo.SkillMask.NoCenterDiva;
						if(m_isCenterDiva)
						{
							mask = m_skillInfos[pos].RegulationButton.IsMisMatchAttr ? ComparisonSkillInfo.SkillMask.MisMatchAttr : ComparisonSkillInfo.SkillMask.None;
							if(m_skillInfos[pos].RegulationButton.IsMisMatchSeries)
								mask = ComparisonSkillInfo.SkillMask.MisMatchSeries;
						}
						if(!resetDisplay)
						{
							SetSkillMask(pos, mask);
							return;
						}
					break;
					case (int)SkillDiapIndex.MainSlotActive:
						if(sceneInfo != null && sceneInfo.HGONFBDIBPM_ActiveSkillId > 0)
						{
							SetSkillLevel(pos, sceneInfo.PNHJPCPFNFI_ActiveSkillLevel, 0);
							SetSkillRank(pos, (SkillRank.Type)sceneInfo.BEKGEAMJGEN_ActiveSkillRank, 0);
							SetSkillDescription(pos, sceneInfo.PCMEMHPDABG_GetActiveSkillDesc(), 0);
							m_skillInfos[pos].RegulationButton.Setup(musicId, RegulationButton.Type.Active, null);
							mask = m_isCenterDiva ? ComparisonSkillInfo.SkillMask.None : ComparisonSkillInfo.SkillMask.NoCenterDiva;
						}
						SetSkillMask(pos, mask);
						return;
					case (int)SkillDiapIndex.MainSlotLive:
					case (int)SkillDiapIndex.SubSlotLive1:
					case (int)SkillDiapIndex.SubSlotLive2:
						m_isDisp2ndLiveSkill = false;
						resetDisplay = true;
						if(sceneInfo != null)
						{
							if(m_musicData == null)
							{
								skillId = sceneInfo.FILPDDHMKEJ(false, 0, 0);
								skillId2 = sceneInfo.FILPDDHMKEJ(true, 0, 0);
								resetDisplay = true;
								if(skillId > 0)
								{
									SetSkillLevel(pos, sceneInfo.AADFFCIDJCB_LiveSkillLevel, 0);
									SetSkillRank(pos, (SkillRank.Type)sceneInfo.OAHMFMJIENM_LiveSkillRank, 0);
									SetSkillDescription(pos, sceneInfo.KDGACEJPGFG_GetLiveSkillDesc(false));
									resetDisplay = false;
									m_skillInfos[pos].RegulationButton.Setup(musicId, RegulationButton.Type.Live, sceneInfo);
								}
								if(skillId2 > 0 && sceneInfo.BLPHPMBFIEI_LiveSkillHasSwitchPatternCond())
								{
									SetSkillLevel(pos, sceneInfo.AADFFCIDJCB_LiveSkillLevel, 1);
									SetSkillRank(pos, (SkillRank.Type)sceneInfo.ELNJADBILOM_LiveSkillRank2, 1);
									SetSkillDescription(pos, sceneInfo.KDGACEJPGFG_GetLiveSkillDesc(true));
									SetSkillCrossFade(pos, true);
								}
								mask = ComparisonSkillInfo.SkillMask.None;
							}
							else
							{
								skillId = sceneInfo.FILPDDHMKEJ(false, m_musicData.FKDCCLPGKDK_JacketAttr, m_musicData.AIHCEGFANAM_Serie);
								skillId2 = sceneInfo.FILPDDHMKEJ(true, m_musicData.FKDCCLPGKDK_JacketAttr, m_musicData.AIHCEGFANAM_Serie);
								mask = ComparisonSkillInfo.SkillMask.None;
								if(skillId == skillId2 && sceneInfo.BLPHPMBFIEI_LiveSkillHasSwitchPatternCond())
								{
									m_isDisp2ndLiveSkill = true;
								}
								SetSkillLevel(pos, sceneInfo.AADFFCIDJCB_LiveSkillLevel, 0);
								SetSkillRank(pos, (SkillRank.Type)(m_isDisp2ndLiveSkill ? sceneInfo.ELNJADBILOM_LiveSkillRank2 : sceneInfo.OAHMFMJIENM_LiveSkillRank), 0);
								SetSkillDescription(pos, sceneInfo.KDGACEJPGFG_GetLiveSkillDesc(m_isDisp2ndLiveSkill));
								m_skillInfos[pos].RegulationButton.Setup(musicId, RegulationButton.Type.Live, sceneInfo);
								resetDisplay = false;
							}
							if(!resetDisplay)
							{
								mask = ComparisonSkillInfo.SkillMask.MainSlot;
								if(!(index == 2 && m_isCenterDiva))
								{
									mask = ComparisonSkillInfo.SkillMask.NoCompatible;
									if(sceneInfo.DCLLIDMKNGO_IsDivaCompatible(m_divaData.AHHJLDLAPAN_DivaId))
									{
										mask = m_skillInfos[pos].RegulationButton.IsMisMatchAttr ? ComparisonSkillInfo.SkillMask.MisMatchAttr : ComparisonSkillInfo.SkillMask.None;
										mask = m_skillInfos[pos].RegulationButton.IsMisMatchMusic ? ComparisonSkillInfo.SkillMask.MisMatchMusic : mask;
									}
								}
								SetSkillMask(pos, mask);
								return;
							}
						}
						break;
				}
			}
			SetSkillLevel(pos, 0, 0);
			SetSkillRank(pos, SkillRank.Type.None, 0);
			SetSkillDescription(pos, null, 0);
			m_skillInfos[pos].RegulationButton.Setup(musicId, 0, null);
			SetSkillMask(pos, mask);
		}

		//// RVA: 0x17D5C98 Offset: 0x17D5C98 VA: 0x17D5C98
		private GCIJNCFDNON GetSlotSceneData(SkillDiapIndex index)
		{
			if(index < SkillDiapIndex.SubSlotLive1)
			{
				if(m_divaData.FGFIBOBAPIA_SceneId == 0)
					return null;
				return m_playerData.OPIBAPEGCLA_Scenes[m_divaData.FGFIBOBAPIA_SceneId - 1];
			}
			else
			{
				if(index >= SkillDiapIndex.Max)
					return null;
				if(m_divaData.DJICAKGOGFO_SubSceneIds[(int)index - 3] == 0)
					return null;
				return m_playerData.OPIBAPEGCLA_Scenes[m_divaData.DJICAKGOGFO_SubSceneIds[(int)index - 3] - 1];
			}
		}

		//// RVA: 0x17D5E38 Offset: 0x17D5E38 VA: 0x17D5E38
		private void OnShowSkillDetials(ComparisonSkillInfo info, int index)
		{
			TodoLogger.LogNotImplemented("OnShowSkillDetials");
		}
	}
}
