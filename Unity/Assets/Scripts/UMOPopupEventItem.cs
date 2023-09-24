using System;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeApp.Game.Menu;
using XeSys.Gfx;

public class UMOPopupEventItem : SwapScrollListContent
{
    public Text NameText;
    public Text DescText;
    public RawImageEx Icon;
    public Button m_button;
    public Button SelectButton;
    public GameObject ButtonSelected;

    public void Setup(UMOEventList.EventData data, HomeBannerTextureCache bannerTexCache, int selectedId, Action<int> onSelect)
    {
        NameText.enabled = data.Name != "";
        if(data.Name != "")
            NameText.text = data.Name;
        DescText.enabled = data.Desc != "";
        if(data.Desc != "")
            DescText.text = data.Desc;
        Icon.enabled = false;
        if(data.GlobalBannerImageId != -1)
        {
            bannerTexCache.LoadForGenaral(data.GlobalBannerImageId, (IiconTexture tex) =>
            {
                if(tex != null)
                {
                    (tex as HomeBannerTexture).Set(Icon);
                    Icon.enabled = true;
                }
            });
        }
        else
        {
            if(FileSystemProxy.FileExists(Application.persistentDataPath + "/data/android/"+string.Format(HomeBannerTextureCache.BundleFormatForEvent, data.Id)))
            {
                bannerTexCache.LoadForEvent(data.Id, (IiconTexture tex) =>
                {
                    if(tex != null)
                    {
                        (tex as HomeBannerTexture).Set(Icon);
                        Icon.enabled = true;
                    }
                });
            }
        }
        ButtonSelected.SetActive(selectedId == data.Id);
        SelectButton.onClick.RemoveAllListeners();
        SelectButton.onClick.AddListener(() =>
        {
            onSelect(data.Id);
        });
        /*int startNumber = 0;
        m_button.onClick.RemoveAllListeners();
        m_button.onClick.AddListener(() =>
        {
            startNumber++;
            while(!FileSystemProxy.FileExists(Application.persistentDataPath + "/data/android/"+string.Format(HomeBannerTextureCache.BundleFormatForGeneral, startNumber)))
            {
                startNumber++;
                if(startNumber > 755)
                    startNumber = 0; 
            }
            UnityEngine.Debug.LogError(startNumber);
            bannerTexCache.LoadForGenaral(startNumber, (IiconTexture tex) =>
            {
                if(tex != null)
                {
                    (tex as HomeBannerTexture).Set(Icon);
                    Icon.enabled = true;
                }
            });
        });*/
    }
}