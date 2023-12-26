
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.AR
{
    public class SelectWindow : MonoBehaviour
    {
        private const int BUTTON_COUNT = 2;
        private const int TEXT_COUNT = 3;
        private const float LEAST_TIME = 1;
        [SerializeField]
        private Text[] m_text; // 0xC
        [SerializeField]
        private Button[] m_button; // 0x10
        [SerializeField]
        private RectTransform m_frame; // 0x14
        private string[] m_message; // 0x18
        private float m_startTime; // 0x1C
        private static SelWinRslt m_result; // 0x0

        public static SelWinRslt Result { get { return m_result; } } // 0x13B555C

        // RVA: 0x13B4474 Offset: 0x13B4474 VA: 0x13B4474
        private void Awake()
        {
            m_result = SelWinRslt.WAITING;
        }

        // RVA: 0x13B4504 Offset: 0x13B4504 VA: 0x13B4504
        private void Start()
        {
            RectTransform rt = GetComponent<RectTransform>();
            rt.localScale = Vector3.one;
            rt.offsetMin = Vector3.zero;
            rt.offsetMax = Vector3.zero;
            for(int i = 0; i < m_text.Length; i++)
            {
                m_text[i].font = GameManager.Instance.GetSystemFont();
                m_text[i].text = m_message[i];
            }
            if(m_button != null)
            {
                m_button[0].onClick.AddListener(CallbackNo);
                m_button[1].onClick.AddListener(CallbackYes);
            }
            m_startTime = Time.unscaledTime;
            setBodyTextSize();
            GameManager.Instance.AddPushBackButtonHandler(OnBackButton);
        }

        // // RVA: 0x13B4CDC Offset: 0x13B4CDC VA: 0x13B4CDC
        private void OnBackButton()
        {
            if(!m_button[0].gameObject.activeSelf)
                return;
            if(m_button[0].targetGraphic.raycastTarget)
                CallbackNo();
        }

        // // RVA: 0x13B49E8 Offset: 0x13B49E8 VA: 0x13B49E8
        private void setBodyTextSize()
        {
            RectTransform rt = m_text[0].gameObject.GetComponent<RectTransform>();
            if(rt != null)
            {
                LayoutElement l = m_text[0].gameObject.GetComponentInParent<LayoutElement>();
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

        // RVA: 0x13B4F8C Offset: 0x13B4F8C VA: 0x13B4F8C
        private void Update()
        {
            setBodyTextSize();
        }

        // RVA: 0x13B4F90 Offset: 0x13B4F90 VA: 0x13B4F90
        public void SetMessage(string[] message)
        {
            m_message = message;
            if(m_text != null)
            {
                m_text[0].text = message[0];
                if(m_frame != null)
                {
                    int a = GetReturnCount(message[0]);
                    m_frame.offsetMin = new Vector2(m_frame.offsetMin.x, m_frame.offsetMin.y - m_text[0].fontSize * a * 0.5f);
                    m_frame.offsetMax = new Vector2(m_frame.offsetMax.x, m_frame.offsetMax.y + m_text[0].fontSize * a * 0.5f);
                }
                m_text[1].text = message[1];
                m_text[2].text = message[2];
            }
        }

        // // RVA: 0x13B5350 Offset: 0x13B5350 VA: 0x13B5350
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

        // // RVA: 0x13B4DF0 Offset: 0x13B4DF0 VA: 0x13B4DF0
        public void CallbackNo()
        {
            if(m_startTime + 1 < Time.unscaledTime)
            {
                m_result = SelWinRslt.NO;
                GameManager.Instance.RemovePushBackButtonHandler(OnBackButton);
                Destroy(gameObject);
            }
        }

        // // RVA: 0x13B53C0 Offset: 0x13B53C0 VA: 0x13B53C0
        public void CallbackYes()
        {
            if(m_startTime + 1 < Time.unscaledTime)
            {
                m_result = SelWinRslt.YES;
                GameManager.Instance.RemovePushBackButtonHandler(OnBackButton);
                Destroy(gameObject);
            }
        }
    }
}