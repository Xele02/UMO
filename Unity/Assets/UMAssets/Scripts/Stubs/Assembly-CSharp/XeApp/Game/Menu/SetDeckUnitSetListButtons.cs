using UnityEngine;
using System;
using XeApp.Game.Common;
using UnityEngine.UI;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class SetDeckUnitSetListButtons : MonoBehaviour
	{
		[Serializable]
		private class UnitButtonElement
		{
			[SerializeField]
			public UGUIButton m_button;
			[SerializeField]
			public Text m_nameText;
			[SerializeField]
			public ScrollText m_nameScroll;
			[SerializeField]
			public Image m_buttonImage;
		}

		[SerializeField]
		private InOutAnime m_inOut;
		[SerializeField]
		private Animator m_unitSetButtonsAnimator;
		[SerializeField]
		private List<SetDeckUnitSetListButtons.UnitButtonElement> m_unitButtons;
		[SerializeField]
		private List<SetDeckUnitSetListButtons.UnitButtonElement> m_switchUnitButtonsBefore;
		[SerializeField]
		private List<SetDeckUnitSetListButtons.UnitButtonElement> m_switchUnitButtonsAfter;
		[SerializeField]
		private UGUIButton m_pageButton;
		[SerializeField]
		private Text m_pageButtonText;
		[SerializeField]
		private Sprite m_unitButtonDefaultSprite;
		[SerializeField]
		private Sprite m_unitButtonSelectingSprite;
	}
}
