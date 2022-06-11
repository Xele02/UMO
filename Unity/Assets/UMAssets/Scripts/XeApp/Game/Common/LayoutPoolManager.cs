using UnityEngine;

namespace XeApp.Game.Common
{
    public class LayoutPoolManager
    {
        public enum PoolType
        {
            DivaIcon_S = 0,
            DivaIcon_M = 1,
            DivaIcon_L = 2,
            SceneIcon_S = 3,
            SceneIcon_L = 4,
            New = 5,
            FriendIcon_S = 6,
            FriendIcon_M = 7,
            Badge = 8,
            Max = 9,
        }

        // Fields
        private const int DivaIconDecorationMsizeCacheNum = 23;
        private const int DivaIconDecorationSsizeCacheNum = 26;
        private const int SceneIconDecorationLsizeCacheNum = 40;
        private const int SceneIconDecorationMsizeCacheNum = 24;
        private const int SceneIconDecorationSsizeCacheNum = 20;
        private const int FriendIconDecorationSsizeCacheNum = 19;
        private const int FriendIconDecorationMsizeCacheNum = 1;
        private const int BadgeIconDecorationCacheNum = 32;
        private readonly int[] m_poolSizeTable; // 0x8
        private LayoutObjectPool[] m_pools; // 0xC
        private GameObject m_rootObject; // 0x10
        private MonoBehaviour m_monoBehaviour; // 0x14
        private Font m_useFont; // 0x18

        // // Methods

        // // RVA: 0x11068B4 Offset: 0x11068B4 VA: 0x11068B4
        public LayoutPoolManager(GameObject parent)
        {
            UnityEngine.Debug.LogError("TODO");
        }

        // // RVA: 0x1106AE0 Offset: 0x1106AE0 VA: 0x1106AE0
        // public void Release() { }

        // // RVA: 0x1106B6C Offset: 0x1106B6C VA: 0x1106B6C
        public void Initialize(MonoBehaviour mb, Font font)
        {
            UnityEngine.Debug.LogError("TODO");
        }

        // // RVA: 0x1106B78 Offset: 0x1106B78 VA: 0x1106B78
        // public void Reserve() { }

        // // RVA: 0x1107028 Offset: 0x1107028 VA: 0x1107028
        // public void Shrink() { }

        // // RVA: 0x110727C Offset: 0x110727C VA: 0x110727C
        // public LayoutObject GetInstance(LayoutPoolManager.PoolType type) { }

        // // RVA: 0x11072DC Offset: 0x11072DC VA: 0x11072DC
        // public void Release(LayoutPoolManager.PoolType type, LayoutObject layout) { }

        // // RVA: 0x1107344 Offset: 0x1107344 VA: 0x1107344
        // public bool IsReady() { }
    }
}