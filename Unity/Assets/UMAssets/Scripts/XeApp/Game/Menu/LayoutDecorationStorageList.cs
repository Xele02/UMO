using XeApp.Game.Common;
using System;
using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationStorageList : SwapScrollListContent
	{
		public struct StorageSetting
		{
			public int m_id; // 0x0
			public string m_name; // 0x4
			public bool m_isUse; // 0x8
		}

		[Serializable]
		public struct StorageListButtonData
		{
			public ActionButton button; // 0x0
			public RawImageEx image; // 0x4
		}

		public const string AssetName = "root_deco_window_03_list_layout_root";
		[SerializeField]
		private StorageListButtonData m_deleteButton; // 0x20
		[SerializeField]
		private StorageListButtonData m_selectButton; // 0x28
		[SerializeField]
		private StorageListButtonData m_saveButton; // 0x30
		[SerializeField]
		private ActionButton m_mapNameEditButton; // 0x38
		[SerializeField] // RVA: 0x66C098 Offset: 0x66C098 VA: 0x66C098
		private Text m_mapNameText; // 0x3C
		private TexUVListManager m_uvManager; // 0x40
		private StorageSetting m_setting; // 0x44
		private Action<StorageSetting> m_deleteCallback; // 0x50
		private Action<StorageSetting> m_selectCallback; // 0x54
		private Action<StorageSetting> m_saveCallback; // 0x58
		private Action<StorageSetting> m_mapNameEditCallback; // 0x5C

		// RVA: 0x18BB9E4 Offset: 0x18BB9E4 VA: 0x18BB9E4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_mapNameText.text = "";
			m_uvManager = uvMan;
			Loaded();
			return base.InitializeFromLayout(layout, uvMan);
		}

		//// RVA: 0x18BBA94 Offset: 0x18BBA94 VA: 0x18BBA94
		public void Setting(StorageSetting setting, Action<StorageSetting> deleteCallback, Action<StorageSetting> selectCallback, Action<StorageSetting> saveCallback, Action<StorageSetting> changeMapCallback)
		{
			SettingStorage(setting);
			m_deleteButton.image.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvManager.GetUVData("deco_fnt_13"));
			m_selectButton.image.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvManager.GetUVData("deco_fnt_07"));
			m_saveButton.image.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvManager.GetUVData("deco_fnt_01"));
			m_deleteCallback = deleteCallback;
			m_deleteButton.button.RemoveOnClickCallback(DeleteCallback);
			m_deleteButton.button.AddOnClickCallback(DeleteCallback);
			m_selectCallback = selectCallback;
			m_selectButton.button.RemoveOnClickCallback(SelectCallback);
			m_selectButton.button.AddOnClickCallback(SelectCallback);
			m_saveCallback = saveCallback;
			m_saveButton.button.RemoveOnClickCallback(SaveCallback);
			m_saveButton.button.AddOnClickCallback(SaveCallback);
			m_mapNameEditCallback = changeMapCallback;
			m_mapNameEditButton.RemoveOnClickCallback(MapNameEditCallback);
			m_mapNameEditButton.AddOnClickCallback(MapNameEditCallback);
		}

		//// RVA: 0x18BBF88 Offset: 0x18BBF88 VA: 0x18BBF88
		public void SettingStorage(StorageSetting setting)
		{
			m_setting = setting;
			m_selectButton.button.Disable = !setting.m_isUse;
			m_deleteButton.button.Disable = !setting.m_isUse;
			m_mapNameEditButton.Hidden = !setting.m_isUse;
			m_mapNameText.text = setting.m_name;
		}

		//// RVA: 0x18BC060 Offset: 0x18BC060 VA: 0x18BC060
		//public bool IsUse() { }

		//// RVA: 0x18BC068 Offset: 0x18BC068 VA: 0x18BC068
		public void DeleteCallback()
		{
			m_deleteCallback(m_setting);
		}

		//// RVA: 0x18BC100 Offset: 0x18BC100 VA: 0x18BC100
		public void SelectCallback()
		{
			m_selectCallback(m_setting);
		}

		//// RVA: 0x18BC198 Offset: 0x18BC198 VA: 0x18BC198
		public void SaveCallback()
		{
			m_saveCallback(m_setting);
		}

		//// RVA: 0x18BC230 Offset: 0x18BC230 VA: 0x18BC230
		public void MapNameEditCallback()
		{
			m_mapNameEditCallback(m_setting);
		}
	}
}
