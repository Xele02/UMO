
using UnityEngine;

namespace XeApp.Game.UI
{
    public class FloatMover
    {
        public enum MoveType
        {
            Linear = 0,
            Sin = 1,
        }

        private float m_StartValue; // 0x8
        private float m_EndValue; // 0xC
        private float m_CurrentValue; // 0x10
        private float m_PassageTime; // 0x14
        private float m_MoveTime = -1; // 0x18
        private FloatMover.MoveType m_MoveType; // 0x1C

        public float Value { get { return m_CurrentValue; } } //0x191AD90
        public bool IsMoving { get { return m_MoveTime >= 0 && m_PassageTime <= m_MoveTime; } } //0x191AF0C

        // // RVA: 0x191AD98 Offset: 0x191AD98 VA: 0x191AD98
        public void Start(float startValue, float endValue, float moveTime, MoveType moveType)
        {
            m_MoveType = moveType;
            m_StartValue = startValue;
            m_EndValue = endValue;
            m_CurrentValue = startValue;
            m_PassageTime = 0;
            m_MoveTime = moveTime;
        }

        // // RVA: 0x191ADCC Offset: 0x191ADCC VA: 0x191ADCC
        public void Update()
        {
            if(m_MoveTime >= 0 && m_PassageTime <= m_MoveTime)
            {
                m_PassageTime += Time.deltaTime;
                if(m_MoveTime <= 0 || m_PassageTime / m_MoveTime >= 1)
                {
                    m_CurrentValue = m_EndValue;
                }
                else
                {
                    float r = m_PassageTime / m_MoveTime;
                    if(m_MoveType == MoveType.Sin)
                    {
                        m_CurrentValue = m_StartValue + (m_EndValue - m_StartValue) * Mathf.Sin(r * 1.570796f);
                    }
                    else if(m_MoveType == MoveType.Linear)
                    {
                        m_CurrentValue = m_StartValue + (m_EndValue - m_StartValue) * r;
                    }
                }
            }
        }
    }
}