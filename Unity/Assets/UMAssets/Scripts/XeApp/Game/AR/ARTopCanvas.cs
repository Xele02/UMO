
using UnityEngine;

namespace XeApp.Game.AR
{
    public class ARTopCanvas : MonoBehaviour
    {
        private static ARTopCanvas sm_instance; // 0x0
        [SerializeField]
        private Canvas m_canvas; // 0xC
        [SerializeField]
        private Camera m_camera; // 0x10

        public static ARTopCanvas Instance { get { return sm_instance; } } //0x13A71F8

        // RVA: 0x13AE908 Offset: 0x13AE908 VA: 0x13AE908
        public void Start()
        {
            sm_instance = this;
        }

        // // RVA: 0x13AE998 Offset: 0x13AE998 VA: 0x13AE998
        public void SetChild(GameObject child)
        {
            child.transform.SetParent(m_canvas.transform, false);
            if(gameObject.activeSelf)
                return;
            gameObject.SetActive(true);
        }

        // RVA: 0x13AEA78 Offset: 0x13AEA78 VA: 0x13AEA78
        public void Update()
        {
            if(m_canvas.transform.childCount != 0)
                return;
            gameObject.SetActive(false);
        }
    }
}