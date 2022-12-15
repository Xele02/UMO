using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class PopupTabContents : UIBehaviour, IPopupContent
	{
		public class ChangeTabStatus
		{
			public int prevType; // 0x8
			public int currentType; // 0xC
			public Dictionary<int, ContentsData> contents; // 0x10
		}

		public class ContentsData
		{
			public int type; // 0x8
			public PopupSetting setting; // 0xC
			public string popupTitleLabel = ""; // 0x10
			public IPopupContent content; // 0x14

			// RVA: 0x1154384 Offset: 0x1154384 VA: 0x1154384
			public ContentsData(int type, PopupSetting popupSetting, string label)
			{
				this.type = type;
				setting = popupSetting;
				popupTitleLabel = label;
			}

			// RVA: 0x1153444 Offset: 0x1153444 VA: 0x1153444
			//public bool IsExistSettingAndContent() { }
		}

		private Dictionary<int, ContentsData> m_contents = new Dictionary<int, ContentsData>(3); // 0x1C
		private List<int> m_typeList = new List<int>(3); // 0x20
		private PopupWindowControl m_popupControl; // 0x24
		private ChangeTabStatus m_changeTabStatus = new ChangeTabStatus(); // 0x28

		public int DefaultSelect { get; set; } // 0xC
		public int SelectIndex { get; set; } // 0x10
		public Action<ChangeTabStatus> changeTabContentsShow { get; set; } // 0x14
		public Transform Parent { get; set; } // 0x18

		//// RVA: 0x1152CBC Offset: 0x1152CBC VA: 0x1152CBC Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupTabSetting s = setting as PopupTabSetting;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			m_popupControl = control;
			Parent = s.m_parent;
			gameObject.SetActive(false);
			transform.localPosition = new Vector3(0, 0, 0);
			m_changeTabStatus.contents = m_contents;
			for(int i = 0; i < m_typeList.Count; i++)
			{
				if(GetContentsData(i) != null && GetContentsData(i).setting != null)
				{
					IPopupContent c = GetContentsData(i).setting.Content.GetComponent<IPopupContent>();
					GetContentsData(i).content = c;
					if (c != null)
					{
						c.Initialize(GetContentsData(i).setting, size, control);
						if (SelectIndex == m_typeList[i])
						{
							GetContentsData(i).setting.Content.transform.SetParent(transform.parent, false);
						}
					}
				}
			}
		}

		//// RVA: 0x1153284 Offset: 0x1153284 VA: 0x1153284 Slot: 18
		public bool IsScrollable()
		{
			if(m_contents.ContainsKey(SelectIndex))
			{
				if(m_contents[SelectIndex].setting != null && m_contents[SelectIndex].content != null)
				{
					return m_contents[SelectIndex].content.IsScrollable();
				}
			}
			return false;
		}

		//// RVA: 0x1153464 Offset: 0x1153464 VA: 0x1153464 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		//// RVA: 0x115349C Offset: 0x115349C VA: 0x115349C Slot: 20
		public void Hide()
		{
			ContentActive(SelectIndex, false, true);
			SelectIndex = DefaultSelect;
			gameObject.SetActive(false);
		}

		//// RVA: 0x1153AB0 Offset: 0x1153AB0 VA: 0x1153AB0 Slot: 21
		public bool IsReady()
		{
			for (int i = 0; i < m_typeList.Count; i++)
			{
				if(GetContentsData(i) != null && GetContentsData(i).content != null)
				{
					if (!GetContentsData(i).content.IsReady())
						return false;
				}
			}
			return true;
		}

		//// RVA: 0x1153BEC Offset: 0x1153BEC VA: 0x1153BEC Slot: 22
		public void CallOpenEnd()
		{
			for(int i = 0; i < m_typeList.Count; i++)
			{
				GetContentsData(i).content.CallOpenEnd();
			}
		}

		//// RVA: 0x1153D34 Offset: 0x1153D34 VA: 0x1153D34
		//public void AddContents(PopupTabContents.ContentsData data) { }

		//// RVA: 0x1153E64 Offset: 0x1153E64 VA: 0x1153E64
		//public void ClearContents() { }

		//// RVA: 0x1153F08 Offset: 0x1153F08 VA: 0x1153F08
		//public void ClearContentsAll() { }

		//// RVA: 0x1153F30 Offset: 0x1153F30 VA: 0x1153F30
		public void SwitchTitle(int type)
		{
			if(m_popupControl != null)
			{
				if (m_popupControl.m_titleText == null)
					return;
				m_popupControl.m_titleText.text = "";
				if(m_contents.ContainsKey(type) && !string.IsNullOrEmpty(m_contents[type].popupTitleLabel))
				{
					m_popupControl.m_titleText.text = MessageManager.Instance.GetBank("menu").GetMessageByLabel(m_contents[type].popupTitleLabel);
				}
			}
		}

		//// RVA: 0x11541F0 Offset: 0x11541F0 VA: 0x11541F0
		public void SwitchContents(int type)
		{
			m_changeTabStatus.prevType = SelectIndex;
			m_changeTabStatus.currentType = type;
			ContentActive(SelectIndex, false, true);
			ContentActive(type, true, true);
			SelectIndex = type;
		}

		//// RVA: 0x115426C Offset: 0x115426C VA: 0x115426C
		public void ChangeContents(int type)
		{
			SwitchTitle(type);
			SwitchContents(type);
		}

		//// RVA: 0x11534FC Offset: 0x11534FC VA: 0x11534FC
		private void ContentActive(int type, bool enable, bool isReset = true)
		{
			if(m_contents.ContainsKey(type))
			{
				if(m_contents[type].setting != null && m_contents[type].content != null)
				{
					if(isReset)
					{
						m_popupControl.ResetScroll(m_contents[type].setting, m_contents[type].content, 1);
					}
					if(enable)
					{
						m_contents[type].setting.Content.transform.SetParent(transform.parent, false);
						if(changeTabContentsShow != null)
							changeTabContentsShow(m_changeTabStatus);
						m_popupControl.InputDisable();
						m_contents[type].content.Show();
						m_popupControl.InputEnable();
						return;
					}
					if(m_contents[type].setting.Content.activeInHierarchy)
					{
						m_contents[type].content.Hide();
						if(m_contents[type].content.Parent != null)
						{
							m_contents[type].setting.Content.transform.SetParent(m_contents[type].content.Parent, false);
						}
					}
				}
			}
		}

		//// RVA: 0x115311C Offset: 0x115311C VA: 0x115311C
		private ContentsData GetContentsData(int index)
		{
			if(index > -1 && index < m_typeList.Count)
			{
				if(m_contents.ContainsKey(m_typeList[index]))
				{
					return m_contents[m_typeList[index]];
				}
			}
			return null;
		}
	}
}
