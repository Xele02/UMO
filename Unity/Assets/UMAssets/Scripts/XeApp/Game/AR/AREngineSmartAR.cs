
using System.Collections;
using System.Collections.Generic;
using System.IO;
using smartar;
using UnityEngine;
using XeApp.Core;

namespace XeApp.Game.AR
{
    public class AREngineSmartAR : AREngineBase
    {
        private GameObject m_arCameraObj; // 0x14
        private SmartARController m_arCont; // 0x18
        private GameObject m_arDivaCamObj; // 0x1C
        private GameObject m_arCanvasCamObj; // 0x20
        private bool m_loadDataSetDone; // 0x24
        private Facing m_currFacing; // 0x28
        private bool m_setupedFlag; // 0x2C
        private ulong m_cameraFrameCount; // 0x30
        private List<string> m_markerNameList = new List<string>(); // 0x38
        private List<TargetEffector> m_targetList = new List<TargetEffector>(); // 0x3C

        // RVA: 0x11CF840 Offset: 0x11CF840 VA: 0x11CF840
        public AREngineSmartAR(VuforiaManager vm)
            : base(vm)
        {
            //
        }

        // [IteratorStateMachineAttribute] // RVA: 0x6783A4 Offset: 0x6783A4 VA: 0x6783A4
        // RVA: 0x11CF908 Offset: 0x11CF908 VA: 0x11CF908 Slot: 4
        public override IEnumerator CoInitialize()
        {
            //0x11D11D0
            m_initializeOk = false;
            m_initializeOk = true;
            yield break;
        }

        // RVA: 0x11CF9B4 Offset: 0x11CF9B4 VA: 0x11CF9B4 Slot: 5
        public override IEnumerator CoLoadMarkerData(AssetBundleLoadAllAssetOperationBase op)
        {
            return CoSetup(0, true, op);
        }

