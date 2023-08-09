using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using mcrs;
using XeSys;
using System.Collections;
using XeApp.Core;

namespace XeApp.Game.Menu
{
	public class PopupLimitOverListContent : LayoutUGUIScriptBase, IPopupContent
	{
		[SerializeField]
		private SwapScrollList m_scrollList; // 0x14
		[SerializeField]
		private Text m_textTotal; // 0x18
		[SerializeField]
		private Text m_textDesc; // 0x1C
		[SerializeField]
		private RawImageEx m_imgSortUpDown; // 0x20
		[SerializeField]
		private ActionButton m_btnSortUpDown; // 0x24
		private TexUVListManager m_uvMan; // 0x28
		private PopupLimitOverListSetting m_setting; // 0x34
		private List<int> m_sceneIndexList = new List<int>(); // 0x38
		private uint m_order = (uint)ListSortButtonGroup.DefaultSortOrder; // 0x3C
		private SceneIconDecoration[] m_sceneIconDecoration; // 0x40
		private Dictionary<SwapScrollListContent, SceneIconDecoration> m_decrationMap; // 0x44
		private DisplayType m_dispType; // 0x48

		//public SwapScrollList List { get; } 0x1688364
		public Transform Parent { get; private set; } // 0x2C
		public int selectIndex { get; set; } // 0x30

		// RVA: 0x1688384 Offset: 0x1688384 VA: 0x1688384 Slot: 6
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupLimitOverListSetting s = setting as PopupLimitOverListSetting;
			m_setting = s;
			Parent = s.m_parent;
			GetComponent<RectTransform>().sizeDelta = size;
			GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
			ChangeContents(0);
			ChangeSort(m_setting.order);
			SetupList(m_sceneIndexList.Count, 0);
			gameObject.SetActive(true);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70558C Offset: 0x70558C VA: 0x70558C
		//// RVA: 0x1688240 Offset: 0x1688240 VA: 0x1688240
		public IEnumerator LoadContents()
		{
			AssetBundleLoadLayoutOperationBase operation; // 0x18
			int i; // 0x1C

			//0x168A0BC
			operation = AssetBundleManager.LoadLayoutAsync("ly/014.xab", "SceneIconButton");
			yield return operation;
			Font font = GameManager.Instance.GetSystemFont();
			GameObject prefab = operation.GetAsset<GameObject>();
			int poolSize = m_scrollList.ScrollObjectCount;
			LayoutUGUIRuntime runtime = prefab.GetComponent<LayoutUGUIRuntime>();
			yield return Co.R(operation.CreateLayoutCoroutine(runtime, font, (Layout loadLayout, TexUVListManager loadUvMan) =>
			{
				//0x1689CC4
				for(int j = 0; j < poolSize; j++)
				{
					GameObject g = Instantiate(prefab);
					LayoutUGUIRuntime r = g.GetComponent<LayoutUGUIRuntime>();
					r.IsLayoutAutoLoad = false;
					r.Layout = loadLayout.DeepClone();
					r.UvMan = loadUvMan;
					r.LoadLayout();
					Text[] ts = g.GetComponentsInChildren<Text>(true);
					for (int k = 0; k < ts.Length; k++)
					{
						ts[k].font = font;
					}
					m_scrollList.AddScrollObject(g.GetComponent<SceneIconScrollContent>());
				}
			}));
			for(i = 0; i < m_scrollList.ScrollObjects.Count; i++)
			{
				while (!m_scrollList.ScrollObjects[i].IsLoaded())
					yield return null;
			}
			m_scrollList.Apply();
		}

