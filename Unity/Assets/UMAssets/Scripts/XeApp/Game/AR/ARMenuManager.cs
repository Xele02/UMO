
using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using XeApp.Core;
using XeSys;

namespace XeApp.Game.AR
{
    public enum SelWinRslt
    {
        WAITING = 0,
        NO = 1,
        YES = 2,
    }

    public class ARMenuManager : MonoBehaviour
    {
        [SerializeField]
        private ARHeaderMenu m_header; // 0xC
        [SerializeField]
        private ARTopMenu m_topMenu; // 0x10
        [SerializeField]
        private ARPhotoMenu m_photoMenu; // 0x14
        [SerializeField]
        private ARHelpMenu m_helpMenu; // 0x18
        [SerializeField]
        private ARCollectionMenu m_collectionMenu; // 0x1C
        [SerializeField]
        private Button m_shutterButton; // 0x20
        [SerializeField]
        private Button m_resetButton; // 0x24
        [SerializeField]
        private ARPauseButton m_pauseButton; // 0x28
        [SerializeField]
        private ARRecognitionIcon m_recoIcon; // 0x2C
        [SerializeField]
        private ARRecognitionText m_recoText; // 0x30
        [SerializeField]
        private ARAwayText m_awayText; // 0x34
        [SerializeField]
        private Image m_partitionImage; // 0x38
        [SerializeField]
        private ARAcquireMarker m_acquireMarker; // 0x3C
        [SerializeField]
        private ExpiredWindow m_expiredWindow; // 0x40
        private ARIconTextureCache m_arIconCache; // 0x44
        private bool m_isInitialized; // 0x4C
        private bool m_isShowMenu; // 0x4D
        private GameObject m_messageWindowPref; // 0x50
        private GameObject m_messageWindowObj; // 0x54
        private GameObject m_selectWindowPref; // 0x58
        private GameObject m_buttonWindowPref; // 0x5C
        public float safeContentScale = 1; // 0x60

        public static ARMenuManager Instance { get; private set; } // 0x0
        public ARHeaderMenu headerMenu { get { return m_header; } } //0x11DFC94
        // public ARTopMenu topMenu { get; } 0x11DFC9C
        public ARPhotoMenu photoMenu { get { return m_photoMenu; } } //0x11DFCA4
        public ARHelpMenu helpMenu { get{
            return m_helpMenu;
        } } //0x11DFCAC
        public ARCollectionMenu collectionMenu { get { return m_collectionMenu; } } //0x11DFCB4
        // public Button shutterButton { get; } 0x11DFCBC
        public UnityAction OnClickShutterButton { set
        {
            m_shutterButton.onClick.RemoveAllListeners();
            m_shutterButton.onClick.AddListener(value);
        } } //0x11DFCC4
        public Button resetButton { get { return m_resetButton; } } //0x11DFD5C
        public UnityAction OnClickResetButton { set {
            m_resetButton.onClick.RemoveAllListeners();
            m_resetButton.onClick.AddListener(value);
        } } //0x11DFD64
        public ARPauseButton pauseButton { get { return m_pauseButton; } } //0x11CD390
        public ARRecognitionIcon recoIcon { get { return m_recoIcon; } } //0x11DFDFC
        public ARRecognitionText recoText { get { return m_recoText; } } //0x11DFE04
        public ARAwayText awayText { get { return m_awayText; } } //0x11DFE0C
        public ARAcquireMarker acquireMarker { get { return m_acquireMarker; } } //0x11DFE14
        public ExpiredWindow expiredWindow { get { return m_expiredWindow; } } //0x11DFE1C
        public ARIconTextureCache arIconCache { get { return m_arIconCache; } } //0x11D898C
        public UnityAction OnClickEndButton { get; set; } // 0x48
        // public GameObject messageWindowPref { set; } 0x11DFE34
        // public GameObject selectWindowPref { set; } 0x11DFE3C
        // public GameObject buttonWindowPref { set; } 0x11DFE44

