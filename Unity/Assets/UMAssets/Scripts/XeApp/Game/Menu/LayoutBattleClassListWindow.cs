using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using XeSys.Gfx;
using System;
using System.Collections.Generic;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutBattleClassListWindow : LayoutShopListBase
	{
        [SerializeField]
        private Text[] m_textCaution; // 0x1C
        private AbsoluteLayout m_layoutRoot; // 0x20
        private PMFBBLGPLLJ m_view; // 0x24
        private Transform m_parent; // 0x28
        public Action<IHGLIHBAOII> OnSelectEvent; // 0x2C
        private bool m_isShow; // 0x30

        protected override AbsoluteLayout layoutRoot { get { return m_layoutRoot; } } //0x14C07DC

        // // RVA: 0x14C07E4 Offset: 0x14C07E4 VA: 0x14C07E4
        // public bool IsLoading() { }

        // RVA: 0x14C07FC Offset: 0x14C07FC VA: 0x14C07FC
        public void Setup(PMFBBLGPLLJ view, bool resetScroll/* = True*/)
        {
            m_view = view;
            m_parent = transform.parent;
            SetupList(view.KBHCHFDAHGL().Count, resetScroll);
        }

        // RVA: 0x14C08E0 Offset: 0x14C08E0 VA: 0x14C08E0 Slot: 7
        protected override void OnSelectListItem(int value, SwapScrollListContent content)
        {
            LayoutBattleClassListItem x = content as LayoutBattleClassListItem;
            if(x != null && OnSelectEvent != null)
            {
                OnSelectEvent(x.View);
            }
        }

        // RVA: 0x14C09F4 Offset: 0x14C09F4 VA: 0x14C09F4 Slot: 8
        protected override void OnUpdateListItem(int index, SwapScrollListContent content)
        {
            LayoutBattleClassListItem x = content as LayoutBattleClassListItem;
            if(x != null)
            {
                List<IHGLIHBAOII> l = m_view.KBHCHFDAHGL();
                if (index > -1 && l.Count > index)
                {
                    x.Setup(l[index]);
                }
            }
        }

        // RVA: 0x14C0B80 Offset: 0x14C0B80 VA: 0x14C0B80
        public void TryEnter()
        {
            if(!m_isShow)
                Enter();
        }

        // RVA: 0x14C0CE8 Offset: 0x14C0CE8 VA: 0x14C0CE8
        public void TryLeave()
        {
            if(m_isShow)
                Leave();
        }

        // // RVA: 0x14C0B90 Offset: 0x14C0B90 VA: 0x14C0B90
        public new void Enter()
        {
            transform.SetParent(GameManager.Instance.PopupCanvas.transform.GetChild(0));
            transform.SetAsFirstSibling();
            m_isShow = true;
            base.Enter();
        }

        // // RVA: 0x14C0CF8 Offset: 0x14C0CF8 VA: 0x14C0CF8
        public new void Leave()
        {
            transform.SetParent(m_parent);
            m_isShow = false;
            base.Leave();
        }

        // // RVA: 0x14C0D4C Offset: 0x14C0D4C VA: 0x14C0D4C
        // public void Show() { }

        // // RVA: 0x14C0D5C Offset: 0x14C0D5C VA: 0x14C0D5C
        // public void Hide() { }

        // RVA: 0x14C0D6C Offset: 0x14C0D6C VA: 0x14C0D6C Slot: 5
        public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
        {
            m_layoutRoot = layout.FindViewById("sw_s_m_btl_class_window_anim_01") as AbsoluteLayout;
            m_layoutRoot.StartChildrenAnimGoStop("st_wait");
            string str = MessageManager.Instance.GetBank("menu").GetMessageByLabel("music_event_battle_class_caution");
            string[] strs = str.Split(new char[] { '\n' });
            for(int i = 0; i < m_textCaution.Length; i++)
            {
                if(i < strs.Length)
                {
                    m_textCaution[i].text = strs[i];
                }
                else
                {
                    m_textCaution[i].text = "";
                }
            }
            Loaded();
            return true;
        }
    }
}
