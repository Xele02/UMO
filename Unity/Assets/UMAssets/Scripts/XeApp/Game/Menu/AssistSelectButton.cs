using System;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class AssistSelectButton : MonoBehaviour
	{
		[SerializeField]
		private InOutAnime m_inOut; // 0xC
		[SerializeField]
		private ButtonBase buttonBase; // 0x10

		public Action OnClickButtonLisner { private get; set; } // 0x14

		// RVA: 0x1434A70 Offset: 0x1434A70 VA: 0x1434A70
		private void Awake()
		{
			buttonBase.AddOnClickCallback(() =>
			{
				//0x1434CE4
				if (OnClickButtonLisner != null)
					OnClickButtonLisner();
			});
			gameObject.SetActive(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.OANJBOPLCKP_IsUnit5Enabled());
		}

		//// RVA: 0x1434BE0 Offset: 0x1434BE0 VA: 0x1434BE0
		public void Enter()
		{
			if (!gameObject.activeSelf)
				return;
			m_inOut.Enter(false, null);
		}

		//// RVA: 0x1434C48 Offset: 0x1434C48 VA: 0x1434C48
		public void Leave()
		{
			if (!gameObject.activeSelf)
				return;
			m_inOut.Leave(false, null);
		}

		//// RVA: 0x1434CB0 Offset: 0x1434CB0 VA: 0x1434CB0
		public bool IsPlaying()
		{
			return m_inOut.IsPlaying();
		}
	}
}
