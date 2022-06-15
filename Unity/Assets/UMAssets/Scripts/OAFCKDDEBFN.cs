using System.Collections.Generic;
using System.Text.RegularExpressions;

public class OAFCKDDEBFN
{
    public class AACCPKIGMED
    {
        public BEEINMBNKNM_Encryption DMKAFCEJFDG_decryptor; // 0x8
        public Regex JHOONHIHJNJ_MatchKey; // 0xC
        private int KNEFBLHBDBG; // 0x10

		// RVA: 0x1CBED14 Offset: 0x1CBED14 VA: 0x1CBED14
        public void KHEKNNFCAOI(string MKANHLNEEGL, int KNEFBLHBDBG)
        {
            DMKAFCEJFDG_decryptor = null;
            JHOONHIHJNJ_MatchKey = null;
            this.KNEFBLHBDBG = KNEFBLHBDBG;

            JHOONHIHJNJ_MatchKey = new Regex(MKANHLNEEGL);
            if(KNEFBLHBDBG == 0)
                return;
            DMKAFCEJFDG_decryptor = new BEEINMBNKNM_Encryption();
            DMKAFCEJFDG_decryptor.KHEKNNFCAOI((uint)KNEFBLHBDBG);
        }
    }

	private List<AACCPKIGMED> MGJKEJHEBPO = new List<AACCPKIGMED>(); // 0x8
	private static string[] GEGMOOLADID_Filters = new string[0x16] {
		".usm$", "/ct/ba/.+", "/ct/bg/.+", "/ct/im/.+",
		"/ct/lo/.+", "/ct/mc/.+", "/ct/rk/.+", "/ct/sc/.+",
		"/ct/sk/.+", "/ct/.+", "/dv/.+", "/ev/.+",
		"/gc/.+", "/gm/.+", "/handmode/.+", "/ly/.+",
		"/mc/.+", "/mn/.+", "/msg/.+", "/st/.+", "/vl/.+", ".xab$" }; // 0x0

	// // RVA: 0x1CBEC0C Offset: 0x1CBEC0C VA: 0x1CBEC0C
	// private int KGIIIIOHIDJ(int OIPCCBHIKIA) { }

	// // RVA: 0x1CBEC14 Offset: 0x1CBEC14 VA: 0x1CBEC14
	// public void ALLGKHCNKDN() { } // <<

	// RVA: 0x1CBEDF4 Offset: 0x1CBEDF4 VA: 0x1CBEDF4
	public void PGLANLKJBLI_Init() //> GameStart >  KEHOJEJMGLJ.PAHGEEOFEPM
	{
		MGJKEJHEBPO.Clear();
		DOKOHKJIDBO a = DOKOHKJIDBO.HHCJCDFCLOB;
		ANCJLICGOLP IKCAJDOKNOM = a.IKCAJDOKNOM;
		int index = 0;
		List<MFJONNINDCJ> JGJJIBPPEPD = IKCAJDOKNOM.JGJJIBPPEPD_List;
		while(true)
		{
			if(JGJJIBPPEPD.Count <= index)
				return;
			AACCPKIGMED newData = new AACCPKIGMED();
			MFJONNINDCJ data = JGJJIBPPEPD[index];
			string MKANHLNEEGL = data.MKANHLNEEGL;
			int value = data.JBGEEPFKIGG;
			newData.KHEKNNFCAOI(MKANHLNEEGL, value);
			MGJKEJHEBPO.Add(newData);
			index = index + 1;
		}
	}

	// RVA: 0x1CBF008 Offset: 0x1CBF008 VA: 0x1CBF008
	public BEEINMBNKNM_Encryption MFHAOMELJKJ_FindDecryptor(string CJEKGLGBIHF_path)
	{
		int index = 0;
		string input = CJEKGLGBIHF_path.Replace('\\','/');
		while(true)
		{
			if(MGJKEJHEBPO.Count <= index)
				return null;
			AACCPKIGMED a = MGJKEJHEBPO[index];
			if(a == null)
				break;
			bool match = a.JHOONHIHJNJ_MatchKey.IsMatch(input);
			if(match)
			{
				return a.DMKAFCEJFDG_decryptor;
			}
			index++;
		}
		UnityEngine.Debug.LogError("TODO");
		return null; // TODO
	}
}
