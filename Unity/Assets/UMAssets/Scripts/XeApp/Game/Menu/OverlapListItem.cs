
using UnityEngine;

namespace XeApp.Game.Menu
{
    public class OverlapListItem : IFlexibleListItem
    {
        public Vector2 Top { get; set; } // 0x8
        public float Height { get; set; } // 0x10
        public int ResourceType { get; set; } // 0x14
        public FlexibleListItemLayout Layout { get; set; } // 0x18
        public GONMPHKGKHI_RewardView.LCMJJMNMIKG_RewardInfo Info { get; set; } // 0x1C
        public bool IsKira { get; set; } // 0x20
    }
}