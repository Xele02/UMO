using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutQuestLoseItem : LayoutQuestRewardItem
	{
		[SerializeField]
		private Text m_textName;
		[SerializeField]
		private Text m_textRecvNum;
		[SerializeField]
		private Text m_textLoseNum;
	}
}
