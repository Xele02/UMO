using UnityEngine;
using XeApp.Game;
using XeApp.Game.Menu;
using XeApp.Game.Title;
using XeApp.Game.Common.uGUI;
using UnityEngine.UI;
using System.Collections;

public class IOGKADECKOP
{
    public delegate void BBCOMMKDEDF(string INHEEPHFAON);

	private MonoBehaviour DANMJLOBLIE; // 0x8
	private bool BICOBOLNFLJ; // 0xC
	private InheritingMenu MCJHELIEHMC; // 0x10
	private LayoutTitleController NOFPJPHIPBD; // 0x14
	private RawImage PDOILOAFKCF; // 0x18
	private GameObject HOFMODFAOEA; // 0x1C
	private string ABJDBPINCIC = "DownLoad"; // 0x20
	public IOGKADECKOP.BBCOMMKDEDF OGNDELCENBB; // 0x24
	private AMOCLPHDGBP OFFPKPHHLKD; // 0x28
	private bool OKDMEMPECDO; // 0x2C
	private bool LKFGMDGFKDP; // 0x2D
	private bool JJHGAKDMGLJ; // 0x2E
	private BgBehaviour IJCPLBPLJLJ; // 0x30
	private bool EHKDIJELHAO; // 0x34
	private bool OOIBKCCMCAG; // 0x35
	private int NLFFEOBGFMC; // 0x38
	private int BLEAOGCLJPK; // 0x3C
	//private readonly int[] MLDJAIHDFOM = new int[10] {Field$<PrivateImplementationDetails>.E0D2592373A0C161E56E266306CD8405CD719D19}; // 0x40

	// // RVA: 0xA061D8 Offset: 0xA061D8 VA: 0xA061D8
	public void LIGFHEAKAGD(MonoBehaviour DANMJLOBLIE)
    {
        this.DANMJLOBLIE = DANMJLOBLIE;
        for(int i = 0; i < DANMJLOBLIE.transform.parent.childCount; i++)
        {
            if(DANMJLOBLIE.transform.parent.GetChild(i).name == "Bg")
                PDOILOAFKCF = DANMJLOBLIE.transform.parent.GetChild(i).GetComponent<RawImage>();
        }
        GameManager.Instance.SetFPS(30);
    }

	// // RVA: 0xA063BC Offset: 0xA063BC VA: 0xA063BC
	public void BHADKPGCNCP()
    {
        BICOBOLNFLJ = false;
        JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = false;
        PGIGNJDPCAH.NNOBACMJHDM(PGIGNJDPCAH.FELLIEJEPIJ.FFPANKMKAPD);
        PGIGNJDPCAH.FLHLJFHILPO(false);
        PGIGNJDPCAH.MLPMNKKNFCJ();
        MenuScene.IsFirstTitleFlow = true;
        GameManager.Instance.ClearPushBackButtonHandler();
        GameManager.Instance.SetTransmissionIconPosition(false);
        DANMJLOBLIE.StartCoroutine(GGKONDNONPP());
        UnityEngine.Debug.LogError("TODO");
    }

	// // RVA: 0xA065F0 Offset: 0xA065F0 VA: 0xA065F0
	public bool FKDKMCKJNJD()
    {
        UnityEngine.Debug.LogError("TODO");
        return false;
    }

	// // RVA: 0xA066E0 Offset: 0xA066E0 VA: 0xA066E0
	public void FGBKOJCFMKM()
    {
        UnityEngine.Debug.LogError("TODO");
    }

	// // RVA: 0xA0694C Offset: 0xA0694C VA: 0xA0694C
	// public void OCCAKNDDCMA() { }

	// // RVA: 0xA06B74 Offset: 0xA06B74 VA: 0xA06B74
	// public void GIPPBCOMDGL() { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B3CB8 Offset: 0x6B3CB8 VA: 0x6B3CB8
	// // RVA: 0xA06658 Offset: 0xA06658 VA: 0xA06658
	// private IEnumerator LMDJGHMDDJA() { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B3D30 Offset: 0x6B3D30 VA: 0x6B3D30
	// // RVA: 0xA06564 Offset: 0xA06564 VA: 0xA06564
	private IEnumerator GGKONDNONPP()
    {
        UnityEngine.Debug.LogError("TODO");
        yield break;
    }

	// [IteratorStateMachineAttribute] // RVA: 0x6B3DA8 Offset: 0x6B3DA8 VA: 0x6B3DA8
	// // RVA: 0xA06B98 Offset: 0xA06B98 VA: 0xA06B98
	// private IEnumerator DFLFHJHBKOC() { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B3E20 Offset: 0x6B3E20 VA: 0x6B3E20
	// // RVA: 0xA06C44 Offset: 0xA06C44 VA: 0xA06C44
	// private IEnumerator FIIEPEEMMLD() { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B3E98 Offset: 0x6B3E98 VA: 0x6B3E98
	// // RVA: 0xA06CF0 Offset: 0xA06CF0 VA: 0xA06CF0
	// private IEnumerator LLMFFOGJNLH_Initialize() { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B3F10 Offset: 0x6B3F10 VA: 0x6B3F10
	// // RVA: 0xA06D9C Offset: 0xA06D9C VA: 0xA06D9C
	// private IEnumerator BLJICEOFNMM_LoadLayoutTitle() { }

