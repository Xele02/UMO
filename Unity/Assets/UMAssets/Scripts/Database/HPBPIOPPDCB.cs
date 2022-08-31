using System.Collections.Generic;
using XeSys;

public class HPBPIOPPDCB { }
public class HPBPIOPPDCB_Diva : DIHHCBACKGG_DbSection
{
	public static bool DINNDBNPNFK; // 0x0
	public const int NLPCOAKLBAN = 0;
	public const int AGBLDFIFLBJ = 10;
	public const int DNLFNEFLNED = 200;
	public int AGNCAAFGLBE; // 0x20
	public List<BJPLLEBHAGO> CDENCMNHNGA = new List<BJPLLEBHAGO>(10); // 0x24

	// // RVA: 0x160846C Offset: 0x160846C VA: 0x160846C
	public bool BEEGJHCDHJB_IsDivaAvaiable(int AHHJLDLAPAN)
	{
		if(AHHJLDLAPAN > 0 && AHHJLDLAPAN <= CDENCMNHNGA.Count)
		{
			return CDENCMNHNGA[AHHJLDLAPAN - 1].PPEGAKEIEGM == 2;
		}
		return false;
	}

	// // RVA: 0x1608560 Offset: 0x1608560 VA: 0x1608560
	public BJPLLEBHAGO GCINIJEMHFK(int AHHJLDLAPAN)
    {
        if(AHHJLDLAPAN != 0)
		{
			return CDENCMNHNGA[AHHJLDLAPAN - 1];
		}
		return null;
    }

	// // RVA: 0x16085F0 Offset: 0x16085F0 VA: 0x16085F0
	public HPBPIOPPDCB_Diva()
    {
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 19;
    }

	// // RVA: 0x16086E8 Offset: 0x16086E8 VA: 0x16086E8 Slot: 8
	protected override void KMBPACJNEOF()
    {
		CDENCMNHNGA.Clear();
		for(int i = 0; i < 10; i++)
		{
			BJPLLEBHAGO data = new BJPLLEBHAGO();
			data.AHHJLDLAPAN = (sbyte)i;
			for(int j = 0; j < 200; j++)
			{
				EPPOHFLMDBC data2 = new EPPOHFLMDBC();
				data2.DOMFHDPMCCO(j, 0x7517748f, 0, 0, 0, 0, 0, 0);
				data.CMCKNKKCNDK.Add(data2);
			}
			CDENCMNHNGA.Add(data);
		}
    }

	// // RVA: 0x16088BC Offset: 0x16088BC VA: 0x16088BC Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
    {
		long time = Utility.GetCurrentUnixTime();
		MHKHMCAPDKK reader = MHKHMCAPDKK.HEGEKFMJNCC(DBBGALAPFGC);
		MALFJMBMCLG[] array = reader.INPCGKFIMIG;
		if (array.Length < 11)
		{
			for(int i = 0; i != array.Length; i++)
			{
				long val2 = time * 0x96a + 2;
				BJPLLEBHAGO data = CDENCMNHNGA[i];
				data.AHHJLDLAPAN = (sbyte)array[i].PPFNGGCBJKC;
				data.AIHCEGFANAM = (sbyte)array[i].JPFMJHLCMJL;
				data.IDDHKOEFJFB = (sbyte)array[i].JIBNPJCIALH;
				data.FPMGHDKACOF = (sbyte)array[i].OKADDOIJGNB;
				data.PPEGAKEIEGM = (sbyte)JKAECBCNHAN(array[i].IJEKNCDIIAE, (int)array[i].PLALNIIBLOF, 0);
				data.DOAJJALOKLI = (sbyte)array[i].KLCMKLPIDDJ;
				data.PKNONBBKCCP = (sbyte)array[i].BAOFEFFADPD;
				data.LIOGKHIGJKN = (ushort)array[i].LIOGKHIGJKN;
				data.CMBCBNEODPD = (ushort)array[i].CMBCBNEODPD;

				EPPOHFLMDBC data2 = new EPPOHFLMDBC();
				data2.DOMFHDPMCCO(0, (int)val2, (short)array[i].DFEDIAPLFHN.BCCOMAODPJI, (short)array[i].DFEDIAPLFHN.LJELGFAFGAB, (short)array[i].DFEDIAPLFHN.KNEDJFLCCLN,
						(short)array[i].DFEDIAPLFHN.MBAMIOJNGBD, (short)array[i].DFEDIAPLFHN.ADLGKMBIPCA, (short)array[i].DFEDIAPLFHN.PIPCIMIALOO);
				data.CMCKNKKCNDK[0].ODDIHGPONFL(data2);
				val2 = val2 * 0xb + 3;
				AGNCAAFGLBE = array[i].DFEDIAPLFHN.OEOIHIIIMCK.Length / 2;
				for(int k = 0, j = 1; j <= AGNCAAFGLBE; j++, k+=2)
				{
					data2.ANAJIAENLNB = j;
					data2.ANIJHEBLMGB((int)array[i].DFEDIAPLFHN.OEOIHIIIMCK[k], (short)array[i].DFEDIAPLFHN.OEOIHIIIMCK[k+1]);
					data.CMCKNKKCNDK[j].FBGGEFFJJHB = (int)val2;
					data.CMCKNKKCNDK[j].ODDIHGPONFL(data2);
					val2 = val2 * 0xb;
				}
			}
			return true;
		}
		HDIDJNCGICK = "\"diva\" table overflow";
		return false;
    }

	// // RVA: 0x16093A0 Offset: 0x16093A0 VA: 0x16093A0 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		return true;
	}

	// // RVA: 0x16093A8 Offset: 0x16093A8 VA: 0x16093A8 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(0, "CAOGDCBPBAN");
		return 0;
	}
}
