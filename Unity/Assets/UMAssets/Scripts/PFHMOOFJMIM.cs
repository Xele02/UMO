using UnityEngine;
using XeSys;
using System.Collections.Generic;
using CriWare;

public class PFHMOOFJMIM : LBHFILLFAGA
{
    private WWW IEJJKNOEKLM; // 0x4C

    // RVA: 0x16C23AC Offset: 0x16C23AC VA: 0x16C23AC
    public PFHMOOFJMIM()
    {
		return;
    }

    // RVA: 0x16C2430 Offset: 0x16C2430 VA: 0x16C2430
    public PFHMOOFJMIM(string CJEKGLGBIHF_path, string BOPDLODALFD_withoutPlarformPath, FileLoadedPostProcess OGLMMENAJFL_onSuccess, FileLoadedPostProcess GOIHDOPGPCE_onFail, Dictionary<string, string> JBKMAPLCBMO_arg, int HNKPENAFDKA_argValue, FileLoadInfo LAMFBMFNOFP_fi, bool ALJGNAPELAH)
		: base(CJEKGLGBIHF_path,BOPDLODALFD_withoutPlarformPath,OGLMMENAJFL_onSuccess,GOIHDOPGPCE_onFail,JBKMAPLCBMO_arg,HNKPENAFDKA_argValue,LAMFBMFNOFP_fi)
	{
		return;
	}

    // RVA: 0x16C24F8 Offset: 0x16C24F8 VA: 0x16C24F8 Slot: 4
    public override void BDALHEMDIDC_DoStart()
	{
		if(Common.IsStreamingAssetsPath(HHHEFALNMJO_mPath))
		{
			IEJJKNOEKLM = new WWW(Application.streamingAssetsPath + HHHEFALNMJO_mPath);
		}
		else
		{
			IEJJKNOEKLM = new WWW("file://"+HHHEFALNMJO_mPath);
		}
	}

    // RVA: 0x16C2630 Offset: 0x16C2630 VA: 0x16C2630 Slot: 5
    public override bool GDEMPLAOGKK_IsDone()
	{
		if(FHHAFJMELMD_alreadyLoading)
		{
			return true;
		}
		return IEJJKNOEKLM.isDone;
	}

    // RVA: 0x16C2674 Offset: 0x16C2674 VA: 0x16C2674 Slot: 6
    public override string LKPOPGJLPAJ_GetErrorStr()
	{
		if(IEJJKNOEKLM != null)
			return IEJJKNOEKLM.error;
		return null;
	}

    // RVA: 0x16C268C Offset: 0x16C268C VA: 0x16C268C Slot: 9
    public override bool MLMEOLAEJEL_DoLoadData()
    {
        if(!FHHAFJMELMD_alreadyLoading)
        {
            byte[] data = IEJJKNOEKLM.bytes;
            if(!BBGDFKAPJHN(data))
            {
                if(DMKAFCEJFDG_decryptor == null)
                {
                    Debug.LogError("decryptor is null");
                }
                DMKAFCEJFDG_decryptor.CLNHGLGOKPF_Decrypt(data);
            }
			IMGIFJHHEED_fro.bytes = data;
        }
        return base.MLMEOLAEJEL_DoLoadData();
    }

    // RVA: 0x16C27EC Offset: 0x16C27EC VA: 0x16C27EC Slot: 11
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

    // RVA: 0x16C2834 Offset: 0x16C2834 VA: 0x16C2834 Slot: 13
    public override void JNDNHPEIMEI()
	{
		IMGIFJHHEED_fro.bytes = null;
	}
}
