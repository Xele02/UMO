
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UdonLib;
using UnityEngine;

namespace XeApp.Game.AR
{
    public enum ARSnsType
    {
        None = -1,
        Twitter = 0,
        Line = 1,
        Num = 2,
    }

    public class ARTakePhoto : MonoBehaviour
    {
        private const int CANVAS_WIDTH = 792;
        private const int CANVAS_HEIGHT = 1184;
        private const int HEADER_HEIGHT = 100;
        private bool m_isBusy; // 0xC
        private DeviceOrientation m_devOri = DeviceOrientation.Portrait; // 0x10
        private static ARTakePhoto ms_instance; // 0x0
        private string m_imageSavedPath = ""; // 0x14
        private Camera m_photoCamera; // 0x18
        private bool m_savedPictureFlag; // 0x1C
        private ARMarkerMasterData.Data m_currData; // 0x20
        private const int ERROR_TYPE_NO_PERMISSION = 1;
        private const int ERROR_TYPE_NOT_ABAILABLE_STORAGE = 2;
        private Texture2D SynthesisTexture; // 0x24
        public RenderTexture m_currPhotoRenderTexture; // 0x28

        // RVA: 0x13A9878 Offset: 0x13A9878 VA: 0x13A9878
        private void Awake()
        {
            ms_instance = this;
        }

        // // RVA: 0x13A9908 Offset: 0x13A9908 VA: 0x13A9908
        public static ARTakePhoto GetInstance()
        {
            return ms_instance;
        }

        // RVA: 0x13A9994 Offset: 0x13A9994 VA: 0x13A9994
        private void Start()
        {
            return;
        }

        // RVA: 0x13A9998 Offset: 0x13A9998 VA: 0x13A9998
        private void Update()
        {
            if(Input.deviceOrientation > DeviceOrientation.Unknown && Input.deviceOrientation <= DeviceOrientation.LandscapeRight)
                m_devOri = Input.deviceOrientation;
        }

        // // RVA: 0x13A99D8 Offset: 0x13A99D8 VA: 0x13A99D8
        public DeviceOrientation GetDeviceOrientation()
        {
            return m_devOri;
        }

        // RVA: 0x13A99E0 Offset: 0x13A99E0 VA: 0x13A99E0
        public bool IsBusy()
        {
            return m_isBusy;
        }

        // RVA: 0x13A99E8 Offset: 0x13A99E8 VA: 0x13A99E8
        public void Shutter()
        {
            this.StartCoroutineWatched(CoTakePhoto());
        }

