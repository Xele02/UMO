using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Tutorial
{
	public class TutorialCharactor : MonoBehaviour
	{
		[SerializeField]
		private Sprite[] m_faceSpriteList;
		[SerializeField]
		private Image m_faceImage;
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement Monobehaviour");
		}
	}
}
