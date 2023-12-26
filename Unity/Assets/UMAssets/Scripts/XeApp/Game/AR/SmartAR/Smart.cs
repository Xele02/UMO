using System;
using System.Runtime.InteropServices;

namespace smartar
{
    public class Error
    {
        public const int OK = 0;
        public const int ERROR_UNINITIALIZED = -2138308608;
        public const int ERROR_ALREADY_INITIALIZED = -2138308607;
        public const int ERROR_OUT_OF_MEMORY = -2138308606;
        public const int ERROR_NOT_STOPPED = -2138308605;
        public const int ERROR_NOT_EMPTY = -2138308604;
        public const int ERROR_INVALID_VALUE = -2138308603;
        public const int ERROR_INVALID_POINTER = -2138308602;
        public const int ERROR_ALREADY_REGISTERED = -2138308601;
        public const int ERROR_NOT_REGISTERED = -2138308600;
        public const int ERROR_ALREADY_STARTED = -2138308599;
        public const int ERROR_NOT_STARTED = -2138308598;
        public const int ERROR_NOT_REQUIRED = -2138308597;
        public const int ERROR_VERSION_MISSMATCH = -2138308596;
        public const int ERROR_NO_DICTIONARY = -2138308595;
        public const int ERROR_BUSY = -2138308594;
        public const int ERROR_EXPIRED_LICENSE = -2138308591;
        public const int ERROR_INVALID_DICTIONARY = -2138308589;
    }

    public enum Facing
    {
        FACING_BACK = 0,
        FACING_FRONT = 1,
    }

    public enum Rotation
    {
        ROTATION_0 = 0,
        ROTATION_90 = 90,
        ROTATION_180 = 180,
        ROTATION_270 = 270,
    }

    public enum FocusMode
    {
        FOCUS_MODE_MANUAL = 0,
        FOCUS_MODE_CONTINUOUS_AUTO_PICTURE = 1,
        FOCUS_MODE_CONTINUOUS_AUTO_VIDEO = 2,
        FOCUS_MODE_EDOF = 3,
        FOCUS_MODE_FIXED = 4,
        FOCUS_MODE_INFINITY = 5,
        FOCUS_MODE_MACRO = 6,
    }

    public enum FlashMode
    {
        FLASH_MODE_AUTO = 0,
        FLASH_MODE_OFF = 1,
        FLASH_MODE_ON = 2,
        FLASH_MODE_RED_EYE = 3,
        FLASH_MODE_TORCH = 4,
    }

    public enum ExposureMode
    {
        EXPOSURE_MODE_MANUAL = 0,
        EXPOSURE_MODE_CONTINUOUS_AUTO = 1,
    }

    public enum WhiteBalanceMode
    {
        WHITE_BALANCE_MODE_CONTINUOUS_AUTO = 0,
        WHITE_BALANCE_MODE_CLOUDY_DAYLIGHT = 1,
        WHITE_BALANCE_MODE_DAYLIGHT = 2,
        WHITE_BALANCE_MODE_FLUORESCENT = 3,
        WHITE_BALANCE_MODE_INCANDESCENT = 4,
        WHITE_BALANCE_MODE_SHADE = 5,
        WHITE_BALANCE_MODE_TWILIGHT = 6,
        WHITE_BALANCE_MODE_WARM_FLUORESCENT = 7,
        WHITE_BALANCE_MODE_MANUAL = 8,
    }

    public enum SceneMode
    {
        SCENE_MODE_ACTION = 0,
        SCENE_MODE_AUTO = 1,
        SCENE_MODE_BARCODE = 2,
        SCENE_MODE_BEACH = 3,
        SCENE_MODE_CANDLELIGHT = 4,
        SCENE_MODE_FIREWORKS = 5,
        SCENE_MODE_LANDSCAPE = 6,
        SCENE_MODE_NIGHT = 7,
        SCENE_MODE_NIGHT_PORTRAIT = 8,
        SCENE_MODE_PARTY = 9,
        SCENE_MODE_PORTRAIT = 10,
        SCENE_MODE_SNOW = 11,
        SCENE_MODE_SPORTS = 12,
        SCENE_MODE_STEADYPHOTO = 13,
        SCENE_MODE_SUNSET = 14,
        SCENE_MODE_THEATRE = 15,
    }

    public class Smart : IDisposable
    {
        public IntPtr self_; // 0x8

        // RVA: 0x2B49904 Offset: 0x2B49904 VA: 0x2B49904
        public Smart(string filePath)
        {
            self_ = sarSmartar_SarSmart_SarSmart(filePath);
        }

        // RVA: 0x2B49A34 Offset: 0x2B49A34 VA: 0x2B49A34 Slot: 1
        ~Smart()
        {
            Dispose();
        }

        // RVA: 0x2B49A98 Offset: 0x2B49A98 VA: 0x2B49A98 Slot: 4
        public void Dispose()
        {
            if(self_ != IntPtr.Zero)
            {
                sarSmartar_SarSmart_sarDelete(self_);
                self_ = IntPtr.Zero;
            }
        }

        // // RVA: 0x2B49BF0 Offset: 0x2B49BF0 VA: 0x2B49BF0
        public int getInitResultCode()
        {
            return sarSmartar_SarSmart_sarGetInitResultCode(self_);
        }

        // RVA: 0x2B49CE4 Offset: 0x2B49CE4 VA: 0x2B49CE4
        public bool isConstructorFailed()
        {
            return sarSmartar_SarSmart_sarIsConstructorFailed(self_) != 0;
        }

        // // RVA: 0x2B49930 Offset: 0x2B49930 VA: 0x2B49930
        [DllImport("smartar")]
        private static extern IntPtr sarSmartar_SarSmart_SarSmart(string filePath);

        // // RVA: 0x2B49B10 Offset: 0x2B49B10 VA: 0x2B49B10
        [DllImport("smartar")]
        private static extern void sarSmartar_SarSmart_sarDelete(IntPtr self);

        // // RVA: 0x2B49BF8 Offset: 0x2B49BF8 VA: 0x2B49BF8
        [DllImport("smartar")]
        private static extern int sarSmartar_SarSmart_sarGetInitResultCode(IntPtr self);

        // // RVA: 0x2B49D00 Offset: 0x2B49D00 VA: 0x2B49D00
        [DllImport("smartar")]
        private static extern int sarSmartar_SarSmart_sarIsConstructorFailed(IntPtr self);
    }
}