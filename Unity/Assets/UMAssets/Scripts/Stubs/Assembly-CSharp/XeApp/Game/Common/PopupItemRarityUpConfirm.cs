using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Common
{
	public class PopupItemRarityUpConfirm : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx m_imageBefore;
		[SerializeField]
		private RawImageEx m_imageAfter;
		[SerializeField]
		private Text m_textName;
		[SerializeField]
		private Text m_textDesc;
	}
}
