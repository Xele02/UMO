using XeSys.Gfx;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game;

namespace XeApp.Game.Menu
{
	public class MusicSelectAttrFrame : LayoutUGUIScriptBase
	{
    public void Awake() { TodoLogger.Log(0, "Implement LayoutUGUIScriptBase"); }
		[SerializeField]
		private List<RawImageEx> m_frameImages;
		[SerializeField]
		private List<RawImageEx> m_subFrameImages;
		[SerializeField]
		private List<RawImageEx> m_rewardBgImages;
		[SerializeField]
		private TextureListSupport m_texListSupport;
	}
}
