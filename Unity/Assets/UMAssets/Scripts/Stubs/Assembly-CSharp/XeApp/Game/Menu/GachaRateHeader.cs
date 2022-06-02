using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class GachaRateHeader : GachaRateElemBase
	{
		[SerializeField]
		private Text m_headerTitle;
		[SerializeField]
		private Text m_listTitle;
		[SerializeField]
		private List<Text> m_s6Percents;
		[SerializeField]
		private List<Text> m_s5Percents;
		[SerializeField]
		private List<Text> m_s4Percents;
		[SerializeField]
		private List<Text> m_s3Percents;
		[SerializeField]
		private List<Text> m_s2Percents;
		[SerializeField]
		private List<Text> m_s1Percents;
		[SerializeField]
		private List<float> m_elemHeights;
	}
}