        // [IteratorStateMachineAttribute] // RVA: 0x67841C Offset: 0x67841C VA: 0x67841C
        // RVA: 0x11CF9D8 Offset: 0x11CF9D8 VA: 0x11CF9D8
        private IEnumerator CoSetup(Facing cameraFacing, bool createTarget = false, AssetBundleLoadAllAssetOperationBase op = null)
        {
            string dataset_local_path; // 0x20
            List<ARMarkerMasterData.Data> list; // 0x24
            int i; // 0x28

            //0x11D12D0
            m_setupedFlag = false;
            m_cameraFrameCount = 0;
            dataset_local_path = Application.persistentDataPath + "/ardata";
            if(createTarget && op != null)
            {
                if(!Directory.Exists(dataset_local_path))
                    Directory.CreateDirectory(dataset_local_path);
                string[] strs = Directory.GetFiles(dataset_local_path);
                for(i = 0; i < strs.Length; i++)
                {
                    if(strs[i].EndsWith(".dic"))
                    {
                        File.Delete(strs[i]);
                    }
                }
                yield return null;
                list = ARMarkerMasterData.Instance.GetMarkerList(true);
                for(i = 0; i < list.Count; i++)
                {
                    if(list[i].enable != 0)
                    {
                        if(list[i].enable != 1)
                        {
                            TextAsset asset = op.GetAsset<TextAsset>(list[i].markerId + "_dic");
                            if(asset != null)
                            {
                                //code_r0x011d16e4
                                if(!CheckAvailableStorageKB(asset.bytes.Length >> 10 + 1))
                                {
                                    m_errorStatus = VuforiaManager.ERROR_TYPE.NO_SPACE_FOR_DATASET;
                                    yield break;
                                }
                                string path = dataset_local_path + "/" + list[i].markerId + ".dic";
                                File.WriteAllBytes(path, asset.bytes);
                                m_markerNameList.Add(list[i].markerId);
                                yield return null;
                            }
                        }
                    }
                }
                list = null;
                //>LAB_011d1838
            }
            //LAB_011d1838
            m_arCameraObj = new GameObject("SmartARCamera");
            if(m_arCameraObj != null)
            {
                Camera c = m_arCameraObj.AddComponent<Camera>();
                if(c != null)
                {
                    c.clearFlags = CameraClearFlags.Depth;
                    c.backgroundColor = Color.black;
                    c.cullingMask = 0;
                    c.nearClipPlane = 2;
                    c.farClipPlane = 5000;
                    c.depth = 0;
                }
                m_arCont = m_arCameraObj.AddComponent<SmartARController>();
                m_arCameraObj.AddComponent<SmartAREffector>();
            }
            Camera c2 = m_arCameraObj.GetComponent<Camera>();
            if(c2 != null)
                c2.cullingMask = 0;
            m_arCont.SetDictDataPath(dataset_local_path);
            if(m_markerNameList.Count > 0)
            {
                SmartARControllerBase.TargetEntry[] t = new SmartARControllerBase.TargetEntry[m_markerNameList.Count];
                for(i = 0; i < m_markerNameList.Count; i++)
                {
                    t[i] = new SmartARControllerBase.TargetEntry() { fileName = m_markerNameList[i] + ".dic", id = m_markerNameList[i] };
                }
                SmartARControllerBase.RecognizerSettings setting = new SmartARControllerBase.RecognizerSettings();
                setting.recognitionMode = 0;
                setting.sceneMappingInitMode = 0;
                setting.targets = t;
                if(AREventMasterData.Instance.GetIntParam("smart_ar_init_mode", 0) == 1)
                    setting.recognitionMode = RecognitionMode.RECOGNITION_MODE_SCENE_MAPPING;
                m_arCont.recognizerSettings_ = setting;
                int a = 0;
                m_arCont.getCameraId(cameraFacing, out a);
                m_currFacing = cameraFacing;
                SmartARController.CameraDeviceSettings setting2 = new SmartARController.CameraDeviceSettings();
                setting2.cameraId = a;
                setting2.videoImageSize = new UnityEngine.Vector2(640, 480);
                setting2.focusMode = FocusMode.FOCUS_MODE_CONTINUOUS_AUTO_VIDEO;
                m_arCont.cameraDeviceSettings_ = setting2;
            }
            if(!createTarget)
            {
                for(i = 0; i < m_targetList.Count; i++)
                {
                    if(m_targetList[i] != null)
                    {
                        m_targetList[i].SetSmartARController(m_arCont);
                    }
                }
                SmartAREffector smartArEffector = m_arCont.GetComponent<SmartAREffector>();
                if(smartArEffector != null)
                {
                    smartArEffector.SetTargetEffectors(m_targetList.ToArray());
                }
            }
            if(m_arCont.smart_.isConstructorFailed())
            {
                m_errorStatus = VuforiaManager.ERROR_TYPE.SMARTAR_INIT_ERROR;
                yield break;
            }
            while(!m_arCont.enabled_)
                yield return null;
                
            if(!m_arCont.smart_.isConstructorFailed())
            {
                if(m_arDivaCamObj == null)
                {
                    m_arDivaCamObj = new GameObject("DivaCamera");
                    if(m_arDivaCamObj != null)
                    {
                        Camera cam = m_arDivaCamObj.AddComponent<Camera>();
                        if(cam != null)
                        {
                            cam.nearClipPlane = 0.1f;
                            cam.farClipPlane = 500;
                            cam.cullingMask = 1 << LayerMask.NameToLayer("Singer");
                            cam.depth = 1;
                            cam.clearFlags = CameraClearFlags.Depth;
                        }
                        m_arDivaCamObj.AddComponent<ARDivaCamera>();
                    }
                }
                if(m_arDivaCamObj != null)
                {
                    ARDivaCamera divaCam = m_arDivaCamObj.GetComponent<ARDivaCamera>();
                    if(divaCam != null)
                    {
                        divaCam.SetARCamera(m_arCont.transform);
                        divaCam.SetCameraSide(cameraFacing);
                    }
                }
                if(m_arCanvasCamObj == null)
                {
                    m_arCanvasCamObj = new GameObject("CanvasCamera");
                    if(m_arCanvasCamObj != null)
                    {
                        Camera cam = m_arCanvasCamObj.AddComponent<Camera>();
                        if(cam != null)
                        {
                            cam.nearClipPlane = 0.1f;
                            cam.farClipPlane = 500;
                            cam.cullingMask = 1 << LayerMask.NameToLayer("UI");
                            cam.depth = 2;
                            cam.clearFlags = CameraClearFlags.Depth;
                        }
                    }
                }
                m_setupedFlag = true;
                m_loadDataSetDone = true;
                yield return null;
            }
            else
            {
                m_errorStatus = VuforiaManager.ERROR_TYPE.SMARTAR_INIT_ERROR;
            }
        }

