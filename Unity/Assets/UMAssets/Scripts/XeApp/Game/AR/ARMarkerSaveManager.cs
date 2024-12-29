
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.AR
{
    public delegate void OnShowARMakerSaveError(ARMarkerSaveManager.ErrorUIType type, SakashoErrorId errorId, Action onRetry, Action onErrorToTitle);
    
    public class ARMarkerSaveManager
    {
        public enum ErrorUIType
        {
            Timeout = 0,
            Network = 1,
            Error = 2,
        }

        private BBHNACPENDM_ServerSaveData arPlayerData; // 0x8
        private bool isExistPlayerData; // 0xC
        private float timeoutTimer; // 0x10
        private float timeoutTime = 10; // 0x14
        public OnShowARMakerSaveError onShowARMarkerSaveError; // 0x18
        public Action onShowNetworkIcon; // 0x1C
        public Action onHideNetworkIcon; // 0x20
        public int lastErrorId; // 0x24

        // // RVA: 0x11DAFC4 Offset: 0x11DAFC4 VA: 0x11DAFC4
        public void Load(IMCBBOAFION onSuccess, DJBHIFLHJLK onErrorToTitle)
        {
            isExistPlayerData = false;
            ARSaveData.Instance.Load();
            arPlayerData = new BBHNACPENDM_ServerSaveData();
            arPlayerData.GGBOGLKKKDM();
            timeoutTime = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("ar_net_timeout", 10);
            N.a.StartCoroutineWatched(Co_Load(onSuccess, onErrorToTitle));
        }

        // [IteratorStateMachineAttribute] // RVA: 0x67ACC4 Offset: 0x67ACC4 VA: 0x67ACC4
        // // RVA: 0x11DB8A8 Offset: 0x11DB8A8 VA: 0x11DB8A8
        private IEnumerator Co_Load(IMCBBOAFION onSuccess, DJBHIFLHJLK onErrorToTitle)
        {
            //0x11DC22C
            NAIJIFAJGGK_RequestLoadPlayerData req;

            req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new NAIJIFAJGGK_RequestLoadPlayerData());
            req.HHIHCJKLJFF_BlockToRequest = arPlayerData.KPIDBPEKMFD_GetBlockList();
            req.IJMPLDBGMHC_OnDataReceived = arPlayerData.IIEMACPEEBJ_Load;
            while(!req.PLOOEECNHFB_IsDone)
                yield return null;
            if(req.NPNNPNAIONN_IsError)
            {
                onErrorToTitle();
                yield break;
            }
            if(arPlayerData.JHFIPCIHJNL_Base.IJHBIMNKOMC_TutorialEnd != 2)
            {
                isExistPlayerData = false;
                onSuccess();
                yield break;
            }
            isExistPlayerData = true;
            if(!ARSaveData.Instance.SyncToPlayerData(arPlayerData))
            {
                onSuccess();
                yield break;
            }
            EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
            arPlayerData.LCLPLFCBDBB_ArMarker.OKJPIBHMKMJ(json, arPlayerData.MCKEOKFMLAH_SaveId + 1);
            KIJECNFNNDB_JsonWriter w = new KIJECNFNNDB_JsonWriter();
            json.EJCOJCGIBNG_ToJson(w);
            string str = w.ToString();
            GGKHIHFPKDH_SavePlayerData r = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new GGKHIHFPKDH_SavePlayerData());
            List<string> l = new List<string>();
            l.Add("ar_marker");
            r.HHIHCJKLJFF_Names = l;
            r.AHEFHIMGIBI_PlayerData = str;
            r.CHDDDCCHJJH_Replace = true;
            while(!r.PLOOEECNHFB_IsDone)
                yield return null;
            if(r.NPNNPNAIONN_IsError)
                onErrorToTitle();
            else
                onSuccess();
        }

        // RVA: 0x11DB988 Offset: 0x11DB988 VA: 0x11DB988
        public void Save(int marker_no, IMCBBOAFION onSuccess, DJBHIFLHJLK onErrorToTitle)
        {
            if(marker_no > 0)
            {
                if(marker_no <= arPlayerData.LCLPLFCBDBB_ArMarker.DNKNFFPLGNM.Count)
                {
                    arPlayerData.LCLPLFCBDBB_ArMarker.DNKNFFPLGNM[marker_no - 1].BEBJKJKBOGH_Date = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
                }
            }
            if(isExistPlayerData)
            {
                ARMenuManager.Instance.SetEnableOperate(false);
                N.a.StartCoroutineWatched(Co_Save(onSuccess, onErrorToTitle));
            }
            else
            {
                onSuccess();
            }
        }

        // [IteratorStateMachineAttribute] // RVA: 0x67AD3C Offset: 0x67AD3C VA: 0x67AD3C
        // // RVA: 0x11DBC7C Offset: 0x11DBC7C VA: 0x11DBC7C
        private IEnumerator Co_Save(IMCBBOAFION onSuccess, DJBHIFLHJLK onErrorToTitle)
        {
            string[] names; // 0x24
            string json; // 0x28
            int retryCount; // 0x2C
            bool timeout; // 0x30
            SakashoAPICallContext context; // 0x34
            SakashoErrorId errorId; // 0x38

            //0x11DCC44
            EDOHBJAPLPF_JsonData data_ = new EDOHBJAPLPF_JsonData();
            arPlayerData.LCLPLFCBDBB_ArMarker.OKJPIBHMKMJ(data_, arPlayerData.MCKEOKFMLAH_SaveId + 1);
            names = new string[1] { "ar_marker" };
            json = data_.EJCOJCGIBNG_ToJson();
            if(onShowARMarkerSaveError == null)
            {
                onShowARMarkerSaveError = OnShowErrorUI;
            }
            if(onShowNetworkIcon == null)
            {
                onShowNetworkIcon = () =>
                {
                    //0x11DC108
                    return;
                };
            }
            if(onHideNetworkIcon == null)
            {
                onHideNetworkIcon = () =>
                {
                    //0x11DC10C
                    return;
                };
            }
            retryCount = 0;
            onShowNetworkIcon();
            while(true)
            {
                timeoutTimer = 0;
                bool done = false;
                bool err = false;
                timeout = false;
                SakashoError lastError = null;
                context = SakashoPlayerData.SavePlayerData(names, json, true, null, (string data) =>
                {
                    //0x11DC118
                    done = true;
                }, (SakashoError e) =>
                {
                    //0x11DC124
                    done = true;
                    lastError = e;
                    err = true;
                });
                while(!done)
                    yield return null;
                if(!timeout && !err)
                    break;
                bool title = false;
                done = false;
                if(!timeout)
                {
                    errorId = lastError.getErrorId();
                    if(errorId != SakashoErrorId.SESSION_NOT_FOUND && errorId != SakashoErrorId.NETWORK_ERROR)
                    {
                        ARMenuManager.Instance.SetEnableOperate(true);
                        onShowARMarkerSaveError.Invoke(ErrorUIType.Error, errorId, () =>
                        {
                            //0x11DC150
                            done = true;
                        }, () =>
                        {
                            //0x11DC1C4
                            done = true;
                            title = true;
                        });
                        while(!done)
                            yield return null;
                        ARMenuManager.Instance.SetEnableOperate(false);
                        lastErrorId = (int)errorId;
                        //LAB_011dd6bc
                        onHideNetworkIcon();
                        onErrorToTitle();
                        yield break;
                    }
                    if(retryCount < 2)
                    {
                        retryCount++;
                        yield return new WaitForSeconds(1);
                        context = null;
                        continue;
                    }
                    done = false;
                    ARMenuManager.Instance.SetEnableOperate(true);
                    onShowARMarkerSaveError.Invoke(ErrorUIType.Network, errorId, () =>
                    {
                        //0x11DC144
                        done = true;
                    }, () =>
                    {
                        //0x11DC194
                        done = true;
                        title = true;
                    });
                    while(!done)
                        yield return null;
                }
                else
                {
                    ARMenuManager.Instance.SetEnableOperate(true);
                    onShowARMarkerSaveError.Invoke(ErrorUIType.Timeout, SakashoErrorId.UNKNOWN, () =>
                    {
                        //0x11DC138
                        done = true;
                    }, () =>
                    {
                        //0x11DC164
                        done = true;
                        title = true;
                    });
                    while(!done)
                        yield return null;
                }
                if(title)
                {
                    //LAB_011dd6ac
                    //>LAB_011dd6bc;
                    onHideNetworkIcon();
                    onErrorToTitle();
                    yield break;
                }
                ARMenuManager.Instance.SetEnableOperate(false);
                retryCount = 0;
            }
            ARMenuManager.Instance.SetEnableOperate(true);
            onHideNetworkIcon();
            onSuccess();
        }

        // // RVA: 0x11DBD5C Offset: 0x11DBD5C VA: 0x11DBD5C
        private void OnShowErrorUI(ARMarkerSaveManager.ErrorUIType uitype, SakashoErrorId errorId, Action onRetry, Action onErrorToTitle)
        {
            string str = "ar_net_error_02";
            PopupButton.ButtonLabel label = PopupButton.ButtonLabel.Retry;
            if (uitype == ErrorUIType.Timeout)
            {
                str = "ar_net_error_02";
            }
            else if(uitype == ErrorUIType.Network)
            {
                str = "ar_net_error_01";
            }
            else
            {
                label = PopupButton.ButtonLabel.Ok;
            }
            ButtonInfo[] btn = new ButtonInfo[1]
            {
                new ButtonInfo() { Label = label, Type = PopupButton.ButtonType.Positive }
            };
            TextPopupSetting s = new TextPopupSetting();
            s.Buttons = btn;
            s.Text = MessageManager.Instance.GetMessage("menu", str);
            PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel buttonLabel) =>
            {
                //0x11DC1F4
                if(buttonLabel == PopupButton.ButtonLabel.Retry)
                    onRetry();
                else
                    onErrorToTitle();
            }, null, null, null);
        }
    }
}