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

        #if UNITY_EDITOR
        IEnumerator updateEnumerator;
        bool fixIsDone = false;
        public bool FixTextures(AssetBundle bundle)
        {
            if(fixIsDone)
                return false;
            if(updateEnumerator == null)
            {
                updateEnumerator = BundleShaderInfo.Instance.FixMaterialShader(bundle);
            }
            bool not_done = updateEnumerator.MoveNext();
            if(!not_done)
            {
                updateEnumerator = null;
                fixIsDone = true;
            }
            return not_done;
        }
        #endif
    }
}