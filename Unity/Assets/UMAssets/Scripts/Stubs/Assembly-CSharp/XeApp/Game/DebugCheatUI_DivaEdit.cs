using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game
{
	public class DebugCheatUI_DivaEdit : DebugCheatUIBase
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
		[SerializeField]
		private GameObject category_list;
		[SerializeField]
		private GameObject categoriy_scroll_content;
		[SerializeField]
		private GameObject item_list;
		[SerializeField]
		private GameObject item_scroll_content;
		[SerializeField]
		private Button button_back;
		[SerializeField]
		private GameObject item_prefab;
		[SerializeField]
		private GameObject category_prefab;
	}
}
