using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupEventGoDivaBonusOpenSetting : PopupSetting
	{
		public IBJAKJJICBC m_musicData; // 0x34
		public BBOPDOIIOGM m_godivaData; // 0x38

		public override string PrefabPath { get { return ""; } } //0xF8C970
		public override string BundleName { get { return "ly/224.xab"; } } //0xF8C9CC
		public override string AssetName { get { return "root_sel_me3_pop_bonus_layout_root"; } } //0xF8CA28
		public override bool IsAssetBundle { get { return true; } } //0xF8CA84
		public override bool IsPreload { get { return false; } } //0xF8CA8C
		public override GameObject Content { get { return m_content; } } //0xF8CA94

		// // RVA: 0xF8CA9C Offset: 0xF8CA9C VA: 0xF8CA9C
		// public void SetContent(GameObject obj) { }
	}

	public class PopupEventGoDivaBonusOpenContents : UIBehaviour, IPopupContent
	{
		private RectTransform m_rectTransform; // 0x10
		private LayoutEventGoDivaPopupBonusOpen m_bonudOpen; // 0x14
		private PopupWindowControl m_popupControl; // 0x18

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0xF8C4CC Offset: 0xF8C4CC VA: 0xF8C4CC
		private void Awake() 
		{
			m_rectTransform = transform as RectTransform;
		}

		// RVA: 0xF8C554 Offset: 0xF8C554 VA: 0xF8C554 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			m_popupControl = control;
			PopupEventGoDivaBonusOpenSetting s = setting as PopupEventGoDivaBonusOpenSetting;
			Parent = s.m_parent;
			m_bonudOpen = GetComponent<LayoutEventGoDivaPopupBonusOpen>();
			if(m_bonudOpen != null)
			{
				m_bonudOpen.Setup(s.m_musicData, s.m_godivaData);
			}
			gameObject.SetActive(true);
		}

		// RVA: 0xF8C768 Offset: 0xF8C768 VA: 0xF8C768 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0xF8C770 Offset: 0xF8C770 VA: 0xF8C770 Slot: 19
		public void Show()
		{
			if(m_bonudOpen != null)
			{
				m_bonudOpen.Show();
			}
			gameObject.SetActive(true);
		}

		// RVA: 0xF8C854 Offset: 0xF8C854 VA: 0xF8C854 Slot: 20
		public void Hide()
		{
			if(m_bonudOpen != null)
			{
				m_bonudOpen.Hide();
			}
			gameObject.SetActive(false);
		}

		// RVA: 0xF8C938 Offset: 0xF8C938 VA: 0xF8C938 Slot: 21
		public bool IsReady()
		{
			return m_bonudOpen.IsReady;
		}

		// RVA: 0xF8C964 Offset: 0xF8C964 VA: 0xF8C964 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
