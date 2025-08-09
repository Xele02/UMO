using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupMissionMusicChangeAlertSetting : PopupSetting
	{
		public int DescType { get; set; } // 0x34
		public bool isUpdateLimitedMusic { get; set; } // 0x38
		public bool isUpdateBonusSchedule { get; set; } // 0x39
		public bool isExclusionBonusMusic { get; set; } // 0x3A
		public override string PrefabPath { get { return ""; } } //0x168FFD0
		public override string BundleName { get { return "ly/107.xab"; } } //0x169002C
		public override string AssetName { get { return "root_sel_music_eve2_pop_02_layout_root"; } } //0x1690088
		public override bool IsAssetBundle { get { return true; } } //0x16900E4
		public override bool IsPreload { get { return true; } } //0x16900EC
		public override GameObject Content { get { return m_content; } } //0x16900F4
	}

	public class PopupMissionMusicChangeAlert : UIBehaviour, IPopupContent
	{
		private Transform m_parent; // 0xC

		public Transform Parent { get { return m_parent; } } //0x168FFA0

		// RVA: 0x168FD40 Offset: 0x168FD40 VA: 0x168FD40 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupMissionMusicChangeAlertSetting s = setting as PopupMissionMusicChangeAlertSetting;
			LayoutMissionMusicChangeAlert l = GetComponentInChildren<LayoutMissionMusicChangeAlert>(true);
			GetComponent<RectTransform>().sizeDelta = size;
			m_parent = setting.m_parent;
			l.UpdateContent(s.DescType, s.isUpdateLimitedMusic, s.isUpdateBonusSchedule, s.isExclusionBonusMusic);
		}

		// RVA: 0x168FF1C Offset: 0x168FF1C VA: 0x168FF1C Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x168FF24 Offset: 0x168FF24 VA: 0x168FF24 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x168FF5C Offset: 0x168FF5C VA: 0x168FF5C Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x168FF94 Offset: 0x168FF94 VA: 0x168FF94 Slot: 21
		public bool IsReady()
		{
			return true;
		}

		// RVA: 0x168FF9C Offset: 0x168FF9C VA: 0x168FF9C Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
