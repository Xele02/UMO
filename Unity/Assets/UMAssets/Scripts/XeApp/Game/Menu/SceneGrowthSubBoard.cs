using System.Collections.Generic;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class SceneGrowthSubBoard : SceneGrowthBoard
	{
		public bool IsFirstInfinityPanelOpen { get; set; } // 0x84

		// RVA: 0x13646C0 Offset: 0x13646C0 VA: 0x13646C0 Slot: 12
		public override float GetScrollHeight()
		{
			return 426;
		}

		// RVA: 0x13646DC Offset: 0x13646DC VA: 0x13646DC Slot: 8
		public override void SetBoardLayout(GCIJNCFDNON_SceneInfo sceneData)
		{
			m_sceneData = sceneData;
			m_boardSquareList.Clear();
			MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[sceneData.BCCHOBPJJKE_SceneId - 1];
			int a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.GENHLFPKOEE(dbScene.EKLIPGELKCL_Rarity, dbScene.MCCIFLKCNKO_Feed);
			int b = sceneData.JPIPENJGGDD_NumBoard;
			if (a < b)
				b = a;
			b--;
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board.AKKIBDEENJH(sceneData.ILABPFOMEAG_Va))
			{
				int v1 = 0;
				int v2 = 0;
				NHINPDLLFIO n = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board.GJLBMELKHEM[sceneData.ILABPFOMEAG_Va - 1];
				for(int i = 0; i < b; i++)
				{
					DMPDJFAGCPN d = sceneData.JCNIAPAJAOB;
					if (i < n.JPJNKNOJBMM)
						d = sceneData.IKBBCHGLLKB;
					NLNDLEEJOFD n2 = d.PDKGMFHIFML_Pl[n.JPJNKNOJBMM - 2];
					v2 += Mathf.Max(n2.GHPLINIACBB_Col, d.ADPJCNHAJPC_Rd[d.ADPJCNHAJPC_Rd.Count - 2].GHPLINIACBB_Col);
					v1 += d.PDKGMFHIFML_Pl.Count - 1;
				}
				if(a < sceneData.JPIPENJGGDD_NumBoard)
				{
					v2 += 2;
				}
				for(int i = 0; i <= v2; i++)
				{
					BoardSquare[] squares = new BoardSquare[5];
					for(int j = 0; j < 5; j++)
					{
						squares[i].type = 0;
					}
					m_boardSquareList.Add(squares);
				}
				DMPDJFAGCPN d2 = sceneData.JCNIAPAJAOB;
				int x = 0;
				int idx = 0;
				for (int i = 0; i < b; i++)
				{
					//L326
					DMPDJFAGCPN d = sceneData.JCNIAPAJAOB;
					if (i < n.JPJNKNOJBMM)
						d = sceneData.IKBBCHGLLKB;
					for(int j = 0; j < d.PDKGMFHIFML_Pl.Count - 1; j++)
					{
						NLNDLEEJOFD n2 = d.PDKGMFHIFML_Pl[j];
						int v3 = 0;
						int v4 = n2.JBGEEPFKIGG;
						if (v4 == -1)
						{
							v4 = n.JJMEIHLNPDI(sceneData.JGJFIJOCPAG_SceneAttr, i);
							v3 = n.JBGEEPFKIGG;
						}
						if(v4 > 0)
						{
							AFIFDLOAKGI a_ = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board.PJADHDHKOEJ[v4 - 1];
							m_boardSquareList[n2.GHPLINIACBB_Col + x][n2.PMBEODGMMBB_Row].id = a_.INDDJNMPONH_StatType;
							m_boardSquareList[n2.GHPLINIACBB_Col + x][n2.PMBEODGMMBB_Row].saveIndex = (short)idx;
							m_boardSquareList[n2.GHPLINIACBB_Col + x][n2.PMBEODGMMBB_Row].type = SquareType.Panel;
							m_boardSquareList[n2.GHPLINIACBB_Col + x][n2.PMBEODGMMBB_Row].isOpen = sceneData.OIEHPHINMIO(idx) == GCIJNCFDNON_SceneInfo.HINAICIJJJC.JIKCABGFIEG/*2*/;
							if(a_.INDDJNMPONH_StatType > 1 && a_.INDDJNMPONH_StatType < 5)
							{
								if(v3 == 0)
								{
									//LAB_013653c8
									v3 = a_.MKNDAOHGOAK;
								}
								else
								{
									if(a_.MKNDAOHGOAK > 0)
									{
										v3 = a_.MKNDAOHGOAK;
									}
								}
								//LAB_0136544c
								m_boardSquareList[n2.GHPLINIACBB_Col + x][n2.PMBEODGMMBB_Row].value = v3;
							}
							else
							{
								if(a_.INDDJNMPONH_StatType == 21 || a_.INDDJNMPONH_StatType == 19)
									v3 = 1;
								else if(a_.INDDJNMPONH_StatType == 18)
									v3 = a_.MKNDAOHGOAK;
								m_boardSquareList[n2.GHPLINIACBB_Col + x][n2.PMBEODGMMBB_Row].value = v3;
							}
							idx++;
						}
					}
					x += d.PDKGMFHIFML_Pl[d.PDKGMFHIFML_Pl.Count - 2].GHPLINIACBB_Col;
				}
				if (a < sceneData.JPIPENJGGDD_NumBoard)
				{
					//L664

				}
			}
			TodoLogger.Log(0, "SetBoardLayout");
		}

		// RVA: 0x136713C Offset: 0x136713C VA: 0x136713C Slot: 9
		public override void UpdateBoardLayout()
		{
			for(int i = 0; i < m_boardSquareList.Count - 1; i++)
			{
				for (int j = 0; j < m_boardSquareList.Count; j++)
				{
					for (int k = 0; k < m_boardSquareList[j].Length; k++)
					{
						if (m_boardSquareList[j][k].type == SquareType.Panel)
						{
							m_boardSquareList[j][k].isOpen = m_sceneData.OIEHPHINMIO(m_boardSquareList[j][k].saveIndex) == GCIJNCFDNON_SceneInfo.HINAICIJJJC.JIKCABGFIEG/*2*/;
							AFIFDLOAKGI a2 = GetPanelItem(m_boardSquareList[j][k].saveIndex);
							if (a2.INDDJNMPONH_StatType == 20)
							{
								//m_boardSquareList[j][k].isPossible =
							}
						}
					}
				}
			}
			TodoLogger.Log(0, "UpdateBoardLayout");
		}

		// RVA: 0x1367890 Offset: 0x1367890 VA: 0x1367890 Slot: 6
		public override float GetDefaultScrollPosition()
		{
			for (int i = 0; i < m_boardSquareList.Count; i++)
			{
				for(int j = 0; j < m_boardSquareList[i].Length; j++)
				{
					if(m_boardSquareList[i][j].type == SquareType.Panel)
					{
						if(m_sceneData.OIEHPHINMIO(m_boardSquareList[i][j].saveIndex) >= GCIJNCFDNON_SceneInfo.HINAICIJJJC.LAHFPKEJLCA/*3*/ &&
							m_sceneData.OIEHPHINMIO(m_boardSquareList[i][j].saveIndex) <= GCIJNCFDNON_SceneInfo.HINAICIJJJC.LBODGCPCGHA/*4*/)
						{
							return GetScrollAreaInPosition(i * 120 - 120 + 170, 0.5f);
						}
						if(m_sceneData.OIEHPHINMIO(m_boardSquareList[i][j].saveIndex) == GCIJNCFDNON_SceneInfo.HINAICIJJJC.BPMNCMICDAF/*1*/)
							return GetScrollAreaInPosition(i * 120, 0.5f);
					}
				}
			}
			return 0;
		}

		// RVA: 0x1367A68 Offset: 0x1367A68 VA: 0x1367A68 Slot: 7
		protected override float GetScrollRange()
		{
			for(int i = 0; i < m_boardSquareList[m_boardSquareList.Count - 1].Length; i++)
			{
				GetPanelItem(m_boardSquareList[m_boardSquareList.Count - 1][i].saveIndex);
			}
			return m_scrollRect.GetComponent<RectTransform>().sizeDelta.x * 0.5f + m_boardSquareList.Count * 120 - 60;
		}

		// RVA: 0x1367C58 Offset: 0x1367C58 VA: 0x1367C58 Slot: 10
		public override AFIFDLOAKGI GetPanelItem(int index)
		{
			return m_sceneData.CDDHNNLPOLG(index, m_sceneData.ILABPFOMEAG_Va, m_sceneData.JGJFIJOCPAG_SceneAttr);
		}

		// RVA: 0x1367CF4 Offset: 0x1367CF4 VA: 0x1367CF4 Slot: 11
		public override void InitializeExpandDirection(ref List<LayoutUGUIScriptBase> directionList)
		{
			TodoLogger.Log(0, "InitializeExpandDirection");
		}
	}
}
