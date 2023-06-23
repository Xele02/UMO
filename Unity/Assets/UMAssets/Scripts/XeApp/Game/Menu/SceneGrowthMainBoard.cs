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
			MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[sceneData.BCCHOBPJJKE_SceneId - 1];
			m_sceneData = sceneData;
			m_boardSquareList.Clear();
			int a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.LAGGGIEIPEG(sceneData.JKGFBFPIMGA_Rarity, m_sceneData.CGIELKDLHGE_GetEvolveId() > 1, sceneData.MCCIFLKCNKO_Feed) - 1;
			if(a > -1 && sceneData.DKFCPBEOBHB_Layout.PDKGMFHIFML_Pl.Count > a)
			{
				NLNDLEEJOFD n = sceneData.DKFCPBEOBHB_Layout.PDKGMFHIFML_Pl[a];
				for(int j = 0; j < n.GHPLINIACBB_Col; j++)
				{
					BoardSquare[] squares = new BoardSquare[5];
					for (int i = 0; i < 5; i++)
					{
						squares[i].type = 0;
					}
					m_boardSquareList.Add(squares);
				}
				for(int i = 0; i < sceneData.DKFCPBEOBHB_Layout.PDKGMFHIFML_Pl.Count; i++)
				{
					n = sceneData.DKFCPBEOBHB_Layout.PDKGMFHIFML_Pl[i];
					if (n.GHPLINIACBB_Col < m_boardSquareList.Count)
					{
						BoardSquare[] squares = m_boardSquareList[n.GHPLINIACBB_Col];
						int idx = n.PMBEODGMMBB_Row;
						AFIFDLOAKGI a_ = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board.PJADHDHKOEJ[n.JBGEEPFKIGG - 1];
						squares[idx].id = a_.INDDJNMPONH_StatType;
						squares[idx].saveIndex = (short)i;
						squares[idx].type = SquareType.Panel;
						squares[idx].isOpen = sceneData.FAPMGGOMCOE(i) == GCIJNCFDNON_SceneInfo.HINAICIJJJC.JIKCABGFIEG/*2*/;
						squares[idx].value = dbScene.GDHGEECAJGI_BoardValue[i];
					}
				}
				for(int i = 0; i < sceneData.DKFCPBEOBHB_Layout.ADPJCNHAJPC_Rd.Count; i++)
				{
					n = sceneData.DKFCPBEOBHB_Layout.ADPJCNHAJPC_Rd[i];
					if(n.GHPLINIACBB_Col + 1 < m_boardSquareList.Count)
					{
						AFIFDLOAKGI a_ = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board.PJADHDHKOEJ[n.JBGEEPFKIGG - 1];
						if(a_.INDDJNMPONH_StatType != 16)
						{
							BoardSquare[] squares = m_boardSquareList[n.GHPLINIACBB_Col + 1];
							if (squares[n.PMBEODGMMBB_Row].type == SquareType.None)
								continue;
						}
						m_boardSquareList[n.GHPLINIACBB_Col][n.PMBEODGMMBB_Row].isOpen = m_boardSquareList[n.GHPLINIACBB_Col + 1][n.PMBEODGMMBB_Row].isOpen;
						m_boardSquareList[n.GHPLINIACBB_Col][n.PMBEODGMMBB_Row].id = n.JBGEEPFKIGG - 2;
						m_boardSquareList[n.GHPLINIACBB_Col][n.PMBEODGMMBB_Row].saveIndex = (short)i;
						m_boardSquareList[n.GHPLINIACBB_Col][n.PMBEODGMMBB_Row].type = a_.INDDJNMPONH_StatType == 16 ? SquareType.Start : SquareType.Road;
					}
				}
				bool b = sceneData.JKGFBFPIMGA_Rarity > 3 && sceneData.JKGFBFPIMGA_Rarity == sceneData.EKLIPGELKCL_SceneRarity && sceneData.JKGFBFPIMGA_Rarity < 6;
				if(b && NHPDPKHMFEP.HHCJCDFCLOB.MENKMJPCELJ() != -2)
				{
					int idx = 0;
					for(int i = 0; i < m_boardSquareList.Count; i++)
					{
						if (m_boardSquareList[i][2].type != SquareType.Panel)
						{
							idx = i;
							break;
						}
					}
					int c = 0;
					int d = 0;
					for(int i = 0; i < sceneData.DKFCPBEOBHB_Layout.PDKGMFHIFML_Pl.Count; i++)
					{
						if(idx < sceneData.DKFCPBEOBHB_Layout.PDKGMFHIFML_Pl[i].GHPLINIACBB_Col &&
							sceneData.DKFCPBEOBHB_Layout.PDKGMFHIFML_Pl[i].PMBEODGMMBB_Row == 2)
						{
							c = sceneData.DKFCPBEOBHB_Layout.PDKGMFHIFML_Pl[i].GHPLINIACBB_Col;
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
					int rarity_up_item_id = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("rarity_up_item_id", 230001);
					rarity_up_item_id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(rarity_up_item_id);
					int cnt = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.JJKEDPHDEDO_GetSpItemCount(rarity_up_item_id);
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
					sceneData.EKLIPGELKCL_SceneRarity, JpStringLiterals.StringLiteral_20179, a + 1,
					JpStringLiterals.StringLiteral_20180, sceneData.DKFCPBEOBHB_Layout.PDKGMFHIFML_Pl.Count,
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
			for (int i = 0; i < m_boardSquareList.Count - 1; i++)
			{
				for (int j = 0; j < m_boardSquareList[i].Length; j++)
				{
					if(m_boardSquareList[i][j].type == SquareType.Panel)
					{
						m_boardSquareList[i][j].isOpen = m_sceneData.FAPMGGOMCOE(m_boardSquareList[i][j].saveIndex) == GCIJNCFDNON_SceneInfo.HINAICIJJJC.JIKCABGFIEG/*2*/;
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
			int a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.LAGGGIEIPEG(m_sceneData.JKGFBFPIMGA_Rarity, false, m_sceneData.MCCIFLKCNKO_Feed);
			NLNDLEEJOFD n = m_sceneData.DKFCPBEOBHB_Layout.PDKGMFHIFML_Pl[a];
			SetScrollPosition(GetScrollAreaInPosition(n.GHPLINIACBB_Col * 120, 0.2f));
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
