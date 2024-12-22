
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.AR
{
    public class MessageWindow : MonoBehaviour
    {
        private const float LEAST_TIME = 1;
        [SerializeField]
        private Text m_text; // 0xC
        [SerializeField]
        private Button m_button; // 0x10
        [SerializeField]
        private RectTransform m_frame; // 0x14
        private string m_message; // 0x18
        private float m_startTime; // 0x1C

        // RVA: 0x13B2F34 Offset: 0x13B2F34 VA: 0x13B2F34
        private void Start()
        {
            RectTransform rt = GetComponent<RectTransform>();
            rt.localScale = Vector3.one;
            rt.offsetMin = Vector3.zero;
            rt.offsetMax = Vector3.zero;
            if(m_text != null)
            {
                GameManager.Instance.GetSystemFont().Apply(m_text);
                m_text.text = m_message;
            }
            if(m_button != null)
            {
                m_button.onClick.AddListener(CallbackTouchScreen);
                GameManager.Instance.AddPushBackButtonHandler(OnPushBack);
            }
            m_startTime = Time.unscaledTime;
        }

        // // RVA: 0x13B330C Offset: 0x13B330C VA: 0x13B330C
        private void OnPushBack()
        {
            CallbackTouchScreen();
        }

        // RVA: 0x13B3464 Offset: 0x13B3464 VA: 0x13B3464
        public void SetMessage(string message)
        {
            m_message = message;
            if(m_text != null)
            {
                m_text.text = message;
                if(m_frame != null)
                {
                    int a = 0;
                    for(int i = 0; i < message.Length; i++)
                    {
                        if(message[i] == '\n')
                            a++;
                    }
                    m_frame.offsetMin = new Vector2(m_frame.offsetMin.x, m_frame.offsetMin.y - m_text.fontSize * 0.5f * a);
                    m_frame.offsetMax = new Vector2(m_frame.offsetMax.x, m_frame.offsetMax.y + m_text.fontSize * 0.5f * a);
                }
            }
        }

        // // RVA: 0x13B3310 Offset: 0x13B3310 VA: 0x13B3310
        private void CallbackTouchScreen()
        {
            if(m_startTime + 1 < Time.unscaledTime)
            {
                Destroy(gameObject);
                GameManager.Instance.RemovePushBackButtonHandler(OnPushBack);
            }
        }
    }
}