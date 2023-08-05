using System;

namespace CriWare.CriMana
{
    public struct EventPoint
    {
        public IntPtr cueName; // 0x0
        public uint cueNameSize; // 0x4
        public ulong time; // 0x8
        public ulong tunit; // 0x10
        public int type; // 0x18
        public IntPtr paramString; // 0x1C
        public uint paramStringSize; // 0x20
        public uint cntCallback; // 0x24
    }

    
    public class MovieInfo
    {
        private uint _reserved1; // 0x8
        private uint _hasAlpha; // 0xC
        public uint width; // 0x10
        public uint height; // 0x14
        public uint dispWidth; // 0x18
        public uint dispHeight; // 0x1C
        public uint framerateN; // 0x20
        public uint framerateD; // 0x24
        public uint totalFrames; // 0x28
        private uint _codecType; // 0x2C
        private uint _alphaCodecType; // 0x30
        public uint numAudioStreams; // 0x34
        //public AudioInfo[] audioPrm; // 0x38
        public uint numSubtitleChannels; // 0x3C
        public uint maxSubtitleSize; // 0x40
        public uint maxChunkSize; // 0x44

        public bool hasAlpha { get { return _hasAlpha != 0; } set { _hasAlpha = (uint)(value ? 1 : 0); } } //0x29523A4 0x29572A4
        public CodecType codecType { get { return (CodecType)_codecType; } set { _codecType = (uint)value; } } //0x294F458 0x29572CC
        public CodecType alphaCodecType { get { return (CodecType)_alphaCodecType; } set { _alphaCodecType = (uint)value;} } //0x2953B7C 0x29572D4
    }
    public enum AlphaType
    {
        CompoOpaq = 0,
        CompoAlphaFull = 1,
        CompoAlpha3Step = 2,
        CompoAlpha32Bit = 3,
    }

    public enum CodecType
    {
        Unknown = 0,
        SofdecPrime = 1,
        H264 = 5,
        VP9 = 9,
        Theora = 10,
    }

    public class FrameInfo
    {
        public int frameNo; // 0x8
        public int frameNoPerFile; // 0xC
        public uint width; // 0x10
        public uint height; // 0x14
        public uint dispWidth; // 0x18
        public uint dispHeight; // 0x1C
        public uint framerateN; // 0x20
        public uint framerateD; // 0x24
        public ulong time; // 0x28
        public ulong tunit; // 0x30
        public uint cntConcatenatedMovie; // 0x38
        private AlphaType alphaType; // 0x3C
        public uint cntSkippedFrames; // 0x40
        public uint totalFramesPerFile; // 0x44
    }

}