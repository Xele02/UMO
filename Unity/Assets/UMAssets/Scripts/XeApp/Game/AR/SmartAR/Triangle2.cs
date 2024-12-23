
using System.Runtime.InteropServices;
using UnityEngine;

namespace smartar
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Triangle2
    {
        public Vector2 p0_; // 0x0
        public Vector2 p1_; // 0x8
        public Vector2 p2_; // 0x10
    }
}
