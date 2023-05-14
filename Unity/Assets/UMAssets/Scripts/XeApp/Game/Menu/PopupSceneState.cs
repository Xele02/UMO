using UnityEngine.EventSystems;
using UnityEngine;
using XeSys.Gfx;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupSceneState : UIBehaviour, IPopupContent
	{
		[SerializeField]
		private SceneStatusParam m_param; // 0xC
		[SerializeField]
		private LayoutUGUIRuntime m_runtime; // 0x10
		private SceneStatePopupSetting m_setting; // 0x14

		public Transform Parent { get; private set; } // 0x18

		// RVA: 0x1147844 Offset: 0x1147844 VA: 0x1147844 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			m_setting = setting as SceneStatePopupSetting;
			m_param.InitializeDecoration();
			transform.GetComponent<RectTransform>().sizeDelta = size;
			m_param.UpdateContent(m_setting.Scene, m_setting.PlayerData, m_setting.IsFriend, 
				m_setting.IsDisableZoom, m_setting.IsDiableLuckyLeaf, m_setting.PageSave);
			Parent = m_setting.m_parent;
			gameObject.SetActive(true);
			transform.localPosition = Vector3.zero;
		}

		// RVA: 0x1147B80 Offset: 0x1147B80 VA: 0x1147B80 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1147B88 Offset: 0x1147B88 VA: 0x1147B88 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x1147BC0 Offset: 0x1147BC0 VA: 0x1147BC0 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
			m_param.ReleaseDecoration();
		}

		// RVA: 0x1147C1C Offset: 0x1147C1C VA: 0x1147C1C Slot: 21
		public bool IsReady()
		{
			return m_runtime.IsReady && !m_param.IsLoading();
		}

		// RVA: 0x1147C7C Offset: 0x1147C7C VA: 0x1147C7C Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
