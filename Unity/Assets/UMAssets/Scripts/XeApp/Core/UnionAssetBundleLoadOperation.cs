
namespace XeApp.Core
{
    public class UnionAssetBundleLoadOperation : AssetBundleLoadOperation
    {
        protected string m_AssetBundleName; // 0x8
        protected bool m_isLoaded; // 0xC
        protected string m_loadingError; // 0x10
        protected LoadedAssetBundle m_loadedAssetBundle; // 0x14

        // RVA: 0x1D74D6C Offset: 0x1D74D6C VA: 0x1D74D6C
        public UnionAssetBundleLoadOperation(string bundleName)
        {
            m_AssetBundleName = bundleName;
        }

        // RVA: 0x1D7829C Offset: 0x1D7829C VA: 0x1D7829C Slot: 7
        public override bool Update()
        {
            if(m_loadedAssetBundle == null)
            {
                m_loadedAssetBundle = AssetBundleManager.GetLoadedAssetBundle(m_AssetBundleName, out m_loadingError);
                return !IsError();
            }
            return !IsDone();
        }

        // RVA: 0x1D78364 Offset: 0x1D78364 VA: 0x1D78364 Slot: 9
        public override bool IsDone()
        {
            if(m_loadedAssetBundle == null)
            {
                if(IsError())
                    return true;
                return false;
            }
            return true;
        }

        // RVA: 0x1D783B0 Offset: 0x1D783B0 VA: 0x1D783B0 Slot: 8
        public override bool IsError()
        {
            return !string.IsNullOrEmpty(m_loadingError);
        }
    }
}