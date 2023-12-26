
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.AR
{
    public abstract class AROverlayMenu : MonoBehaviour
    {
        protected const float ANIM_TIME = 0.25f;
        [SerializeField]
        protected Button m_closeButton; // 0xC
        private float m_menuHeight; // 0x10
        protected bool m_isInitialized; // 0x14
        protected bool m_isOpened; // 0x15
        protected bool m_isPlaying; // 0x16

        // RVA: 0x11D606C Offset: 0x11D606C VA: 0x11D606C Slot: 4
        public virtual void Start()
        {
            return;
        }

        // [IteratorStateMachineAttribute] // RVA: 0x67A3BC Offset: 0x67A3BC VA: 0x67A3BC
        // // RVA: 0x11D811C Offset: 0x11D811C VA: 0x11D811C Slot: 5
        protected virtual IEnumerator Co_Initialize()
        {
            //0x11E5BC8
            m_isInitialized = false;
            m_closeButton.onClick.AddListener(OnClickCloseButton);
            m_menuHeight = GetComponentInParent<Canvas>().GetComponent<RectTransform>().sizeDelta.y;
            RectTransform r = GetComponent<RectTransform>();
            r.anchoredPosition = new Vector2(r.anchoredPosition.x, -m_menuHeight);
            m_isInitialized = true;
            yield break;
        }

        // // RVA: 0x11E59A4 Offset: 0x11E59A4 VA: 0x11E59A4 Slot: 6
        protected virtual void OnBackButton()
        {
            if(!m_closeButton.gameObject.activeSelf)
                return;
            if(m_closeButton.targetGraphic.raycastTarget)
                Close();
        }

        // // RVA: 0x11E5A74 Offset: 0x11E5A74 VA: 0x11E5A74 Slot: 7
        public virtual void Setup()
        {
            this.StartCoroutineWatched(Co_Initialize());
        }

        // // RVA: 0x11E0238 Offset: 0x11E0238 VA: 0x11E0238
        public bool IsInitialized()
        {
            return m_isInitialized;
        }

        // // RVA: 0x11E5AA8 Offset: 0x11E5AA8 VA: 0x11E5AA8
        public bool IsOpened()
        {
            return m_isOpened;
        }

        // // RVA: 0x11E5AB0 Offset: 0x11E5AB0 VA: 0x11E5AB0
        public bool IsPlaying()
        {
            return m_isPlaying;
        }

        // // RVA: 0x11D81AC Offset: 0x11D81AC VA: 0x11D81AC Slot: 8
        public virtual void Open()
        {
            if(!m_isOpened && !m_isPlaying)
            {
                this.StartCoroutineWatched(Co_MoveY(-m_menuHeight, 0, 0.25f));
                m_isOpened = true;
                VuforiaManager.Instance.OpenFullScreenMenu();
                GameManager.Instance.AddPushBackButtonHandler(OnClickCloseButton);
            }
        }

        // // RVA: 0x11D7448 Offset: 0x11D7448 VA: 0x11D7448 Slot: 9
        public virtual void Close()
        {
            if(m_isOpened && !m_isPlaying)
            {
                this.StartCoroutineWatched(Co_MoveY(0, -m_menuHeight, 0.25f));
                m_isOpened = false;
                VuforiaManager.Instance.CloseFullScreenMenu();
                GameManager.Instance.RemovePushBackButtonHandler(OnBackButton);
            }
        }

        // [IteratorStateMachineAttribute] // RVA: 0x67A434 Offset: 0x67A434 VA: 0x67A434
        // // RVA: 0x11E5AB8 Offset: 0x11E5AB8 VA: 0x11E5AB8
        private IEnumerator Co_MoveY(float start, float end, float time)
        {
            RectTransform rt; // 0x20
            Vector2 pos; // 0x24
            float elapsedTime; // 0x2C

            //0x11E5E68
            m_isPlaying = true;
            ARMenuManager.Instance.SetEnableOperate(false);
            rt = GetComponent<RectTransform>();
            pos = rt.anchoredPosition;
            elapsedTime = 0;
            while(elapsedTime < time)
            {
                rt.anchoredPosition = new Vector2(pos.x, Mathf.Lerp(start, end, Mathf.Clamp01(Mathf.Sin(elapsedTime / time * 1.570796f))));
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            rt.anchoredPosition = new Vector2(pos.x, end);
            ARMenuManager.Instance.SetEnableOperate(true);
            m_isPlaying = false;
        }

        // // RVA: 0x11E5A64 Offset: 0x11E5A64 VA: 0x11E5A64
        private void OnClickCloseButton()
        {
            Close();
        }
    }
}