/****************************************************************************
 *
 * Copyright (c) 2019 CRI Middleware Co., Ltd.
 *
 ****************************************************************************/

using System;
using System.Runtime.InteropServices;
using UnityEngine;

/*==========================================================================
 *      CRI Atom Native Wrapper
 *=========================================================================*/
/**
 * \addtogroup CRIATOM_NATIVE_WRAPPER
 * @{
 */

namespace CriWare {

/**
 * <summary>ACFデータ</summary>
 * <remarks>
 * <para header='説明'>CRI Atom Craftで設定したプロジェクト設定を管理するクラスです。<br/>
 * ACFファイルに記述された各種情報を取得します。</para>
 * </remarks>
 */
public class CriAtomExAcf
{
    #region Native Struct Definition

    /**
     * <summary>DSPバス設定の情報取得用構造体</summary>
     * <remarks>
     * <para header='説明'>DSPバス設定の情報を取得するための構造体です。<br/>
	 * CriAtomExAcf::GetDspSettingInformation 関数に引数として渡します。<br/></para>
     * </remarks>
     * <seealso cref='CriAtomExAcf::GetDspSettingInformation'/>
     */
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct AcfDspSettingInfo
    {
        [MarshalAs(UnmanagedType.LPStr)]
        public string name;                     /**< セッティング名 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public ushort[] busIndexes;             /**< DSPバスインデックス配列 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public ushort[] extendBusIndexes;       /**< DSP拡張バスインデックス配列 */
        public ushort snapshotStartIndex;       /**< スナップショット開始インデックス */
        public byte numBuses;                   /**< 有効DSPバス数 */
        public byte numExtendBuses;             /**< 有効拡張DSPバス数 */
        public ushort numSnapshots;             /**< スナップショット数 */
        public ushort snapshotWorkSize;         /**< スナップショット開始インデックス */
        public ushort numMixerAisacs;           /**< ミキサーAISAC数 */
        public ushort mixerAisacStartIndex;     /**< ミキサーAISAC開始インデックス */

        public AcfDspSettingInfo(byte[] data, int startIndex)
        {
            if (IntPtr.Size == 4)
            {
                this.name = Marshal.PtrToStringAnsi(new IntPtr(BitConverter.ToInt32(data, startIndex + 0)));
                this.busIndexes = new ushort[64];
                for (int i = 0; i < 64; ++i)
                {
                    busIndexes[i] = BitConverter.ToUInt16(data, startIndex + 4 + (2 * i));
                }
                this.extendBusIndexes = new ushort[64];
                for (int i = 0; i < 64; ++i)
                {
                    extendBusIndexes[i] = BitConverter.ToUInt16(data, startIndex + 132 + (2 * i));
                }
                this.snapshotStartIndex = BitConverter.ToUInt16(data, startIndex + 260);
                this.numBuses = data[startIndex + 262];
                this.numExtendBuses = data[startIndex + 263];
                this.numSnapshots = BitConverter.ToUInt16(data, startIndex + 264);
                this.snapshotWorkSize = BitConverter.ToUInt16(data, startIndex + 266);
                this.numMixerAisacs = BitConverter.ToUInt16(data, startIndex + 268);
                this.mixerAisacStartIndex = BitConverter.ToUInt16(data, startIndex + 270);
            }
            else
            {
                this.name = Marshal.PtrToStringAnsi(new IntPtr(BitConverter.ToInt64(data, startIndex + 0)));
                this.busIndexes = new ushort[64];
                for (int i = 0; i < 64; ++i)
                {
                    busIndexes[i] = BitConverter.ToUInt16(data, startIndex + 8 + (2 * i));
                }
                this.extendBusIndexes = new ushort[64];
                for (int i = 0; i < 64; ++i)
                {
                    extendBusIndexes[i] = BitConverter.ToUInt16(data, startIndex + 136 + (2 * i));
                }
                this.snapshotStartIndex = BitConverter.ToUInt16(data, startIndex + 264);
                this.numBuses = data[startIndex + 265];
                this.numExtendBuses = data[startIndex + 266];
                this.numSnapshots = BitConverter.ToUInt16(data, startIndex + 268);
                this.snapshotWorkSize = BitConverter.ToUInt16(data, startIndex + 270);
                this.numMixerAisacs = BitConverter.ToUInt16(data, startIndex + 272);
                this.mixerAisacStartIndex = BitConverter.ToUInt16(data, startIndex + 274);
            }
        }
    }

    /**
	 * <summary>DSPバス設定スナップショットの情報取得用構造体</summary>
	 * <remarks>
	 * <para header='説明'>DSPバス設定のスナップショット情報を取得するための構造体です。<br/>
	 * CriAtomExAcf::GetDspSettingSnapshotInformation 関数に引数として渡します。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExAcf::GetDspSettingSnapshotInformation'/>
	 */
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct AcfDspSettingSnapshotInfo
    {
        [MarshalAs(UnmanagedType.LPStr)]
        public string name;                         /**< スナップショット名 */
        public byte numBuses;                       /**< 有効DSPバス数 */
        public byte numExtendBuses;                 /**< 有効拡張DSPバス数 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] reserved;                     /**< 予約領域 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public ushort[] busIndexes;                 /**< DSPバスインデックス配列 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public ushort[] extendBusIndexes;           /**< DSP拡張バスインデックス配列 */

        public AcfDspSettingSnapshotInfo(byte[] data, int startIndex)
        {
            if (IntPtr.Size == 4)
            {
                this.name = Marshal.PtrToStringAnsi(new IntPtr(BitConverter.ToInt32(data, startIndex + 0)));
                this.numBuses = data[startIndex + 4];
                this.numExtendBuses = data[startIndex + 5];
                this.reserved = new byte[2];
                for (int i = 0; i < 2; ++i)
                {
                    reserved[i] = data[startIndex + 6 + i];
                }
                this.busIndexes = new ushort[64];
                for (int i = 0; i < 64; ++i)
                {
                    busIndexes[i] = BitConverter.ToUInt16(data, startIndex + 8 + (2 * i));
                }
                this.extendBusIndexes = new ushort[64];
                for (int i = 0; i < 64; ++i)
                {
                    extendBusIndexes[i] = BitConverter.ToUInt16(data, startIndex + 136 + (2 * i));
                }
            }
            else
            {
                this.name = Marshal.PtrToStringAnsi(new IntPtr(BitConverter.ToInt64(data, startIndex + 0)));
                this.numBuses = data[startIndex + 8];
                this.numExtendBuses = data[startIndex + 9];
                this.reserved = new byte[2];
                for (int i = 0; i < 2; ++i)
                {
                    reserved[i] = data[startIndex + 10 + i];
                }
                this.busIndexes = new ushort[64];
                for (int i = 0; i < 64; ++i)
                {
                    busIndexes[i] = BitConverter.ToUInt16(data, startIndex + 12 + (2 * i));
                }
                this.extendBusIndexes = new ushort[64];
                for (int i = 0; i < 64; ++i)
                {
                    extendBusIndexes[i] = BitConverter.ToUInt16(data, startIndex + 140 + (2 * i));
                }
            }
        }
    }

