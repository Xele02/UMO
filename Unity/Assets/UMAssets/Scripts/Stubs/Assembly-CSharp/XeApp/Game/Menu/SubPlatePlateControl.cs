using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class SubPlatePlateControl : LayoutUGUIScriptBase
	{
		[SerializeField]
		private LayoutUGUIRuntime m_runtime;
		[SerializeField]
		private GameObject m_baseObject;
		[SerializeField]
		private Text m_rateText;
		[SerializeField]
		private Text m_addText;
		[SerializeField]
		private int m_attribute;
		[SerializeField]
		private int m_status;
		[SerializeField]
		private GameObject m_lockIconObject;
		[SerializeField]
		private GameObject m_rateTextObject;
		[SerializeField]
		private RawImageEx m_image;
		[SerializeField]
		private StayButton m_detailButton;
		[SerializeField]
		private RectTransform m_arrow;
		public bool IsShowSceneDetail;
	}
}
