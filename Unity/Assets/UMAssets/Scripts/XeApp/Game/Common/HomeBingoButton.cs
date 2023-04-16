using System;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class HomeBingoButton : MonoBehaviour
	{
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x6897B8 Offset: 0x6897B8 VA: 0x6897B8
		private ButtonBase m_button; // 0xC
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x689800 Offset: 0x689800 VA: 0x689800
		private GameObject m_iconNew; // 0x10
		//[HeaderAttribute] // RVA: 0x689848 Offset: 0x689848 VA: 0x689848
		[SerializeField]
		private GameObject m_iconBegginer; // 0x14
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x68989C Offset: 0x68989C VA: 0x68989C
		private InOutAnime m_inOutAnime; // 0x18
		private int m_bingoId; // 0x1C

		public Action<int> onClickButton { private get; set; } // 0x20

		// RVA: 0xEA7CBC Offset: 0xEA7CBC VA: 0xEA7CBC
		private void Start()
		{
			m_button.ClearOnClickCallback();
			m_button.AddOnClickCallback(() =>
			{
				//0xEA80C8
				if (onClickButton != null)
					onClickButton(m_bingoId);
			});
		}

		//// RVA: 0xEA7D84 Offset: 0xEA7D84 VA: 0xEA7D84
		public void Setup(long currentTime)
		{
			bool b1 = false;
			bool b2 = false;
			bool b3 = false;
			if(GNGMCIAIKMA.HHCJCDFCLOB != null)
			{
				b3 = GNGMCIAIKMA.HHCJCDFCLOB.GBCPDBJEDHL(currentTime);
				m_bingoId = 0;
				if(GNGMCIAIKMA.HHCJCDFCLOB.CNADOFDDNLO_GetActiveBingos().Count > 0)
				{
					m_bingoId = GNGMCIAIKMA.HHCJCDFCLOB.CNADOFDDNLO_GetActiveBingos()[0];
					b2 = GNGMCIAIKMA.HHCJCDFCLOB.DOEGBMNNFKH(m_bingoId);
					if(b2 || GNGMCIAIKMA.HHCJCDFCLOB.DHPLHALIDHH(m_bingoId))
					{
						if(GNGMCIAIKMA.HHCJCDFCLOB.OBOGIOGEBPK(m_bingoId, FKMOKDCJFEN.ADCPCCNCOMD_Status.FJGFAPKLLCL_Achieved) > 0)
							b2 = true;
					}
					b2 = GNGMCIAIKMA.HHCJCDFCLOB.NJBPNCDPGNO(m_bingoId);
				}
			}
			m_button.gameObject.SetActive(b3);
			m_iconNew.SetActive(b1);
			m_iconBegginer.SetActive(b2);
		}

		//// RVA: 0xEA7F9C Offset: 0xEA7F9C VA: 0xEA7F9C
		public void Enter()
		{
			m_inOutAnime.Enter(false, null);
		}

		//// RVA: 0xEA7FD0 Offset: 0xEA7FD0 VA: 0xEA7FD0
		//public void Enter(float animTime) { }

		//// RVA: 0xEA8018 Offset: 0xEA8018 VA: 0xEA8018
		public void Leave()
		{
			m_inOutAnime.Leave(false, null);
		}

		//// RVA: 0xEA804C Offset: 0xEA804C VA: 0xEA804C
		//public void Leave(float animTime) { }

		//// RVA: 0xEA8094 Offset: 0xEA8094 VA: 0xEA8094
		public bool IsPlaying()
		{
			return m_inOutAnime.IsPlaying();
		}
	}
}