    /**
	 * <summary>DSPバス設定情報取得用構造体</summary>
	 * <remarks>
	 * <para header='説明'>DSPバス設定情報を取得するための構造体です。<br/>
	 * CriAtomExAcf::GetDspBusInformation 関数に引数として渡します。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExAcf::GetDspBusInformation'/>
	 */
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct AcfDspBusInfo
    {
        [MarshalAs(UnmanagedType.LPStr)]
        public string name;                     /**< 名前 */
        public float volume;                    /**< 音量 */
        public float pan3dVolume;               /**< Pan3D 音量 */
        public float pan3dAngle;                /**< Pan3D 角度 */
        public float pan3dDistance;             /**< Pan3D インテリア距離 */
        public float pan3dSpread;               /**< Pan3D スプレッド */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public ushort[] fxIndexes;              /**< DSP FXインデックス配列 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public ushort[] busLinkIndexes;         /**< DSPバスリンクインデックス配列 */
        public ushort busNo;                    /**< セッティング内DSPバス番号 */
        public byte numFxes;                    /**< DSP FX数 */
        public byte numBusLinks;                /**< DSPバスリンク数 */

        public AcfDspBusInfo(byte[] data, int startIndex)
        {
            if (IntPtr.Size == 4)
            {
                this.name = Marshal.PtrToStringAnsi(new IntPtr(BitConverter.ToInt32(data, startIndex + 0)));
                this.volume = BitConverter.ToSingle(data, startIndex + 4);
                this.pan3dVolume = BitConverter.ToSingle(data, startIndex + 8);
                this.pan3dAngle = BitConverter.ToSingle(data, startIndex + 12);
                this.pan3dDistance = BitConverter.ToSingle(data, startIndex + 16);
                this.pan3dSpread = BitConverter.ToSingle(data, startIndex + 20);
                this.fxIndexes = new ushort[8];
                for (int i = 0; i < 8; ++i)
                {
                    fxIndexes[i] = BitConverter.ToUInt16(data, startIndex + 24 + (2 * i));
                }
                this.busLinkIndexes = new ushort[64];
                for (int i = 0; i < 64; ++i)
                {
                    busLinkIndexes[i] = BitConverter.ToUInt16(data, startIndex + 40 + (2 * i));
                }
                this.busNo = BitConverter.ToUInt16(data, startIndex + 168);
                this.numFxes = data[startIndex + 169];
                this.numBusLinks = data[startIndex + 170];
            }
            else
            {
                this.name = Marshal.PtrToStringAnsi(new IntPtr(BitConverter.ToInt64(data, startIndex + 0)));
                this.volume = BitConverter.ToSingle(data, startIndex + 8);
                this.pan3dVolume = BitConverter.ToSingle(data, startIndex + 12);
                this.pan3dAngle = BitConverter.ToSingle(data, startIndex + 16);
                this.pan3dDistance = BitConverter.ToSingle(data, startIndex + 20);
                this.pan3dSpread = BitConverter.ToSingle(data, startIndex + 24);
                this.fxIndexes = new ushort[8];
                for (int i = 0; i < 8; ++i)
                {
                    fxIndexes[i] = BitConverter.ToUInt16(data, startIndex + 28 + (2 * i));
                }
                this.busLinkIndexes = new ushort[64];
                for (int i = 0; i < 64; ++i)
                {
                    busLinkIndexes[i] = BitConverter.ToUInt16(data, startIndex + 44 + (2 * i));
                }
                this.busNo = BitConverter.ToUInt16(data, startIndex + 172);
                this.numFxes = data[startIndex + 173];
                this.numBusLinks = data[startIndex + 174];
            }
        }
    }

    /**
	 * <summary>DSPバスリンクタイプ</summary>
	 * <seealso cref='CriAtomExAcf::AcfDspBusLinkInfo'/>
	 */
    public enum AcfDspBusLinkType : uint
    {
        preVolume = 0,      /**< プレボリュームタイプ */
        postVolume,         /**< ポストボリュームタイプ */
        postPan,            /**< ポストパンタイプ */
    }

    /**
	 * <summary>DSPバスリンク情報取得用構造体</summary>
	 * <remarks>
	 * <para header='説明'>DSPバスリンク情報を取得するための構造体です。<br/>
	 * CriAtomExAcf::GetDspBusLinkInformation 関数に引数として渡します。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExAcf::GetDspBusLinkInformation'/>
	 */
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct AcfDspBusLinkInfo
    {
        public AcfDspBusLinkType type;          /**< タイプ */
        public float sendLevel;                 /**< センドレベル */
        public ushort busNo;                    /**< 送り先のセッティング内DSPバス番号 */
        public ushort busId;                    /**< 送り先のセッティング内DSPバスID */

        public AcfDspBusLinkInfo(byte[] data, int startIndex)
        {
            {
                this.type = (AcfDspBusLinkType)Enum.ToObject(typeof(AcfDspBusLinkType), BitConverter.ToUInt32(data, startIndex + 0));
                this.sendLevel = BitConverter.ToSingle(data, startIndex + 4);
                this.busNo = BitConverter.ToUInt16(data, startIndex + 8);
                this.busId = BitConverter.ToUInt16(data, startIndex + 10);
            }
        }
    }

    /**
	 * <summary>カテゴリ情報取得用構造体</summary>
	 * <remarks>
	 * <para header='説明'>カテゴリ情報を取得するための構造体です。<br/>
	 * CriAtomExAcf::GetCategoryInfo 関数に引数として渡します。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExAcf::GetCategoryInfo'/>
	 */
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct CategoryInfo
    {
        public uint groupNo;                /**< グループ番号 */
        public uint id;                     /**< カテゴリID */
        [MarshalAs(UnmanagedType.LPStr)]
        public string name;                 /**< カテゴリ名 */
        public uint numCueLimits;           /**< キューリミット数 */
        public float volume;                /**< ボリューム */

        public CategoryInfo(byte[] data, int startIndex)
        {
            if (IntPtr.Size == 4)
            {
                this.groupNo = BitConverter.ToUInt16(data, startIndex + 0);
                this.id = BitConverter.ToUInt16(data, startIndex + 4);
                this.name = Marshal.PtrToStringAnsi(new IntPtr(BitConverter.ToInt32(data, startIndex + 8)));
                this.numCueLimits = BitConverter.ToUInt16(data, startIndex + 12);
                this.volume = BitConverter.ToSingle(data, startIndex + 16);
            }
            else
            {
                this.groupNo = BitConverter.ToUInt16(data, startIndex + 0);
                this.id = BitConverter.ToUInt16(data, startIndex + 4);
                this.name = Marshal.PtrToStringAnsi(new IntPtr(BitConverter.ToInt64(data, startIndex + 8)));
                this.numCueLimits = BitConverter.ToUInt16(data, startIndex + 16);
                this.volume = BitConverter.ToSingle(data, startIndex + 20);
            }
        }
    }

