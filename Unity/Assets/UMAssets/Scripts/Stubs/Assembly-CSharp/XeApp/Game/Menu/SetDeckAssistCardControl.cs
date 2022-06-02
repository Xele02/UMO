using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class SetDeckAssistCardControl : MonoBehaviour
	{
		[SerializeField]
		private SetDeckDivaCardControl m_divaCard;
		[SerializeField]
		private SetDeckSceneControl m_scene;
		[SerializeField]
		private GameObject m_assistIconObject;
		[SerializeField]
		private GameObject m_rivalIconObject;
		[SerializeField]
		private Image m_rivalRankImage;
		[SerializeField]
		private GameObject m_scoreObject;
		[SerializeField]
		private Text m_scoreText;
		[SerializeField]
		private GameObject m_tapGuardObject;
		[SerializeField]
		private List<Sprite> m_rivalRankSprite;
	}
}
