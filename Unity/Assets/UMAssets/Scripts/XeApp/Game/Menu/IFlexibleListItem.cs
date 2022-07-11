
using UnityEngine;

namespace XeApp.Game.Menu
{
    public interface IFlexibleListItem
    {
        Vector2 Top { get; set; } //Slot: 0 Slot: 1
        float Height { get; set; } //Slot: 2 Slot: 3
        int ResourceType { get; set; }//  Slot: 4  Slot: 5
        FlexibleListItemLayout Layout { get; set; }//  Slot: 6  Slot: 7
    }
}