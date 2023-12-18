using SecureLib;
using UnityEngine;
using XeSys;

public class CNGFKOJANNP
{
	private CEBFFLDKAEC_SecureInt IKBKLPNADJM; // 0x8
	private LINJMMGGDKL_SecureInt2 OCCEOHOFGNE; // 0xC
	private const int DFLLFGDDFFG_StartCheckFrame = 750;
	private int DGIPJOMHJEJ_WaitCheck; // 0x10
	private int LGADCGFMLLD_State; // 0x14
	private int FBGGEFFJJHB; // 0x18
	public PJADOKMABLA IBJEFPCNMAL; // 0x1C

	public static CNGFKOJANNP HHCJCDFCLOB { get; set; } // 0x0 LGMPACEDIJF // NKACBOEHELJ OKPMHKNCNAL
	public bool MGALHAHPADF_CanAutoCheck { get { return IKBKLPNADJM.DNJEJEANJGL_Value != 0; } set { IKBKLPNADJM.DNJEJEANJGL_Value = value ? 1 : 0; } } // AOMLLAKLDEO 0x175B694 AMKHFLKAEGG 0x175B61C
	public bool AKPCMLEPPGC_IsInvalid { get { return OCCEOHOFGNE.DNJEJEANJGL_Value != 0; } set { OCCEOHOFGNE.DNJEJEANJGL_Value = value ? 1 : 0; } } // HJLOFLKLELJ 0x175B6C8 EGALFIJGJOH 0x175B658

	// // RVA: 0x175B470 Offset: 0x175B470 VA: 0x175B470
	public void NOIKNDALDAC(byte[] PFJBBHAMAKM)
	{
		IBJEFPCNMAL = PJADOKMABLA.HEGEKFMJNCC(PFJBBHAMAKM);
	}

	// // RVA: 0x175B490 Offset: 0x175B490 VA: 0x175B490
	public void IJBGPAENLJA_Init(MonoBehaviour DANMJLOBLIE)
	{
		FBGGEFFJJHB = (int)(Utility.GetCurrentUnixTime() * 0x1d7);
		HHCJCDFCLOB = this;
		IKBKLPNADJM = new CEBFFLDKAEC_SecureInt();
		IKBKLPNADJM.DNJEJEANJGL_Value = 0;
		OCCEOHOFGNE = new LINJMMGGDKL_SecureInt2();
		OCCEOHOFGNE.DNJEJEANJGL_Value = 0;
		MGALHAHPADF_CanAutoCheck = true;
		AKPCMLEPPGC_IsInvalid = false;
		DGIPJOMHJEJ_WaitCheck = 0;
		LGADCGFMLLD_State = 0;
	}

	// // RVA: 0x175B6FC Offset: 0x175B6FC VA: 0x175B6FC
	public void EGDJHGIAFGO_Start()
    {
		MGALHAHPADF_CanAutoCheck = true;
		AKPCMLEPPGC_IsInvalid = false;
    }

	// // RVA: 0x175B720 Offset: 0x175B720 VA: 0x175B720
	public void IKHJJMKLAEP_DisableAutoCheck()
    {
        MGALHAHPADF_CanAutoCheck = false;
    }

	// // RVA: 0x175B728 Offset: 0x175B728 VA: 0x175B728
	public void KANPNADDJBK_EnableAutoCheck()
	{
		MGALHAHPADF_CanAutoCheck = true;
	}

	// // RVA: 0x175B730 Offset: 0x175B730 VA: 0x175B730
	public void FGDBKOCCKOE(bool JKDJCFEBDHC)
	{
		if(SecureLibAPI.isDebuggerAttachedJava())
			AKPCMLEPPGC_IsInvalid = true;
		if(SecureLibAPI.isDebuggerAttachedNative())
			AKPCMLEPPGC_IsInvalid = true;
	}

