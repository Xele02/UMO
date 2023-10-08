
namespace XeApp.Game.Menu
{
    public class SelectVFFigureTextureLoader : DecorationSelectItemTextureLoaderBase
    {
        // // RVA: 0xA675E4 Offset: 0xA675E4 VA: 0xA675E4 Slot: 4
        public void Load(int id, int subId, LoadedCallback LoadedCallback)
        {
            MenuScene.Instance.ItemTextureCache.Load(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.HEMGMACMGAB_DecoItemVFFigure, id), (IiconTexture texture) =>
            {
                //0xA677E8
                LoadedCallback(texture, EKLNMHFCAOI.DEACAHNLMNI_getItemId(id), subId);
            });
        }
    }
}