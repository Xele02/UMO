using XeApp.Game.Common;
using UnityEngine.UI;
using UnityEngine;
using System;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class PopupHelpBtn : SwapScrollListContent
	{
		public enum ICON_TYPE
		{
			HELP = 0,
			WIKI = 1,
		}

		private Action m_updater; // 0x20
		[SerializeField]
		private Text m_btn_name; // 0x24
		[SerializeField]
		private ActionButton m_btn; // 0x28
		[SerializeField]
		private AbsoluteLayout m_icon_table; // 0x2C

		// RVA: 0x17AA79C Offset: 0x17AA79C VA: 0x17AA79C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_icon_table = layout.FindViewById("swtbl_cmn_icon") as AbsoluteLayout;
			Loaded();
			return true;
		}

		// RVA: 0x17AA874 Offset: 0x17AA874 VA: 0x17AA874
		private void Start()
		{
			return;
		}

		// RVA: 0x17AA878 Offset: 0x17AA878 VA: 0x17AA878
		private void Update()
		{
			if (m_updater != null)
				m_updater();
		}

		//// RVA: 0x17AA88C Offset: 0x17AA88C VA: 0x17AA88C
		public void SetName(string str)
		{
			m_btn_name.text = str;
		}

		//// RVA: 0x17AA8C8 Offset: 0x17AA8C8 VA: 0x17AA8C8
		public void SetIcon(ICON_TYPE type)
		{
			m_icon_table.StartChildrenAnimGoStop((int)type, (int)type);
		}

		// RVA: 0x17AA900 Offset: 0x17AA900 VA: 0x17AA900
		public ActionButton GetBtn()
		{
			return m_btn;
		}
	}
}
