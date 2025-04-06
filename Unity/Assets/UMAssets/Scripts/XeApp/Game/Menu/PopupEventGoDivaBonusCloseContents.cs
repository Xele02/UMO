using System;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupEventGoDivaBonusCloseSetting : PopupSetting
	{
		public Action<bool> OnClickCheckBoxHiddenListener; // 0x34

		public override string PrefabPath { get { return ""; } } //0xF8C380
		public override string BundleName { get { return "ly/224.xab"; } } //0xF8C3DC
		public override string AssetName { get { return "root_sel_me3_pop_end_layout_root"; } } //0xF8C438
		public override bool IsAssetBundle { get { return true; } } //0xF8C494
		public override bool IsPreload { get { return false; } } //0xF8C49C
		public override GameObject Content { get { return m_content; } } //0xF8C4A4

		// // RVA: 0xF8C4AC Offset: 0xF8C4AC VA: 0xF8C4AC
		// public void SetContent(GameObject obj) { }
	}

	public class PopupEventGoDivaBonusCloseContents : UIBehaviour, IPopupContent
	{
		private RectTransform m_rectTransform; // 0x10
		private LayoutEventGoDivaPopupBonusClose m_bonusClose; // 0x14
		private PopupWindowControl m_popupControl; // 0x18
		public Transform Parent { get; private set; } // 0xC

		// RVA: 0xF8BEF4 Offset: 0xF8BEF4 VA: 0xF8BEF4
		private void Awake()
		{
			m_rectTransform = transform as RectTransform;
		}

		// RVA: 0xF8BF7C Offset: 0xF8BF7C VA: 0xF8BF7C Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupEventGoDivaBonusCloseSetting s = setting as PopupEventGoDivaBonusCloseSetting;
			m_popupControl = control;
			Parent = s.m_parent;
			m_bonusClose = GetComponent<LayoutEventGoDivaPopupBonusClose>();
			if(m_bonusClose != null)
			{
				m_bonusClose.OnClickCheckButtonHiddenListener = s.OnClickCheckBoxHiddenListener;
				m_bonusClose.Setup();
			}
			gameObject.SetActive(true);
		}

		// RVA: 0xF8C19C Offset: 0xF8C19C VA: 0xF8C19C Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0xF8C1A4 Offset: 0xF8C1A4 VA: 0xF8C1A4 Slot: 19
		public void Show()
		{
			if(m_bonusClose != null)
				m_bonusClose.Show();
			gameObject.SetActive(true);
		}

		// RVA: 0xF8C288 Offset: 0xF8C288 VA: 0xF8C288 Slot: 20
		public void Hide()
		{
			if(m_bonusClose != null)
				m_bonusClose.Hide();
			gameObject.SetActive(false);
		}

		// RVA: 0xF8C36C Offset: 0xF8C36C VA: 0xF8C36C Slot: 21
		public bool IsReady()
		{
			return true;
		}

		// RVA: 0xF8C374 Offset: 0xF8C374 VA: 0xF8C374 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
