using XeSys.Gfx;
using UnityEngine;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class LayoutPopupConfigScrollList : LayoutUGUIScriptBase
	{
		public enum LayoutType
		{
			Menu = 0,
			Rhythm = 1,
			Simulation = 2,
			Other = 3,
		}

		[SerializeField]
		private LayoutUGUIScrollSupport m_scrollSupport; // 0x14
		private LayoutPopupConfigMenu m_menu; // 0x18
		private LayoutPopupConfigRhythm m_rhythm; // 0x1C
		private LayoutPopupConfigSimulation m_simulation; // 0x20
		private LayoutPopupConfigOther m_other; // 0x24
		private LayoutType m_layoutType; // 0x28

		public Transform Parent { get; set; } // 0x2C

		//// RVA: 0x1ED6FA8 Offset: 0x1ED6FA8 VA: 0x1ED6FA8
		public void SetStatus()
		{
			if (m_layoutType > LayoutType.Other)
				return;
			switch(m_layoutType)
			{
				case LayoutType.Rhythm:
					m_rhythm.SetStatus(m_scrollSupport.scrollRect);
					break;
				case LayoutType.Simulation:
					m_simulation.SetStatus(m_scrollSupport.scrollRect);
					break;
				case LayoutType.Other:
					m_other.SetStatus(m_scrollSupport.scrollRect);
					break;
				default:
					m_menu.SetStatus(m_scrollSupport.scrollRect);
					break;
			}
		}

		//// RVA: 0x1ED719C Offset: 0x1ED719C VA: 0x1ED719C
		public void AddView(GameObject item, Vector2 size, LayoutType layoutType, ConfigMenu.eType configType)
		{
			m_scrollSupport.BeginAddView();
			m_scrollSupport.AddView(item, 0, 0);
			m_scrollSupport.EndAddView();
			m_layoutType = layoutType;
			int h = 0;
			switch(layoutType)
			{
				case LayoutType.Menu:
					m_menu = item.GetComponent<LayoutPopupConfigMenu>();
					m_menu.ConfigType = configType;
					m_menu.Parent = Parent;
					h = m_menu.GetContentsHeight();
					break;
				case LayoutType.Rhythm:
					m_rhythm = item.GetComponent<LayoutPopupConfigRhythm>();
					m_rhythm.ConfigType = configType;
					m_rhythm.Parent = Parent;
					h = m_rhythm.GetContentsHeight();
					break;
				case LayoutType.Simulation:
					m_simulation = item.GetComponent<LayoutPopupConfigSimulation>();
					m_simulation.ConfigType = configType;
					m_simulation.Parent = Parent;
					h = m_simulation.GetContentsHeight();
					break;
				case LayoutType.Other:
					m_other = item.GetComponent<LayoutPopupConfigOther>();
					m_other.ConfigType = configType;
					m_other.Parent = Parent;
					h = m_other.GetContentsHeight();
					break;
			}
			SetContentsSize(new Vector2(m_scrollSupport.GetComponent<RectTransform>().sizeDelta.x, h));
			if(m_rhythm != null)
			{
				m_rhythm.CallbackButtonTiming = () =>
				{
					//0x1ED7C60
					ConfigManager.scrollPosition = m_scrollSupport.scrollRect.normalizedPosition;
					ConfigManager.selectTab = 21;
					ConfigManager.gotoTimingScene = true;
				};
			}
		}

		//// RVA: 0x1ED79DC Offset: 0x1ED79DC VA: 0x1ED79DC
		public void SetScrollPosition()
		{
			if (!ConfigManager.gotoTimingScene)
				return;
			this.StartCoroutineWatched(Co_SetScrollPosition());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7024B4 Offset: 0x7024B4 VA: 0x7024B4
		//// RVA: 0x1ED7A14 Offset: 0x1ED7A14 VA: 0x1ED7A14
		public IEnumerator Co_SetScrollPosition()
		{
			//0x1ED7CE0
			yield return null;
			m_scrollSupport.scrollRect.normalizedPosition = ConfigManager.scrollPosition;
			ConfigManager.gotoTimingScene = false;
		}

		//// RVA: 0x1ED7918 Offset: 0x1ED7918 VA: 0x1ED7918
		public void SetContentsSize(Vector2 size)
		{
			if(m_scrollSupport != null)
			{
				m_scrollSupport.ContentSize = size;
			}
		}

		// RVA: 0x1ED7AC0 Offset: 0x1ED7AC0 VA: 0x1ED7AC0
		public void Reset()
		{
			return;
		}

		//// RVA: 0x1ED7AC4 Offset: 0x1ED7AC4 VA: 0x1ED7AC4
		public void Show()
		{
			gameObject.SetActive(true);
		}

		//// RVA: 0x1ED7AFC Offset: 0x1ED7AFC VA: 0x1ED7AFC
		public void Hide()
		{
			m_scrollSupport.scrollRect.verticalNormalizedPosition = 1;
			m_scrollSupport.scrollRect.normalizedPosition = Vector2.up;
			gameObject.SetActive(false);
		}

		// RVA: 0x1ED7C40 Offset: 0x1ED7C40 VA: 0x1ED7C40 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Loaded();
			return true;
		}
	}
}
