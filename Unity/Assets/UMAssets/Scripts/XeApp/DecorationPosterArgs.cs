
using System.Diagnostics;
using UnityEngine;

namespace XeApp
{
    public class DecorationPosterArgs : DecorationItemArgsBase
    {
        public Material m_kiraMaterialSource; // 0x8
        public Material m_kiraMaterialFlipSource; // 0xC

        // RVA: 0xBB13F4 Offset: 0xBB13F4 VA: 0xBB13F4
        public DecorationPosterArgs(Material source, Material souceFlip)
        {
            m_kiraMaterialSource = source;
            m_kiraMaterialFlipSource = souceFlip;
        }
    }
}