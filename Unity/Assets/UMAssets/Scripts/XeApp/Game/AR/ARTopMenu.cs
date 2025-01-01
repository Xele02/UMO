
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using XeSys;

namespace XeApp.Game.AR
{
    public class ARTopMenu : MonoBehaviour
    {
        private const float ANIM_TIME = 0.25f;
        [SerializeField]
        private Button m_collectionButton; // 0xC
        [SerializeField]
        private Button m_helpButton; // 0x10
        [SerializeField]
        private Button m_eventInfoButton; // 0x14
        [SerializeField]
        private Button m_endButton; // 0x18
        private UnityAction m_onClickCloseButton; // 0x1C
        private float m_menuWidth; // 0x20
        private bool m_isInitialized; // 0x24
        private bool m_isOpened; // 0x25
        private bool m_isPlaying; // 0x26

        public UnityAction OnClickCloseButtonCallback { set { m_onClickCloseButton = value; } } //0x13AEB0C

        public void Reconstruct()
        {
            m_collectionButton = transform.Find("MenuItem/Collection").gameObject.GetComponent<Button>();
            m_helpButton = transform.Find("MenuItem/Help").gameObject.GetComponent<Button>();
            m_eventInfoButton = transform.Find("MenuItem/Event").gameObject.GetComponent<Button>();
            m_endButton = transform.Find("MenuItem/End").gameObject.GetComponent<Button>();
        }

        // RVA: 0x13AEB14 Offset: 0x13AEB14 VA: 0x13AEB14
        public void Start()
        {
            this.StartCoroutineWatched(Co_Initialize());
        }

        // [IteratorStateMachineAttribute] // RVA: 0x67A6EC Offset: 0x67A6EC VA: 0x67A6EC
        // // RVA: 0x13AEB38 Offset: 0x13AEB38 VA: 0x13AEB38
        private IEnumerator Co_Initialize()
        {
            //0x13AF7E4
            m_isInitialized = false;
            MessageBank bk = MessageManager.Instance.GetBank("menu");
            m_collectionButton.GetComponentInChildren<Text>(true).text = bk.GetMessageByLabel("ar_top_button_text_collection");
            m_helpButton.GetComponentInChildren<Text>(true).text = bk.GetMessageByLabel("ar_top_button_text_help");
            m_eventInfoButton.GetComponentInChildren<Text>(true).text = bk.GetMessageByLabel("ar_top_button_text_event");
            m_endButton.GetComponentInChildren<Text>(true).text = bk.GetMessageByLabel("ar_top_button_text_back");
            m_collectionButton.onClick.AddListener(OnClickCollectionButton);
            m_helpButton.onClick.AddListener(OnClickHelpButton);
            m_eventInfoButton.onClick.AddListener(OnClickEventButton);
            m_endButton.onClick.AddListener(OnClickEndButton);
            m_isInitialized = true;
            yield break;
        }

        // RVA: 0x13AEBE4 Offset: 0x13AEBE4 VA: 0x13AEBE4
        public bool IsInitialized()
        {
            return m_isInitialized;
        }

        // RVA: 0x13AEBEC Offset: 0x13AEBEC VA: 0x13AEBEC
        public void Setup()
        {
            RectTransform r = GetComponent<RectTransform>();
            Canvas c = GetComponentInParent<Canvas>();
            RectTransform rc = c.GetComponent<RectTransform>();
            m_menuWidth = rc.sizeDelta.x * 0.5f;
            r.sizeDelta = new Vector2(m_menuWidth, r.sizeDelta.y);
            r.anchoredPosition = new Vector2(-m_menuWidth, r.anchoredPosition.y);
        }

        // RVA: 0x13AED98 Offset: 0x13AED98 VA: 0x13AED98
        public void SetEnableOperate(bool isEnable)
        {
            m_collectionButton.targetGraphic.raycastTarget = isEnable;
            m_helpButton.targetGraphic.raycastTarget = isEnable;
            m_eventInfoButton.targetGraphic.raycastTarget = isEnable;
            m_endButton.targetGraphic.raycastTarget = isEnable;
        }

