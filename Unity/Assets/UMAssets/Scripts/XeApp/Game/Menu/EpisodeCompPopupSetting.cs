
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class EpisodeCompPopupSetting : PopupSetting
	{
		public PIGBBNDPPJC data { get; set; } // 0x34
		public List<MFDJIFIIPJD> ItemList { get; set; } // 0x38
		public int add_episode_point { get; set; } // 0x3C
		public bool is_restart { get; set; } // 0x40
		public override string PrefabPath { get { return ""; } } //0x127F64C
		public override string BundleName { get { return "ly/052.xab"; } } //0x127F6A8
		public override string AssetName { get { return "PopupEpisodeComp"; } } //0x127F704
		public override bool IsAssetBundle { get { return true; } } //0x127F760
		public override bool IsPreload { get { return true; } } //0x127F768
		public override GameObject Content { get { return m_content; } } //0x127F770

		//// RVA: 0x127F778 Offset: 0x127F778 VA: 0x127F778
		public void SetContent(GameObject obj)
		{
			m_content = obj;
		}
	}
}
