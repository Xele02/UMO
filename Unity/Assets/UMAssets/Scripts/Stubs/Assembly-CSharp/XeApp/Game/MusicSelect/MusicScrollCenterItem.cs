using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using TMPro;
using XeSys.Gfx;

namespace XeApp.Game.MusicSelect
{
	public class MusicScrollCenterItem : MonoBehaviour
	{
		[SerializeField]
		private Text m_musicName;
		[SerializeField]
		private Text m_singerNameText;
		[SerializeField]
		private UGUIButton m_rewardButton;
		[SerializeField]
		private UGUIButton m_rankingButton;
		[SerializeField]
		private UGUIButton m_musicInfoButton;
		[SerializeField]
		private UGUIButton m_enemyInfoButton;
		[SerializeField]
		private XeApp.Game.Common.ScrollText m_musicNameScroll;
		[SerializeField]
		private XeApp.Game.Common.ScrollText m_singerNameScroll;
		[SerializeField]
		private XeApp.Game.Common.ScrollText m_eventNameScroll;
		[SerializeField]
		private XeApp.Game.Common.ScrollText m_eventDescScroll;
		[SerializeField]
		private Image m_newIcon;
		[SerializeField]
		private TextMeshProUGUI m_musicListNo;
		[SerializeField]
		private MusicScrollItemLabelGroup m_labelGroup;
		[SerializeField]
		private RawImageEx m_seriesLogo;
		[SerializeField]
		private Image m_attrIcon;
		[SerializeField]
		private MusicAttrIconScriptableObject m_attrIconSet;
		[SerializeField]
		private Image m_attrBack;
		[SerializeField]
		private MusicAttrIconScriptableObject m_attrBackSet;
		[SerializeField]
		private Image m_attrArrow;
		[SerializeField]
		private MusicAttrIconScriptableObject m_attrArrowSet;
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
		private Text m_eventDesc;
		[SerializeField]
		private Text m_eventPeriod;
		[SerializeField]
		private CanvasGroup m_highLevelObj;
		[SerializeField]
		private Text m_highLevelMusicName;
		[SerializeField]
		private Text m_highLevelSingerName;
		[SerializeField]
		private XeApp.Game.Common.ScrollText m_highLevelMusicNameScroll;
		[SerializeField]
		private XeApp.Game.Common.ScrollText m_highLevelSingerNameScroll;
	}
}