		//// RVA: 0x16885C8 Offset: 0x16885C8 VA: 0x16885C8
		public void ChangeContents(int tabIndex)
		{
			if(tabIndex == 1)
			{
				m_sceneIndexList = m_setting.sceneIndexList.FindAll((int listIndex) =>
				{
					//0x1689A30
					if (listIndex < 0)
						return false;
					else
					{
						if(m_setting.sceneList[listIndex].MNODFKEOPGK() < 1)
						{
							return m_setting.sceneList[listIndex].MKHFCGPJPFI_LimitOverCount > 0;
						}
						return false;
					}
				});
			}
			else
			{
				m_sceneIndexList = m_setting.sceneIndexList.FindAll((int listIndex) =>
				{
					//0x168995C
					if (listIndex < 0)
						return false;
					else
					{
						return m_setting.sceneList[listIndex].MNODFKEOPGK() > 0;
					}
				});
			}
			m_dispType = DisplayType.LuckyLeaf;
			m_textTotal.text = string.Format(MessageManager.Instance.GetMessage("menu", "popup_limit_over_list_count"), m_sceneIndexList.Count);
			if(m_sceneIndexList.Count < 1)
			{
				m_textDesc.text = MessageManager.Instance.GetMessage("menu", "popup_limit_over_list_none_desc");
				m_textDesc.enabled = true;
			}
			else
			{
				m_textDesc.enabled = false;
			}
		}

		//// RVA: 0x168784C Offset: 0x168784C VA: 0x168784C
		public void InitializeDecoration()
		{
			if (m_decrationMap == null)
				m_decrationMap = new Dictionary<SwapScrollListContent, SceneIconDecoration>(m_scrollList.ScrollObjects.Count);
			if(m_sceneIconDecoration == null)
			{
				m_sceneIconDecoration = new SceneIconDecoration[m_scrollList.ScrollObjects.Count];
				if (m_scrollList.ScrollObjects.Count < 1)
					return;
				for(int i = 0; i < m_scrollList.ScrollObjects.Count; i++)
				{
					m_sceneIconDecoration[i] = new SceneIconDecoration();
				}
			}
			for (int i = 0; i < m_scrollList.ScrollObjects.Count; i++)
			{
				m_sceneIconDecoration[i].Initialize((m_scrollList.ScrollObjects[i] as SceneIconScrollContent).SceneIconImage.gameObject, SceneIconDecoration.Size.M, null, null);
				m_decrationMap.Add(m_scrollList.ScrollObjects[i], m_sceneIconDecoration[i]);
			}
		}

		//// RVA: 0x1688CC4 Offset: 0x1688CC4 VA: 0x1688CC4
		public void ReleaseDecoration()
		{
			for(int i = 0; i < m_sceneIconDecoration.Length; i++)
			{
				m_sceneIconDecoration[i].Release();
			}
			m_decrationMap.Clear();
		}

		//// RVA: 0x1688ACC Offset: 0x1688ACC VA: 0x1688ACC
		private void SetupList(int count, int focusIndex)
		{
			m_scrollList.SetItemCount(count);
			m_scrollList.OnUpdateItem.RemoveAllListeners();
			m_scrollList.OnUpdateItem.AddListener(OnUpdateListItem);
			m_scrollList.ResetScrollVelocity();
			if(focusIndex > -1)
			{
				m_scrollList.SetPosition(focusIndex, 0, 0, false);
			}
			m_scrollList.VisibleRegionUpdate();
		}

		//// RVA: 0x1688DBC Offset: 0x1688DBC VA: 0x1688DBC
		private void OnSelectListItem(int value, SwapScrollListContent content)
		{
			if(value != 0)
			{
				OnShowListSceneStatus(content.Index);
			}
			else
			{
				OnSelectListScene(content.Index);
			}
		}

		//// RVA: 0x16891F8 Offset: 0x16891F8 VA: 0x16891F8
		protected void OnUpdateListItem(int index, SwapScrollListContent content)
		{
			SceneIconScrollContent c = content as SceneIconScrollContent;
			if(c != null)
			{
				c.ClickButton.RemoveAllListeners();
				c.ClickButton.AddListener(OnSelectListItem);
				m_decrationMap[content].Change(m_setting.sceneList[m_sceneIndexList[index]], m_dispType);
				c.UpdateContent(m_setting.sceneList[m_sceneIndexList[index]], SceneSelectList.GetSceneIconBitFlag(m_setting.playerData, m_setting.sceneList[m_sceneIndexList[index]], false), false, SceneIconScrollContent.SkillIconType.None, TransitionList.Type.UNDEFINED, true);
			}
		}

