using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupEnemyInfo : UIBehaviour, IPopupContent
	{
		private EJKBKMBJMGL_EnemyData data; // 0x10
		private PopupWindowControl m_control; // 0x14
		private EnemyInfoWindow m_window; // 0x18

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0xF83D3C Offset: 0xF83D3C VA: 0xF83D3C Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			EnemyInfoPopupSetting s = setting as EnemyInfoPopupSetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = new Vector3(0, 0, 0);
			m_control = control;
			data = s.enemyData;
			m_window = transform.GetComponent<EnemyInfoWindow>();
			m_window.SetListner(OnBeginTextureLoad, OnEndTextureLoad);
			m_window.SetEnemy(data);
		}

		// RVA: 0xF84000 Offset: 0xF84000 VA: 0xF84000 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0xF84008 Offset: 0xF84008 VA: 0xF84008 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0xF84040 Offset: 0xF84040 VA: 0xF84040 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0xF84078 Offset: 0xF84078 VA: 0xF84078 Slot: 21
		public bool IsReady()
		{
			return m_window.IsLoaded() && m_window.IsLoadTex();
		}

		// RVA: 0xF840D4 Offset: 0xF840D4 VA: 0xF840D4 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}

		//// RVA: 0xF840D8 Offset: 0xF840D8 VA: 0xF840D8
		private void OnBeginTextureLoad()
		{
			m_control.InputDisable();
		}

		//// RVA: 0xF84104 Offset: 0xF84104 VA: 0xF84104
		private void OnEndTextureLoad()
		{
			m_control.InputEnable();
		}
	}
}
