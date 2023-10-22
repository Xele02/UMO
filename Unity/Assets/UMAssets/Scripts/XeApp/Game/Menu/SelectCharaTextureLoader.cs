
namespace XeApp.Game.Menu
{
    public class SelectCharaTextureLoader : DecorationSelectItemTextureLoaderBase
    {
        // // RVA: 0xA66550 Offset: 0xA66550 VA: 0xA66550 Slot: 4
        public void Load(int id, int subId, LoadedCallback LoadedCallback)
        {
            MenuScene.Instance.DecorationItemTextureCache.LoadForSelectChara(id, (IiconTexture image) =>
            {
                //0xA666DC
                LoadedCallback(image, id, subId);
            });
        }
    }
}