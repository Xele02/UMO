
using UnityEngine;

namespace XeApp.Game.Common
{
    public interface IPopupContent
    {
        Transform Parent { get; } //  Slot: 6

        // // RVA: -1 Offset: -1 Slot: 0
        void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control);

        // // RVA: -1 Offset: -1 Slot: 1
        bool IsScrollable();

        // // RVA: -1 Offset: -1 Slot: 2
        void Show();

        // // RVA: -1 Offset: -1 Slot: 3
        void Hide();

        // // RVA: -1 Offset: -1 Slot: 4
        bool IsReady();

        // // RVA: -1 Offset: -1 Slot: 5
        void CallOpenEnd();
    }
}