    /**
	 * <summary>Aisacタイプ</summary>
	 * <seealso cref='CriAtomExAcf::GlobalAisacInfo'/>
	 */
    public enum AcfAisacType : uint
    {
        normal = 0,             /**< ノーマルタイプ */
        autoModulation,         /**< オートモジュレーションタイプ */
    }

    /**
	 * <summary>Aisac情報取得用構造体</summary>
	 * <remarks>
	 * <para header='説明'>Global Aisac情報を取得するための構造体です。<br/>
	 * CriAtomExAcf::GetGlobalAisacInfo 関数に引数として渡します。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExAcf::GetGlobalAisacInfo'/>
	 */
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct GlobalAisacInfo
    {
        [MarshalAs(UnmanagedType.LPStr)]
        public string name;             /**< Global Aisac名 */
        public ushort index;            /**< データインデックス */
        public ushort numGraphs;        /**< グラフ数 */
        public AcfAisacType type;       /**< Aisacタイプ */
        public float randomRange;       /**< ランダムレンジ */
        public ushort controlId;        /**< Control Id */
        public ushort dummy;            /**< 未使用 */

        public GlobalAisacInfo(byte[] data, int startIndex)
        {
            if (IntPtr.Size == 4)
            {
                this.name = Marshal.PtrToStringAnsi(new IntPtr(BitConverter.ToInt32(data, startIndex + 0)));
                this.index = BitConverter.ToUInt16(data, startIndex + 4);
                this.numGraphs = BitConverter.ToUInt16(data, startIndex + 6);
                this.type = (AcfAisacType)Enum.ToObject(typeof(AcfAisacType), BitConverter.ToUInt32(data, startIndex + 8));
                this.randomRange = BitConverter.ToSingle(data, startIndex + 12);
                this.controlId = BitConverter.ToUInt16(data, startIndex + 16);
                this.dummy = BitConverter.ToUInt16(data, startIndex + 18);
            }
            else
            {
                this.name = Marshal.PtrToStringAnsi(new IntPtr(BitConverter.ToInt64(data, startIndex + 0)));
                this.index = BitConverter.ToUInt16(data, startIndex + 8);
                this.numGraphs = BitConverter.ToUInt16(data, startIndex + 10);
                this.type = (AcfAisacType)Enum.ToObject(typeof(AcfAisacType), BitConverter.ToUInt32(data, startIndex + 12));
                this.randomRange = BitConverter.ToSingle(data, startIndex + 16);
                this.controlId = BitConverter.ToUInt16(data, startIndex + 20);
                this.dummy = BitConverter.ToUInt16(data, startIndex + 22);
            }
        }
    }

    /**
	 * <summary>Aisacグラフタイプ</summary>
	 * <seealso cref='CriAtomExAcf::AisacGraphInfo'/>
	 */
    public enum AisacGraphType : int
    {
        none = 0,               /**< 未使用 */
        volume,                 /**< ボリューム */
        pitch,                  /**< ピッチ */
        bandpassHigh,           /**< バンドパスフィルタの高域カットオフ周波数 */
        bandpassLow,            /**< バンドパスフィルタの低域カットオフ周波数 */
        biquadFreq,             /**< バイクアッドフィルタの周波数 */
        biquadQ,                /**< バイクアッドフィルタのQ値 */
        busSend0,               /**< バスセンドレベル0 */
        busSend1,               /**< バスセンドレベル1 */
        busSend2,               /**< バスセンドレベル2 */
        busSend3,               /**< バスセンドレベル3 */
        busSend4,               /**< バスセンドレベル4 */
        busSend5,               /**< バスセンドレベル5 */
        busSend6,               /**< バスセンドレベル6 */
        busSend7,               /**< バスセンドレベル7 */
        pan3dAngel,             /**< パンニング3D角度 */
        pan3dVolume,            /**< パンニング3Dボリューム */
        pan3dInteriorDistance,  /**< パンニング3D距離 */
        pan3dCenter,            /**< ACB Ver.0.11.00以降では使用しない */
        pan3dLfe,               /**< ACB Ver.0.11.00以降では使用しない */
        aisac0,                 /**< AISACコントロールID 0 */
        aisac1,                 /**< AISACコントロールID 1 */
        aisac2,                 /**< AISACコントロールID 2 */
        aisac3,                 /**< AISACコントロールID 3 */
        aisac4,                 /**< AISACコントロールID 4 */
        aisac5,                 /**< AISACコントロールID 5 */
        aisac6,                 /**< AISACコントロールID 6 */
        aisac7,                 /**< AISACコントロールID 7 */
        aisac8,                 /**< AISACコントロールID 8 */
        aisac9,                 /**< AISACコントロールID 9 */
        aisac10,                /**< AISACコントロールID 10 */
        aisac11,                /**< AISACコントロールID 11 */
        aisac12,                /**< AISACコントロールID 12 */
        aisac13,                /**< AISACコントロールID 13 */
        aisac14,                /**< AISACコントロールID 14 */
        aisac15,                /**< AISACコントロールID 15 */
        priority,               /**< ボイスプライオリティ */
        preDelayTime,           /**< プリディレイ */
        biquadGain,             /**< バイクアッドフィルタのゲイン */
        pan3dMixdownCenter,     /**< パンニング3D センターレベル */
        pan3dMixdownLfe,        /**< パンニング3D LFEレベル */
        egAttack,               /**< エンベロープ アタック */
        egRelease,              /**< エンベロープ リリース */
        playbackRatio,          /**< シーケンス再生レシオ */
        drySendL,               /**< L chドライセンド */
        drySendR,               /**< R chドライセンド */
        drySendCenter,          /**< Center chドライセンド */
        drySendLfe,             /**< LFE chドライセンド */
        drySendSl,              /**< Surround L chドライセンド */
        drySendSr,              /**< Surround R chドライセンド */
        drySendEx1,             /**< Ex1 chドライセンド */
        drySendEx2,             /**< Ex2 chドライセンド */
        panSpread,              /**< パンスプレッド */
    }

    /**
	 * <summary>Aisac Graph情報取得用構造体</summary>
	 * <remarks>
	 * <para header='説明'>Global Aisac Graph情報を取得するための構造体です。<br/>
	 * ::CriAtomExAcf::GetGlobalAisacGraphInfo 関数に引数として渡します。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExAcf::GetGlobalAisacGraphInfo'/>
	 */
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct AisacGraphInfo
    {
        public AisacGraphType type;     /**< Graphタイプ */

        public AisacGraphInfo(byte[] data, int startIndex)
        {
            this.type = (AisacGraphType)Enum.ToObject(typeof(AisacGraphType), BitConverter.ToInt32(data, startIndex + 0));
        }
    }

