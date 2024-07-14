using System;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeApp.Game.Menu;
using XeSys.Gfx;

public class UMOPopupLanguageItem : SwapScrollListContent
{
    public Text NameText;
    public RawImageEx Icon;
    public Button SelectButton;
    public GameObject ButtonSelected;

    public void Setup(UMOPopupLanguage.LanguageInfo data, string selectedId, Action<string> onSelect)
    {
        Icon.gameObject.SetActive(false);
        NameText.text = data.languageName;
        ButtonSelected.SetActive(selectedId == data.name);
        SelectButton.onClick.RemoveAllListeners();
        SelectButton.onClick.AddListener(() =>
        {
            onSelect(data.name);
        });
    }
}