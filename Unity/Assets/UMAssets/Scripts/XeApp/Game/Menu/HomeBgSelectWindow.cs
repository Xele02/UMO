using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class HomeBgSelectWindow : MonoBehaviour
	{
		public UnityAction OnClickCancelEvent; // 0xC
		public UnityAction OnClickOkEvent; // 0x10
		public UnityAction OnClickPreviewEvent; // 0x14
		[SerializeField]
		private UGUIButton m_buttonCancel; // 0x18
		[SerializeField]
		private UGUIButton m_buttonOk; // 0x1C
		[SerializeField]
		private UGUIButton m_buttonPreview; // 0x20

		// RVA: 0x95F5D8 Offset: 0x95F5D8 VA: 0x95F5D8
		private void Awake()
		{
			m_buttonOk.ClearOnClickCallback();
			m_buttonOk.AddOnClickCallback(() =>
			{
				//0x95FB58
				if (OnClickOkEvent != null)
					OnClickOkEvent();
			});
			m_buttonCancel.ClearOnClickCallback();
			m_buttonCancel.AddOnClickCallback(() =>
			{
				//0x95FB6C
				if (OnClickCancelEvent != null)
					OnClickCancelEvent();
			});
			m_buttonPreview.ClearOnClickCallback();
			m_buttonPreview.AddOnClickCallback(() =>
			{
				//0x95FB80
				if (OnClickPreviewEvent != null)
					OnClickPreviewEvent();
			});
			m_buttonPreview.transform.Find("Top/Text").GetComponent<Text>().text = JpStringLiterals.UMO_Preview;
			m_buttonCancel.transform.Find("Top/Text").GetComponent<Text>().text = JpStringLiterals.UMO_Cancel;
			m_buttonOk.transform.Find("Top/Text").GetComponent<Text>().text = JpStringLiterals.UMO_Ok;
		}

		// RVA: 0x95F798 Offset: 0x95F798 VA: 0x95F798
		private void Start()
		{
			return;
		}

		// RVA: 0x95F79C Offset: 0x95F79C VA: 0x95F79C
		private void Update()
		{
			return;
		}

		//[ContextMenu] // RVA: 0x6E57DC Offset: 0x6E57DC VA: 0x6E57DC
		//// RVA: 0x95F7A0 Offset: 0x95F7A0 VA: 0x95F7A0
		//public void PasteStart() { }
	}
}
