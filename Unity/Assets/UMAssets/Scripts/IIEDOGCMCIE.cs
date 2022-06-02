using System.Collections;

// Namespace: 
public class IIEDOGCMCIE : CBBJHPBGBAJ_Archive // TypeDefIndex: 8687
{
	// Fields
	// private const int NNBHLPECAHJ = 1;
	public bool BIOFMLDLNKD; // 0xC
	public bool NPNNPNAIONN; // 0xD
	public bool PLOOEECNHFB; // 0xE

	// // Methods

	// // RVA: 0x120437C Offset: 0x120437C VA: 0x120437C
	// public void MCDJJPAKBLH(string CJEKGLGBIHF) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6BA26C Offset: 0x6BA26C VA: 0x6BA26C
	// // RVA: 0x12043D8 Offset: 0x12043D8 VA: 0x12043D8
	public IEnumerator ODDEPBIJHOE_Load(string CJEKGLGBIHF_filePath)
    {
        // Namespace: 
        // [CompilerGeneratedAttribute] // RVA: 0x63B14C Offset: 0x63B14C VA: 0x63B14C
        // private sealed class IIEDOGCMCIE.<Coroutine_Load>d__5 : IEnumerator<object>, IEnumerator, IDisposable // TypeDefIndex: 8688
        // {
        // 	// Fields
        // 	private int GGPNEJDOELB; // 0x8
        // 	private object GMEFKDIEHCA; // 0xC
        // 	public string CJEKGLGBIHF; // 0x10
        // 	public IIEDOGCMCIE KIGBLACMODG; // 0x14
        // 	private DsfdLoader.ILoadRequest OCJDGDAJMFC; // 0x18

        // 	// Properties
        // 	private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
        // 	private object System.Collections.IEnumerator.Current { get; }

        // 	// Methods

        // 	[DebuggerHiddenAttribute] // RVA: 0x6BA2E4 Offset: 0x6BA2E4 VA: 0x6BA2E4
        // 	// RVA: 0x1204480 Offset: 0x1204480 VA: 0x1204480
        // 	public void .ctor(int GGPNEJDOELB) { }

        // 	[DebuggerHiddenAttribute] // RVA: 0x6BA2F4 Offset: 0x6BA2F4 VA: 0x6BA2F4
        // 	// RVA: 0x12044A8 Offset: 0x12044A8 VA: 0x12044A8 Slot: 5
        // 	private void System.IDisposable.Dispose() { }

        // 	// RVA: 0x12044AC Offset: 0x12044AC VA: 0x12044AC Slot: 6
        // 	private bool MoveNext() { }

        // 	[DebuggerHiddenAttribute] // RVA: 0x6BA304 Offset: 0x6BA304 VA: 0x6BA304
        // 	// RVA: 0x1204AC4 Offset: 0x1204AC4 VA: 0x1204AC4 Slot: 4
        // 	private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

        // 	[DebuggerHiddenAttribute] // RVA: 0x6BA314 Offset: 0x6BA314 VA: 0x6BA314
        // 	// RVA: 0x1204ACC Offset: 0x1204ACC VA: 0x1204ACC Slot: 8
        // 	private void System.Collections.IEnumerator.Reset() { }

        // 	[DebuggerHiddenAttribute] // RVA: 0x6BA324 Offset: 0x6BA324 VA: 0x6BA324
        // 	// RVA: 0x1204B54 Offset: 0x1204B54 VA: 0x1204B54 Slot: 7
        // 	private object System.Collections.IEnumerator.get_Current() { }
        // }

        Cryptor.DsfdLoader.ILoadRequest request = Cryptor.DsfdLoader.LoadFile(CJEKGLGBIHF_filePath);
        if(request == null)
        {
            PLOOEECNHFB = true;
            NPNNPNAIONN = true;
            yield break;
        }
        while(!request.IsDone)
        {
            yield return null;
        }
        if(!request.IsSuccess)
        {
            PLOOEECNHFB = true;
        }
        else
        {
            byte[] result = request.Result;
            bool r = BOBCNJIPPJN.AGJJGJCIMKI(result);
            if(!r)
            {
                ANCJLICGOLP a = DOKOHKJIDBO.HHCJCDFCLOB.IKCAJDOKNOM;
                int val1 = a.LPJLEHAJADA("m_0", 0);
                int val2 = a.LPJLEHAJADA("m_1", 0);
                int val3 = a.LPJLEHAJADA("m_2", 0);
                int val4 = a.LPJLEHAJADA("m_3", 0);
                BEEINMBNKNM_Encryption encryption = new BEEINMBNKNM_Encryption();
                encryption.KHEKNNFCAOI((uint)(val4 + 7));
                encryption.DGBPHDMEDNP(val1, val2, val3);
                encryption.FAEFDAJAMCE(result);
                encryption.AAGCKDHEMFD_GenerateKey();
            }
            BIOFMLDLNKD = KHEKNNFCAOI_Load(request.Result);
            PLOOEECNHFB = true;
            if(!BIOFMLDLNKD)
            {
                yield break;
            }
        }
        NPNNPNAIONN = true;
    }
}
