
using System;
using UnityEngine.UI;

namespace XeApp.Game.Common
{ 
	public class InputPopupSetting : PopupSetting
	{
		public string Description { get; set; } // 0x34
		public string InputText { get; set; } // 0x38
		public string Notes { get; set; } // 0x3C
		public int CharacterLimit { get; set; } // 0x40
		public int InputLineCount { get; set; } // 0x44
		public InputField.ContentType ContentType { get; set; } // 0x48
		public Action CommitCallBack { get; set; } // 0x4C
		public override string PrefabPath { get { return "Menu/Prefab/PopupWindow/InputContent"; } } //0x1101C0C

		public bool DisableRegex { get; set; } // UMO add

		// RVA: 0x1101C68 Offset: 0x1101C68 VA: 0x1101C68
		public InputPopupSetting()
		{
			InputLineCount = 1;
			ContentType = InputField.ContentType.Standard;
			InputText = "";
		}
	}
}
