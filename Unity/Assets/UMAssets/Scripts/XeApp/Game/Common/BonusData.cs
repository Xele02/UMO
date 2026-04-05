using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class BonusData
	{
		private List<IKDICBBFBMI_NetEventBaseController.GNPOABJANKO> effectiveEpisodeBonus = new List<IKDICBBFBMI_NetEventBaseController.GNPOABJANKO>(); // 0x8

		public List<IKDICBBFBMI_NetEventBaseController.GNPOABJANKO> EffectiveEpisodeBonus { get { return effectiveEpisodeBonus; } } //0xE636F8

		// // RVA: 0xE63700 Offset: 0xE63700 VA: 0xE63700
		public void ClearEpisodeBonus()
		{
			effectiveEpisodeBonus.Clear();
		}

		// // RVA: 0xE63778 Offset: 0xE63778 VA: 0xE63778
		public void SetEpisodeBonus(List<IKDICBBFBMI_NetEventBaseController.GNPOABJANKO> bonusEpisodeList)
		{
			effectiveEpisodeBonus.Clear();
			for(int i = 0; i < bonusEpisodeList.Count; i++)
			{
				IKDICBBFBMI_NetEventBaseController.GNPOABJANKO d = new IKDICBBFBMI_NetEventBaseController.GNPOABJANKO();
				d.JKDJCFEBDHC_Enabled = bonusEpisodeList[i].JKDJCFEBDHC_Enabled;
				d.KELFCMEOPPM_EpisodeId = bonusEpisodeList[i].KELFCMEOPPM_EpisodeId;
				d.HEDODOBGPPM_BonusValue = bonusEpisodeList[i].HEDODOBGPPM_BonusValue;
				effectiveEpisodeBonus.Add(d);
			}
		}
	}
}
