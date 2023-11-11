using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

public class UMOPopupConfig : UIBehaviour, IPopupContent
{
	public Transform Parent { get; private set; } // 0xC

    public UMO_ToggleButtonGroup CanSkipSongs;
    public UMO_ToggleButtonGroup InvincibleMode;
    public UMO_ToggleButtonGroup ForcePerfect;
    public UMO_ToggleButtonGroup DisableNoteSound;
    public UMO_ToggleButtonGroup DisableWatermark;
    public UMO_ToggleButtonGroup MinigameAutoPlay;
    public UMO_ToggleButtonGroup ForceIntegrityCheck;
    public UMO_ToggleButtonGroup DisplayItemId;

    public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
    {
        Parent = setting.m_parent;
        CanSkipSongs.SetSelected(RuntimeSettings.CurrentSettings.CanSkipUnplayedSongs ? 0 : 1);
        InvincibleMode.SetSelected(RuntimeSettings.CurrentSettings.IsInvincibleCheat ? 0 : 1);
        ForcePerfect.SetSelected(RuntimeSettings.CurrentSettings.ForcePerfectNote ? 0 : 1);
        DisableNoteSound.SetSelected(RuntimeSettings.CurrentSettings.DisableNoteSound ? 0 : 1);
        DisableWatermark.SetSelected(RuntimeSettings.CurrentSettings.DisableWatermark ? 0 : 1);
        MinigameAutoPlay.SetSelected(RuntimeSettings.CurrentSettings.MinigameAutoPlay ? 0 : 1);
        ForceIntegrityCheck.SetSelected(KEHOJEJMGLJ.FJDOHLADGFI ? 0 : 1);
        DisplayItemId.SetSelected(RuntimeSettings.CurrentSettings.DisplayIdInName ? 0 : 1);
    }

    public void Save()
    {
        RuntimeSettings.CurrentSettings.CanSkipUnplayedSongs = CanSkipSongs.GetSelected() == 0;
        RuntimeSettings.CurrentSettings.IsInvincibleCheat = InvincibleMode.GetSelected() == 0;
        RuntimeSettings.CurrentSettings.ForcePerfectNote = ForcePerfect.GetSelected() == 0;
        RuntimeSettings.CurrentSettings.DisableNoteSound = DisableNoteSound.GetSelected() == 0;
        RuntimeSettings.CurrentSettings.DisableWatermark = DisableWatermark.GetSelected() == 0;
        RuntimeSettings.CurrentSettings.MinigameAutoPlay = MinigameAutoPlay.GetSelected() == 0;
        KEHOJEJMGLJ.FJDOHLADGFI = ForceIntegrityCheck.GetSelected() == 0;
        RuntimeSettings.CurrentSettings.DisplayIdInName = DisplayItemId.GetSelected() == 0;
        UMO_PlayerPrefs.Save();
    }
    public bool IsScrollable()
    {
        return true;
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