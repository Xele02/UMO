using XeSys;
using System.Collections.Generic;
using CriWare;

public class PLKCJJECNCK : LBHFILLFAGA
{
	private CriFsBindRequest NHDMLDHDCIG; // 0x4C
	private uint EHFLALENJKP; // 0x50

	// // RVA: 0xFE9E58 Offset: 0xFE9E58 VA: 0xFE9E58
	public PLKCJJECNCK()
    {
		COIBJNACMFK = null;
		EHFLALENJKP = 0;
    }

	// // RVA: 0xFE9EF4 Offset: 0xFE9EF4 VA: 0xFE9EF4
	public PLKCJJECNCK(string CJEKGLGBIHF_path, string BOPDLODALFD_withoutPlarformPath, FileLoadedPostProcess OGLMMENAJFL_onSuccess, FileLoadedPostProcess GOIHDOPGPCE_onFail, Dictionary<string, string> JBKMAPLCBMO_arg, int HNKPENAFDKA_argValue, FileLoadInfo LAMFBMFNOFP_fi, bool ALJGNAPELAH)
		: base(CJEKGLGBIHF_path,BOPDLODALFD_withoutPlarformPath,OGLMMENAJFL_onSuccess,GOIHDOPGPCE_onFail,JBKMAPLCBMO_arg,HNKPENAFDKA_argValue,LAMFBMFNOFP_fi)
    {
    }

	// // RVA: 0xFE9FBC Offset: 0xFE9FBC VA: 0xFE9FBC Slot: 4
	public override void BDALHEMDIDC_DoStart()
	{
		if(!HHHEFALNMJO_mPath.Contains("bind:"))
			return;
		NHDMLDHDCIG = CriFsUtility.BindCpk(COIBJNACMFK, HHHEFALNMJO_mPath);
	}

	// // RVA: 0xFEA05C Offset: 0xFEA05C VA: 0xFEA05C Slot: 5
	public override bool GDEMPLAOGKK_IsDone()
	{
		if(FHHAFJMELMD_alreadyLoading)
		{
			return true;
		}
		return NHDMLDHDCIG.isDone;
	}

	// // RVA: 0xFEA0A0 Offset: 0xFEA0A0 VA: 0xFEA0A0 Slot: 6
	public override string LKPOPGJLPAJ_GetErrorStr()
	{
		if(NHDMLDHDCIG != null)
			return NHDMLDHDCIG.error;
		return null;
	}

	// // RVA: 0xFEA0B8 Offset: 0xFEA0B8 VA: 0xFEA0B8 Slot: 9
	public override bool MLMEOLAEJEL_DoLoadData()
	{
		if(!FHHAFJMELMD_alreadyLoading)
        {
			EHFLALENJKP = NHDMLDHDCIG.bindId;
		}
		return base.MLMEOLAEJEL_DoLoadData();
	}

	// // RVA: 0xFEA108 Offset: 0xFEA108 VA: 0xFEA108 Slot: 11
	public override void PAHHAMPDBFP()
	{
		if(FHHAFJMELMD_alreadyLoading)
			return;
		NHDMLDHDCIG.Stop();
		base.PAHHAMPDBFP();
	}

	// // RVA: 0xFEA150 Offset: 0xFEA150 VA: 0xFEA150 Slot: 12
	public override void DKNGPHJKGAP()
	{
		if(FHHAFJMELMD_alreadyLoading)
			return;
		base.DKNGPHJKGAP();
	}

	// // RVA: 0xFEA17C Offset: 0xFEA17C VA: 0xFEA17C Slot: 13
	public override void JNDNHPEIMEI()
	{
		if(EHFLALENJKP == 0)
			return;
		CriFsBinder.Unbind(EHFLALENJKP);
		EHFLALENJKP = 0;
	}
}
