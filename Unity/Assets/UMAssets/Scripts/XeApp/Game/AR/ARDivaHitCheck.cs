
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.AR
{
    public class ARDivaHitCheck : MonoBehaviour
    {
        [SerializeField]
        private ARDivaObject m_divaObject; // 0xC
        private Vector3 m_bbMax = Vector3.zero; // 0x10
        private Vector3 m_bbMin = Vector3.zero; // 0x1C

        // RVA: 0x161D100 Offset: 0x161D100 VA: 0x161D100
        private void LateUpdate()
        {
            if(m_divaObject.divaPrefab != null)
            {
                m_bbMax = new Vector3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);
                m_bbMin = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
                SkinnedMeshRenderer[] srs = m_divaObject.divaPrefab.GetComponentsInChildren<SkinnedMeshRenderer>();
                for(int i = 0; i < srs.Length; i++)
                {
                    m_bbMax = Vector3.Max(m_bbMax, srs[i].bounds.max);
                    m_bbMin = Vector3.Min(m_bbMin, srs[i].bounds.min);
                }
            }
        }

        // RVA: 0x161D3D0 Offset: 0x161D3D0 VA: 0x161D3D0
        public bool IsHitDiva(Vector3 pos, float scale = 1)
        {
            if(m_divaObject.divaPrefab != null)
            {
                Vector3 v = m_bbMax * scale;
                Vector3 v2 = m_bbMin * scale;
                if(v.x < pos.x || pos.x < v2.x || 
                   v.y < pos.y || pos.y < v2.y || 
                   v.z < pos.z || pos.z < v2.z)
                    return false;
                else
                    return true;
            }
            return false;
        }
    }
}