using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game
{
	public class DebugCheatUI_SystemsBase : DebugCheatUIBase
	{
		[SerializeField]
		private GameObject category_list;
		[SerializeField]
		private GameObject categoriy_scroll_content;
		[SerializeField]
		private GameObject toggle_prefab;
		[SerializeField]
		private GameObject button_prefab;
		[SerializeField]
		private GameObject label_prefab;
		[SerializeField]
		private GameObject inputfield_prefab;
		[SerializeField]
		private GameObject item_list;
		[SerializeField]
		private Button button_back;
	}
}
