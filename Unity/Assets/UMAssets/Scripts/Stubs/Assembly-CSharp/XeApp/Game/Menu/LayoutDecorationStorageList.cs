using XeApp.Game.Common;
using System;
using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationStorageList : SwapScrollListContent
	{
		[Serializable]
		public struct StorageListButtonData
		{
			public ActionButton button;
			public RawImageEx image;
		}

		[SerializeField]
		private StorageListButtonData m_deleteButton;
		[SerializeField]
		private StorageListButtonData m_selectButton;
		[SerializeField]
		private StorageListButtonData m_saveButton;
		[SerializeField]
		private ActionButton m_mapNameEditButton;
		[SerializeField]
		private Text m_mapNameText;
	}
}
