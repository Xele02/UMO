using System;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class GakuyaViewReturnButton : MonoBehaviour
	{
		[SerializeField]
		private UGUIEnterLeave m_enterLeaveControl; // 0xC
		[SerializeField]
		private UGUIButton m_buttonReturn; // 0x10
		public Action OnClickReturnButtonCallback; // 0x14

		public bool IsShown { get { return m_enterLeaveControl.IsShown; } } //0xB84210

		// RVA: 0xB8423C Offset: 0xB8423C VA: 0xB8423C
		private void Awake()
		{
			m_buttonReturn.AddOnClickCallback(() =>
			{
				//0xB8439C
				if (OnClickReturnButtonCallback != null)
					OnClickReturnButtonCallback();
			});
			m_buttonReturn.transform.Find("Top/Text").GetComponent<Text>().text = JpStringLiterals.UMO_Back;
		}

		//// RVA: 0xB842E4 Offset: 0xB842E4 VA: 0xB842E4
		//public void Enter() { }

		//// RVA: 0xB84310 Offset: 0xB84310 VA: 0xB84310
		//public void Leave() { }

		// RVA: 0xB71158 Offset: 0xB71158 VA: 0xB71158
		public void TryEnter()
		{
			m_enterLeaveControl.TryEnter();
		}

		// RVA: 0xB71098 Offset: 0xB71098 VA: 0xB71098
		public void TryLeave()
		{
			m_enterLeaveControl.TryLeave();
		}

		//// RVA: 0xB8433C Offset: 0xB8433C VA: 0xB8433C
		//public void Show() { }

		//// RVA: 0xB84368 Offset: 0xB84368 VA: 0xB84368
		//public void Hide() { }

		// RVA: 0xB70E48 Offset: 0xB70E48 VA: 0xB70E48
		public bool IsPlaying()
		{
			return m_enterLeaveControl.IsPlaying();
		}
	}
}
