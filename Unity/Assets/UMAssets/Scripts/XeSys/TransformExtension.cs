
using UnityEngine;

namespace XeSys
{
	public static class TransformExtension // TypeDefIndex: 6057
	{
		//[ExtensionAttribute] // RVA: 0x690490 Offset: 0x690490 VA: 0x690490
		//// RVA: 0x23A774C Offset: 0x23A774C VA: 0x23A774C
		//public static void DestroyChildren(Transform transform) { }

		//[ExtensionAttribute] // RVA: 0x6904A0 Offset: 0x6904A0 VA: 0x6904A0
		//// RVA: 0x23A7838 Offset: 0x23A7838 VA: 0x23A7838
		//public static void DestroyChildrenImmediate(Transform transform, bool allowDestroyingAssets = False) { }

		//[ExtensionAttribute] // RVA: 0x6904B0 Offset: 0x6904B0 VA: 0x6904B0
		//// RVA: 0x23A7930 Offset: 0x23A7930 VA: 0x23A7930
		public static void SetPositionX(this Transform transform, float x)
		{
			Vector3 p = transform.position;
			p.x = x;
			transform.position = p;
		}

		//[ExtensionAttribute] // RVA: 0x6904C0 Offset: 0x6904C0 VA: 0x6904C0
		//// RVA: 0x23A79E8 Offset: 0x23A79E8 VA: 0x23A79E8
		public static void SetPositionY(this Transform transform, float y)
		{
			Vector3 p = transform.position;
			p.y = y;
			transform.position = p;
		}

		//[ExtensionAttribute] // RVA: 0x6904D0 Offset: 0x6904D0 VA: 0x6904D0
		//// RVA: 0x23A7AA0 Offset: 0x23A7AA0 VA: 0x23A7AA0
		public static void SetPositionZ(this Transform transform, float z)
		{
			Vector3 p = transform.position;
			p.z = z;
			transform.position = p;
		}

		//[ExtensionAttribute] // RVA: 0x6904E0 Offset: 0x6904E0 VA: 0x6904E0
		//// RVA: 0x23A7B58 Offset: 0x23A7B58 VA: 0x23A7B58
		//public static void AddPositionX(Transform transform, float x) { }

		//[ExtensionAttribute] // RVA: 0x6904F0 Offset: 0x6904F0 VA: 0x6904F0
		//// RVA: 0x23A7BB0 Offset: 0x23A7BB0 VA: 0x23A7BB0
		//public static void AddPositionY(Transform transform, float y) { }

		//[ExtensionAttribute] // RVA: 0x690500 Offset: 0x690500 VA: 0x690500
		//// RVA: 0x23A7C08 Offset: 0x23A7C08 VA: 0x23A7C08
		//public static void AddPositionZ(Transform transform, float z) { }

		//[ExtensionAttribute] // RVA: 0x690510 Offset: 0x690510 VA: 0x690510
		//// RVA: 0x23A7C60 Offset: 0x23A7C60 VA: 0x23A7C60
		//public static void SetLocalPositionX(Transform transform, float x) { }

		//[ExtensionAttribute] // RVA: 0x690520 Offset: 0x690520 VA: 0x690520
		//// RVA: 0x23A7D18 Offset: 0x23A7D18 VA: 0x23A7D18
		//public static void SetLocalPositionY(Transform transform, float y) { }

		//[ExtensionAttribute] // RVA: 0x690530 Offset: 0x690530 VA: 0x690530
		//// RVA: 0x23A7DD0 Offset: 0x23A7DD0 VA: 0x23A7DD0
		public static void SetLocalPositionZ(this Transform transform, float z)
		{
			transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, z);
		}

		//[ExtensionAttribute] // RVA: 0x690540 Offset: 0x690540 VA: 0x690540
		//// RVA: 0x23A7E88 Offset: 0x23A7E88 VA: 0x23A7E88
		//public static void AddLocalPositionX(Transform transform, float x) { }

		//[ExtensionAttribute] // RVA: 0x690550 Offset: 0x690550 VA: 0x690550
		//// RVA: 0x23A7EE0 Offset: 0x23A7EE0 VA: 0x23A7EE0
		//public static void AddLocalPositionY(Transform transform, float y) { }

		//[ExtensionAttribute] // RVA: 0x690560 Offset: 0x690560 VA: 0x690560
		//// RVA: 0x23A7F38 Offset: 0x23A7F38 VA: 0x23A7F38
		//public static void AddLocalPositionZ(Transform transform, float z) { }

		//[ExtensionAttribute] // RVA: 0x690570 Offset: 0x690570 VA: 0x690570
		//// RVA: 0x23A7F90 Offset: 0x23A7F90 VA: 0x23A7F90
		//public static void SetEulerAngleX(Transform transform, float x) { }

