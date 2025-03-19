using UnityEngine.UI;
using UnityEngine;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortUGUIParts_Title_H2 : PopupFilterSortUGUIPartsBase
	{
		[SerializeField]
		private Text m_title_text; // 0x10

		public override Type MyType { get { return Type.TitleH2; } } // 0x179AE9C

		// [IteratorStateMachineAttribute] // RVA: 0x709D9C Offset: 0x709D9C VA: 0x709D9C
		// // RVA: 0x179AEA4 Offset: 0x179AEA4 VA: 0x179AEA4 Slot: 5
		protected override IEnumerator OnInitialize()
		{
			//0x179AF80
			yield break;
		}

		// // RVA: 0x179AF38 Offset: 0x179AF38 VA: 0x179AF38
		public void SetTitle(string a_title)
		{
			m_title_text.text = a_title;
		}
	}
}
