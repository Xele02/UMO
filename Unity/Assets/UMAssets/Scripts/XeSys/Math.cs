using UnityEngine;

namespace XeSys
{
	public class Math
	{
		public interface ICurveEvaluator
		{
			// RVA: -1 Offset: -1 Slot: 0
			Vector3 Evaluate(float t);
		}

		public class CurveBezier3 : ICurveEvaluator
		{
			public Vector3 p0 { get; set; } // 0x8
			public Vector3 p1 { get; set; } // 0x14
			public Vector3 p2 { get; set; } // 0x20
			public Vector3 p3 { get; set; } // 0x2C

			// RVA: 0x239134C Offset: 0x239134C VA: 0x239134C
			public CurveBezier3(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
			{
				this.p0 = p0;
				this.p1 = p1;
				this.p2 = p2;
				this.p3 = p3;
			}

			//// RVA: 0x23913B8 Offset: 0x23913B8 VA: 0x23913B8 Slot: 4
			public Vector3 Evaluate(float t)
			{
				TodoLogger.LogError(0, "CurveBezier3 Evaluate");
				return Vector3.zero;
			}

			//// RVA: 0x23915E0 Offset: 0x23915E0 VA: 0x23915E0
			public static void CalcCoefficient(float t, out float tA, out float tB, out float tC, out float tD)
			{
				t = Mathf.Clamp01(t);
				tA = t * t * t;
				tB = 3 * t * t * (1 - t);
				tC = 3 * t * (1 - t) * (1 - t);
				tD = (1 - t) * (1 - t) * (1 - t);
			}

			//// RVA: 0x23916B4 Offset: 0x23916B4 VA: 0x23916B4
			public static float Evaluate(float t, float p0, float p1, float p2, float p3)
			{
				float A, B, C, D;
				CalcCoefficient(t, out A, out B, out C, out D);
				return A * p3 + B * p2 + C * p1 + D * p0;
			}

			//// RVA: 0x2391740 Offset: 0x2391740 VA: 0x2391740
			public static Vector2 Evaluate(float t, Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3)
			{
				float A, B, C, D;
				CalcCoefficient(t, out A, out B, out C, out D);
				return p3 * A + p2 * B + p1 * C + p0 * D;
			}

			//// RVA: 0x2391410 Offset: 0x2391410 VA: 0x2391410
			//public static Vector3 Evaluate(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3) { }
		}

		
		public class Tween
		{
			public enum EasingFunc
			{
				Liner = 0,
				InQuad = 1,
				OutQuad = 2,
				InOutQuad = 3,
				InCubic = 4,
				OutCubic = 5,
				InOutCubic = 6,
				InQuart = 7,
				OutQuart = 8,
				InOutQuart = 9,
				InQuint = 10,
				OutQuint = 11,
				InOutQuint = 12,
				InSine = 13,
				OutSine = 14,
				InOutSine = 15,
				InExpo = 16,
				OutExpo = 17,
				InOutExpo = 18,
				InCirc = 19,
				OutCirc = 20,
				InOutCirc = 21,
				InBack = 22,
				OutBack = 23,
				InOutBack = 24,
				InBounce = 25,
				OutBounce = 26,
				InOutBounce = 27,
				InElastic = 28,
				OutElastic = 29,
				InOutElastic = 30,
			}


			private const float RAD90 = 1.570796f;
			private const float RAD180 = 3.141593f;
			public static float S = 1.70158f; // 0x0
			private const float BOUNCE_T = 2.75f;

			//// RVA: 0x2394C40 Offset: 0x2394C40 VA: 0x2394C40
			public static float Evaluate(Math.Tween.EasingFunc type, float start, float end, float t)
			{
				switch(type)
				{
					case EasingFunc.InOutExpo:
						return EasingInOutExpo(start, end, t);
					default:
						TodoLogger.LogError(0, "Todo Evaluate "+type);
						break;
				}
				return 0;
			}

			//// RVA: 0x2396A6C Offset: 0x2396A6C VA: 0x2396A6C
			public static Vector3 Evaluate(EasingFunc type, Vector3 start, Vector3 end, float t)
			{
				return new Vector3(Evaluate(type, start.x, end.x, t), Evaluate(type, start.y, end.y, t), Evaluate(type, start.z, end.z, t));
			}

			//// RVA: 0x2396B78 Offset: 0x2396B78 VA: 0x2396B78
			//public static Vector2 Evaluate(Math.Tween.EasingFunc efunc, Vector2 start, Vector2 end, float t) { }

