using XeSys;
using UnityEngine;
using System.Collections.Generic;
using Cryptor;

public class IPGPAGNBBIK : LBHFILLFAGA
{
	private DsfdLoader.ILoadRequest COJNCNGHIJC; // 0x4C
#if UNITY_EDITOR || UNITY_STANDALONE
	bool isInstalling = false;
#endif

	// RVA: 0x140F5A4 Offset: 0x140F5A4 VA: 0x140F5A4
	public IPGPAGNBBIK(string CJEKGLGBIHF_path, string BOPDLODALFD_withoutPlarformPath, FileLoadedPostProcess OGLMMENAJFL_onSuccess, FileLoadedPostProcess GOIHDOPGPCE_onFail, Dictionary<string, string> JBKMAPLCBMO_arg, int HNKPENAFDKA_argValue, FileLoadInfo LAMFBMFNOFP_fi, bool ALJGNAPELAH)
		: base(CJEKGLGBIHF_path,BOPDLODALFD_withoutPlarformPath,OGLMMENAJFL_onSuccess,GOIHDOPGPCE_onFail,JBKMAPLCBMO_arg,HNKPENAFDKA_argValue,LAMFBMFNOFP_fi)
    {
		return;
    }

	// // RVA: 0x140F66C Offset: 0x140F66C VA: 0x140F66C Slot: 4
	public override void BDALHEMDIDC_DoStart()
	{
#if UNITY_EDITOR || UNITY_STANDALONE
		isInstalling = true;
		FileSystemProxy.TryInstallFile(HHHEFALNMJO_mPath, (string newPath) =>
		{
			isInstalling = false;
			HHHEFALNMJO_mPath = newPath;
#endif
			COJNCNGHIJC = Cryptor.DsfdLoader.LoadFile(HHHEFALNMJO_mPath);
#if UNITY_EDITOR || UNITY_STANDALONE
		});
#endif
	}

	// // RVA: 0x140F6F8 Offset: 0x140F6F8 VA: 0x140F6F8 Slot: 5
	public override bool GDEMPLAOGKK_IsDone()
	{
#if UNITY_EDITOR || UNITY_STANDALONE
		if (isInstalling)
			return false;
#endif
		if(FHHAFJMELMD_alreadyLoading)
			return true;
		return COJNCNGHIJC.IsDone;
	}

	// // RVA: 0x140F7EC Offset: 0x140F7EC VA: 0x140F7EC Slot: 6
	public override string LKPOPGJLPAJ_GetErrorStr()
	{
#if UNITY_EDITOR || UNITY_STANDALONE
		if (isInstalling)
			return null;
#endif
		if (!COJNCNGHIJC.IsSuccess)
		{
			return "decrypt error";
		}
		return null;
	}

	// // RVA: 0x140F8E0 Offset: 0x140F8E0 VA: 0x140F8E0 Slot: 9
	public override bool MLMEOLAEJEL_DoLoadData()
	{
		if(!FHHAFJMELMD_alreadyLoading)
		{
			byte[] data = COJNCNGHIJC.Result;
			if(BOBCNJIPPJN.AGJJGJCIMKI(data))
			{
				data = BOBCNJIPPJN.JCBCBNFPJDH(data);
			}
			IMGIFJHHEED_fro.bytes = data;
		}
		return base.MLMEOLAEJEL_DoLoadData();
	}

	// // RVA: 0x140FA2C Offset: 0x140FA2C VA: 0x140FA2C Slot: 11
	public override void PAHHAMPDBFP()
	{
#if UNITY_EDITOR || UNITY_STANDALONE
		if (isInstalling)
			return;
#endif
		if (FHHAFJMELMD_alreadyLoading)
			return;
		COJNCNGHIJC = null;
		base.PAHHAMPDBFP();
	}

	// // RVA: 0x140FA60 Offset: 0x140FA60 VA: 0x140FA60 Slot: 13
	public override void JNDNHPEIMEI()
	{
		IMGIFJHHEED_fro.bytes = null;
	}
}
