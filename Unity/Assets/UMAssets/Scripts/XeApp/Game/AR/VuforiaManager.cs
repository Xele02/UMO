// Using UMO 3.1.0 code

using System.Collections;
using System.Collections.Generic;
using UdonLib;
using UnityEngine;
using XeApp.Core;

namespace XeApp.Game.AR
{
    public class VuforiaManager : MonoBehaviour
    {
        public enum ERROR_TYPE
        {
            NONE = 0,
            CAMERA_PERMISSION = 1,
            DEVICE_NOT_SUPPORTED = 2,
            VUFORIA_INIT_ERROR = 3,
            SMARTAR_INIT_ERROR = 4,
            NO_SPACE_FOR_DATASET = 5,
            SYSTEM_ERROR = 6,
            COUNT = 7,
        }

        public const float RESET_TRACKING_TIME = 1;
        private const float OK_ANGLE_OFFSET = 15;
        private bool m_initialized; // 0xC
        private bool m_sleeping; // 0xD
        [SerializeField]
        private Camera m_clearCamera; // 0x10
        [SerializeField]
        private ARObject m_arObject; // 0x14
        [SerializeField]
        private ARDivaHitCheck m_divaHitCheck; // 0x18
        [SerializeField]
        private Canvas m_photoCanvas; // 0x1C
        private GameObject m_currTrackingObj; // 0x20
        private List<GameObject> m_trackingObjList = new List<GameObject>(); // 0x24
        private bool m_isChangingCameraSide; // 0x28
        private bool m_isResetTracking; // 0x29
        private ARMarkerMasterData.Data m_lastFoundMasterData; // 0x2C
        private bool m_existingArObj; // 0x30
        private bool m_hipsOk; // 0x31
        private Transform m_hipsTr; // 0x34
        private float m_hipsLimitNgCos; // 0x38
        private float m_hipsLimitOkCos; // 0x3C
        private bool m_hipsFading; // 0x40
        private bool m_finishFlag; // 0x41
        private Camera m_cameraAR; // 0x44
        private string m_initializeErrorMessage = ""; // 0x48
        private bool m_needMessageWindow = true; // 0x4C
        private AREngineBase m_arEngine; // 0x50
        private static VuforiaManager ms_instance; // 0x0
        private bool m_divaControl; // 0x54
        private bool m_arEngineError; // 0x55
        private bool m_serverError; // 0x56
        private int m_fullScrMenuCnt; // 0x58
        private bool m_flip; // 0x5C
        private bool m_loadDataSetDone; // 0x5D
        private bool m_startFlag; // 0x5E
        private bool m_suspendFlag; // 0x5F

        public bool IsFlip { get { return m_flip; } } //0x13AB940
        public static VuforiaManager Instance { get { return ms_instance; } } //0x13A9DF4
        public string InitializeErrorMessage { get { return m_initializeErrorMessage; } } //0x13A89F8
        public ARMarkerMasterData.Data LastFoundARMarkerMasterData { get { return m_lastFoundMasterData; } } //0x13AA3DC

        // // RVA: 0x13B55F4 Offset: 0x13B55F4 VA: 0x13B55F4
        public void SetErrorMessage(ERROR_TYPE errType, int code = 0)
        {
            m_needMessageWindow = true;
            switch(errType)
            {
                case ERROR_TYPE.CAMERA_PERMISSION:
                    m_initializeErrorMessage = Messages.Get(MessageID.ERR_CAMERA_PERMISSION);
                    m_needMessageWindow = false;
                    break;
                case ERROR_TYPE.DEVICE_NOT_SUPPORTED:
                    m_initializeErrorMessage = Messages.Get(MessageID.ERR_DEVICE_NOT_SUPPORTED);
                    break;
                case ERROR_TYPE.VUFORIA_INIT_ERROR:
                case ERROR_TYPE.SMARTAR_INIT_ERROR:
                    m_initializeErrorMessage = Messages.Get(MessageID.ERR_VUFORIA_INIT_ERROR);
                    break;
                case ERROR_TYPE.NO_SPACE_FOR_DATASET:
                    m_initializeErrorMessage = Messages.Get(MessageID.ERR_NO_SYSTEM_ERROR);
                    break;
                default:
                    m_initializeErrorMessage = "";
                    break;
            }
        }

