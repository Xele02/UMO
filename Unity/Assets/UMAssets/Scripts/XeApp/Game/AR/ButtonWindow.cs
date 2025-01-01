
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace XeApp.Game.AR
{
    public enum BtnWinRslt
    {
        WAITING = 0,
        SELECT = 1,
    }

    public class ButtonWindow : MonoBehaviour
    {
        private const float LEAST_TIME = 0.1f;
        [SerializeField]
        private Button m_button; // 0xC
        [SerializeField]
        private Text m_buttonText; // 0x10
        [SerializeField]
        private Text m_messageText; // 0x14
        [SerializeField]
        private RectTransform m_frame; // 0x18
        private string m_buttonName; // 0x1C
        private string m_message; // 0x20
        private float m_startTime; // 0x24
        private static BtnWinRslt m_result; // 0x0
        private UnityAction m_callback; // 0x28

        public static BtnWinRslt Result { get { return m_result; } } // 0x13B1024

        // RVA: 0x13B0668 Offset: 0x13B0668 VA: 0x13B0668
        private void Awake()
        {
            m_result = BtnWinRslt.WAITING;
        }

        // RVA: 0x13B06F8 Offset: 0x13B06F8 VA: 0x13B06F8
        private void Start()
        {
            this.StartCoroutineWatched(Co_Setup());
        }

        // [IteratorStateMachineAttribute] // RVA: 0x67AA0C Offset: 0x67AA0C VA: 0x67AA0C
        // // RVA: 0x13B071C Offset: 0x13B071C VA: 0x13B071C
        private IEnumerator Co_Setup()
        {
            //0x13B1268
            RectTransform rt = GetComponent<RectTransform>();
            rt.localScale = Vector3.one;
            rt.offsetMin = Vector3.zero;
            rt.offsetMax = Vector3.zero;
            GameManager.Instance.GetSystemFont().Apply(m_messageText);
            m_messageText.text = m_message;
            GameManager.Instance.GetSystemFont().Apply(m_buttonText);
            m_buttonText.text = m_buttonName;
            if(m_button != null)
                m_button.onClick.AddListener(CallbackSelect);
            m_startTime = Time.unscaledTime;
            setBodyTextSize();
            yield return null;
            ARTopCanvas.Instance.SetChild(gameObject);
            GameManager.Instance.AddPushBackButtonHandler(OnBackButton);
        }

        // // RVA: 0x13B07C8 Offset: 0x13B07C8 VA: 0x13B07C8
        private void OnBackButton()
        {
            if(m_button.gameObject.activeSelf)
            {
                if(m_button.targetGraphic.raycastTarget)
                {
                    CallbackSelect();
                    GameManager.Instance.RemovePushBackButtonHandler(OnBackButton);
                }
            }
        }

        // // RVA: 0x13B0A6C Offset: 0x13B0A6C VA: 0x13B0A6C
        private void setBodyTextSize()
        {
            RectTransform rt = m_messageText.gameObject.GetComponent<RectTransform>();
            if(rt != null)
            {
                LayoutElement l = m_messageText.gameObject.GetComponentInParent<LayoutElement>();
                if(l != null)
                {
                    if(l.preferredWidth == rt.sizeDelta.x)
                    {
                        if(l.preferredHeight == rt.sizeDelta.y)
                            return;
                    }
                    l.preferredWidth = rt.sizeDelta.x;
                    l.preferredHeight = rt.sizeDelta.y;
                }
            }
        }

        // RVA: 0x13B0D00 Offset: 0x13B0D00 VA: 0x13B0D00
        private void Update()
        {
            setBodyTextSize();
        }

        // RVA: 0x13B0D04 Offset: 0x13B0D04 VA: 0x13B0D04
        public void SetMessage(string message, string buttonName, UnityAction callback)
        {
            m_buttonName = buttonName;
            m_message = message;
            m_callback = callback;
            if(m_messageText != null)
            {
                m_messageText.text = message;
                if(m_frame != null)
                {
                    int a = GetReturnCount(message);
                    m_frame.offsetMin = new Vector2(m_frame.offsetMin.x, m_frame.offsetMin.y - m_messageText.fontSize * 0.5f * a);
                    m_frame.offsetMax = new Vector2(m_frame.offsetMax.x, m_frame.offsetMax.y + m_messageText.fontSize * 0.5f * a);
                }
                m_buttonText.text = buttonName;
            }
        }

        // // RVA: 0x13B0FB4 Offset: 0x13B0FB4 VA: 0x13B0FB4
        private int GetReturnCount(string message)
        {
            int r = 0;
            for(int i = 0; i < message.Length; i++)
            {
                if(message[i] == '\n')
                    r++;
            }
            return r;
        }

        // // RVA: 0x13B0948 Offset: 0x13B0948 VA: 0x13B0948
        public void CallbackSelect()
        {
            if(m_startTime + 1 < Time.unscaledTime)
            {
                m_result = BtnWinRslt.SELECT;
                if(m_callback != null)
                    m_callback();
                Destroy(gameObject);
            }
        }

        // // RVA: 0x13B10B0 Offset: 0x13B10B0 VA: 0x13B10B0
        // private void Show() { }

        // // RVA: 0x13B1184 Offset: 0x13B1184 VA: 0x13B1184
        // private void Hide() { }
    }
}