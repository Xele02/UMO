using System;
using System.Collections;
using UdonLib;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeApp.Game.Menu;
using XeSys;
using XeSys.Gfx;
using System.IO;



#if UNITY_EDITOR
using UnityEditor;
#endif

public class UMOPopupDlc : UIBehaviour, IPopupContent
{
	public Transform Parent { get; private set; } // 0xC

    public SwapScrollList scrollList;
    public GameObject dlcPrefab;

    public Button ImportButton;

    public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
    {
        Parent = setting.m_parent;

        DlcManager.Instance.LoadDlcFiles();
 
        for(int i = 0; i < scrollList.ScrollObjectCount; i++)
        {
            GameObject g = Instantiate(dlcPrefab);
            g.GetComponent<UMOPopupDlcItem>().OnRefreshRequested = () => {
                Refresh();
            };
            scrollList.AddScrollObject(g.GetComponentInChildren<SwapScrollListContent>());
        }
        
        scrollList.OnUpdateItem.RemoveAllListeners();
        scrollList.OnUpdateItem.AddListener((int idx, SwapScrollListContent content) =>
        {
            (content as UMOPopupDlcItem).Setup(DlcManager.Instance.Get(idx));
        });
        Refresh();
        gameObject.SetActive(true);

        ImportButton.onClick.RemoveAllListeners();
        ImportButton.onClick.AddListener(() => {
            this.StartCoroutineWatched(ImportDlc());
        });
    }

    public void Refresh()
    {
        scrollList.SetItemCount(DlcManager.Instance.GetNumDLCs());
        scrollList.Apply();
		scrollList.SetContentEscapeMode(true);
        scrollList.SetPosition(0, 0, 0, false);
        scrollList.VisibleRegionUpdate();
    }
    public IEnumerator ImportDlc()
    {
        bool isError = false;
#if UNITY_EDITOR
        string selectedFile = EditorUtility.OpenFilePanel("Select Dlc zip file", "", "zip");
#else
        bool isRunning = true;
        byte[] ZipFileData = null;
        AndroidUtils.OpenFile("Select Dlc Zip file", (byte[] data) =>
        {
            isRunning = false;
            ZipFileData = data;
        }, (string error) =>
        {
            isRunning = false;
        }, "application/octet-stream");
        while(isRunning)
            yield return null;
        string selectedFile = null;
        if(ZipFileData != null)
        {
            selectedFile = Application.persistentDataPath + "tmpdlc.zip";
            File.WriteAllBytes(selectedFile, ZipFileData);
        }
#endif
        do
        {
            if(selectedFile == null || !File.Exists(selectedFile))
            {
                isError = true;
                break;
            }
            ICSharpCode.SharpZipLib.Zip.FastZip UnCompress = new ICSharpCode.SharpZipLib.Zip.FastZip();

            Directory.CreateDirectory(DlcManager.DlcPath);
            string TmpPath = Application.persistentDataPath + "/tmpdlc/";
            UnCompress.ExtractZip(selectedFile, TmpPath, null);
            DlcPackage info = DlcManager.Instance.GetDlcFile(TmpPath);
            if(info == null)
            {
                if(Directory.Exists(TmpPath))
                    Directory.Delete(TmpPath, true);
#if UNITY_ANDROID
                if(File.Exists(selectedFile))
                    File.Delete(selectedFile);
#endif
                isError = true;
                break;
            }
            bool allowInstall = true;
            if(DlcManager.Instance.Exists(info.PackageName))
            {
                bool isShowPopup = true;
                bool isCancel = false;
                PopupWindowManager.Show(PopupWindowManager.CrateTextContent("Dlc already installed", SizeType.Small, "Dlc already installed, update it ?", new ButtonInfo[2]
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
                allowInstall = !isCancel;
            }
            if(allowInstall)
            {
                string DlcInstallPath = DlcManager.Instance.GetPath(info.PackageName);
                if(Directory.Exists(DlcInstallPath))
                    Directory.Delete(DlcInstallPath, true);
                Directory.Move(TmpPath, DlcInstallPath);
                DlcManager.Instance.Load(info.PackageName);
            }
            if(Directory.Exists(TmpPath))
                Directory.Delete(TmpPath, true);
#if UNITY_ANDROID
            if(File.Exists(selectedFile))
                File.Delete(selectedFile);
#endif
        } while(false);
        if(isError)
        {
            bool isShowPopup = true;
            bool isCancel = false;
            PopupWindowManager.Show(PopupWindowManager.CrateTextContent("Error importing Dlc", SizeType.Small, "The file is not valid", new ButtonInfo[1]
            {
                new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative }
            }, false, true), (PopupWindowControl c, PopupButton.ButtonType t, PopupButton.ButtonLabel l) =>
            {
                isCancel = true;
                isShowPopup = false;
            }, null, null, null, true, true, false, null, null, null, null, null);
            while(isShowPopup)
                yield return null;
            if(isCancel)
                yield break;
        }
        Refresh();
    }
    public void Save()
    {
        //UMOEventList.SetCurrentEvent(currentEventSelectedId);
    }

    public void OnSelect(int Id)
    {
        //currentEventSelectedId = Id;
        scrollList.VisibleRegionUpdate();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }

    private void Update()
    {
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