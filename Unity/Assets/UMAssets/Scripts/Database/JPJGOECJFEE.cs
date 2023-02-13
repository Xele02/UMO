
using System.Collections.Generic;

[System.Obsolete("Use JPJGOECJFEE_EventGoDivaRanking", true)]
public class JPJGOECJFEE { }
public class JPJGOECJFEE_EventGoDivaRanking : DIHHCBACKGG_DbSection
{
	public class IKHDAADBIAL
	{
		public int OBGBAOLONDD; // 0x8
		public string OPFGFINHFCE; // 0xC
		public string HEDAGCNPHGD; // 0x10
		public string OCGFKMHNEOF; // 0x14
		public long BONDDBOFBND; // 0x18
		public long HPNOGLIFJOP; // 0x20
		public long LNFKGHNHJKE; // 0x28
		public long JGMDAOACOJF; // 0x30
		public long IDDBFFBPNGI; // 0x38
		public long KNLGKBBIBOH; // 0x40
		public List<string> MPCAGEPEJJJ = new List<string>(); // 0x48
		public List<int> JHPCPNJJHLI = new List<int>(); // 0x4C

		//// RVA: 0x1BA7B7C Offset: 0x1BA7B7C VA: 0x1BA7B7C
		public void LHPDDGIJKNB()
		{
			BONDDBOFBND = 0;
			HPNOGLIFJOP = 0;
			JGMDAOACOJF = 0;
			IDDBFFBPNGI = 0;
			OBGBAOLONDD = 0;
			OPFGFINHFCE = "";
			HEDAGCNPHGD = "";
			OCGFKMHNEOF = "";
			MPCAGEPEJJJ.Clear();
			JHPCPNJJHLI.Clear();
		}

		//// RVA: 0x1BA84F4 Offset: 0x1BA84F4 VA: 0x1BA84F4
		//public uint CAOGDCBPBAN() { }
	}

	public IKHDAADBIAL NGHKJOEDLIP = new IKHDAADBIAL(); // 0x20
	private List<NNJFKLBPBNK_SecureString> IFBBNEGGCIH; // 0x2C
	private List<CEBFFLDKAEC_SecureInt> JNJAOACIGOC; // 0x30

	public Dictionary<string, NNJFKLBPBNK_SecureString> FJOEBCMGDMI { get; private set; } // 0x24 IHKPIFIBECO GAMGELHIHHI DDDEJIJGGBJ
	public Dictionary<string, CEBFFLDKAEC_SecureInt> OHJFBLFELNK { get; private set; } // 0x28 KLDCHOIPJGB AEMNOGNEBOJ DGKDBOAMNBB

	//// RVA: 0x1BA762C Offset: 0x1BA762C VA: 0x1BA762C
	//public string EFEGBHACJAL(string LJNAKDMILMC, string KKMJBMKHGNH) { }

	//// RVA: 0x1BA7710 Offset: 0x1BA7710 VA: 0x1BA7710
	//public int LPJLEHAJADA(string LJNAKDMILMC, int KKMJBMKHGNH) { }

	// RVA: 0x1BA77F4 Offset: 0x1BA77F4 VA: 0x1BA77F4
	public JPJGOECJFEE_EventGoDivaRanking()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		OHJFBLFELNK = new Dictionary<string, CEBFFLDKAEC_SecureInt>();
		JNJAOACIGOC = new List<CEBFFLDKAEC_SecureInt>();
		FJOEBCMGDMI = new Dictionary<string, NNJFKLBPBNK_SecureString>();
		IFBBNEGGCIH = new List<NNJFKLBPBNK_SecureString>();
		LMHMIIKCGPE = 33;
	}

	// RVA: 0x1BA7A64 Offset: 0x1BA7A64 VA: 0x1BA7A64 Slot: 8
	protected override void KMBPACJNEOF()
	{
		NGHKJOEDLIP.LHPDDGIJKNB();
		FJOEBCMGDMI.Clear();
		OHJFBLFELNK.Clear();
		JNJAOACIGOC.Clear();
		IFBBNEGGCIH.Clear();
	}

	// RVA: 0x1BA7C58 Offset: 0x1BA7C58 VA: 0x1BA7C58 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		CEGLELHPKBO parser = CEGLELHPKBO.HEGEKFMJNCC(DBBGALAPFGC);
		DGKKMKLCEDF(parser);
		{
			KAGMCEBLHAI[] array = parser.BHGDNGHDDAC;
			for(int i = 0; i < array.Length; i++)
			{
				CEBFFLDKAEC_SecureInt data = new CEBFFLDKAEC_SecureInt();
				data.DNJEJEANJGL_Value = array[i].JBGEEPFKIGG;
				OHJFBLFELNK.Add(array[i].LJNAKDMILMC, data);
				JNJAOACIGOC.Add(data);
			}
		}
		{
			KBHIGPCGLKH[] array = parser.MHGMDJNOLMI;
			for(int i = 0; i < array.Length; i++)
			{
				NNJFKLBPBNK_SecureString data = new NNJFKLBPBNK_SecureString();
				data.DNJEJEANJGL_Value = array[i].JBGEEPFKIGG;
				FJOEBCMGDMI.Add(array[i].LJNAKDMILMC, data);
				IFBBNEGGCIH.Add(data);
			}
		}
		return true;
	}

	// RVA: 0x1BA84BC Offset: 0x1BA84BC VA: 0x1BA84BC Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		return true;
	}

	//// RVA: 0x1BA7F78 Offset: 0x1BA7F78 VA: 0x1BA7F78
	private bool DGKKMKLCEDF(CEGLELHPKBO JMHECKKKMLK)
	{
		HMNCNMGCIMM pData = JMHECKKKMLK.HMBHNLCFDIH;
		NGHKJOEDLIP.OBGBAOLONDD = (int)pData.OBGBAOLONDD;
		NGHKJOEDLIP.OPFGFINHFCE = pData.OPFGFINHFCE;
		NGHKJOEDLIP.HEDAGCNPHGD = pData.HEDAGCNPHGD;
		NGHKJOEDLIP.OCGFKMHNEOF = pData.OCGFKMHNEOF;
		NGHKJOEDLIP.BONDDBOFBND = pData.BONDDBOFBND;
		NGHKJOEDLIP.HPNOGLIFJOP = pData.HPNOGLIFJOP;
		NGHKJOEDLIP.LNFKGHNHJKE = pData.LNFKGHNHJKE;
		NGHKJOEDLIP.JGMDAOACOJF = pData.JGMDAOACOJF;
		NGHKJOEDLIP.IDDBFFBPNGI = pData.IDDBFFBPNGI;
		NGHKJOEDLIP.KNLGKBBIBOH = pData.KNLGKBBIBOH;
		NGHKJOEDLIP.MPCAGEPEJJJ.Clear();
		for(int i = 0; i < pData.MPCAGEPEJJJ.Length; i++)
		{
			NGHKJOEDLIP.MPCAGEPEJJJ.Add(pData.MPCAGEPEJJJ[i]);
		}
		for(int i = 0; i < pData.JHPCPNJJHLI.Length; i++)
		{
			if(pData.JHPCPNJJHLI[i] < 1001)
			{
				NGHKJOEDLIP.JHPCPNJJHLI.Add(pData.JHPCPNJJHLI[i]);
			}
		}
		return true;
	}

	// RVA: 0x1BA84C4 Offset: 0x1BA84C4 VA: 0x1BA84C4 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(TodoLogger.DbIntegrityCheck, "JPJGOECJFEE_EventGoDivaRanking.CAOGDCBPBAN");
		return 0;
	}
}
