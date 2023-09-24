
using System;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;

public class UMOPopupConfigSetting : PopupSetting
{
    public override string PrefabPath { get { return "UMO/PopupUmoConfig"; } } //0x1101C0C
    public void SetContent(GameObject content)
    {
        m_content = content;
    }

}
