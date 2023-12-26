
using System.Collections;
using UdonLib;
using UnityEngine;

namespace XeApp.Game.AR
{
    public class CircleShadow : MonoBehaviour
    {
        private const float SHADOW_SCALE = 30;
        private Transform m_trRoot; // 0xC
        private Transform m_trHips; // 0x10
        private int m_id; // 0x14
        private float m_baseScale = 1; // 0x18
        private Material m_material; // 0x1C
        private Color m_shadowColor = Color.white; // 0x20
        private ARObject m_arObject; // 0x30
        private Renderer m_renderer; // 0x34
        private bool m_isInitialized; // 0x38
        private string[] NODE_NAME = new string[2]
        {
            "foot_l", "foot_r"
        }; // 0x3C

        // RVA: 0x13B17F0 Offset: 0x13B17F0 VA: 0x13B17F0
        private void Start()
        {
            return;
        }

        // RVA: 0x13B17F4 Offset: 0x13B17F4 VA: 0x13B17F4
        public void Reset()
        {
            m_isInitialized = false;
            m_trRoot = null;
            m_trHips = null;
        }

        // // RVA: 0x13B1808 Offset: 0x13B1808 VA: 0x13B1808
        public void Initialize()
        {
            this.StartCoroutineWatched(Co_Initialize());
        }

        // [IteratorStateMachineAttribute] // RVA: 0x678E94 Offset: 0x678E94 VA: 0x678E94
        // // RVA: 0x13B182C Offset: 0x13B182C VA: 0x13B182C
        private IEnumerator Co_Initialize()
        {
            //0x13B1DF4
            m_isInitialized = false;
            transform.localRotation = Quaternion.Euler(90, 0, 0);
            transform.localScale = Vector3.one * 30;
            transform.localPosition = Vector3.zero;
            while(m_trRoot == null)
            {
                m_trRoot = transform.parent;
                yield return null;
            }
            while(m_trHips == null)
            {
                m_trHips = Utils.SearchNodeByName(m_trRoot, NODE_NAME[m_id]);
                yield return null;
            }
            gameObject.layer = LayerMask.NameToLayer("Singer");
            m_material = GetComponent<Renderer>().material;
            m_renderer = GetComponentInChildren<Renderer>();
            m_isInitialized = true;
        }

        // // RVA: 0x13B18D8 Offset: 0x13B18D8 VA: 0x13B18D8
        public bool IsInitialized()
        {
            return m_isInitialized;
        }

        // // RVA: 0x13B18E0 Offset: 0x13B18E0 VA: 0x13B18E0
        private void LateUpdate()
        {
            if(!m_isInitialized)
                return;
            if(m_arObject == null || m_arObject.CanDraw())
            {
                Vector3 v = m_trRoot.InverseTransformPoint(m_trHips.position);
                transform.localPosition = new Vector3(v.x, 0, v.y);
                m_shadowColor.a = Mathf.Clamp01(0.75f - Mathf.Clamp01(v.y / 10.0f) * 0.75f);
                m_material.color = m_shadowColor;
                transform.localScale = Vector3.one * m_baseScale * 30 * Mathf.Clamp01(Mathf.Clamp01(v.y / 10.0f) * 0.5f + 0.5f);
                if(m_renderer != null)
                    m_renderer.enabled = true;
            }
            else
            {
                if(m_renderer != null)
                    m_renderer.enabled = false;
            }
        }

        // // RVA: 0x13B1C48 Offset: 0x13B1C48 VA: 0x13B1C48
        public void SetSerialNo(int no)
        {
            m_id = no;
        }

        // // RVA: 0x13B1C50 Offset: 0x13B1C50 VA: 0x13B1C50
        public void SetBaseScale(float scale)
        {
            m_baseScale = scale;
        }

        // // RVA: 0x13B1C58 Offset: 0x13B1C58 VA: 0x13B1C58
        public void SetARObject(ARObject arObj)
        {
            m_arObject = arObj;
        }
    }
}