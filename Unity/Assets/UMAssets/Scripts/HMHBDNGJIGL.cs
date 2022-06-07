using XeSys;
using System.Collections.Generic;

public class HMHBDNGJIGL : LBHFILLFAGA
{
	public struct BIIAHJNILEE
	{
		// Fields
		public int PHHAMBAEGPI; // 0x0
		public int MABJPACAAPI; // 0x4

		// RVA: 0x7FD02C Offset: 0x7FD02C VA: 0x7FD02C
		public BIIAHJNILEE(int GHPLINIACBB, int PMBEODGMMBB)
		{
			PHHAMBAEGPI = GHPLINIACBB;
			MABJPACAAPI = PMBEODGMMBB;
		}
	}

	private static byte[] JIEHGOCHDGB; // 0x0
	private CriFsLoadFileRequest CHPPDDBBEFF; // 0x4C

	// // RVA: 0x15F4D68 Offset: 0x15F4D68 VA: 0x15F4D68
	public HMHBDNGJIGL()
    {
    }

	// // RVA: 0x15F4DEC Offset: 0x15F4DEC VA: 0x15F4DEC
	public HMHBDNGJIGL(string CJEKGLGBIHF_path, string BOPDLODALFD_withoutPlarformPath, FileLoadedPostProcess OGLMMENAJFL_onSuccess, FileLoadedPostProcess GOIHDOPGPCE_onFail, Dictionary<string, string> JBKMAPLCBMO_arg, int HNKPENAFDKA_argValue, FileLoadInfo LAMFBMFNOFP_fi, bool ALJGNAPELAH)
		: base(CJEKGLGBIHF_path,BOPDLODALFD_withoutPlarformPath,OGLMMENAJFL_onSuccess,GOIHDOPGPCE_onFail,JBKMAPLCBMO_arg,HNKPENAFDKA_argValue,LAMFBMFNOFP_fi)
    {
    }

	// // RVA: 0x15F4EB4 Offset: 0x15F4EB4 VA: 0x15F4EB4 Slot: 4
	public override void BDALHEMDIDC_DoStart()
	{
		if(HHHEFALNMJO_mPath.Contains("bind:"))
		{
			CHPPDDBBEFF = CriFsUtility.LoadFile(COIBJNACMFK, HHHEFALNMJO_mPath.Substring(5), 0x100000);
		}
		else
		{
			CHPPDDBBEFF = CriFsUtility.LoadFile(HHHEFALNMJO_mPath, 0x100000);
		}
	}

	// // RVA: 0x15F4F98 Offset: 0x15F4F98 VA: 0x15F4F98 Slot: 5
	public override bool GDEMPLAOGKK_IsDone()
	{
		if(FHHAFJMELMD_alreadyLoading)
			return true;
		return CHPPDDBBEFF.isDone;
	}

	// // RVA: 0x15F4FDC Offset: 0x15F4FDC VA: 0x15F4FDC Slot: 6
	public override string LKPOPGJLPAJ_GetErrorStr()
	{
		if(CHPPDDBBEFF != null)
			return CHPPDDBBEFF.error;
		return null;
	}

	// // RVA: 0x15F4FF4 Offset: 0x15F4FF4 VA: 0x15F4FF4 Slot: 9
	public override bool MLMEOLAEJEL_DoLoadData()
	{
		if(!FHHAFJMELMD_alreadyLoading)
		{
			BIIAHJNILEE size;
			if(KGDPFAPANIH(CHPPDDBBEFF.bytes))
			{
				size = BNPBLFMLECC(CHPPDDBBEFF.bytes);
			}
			else
			{
				size = BAGLLAKJMPO(CHPPDDBBEFF.bytes);
			}
			IMGIFJHHEED_fro.texture = new Texture2D(size.PHHAMBAEGPI, size.MABJPACAAPI);
			if(size.PHHAMBAEGPI > 1 && size.MABJPACAAPI > 1)
			{
				ImageConversion.LoadImage(IMGIFJHHEED_fro.texture, CHPPDDBBEFF.bytes);
			}
		}
		return base.MLMEOLAEJEL_DoLoadData();
	}

	// // RVA: 0x15F58B0 Offset: 0x15F58B0 VA: 0x15F58B0 Slot: 11
	public override void PAHHAMPDBFP()
	{
		if(FHHAFJMELMD_alreadyLoading)
			return;
		if(CHPPDDBBEFF != null)
			CHPPDDBBEFF.Stop();
		base.PAHHAMPDBFP();
	}

	// // RVA: 0x15F58F8 Offset: 0x15F58F8 VA: 0x15F58F8 Slot: 13
	public override void JNDNHPEIMEI()
	{
		if(IMGIFJHHEED_fro.texture == null)
			return;
		Destroy(IMGIFJHHEED_fro.texture);
		IMGIFJHHEED_fro.texture = null;
	}

	// // RVA: 0x15F521C Offset: 0x15F521C VA: 0x15F521C
	private static bool KGDPFAPANIH(byte[] GKBDHBJDGAH)
	{
		if(GKBDHBJDGAH.Length > 20)
		{
			for(int i = 0; i < 7; i++)
			{
				if(JIEHGOCHDGB[i] != GKBDHBJDGAH[i]
					return false;
			}
		}
		return true;
	}

	// // RVA: 0x15F5A50 Offset: 0x15F5A50 VA: 0x15F5A50
	// private static uint LDOAOKFCOEE(byte[] IDLHJIOMJBK, int MMENOGLLOKL) { }

	// // RVA: 0x15F5344 Offset: 0x15F5344 VA: 0x15F5344
	private static HMHBDNGJIGL.BIIAHJNILEE BNPBLFMLECC(byte[] GKBDHBJDGAH)
	{
		Debug.LogError("TODO");
	}

	// // RVA: 0x15F542C Offset: 0x15F542C VA: 0x15F542C
	private static HMHBDNGJIGL.BIIAHJNILEE BAGLLAKJMPO(byte[] FLOEPENHMCO)
	{
		Debug.LogError("TODO");
	}

	// // RVA: 0x15F5C3C Offset: 0x15F5C3C VA: 0x15F5C3C
	static HMHBDNGJIGL()
    {
        UnityEngine.Debug.LogWarning("TODO static HMHBDNGJIGL");
        //Field$<PrivateImplementationDetails>.4CAECE539B039B16E16206EA2478F8C5FFB2CA05
    }
}
