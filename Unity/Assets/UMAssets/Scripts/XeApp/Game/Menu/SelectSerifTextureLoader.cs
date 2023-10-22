
namespace XeApp.Game.Menu
{
    public class SelectSerifTextureLoader : DecorationSelectItemTextureLoaderBase
    {
        // // RVA: 0xA67138 Offset: 0xA67138 VA: 0xA67138 Slot: 4
        public void Load(int id, int subId, LoadedCallback LoadedCallback)
        {
            MenuScene.Instance.DecorationItemTextureCache.LoadForSelectSerif(id, (IiconTexture texture) =>
            {
                //0xA672C4
                LoadedCallback(texture, id, subId);
            });
        }
    }
}