        // // RVA: 0x13B57AC Offset: 0x13B57AC VA: 0x13B57AC
        // public static void ChangeExtraTrackingMode(int mode) { }

        // // RVA: 0x13B57B0 Offset: 0x13B57B0 VA: 0x13B57B0
        // public static void ChangeDebugErrorDirect() { }

        // // RVA: 0x13B57B4 Offset: 0x13B57B4 VA: 0x13B57B4
        // public static int GetExtraTrackingMode() { }

        // // RVA: 0x13B57BC Offset: 0x13B57BC VA: 0x13B57BC
        // public static ERROR_TYPE GetDebugErrorDirect() { }

        // RVA: 0x13B57C4 Offset: 0x13B57C4 VA: 0x13B57C4
        private void Awake()
        {
            ms_instance = this;
        }

        // // RVA: 0x13A8A00 Offset: 0x13A8A00 VA: 0x13A8A00
        public bool IsNeedMessageWindow()
        {
            return m_needMessageWindow;
        }

        // // RVA: 0x13A89CC Offset: 0x13A89CC VA: 0x13A89CC
        public void Initialize()
        {
            this.StartCoroutineWatched(CoInitialize());
        }

        // [IteratorStateMachineAttribute] // RVA: 0x67878C Offset: 0x67878C VA: 0x67878C
        // // RVA: 0x13B5854 Offset: 0x13B5854 VA: 0x13B5854
        private IEnumerator CoInitialize()
        {
            string bundleName; // 0x18
            AssetBundleLoadAllAssetOperationBase op; // 0x1C
            int i; // 0x20

            //0x13B6EAC
            m_initialized = false;
            bundleName = "ar/vf.xab";
            op = AssetBundleManager.LoadAllAssetAsync(bundleName);
            yield return op;
            GameObject g = GameObject.Find("Canvas-Fade");
            if(g != null)
            {
                Canvas c = g.GetComponent<Canvas>();
                if(c != null)
                {
                    if(c.worldCamera != null)
                    {
                        c.planeDistance = c.worldCamera.nearClipPlane * 1.0001f;
                    }
                }
            }
            AndroidPermissionReceiver.Create();
            if(!AndroidUtils.CheckSelfPermission(AndroidPermission.CAMERA))
            {
                int requestResult = 0;
                AndroidPermissionReceiver.Instance.RequestPremission(AndroidPermission.CAMERA, () =>
                {
                    //0x13B6B78
                    requestResult = 1;
                }, () =>
                {
                    //0x13B6B84
                    requestResult = 2;
                });
                while(requestResult == 0)
                    yield return null;
                if(requestResult == 2)
                {
                    ARMenuManager.Instance.SetSelectWindow(Messages.GetSel(0, false, AndroidUtils.CheckSelfPermission(AndroidPermission.WRITE_EXTERNAL_STORAGE)), true);
                    yield return null;
                    while(ARMenuManager.Instance.GetSelectWindowResult() == SelWinRslt.WAITING)
                        yield return null;
                    if(ARMenuManager.Instance.GetSelectWindowResult() != SelWinRslt.YES)
                    {
                        //>LAB_013b7474
                    }
                    else
                    {
                        AndroidUtils.RedirectSystemSettings();
                        for(i = 0; i < 10; i++)
                            yield return null;
                    }
                    //LAB_013b7474
                    if(ARMenuManager.Instance.GetSelectWindowResult() == SelWinRslt.NO)
                    {
                        //LAB_013b7728
                        SetErrorMessage(ERROR_TYPE.CAMERA_PERMISSION, 0);
                        m_initialized = true;
                        yield break;
                    }
                    if(!AndroidUtils.CheckSelfPermission(AndroidPermission.CAMERA))
                    {
                        //LAB_013b7728
                        SetErrorMessage(ERROR_TYPE.CAMERA_PERMISSION, 0);
                        m_initialized = true;
                        yield break;
                    }
                }
                //LAB_013b74e4
            }
            //LAB_013b74ec
            m_arEngine = new AREngineSmartAR(this);
            m_cameraAR = Camera.main;
            yield return this.StartCoroutineWatched(m_arEngine.CoInitialize());
            m_initialized = true;
            if(!m_arEngine.IsInitializeOK())
                yield break;
            yield return this.StartCoroutineWatched(m_arEngine.CoLoadMarkerData(op));
            if(m_arEngine.GetErrorType() != 0)
            {
                SetErrorMessage(m_arEngine.GetErrorType(), 0);
                m_initialized = true;
                yield break;
            }
            m_loadDataSetDone = true;
            yield return null;
            AssetBundleManager.UnloadAssetBundle(bundleName, false);
            m_cameraAR = m_arEngine.GetARCamera();
            if(m_photoCanvas != null)
            {
                m_photoCanvas.worldCamera = m_arEngine.GetCanvasCamera();
            }
            m_initialized = true;
            this.StartCoroutineWatched(CoObserveAR());
            this.StartCoroutineWatched(CoObserveError());
            Debug.LogError("C");
        }

