
using UnityEngine;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
    public class NewMarkIcon
    {
        private const string ShowAnimLabel = "st_wait";
        private const string LoopStartAnimLabel = "lo_go_act";
        private const string LoopEndAnimLabel = "lo_en_act";
        private const string HideAnimLabel = "st_non";
        private const float LoopStartTime = 0.01666667f;
        private const float LoopEndTime = 0.9833334f;
        private AbsoluteLayout m_iconEffectLayout; // 0x8
        private AbsoluteLayout m_iconLayout; // 0xC
        private LayoutObject m_object; // 0x10

        // public static string ParentObjectName { get; } 0x1515A98

        // RVA: 0x1515AF4 Offset: 0x1515AF4 VA: 0x1515AF4
        public NewMarkIcon(GameObject parent)
		{
			m_object = GameManager.Instance.IconDecorationCache.GetInstance(Common.LayoutPoolManager.PoolType.New);
			m_object.Runtime.transform.SetParent(parent.transform, false);
			m_object.Runtime.transform.SetAsLastSibling();
			m_iconEffectLayout = m_object.Runtime.Layout.FindViewByExId("sw_new_anim_cmn_new_icon_eff") as AbsoluteLayout;
			m_iconLayout = m_object.Runtime.Layout.FindViewByExId("sw_new_anim_cmn_new_icon") as AbsoluteLayout;
		}

        // RVA: 0x1515E2C Offset: 0x1515E2C VA: 0x1515E2C
        public NewMarkIcon()
        {
            return;
        }

        // // RVA: 0x1515E34 Offset: 0x1515E34 VA: 0x1515E34
        public void Initialize(GameObject parent)
        {
            Release();
            m_object = GameManager.Instance.IconDecorationCache.GetInstance(LayoutPoolManager.PoolType.New);
            m_object.Runtime.transform.SetParent(parent.transform, false);
            m_object.Runtime.transform.SetAsLastSibling();
            m_iconEffectLayout = m_object.Runtime.Layout.FindViewByExId("sw_new_anim_cmn_new_icon_eff") as AbsoluteLayout;
            m_iconLayout = m_object.Runtime.Layout.FindViewByExId("sw_new_anim_cmn_new_icon") as AbsoluteLayout;
        }

        // // RVA: 0x1516250 Offset: 0x1516250 VA: 0x1516250
        public void SetActive(bool isActive)
		{
			m_object.Runtime.gameObject.SetActive(isActive);
			PlayLoopAnim();
		}

        // // RVA: 0x1516390 Offset: 0x1516390 VA: 0x1516390
        public bool IsActive()
        {
            if(m_object == null)
                return false;
            return m_object.Runtime.gameObject.activeSelf;
        }

        // // RVA: 0x1516168 Offset: 0x1516168 VA: 0x1516168
        public void Release()
        {
			if (m_object == null)
				return;
			GameManager.Instance.IconDecorationCache.Release(LayoutPoolManager.PoolType.New, m_object);
			m_iconEffectLayout = null;
			m_iconLayout = null;
			m_object = null;
        }

        // // RVA: 0x15163F4 Offset: 0x15163F4 VA: 0x15163F4
        // private void PlayShowAnim() { }

        // // RVA: 0x15162C4 Offset: 0x15162C4 VA: 0x15162C4
        private void PlayLoopAnim()
		{
			m_object.Runtime.Layout.StartAllAnimLoop("lo_go_act", "lo_en_act");
		}

        // // RVA: 0x15164B0 Offset: 0x15164B0 VA: 0x15164B0
        // private void PlayHideAnim() { }

        // // RVA: 0x151656C Offset: 0x151656C VA: 0x151656C
        public void OverridePlayTime(int time)
        {
            m_iconEffectLayout.StartAnimGoStop(time, time);
            m_iconLayout.StartAnimGoStop(time, time);
        }
    }
}
