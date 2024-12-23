
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace XeApp.Game.AR
{
    public enum PauseType
    {
        None = -1,
        System = 0,
        Button = 1,
        Force = 2,
        Num = 3,
    }

    public class ARPauseButton : MonoBehaviour
    {
        [SerializeField]
        private Button m_button; // 0xC
        [SerializeField]
        private Image m_pauseImage; // 0x10
        [SerializeField] // RVA: 0x5DA650 Offset: 0x5DA650 VA: 0x5DA650
        private Image m_playImage; // 0x14
        private UnityAction<PauseType> m_onPauseCallback; // 0x18
        private UnityAction<PauseType> m_onResumeCallback; // 0x1C
        private bool m_isPaused; // 0x20

        public UnityAction<PauseType> OnPauseCallback { set { m_onPauseCallback = value; } } //0x11CD398
        public UnityAction<PauseType> OnResumeCallback { set { m_onResumeCallback = value; } } //0x11CD3A0

        public void Reconstruct()
        {
            m_button = GetComponent<Button>();
            m_pauseImage = transform.Find("PuaseImage").gameObject.GetComponent<Image>();
            m_playImage = transform.Find("PlayImage").gameObject.GetComponent<Image>();
        }

        // RVA: 0x11E6214 Offset: 0x11E6214 VA: 0x11E6214
        public void Start()
        {
            m_button.onClick.RemoveAllListeners();
            m_button.onClick.AddListener(OnClickPauseButton);
            m_pauseImage.enabled = true;
            m_playImage.enabled = false;
        }

        // RVA: 0x11CE7F0 Offset: 0x11CE7F0 VA: 0x11CE7F0
        public void Reset()
        {
            m_isPaused = false;
            m_pauseImage.enabled = true;
            m_playImage.enabled = false;
        }

        // RVA: 0x11E029C Offset: 0x11E029C VA: 0x11E029C
        public void SetEnableOperate(bool isEnable)
        {
            m_button.enabled = isEnable;
        }

        // // RVA: 0x11E6364 Offset: 0x11E6364 VA: 0x11E6364
        public void Pause() 
        {
            if(m_isPaused)
                return;
            m_pauseImage.enabled = false;
            m_playImage.enabled = true;
            m_isPaused = true;
        }

        // // RVA: 0x11E63D0 Offset: 0x11E63D0 VA: 0x11E63D0
        public void Resume()
        {
            if(!m_isPaused)
                return;
            m_pauseImage.enabled = true;
            m_playImage.enabled = false;
            m_isPaused = false;
        }

        // // RVA: 0x11E643C Offset: 0x11E643C VA: 0x11E643C
        private void OnClickPauseButton()
        {
            if(!m_isPaused)
            {
                m_onPauseCallback(PauseType.Button);
            }
            else
            {
                m_onResumeCallback(PauseType.Button);
            }
        }
    }
}