    /**
	 * <summary>文字コード</summary>
	 * <remarks>
	 * <para header='説明'>文字コード（文字符号化方式）を表します。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExAcf::AcfInfo'/>
	 */
    public enum CharacterEncoding : uint
    {
        utf8 = 0,  /**< UTF-8 */
        sjis = 1,  /**< Shift_JIS */
    }

    /**
	 * <summary>ACF情報</summary>
	 * <remarks>
	 * <para header='説明'>ACFデータの詳細情報です。<br/>
	 * ::CriAtomExAcf::GetAcfInfo 関数に引数として渡します。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExAcf::GetAcfInfo'/>
	 */
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct AcfInfo
    {
        [MarshalAs(UnmanagedType.LPStr)]
        public string name;                             /**< 名前 */
        public uint size;                               /**< サイズ */
        public uint version;                            /**< ACBバージョン */
        public CharacterEncoding characterEncoding;     /**< 文字コード */
        public int numDspSettings;                      /**< DSP設定数 */
        public int numCategories;                       /**< カテゴリ数 */
        public int numCategoriesPerPlayback;            /**< 再生毎カテゴリ参照数 */
        public int numReacts;                           /**< REACT数 */
        public int numAisacControls;                    /**< AISACコントロール数 */
        public int numGlobalAisacs;                     /**< グローバルAISAC数 */
        public int numGameVariables;                    /**< ゲーム変数数 */
        public int maxBusesOfDspBusSettings;            /**< DSP設定内最大バス数 */
        public int numBuses;                            /**< バス数 */
        public int numVoiceLimitGroups;                 /**< ボイスリミットグループ数 */

        public AcfInfo(byte[] data, int startIndex)
        {
            if (IntPtr.Size == 4)
            {
                this.name = Marshal.PtrToStringAnsi(new IntPtr(BitConverter.ToInt32(data, startIndex + 0)));
                this.size = BitConverter.ToUInt32(data, startIndex + 4);
                this.version = BitConverter.ToUInt32(data, startIndex + 8);
                this.characterEncoding = (CharacterEncoding)Enum.ToObject(typeof(CharacterEncoding), BitConverter.ToUInt32(data, startIndex + 12));
                this.numDspSettings = BitConverter.ToInt32(data, startIndex + 16);
                this.numCategories = BitConverter.ToInt32(data, startIndex + 20);
                this.numCategoriesPerPlayback = BitConverter.ToInt32(data, startIndex + 24);
                this.numReacts = BitConverter.ToInt32(data, startIndex + 28);
                this.numAisacControls = BitConverter.ToInt32(data, startIndex + 32);
                this.numGlobalAisacs = BitConverter.ToInt32(data, startIndex + 36);
                this.numGameVariables = BitConverter.ToInt32(data, startIndex + 40);
                this.maxBusesOfDspBusSettings = BitConverter.ToInt32(data, startIndex + 44);
                this.numBuses = BitConverter.ToInt32(data, startIndex + 48);
                this.numVoiceLimitGroups = BitConverter.ToInt32(data, startIndex + 52);
            }
            else
            {
                this.name = Marshal.PtrToStringAnsi(new IntPtr(BitConverter.ToInt64(data, startIndex + 0)));
                this.size = BitConverter.ToUInt32(data, startIndex + 8);
                this.version = BitConverter.ToUInt32(data, startIndex + 12);
                this.characterEncoding = (CharacterEncoding)Enum.ToObject(typeof(CharacterEncoding), BitConverter.ToUInt32(data, startIndex + 16));
                this.numDspSettings = BitConverter.ToInt32(data, startIndex + 20);
                this.numCategories = BitConverter.ToInt32(data, startIndex + 24);
                this.numCategoriesPerPlayback = BitConverter.ToInt32(data, startIndex + 28);
                this.numReacts = BitConverter.ToInt32(data, startIndex + 32);
                this.numAisacControls = BitConverter.ToInt32(data, startIndex + 36);
                this.numGlobalAisacs = BitConverter.ToInt32(data, startIndex + 40);
                this.numGameVariables = BitConverter.ToInt32(data, startIndex + 44);
                this.maxBusesOfDspBusSettings = BitConverter.ToInt32(data, startIndex + 48);
                this.numBuses = BitConverter.ToInt32(data, startIndex + 52);
                this.numVoiceLimitGroups = BitConverter.ToInt32(data, startIndex + 56);
            }
        }
    }

    /**
	 * <summary>セレクタ情報取得用構造体</summary>
	 * <remarks>
	 * <para header='説明'>セレクタ情報を取得するための構造体です。<br/>
	 * CriAtomExAcf::GetSelectorInfo 関数に引数として渡します。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExAcf::GetSelectorInfo'/>
	 */
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct SelectorInfo
    {
        [MarshalAs(UnmanagedType.LPStr)]
        public string name;                     /**< セレクタ名 */
        public ushort index;                    /**< データインデックス */
        public ushort numLabels;                /**< ラベル数 */
        public ushort globalLabelIndex;         /**< グローバル参照ラベルインデックス */

        public SelectorInfo(byte[] data, int startIndex)
        {
            if (IntPtr.Size == 4)
            {
                this.name = Marshal.PtrToStringAnsi(new IntPtr(BitConverter.ToInt32(data, startIndex + 0)));
                this.index = BitConverter.ToUInt16(data, startIndex + 4);
                this.numLabels = BitConverter.ToUInt16(data, startIndex + 6);
                this.globalLabelIndex = BitConverter.ToUInt16(data, startIndex + 8);
            }
            else
            {
                this.name = Marshal.PtrToStringAnsi(new IntPtr(BitConverter.ToInt64(data, startIndex + 0)));
                this.index = BitConverter.ToUInt16(data, startIndex + 8);
                this.numLabels = BitConverter.ToUInt16(data, startIndex + 10);
                this.globalLabelIndex = BitConverter.ToUInt16(data, startIndex + 12);
            }
        }
    }

    /**
	 * <summary>セレクタラベル情報取得用構造体</summary>
	 * <remarks>
	 * <para header='説明'>セレクタラベル情報を取得するための構造体です。<br/>
	 * ::CriAtomExAcf::GetSelectorLabelInfo 関数に引数として渡します。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExAcf::GetSelectorLabelInfo'/>
	 */
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct SelectorLabelInfo
    {
        [MarshalAs(UnmanagedType.LPStr)]
        public string selectorName;         /**< セレクタ名 */
        [MarshalAs(UnmanagedType.LPStr)]
        public string labelName;            /**< セレクタラベル名 */

        public SelectorLabelInfo(byte[] data, int startIndex)
        {
            if (IntPtr.Size == 4)
            {
                this.selectorName = Marshal.PtrToStringAnsi(new IntPtr(BitConverter.ToInt32(data, startIndex + 0)));
                this.labelName = Marshal.PtrToStringAnsi(new IntPtr(BitConverter.ToInt32(data, startIndex + 4)));
            }
            else
            {
                this.selectorName = Marshal.PtrToStringAnsi(new IntPtr(BitConverter.ToInt64(data, startIndex + 0)));
                this.labelName = Marshal.PtrToStringAnsi(new IntPtr(BitConverter.ToInt64(data, startIndex + 8)));
            }
        }
    }
    #endregion

