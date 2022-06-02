using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class SetDeckSceneSetControl : MonoBehaviour
	{
		[SerializeField]
		private Image m_backImage;
		[SerializeField]
		private List<SetDeckSceneControl> m_scenes;
		[SerializeField]
		private DivaColorSetScriptableObject m_divaColors;
		[SerializeField]
		private Color m_emptyColor;
	}
}
