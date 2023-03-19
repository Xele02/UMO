
using System;
using System.IO;
using UnityEngine;

public class EFLBHNFNFHA
{
	private int CCNCPGJGNDP_SagashoGameId; // 0xC

	public bool CILPABJCBPH_AgreeTos { get; private set; } // 0x8 AKNCKHDGMNK PBGPIOGGCIP DILNDDFKGLK

	//// RVA: 0x1C4C680 Offset: 0x1C4C680 VA: 0x1C4C680
	private string HIOMFHINAAH_GetFileName(int CCNCPGJGNDP)
	{
		return Application.persistentDataPath + "/50/" + string.Format("{0}", CCNCPGJGNDP ^ 0x266e3);
	}

	//// RVA: 0x1C4C754 Offset: 0x1C4C754 VA: 0x1C4C754
	public void PCODDPDFLHK_Refresh()
	{
		CCNCPGJGNDP_SagashoGameId = 0;
		CILPABJCBPH_AgreeTos = false;
		if(int.TryParse(NKGJPJPHLIF.HHCJCDFCLOB.MLKOPOKGHHH_SakashoGameId, out CCNCPGJGNDP_SagashoGameId))
		{
			if(NKGJPJPHLIF.HHCJCDFCLOB.MDAMJIGBOLD_PlayerId != 0)
			{
				if(CIOECGOMILE.HHCJCDFCLOB.LNAHEIEIBOI_Initialized)
				{
					if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.PBEKKMOPENN_AgreeTosVer != 0)
					{
						CILPABJCBPH_AgreeTos = true;
						return;
					}
				}
				string path = HIOMFHINAAH_GetFileName(CCNCPGJGNDP_SagashoGameId);
				if (File.Exists(path))
				{
					byte[] data = File.ReadAllBytes(path);
					if(data != null)
					{
						if (data.Length != 4)
							return;
						CILPABJCBPH_AgreeTos = BitConverter.ToInt32(data, 0) == NKGJPJPHLIF.HHCJCDFCLOB.MDAMJIGBOLD_PlayerId;
					}
				}
			}
		}
	}

	//// RVA: 0x1C4C9FC Offset: 0x1C4C9FC VA: 0x1C4C9FC
	public void HJMKBCFJOOH_SetAgreeTos()
	{
		if (CCNCPGJGNDP_SagashoGameId == 0)
			return;
		int pId = NKGJPJPHLIF.HHCJCDFCLOB.MDAMJIGBOLD_PlayerId;
		string path = HIOMFHINAAH_GetFileName(CCNCPGJGNDP_SagashoGameId);
		byte[] data = BitConverter.GetBytes(pId);
		string pathName = Path.GetDirectoryName(path);
		if (!Directory.Exists(pathName))
			Directory.CreateDirectory(pathName);
		File.WriteAllBytes(path, data);
		if(CIOECGOMILE.HHCJCDFCLOB.LNAHEIEIBOI_Initialized)
		{
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.PBEKKMOPENN_AgreeTosVer = 1;
		}
		CILPABJCBPH_AgreeTos = true;
	}

	//// RVA: 0x1C4CC58 Offset: 0x1C4CC58 VA: 0x1C4CC58
	//public static void KEIPMGOEKFL() { }
}
