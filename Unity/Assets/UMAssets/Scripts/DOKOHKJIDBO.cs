using System.Collections.Generic;

public delegate void IMCBBOAFION();
public delegate void DJBHIFLHJLK();

public class DOKOHKJIDBO
{
	public ANCJLICGOLP IKCAJDOKNOM; // 0x8
	public bool LNAHEIEIBOI; // 0xC
	public string BEIFBNGMFPG = "StringLiteral_9874"; // 0x10
	public Dictionary<int, BEEINMBNKNM_Encryption> KCOIDGJOJHC_EncryptionMap = new Dictionary<int, BEEINMBNKNM_Encryption>(); // 0x14

	public static DOKOHKJIDBO HHCJCDFCLOB { get; private set; } // 0x0 // LGMPACEDIJF, Get NKACBOEHELJ, Set OKPMHKNCNAL

	// RVA: 0x1232884 Offset: 0x1232884 VA: 0x1232884
	public void KIDFJDNOGDG()
	{
		HHCJCDFCLOB = this;
	}

	// RVA: 0x12328E8 Offset: 0x12328E8 VA: 0x12328E8
	// LFIEDDHNLBE : GameStart : true, Initialize : false
	public void DBEPFLFHAFH(bool LFIEDDHNLBE, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		// // RVA: 0x12330E0 Offset: 0x12330E0 VA: 0x12330E0
		// internal bool APDFIGKALGM(SakashoErrorId LJJGBICGLLF) { }
		// // RVA: 0x1233124 Offset: 0x1233124 VA: 0x1233124
		// internal void OMGNDJPDAMH(CACGCMBKHDI JIPCHHHLOMM) { }
		// // RVA: 0x123329C Offset: 0x123329C VA: 0x123329C
		// internal void CCHHOEDOHKN(CACGCMBKHDI JIPCHHHLOMM) { }

		KCOIDGJOJHC_EncryptionMap.Clear();
		LNAHEIEIBOI = false;

		IKCAJDOKNOM = new ANCJLICGOLP();
		IKCAJDOKNOM.KHEKNNFCAOI_Init();

		HDPLHCDAFHA_RequestMaster request = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.IFFNCAFNEAG_AddRequest<HDPLHCDAFHA_RequestMaster>(new HDPLHCDAFHA_RequestMaster());
		request.AILPHBMCCGP = !LFIEDDHNLBE;
		request.NBFDEFGFLPJ = (SakashoErrorId LJJGBICGLLF) => 
		{ // 0x12330E0
			if(!LFIEDDHNLBE) return true;
			return LJJGBICGLLF == SakashoErrorId.MASTER_DATA_NOT_FOUND;
		};
		
		request.DFDLAIGFDAH = IKCAJDOKNOM.ELJGLMPOINC_GetTypesStr();
		request.MKGLJLCMGIB = IKCAJDOKNOM.IIEMACPEEBJ;
		request.BHFHGFKBOHH = (CACGCMBKHDI_Request JIPCHHHLOMM) => 
		{
			//0x1233124
			if(IKCAJDOKNOM.LPJLEHAJADA("m_0", 0) != 0)
			{
				if(IKCAJDOKNOM.LPJLEHAJADA("s_0", 0) != 0)
				{
					ANDDAABHGIP();
					LNAHEIEIBOI = true;
					BHFHGFKBOHH.Invoke();
					return;
				}
			}
			if(LNAHEIEIBOI)
			{
				GNCHKCLDCBP(MOBEEPPKFLG);
				return;
			}
			BHFHGFKBOHH.Invoke();
		};
		request.MOBEEPPKFLG = (CACGCMBKHDI_Request JIPCHHHLOMM) => 
		{
			//0x123329C
			if(!JIPCHHHLOMM.DLKLLHPLANH && JIPCHHHLOMM.CJMFJOMECKI != SakashoErrorId.MASTER_DATA_NOT_FOUND)
			{
				MOBEEPPKFLG();
				return;
			}
			if(!LFIEDDHNLBE)
			{
				BHFHGFKBOHH();
				return;
			}
			GNCHKCLDCBP(MOBEEPPKFLG);
		};
	}

	// RVA: 0x1232C34 Offset: 0x1232C34 VA: 0x1232C34
	private void GNCHKCLDCBP(DJBHIFLHJLK MOBEEPPKFLG)
	{
		TodoLogger.Log(0, "TODO");
	}

	// RVA: 0x1232CE4 Offset: 0x1232CE4 VA: 0x1232CE4
	//private bool FPMFBJINHPJ(SakashoErrorId KLCMLLLIANB) { }

	// RVA: 0x1232CF4 Offset: 0x1232CF4 VA: 0x1232CF4
	private void ANDDAABHGIP()
	{
		KCOIDGJOJHC_EncryptionMap.Clear();
		for(int i = 1; i < 11; i++)
		{
			if(IKCAJDOKNOM.LPJLEHAJADA("w"+i+"_0", 0) != 0)
			{
				BEEINMBNKNM_Encryption encryptor = new BEEINMBNKNM_Encryption();
				encryptor.DGBPHDMEDNP(IKCAJDOKNOM.LPJLEHAJADA("w"+i+"_0", 0), 
									IKCAJDOKNOM.LPJLEHAJADA("w"+i+"_1", 0),
									IKCAJDOKNOM.LPJLEHAJADA("w"+i+"_2", 0));
				encryptor.KHEKNNFCAOI_Init((uint)IKCAJDOKNOM.LPJLEHAJADA("w"+i+"_3", 0) + 7);
				KCOIDGJOJHC_EncryptionMap.Add(i, encryptor);
			}
		}
	}
}