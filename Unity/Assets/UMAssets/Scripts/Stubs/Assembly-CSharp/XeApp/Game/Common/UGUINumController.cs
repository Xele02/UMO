using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace XeApp.Game.Common
{
	public class UGUINumController : MonoBehaviour
	{
		[SerializeField]
		private bool m_enableClampValue;
		[SerializeField]
		private bool m_dispAllDigits;
		[SerializeField]
		private Sprite m_spriteNum0;
		[SerializeField]
		private Sprite m_spriteNum1;
		[SerializeField]
		private Sprite m_spriteNum2;
		[SerializeField]
		private Sprite m_spriteNum3;
		[SerializeField]
		private Sprite m_spriteNum4;
		[SerializeField]
		private Sprite m_spriteNum5;
		[SerializeField]
		private Sprite m_spriteNum6;
		[SerializeField]
		private Sprite m_spriteNum7;
		[SerializeField]
		private Sprite m_spriteNum8;
		[SerializeField]
		private Sprite m_spriteNum9;
		[SerializeField]
		private Animator m_animatorDigits;
		[SerializeField]
		private List<Image> m_imagesNum;
	}
}