    #region Exported API
    /**
     * <summary>AISACコントロール数の取得</summary>
     * <returns>AISACコントロール数</returns>
     * <remarks>
     * <para header='説明'>登録されたACFに含まれるAISACコントロールの数を取得します。<br/>
	 * ACFが登録されていない場合、-1が返ります。</para>
     * </remarks>
     */
    public static int GetNumAisacControls()
    {
        return criAtomExAcf_GetNumAisacControls();
    }

    /**
     * <summary>AISACコントロール情報の取得</summary>
     * <param name='index'>AISACコントロールインデックス</param>
     * <param name='info'>AISACコントロール情報</param>
     * <returns>情報が取得できたかどうか？（取得できた：TRUE／取得できない：FALSE）</returns>
     * <remarks>
     * <para header='説明'>AISACコントロールインデックスからAISACコントロール情報を取得します。<br/>
	 * 指定したインデックスのAISACコントロールが存在しない場合、FALSEが返ります。</para>
     * </remarks>
     */
    public static bool GetAisacControlInfo(ushort index, out CriAtomEx.AisacControlInfo info)
    {
        using (var mem = new CriStructMemory<CriAtomEx.AisacControlInfo>())
        {
            bool result = criAtomExAcf_GetAisacControlInfo(index, mem.ptr);
            info = new CriAtomEx.AisacControlInfo(mem.bytes, 0);
            return result;
        }
    }

    /**
     * <summary>DSPバス設定数の取得</summary>
     * <returns>DSPバス設定数</returns>
     * <remarks>
     * <para header='説明'>ライブラリに登録されたACFデータに含まれるDSPバス設定の数を取得します。<br/>
	 * ACFデータが登録されていない場合、本関数は -1 を返します。<br/></para>
     * </remarks>
     */
    public static int GetNumDspSettings()
    {
        return criAtomExAcf_GetNumDspSettings();
    }

    /**
     * <summary>DSPバス設定情報の取得</summary>
     * <param name='name'>セッティング名</param>
     * <param name='info'>セッティング情報</param>
     * <returns>情報が取得できたかどうか？（取得できた：TRUE／取得できない：FALSE）</returns>
     * <remarks>
     * <para header='説明'>セッティング名を指定してセッティング情報を取得します。<br/>
	 * 指定したセッティング名のDsp settingが存在しない場合、FALSEが返ります。<br/></para>
     * </remarks>
     */
    public static bool GetDspSettingInformation(string name, out AcfDspSettingInfo info)
    {
        using (var mem = new CriStructMemory<AcfDspSettingInfo>())
        {
            bool result = criAtomExAcf_GetDspSettingInformation(name, mem.ptr);
            info = new AcfDspSettingInfo(mem.bytes, 0);
            return result;
        }
    }

    /**
     * <summary>DSPバス設定スナップショット情報の取得</summary>
     * <param name='index'>スナップショットインデックス</param>
     * <param name='info'>スナップショット情報</param>
     * <returns>情報が取得できたかどうか？（取得できた：TRUE／取得できない：FALSE）</returns>
     * <remarks>
     * <para header='説明'>スナップショットインデックスを指定してスナップショット情報を取得します。<br/>
	 * 指定したセッティング名のスナップショットが存在しない場合、FALSEが返ります。<br/>
	 * スナップショットインデックスは親となるDSPバス設定情報の CriAtomExAcf::AcfDspSettingInfo 構造体内の
	 * snapshotStartIndexメンバとnumSnapshotsメンバを元に適切な値を算出してください。</para>
     * </remarks>
     */
    public static bool GetDspSettingSnapshotInformation(ushort index, out AcfDspSettingSnapshotInfo info)
    {
        using (var mem = new CriStructMemory<AcfDspSettingSnapshotInfo>())
        {
            bool result = criAtomExAcf_GetDspSettingSnapshotInformation(index, mem.ptr);
            info = new AcfDspSettingSnapshotInfo(mem.bytes, 0);
            return result;
        }
    }

    /**
     * <summary>DSPバスの取得</summary>
     * <param name='index'>バスインデックス</param>
     * <param name='info'>バス情報</param>
     * <returns>情報が取得できたかどうか？（取得できた：TRUE／取得できない：FALSE）</returns>
     * <remarks>
     * <para header='説明'>インデックスを指定してDSPバス情報を取得します。<br/>
	 * 指定したインデックス名のDSPバスが存在しない場合、FALSEが返ります。<br/></para>
     * </remarks>
     */
    public static bool GetDspBusInformation(ushort index, out AcfDspBusInfo info)
    {
        using (var mem = new CriStructMemory<AcfDspBusInfo>())
        {
            bool result = criAtomExAcf_GetDspBusInformation(index, mem.ptr);
            info = new AcfDspBusInfo(mem.bytes, 0);
            return result;
        }
    }

    /**
     * <summary>DSPバスリンクの取得</summary>
     * <param name='index'>DSPバスリンクインデックス</param>
     * <param name='info'>DSPバスリンク情報</param>
     * <returns>情報が取得できたかどうか？（取得できた：TRUE／取得できない：FALSE）</returns>
     * <remarks>
     * <para header='説明'>インデックスを指定してバスリンク情報を取得します。<br/>
	 * 指定したインデックス名のDSPバスリンクが存在しない場合、FALSEが返ります。<br/></para>
     * </remarks>
     */
    public static bool GetDspBusLinkInformation(ushort index, out AcfDspBusLinkInfo info)
    {
        using (var mem = new CriStructMemory<AcfDspBusLinkInfo>())
        {
            bool result = criAtomExAcf_GetDspBusLinkInformation(index, mem.ptr);
            info = new AcfDspBusLinkInfo(mem.bytes, 0);
            return result;
        }
    }

    /**
     * <summary>カテゴリ数の取得</summary>
     * <returns>カテゴリ数</returns>
     * <remarks>
     * <para header='説明'>登録されたACFに含まれるカテゴリの数を取得します。</para>
     * </remarks>
     */
    public static int GetNumCategories()
    {
        return criAtomExAcf_GetNumCategories();
    }

    /**
     * <summary>再生毎カテゴリ参照数の取得</summary>
     * <returns>再生毎カテゴリ参照数</returns>
     * <remarks>
     * <para header='説明'>登録されたACFに含まれる再生毎カテゴリ参照数を取得します。</para>
     * </remarks>
     */
    public static int GetNumCategoriesPerPlayback()
    {
        return criAtomExAcf_GetNumCategoriesPerPlayback();
    }

