using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class ConfigMenu : MonoBehaviour, IDisposable
	{
		public enum eType
		{
			Menu = 0,
			Rhythm = 1,
			Simulation = 2,
		}
		private bool m_loaded; // 0xC
		private PopupTabSetting m_tabSetting; // 0x10
		private PopupTabContents m_tabContents; // 0x14
		private PopupConfigScrollListSetting m_settingMenu; // 0x18
		private PopupConfigScrollListSetting m_settingRhythmView; // 0x1C
		private PopupConfigScrollListSetting m_settingRhythmSystem; // 0x20
		private PopupConfigScrollListSetting m_settingRhythmSimulation; // 0x24
		private PopupConfigScrollListSetting m_settingOther; // 0x28
		private GameObject m_loadingObject; // 0x2C
		private Dictionary<string, int> m_bundleCounter = new Dictionary<string, int>(8); // 0x30

		public bool IsOpen { get; private set; } // 0x34
		//public bool IsReady { get; } 0x1B5E13C
		public bool IsLoadBundle { get; private set; } // 0x35

		//// RVA: 0x1B5D9E0 Offset: 0x1B5D9E0 VA: 0x1B5D9E0
		public static ConfigMenu Create(Transform parent)
		{
			GameObject go = new GameObject("ConfigMenu");
			go.transform.SetParent(parent, false);
			ConfigMenu c = go.AddComponent<ConfigMenu>();
			if(ConfigManager.Instance == null)
			{
				ConfigManager.Create();
				ConfigManager.Instance.Initialize();
			}
			c.CreateLoadingObject();
			c.StartCoroutineWatched(c.LoadUnionAssetBundle());
			return c;
		}

		//// RVA: 0x1B5DB78 Offset: 0x1B5DB78 VA: 0x1B5DB78
		public void CreateLoadingObject()
		{
			if(m_loadingObject == null)
			{
				GameObject c = GameObject.Find("Canvas-Popup/Root");
				if(c != null)
				{
					m_loadingObject = new GameObject("LoadingBackObject");
					m_loadingObject.layer = 5;
					m_loadingObject.transform.SetParent(c.transform, false);
					m_loadingObject.transform.SetAsFirstSibling();
					Image i = m_loadingObject.AddComponent<Image>();
					i.color = new Color(0, 0, 0, 0.501961f);
					i.raycastTarget = true;
					i.rectTransform.anchorMin = new Vector2(0, 0);
					i.rectTransform.anchorMax = new Vector2(1, 1);
					i.rectTransform.sizeDelta = new Vector2(0, 0);
					i.rectTransform.pivot = new Vector2(0.5f, 0.5f);
					LoadingObjectEnable(false);
				}
			}
		}

		//// RVA: 0x1B5E04C Offset: 0x1B5E04C VA: 0x1B5E04C
		private void DestroyLoadingObject()
		{
			if (m_loadingObject == null)
				return;
			Destroy(m_loadingObject);
			m_loadingObject = null;
		}

		//// RVA: 0x1B5DF90 Offset: 0x1B5DF90 VA: 0x1B5DF90
		private void LoadingObjectEnable(bool enable)
		{
			if (m_loadingObject == null)
				return;
			m_loadingObject.SetActive(enable);
		}

		//// RVA: 0x1B5E124 Offset: 0x1B5E124 VA: 0x1B5E124
		public void Awake()
		{
			return;
		}

		//// RVA: 0x1B5E128 Offset: 0x1B5E128 VA: 0x1B5E128
		public void Start()
		{
			return;
		}

		//// RVA: 0x1B5DF6C Offset: 0x1B5DF6C VA: 0x1B5DF6C
		//public void LoadAssetBundle() { }

		//[IteratorStateMachineAttribute] // RVA: 0x700B8C Offset: 0x700B8C VA: 0x700B8C
		//// RVA: 0x1B5E154 Offset: 0x1B5E154 VA: 0x1B5E154
		private IEnumerator LoadUnionAssetBundle()
		{
			//0x1B63224
			IsLoadBundle = false;
			yield return Co.R(AssetBundleManager.LoadUnionAssetBundle("ly/072.xab"));
			IsLoadBundle = true;
		}

		//// RVA: 0x1B5E200 Offset: 0x1B5E200 VA: 0x1B5E200
		public void UnloadAssetBundle()
		{
			foreach(var k in m_bundleCounter)
			{
				for(int i = 0; i < k.Value; i++)
				{
					AssetBundleManager.UnloadAssetBundle(k.Key, false);
				}
			}
			AssetBundleManager.UnloadAssetBundle("ly/072.xab", false);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x700C04 Offset: 0x700C04 VA: 0x700C04
		//// RVA: 0x1B5E4A4 Offset: 0x1B5E4A4 VA: 0x1B5E4A4
		private IEnumerator LoadLayoutAssetBundle(PopupSetting setting, Action<GameObject> callback)
		{
			//0x1B6166C
			if (setting != null)
			{
				yield return Co.R(LoadLayoutAssetBundle(setting.BundleName, setting.AssetName, callback));
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x700C7C Offset: 0x700C7C VA: 0x700C7C
		//// RVA: 0x1B5E584 Offset: 0x1B5E584 VA: 0x1B5E584
		private IEnumerator LoadLayoutAssetBundle(string bundleName, string assetName, Action<GameObject> callback)
		{
			Font font; // 0x24
			AssetBundleLoadLayoutOperationBase operation; // 0x28

			//0x1B617D8
			while (!IsLoadBundle)
				yield return null;
			font = GameManager.Instance.GetSystemFont();
			operation = AssetBundleManager.LoadLayoutAsync(bundleName, assetName);
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
			{
				//0x1B5FD9C
				callback(instance);
			}));
			if(m_bundleCounter.ContainsKey(bundleName))
			{
				m_bundleCounter[bundleName]++;
			}
			else
			{
				m_bundleCounter.Add(bundleName, 1);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x700CF4 Offset: 0x700CF4 VA: 0x700CF4
		//// RVA: 0x1B5E67C Offset: 0x1B5E67C VA: 0x1B5E67C
		private IEnumerator LoadLayout(eType etype)
		{
			//0x1B61214
			if(MenuScene.Instance != null)
			{
				MenuScene.Instance.RaycastDisable();
			}
			LoadingObjectEnable(true);
			GameManager.Instance.NowLoading.Show();
			this.StartCoroutineWatched(LoadLayoutInner(etype));
			while (!m_loaded)
				yield return null;
			GameManager.Instance.NowLoading.Hide();
			LoadingObjectEnable(false);
			if (MenuScene.Instance != null)
			{
				MenuScene.Instance.RaycastEnable();
			}
			DestroyLoadingObject();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x700D6C Offset: 0x700D6C VA: 0x700D6C
		//// RVA: 0x1B5E744 Offset: 0x1B5E744 VA: 0x1B5E744
		private IEnumerator LoadLayoutInner(eType etype)
		{
			LayoutPopupConfigMenu menu; // 0x18
			LayoutPopupConfigRhythm rhythmView; // 0x1C
			LayoutPopupConfigRhythm rhythmSystem; // 0x20
			LayoutPopupConfigSimulation rhythmSimulation; // 0x24
			LayoutPopupConfigOther other; // 0x28

			//0x1B61B9C
			bool hasLoad = false;
			if (etype == eType.Simulation)
			{
				if (m_settingRhythmSimulation == null)
				{
					m_settingRhythmSimulation = new PopupConfigScrollListSetting();
					m_settingRhythmSimulation.ConfigType = eType.Simulation;
					m_settingRhythmSimulation.LayoutType = LayoutPopupConfigScrollList.LayoutType.Simulation;
					m_settingRhythmSimulation.m_parent = transform;
					hasLoad = true;
				}
			}
			else if(etype == eType.Rhythm)
			{
				if (m_settingRhythmView == null)
				{
					m_settingRhythmView = new PopupConfigScrollListSetting();
					m_settingRhythmView.ConfigType = eType.Rhythm;
					m_settingRhythmView.LayoutType = LayoutPopupConfigScrollList.LayoutType.Rhythm;
					m_settingRhythmView.m_parent = transform;
					hasLoad = true;
				}
				if(m_settingRhythmSystem == null)
				{
					m_settingRhythmSystem = new PopupConfigScrollListSetting();
					m_settingRhythmSystem.ConfigType = eType.Rhythm;
					m_settingRhythmSystem.LayoutType = LayoutPopupConfigScrollList.LayoutType.Rhythm;
					m_settingRhythmSystem.m_parent = transform;
					hasLoad = true;
				}
			}
			else if(etype == eType.Menu)
			{
				if (m_settingMenu == null)
				{
					m_settingMenu = new PopupConfigScrollListSetting();
					m_settingMenu.ConfigType = eType.Menu;
					m_settingMenu.LayoutType = LayoutPopupConfigScrollList.LayoutType.Menu;
					m_settingMenu.m_parent = transform;
					hasLoad = true;
				}
				if(m_settingRhythmView == null)
				{
					m_settingRhythmView = new PopupConfigScrollListSetting();
					m_settingRhythmView.ConfigType = eType.Menu;
					m_settingRhythmView.LayoutType = LayoutPopupConfigScrollList.LayoutType.Rhythm;
					m_settingRhythmView.m_parent = transform;
					hasLoad = true;
				}
				if (m_settingRhythmSystem == null)
				{
					m_settingRhythmSystem = new PopupConfigScrollListSetting();
					m_settingRhythmSystem.ConfigType = eType.Menu;
					m_settingRhythmSystem.LayoutType = LayoutPopupConfigScrollList.LayoutType.Rhythm;
					m_settingRhythmSystem.m_parent = transform;
					hasLoad = true;
				}
				if (m_settingRhythmSimulation == null)
				{
					m_settingRhythmSimulation = new PopupConfigScrollListSetting();
					m_settingRhythmSimulation.ConfigType = eType.Menu;
					m_settingRhythmSimulation.LayoutType = LayoutPopupConfigScrollList.LayoutType.Simulation;
					m_settingRhythmSimulation.m_parent = transform;
					hasLoad = true;
				}
				if (m_settingOther == null)
				{
					m_settingOther = new PopupConfigScrollListSetting();
					m_settingOther.ConfigType = eType.Menu;
					m_settingOther.LayoutType = LayoutPopupConfigScrollList.LayoutType.Other;
					m_settingOther.m_parent = transform;
					hasLoad = true;
				}
			}
			if (!hasLoad)
				yield break;

			m_loaded = false;
			yield return Co.R(LoadLayoutAssetBundle(m_settingRhythmView, (GameObject instance) =>
			{
				//0x1B5F374
				m_settingRhythmView.m_parent = transform;
				m_settingRhythmView.SetContent(instance);
				m_settingRhythmView.Content.transform.SetParent(transform, false);
			}));
			yield return Co.R(LoadLayoutAssetBundle(m_settingRhythmSystem, (GameObject instance) =>
			{
				//0x1B5F450
				m_settingRhythmSystem.m_parent = transform;
				m_settingRhythmSystem.SetContent(instance);
				m_settingRhythmSystem.Content.transform.SetParent(transform, false);
			}));
			yield return Co.R(LoadLayoutAssetBundle(m_settingRhythmSimulation, (GameObject instance) =>
			{
				//0x1B5F52C
				m_settingRhythmSimulation.m_parent = transform;
				m_settingRhythmSimulation.SetContent(instance);
				m_settingRhythmSimulation.Content.transform.SetParent(transform, false);
			}));
			yield return Co.R(LoadLayoutAssetBundle(m_settingMenu, (GameObject instance) =>
			{
				//0x1B5F608
				m_settingMenu.m_parent = transform;
				m_settingMenu.SetContent(instance);
				m_settingMenu.Content.transform.SetParent(transform, false);
			}));
			yield return Co.R(LoadLayoutAssetBundle(m_settingOther, (GameObject instance) =>
			{
				//0x1B5F6E4
				m_settingOther.m_parent = transform;
				m_settingOther.SetContent(instance);
				m_settingOther.Content.transform.SetParent(transform, false);
			}));
			if(etype == eType.Simulation)
			{
				yield return Co.R(LoadLayoutAssetBundle("ly/072.xab", "UI_ConfigRhythmSimulation", (GameObject instance) =>
				{
					//0x1B5FB94
					instance.transform.SetParent(transform, false);
					m_settingRhythmSimulation.ListContents = instance;
				}));
				rhythmSimulation = m_settingRhythmSimulation.ListContents.GetComponent<LayoutPopupConfigSimulation>();
				while (!rhythmSimulation.IsLoaded())
					yield return null;
			}
			if(etype == eType.Rhythm)
			{
				yield return Co.R(LoadLayoutAssetBundle("ly/072.xab", "UI_ConfigRhythmView", (GameObject instance) =>
				{
					//0x1B5FA7C
					instance.transform.SetParent(transform, false);
					m_settingRhythmView.ListContents = instance;
				}));
				rhythmSystem = m_settingRhythmView.ListContents.GetComponent<LayoutPopupConfigRhythm>();
				while (!rhythmSystem.IsLoaded())
					yield return null;
				yield return Co.R(LoadLayoutAssetBundle("ly/072.xab", "UI_ConfigRhythmSystem", (GameObject instance) =>
				{
					//0x1B5FB08
					instance.transform.SetParent(transform, false);
					m_settingRhythmSystem.ListContents = instance;
				}));
				rhythmView = m_settingRhythmSystem.ListContents.GetComponent<LayoutPopupConfigRhythm>();
				while (!rhythmView.IsLoaded())
					yield return null;
			}
			if (etype == eType.Menu)
			{
				yield return Co.R(LoadLayoutAssetBundle("ly/072.xab", "UI_ConfigMenu", (GameObject instance) =>
				{
					//0x1B5F7C0
					instance.transform.SetParent(transform, false);
					m_settingMenu.ListContents = instance;
				}));
				menu = m_settingMenu.ListContents.GetComponent<LayoutPopupConfigMenu>();
				while (!menu.IsLoaded())
					yield return null;
				yield return Co.R(LoadLayoutAssetBundle("ly/072.xab", "UI_ConfigRhythmView", (GameObject instance) =>
				{
					//0x1B5F84C
					instance.transform.SetParent(transform, false);
					m_settingRhythmView.ListContents = instance;
				}));
				rhythmView = m_settingRhythmView.ListContents.GetComponent<LayoutPopupConfigRhythm>();
				while (!rhythmView.IsLoaded())
					yield return null;
				yield return Co.R(LoadLayoutAssetBundle("ly/072.xab", "UI_ConfigRhythmSystem", (GameObject instance) =>
				{
					//0x1B5F8D8
					instance.transform.SetParent(transform, false);
					m_settingRhythmSystem.ListContents = instance;
				}));
				rhythmSystem = m_settingRhythmSystem.ListContents.GetComponent<LayoutPopupConfigRhythm>();
				while (!rhythmSystem.IsLoaded())
					yield return null;
				yield return Co.R(LoadLayoutAssetBundle("ly/072.xab", "UI_ConfigRhythmSimulation", (GameObject instance) =>
				{
					//0x1B5F964
					instance.transform.SetParent(transform, false);
					m_settingRhythmSimulation.ListContents = instance;
				}));
				rhythmSimulation = m_settingRhythmSimulation.ListContents.GetComponent<LayoutPopupConfigSimulation>();
				while (!rhythmSimulation.IsLoaded())
					yield return null;
				yield return Co.R(LoadLayoutAssetBundle("ly/072.xab", "UI_ConfigOther", (GameObject instance) =>
				{
					//0x1B5F9F0
					instance.transform.SetParent(transform, false);
					m_settingOther.ListContents = instance;
				}));
				other = m_settingOther.ListContents.GetComponent<LayoutPopupConfigOther>();
				while (!other.IsLoaded())
					yield return null;
			}
			//LAB_01b626ac
			yield return Co.R(LoadLayoutTab(etype));
			m_loaded = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x700DE4 Offset: 0x700DE4 VA: 0x700DE4
		//// RVA: 0x1B5E80C Offset: 0x1B5E80C VA: 0x1B5E80C
		private IEnumerator LoadLayoutTab(eType etype)
		{
			//0x1B62F9C
			if(etype != eType.Simulation)
			{
				bool isCreateTab = false;
				m_tabSetting = PopupWindowManager.CreateTabContents((PopupTabContents tabContents) =>
				{
					//0x1B5FE24
					m_tabContents = tabContents;
					if(m_tabContents != null)
					{
						if(etype == eType.Rhythm)
						{
							m_tabContents.AddContents(new PopupTabContents.ContentsData(20, m_settingRhythmView, "config_text_79"));
							m_tabContents.AddContents(new PopupTabContents.ContentsData(21, m_settingRhythmSystem, "config_text_80"));
						}
						else if(etype == eType.Menu)
						{
							m_tabContents.AddContents(new PopupTabContents.ContentsData(20, m_settingRhythmView, "config_text_79"));
							m_tabContents.AddContents(new PopupTabContents.ContentsData(21, m_settingRhythmSystem, "config_text_80"));
							m_tabContents.AddContents(new PopupTabContents.ContentsData(22, m_settingRhythmSimulation, "config_text_81"));
							m_tabContents.AddContents(new PopupTabContents.ContentsData(13, m_settingMenu, "config_text_28"));
							m_tabContents.AddContents(new PopupTabContents.ContentsData(12, m_settingOther, "config_text_29"));
						}
					}
					isCreateTab = true;
				});
				while (!isCreateTab)
					yield return null;
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x700E5C Offset: 0x700E5C VA: 0x700E5C
		//// RVA: 0x1B5E8D4 Offset: 0x1B5E8D4 VA: 0x1B5E8D4
		private IEnumerator SetupTabWindow(eType etype, PopupTabButton.ButtonLabel[] tabs, UnityAction showEndCb, UnityAction<PopupButton.ButtonLabel> finishCb)
		{
			//0x1B63610
			yield return Co.R(LoadLayout(etype));
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			string str = "";
			if (!ConfigManager.gotoTimingScene)
			{
				ConfigManager.selectTab = 20;
				str = bk.GetMessageByLabel("config_text_79");
			}
			else
			{
				str = bk.GetMessageByLabel("config_text_80");
			}
			m_tabContents.DefaultSelect = ConfigManager.selectTab;
			m_tabContents.SelectIndex = ConfigManager.selectTab;
			m_tabSetting.Tabs = tabs;
			m_tabSetting.m_parent = transform;
			m_tabSetting.TitleText = str;
			m_tabSetting.WindowSize = SizeType.Large;
			m_tabSetting.DefaultTab = (PopupTabButton.ButtonLabel)ConfigManager.selectTab;
			m_tabSetting.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			m_tabSetting.Content.transform.SetParent(transform.parent);
			bool popupWait = true;
			bool isOk = false;
			PopupButton.ButtonLabel butLabel = 0;
			PopupWindowManager.Show(m_tabSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1B602C4
				butLabel = label;
				isOk = label == PopupButton.ButtonLabel.Ok;
				popupWait = false;
			}, (IPopupContent content, PopupTabButton.ButtonLabel label) =>
			{
				//0x1B5FC9C
				(content as PopupTabContents).ChangeContents((int)label);
			}, () =>
			{
				//0x1B602F4
				PopupConfigScrollListContent c = null;
				switch (ConfigManager.selectTab)
				{
					case 12:
						c = m_settingOther.Content.GetComponent<PopupConfigScrollListContent>();
						break;
					case 13:
						c = m_settingMenu.Content.GetComponent<PopupConfigScrollListContent>();
						break;
					default:
						break;
					case 20:
						c = m_settingRhythmView.Content.GetComponent<PopupConfigScrollListContent>();
						break;
					case 21:
						c = m_settingRhythmSystem.Content.GetComponent<PopupConfigScrollListContent>();
						break;
					case 22:
						c = m_settingRhythmSimulation.Content.GetComponent<PopupConfigScrollListContent>();
						break;
				}
				if(c != null)
				{
					c.SetScrollPosition();
				}
			}, () =>
			{
				//0x1B60520
				if (showEndCb != null)
					showEndCb();
			}, true, true, false);
			while(popupWait)
				yield return null;
			if(!isOk)
			{
				ConfigManager.Instance.ApplyValue(false, null);
				if (finishCb != null)
					finishCb(butLabel);
			}
			else
			{
				bool isReShow = false;
				yield return Co.R(Co_ConfigSave((bool reShow) =>
				{
					//0x1B6053C
					isReShow = reShow;
				}));
				if (!isReShow)
				{
					ConfigManager.Instance.ApplyValue(false, null);
				}
				else
				{
					bool done = false;
					ConfigManager.Instance.ApplyValue(true, () =>
					{
						//0x1B6054C
						done = true;
					});
					while (!done)
						yield return null;
					BIFNGFAIEIL.HHCJCDFCLOB.DNKCCHCEPBH(true);
					if (finishCb != null)
						finishCb(butLabel);
				}
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x700ED4 Offset: 0x700ED4 VA: 0x700ED4
		//// RVA: 0x1B5E9EC Offset: 0x1B5E9EC VA: 0x1B5E9EC
		//private IEnumerator ReShowTabWindow(ConfigMenu.eType etype, PopupTabButton.ButtonLabel[] tabs, UnityAction showEndCb, UnityAction<PopupButton.ButtonLabel> finishCb) { }

		//[IteratorStateMachineAttribute] // RVA: 0x700F4C Offset: 0x700F4C VA: 0x700F4C
		//// RVA: 0x1B5EB00 Offset: 0x1B5EB00 VA: 0x1B5EB00
		private IEnumerator SetupWindowSimulation(UnityAction showEndCb, UnityAction<PopupButton.ButtonLabel> finishCb)
		{
			eType etype;

			//0x1B642B4
			etype = eType.Simulation;
			yield return Co.R(LoadLayout(eType.Simulation));
			PopupConfigScrollListSetting setting = m_settingRhythmSimulation;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			setting.TitleText = bk.GetMessageByLabel("config_text_81");
			setting.WindowSize = SizeType.Large;
			setting.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive },
			};
			bool popupWait = true;
			bool isOk = false;
			PopupButton.ButtonLabel butLabel = 0;
			PopupWindowManager.Show(setting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1B60560
				butLabel = label;
				if (label == PopupButton.ButtonLabel.Cancel)
					isOk = false;
				else if (label == PopupButton.ButtonLabel.Ok)
					isOk = true;
				popupWait = false;
			}, null, null, () =>
			{
				//0x1B60590
				if (showEndCb != null)
					showEndCb();
			});
			while (popupWait)
				yield return null;
			if(!isOk)
			{
				ConfigManager.Instance.ApplyValue(false);
				//LAB_01b649b4
				if (finishCb != null)
					finishCb(butLabel);
				PopupConfigScrollListContent p = setting.Content.GetComponent<PopupConfigScrollListContent>();
				if(p != null)
				{
					p.SetScrollPosition();
				}
			}
			else
			{
				bool isReShow = false;
				yield return Co.R(Co_ConfigSave((bool reShow) =>
				{
					//0x1B606B0
					isReShow = reShow;
				}));
				if(isReShow)
				{
					ConfigManager.Instance.ApplyValue(false);
					yield break;
				}
				else
				{
					bool done = false;
					ConfigManager.Instance.ApplyValue(true, () =>
					{
						//0x1B606C0
						done = true;
					});
					while (!done)
						yield return null;
					if (finishCb != null)
						finishCb(butLabel);
				}
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x700FC4 Offset: 0x700FC4 VA: 0x700FC4
		//// RVA: 0x1B5EBE0 Offset: 0x1B5EBE0 VA: 0x1B5EBE0
		//private IEnumerator ReShowWindowSimulation(UnityAction showEndCb, UnityAction<PopupButton.ButtonLabel> finishCb) { }

		//[IteratorStateMachineAttribute] // RVA: 0x70103C Offset: 0x70103C VA: 0x70103C
		//// RVA: 0x1B5ECC0 Offset: 0x1B5ECC0 VA: 0x1B5ECC0
		private IEnumerator Co_ConfigSave(Action<bool> repopCallback)
		{
			//0x1B606F4
			if(ConfigManager.Instance.IsChangeVideo())
			{
				bool isWait = true;
				bool isChange = false;
				ConfigUtility.PopupShowVideoQuality((bool change) =>
				{
					//0x1B606D4
					isWait = false;
					isChange = change;
				});
				while (isWait)
					yield return null;
				if(!isChange)
				{
					ConfigManager.Instance.UndoVideo();
					if (repopCallback != null)
						repopCallback(true);
					yield break;
				}
				KEHOJEJMGLJ.HHCJCDFCLOB.KLIJFOBEKBE.IKOFAKDLDJE_CleanupVideo();
				isWait = true;
				ConfigUtility.PopupShowVideoDelete(() =>
				{
					//0x1B606E4
					isWait = false;
				});
				while (isWait)
					yield return null;
			}
			//LAB_01b60998
			if (ConfigManager.Instance.IsChangeNotification())
			{
				ConfigManager.Instance.ApplyNotification();
			}
			if(ConfigManager.Instance.IsChangeDecoNotification())
			{
				ConfigManager.Instance.ApplyDecoNotification();
			}
		}

		//// RVA: 0x1B5ED6C Offset: 0x1B5ED6C VA: 0x1B5ED6C
		//public void ShowPopupConfig(UnityAction showEndCb, UnityAction<PopupButton.ButtonLabel> finishCb) { }

		//// RVA: 0x1B5EE28 Offset: 0x1B5EE28 VA: 0x1B5EE28
		public void ShowPopupRhythm(UnityAction showEndCb, UnityAction<PopupButton.ButtonLabel> finishCb)
		{
			if(Database.Instance.gameSetup.musicInfo.IsMvMode)
			{
				this.StartCoroutineWatched(SetupWindowSimulation(showEndCb, finishCb));
			}
			else
			{
				this.StartCoroutineWatched(SetupTabWindow(eType.Rhythm, new PopupTabButton.ButtonLabel[2] { PopupTabButton.ButtonLabel.LiveView, PopupTabButton.ButtonLabel.LiveSystem }, showEndCb, finishCb));
			}
		}

		//// RVA: 0x1B5EFA4 Offset: 0x1B5EFA4 VA: 0x1B5EFA4 Slot: 4
		public void Dispose()
		{
			if(m_settingMenu != null)
			{
				Destroy(m_settingMenu.Content.gameObject);
			}
			if(m_settingOther != null)
			{
				Destroy(m_settingOther.Content.gameObject);
			}
			if (m_settingRhythmView != null)
			{
				Destroy(m_settingRhythmView.Content.gameObject);
			}
			if (m_settingRhythmSystem != null)
			{
				Destroy(m_settingRhythmSystem.Content.gameObject);
			}
			if (m_settingRhythmSimulation != null)
			{
				Destroy(m_settingRhythmSimulation.Content.gameObject);
			}
			m_settingMenu = null;
			m_settingRhythmView = null;
			m_settingRhythmSystem = null;
			m_settingRhythmSimulation = null;
			m_settingOther = null;
			if (ConfigManager.Instance != null)
				ConfigManager.Release();
			DestroyLoadingObject();
			UnloadAssetBundle();
			Destroy(gameObject);
		}
	}
}
