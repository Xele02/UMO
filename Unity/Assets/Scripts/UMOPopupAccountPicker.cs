using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;
using XeApp.Game.Menu;
using XeSys;
using XeSys.Gfx;

public class UMOPopupAccountPicker : UIBehaviour, IPopupContent
{
	public Transform Parent { get; private set; } // 0xC

    public SwapScrollList scrollList;
    public GameObject accountLinePrefab;
    private List<int> accountIdsList = new List<int>();
    private List<string> accountNamesList = new List<string>();
    public int AccountSelected;
    private PopupWindowControl m_control;

    public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
    {
        Parent = setting.m_parent;
        m_control = control;

        AccountSelected = -3;
        accountIdsList.Add(-1);
        accountNamesList.Add("");
        accountIdsList.Add(-2);
        accountNamesList.Add("");
        string path = Application.persistentDataPath + "/Profiles/";
        if(Directory.Exists(path))
        {
            string[] dirs = Directory.GetDirectories(path);
            for(int i = 0; i < dirs.Length; i++)
            {
                if(File.Exists(dirs[i] + "/data.json"))
                {
                    int profileId = 0;
                    if(int.TryParse(new DirectoryInfo(dirs[i]).Name, out profileId))
                    {
                        EDOHBJAPLPF_JsonData d = ExternLib.LibSakasho.GetAccountServerData(profileId);
                        if(d != null)
                        {
                            string accountName = (string)d["base"]["name"];
                            if(profileId == 999999999)
                            {
                                accountNamesList[1] = accountName + " (Cheat)";
                            }
                            else
                            {
                                accountIdsList.Add(profileId);
                                accountNamesList.Add(accountName);
                            }
                        }
                    }
                }
            }
        }

        for(int i = 0; i < scrollList.ScrollObjectCount; i++)
        {
            GameObject g = Instantiate(accountLinePrefab);
            scrollList.AddScrollObject(g.GetComponentInChildren<SwapScrollListContent>());
        }
        scrollList.OnUpdateItem.RemoveAllListeners();
        scrollList.OnUpdateItem.AddListener((int idx, SwapScrollListContent content) =>
        {
            (content as UMOPopupAccountPickerItem).Setup(accountIdsList[idx], accountNamesList[idx], OnSelect);
        });
        scrollList.SetItemCount(accountIdsList.Count);
        scrollList.Apply();
		scrollList.SetContentEscapeMode(true);
        scrollList.SetPosition(0, 0, 0, false);
        scrollList.VisibleRegionUpdate();
        gameObject.SetActive(true);
    }

    public void OnSelect(int Id)
    {
        AccountSelected = Id;
        m_control.Close(() => { return; }, null);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
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