using System;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeApp.Game.Menu;
using XeSys.Gfx;

public class UMOPopupAccountPickerItem : SwapScrollListContent
{
    public Text NameText;
    public Text IdText;
    public Button SelectButton;
    public Text SelectButtonText;
    public GameObject NewAccountMode;
    public GameObject UseAccountMode;
    public Button CopyButton;
    public Button DeleteButton;

    public void Setup(int accountId, string accountName, Action<int> onSelect, Action<int> onCopy, Action<int> onDelete)
    {
        CopyButton.transform.parent.gameObject.SetActive(true);
        if(accountId == -1)
        {
            NewAccountMode.SetActive(true);
            UseAccountMode.SetActive(false);
            NameText.text = "Create new account";
            IdText.text = "";
        }
        else if(accountId == -2)
        {
            CopyButton.transform.parent.gameObject.SetActive(false);
            NewAccountMode.SetActive(accountName == "");
            UseAccountMode.SetActive(accountName != "");
            IdText.text = "";
            if(accountName != "")
                NameText.text = accountName;
            else
                NameText.text = "Create cheat account";
        }
        else
        {
            NewAccountMode.SetActive(false);
            UseAccountMode.SetActive(true);
            NameText.text = accountName;
            IdText.text = accountId.ToString();
        }
        SelectButton.onClick.RemoveAllListeners();
        SelectButton.onClick.AddListener(() =>
        {
            onSelect(accountId);
        });
        CopyButton.onClick.RemoveAllListeners();
        CopyButton.onClick.AddListener(() =>
        {
            onCopy(accountId);
        });
        DeleteButton.onClick.RemoveAllListeners();
        DeleteButton.onClick.AddListener(() =>
        {
            onDelete(accountId);
        });
    }
}