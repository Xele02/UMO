
using System.Runtime.InteropServices;

namespace smartar
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector3
    {
        public float x_; // 0x0
        public float y_; // 0x4
        public float z_; // 0x8
    }
}