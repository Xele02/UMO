using UnityEngine;

// Namespace:
public class PFHMOOFJMIM : LBHFILLFAGA
{
        // Fields
        private WWW IEJJKNOEKLM; // 0x4C

        // Methods

        // RVA: 0x16C23AC Offset: 0x16C23AC VA: 0x16C23AC
        //public void PFHMOOFJMIM() { }

        // RVA: 0x16C2430 Offset: 0x16C2430 VA: 0x16C2430
        //public void PFHMOOFJMIM(string CJEKGLGBIHF, string BOPDLODALFD, FileLoadedPostProcess OGLMMENAJFL, FileLoadedPostProcess GOIHDOPGPCE, Dictionary<string, string> JBKMAPLCBMO, int HNKPENAFDKA, FileLoadInfo LAMFBMFNOFP, bool ALJGNAPELAH) { }

        // RVA: 0x16C24F8 Offset: 0x16C24F8 VA: 0x16C24F8 Slot: 4
        //public override void BDALHEMDIDC() { }

        // RVA: 0x16C2630 Offset: 0x16C2630 VA: 0x16C2630 Slot: 5
        //public override bool GDEMPLAOGKK() { }

        // RVA: 0x16C2674 Offset: 0x16C2674 VA: 0x16C2674 Slot: 6
        //public override string LKPOPGJLPAJ() { }

        // RVA: 0x16C268C Offset: 0x16C268C VA: 0x16C268C Slot: 9
        public override bool MLMEOLAEJEL()
        {
            bool a = LGCBNNBFLLC();
            if(!a)
            {
                byte[] DBBGALAPFGC = null;//IEJJKNOEKLM.get_bytes(); // TODO
                a = BBGDFKAPJHN(DBBGALAPFGC);
                if(!a)
                {
                    BEEINMBNKNM_Encryption b = LIMGNMMPKGF();
                    if(b == null)
                    {
                        Debug.LogError("decryptor is null");
                    }
                    b.CLNHGLGOKPF_Decrypt(DBBGALAPFGC);
                }
                // TODO
                //XeSys.FileResultObject obj = LNDGEDHIEAF();
                //obj.set_bytes(DBBGALAPFGC);
            }
            a = MLMEOLAEJEL();
            return a;
        }

        // RVA: 0x16C27EC Offset: 0x16C27EC VA: 0x16C27EC Slot: 11
        //public override void PAHHAMPDBFP() { }

        // RVA: 0x16C2834 Offset: 0x16C2834 VA: 0x16C2834 Slot: 13
        //public override void JNDNHPEIMEI() { }
}