using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace smartar
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RecognitionResult
    {
        public IntPtr target_; // 0x0
        public bool isRecognized_; // 0x4
        public Vector3 position_; // 0x8
        public Quaternion rotation_; // 0x14
        public ulong timestamp_; // 0x28
        public Vector3 velocity_; // 0x30
        public Vector3 angularVelocity_; // 0x3C
        public TargetTrackingState targetTrackingState_; // 0x48
        public SceneMappingState sceneMappingState_; // 0x4C
        public int numLandmarks_; // 0x50
        public int maxLandmarks_; // 0x54
        public IntPtr landmarks_; // 0x58
        public int numNodePoints_; // 0x5C
        public int maxNodePoints_; // 0x60
        public IntPtr nodePoints_; // 0x64
        public int numInitPoints_; // 0x68
        public int maxInitPoints_; // 0x6C
        public IntPtr initPoints_; // 0x70
    }
}