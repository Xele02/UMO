using System.Collections.Generic;
using XeSys;

namespace XeApp.Game.Common
{
	public class ViewDecoBgEffect
	{
		private MDDBFCFOKFC localSaveData = new MDDBFCFOKFC(); // 0x20

		public string Name { get; private set; } // 0x8
		public int EffectId { get; private set; } // 0xC
		public long OpenAt { get; private set; } // 0x10
		public long CloseAt { get; private set; } // 0x18

		// RVA: 0xD32894 Offset: 0xD32894 VA: 0xD32894
		public bool Init(long currentTime)
		{
			localSaveData.PCODDPDFLHK_Load();
			List<NDBFKHKMMCE_DecoItem.NNCIBDMDEFE> l = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.JDMCHNFAOFO;
			for(int i = 0; i < l.Count; i++)
			{
				if(l[i].PPEGAKEIEGM_Enabled == 2)
				{
					if(currentTime >= l[i].NMELNJNFMJF_Start)
					{
						if(currentTime < l[i].IAJAOIEOPDP_End)
						{
							Name = MessageManager.Instance.GetMessage("master", string.Format("bgeff_nm_{0:D4}", l[i].MDLEEKBBEKD));
							EffectId = l[i].EFNKCPBALOP_EffectId;
							OpenAt = l[i].NMELNJNFMJF_Start;
							CloseAt = l[i].IAJAOIEOPDP_End;
							return true;
						}
					}
				}
			}
			return false;
		}

		// RVA: 0xD32CC8 Offset: 0xD32CC8 VA: 0xD32CC8
		public bool CanShowPopup()
		{
			return OpenAt >= localSaveData.KOGBMDOONFA.NPDKEIIMCDI_LastShowtime;
		}

		//// RVA: 0xD32D24 Offset: 0xD32D24 VA: 0xD32D24
		public void SetLastShowTime(long currentTime)
		{
			localSaveData.KOGBMDOONFA.NPDKEIIMCDI_LastShowtime = currentTime;
		}

		//// RVA: 0xD32D80 Offset: 0xD32D80 VA: 0xD32D80
		public void SetShowStatus(bool isEnable)
		{
			localSaveData.KOGBMDOONFA.CINLIMIKCAL_EnableBgEffect = isEnable;
		}

		// RVA: 0xD32DC8 Offset: 0xD32DC8 VA: 0xD32DC8
		public bool IsEnableBgEffect()
		{
			return localSaveData.KOGBMDOONFA.CINLIMIKCAL_EnableBgEffect;
		}

		// RVA: 0xD32E08 Offset: 0xD32E08 VA: 0xD32E08
		public void Save()
		{
			localSaveData.HJMKBCFJOOH_Save();
		}
	}
}
