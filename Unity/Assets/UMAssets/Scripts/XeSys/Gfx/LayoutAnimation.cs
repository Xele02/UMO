
using System.Collections.Generic;

namespace XeSys.Gfx
{
    public class LayoutAnimation
    {
        private enum ETagType
        {
            LayoutAnim = 0,
            Layer = 1,
            Frame = 2,
            Label = 3,
            CtrlType = 4,
            CtrlPoint = 5,
            TimeMap = 6,
            CustomTimeMap = 7,
        }

        private enum ECtrlType
        {
            frameIdx = 0,
            time = 1,
            x = 2,
            xn = 3,
            xp = 4,
            y = 5,
            yn = 6,
            yp = 7,
            rot = 8,
            scaleX = 9,
            scaleY = 10,
            rp = 11,
            ro = 12,
            gp = 13,
            go = 14,
            bp = 15,
            bo = 16,
            ap = 17,
            ao = 18,
            none = 19,
        }

        private class SCtrlTypeSet
        {
            private string m_TypeStr; // 0x8
            private LayoutAnimation.ECtrlType m_CtrlType; // 0xC

            // public string TypeStr { get; } 0x1EF7948
            // public LayoutAnimation.ECtrlType CtrlType { get; } 0x1EF7950

            // RVA: 0x1EF7958 Offset: 0x1EF7958 VA: 0x1EF7958
            public SCtrlTypeSet(string str, LayoutAnimation.ECtrlType type)
            {
                m_TypeStr = str;
                m_CtrlType = type;
            }
        }

