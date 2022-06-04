using System.Collections;

namespace XeApp.Core
{
    public abstract class AssetBundleLoadOperation : IEnumerator // TypeDefIndex: 18439
    {
        // Properties
        public object Current { get; }

        // Methods

        // // RVA: 0xE11720 Offset: 0xE11720 VA: 0xE11720 Slot: 5
        // public object get_Current() { }

        // // RVA: 0xE11728 Offset: 0xE11728 VA: 0xE11728 Slot: 4
        public bool MoveNext()
        {
            UnityEngine.Debug.LogError("TODO");
            return false;
        }

        // // RVA: 0xE11748 Offset: 0xE11748 VA: 0xE11748 Slot: 6
        public void Reset()
        {
            UnityEngine.Debug.LogError("TODO");
        }

        // // RVA: -1 Offset: -1 Slot: 7
        // public abstract bool Update();

        // // RVA: -1 Offset: -1 Slot: 8
        public abstract bool IsError();

        // // RVA: -1 Offset: -1 Slot: 9
        // public abstract bool IsDone();

        // // RVA: 0xE0F788 Offset: 0xE0F788 VA: 0xE0F788
        // protected void .ctor() { }
    }
}