	// // RVA: 0xA06E24 Offset: 0xA06E24 VA: 0xA06E24
	// private void PELOLGDNOGL() { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B3F88 Offset: 0x6B3F88 VA: 0x6B3F88
	// // RVA: 0xA07174 Offset: 0xA07174 VA: 0xA07174
	// private IEnumerator ABPGOJDKKHO_PopupShowSNS(Action KBCBGIGOLHP, Action AOCANKOMKFG, bool DLNDPMNLMGC = False) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B4000 Offset: 0x6B4000 VA: 0x6B4000
	// // RVA: 0xA07248 Offset: 0xA07248 VA: 0xA07248
	// private IEnumerator IMDAHCEDGFK_TitleLogo() { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B4078 Offset: 0x6B4078 VA: 0x6B4078
	// // RVA: 0xA072D0 Offset: 0xA072D0 VA: 0xA072D0
	// private IEnumerator IMJGOIOLGIO_Contract(Action FHANAFNKIFC, Action DOGDHKIEBJA) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B40F0 Offset: 0x6B40F0 VA: 0x6B40F0
	// // RVA: 0xA07398 Offset: 0xA07398 VA: 0xA07398
	// private IEnumerator HNPMKCFMEGA_Inquiry() { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B4168 Offset: 0x6B4168 VA: 0x6B4168
	// // RVA: 0xA068C0 Offset: 0xA068C0 VA: 0xA068C0
	// private IEnumerator PFEKBBONCJJ_GameStart() { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B41E0 Offset: 0x6B41E0 VA: 0x6B41E0
	// // RVA: 0xA07440 Offset: 0xA07440 VA: 0xA07440
	// private IEnumerator ACHBBAIODMC() { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B4258 Offset: 0x6B4258 VA: 0x6B4258
	// // RVA: 0xA074C8 Offset: 0xA074C8 VA: 0xA074C8
	// private IEnumerator HBBDEHKOFKN_DownloadTitleBannerTexture() { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B42D0 Offset: 0x6B42D0 VA: 0x6B42D0
	// // RVA: 0xA06AEC Offset: 0xA06AEC VA: 0xA06AEC
	// private IEnumerator KOEILOLECCF_StartARMode() { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B4348 Offset: 0x6B4348 VA: 0x6B4348
	// // RVA: 0xA07574 Offset: 0xA07574 VA: 0xA07574
	// private IEnumerator NNPDJBJGBFA_ReturnToTitle() { }

	// // RVA: 0xA075FC Offset: 0xA075FC VA: 0xA075FC
	// private void EECGCFAKEPF() { }

	// // RVA: 0xA07698 Offset: 0xA07698 VA: 0xA07698
	// private void JNBOGCGCOMH() { }

	// // RVA: 0xA0780C Offset: 0xA0780C VA: 0xA0780C
	// private void CFGABDOEHBI() { }

	// // RVA: 0xA07A3C Offset: 0xA07A3C VA: 0xA07A3C
	// private void GJLDMJFMIOD() { }

	// // RVA: 0xA07B88 Offset: 0xA07B88 VA: 0xA07B88
	// public void NIFKNMFALEM() { }

	// // RVA: 0xA07D9C Offset: 0xA07D9C VA: 0xA07D9C
	// public void FHBJNLFHGPB(int LNAHJANMJNM) { }

	// // RVA: 0xA07E70 Offset: 0xA07E70 VA: 0xA07E70
	// public void HFIBEEMGOND() { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B43C0 Offset: 0x6B43C0 VA: 0x6B43C0
	// // RVA: 0xA07FF0 Offset: 0xA07FF0 VA: 0xA07FF0
	// private IEnumerator LCCKLAEOAMB_InitAREventAndTitleBG() { }

	// // RVA: 0xA0809C Offset: 0xA0809C VA: 0xA0809C
	// private void GCGFGMICEGF() { }

	// // RVA: 0xA081F8 Offset: 0xA081F8 VA: 0xA081F8
	// private void FJHPOIDFLEE() { }

	// // RVA: 0xA084F8 Offset: 0xA084F8 VA: 0xA084F8
	// public void .ctor() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6B4438 Offset: 0x6B4438 VA: 0x6B4438
	// // RVA: 0xA085A0 Offset: 0xA085A0 VA: 0xA085A0
	// private void <SetLayoutButtonCallback>b__31_0() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6B4448 Offset: 0x6B4448 VA: 0x6B4448
	// // RVA: 0xA085FC Offset: 0xA085FC VA: 0xA085FC
	// private void <SetLayoutButtonCallback>b__31_1() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6B4458 Offset: 0x6B4458 VA: 0x6B4458
	// // RVA: 0xA087F8 Offset: 0xA087F8 VA: 0xA087F8
	// private void <SetLayoutButtonCallback>b__31_3() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6B4468 Offset: 0x6B4468 VA: 0x6B4468
	// // RVA: 0xA088EC Offset: 0xA088EC VA: 0xA088EC
	// private bool <Coroutine_DownloadTitleBannerTexture>b__38_0(FileResultObject NLCGHBBNOJA) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6B4478 Offset: 0x6B4478 VA: 0x6B4478
	// // RVA: 0xA089D0 Offset: 0xA089D0 VA: 0xA089D0
	// private void <OnPushBackButton>b__44_0() { }
}
