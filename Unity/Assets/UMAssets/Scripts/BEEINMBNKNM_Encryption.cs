using System;
// Namespace:
public class BEEINMBNKNM_Encryption
{
        // Fields
        public byte[] GPGMEAPLJAI_Key; // 0x8
        private uint KNEFBLHBDBG; // 0xC
        private uint PMBEODGMMBB; // 0x10
        private int GELENHPBKFA; // 0x14
        private int DLDLDGJEOJG; // 0x18
        private int PLNOOFNMHAL; // 0x1C

        // Methods

        // RVA: 0xC73B0C Offset: 0xC73B0C VA: 0xC73B0C
        //private uint FBGGEFFJJHB() { }

        public void KHEKNNFCAOI(uint KNEFBLHBDBG)
        {
                this.KNEFBLHBDBG = KNEFBLHBDBG;
                PMBEODGMMBB = KNEFBLHBDBG;
                int i = 0;
                while(true)
                {
                        uint a = KNEFBLHBDBG ^ (KNEFBLHBDBG << 0xd);
                        a = a ^ a >> 0x11;
                        a = a ^ a << 5;
                        PMBEODGMMBB = a;
                        if(GPGMEAPLJAI_Key.Length <= i)
                                break;
                        GPGMEAPLJAI_Key[i] = (byte)(a >> 3);
                        if(i == 1023)
                                return;
                        i++;
                        KNEFBLHBDBG = PMBEODGMMBB;
                }
        }

        public void AAGCKDHEMFD_GenerateKey()
        { 
                uint i = 0;
                while(true)
                {
                        uint a = PMBEODGMMBB;
                        a = a ^ a << 0xd;
                        a = a ^ a >> 0x11;
                        a = a ^ a << 5;
                        PMBEODGMMBB = a;
                        if(GPGMEAPLJAI_Key.Length <= i)
                                break;
                        GPGMEAPLJAI_Key[i] = (byte)(a >> 3);
                        i++;
                        if(i == 1024)
                                return;
                }
        }

        // RVA: 0xC73C18 Offset: 0xC73C18 VA: 0xC73C18
        private static /*extern*/ void FFPAGMCDALB(byte[] CDENCMNHNGA, byte[] DBBGALAPFGC, int NFHFALDMGGC)
        {
                //TODO
                // Decrypt xedec
        }

        // RVA: 0xC73D28 Offset: 0xC73D28 VA: 0xC73D28
        //private static extern void MFKJIGBFJEN(IntPtr CDENCMNHNGA, IntPtr DBBGALAPFGC, int NFHFALDMGGC) { }

        // RVA: 0xC73E34 Offset: 0xC73E34 VA: 0xC73E34
        //public void DMDLDOAOIAJ(byte[] DBBGALAPFGC) { }

        public void CLNHGLGOKPF_Decrypt(byte[] DBBGALAPFGC)
        {
                FFPAGMCDALB(GPGMEAPLJAI_Key, DBBGALAPFGC, DBBGALAPFGC.Length);
        }

        // RVA: 0xC73ECC Offset: 0xC73ECC VA: 0xC73ECC
        //private int NEKCJNMGNID(int PKLPKMLGFGK) { }

        // RVA: 0xC73ED8 Offset: 0xC73ED8 VA: 0xC73ED8
        //public string AGKMBDIJHID(int INDDJNMPONH) { }

        // RVA: 0xC73F54 Offset: 0xC73F54 VA: 0xC73F54
        //public static uint GKBODMNBFJM(uint IOIMHJAOKOO, byte[] DBBGALAPFGC) { }

        // RVA: 0xC73FC8 Offset: 0xC73FC8 VA: 0xC73FC8
        //private static extern uint ANMDMMBEJPB(uint IOIMHJAOKOO, IntPtr DBBGALAPFGC, int NFHFALDMGGC) { }

        // RVA: 0xC740D4 Offset: 0xC740D4 VA: 0xC740D4
        //public static uint DIKDKNIKPNJ(uint IOIMHJAOKOO, string CJEKGLGBIHF) { }

        public void DGBPHDMEDNP(int DHIPGHBJLIL, int POMLAOPLMNA, int DFIDIEENJAE)
        {
                GELENHPBKFA = DHIPGHBJLIL;
                DLDLDGJEOJG = POMLAOPLMNA;
                PLNOOFNMHAL = DFIDIEENJAE;
        }

        public void LBGGPBBOIEH(byte[] DBBGALAPFGC)
        { 
                int size = DBBGALAPFGC.Length;
                PMBEODGMMBB = KNEFBLHBDBG;
                if(size > 0)
                {
                        // TODO
                        uint q = 0;//Math.DivRem(size, PLNOOFNMHAL);
                        /*for(int i = 0; i < size; i++)
                        {
                                q = q * GELENHPBKFA + DLDLDGJEOJG;
                                DBBGALAPFGC[i] = GPGMEAPLJAI_Key[q & 0x3ff] ^ DBBGALAPFGC[i];
                        }*/
                }
        }

        public void FAEFDAJAMCE(byte[] DBBGALAPFGC)
        {
                uint size = (uint)DBBGALAPFGC.Length;
                PMBEODGMMBB = KNEFBLHBDBG;
                if(size > 0)
                {
                        // TODO
                        /*uint q = Math.DivRem(size, PLNOOFNMHAL);
                        for(int i = 0; i < size; i++)
                        {
                                q = q * GELENHPBKFA + DLDLDGJEOJG;
                                DBBGALAPFGC[i] = GPGMEAPLJAI_Key[q & 0x3ff] ^ DBBGALAPFGC[i];
                        }*/
                }
        }

        public BEEINMBNKNM_Encryption()
        { 
                // TODO
                KNEFBLHBDBG = 0x15ab17a1;
                PMBEODGMMBB = 0x15ab17a1;
                GELENHPBKFA = 0x1;
                DLDLDGJEOJG = 0x7; // inversed ?
                GPGMEAPLJAI_Key = new byte[1024];
                PLNOOFNMHAL = 1;
        }
}
