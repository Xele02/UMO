using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;

namespace XeApp.Game.MusicSelect
{
	public class MusicScrollItem : MonoBehaviour
	{
		[SerializeField]
		private Text _title;
		[SerializeField]
		private UGUIButton m_button;
		[SerializeField]
		private MusicScrollItemLabelGroup m_labelGroup;
		[SerializeField]
		private Image m_newIcon;
		[SerializeField]
		private Image m_attrIcon;
		[SerializeField]
		private MusicAttrIconScriptableObject m_attrIconSet;
		[SerializeField]
		private CanvasGroup m_lockObj;
		[SerializeField]
		private Image m_unlockableImage;
		[SerializeField]
		private CanvasGroup m_rewardObj;
		[SerializeField]
		private Image m_scoreReward;
		[SerializeField]
		private Image m_comboReward;
		[SerializeField]
		private Image m_clearCountReward;
		[SerializeField]
		private Text m_eventName;
		[SerializeField]
		private CanvasGroup m_highLevelObj;
		[SerializeField]
		private Text m_highLevelMusicName;
	}
}
