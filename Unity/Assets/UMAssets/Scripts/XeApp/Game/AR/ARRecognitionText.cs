
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.AR
{
    public class ARRecognitionText : MonoBehaviour
    {
        [SerializeField]
        private float m_blinkTime = 2; // 0xC
        [SerializeField]
        private Image m_textImage; // 0x10
        private bool m_isShow; // 0x14
        private float m_elapsedTime; // 0x18

        // RVA: 0x11E84E8 Offset: 0x11E84E8 VA: 0x11E84E8
        public void Start()
        {
            Hide();
        }

        // RVA: 0x11E85C0 Offset: 0x11E85C0 VA: 0x11E85C0
        private void Show()
        {
            ARMenuManager.Instance.awayText.SetShowText(false);
            Graphic[] gs = GetComponentsInChildren<Graphic>(true);
            for(int i = 0; i < gs.Length; i++)
            {
                gs[i].enabled = true;
            }
        }

        // RVA: 0x11E84EC Offset: 0x11E84EC VA: 0x11E84EC
        private void Hide()
        {
            Graphic[] gs = GetComponentsInChildren<Graphic>(true);
            for(int i = 0; i < gs.Length; i++)
            {
                gs[i].enabled = false;
            }
        }

        // RVA: 0x11E871C Offset: 0x11E871C VA: 0x11E871C
        public void UpdateRecoTarget(ARMarkerMasterData.Data data)
        {
            if(data == null && !ARMenuManager.Instance.expiredWindow.IsShow())
            {
                if(m_isShow)
                    return;
                m_isShow = true;
                Show();
            }
            else
            {
                if(!m_isShow)
                    return;
                m_isShow = false;
                Hide();
            }
            m_elapsedTime = 0;
            m_textImage.color = new Color(1, 1, 1, 0);
        }

        // RVA: 0x11E8868 Offset: 0x11E8868 VA: 0x11E8868
        public void Update()
        {
            if(m_isShow)
            {
                m_elapsedTime += Time.deltaTime;
                if(m_blinkTime <= m_elapsedTime)
                    m_elapsedTime -= m_blinkTime;
                float f = Mathf.Clamp01(m_elapsedTime / m_blinkTime);
                if(f >= 0.5f)
                {
                    f = Mathf.Clamp01(f - 0.5f + f - 0.5f);
                    f = 1 - f;
                }
                else
                {
                    f = Mathf.Clamp01(2 * f);
                }
                m_textImage.color = new Color(1, 1, 1, f + 0.1f);
            }
        }
    }
}