
namespace XeSys.Gfx
{
    public class LayoutSymbolData
    {
        public LabelDefData def { get; private set; } // 0x8
        public AbsoluteLayout lyt { get; private set; } // 0xC
        private LayoutLabelScriptBase parent { get; set; } // 0x10

        // // RVA: 0x1EF8EAC Offset: 0x1EF8EAC VA: 0x1EF8EAC
        public LayoutSymbolData(LabelDefData def, AbsoluteLayout lyt, LayoutLabelScriptBase parent)
        {
            this.def = def;
            this.lyt = lyt;
            this.parent = parent;
        }

        // // RVA: 0x1EFA8B8 Offset: 0x1EFA8B8 VA: 0x1EFA8B8
        public void StartAnim(string presetName)
        {
            parent.StartAnim(FindPreset(presetName), lyt);
        }

        // // RVA: 0x1EFAA98 Offset: 0x1EFAA98 VA: 0x1EFAA98
        public void GoToFrame(string presetName, int frame)
		{
			parent.GoToFrame(FindPreset(presetName), lyt, frame);
		}

        // // RVA: 0x1EFAAE4 Offset: 0x1EFAAE4 VA: 0x1EFAAE4
        // public void GoToLabelFrame(string presetName, int frame = 0) { }

        // // RVA: 0x1EFAB30 Offset: 0x1EFAB30 VA: 0x1EFAB30
        // public void StartAllDecoLoop() { }

        // // RVA: 0x1EFAB5C Offset: 0x1EFAB5C VA: 0x1EFAB5C
        public bool IsPlaying()
        {
            if(IsChildren())
                return lyt.IsPlayingChildren();
            return lyt.IsPlaying();
        }

        // // RVA: 0x1EFA8F4 Offset: 0x1EFA8F4 VA: 0x1EFA8F4
        private LabelPreset FindPreset(string presetName)
        {
            for(int i = 0; i < def.presets.Count; i++)
            {
                if(def.presets[i].name == presetName)
                {
                    return def.presets[i];
                }
            }
            return null;
        }

        // // RVA: 0x1EFABA4 Offset: 0x1EFABA4 VA: 0x1EFABA4
        private bool IsChildren()
        {
            return (int)def.presets[0].type > 5;
        }
    }
}