    /**
     * <summary>カテゴリ情報の取得（インデックス指定）</summary>
     * <param name='index'>カテゴリインデックス</param>
     * <param name='info'>カテゴリ情報</param>
     * <returns>情報が取得できたかどうか？（取得できた：TRUE／取得できない：FALSE）</returns>
     * <remarks>
     * <para header='説明'>カテゴリインデックスからカテゴリ情報を取得します。<br/>
	 * 指定したインデックスのカテゴリが存在しない場合、FALSEが返ります。</para>
     * </remarks>
     */
    public static bool GetCategoryInfoByIndex(ushort index, out CategoryInfo info)
    {
        using (var mem = new CriStructMemory<CategoryInfo>())
        {
            bool result = criAtomExAcf_GetCategoryInfo(index, mem.ptr);
            info = new CategoryInfo(mem.bytes, 0);
            return result;
        }
    }

    /**
     * <summary>カテゴリ情報の取得（カテゴリ名指定）</summary>
     * <param name='name'>カテゴリ名指定</param>
     * <param name='info'>カテゴリ情報</param>
     * <returns>情報が取得できたかどうか？（取得できた：TRUE／取得できない：FALSE）</returns>
     * <remarks>
     * <para header='説明'>カテゴリ名からカテゴリ情報を取得します。<br/>
	 * 指定したカテゴリ名のカテゴリが存在しない場合、FALSEが返ります。</para>
     * </remarks>
     */
    public static bool GetCategoryInfoByName(string name, out CategoryInfo info)
    {
        using (var mem = new CriStructMemory<CategoryInfo>())
        {
            bool result = criAtomExAcf_GetCategoryInfoByName(name, mem.ptr);
            info = new CategoryInfo(mem.bytes, 0);
            return result;
        }
    }

    /**
     * <summary>カテゴリ情報の取得（カテゴリID指定）</summary>
     * <param name='id'>カテゴリID</param>
     * <param name='info'>カテゴリ情報</param>
     * <returns>情報が取得できたかどうか？（取得できた：TRUE／取得できない：FALSE）</returns>
     * <remarks>
     * <para header='説明'>カテゴリIDからカテゴリ情報を取得します。<br/>
	 * 指定したカテゴリIDのカテゴリが存在しない場合、FALSEが返ります。</para>
     * </remarks>
     */
    public static bool GetCategoryInfoById(uint id, out CategoryInfo info)
    {
        using (var mem = new CriStructMemory<CategoryInfo>())
        {
            bool result = criAtomExAcf_GetCategoryInfoById(id, mem.ptr);
            info = new CategoryInfo(mem.bytes, 0);
            return result;
        }
    }

    /**
     * <summary>Global Aisac数の取得</summary>
     * <returns>Global Aisac数</returns>
     * <remarks>
     * <para header='説明'>登録されたACFに含まれるGlobal Aisacの数を取得します。</para>
     * </remarks>
     */
    public static int GetNumGlobalAisacs()
    {
        return criAtomExAcf_GetNumGlobalAisacs();
    }

    /**
     * <summary>Global Aisac情報の取得（インデックス指定）</summary>
     * <param name='index'>Global Aisacインデックス</param>
     * <param name='info'>Global Aisac情報</param>
     * <returns>情報が取得できたかどうか？（取得できた：TRUE／取得できない：FALSE）</returns>
     * <remarks>
     * <para header='説明'>Global AisacインデックスからAisac情報を取得します。<br/>
	 * 指定したインデックスのGlobal Aisacが存在しない場合、FALSEが返ります。</para>
     * </remarks>
     */
    public static bool GetGlobalAisacInfoByIndex(ushort index, out GlobalAisacInfo info)
    {
        using (var mem = new CriStructMemory<GlobalAisacInfo>())
        {
            bool result = criAtomExAcf_GetGlobalAisacInfo(index, mem.ptr);
            info = new GlobalAisacInfo(mem.bytes, 0);
            return result;
        }
    }

    /**
     * <summary>Global Aisac情報の取得（名前指定）</summary>
     * <param name='name'>Global Aisac名</param>
     * <param name='info'>Global Aisac情報</param>
     * <returns>情報が取得できたかどうか？（取得できた：TRUE／取得できない：FALSE）</returns>
     * <remarks>
     * <para header='説明'>Global Aisac名からAisac情報を取得します。<br/>
	 * 指定した名前のGlobal Aisacが存在しない場合、FALSEが返ります。</para>
     * </remarks>
     */
    public static bool GetGlobalAisacInfoByName(string name, out GlobalAisacInfo info)
    {
        using (var mem = new CriStructMemory<GlobalAisacInfo>())
        {
            bool result = criAtomExAcf_GetGlobalAisacInfoByName(name, mem.ptr);
            info = new GlobalAisacInfo(mem.bytes, 0);
            return result;
        }
    }

