using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;
using XeApp.Game.Menu;
using XeSys;
using XeSys.Gfx;

public class UMOPopupLanguage : UIBehaviour, IPopupContent
{
	public Transform Parent { get; private set; } // 0xC

    public SwapScrollList scrollList;
    public GameObject languagePrefab;

    string currentLanguageSelected = "";

    [Serializable]
    public class LanguageInfo
    {
        public string name;
        public Texture2D flag;
        public string languageName;
    }

    public List<LanguageInfo> languages = new List<LanguageInfo>();

    public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
    {
        Parent = setting.m_parent;
        for(int i = 0; i < scrollList.ScrollObjectCount; i++)
        {
            GameObject g = Instantiate(languagePrefab);
            scrollList.AddScrollObject(g.GetComponentInChildren<SwapScrollListContent>());
        }
        currentLanguageSelected = RuntimeSettings.CurrentSettings.Language;
        if(currentLanguageSelected == "" && languages.Count > 0)
            currentLanguageSelected = languages[0].name;
        scrollList.OnUpdateItem.RemoveAllListeners();
        scrollList.OnUpdateItem.AddListener((int idx, SwapScrollListContent content) =>
        {
            (content as UMOPopupLanguageItem).Setup(languages[idx], currentLanguageSelected, OnSelect);
        });
        scrollList.SetItemCount(languages.Count);
        scrollList.Apply();
		scrollList.SetContentEscapeMode(true);
        scrollList.SetPosition(0, 0, 0, false);
        scrollList.VisibleRegionUpdate();
        gameObject.SetActive(true);
    }

    public void Save()
    {
        RuntimeSettings.CurrentSettings.Language = currentLanguageSelected;
        RuntimeSettings.CurrentSettings.Save();
    }

    public void OnSelect(string Id)
    {
        currentLanguageSelected = Id;
        scrollList.VisibleRegionUpdate();
    }
    public bool IsScrollable()
    {
        return false;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public bool IsReady()
    {
        return true;
    }

    public void CallOpenEnd()
    {
        return;
    }
}