        // // RVA: 0x13B5900 Offset: 0x13B5900 VA: 0x13B5900
        public Camera GetCameraAR()
        {
            return m_cameraAR;
        }

        // // RVA: 0x13B5908 Offset: 0x13B5908 VA: 0x13B5908
        // private void setupTrackingMode(GameObject trackingObj, int trackingType) { }

        // // RVA: 0x13B594C Offset: 0x13B594C VA: 0x13B594C
        private void ChangeDivaVisible(bool visible)
        {
            if(!visible)
                suspendDiva();
            else
                resumeDiva();
            m_arObject.SetDiaplayMask(ARObjDispMask.DIVA_REASON, visible);
        }

        // // RVA: 0x13B599C Offset: 0x13B599C VA: 0x13B599C
        public void suspendDiva()
        {
            if(m_arObject != null)
                m_arObject.PauseDiva();
        }

        // // RVA: 0x13B5A50 Offset: 0x13B5A50 VA: 0x13B5A50
        public void resumeDiva()
        {
            if(m_arObject != null)
                m_arObject.ResumeDiva();
        }

        // [IteratorStateMachineAttribute] // RVA: 0x678804 Offset: 0x678804 VA: 0x678804
        // // RVA: 0x13B5B04 Offset: 0x13B5B04 VA: 0x13B5B04
        private IEnumerator CoObserveAR()
        {
            int summonCnt; // 0x18
            GameObject nextTarget; // 0x1C
            bool isHitDiva; // 0x20
            ARMarkerMasterData.Data data; // 0x24
            int count; // 0x28
            ARMarkerSaveManager mgr; // 0x2C

            //0x13B79D8
            yield return null;
            summonCnt = 0;
            while(true)
            {
                if(m_divaControl)
                {
                    m_sleeping = false;
                    //LAB_013b7cac
                    if(m_currTrackingObj != null)
                    {
                        if(m_hipsTr == null || m_lastFoundMasterData == null)
                            ;//>LAB_013b815c;
                        else
                        {
                            Vector3 v = m_hipsTr.position - m_cameraAR.transform.position;
                            v.Normalize();
                            float f1 = Vector3.Dot(m_hipsTr.up, v);
                            float f2 = Vector3.Dot(m_cameraAR.transform.forward, v);
                            float c = Mathf.Cos((m_cameraAR.fieldOfView * 0.5f * 3.141593f) / 180.0f);
                            isHitDiva = m_divaHitCheck.IsHitDiva(m_cameraAR.transform.position, m_hipsOk ? 1 : 1.5f);
                            if(!m_hipsOk)
                            {
                                if((c >= f2 || f1 < m_hipsLimitOkCos) && !isHitDiva)
                                {
                                    if(!m_hipsFading)
                                    {
                                        this.StartCoroutineWatched(CoWhiteFade(0.1f, 0));
                                        yield return new WaitForSeconds(0.1f);
                                        //LAB_013b80f0
                                    }
                                    else
                                    {
                                        //LAB_013b7ab8
                                        m_hipsOk = true;
                                    }
                                    //LAB_013b80f8
                                    ChangeDivaVisible(true);
                                    ARMenuManager.Instance.awayText.SetShowText(isHitDiva);
                                    //LAB_013b8154
                                    //>LAB_013b815c
                                }
                                //>LAB_013b815c
                            }
                            else
                            {
                                if((c >= f2 || f1 < m_hipsLimitNgCos) && !isHitDiva)
                                    ;//>LAB_013b815c
                                else
                                {
                                    if(!m_hipsFading)
                                    {
                                        if(m_arObject.CanDraw())
                                        {
                                            this.StartCoroutineWatched(CoWhiteFade(0.1f, 0));
                                            yield return new WaitForSeconds(0.1f);
                                            //LAB_013b7a9c
                                        }
                                    }
                                    //LAB_013b7a9c
                                    m_hipsOk = false;
                                    //LAB_013b80c8
                                    //LAB_013b80f8
                                    ChangeDivaVisible(false);
                                    ARMenuManager.Instance.awayText.SetShowText(isHitDiva);
                                    //LAB_013b8154
                                    //>LAB_013b815c
                                }
                            }
                        }
                    }
                    //else remove cause all go here
                    while(true)
                    {
                        //LAB_013b815c
                        if(m_divaControl)
                        {
                            m_sleeping = false;
                            nextTarget = null;
                            //LAB_013b81b8
                            if(m_trackingObjList.Count > 0)
                            {
                                nextTarget = m_trackingObjList[m_trackingObjList.Count - 1];
                            }
                            if(m_currTrackingObj != nextTarget)
                            {
                                goodbyeDiva();
                                m_arEngine.StopExtendedTracking(m_currTrackingObj);
                                yield return null;
                                ARMenuManager.Instance.awayText.SetShowText(false);
                                m_currTrackingObj = nextTarget;
                                if(nextTarget != null)
                                {
                                    data = findARMarkerMasterData(nextTarget.name);
                                    if(data != null)
                                    {
                                        ARMenuManager.Instance.expiredWindow.Hide();
                                        m_lastFoundMasterData = data;
                                        m_arEngine.SetCurrentMasterData(data);
                                        isHitDiva = ARSaveData.Instance.IsHaveStamp(data.markerId);
                                        if(!isHitDiva)
                                        {
                                            mgr = NKGJPJPHLIF.HHCJCDFCLOB.NJMOAHNLDBO;
                                            bool done = false;
                                            bool err = false;
                                            GameManager.Instance.SetTransmissionIconPosition(true);
                                            mgr.onShowARMarkerSaveError = ARMenuManager.Instance.ShowARMakerSaveError;
                                            mgr.onShowNetworkIcon = ARMenuManager.Instance.ShowNetworkIcon;
                                            mgr.onHideNetworkIcon = ARMenuManager.Instance.HideNetworkIcon;
                                            mgr.Save(data.no, () =>
                                            {
                                                //0x13B6B98
                                                done = true;
                                            }, () =>
                                            {
                                                //0x13B6BA4
                                                done = true;
                                                err = true;
                                            });
                                            //LAB_013b7b48
                                            while(!done)
                                                yield return null;
                                            mgr.onShowARMarkerSaveError = null;
                                            mgr.onShowNetworkIcon = null;
                                            mgr.onHideNetworkIcon = null;
                                            if(err)
                                            {
                                                m_serverError = true;
                                                yield break;
                                            }
                                            ARMenuManager.Instance.acquireMarker.SetShowMarker(data);
                                            ARSaveData.Instance.SetHaveStamp(data.markerId, true);
                                            ARSaveData.Instance.Save();
                                            mgr = null;
                                        }
                                        //LAB_013b86a0
                                        ILCCJNDFFOB.HHCJCDFCLOB.ILLBGAFIBDE(GameManager.Instance.ar_session_id, data.no, data.eventId, data.markerId, !isHitDiva);
                                        summonCnt++;
                                        m_arObject.SetDivaAndShow(data, summonCnt);
                                        m_arObject.transform.SetParent(m_currTrackingObj.transform);
                                        m_arObject.transform.localPosition = Vector3.zero;
                                        m_arObject.transform.localRotation = Quaternion.identity;
                                        m_arObject.transform.localScale = Vector3.one;
                                        m_arObject.SetOffsetRotation(m_arEngine.GetDivaOffsetRotation());
                                        count = 0;
                                        //LAB_013b8d9c
                                        while(m_arObject.IsLoading())
                                        {
                                            count++;
                                            yield return null;
                                        }
                                        m_hipsTr = UdonLib.Utils.SearchNodeByName(m_arObject.transform, "hips");
                                        m_hipsOk = true;
                                        m_hipsLimitNgCos = Mathf.Cos((m_lastFoundMasterData.angleLimit * 3.141593f) / 180f);
                                        m_hipsLimitOkCos = Mathf.Cos((m_lastFoundMasterData.angleLimit + 15 * 3.141593f) / 180f);
                                        m_arEngine.SetupTrackingMode(m_currTrackingObj, m_lastFoundMasterData.trackingType);
                                        count = 0;
                                        //LAB_013b8ef8
                                        while(!m_arObject.IsReady())
                                        {
                                            count++;
                                            yield return null;
                                        }
                                        data = null;
                                        //>LAB_013b8f30
                                    }
                                    else
                                    {
                                        if(!IsExpiredMarker(nextTarget.name))
                                            yield break;
                                        ARMenuManager.Instance.expiredWindow.Show();
                                        m_lastFoundMasterData = null;
                                        //LAB_013b8f28;
                                        data = null;
                                        //>LAB_013b8f30
                                    }
                                }
                                else
                                {
                                    ARMenuManager.Instance.expiredWindow.Hide();
                                }
                                //>LAB_013b8f30
                            }
                            //LAB_013b8f30
                            yield return null;
                            nextTarget = null;
                            //restart loop
                            break;
                        }
                        else
                        {
                            yield return null;
                            //>LAB_013b8154
                            //>LAB_013b815c
                        }
                    }
                }
                else
                {
                    m_sleeping = true;
                    yield return null;
                }
            }
        }

