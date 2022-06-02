using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class SetDeckMusicInfo : MonoBehaviour
	{
		[SerializeField]
		private InOutAnime m_inOut;
		[SerializeField]
		private UGUIPositionTable m_posTable;
		[SerializeField]
		private Image m_musicAttrImage;
		[SerializeField]
		private Image m_musicAttrEffectImage;
		[SerializeField]
		private SpriteAnime m_musicAttrEffectAnime;
		[SerializeField]
		private Image m_difficultyImage;
		[SerializeField]
		private Text m_musicNameText;
		[SerializeField]
		private GameObject m_expectedScoreGaugeObject;
		[SerializeField]
		private SetDeckExpectedScoreGauge m_expectedScoreGauge;
		[SerializeField]
		private UGUIButton m_expectedScoreDescButton;
		[SerializeField]
		private GameObject m_descriptionObject;
		[SerializeField]
		private Text m_descriptionText;
		[SerializeField]
		private ScrollText m_descriptionScroll;
		[SerializeField]
		private MusicAttrIconScriptableObject m_musicAttrSprites;
		[SerializeField]
		private MusicAttrIconScriptableObject m_musicAttrEffectSprites;
		[SerializeField]
		private List<Sprite> m_difficultySprites;
		[SerializeField]
		private List<Sprite> m_difficulty6LineSprites;
	}
}
