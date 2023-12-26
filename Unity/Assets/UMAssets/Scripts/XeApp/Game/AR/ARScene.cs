
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;
using UdonLib;

namespace XeApp.Game.AR
{
    public class ARScene : MainSceneBase
    {
        private ScreenOrientation m_lastScrOri = (ScreenOrientation)(-1); // 0x28
        private bool[] m_lastAutoRotFlag = new bool[4]; // 0x2C
        [SerializeField]
        private VuforiaManager m_vuforiaMan; // 0x30
        [SerializeField]
        private Canvas m_photoCanvas; // 0x34
        [SerializeField]
        private ARDivaManager m_divaMan; // 0x38
        private ARTakePhoto m_arTakePhoto; // 0x3C
        private bool m_isSetup; // 0x40
        private bool m_isDoneChangeOrientation; // 0x41
        private Dictionary<string, List<string>> m_helpDict = new Dictionary<string, List<string>>(); // 0x44
        public const string HowToHelpKey = "howto";
        private static int ms_lastResolutionX; // 0x0
        private static int ms_lastResolutionY; // 0x4
        private int m_leaveStep; // 0x48

        // RVA: 0x11EA118 Offset: 0x11EA118 VA: 0x11EA118
        private void ListupFileList(List<string> assetList, List<string> cueSheetList)
        {
            assetList.Add("ar/dv.xab");
            assetList.Add("ar/ui.xab");
            assetList.Add("ar/vf.xab");
            assetList.Add("handmade/shader.xab");
            assetList.Add("ly/ct.xab");
            assetList.Add("bt.xab");
            assetList.Add("ly/065.xab");
            assetList.Add("ly/094.xab");
            foreach(var k in m_helpDict)
            {
                for(int i = 0; i < k.Value.Count; i++)
                {
                    assetList.Add(k.Value[i]);
                }
            }
            for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.CDENCMNHNGA_Divas.Count; i++)
            {
                BJPLLEBHAGO_DivaInfo d = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.CDENCMNHNGA_Divas[i];
                if (d != null)
                {
                    if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.BEEGJHCDHJB_IsDivaAvaiable(d.AHHJLDLAPAN_DivaId))
                    {
                        assetList.Add(string.Format("ct/ar/dv/ic/{0:D2}.xab", d.AHHJLDLAPAN_DivaId));
                    }
                }
            }
        }

        // RVA: 0x11EA798 Offset: 0x11EA798 VA: 0x11EA798
        public void OnDestroy()
        {
            return;
        }

        // RVA: 0x11EA79C Offset: 0x11EA79C VA: 0x11EA79C Slot: 9
        protected override void DoAwake()
        {
            enableFade = false;
            GameManager.Instance.SetDispLongScreenFrame(false);
            base.DoAwake();
        }

        // RVA: 0x11EA85C Offset: 0x11EA85C VA: 0x11EA85C Slot: 10
        protected override void DoStart()
        {
            base.DoStart();
            this.StartCoroutineWatched(Co_MainProc());
        }

        // [IteratorStateMachineAttribute] // RVA: 0x678F5C Offset: 0x678F5C VA: 0x678F5C
        // // RVA: 0x11EA914 Offset: 0x11EA914 VA: 0x11EA914
        private IEnumerator CoLeavingChangeOrientation()
        {
            //0x11EBA94
            Screen.orientation = Input.deviceOrientation == DeviceOrientation.LandscapeRight ? ScreenOrientation.LandscapeRight : ScreenOrientation.Landscape;
            yield return new WaitForSeconds(0.2f);
            m_leaveStep++;
        }

        // // RVA: 0x11EA9C0 Offset: 0x11EA9C0 VA: 0x11EA9C0 Slot: 14
        protected override bool DoUpdateLeave()
        {
            if(m_leaveStep == 1)
                return false;
            if(m_leaveStep == 0)
            {
                m_vuforiaMan.StopCamera();
                this.StartCoroutineWatched(CoLeavingChangeOrientation());
                m_leaveStep++;
                return false;
            }
            else
            {
                revertScreenOrientation();
                GameManager.Instance.SetSystemCanvasResolution(SystemManager.BaseScreenSize);
                GameManager.Instance.LetterBox.SetVisible(true);
                GameManager.Instance.SetFPS(30);
                return base.DoUpdateLeave();
            }
        }

        // // RVA: 0x11EABA0 Offset: 0x11EABA0 VA: 0x11EABA0
        private void revertScreenOrientation()
        {
            if(m_lastScrOri != (ScreenOrientation)(-1))
            {
                Screen.orientation = Input.deviceOrientation == DeviceOrientation.LandscapeRight ? ScreenOrientation.LandscapeRight : ScreenOrientation.Landscape;
                Screen.autorotateToLandscapeLeft = m_lastAutoRotFlag[0];
                Screen.autorotateToLandscapeRight = m_lastAutoRotFlag[1];
                Screen.autorotateToPortrait = m_lastAutoRotFlag[2];
                Screen.autorotateToPortraitUpsideDown = m_lastAutoRotFlag[3];
                m_lastScrOri = (ScreenOrientation)(-1);
                GameManager.Instance.RevertResolution();
            }
        }

        // RVA: 0x11EAD60 Offset: 0x11EAD60 VA: 0x11EAD60 Slot: 15
        protected override void DoOnApplicationQuit()
        {
            revertScreenOrientation();
            GameManager.Instance.SetSystemCanvasResolution(SystemManager.BaseScreenSize);
        }

        // // RVA: 0x11EAE4C Offset: 0x11EAE4C VA: 0x11EAE4C
        private void OnShutdown()
        {
            if(m_divaMan.IsLoading)
                return;
            this.StartCoroutineWatched(Co_ShutDownPopup());
        }

        // [IteratorStateMachineAttribute] // RVA: 0x678FD4 Offset: 0x678FD4 VA: 0x678FD4
        // // RVA: 0x11EAE98 Offset: 0x11EAE98 VA: 0x11EAE98
        private IEnumerator Co_ShutDownPopup()
        {
            //0x13A9044
            ARMenuManager.Instance.SetSelectWindow(Messages.GetSel(SelMsgID.AT_SHUTDOWN, true, true), true);
            yield return null;
            while(ARMenuManager.Instance.GetSelectWindowResult() == SelWinRslt.WAITING)
                yield return null;
            if(ARMenuManager.Instance.GetSelectWindowResult() == SelWinRslt.YES)
                Application.Quit();
        }

        // // RVA: 0x11EAF08 Offset: 0x11EAF08 VA: 0x11EAF08
        private void OnBackButton()
        {
            this.StopAllCoroutinesWatched();
            this.StartCoroutineWatched(Co_GotoTitleProc());
        }

        // [IteratorStateMachineAttribute] // RVA: 0x67904C Offset: 0x67904C VA: 0x67904C
        // // RVA: 0x11EA88C Offset: 0x11EA88C VA: 0x11EA88C
        private IEnumerator Co_MainProc()
        {
            List<AREventMasterData.Data> eventList;
            int i; // 0x18
            AREventMasterData.Data eventInfo; // 0x1C

            //0x13A7340
            yield return Co.R(Co_Initialize());
            GameManager.Instance.SetFPS(60);
            yield return Co.R(ARMenuManager.Instance.Co_Setup());
            ARMenuManager.Instance.OnClickEndButton = () =>
            {
                //0x11EB97C
                this.StartCoroutineWatched(Co_GotoTitleProc());
            };
            ARMenuManager.Instance.OnClickShutterButton = CallbackCameraShutter;
            ARMenuManager.Instance.OnClickResetButton = CallbackResetDiva;
            while(!ARMenuManager.Instance.IsReady())
                yield return null;
            GameManager.Instance.UpdateInputArea(true);
            KDLPEDBKMID.HHCJCDFCLOB.MAIHLKPEHJN = ARMenuManager.Instance.ShowInstallRetryMessage;
            SoundManager.Instance.bgmPlayer.FadeOut(0.3f, null);
            GameManager.Instance.SetTouchEffectVisible(false);
            GameManager.Instance.SetSystemCanvasResolution(new Vector2(GameManager.Instance.ResolutionWidth, GameManager.Instance.ResolutionHeight));
            m_vuforiaMan.Initialize();
            while(!m_vuforiaMan.IsInitDone())
                yield return null;
            GameManager.Instance.fullscreenFader.Fade(0.5f, 0);
            yield return GameManager.Instance.WaitFadeYielder;
            yield return null;
            if(!string.IsNullOrEmpty(m_vuforiaMan.InitializeErrorMessage))
            {
                ILCCJNDFFOB.HHCJCDFCLOB.BGJDJBOCLEA(GameManager.Instance.ar_session_id, 0, m_vuforiaMan.InitializeErrorMessage);
                if(m_vuforiaMan.IsNeedMessageWindow())
                {
                    ARMenuManager.Instance.SetMessageWindow(m_vuforiaMan.InitializeErrorMessage);
                    yield return null;
                    while(ARMenuManager.Instance.IsDisplayMessageWindow(null))
                        yield return null;
                }
                OnBackButton();
                yield break;
            }
            ARMenuManager.Instance.helpMenu.HelpKey = "";
            ARMenuManager.Instance.helpMenu.SetupHelp(m_helpDict);
            eventList = AREventMasterData.Instance.GetEventList(false);
            if(ARSaveData.Instance.IsShowHelp())
            {
                ARMenuManager.Instance.helpMenu.HelpKey = "howto";
                ARMenuManager.Instance.helpMenu.Open();
                yield return null;
                while(ARMenuManager.Instance.helpMenu.IsOpening)
                    yield return null;
                while(ARMenuManager.Instance.helpMenu.IsOpened())
                    yield return null;
                ARSaveData.Instance.SetShowHelp(false);
                ARSaveData.Instance.Save();
                //LAB_013a7ef0
                while(ARMenuManager.Instance.helpMenu.IsPlaying())
                    yield return null;
                //>LAB_013a82d0
            }
            else
            {
                string s = AREventMasterData.Instance.GetStringParam("already_read_help_eventid_list", "");
                if(!string.IsNullOrEmpty(s))
                {
                    string[] strs = s.Split(new char[] { ',' });
                    for(i = 0; i < strs.Length; i++)
                    {
                        ARSaveData.Instance.SetMarkerHelpShowFlag(strs[i]);
                    }
                }
            }
            //LAB_013a82d0;
            if(ARSaveData.Instance.IsNotSeeingMarkerHelp(eventList))
            {
                for(i = 0; i < eventList.Count; i++)
                {
                    eventInfo = eventList[i];
                    if(eventInfo.enable == 2)
                    {
                        List<ARMarkerMasterData.Data> data = ARMarkerMasterData.Instance.GetEventMarkerList(eventInfo.eventId, false);
                        if(data != null && data.Count != 0)
                        {
                            if(ARSaveData.Instance.IsShowMarkerHelp(eventInfo.eventId))
                            {
                                ARMenuManager.Instance.helpMenu.HelpKey = eventInfo.eventId;
                                ARMenuManager.Instance.helpMenu.Open();
                                yield return null;
                                while(ARMenuManager.Instance.helpMenu.IsOpening)
                                    yield return null;
                                while(ARMenuManager.Instance.helpMenu.IsOpened())
                                    yield return null;
                                while(ARMenuManager.Instance.helpMenu.IsPlaying())
                                    yield return null;
                                ARSaveData.Instance.SetMarkerHelpShowFlag(eventInfo.eventId);
                                ARSaveData.Instance.Save();
                                eventInfo = null;
                            }
                        }
                    }
                    //LAB_013a859c
                }
            }
            ARMenuManager.Instance.SetEnableOperate(true);
            m_arTakePhoto = gameObject.AddComponent<ARTakePhoto>();
            m_vuforiaMan.StartProcess();
            //LAB_013a86a8
            while(!m_vuforiaMan.IsStartedProcess())
            {
                if(string.IsNullOrEmpty(m_vuforiaMan.InitializeErrorMessage))
                {
                    yield return null;
                }
                else
                {
                    ILCCJNDFFOB.HHCJCDFCLOB.BGJDJBOCLEA(GameManager.Instance.ar_session_id, 0, m_vuforiaMan.InitializeErrorMessage);
                    ARMenuManager.Instance.SetMessageWindow(m_vuforiaMan.InitializeErrorMessage);
                    yield return null;
                    while(ARMenuManager.Instance.IsDisplayMessageWindow(null))
                        yield return null;
                    OnBackButton();
                    yield break;
                }
            }
            ILCCJNDFFOB.HHCJCDFCLOB.BGJDJBOCLEA(GameManager.Instance.ar_session_id, 1, "");
            this.StartCoroutineWatched(Co_CheckError());
            GameManager.Instance.AddPushBackButtonHandler(OnShutdown);
        }

        // [IteratorStateMachineAttribute] // RVA: 0x6790C4 Offset: 0x6790C4 VA: 0x6790C4
        // // RVA: 0x11EAFC4 Offset: 0x11EAFC4 VA: 0x11EAFC4
        private IEnumerator Co_CheckError()
        {
            //0x11EBC30
            while(true)
            {
                if(m_vuforiaMan.CheckServerError())
                {
                    OnBackButton();
                    yield break;
                }
                if(m_vuforiaMan.CheckError())
                {
                    Debug.LogWarning("----!! ERROR!! " + m_vuforiaMan.InitializeErrorMessage);
                    ILCCJNDFFOB.HHCJCDFCLOB.BGJDJBOCLEA(GameManager.Instance.ar_session_id, 0, m_vuforiaMan.InitializeErrorMessage);
                    ARMenuManager.Instance.SetMessageWindow(m_vuforiaMan.InitializeErrorMessage);
                    while(ARMenuManager.Instance.IsDisplayMessageWindow(null))
                        yield return null;
                    OnBackButton();
                    yield break;
                }
                yield return null;
            }
        }

        // [IteratorStateMachineAttribute] // RVA: 0x67913C Offset: 0x67913C VA: 0x67913C
        // // RVA: 0x11EB070 Offset: 0x11EB070 VA: 0x11EB070
        private IEnumerator Co_Initialize()
        {
            //0x13A6588
            bool isSuccess = false;
            ARMarkerMasterData.Instance.StartInstall(() =>
            {
                //0x11EBA78
                isSuccess = true;
            }, () =>
            {
                //0x11EB9A0
                NextScene("Title");
            });
            while(!isSuccess)
                yield return null;
            isSuccess = false;
            AREventMasterData.Instance.StartInstall(() =>
            {
                //0x11EBA84
                isSuccess = true;
            }, () =>
            {
                //0x11EBA08
                NextScene("Title");
            });
            while(!isSuccess)
                yield return null;
            List<string> l = new List<string>();
            for(int i = 1; true; i++)
            {
                string str = string.Format("ct/ar/hp/{0:D3}.xab", i);
                if(!KEHOJEJMGLJ.HHCJCDFCLOB.IDJBKGBMDAJ.PPCCFNAPHCH_FileExists(str))
                    break;
                l.Add(str);
            }
            m_helpDict.Add("howto", l);
            List<AREventMasterData.Data> eventList = AREventMasterData.Instance.GetEventList(false);
            for(int i = 0; i < eventList.Count; i++)
            {
                if(eventList[i].enable == 2)
                {
                    List<string> l2 = new List<string>();
                    for(int j = 1; true; j++)
                    {
                        string str = string.Format("ct/ar/hp/{0}{1:D3}.xab", eventList[i].eventId, j);
                        if(!KEHOJEJMGLJ.HHCJCDFCLOB.IDJBKGBMDAJ.PPCCFNAPHCH_FileExists(str))
                            break;
                        l2.Add(str);
                    }
                    m_helpDict.Add(eventList[i].eventId, l);
                }
            }
            List<string> assetList = new List<string>();
            List<string> cueSheetlist= new List<string>();
            ListupFileList(assetList, cueSheetlist);
            for(int i = 0; i < assetList.Count; i++)
            {
                KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(assetList[i]);
            }
            for(int i = 0; i < cueSheetlist.Count; i++)
            {
                SoundResource.InstallCueSheet(cueSheetlist[i]);
            }
            yield return null;
            while(KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
                yield return null;
            GameManager.Instance.InitializeUnionData();
            while(!GameManager.Instance.IsUnionDataInitialized)
                yield return null;
            this.StartCoroutineWatched(Co_SetupScreenOrientation());
            while(ARTopCanvas.Instance == null)
                yield return null;
            yield return Co.R(ARMenuManager.Co_Load(transform, m_photoCanvas));
            while(!m_isDoneChangeOrientation)
                yield return null;
        }

        // [IteratorStateMachineAttribute] // RVA: 0x6791B4 Offset: 0x6791B4 VA: 0x6791B4
        // // RVA: 0x11EB0F8 Offset: 0x11EB0F8 VA: 0x11EB0F8
        private IEnumerator Co_SetupScreenOrientation()
        {
            ScreenOrientation[] ORI_TABLE; // 0x14
            int i; // 0x18
            ScreenOrientation targetOri; // 0x1C
            int j; // 0x20

            //0x13A8AFC
            m_isDoneChangeOrientation = false;
            GameManager.Instance.LetterBox.SetVisible(false);
            m_lastScrOri = Screen.orientation;
            m_lastAutoRotFlag[0] = Screen.autorotateToLandscapeLeft;
            m_lastAutoRotFlag[1] = Screen.autorotateToLandscapeRight;
            m_lastAutoRotFlag[2] = Screen.autorotateToPortrait;
            m_lastAutoRotFlag[3] = Screen.autorotateToPortraitUpsideDown;
            ORI_TABLE = new ScreenOrientation[1] { ScreenOrientation.Portrait };
            for(i = 0; i < ORI_TABLE.Length; i++)
            {
                targetOri = ORI_TABLE[i];
                for(j = 0; j < 999; j++)
                {
                    Screen.orientation = targetOri;
                    yield return null;
                    if(Screen.orientation == targetOri)
                        break;
                    yield return null;
                }
                yield return new WaitForSeconds(0.25f);
            }
            int w = Screen.width;
            int h = Screen.height;
            if(w < h)
            {
                ms_lastResolutionX = h;
                ms_lastResolutionY = w;
                Screen.SetResolution(w, h, true);
            }
            else
            {
                ms_lastResolutionX = w;
                ms_lastResolutionY = h;
                Screen.SetResolution(h, w, true);
            }
            m_isDoneChangeOrientation = true;
        }

        // // RVA: 0x11EB180 Offset: 0x11EB180 VA: 0x11EB180
        // public static int RevertResolution(int step) { }

        // [IteratorStateMachineAttribute] // RVA: 0x67922C Offset: 0x67922C VA: 0x67922C
        // // RVA: 0x11EAF38 Offset: 0x11EAF38 VA: 0x11EAF38
        private IEnumerator Co_GotoTitleProc()
        {
            //0x11EC070
            ARMenuManager.Instance.SetEnableOperate(false);
            GameManager.Instance.fullscreenFader.Fade(0.5f, new Color(0, 0, 0, 0), Color.black);
            yield return GameManager.Instance.WaitFadeYielder;
            yield return null;
            SoundManager.Instance.bgmPlayer.Stop();
            SoundManager.Instance.bgmPlayer.source.Pause(false);
            SoundManager.Instance.voARDiva.source.Stop();
            SoundManager.Instance.voARDiva.source.Pause(false);
            if(m_vuforiaMan != null)
                m_vuforiaMan.FinishProcess();
            GameManager.Instance.SetTouchEffectVisible(true);
            NextScene("Title");
        }

        // RVA: 0x11EB2C8 Offset: 0x11EB2C8 VA: 0x11EB2C8 Slot: 13
        protected override void DoUpdateMain()
        {
            if(!m_isSetup)
                return;
            ARMarkerMasterData.Data tgt = m_vuforiaMan.GetRecoTarget();
            ARMenuManager.Instance.recoIcon.UpdateRecoTarget(tgt);
            ARMenuManager.Instance.recoText.UpdateRecoTarget(tgt);
        }

        // // RVA: 0x11EB40C Offset: 0x11EB40C VA: 0x11EB40C
        // public void CallbackCameraSideChange() { }

        // // RVA: 0x11EB5F8 Offset: 0x11EB5F8 VA: 0x11EB5F8
        public void CallbackCameraShutter()
        {
            Debug.Log("Take Photo.");
            if(IsBusyARSystem())
                return;
            m_arTakePhoto.Shutter();
        }

        // // RVA: 0x11EB6B8 Offset: 0x11EB6B8 VA: 0x11EB6B8
        public void CallbackResetDiva()
        {
            Debug.Log("Reset AR Diva.");
            if(IsBusyARSystem())
                return;
            m_vuforiaMan.ResetTracking();
            Transform t = UdonLib.Utils.SearchNodeByName(transform, "ResetButton");
            if(t != null)
            {
                RotateForTime r = t.GetComponent<RotateForTime>();
                if(r != null)
                {
                    r.StartRotate(1, -540);
                }
            }
            m_divaMan.Reset();
        }

        // // RVA: 0x11EB4CC Offset: 0x11EB4CC VA: 0x11EB4CC
        private bool IsBusyARSystem()
        {
            if(m_arTakePhoto != null)
            {
                if(!m_arTakePhoto.IsBusy())
                {
                    if(m_vuforiaMan != null)
                    {
                        return m_vuforiaMan.IsBusy();
                    }
                }
            }
            return true;
        }
    }
}