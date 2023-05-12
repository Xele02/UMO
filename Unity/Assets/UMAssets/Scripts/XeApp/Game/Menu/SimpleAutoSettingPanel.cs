using UnityEngine;
using System;
using UnityEngine.Events;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class SimpleAutoSettingPanel : MonoBehaviour
	{
		[Serializable]
		public class SelectAttrEvent : UnityEvent<int>
		{
			//
		}

		[Serializable]
		public class SelectStyleEvent : UnityEvent<int>
		{
			//
		}

		[SerializeField]
		private UGUIToggleButtonGroup m_AttrTypeGroup; // 0xC
		[SerializeField]
		private UGUIToggleButtonGroup m_PlayStyleGroup; // 0x10
		[SerializeField]
		private SelectAttrEvent m_onSelectAttributeEvent; // 0x14
		[SerializeField]
		private SelectStyleEvent m_onSelectStyleEvent; // 0x18

		public UGUIToggleButtonGroup AttributeGroup { get { return m_AttrTypeGroup; } } //0xC491A0
		public UGUIToggleButtonGroup StyleGroup { get { return m_PlayStyleGroup; } } //0xC491A8
		public SelectAttrEvent OnSelectAttrEvent { get { return m_onSelectAttributeEvent; } } //0xC491B0
		public SelectStyleEvent OnSelectStyleEvent { get { return m_onSelectStyleEvent; } } //0xC491B8

		// RVA: 0xC491C0 Offset: 0xC491C0 VA: 0xC491C0
		private void Awake()
		{
			m_AttrTypeGroup.OnSelectToggleButtonEvent.RemoveAllListeners();
			m_AttrTypeGroup.OnSelectToggleButtonEvent.AddListener((int index) =>
			{
				//0xC493BC
				m_onSelectAttributeEvent.Invoke(index);
			});
			m_PlayStyleGroup.OnSelectToggleButtonEvent.RemoveAllListeners();
			m_PlayStyleGroup.OnSelectToggleButtonEvent.AddListener((int index) =>
			{
				//0xC4943C
				m_onSelectStyleEvent.Invoke(index);
			});
		}
	}
}
