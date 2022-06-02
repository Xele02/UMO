using XeApp.Core;
using System;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class StoryMapScrollTest : MainSceneBase
{
	[Serializable]
	public class TextUIFormat
	{
		[SerializeField]
		private Text m_text;
		[SerializeField]
		private string m_format;
	}

	[SerializeField]
	private Button m_mainAddButton;
	[SerializeField]
	private Button m_mainRemoveButton;
	[SerializeField]
	private Button m_backAddButton;
	[SerializeField]
	private Button m_backRemoveButton;
	[SerializeField]
	private ScrollRect m_mainScrollView;
	[SerializeField]
	private ScrollRect m_backScrollView;
	[SerializeField]
	private GameObject m_mainContentPrefab;
	[SerializeField]
	private GameObject m_backContentPrefab;
	[SerializeField]
	private TextUIFormat m_mainCreateCount;
	[SerializeField]
	private TextUIFormat m_backCreateCount;
	[SerializeField]
	private List<Texture2D> m_backTextures;
	[SerializeField]
	private Button m_hideButton;
	[SerializeField]
	private List<GameObject> m_hidingObjects;
}
