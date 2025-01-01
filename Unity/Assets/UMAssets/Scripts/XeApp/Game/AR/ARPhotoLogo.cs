
using UnityEngine;

namespace XeApp.Game.AR
{
    public class ARPhotoLogo : MonoBehaviour
    {
        private RectTransform m_rect; // 0xC
        private Vector2 m_spriteSize = Vector2.zero; // 0x10
        private float m_targetAngleZ; // 0x18
        private bool m_isFlip; // 0x1C
        private Vector2 m_normalAnchor = new Vector2(0, 1); // 0x20
        private Vector2 m_flipAnchor = new Vector2(1, 1); // 0x28
        private Vector3 m_flipScale = new Vector3(-1, 1, 1); // 0x30

        // RVA: 0x11E64E0 Offset: 0x11E64E0 VA: 0x11E64E0
        private void Start()
        {
            m_rect = GetComponent<RectTransform>();
            m_spriteSize = m_rect.sizeDelta;
            relocateSprite(0, 1);
        }

        // RVA: 0x11E6C44 Offset: 0x11E6C44 VA: 0x11E6C44
        private void Update()
        {
            ARTakePhoto photo = ARTakePhoto.GetInstance();
            if(photo != null)
            {
                DeviceOrientation r = ARTakePhoto.GetInstance().GetDeviceOrientation();
                m_targetAngleZ = r >= DeviceOrientation.PortraitUpsideDown && r < DeviceOrientation.FaceUp ? new float[3] { 180, 270, 90 } [(int)r - 2] : 0;
                relocateSprite(m_targetAngleZ, Time.deltaTime * 10);
            }
        }

        // // RVA: 0x11E6590 Offset: 0x11E6590 VA: 0x11E6590
        private void relocateSprite(float angleZ, float lerpRate)
        {
            float f = 1;
            if(m_isFlip)
                f = -1;
            m_rect.localRotation = Quaternion.Lerp(m_rect.localRotation, Quaternion.Euler(0, 0, angleZ * f), lerpRate);
            Vector3[] v = new Vector3[4]
            {
                new Vector3(m_spriteSize.x * 0.5f, m_spriteSize.y * 0.5f, 0),
                new Vector3(m_spriteSize.x * -0.5f, m_spriteSize.y * 0.5f, 0),
                new Vector3(m_spriteSize.x * 0.5f, m_spriteSize.y * -0.5f, 0),
                new Vector3(m_spriteSize.x * -0.5f, m_spriteSize.y * -0.5f, 0)
            };
            Vector3 v2 = Vector3.zero;
            for(int i = 0; i < v.Length; i++)
            {
                Vector3 v3 = m_rect.localRotation * v[i];
                v2.x = Mathf.Max(v2.x, v3.x);
                v2.y = Mathf.Max(v2.y, v3.y);
            }
            if(!m_isFlip)
            {
                m_rect.anchoredPosition = new Vector2(v2.x + 16, -116 - v2.y);
                m_rect.anchorMin = m_normalAnchor;
                m_rect.anchorMax = m_normalAnchor;
                m_rect.localScale = Vector3.one;
            }
            else
            {
                m_rect.anchoredPosition = new Vector2(-(v2.x + 16), -116 - v2.y);
                m_rect.anchorMin = m_flipAnchor;
                m_rect.anchorMax = m_flipAnchor;
                m_rect.localScale = m_flipScale;
            }
        }

        // RVA: 0x11E6DC4 Offset: 0x11E6DC4 VA: 0x11E6DC4
        public void ResetAngle()
        {
            relocateSprite(m_targetAngleZ, 1);
        }

        // // RVA: 0x11E6DD0 Offset: 0x11E6DD0 VA: 0x11E6DD0
        // public void SetFlip(bool isFlip) { }
    }
}