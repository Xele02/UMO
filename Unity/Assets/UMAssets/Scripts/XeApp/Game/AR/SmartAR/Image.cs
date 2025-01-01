
using System;
using System.Runtime.InteropServices;

namespace smartar
{
    public enum ImageFormat
    {
        IMAGE_FORMAT_L8 = 0,
        IMAGE_FORMAT_YCRCB420 = 1,
        IMAGE_FORMAT_YCBCR420 = 2,
        IMAGE_FORMAT_RGBA8888 = 3,
        IMAGE_FORMAT_JPEG = 4,
        IMAGE_FORMAT_RGB888 = 5,
        IMAGE_FORMAT_ABGR8888 = 6,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Image
    {
        public IntPtr pixels_; // 0x0
        public int width_; // 0x4
        public int height_; // 0x8
        public int stride_; // 0xC
        public ImageFormat format_; // 0x10
    }
}