	// // RVA: 0x175B80C Offset: 0x175B80C VA: 0x175B80C
	public void BAGMHFKPFIF_Update()
	{
		if(IKBKLPNADJM.KPOCKNCJBPN_CheckSecure() != null)
		{
			AKPCMLEPPGC_IsInvalid = true;
		}
		if (!MGALHAHPADF_CanAutoCheck)
			return;
		if (IKBKLPNADJM.DNJEJEANJGL_Value == 0)
			return;
		DGIPJOMHJEJ_WaitCheck++;
		if (DGIPJOMHJEJ_WaitCheck <= DFLLFGDDFFG_StartCheckFrame)
			return;
		if(LGADCGFMLLD_State == 2)
		{
			if(IBJEFPCNMAL != null)
			{
				if(IBJEFPCNMAL.MLMGFOGCDMD.Length == 0)
				{
					LGADCGFMLLD_State = 0;
					DGIPJOMHJEJ_WaitCheck = 0;
					return;
				}
				bool hasChecked = false;
				bool isInvalid = true;
				for(int i = 0; i < IBJEFPCNMAL.MLMGFOGCDMD.Length; i++)
				{
					if(IBJEFPCNMAL.MLMGFOGCDMD[i].NHJBJIGNLHI == IKBKLPNADJM.DNJEJEANJGL_Value)
					{
						if(IBJEFPCNMAL.MLMGFOGCDMD[i].IOIMHJAOKOO.Contains(","))
						{
							hasChecked = true;
							if(!SecureLib.SecureLibAPI.checkCodeDigest(IBJEFPCNMAL.MLMGFOGCDMD[i].IOIMHJAOKOO))
							{
								isInvalid = false;
								break;
							}
						}
					}
				}
				if(hasChecked && isInvalid)
				{
					AKPCMLEPPGC_IsInvalid = true;
				}
			}
			LGADCGFMLLD_State = 0;
		}
		else
		{
			bool d = false;
			if(LGADCGFMLLD_State == 1)
			{
				d = SecureLib.SecureLibAPI.isDebuggerAttachedNative();
			}
			else if(LGADCGFMLLD_State != 0)
			{
				DGIPJOMHJEJ_WaitCheck = 0;
			}
			else
			{
				d = SecureLib.SecureLibAPI.isHooked();
			}
			if(d)
			{
				AKPCMLEPPGC_IsInvalid = true;
			}
			LGADCGFMLLD_State++;
		}
		DGIPJOMHJEJ_WaitCheck = 0;
	}

	// // RVA: 0x175BB70 Offset: 0x175BB70 VA: 0x175BB70
	public void BNGIDMBNILP_ManualCheck()
	{
		if(IBJEFPCNMAL == null)
		{
			AKPCMLEPPGC_IsInvalid = true;
			return;
		}
		if(!AKPCMLEPPGC_IsInvalid)
		{
			AKPCMLEPPGC_IsInvalid = SecureLib.SecureLibAPI.isDebuggerAttachedJava();
			if(!AKPCMLEPPGC_IsInvalid)
			{
				AKPCMLEPPGC_IsInvalid = SecureLib.SecureLibAPI.isDebuggerAttachedNative();
			}
			if (!AKPCMLEPPGC_IsInvalid)
			{
				if(IBJEFPCNMAL.MLMGFOGCDMD.Length != 0)
				{
					bool hasChecked = false;
					bool isValid = true;
					for (int i = 0; i < IBJEFPCNMAL.MLMGFOGCDMD.Length; i++)
					{
						if (IBJEFPCNMAL.MLMGFOGCDMD[i].NHJBJIGNLHI == IKBKLPNADJM.DNJEJEANJGL_Value)
						{
							if (IBJEFPCNMAL.MLMGFOGCDMD[i].IOIMHJAOKOO.Contains(","))
							{
								hasChecked = true;
								if (!SecureLib.SecureLibAPI.checkCodeDigest(IBJEFPCNMAL.MLMGFOGCDMD[i].IOIMHJAOKOO))
								{
									isValid = false;
									break;
								}
							}
						}
					}
					if(hasChecked && isValid)
						AKPCMLEPPGC_IsInvalid = true;
				}
			}
		}
	}
}
