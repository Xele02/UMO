
using XeApp.Game.Common;

public struct CFHDKAFLNEP
{
	public struct OCNHGDCPJDG
	{
		public int PBPOLELIPJI_Id; // 0x0 SceneId
		public int IFFKEMEOFAE_EvolveId; // 0x4
		public int OEOIHIIIMCK_add; // 0x8
		public int ADKDHKMPMHP_Rate; // 0xC
		public int KHDDPKHPJID; // 0x10
		public int HIPODBKKJFL; // 0x14
		public int ALJGIPAGDJI; // 0x18
		public bool LHFPLDHBAAN; // 0x1C
		public bool KPNDMALAOKC; // 0x1D
		public bool OGHIOHAACIB_IsKira; // 0x1E

		public int IKEJLHJEANO { get {
				int res = 3;
				if (!LHFPLDHBAAN)
					res = 2;
				if (!KPNDMALAOKC)
					res = LHFPLDHBAAN ? 1 : 0;
				return res;
			} } //0x7FC5B8
		public bool CDOCOLOKCJK_HasRate { get { return ADKDHKMPMHP_Rate > 0; } } //0x7FC5D8
		public bool DFIGPDCBAPB_IsInvalid { get { return PBPOLELIPJI_Id < 1; } } //0x7FC5EC

		//// RVA: 0x7FC600 Offset: 0x7FC600 VA: 0x7FC600
		public void JCHLONCMPAJ()
		{
			PBPOLELIPJI_Id = 0;
			IFFKEMEOFAE_EvolveId = 0;
			OEOIHIIIMCK_add = 0;
			ADKDHKMPMHP_Rate = 0;
			OGHIOHAACIB_IsKira = false;
		}

		// RVA: 0x7FC618 Offset: 0x7FC618 VA: 0x7FC618 Slot: 3
		public override string ToString()
		{
			return string.Format("ID={0}, add={1}, rate={2}", PBPOLELIPJI_Id, OEOIHIIIMCK_add, ADKDHKMPMHP_Rate);
		}
	}

	public OCNHGDCPJDG[,] KOGBMDOONFA_Info; // 0x0
	public StatusData CMCKNKKCNDK_Status; // 0x4

	//// RVA: 0x7FC4CC Offset: 0x7FC4CC VA: 0x7FC4CC
	public void OBKGEDCKHHE()
	{
		KOGBMDOONFA_Info = new OCNHGDCPJDG[LCLCCHLDNHJ_Costume.GFIKOEEBIJP, 3];
		for (int i = 0; i < KOGBMDOONFA_Info.GetLength(0); i++)
		{
			for (int j = 0; j < KOGBMDOONFA_Info.GetLength(1); j++)
			{
				KOGBMDOONFA_Info[i, j] = new OCNHGDCPJDG();
			}
		}
		CMCKNKKCNDK_Status = new StatusData();
	}

	//// RVA: 0x7FC4D4 Offset: 0x7FC4D4 VA: 0x7FC4D4
	public void JCHLONCMPAJ()
	{
		for(int i = 0; i < KOGBMDOONFA_Info.GetLength(0); i++)
		{
			for(int j = 0; j < KOGBMDOONFA_Info.GetLength(1); j++)
			{
				KOGBMDOONFA_Info[i, j].JCHLONCMPAJ();
			}
		}
		CMCKNKKCNDK_Status.Clear();
	}

	//// RVA: 0x7FC4DC Offset: 0x7FC4DC VA: 0x7FC4DC
	public bool CDOCOLOKCJK()
	{
		for(int i = 0; i < KOGBMDOONFA_Info.GetLength(0); i++)
		{
			for(int j = 0; j < KOGBMDOONFA_Info.GetLength(1); j++)
			{
				if(KOGBMDOONFA_Info[i, j].ADKDHKMPMHP_Rate > 0)
					return true;
			}
		}
		return false;
	}

	//// RVA: 0x7FC4E4 Offset: 0x7FC4E4 VA: 0x7FC4E4
	public int IKEJLHJEANO(int _CMCKNKKCNDK_Status)
	{
		int res = 0;
		for(int i = 0; i < KOGBMDOONFA_Info.GetLength(1); i++)
		{
			int a = 3;
			if (!KOGBMDOONFA_Info[_CMCKNKKCNDK_Status, i].LHFPLDHBAAN)
				a = 2;
			if (!KOGBMDOONFA_Info[_CMCKNKKCNDK_Status, i].KPNDMALAOKC)
				a = KOGBMDOONFA_Info[_CMCKNKKCNDK_Status, i].LHFPLDHBAAN ? 1 : 0;
			res |= a;
		}
		return res;
	}

	//// RVA: 0x7FC4EC Offset: 0x7FC4EC VA: 0x7FC4EC
	//public bool CDOCOLOKCJK(int _CMCKNKKCNDK_Status) { }
}
