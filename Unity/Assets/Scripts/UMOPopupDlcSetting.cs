
using UnityEngine;
using XeApp.Game.Common;

public class UMOPopupDlcSetting : PopupSetting
{
    public override string PrefabPath { get { return "UMO/PopupUmoDlc"; } }
    public void SetContent(GameObject content)
    {
        m_content = content;
    }
	public override bool IsPreload { get { return true; } }

}
