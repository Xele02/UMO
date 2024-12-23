
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Menu;

namespace XeApp.Game.AR
{
    public class ARRecognitionIcon : MonoBehaviour
    {
        private float m_blinkTime = 2; // 0xC
        [SerializeField]
        private RawImage m_iconImage; // 0x10
        [SerializeField]
        private Image m_recogTextImage; // 0x14
        [SerializeField]
        private Image m_pauseTextImage; // 0x18
        private bool m_isShow; // 0x1C
        private float m_elapsedTime; // 0x20
        private string m_currentId = ""; // 0x24
        private ARDivaManager m_divaMan; // 0x28

        public void Reconstruct()
        {
            m_iconImage = transform.Find("Image").gameObject.GetComponent<RawImage>();
            m_recogTextImage = transform.Find("RecogText").gameObject.GetComponent<Image>();
            m_pauseTextImage = transform.Find("PauseText").gameObject.GetComponent<Image>();
        }

        // RVA: 0x11E7BD8 Offset: 0x11E7BD8 VA: 0x11E7BD8
        public void Start()
        {
            m_divaMan = FindObjectOfType<ARDivaManager>();
            Hide();
        }

        // RVA: 0x11E7D44 Offset: 0x11E7D44 VA: 0x11E7D44
        private void Show()
        {
            Graphic[] gs = GetComponentsInChildren<Graphic>(true);
            for(int i = 0; i < gs.Length; i++)
            {
                gs[i].enabled = true;
            }
        }

        // RVA: 0x11E7C70 Offset: 0x11E7C70 VA: 0x11E7C70
        private void Hide()
        {
            Graphic[] gs = GetComponentsInChildren<Graphic>(true);
            for(int i = 0; i < gs.Length; i++)
            {
                gs[i].enabled = false;
            }
        }

        // RVA: 0x11E7E18 Offset: 0x11E7E18 VA: 0x11E7E18
        public void UpdateRecoTarget(ARMarkerMasterData.Data data)
        {
            if(data == null)
            {
                if(!m_isShow)
                    return;
                m_isShow = false;
                Hide();
            }
            else
            {
                if(!m_divaMan.IsLoaded)
                    return;
                if(m_isShow && m_currentId == data.markerId)
                    return;
                m_isShow = true;
                m_iconImage.enabled = false;
                ARMenuManager.Instance.arIconCache.LoadDivaIcon(data.divaId, (IiconTexture tex) =>
                {
                    //0x11E83E8
                    m_iconImage.enabled = true;
                    if(tex != null)
                        tex.Set(m_iconImage);
                });
                m_currentId = data.markerId;
                Show();
            }
            m_elapsedTime = 0;
            m_recogTextImage.color = new Color(1, 1, 1, 0);
            m_pauseTextImage.color = new Color(1, 1, 1, 0);
        }

        // RVA: 0x11E80B4 Offset: 0x11E80B4 VA: 0x11E80B4
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
                    f = Mathf.Clamp01(2 * f);
                m_recogTextImage.color = new Color(1, 1, 1, f + 0.1f);
                m_pauseTextImage.color = new Color(1, 1, 1, f + 0.1f);
                m_recogTextImage.enabled = !m_divaMan.IsPaused();
                m_pauseTextImage.enabled = !m_divaMan.IsPaused();
            }
        }
    }
}