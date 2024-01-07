using System;
using System.Linq;
using UnityEngine.UI;
using XeSys.Gfx;

namespace XeApp.Game.DownLoad
{
	public class LayoutDownLoadArrow : LayoutUGUIScriptBase
	{
		private Action<LayoutDownLoadDefine.DirectionType> m_OnClickArrow; // 0x14
		private Button[] m_ArrowButtons; // 0x18
		private AbsoluteLayout m_rootAnim; // 0x1C

		public Action<LayoutDownLoadDefine.DirectionType> OnClickArrow { set { m_OnClickArrow = value; } } //0x11C2984

		// RVA: 0x11C54A0 Offset: 0x11C54A0 VA: 0x11C54A0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_ArrowButtons = GetComponentsInChildren<Button>(true);
			for(int i = 0; i < m_ArrowButtons.Length; i++)
			{
				int index = i;
				m_ArrowButtons[i].onClick.AddListener(() => {
					//0x11C5728
					if(m_OnClickArrow == null)
						return;
					m_OnClickArrow((LayoutDownLoadDefine.DirectionType)index);
				});
			}
			m_rootAnim = layout.FindViewByExId("sel_chara_arrow_all_sw_sel_chara_wind_anim") as AbsoluteLayout;
			Loaded();
			return true;
		}

		// // RVA: 0x11C2CE0 Offset: 0x11C2CE0 VA: 0x11C2CE0
		public bool IsReady()
		{
			if(IsLoaded())
			{
				return GetComponent<LayoutUGUIRuntime>().IsReady;
			}
			return false;
		}

		// // RVA: 0x11C3764 Offset: 0x11C3764 VA: 0x11C3764
		public void SetEnabledOperation(bool is_enable)
		{
			for(int i = 0; i < m_ArrowButtons.Length; i++)
			{
				m_ArrowButtons[i].enabled = is_enable;
			}
		}

		// // RVA: 0x11C3110 Offset: 0x11C3110 VA: 0x11C3110
		public void InVisible()
		{
			m_rootAnim.StartChildrenAnimGoStop("st_out");
		}

		// // RVA: 0x11C2E28 Offset: 0x11C2E28 VA: 0x11C2E28
		public void Visible()
		{
			m_rootAnim.StartChildrenAnimGoStop("st_wait");
		}

		// // RVA: 0x11C4264 Offset: 0x11C4264 VA: 0x11C4264
		public void SetButtonEnable()
		{
			for(int i = 0; i < m_ArrowButtons.Length; i++)
			{
				m_ArrowButtons[i].interactable = true;
			}
		}

		// // RVA: 0x11C4420 Offset: 0x11C4420 VA: 0x11C4420
		public void SetButtonDisable()
		{
			for(int i = 0; i < m_ArrowButtons.Length; i++)
			{
				m_ArrowButtons[i].interactable = false;
			}
		}
	}
}
