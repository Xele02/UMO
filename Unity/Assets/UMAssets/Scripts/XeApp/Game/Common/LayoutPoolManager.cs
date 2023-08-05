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

        private const int DivaIconDecorationMsizeCacheNum = 23;
        private const int DivaIconDecorationSsizeCacheNum = 26;
        private const int SceneIconDecorationLsizeCacheNum = 40;
        private const int SceneIconDecorationMsizeCacheNum = 24;
        private const int SceneIconDecorationSsizeCacheNum = 20;
        private const int FriendIconDecorationSsizeCacheNum = 19;
        private const int FriendIconDecorationMsizeCacheNum = 1;
        private const int BadgeIconDecorationCacheNum = 32;
		private readonly int[] m_poolSizeTable = new int[9] { 26, 23, 1, 44, 40, 20, 13, 1, 32 }; // 0x8
        private LayoutObjectPool[] m_pools = new LayoutObjectPool[9]; // 0xC
        private GameObject m_rootObject; // 0x10
        private MonoBehaviour m_monoBehaviour; // 0x14
        private Font m_useFont; // 0x18

        // // RVA: 0x11068B4 Offset: 0x11068B4 VA: 0x11068B4
        public LayoutPoolManager(GameObject parent)
        {
			m_rootObject = new GameObject("IconDecorationRoot");
			m_rootObject.transform.SetParent(parent.transform);
			for(int i = 0; i < 9; i++)
			{
				m_pools[i] = new LayoutObjectPool(m_rootObject, m_poolSizeTable[i]);
			}
		}

        // // RVA: 0x1106AE0 Offset: 0x1106AE0 VA: 0x1106AE0
        public void Release()
		{
			for(int i = 0; i < m_pools.Length; i++)
			{
				m_pools[i].Release();
			}
		}

        // // RVA: 0x1106B6C Offset: 0x1106B6C VA: 0x1106B6C
        public void Initialize(MonoBehaviour mb, Font font)
        {
			m_monoBehaviour = mb;
			m_useFont = font;
		}

        // // RVA: 0x1106B78 Offset: 0x1106B78 VA: 0x1106B78
        public void Reserve()
		{
			m_pools[0].Entry("ly/030.xab", "diva_icon_front_s", m_useFont, m_monoBehaviour);
			m_pools[1].Entry("ly/030.xab", "diva_icon_front_m", m_useFont, m_monoBehaviour);
			m_pools[2].Entry("ly/030.xab", "diva_icon_front_l", m_useFont, m_monoBehaviour);
			m_pools[3].Entry("ly/031.xab", "scene_icon_front_s", m_useFont, m_monoBehaviour);
			m_pools[4].Entry("ly/031.xab", "scene_icon_front_l", m_useFont, m_monoBehaviour);
			m_pools[5].Entry("ly/033.xab", "New", m_useFont, m_monoBehaviour);
			m_pools[6].Entry("ly/046.xab", "diva_icon_friend_s", m_useFont, m_monoBehaviour);
			m_pools[7].Entry("ly/046.xab", "diva_icon_friend_m", m_useFont, m_monoBehaviour);
			m_pools[8].Entry("ly/033.xab", "Badge", m_useFont, m_monoBehaviour);
		}

        // // RVA: 0x1107028 Offset: 0x1107028 VA: 0x1107028
        // public void Shrink() { }

        // // RVA: 0x110727C Offset: 0x110727C VA: 0x110727C
        public LayoutObject GetInstance(PoolType type)
		{
			return m_pools[(int)type].GetInstance();
		}

        // // RVA: 0x11072DC Offset: 0x11072DC VA: 0x11072DC
        public void Release(PoolType type, LayoutObject layout)
		{
			m_pools[(int)type].Release(layout);
		}

        // // RVA: 0x1107344 Offset: 0x1107344 VA: 0x1107344
        public bool IsReady()
		{
			for(int i = 0; i < m_pools.Length; i++)
			{
				if (!m_pools[i].IsReady)
					return false;
			}
			return true;
		}
    }
}
