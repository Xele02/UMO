using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutGachaSkillUpPopup : LayoutUGUIScriptBase
	{
    public void Awake() { TodoLogger.LogError(0, "Implement LayoutUGUIScriptBase"); }
		[SerializeField]
		private RawImageEx PrePlateImage;
		[SerializeField]
		private RawImageEx NextPlateImage;
		[SerializeField]
		private RawImageEx PrePlateRank;
		[SerializeField]
		private RawImageEx NextPlateRank;
		[SerializeField]
		private Text PrePlateName;
		[SerializeField]
		private Text NextPlateName;
		[SerializeField]
		private Text PrePlateLevel;
		[SerializeField]
		private Text NextPlateLevel;
		[SerializeField]
		private Text PrePlateText;
		[SerializeField]
		private Text NextPlateText;
	}
}