			//// RVA: 0x2396C58 Offset: 0x2396C58 VA: 0x2396C58
			//public static Color Evaluate(Math.Tween.EasingFunc efunc, Color start, Color end, float t) { }

			//// RVA: 0x2395638 Offset: 0x2395638 VA: 0x2395638
			//public static float EasingLerp(float start, float end, float t) { }

			//// RVA: 0x2395658 Offset: 0x2395658 VA: 0x2395658
			//public static float EasingInQuad(float start, float end, float t) { }

			//// RVA: 0x239567C Offset: 0x239567C VA: 0x239567C
			//public static float EasingOutQuad(float start, float end, float t) { }

			//// RVA: 0x23956AC Offset: 0x23956AC VA: 0x23956AC
			//public static float EasingInOutQuad(float start, float end, float t) { }

			//// RVA: 0x2395708 Offset: 0x2395708 VA: 0x2395708
			//public static float EasingInCubic(float start, float end, float t) { }

			//// RVA: 0x2395730 Offset: 0x2395730 VA: 0x2395730
			//public static float EasingOutCubic(float start, float end, float t) { }

			//// RVA: 0x2395764 Offset: 0x2395764 VA: 0x2395764
			public static float EasingInOutCubic(float start, float end, float t)
			{
				float f2 = t * 2;
				float f = (end - start) * 0.5f;
				if(t >= 0.5f)
				{
					start += f;
					f2 = 2 - f2;
					f2 = f * (1 - f2 * f2 * f2);
				}
				else
				{
					f2 = f2 * f2 * f * f2;
				}
				return f2 + start;
			}

			//// RVA: 0x2395980 Offset: 0x2395980 VA: 0x2395980
			//public static float EasingInSine(float start, float end, float t) { }

			//// RVA: 0x2395A38 Offset: 0x2395A38 VA: 0x2395A38
			//public static float EasingOutSine(float start, float end, float t) { }

			//// RVA: 0x2395AEC Offset: 0x2395AEC VA: 0x2395AEC
			//public static float EasingInOutSine(float start, float end, float t) { }

			//// RVA: 0x23957C8 Offset: 0x23957C8 VA: 0x23957C8
			//public static float EasingInQuart(float start, float end, float t) { }

			//// RVA: 0x23957F0 Offset: 0x23957F0 VA: 0x23957F0
			//public static float EasingOutQuart(float start, float end, float t) { }

			//// RVA: 0x2395824 Offset: 0x2395824 VA: 0x2395824
			//public static float EasingInOutQuart(float start, float end, float t) { }

			//// RVA: 0x2395894 Offset: 0x2395894 VA: 0x2395894
			//public static float EasingInQuint(float start, float end, float t) { }

			//// RVA: 0x23958C4 Offset: 0x23958C4 VA: 0x23958C4
			//public static float EasingOutQuint(float start, float end, float t) { }

			//// RVA: 0x2395904 Offset: 0x2395904 VA: 0x2395904
			//public static float EasingInOutQuint(float start, float end, float t) { }

			//// RVA: 0x2395BB0 Offset: 0x2395BB0 VA: 0x2395BB0
			//public static float EasingInExpo(float start, float end, float t) { }

			//// RVA: 0x2395C68 Offset: 0x2395C68 VA: 0x2395C68
			//public static float EasingOutExpo(float start, float end, float t) { }

			//// RVA: 0x2395D20 Offset: 0x2395D20 VA: 0x2395D20
			public static float EasingInOutExpo(float start, float end, float t)
			{
				float res = start;
				if(t > 0)
				{
					res = end;
					if(t < 1)
					{
						res = 2*t;
						if(res >= 1)
						{
							res = Mathf.Pow(2, (res - 1) * 10);
							res = 2 - res;
						}
						else
						{
							res = Mathf.Pow(2, (res - 1) * 10);
						}
						res = (end - start) * 0.5f * res + start;
					}
				}
				return res;
			}

			//// RVA: 0x2395E74 Offset: 0x2395E74 VA: 0x2395E74
			//public static float EasingInCirc(float start, float end, float t) { }

			//// RVA: 0x2395F48 Offset: 0x2395F48 VA: 0x2395F48
			//public static float EasingOutCirc(float start, float end, float t) { }

			//// RVA: 0x2396018 Offset: 0x2396018 VA: 0x2396018
			//public static float EasingInOutCirc(float start, float end, float t) { }

			//// RVA: 0x2396144 Offset: 0x2396144 VA: 0x2396144
			//public static float EasingInBack(float start, float end, float t) { }

			//// RVA: 0x2396210 Offset: 0x2396210 VA: 0x2396210
			//public static float EasingOutBack(float start, float end, float t) { }

