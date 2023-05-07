using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System.Collections;
using mcrs;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortUGUIParts_Title_H1 : PopupFilterSortUGUIPartsBase
	{
		[SerializeField]
		private Text m_title_text; // 0x10
		[SerializeField]
		private UGUIButton[] m_btn; // 0x14
		[SerializeField]
		private Text[] m_btn_text; // 0x18
		private ButtonBase.OnClickCallback m_cb_btn; // 0x1C

		public override PopupFilterSortUGUIPartsBase.Type MyType { get { return PopupFilterSortUGUIPartsBase.Type.TitleH1; } } //0x179AAB0

		// [IteratorStateMachineAttribute] // RVA: 0x709CC4 Offset: 0x709CC4 VA: 0x709CC4
		// RVA: 0x179AAB8 Offset: 0x179AAB8 VA: 0x179AAB8 Slot: 5
		protected override IEnumerator OnInitialize()
		{
			//0x179AD00
			m_btn[0].AddOnClickCallback(() =>
			{
				//0x179AC8C
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				if(m_cb_btn != null)
					m_cb_btn();
			});
			yield break;
		}

		// RVA: 0x179AB64 Offset: 0x179AB64 VA: 0x179AB64
		public void SetTitle(string a_title)
		{
			m_title_text.text = a_title;
		}

		// // RVA: 0x179ABA0 Offset: 0x179ABA0 VA: 0x179ABA0
		public void SetButton(string a_name = "", ButtonBase.OnClickCallback a_cb = null)
		{
			m_cb_btn = a_cb;
			m_btn_text[0].text = a_name;
			EnableButton(true);
		}

		// // RVA: 0x179AC20 Offset: 0x179AC20 VA: 0x179AC20
		public void EnableButton(bool a_enable)
		{
			m_btn[0].Hidden = !a_enable;
		}
	}
}
