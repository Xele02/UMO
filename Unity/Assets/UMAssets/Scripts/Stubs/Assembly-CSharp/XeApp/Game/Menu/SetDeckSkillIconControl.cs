using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class SetDeckSkillIconControl : MonoBehaviour
	{
		[SerializeField]
		private Image m_skillIconImage;
		[SerializeField]
		private Sprite m_lSkillSprite;
		[SerializeField]
		private Sprite m_aSkillSprite;
		[SerializeField]
		private SpriteAnime m_effectAnime;
	}
}