        // RVA: 0x11CFAD0 Offset: 0x11CFAD0 VA: 0x11CFAD0 Slot: 6
        public override Camera GetARCamera()
        {
            if(m_arDivaCamObj != null)
                return m_arDivaCamObj.GetComponent<Camera>();
            return null;
        }

        // RVA: 0x11CFB9C Offset: 0x11CFB9C VA: 0x11CFB9C Slot: 7
        public override Camera GetCanvasCamera()
        {
            if(m_arCanvasCamObj != null)
                return m_arCanvasCamObj.GetComponent<Camera>();
            return null;
        }

        // // RVA: 0x11CFC68 Offset: 0x11CFC68 VA: 0x11CFC68
        private GameObject createSmartARTargetObj(string targetId)
        {
            GameObject g = new GameObject(targetId);
            if(g != null)
            {
                g.AddComponent<TargetEffector>();
            }
            return g;
        }

        // [IteratorStateMachineAttribute] // RVA: 0x678494 Offset: 0x678494 VA: 0x678494
        // RVA: 0x11CFD48 Offset: 0x11CFD48 VA: 0x11CFD48 Slot: 9
        public override IEnumerator StartTracking()
        {
            //0x11D2F3C
            for(int i = 0; i < m_markerNameList.Count; i++)
            {
                GameObject g = createSmartARTargetObj(m_markerNameList[i]);
                TargetEffector t = g.GetComponent<TargetEffector>();
                if(t != null)
                {
                    t.targetID = m_markerNameList[i];
                    t.SetSmartARController(m_arCont);
                    m_targetList.Add(t);
                }
            }
            SmartAREffector smae = m_arCont.GetComponent<SmartAREffector>();
            if(smae != null)
            {
                smae.SetTargetEffectors(m_targetList.ToArray());
            }
            while(!m_arCont.enabled_)
                yield return null;
        }

        // RVA: 0x11CFDF4 Offset: 0x11CFDF4 VA: 0x11CFDF4 Slot: 10
        public override void SetupTrackingMode(GameObject trackingObj, int trackingType)
        {
            return;
        }

        // RVA: 0x11CFDF8 Offset: 0x11CFDF8 VA: 0x11CFDF8 Slot: 11
        public override void StopExtendedTracking(GameObject trackingObj)
        {
            return;
        }

        // [IteratorStateMachineAttribute] // RVA: 0x67850C Offset: 0x67850C VA: 0x67850C
        // RVA: 0x11CFDFC Offset: 0x11CFDFC VA: 0x11CFDFC Slot: 12
        // public override IEnumerator CoChangeCameraSide() { }

        // RVA: 0x11CFEA8 Offset: 0x11CFEA8 VA: 0x11CFEA8 Slot: 13
        public override void StopTracking(GameObject currTrackingObj)
        {
            return;
        }

        // RVA: 0x11CFEAC Offset: 0x11CFEAC VA: 0x11CFEAC Slot: 14
        public override void RestartTracking()
        {
            if(m_arCont != null)
            {
                m_arCont.StopController();
                m_arCont.RestartController();
            }
        }

        // RVA: 0x11CFF80 Offset: 0x11CFF80 VA: 0x11CFF80 Slot: 15
        // public override void FinishProcess() { }

