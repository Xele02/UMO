
using XeApp.Game.Common;

public struct CFHDKAFLNEP
{
	public struct OCNHGDCPJDG
	{
		public int PBPOLELIPJI_Id; // 0x0
		public int IFFKEMEOFAE; // 0x4
		public int OEOIHIIIMCK_Add; // 0x8
		public int ADKDHKMPMHP_Rate; // 0xC
		public int KHDDPKHPJID; // 0x10
		public int HIPODBKKJFL; // 0x14
		public int ALJGIPAGDJI; // 0x18
		public bool LHFPLDHBAAN; // 0x1C
		public bool KPNDMALAOKC; // 0x1D
		public bool OGHIOHAACIB; // 0x1E

		//public int IKEJLHJEANO { get; } 0x7FC5B8
		//public bool CDOCOLOKCJK { get; } 0x7FC5D8
		//public bool DFIGPDCBAPB { get; } 0x7FC5EC

		//// RVA: 0x7FC600 Offset: 0x7FC600 VA: 0x7FC600
		//public void JCHLONCMPAJ() { }

		// RVA: 0x7FC618 Offset: 0x7FC618 VA: 0x7FC618 Slot: 3
		public override string ToString()
		{
			return string.Format("ID={0}, add={1}, rate={2}", PBPOLELIPJI_Id, OEOIHIIIMCK_Add, ADKDHKMPMHP_Rate);
		}
	}

	public OCNHGDCPJDG[,] KOGBMDOONFA; // 0x0
	public StatusData CMCKNKKCNDK; // 0x4

	//// RVA: 0x7FC4CC Offset: 0x7FC4CC VA: 0x7FC4CC
	public void OBKGEDCKHHE()
	{
		KOGBMDOONFA = new OCNHGDCPJDG[LCLCCHLDNHJ_Costume.GFIKOEEBIJP, 3];
		for (int i = 0; i < KOGBMDOONFA.GetLength(0); i++)
		{
			for (int j = 0; j < KOGBMDOONFA.GetLength(1); j++)
			{
				KOGBMDOONFA[i, j] = new OCNHGDCPJDG();
			}
		}
		CMCKNKKCNDK = new StatusData();
	}

	//// RVA: 0x7FC4D4 Offset: 0x7FC4D4 VA: 0x7FC4D4
	//public void JCHLONCMPAJ() { }

	//// RVA: 0x7FC4DC Offset: 0x7FC4DC VA: 0x7FC4DC
	public bool CDOCOLOKCJK()
	{
		TodoLogger.Log(0, "CDOCOLOKCJK");
		return false;
	}

	//// RVA: 0x7FC4E4 Offset: 0x7FC4E4 VA: 0x7FC4E4
	//public int IKEJLHJEANO(int CMCKNKKCNDK) { }

	//// RVA: 0x7FC4EC Offset: 0x7FC4EC VA: 0x7FC4EC
	//public bool CDOCOLOKCJK(int CMCKNKKCNDK) { }
}
