
using System;
using System.Runtime.InteropServices;

namespace smartar
{
    public class ImageHolder
    {
        public IntPtr self_; // 0x8

        // RVA: 0x20B8AF4 Offset: 0x20B8AF4 VA: 0x20B8AF4
        public ImageHolder(IntPtr self)
        {
            self_ = self;
        }

        // RVA: 0x20C0F4C Offset: 0x20C0F4C VA: 0x20C0F4C Slot: 1
        ~ImageHolder()
        {
            self_ = IntPtr.Zero;
        }

        // // RVA: 0x20C0FAC Offset: 0x20C0FAC VA: 0x20C0FAC
        public int getImageSizeInBytes()
        {
            return sarSmartar_SarImageHolder_sarGetImageSizeInBytes(self_);
        }

        // // RVA: 0x20C10AC Offset: 0x20C10AC VA: 0x20C10AC
        public int getImage(ref Image image, int maxSizeInBytes, Smart smart)
        {
            return sarSmartar_SarImageHolder_sarGetImage(self_, ref image, maxSizeInBytes, smart.self_);
        }

        // // RVA: 0x20C0FB8 Offset: 0x20C0FB8 VA: 0x20C0FB8
        [DllImport("smartar")]
        private static extern int sarSmartar_SarImageHolder_sarGetImageSizeInBytes(IntPtr self);

        // // RVA: 0x20C10F8 Offset: 0x20C10F8 VA: 0x20C10F8
        [DllImport("smartar")]
        private static extern int sarSmartar_SarImageHolder_sarGetImage(IntPtr self, ref Image image, int maxSizeInBytes, IntPtr smart);
    }
}