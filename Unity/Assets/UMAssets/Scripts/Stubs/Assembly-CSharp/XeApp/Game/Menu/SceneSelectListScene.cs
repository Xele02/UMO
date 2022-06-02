using UnityEngine;

namespace XeApp.Game.Menu
{
	public class SceneSelectListScene : TransitionRoot
	{
		[SerializeField]
		private EquipmentScene m_equipmentScene;
		[SerializeField]
		private SceneSelectList m_sceneSelectList;
		[SerializeField]
		private ListSortButtonGroup m_sortButtonGroup;
		[SerializeField]
		private PopupSortMenu.SortPlace m_sortPlace;
		[SerializeField]
		private PopupFilterSort.Scene m_popupFilterSortScene;
	}
}