    /**
     * <summary>Global Aisac Graph情報の取得</summary>
     * <param name='aisacInfo'>Global Aisac情報</param>
     * <param name='graphIndex'>Global Aisac graphインデックス</param>
     * <param name='graphInfo'>Aisac graph情報</param>
     * <returns>情報が取得できたかどうか？（取得できた：TRUE／取得できない：FALSE）</returns>
     * <remarks>
     * <para header='説明'>Global Aisac情報とgraphインデックスからgraph情報を取得します。<br/>
	 * 指定したインデックスのGlobal Aisacが存在しない場合、FALSEが返ります。</para>
     * </remarks>
     */
    public static bool GetGlobalAisacGraphInfo(GlobalAisacInfo aisacInfo, ushort graphIndex, out AisacGraphInfo graphInfo)
    {
        bool result = false;
        IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GlobalAisacInfo)));
        Marshal.StructureToPtr(aisacInfo, ptr, false);
        using (var mem = new CriStructMemory<AisacGraphInfo>())
        {
            result = criAtomExAcf_GetGlobalAisacGraphInfo(ptr, graphIndex, mem.ptr);
            graphInfo = new AisacGraphInfo(mem.bytes, 0);
        }
        Marshal.FreeHGlobal(ptr);
        return result;
    }

    /**
     * <summary>Global Aisac値の取得</summary>
     * <param name='aisacInfo'>Global Aisac情報</param>
     * <param name='control'>AISACコントロール値</param>
     * <param name='type'>グラフタイプ</param>
     * <param name='value'>AISAC値</param>
     * <returns>情報が取得できたかどうか？（取得できた：TRUE／取得できない：FALSE）</returns>
     * <remarks>
     * <para header='説明'>Global Aisac情報、コントロール値、グラフタイプを指定してAisac値を取得します。<br/>
	 * 指定したインデックスのGlobal Aisacが存在しない場合やグラフが存在しない場合は、FALSEが返ります。</para>
     * </remarks>
     */
    public static bool GetGlobalAisacValue(GlobalAisacInfo aisacInfo, float control, AisacGraphType type, out float value)
    {
        IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GlobalAisacInfo)));
        Marshal.StructureToPtr(aisacInfo, ptr, false);
        bool result = criAtomExAcf_GetGlobalAisacValue(ptr, control, type, out value);
        Marshal.FreeHGlobal(ptr);
        return result;
    }

    /**
     * <summary>ACF情報の取得</summary>
     * <param name='acfInfo'>ACF情報</param>
     * <returns>情報が取得できたかどうか？（取得できた：TRUE／取得できない：FALSE）</returns>
     * <remarks>
     * <para header='説明'>ライブラリに登録されたACFデータの各種情報を取得します。<br/>
	 * ACF情報の取得に失敗した場合、FALSEが返ります。</para>
     * </remarks>
     */
    public static bool GetAcfInfo(out AcfInfo acfInfo)
    {
        using (var mem = new CriStructMemory<AcfInfo>())
        {
            bool result = criAtomExAcf_GetAcfInfo(mem.ptr);
            acfInfo = new AcfInfo(mem.bytes, 0);
            return result;
        }
    }

    /**
     * <summary>セレクタ数の取得</summary>
     * <returns>セレクタ数</returns>
     * <remarks>
     * <para header='説明'>登録されたACFに含まれるセレクタの数を取得します。</para>
     * </remarks>
     */
    public static int GetNumSelectors()
    {
        return criAtomExAcf_GetNumSelectors();
    }

    /**
     * <summary>セレクタ情報の取得（インデックス指定）</summary>
     * <param name='index'>セレクタインデックス</param>
     * <param name='info'>セレクタ情報</param>
     * <returns>情報が取得できたかどうか？（取得できた：TRUE／取得できない：FALSE）</returns>
     * <remarks>
     * <para header='説明'>セレクタインデックスからセレクタ情報を取得します。<br/>
	 * 指定したインデックスのセレクタが存在しない場合、FALSEが返ります。</para>
     * </remarks>
     */
    public static bool GetSelectorInfoByIndex(ushort index, out SelectorInfo info)
    {
        using (var mem = new CriStructMemory<SelectorInfo>())
        {
            bool result = criAtomExAcf_GetSelectorInfoByIndex(index, mem.ptr);
            info = new SelectorInfo(mem.bytes, 0);
            return result;
        }
    }

    /**
     * <summary>セレクタ情報の取得（名前指定）</summary>
     * <param name='name'>セレクタ名</param>
     * <param name='info'>セレクタ情報</param>
     * <returns>情報が取得できたかどうか？（取得できた：TRUE／取得できない：FALSE）</returns>
     * <remarks>
     * <para header='説明'>セレクタ名からセレクタ情報を取得します。<br/>
	 * 指定した名前のセレクタが存在しない場合、FALSEが返ります。</para>
     * </remarks>
     */
    public static bool GetSelectorInfoByName(string name, out SelectorInfo info)
    {
        using (var mem = new CriStructMemory<SelectorInfo>())
        {
            bool result = criAtomExAcf_GetSelectorInfoByName(name, mem.ptr);
            info = new SelectorInfo(mem.bytes, 0);
            return result;
        }
    }

    /**
     * <summary>セレクタラベル情報の取得</summary>
     * <param name='selectorInfo'>セレクタ情報</param>
     * <param name='labelIndex'>ラベルインデックス</param>
     * <param name='info'>セレクタラベル情報</param>
     * <returns>情報が取得できたかどうか？（取得できた：TRUE／取得できない：FALSE）</returns>
     * <remarks>
     * <para header='説明'>セレクタ情報とセレクタラベルインデックスからセレクタラベル情報を取得します。<br/>
	 * 指定したインデックスのセレクタラベルが存在しない場合、FALSEが返ります。</para>
     * </remarks>
     */
    public static bool GetSelectorLabelInfo(SelectorInfo selectorInfo, ushort labelIndex, out SelectorLabelInfo info)
    {
        bool result = false;
        IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(SelectorInfo)));
        Marshal.StructureToPtr(selectorInfo, ptr, false);
        using (var mem = new CriStructMemory<SelectorLabelInfo>())
        {
            result = criAtomExAcf_GetSelectorLabelInfo(ptr, labelIndex, mem.ptr);
            info = new SelectorLabelInfo(mem.bytes, 0);
        }
        Marshal.FreeHGlobal(ptr);
        return result;
    }

    /**
     * <summary>バス数の取得</summary>
     * <returns>バス数</returns>
     * <remarks>
     * <para header='説明'>登録されたACFに含まれるバスの数を取得します。</para>
     * </remarks>
     */
    public static int GetNumBuses()
    {
        return criAtomExAcf_GetNumBuses();
    }

    /**
     * <summary>DSPバス設定内の最大バス数の取得</summary>
     * <returns>DSPバス設定内の最大バス数</returns>
     * <remarks>
     * <para header='説明'>登録されたACFに含まれるDSPバス設定内の最大バスの数を取得します。</para>
     * </remarks>
     */
    public static int GetMaxBusesOfDspBusSettings()
    {
        return criAtomExAcf_GetMaxBusesOfDspBusSettings();
    }

    /**
     * <summary>ACF内のバス名取得</summary>
     * <param name='busName'>バス名</param>
     * <returns>ACF内バス名</returns>
     * <remarks>
     * <para header='説明'>指定されたバス名のACF内文字列を取得します。<br/>
	 * 存在しないバス名を指定した場合はNULLが返ります。<br/></para>
     * </remarks>
     */
    public static string FindBusName(string busName)
    {
        return criAtomExAcf_FindBusName(busName);
    }
    #endregion

    #region DLL Import
