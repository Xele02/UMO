
using System;
using System.IO;
using UnityEngine;

public class EFLBHNFNFHA
{
	private int CCNCPGJGNDP_SagashoGameId; // 0xC

	public bool CILPABJCBPH_AgreeTos { get; private set; } // 0x8 AKNCKHDGMNK_bgs PBGPIOGGCIP_bgs DILNDDFKGLK_bgs

	//// RVA: 0x1C4C680 Offset: 0x1C4C680 VA: 0x1C4C680
	private string HIOMFHINAAH_GetFileName(int _CCNCPGJGNDP_SagashoGameId)
	{
		return Application.persistentDataPath + "/50/" + string.Format("{0}", _CCNCPGJGNDP_SagashoGameId ^ 0x266e3);
	}

	//// RVA: 0x1C4C754 Offset: 0x1C4C754 VA: 0x1C4C754
	public void PCODDPDFLHK_Load()
	{
		CCNCPGJGNDP_SagashoGameId = 0;
		CILPABJCBPH_AgreeTos = false;
		if(int.TryParse(NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.MLKOPOKGHHH_SakashoGameId, out CCNCPGJGNDP_SagashoGameId))
		{
			if(NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.MDAMJIGBOLD_PlayerId != 0)
			{
				if(CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.LNAHEIEIBOI_Initialized)
				{
					if (CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.JHFIPCIHJNL_Base.PBEKKMOPENN_agree_tos_ver != 0)
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
						CILPABJCBPH_AgreeTos = BitConverter.ToInt32(data, 0) == NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.MDAMJIGBOLD_PlayerId;
					}
				}
			}
		}
	}

	//// RVA: 0x1C4C9FC Offset: 0x1C4C9FC VA: 0x1C4C9FC
	public void HJMKBCFJOOH_Save()
	{
		if (CCNCPGJGNDP_SagashoGameId == 0)
			return;
		int pId = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.MDAMJIGBOLD_PlayerId;
		string path = HIOMFHINAAH_GetFileName(CCNCPGJGNDP_SagashoGameId);
		byte[] data = BitConverter.GetBytes(pId);
		string pathName = Path.GetDirectoryName(path);
		if (!Directory.Exists(pathName))
			Directory.CreateDirectory(pathName);
		File.WriteAllBytes(path, data);
		if(CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.LNAHEIEIBOI_Initialized)
		{
			CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.JHFIPCIHJNL_Base.PBEKKMOPENN_agree_tos_ver = 1;
		}
		CILPABJCBPH_AgreeTos = true;
	}

	//// RVA: 0x1C4CC58 Offset: 0x1C4CC58 VA: 0x1C4CC58
	public static void KEIPMGOEKFL_DeleteCache()
	{
		string path = Application.persistentDataPath + "/50";
		if (Directory.Exists(path))
			Directory.Delete(path, true);
	}
}
