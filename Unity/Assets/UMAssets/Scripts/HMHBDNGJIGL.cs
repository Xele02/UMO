using XeSys;
using System.Collections.Generic;
using UnityEngine;
using CriWare;
using System;
using System.IO;

public class HMHBDNGJIGL : LBHFILLFAGA
{
	public struct BIIAHJNILEE
	{
		public int PHHAMBAEGPI_Width; // 0x0
		public int MABJPACAAPI_Height; // 0x4

		// RVA: 0x7FD02C Offset: 0x7FD02C VA: 0x7FD02C
		public BIIAHJNILEE(int GHPLINIACBB, int PMBEODGMMBB)
		{
			PHHAMBAEGPI_Width = GHPLINIACBB;
			MABJPACAAPI_Height = PMBEODGMMBB;
		}
	}

	private static byte[] JIEHGOCHDGB = new byte[8] {0x89, 0x50, 0x4e, 0x47, 0x0d, 0x0a, 0x1a, 0x0a}; // 0x0
	private CriFsLoadFileRequest CHPPDDBBEFF; // 0x4C

	// // RVA: 0x15F4DEC Offset: 0x15F4DEC VA: 0x15F4DEC
	public HMHBDNGJIGL(string CJEKGLGBIHF_path, string BOPDLODALFD_withoutPlarformPath, FileLoadedPostProcess OGLMMENAJFL_onSuccess, FileLoadedPostProcess GOIHDOPGPCE_onFail, Dictionary<string, string> JBKMAPLCBMO_arg, int HNKPENAFDKA_argValue, FileLoadInfo LAMFBMFNOFP_fi, bool ALJGNAPELAH)
		: base(CJEKGLGBIHF_path,BOPDLODALFD_withoutPlarformPath,OGLMMENAJFL_onSuccess,GOIHDOPGPCE_onFail,JBKMAPLCBMO_arg,HNKPENAFDKA_argValue,LAMFBMFNOFP_fi)
    {
		return;
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
			IMGIFJHHEED_fro.texture = new Texture2D(size.PHHAMBAEGPI_Width, size.MABJPACAAPI_Height);
			if(size.PHHAMBAEGPI_Width > 1 && size.MABJPACAAPI_Height > 1)
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
		UnityEngine.Object.Destroy(IMGIFJHHEED_fro.texture);
		IMGIFJHHEED_fro.texture = null;
	}

	// // RVA: 0x15F521C Offset: 0x15F521C VA: 0x15F521C
	private static bool KGDPFAPANIH(byte[] GKBDHBJDGAH)
	{
		if(GKBDHBJDGAH.Length > 20)
		{
			for(int i = 0; i < 7; i++)
			{
				if(JIEHGOCHDGB[i] != GKBDHBJDGAH[i])
					return false;
			}
			return true;
		}
		return false;
	}

	// // RVA: 0x15F5A50 Offset: 0x15F5A50 VA: 0x15F5A50
	private static uint LDOAOKFCOEE(byte[] IDLHJIOMJBK, int MMENOGLLOKL)
	{
		byte[] b = new byte[4];
		b[0] = IDLHJIOMJBK[MMENOGLLOKL + 3];
		b[1] = IDLHJIOMJBK[MMENOGLLOKL + 2];
		b[2] = IDLHJIOMJBK[MMENOGLLOKL + 1];
		b[3] = IDLHJIOMJBK[MMENOGLLOKL + 0];
		return BitConverter.ToUInt32(b, 0);
	}

	// // RVA: 0x15F5344 Offset: 0x15F5344 VA: 0x15F5344
	private static BIIAHJNILEE BNPBLFMLECC(byte[] GKBDHBJDGAH)
	{
		if(LDOAOKFCOEE(GKBDHBJDGAH, 8) == 13)
		{
			return new BIIAHJNILEE((int)LDOAOKFCOEE(GKBDHBJDGAH, 16), (int)LDOAOKFCOEE(GKBDHBJDGAH, 20));
		}
		return new BIIAHJNILEE(1, 1);
	}

	// // RVA: 0x15F542C Offset: 0x15F542C VA: 0x15F542C
	private static BIIAHJNILEE BAGLLAKJMPO(byte[] FLOEPENHMCO)
	{
		using(MemoryStream ms = new MemoryStream(FLOEPENHMCO))
		{
			byte[] b = new byte[8];
			while(true)
			{
				int v = ms.Read(b, 0, 2);
				if(v == 2)
				{
					if(b[0] == 0xff)
					{
						if(b[1] == 0xc0 && ms.Read(b, 0, 7) == 7)
						{
							return new BIIAHJNILEE(b[3] << 8 + b[4], b[5] << 8 + b[6]);
						}
						else if(b[1] == 0xd8 && ms.Read(b, 0, 2) == 2)
						{
							long pos = ms.Position;
							int offset = b[0] << 8 + b[1] - 2;
							ms.Position = pos + offset;
						}
						else
							break;
					}
				}
			}
		}
		return new BIIAHJNILEE(0, 0);
	}
}
