using UnityEngine;
using XeSys;
using System.Collections.Generic;

public class BDFPCPHIJCN : LBHFILLFAGA
{
	private WWW IEJJKNOEKLM; // 0x4C
	private int LGADCGFMLLD; // 0x50
	private AssetBundleCreateRequest NMNCMNNPNCI; // 0x54

#if UNITY_EDITOR
	bool m_DownloadingFile = false;
#endif
	// RVA: 0xC70568 Offset: 0xC70568 VA: 0xC70568
	public BDFPCPHIJCN(string CJEKGLGBIHF_path, string BOPDLODALFD_withoutPlarformPath, FileLoadedPostProcess OGLMMENAJFL_onSuccess, FileLoadedPostProcess GOIHDOPGPCE_onFail, Dictionary<string, string> JBKMAPLCBMO_arg, int HNKPENAFDKA_argValue, FileLoadInfo LAMFBMFNOFP_fi, bool ALJGNAPELAH)
        : base(CJEKGLGBIHF_path,BOPDLODALFD_withoutPlarformPath,OGLMMENAJFL_onSuccess,GOIHDOPGPCE_onFail,JBKMAPLCBMO_arg,HNKPENAFDKA_argValue,LAMFBMFNOFP_fi)
    {
		return;
    }

	// RVA: 0xC70630 Offset: 0xC70630 VA: 0xC70630 Slot: 4
	public override void BDALHEMDIDC_DoStart()
	{
		if(CriWare.IsStreamingAssetsPath(HHHEFALNMJO_mPath))
		{
			IEJJKNOEKLM = new WWW(Application.streamingAssetsPath + HHHEFALNMJO_mPath);
		}
		else
		{
#if UNITY_EDITOR
			m_DownloadingFile = true;
			FileSystemProxy.TryInstallFile(HHHEFALNMJO_mPath, (string newPath) =>
			{
				IEJJKNOEKLM = new WWW("file://" + newPath);
				m_DownloadingFile = false;
			});
#else
			IEJJKNOEKLM = new WWW("file://"+HHHEFALNMJO_mPath);
#endif
		}
		LGADCGFMLLD = 0;
	}

	// // RVA: 0xC70770 Offset: 0xC70770 VA: 0xC70770 Slot: 5
	public override bool GDEMPLAOGKK_IsDone()
	{
#if UNITY_EDITOR
		if (m_DownloadingFile)
			return false;
#endif
		if(FHHAFJMELMD_alreadyLoading)
		{
			return true;
		}
		return IEJJKNOEKLM.isDone;
	}

	// // RVA: 0xC707B4 Offset: 0xC707B4 VA: 0xC707B4 Slot: 6
	public override string LKPOPGJLPAJ_GetErrorStr()
	{
		if(IEJJKNOEKLM != null)
			return IEJJKNOEKLM.error;
		return null;
	}

	// // RVA: 0xC707CC Offset: 0xC707CC VA: 0xC707CC Slot: 9
	public override bool MLMEOLAEJEL_DoLoadData()
	{
#if UNITY_EDITOR
		if (m_DownloadingFile)
			return false;
#endif
		if(!FHHAFJMELMD_alreadyLoading)
		{
			if(LGADCGFMLLD == 1)
			{
				UnityEngine.Debug.Log("Bundle wait for load in memory");
				if(NMNCMNNPNCI.isDone)
				{
					UnityEngine.Debug.Log("Bundle loaded in memory");
					IMGIFJHHEED_fro.assetBundle = NMNCMNNPNCI.assetBundle;
					NMNCMNNPNCI = null;
				}
				else
				{
					return false;
				}
			}
			else if(LGADCGFMLLD == 0)
			{
				byte[] data = IEJJKNOEKLM.bytes;
				if(!BBGDFKAPJHN(data))
				{
					if(DMKAFCEJFDG_decryptor == null)
					{
						Debug.LogError("decryptor is null");
					}
					DMKAFCEJFDG_decryptor.CLNHGLGOKPF_Decrypt(data);
					if(!BBGDFKAPJHN(data))
					{
						Debug.LogError("decrypt failed");
					}
				}
				UnityEngine.Debug.Log("Bundle decrypted, start load in memory");
				NMNCMNNPNCI = AssetBundle.LoadFromMemoryAsync(data);
				LGADCGFMLLD = 1;
				return false;
			}
		}
		return base.MLMEOLAEJEL_DoLoadData();
	}

	// // RVA: 0xC70AB0 Offset: 0xC70AB0 VA: 0xC70AB0 Slot: 11
	public override void PAHHAMPDBFP()
	{
		if(FHHAFJMELMD_alreadyLoading)
			return;
		if(IEJJKNOEKLM != null)
		{
			IEJJKNOEKLM.Dispose();
			IEJJKNOEKLM = null;
		}
		base.PAHHAMPDBFP();
	}

	// // RVA: 0xC70AF8 Offset: 0xC70AF8 VA: 0xC70AF8 Slot: 12
	public override void DKNGPHJKGAP()
	{
		if(FHHAFJMELMD_alreadyLoading)
			return;
		if(IEJJKNOEKLM != null)
		{
			IEJJKNOEKLM.Dispose();
			IEJJKNOEKLM = null;
		}
		base.DKNGPHJKGAP();
	}

	// // RVA: 0xC70B40 Offset: 0xC70B40 VA: 0xC70B40 Slot: 13
	public override void JNDNHPEIMEI()
	{
		if(IMGIFJHHEED_fro.assetBundle == null)
		{
			return;
		}
		IMGIFJHHEED_fro.assetBundle.Unload(false);
		IMGIFJHHEED_fro.assetBundle = null;
	}
}
