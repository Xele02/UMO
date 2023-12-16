
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Title
{ 
	public class PopupTitlePopupSupportSetting : PopupSetting
	{
		public override string PrefabPath { get { return "Layout/title/root_title_pop_01_layout_root"; } } //0xE3BD60
		public override string BundleName { get { return ""; } } //0xE3BDBC
		public override string AssetName { get { return "root_title_pop_01_layout_root"; } } //0xE3BE18
		public override bool IsAssetBundle { get { return false; } } //0xE3BE74
		public override bool IsPreload { get { return false; } } //0xE3BE7C
		public override GameObject Content { get { return m_content; } } //0xE3BE84
	}
}
