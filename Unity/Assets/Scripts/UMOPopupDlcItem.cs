using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeApp.Game.Menu;
using XeSys.Gfx;

public class UMOPopupDlcItem : SwapScrollListContent
{
    public Text NameText;
    public Text DescText;
    public UMO_ToggleButtonGroup ToggleButton;
    public Button DelButton;

    public Action OnRefreshRequested;

    public void Setup(DlcPackage data)
    {
        NameText.text = data.Title;
        string MinV = data.IsUMOVersionCompatible() ? data.MinUMOVersion : "<color=red>"+data.MinUMOVersion+"</color>";
        DescText.text = "Version : "+data.Version+", UMO Min version : "+MinV;
        ToggleButton.SetSelected( DlcManager.Instance.IsEnabled(data) ? 0 : 1 );
        ToggleButton.OnChangeCallback = (bool Enabled) => {
            DlcManager.Instance.SetEnabled(data, Enabled);
            Setup(data);
        };
        DelButton.onClick.RemoveAllListeners();
        DelButton.onClick.AddListener(() =>
        {
            this.StartCoroutineWatched(RequestUninstall(data));
        });
    }

    public IEnumerator RequestUninstall(DlcPackage data)
    {
        bool isShowPopup = true;
        bool isCancel = false;
        PopupWindowManager.Show(PopupWindowManager.CrateTextContent("Uninstall Dlc", SizeType.Small, "Uninstall the dlc ?", new ButtonInfo[2]
        {
            new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
            new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
        }, false, true), (PopupWindowControl c, PopupButton.ButtonType t, PopupButton.ButtonLabel l) =>
        {
            if(t == PopupButton.ButtonType.Negative)
                isCancel = true;
            isShowPopup = false;
        }, null, null, null, true, true, false, null, null, null, null, null);
        while(isShowPopup)
            yield return null;
        if(!isCancel)
        {
            DlcManager.Instance.Uninstall(data);
            if(OnRefreshRequested != null)
                OnRefreshRequested();
        }
    }
}