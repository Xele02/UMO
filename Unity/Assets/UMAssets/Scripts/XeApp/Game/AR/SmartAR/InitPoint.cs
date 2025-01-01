
using System.Runtime.InteropServices;

namespace smartar
{
    [StructLayout(LayoutKind.Sequential)]
    public struct InitPoint
    {
        public uint id_; // 0x0
        public Vector2 position_; // 0x4
    }
}