        // [IteratorStateMachineAttribute] // RVA: 0x67887C Offset: 0x67887C VA: 0x67887C
        // // RVA: 0x13B5BB0 Offset: 0x13B5BB0 VA: 0x13B5BB0
        private IEnumerator CoObserveError()
        {
            //0x13B908C
            while(true)
            {
                yield return new WaitForSeconds(3);
                if(m_arEngine != null)
                {
                    if(m_arEngine.CheckError())
                    {
                        m_arEngineError = true;
                        SetErrorMessage(ERROR_TYPE.SYSTEM_ERROR, 0);
                        yield break;
                    }
                }
            }
        }

        // // RVA: 0x13B5C5C Offset: 0x13B5C5C VA: 0x13B5C5C
        public bool CheckError()
        {
            return m_arEngineError;
        }

        // // RVA: 0x13B5C64 Offset: 0x13B5C64 VA: 0x13B5C64
        public bool CheckServerError()
        {
            return m_serverError;
        }

        // // RVA: 0x13B5C6C Offset: 0x13B5C6C VA: 0x13B5C6C
        private void goodbyeDiva()
        {
            m_arObject.SetDiaplayMask(ARObjDispMask.DIVA_REASON, false);
            m_arObject.ResetObject();
        }

        // // RVA: 0x13AD4F4 Offset: 0x13AD4F4 VA: 0x13AD4F4
        public ARMarkerMasterData.Data GetCurrentTargettingData()
        {
            if(m_currTrackingObj != null)
            {
                return m_lastFoundMasterData;
            }
            return null;
        }

