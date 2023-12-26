
using UnityEngine;

namespace UdonLib
{
    public class Utils
    {
        // // RVA: 0x13073A8 Offset: 0x13073A8 VA: 0x13073A8
        // public static float ParseFloat(string word, float defaultValue) { }

        // // RVA: 0x1307410 Offset: 0x1307410 VA: 0x1307410
        // public static int ParseInt(string word, int defaultValue) { }

        // // RVA: 0x1307474 Offset: 0x1307474 VA: 0x1307474
        // public static Vector3 CatmullRom(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3) { }

        // // RVA: 0x1307824 Offset: 0x1307824 VA: 0x1307824
        public static Transform SearchNodeByName(Transform root, string targetName)
        {
            Transform t = root.Find(targetName);
            if(t == null)
            {
                for(int i = 0; i < root.childCount; i++)
                {
                    t = SearchNodeByName(root.GetChild(i), targetName);
                    if(t != null)
                        return t;
                }
            }
            return t;
        }

        // // RVA: 0x1307980 Offset: 0x1307980 VA: 0x1307980
        // public static void SetGameObjectLayerChildren(Transform root, int layerNo) { }

        // // RVA: 0x1307A2C Offset: 0x1307A2C VA: 0x1307A2C
        // public static string HanToZenNum(string s) { }

        // // RVA: 0x1307B98 Offset: 0x1307B98 VA: 0x1307B98
        // private static int min(int[] param) { }

        // // RVA: 0x1307C24 Offset: 0x1307C24 VA: 0x1307C24
        // public static int LevenshteinDistance(string str1, string str2) { }
    }
}