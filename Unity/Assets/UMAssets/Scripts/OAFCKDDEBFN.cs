using System.Collections.Generic;
using System.Text.RegularExpressions;

// Namespace:
public class OAFCKDDEBFN // TypeDefIndex: 8823
{
    // Namespace:
    public class AACCPKIGMED // TypeDefIndex: 8824
    {
        // Fields
        public BEEINMBNKNM_Encryption DMKAFCEJFDG; // 0x8
        public Regex JHOONHIHJNJ_MatchKey; // 0xC
        private int KNEFBLHBDBG; // 0x10

        // Methods

        public void KHEKNNFCAOI(string MKANHLNEEGL, int KNEFBLHBDBG)
        {
            DMKAFCEJFDG = null;
            JHOONHIHJNJ_MatchKey = null;
            this.KNEFBLHBDBG = KNEFBLHBDBG;

            JHOONHIHJNJ_MatchKey = new Regex(MKANHLNEEGL);
            if(KNEFBLHBDBG == 0)
                return;
            DMKAFCEJFDG = new BEEINMBNKNM_Encryption();
            DMKAFCEJFDG.KHEKNNFCAOI((uint)KNEFBLHBDBG);
        }

        public AACCPKIGMED() { }
    }

        // Fields
        private List<AACCPKIGMED> MGJKEJHEBPO; // 0x8
        private static string[] GEGMOOLADID_Filters; // 0x0

        // Methods
/*
        // RVA: 0x1CBEC0C Offset: 0x1CBEC0C VA: 0x1CBEC0C
        private int KGIIIIOHIDJ(int OIPCCBHIKIA) { }

        // RVA: 0x1CBEC14 Offset: 0x1CBEC14 VA: 0x1CBEC14
        public void ALLGKHCNKDN() { } // <<
*/
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
                int value = data.OLOCMINKGON();
                newData.KHEKNNFCAOI(MKANHLNEEGL, value);
                MGJKEJHEBPO.Add(newData);
                index = index + 1;
            }
        }

        public BEEINMBNKNM_Encryption MFHAOMELJKJ_FindDecryptor(string CJEKGLGBIHF_Key)
        {
            int index = 0;
            string input = CJEKGLGBIHF_Key.Replace('\\','/');
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
                    return a.DMKAFCEJFDG;
                }
                index++;
            }
            UnityEngine.Debug.LogError("TODO");
            return null; // TODO
        }

        // RVA: 0x1CBF180 Offset: 0x1CBF180 VA: 0x1CBF180
        public OAFCKDDEBFN() 
        { 
            MGJKEJHEBPO = new List<AACCPKIGMED>();
        }

        static OAFCKDDEBFN()
        {
            GEGMOOLADID_Filters = new string[0x16];
            int i = 0;
            GEGMOOLADID_Filters[i++] = ".usm$";
            GEGMOOLADID_Filters[i++] = "/ct/ba/.+";
            GEGMOOLADID_Filters[i++] = "/ct/bg/.+";
            GEGMOOLADID_Filters[i++] = "/ct/im/.+";
            GEGMOOLADID_Filters[i++] = "/ct/lo/.+";
            GEGMOOLADID_Filters[i++] = "/ct/mc/.+";
            GEGMOOLADID_Filters[i++] = "/ct/rk/.+";
            GEGMOOLADID_Filters[i++] = "/ct/sc/.+";
            GEGMOOLADID_Filters[i++] = "/ct/sk/.+";
            GEGMOOLADID_Filters[i++] = "/ct/.+";
            GEGMOOLADID_Filters[i++] = "/dv/.+";
            GEGMOOLADID_Filters[i++] = "/ev/.+";
            GEGMOOLADID_Filters[i++] = "/gc/.+";
            GEGMOOLADID_Filters[i++] = "/gm/.+";
            GEGMOOLADID_Filters[i++] = "/handmode/.+";
            GEGMOOLADID_Filters[i++] = "/ly/.+";
            GEGMOOLADID_Filters[i++] = "/mc/.+";
            GEGMOOLADID_Filters[i++] = "/mn/.+";
            GEGMOOLADID_Filters[i++] = "/msg/.+";
            GEGMOOLADID_Filters[i++] = "/st/.+";
            GEGMOOLADID_Filters[i++] = "/vl/.+";
            GEGMOOLADID_Filters[i++] = ".xab$";
        }
}
