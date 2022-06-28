using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class SceneGrowthEpisodeGauge : LayoutUGUIScriptBase
	{
    public void Awake() { UnityEngine.Debug.LogError("Immplement LayoutUGUIScriptBase"); }
		[SerializeField]
		private RawImageEx m_rewordImage;
		[SerializeField]
		private RawImageEx m_rewordMaskImage;
		[SerializeField]
		private Text m_addRewardText;
	}
}