        // // RVA: 0x13B5CC4 Offset: 0x13B5CC4 VA: 0x13B5CC4
        private ARMarkerMasterData.Data findARMarkerMasterData(string markerID)
        {
            List<ARMarkerMasterData.Data> l = ARMarkerMasterData.Instance.GetMarkerList(false);
            for(int i = 0; i < l.Count; i++)
            {
                if(l[i].markerId == markerID)
                {
                    return l[i];
                }
            }
            return null;
        }

        // // RVA: 0x13B5E34 Offset: 0x13B5E34 VA: 0x13B5E34
        private bool IsExpiredMarker(string markerId)
        {
            List<ARMarkerMasterData.Data> l = ARMarkerMasterData.Instance.GetMarkerList(true);
            ARMarkerMasterData.Data data = l.Find((ARMarkerMasterData.Data _) =>
            {
                //0x13B6BB0
                return _.markerId == markerId;
            });
            if(data != null && data.enable == 2)
            {
                long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
                if(t >= data.markerStart)
                    return t >= data.markerEnd;
                return true;
            }
            return false;
        }

        // [IteratorStateMachineAttribute] // RVA: 0x6788F4 Offset: 0x6788F4 VA: 0x6788F4
        // // RVA: 0x13B6068 Offset: 0x13B6068 VA: 0x13B6068
        private IEnumerator CoWhiteFade(float fadeTime, int mode)
        {
            Color endColor; // 0x18
            Color startColor; // 0x28

            //0x13B959C
            m_hipsFading = true;
            endColor = Color.white;
            startColor = Color.white;
            startColor.a = 0;
            GameManager.Instance.fullscreenFader.Fade(fadeTime, startColor, endColor);
            yield return GameManager.Instance.WaitFadeYielder;
            yield return null;
            GameManager.Instance.fullscreenFader.Fade(fadeTime, endColor, startColor);
            yield return GameManager.Instance.WaitFadeYielder;
            yield return null;
            m_hipsFading = false;
        }

