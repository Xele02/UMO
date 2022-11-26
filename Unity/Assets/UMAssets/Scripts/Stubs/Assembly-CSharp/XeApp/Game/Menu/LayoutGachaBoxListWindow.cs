using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutGachaBoxListWindow : LayoutGachaBoxListBase
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		[SerializeField]
		private Text m_textRemain;
		[SerializeField]
		private Text m_textRemainNum;
	}
}
