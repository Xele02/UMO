using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class MusicSelectOptionButton : ActionButton
	{
		public enum OptionType
		{
			Ranking = 0,
			Reward = 1,
			MusicDetail = 2,
			EvRanking = 3,
			EvReward = 4,
			EnemyInfo = 5,
			EvStory = 6,
			EvMission = 7,
			_Num = 8,
		}

		[SerializeField]
		private RawImageEx m_fontImage;
		[SerializeField]
		private RawImageEx m_iconImage;
		[SerializeField]
		private RawImageEx m_buttonForeImage;
		[SerializeField]
		private RawImageEx m_buttonBackImage;
		[SerializeField]
		private RawImageEx m_eventIconImage;
		[SerializeField]
		private RawImageEx m_badgeImage;
		[SerializeField]
		private List<RawImageEx> m_dangerImage;
		[SerializeField]
		private OptionType m_optionType;
	}
}
