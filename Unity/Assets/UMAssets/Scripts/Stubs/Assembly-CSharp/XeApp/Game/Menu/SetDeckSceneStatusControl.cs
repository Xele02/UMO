using UnityEngine;
using XeApp.Game.Common;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class SetDeckSceneStatusControl : MonoBehaviour
	{
		[SerializeField]
		private GameObject m_paramObject;
		[SerializeField]
		private UGUICrossFader m_paramCrossFader;
		[SerializeField]
		private TextMeshProUGUI m_paramText;
		[SerializeField]
		private GameObject m_luckyLeafObject;
		[SerializeField]
		private UGUIPositionTable m_luckyLeafPosTbl;
		[SerializeField]
		private TextMeshProUGUI m_luckyLeafText;
		[SerializeField]
		private GameObject m_levelObject;
		[SerializeField]
		private UGUICrossFader m_levelCrossFader;
		[SerializeField]
		private GameObject m_levelMaxObject;
		[SerializeField]
		private TextMeshProUGUI m_levelText;
		[SerializeField]
		private GameObject m_skillIconObject;
		[SerializeField]
		private UGUICrossFader m_skillIconCrossFader;
		[SerializeField]
		private List<Image> m_skillIconImages;
		[SerializeField]
		private Image m_activeIconImage;
		[SerializeField]
		private GameObject m_episodeNameObject;
		[SerializeField]
		private Text m_episodeNameText;
		[SerializeField]
		private Image m_episodeNameBackImage;
		[SerializeField]
		private SkillIconScriptableObject m_skillIconSprites;
		[SerializeField]
		private Sprite m_episodeNameBackSpriteNormal;
		[SerializeField]
		private Sprite m_episodeNameBackSpriteBonus;
	}
}
