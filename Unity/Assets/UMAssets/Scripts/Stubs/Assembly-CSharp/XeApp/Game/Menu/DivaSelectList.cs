using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.Events;

namespace XeApp.Game.Menu
{
	public class DivaSelectList : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_removeButton;
		[SerializeField]
		private StayButton m_selectDivaButton;
		[SerializeField]
		private RawImageEx m_selectDivaIconImage;
		[SerializeField]
		private RawImageEx m_selectDivaCenterIconImage;
		[SerializeField]
		private RawImageEx[] m_selectDivaSceneImages;
		[SerializeField]
		private RawImageEx[] m_skillIconImages;
		[SerializeField]
		private UnityEvent m_onRemoveEvent;
		[SerializeField]
		private SelectDivaEvent m_onSelectDivaEvent;
		[SerializeField]
		private SelectDivaEvent m_onShowDivaStatusEvent;
		[SerializeField]
		private SelecteDivaSceneSelectEvent m_onShowSelectedDivaSceneStatus;
		[SerializeField]
		private string m_animeLayoutExId;
		[SerializeField]
		private SwapScrollList m_scrollList;
	}
}