        // RVA: 0x13AEEDC Offset: 0x13AEEDC VA: 0x13AEEDC
        public void Open()
        {
            if(!m_isOpened && !m_isPlaying)
            {
                ARMenuManager.Instance.headerMenu.HideButton(ARHeaderMenu.ARHeaderButtonPos.Right);
                ARMenuManager.Instance.headerMenu.ShowButton(ARHeaderMenu.ARHeaderButton.Close);
                GameManager.Instance.AddPushBackButtonHandler(OnBackButton);
                ARMenuManager.Instance.headerMenu.SetCallback(ARHeaderMenu.ARHeaderButton.Close, OnClickCloseButton);
                this.StartCoroutineWatched(Co_Open());
                m_isOpened = true;
            }
        }

        // // RVA: 0x13AF150 Offset: 0x13AF150 VA: 0x13AF150
        private void OnBackButton()
        {
            Close();
        }

        // [IteratorStateMachineAttribute] // RVA: 0x67A764 Offset: 0x67A764 VA: 0x67A764
        // // RVA: 0x13AF0C4 Offset: 0x13AF0C4 VA: 0x13AF0C4
        private IEnumerator Co_Open()
        {
            //0x13B0084
            m_isPlaying = true;
            yield return Co.R(Co_MoveX(-m_menuWidth, 0, 0.25f));
            m_isPlaying = false;
        }

        // // RVA: 0x13AF178 Offset: 0x13AF178 VA: 0x13AF178
        public void Close()
        {
            if(m_isOpened)
            {
                if(m_isPlaying)
                    return;
                this.StartCoroutineWatched(Co_Close());
                m_isOpened = false;
                GameManager.Instance.RemovePushBackButtonHandler(OnBackButton);
            }
        }

        // [IteratorStateMachineAttribute] // RVA: 0x67A7DC Offset: 0x67A7DC VA: 0x67A7DC
        // // RVA: 0x13AF290 Offset: 0x13AF290 VA: 0x13AF290
        private IEnumerator Co_Close()
        {
            //0x13AF660
            m_isPlaying = true;
            yield return Co.R(Co_MoveX(0, -m_menuWidth, 0.25f));
            if(m_onClickCloseButton != null)
                m_onClickCloseButton();
            m_isPlaying = false;
        }

        // [IteratorStateMachineAttribute] // RVA: 0x67A854 Offset: 0x67A854 VA: 0x67A854
        // // RVA: 0x13AF33C Offset: 0x13AF33C VA: 0x13AF33C
        private IEnumerator Co_MoveX(float start, float end, float time)
        {
            RectTransform rt; // 0x20
            Vector2 pos; // 0x24
            float elapsedTime; // 0x2C

            //0x13AFD70
            ARMenuManager.Instance.SetEnableOperate(false);
            rt = GetComponent<RectTransform>();
            pos = rt.anchoredPosition;
            elapsedTime = 0;
            while(elapsedTime < time)
            {
                rt.anchoredPosition = new Vector2(Mathf.Lerp(start, end, Mathf.Clamp01(Mathf.Sin(elapsedTime / time * 1.570796f))), pos.y);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            rt.anchoredPosition = new Vector2(end, pos.y);
            ARMenuManager.Instance.SetEnableOperate(true);
        }

        // // RVA: 0x13AF154 Offset: 0x13AF154 VA: 0x13AF154
        private void OnClickCloseButton()
        {
            Close();
        }

        // // RVA: 0x13AF448 Offset: 0x13AF448 VA: 0x13AF448
        private void OnClickCollectionButton()
        {
            Close();
            ARMenuManager.Instance.collectionMenu.Open();
        }

        // // RVA: 0x13AF4A8 Offset: 0x13AF4A8 VA: 0x13AF4A8
        private void OnClickHelpButton()
        {
            Close();
            ARMenuManager.Instance.helpMenu.HelpKey = "howto";
            ARMenuManager.Instance.helpMenu.Open();
        }

        // // RVA: 0x13AF5A4 Offset: 0x13AF5A4 VA: 0x13AF5A4
        private void OnClickEventButton()
        {
            Close();
            ARMenuManager.Instance.collectionMenu.OpenEventInfo();
        }

        // // RVA: 0x13AF5FC Offset: 0x13AF5FC VA: 0x13AF5FC
        private void OnClickEndButton()
        {
            ARMenuManager.Instance.OnClickEndButton();
        }

        // RVA: 0x13AF650 Offset: 0x13AF650 VA: 0x13AF650
        public void Update()
        {
            return;
        }
    }
}