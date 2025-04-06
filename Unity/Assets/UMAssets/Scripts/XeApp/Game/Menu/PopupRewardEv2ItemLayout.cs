using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using XeApp.Game.Common;
using mcrs;
using System.Collections;
using XeSys;
using XeApp.Core;

namespace XeApp.Game.Menu
{
	public class PopupRewardEv2ItemLayout : LayoutUGUIScriptBase
	{
		public enum PlateType
		{
			BIG = 0,
			SMALL = 1,
		}

		private enum ListType
		{
			Ranking = 0,
			Point = 1,
			Drop = 2,
		}

		public class ViewPlateData
		{
			public PlateType type; // 0x8
			public string name; // 0xC
			public List<string> point; // 0x10
			public List<string> ranking; // 0x14
			public int plateNo; // 0x18
			public GCIJNCFDNON_SceneInfo data; // 0x1C
			public string rankingTitle; // 0x20
		}

		private class ScrollData
		{
			public int index; // 0x8
			public PopupRewardEv2PlateBig big; // 0xC
			public PopupRewardEv2PlateSmall small; // 0x10

			// // RVA: 0x1A63124 Offset: 0x1A63124 VA: 0x1A63124
			public void Remove()
			{
				if(big != null)
				{
					big.gameObject.SetActive(false);
				}
				if(small != null)
				{
					small.gameObject.SetActive(false);
				}
			}
		}

		private AbsoluteLayout m_windowStyleTable; // 0x14
		[SerializeField] // RVA: 0x67ACDC Offset: 0x67ACDC VA: 0x67ACDC
		private ScrollRect m_scrollRect; // 0x18
		private SwapScrollList m_swapScroll; // 0x1C
		private List<PopupRewardEv2PlateBig> m_bigPlateList = new List<PopupRewardEv2PlateBig>(); // 0x20
		private List<PopupRewardEv2PlateSmall> m_smallPlateList = new List<PopupRewardEv2PlateSmall>(); // 0x24
		private List<ViewPlateData> m_plateList = new List<ViewPlateData>(); // 0x28
		private List<ViewPlateData> m_plateSmallList = new List<ViewPlateData>(); // 0x2C
		private List<ViewPlateData> m_plateBigList = new List<ViewPlateData>(); // 0x30
		private List<ScrollData> m_scrollList = new List<ScrollData>(); // 0x34
		private float m_downPos; // 0x38
		private float m_upPos; // 0x3C
		private int m_plateIndex; // 0x40
		private PopupRewardEv2DetailSetting m_plateDetailWindow = new PopupRewardEv2DetailSetting(); // 0x44
		private const int BIG_PANEL_SIZE = 390;
		private const int SMALL_PANEL_SIZE = 170;
		private const int PLATE_NUM = 8;
		private bool m_isInit; // 0x48

		// RVA: 0x162254C Offset: 0x162254C VA: 0x162254C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			return true;
		}

		// RVA: 0x1622554 Offset: 0x1622554 VA: 0x1622554
		private void Start()
		{
			return;
		}

		// RVA: 0x1622558 Offset: 0x1622558 VA: 0x1622558
		private void Update()
		{
			if(m_isInit)
			{
				if(m_scrollRect.content.localPosition.y <= m_downPos)
					UpdatePlate();
				if(m_scrollRect.content.localPosition.y >= m_upPos)
					UpdatePlate();
			}
		}

		// RVA: 0x1622A94 Offset: 0x1622A94 VA: 0x1622A94
		private void OnDestroy()
		{
			return;
		}