		//// RVA: 0x1688E0C Offset: 0x1688E0C VA: 0x1688E0C
		private void OnSelectListScene(int index)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			m_setting.sceneList[m_setting.sceneIndexList[index]].LEHDLBJJBNC_SetNotNew();
			GCIJNCFDNON_SceneInfo sceneData = m_setting.sceneList[m_setting.sceneIndexList[index]];
			m_setting.control.Close(() =>
			{
				//0x1689FA0
				MenuScene.Instance.Call(TransitionList.Type.SCENE_GROWTH, new SceneGrowthSceneArgs(sceneData, m_setting.isBeginner), true);
			}, null);
		}

		//// RVA: 0x1689008 Offset: 0x1689008 VA: 0x1689008
		private void OnShowListSceneStatus(int index)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			MenuScene.Instance.ShowSceneStatusPopupWindow(m_setting.sceneList[m_sceneIndexList[index]], m_setting.playerData, false, TransitionList.Type.UNDEFINED, () =>
			{
				//0x1689B24
				ChangeContents(selectIndex);
				ChangeSort(m_order);
				SetupList(m_sceneIndexList.Count, 0);
			}, false, false, SceneStatusParam.PageSave.Player, false);
		}

		//// RVA: 0x168891C Offset: 0x168891C VA: 0x168891C
		private void ChangeSort(uint order)
		{
			m_order = order;
			m_sceneIndexList.Sort(Sort);
			TexUVData data = m_order == 0 ? m_uvMan.GetUVData("cmn_btn_orde_fnt_01") : m_uvMan.GetUVData("cmn_btn_orde_fnt_02");
			m_imgSortUpDown.uvRect = LayoutUGUIUtility.MakeUnityUVRect(data);
		}

		//// RVA: 0x1689504 Offset: 0x1689504 VA: 0x1689504
		private int Sort(int left, int right)
		{
			if (left < 0)
				return -1;
			if (right < 0)
				return 1;
			GCIJNCFDNON_SceneInfo s1 = m_setting.playerData.OPIBAPEGCLA_Scenes[left];
			GCIJNCFDNON_SceneInfo s2 = m_setting.playerData.OPIBAPEGCLA_Scenes[right];
			int res = 0;
			if(selectIndex == 1)
			{
				res = s1.MKHFCGPJPFI_LimitOverCount - s2.MKHFCGPJPFI_LimitOverCount;
			}
			else if(selectIndex == 0)
			{
				res = s1.MNODFKEOPGK() - s2.MNODFKEOPGK();
			}
			if (res == 0)
			{
				res = s1.JKGFBFPIMGA_Rarity - s2.JKGFBFPIMGA_Rarity;
			}
			if(res == 0)
			{
				res = s1.EKLIPGELKCL_SceneRarity - s2.EKLIPGELKCL_SceneRarity;
			}
			if(res == 0)
			{
				res = s1.BCCHOBPJJKE_SceneId - s2.BCCHOBPJJKE_SceneId;
			}
			if (m_order != 0)
				res = -res;
			return res;
		}

		// RVA: 0x1689720 Offset: 0x1689720 VA: 0x1689720 Slot: 7
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1689728 Offset: 0x1689728 VA: 0x1689728 Slot: 8
		public void Show()
		{
			ChangeContents(selectIndex);
			ChangeSort(m_order);
			SetupList(m_sceneIndexList.Count, 0);
		}

		// RVA: 0x16897C8 Offset: 0x16897C8 VA: 0x16897C8 Slot: 9
		public void Hide()
		{
			return;
		}

		// RVA: 0x16897CC Offset: 0x16897CC VA: 0x16897CC Slot: 10
		public bool IsReady()
		{
			return true;
		}

		// RVA: 0x16897D4 Offset: 0x16897D4 VA: 0x16897D4 Slot: 11
		public void CallOpenEnd()
		{
			return;
		}

		// RVA: 0x16897D8 Offset: 0x16897D8 VA: 0x16897D8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_uvMan = uvMan;
			m_btnSortUpDown.AddOnClickCallback(() =>
			{
				//0x1689BC4
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				ChangeContents(selectIndex);
				ChangeSort((uint)(m_order == 0 ? 1 : 0));
				SetupList(m_sceneIndexList.Count, 0);
			});
			Loaded();
			return true;
		}
	}
}
