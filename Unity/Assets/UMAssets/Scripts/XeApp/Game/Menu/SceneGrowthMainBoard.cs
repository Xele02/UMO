using System.Collections.Generic;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class SceneGrowthMainBoard : SceneGrowthBoard
	{

		//// RVA: 0x10D7F20 Offset: 0x10D7F20 VA: 0x10D7F20 Slot: 12
		public override float GetScrollHeight()
		{
			return 550;
		}

		//// RVA: 0x10D7F2C Offset: 0x10D7F2C VA: 0x10D7F2C Slot: 8
		public override void SetBoardLayout(GCIJNCFDNON_SceneInfo sceneData)
		{
			MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_table[sceneData.BCCHOBPJJKE_SceneId - 1];
			m_sceneData = sceneData;
			m_boardSquareList.Clear();
			int a = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.HNMMJINNHII_Game.LAGGGIEIPEG(sceneData.JKGFBFPIMGA_Rarity, m_sceneData.CGIELKDLHGE_GetEvolveId() > 1, sceneData.MCCIFLKCNKO_Feed) - 1;
			if(a > -1 && sceneData.DKFCPBEOBHB_Layout.PDKGMFHIFML_Panels.Count > a)
			{
				NLNDLEEJOFD n = sceneData.DKFCPBEOBHB_Layout.PDKGMFHIFML_Panels[a];
				for(int j = 0; j < n.GHPLINIACBB_x + 1; j++)
				{
					BoardSquare[] squares = new BoardSquare[5];
					for (int i = 0; i < 5; i++)
					{
						squares[i].type = 0;
					}
					m_boardSquareList.Add(squares);
				}
				for(int i = 0; i < sceneData.DKFCPBEOBHB_Layout.PDKGMFHIFML_Panels.Count; i++)
				{
					n = sceneData.DKFCPBEOBHB_Layout.PDKGMFHIFML_Panels[i];
					if (n.GHPLINIACBB_x < m_boardSquareList.Count)
					{
						BoardSquare[] squares = m_boardSquareList[n.GHPLINIACBB_x];
						int idx = n.PMBEODGMMBB_y;
						AFIFDLOAKGI a_ = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.JEMMMJEJLNL_Board.PJADHDHKOEJ[n.JBGEEPFKIGG_val - 1];
						squares[idx].id = a_.INDDJNMPONH_type;
						squares[idx].saveIndex = (short)i;
						squares[idx].type = SquareType.Panel;
						squares[idx].isOpen = sceneData.FAPMGGOMCOE(i) == GCIJNCFDNON_SceneInfo.HINAICIJJJC.JIKCABGFIEG_2_Unlock/*2*/;
						squares[idx].value = dbScene.GDHGEECAJGI_BoardValue[i];
					}
				}
				for(int i = 0; i < sceneData.DKFCPBEOBHB_Layout.ADPJCNHAJPC_Roads.Count; i++)
				{
					n = sceneData.DKFCPBEOBHB_Layout.ADPJCNHAJPC_Roads[i];
					if(n.GHPLINIACBB_x + 1 < m_boardSquareList.Count)
					{
						AFIFDLOAKGI a_ = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.JEMMMJEJLNL_Board.PJADHDHKOEJ[n.JBGEEPFKIGG_val - 1];
						if(a_.INDDJNMPONH_type != 16)
						{
							BoardSquare[] squares = m_boardSquareList[n.GHPLINIACBB_x + 1];
							if (squares[n.PMBEODGMMBB_y].type == SquareType.None)
								continue;
						}
						m_boardSquareList[n.GHPLINIACBB_x][n.PMBEODGMMBB_y].isOpen = m_boardSquareList[n.GHPLINIACBB_x + 1][n.PMBEODGMMBB_y].isOpen;
						m_boardSquareList[n.GHPLINIACBB_x][n.PMBEODGMMBB_y].id = n.JBGEEPFKIGG_val - 2;
						m_boardSquareList[n.GHPLINIACBB_x][n.PMBEODGMMBB_y].saveIndex = (short)i;
						m_boardSquareList[n.GHPLINIACBB_x][n.PMBEODGMMBB_y].type = a_.INDDJNMPONH_type == 16 ? SquareType.Start : SquareType.Road;
					}
				}
				bool b = sceneData.JKGFBFPIMGA_Rarity > 3 && sceneData.JKGFBFPIMGA_Rarity == sceneData.EKLIPGELKCL_Rarity && sceneData.JKGFBFPIMGA_Rarity < 6;
				if(b && NHPDPKHMFEP_NetMonthlyPassManager.HHCJCDFCLOB_Instance.MENKMJPCELJ() != -2)
				{
					int idx = 0;
					for(int i = m_boardSquareList.Count - 1; i >= 0; i--)
					{
						if (m_boardSquareList[i][2].type == SquareType.Panel)
						{
							idx = i;
							break;
						}
					}
					int c = 0;
					int d = 0;
					for(int i = 0; i < sceneData.DKFCPBEOBHB_Layout.PDKGMFHIFML_Panels.Count; i++)
					{
						if(idx < sceneData.DKFCPBEOBHB_Layout.PDKGMFHIFML_Panels[i].GHPLINIACBB_x &&
							sceneData.DKFCPBEOBHB_Layout.PDKGMFHIFML_Panels[i].PMBEODGMMBB_y == 2)
						{
							c = sceneData.DKFCPBEOBHB_Layout.PDKGMFHIFML_Panels[i].GHPLINIACBB_x;
							d = i;
							break;
						}
					}
					for(int i = m_boardSquareList.Count; i <= c; i++)
					{
						BoardSquare[] squares = new BoardSquare[5];
						for(int j = 0; j < 5; j++)
						{
							squares[j].type = SquareType.None;
						}
						m_boardSquareList.Add(squares);
					}
					int rarity_up_item_id = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA_GetIntParam("rarity_up_item_id", 230001);
					rarity_up_item_id = EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(rarity_up_item_id);
					int cnt = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.JJKEDPHDEDO_GetSpItemCount(rarity_up_item_id);
					m_boardSquareList[c][2].id = 0;
					m_boardSquareList[c][2].saveIndex = (short)d;
					m_boardSquareList[c][2].type = SquareType.Lock;
					m_boardSquareList[c][2].isOpen = false;
					m_boardSquareList[c][2].isPossible = cnt > 0;
					m_boardSquareList[c][2].value = 0;

					m_boardSquareList[c - 1][2].id = 0;
					m_boardSquareList[c - 1][2].saveIndex = (short)d;
					m_boardSquareList[c - 1][2].type = SquareType.Road;
					m_boardSquareList[c - 1][2].isOpen = false;
				}
				UpdateBoardLayout();
			}
			else
			{
				Debug.LogError(string.Concat(new object[9] { "boardId=", dbScene.BJNBBEMBMIK_BoardId, JpStringLiterals.StringLiteral_20178,
					sceneData.EKLIPGELKCL_Rarity, JpStringLiterals.StringLiteral_20179, a + 1,
					JpStringLiterals.StringLiteral_20180, sceneData.DKFCPBEOBHB_Layout.PDKGMFHIFML_Panels.Count,
					JpStringLiterals.StringLiteral_20181
				}));
			}
		}

		//// RVA: 0x10D99C8 Offset: 0x10D99C8 VA: 0x10D99C8 Slot: 6
		public override float GetDefaultScrollPosition()
		{
			for(int i = 0; i < m_boardSquareList.Count; i++)
			{
				for(int j = 0; j < m_boardSquareList[i].Length; j++)
				{
					if(m_boardSquareList[i][j].type == SquareType.Panel)
					{
						if(m_sceneData.FAPMGGOMCOE(m_boardSquareList[i][j].saveIndex) == GCIJNCFDNON_SceneInfo.HINAICIJJJC.BPMNCMICDAF/*1*/)
						{
							return GetScrollAreaInPosition(i * 120, 0.5f);
						}
					}
				}
			}
			return 0;
		}

		//// RVA: 0x10D9B70 Offset: 0x10D9B70 VA: 0x10D9B70 Slot: 7
		protected override float GetScrollRange()
		{
			return m_scrollRect.GetComponent<RectTransform>().sizeDelta.x * 0.5f + m_boardSquareList.Count * 120 - 60;
		}

		//// RVA: 0x10D9C74 Offset: 0x10D9C74 VA: 0x10D9C74 Slot: 9
		public override void UpdateBoardLayout()
		{
			for(int i = 0; i < m_boardSquareList.Count - 1; i++)
			{
				for(int j = 0; j < m_boardSquareList[i].Length; j++)
				{
					if(m_boardSquareList[i][j].type == SquareType.Road)
					{
						m_boardSquareList[i][j].isOpen = m_boardSquareList[i + 1][j].isOpen;
					}
					m_boardSquareList[i][j].isPossible = IsPossiblePanel(i + 1, j);
				}
			}
			for (int i = 0; i < m_boardSquareList.Count; i++)
			{
				for (int j = 0; j < m_boardSquareList[i].Length; j++)
				{
					if(m_boardSquareList[i][j].type == SquareType.Panel)
					{
						m_boardSquareList[i][j].isOpen = m_sceneData.FAPMGGOMCOE(m_boardSquareList[i][j].saveIndex) == GCIJNCFDNON_SceneInfo.HINAICIJJJC.JIKCABGFIEG_2_Unlock/*2*/;
						m_boardSquareList[i][j].isPossible = m_boardSquareList[i - 1][j].isPossible;
					}
				}
			}
		}

		//// RVA: 0x10DA28C Offset: 0x10DA28C VA: 0x10DA28C Slot: 10
		public override AFIFDLOAKGI GetPanelItem(int index)
		{
			return m_sceneData.LDGCIDPEMPG(index);
		}

		//// RVA: 0x10DA2C0 Offset: 0x10DA2C0 VA: 0x10DA2C0 Slot: 11
		public override void InitializeExpandDirection(ref List<LayoutUGUIScriptBase> directionList)
		{
			int a = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.HNMMJINNHII_Game.LAGGGIEIPEG(m_sceneData.JKGFBFPIMGA_Rarity, false, m_sceneData.MCCIFLKCNKO_Feed);
			NLNDLEEJOFD n = m_sceneData.DKFCPBEOBHB_Layout.PDKGMFHIFML_Panels[a];
			SetScrollPosition(GetScrollAreaInPosition(n.GHPLINIACBB_x * 120, 0.2f));
			for(int i = 0; i < m_boardSquareList.Count; i++)
			{
				for(int j = 0; j < m_boardSquareList[i].Length; j++)
				{
					if(m_boardSquareList[i][j].panelObject != null)
					{
						if(m_boardSquareList[i][j].panelObject is ISceneGrowthPanel)
						{
							if (m_boardSquareList[i][j].saveIndex < a)
								continue;
							(m_boardSquareList[i][j].panelObject as ISceneGrowthPanel).Expand();
						}
						else if(m_boardSquareList[i][j].panelObject is SceneGrowthRoad)
						{
							(m_boardSquareList[i][j].panelObject as SceneGrowthRoad).Expand();
						}
						directionList.Add(m_boardSquareList[i][j].panelObject);
					}
				}
			}
		}
	}
}
