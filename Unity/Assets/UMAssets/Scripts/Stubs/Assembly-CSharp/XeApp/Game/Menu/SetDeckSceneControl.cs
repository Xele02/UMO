using UnityEngine;
using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class SetDeckSceneControl : MonoBehaviour
	{
		[SerializeField]
		private UGUIStayButton m_sceneButton;
		[SerializeField]
		private RawImageEx m_sceneImage;
		[SerializeField]
		private Image m_attrIconEffectImage;
		[SerializeField]
		private SpriteAnime m_attrIconEffectAnime;
		[SerializeField]
		private SetDeckSceneStatusControl m_statucControl;
		[SerializeField]
		private MusicAttrIconScriptableObject m_attrIconEffectSprites;
	}
}