		// // RVA: 0x162263C Offset: 0x162263C VA: 0x162263C
		private void UpdatePlate()
		{
			Vector3 v = m_scrollRect.content.localPosition;
			float f1 = 390;
			float f2 = 0;
			int index = 0;
			for(int i = 0; i < m_plateList.Count; i++)
			{
				float f = 0;
				if(m_plateList[i].type == PlateType.SMALL)
					f = 170;
				if(m_plateList[i].type == PlateType.BIG)
					f = 390;
				f += f2;
				if(v.y <= f)
				{
					m_downPos = f2;
					m_upPos = f;
					index = i;
					break;
				}
				f2 = f;
			}
			for(int i = -1; i != -3 && i + index > -1; i--)
			{
				float f = 0;
				if(m_plateList[index + i].type == PlateType.SMALL)
					f = 170;
				if(m_plateList[index + i].type == PlateType.BIG)
					f = 390;
				f2 -= f;
			}
			for(int i = 0; i < m_scrollList.Count; i++)
			{
				if(m_scrollList[i].index <= index - 2 || index + 5 <= m_scrollList[i].index)
				{
					m_scrollList[i].Remove();
					m_scrollList.RemoveAt(i);
				}
			}
			float f4 = -f2;
			for(int i = -2; i != 5; i++)
			{
				SetPlate(0, f4, index + i);
				if(index + i > -1 && index + i < m_plateList.Count)
				{
					float f = 0;
					if(m_plateList[index + i].type == PlateType.SMALL)
						f = 170;
					if(m_plateList[index + i].type == PlateType.BIG)
						f = 390;
					f4 -= f;
				}
			}
		}