		//[ExtensionAttribute] // RVA: 0x690580 Offset: 0x690580 VA: 0x690580
		//// RVA: 0x23A8048 Offset: 0x23A8048 VA: 0x23A8048
		//public static void SetEulerAngleY(Transform transform, float y) { }

		//[ExtensionAttribute] // RVA: 0x690590 Offset: 0x690590 VA: 0x690590
		//// RVA: 0x23A8100 Offset: 0x23A8100 VA: 0x23A8100
		//public static void SetEulerAngleZ(Transform transform, float z) { }

		//[ExtensionAttribute] // RVA: 0x6905A0 Offset: 0x6905A0 VA: 0x6905A0
		//// RVA: 0x23A81B8 Offset: 0x23A81B8 VA: 0x23A81B8
		//public static void AddEulerAngleX(Transform transform, float x) { }

		//[ExtensionAttribute] // RVA: 0x6905B0 Offset: 0x6905B0 VA: 0x6905B0
		//// RVA: 0x23A8210 Offset: 0x23A8210 VA: 0x23A8210
		//public static void AddEulerAngleY(Transform transform, float y) { }

		//[ExtensionAttribute] // RVA: 0x6905C0 Offset: 0x6905C0 VA: 0x6905C0
		//// RVA: 0x23A8268 Offset: 0x23A8268 VA: 0x23A8268
		//public static void AddEulerAngleZ(Transform transform, float z) { }

		//[ExtensionAttribute] // RVA: 0x6905D0 Offset: 0x6905D0 VA: 0x6905D0
		//// RVA: 0x23A82C0 Offset: 0x23A82C0 VA: 0x23A82C0
		//public static void SetLocalEulerAngleX(Transform transform, float x) { }

		//[ExtensionAttribute] // RVA: 0x6905E0 Offset: 0x6905E0 VA: 0x6905E0
		//// RVA: 0x23A8378 Offset: 0x23A8378 VA: 0x23A8378
		//public static void SetLocalEulerAngleY(Transform transform, float y) { }

		//[ExtensionAttribute] // RVA: 0x6905F0 Offset: 0x6905F0 VA: 0x6905F0
		//// RVA: 0x23A8430 Offset: 0x23A8430 VA: 0x23A8430
		public static void SetLocalEulerAngleZ(this Transform transform, float z)
		{
			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, z);
		}

		//[ExtensionAttribute] // RVA: 0x690600 Offset: 0x690600 VA: 0x690600
		//// RVA: 0x23A84E8 Offset: 0x23A84E8 VA: 0x23A84E8
		//public static void AddLocalEulerAngleX(Transform transform, float x) { }

		//[ExtensionAttribute] // RVA: 0x690610 Offset: 0x690610 VA: 0x690610
		//// RVA: 0x23A8540 Offset: 0x23A8540 VA: 0x23A8540
		//public static void AddLocalEulerAngleY(Transform transform, float y) { }

		//[ExtensionAttribute] // RVA: 0x690620 Offset: 0x690620 VA: 0x690620
		//// RVA: 0x23A8598 Offset: 0x23A8598 VA: 0x23A8598
		//public static void AddLocalEulerAngleZ(Transform transform, float z) { }

		//[ExtensionAttribute] // RVA: 0x690630 Offset: 0x690630 VA: 0x690630
		//// RVA: 0x23A85F0 Offset: 0x23A85F0 VA: 0x23A85F0
		//public static void SetLocalScaleX(Transform transform, float x) { }

		//[ExtensionAttribute] // RVA: 0x690640 Offset: 0x690640 VA: 0x690640
		//// RVA: 0x23A86A8 Offset: 0x23A86A8 VA: 0x23A86A8
		//public static void SetLocalScaleY(Transform transform, float y) { }

		//[ExtensionAttribute] // RVA: 0x690650 Offset: 0x690650 VA: 0x690650
		//// RVA: 0x23A8760 Offset: 0x23A8760 VA: 0x23A8760
		//public static void SetLocalScaleZ(Transform transform, float z) { }

		//[ExtensionAttribute] // RVA: 0x690660 Offset: 0x690660 VA: 0x690660
		//// RVA: 0x23A8818 Offset: 0x23A8818 VA: 0x23A8818
		//public static void AddLocalScaleX(Transform transform, float x) { }

		//[ExtensionAttribute] // RVA: 0x690670 Offset: 0x690670 VA: 0x690670
		//// RVA: 0x23A8870 Offset: 0x23A8870 VA: 0x23A8870
		//public static void AddLocalScaleY(Transform transform, float y) { }

		//[ExtensionAttribute] // RVA: 0x690680 Offset: 0x690680 VA: 0x690680
		//// RVA: 0x23A88C8 Offset: 0x23A88C8 VA: 0x23A88C8
		//public static void AddLocalScaleZ(Transform transform, float z) { }
	}
}
