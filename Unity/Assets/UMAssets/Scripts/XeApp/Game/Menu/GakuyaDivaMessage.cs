using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using System.Collections.Generic;
using XeSys;

namespace XeApp.Game.Menu
{
	public class GakuyaDivaMessage : MonoBehaviour
	{
		public enum PosType
		{
			Gakuya = 0,
			Home = 1,
		}

		[SerializeField]
		private UGUIEnterLeave m_enterLeaveControl; // 0xC
		[SerializeField]
		private Image m_imageDivaNameBase; // 0x10
		[SerializeField]
		private Text m_textDivaName; // 0x14
		[SerializeField]
		private Text m_textMessage; // 0x18
		[SerializeField]
		private Animator m_animatorPosition; // 0x1C
		[SerializeField]
		private List<Color> m_divaColor = new List<Color>(10); // 0x20

		public bool IsShown { get { return m_enterLeaveControl.IsShown; } } //0xB703A8

		// RVA: 0xB703D4 Offset: 0xB703D4 VA: 0xB703D4
		private void Awake()
		{
			return;
		}

		//// RVA: 0xB703D8 Offset: 0xB703D8 VA: 0xB703D8
		public void SetDiva(int divaId)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_textDivaName.text = bk.GetMessageByLabel(string.Format("diva_name_{0:D2}", divaId));
			int a = Mathf.Clamp(divaId - 1, 0, m_divaColor.Count - 1);
			m_imageDivaNameBase.color = m_divaColor[a];
		}

		// RVA: 0xB705E4 Offset: 0xB705E4 VA: 0xB705E4
		public void SetMessage(string message)
		{
			m_textMessage.text = message;
		}

		// RVA: 0xB70620 Offset: 0xB70620 VA: 0xB70620
		public void SetPos(PosType type)
		{
			m_animatorPosition.CrossFade(string.Format("Pos{0}", (int)type), 0);
		}

		// RVA: 0xB706DC Offset: 0xB706DC VA: 0xB706DC
		public void TryEnter()
		{
			m_enterLeaveControl.TryEnter();
		}

		// RVA: 0xB70708 Offset: 0xB70708 VA: 0xB70708
		public void TryLeave()
		{
			m_enterLeaveControl.TryLeave();
		}

		//// RVA: 0xB70734 Offset: 0xB70734 VA: 0xB70734
		//public void Enter() { }

		//// RVA: 0xB70760 Offset: 0xB70760 VA: 0xB70760
		//public void Leave() { }

		//// RVA: 0xB7078C Offset: 0xB7078C VA: 0xB7078C
		//public void Show() { }

		// RVA: 0xB707B8 Offset: 0xB707B8 VA: 0xB707B8
		public void Hide()
		{
			m_enterLeaveControl.Hide();
		}

		// RVA: 0xB707E4 Offset: 0xB707E4 VA: 0xB707E4
		public bool IsPlaying()
		{
			return m_enterLeaveControl.IsPlaying();
		}
	}
}