#if !CRIWARE_ENABLE_HEADLESS_MODE
    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern int criAtomExAcf_GetNumAisacControls();

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern bool criAtomExAcf_GetAisacControlInfo(ushort index, IntPtr info);

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern uint criAtomExAcf_GetAisacControlIdByName(string name);

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern string criAtomExAcf_GetAisacControlNameById(uint id);

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern int criAtomExAcf_GetNumDspSettings();

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern int criAtomExAcf_GetNumDspSettingsFromAcfData(IntPtr acf_data, int acf_data_size);

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern string criAtomExAcf_GetDspSettingNameByIndex(ushort index);

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern string criAtomExAcf_GetDspSettingNameByIndexFromAcfData(IntPtr acf_data, int acf_data_size, ushort index);

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern bool criAtomExAcf_GetDspSettingInformation(string name, IntPtr info);

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern bool criAtomExAcf_GetDspSettingSnapshotInformation(ushort index, IntPtr info);

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern bool criAtomExAcf_GetDspBusInformation(ushort index, IntPtr info);

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern int criAtomExAcf_GetDspFxType(ushort index);

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern string criAtomExAcf_GetDspFxName(ushort index);

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern bool criAtomExAcf_GetDspFxParameters(ushort index, IntPtr parameters, int size);

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern bool criAtomExAcf_GetDspBusLinkInformation(ushort index, IntPtr info);

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern int criAtomExAcf_GetNumCategoriesFromAcfData(IntPtr acf_data, int acf_data_size);

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern int criAtomExAcf_GetNumCategories();

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern int criAtomExAcf_GetNumCategoriesPerPlaybackFromAcfData(IntPtr acf_data, int acf_data_size);

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern int criAtomExAcf_GetNumCategoriesPerPlayback();

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern bool criAtomExAcf_GetCategoryInfo(ushort index, IntPtr info);

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern bool criAtomExAcf_GetCategoryInfoByName(string name, IntPtr info);

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern bool criAtomExAcf_GetCategoryInfoById(uint id, IntPtr info);

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern int criAtomExAcf_GetNumGlobalAisacs();

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern bool criAtomExAcf_GetGlobalAisacInfo(ushort index, IntPtr info);

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern bool criAtomExAcf_GetGlobalAisacInfoByName(string name, IntPtr info);

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern bool criAtomExAcf_GetGlobalAisacGraphInfo(IntPtr aisac_info, ushort graph_index, IntPtr graph_info);

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern bool criAtomExAcf_GetGlobalAisacValue(IntPtr aisac_info, float control, AisacGraphType type, out float value);

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern bool criAtomExAcf_GetAcfInfo(IntPtr acf_info);

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern bool criAtomExAcf_GetAcfInfoFromAcfData(IntPtr acf_data, int acf_data_size, IntPtr acf_info);

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern int criAtomExAcf_GetNumSelectors();

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern bool criAtomExAcf_GetSelectorInfoByIndex(ushort index, IntPtr info);

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern bool criAtomExAcf_GetSelectorInfoByName(string name, IntPtr info);

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern bool criAtomExAcf_GetSelectorLabelInfo(IntPtr selector_info, ushort label_index, IntPtr info);

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern int criAtomExAcf_GetNumBusesFromAcfData(IntPtr acf_data, int acf_data_size);

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern int criAtomExAcf_GetNumBuses();

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern int criAtomExAcf_GetMaxBusesOfDspBusSettingsFromAcfData(IntPtr acf_data, int acf_data_size);

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern int criAtomExAcf_GetMaxBusesOfDspBusSettings();

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern string criAtomExAcf_FindBusName(string bus_name);
#else
    private static int criAtomExAcf_GetNumAisacControls() { return 0; }
    private static bool criAtomExAcf_GetAisacControlInfo(ushort index, IntPtr info) { return false; }
    private static uint criAtomExAcf_GetAisacControlIdByName(string name) { return 0; }
    private static string criAtomExAcf_GetAisacControlNameById(uint id) { return null; }
    private static int criAtomExAcf_GetNumDspSettings() { return 0; }
    private static int criAtomExAcf_GetNumDspSettingsFromAcfData(IntPtr acf_data, int acf_data_size) { return 0; }
    private static string criAtomExAcf_GetDspSettingNameByIndex(ushort index) { return null; }
    private static string criAtomExAcf_GetDspSettingNameByIndexFromAcfData(IntPtr acf_data, int acf_data_size, ushort index) { return null; }
    private static bool criAtomExAcf_GetDspSettingInformation(string name, IntPtr info) { return false; }
    private static bool criAtomExAcf_GetDspSettingSnapshotInformation(ushort index, IntPtr info) { return false; }
    private static bool criAtomExAcf_GetDspBusInformation(ushort index, IntPtr info) { return false; }
    private static int criAtomExAcf_GetDspFxType(ushort index) { return 0; }
    private static string criAtomExAcf_GetDspFxName(ushort index) { return null; }
    private static bool criAtomExAcf_GetDspFxParameters(ushort index, IntPtr parameters, int size) { return false; }
    private static bool criAtomExAcf_GetDspBusLinkInformation(ushort index, IntPtr info) { return false; }
    private static int criAtomExAcf_GetNumCategoriesFromAcfData(IntPtr acf_data, int acf_data_size) { return 0; }
    private static int criAtomExAcf_GetNumCategories() { return 0; }
    private static int criAtomExAcf_GetNumCategoriesPerPlaybackFromAcfData(IntPtr acf_data, int acf_data_size) { return 0; }
    private static int criAtomExAcf_GetNumCategoriesPerPlayback() { return 0; }
    private static bool criAtomExAcf_GetCategoryInfo(ushort index, IntPtr info) { return false; }
    private static bool criAtomExAcf_GetCategoryInfoByName(string name, IntPtr info) { return false; }
    private static bool criAtomExAcf_GetCategoryInfoById(uint id, IntPtr info) { return false; }
    private static int criAtomExAcf_GetNumGlobalAisacs() { return 0; }
    private static bool criAtomExAcf_GetGlobalAisacInfo(ushort index, IntPtr info) { return false; }
    private static bool criAtomExAcf_GetGlobalAisacInfoByName(string name, IntPtr info) { return false; }
    private static bool criAtomExAcf_GetGlobalAisacGraphInfo(IntPtr aisac_info, ushort graph_index, IntPtr graph_info) { return false; }
    private static bool criAtomExAcf_GetGlobalAisacValue(IntPtr aisac_info, float control, AisacGraphType type, out float value) { value = 0.0f; return false; }
    private static bool criAtomExAcf_GetAcfInfo(IntPtr acf_info) { return false; }
    private static bool criAtomExAcf_GetAcfInfoFromAcfData(IntPtr acf_data, int acf_data_size, IntPtr acf_info) { return false; }
    private static int criAtomExAcf_GetNumSelectors() { return 0; }
    private static bool criAtomExAcf_GetSelectorInfoByIndex(ushort index, IntPtr info) { return false; }
    private static bool criAtomExAcf_GetSelectorInfoByName(string name, IntPtr info) { return false; }
    private static bool criAtomExAcf_GetSelectorLabelInfo(IntPtr selector_info, ushort label_index, IntPtr info) { return false; }
    private static int criAtomExAcf_GetNumBusesFromAcfData(IntPtr acf_data, int acf_data_size) { return 0; }
    private static int criAtomExAcf_GetNumBuses() { return 0; }
    private static int criAtomExAcf_GetMaxBusesOfDspBusSettingsFromAcfData(IntPtr acf_data, int acf_data_size) { return 0; }
    private static int criAtomExAcf_GetMaxBusesOfDspBusSettings() { return 0; }
    private static string criAtomExAcf_FindBusName(string bus_name) { return null; }
#endif
    #endregion
}

} //namespace CriWare
/**
 * @}
 */

/* --- end of file --- */
