using XeSys.Gfx;
using UnityEngine;
using System.Collections.Generic;
using XeApp.Game.Common;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class RankingListElemBase : GeneralListElemBase
	{
		[SerializeField]
		private RawImageEx m_divaIconImage;
		[SerializeField]
		private RawImageEx m_sceneIconImage;
		[SerializeField]
		private RawImageEx m_scoreLabelImage;
		[SerializeField]
		private RawImageEx m_pointUnitImage;
		[SerializeField]
		private RawImageEx m_musicRatioIconImage;
		[SerializeField]
		private List<RawImageEx> m_rankOrderImages;
		[SerializeField]
		private RawImageEx m_rankOrderUnit;
		[SerializeField]
		private ButtonBase m_profileButton;
		[SerializeField]
		private Text m_nameText;
		[SerializeField]
		private Text m_levelText;
		[SerializeField]
		private Text m_scoreText;
		[SerializeField]
		private Text m_damageText;
		[SerializeField]
		private Text m_rankOrderText;
		[SerializeField]
		private Text m_outOfRangeText;
		[SerializeField]
		private Text m_musicRatioText;
		[SerializeField]
		private NumberBase m_numberEventHiScore;
	}
}
