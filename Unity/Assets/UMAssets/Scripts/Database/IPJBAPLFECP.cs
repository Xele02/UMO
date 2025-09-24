
using System.Collections.Generic;

[System.Obsolete("Use IPJBAPLFECP_Anketo", true)]
public class IPJBAPLFECP { }
public class IPJBAPLFECP_Anketo : DIHHCBACKGG_DbSection
{
	public class MDOMAACPHCN
	{
		public int PPFNGGCBJKC_id; // 0x8
		public int PLALNIIBLOF_en; // 0xC
		public int EILKGEADKGH_Order; // 0x10
		public int INDDJNMPONH_type; // 0x14 NotifId
		public int GJLFANGDGCL_Target; // 0x18 // Category
		public string ADCMNODJBGJ_title; // 0x1C
		public string[] BNMCMNPPPCI_ChoiceText; // 0x20
		public int EMNLOGDDOBC; // 0x24
		public int IICECOLFEEL; // 0x28
		public int NNDBJGDFEEM_Min; // 0x2C
		public int DOOGFEGEKLG_max; // 0x30
		public int LLNDMKBBNIJ_ver; // 0x34
	}

	public List<MDOMAACPHCN> CDENCMNHNGA_table { get; private set; } // 0x20 GIODFKFCBMO JDMECLDHNOF ILHOADLEJPB

	//// RVA: 0x1410178 Offset: 0x1410178 VA: 0x1410178
	//public MDOMAACPHCN LBDOLHGDIEB(int _PPFNGGCBJKC_id) { }

	// RVA: 0x1410278 Offset: 0x1410278 VA: 0x1410278
	public IPJBAPLFECP_Anketo()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 2;
		CDENCMNHNGA_table = new List<MDOMAACPHCN>();
	}

	// RVA: 0x141036C Offset: 0x141036C VA: 0x141036C Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		CDENCMNHNGA_table.Clear();
	}

	// RVA: 0x14103E4 Offset: 0x14103E4 VA: 0x14103E4 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
	{
		HHHEIMGFICD parser = HHHEIMGFICD.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		KLNOMBKJDNN(parser);
		return true;
	}

	// RVA: 0x1410794 Offset: 0x1410794 VA: 0x1410794 Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		return true;
	}

	//// RVA: 0x1410410 Offset: 0x1410410 VA: 0x1410410
	private bool KLNOMBKJDNN(HHHEIMGFICD JMHECKKKMLK)
	{
		GGDEOLDOFMH[] array = JMHECKKKMLK.EEMGLFBGGKN;
		for(int i = 0; i < array.Length; i++)
		{
			MDOMAACPHCN data = new MDOMAACPHCN();
			data.PPFNGGCBJKC_id = array[i].PPFNGGCBJKC;
			data.PLALNIIBLOF_en = JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE, array[i].PLALNIIBLOF, 0);
			data.EILKGEADKGH_Order = array[i].EILKGEADKGH;
			data.INDDJNMPONH_type = array[i].GBJFNGCDKPM;
			data.ADCMNODJBGJ_title = DatabaseTextConverter.TranslateAnketoQuestion(i, array[i].ADCMNODJBGJ);
			data.BNMCMNPPPCI_ChoiceText = new string[array[i].BNMCMNPPPCI.Length];
			for(int j = 0; j < data.BNMCMNPPPCI_ChoiceText.Length; j++)
			{
				data.BNMCMNPPPCI_ChoiceText[j] = DatabaseTextConverter.TranslateAnketoChoice(i, j, array[i].BNMCMNPPPCI[j]);
			}
			data.GJLFANGDGCL_Target = array[i].AGNHPHEJKMK;
			data.EMNLOGDDOBC = array[i].EMNLOGDDOBC;
			data.IICECOLFEEL = array[i].IICECOLFEEL;
			data.NNDBJGDFEEM_Min = array[i].NNDBJGDFEEM;
			data.DOOGFEGEKLG_max = array[i].DOOGFEGEKLG;
			data.LLNDMKBBNIJ_ver = array[i].LLNDMKBBNIJ;
			CDENCMNHNGA_table.Add(data);
		}
		return true;
	}

	//// RVA: 0x14107A4 Offset: 0x14107A4 VA: 0x14107A4
	//private bool KLNOMBKJDNN(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label) { }

	// RVA: 0x14107AC Offset: 0x14107AC VA: 0x14107AC Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "IPJBAPLFECP_Anketo.CAOGDCBPBAN");
		return 0;
	}
}