        // [IteratorStateMachineAttribute] // RVA: 0x678D04 Offset: 0x678D04 VA: 0x678D04
        // // RVA: 0x13A9A0C Offset: 0x13A9A0C VA: 0x13A9A0C
        private IEnumerator CoTakePhoto()
        {
            Texture2D tex; // 0x18
            Color endColor; // 0x1C
            Color startColor; // 0x2C
            Texture2D tex3; // 0x3C
            byte[] bytes; // 0x40
            long photoSizeKb; // 0x48
            string fname; // 0x50
            bool photoDone; // 0x54
            int errorType; // 0x58
            bool photo_permission_ok; // 0x5C
            int i; // 0x60
            ARPhotoMenu photoMenu; // 0x64

            //0x13ABB18
            m_isBusy = true;
            ARMenuManager.Instance.SetEnableOperate(false);
            VuforiaManager.Instance.StopCamera();
            VuforiaManager.Instance.SuspendDivaControl();
            if(Application.platform == RuntimePlatform.IPhonePlayer)
            {
                IOSBridge.PlayShutterSound();
            }
            else if(Application.platform == RuntimePlatform.Android)
            {
                AndroidUtils.PlayShutterSound();
            }
            takePhotoJustNow();
            m_currData = VuforiaManager.Instance.GetCurrentTargettingData();
            yield return new WaitForEndOfFrame();
            VuforiaManager.Instance.ChangeCanvasTarget();
            Vector2 r = GetComponent<RectTransform>().sizeDelta;
            m_currPhotoRenderTexture = new RenderTexture((int)r.x, (int)r.y, 24, RenderTextureFormat.ARGB32);
            m_currPhotoRenderTexture.Create();
            tex = new Texture2D((int)r.x, (int)r.y, TextureFormat.RGB24, false, false);
            VuforiaManager.Instance.RenderPhotoTexture(m_currPhotoRenderTexture, tex);
            endColor = Color.white;
            startColor = Color.white;
            startColor.a = 0;
            GameManager.Instance.fullscreenFader.Fade(0.1f, startColor, endColor);
            yield return GameManager.Instance.WaitFadeYielder;
            yield return null;
            yield return null;
            tex3 = FlipTexture2D(tex);
            bytes = ImageConversion.EncodeToJPG(tex3, 100);
            photoSizeKb = bytes.Length / 1024 + 1;
            yield return null;
            fname = "Photo" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".jpg";
            m_imageSavedPath = "";
            errorType = 0;
            photoDone = false;
            if(Application.platform != RuntimePlatform.IPhonePlayer)
            {
                long l = AndroidUtils.GetAvailableStorageKB;
                if(photoSizeKb >= l)
                {
                    errorType = 2;
                    photoDone = false;
                    //>LAB_013ac72c;
                }
                else
                {
                    photo_permission_ok = false;
                    if(AndroidUtils.CheckSelfPermission(AndroidPermission.WRITE_EXTERNAL_STORAGE))
                    {
                        photo_permission_ok = true;
                        //LAB_013acebc;
                    }
                    else
                    {
                        int requestResult = 0;
                        AndroidPermissionReceiver.Instance.RequestPremission(AndroidPermission.WRITE_EXTERNAL_STORAGE, () =>
                        {
                            //0x13ABAFC
                            requestResult = 1;
                        }, () =>
                        {
                            //0x13ABB08
                            requestResult = 2;
                        });
                        //LAB_013ac490
                        while(requestResult == 0)
                            yield return null;
                        if(requestResult != 1)
                        {
                            ARMenuManager.Instance.SetSelectWindow(Messages.GetSel(SelMsgID.AT_STORAGE, true, false), true);
                            yield return null;
                            while(ARMenuManager.Instance.GetSelectWindowResult() == 0)
                                yield return null;
                            if(ARMenuManager.Instance.GetSelectWindowResult() == SelWinRslt.YES)
                            {
                                AndroidUtils.RedirectSystemSettings();
                                for(i = 0; i < 10; i++)
                                {
                                    Debug.LogError("[MCRS]loop." + i);
                                    yield return null;
                                }
                            }
                            //LAB_013ac56c;
                            Debug.Log("[MCRS] Storage:" + AndroidUtils.CheckSelfPermission(AndroidPermission.WRITE_EXTERNAL_STORAGE) + " / Camera:" + AndroidUtils.CheckSelfPermission(AndroidPermission.CAMERA));
                            if(AndroidUtils.CheckSelfPermission(AndroidPermission.WRITE_EXTERNAL_STORAGE))
                            {
                                //LAB_013ac650
                                photo_permission_ok = true;
                            }
                            else
                            {
                                if(!photo_permission_ok)
                                {
                                    //LAB_013acf18
                                    errorType = 1;
                                    photoDone = false;
                                    //>LAB_013ac72c;
                                }
                                else
                                {
                                    //>LAB_013acca4
                                }
                            }
                        }
                        else
                        {
                            //LAB_013ac650
                            photo_permission_ok = true;
                        }
                    }
                    if(photo_permission_ok)
                    {
                        //LAB_013acca4
                        m_imageSavedPath = GetPhotoSavePath() + fname;
                        File.WriteAllBytes(m_imageSavedPath, bytes);
                        yield return null;
                        ScanMedia(m_imageSavedPath);
                        photoDone = true;
                        //>LAB_013ac72c/
                    }
                }
            }
            else
            {
                /*long l2 = IOSBridge.GetAvailableStorageKB();
                if(l2 >= 51201 && photoSizeKb * 2 < l2)
                {
                    photo_permission_ok = false;
                    int a = IOSBridge.GetPhotoAuthorizationStatus();
                    if(a == 2)
                    {
                        //LAB_013ac3ec
                        while(IOSBridge.GetAuthorizationResult() == 2)
                            yield return null;
                        if(IOSBridge.GetPhotoAuthorizationStatus() == 0)
                            photo_permission_ok = true;
                        else
                        {
                            //LAB_013accd8
                            if(!photo_permission_ok)
                            {
                                ARMenuManager.Instance.SetSelectWindow(Messages.GetSel(SelMsgID.AT_STORAGE, true, false), true);
                                yield return null;
                                while(ARMenuManager.Instance.GetSelectWindowResult() == SelWinRslt.WAITING)
                                    yield return null;
                                if(ARMenuManager.Instance.GetSelectWindowResult() == SelWinRslt.YES)
                                {
                                    IOSBridge.RedirectSystemSettings();
                                    //LAB_013ac444
                                    for(i = 0; i < 10; i++)
                                    {
                                        yield return null;
                                    }
                                }
                                //LAB_013ac424
                                if(IOSBridge.GetPhotoAuthorizationStatus() == 0)
                                {
                                    photo_permission_ok = true;
                                    LAB_013ad0dc;
                                }
                                else
                                {
                                    if(photo_permission_ok)
                                        LAB_013ad0cc
                                    else
                                    {
                                        errorType = 1;
                                        photoDone = false;
                                        LAB_013ac72c
                                    }
                                }
                            }
                        }
                        //LAB_013ad0cc;
                        //>LAB_013ad0dc
                    }
                    if(a != 0)
                        LAB_013accd8;
                    photo_permission_ok = true;
                    //LAB_013ad0dc
                    m_savedPictureFlag = false;
                    IOSBridge.SavePictureIOS(fname, bytes);
                    yield return null;
                    m_imageSavedPath = Application.persistentDataPath + "/arphoto.jpg";
                    File.WriteAllBytes(m_imageSavedPath, bytes);
                    while(!m_savedPictureFlag)
                        yield return null;
                    //LAB_013ac724;
                    photoDone = true;
                }
                else
                {
                    photoDone = false;
                    errorType = 2;
                }*/
                TodoLogger.LogError(0, "IOS");
            }
            //LAB_013ac72c
            VuforiaManager.Instance.ResetCanvasTarget();
            yield return null;
            GameManager.Instance.fullscreenFader.Fade(0.1f, endColor, startColor);
            yield return GameManager.Instance.WaitFadeYielder;
            yield return null;
            if(photoDone)
            {
                photoMenu = ARMenuManager.Instance.photoMenu;
                photoMenu.SetSNSCallback(OnCallbackButtonShare);
                photoMenu.photoImage.texture = tex3;
                RectTransform r2 = photoMenu.photoImage.GetComponent<RectTransform>();
                if(r2 != null)
                {
                    r2.sizeDelta = new Vector2(((r2.sizeDelta.y * 1.0f * tex3.width) / tex3.height) * 1.01f, r2.sizeDelta.y);
                }
                photoMenu.Open();
                ARMenuManager.Instance.SetMessageWindow(Messages.Get(MessageID.SAVED_PHOTO));
                yield return null;
                while(ARMenuManager.Instance.IsDisplayMessageWindow(null))
                    yield return null;
                ARMenuManager.Instance.SetEnableOperate(true);
                if(m_currData == null)
                {
                    ILCCJNDFFOB.HHCJCDFCLOB.KIFPDEFNEPB(GameManager.Instance.ar_session_id, 0, null, null);
                }
                else
                {
                    ILCCJNDFFOB.HHCJCDFCLOB.KIFPDEFNEPB(GameManager.Instance.ar_session_id, m_currData.no, m_currData.eventId, m_currData.markerId);
                }
                while(photoMenu.IsOpen)
                    yield return null;
                photoMenu = null;
            }
            else
            {
                if(errorType == 2)
                {
                    ARMenuManager.Instance.SetMessageWindow(Messages.Get(MessageID.ERR_NOT_ABAILABLE_STORAGE));
                }
                else if(errorType == 1)
                {
                    ARMenuManager.Instance.SetMessageWindow(Messages.Get(MessageID.ERR_NO_PERMISSION_STORAGE));
                }
                yield return null;
                while(ARMenuManager.Instance.IsDisplayMessageWindow(null))
                    yield return null;
                ARMenuManager.Instance.SetEnableOperate(true);
            }
            //LAB_013ad324
            VuforiaManager.Instance.StartCamera();
            VuforiaManager.Instance.ResumeDivaControl();
            m_isBusy = false;
        }