        private const string LayoutAnimTag = "LA";
        private const string idAtt = "id";
        private const string LayerTag = "La";
        private const string AlignHAtt = "aH";
        private const string AlignVAtt = "aV";
        private const string FrameNumAtt = "FN";
        private const string FrameTag = "Fr";
        private const string LabelTag = "Lb";
        private const string CtrlTypeTag = "CT";
        private const string CtrlPointTag = "CP";
        private const string TimeMapTag = "TM";
        private const string CustomTimeMapTag = "CTM";
        private const string QuadraticElmStr = "Q";
        private const string CustomElmStr = "C";
        private const int TimeMapElmStartIdx = 0;
        private const int TimeMapElmEndIdx = 1;
        private const int TimeMapElmTypeIdx = 2;
        private const int TimeMapElmStrengthIdx = 3;
        private const int TimeMapElmNumIdx = 4;
        private const int TimeMapElmNum = 5;
        private const int CustomTimeMapElmPointIdx = 0;
        private const int CustomTimeMapElmNextIdx = 1;
        private const int CustomTimeMapElmPrevIdx = 2;
        private const int CustomTimeMapElmNum = 3;
        private const string CtrlTypeXStr = "X";
        private const string CtrlTypeXNStr = "XN";
        private const string CtrlTypeXPStr = "XP";
        private const string CtrlTypeYStr = "Y";
        private const string CtrlTypeYNStr = "YN";
        private const string CtrlTypeYPStr = "YP";
        private const string CtrlTypeRotStr = "Rot";
        private const string CtrlTypeScaleXStr = "ScaleX";
        private const string CtrlTypeScaleYStr = "ScaleY";
        private const string CtrlTypeRpStr = "Rp";
        private const string CtrlTypeRoStr = "Ro";
        private const string CtrlTypeGpStr = "Gp";
        private const string CtrlTypeGoStr = "Go";
        private const string CtrlTypeBpStr = "Bp";
        private const string CtrlTypeBoStr = "Bo";
        private const string CtrlTypeApStr = "Ap";
        private const string CtrlTypeAoStr = "Ao";
        private static Dictionary<string, LayoutAnimation.ETagType> TagToTypeDic = new Dictionary<string, ETagType>() {
            { LayoutAnimTag, ETagType.LayoutAnim },
            { LayerTag, ETagType.Layer },
            { FrameTag, ETagType.Frame },
            { LabelTag, ETagType.Label },
            { CtrlTypeTag, ETagType.CtrlType },
            { CtrlPointTag, ETagType.CtrlPoint },
            { TimeMapTag, ETagType.TimeMap },
            { CustomTimeMapTag, ETagType.CustomTimeMap }
        }; // 0x0
        private static LayoutAnimation.SCtrlTypeSet[] TypeSetTbl = new SCtrlTypeSet[17] {
            new SCtrlTypeSet(CtrlTypeXStr, ECtrlType.x),
            new SCtrlTypeSet(CtrlTypeXNStr, ECtrlType.xn),
            new SCtrlTypeSet(CtrlTypeXPStr, ECtrlType.xp),
            new SCtrlTypeSet(CtrlTypeYStr, ECtrlType.y),
            new SCtrlTypeSet(CtrlTypeYNStr, ECtrlType.yn),
            new SCtrlTypeSet(CtrlTypeYPStr, ECtrlType.yp),
            new SCtrlTypeSet(CtrlTypeRotStr, ECtrlType.rot),
            new SCtrlTypeSet(CtrlTypeScaleXStr, ECtrlType.scaleX),
            new SCtrlTypeSet(CtrlTypeScaleYStr, ECtrlType.scaleY),
            new SCtrlTypeSet(CtrlTypeRpStr, ECtrlType.rp),
            new SCtrlTypeSet(CtrlTypeRoStr, ECtrlType.ro),
            new SCtrlTypeSet(CtrlTypeGpStr, ECtrlType.gp),
            new SCtrlTypeSet(CtrlTypeGoStr, ECtrlType.go),
            new SCtrlTypeSet(CtrlTypeBpStr, ECtrlType.bp),
            new SCtrlTypeSet(CtrlTypeBoStr, ECtrlType.bo),
            new SCtrlTypeSet(CtrlTypeApStr, ECtrlType.ap),
            new SCtrlTypeSet(CtrlTypeAoStr, ECtrlType.ao)
        }; // 0x4
        private static Dictionary<string, LayoutAnimation.ECtrlType> TypeSetDic = new Dictionary<string, ECtrlType>() {
            { CtrlTypeXStr, ECtrlType.x},
            { CtrlTypeXNStr, ECtrlType.xn},
            { CtrlTypeXPStr, ECtrlType.xp},
            { CtrlTypeYStr, ECtrlType.y},
            { CtrlTypeYNStr, ECtrlType.yn},
            { CtrlTypeYPStr, ECtrlType.yp},
            { CtrlTypeRotStr, ECtrlType.rot},
            { CtrlTypeScaleXStr, ECtrlType.scaleX},
            { CtrlTypeScaleYStr, ECtrlType.scaleY},
            { CtrlTypeRpStr, ECtrlType.rp},
            { CtrlTypeRoStr, ECtrlType.ro},
            { CtrlTypeGpStr, ECtrlType.gp},
            { CtrlTypeGoStr, ECtrlType.go},
            { CtrlTypeBpStr, ECtrlType.bp},
            { CtrlTypeBoStr, ECtrlType.bo},
            { CtrlTypeApStr, ECtrlType.ap},
            { CtrlTypeAoStr, ECtrlType.ao}
        }; // 0x8
        private const int LabelLabelElmIdx = 0;
        private const int LabelFrameElmIdx = 1;
        private string m_Name; // 0x8
        private static float DefaultFrameSec = 0.0333333f; // 0xC
        private float m_FrameSec = DefaultFrameSec; // 0xC
        private Dictionary<string, ViewFrameAnimation> m_AnimLayers = new Dictionary<string, ViewFrameAnimation>(); // 0x10
        private Dictionary<string, string> m_TmpAttDic = new Dictionary<string, string>(20); // 0x14

        // public string Name { get; set; } 0x20522F4 0x20522FC
        // public float FrameSec { get; } 0x2052304
        public Dictionary<string, ViewFrameAnimation> AnimLayers { get { return m_AnimLayers; } } //0x203FB94
        // private Dictionary<string, string> TmpAttDic { get; } 0x2054D3C

        // // RVA: 0x205230C Offset: 0x205230C VA: 0x205230C
        // private void Claer() { }

        // // RVA: 0x2052384 Offset: 0x2052384 VA: 0x2052384
        public void LoadFromBytes(byte[] bytes)
        {
            TodoLogger.LogError(0, "TODO");
        }

        // // RVA: 0x2052478 Offset: 0x2052478 VA: 0x2052478
        // public void LoadFromBytes(byte[] bytes, float frameSec) { }

