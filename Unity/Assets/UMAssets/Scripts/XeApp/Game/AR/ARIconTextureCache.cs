
using System;
using XeApp.Game.Menu;

namespace XeApp.Game.AR
{
    public class ARIconTexture : IconTexture
    {
        //
    }

    public class ARIconTextureCache : IconTextureCache
    {
        // RVA: 0x11D9688 Offset: 0x11D9688 VA: 0x11D9688
        public ARIconTextureCache() : base(0) 
        {
            //
        }

        // RVA: 0x11D9694 Offset: 0x11D9694 VA: 0x11D9694 Slot: 5
        public override void Terminated()
        {
            Clear();
        }

        // RVA: 0x11D969C Offset: 0x11D969C VA: 0x11D969C Slot: 7
        protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
        {
            ARIconTexture res = new ARIconTexture();
            SetupForSplitTexture(info, res);
            return res;
        }

        // // RVA: 0x11D9724 Offset: 0x11D9724 VA: 0x11D9724
        public void LoadStamp(string eventId, int stampId, int type, Action<IiconTexture> callback)
        {
            Load(string.Format("ct/ar/st/{0:D2}/{1}{2:D2}.xab", type + 1, eventId, stampId), callback);
        }

        // // RVA: 0x11D97F8 Offset: 0x11D97F8 VA: 0x11D97F8
        // public void LoadCampaignBanner(int bannerId, Action<IiconTexture> callback) { }

        // // RVA: 0x11D98A0 Offset: 0x11D98A0 VA: 0x11D98A0
        // public void LoadCampaign(string eventId, int no, Action<IiconTexture> callback) { }

        // // RVA: 0x11D8C9C Offset: 0x11D8C9C VA: 0x11D8C9C
        // public void LoadHelp(string path, Action<IiconTexture> callback) { }

        // // RVA: 0x11D9954 Offset: 0x11D9954 VA: 0x11D9954
        public void LoadDivaIcon(int divaId, Action<IiconTexture> callback)
        {
            Load(string.Format("ct/ar/dv/ic/{0:D2}.xab", divaId), callback);
        }
    }
}