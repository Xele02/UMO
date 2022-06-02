using UnityEngine;
using UnityEngine.UI;
using XeApp.Game;

namespace XeApp.Game.Adv
{
	public class AdvCharacter : MonoBehaviour
	{
		[SerializeField]
		private Image _body;
		[SerializeField]
		private Image _eye;
		[SerializeField]
		private Image _mouth;
		[SerializeField]
		private RawImage _aura;
		[SerializeField]
		private RawImage _prism;
		[SerializeField]
		private AdvCharacterData _charaData;
		[SerializeField]
		private ColorTween[] m_showTween;
		[SerializeField]
		private TweenBase[] m_pickupTween;
		[SerializeField]
		private ColorTween[] m_hideTween;
		[SerializeField]
		private Material auraMaterialSource;
		[SerializeField]
		private Material prismMaterialSource;
	}
}
