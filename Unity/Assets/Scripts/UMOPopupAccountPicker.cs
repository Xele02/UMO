using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UdonLib;
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

        AccountSelected = -4;
        accountIdsList.Add(-1);
        accountNamesList.Add("");
        accountIdsList.Add(-2);
        accountNamesList.Add("");
        #if UNITY_ANDROID
        accountIdsList.Add(-3);
        accountNamesList.Add("");
        #endif
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
            (content as UMOPopupAccountPickerItem).Setup(accountIdsList[idx], accountNamesList[idx], OnSelect, OnCopy, OnDelete, OnSaveProfile, OnSaveOption);
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
        if(Id == -3)
        {
            this.StartCoroutineWatched(ImportProfile());
        }
        else
        {
            AccountSelected = Id;
            m_control.Close(() => { return; }, null);
        }
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

    public void OnSaveProfile(int Id)
    {
        #if UNITY_ANDROID
        string path = Application.persistentDataPath + "/Profiles/" + Id + "/data.json";
        AndroidUtils.OnShare2(path, "Save Profile", "");
        #else
        Application.OpenURL(Application.persistentDataPath + "/Profiles/" + Id + "/");
        #endif
    }

    public void OnSaveOption(int Id)
    {
        #if UNITY_ANDROID
        string path = Application.persistentDataPath + "/SaveData/" + Id + "_save.bin";
        AndroidUtils.OnShare2(path, "Save Profile", "");
        #else
        Application.OpenURL(Application.persistentDataPath + "/SaveData/");
        #endif
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

    IEnumerator ImportProfile()
    {
        byte[] readData = null;
        bool isShowPopup = true;
        bool isCancel = false;
        PopupWindowManager.Show(PopupWindowManager.CrateTextContent("Select profile file", SizeType.Small, "Select the profile file (data.json)", new ButtonInfo[2]
        {
            new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
            new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
        }, false, true), (PopupWindowControl c, PopupButton.ButtonType t, PopupButton.ButtonLabel l) =>
        {
            if(t == PopupButton.ButtonType.Negative)
                isCancel = true;
            isShowPopup = false;
        }, null, null, null, true, true, false);
        while(isShowPopup)
            yield return null;
        if(isCancel)
            yield break;
        while(true)
        {
            bool isRunning = true;
            AndroidUtils.OpenFile("Select profile file", (byte[] data) =>
            {
                isRunning = false;
                readData = data;
            }, (string error) =>
            {
                isRunning = false;
            });
            while(isRunning)
                yield return null;
            bool isError = false;
            try
            {
                if(readData == null)
                    throw new Exception();
                string jsonData = Encoding.UTF8.GetString(readData);
                EDOHBJAPLPF_JsonData data = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(jsonData);
                if(!data.BBAJPINMOEP_Contains("base") || !data.BBAJPINMOEP_Contains("common"))
                {
                    throw new Exception();
                }
                break;
            }
            catch(Exception e)
            {
                UnityEngine.Debug.LogError("UMO : "+e.ToString());
                isError = true;
            }
            if(isError)
            {
                isShowPopup = true;
                isCancel = false;
                PopupWindowManager.Show(PopupWindowManager.CrateTextContent("Select profile file", SizeType.Small, "The file is not valid, retry ?", new ButtonInfo[2]
                {
                    new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
                    new ButtonInfo() { Label = PopupButton.ButtonLabel.Retry, Type = PopupButton.ButtonType.Positive }
                }, false, true), (PopupWindowControl c, PopupButton.ButtonType t, PopupButton.ButtonLabel l) =>
                {
                    if(t == PopupButton.ButtonType.Negative)
                        isCancel = true;
                    isShowPopup = false;
                }, null, null, null, true, true, false);
                while(isShowPopup)
                    yield return null;
                if(isCancel)
                    yield break;
            }
        }
        byte[] readOptionData = null;
        bool isSkip = false;
        isShowPopup = true;
        isCancel = false;
        PopupWindowManager.Show(PopupWindowManager.CrateTextContent("Select option file", SizeType.Small, "Select the option file (XXX_save.bin)\nUse skip to use default options", new ButtonInfo[3]
        {
            new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
            new ButtonInfo() { Label = PopupButton.ButtonLabel.Skip, Type = PopupButton.ButtonType.Other },
            new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
        }, false, true), (PopupWindowControl c, PopupButton.ButtonType t, PopupButton.ButtonLabel l) =>
        {
            if(t == PopupButton.ButtonType.Negative)
                isCancel = true;
            if(t == PopupButton.ButtonType.Other)
                isSkip = true;
            isShowPopup = false;
        }, null, null, null, true, true, false);
        while(isShowPopup)
            yield return null;
        if(isCancel)
            yield break;
        while(!isSkip && true)
        {
            bool isRunning = true;
            AndroidUtils.OpenFile("Select option file", (byte[] data) =>
            {
                isRunning = false;
                readOptionData = data;
            }, (string error) =>
            {
                isRunning = false;
            });
            while(isRunning)
                yield return null;
            bool isError = false;
            try
            {
                if(readOptionData == null)
                    throw new Exception();
                ILDKBCLAFPB.IPHAEFKCNMN GLANNFOPMDO_Save = new ILDKBCLAFPB.IPHAEFKCNMN();
                CipherRijndael MIDAHPPDINB;
                MIDAHPPDINB = new CipherRijndael(AFEHLCGHAEE_Strings.IEGHKKJJMHI_SaveCipherPass, AFEHLCGHAEE_Strings.HBMPOOCGNEN_SaveCipherSalt);
                string txt = Encoding.UTF8.GetString(readOptionData);
                GLANNFOPMDO_Save.NFDEBEJFNGD(MIDAHPPDINB.DecryptFromBase64(txt));
                break;
            }
            catch(Exception e)
            {
                UnityEngine.Debug.LogError("UMO : "+e.ToString());
                isError = true;
            }
            if(isError)
            {
                isShowPopup = true;
                isCancel = false;
                PopupWindowManager.Show(PopupWindowManager.CrateTextContent("Select option file", SizeType.Small, "The file is not valid\nUse skip to use default options", new ButtonInfo[3]
                {
                    new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
                    new ButtonInfo() { Label = PopupButton.ButtonLabel.Skip, Type = PopupButton.ButtonType.Other },
                    new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
                }, false, true), (PopupWindowControl c, PopupButton.ButtonType t, PopupButton.ButtonLabel l) =>
                {
                    if(t == PopupButton.ButtonType.Negative)
                        isCancel = true;
                    if(t == PopupButton.ButtonType.Other)
                        isSkip = true;
                    isShowPopup = false;
                }, null, null, null, true, true, false);
                while(isShowPopup)
                    yield return null;
                if(isCancel)
                    yield break;
            }
        }
        int accountId = UnityEngine.Random.Range(100000000, 599999999);
        while(true)
        {
            InputPopupSetting s = new InputPopupSetting();
			s.TitleText = "Select account Id";
			s.InputText = accountId.ToString();
			s.InputLineCount = 1;
			s.CharacterLimit = 10;
			s.WindowSize = SizeType.Middle;
			s.Description = "Select the account Id (Between 100000000 & 599999999).";
			s.Notes = "Use an existing to replace the save.";
            s.ContentType = UnityEngine.UI.InputField.ContentType.IntegerNumber;
            s.DisableRegex = true;
            isShowPopup = true;
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				accountId = int.Parse((control.Content as InputContent).Text);
                isShowPopup = false;
			}, null, null, null);
            while(isShowPopup)
                yield return null;
            if(accountId < 100000000 || accountId > 599999999)
            {
                isShowPopup = true;
                isCancel = false;
                PopupWindowManager.Show(PopupWindowManager.CrateTextContent("Select account Id", SizeType.Small, "Id is not valid", new ButtonInfo[2]
                {
                    new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
                    new ButtonInfo() { Label = PopupButton.ButtonLabel.Retry, Type = PopupButton.ButtonType.Positive }
                }, false, true), (PopupWindowControl c, PopupButton.ButtonType t, PopupButton.ButtonLabel l) =>
                {
                    if(t == PopupButton.ButtonType.Negative)
                        isCancel = true;
                    isShowPopup = false;
                }, null, null, null, true, true, false);
                while(isShowPopup)
                    yield return null;
                if(isCancel)
                    yield break;
            }
            else if(accountIdsList.Contains(accountId))
            {
                isShowPopup = true;
                isCancel = false;
                PopupWindowManager.Show(PopupWindowManager.CrateTextContent("Select account Id", SizeType.Small, "Overrite existing save ?", new ButtonInfo[2]
                {
                    new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
                    new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
                }, false, true), (PopupWindowControl c, PopupButton.ButtonType t, PopupButton.ButtonLabel l) =>
                {
                    if(t == PopupButton.ButtonType.Negative)
                        isCancel = true;
                    isShowPopup = false;
                }, null, null, null, true, true, false);
                while(isShowPopup)
                    yield return null;
                if(isCancel)
                    yield break;
                break;
            }
            else
                break;
        }
        int newId = accountId;
        string path2 = Application.persistentDataPath + "/Profiles/" + accountId;
        Directory.CreateDirectory(path2);
        Directory.CreateDirectory(Application.persistentDataPath + "/SaveData/");
        File.WriteAllBytes(Application.persistentDataPath + "/Profiles/" + accountId + "/data.json", readData);
        if(readOptionData != null)
            File.WriteAllBytes(Application.persistentDataPath + "/SaveData/" + accountId + "_save.bin", readOptionData);
        EDOHBJAPLPF_JsonData d = ExternLib.LibSakasho.GetAccountServerData(accountId);
        if(d != null)
        {
            if(!accountIdsList.Contains(accountId))
            {
                accountIdsList.Add(newId);
                accountNamesList.Add((string)d["base"]["name"]);
            }
            else
            {
                accountNamesList[accountIdsList.IndexOf(accountId)] = (string)d["base"]["name"];
            }
            scrollList.SetItemCount(accountIdsList.Count);
            scrollList.VisibleRegionUpdate();
        }
    }
}