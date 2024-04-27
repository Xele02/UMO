
using UnityEngine;
using XeApp.Game.Common;

public class UMOPopupAccountPickerSetting : PopupSetting
{
    public override string PrefabPath { get { return "UMO/PopupAccountPicker"; } } //0x1101C0C
    public void SetContent(GameObject content)
    {
        m_content = content;
    }
	public override bool IsPreload { get { return true; } }

}
