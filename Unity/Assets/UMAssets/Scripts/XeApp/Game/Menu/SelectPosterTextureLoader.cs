
namespace XeApp.Game.Menu
{
    public class SelectPosterTextureLoader : DecorationSelectItemTextureLoaderBase
    {
        // // RVA: 0xA66D9C Offset: 0xA66D9C VA: 0xA66D9C Slot: 4
        public void Load(int id, int subId, LoadedCallback LoadedCallback)
        {
            EKLNMHFCAOI.FKGCBLHOOCL_Category cat = 0;
            if(subId == 1)
            {
                cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.AEFGOANHNMG_DecoItemPosterSceneBef;
            }
            else if(subId == 2)
            {
                cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft;
            }
            else
            {
                cat = EKLNMHFCAOI.FKGCBLHOOCL_Category.OOMMOOIIPJE_DecoItemPoster;
            }
            MenuScene.Instance.ItemTextureCache.Load(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(cat, id), (IiconTexture texture) =>
            {
                //0xA6706C
                LoadedCallback(texture, EKLNMHFCAOI.DEACAHNLMNI_getItemId(id), subId);
            });
        }
    }
}