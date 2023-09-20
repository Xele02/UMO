
using UnityEngine;

namespace XeApp
{ 
	public class DecorationItemBaseSetting // TypeDefIndex: 7374
	{
		public enum PriorityControlType
		{
			FloorBack = 0,
			Wall = 1,
			Floor = 2,
			Front = 3,
			Num = 4,
		}

		public DecorationConstants.Attribute.Type AttributeType; // 0x8
		public DecorationConstants.Attribute.AreaType AreaType; // 0xC
		public bool IsAutoFlip; // 0x10
		public bool IsOverlay; // 0x11
		public PriorityControlType PriorityControl; // 0x14
		public bool IsOnShelf; // 0x18
		public bool IsShelf; // 0x19
		public Vector2 AdjustOffset; // 0x1C
		public int FontSizeType; // 0x24
		public int Thickness; // 0x28
		public int Order; // 0x2C
		public Vector2 InitPosition; // 0x30
		public int InitOrder; // 0x38
		public bool InitFlip; // 0x3C
		public int InitWord; // 0x40
		public int InitStatusFlag; // 0x44
		public KDKFHGHGFEK viewDecoItemData; // 0x48

		// RVA: 0x1AD4BE8 Offset: 0x1AD4BE8 VA: 0x1AD4BE8
		public DecorationItemBaseSetting()
		{
			return;
		}

		// RVA: 0x1AC30EC Offset: 0x1AC30EC VA: 0x1AC30EC
		public DecorationItemBaseSetting(KDKFHGHGFEK viewDecoItemData)
		{
			TodoLogger.LogError(0, "DecorationItemBaseSetting");
		}

		//// RVA: 0x1AD4EAC Offset: 0x1AD4EAC VA: 0x1AD4EAC
		//private int MakeThickness(KDKFHGHGFEK viewDecoItemData) { }

		// RVA: 0x1ABF944 Offset: 0x1ABF944 VA: 0x1ABF944
		public DecorationItemBaseSetting(NDBFKHKMMCE_DecoItem.FIDBAFHNGCF info)
		{
			TodoLogger.LogError(0, "DecorationItemBaseSetting 2");
		}

		//// RVA: 0x1AD0934 Offset: 0x1AD0934 VA: 0x1AD0934
		//public bool CheckAttribute(DecorationConstants.Attribute.Type attribute) { }

		//// RVA: 0x1AD4D8C Offset: 0x1AD4D8C VA: 0x1AD4D8C
		//private static bool MakeOnShelf(KDKFHGHGFEK viewDecoItemData) { }

		//// RVA: 0x1AD4C14 Offset: 0x1AD4C14 VA: 0x1AD4C14
		//private static bool MakeAutoFlip(KDKFHGHGFEK viewDecoItemData) { }

		//// RVA: 0x1AD4E7C Offset: 0x1AD4E7C VA: 0x1AD4E7C
		//private bool MakeIsShelf(EKLNMHFCAOI.FKGCBLHOOCL ctg, int type) { }

		//// RVA: 0x1AD4D14 Offset: 0x1AD4D14 VA: 0x1AD4D14
		//private bool MakeOverlay(EKLNMHFCAOI.FKGCBLHOOCL ctg, DecorationConstants.Attribute.Type attr, int type) { }

		//// RVA: 0x1AD4E84 Offset: 0x1AD4E84 VA: 0x1AD4E84
		//private DecorationItemBaseSetting.PriorityControlType MakePriortyControl(EKLNMHFCAOI.FKGCBLHOOCL ctg, int type, DecorationConstants.Attribute.Type attr) { }

		//// RVA: 0x1AD4BF0 Offset: 0x1AD4BF0 VA: 0x1AD4BF0
		//private DecorationConstants.Attribute.AreaType MakeAreaType(int attribute) { }

		//// RVA: 0x1AD5168 Offset: 0x1AD5168 VA: 0x1AD5168
		//private bool IsRug(EKLNMHFCAOI.FKGCBLHOOCL ctg, int type) { }
	}
}
