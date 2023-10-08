
namespace XeApp.Game.Menu
{
    public class SelectCostumeTorsoTextureLoader : DecorationSelectItemTextureLoaderBase
    {
        // // RVA: 0xA6672C Offset: 0xA6672C VA: 0xA6672C Slot: 4
        public void Load(int id, int subId, LoadedCallback LoadedCallback)
        {
            MenuScene.Instance.ItemTextureCache.Load(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.NNBMEEPOBIO_DecoItemCostumeTorso, id), (IiconTexture texture) =>
            {
                //0xA66930
                LoadedCallback(texture, EKLNMHFCAOI.DEACAHNLMNI_getItemId(id), subId);
            });
        }
    }
}