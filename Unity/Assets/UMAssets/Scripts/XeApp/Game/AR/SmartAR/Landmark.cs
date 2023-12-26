
using System.Runtime.InteropServices;
using UnityEngine;

namespace smartar
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Landmark
    {
        public uint id_; // 0x0
        public LandmarkState state_; // 0x4
        public Vector3 position_; // 0x8
    }
}