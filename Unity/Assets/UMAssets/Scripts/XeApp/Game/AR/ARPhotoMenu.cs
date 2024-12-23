
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using XeSys;

namespace XeApp.Game.AR
{
    public class ARPhotoMenu : MonoBehaviour
    {
        private const float ANIM_TIME = 0.25f;
        [SerializeField]
        private RawImage m_photoImage; // 0xC
        [SerializeField]
        private Image m_shareIconImage; // 0x10
        [SerializeField]
        private Sprite m_shareImageiOS; // 0x14
        [SerializeField]
        private Sprite m_shareImageAndroid; // 0x18
        [SerializeField]
        private Button m_snsButton; // 0x1C
        private UnityAction m_onClickCloseButton; // 0x20
        private bool m_isInitialized; // 0x24
        private bool m_isPlaying; // 0x25
        private bool m_isOpen; // 0x26

        public RawImage photoImage { get { return m_photoImage; } } //0x11E6F14
        public UnityAction OnClickCloseButtonCallback { set { m_onClickCloseButton = value; } } //0x11E1F5C
        public bool IsOpen { get { return m_isOpen; } } //0x11E6F1C

        public void Reconstruct()
        {
            m_photoImage = transform.Find("ShowArea/PhotoImage").gameObject.GetComponent<RawImage>();
            m_shareIconImage = transform.Find("ShowArea/SNSButton/Icon").gameObject.GetComponent<Image>();
            m_snsButton = transform.Find("ShowArea/SNSButton").gameObject.GetComponent<Button>();
            m_shareImageAndroid = m_shareIconImage.sprite;
        }

        // RVA: 0x11E6F24 Offset: 0x11E6F24 VA: 0x11E6F24
        public void Start()
        {
            return;
        }

        // [IteratorStateMachineAttribute] // RVA: 0x67A54C Offset: 0x67A54C VA: 0x67A54C
        // RVA: 0x11E6F28 Offset: 0x11E6F28 VA: 0x11E6F28
        private IEnumerator Co_Initialize()
        {
            //0x11E75DC
            m_isInitialized = false;
            m_snsButton.GetComponentInChildren<Text>(true).text = MessageManager.Instance.GetMessage("menu", "ar_photo_button_text_sns");
            m_shareIconImage.sprite = Application.platform == RuntimePlatform.IPhonePlayer ? m_shareImageiOS : m_shareImageAndroid;
            Hide();
            m_isInitialized = true;
            yield break;
        }

        // // RVA: 0x11E0230 Offset: 0x11E0230 VA: 0x11E0230
        public bool IsInitialized()
        {
            return m_isInitialized;
        }

        // // RVA: 0x11E28C0 Offset: 0x11E28C0 VA: 0x11E28C0
        public void Setup()
        {
            this.StartCoroutineWatched(Co_Initialize());
        }

        // RVA: 0x11E0240 Offset: 0x11E0240 VA: 0x11E0240
        public void SetEnableOperate(bool isEnable)
        {
            m_snsButton.targetGraphic.raycastTarget = isEnable;
        }

        // RVA: 0x11E6FD4 Offset: 0x11E6FD4 VA: 0x11E6FD4
        public void SetSNSCallback(UnityAction callback)
        {
            m_snsButton.onClick.RemoveAllListeners();
            m_snsButton.onClick.AddListener(callback);
        }

        // // RVA: 0x11E706C Offset: 0x11E706C VA: 0x11E706C
        private void Show()
        {
            RectTransform r = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
            r.anchoredPosition = new Vector2(r.anchoredPosition.x, 0);
        }

        // // RVA: 0x11E713C Offset: 0x11E713C VA: 0x11E713C
        private void Hide()
        {
            RectTransform r = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
            r.anchoredPosition = new Vector2(r.anchoredPosition.x, -r.sizeDelta.y);
        }

        // RVA: 0x11E7284 Offset: 0x11E7284 VA: 0x11E7284
        public void Open()
        {
            if(!m_isOpen && !m_isPlaying)
            {
                this.StartCoroutineWatched(Co_Open());
                m_isOpen = true;
                VuforiaManager.Instance.OpenFullScreenMenu();
            }
        }

        // [IteratorStateMachineAttribute] // RVA: 0x67A5C4 Offset: 0x67A5C4 VA: 0x67A5C4
        // RVA: 0x11E735C Offset: 0x11E735C VA: 0x11E735C
        private IEnumerator Co_Open()
        {
            //0x11E7810
            m_isPlaying = true;
            RectTransform r = m_snsButton.GetComponent<RectTransform>();
            r.sizeDelta = new Vector2(m_photoImage.GetComponent<RectTransform>().sizeDelta.x, r.sizeDelta.y);
            Show();
            ARMenuManager.Instance.headerMenu.HideButton(ARHeaderMenu.ARHeaderButtonPos.Right);
            ARMenuManager.Instance.headerMenu.ShowButton(ARHeaderMenu.ARHeaderButton.Close);
            GameManager.Instance.AddPushBackButtonHandler(OnBackButton);
            ARMenuManager.Instance.headerMenu.SetCallback(ARHeaderMenu.ARHeaderButton.Close, OnClickCloseButton);
            m_isPlaying = false;
            yield break;
        }

        // // RVA: 0x11E7408 Offset: 0x11E7408 VA: 0x11E7408
        private void OnBackButton()
        {
            OnClickCloseButton();
        }

        // // RVA: 0x11E7504 Offset: 0x11E7504 VA: 0x11E7504
        public void Close()
        {
            if(m_isOpen)
            {
                if(m_isPlaying)
                    return;
                Hide();
                m_isOpen = false;
                VuforiaManager.Instance.CloseFullScreenMenu();
            }
        }

        // // RVA: 0x11E740C Offset: 0x11E740C VA: 0x11E740C
        private void OnClickCloseButton()
        {
            GameManager.Instance.RemovePushBackButtonHandler(OnBackButton);
            Close();
            if(m_onClickCloseButton != null)
                m_onClickCloseButton();
        }
    }
}