        // [IteratorStateMachineAttribute] // RVA: 0x67A164 Offset: 0x67A164 VA: 0x67A164
        // // RVA: 0x11DFE4C Offset: 0x11DFE4C VA: 0x11DFE4C
        public static IEnumerator Co_Load(Transform parent, Canvas photoCanvas)
        {
            string bundleName; // 0x18
            AssetBundleLoadAllAssetOperationBase op; // 0x1C

            //0x11E2000
            bundleName = "ar/ui.xab";
            op = AssetBundleManager.LoadAllAssetAsync(bundleName);
            yield return op;
            GameObject g = Instantiate(op.GetAsset<GameObject>("ARMenuManager"), parent, false);
            ARMenuManager menuMgr = g.GetComponent<ARMenuManager>();
            g = Instantiate(op.GetAsset<GameObject>("PhotoLogo"), photoCanvas.transform.Find("SafeAreaOffSet"), false);
            SetupSafeScreen(menuMgr.gameObject, photoCanvas.transform.Find("SafeAreaOffSet").gameObject, menuMgr);
            menuMgr.m_helpMenu.imagePrefab = op.GetAsset<GameObject>("OverlayImage");
            menuMgr.m_collectionMenu.eventInfoPrefab = op.GetAsset<GameObject>("EventInfo");
            menuMgr.m_collectionMenu.stampPrefab = op.GetAsset<GameObject>("StampObject");
            menuMgr.m_collectionMenu.stampGroupPrefab = op.GetAsset<GameObject>("StampGroup");
            menuMgr.m_messageWindowPref = op.GetAsset<GameObject>("MessageWindow");
            menuMgr.m_selectWindowPref = op.GetAsset<GameObject>("SelectWindow");
            menuMgr.m_buttonWindowPref = op.GetAsset<GameObject>("ButtonWindow");
            AssetBundleManager.UnloadAssetBundle(bundleName, false);
            yield return null;
        }

        // RVA: 0x11DFF14 Offset: 0x11DFF14 VA: 0x11DFF14
        public void Awake()
        {
            Instance = this;
            m_arIconCache = new ARIconTextureCache();
        }

        // RVA: 0x11DFFDC Offset: 0x11DFFDC VA: 0x11DFFDC
        public void OnDestroy()
        {
            m_arIconCache.Terminated();
        }

        // RVA: 0x11E0010 Offset: 0x11E0010 VA: 0x11E0010
        public void Start()
        {
            this.StartCoroutineWatched(Co_Initialize());
        }

        // [IteratorStateMachineAttribute] // RVA: 0x67A1DC Offset: 0x67A1DC VA: 0x67A1DC
        // // RVA: 0x11E0034 Offset: 0x11E0034 VA: 0x11E0034
        private IEnumerator Co_Initialize()
        {
            //0x11E1D34
            m_isInitialized = false;
            while(!m_header.IsReady())
                yield return null;
            m_header.SetEnableOperate(false);
            m_header.SetCallback(0, OnClickHamburgerButton);
            m_topMenu.OnClickCloseButtonCallback = OnClickCloseButton;
            m_photoMenu.OnClickCloseButtonCallback = OnClickCloseButton;
            m_partitionImage.raycastTarget = false;
            m_isInitialized = true;
        }

        // [IteratorStateMachineAttribute] // RVA: 0x67A254 Offset: 0x67A254 VA: 0x67A254
        // RVA: 0x11E00E0 Offset: 0x11E00E0 VA: 0x11E00E0
        public IEnumerator Co_Setup()
        {
            //0x11E2704
            while(!m_header.IsReady())
                yield return null;
            m_header.ShowButton(0);
            m_topMenu.Setup();
            m_photoMenu.Setup();
            m_helpMenu.Setup();
            m_collectionMenu.Setup();
            m_resetButton.gameObject.SetActive(false);
            m_pauseButton.gameObject.SetActive(false);
        }

        // RVA: 0x11E018C Offset: 0x11E018C VA: 0x11E018C
        public bool IsReady()
        {
            if(m_isInitialized)
            {
                if(m_topMenu.IsInitialized())
                {
                    if(m_photoMenu.IsInitialized())
                    {
                        if(m_helpMenu.IsInitialized())
                            return m_collectionMenu.IsInitialized();
                    }
                }
            }
            return false;
        }

