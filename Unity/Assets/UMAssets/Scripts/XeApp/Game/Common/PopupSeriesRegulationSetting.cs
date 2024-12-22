
using UnityEngine;

namespace XeApp.Game.Common
{
    public class PopupSeriesRegulationSetting : PopupSetting
    {
        public int SeriesId { get; set; } // 0x34
        public override bool IsPreload { get { return false; } } //0x1BB2044
        public override bool IsAssetBundle { get { return true; } } //0x1BB204C
        public override string PrefabPath { get { return ""; } } //0x1BB2054
        public override string BundleName { get { return "ly/016.xab"; } } //0x1BB20B0
        public override string AssetName { get { return "root_pop_series_skill_layout_root"; } } //0x1BB210C
        public override GameObject Content { get { return m_content; } } //0x1BB2168
    }
}