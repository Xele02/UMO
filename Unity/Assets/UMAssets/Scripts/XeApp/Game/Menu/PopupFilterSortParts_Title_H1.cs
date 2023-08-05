using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using XeSys.Gfx;
using mcrs;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortParts_Title_H1 : PopupFilterSortPartsBase
	{
		[SerializeField]
		private Text m_title_text; // 0x1C
		[SerializeField]
		private ActionButton[] m_btn; // 0x20
		[SerializeField]
		private Text[] m_btn_text; // 0x24
		private ButtonBase.OnClickCallback m_cb_btn; // 0x28

		// RVA: 0x1C8CC6C Offset: 0x1C8CC6C VA: 0x1C8CC6C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_btn[0].AddOnClickCallback(() =>
			{
				//0x1C8CE8C
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				if(m_cb_btn != null)
					m_cb_btn();
			});
			return true;
		}

		// // RVA: 0x1C8CD64 Offset: 0x1C8CD64 VA: 0x1C8CD64
		public void SetTitle(string a_title)
		{
			m_title_text.text = a_title;
		}

		// // RVA: 0x1C8CDA0 Offset: 0x1C8CDA0 VA: 0x1C8CDA0
		public void SetButton(string a_name = "", ButtonBase.OnClickCallback a_cb = null)
		{
			m_cb_btn = a_cb;
			m_btn_text[0].text = a_name;
			EnableButton(true);
		}

		// // RVA: 0x1C8CE20 Offset: 0x1C8CE20 VA: 0x1C8CE20
		public void EnableButton(bool a_enable)
		{
			m_btn[0].Hidden = !a_enable;
		}
	}
}
