
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.AR
{
    public class ARAwayText : MonoBehaviour
    {
        [SerializeField]
        private float m_blinkTime = 2; // 0xC
        [SerializeField]
        private float m_waitTime = 1; // 0x10
        [SerializeField]
        private Image m_textImage; // 0x14
        private bool m_isShow; // 0x18
        private float m_elapsedTime; // 0x1C

        // RVA: 0x1611E90 Offset: 0x1611E90 VA: 0x1611E90
        public void Start()
        {
            Hide();
        }

        // // RVA: 0x1611F68 Offset: 0x1611F68 VA: 0x1611F68
        private void Show() 
        {
            Graphic[] gs = GetComponentsInChildren<Graphic>(true);
            for(int i = 0; i < gs.Length; i++)
            {
                gs[i].enabled = true;
            }
        }

        // [IteratorStateMachineAttribute] // RVA: 0x679694 Offset: 0x679694 VA: 0x679694
        // // RVA: 0x161203C Offset: 0x161203C VA: 0x161203C
        private IEnumerator Co_Show()
        {
            //0x16123A8
            yield return new WaitForSeconds(m_waitTime);
            Show();
        }

        // // RVA: 0x1611E94 Offset: 0x1611E94 VA: 0x1611E94
        private void Hide()
        {
            Graphic[] gs = GetComponentsInChildren<Graphic>(true);
            for(int i = 0; i < gs.Length; i++)
            {
                gs[i].enabled = false;
            }
        }

        // RVA: 0x16120E8 Offset: 0x16120E8 VA: 0x16120E8
        public void SetShowText(bool isShow)
        {
            if(m_isShow != isShow)
            {
                this.StopAllCoroutinesWatched();
                if(isShow)
                {
                    this.StartCoroutineWatched(Co_Show());
                }
                else
                {
                    Hide();
                }
                m_elapsedTime = 0;
                m_textImage.color = new Color(1, 1, 1, 0);
                m_isShow = isShow;
            }
        }

        // RVA: 0x16121B4 Offset: 0x16121B4 VA: 0x16121B4
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