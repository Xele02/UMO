using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections.Generic;

namespace XeApp.Game
{
	public class DebugCheatMenuContent : MonoBehaviour
	{
		[Serializable]
		public class MenuElem
		{
			public DebugCheatUIBase prefab;
		}

		[SerializeField]
		private DebugCheatElemButton m_elemButtonPrefab;
		[SerializeField]
		private RectTransform m_listRoot;
		[SerializeField]
		private RectTransform m_scrollContent;
		[SerializeField]
		private RectTransform m_instanceRoot;
		[SerializeField]
		private Button m_contentClearButton;
		[SerializeField]
		private Toggle m_menuFoldoutToggle;
		[SerializeField]
		private List<DebugCheatMenuContent.MenuElem> m_menuElems;
	}
}
