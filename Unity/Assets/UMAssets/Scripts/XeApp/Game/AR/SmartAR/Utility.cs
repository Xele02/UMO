
using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace smartar
{
    public struct Utility
    {
        // // RVA: 0x2B49DFC Offset: 0x2B49DFC VA: 0x2B49DFC
        public static int convertPose2Matrix(Vector3 position, Quaternion rotation, out Matrix44 matrix)
        {
            return sarSmartar_sarConvertPose2Matrix(ref position, ref rotation, out matrix);
        }

        // // RVA: 0x2B49F3C Offset: 0x2B49F3C VA: 0x2B49F3C
        public static Matrix44 setPerspectiveM(float fovy, float aspect, float near, float far)
        {
            return sarSmartar_sarSetPerspectiveM(fovy, aspect, near, far);
        }

        // // RVA: 0x2B4A060 Offset: 0x2B4A060 VA: 0x2B4A060
        // public static void memcpy(IntPtr dst, IntPtr src, int length) { }

        // RVA: 0x2B4A188 Offset: 0x2B4A188 VA: 0x2B4A188
        public static bool isMultiCore()
        {
            return sarSmartar_sarIsMultiCore();
        }

        // // RVA: 0x2B49E48 Offset: 0x2B49E48 VA: 0x2B49E48
#if UNITY_EDITOR
        private static int sarSmartar_sarConvertPose2Matrix(ref Vector3 position, ref Quaternion rotation, out Matrix44 matrix)
        {
            matrix = new Matrix44();
            return 0;
        }
#else
        [DllImport("smartar")]
        private static extern int sarSmartar_sarConvertPose2Matrix(ref Vector3 position, ref Quaternion rotation, out Matrix44 matrix);
#endif

        // // RVA: 0x2B49F60 Offset: 0x2B49F60 VA: 0x2B49F60
#if UNITY_EDITOR
        private static Matrix44 sarSmartar_sarSetPerspectiveM(float fovy, float aspect, float near, float far)
        {
            return new Matrix44();
        }
#else
        [DllImport("smartar")]
        private static extern Matrix44 sarSmartar_sarSetPerspectiveM(float fovy, float aspect, float near, float far);
#endif

        // // RVA: 0x2B4A068 Offset: 0x2B4A068 VA: 0x2B4A068
        // private static extern void sarSmartar_sarMemcpy(IntPtr dst, IntPtr src, int length) { }

        // // RVA: 0x2B4A190 Offset: 0x2B4A190 VA: 0x2B4A190
#if UNITY_EDITOR
        private static bool sarSmartar_sarIsMultiCore()
        {
            return false;
        }
#else
        [DllImport("smartar")]
        private static extern bool sarSmartar_sarIsMultiCore();
#endif
    }
}