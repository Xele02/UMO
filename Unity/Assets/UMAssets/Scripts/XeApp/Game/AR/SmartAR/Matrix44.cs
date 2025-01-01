
using System.Runtime.InteropServices;

namespace smartar
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Matrix44
    {
        public float v00_; // 0x0
        public float v01_; // 0x4
        public float v02_; // 0x8
        public float v03_; // 0xC
        public float v10_; // 0x10
        public float v11_; // 0x14
        public float v12_; // 0x18
        public float v13_; // 0x1C
        public float v20_; // 0x20
        public float v21_; // 0x24
        public float v22_; // 0x28
        public float v23_; // 0x2C
        public float v30_; // 0x30
        public float v31_; // 0x34
        public float v32_; // 0x38
        public float v33_; // 0x3C

        // RVA: 0x20C2044 Offset: 0x20C2044 VA: 0x20C2044
        public static Matrix44 operator*(Matrix44 lhs, Matrix44 rhs) 
        {
            return sarSmartar_SarMatrix44_sarMulM(ref lhs, ref rhs);
        }

        // RVA: 0x20C2148 Offset: 0x20C2148 VA: 0x20C2148
#if UNITY_EDITOR
        private static Matrix44 sarSmartar_SarMatrix44_sarMulM(ref Matrix44 lhs, ref Matrix44 rhs)
        {
            return new Matrix44();
        }
#else
        [DllImport("smartar")]
        private static extern Matrix44 sarSmartar_SarMatrix44_sarMulM(ref Matrix44 lhs, ref Matrix44 rhs);
#endif
    }
}