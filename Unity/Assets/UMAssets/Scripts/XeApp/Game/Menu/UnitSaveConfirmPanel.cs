using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using System.Text;
using XeSys;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class UnitSaveConfirmPanel : LayoutUGUIScriptBase
	{
		public enum Mode
		{
			Load = 0,
			Save = 1,
		}

		[SerializeField]
		private RawImageEx[] m_lowerDivaIconImages; // 0x14
		[SerializeField]
		private RawImageEx[] m_upperDivaIconImages; // 0x18
		[SerializeField]
		private RawImageEx[] m_lowerSceneIconImages; // 0x1C
		[SerializeField]
		private RawImageEx[] m_upperSceneIconImages; // 0x20
		[SerializeField]
		private Text m_lowerSlotNumberText; // 0x24
		[SerializeField]
		private Text m_upperSlotNumberText; // 0x28
		[SerializeField]
		private Text m_lowerUnitNameText; // 0x2C
		[SerializeField]
		private Text m_upperUnitNameText; // 0x30
		[SerializeField]
		private Text m_infoText; // 0x34
		[SerializeField]
		private Text m_lowerTotalText; // 0x38
		[SerializeField]
		private Text m_upperTotalText; // 0x3C
		private DivaIconDecoration[] m_divaIconDecoration; // 0x40
		private SceneIconDecoration[] m_sceneIconDecoration; // 0x44
		private AEGLGBOGDHH m_statusCalculateWork; // 0x48
		private StatusData m_statusResultWork = new StatusData(); // 0x78
		private StatusData m_costumeResultWork = new StatusData(); // 0x7C
		private StringBuilder m_strBuilder = new StringBuilder(64); // 0x80
		private AbsoluteLayout m_unitSwitchLayout; // 0x84

		// RVA: 0x124A9A0 Offset: 0x124A9A0 VA: 0x124A9A0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_unitSwitchLayout = layout.FindViewByExId("sw_overwrite_unit_01_swtbl_save_unit") as AbsoluteLayout;
			m_divaIconDecoration = new DivaIconDecoration[m_lowerDivaIconImages.Length + m_upperDivaIconImages.Length];
			m_sceneIconDecoration = new SceneIconDecoration[m_lowerSceneIconImages.Length + m_upperSceneIconImages.Length];
			int cnt = 0;
			for (int i = 0; i < m_lowerDivaIconImages.Length; i++, cnt++)
			{
				m_divaIconDecoration[cnt] = new DivaIconDecoration();
			}
			for (int i = 0; i < m_upperDivaIconImages.Length; i++, cnt++)
			{
				m_divaIconDecoration[cnt] = new DivaIconDecoration();
			}
			cnt = 0;
			for(int i = 0; i < m_lowerSceneIconImages.Length; i++, cnt++)
			{
				m_sceneIconDecoration[cnt] = new SceneIconDecoration();
			}
			for(int i = 0; i < m_upperSceneIconImages.Length; i++, cnt++)
			{
				m_sceneIconDecoration[cnt] = new SceneIconDecoration();
			}
			m_statusCalculateWork.OBKGEDCKHHE();
			ClearLoadedCallback();
			return true;
		}

		// RVA: 0x124AE1C Offset: 0x124AE1C VA: 0x124AE1C
		public void InitializeDecroration()
		{
			int cnt = 0;
			for(int i = 0; i < m_lowerDivaIconImages.Length; i++, cnt++)
			{
				m_divaIconDecoration[cnt].Initialize(m_lowerDivaIconImages[i].gameObject, DivaIconDecoration.Size.S, null, null);
			}
			for(int i = 0; i < m_upperDivaIconImages.Length; i++, cnt++)
			{
				m_divaIconDecoration[cnt].Initialize(m_upperDivaIconImages[i].gameObject, DivaIconDecoration.Size.S, null, null);
			}
			cnt = 0;
			for(int i = 0; i < m_lowerSceneIconImages.Length; i++, cnt++)
			{
				m_sceneIconDecoration[cnt].Initialize(m_lowerSceneIconImages[i].gameObject, SceneIconDecoration.Size.M, null, null);
			}
			for (int i = 0; i < m_upperSceneIconImages.Length; i++, cnt++)
			{
				m_sceneIconDecoration[cnt].Initialize(m_upperSceneIconImages[i].gameObject, SceneIconDecoration.Size.M, null, null);
			}
		}

		// RVA: 0x124B1E4 Offset: 0x124B1E4 VA: 0x124B1E4
		public void ReleaseDecoration()
		{
			for(int i = 0; i < m_divaIconDecoration.Length; i++)
			{
				m_divaIconDecoration[i].Release();
			}
			for(int i = 0; i < m_sceneIconDecoration.Length; i++)
			{
				m_sceneIconDecoration[i].Release();
			}
		}

		//// RVA: 0x124B2F4 Offset: 0x124B2F4 VA: 0x124B2F4
		public void Set(DFKGGBMFFGB_PlayerInfo playerData, int targetUnitId, Mode mode, EEDKAACNBBG_MusicData musicData, EJKBKMBJMGL_EnemyData enemyData, EAJCBFGKKFA_FriendInfo friendData, bool isGoDiva)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(mode == Mode.Save)
			{
				m_lowerSlotNumberText.text = bk.GetMessageByLabel(playerData.JKIJFGGMNAN_GetUnit(targetUnitId - 1, isGoDiva).EIGKIHENKNC_HasNoDivaSet ? "unit_setpopup_text_04" : "unit_setpopup_text_09");
				m_upperSlotNumberText.text = bk.GetMessageByLabel(playerData.JKIJFGGMNAN_GetUnit(targetUnitId - 1, isGoDiva).EIGKIHENKNC_HasNoDivaSet ? "unit_setpopup_text_03" : "unit_setpopup_text_08");
				m_infoText.text = string.Format(bk.GetMessageByLabel(playerData.JKIJFGGMNAN_GetUnit(targetUnitId - 1, isGoDiva).EIGKIHENKNC_HasNoDivaSet ? "unit_setpopup_text_05" : "unit_setpopup_text_06"), targetUnitId);
				m_unitSwitchLayout.StartChildrenAnimGoStop(playerData.JKIJFGGMNAN_GetUnit(targetUnitId - 1, isGoDiva).EIGKIHENKNC_HasNoDivaSet ? "02" : "01");
				Set(playerData.JKIJFGGMNAN_GetUnit(targetUnitId - 1, isGoDiva), playerData, playerData.OPIBAPEGCLA_Scenes, m_upperUnitNameText, m_upperTotalText, m_upperDivaIconImages, m_upperSceneIconImages, musicData, enemyData, friendData, isGoDiva);
				SetIcon(playerData.JKIJFGGMNAN_GetUnit(targetUnitId - 1, isGoDiva), playerData, m_divaIconDecoration, 3, m_sceneIconDecoration, 3, isGoDiva);
				Set(playerData.DPLBHAIKPGL_GetTeam(isGoDiva), playerData, playerData.OPIBAPEGCLA_Scenes, m_lowerUnitNameText, m_lowerTotalText, m_lowerDivaIconImages, m_lowerSceneIconImages, musicData, enemyData, friendData, isGoDiva);
				SetIcon(playerData.DPLBHAIKPGL_GetTeam(isGoDiva), playerData, m_divaIconDecoration, 0, m_sceneIconDecoration, 0, isGoDiva);
			}
			else
			{
				m_upperSlotNumberText.text = bk.GetMessageByLabel("unit_setpopup_text_01");
				m_lowerSlotNumberText.text = bk.GetMessageByLabel("unit_setpopup_text_02");
				m_infoText.text = string.Format(bk.GetMessageByLabel("unit_setpopup_text_07"), targetUnitId);
				m_unitSwitchLayout.StartChildrenAnimGoStop("01");
				Set(playerData.DPLBHAIKPGL_GetTeam(isGoDiva), playerData, playerData.OPIBAPEGCLA_Scenes, m_upperUnitNameText, m_upperTotalText, m_upperDivaIconImages, m_upperSceneIconImages, musicData, enemyData, friendData, isGoDiva);
				SetIcon(playerData.DPLBHAIKPGL_GetTeam(isGoDiva), playerData, m_divaIconDecoration, 3, m_sceneIconDecoration, 3, isGoDiva);
				Set(playerData.JKIJFGGMNAN_GetUnit(targetUnitId - 1, isGoDiva), playerData, playerData.OPIBAPEGCLA_Scenes, m_lowerUnitNameText, m_lowerTotalText, m_lowerDivaIconImages, m_lowerSceneIconImages, musicData, enemyData, friendData, isGoDiva);
				SetIcon(playerData.JKIJFGGMNAN_GetUnit(targetUnitId - 1, isGoDiva), playerData, m_divaIconDecoration, 0, m_sceneIconDecoration, 0, isGoDiva);
			}
		}

		//// RVA: 0x124BB4C Offset: 0x124BB4C VA: 0x124BB4C
		private void Set(JLKEOGLJNOD_TeamInfo unitData, DFKGGBMFFGB_PlayerInfo playerData, List<GCIJNCFDNON_SceneInfo> sceneList, Text unitNameText, Text total, RawImageEx[] divaImages, RawImageEx[] sceneImages, EEDKAACNBBG_MusicData musicData, EJKBKMBJMGL_EnemyData enemyData, EAJCBFGKKFA_FriendInfo friendData, bool isGoDiva)
		{
			unitNameText.text = unitData.EIGKIHENKNC_HasNoDivaSet ? "" : unitData.BHKALCOAHHO_Name;
			for(int i = 0; i < unitData.BCJEAJPLGMB_MainDivas.Count; i++)
			{
				int divaIndex = i;
				FFHPBEPOMAK_DivaInfo f = unitData.BCJEAJPLGMB_MainDivas[i];
				int divaId = 0;
				int cosId = 0;
				int colId = 0;
				if(f != null)
				{
					divaId = f.AHHJLDLAPAN_DivaId;
					cosId = f.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId;
					colId = f.EKFONBFDAAP_ColorId;
				}
				if(isGoDiva && i != 0)
				{
					if(divaId != 0)
					{
						MenuScene.Instance.DivaIconCache.LoadEventGoDivaIcon(divaId, (IiconTexture texture) =>
						{
							//0x124CA34
							texture.Set(divaImages[divaIndex]);
						});
					}
				}
				else
				{
					MenuScene.Instance.DivaIconCache.Load(divaId, cosId, colId, (IiconTexture texture) =>
					{
						//0x124CB60
						texture.Set(divaImages[divaIndex]);
					});
				}
				bool isKira = false;
				int evolve = 0;
				int sceneId = 0;
				if (f != null)
				{
					if(f.FGFIBOBAPIA_SceneId > 0)
					{
						sceneId = sceneList[f.FGFIBOBAPIA_SceneId - 1].BCCHOBPJJKE_SceneId;
						evolve = sceneList[f.FGFIBOBAPIA_SceneId - 1].CGIELKDLHGE_GetEvolveId();
						isKira = sceneList[f.FGFIBOBAPIA_SceneId - 1].MBMFJILMOBP_IsKira();
					}
				}
				MenuScene.Instance.SceneIconCache.Load(sceneId, evolve, (IiconTexture texture) =>
				{
					//0x124CC8C
					texture.Set(sceneImages[divaIndex]);
					SceneIconTextureCache.ChangeKiraMaterial(sceneImages[divaIndex], texture as IconTexture, isKira);
				});
			}
			if(unitData.EIGKIHENKNC_HasNoDivaSet)
			{
				UnitWindowConstant.SetInvalidText(total, TextAnchor.UpperLeft);
			}
			else
			{
				m_statusCalculateWork.JCHLONCMPAJ();
				CMMKCEPBIHI.DIDENKKDJKI(ref m_statusCalculateWork, unitData, playerData, musicData, friendData, enemyData);
				m_statusCalculateWork.GEEDEOHGMOM(ref m_statusResultWork);
				m_statusCalculateWork.DDPJACNMPEJ(ref m_costumeResultWork);
				m_statusResultWork.Add(unitData.JLJGCBOHJID_Status);
				m_statusResultWork.Add(m_costumeResultWork);
				if(friendData != null && friendData.KHGKPKDBMOH_GetAssistScene() != null)
				{
					m_statusResultWork.Add(friendData.KHGKPKDBMOH_GetAssistScene().CMCKNKKCNDK_Status);
				}
				m_strBuilder.Set(m_statusResultWork.Total.ToString());
				if(musicData != null && m_statusCalculateWork.COCIPAJKDAF() > 0)
				{
					m_strBuilder.AppendFormat(JpStringLiterals.StringLiteral_20882, m_statusCalculateWork.COCIPAJKDAF(), StatusTextColor.UpColor);
				}
				total.text = m_strBuilder.ToString();
			}
		}

		//// RVA: 0x124C4EC Offset: 0x124C4EC VA: 0x124C4EC
		private void SetIcon(JLKEOGLJNOD_TeamInfo unitData, DFKGGBMFFGB_PlayerInfo playerData, DivaIconDecoration[] divaIcon, int divaIconStartIndex, SceneIconDecoration[] sceneIcon, int sceneIconStartIndex, bool isGoDiva)
		{
			for(int i = 0; i < unitData.BCJEAJPLGMB_MainDivas.Count; i++)
			{
				FFHPBEPOMAK_DivaInfo d = unitData.BCJEAJPLGMB_MainDivas[i];
				GCIJNCFDNON_SceneInfo s = null;
				if(d != null)
				{
					divaIcon[divaIconStartIndex + i].Change(d, playerData, DisplayType.Level);
					if(d.FGFIBOBAPIA_SceneId > 0)
					{
						s = playerData.OPIBAPEGCLA_Scenes[d.FGFIBOBAPIA_SceneId - 1];
						sceneIcon[sceneIconStartIndex + i].Change(s, DisplayType.Level);
					}
				}
				divaIcon[divaIconStartIndex + i].SetActive((i == 0 || !isGoDiva) && d != null);
				sceneIcon[sceneIconStartIndex + i].SetActive(d != null && s != null);
			}
		}
	}
}
