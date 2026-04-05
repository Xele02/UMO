
namespace XeApp.Game.Menu
{
    public class SelectSpTextureLoader : DecorationSelectItemTextureLoaderBase
    {
        // // RVA: 0xA67314 Offset: 0xA67314 VA: 0xA67314 Slot: 4
        public void Load(int id, int subId, LoadedCallback LoadedCallback)
        {
            MenuScene.Instance.ItemTextureCache.Load(EKLNMHFCAOI_ItemManager.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp, id), (IiconTexture texture) =>
            {
                //0xA67518
                LoadedCallback(texture, EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(id), subId);
            });
        }
    }
}