        // RVA: 0x11CFF84 Offset: 0x11CFF84 VA: 0x11CFF84 Slot: 16
        public override void RenderPhotoTexture(RenderTexture rt, Texture2D photoTexture)
        {
            RenderTexture prev = RenderTexture.active;
            RenderTexture.active = rt;
            Camera c = m_arCameraObj.GetComponent<Camera>();
            c.targetTexture = rt;
            c.Render();
            c.targetTexture = null;
            c = m_arDivaCamObj.GetComponent<Camera>();
            c.targetTexture = rt;
            c.Render();
            c.targetTexture = null;
            c = m_arCanvasCamObj.GetComponent<Camera>();
            Matrix4x4 mat = c.projectionMatrix;
            if(m_currFacing == Facing.FACING_FRONT)
            {
                GL.invertCulling = true;
                Matrix4x4 mat2 = Matrix4x4.Scale(new UnityEngine.Vector3(-1, 1, 1));
                c.projectionMatrix = mat * mat2;
            }
            c.targetTexture = rt;
            c.Render();
            c.targetTexture = null;
            if(m_currFacing == Facing.FACING_FRONT)
            {
                c.projectionMatrix = mat;
                GL.invertCulling = false;
            }
            photoTexture.ReadPixels(new Rect(0, 0, photoTexture.width, photoTexture.height), (rt.width - photoTexture.width) / 2, 0);
            photoTexture.Apply();
            RenderTexture.active = prev;
        }

        // // RVA: 0x11D0714 Offset: 0x11D0714 VA: 0x11D0714
        // private static float CM2MCR(float cm) { }

        // RVA: 0x11D072C Offset: 0x11D072C VA: 0x11D072C Slot: 17
        public override void SetCurrentMasterData(ARMarkerMasterData.Data data)
        {
            float f = 1;
            if(m_arCont != null)
            {
                for(int i = 0; i < m_arCont.recognizerSettings_.targets.Length; i++)
                {
                    if(m_arCont.recognizerSettings_.targets[i] != null)
                    {
                        if(m_arCont.recognizerSettings_.targets[i].id == data.markerId)
                        {
                            smartar.Vector2 v;
                            m_arCont.targets_[i].GetPhysicalSize(out v);
                            Camera c = m_arCameraObj.GetComponent<Camera>();
                            if(c == null)
                                f = 1;
                            else
                                f = v.x_ * c.nearClipPlane * 1000;
                            break;
                        }
                    }
                }
            }
            if(data.divaHeight <= 0)
            {
                f = f / data.imageWidth * 0.09999999f;
            }
            f = data.divaHeight * ((f / (data.imageWidth * 0.09999999f)) / VuforiaManager.GetCharaModelHeight(data.divaId));
            ARDivaCamera.SetARImageScale(f);
        }

        // RVA: 0x11D0B0C Offset: 0x11D0B0C VA: 0x11D0B0C Slot: 18
        public override void StartCamera()
        {
            if(m_arCont != null)
            {
                m_arCanvasCamObj.SetActive(true);
            }
        }

        // RVA: 0x11D0BC4 Offset: 0x11D0BC4 VA: 0x11D0BC4 Slot: 19
        public override void StopCamera()
        {
            if(m_arCont != null)
            {
                m_arCanvasCamObj.SetActive(false);
            }
        }

        // RVA: 0x11D0C7C Offset: 0x11D0C7C VA: 0x11D0C7C Slot: 20
        public override UnityEngine.Quaternion GetDivaOffsetRotation()
        {
            if(m_currFacing != 0)
                return UnityEngine.Quaternion.Euler(0, 180, 0);
            return UnityEngine.Quaternion.identity;
        }

        // RVA: 0x11D0D5C Offset: 0x11D0D5C VA: 0x11D0D5C Slot: 21
        public override bool CheckError()
        {
            if(m_arCont != null)
            {
                int code = m_arCont.smart_.getInitResultCode();
                if(code == 0)
                {
                    if(!m_setupedFlag)
                        return false;
                    if(m_cameraFrameCount == 0 || m_cameraFrameCount != m_arCont.cameraFrameCount_)
                    {
                        m_cameraFrameCount = m_arCont.cameraFrameCount_;
                        return false;
                    }
                    Debug.LogError("SMART AR : ERROR!!! camera frame not adding. " + m_arCont.cameraFrameCount_);
                }
                else
                {
                    Debug.LogError("SMART AR : ERROR!!! = 0x" + code.ToString("X"));
                }
                return true;
            }
            return false;
        }
    }
}