        // // RVA: 0x13A8A08 Offset: 0x13A8A08 VA: 0x13A8A08
        public void StartProcess()
        {
            m_startFlag = false;
            this.StartCoroutineWatched(CoStartProcess());
        }

        // // RVA: 0x13A8A38 Offset: 0x13A8A38 VA: 0x13A8A38
        public bool IsStartedProcess()
        {
            return m_startFlag;
        }

        // [IteratorStateMachineAttribute] // RVA: 0x67896C Offset: 0x67896C VA: 0x67896C
        // // RVA: 0x13B613C Offset: 0x13B613C VA: 0x13B613C
        private IEnumerator CoStartProcess()
        {
            //0x13B9430
            while(!m_loadDataSetDone)
                yield return null;
            m_divaControl = true;
            yield return this.StartCoroutineWatched(m_arEngine.StartTracking());
            m_startFlag = true;
        }

        // // RVA: 0x13A89F0 Offset: 0x13A89F0 VA: 0x13A89F0
        public bool IsInitDone()
        {
            return m_initialized;
        }

        // // RVA: 0x13B61E8 Offset: 0x13B61E8 VA: 0x13B61E8
        public void CallbackTrackingFound(GameObject targetImageObj)
        {
            int idx = m_trackingObjList.IndexOf(targetImageObj);
            if(idx > -1)
            {
                m_trackingObjList.RemoveAt(idx);
            }
            m_trackingObjList.Add(targetImageObj);
            m_hipsOk = true;
        }

        // // RVA: 0x13B62DC Offset: 0x13B62DC VA: 0x13B62DC
        public void CallbackTrackingLost(GameObject targetImageObj)
        {
            int idx = m_trackingObjList.IndexOf(targetImageObj);
            if(idx < 0)
            {
                m_trackingObjList.RemoveAt(idx);
            }
        }

        // // RVA: 0x13B6398 Offset: 0x13B6398 VA: 0x13B6398
        public ARMarkerMasterData.Data GetRecoTarget()
        {
            if(m_currTrackingObj != null && m_lastFoundMasterData != null)
            {
                if(m_lastFoundMasterData.markerId == m_currTrackingObj.name)
                    return m_lastFoundMasterData;
            }
            return null;
        }

        // // RVA: 0x13B6480 Offset: 0x13B6480 VA: 0x13B6480
        // public void ChangeCameraSide() { }

        // [IteratorStateMachineAttribute] // RVA: 0x6789E4 Offset: 0x6789E4 VA: 0x6789E4
        // // RVA: 0x13B64C4 Offset: 0x13B64C4 VA: 0x13B64C4
        // private IEnumerator CoChangeCameraSide() { }

        // // RVA: 0x13B6570 Offset: 0x13B6570 VA: 0x13B6570
        // private void CameraModeCheck() { }

        // // RVA: 0x13B65F4 Offset: 0x13B65F4 VA: 0x13B65F4
        public void ResetTracking()
        {
            if(!m_initialized)
                return;
            if(m_isResetTracking)
                return;
            this.StartCoroutineWatched(CoResetTracking());
        }

        // [IteratorStateMachineAttribute] // RVA: 0x678A5C Offset: 0x678A5C VA: 0x678A5C
        // // RVA: 0x13B6638 Offset: 0x13B6638 VA: 0x13B6638
        private IEnumerator CoResetTracking()
        {
            //0x13B9228
            m_isResetTracking = true;
            SuspendTracking();
            goodbyeDiva();
            m_currTrackingObj = null;
            yield return new WaitForSeconds(1);
            ResumeTracking();
            yield return null;
            m_isResetTracking = false;
        }

