using XeSys.Gfx;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class NumberBase : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx[] m_numberImage;
		[SerializeField]
		private string m_texFormat;
		[SerializeField]
		private string m_symbolFormat;
	}
}