		// // RVA: 0x1622AC4 Offset: 0x1622AC4 VA: 0x1622AC4
		private void SetPlate(int startIndex, float pos, int listIndex)
		{
			if(listIndex >= 0 && listIndex < m_plateList.Count)
			{
				for(int i = 0; i < m_scrollList.Count; i++)
				{
					if(m_scrollList[i].index == listIndex)
						return;
				}
				ScrollData data = new ScrollData();
				data.index = listIndex;
				data.small = null;
				data.big = null;
				if(m_plateList[listIndex].type ==PlateType.SMALL)
				{
					for(int i = 0; i < m_smallPlateList.Count; i++)
					{
						if(!m_smallPlateList[i].gameObject.activeSelf)
						{
							data.small = m_smallPlateList[i];
							break;
						}
					}
					data.small.gameObject.SetActive(true);
					data.small.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, pos);
					data.small.Setup(m_plateList[listIndex]);
					data.small.GetBtn().ClearOnClickCallback();
					data.small.GetBtn().ClearOnStayCallback();
					int plateId = m_plateList[listIndex].plateNo;
					data.small.GetBtn().AddOnClickCallback(() =>
					{
						//0x1626500
						ShowPlateInfoWindow(plateId);
					});
					data.small.GetBtn().AddOnStayCallback(() =>
					{
						//0x1626530
						ShowPlateInfoWindow(plateId);
					});
					m_scrollList.Add(data);
					return;
				}
				else if(m_plateList[listIndex].type ==PlateType.BIG)
				{
					for(int i = 0; i < m_bigPlateList.Count; i++)
					{
						if(!m_bigPlateList[i].gameObject.activeSelf)
						{
							data.big = m_bigPlateList[i];
							break;
						}
					}
					data.big.gameObject.SetActive(true);
					data.big.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, pos);
					data.big.Setup(m_plateList[listIndex]);
					data.big.GetBtn().ClearOnClickCallback();
					data.big.GetBtn().ClearOnStayCallback();
					int plateId = m_plateList[listIndex].plateNo;
					data.big.GetBtn().AddOnClickCallback(() =>
					{
						//0x16264A0
						ShowPlateInfoWindow(plateId);
					});
					data.big.GetBtn().AddOnStayCallback(() =>
					{
						//0x16264D0
						ShowPlateInfoWindow(plateId);
					});
					m_scrollList.Add(data);
					return;
				}
			}
		}

		// // RVA: 0x1622A98 Offset: 0x1622A98 VA: 0x1622A98
		// private float GetPlateSize(PopupRewardEv2ItemLayout.PlateType type) { }

		// // RVA: 0x16235A4 Offset: 0x16235A4 VA: 0x16235A4
		public void Setup()
		{
			m_scrollList.Clear();
			for(int i = 0; i < m_bigPlateList.Count; i++)
			{
				m_bigPlateList[i].gameObject.SetActive(false);
			}
			for(int i = 0; i < m_smallPlateList.Count; i++)
			{
				m_smallPlateList[i].gameObject.SetActive(false);
			}
			LayoutElement l = m_scrollRect.content.Find("Range").GetComponent<LayoutElement>();
			float f2 = 0;
			for(int i = 0; i < m_plateList.Count; i++)
			{
				float f = 0;
				if(m_plateList[i].type == PlateType.SMALL)
					f = 170;
				if(m_plateList[i].type == PlateType.BIG)
					f = 390;
				f2 += f;
			}
			l.minHeight = f2;
			m_scrollRect.content.anchoredPosition = new Vector2(0, 0);
			UpdatePlate();
			m_isInit = true;
		}

		// // RVA: 0x162396C Offset: 0x162396C VA: 0x162396C
		private void CreatePlateList(PopupRewardEvCheck.ViewRewardEvCheckData data)
		{
			m_plateList.Clear();
			m_plateSmallList.Clear();
			m_plateBigList.Clear();
			if(data.dropList == null)
				return;
			for(int i = 0; i < data.dropList.Count; i++)
			{
				AddViewPlateList(data.dropList[i], "", ListType.Drop, "");
			}
			string str = JpStringLiterals.StringLiteral_19422;
			if(data.eventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection)
			{
				str = MessageManager.Instance.GetMessage("menu", "popup_event_reward_ranking_type001");
			}
			else if(data.eventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle)
			{
				str = MessageManager.Instance.GetMessage("menu", "popup_event_reward_ranking_type002");
			}
			else if(data.eventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva)
			{
				str = MessageManager.Instance.GetMessage("menu", "popup_event_reward_ranking_type003");
			}
			else if(data.eventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.NKDOEBONGNI_EventQuest && data.contExt != null)
			{
				TodoLogger.LogError(TodoLogger.EventQuest_6, "Event Quest");
			}
			for(int i = 0; i < data.total_data_list.Count; i++)
			{
				for(int j = 0; j < data.total_data_list[i].HBHMAKNGKFK_Items.Count; j++)
				{
					if(data.total_data_list[i].HBHMAKNGKFK_Items[j].NPPNDDMPFJJ_ItemCategory == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
					{
						AddViewPlateList(data.total_data_list[i].HBHMAKNGKFK_Items[j].JJBGOIMEIPF_ItemId - 40000, string.Concat(data.total_data_list[i].FIOIKMOIJGK_Point, "pt:", data.total_data_list[i].HBHMAKNGKFK_Items[j].MBJIFDBEDAC_Cnt, JpStringLiterals.StringLiteral_10090), ListType.Point, str);
					}
				}
			}
			if(data.eventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle)
			{
				str = MessageManager.Instance.GetMessage("menu", "popup_event_reward_ranking_type002");
			}
			else if(data.eventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.NKDOEBONGNI_EventQuest)
			{
				TodoLogger.LogError(TodoLogger.EventQuest_6, "Event Quest");
			}
			else
			{
				for(int i = 0; i < data.rank_data_list.Count; i++)
				{
					for(int j = 0; j < data.rank_data_list[i].HBHMAKNGKFK_Items.Count; j++)
					{
						if(data.rank_data_list[i].HBHMAKNGKFK_Items[j].NPPNDDMPFJJ_ItemCategory == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
						{
							AddViewPlateList(data.rank_data_list[i].HBHMAKNGKFK_Items[j].JJBGOIMEIPF_ItemId - 40000, string.Concat(new string[6]
							{
								data.rank_data_list[i].JBDGBPAAAEF_HighRank.ToString(),
								JpStringLiterals.StringLiteral_19427,
								data.rank_data_list[i].GHANKNIBALB_LowRank.ToString(),
								JpStringLiterals.StringLiteral_19428,
								data.rank_data_list[i].HBHMAKNGKFK_Items[j].MBJIFDBEDAC_Cnt.ToString(),
								JpStringLiterals.StringLiteral_10090
							}), ListType.Ranking, str);
						}
					}
				}
			}
			m_plateSmallList.Sort((ViewPlateData a, ViewPlateData b) =>
			{
				//0x16262F8
				return a.data.BCCHOBPJJKE_SceneId - b.data.BCCHOBPJJKE_SceneId;
			});
			m_plateBigList.Sort((ViewPlateData a, ViewPlateData b) =>
			{
				//0x1626360
				return a.data.BCCHOBPJJKE_SceneId - b.data.BCCHOBPJJKE_SceneId;
			});
			m_plateSmallList.Sort((ViewPlateData a, ViewPlateData b) =>
			{
				//0x16263C8
				return a.data.EKLIPGELKCL_SceneRarity - b.data.EKLIPGELKCL_SceneRarity;
			});
			m_plateBigList.Sort((ViewPlateData a, ViewPlateData b) =>
			{
				//0x1626430
				return a.data.EKLIPGELKCL_SceneRarity - b.data.EKLIPGELKCL_SceneRarity;
			});
			m_plateList.AddRange(m_plateBigList);
			m_plateList.AddRange(m_plateSmallList);
		}

		// // RVA: 0x16255F4 Offset: 0x16255F4 VA: 0x16255F4
		private void TrySceneInstall(int sceneId)
		{
			GameManager.Instance.SceneIconCache.TryInstall(sceneId, 1);
			GameManager.Instance.SceneIconCache.TryInstall(sceneId, 2);
		}

		// // RVA: 0x1625200 Offset: 0x1625200 VA: 0x1625200
		private void AddViewPlateList(int plateId, string str, ListType type, string rankingTitle)
		{
			if(type < ListType.Drop)
			{
				for(int i = 0; i < m_plateBigList.Count; i++)
				{
					if(m_plateBigList[i].plateNo == plateId)
					{
						AddViewPlateConditions(i, str, type);
						return;
					}
				}
			}
			if(type == ListType.Drop)
			{
				for(int i = 0; i < m_plateSmallList.Count; i++)
				{
					if(m_plateSmallList[i].plateNo == plateId)
						return;
				}
			}
			ViewPlateData d = new ViewPlateData();
			d.plateNo = plateId;
			d.point = new List<string>();
			d.ranking = new List<string>();
			d.data = new GCIJNCFDNON_SceneInfo();
			d.data.KHEKNNFCAOI(plateId, null, null, 0, 0, 0, false, 0, 0);
			if(type == ListType.Drop)
			{
				d.type = PlateType.SMALL;
				m_plateSmallList.Add(d);
			}
			else
			{
				d.type = PlateType.BIG;
				d.rankingTitle = rankingTitle;
				m_plateBigList.Add(d);
				AddViewPlateConditions(m_plateBigList.Count - 1, str, type);
			}
			TrySceneInstall(plateId);
		}

		// // RVA: 0x162570C Offset: 0x162570C VA: 0x162570C
		private void AddViewPlateConditions(int index, string str, ListType type)
		{
			if(type == ListType.Point)
			{
				m_plateBigList[index].point.Add(str);
			}
			else if(type == ListType.Ranking)
			{
				m_plateBigList[index].ranking.Add(str);
			}
		}

		// // RVA: 0x162581C Offset: 0x162581C VA: 0x162581C
		private void ShowPlateInfoWindow(int plateId)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			GCIJNCFDNON_SceneInfo[] scenes = new GCIJNCFDNON_SceneInfo[2];
			scenes[0] = new GCIJNCFDNON_SceneInfo();
			scenes[1] = new GCIJNCFDNON_SceneInfo();
			scenes[0].IJIKIPDKCPP = 1;
			scenes[1].IJIKIPDKCPP = 2;
			scenes[0].KHEKNNFCAOI(plateId, null, null, 0, 0, 0, false, 0, 0);
			scenes[1].KHEKNNFCAOI(plateId, null, null, 1, 0, 0, false, 0, 0);
			m_plateDetailWindow.TitleText = GameMessageManager.GetSceneCardName(scenes[0]);
			m_plateDetailWindow.SetParent(transform);
			m_plateDetailWindow.Scene = scenes;
			m_plateDetailWindow.WindowSize = SizeType.Large;
			m_plateDetailWindow.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type =  PopupButton.ButtonType.Negative }
			};
			PopupWindowManager.Show(m_plateDetailWindow, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1626498
				return;
			}, (IPopupContent content, PopupTabButton.ButtonLabel label) =>
			{
				//0x162649C
				return;
			}, null, null);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x70D85C Offset: 0x70D85C VA: 0x70D85C
		// // RVA: 0x1625EE0 Offset: 0x1625EE0 VA: 0x1625EE0
		public IEnumerator CO_LoadResource(PopupRewardEvCheck.ViewRewardEvCheckData data)
		{
			//0x162666C
			CreatePlateList(data);
			yield return this.StartCoroutineWatched(CO_LoadResourceBigPlate());
			yield return this.StartCoroutineWatched(CO_LoadResourceSmallPlate());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x70D8D4 Offset: 0x70D8D4 VA: 0x70D8D4
		// // RVA: 0x1625FA8 Offset: 0x1625FA8 VA: 0x1625FA8
		private IEnumerator CO_LoadResourceBigPlate()
		{
			AssetBundleLoadLayoutOperationBase layOp;

			//0x162680C
			LayoutUGUIRuntime runtime = null;
			layOp = AssetBundleManager.LoadLayoutAsync("ly/053.xab", "PopupRewardEv2Plate01");
			yield return layOp;
			yield return Co.R(layOp.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0x1626568
				runtime = instance.GetComponent<LayoutUGUIRuntime>();
			}));
			Transform t = m_scrollRect.content.Find("Range");
			for(int i = 0; i < 8; i++)
			{
				LayoutUGUIRuntime r = Instantiate(runtime);
				r.IsLayoutAutoLoad = false;
				r.Layout = runtime.Layout.DeepClone();
				r.UvMan = runtime.UvMan;
				r.LoadLayout();
				r.GetComponent<Transform>().SetParent(t, false);
				m_bigPlateList.Add(r.GetComponent<PopupRewardEv2PlateBig>());
			}
			Destroy(runtime);
			yield return null;
			AssetBundleManager.UnloadAssetBundle("ly/053.xab", false);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x70D94C Offset: 0x70D94C VA: 0x70D94C
		// // RVA: 0x1626054 Offset: 0x1626054 VA: 0x1626054
		private IEnumerator CO_LoadResourceSmallPlate()
		{
			AssetBundleLoadLayoutOperationBase layOp;

			//0x1626E54
			LayoutUGUIRuntime runtime = null;
			layOp = AssetBundleManager.LoadLayoutAsync("ly/053.xab", "PopupRewardEv2Plate02");
			yield return layOp;
			yield return Co.R(layOp.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0x16265EC
				runtime = instance.GetComponent<LayoutUGUIRuntime>();
			}));
			Transform t = m_scrollRect.content.Find("Range");
			for(int i = 0; i < 8; i++)
			{
				LayoutUGUIRuntime r = Instantiate(runtime);
				r.IsLayoutAutoLoad = false;
				r.Layout = runtime.Layout.DeepClone();
				r.UvMan = runtime.UvMan;
				r.LoadLayout();
				r.GetComponent<Transform>().SetParent(t, false);
				m_smallPlateList.Add(r.GetComponent<PopupRewardEv2PlateSmall>());
			}
			Destroy(runtime);
			yield return null;
			AssetBundleManager.UnloadAssetBundle("ly/053.xab", false);
		}
	}
}
