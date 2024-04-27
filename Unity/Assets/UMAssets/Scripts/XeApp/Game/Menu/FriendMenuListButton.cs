using XeApp.Game.Common;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class FriendMenuListButton : ActionButton
	{
		[SerializeField]
		private List<Text> m_listCountValues; // 0x80
		[SerializeField]
		private Text m_listMaxValue; // 0x84
		[SerializeField]
		private Text m_newCountValue; // 0x88
		[SerializeField]
		private RawImageEx m_newMarkImage; // 0x8C

		// RVA: 0xED4FCC Offset: 0xED4FCC VA: 0xED4FCC
		public void SetListCount(string count)
		{
			for(int i = 0; i < m_listCountValues.Count; i++)
			{
				m_listCountValues[i].text = count;
			}
		}

		// RVA: 0xED50B8 Offset: 0xED50B8 VA: 0xED50B8
		public void SetListMax(string max)
		{
			m_listMaxValue.text = max;
		}

		// RVA: 0xED50F4 Offset: 0xED50F4 VA: 0xED50F4
		public void SetNewMark(bool isVisible)
		{
			m_newMarkImage.enabled = isVisible;
		}

		// RVA: 0xED5128 Offset: 0xED5128 VA: 0xED5128
		public void SetNewCount(string count)
		{
			m_newCountValue.text = count;
		}

		// RVA: 0xED5164 Offset: 0xED5164 VA: 0xED5164 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			Loaded();
			return true;
		}
	}
}
