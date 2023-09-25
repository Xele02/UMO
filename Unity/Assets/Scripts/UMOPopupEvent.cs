using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;
using XeApp.Game.Menu;
using XeSys;
using XeSys.Gfx;

public class UMOPopupEvent : UIBehaviour, IPopupContent
{
	public Transform Parent { get; private set; } // 0xC

    public SwapScrollList scrollList;
    public GameObject eventPrefab;

    HomeBannerTextureCache m_bannerTexCache;

    OAFCKDDEBFN decryptor;
    int currentEventSelectedId = -1;

    public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
    {
        Parent = setting.m_parent;
        decryptor = new OAFCKDDEBFN();
        FileLoader.Instance.findDecryptor = decryptor.MFHAOMELJKJ_FindDecryptor;
		decryptor.PGLANLKJBLI_Init();
        m_bannerTexCache = new HomeBannerTextureCache();
        for(int i = 0; i < scrollList.ScrollObjectCount; i++)
        {
            GameObject g = Instantiate(eventPrefab);
            scrollList.AddScrollObject(g.GetComponentInChildren<SwapScrollListContent>());
        }
        UMOEventList.EventData CurrentEvent = UMOEventList.GetCurrentEvent();
        if(CurrentEvent != null)
            currentEventSelectedId = CurrentEvent.Id;
        scrollList.OnUpdateItem.RemoveAllListeners();
        scrollList.OnUpdateItem.AddListener((int idx, SwapScrollListContent content) =>
        {
            (content as UMOPopupEventItem).Setup(UMOEventList.EventList[idx], m_bannerTexCache, currentEventSelectedId, OnSelect);
        });
        scrollList.SetItemCount(UMOEventList.EventList.Count);
        scrollList.Apply();
		scrollList.SetContentEscapeMode(true);
        scrollList.SetPosition(0, 0, 0, false);
        scrollList.VisibleRegionUpdate();
    }

    public void Save()
    {
        UMOEventList.SetCurrentEvent(currentEventSelectedId);
    }

    public void OnSelect(int Id)
    {
        currentEventSelectedId = Id;
        scrollList.VisibleRegionUpdate();
    }

    protected override void OnDestroy()
    {
        if(m_bannerTexCache != null)
        {
            m_bannerTexCache.Terminated();
            m_bannerTexCache = null;
        }
        base.OnDestroy();
    }

    private void Update()
    {
        if(m_bannerTexCache != null)
            m_bannerTexCache.Update();
    }
    public bool IsScrollable()
    {
        return false;
    }

    public void Show()
    {
        //gameObject.SetActive(true);
    }

    public void Hide()
    {
        //gameObject.SetActive(false);
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