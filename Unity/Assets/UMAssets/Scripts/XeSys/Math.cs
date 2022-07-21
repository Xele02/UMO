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
			float f17;
			Vector3 v9c;
			Vector3 v70 = line1EndPoint - line1StartPoint;
			Vector3 v9 = v70;
			Vector3 v80 = line2EndPoint - line2StartPoint;
			Vector3 v7 = v80;
			Vector3 v90 = line2StartPoint - line1StartPoint;
			Vector3 v3 = v90;
			float f10 = Vector3.Dot(v80, v80);
			float f11 = Vector3.Dot(v70, v80);
			float f12 = Vector3.Dot(v90, v80);
			line1NearestTargetRate = 0;
			line2NearestTargetRate = 0;
			if (f10 >= 0)
			{
				v70 = v7 * f11 / f10;
				v80 = v70 - v9;
				v90 = v7 * f12 / f10;
				v9c = v90 - v3;
				Vector3 v8 = v80;
				Vector3 v2 = v9c;
				float f13 = Vector3.Dot(v80, v80);
				float f14 = Vector3.Dot(v8, v9c);
				if (f13 < Mathf.Epsilon)
				{
					line1NearestTargetRate = 0;
					v70 = line1StartPoint - line2StartPoint;
					Vector3 v60 = v70;
					float f15 = v60.sqrMagnitude;
					v80 = line1StartPoint - line2EndPoint;
					v60 = v80;
					float f16 = v60.sqrMagnitude;
					if (f16 < f15)
						f15 = f16;
					v70 = line1EndPoint - line2StartPoint;
					v60 = v70;
					f16 = v60.sqrMagnitude;
					if (f16 < f15)
						f15 = f16;
					v70 = line1EndPoint - line2EndPoint;
					v60 = v70;
					f17 = v60.sqrMagnitude;
					if (f17 < f15)
						f15 = f17;
					line2NearestTargetRate = v7.x * v3.x + v7.y * v3.y + v7.z * v3.z / (0 - f10);
					float f19 = line2NearestTargetRate;
					v70 = v7 * f19;
					v80 = v70 + line2StartPoint;
					v90 = line1StartPoint - v80;
					v60 = v90;
					f17 = v60.sqrMagnitude;
					if (f15 < f17)
						return f15;
					return f17;
				}
				f14 = f14 / f13;
				line1NearestTargetRate = f14;
				if (f14 >= 0)
					f11 = 1.0f;
				else
					f11 = 0.0f;
				if (f14 < 0 || f14 >= 1.0f)
				{
					f14 = f11;
					line1NearestTargetRate = f14;
				}
				f10 = ((f14 * v9.z - v3.z) * v7.z + (f14 * v9.x - v3.x) * v7.x + (f14 * v9.y - v3.y) * v7.y) / f10;
				line2NearestTargetRate = f10;
				if (f10 >= 0)
					f17 = 1.0f;
				else
					f17 = 0.0f;
				if (f10 <= 0 || f10 >= 1)
					line2NearestTargetRate = f17;
			}
			f17 = line2NearestTargetRate;
			v70 = v9 * f17;
			v80 = v70 + line1StartPoint;
			v90 = v7 * line2NearestTargetRate;
			v9c = v90 + line2StartPoint;
			Vector3 va8 = v9c - v80;
			return va8.sqrMagnitude;
		}

	}
}
