
using System;
using System.Collections;
using UnityEngine;
using XeApp.Game;
using XeApp.Game.Common;
using XeApp.Game.Menu;
using XeSys;

public class CKPOGHOIBEP
{
	private bool PCIDGIBANFO; // 0x8

	// // RVA: 0x10816F0 Offset: 0x10816F0 VA: 0x10816F0
	public bool LEFBECMBOLH()
    {
        return !MenuScene.CheckDatelineAndAssetUpdate();
    }

	// RVA: 0x1081770 Offset: 0x1081770 VA: 0x1081770
	public void IJELHNMHAJH(MonoBehaviour CFLCEFJJPDH, FJGOKILCBJA _COCEIPAKJKF_item, Action JGELCIJAGFF, Action LIELJBACFKB, Action _MOBEEPPKFLG_OnFail, Action NIMPEHIECJH)
    {
        if(!PCIDGIBANFO)
        {
            MenuScene.Instance.InputDisable();
            PCIDGIBANFO = true;
            MessageBank bk = MessageManager.Instance.GetBank("menu");
            PopupExchangeSetting s = new PopupExchangeSetting();
            s.TitleText = bk.GetMessageByLabel("item_popup_shop_text_00");
            s.Buttons = new ButtonInfo[2]
            {
                new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
                new ButtonInfo() { Label = PopupButton.ButtonLabel.Exchange, Type = PopupButton.ButtonType.Positive }
            };
            s.WindowSize = SizeType.Large;
            s.View = _COCEIPAKJKF_item;
            PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType _INDDJNMPONH_type, PopupButton.ButtonLabel _KAPMOPMDHJE_label) =>
            {
                //0x1081DD0
                if(_INDDJNMPONH_type == PopupButton.ButtonType.Positive)
                {
                    if(LEFBECMBOLH())
                    {
                        MenuScene.Instance.InputDisable();
                        PCIDGIBANFO = true;
                        Action CMJMGEFNBDK = () =>
                        {
                            //0x108207C
                            MenuScene.Instance.InputEnable();
                            PCIDGIBANFO = false;
                            if(_MOBEEPPKFLG_OnFail != null)
                                _MOBEEPPKFLG_OnFail();
                        };
                        Action DMLJLPMBLCH = () =>
                        {
                            //0x108214C
                            MenuScene.Instance.InputEnable();
                            PCIDGIBANFO = false;
                            if(_MOBEEPPKFLG_OnFail != null)
                                _MOBEEPPKFLG_OnFail();
                        };
                        Action EEIFDMNADPA = () =>
                        {
                            //0x108221C
                            if(JGELCIJAGFF != null)
                                JGELCIJAGFF();
                        };
                        Action NDBKOPGCPHJ = () =>
                        {
                            //0x1082230
                            MenuScene.Instance.InputEnable();
                            PCIDGIBANFO = false;
                            if(LIELJBACFKB != null)
                                LIELJBACFKB();
                        };
                        int DPHIJHDAPLJ = 1;
                        CFLCEFJJPDH.StartCoroutineWatched(EHDNGPFPOKJ_Co_Buy(DPHIJHDAPLJ, _COCEIPAKJKF_item, CMJMGEFNBDK, DMLJLPMBLCH, EEIFDMNADPA, NDBKOPGCPHJ));
                    }
                }
                else
                {
                    if(NIMPEHIECJH != null)
                        NIMPEHIECJH();
                }
            }, null, null, () =>
            {
                //0x1082300
                MenuScene.Instance.InputEnable();
                PCIDGIBANFO = false;
            }, true, true, false, null, null, null, null, null);
        }
    }

	// [IteratorStateMachineAttribute] // RVA: 0x6B9E98 Offset: 0x6B9E98 VA: 0x6B9E98
	// // RVA: 0x1081C18 Offset: 0x1081C18 VA: 0x1081C18
	public IEnumerator EHDNGPFPOKJ_Co_Buy(int _NANNGLGOFKH_value, FJGOKILCBJA _IFGEJDMMAHE_Info, Action NIMPEHIECJH, Action _MOBEEPPKFLG_OnFail, Action FECMHKDMOHF, Action HPNGEKABKBE)
    {
        EKLNMHFCAOI.FKGCBLHOOCL_Category HMIHNDIJBJD;

        //0x1082460
        MenuScene.Instance.InputDisable();
        bool BEKAMBBOLBO_Done = false;
        bool GIGHIFOIMNA = false;
        _IFGEJDMMAHE_Info.PFIBEGFOBEG_Buy(_NANNGLGOFKH_value, () =>
        {
            //0x10823C4
            BEKAMBBOLBO_Done = true;
        }, () =>
        {
            //0x10823D0
            BEKAMBBOLBO_Done = true;
            GIGHIFOIMNA = true;
        }, () =>
        {
            //0x10823DC
            _MOBEEPPKFLG_OnFail();
        });
        yield return new WaitWhile(() =>
        {
            //0x1082408
            return !BEKAMBBOLBO_Done;
        });
        if(GIGHIFOIMNA)
        {
            MenuScene.Instance.InputEnable();
            NIMPEHIECJH();
            yield break;
        }
        if(FECMHKDMOHF != null)
            FECMHKDMOHF();
        MessageBank bk = MessageManager.Instance.GetBank("menu");
        HMIHNDIJBJD = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(_IFGEJDMMAHE_Info.KIJAPOFAGPN_ItemId);
        TextPopupSetting s = PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("item_popup_shop_text_05"), SizeType.Middle, 
            string.Format(bk.GetMessageByLabel("pbox_text_03"), EKLNMHFCAOI.INCKKODFJAP_GetItemName(_IFGEJDMMAHE_Info.KIJAPOFAGPN_ItemId) + " " + (_NANNGLGOFKH_value * _IFGEJDMMAHE_Info.JDLJPNMLFID_ItemCount).ToString() + EKLNMHFCAOI.NDBLEADIDLA(HMIHNDIJBJD, EKLNMHFCAOI.DEACAHNLMNI_getItemId(_IFGEJDMMAHE_Info.KIJAPOFAGPN_ItemId))), new ButtonInfo[1]
            {
                new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
            }, false, true);
        BEKAMBBOLBO_Done = false;
        PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType _INDDJNMPONH_type, PopupButton.ButtonLabel _KAPMOPMDHJE_label) =>
        {
            //0x1081DCC
            return;
        }, null, null, null, true, true, false, null, () =>
        {
            //0x108241C
            BEKAMBBOLBO_Done = true;
        }, null, null, null);
        yield return new WaitWhile(() =>
        {
            //0x1082428
            return !BEKAMBBOLBO_Done;
        });
        GameManager.Instance.ResetViewPlayerData();
        if(HMIHNDIJBJD == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
        {
            BEKAMBBOLBO_Done = false;
            yield return Co.R(PopupRecordPlate.Show(RecordPlateUtility.eSceneType.Shop, _IFGEJDMMAHE_Info.JANMJPOKLFL_InventoryUtil, () =>
            {
                //0x108243C
                BEKAMBBOLBO_Done = true;
            }, false));
            yield return new WaitWhile(() =>
            {
                //0x1082448
                return !BEKAMBBOLBO_Done;
            });
        }
        if(HPNGEKABKBE != null)
            HPNGEKABKBE();
        MenuScene.Instance.InputEnable();
    }
}