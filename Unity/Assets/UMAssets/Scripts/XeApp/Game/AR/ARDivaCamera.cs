
using smartar;
using UnityEngine;

namespace XeApp.Game.AR
{
    public class ARDivaCamera : MonoBehaviour
    {
        public const float LERP_COEF = 0.3f;
        private Transform m_arCameraTr; // 0xC
        private Camera m_camera; // 0x10
        private static ARDivaCamera ms_instance = null; // 0x0
        private static float ms_imageScale = 1; // 0x4
        private UnityEngine.Quaternion m_lastRot = UnityEngine.Quaternion.identity; // 0x14
        private float m_offsetAngle; // 0x24
        private UnityEngine.Quaternion m_offsetRot = UnityEngine.Quaternion.identity; // 0x28
        private Facing m_cameraFacing; // 0x38
        private bool m_flip; // 0x3C

        // public static float GetARImageScale { get; } 0x161C5F0

        // RVA: 0x161BBD8 Offset: 0x161BBD8 VA: 0x161BBD8
        private void Awake()
        {
            ms_instance = this;
        }

        // RVA: 0x161BC68 Offset: 0x161BC68 VA: 0x161BC68
        private void Start()
        {
            m_camera = GetComponent<Camera>();
            int fix_smartar_rotate_bug = AREventMasterData.Instance.GetIntParam("fix_smartar_rotate_bug", 0);
            if(fix_smartar_rotate_bug != 0)
            {
                string s = SystemInfo.deviceModel;
                foreach(var k in AREventMasterData.Instance.m_stringParam.Keys)
                {
                    if(k == s)
                    {
                        float f = 0;
                        if(float.TryParse(AREventMasterData.Instance.m_stringParam[k].DNJEJEANJGL_Value, out f))
                        {
                            m_offsetAngle = f;
                            SetCameraSide(m_cameraFacing);
                            return;
                        }
                    }
                }
            }
        }

        // RVA: 0x161C064 Offset: 0x161C064 VA: 0x161C064
        private void Update()
        {
            if(m_arCameraTr != null)
            {
                Camera cam = m_arCameraTr.GetComponentInChildren<Camera>();
                if(cam != null)
                {
                    m_camera.fieldOfView = cam.fieldOfView;
                }
                setCameraPositionWithScale(ms_imageScale);
            }
        }

        // // RVA: 0x161C1FC Offset: 0x161C1FC VA: 0x161C1FC
        private void setCameraPositionWithScale(float scale)
        {
            transform.localPosition = UnityEngine.Vector3.Lerp(transform.localPosition, m_arCameraTr.transform.localPosition / scale, 0.3f);
            m_lastRot = UnityEngine.Quaternion.Lerp(m_lastRot, m_arCameraTr.localRotation, 0.3f);
            transform.localRotation = m_lastRot * m_offsetRot;
            transform.localScale = m_arCameraTr.localScale;
        }

        // RVA: 0x161C4E0 Offset: 0x161C4E0 VA: 0x161C4E0
        public void SetARCamera(Transform arCamTr)
        {
            m_arCameraTr = arCamTr;
            m_lastRot = arCamTr.transform.localRotation;
        }

        // RVA: 0x161BF68 Offset: 0x161BF68 VA: 0x161BF68
        public void SetCameraSide(Facing cameraFacing)
        {
            m_cameraFacing = cameraFacing;
            float f = m_offsetAngle;
            if(cameraFacing != Facing.FACING_BACK)
            {
                f = -f;
            }
            m_offsetRot = UnityEngine.Quaternion.Euler(0, 0, f);
        }

        // RVA: 0x161C554 Offset: 0x161C554 VA: 0x161C554
        public static void SetARImageScale(float scale)
        {
            ms_imageScale = scale;
        }

        // // RVA: 0x161C67C Offset: 0x161C67C VA: 0x161C67C
        // public static void SetFlip(bool flip) { }

        // // RVA: 0x161C7A8 Offset: 0x161C7A8 VA: 0x161C7A8
        // public static bool GetFlip() { }
    }
}