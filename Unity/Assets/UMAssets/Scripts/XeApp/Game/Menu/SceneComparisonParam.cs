using System.Text;
using UnityEngine;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class SceneComparisonParam : ComparisonParamBase
	{
		public enum Style
		{
			Param = 0,
			Skill = 1,
			Notes = 2,
			Max = 3,
			Assist = 4,
			None = 5,
		}

		protected enum SkillDiapIndex
		{
			Center = 0,
			Active = 1,
			Live = 2,
			Max = 3,
			None = 4,
		}

		[SerializeField]
		private ComparisonNotesInfo[] m_notesInfo; // 0x50
		protected AbsoluteLayout m_styleLayout; // 0x54
		protected int m_styleIndex; // 0x58
		protected SceneIconDecoration m_sceneIconDecoration = new SceneIconDecoration(); // 0x5C
		protected GCIJNCFDNON_SceneInfo m_sceneData; // 0x60
		protected DFKGGBMFFGB_PlayerInfo m_playerData; // 0x64
		protected int m_musicId; // 0x68
		protected bool m_isMainSlot; // 0x6C
		protected bool m_isNoCompatible; // 0x6D
		private StringBuilder m_strBuilder = new StringBuilder(64); // 0x70
		private bool m_isDisp2ndCenterSkill; // 0x74
		private bool m_isDisp2ndLiveSkill; // 0x75
		private bool m_skillMisMatchMask; // 0x76

		// RVA: 0x159FCFC Offset: 0x159FCFC VA: 0x159FCFC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			RectTransform rt = transform as RectTransform;
			m_styleLayout = m_runtime.FindViewBase(rt) as AbsoluteLayout;
			return base.InitializeFromLayout(layout, uvMan);
		}

		// RVA: 0x159FE0C Offset: 0x159FE0C VA: 0x159FE0C Slot: 7
		public override void InitializeDecoration()
		{
			m_sceneIconDecoration.Initialize(m_iconImage.gameObject, SceneIconDecoration.Size.M, null, null);
			OnPushDetailsEvent -= OnShowSkillDetials;
			OnPushDetailsEvent += OnShowSkillDetials;
			for(int i = 0; i < m_notesInfo.Length; i++)
			{
				m_notesInfo[i].SetNotesIcon((SpecialNoteAttribute.Type)(i + 1));
				m_notesInfo[i].SetNotesValue(0);
			}
		}

		// RVA: 0x15A0018 Offset: 0x15A0018 VA: 0x15A0018 Slot: 8
		public override void ReleaseDecoration()
		{
			m_sceneIconDecoration.Release();
		}

		// RVA: 0x15A0044 Offset: 0x15A0044 VA: 0x15A0044 Slot: 9
		public override void UpdateDecoration(DisplayType type)
		{
			if (m_sceneData == null)
				return;
			m_sceneIconDecoration.Change(m_sceneData, type);
		}

		//// RVA: 0x15A0088 Offset: 0x15A0088 VA: 0x15A0088
		public void ChangeStyle()
		{
			m_styleIndex++;
			if (m_styleIndex > 2)
				m_styleIndex = 0;
			SetStyle((Style)m_styleIndex);
		}

		//// RVA: 0x15A00A0 Offset: 0x15A00A0 VA: 0x15A00A0
		public void SetStyle(Style style)
		{
			switch(style)
			{
				case Style.Param:
					m_styleIndex = 0;
					m_styleLayout.StartChildrenAnimGoStop("02");
					break;
				case Style.Skill:
					m_styleIndex = 1;
					m_styleLayout.StartChildrenAnimGoStop("03");
					break;
				case Style.Notes:
					m_styleIndex = 2;
					m_styleLayout.StartChildrenAnimGoStop("04");
					break;
				default:
					return;
				case Style.Assist:
				case Style.None:
					m_styleIndex = (int)style;
					m_styleLayout.StartChildrenAnimGoStop("01");
					break;
			}
		}

		//// RVA: 0x15A01E4 Offset: 0x15A01E4 VA: 0x15A01E4
		public int GetStyleIndex()
		{
			return m_styleIndex;
		}

		//// RVA: 0x15A01EC Offset: 0x15A01EC VA: 0x15A01EC
		public int GetStyleMax()
		{
			return 3;
		}

		//// RVA: 0x15A01F4 Offset: 0x15A01F4 VA: 0x15A01F4
		public void SetNotesValue(SpecialNoteAttribute.Type type, int value)
		{
			m_notesInfo[(int)type - 1].SetNotesValue(value);
		}

		//// RVA: 0x15A0264 Offset: 0x15A0264 VA: 0x15A0264
		public void UpdateContent(Style style, GCIJNCFDNON_SceneInfo sceneData, GCIJNCFDNON_SceneInfo comparisonScene, DFKGGBMFFGB_PlayerInfo playerData, FFHPBEPOMAK_DivaInfo divaData, int slotIndex, int divaSlot, int musicId = 0, bool isGoDiva = false)
		{
			!!!
		}

		//// RVA: 0x15A267C Offset: 0x15A267C VA: 0x15A267C Slot: 6
		protected override void UpdateSkillText(int pos, int index)
		{
			EONOEHOKBEB_Music musicInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(m_musicId);
			SetSkillCrossFade(pos, false);
			bool needResetDisplay = false;
			if(index == 2)
			{
				m_isDisp2ndLiveSkill = false;
				if(m_sceneData != null)
				{
					if(musicInfo == null)
					{
						int skillId = m_sceneData.FILPDDHMKEJ_GetLiveSkillId(false, 0, 0);
						int skillId2 = m_sceneData.FILPDDHMKEJ_GetLiveSkillId(true, 0, 0);
						needResetDisplay = true;
						if(skillId > 0)
						{
							SetSkillLevel(pos, m_sceneData.AADFFCIDJCB_LiveSkillLevel, 0);
							SetSkillRank(pos, (SkillRank.Type)m_sceneData.OAHMFMJIENM_LiveSkillRank, 0);
							SetSkillDescription(pos, m_sceneData.KDGACEJPGFG_GetLiveSkillDesc(false));
							m_skillInfos[pos].RegulationButton.Setup(m_musicId, RegulationButton.Type.Live, m_sceneData);
							needResetDisplay = false;
						}
						if(skillId2 > 0 && m_sceneData.BLPHPMBFIEI_LiveSkillHasSwitchPatternCond())
						{
							SetSkillLevel(pos, m_sceneData.AADFFCIDJCB_LiveSkillLevel, 1);
							SetSkillRank(pos, (SkillRank.Type)m_sceneData.ELNJADBILOM_LiveSkillRank2, 1);
							SetSkillDescription(pos, m_sceneData.KDGACEJPGFG_GetLiveSkillDesc(true), 1);
						}
						SetSkillCrossFade(pos, true);
						if (!needResetDisplay)
						{
							SetSkillMisMatchMask(pos, (SkillDiapIndex)index);
							return;
						}
					}
					else
					{
						int skillId = m_sceneData.FILPDDHMKEJ_GetLiveSkillId(false, musicInfo.FKDCCLPGKDK_Ma, musicInfo.AIHCEGFANAM_SerieId);
						int skillId2 = m_sceneData.FILPDDHMKEJ_GetLiveSkillId(true, musicInfo.FKDCCLPGKDK_Ma, musicInfo.AIHCEGFANAM_SerieId);
						if(skillId > 0)
						{
							int level = m_sceneData.AADFFCIDJCB_LiveSkillLevel;
							string desc = m_sceneData.KDGACEJPGFG_GetLiveSkillDesc(false);
							if(skillId == skillId2 && m_sceneData.BLPHPMBFIEI_LiveSkillHasSwitchPatternCond())
							{
								level = m_sceneData.ELNJADBILOM_LiveSkillRank2;
								desc = m_sceneData.KDGACEJPGFG_GetLiveSkillDesc(true);
								m_isDisp2ndLiveSkill = true;
							}
							SetSkillLevel(pos, level, 0);
							SetSkillRank(pos, (SkillRank.Type)m_sceneData.OAHMFMJIENM_LiveSkillRank, 0);
							SetSkillDescription(pos, desc, 0);
							m_skillInfos[pos].RegulationButton.Setup(m_musicId, RegulationButton.Type.Live, m_sceneData);
							SetSkillMisMatchMask(pos, (SkillDiapIndex)index);
							return;
						}
					}
				}
			}
			else if(index == 1)
			{
				if(m_sceneData == null || m_sceneData.HGONFBDIBPM_ActiveSkillId < 1)
				{
					SetSkillLevel(pos, m_sceneData.PNHJPCPFNFI_ActiveSkillLevel, 0);
					SetSkillRank(pos, (SkillRank.Type)m_sceneData.BEKGEAMJGEN_ActiveSkillRank, 0);
					SetSkillDescription(pos, m_sceneData.PCMEMHPDABG_GetActiveSkillDesc(), 0);
					m_skillInfos[pos].RegulationButton.Setup(m_musicId, RegulationButton.Type.Active, m_sceneData);
					SetSkillMisMatchMask(pos, (SkillDiapIndex)index);
					return;
				}
			}
			else
			{
				if(index != 0)
				{
					m_isDisp2ndCenterSkill = false;
					if (m_sceneData != null)
					{
						int skillId = m_sceneData.MEOOLHNNMHL_GetCenterSkillId(false, 0, 0);
						int skillId2 = m_sceneData.MEOOLHNNMHL_GetCenterSkillId(true, 0, 0);
						if (skillId == skillId2)
							skillId2 = 0;
						if (musicInfo == null)
						{
							if (skillId > 0)
							{
								SetSkillLevel(pos, m_sceneData.DDEDANKHHPN_SkillLevel, 0);
								SetSkillRank(pos, (SkillRank.Type)m_sceneData.DHEFMEGKKDN_CenterSkillRank, 0);
								SetSkillDescription(pos, m_sceneData.IHLINMFMCDN_GetCenterSkillDesc(false), 0);
								m_skillInfos[pos].RegulationButton.Setup(m_musicId, RegulationButton.Type.Center, m_sceneData);
								if (skillId2 > 0)
								{
									SetSkillLevel(pos, m_sceneData.DDEDANKHHPN_SkillLevel, 1);
									SetSkillRank(pos, (SkillRank.Type)m_sceneData.FFDCGHDNDFJ_CenterSkillRank2, 1);
									SetSkillDescription(pos, m_sceneData.IHLINMFMCDN_GetCenterSkillDesc(true));
									SetSkillCrossFade(pos, true);
								}
								SetSkillMisMatchMask(pos, (SkillDiapIndex)index);
								return;
							}
						}
						else
						{
							skillId = m_sceneData.MEOOLHNNMHL_GetCenterSkillId(false, musicInfo.FKDCCLPGKDK_Ma, musicInfo.AIHCEGFANAM_SerieId);
							if (skillId > 0)
							{
								m_isDisp2ndCenterSkill = skillId == skillId2;
								SetSkillLevel(pos, m_sceneData.DDEDANKHHPN_SkillLevel, 0);
								SetSkillRank(pos, (SkillRank.Type)(m_isDisp2ndCenterSkill ? m_sceneData.FFDCGHDNDFJ_CenterSkillRank2 : m_sceneData.DHEFMEGKKDN_CenterSkillRank), 0);
								SetSkillDescription(pos, m_sceneData.IHLINMFMCDN_GetCenterSkillDesc(m_isDisp2ndCenterSkill), 0);
								m_skillInfos[pos].RegulationButton.Setup(m_musicId, RegulationButton.Type.Center, m_sceneData);
								SetSkillMisMatchMask(pos, (SkillDiapIndex)index);
								return;
							}
						}
					}
				}
			}
			SetSkillLevel(pos, 0, 0);
			SetSkillRank(pos, 0, 0);
			SetSkillDescription(pos, null, 0);
			SetSkillMisMatchMask(pos, SkillDiapIndex.None);
			m_skillInfos[pos].RegulationButton.Setup(m_musicId, RegulationButton.Type.Center, null);
		}

		//// RVA: 0x15A2290 Offset: 0x15A2290 VA: 0x15A2290
		private void SetSkillMisMatchMask(int pos, SkillDiapIndex index)
		{
			ComparisonSkillInfo.SkillMask mask = ComparisonSkillInfo.SkillMask.None;
			if(m_skillMisMatchMask)
			{
				if(index == SkillDiapIndex.Live)
				{
					if(!m_isNoCompatible &&
						!m_isCenterDiva || !m_isMainSlot &&
						!m_skillInfos[pos].RegulationButton.IsMisMatchAttr &&
						!m_skillInfos[pos].RegulationButton.IsMisMatchMusic)
					{
						// nothing
					}
					else
					{
						if(m_isCenterDiva)
						{
							mask = ComparisonSkillInfo.SkillMask.MainSlot;
						}
						if(!m_isCenterDiva && !m_isMainSlot)
						{
							mask = ComparisonSkillInfo.SkillMask.NoCompatible;
							if(!m_isNoCompatible)
							{
								mask = m_skillInfos[pos].RegulationButton.IsMisMatchAttr ? ComparisonSkillInfo.SkillMask.MisMatchAttr : ComparisonSkillInfo.SkillMask.None;
								mask = m_skillInfos[pos].RegulationButton.IsMisMatchMusic ? ComparisonSkillInfo.SkillMask.MisMatchMusic : mask;
							}
						}
					}
				}
				else if(index == SkillDiapIndex.Active)
				{
					if (!m_isCenterDiva || m_isMainSlot)
					{
						mask = ComparisonSkillInfo.SkillMask.NoCenterDiva;
						if (m_isCenterDiva)
							mask = ComparisonSkillInfo.SkillMask.None;
					}
					else
						mask = ComparisonSkillInfo.SkillMask.NoCenterDiva;
				}
				else
				{
					mask = 0;
					if(index == SkillDiapIndex.Center)
					{
						mask = ComparisonSkillInfo.SkillMask.NoCenterDiva;
						if(m_isCenterDiva && m_isMainSlot)
						{
							mask = m_skillInfos[pos].RegulationButton.IsMisMatchAttr ? ComparisonSkillInfo.SkillMask.MisMatchAttr : ComparisonSkillInfo.SkillMask.None;
							mask = m_skillInfos[pos].RegulationButton.IsMisMatchSeries ? ComparisonSkillInfo.SkillMask.MisMatchSeries : mask;
						}
					}
				}
			}
			SetSkillMask(pos, mask);
		}

		//// RVA: 0x15A3050 Offset: 0x15A3050 VA: 0x15A3050
		private void OnShowSkillDetials(ComparisonSkillInfo info, int index)
		{
			TodoLogger.LogNotImplemented("OnShowSkillDetials");
		}
	}
}
