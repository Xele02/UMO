
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class PlayRecordView
	{
		public PlayRecordView_Total m_total; // 0x8
		public List<PlayRecordView_Diva> m_diva; // 0xC

		//// RVA: 0xDE3224 Offset: 0xDE3224 VA: 0xDE3224
		public void Create(BBHNACPENDM_ServerSaveData a_player_data)
		{
			Create_Total(a_player_data);
			Create_Diva(a_player_data);
			Setup_Costume(a_player_data);
		}

		//// RVA: 0xDE3254 Offset: 0xDE3254 VA: 0xDE3254
		private void Create_Total(BBHNACPENDM_ServerSaveData a_player_data)
		{
			m_total = new PlayRecordView_Total();
			m_total.Setup(a_player_data);
		}

		//// RVA: 0xDE32E4 Offset: 0xDE32E4 VA: 0xDE32E4
		private void Create_Diva(BBHNACPENDM_ServerSaveData a_player_data)
		{
			m_diva = new List<PlayRecordView_Diva>();
			for(int i = 0; i < 10; i++)
			{
				PlayRecordView_Diva data = new PlayRecordView_Diva();
				data.Setup(i + 1, a_player_data);
				m_diva.Add(data);
			}
		}

		//// RVA: 0xDE33F0 Offset: 0xDE33F0 VA: 0xDE33F0
		private void Setup_Costume(BBHNACPENDM_ServerSaveData a_player_data)
		{
			TodoLogger.Log(0, "Setup_Costume");
		}
	}
}
