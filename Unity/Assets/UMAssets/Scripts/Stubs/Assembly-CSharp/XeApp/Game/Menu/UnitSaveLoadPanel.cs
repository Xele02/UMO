using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class UnitSaveLoadPanel : SwapScrollListContent
	{
		[SerializeField]
		private RawImageEx[] m_divaIconImages;
		[SerializeField]
		private RawImageEx[] m_sceneIconImages;
		[SerializeField]
		private StayButton[] m_divaStayButtons;
		[SerializeField]
		private StayButton[] m_sceneStayButtons;
		[SerializeField]
		private ActionButton m_detailButton;
		[SerializeField]
		private ActionButton m_saveButton;
		[SerializeField]
		private ActionButton m_loadButton;
		[SerializeField]
		private RawImageEx m_saveButtonLabel;
		[SerializeField]
		private RawImageEx m_loadButtonLabel;
		[SerializeField]
		private Text m_slotNumberText;
		[SerializeField]
		private Text m_unitNameText;
		[SerializeField]
		private Text m_totalText;
	}
}