        // // RVA: 0x13A9AB8 Offset: 0x13A9AB8 VA: 0x13A9AB8
        private void OnCallbackButtonShare()
        {
            Debug.Log("Share");
            if(!string.IsNullOrEmpty(m_imageSavedPath))
            {
                if(VuforiaManager.Instance != null)
                {
                    if(m_currData == null)
                    {
                        ILCCJNDFFOB.HHCJCDFCLOB.PHLHLIDCNNN(GameManager.Instance.ar_session_id, 0, null, null);
                    }
                    else
                    {
                        ILCCJNDFFOB.HHCJCDFCLOB.PHLHLIDCNNN(GameManager.Instance.ar_session_id, m_currData.no, m_currData.eventId, m_currData.markerId);
                    }
                    AndroidUtils.OnShare(m_imageSavedPath, GetSnsMessageOnEvent(0), JpStringLiterals2.StringLiteral_13083);
                }
            }
        }

        // // RVA: 0x13AA10C Offset: 0x13AA10C VA: 0x13AA10C
        // private void OnCallbackButtonTwitter() { }

        // // RVA: 0x13AA274 Offset: 0x13AA274 VA: 0x13AA274
        // private void OnCallbackButtonLINE() { }

        // // RVA: 0x13A9E80 Offset: 0x13A9E80 VA: 0x13A9E80
        private string GetSnsMessageOnEvent(ARSnsType snsType)
        {
            if(VuforiaManager.Instance != null)
            {
                if(VuforiaManager.Instance.LastFoundARMarkerMasterData != null)
                {
                    List<AREventMasterData.Data> l = AREventMasterData.Instance.GetEventList(false);
                    for(int i = 0; i < l.Count; i++)
                    {
                        if(l[i].enable == 2 && l[i].eventId == VuforiaManager.Instance.LastFoundARMarkerMasterData.eventId)
                        {
                            return l[i].snsTemplateTable[(int)snsType];
                        }
                    }
                }
            }
            return "";
        }

