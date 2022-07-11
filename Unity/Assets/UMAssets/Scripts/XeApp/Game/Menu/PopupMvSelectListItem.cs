using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using UnityEngine.Events;

namespace XeApp.Game.Menu
{
	public class PopupMvSelectListItem : FlexibleListItemLayout
	{
		[SerializeField]
		private RawImageEx m_iconImage; // 0x18
		[SerializeField]
		private RawImageEx m_setIcon; // 0x1C
		[SerializeField]
		private RawImageEx m_subImage; // 0x20
		[SerializeField]
		private Text m_nameText; // 0x24
		[SerializeField]
		private ActionButton m_button; // 0x28
		private TexUVList m_uvData; // 0x2C
		private AbsoluteLayout m_cursorLayout; // 0x30
		private AbsoluteLayout m_cursorLayout2; // 0x34
		private AbsoluteLayout m_backGroundLayout; // 0x38

		public int ListIndex { get; private set; } // 0x3C

		// RVA: 0x169CC08 Offset: 0x169CC08 VA: 0x169CC08 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_uvData = uvMan.GetTexUVList("pop_simu_pack");
			m_cursorLayout = layout.FindViewByExId("sw_pop_simu_icon_sw_pop_simu_cursor_anim_01") as AbsoluteLayout;
			m_cursorLayout2 = layout.FindViewByExId("sw_pop_simu_icon_sw_pop_simu_cursor_anim_02") as AbsoluteLayout;
			m_backGroundLayout = layout.FindViewByExId("sw_pop_simu_icon_swtbl_pop_simu_frm02") as AbsoluteLayout;
			return base.InitializeFromLayout(layout, uvMan);
		}

		// // RVA: 0x169B6B8 Offset: 0x169B6B8 VA: 0x169B6B8
		public void SetListIndex(int listIndex)
		{
			ListIndex = listIndex;
		}

		// // RVA: 0x169B6C0 Offset: 0x169B6C0 VA: 0x169B6C0
		public void HideTexture()
		{
			m_iconImage.enabled = false;
			m_subImage.enabled = false;
		}

		// // RVA: 0x169C0D4 Offset: 0x169C0D4 VA: 0x169C0D4
		public void SetTexture(IiconTexture texture) 
		{
			texture.Set(m_iconImage);
			m_iconImage.enabled = true;
		}

		// // RVA: 0x169B7AC Offset: 0x169B7AC VA: 0x169B7AC
		public void SetSubImage(IiconTexture texture)
		{
			if(texture == null)
			{
				m_subImage.material = null;
				m_subImage.MaterialMul = null;
				m_subImage.texture = null;
			}
			else
			{
				texture.Set(m_subImage);
			}
			m_subImage.enabled = true;
		}

		// // RVA: 0x169B47C Offset: 0x169B47C VA: 0x169B47C
		public void SetImageState(bool isSet)
		{
			m_setIcon.enabled = isSet;
			if(m_cursorLayout == null || m_cursorLayout2 == null)
				return;
			m_cursorLayout.StartChildrenAnimLoop(isSet ? "lo_" : "sw_wait");
			m_cursorLayout2.StartChildrenAnimLoop(isSet ? "lo_" : "st_wait");
		}

		// // RVA: 0x169B67C Offset: 0x169B67C VA: 0x169B67C
		public void SetName(string name)
		{
			m_nameText.text = name;
		}

		// // RVA: 0x169B718 Offset: 0x169B718 VA: 0x169B718
		public void SetBackGround(bool isEnable)
		{
			m_backGroundLayout.StartChildrenAnimGoStop(isEnable ? "on" : "off");
		}

		// // RVA: 0x169B56C Offset: 0x169B56C VA: 0x169B56C
		public void SetButtonEvent(UnityAction action)
		{
			m_button.ClearOnClickCallback();
			m_button.AddOnClickCallback(() => {
				//0x169CE18
				if(action != null)
					action.Invoke();
			});
		}
	}
}
