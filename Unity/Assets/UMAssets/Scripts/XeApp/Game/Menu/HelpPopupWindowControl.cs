using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class HelpPopupWindowControl
	{
		private PopupTabContents m_tabContents; // 0x8
		private PopupTabSetting m_tabSetting; // 0xC
		private HelpSelectPopupSetting m_wiki_setting; // 0x10
		private HelpSelectPopupSetting m_help_setting; // 0x14
		private Transform m_parent; // 0x18

		// RVA: 0x953ED4 Offset: 0x953ED4 VA: 0x953ED4
		public void Initialize(Transform parent)
		{
			m_parent = parent;
			m_wiki_setting = new HelpSelectPopupSetting();
			m_help_setting = new HelpSelectPopupSetting();
			m_wiki_setting.SetParent(m_parent);
			m_help_setting.SetParent(m_parent);
		}

		// // RVA: 0x953FBC Offset: 0x953FBC VA: 0x953FBC
		public void Show(MonoBehaviour mb, int id, UnityAction onEnd)
		{
			mb.StartCoroutineWatched(ShowPopupCoroutin(mb, id, onEnd));
		}

		// // RVA: 0x9540D4 Offset: 0x9540D4 VA: 0x9540D4
		public void Release()
		{
			UnityEngine.Object.Destroy(m_wiki_setting.Content);
			UnityEngine.Object.Destroy(m_help_setting.Content);
			m_wiki_setting.SetParent(null);
			m_help_setting.SetParent(null);
			m_tabSetting = null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E1DBC Offset: 0x6E1DBC VA: 0x6E1DBC
		// // RVA: 0x954204 Offset: 0x954204 VA: 0x954204
		private IEnumerator LoadPopupWindow(HelpSelectPopupSetting setting)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0x954530
			operation = AssetBundleManager.LoadLayoutAsync(setting.BundleName, setting.AssetName);
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0x954474
				setting.SetContent(instance);
				setting.SetParent(m_parent);
			}));
			AssetBundleManager.UnloadAssetBundle(setting.BundleName, false);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E1E34 Offset: 0x6E1E34 VA: 0x6E1E34
		// // RVA: 0x953FFC Offset: 0x953FFC VA: 0x953FFC
		private IEnumerator ShowPopupCoroutin(MonoBehaviour mb, int id, UnityAction onEnd)
		{
			PopupTabButton.ButtonLabel[] labelList;

			//0x9548DC
			labelList = new PopupTabButton.ButtonLabel[2]
			{
				PopupTabButton.ButtonLabel.Help,
				PopupTabButton.ButtonLabel.Wiki
			};
			if(m_tabSetting == null)
			{
				m_tabSetting = PopupWindowManager.CreateTabContents((PopupTabContents tabContents) =>
				{
					//0x9544EC
					m_tabContents = tabContents;
				});
				m_tabSetting.SetParent(m_parent);
				AssetBundleManager.LoadUnionAssetBundle("ly/091.xab");
				yield return mb.StartCoroutineWatched(LoadPopupWindow(m_wiki_setting));
				yield return mb.StartCoroutineWatched(LoadPopupWindow(m_help_setting));
				while (!m_tabSetting.ISLoaded())
					yield return null;
				while (!m_wiki_setting.ISLoaded())
					yield return null;
				while (!m_help_setting.ISLoaded())
					yield return null;
				m_wiki_setting.Content.GetComponent<HelpSelectWindow>().BtnLoad(mb);
				m_help_setting.Content.GetComponent<HelpSelectWindow>().BtnLoad(mb);
				while (!m_wiki_setting.Content.GetComponent<HelpSelectWindow>().IsBtnLoad())
					yield return null;
				while (!m_help_setting.Content.GetComponent<HelpSelectWindow>().IsBtnLoad())
					yield return null;
				AssetBundleManager.UnloadAssetBundle("ly/091.xab", false);
			}
			m_wiki_setting.uniqueId = id;
			m_wiki_setting.IsWiki = true;
			m_help_setting.uniqueId = id;
			m_help_setting.IsWiki = false;
			m_tabContents.ClearContents();
			VeiwOptionHelpCategoryData data = new VeiwOptionHelpCategoryData();
			data.Init(id);
			bool isWait = true;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(data.wikis.Count == 0)
			{
				m_wiki_setting.IsDefault = false;
				m_help_setting.IsDefault = true;
				m_help_setting.TitleText = bk.GetMessageByLabel("popup_help_select_title");
				m_help_setting.WindowSize = SizeType.Large;
				m_help_setting.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
				};
				PopupWindowManager.Show(m_help_setting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x954520
					isWait = false;
				}, (IPopupContent content, PopupTabButton.ButtonLabel blabel) =>
				{
					//0x954468
					return;
				}, null, null);
			}
			else
			{
				PopupTabContents.ContentsData d = new PopupTabContents.ContentsData(17, m_wiki_setting, "popup_help_select_title");
				PopupTabContents.ContentsData d2 = new PopupTabContents.ContentsData(18, m_help_setting, "popup_help_select_title");
				m_tabContents.AddContents(d2);
				m_tabContents.AddContents(d);
				m_wiki_setting.IsDefault = false;
				m_help_setting.IsDefault = true;
				m_tabContents.SelectIndex = (int)labelList[0];
				m_tabSetting.TitleText = bk.GetMessageByLabel("popup_help_select_title");
				m_tabSetting.WindowSize = SizeType.Large;
				m_tabSetting.DefaultTab = labelList[0];
				m_tabSetting.Tabs = labelList;
				m_tabSetting.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
				};
				PopupWindowManager.Show(m_tabSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x954514
					isWait = false;
				}, (IPopupContent content, PopupTabButton.ButtonLabel blabel) =>
				{
					//0x954370
					(content as PopupTabContents).ChangeContents((int)blabel);
				}, null, null);
			}
			while (isWait)
				yield return null;
			if (onEnd != null)
				onEnd();
		}
	}
}
