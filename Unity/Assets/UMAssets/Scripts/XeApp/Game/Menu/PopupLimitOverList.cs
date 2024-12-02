using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class PopupLimitOverList
	{
		public enum TabType
		{
			Releasable = 0,
			Released = 1,
			Num = 2,
		}

		private PopupTabSetting m_tabSetting; // 0x8
		private PopupTabContents m_tabContents; // 0xC
		private GameObject m_tabEscapeContents; // 0x10
		private PopupLimitOverListSetting m_limitOverListSetting; // 0x14
		private PopupLimitOverListContent m_layoutLimitOverList; // 0x18
		private static PopupTabButton.ButtonLabel[] s_tabButtons = new PopupTabButton.ButtonLabel[2]
			{
				PopupTabButton.ButtonLabel.Releasable,
				PopupTabButton.ButtonLabel.Released
			}; // 0x0
		private static string[] s_tabTitles = new string[2] {
			"popup_limit_over_list_title", "popup_limit_over_list_title"
		}; // 0x4

		public static string BundleName { get { return "ly/014.xab"; } } //0x17AF7CC
		public static string AssetName { get { return "root_pop_sel_card_reaf_layout_root"; } } //0x17AF828

		//// RVA: 0x17AF884 Offset: 0x17AF884 VA: 0x17AF884
		public static void Show(DFKGGBMFFGB_PlayerInfo playerData, uint order, List<GCIJNCFDNON_SceneInfo> sceneList, List<int> sceneIndexList, bool isBeginner, int tabIndex = 0, Action endCallBack = null)
		{
			PopupLimitOverList p = new PopupLimitOverList();
			MenuScene.Instance.StartCoroutineWatched(p.Co_Show(playerData, order, sceneList, sceneIndexList, isBeginner, tabIndex, endCallBack));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7052FC Offset: 0x7052FC VA: 0x7052FC
		//// RVA: 0x17AF99C Offset: 0x17AF99C VA: 0x17AF99C
		private IEnumerator Co_Show(DFKGGBMFFGB_PlayerInfo playerData, uint order, List<GCIJNCFDNON_SceneInfo> sceneList, List<int> sceneIndexList, bool isBeginner, int tabIndex = 0, Action endCallBack = null)
		{
			//0x1687164
			MenuScene.Instance.InputDisable();
			yield return Co.R(SetupContent(playerData, order, playerData.OPIBAPEGCLA_Scenes, sceneIndexList, isBeginner));
			MenuScene.Instance.InputEnable();
			m_tabContents.SelectIndex = (int)s_tabButtons[tabIndex];
			m_layoutLimitOverList.selectIndex = tabIndex;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_tabSetting.m_parent = m_tabEscapeContents.transform;
			m_tabSetting.Tabs = s_tabButtons;
			m_tabSetting.TitleText = bk.GetMessageByLabel(s_tabTitles[tabIndex]);
			m_tabSetting.WindowSize = SizeType.Large;
			m_tabSetting.DefaultTab = s_tabButtons[tabIndex];
			m_tabSetting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			m_layoutLimitOverList.InitializeDecoration();
			m_limitOverListSetting.control = PopupWindowManager.Show(m_tabSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x17AFDBC
				if (endCallBack != null)
					endCallBack();
			}, (IPopupContent content, PopupTabButton.ButtonLabel label) =>
			{
				//0x17AFDD0
				int idx = Array.FindIndex(s_tabButtons, (PopupTabButton.ButtonLabel x) =>
				{
					//0x1686AF0
					return label == x;
				});
				m_layoutLimitOverList.selectIndex = idx;
				m_tabContents.ChangeContents((int)label);
			}, null, null, true, true, false, null, () =>
			{
				//0x17AFF70
				m_layoutLimitOverList.ReleaseDecoration();
				UnityEngine.Object.DestroyImmediate(m_tabContents.gameObject);
				m_tabContents = null;
			});
		}

		//[IteratorStateMachineAttribute] // RVA: 0x705374 Offset: 0x705374 VA: 0x705374
		//// RVA: 0x17AFAC0 Offset: 0x17AFAC0 VA: 0x17AFAC0
		private IEnumerator SetupContent(DFKGGBMFFGB_PlayerInfo playerData, uint order, List<GCIJNCFDNON_SceneInfo> sceneList, List<int> sceneIndexList, bool isBeginner)
		{
			XeSys.FontInfo font; // 0x2C
			AssetBundleLoadLayoutOperationBase operation; // 0x30

			//0x1687D0C
			yield return AssetBundleManager.LoadUnionAssetBundle(BundleName);
			font = GameManager.Instance.GetSystemFont();
			m_limitOverListSetting = new PopupLimitOverListSetting();
			bool done = false;
			m_tabSetting = PopupWindowManager.CreateTabContents((PopupTabContents tabContents) =>
			{
				//0x1686B0C
				m_tabContents = tabContents;
				m_tabEscapeContents = new GameObject("escape");
				m_tabEscapeContents.SetActive(false);
				m_tabEscapeContents.transform.SetParent(m_tabContents.transform);
				for(int i = 0; i < 2; i++)
				{
					m_tabContents.AddContents(new PopupTabContents.ContentsData((int)s_tabButtons[i], m_limitOverListSetting, s_tabTitles[i]));
				}
				done = true;
			});
			while (!done)
				yield return null;
			operation = AssetBundleManager.LoadLayoutAsync(BundleName, AssetName);
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
			{
				//0x1686E0C
				m_layoutLimitOverList = instance.GetComponent<PopupLimitOverListContent>();
				m_layoutLimitOverList.gameObject.transform.SetParent(m_tabEscapeContents.transform, false);
				m_limitOverListSetting.m_parent = m_tabEscapeContents.transform;
				m_limitOverListSetting.order = order;
				m_limitOverListSetting.sceneList = sceneList;
				m_limitOverListSetting.sceneIndexList = sceneIndexList;
				m_limitOverListSetting.playerData = playerData;
				m_limitOverListSetting.isBeginner = isBeginner;
				m_limitOverListSetting.SetContent(m_layoutLimitOverList.gameObject);

			}));
			AssetBundleManager.UnloadAssetBundle(BundleName, false);
			AssetBundleManager.UnloadAssetBundle(BundleName, false);
			yield return Co.R(m_layoutLimitOverList.LoadContents());
		}
	}
}
