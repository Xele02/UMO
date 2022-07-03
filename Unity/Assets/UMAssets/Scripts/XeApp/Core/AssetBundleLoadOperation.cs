using System.Collections;
using UnityEngine;

namespace XeApp.Core
{
    public abstract class AssetBundleLoadOperation : IEnumerator
    {
        public object Current { get { return null; } } // get_Current 0xE11720

        // // RVA: 0xE11728 Offset: 0xE11728 VA: 0xE11728 Slot: 4
        public bool MoveNext()
        {
            return !IsDone();
        }

        // // RVA: 0xE11748 Offset: 0xE11748 VA: 0xE11748 Slot: 6
        public void Reset()
        {
            return;
        }

        // // RVA: -1 Offset: -1 Slot: 7
        public abstract bool Update();

        // // RVA: -1 Offset: -1 Slot: 8
        public abstract bool IsError();

        // // RVA: -1 Offset: -1 Slot: 9
        public abstract bool IsDone();
    }
}