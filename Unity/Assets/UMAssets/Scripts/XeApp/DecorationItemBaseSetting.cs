
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
			AttributeType = DecorationConstants.MakeAttribute(viewDecoItemData);
			this.viewDecoItemData = new KDKFHGHGFEK();
			this.viewDecoItemData.ODDIHGPONFL(viewDecoItemData);
			AreaType = MakeAreaType((int)AttributeType);
			IsAutoFlip = MakeAutoFlip(viewDecoItemData);
			IsOverlay = MakeOverlay(viewDecoItemData.NPADACLCNAN_Category, AttributeType, viewDecoItemData.FJFCNGNGIBN);
			IsOnShelf = MakeOnShelf(viewDecoItemData);
			IsShelf = false;
			PriorityControl = MakePriortyControl(viewDecoItemData.NPADACLCNAN_Category, viewDecoItemData.GBJFNGCDKPM_Attribute, AttributeType);
			AdjustOffset.x = viewDecoItemData.EDEEMPJPFCP;
			AdjustOffset.y = viewDecoItemData.HDHNEILDILJ;
			FontSizeType = viewDecoItemData.DBGAJBIBODC_FontType;
			Thickness = MakeThickness(viewDecoItemData);
			Order = viewDecoItemData.EILKGEADKGH;
		}

		//// RVA: 0x1AD4EAC Offset: 0x1AD4EAC VA: 0x1AD4EAC
		private int MakeThickness(KDKFHGHGFEK viewDecoItemData)
		{
			int a = 0;
			string str = "";
			if(viewDecoItemData.NPADACLCNAN_Category == EKLNMHFCAOI.FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara)
			{
				str = "deco_chara_thickness";
				a = 50;
			}
			else if(viewDecoItemData.NPADACLCNAN_Category == EKLNMHFCAOI.FKGCBLHOOCL_Category.HEMGMACMGAB_DecoItemVFFigure)
			{
				str = "deco_valkyrie_thickness";
				a = 10;
			}
			else if(viewDecoItemData.NPADACLCNAN_Category == EKLNMHFCAOI.FKGCBLHOOCL_Category.NNBMEEPOBIO_DecoItemCostumeTorso)
			{
				str = "deco_costume_thickness";
				a = 10;
			}
			else
			{
				return viewDecoItemData.BHDHPCDLICO_Thickness;
			}
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.LPJLEHAJADA(str, a);
		}

		// RVA: 0x1ABF944 Offset: 0x1ABF944 VA: 0x1ABF944
		public DecorationItemBaseSetting(NDBFKHKMMCE_DecoItem.FIDBAFHNGCF info)
		{
			AttributeType = (DecorationConstants.Attribute.Type)info.FJFCNGNGIBN_Attribute;
			AreaType = MakeAreaType((int)AttributeType);
			IsAutoFlip = info.FAKNMCIIAEM_IsAutoFlip == 1;
			IsOnShelf = info.CMMNFCJNIOO_IsOnShelf == 1;
			AdjustOffset.x = info.NGILPOOLBCF;
			AdjustOffset.y = info.JINEKNIBOFI;
		}

		//// RVA: 0x1AD0934 Offset: 0x1AD0934 VA: 0x1AD0934
		//public bool CheckAttribute(DecorationConstants.Attribute.Type attribute) { }

		//// RVA: 0x1AD4D8C Offset: 0x1AD4D8C VA: 0x1AD4D8C
		private static bool MakeOnShelf(KDKFHGHGFEK viewDecoItemData)
		{
			if(viewDecoItemData.NPADACLCNAN_Category != EKLNMHFCAOI.FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara)
			{
				if(viewDecoItemData.NPADACLCNAN_Category < EKLNMHFCAOI.FKGCBLHOOCL_Category.OOMMOOIIPJE_DecoItemPoster
					|| viewDecoItemData.NPADACLCNAN_Category > EKLNMHFCAOI.FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft)
					return viewDecoItemData.GEMAFKNIKJN_IsOnShelf;
			}
			return false;
		}

		//// RVA: 0x1AD4C14 Offset: 0x1AD4C14 VA: 0x1AD4C14
		private static bool MakeAutoFlip(KDKFHGHGFEK viewDecoItemData)
		{
			if(viewDecoItemData.NPADACLCNAN_Category != EKLNMHFCAOI.FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara)
			{
				if(viewDecoItemData.NPADACLCNAN_Category < EKLNMHFCAOI.FKGCBLHOOCL_Category.OOMMOOIIPJE_DecoItemPoster
					|| viewDecoItemData.NPADACLCNAN_Category > EKLNMHFCAOI.FKGCBLHOOCL_Category.KKGHNKKGLCO_DecoItemPosterSceneAft)
					return viewDecoItemData.FAKNMCIIAEM_IsAutoFlip == 1;
				return true;
			}
			return false;
		}

		//// RVA: 0x1AD4E7C Offset: 0x1AD4E7C VA: 0x1AD4E7C
		//private bool MakeIsShelf(EKLNMHFCAOI.FKGCBLHOOCL ctg, int type) { }

		//// RVA: 0x1AD4D14 Offset: 0x1AD4D14 VA: 0x1AD4D14
		private bool MakeOverlay(EKLNMHFCAOI.FKGCBLHOOCL_Category ctg, DecorationConstants.Attribute.Type attr, int type)
		{
			return true;
		}

		//// RVA: 0x1AD4E84 Offset: 0x1AD4E84 VA: 0x1AD4E84
		private PriorityControlType MakePriortyControl(EKLNMHFCAOI.FKGCBLHOOCL_Category ctg, int type, DecorationConstants.Attribute.Type attr)
		{
			PriorityControlType res = PriorityControlType.Wall;
			if(((int)attr & 3) == 0)
			{
				res = PriorityControlType.Floor;
				if(type == 5)
					res = PriorityControlType.FloorBack;
				if(ctg != EKLNMHFCAOI.FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj)
					res = PriorityControlType.Floor;
			}
			return res;
		}

		//// RVA: 0x1AD4BF0 Offset: 0x1AD4BF0 VA: 0x1AD4BF0
		private DecorationConstants.Attribute.AreaType MakeAreaType(int attribute)
		{
			DecorationConstants.Attribute.AreaType res = 0;
			if((attribute & 4) != 0)
				res = DecorationConstants.Attribute.AreaType.Inner;
			else if((attribute & 2) != 0)
				res = DecorationConstants.Attribute.AreaType.Inner;

			if((attribute & 8) != 0)
				res |= DecorationConstants.Attribute.AreaType.Outer;
			else if ((attribute & 1) != 0)
				res |= DecorationConstants.Attribute.AreaType.Outer;
			return res;
		}

		//// RVA: 0x1AD5168 Offset: 0x1AD5168 VA: 0x1AD5168
		//private bool IsRug(EKLNMHFCAOI.FKGCBLHOOCL ctg, int type) { }
	}
}
