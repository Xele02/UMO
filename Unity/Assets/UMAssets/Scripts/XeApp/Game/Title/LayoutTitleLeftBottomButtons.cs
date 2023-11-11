using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;
using XeApp.Game.Menu;
using System.Collections;
using XeSys;

namespace XeApp.Game.Title
{
	public class LayoutTitleLeftBottomButtons : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_buttonGpgs; // 0x14
		private AbsoluteLayout m_buttonGpgsLayout; // 0x1C

		public Action ButtonCallbackGpgs { get; set; } // 0x18

		public Action OnUpdateBG { get; set; }

		// // RVA: 0xE39670 Offset: 0xE39670 VA: 0xE39670
		public void CallbackClear()
		{
			if(m_buttonGpgs != null)
				m_buttonGpgs.ClearOnClickCallback();
		}

		// // RVA: 0xE39724 Offset: 0xE39724 VA: 0xE39724
		public void SetCallback()
		{
			if(m_buttonGpgs != null)
			{
				m_buttonGpgs.AddOnClickCallback(() => {
					// 0xE399C4
					//TodoLogger.LogNotImplemented("LayoutTitleLeftBottomButton");
					/*PopupWindowManager.Show(PopupWindowManager.CrateTextContent("Check File?", SizeType.Small, "Recheck all file integrity ?", new ButtonInfo[2]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive },
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative }
					}) , (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
					{
						if(type == PopupButton.ButtonType.Positive)
							KEHOJEJMGLJ.FJDOHLADGFI = true;
						else
							KEHOJEJMGLJ.FJDOHLADGFI = false;
					}, null, null, null);*/
					this.StartCoroutineWatched(ShowUMOPopup());
				});
			}
		}

		UMOPopupConfigSetting umoSetting = null;
		UMOPopupEventSetting umoEventSetting = null;
		private IEnumerator ShowUMOPopup()
		{
			if(umoSetting == null)
			{
				umoSetting = new UMOPopupConfigSetting();
				umoSetting.m_parent = transform;
				bool isLoading = false;
				ResourcesManager.Instance.Load(umoSetting.PrefabPath, (FileResultObject fro) =>
				{
					//0x13883F0
					GameObject g = Instantiate(fro.unityObject) as GameObject;
					g.transform.SetParent(transform, false);
					umoSetting.SetContent(g);
					isLoading = true;
					return true;
				});
				while (!isLoading)
					yield return null;
			}
			
			if(umoEventSetting == null)
			{
				umoEventSetting = new UMOPopupEventSetting();
				umoEventSetting.m_parent = transform;
				bool isLoading = false;
				ResourcesManager.Instance.Load(umoEventSetting.PrefabPath, (FileResultObject fro) =>
				{
					//0x13883F0
					GameObject g = Instantiate(fro.unityObject) as GameObject;
					g.transform.SetParent(transform, false);
					umoEventSetting.SetContent(g);
					isLoading = true;
					return true;
				});
				while (!isLoading)
					yield return null;
			}

			PopupTabContents m_tabContents = null;
			PopupTabSetting s = PopupWindowManager.CreateTabContents((PopupTabContents tabContents) =>
			{
				//0x9544EC
				m_tabContents = tabContents;
				if(m_tabContents != null)
				{
					m_tabContents.AddContents(new PopupTabContents.ContentsData((int)PopupTabButton.ButtonLabel.Menu, umoSetting, ""));
					m_tabContents.AddContents(new PopupTabContents.ContentsData((int)PopupTabButton.ButtonLabel.EventInfomation, umoEventSetting, ""));
				}
			});
			while(m_tabContents == null)
				yield return null;
			while (!s.ISLoaded())
				yield return null;

			m_tabContents.DefaultSelect = (int)PopupTabButton.ButtonLabel.Menu;
			m_tabContents.SelectIndex = (int)PopupTabButton.ButtonLabel.Menu;
			s.Tabs = new PopupTabButton.ButtonLabel[2]
			{
				PopupTabButton.ButtonLabel.Menu,
				PopupTabButton.ButtonLabel.EventInfomation
			};
			s.m_parent = transform;
			s.DefaultTab = PopupTabButton.ButtonLabel.Menu;
			s.WindowSize = SizeType.Large;
			s.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive },
			};
			s.Content.transform.SetParent(transform.parent, false);
			PopupWindowManager.Show(s, (PopupWindowControl ctrl, PopupButton.ButtonType t, PopupButton.ButtonLabel l) =>
			{
				if(t == PopupButton.ButtonType.Positive)
				{
					umoSetting.Content.GetComponent<UMOPopupConfig>().Save();
					umoEventSetting.Content.GetComponent<UMOPopupEvent>().Save();
					OnUpdateBG();
				}
			}, (IPopupContent content, PopupTabButton.ButtonLabel label) =>
			{
				//0x1B5FC9C
				(content as PopupTabContents).ChangeContents((int)label);
			}, () =>
			{
				m_tabContents.ChangeContents((int)s.DefaultTab);
			},null);
		}

		// // RVA: 0xE39814 Offset: 0xE39814 VA: 0xE39814
		// public void Reset() { }

		// // RVA: 0xE3667C Offset: 0xE3667C VA: 0xE3667C
		public void Show()
		{
			if(m_buttonGpgsLayout == null)
				return;
			if(!AppEnv.IsCBT())
			{
				if(NDABOOOOENC.HHCJCDFCLOB.LHGFPPIEKPJ)
				{
					m_buttonGpgsLayout.StartChildrenAnimGoStop("go_in", "st_in");
					return;
				}
			}
			m_buttonGpgsLayout.StartChildrenAnimGoStop("st_non");
		}

		// // RVA: 0xE39818 Offset: 0xE39818 VA: 0xE39818
		// public void Hide() { }

		// // RVA: 0xE39898 Offset: 0xE39898 VA: 0xE39898 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_buttonGpgsLayout = layout.Root[0] as AbsoluteLayout;
			SetCallback();
			m_buttonGpgsLayout.StartChildrenAnimGoStop("st_non");
			Loaded();
			return true;
		}
	}
}
