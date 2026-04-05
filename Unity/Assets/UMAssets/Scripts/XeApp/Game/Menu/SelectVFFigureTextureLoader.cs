
namespace XeApp.Game.Menu
{
    public class SelectVFFigureTextureLoader : DecorationSelectItemTextureLoaderBase
    {
        // // RVA: 0xA675E4 Offset: 0xA675E4 VA: 0xA675E4 Slot: 4
        public void Load(int id, int subId, LoadedCallback LoadedCallback)
        {
            MenuScene.Instance.ItemTextureCache.Load(EKLNMHFCAOI_ItemManager.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.HEMGMACMGAB_DecoItemVFFigure, id), (IiconTexture texture) =>
            {
                //0xA677E8
                LoadedCallback(texture, EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(id), subId);
            });
        }
    }
}