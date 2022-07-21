using UnityEngine;

namespace XeSys
{
	public class Math
	{
		// // RVA: 0x238F5F4 Offset: 0x238F5F4 VA: 0x238F5F4
		// public static bool Random100(float rate) { }

		// // RVA: 0x238F6BC Offset: 0x238F6BC VA: 0x238F6BC
		// public static int Repeat(int val, int min, int max) { }

		// // RVA: 0x238F6E4 Offset: 0x238F6E4 VA: 0x238F6E4
		// public static float Repeat(float val, float min, float max) { }

		// // RVA: 0x238F720 Offset: 0x238F720 VA: 0x238F720
		// public static Vector2 Repeat(Vector2 val, Vector2 min, Vector2 max) { }

		// // RVA: 0x238F90C Offset: 0x238F90C VA: 0x238F90C
		// public static Vector3 Repeat(Vector3 val, Vector3 min, Vector3 max) { }

		// // RVA: 0x238FB20 Offset: 0x238FB20 VA: 0x238FB20
		// public static Color Repeat(Color val, Color min, Color max) { }

		// // RVA: 0x238FCE0 Offset: 0x238FCE0 VA: 0x238FCE0
		// public static Vector3 NoClampLerp(Vector3 start, Vector3 end, float t) { }

		// // RVA: 0x238FDF0 Offset: 0x238FDF0 VA: 0x238FDF0
		// public static float CalcRadian(Vector2 start, Vector2 end) { }

		// // RVA: 0x238FEA0 Offset: 0x238FEA0 VA: 0x238FEA0
		// public static float CalcDegree(Vector2 start, Vector2 end) { }

		// // RVA: 0x238FECC Offset: 0x238FECC VA: 0x238FECC
		// public static int CalcAngleType(int divCount, Vector2 start, Vector2 end, bool isHalfOffset) { }

		// // RVA: 0x238FF60 Offset: 0x238FF60 VA: 0x238FF60
		public static float CalcNearDistancePointToLine(Vector3 point, Vector3 lineStart, Vector3 lineEnd, out float lineNearestTargetRate)
		{
			float dot;
			float dist;
			Vector3 cross = Vector3.Cross(lineEnd - lineStart, point - lineStart);
			if(Mathf.Epsilon <= Vector3.Dot(point - lineStart, lineEnd - lineStart))
			{
				if(Mathf.Epsilon <= Vector3.Dot(lineStart - lineEnd, point - lineEnd))
				{
					dist = cross.magnitude / (lineEnd - lineStart).magnitude;
					dot = Vector3.Dot((lineEnd - lineStart).normalized, point - lineStart);
				}
				else
				{
					dist = (point - lineEnd).magnitude;
					dot = (lineEnd - lineStart).magnitude;
				}
			}
			else
			{
				dist = (point - lineStart).magnitude;
				dot = 0;
			}
			lineNearestTargetRate = dot / (lineEnd - lineStart).magnitude;
			return dist;
		}

		// // RVA: 0x2390464 Offset: 0x2390464 VA: 0x2390464
		public static float CalcNearDistanceLineToLine(Vector3 line1StartPoint, Vector3 line1EndPoint, Vector3 line2StartPoint, Vector3 line2EndPoint, out float line1NearestTargetRate, out float line2NearestTargetRate)
		{
			UnityEngine.Debug.LogError("TODO CalcNearDistanceLineToLine");
			line1NearestTargetRate = 0;
			line2NearestTargetRate = 0;
			return 9999;
		}

	}
}
