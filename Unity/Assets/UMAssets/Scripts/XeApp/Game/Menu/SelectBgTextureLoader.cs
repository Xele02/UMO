
namespace XeApp.Game.Menu
{
    public class SelectBgTextureLoader : DecorationSelectItemTextureLoaderBase
    {
        // RVA: 0xA66360 Offset: 0xA66360 VA: 0xA66360 Slot: 4
        public void Load(int id, int subId, LoadedCallback LoadedCallback)
        {
            MenuScene.Instance.DecorationItemTextureCache.LoadForSelectBg(id, subId, (IiconTexture image) =>
            {
                //0xA66500
                LoadedCallback(image, id, subId);
            });
        }
    }
}