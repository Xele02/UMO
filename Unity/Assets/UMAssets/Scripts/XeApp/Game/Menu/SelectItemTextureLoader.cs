
namespace XeApp.Game.Menu
{
    public class SelectItemTextureLoader : DecorationSelectItemTextureLoaderBase
    {
        // RVA: 0xA66AC4 Offset: 0xA66AC4 VA: 0xA66AC4 Slot: 4
        public void Load(int id, int subId, LoadedCallback LoadedCallback)
        {
            MenuScene.Instance.ItemTextureCache.Load(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj, id), (IiconTexture image) =>
            {
                //0xA66CC8
                LoadedCallback(image, EKLNMHFCAOI.DEACAHNLMNI_getItemId(id), subId);
            });
        }
    }
}