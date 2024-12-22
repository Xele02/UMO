
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using XeSys;

namespace XeApp.Game.AR
{
    public class ExpiredWindow : MonoBehaviour
    {
        [SerializeField]
        private Text m_messageText; // 0xC
        [SerializeField]
        private RectTransform m_frame; // 0x10
        private bool m_isShow = true; // 0x14

        // RVA: 0x13B2354 Offset: 0x13B2354 VA: 0x13B2354
        private void Start()
        {
            this.StartCoroutineWatched(Co_Setup());
        }

        // [IteratorStateMachineAttribute] // RVA: 0x67AAD4 Offset: 0x67AAD4 VA: 0x67AAD4
        // // RVA: 0x13B2378 Offset: 0x13B2378 VA: 0x13B2378
        private IEnumerator Co_Setup()
        {
            //0x13B2B78
            RectTransform r = GetComponent<RectTransform>();
            r.localScale = Vector3.one;
            r.offsetMin = Vector3.zero;
            r.offsetMax = Vector3.zero;
            GameManager.Instance.GetSystemFont().Apply(m_messageText);
            SetMessage(MessageManager.Instance.GetMessage("menu", "ar_popup_expired_message"));
            yield return null;
            setBodyTextSize();
            yield return null;
            Hide();
        }

        // // RVA: 0x13B2424 Offset: 0x13B2424 VA: 0x13B2424
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

        // // RVA: 0x13B26B8 Offset: 0x13B26B8 VA: 0x13B26B8
        private void SetMessage(string message)
        {
            if(m_messageText != null)
            {
                if(m_frame != null)
                {
                    m_messageText.text = message;
                    int a = GetReturnCount(message);
                    m_frame.offsetMin = new Vector2(m_frame.offsetMin.x, m_frame.offsetMin.y - m_messageText.fontSize * 0.5f * a);
                    m_frame.offsetMax = new Vector2(m_frame.offsetMax.x, m_messageText.fontSize * 0.5f * a + m_frame.offsetMax.y);
                }
            }
        }

        // // RVA: 0x13B2920 Offset: 0x13B2920 VA: 0x13B2920
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

        // RVA: 0x13B2990 Offset: 0x13B2990 VA: 0x13B2990
        public bool IsShow()
        {
            return m_isShow;
        }

        // RVA: 0x13B2998 Offset: 0x13B2998 VA: 0x13B2998
        public void Show()
        {
            if(m_isShow)
                return;
            m_isShow = true;
            Graphic[] gs = GetComponentsInChildren<Graphic>(true);
            for(int i = 0; i < gs.Length; i++)
            {
                gs[i].enabled = true;
            }
        }

        // RVA: 0x13B2A80 Offset: 0x13B2A80 VA: 0x13B2A80
        public void Hide()
        {
            if(!m_isShow)
                return;
            m_isShow = false;
            Graphic[] gs = GetComponentsInChildren<Graphic>(true);
            for(int i = 0; i < gs.Length; i++)
            {
                gs[i].enabled = false;
            }
        }
    }
}