using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutOfferFormation : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton DoneBtn;
		[SerializeField]
		private ActionButton DissolutionBtn;
		[SerializeField]
		private ActionButton LeftButton;
		[SerializeField]
		private ActionButton RightButton;
		[SerializeField]
		private ActionButton NameChenge;
		[SerializeField]
		private Text PlatoonName;
		[SerializeField]
		private Text AttackText;
		[SerializeField]
		private Text AcccuracyText;
		[SerializeField]
		private ActionButton[] PlatoonButtons;
		[SerializeField]
		private RawImageEx[] SubValkyrieImageIcons;
		[SerializeField]
		private RawImageEx[] ValkyrieBanners;
		[SerializeField]
		private ActionButton[] ValkyrieBannerBtns;
		[SerializeField]
		private RawImageEx ValkyrieIcon;
	}
}
