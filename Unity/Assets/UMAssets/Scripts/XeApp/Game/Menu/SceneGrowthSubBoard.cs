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
					NLNDLEEJOFD n2 = d.PDKGMFHIFML_Panels[d.PDKGMFHIFML_Panels.Count - 2];
					v2 += Mathf.Max(n2.GHPLINIACBB_Col, d.ADPJCNHAJPC_Roads[d.ADPJCNHAJPC_Roads.Count - 2].GHPLINIACBB_Col);
					v1 += d.PDKGMFHIFML_Panels.Count - 1;
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
						squares[j].type = 0;
					}
					m_boardSquareList.Add(squares);
				}
				DMPDJFAGCPN d2 = sceneData.JCNIAPAJAOB;
				int x = 0;
				int idx = 0;
				for (int i = 0; i < b; i++)
				{
					//L326
					d2 = sceneData.JCNIAPAJAOB;
					if (i < n.JPJNKNOJBMM)
						d2 = sceneData.IKBBCHGLLKB;
					for(int j = 0; j < d2.PDKGMFHIFML_Panels.Count - 1; j++)
					{
						NLNDLEEJOFD n2 = d2.PDKGMFHIFML_Panels[j];
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
							m_boardSquareList[n2.GHPLINIACBB_Col + x][n2.PMBEODGMMBB_Row].isOpen = sceneData.OIEHPHINMIO(idx) == GCIJNCFDNON_SceneInfo.HINAICIJJJC.JIKCABGFIEG_2/*2*/;
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
					x += d2.PDKGMFHIFML_Panels[d2.PDKGMFHIFML_Panels.Count - 2].GHPLINIACBB_Col;
				}
				if (a < sceneData.JPIPENJGGDD_NumBoard)
				{
					//L664
					NLNDLEEJOFD n2 = d2.PDKGMFHIFML_Panels[d2.PDKGMFHIFML_Panels.Count - 1];
					AFIFDLOAKGI a_ = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board.PJADHDHKOEJ[n2.JBGEEPFKIGG - 1];
					m_boardSquareList[m_boardSquareList.Count - 1][n2.PMBEODGMMBB_Row].id = a_.INDDJNMPONH_StatType;
					m_boardSquareList[m_boardSquareList.Count - 1][n2.PMBEODGMMBB_Row].saveIndex = (short)v1;
					m_boardSquareList[m_boardSquareList.Count - 1][n2.PMBEODGMMBB_Row].type = SquareType.Panel;
					m_boardSquareList[m_boardSquareList.Count - 1][n2.PMBEODGMMBB_Row].value = a_.MKNDAOHGOAK;
					m_boardSquareList[m_boardSquareList.Count - 1][n2.PMBEODGMMBB_Row].isOpen = sceneData.MCDPPBBLDKA(v1) > 0;
				}
				int v3_ = 0;
				for(int i = 0, idx2 = 0; i <= b; i++)
				{
					d2 = sceneData.JCNIAPAJAOB;
					if (i < n.JPJNKNOJBMM)
						d2 = sceneData.IKBBCHGLLKB;
					for (int j = 0; j < d2.ADPJCNHAJPC_Roads.Count - 1; j++, idx2++)
					{
						NLNDLEEJOFD n2 = d2.ADPJCNHAJPC_Roads[j];
						AFIFDLOAKGI a_ = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board.PJADHDHKOEJ[n2.JBGEEPFKIGG - 1];
						if(v3_ + n2.GHPLINIACBB_Col + 1 < m_boardSquareList.Count)
						{
							if(a_.INDDJNMPONH_StatType != 16)
							{
								if (m_boardSquareList[n2.GHPLINIACBB_Col + 1][n2.PMBEODGMMBB_Row].type == SquareType.None)
									continue;
							}
							if(m_boardSquareList[v3_ + n2.GHPLINIACBB_Col][n2.PMBEODGMMBB_Row].type != SquareType.Panel)
							{
								m_boardSquareList[v3_ + n2.GHPLINIACBB_Col][n2.PMBEODGMMBB_Row].isOpen = m_boardSquareList[v3_ + n2.GHPLINIACBB_Col + 1][n2.PMBEODGMMBB_Row].isOpen;
								m_boardSquareList[v3_ + n2.GHPLINIACBB_Col][n2.PMBEODGMMBB_Row].id = n2.JBGEEPFKIGG - 2;
								m_boardSquareList[v3_ + n2.GHPLINIACBB_Col][n2.PMBEODGMMBB_Row].saveIndex = (short)(idx2);
								m_boardSquareList[v3_ + n2.GHPLINIACBB_Col][n2.PMBEODGMMBB_Row].type = a_.INDDJNMPONH_StatType != 16 ? SquareType.Road : SquareType.Start;
							}
						}
					}
					v3_ += d2.PDKGMFHIFML_Panels[d2.PDKGMFHIFML_Panels.Count - 2].GHPLINIACBB_Col;
				}
			}
			else
			{
				//L1068
				int cnt = Mathf.Max(sceneData.JCNIAPAJAOB.PDKGMFHIFML_Panels[sceneData.JCNIAPAJAOB.PDKGMFHIFML_Panels.Count - 1].GHPLINIACBB_Col, sceneData.JCNIAPAJAOB.ADPJCNHAJPC_Roads[sceneData.JCNIAPAJAOB.ADPJCNHAJPC_Roads.Count - 2].GHPLINIACBB_Col);
				cnt *= b;
				if (a < sceneData.JPIPENJGGDD_NumBoard)
					cnt += 2;
				for(int j = 0; j <= cnt; j++)
				{
					BoardSquare[] squares = new BoardSquare[5];
					for (int i = 0; i < 5; i++)
						squares[i].type = SquareType.None;
					m_boardSquareList.Add(squares);
				}
				int cnt2 = (sceneData.JCNIAPAJAOB.PDKGMFHIFML_Panels.Count - 1) * b;
				int col = sceneData.JCNIAPAJAOB.PDKGMFHIFML_Panels[sceneData.JCNIAPAJAOB.PDKGMFHIFML_Panels.Count - 2].GHPLINIACBB_Col;
				for (int j = 0; j < cnt2; j++)
				{
					int idx = j % col;
					NLNDLEEJOFD n = sceneData.JCNIAPAJAOB.PDKGMFHIFML_Panels[idx];
					AFIFDLOAKGI a_ = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board.PJADHDHKOEJ[n.JBGEEPFKIGG - 1];
					int x = (j / col) * col + n.GHPLINIACBB_Col;
					m_boardSquareList[x][n.PMBEODGMMBB_Row].id = a_.INDDJNMPONH_StatType;
					m_boardSquareList[x][n.PMBEODGMMBB_Row].saveIndex = (short)j;
					m_boardSquareList[x][n.PMBEODGMMBB_Row].type = SquareType.Panel;
					m_boardSquareList[x][n.PMBEODGMMBB_Row].isOpen = sceneData.OIEHPHINMIO(j) == GCIJNCFDNON_SceneInfo.HINAICIJJJC.JIKCABGFIEG_2/*2*/;
					if(a_.INDDJNMPONH_StatType == 21 || a_.INDDJNMPONH_StatType == 19)
					{
						m_boardSquareList[x][n.PMBEODGMMBB_Row].value = 1;
					}
					else if(a_.INDDJNMPONH_StatType == 18)
					{
						m_boardSquareList[x][n.PMBEODGMMBB_Row].value = a_.MKNDAOHGOAK;
					}
				}
				if(a < sceneData.JPIPENJGGDD_NumBoard)
				{
					NLNDLEEJOFD n = sceneData.JCNIAPAJAOB.PDKGMFHIFML_Panels[sceneData.JCNIAPAJAOB.PDKGMFHIFML_Panels.Count - 1];
					AFIFDLOAKGI a_ = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board.PJADHDHKOEJ[n.JBGEEPFKIGG - 1];
					m_boardSquareList[m_boardSquareList.Count - 1][n.PMBEODGMMBB_Row].id = a_.INDDJNMPONH_StatType;
					m_boardSquareList[m_boardSquareList.Count - 1][n.PMBEODGMMBB_Row].saveIndex = (short)cnt2;
					m_boardSquareList[m_boardSquareList.Count - 1][n.PMBEODGMMBB_Row].type = SquareType.Panel;
					m_boardSquareList[m_boardSquareList.Count - 1][n.PMBEODGMMBB_Row].value = a_.MKNDAOHGOAK;
					m_boardSquareList[m_boardSquareList.Count - 1][n.PMBEODGMMBB_Row].isOpen = sceneData.MCDPPBBLDKA(cnt2) > 0;
				}
				{
					NLNDLEEJOFD n = sceneData.JCNIAPAJAOB.PDKGMFHIFML_Panels[sceneData.JCNIAPAJAOB.PDKGMFHIFML_Panels.Count - 2];
					int x = sceneData.JCNIAPAJAOB.PDKGMFHIFML_Panels.Count * b - 1;
					for(int i = 0; i < x; i++)
					{
						NLNDLEEJOFD n2 = sceneData.JCNIAPAJAOB.PDKGMFHIFML_Panels[i % (sceneData.JCNIAPAJAOB.PDKGMFHIFML_Panels.Count - 1)];
						AFIFDLOAKGI a_ = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board.PJADHDHKOEJ[n2.JBGEEPFKIGG - 1];
						int x2 = (i / (sceneData.JCNIAPAJAOB.PDKGMFHIFML_Panels.Count - 1) * n.GHPLINIACBB_Col + n2.GHPLINIACBB_Col);
						if(x2 + 1 < m_boardSquareList.Count)
						{
							if(a_.INDDJNMPONH_StatType != 16)
							{
								if (m_boardSquareList[n2.GHPLINIACBB_Col + 1][n2.PMBEODGMMBB_Row].type == 0)
									continue;
							}
							if(m_boardSquareList[x2][n2.PMBEODGMMBB_Row].type != SquareType.Panel)
							{
								m_boardSquareList[x2][n2.PMBEODGMMBB_Row].isOpen = m_boardSquareList[x2 + 1][n2.PMBEODGMMBB_Row].isOpen;
								m_boardSquareList[x2][n2.PMBEODGMMBB_Row].id = n2.JBGEEPFKIGG - 2;
								m_boardSquareList[x2][n2.PMBEODGMMBB_Row].saveIndex = (short)i;
								m_boardSquareList[x2][n2.PMBEODGMMBB_Row].type = a_.INDDJNMPONH_StatType == 16 ? SquareType.Start : SquareType.Road;
							}
						}
					}
				}
			}
			UpdateBoardLayout();
		}

		// RVA: 0x136713C Offset: 0x136713C VA: 0x136713C Slot: 9
		public override void UpdateBoardLayout()
		{
			for(int i = 0; i < m_boardSquareList.Count - 1; i++)
			{
				for(int j = 0; j < m_boardSquareList[i].Length; j++)
				{
					if(m_boardSquareList[i][j].type == SquareType.Road)
					{
						m_boardSquareList[i][j].isOpen = m_boardSquareList[i + 1][j].isOpen;
						m_boardSquareList[i][j].isPossible = IsPossiblePanel(i + 1, j);
					}
				}
			}
			for (int j = 0; j < m_boardSquareList.Count; j++)
			{
				for (int k = 0; k < m_boardSquareList[j].Length; k++)
				{
					if (m_boardSquareList[j][k].type == SquareType.Panel)
					{
						m_boardSquareList[j][k].isOpen = m_sceneData.OIEHPHINMIO(m_boardSquareList[j][k].saveIndex) == GCIJNCFDNON_SceneInfo.HINAICIJJJC.JIKCABGFIEG_2/*2*/;
						AFIFDLOAKGI a2 = GetPanelItem(m_boardSquareList[j][k].saveIndex);
						if (a2.INDDJNMPONH_StatType == 20)
						{
							m_boardSquareList[j][k].isPossible = IsPossiblePanel(j, k);
							m_boardSquareList[j][k].isOpen = m_sceneData.MCDPPBBLDKA(m_boardSquareList[j][k].saveIndex) > 0;
						}
						else
						{
							m_boardSquareList[j][k].isPossible = m_boardSquareList[j - 1][k].isPossible;
						}
					}
				}
			}
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
						if(m_sceneData.OIEHPHINMIO(m_boardSquareList[i][j].saveIndex) >= GCIJNCFDNON_SceneInfo.HINAICIJJJC.LAHFPKEJLCA_3/*3*/ &&
							m_sceneData.OIEHPHINMIO(m_boardSquareList[i][j].saveIndex) <= GCIJNCFDNON_SceneInfo.HINAICIJJJC.LBODGCPCGHA_4/*4*/)
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
			MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[m_sceneData.BCCHOBPJJKE_SceneId - 1];
			NLNDLEEJOFD n = m_sceneData.JCNIAPAJAOB.PDKGMFHIFML_Panels[m_sceneData.JCNIAPAJAOB.PDKGMFHIFML_Panels.Count - 2];
			NLNDLEEJOFD n2 = m_sceneData.JCNIAPAJAOB.ADPJCNHAJPC_Roads[m_sceneData.JCNIAPAJAOB.ADPJCNHAJPC_Roads.Count - 2];
			int cnt = Mathf.Max(n.GHPLINIACBB_Col, n2.GHPLINIACBB_Col);
			int a = m_sceneData.IELENGDJPHF;
			int b = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.GENHLFPKOEE(dbScene.EKLIPGELKCL_Rarity, dbScene.MCCIFLKCNKO_Feed);
			if (b < m_sceneData.IELENGDJPHF)
				a = b;
			int a2 = a - 1;
			int d = 0;
			if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board.AKKIBDEENJH(m_sceneData.ILABPFOMEAG_Va))
			{
				NHINPDLLFIO n3 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.JEMMMJEJLNL_Board.GJLBMELKHEM[m_sceneData.ILABPFOMEAG_Va - 1];
				NLNDLEEJOFD n4 = m_sceneData.JCNIAPAJAOB.PDKGMFHIFML_Panels[m_sceneData.JCNIAPAJAOB.PDKGMFHIFML_Panels.Count - 2];
				NLNDLEEJOFD n5 = m_sceneData.JCNIAPAJAOB.ADPJCNHAJPC_Roads[m_sceneData.JCNIAPAJAOB.ADPJCNHAJPC_Roads.Count - 2];
				cnt = Mathf.Max(n4.GHPLINIACBB_Col, n5.GHPLINIACBB_Col);
				n4 = m_sceneData.IKBBCHGLLKB.PDKGMFHIFML_Panels[m_sceneData.IKBBCHGLLKB.PDKGMFHIFML_Panels.Count - 2];
				n5 = m_sceneData.IKBBCHGLLKB.ADPJCNHAJPC_Roads[m_sceneData.IKBBCHGLLKB.ADPJCNHAJPC_Roads.Count - 2];
				int cnt2 = Mathf.Max(n4.GHPLINIACBB_Col, n5.GHPLINIACBB_Col);
				int c = cnt2;
				for (int i = 0; i < a2; i++)
				{
					c = cnt;
					if (i < n3.JPJNKNOJBMM)
						c = cnt2;
					d = c;
				}
				if (m_sceneData.IELENGDJPHF <= b)
					d -= c;
			}
			else if (b < m_sceneData.IELENGDJPHF)
				d = a2 * cnt;
			else
				d = (a - 2) * cnt;
			SetScrollPosition(GetScrollAreaInPosition((d + 1) * 120, 0.2f));
			for(int i = d + 1; i < m_boardSquareList.Count; i++)
			{
				for(int j = 0; j < m_boardSquareList[i].Length; j++)
				{
					if(m_boardSquareList[i][j].panelObject != null)
					{
						if(m_boardSquareList[i][j].panelObject is ISceneGrowthPanel)
						{
							(m_boardSquareList[i][j].panelObject as ISceneGrowthPanel).Expand();
						}
						else if(m_boardSquareList[i][j].panelObject is SceneGrowthInfinityPanel)
						{
							if (!IsFirstInfinityPanelOpen)
								(m_boardSquareList[i][j].panelObject as SceneGrowthInfinityPanel).SetOpen();
							else
								(m_boardSquareList[i][j].panelObject as SceneGrowthInfinityPanel).SetClose();
						}
						else if (m_boardSquareList[i][j].panelObject is SceneGrowthRoad)
						{
							if(i + 1 < m_boardSquareList.Count)
							{
								if (m_boardSquareList[i + 1][j].panelObject is ISceneGrowthPanel)
								{
									if((m_boardSquareList[i + 1][j].panelObject as ISceneGrowthPanel).PanelType != GrowthPanelType.Infinity || IsFirstInfinityPanelOpen)
									{
										(m_boardSquareList[i][j].panelObject as SceneGrowthRoad).Expand();
									}
									else
									{
										(m_boardSquareList[i][j].panelObject as SceneGrowthRoad).Expanded(m_boardSquareList[i][j].isOpen);
									}
								}
							}
							else
							{
								(m_boardSquareList[i][j].panelObject as SceneGrowthRoad).Expand();
							}
						}
						directionList.Add(m_boardSquareList[i][j].panelObject);
					}
				}
			}
		}
	}
}