        // RVA: 0x11D9204 Offset: 0x11D9204 VA: 0x11D9204
        public void SetEnableOperate(bool isEnable)
        {
            m_header.SetEnableOperate(isEnable);
            m_topMenu.SetEnableOperate(isEnable);
            m_photoMenu.SetEnableOperate(isEnable);
            m_helpMenu.SetEnableOperate(isEnable);
            m_collectionMenu.SetEnableOperate(isEnable);
            m_shutterButton.enabled = isEnable;
            m_resetButton.enabled = isEnable;
            m_pauseButton.SetEnableOperate(isEnable);
        }

        // // RVA: 0x11E02D0 Offset: 0x11E02D0 VA: 0x11E02D0
        private void OnClickHamburgerButton()
        {
            m_topMenu.Open();
            m_partitionImage.raycastTarget = true;
        }

        // // RVA: 0x11E032C Offset: 0x11E032C VA: 0x11E032C
        private void OnClickCloseButton()
        {
            m_header.ShowButton(0);
            m_partitionImage.raycastTarget = false;
        }

        // RVA: 0x11E0388 Offset: 0x11E0388 VA: 0x11E0388
        public void Update()
        {
            m_arIconCache.Update();
        }

        // RVA: 0x11E03B4 Offset: 0x11E03B4 VA: 0x11E03B4
        public GameObject SetMessageWindow(string message)
        {
            if(m_messageWindowPref != null)
            {
                if(m_messageWindowObj != null)
                {
                    Destroy(m_messageWindowObj);
                }
                m_messageWindowObj = Instantiate(m_messageWindowPref, transform.parent);
                m_messageWindowObj.GetComponent<MessageWindow>().SetMessage(message);
                return m_messageWindowObj;
            }
            return null;
        }

        // RVA: 0x11E05AC Offset: 0x11E05AC VA: 0x11E05AC
        public GameObject SetSelectWindow(string[] messages, bool topCanvas = false)
        {
            if(m_selectWindowPref != null)
            {
                if(m_messageWindowObj != null)
                {
                    Destroy(m_messageWindowObj);
                }
                Transform t = transform;
                if(topCanvas)
                {
                    if(GameManager.Instance.fullscreenFader.isActiveAndEnabled)
                    {
                        GameManager.Instance.fullscreenFader.Fade(0.05f, 0);
                    }
                    GameObject g = GameObject.Find("CanvasError");
                    if(g != null)
                    {
                        t = g.transform;
                    }
                }
                m_messageWindowObj = Instantiate(m_selectWindowPref, t, false);
                m_messageWindowObj.GetComponent<SelectWindow>().SetMessage(messages);
                return m_messageWindowObj;
            }
            return null;
        }

        // // RVA: 0x11E0910 Offset: 0x11E0910 VA: 0x11E0910
        public GameObject SetButtonWindow(string message, string buttonName, UnityAction callback)
        {
            if(m_buttonWindowPref != null)
            {
                if(m_messageWindowObj != null)
                {
                    Destroy(m_messageWindowObj);
                }
                m_messageWindowObj = Instantiate(m_buttonWindowPref);
                m_messageWindowObj.GetComponent<ButtonWindow>().SetMessage(message, buttonName, callback);
                return m_messageWindowObj;
            }
            return null;
        }

        // RVA: 0x11E0AF0 Offset: 0x11E0AF0 VA: 0x11E0AF0
        public bool IsDisplayMessageWindow(GameObject winObj)
        {
            if(winObj == null)
            {
                return m_messageWindowObj != null;
            }
            return m_messageWindowObj == winObj;
        }

        // RVA: 0x11E0BF8 Offset: 0x11E0BF8 VA: 0x11E0BF8
        public SelWinRslt GetSelectWindowResult()
        {
            return SelectWindow.Result;
        }

        // RVA: 0x11E0C74 Offset: 0x11E0C74 VA: 0x11E0C74
        public void ShowInstallRetryMessage(string reason, IMCBBOAFION onNetSuccess, JFDNPFFOACP onNetCancel)
        {
            MessageBank bk = MessageManager.Instance.GetBank("menu");
            if(reason == "storage")
            {
                SetButtonWindow(bk.GetMessageByLabel("ar_popup_download_error_0_message"), bk.GetMessageByLabel("ar_popup_download_error_button"), () =>
                {
                    //0x11E1C54
                    onNetSuccess();
                });
            }
            else
            {
                SetButtonWindow(bk.GetMessageByLabel("ar_popup_download_error_1_message"), bk.GetMessageByLabel("ar_popup_download_error_button"), () =>
                {
                    //0x11E1C80
                    onNetSuccess();
                });
            }
        }

