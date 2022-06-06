using UnityEngine;
using System;
using System.Collections.Generic;

namespace XeSys.File
{
	internal class CriFileRequestManager : MonoBehaviour
	{
		public enum IFDILJEGCLD
		{
			NFFGMBBNNPH = 0,
			IADCGKMLFFE = 1,
			MKEJFPFGLCF = 2,
			JKONMHNBGLL = 3,
		}

		private int EAABKFGHKBG = 3; // 0x14
		private float ICDEFIIADDO = 80.0f; // 0x18
		private int EOBEHIILNPF = 64; // 0x1C
		private float KCEEKGLBNOI = 0.05f; // 0x20
		[SerializeField]
		private bool emulation; // 0x24
		[SerializeField]
		private float emulationWait = 1.0f; // 0x28
		private List<LBHFILLFAGA> CEKHMLAEKIK; // 0x2C
		private List<LBHFILLFAGA> MEDMPJHJNBJ; // 0x30
		private bool LEDAPFHKIMD; // 0x34
		private bool OALKCHOADBI; // 0x35
		private int LMKJAHNKELA; // 0x38
		[SerializeField]
		private int loadCountLimit = 1; // 0x3C
		private const byte JDPJHJKJOEN = 0;
		private const byte OEMHNAGJKIA = 1;
		private const byte GPBEJLIAAHM = 2;
		private const byte JELCBLNFEMN = 3;
		private const byte HHLHLDFAHLM = 4;
		private const byte HBPDDBDJGBI = 5;
		private const byte OOFGFPEEPOC = 6;

		public static CriFileRequestManager HHCJCDFCLOB { get; set; } // 0x0 LGMPACEDIJF NKACBOEHELJ OKPMHKNCNAL
		public Func<bool> GOEAHKDGBBH { get; set; } // 0xC MFPBFPMEGLH CIHOBBNBGMD NPGIEMFFFIO
		public Func<string, bool> JPNMBNEHBOC { get; set; } // 0x10 PLEOGKLBFOE PNNNJDJIOBD CODNMFLLEPN
		public static Action PKEPDCMJKGF { get; set; } // 0x4 LLHEBHLOMGK LJCCPPIBKCM ACBCAFEDELI
		public static Action<LBHFILLFAGA> HMACMKFKHFG { get; set; } // 0x8 AAIDMLJLOLL HDILEKDDLBP DJCPECPNLNN
		public static Action<LBHFILLFAGA> CCGJIEMDFAI { get; set; } // 0xC GMMAAGMCBDH JHDCDJOKGMM FPOIIPBFKON
		public IFDILJEGCLD NFABHMNAODN { get; set; } // 0x40 JGIJJAMABPM IMJKHFFDNEG KDJNMIHJEIL

		// // RVA: 0x2038238 Offset: 0x2038238 VA: 0x2038238
		private void Awake()
		{
			DontDestroyOnLoad(this);
			HHCJCDFCLOB = this;
			NFABHMNAODN = IFDILJEGCLD.NFFGMBBNNPH;
			LEDAPFHKIMD = false;
			CEKHMLAEKIK = new List<LBHFILLFAGA>(EOBEHIILNPF);
			MEDMPJHJNBJ = new List<LBHFILLFAGA>(EOBEHIILNPF);
			LMKJAHNKELA = 0;
			GOEAHKDGBBH = null;
		}

		// // RVA: 0x2038380 Offset: 0x2038380 VA: 0x2038380
		public static GameObject HEGEKFMJNCC(CriFileRequestManager JKAMBKCKIPP)
		{
			if(HHCJCDFCLOB == null)
			{
				if(JKAMBKCKIPP != null)
				{
					GameObject go = GameObject.Find("CriFileRequestManager");
					if(go == null)
					{
						CriFileRequestManager crm = Instantiate(JKAMBKCKIPP);
						go = crm.gameObject;
						go.name = "CriFileRequestManager";
					}
					return go;
				}	
			}
			return null;
		}

		// // RVA: 0x20385A8 Offset: 0x20385A8 VA: 0x20385A8
		private void Update()
		{
		}

		// // RVA: 0x20385AC Offset: 0x20385AC VA: 0x20385AC
		public void ELFMKCOKNHK(LBHFILLFAGA COJNCNGHIJC)
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0x2038664 Offset: 0x2038664 VA: 0x2038664
		// public bool MGLNBBJOCFO() { }

		// // RVA: 0x2038674 Offset: 0x2038674 VA: 0x2038674
		// public bool KKNPHHFBKOE() { }

		// // RVA: 0x2038688 Offset: 0x2038688 VA: 0x2038688
		// public void IPGGCCPIMMI() { }

		// // RVA: 0x2038694 Offset: 0x2038694 VA: 0x2038694
		// public void LFBFKKKCMNM() { }

		// // RVA: 0x2038954 Offset: 0x2038954 VA: 0x2038954
		// private bool BNOGEKDDEIB(string CJEKGLGBIHF) { }

		// // RVA: 0x203895C Offset: 0x203895C VA: 0x203895C
		// private bool LDMEFPHAABD(string CJEKGLGBIHF) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6937B0 Offset: 0x6937B0 VA: 0x6937B0
		// // RVA: 0x20388C8 Offset: 0x20388C8 VA: 0x20388C8
		// private IEnumerator IALIHGPHLPH() { }

		// [IteratorStateMachineAttribute] // RVA: 0x693828 Offset: 0x693828 VA: 0x693828
		// // RVA: 0x2038984 Offset: 0x2038984 VA: 0x2038984
		// private IEnumerator NBCKHIAINIM() { }

		// // RVA: 0x2038A30 Offset: 0x2038A30 VA: 0x2038A30
		// private bool EKAEAKACODC(LBHFILLFAGA COJNCNGHIJC) { }

		// // RVA: 0x2038A70 Offset: 0x2038A70 VA: 0x2038A70
		// private bool GCPOIANJEOC(LBHFILLFAGA COJNCNGHIJC) { }

		// // RVA: 0x2038A9C Offset: 0x2038A9C VA: 0x2038A9C
		// private bool INODGGFPKOE(LBHFILLFAGA COJNCNGHIJC) { }
	}
}
