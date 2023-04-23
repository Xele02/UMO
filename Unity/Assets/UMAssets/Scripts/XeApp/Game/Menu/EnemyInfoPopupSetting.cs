
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class EnemyInfoPopupSetting : PopupSetting
	{
		public EJKBKMBJMGL_EnemyData enemyData { get; set; } // 0x34
		public override string PrefabPath { get { return ""; } } //0x12741A0
		public override string BundleName { get { return "ly/040.xab"; } } //0x12741FC
		public override string AssetName { get { return "PopupEnemyInfo"; } } //0x1274258
		public override bool IsAssetBundle { get { return true; } } //0x12742B4
		public override bool IsPreload { get { return true; } } //0x12742BC
		public override GameObject Content { get { return m_content; } } //0x12742C4

		//// RVA: 0x12742CC Offset: 0x12742CC VA: 0x12742CC
		public void SetContent(GameObject obj)
		{
			m_content = obj;
		}
	}
}
