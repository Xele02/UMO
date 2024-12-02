using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using XeSys.Gfx;

namespace XeApp.Game
{
	[ExecuteInEditMode]
	public class TextFontReapply : MonoBehaviour, ILayoutUGUIPaste
	{
		[SerializeField]
		private List<Text> m_textComponents; // 0xC

		//// RVA: 0x156FD00 Offset: 0x156FD00 VA: 0x156FD00
		//private void Reset() { }

		// RVA: 0x156FE50 Offset: 0x156FE50 VA: 0x156FE50
		private void Start()
		{
			SetFont(GameManager.Instance.GetSystemFont());
		}

		//// RVA: 0x156FD88 Offset: 0x156FD88 VA: 0x156FD88
		//public void Detect() { }

		//// RVA: 0x156FF34 Offset: 0x156FF34 VA: 0x156FF34
		public void SetFont(XeSys.FontInfo font)
		{
			for(int i = 0; i < m_textComponents.Count; i++)
			{
				font.Apply(m_textComponents[i]);
			}
		}

		// RVA: 0x1570018 Offset: 0x1570018 VA: 0x1570018 Slot: 4
		bool ILayoutUGUIPaste.InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			return true;
		}
	}
}
