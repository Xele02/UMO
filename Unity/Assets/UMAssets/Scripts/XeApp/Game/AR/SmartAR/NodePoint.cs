
using System.Runtime.InteropServices;
using UnityEngine;

namespace smartar
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NodePoint
    {
        public uint id_; // 0x0
        public Vector3 position_; // 0x4
    }
}