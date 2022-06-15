using System.Collections.Generic;

public delegate void IMCBBOAFION();
public delegate void DJBHIFLHJLK();

public class DOKOHKJIDBO
{
	public ANCJLICGOLP IKCAJDOKNOM; // 0x8
	public bool LNAHEIEIBOI; // 0xC
	public string BEIFBNGMFPG = "StringLiteral_9874"; // 0x10
	public Dictionary<int, BEEINMBNKNM_Encryption> KCOIDGJOJHC_EncryptionMap = new Dictionary<int, BEEINMBNKNM_Encryption>(); // 0x14

	public static DOKOHKJIDBO HHCJCDFCLOB { get; private set; } // LGMPACEDIJF, Get NKACBOEHELJ, Set OKPMHKNCNAL

	// RVA: 0x1232884 Offset: 0x1232884 VA: 0x1232884
	public void KIDFJDNOGDG()
	{
		HHCJCDFCLOB = this;
	}

	// RVA: 0x12328E8 Offset: 0x12328E8 VA: 0x12328E8
	// LFIEDDHNLBE : GameStart : true, Initialize : false
	public void DBEPFLFHAFH(bool LFIEDDHNLBE, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		UnityEngine.Debug.LogError("TODO");
		KCOIDGJOJHC_EncryptionMap.Clear();
		LNAHEIEIBOI = false;

		IKCAJDOKNOM = new ANCJLICGOLP();
		IKCAJDOKNOM.KHEKNNFCAOI_Init();

		NKGJPJPHLIF a = NKGJPJPHLIF.HHCJCDFCLOB;

		//PJKLMCGEJMK b = a.IBLPICFDGOF;
		HDPLHCDAFHA_RequestMaster request = new HDPLHCDAFHA_RequestMaster();
		//request = b.IFFNCAFNEAG_AddRequest(request) as HDPLHCDAFHA_RequestMaster;
		// c.AILPHBMCCGP = !LFIEDDHNLBE;
		// MMACCEADALH dgt = (/*SakashoErrorId*/ LJJGBICGLLF) => 
		// {
		//     if(!LFIEDDHNLBE) return true;
		//     return LJJGBICGLLF == 5;
		// };
		// c.NBFDEFGFLPJ = dgt;

		List<string> s = IKCAJDOKNOM.ELJGLMPOINC_GetTypesStr();
		request.DFDLAIGFDAH = s; // ??
		FAPJEIOBPDG dgt2 = IKCAJDOKNOM.IIEMACPEEBJ; // called by HDPLHCDAFHA.DIAMDBHBKBH 0x1743464 > HDPLHCDAFHA.MGFNKDPHFGI
													// 
													// IIEMACPEEBJ(s, IKPIMINCOPI.PFAMKCGJKKL(c.ALHHGGDPGEH()) )
		request.MKGLJLCMGIB = dgt2;
		// CACGCMBKHDI.HDHIKGLMOGF dgt3 = (/*CACGCMBKHDI*/ JIPCHHHLOMM) => {
		//     int val = this.IKCAJDOKNOM.LPJLEHAJADA("m_0", 0);
		//     if(val != 0)
		//     {
		//         val = this.IKCAJDOKNOM.LPJLEHAJADA("s_0", 0);
		//         if(val != 0)
		//         {
		//             this.ANDDAABHGIP();
		//             this.LNAHEIEIBOI = true;
		//             BHFHGFKBOHH.Invoke();
		//             return;
		//         }
		//     }
		//     if(LFIEDDHNLBE != false)
		//     {
		//         this.GNCHKCLDCBP(MOBEEPPKFLG);
		//         return;
		//     }
		//     BHFHGFKBOHH.Invoke();
		// };
		// c.FAKPBHKKNOK(dgt3);
		// CACGCMBKHDI.HDHIKGLMOGF dgt4 = (/*CACGCMBKHDI */JIPCHHHLOMM) => {
		//     if(!JIPCHHHLOMM.DLKLLHPLANH && JIPCHHHLOMM.LBJPGPOJOKP() != 5)
		//     {
		//         MOBEEPPKFLG.Invoke();
		//         return;
		//     }
		//     if(!LFIEDDHNLBE)
		//     {
		//         BHFHGFKBOHH.Invoke();
		//         return;
		//     }
		//     this.GNCHKCLDCBP(MOBEEPPKFLG);
		//     return;
		// };
		// c.AHNDFJKKLDJ = dgt4;

		// Hack
		//request.DIAMDBHBKBH();
	}

	// RVA: 0x1232C34 Offset: 0x1232C34 VA: 0x1232C34
	//private void GNCHKCLDCBP(DJBHIFLHJLK MOBEEPPKFLG) { }

	// RVA: 0x1232CE4 Offset: 0x1232CE4 VA: 0x1232CE4
	//private bool FPMFBJINHPJ(SakashoErrorId KLCMLLLIANB) { }

	// RVA: 0x1232CF4 Offset: 0x1232CF4 VA: 0x1232CF4
	private void ANDDAABHGIP()
	{
		UnityEngine.Debug.LogError("TODO");
		
	}
}