        // // RVA: 0x2052684 Offset: 0x2052684 VA: 0x2052684
        // public void ReadXmlString(string text, float frameSec) { }

        // // RVA: 0x2052B88 Offset: 0x2052B88 VA: 0x2052B88
        // public void ReadXmlString(string text) { }

        // // RVA: 0x2052858 Offset: 0x2052858 VA: 0x2052858
        // private void ReadLayoutAnim(XmlElement layoutAnim) { }

        // // RVA: 0x2052C28 Offset: 0x2052C28 VA: 0x2052C28
        // private void ReadLabel(Dictionary<int, string> labelList, XmlElement label) { }

        // // RVA: 0x2052F2C Offset: 0x2052F2C VA: 0x2052F2C
        // private string ReadLayer(out ViewFrameAnimation animData, XmlElement layer, Dictionary<int, string> labelList) { }

        // // RVA: 0x2053248 Offset: 0x2053248 VA: 0x2053248
        // private void ReadFrame(ViewFrameAnimation animData, XmlElement frame, Dictionary<int, string> labelList) { }

        // // RVA: 0x2053E3C Offset: 0x2053E3C VA: 0x2053E3C
        // private void ReadTimeMap(ViewFrameAnimation animData, XmlElement timemapXml) { }

        // // RVA: 0x205394C Offset: 0x205394C VA: 0x205394C
        // private void ReadCtrlType(List<LayoutAnimation.ECtrlType> typeList, XmlElement ctrlType) { }

        // // RVA: 0x2053D50 Offset: 0x2053D50 VA: 0x2053D50
        // private FrameData[] ReadCtrlPoint(XmlElement ctrlpoint, List<LayoutAnimation.ECtrlType> typeList) { }

        // // RVA: 0x2054D44 Offset: 0x2054D44 VA: 0x2054D44
        // private void AddXmlAttributeDic(XmlReader reader, Dictionary<string, string> dic) { }

        // // RVA: 0x20524D4 Offset: 0x20524D4 VA: 0x20524D4
        // public void ReadXmlStringReader(string text, float frameSec) { }

        // // RVA: 0x20523D8 Offset: 0x20523D8 VA: 0x20523D8
        // public void ReadXmlStringReader(string text) { }

        // // RVA: 0x2054E4C Offset: 0x2054E4C VA: 0x2054E4C
        // private void ReadLayoutAnimReader(XmlReader reader) { }

        // // RVA: 0x2055078 Offset: 0x2055078 VA: 0x2055078
        // private void ReadLabelReader(Dictionary<int, string> labelList, XmlReader reader) { }

        // // RVA: 0x2055340 Offset: 0x2055340 VA: 0x2055340
        // private string ReadLayerReader(out ViewFrameAnimation animData, XmlReader reader, Dictionary<int, string> labelList) { }

        // // RVA: 0x2055678 Offset: 0x2055678 VA: 0x2055678
        // private void ReadFrameReader(ViewFrameAnimation animData, XmlReader reader, Dictionary<int, string> labelList) { }

        // // RVA: 0x2055B6C Offset: 0x2055B6C VA: 0x2055B6C
        // private void ReadTimeMapReader(ViewFrameAnimation animData, XmlReader reader) { }

        // // RVA: 0x2053F18 Offset: 0x2053F18 VA: 0x2053F18
        // private void ParseTimeMap(ViewFrameAnimation animData, string timemapListStr) { }

        // // RVA: 0x2055C08 Offset: 0x2055C08 VA: 0x2055C08
        // private void ReadCtrlTypeReader(List<LayoutAnimation.ECtrlType> typeList, XmlReader reader) { }

        // // RVA: 0x2055E78 Offset: 0x2055E78 VA: 0x2055E78
        // private void ReadCtrlPointReader(ViewFrameAnimation animData, XmlReader reader, List<LayoutAnimation.ECtrlType> typeList, Dictionary<int, string> labelList) { }

        // // RVA: 0x20544B0 Offset: 0x20544B0 VA: 0x20544B0
        // private FrameData[] ParseCtrlPoint(string val, List<LayoutAnimation.ECtrlType> typeList) { }
    }
}