        // // RVA: 0x13B66E4 Offset: 0x13B66E4 VA: 0x13B66E4
        public void SuspendTracking()
        {
            m_suspendFlag = true;
            m_arEngine.StopTracking(m_currTrackingObj);
        }

        // // RVA: 0x13B6734 Offset: 0x13B6734 VA: 0x13B6734
        public void ResumeTracking()
        {
            if(!m_suspendFlag)
                return;
            m_suspendFlag = false;
            m_arEngine.RestartTracking();
        }

        // // RVA: 0x13AD4CC Offset: 0x13AD4CC VA: 0x13AD4CC
        public void StopCamera()
        {
            m_arEngine.StopCamera();
        }

        // // RVA: 0x13AD92C Offset: 0x13AD92C VA: 0x13AD92C
        public void StartCamera()
        {
            m_arEngine.StartCamera();
        }

        // // RVA: 0x13B677C Offset: 0x13B677C VA: 0x13B677C
        public bool IsBusy()
        {
            if(m_isChangingCameraSide)
                return true;
            return m_isResetTracking;
        }

        // // RVA: 0x13B67A0 Offset: 0x13B67A0 VA: 0x13B67A0
        public void FinishProcess()
        {
            if(m_clearCamera != null)
            {
                m_clearCamera.gameObject.SetActive(true);
            }
        }

        // // RVA: 0x13B6878 Offset: 0x13B6878 VA: 0x13B6878
        // public void OnDestroy() { }

        // // RVA: 0x13AD590 Offset: 0x13AD590 VA: 0x13AD590
        public void ChangeCanvasTarget()
        {
            if(m_photoCanvas != null)
            {
                Camera c = m_arEngine.GetRenderCamera();
                if(c != null)
                {
                    m_photoCanvas.worldCamera = c;
                }
            }
        }

        // // RVA: 0x13AD700 Offset: 0x13AD700 VA: 0x13AD700
        public void ResetCanvasTarget()
        {
            if(m_photoCanvas == null)
                return;
            m_photoCanvas.worldCamera = m_arEngine.GetCanvasCamera();
        }

        // // RVA: 0x13AD6BC Offset: 0x13AD6BC VA: 0x13AD6BC
        public void RenderPhotoTexture(RenderTexture rt, Texture2D photoTexture)
        {
            m_arEngine.RenderPhotoTexture(rt, photoTexture);
        }

        // // RVA: 0x13AD4E8 Offset: 0x13AD4E8 VA: 0x13AD4E8
        public void SuspendDivaControl()
        {
            m_divaControl = false;
            suspendDiva();
        }

        // // RVA: 0x13AD948 Offset: 0x13AD948 VA: 0x13AD948
        public void ResumeDivaControl()
        {
            m_divaControl = true;
            resumeDiva();
        }

        // // RVA: 0x13B68B8 Offset: 0x13B68B8 VA: 0x13B68B8
        public void OpenFullScreenMenu()
        {
            if(m_fullScrMenuCnt == 0)
            {
                m_divaControl = false;
                suspendDiva();
            }
            m_fullScrMenuCnt++;
        }

        // // RVA: 0x13B68F0 Offset: 0x13B68F0 VA: 0x13B68F0
        public void CloseFullScreenMenu()
        {
            m_fullScrMenuCnt--;
            if(m_fullScrMenuCnt != 0)
                return;
            m_divaControl = true;
            resumeDiva();
        }

        // // RVA: 0x13B690C Offset: 0x13B690C VA: 0x13B690C
        // public static float GetCharaHeightMagni(int divaId) { }

        // // RVA: 0x13B69E0 Offset: 0x13B69E0 VA: 0x13B69E0
        public static float GetCharaModelHeight(int divaId)
        {
            float[] l = new float[11]
            {
                1, 154, 165, 168, 159, 147, 156, 165, 153.3f, 184, 164
            };
            if(divaId < 1)
                divaId = 1;
            else
            {
                if(l.Length <= divaId)
                    divaId = 1;
            }
            return l[divaId];
        }

        // // RVA: 0x13AD4C4 Offset: 0x13AD4C4 VA: 0x13AD4C4
        // public bool IsUseVuforia() { }
    }
}