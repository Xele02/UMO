using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;
using XeApp.Game.Menu;
using XeApp.Game.NameEntry;
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
            (content as UMOPopupAccountPickerItem).Setup(accountIdsList[idx], accountNamesList[idx], OnSelect, OnCopy, OnDelete);
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

    public void OnCopy(int Id)
    {
        TextPopupSetting s = PopupWindowManager.CrateTextContent("Confirmation", SizeType.Small, "Copy account ?", new ButtonInfo[2]
        {
            new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
            new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
        }, false, true);
        PopupWindowManager.Show(s, (c, b, l) =>
        {
            int idx = accountIdsList.FindIndex((int a) =>
            {
                return a == Id;
            });
            if(l == PopupButton.ButtonLabel.Ok)
            {
                NameEntry.ShowPlayerNameEntry(accountNamesList[idx], (string n) =>
                {
                    string path = Application.persistentDataPath + "/Profiles/" + Id;
                    int newId = ExternLib.LibSakasho.CreateAccountId(false);
                    string path2 = Application.persistentDataPath + "/Profiles/" + newId;
                    Directory.CreateDirectory(path2);
                    File.Copy(Application.persistentDataPath + "/SaveData/" + Id + "_save.bin", Application.persistentDataPath + "/SaveData/" + newId + "_save.bin");
                    EDOHBJAPLPF_JsonData d = ExternLib.LibSakasho.GetAccountServerData(Id);
                    if(d != null)
                    {
                        d["base"]["name"] = n;
                        ExternLib.LibSakasho.SaveAccountServerData(d, newId, "data.json");
                        accountIdsList.Add(newId);
                        accountNamesList.Add(n);
                        scrollList.SetItemCount(accountIdsList.Count);
                        scrollList.VisibleRegionUpdate();
                    }
                }, () => {});
            }
        }, null, null, null);
    }

    public void OnDelete(int Id)
    {
        TextPopupSetting s = PopupWindowManager.CrateTextContent("Confirmation", SizeType.Small, "Delete account ?", new ButtonInfo[2]
        {
            new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
            new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
        }, false, true);
        PopupWindowManager.Show(s, (c, b, l) =>
        {
            if(l == PopupButton.ButtonLabel.Ok)
            {
                int idx = accountIdsList.FindIndex((int a) =>
                {
                    return a == Id;
                });
                if(idx != -1)
                {
                    int IdPath = Id;
                    if(Id == -2)
                        IdPath = 999999999;
                    string path = Application.persistentDataPath + "/Profiles/" + IdPath;
                    Directory.Delete(path, true);
                    File.Delete(Application.persistentDataPath + "/SaveData/" + IdPath + "_save.bin");
                    if(Id > 0)
                    {
                        accountIdsList.RemoveAt(idx);
                        accountNamesList.RemoveAt(idx);
                    }
                    else
                    {
                        accountNamesList[idx] = "";
                    }
                    scrollList.SetItemCount(accountIdsList.Count);
                    scrollList.VisibleRegionUpdate();
                }
            }
        }, null, null, null);
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