using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupGachaSkillUpContent : UIBehaviour, IPopupContent
	{
		private PopupGachaSkillUpSetting setup; // 0x10
		private PopupWindowControl control; // 0x14
		private LayoutGachaSkillUpPopup layout; // 0x18

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x17A6678 Offset: 0x17A6678 VA: 0x17A6678 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			this.control = control;
			setup = setting as PopupGachaSkillUpSetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			layout = transform.GetComponent<LayoutGachaSkillUpPopup>();
			layout.Setup(setup.SceneId, setup.SkillType);
		}

		// RVA: 0x17A68A0 Offset: 0x17A68A0 VA: 0x17A68A0
		private void Start()
		{
			return;
		}

		// RVA: 0x17A68A4 Offset: 0x17A68A4 VA: 0x17A68A4
		private void Update()
		{
			return;
		}

		// RVA: 0x17A68A8 Offset: 0x17A68A8 VA: 0x17A68A8 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x17A68B0 Offset: 0x17A68B0 VA: 0x17A68B0 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
			layout.Enter();
		}

		// RVA: 0x17A690C Offset: 0x17A690C VA: 0x17A690C Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x17A6944 Offset: 0x17A6944 VA: 0x17A6944 Slot: 21
		public bool IsReady()
		{
			if(layout != null)
			{
				if(layout.IsSettingEnd())
				{
					return layout.IsLoaded();
				}
			}
			return false;
		}

		// RVA: 0x17A6A28 Offset: 0x17A6A28 VA: 0x17A6A28 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