        // // RVA: 0x11E0EC4 Offset: 0x11E0EC4 VA: 0x11E0EC4
        public void ShowARMakerSaveError(ARMarkerSaveManager.ErrorUIType errorUiType, SakashoErrorId errorId, Action onRetry, Action onErrorToTitle)
        {
            MessageBank bk = MessageManager.Instance.GetBank("menu");
            if(errorUiType == ARMarkerSaveManager.ErrorUIType.Timeout)
            {
                SetButtonWindow(bk.GetMessageByLabel("ar_net_error_02"), bk.GetMessageByLabel("ar_net_error_retry"), () =>
                {
                    //0x11E1CD8
                    onRetry();
                });
            }
            else if(errorUiType == ARMarkerSaveManager.ErrorUIType.Network)
            {
                SetButtonWindow(bk.GetMessageByLabel("ar_net_error_01"), bk.GetMessageByLabel("ar_net_error_retry"), () =>
                {
                    //0x11E1CAC
                    onRetry();
                });
            }
            else
            {
                SetButtonWindow(string.Format(bk.GetMessageByLabel("ar_net_error_03"), errorId), bk.GetMessageByLabel("ar_net_error_title"), () =>
                {
                    //0x11E1D04
                    onErrorToTitle();
                });
            }
        }

        // // RVA: 0x11E11F8 Offset: 0x11E11F8 VA: 0x11E11F8
        public void ShowNetworkIcon()
        {
            if(GameManager.Instance.transmissionIcon == null)
                return;
            GameManager.Instance.transmissionIcon.SetActive(true);
        }

        // // RVA: 0x11E133C Offset: 0x11E133C VA: 0x11E133C
        public void HideNetworkIcon()
        {
            if(GameManager.Instance.transmissionIcon == null)
                return;
            GameManager.Instance.transmissionIcon.SetActive(false);
        }

        // // RVA: 0x11E1480 Offset: 0x11E1480 VA: 0x11E1480
        private static void SetupSafeScreen(GameObject obj, GameObject logoOffset, ARMenuManager menuMgr)
        {
            Rect safe = XeSafeArea.GetRect();
            Rect screen = XeSafeArea.GetScreenArea();
            menuMgr.safeContentScale = 1;
            if(safe.y > 0)
            {
                ARCollectionMenu arcm = obj.GetComponentInChildren<ARCollectionMenu>();
                ARHelpMenu arhm = obj.GetComponentInChildren<ARHelpMenu>();
                string ar_mode_safearea_offsets = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.EFEGBHACJAL("ar_mode_safearea_offsets", "20.0,0.0");
                string[] strs = ar_mode_safearea_offsets.Split(new char[] { ',' });
                float f1 = 0;
                float f2 = 0;
                if(strs.Length == 2)
                {
                    float.TryParse(strs[0], out f1);
                    float.TryParse(strs[1], out f2);
                }
                Vector2 v = new Vector2(0, ((screen.height - (safe.y + safe.height)) / screen.height) * 1184 - f1);
                arcm.SetheaderSize(v);
                arhm.SetheaderSize(v);
                RectTransform r = obj.GetComponent<RectTransform>();
                r.offsetMin = new Vector2(0, safe.y * 1184 / screen.height + f2);
                r.offsetMax = new Vector2(0, -v.y);
                RectTransform r2 = logoOffset.GetComponent<RectTransform>();
                r2.offsetMin = r.offsetMin;
                r2.offsetMax = r.offsetMax;
                RectTransform r3 = menuMgr.recoText.gameObject.GetComponent<RectTransform>();
                RectTransform r4 = menuMgr.m_shutterButton.gameObject.GetComponent<RectTransform>();
                r4.offsetMin = new Vector2(r4.offsetMin.x, r4.offsetMin.y + v.y);
                r3.offsetMin = new Vector2(r3.offsetMin.x, r3.offsetMin.y + v.y);
                r4.offsetMax = new Vector2(r4.offsetMax.x, r4.offsetMax.y + v.y);
                r3.offsetMax = new Vector2(r3.offsetMax.x, r3.offsetMax.y + v.y);
                menuMgr.safeContentScale = safe.height / screen.height;
            }
        }
    }
}