        // // RVA: 0x13AA3E4 Offset: 0x13AA3E4 VA: 0x13AA3E4
        private void takePhotoJustNow()
        {
            ARPhotoLogo p = FindObjectOfType(typeof(ARPhotoLogo)) as ARPhotoLogo;
            if(p != null)
                p.ResetAngle();
        }

        // // RVA: 0x13AA588 Offset: 0x13AA588 VA: 0x13AA588
        private string GetPhotoSavePath()
        {
            string path;
            if(Application.platform == RuntimePlatform.Android)
            {
                AndroidJavaClass c = new AndroidJavaClass("android.os.Environment");
                AndroidJavaObject s = c.CallStatic<AndroidJavaObject>("getExternalStoragePublicDirectory", c.GetStatic<string>("DIRECTORY_PICTURES"));
                path = s.Call<string>("getAbsolutePath", Array.Empty<object>());
                path += "/UtaMacross/";
                s.Dispose();
                c.Dispose();
            }
            else
            {
                path = Application.dataPath + "/../Photo/";
            }
            if(!string.IsNullOrEmpty(path) && !Directory.Exists(path))
                Directory.CreateDirectory(path);
            return path;
        }

        // // RVA: 0x13AA950 Offset: 0x13AA950 VA: 0x13AA950
        public static void ScanMedia(string path)
        {
            if(Application.platform == RuntimePlatform.Android)
            {
                AndroidJavaClass c = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                AndroidJavaObject s = c.GetStatic<AndroidJavaObject>("currentActivity");
                AndroidJavaObject s2 = s.Call<AndroidJavaObject>("getApplicationContext");
                AndroidJavaClass c2 = new AndroidJavaClass("android.media.MediaScannerConnection");
                c2.CallStatic("scanFile", new object[4]
                {
                    s2, new string[1] { path }, new string[1] { "image/png" }, null
                });
                c2.Dispose();
                s2.Dispose();
                s.Dispose();
                c.Dispose();
            }
        }

        // // RVA: 0x13AB15C Offset: 0x13AB15C VA: 0x13AB15C
        // private Texture2D rotateTexture2D(Texture2D tex, DeviceOrientation devOri) { }

        // // RVA: 0x13AB640 Offset: 0x13AB640 VA: 0x13AB640
        public Texture2D FlipTexture2D(Texture2D tex)
        {
            Color32[] cols = tex.GetPixels32();
            Color32[] newCols = new Color32[cols.Length];
            int w = tex.width;
            int h = tex.height;
            if(VuforiaManager.Instance.IsFlip)
            {
                for(int i = 0; i < h; i++)
                {
                    for(int j = 0; j < w; j++)
                    {
                        newCols[i * w + j] = cols[i * w + w - 1 - j];
                    }
                }
                Texture2D res = new Texture2D(w, h, tex.format, false);
                res.SetPixels32(newCols);
                res.Apply();
                return res;
            }
            return tex;
        }

        // // RVA: 0x13AB948 Offset: 0x13AB948 VA: 0x13AB948
        // private Color32 blendColor(Color32 back, Color32 logo, byte alpha) { }

        // // RVA: 0x13AB9CC Offset: 0x13AB9CC VA: 0x13AB9CC
        // public void DidImageWriteToAlbum(string message) { }
    }
}