			//// RVA: 0x23962E4 Offset: 0x23962E4 VA: 0x23962E4
			//public static float EasingInOutBack(float start, float end, float t) { }

			//// RVA: 0x23964C4 Offset: 0x23964C4 VA: 0x23964C4
			//public static float EasingOutBounce(float start, float end, float t) { }

			//// RVA: 0x239640C Offset: 0x239640C VA: 0x239640C
			//public static float EasingInBounce(float start, float end, float t) { }

			//// RVA: 0x239658C Offset: 0x239658C VA: 0x239658C
			//public static float EasingInOutBounce(float start, float end, float t) { }

			//// RVA: 0x239669C Offset: 0x239669C VA: 0x239669C
			//public static float EasingInElastic(float start, float end, float t) { }

			//// RVA: 0x23967B4 Offset: 0x23967B4 VA: 0x23967B4
			//public static float EasingOutElastic(float start, float end, float t) { }

			//// RVA: 0x23968C8 Offset: 0x23968C8 VA: 0x23968C8
			//public static float EasingInOutElastic(float start, float end, float t) { }
		}

		// // RVA: 0x238F5F4 Offset: 0x238F5F4 VA: 0x238F5F4
		// public static bool Random100(float rate) { }

		// // RVA: 0x238F6BC Offset: 0x238F6BC VA: 0x238F6BC
		public static int Repeat(int val, int min, int max)
		{
			int tmp = (max - min) + 1;
			for (; val < min; val += tmp) ;
			for (; max < val; val -= tmp) ;
			return val;
		}

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
		public static float CalcRadian(Vector2 start, Vector2 end)
		{
			return Mathf.Atan2(end.y - start.y, end.x - start.x);
		}

		// // RVA: 0x238FEA0 Offset: 0x238FEA0 VA: 0x238FEA0
		// public static float CalcDegree(Vector2 start, Vector2 end) { }

		// // RVA: 0x238FECC Offset: 0x238FECC VA: 0x238FECC
		public static int CalcAngleType(int divCount, Vector2 start, Vector2 end, bool isHalfOffset)
		{
			if (divCount == 0)
				return -1;
			else
			{
				float f = CalcRadian(start, end);
				if (isHalfOffset)
					f += 2 * Mathf.PI / divCount * 0.5f;
				if (f < 0)
					f += 2* Mathf.PI;
				return (int)(f / (2 * Mathf.PI) * divCount);
			}
		}

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
			Vector3 /*v70*/line1 = line1EndPoint - line1StartPoint;
			//Vector3 v9 = v70;
			Vector3 /*v80*/line2 = line2EndPoint - line2StartPoint;
			//Vector3 v7 = v80;
			Vector3 /*v90*/line12Start = line2StartPoint - line1StartPoint;
			//Vector3 v3 = v90;
			float f10 = Vector3.Dot(line2, line2);
			float f11 = Vector3.Dot(line1, line2);
			float f12 = Vector3.Dot(line12Start, line2);
			line1NearestTargetRate = 0;
			line2NearestTargetRate = 0;
			if (f10 >= 0)
			{
				Vector3 v70 = line2 * f11 / f10;
				Vector3 v80 = v70 - line1;
				Vector3 v90 = line2 * f12 / f10;
				v9c = v90 - line12Start;
				float f13 = Vector3.Dot(v80, v80);
				float f14 = Vector3.Dot(v80, v9c);
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
					line2NearestTargetRate = line2.x * line12Start.x + line2.y * line12Start.y + line2.z * line12Start.z / (0 - f10);
					float f19 = line2NearestTargetRate;
					v70 = line2 * f19;
					v80 = v70 + line2StartPoint;
					v90 = line1StartPoint - v80;
					v60 = v90;
					f17 = v60.sqrMagnitude;
					if (f15 < f17)
					{
						return f15;
					}
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
				f10 = ((f14 * line1.z - line12Start.z) * line2.z + (f14 * line1.x - line12Start.x) * line2.x + (f14 * line1.y - line12Start.y) * line2.y) / f10;
				line2NearestTargetRate = f10;
				if (f10 >= 0)
					f17 = 1.0f;
				else
					f17 = 0.0f;
				if (f10 <= 0 || f10 >= 1)
					line2NearestTargetRate = f17;
			}
			Vector3 line1Intersect = line1 * line1NearestTargetRate + line1StartPoint;
			Vector3 line2Intersect = line2 * line2NearestTargetRate + line2StartPoint;
			Vector3 intersectLine = line2Intersect - line1Intersect;
			return intersectLine.magnitude;
		}

	}
}
