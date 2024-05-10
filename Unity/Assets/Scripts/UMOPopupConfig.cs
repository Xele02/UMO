using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeApp.Game.Menu;

public class UMOPopupConfig : UIBehaviour, IPopupContent
{
	public Transform Parent { get; private set; } // 0xC

    /*public UMO_ToggleButtonGroup CanSkipSongs;
    public UMO_ToggleButtonGroup InvincibleMode;
    public UMO_ToggleButtonGroup ForcePerfect;
    public UMO_ToggleButtonGroup DisableNoteSound;
    public UMO_ToggleButtonGroup DisableWatermark;
    public UMO_ToggleButtonGroup MinigameAutoPlay;
    public UMO_ToggleButtonGroup ForceIntegrityCheck;
    public UMO_ToggleButtonGroup DisplayItemId;
    public UMO_ToggleButtonGroup EnableInfoLog;
    public UMO_ToggleButtonGroup EnableErrorLog;*/
    
    [SerializeField]
	private GameObject ToggleButtonPrefab;

    public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
    {
        Parent = setting.m_parent;

        float y = -10;
        AddToggleButton(ref y, "Can skip unplayed song", () =>
        {
            return RuntimeSettings.CurrentSettings.CanSkipUnplayedSongs;
        }, (bool b) =>
        {
            RuntimeSettings.CurrentSettings.CanSkipUnplayedSongs = b;
        });
        
        AddToggleButton(ref y, "Live : Invincible mode", () =>
        {
            return RuntimeSettings.CurrentSettings.IsInvincibleCheat;
        }, (bool b) =>
        {
            RuntimeSettings.CurrentSettings.IsInvincibleCheat = b;
        });
        
        AddToggleButton(ref y, "Live : Force perfect", () =>
        {
            return RuntimeSettings.CurrentSettings.ForcePerfectNote;
        }, (bool b) =>
        {
            RuntimeSettings.CurrentSettings.ForcePerfectNote = b;
        });
        
        AddToggleButton(ref y, "SLive : Disable note sound", () =>
        {
            return RuntimeSettings.CurrentSettings.DisableNoteSound;
        }, (bool b) =>
        {
            RuntimeSettings.CurrentSettings.DisableNoteSound = b;
        });
        
        AddToggleButton(ref y, "SLive : Disable watermark", () =>
        {
            return RuntimeSettings.CurrentSettings.DisableWatermark;
        }, (bool b) =>
        {
            RuntimeSettings.CurrentSettings.DisableWatermark = b;
        });
        
        AddToggleButton(ref y, "April fool minigame : Autoplay", () =>
        {
            return RuntimeSettings.CurrentSettings.MinigameAutoPlay;
        }, (bool b) =>
        {
            RuntimeSettings.CurrentSettings.MinigameAutoPlay = b;
        });
        AddToggleButton(ref y, "Shop : Unloc max buy limit", () =>
        {
            return RuntimeSettings.CurrentSettings.RemoveShopLimit;
        }, (bool b) =>
        {
            RuntimeSettings.CurrentSettings.RemoveShopLimit = b;
        });
        AddToggleButton(ref y, "Shop : Remove crystal limit", () =>
        {
            return RuntimeSettings.CurrentSettings.RemoveCrystalLimit;
        }, (bool b) =>
        {
            RuntimeSettings.CurrentSettings.RemoveCrystalLimit = b;
        });
        
        AddToggleButton(ref y, "Data : Force integrity check on next launch", () =>
        {
            return KEHOJEJMGLJ.FJDOHLADGFI;
        }, (bool b) =>
        {
            KEHOJEJMGLJ.FJDOHLADGFI = b;
        });
        
        AddToggleButton(ref y, "Debug : Display item id in name", () =>
        {
            return RuntimeSettings.CurrentSettings.DisplayIdInName;
        }, (bool b) =>
        {
            RuntimeSettings.CurrentSettings.DisplayIdInName = b;
        });
        
        AddToggleButton(ref y, "Debug : Enable info log", () =>
        {
            return RuntimeSettings.CurrentSettings.EnableInfoLog;
        }, (bool b) =>
        {
            RuntimeSettings.CurrentSettings.EnableInfoLog = b;
        });
        
        AddToggleButton(ref y, "Debug : Enable error log", () =>
        {
            return RuntimeSettings.CurrentSettings.EnableErrorLog;
        }, (bool b) =>
        {
            RuntimeSettings.CurrentSettings.EnableErrorLog = b;
        });
        AddToggleButton(ref y, "Debug : Dump string used info in log (for translation)", () =>
        {
            return RuntimeSettings.CurrentSettings.DumpStringUsed;
        }, (bool b) =>
        {
            RuntimeSettings.CurrentSettings.DumpStringUsed = b;
        });
        AddToggleButton(ref y, "Debug : Show string key instead of real text (for translation)", () =>
        {
            return RuntimeSettings.CurrentSettings.ShowStringUsed;
        }, (bool b) =>
        {
            RuntimeSettings.CurrentSettings.ShowStringUsed = b;
        });
        
        #if UNITY_ANDROID
        AddToggleButton(ref y, "Debug : Disable Cryware low latency", () =>
        {
            return RuntimeSettings.CurrentSettings.DisableCrywareLowLatency;
        }, (bool b) =>
        {
            RuntimeSettings.CurrentSettings.DisableCrywareLowLatency = b;
        });
        #endif
        #if UNITY_EDITOR
        AddToggleButton(ref y, "Use touch screen", () =>
        {
            return RuntimeSettings.CurrentSettings.UseTouchScreen;
        }, (bool b) =>
        {
            RuntimeSettings.CurrentSettings.UseTouchScreen = b;
        });
        #endif
        GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<RectTransform>().sizeDelta.x, -y);
        gameObject.SetActive(true);
    }

    public void Save()
    {
        UMO_ToggleButtonGroup[] btns = GetComponentsInChildren<UMO_ToggleButtonGroup>();
        for(int i = 0; i < btns.Length; i++)
        {
            btns[i].Save();
        }
        RuntimeSettings.CurrentSettings.Save();
    }

    void AddToggleButton(ref float y, string txt, Func<bool> isOnCallback, Action<bool> setOnCallback)
    {
        GameObject g = Instantiate(ToggleButtonPrefab);
        UMO_ToggleButtonGroup toggle = g.GetComponentInChildren<UMO_ToggleButtonGroup>();
        g.transform.SetParent(transform, false);
        y -= 52;
        (g.transform as RectTransform).anchoredPosition = new Vector2(71, y);
        y -= 10;
        toggle.IsOnCallback = isOnCallback;
        toggle.SetOnCallback = setOnCallback;
        Text text = g.GetComponentInChildren<Text>();
        text.text = txt;
        toggle.Init();
    }
    public bool IsScrollable()
    {
        return true;
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