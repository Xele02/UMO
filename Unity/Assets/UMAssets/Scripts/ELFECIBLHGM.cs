
using System.IO;

public class ELFECIBLHGM
{
    public class DFHIELOMEGA
    {
        private int FBGGEFFJJHB = 0x4617e65; // 0x8
        private long BHEHGCHGBDG = 0xa42143651a1c9f; // 0x10
        private long AKHADFNHCBJ; // 0x18

        public long MOBHLLDIMMN_LastShowDate { get { return AKHADFNHCBJ ^ BHEHGCHGBDG; } set { AKHADFNHCBJ = value ^ BHEHGCHGBDG; } } //0x1305560 KAFHGBHOHBM 0x1304EB4 DKHPNKJALPP

        // RVA: 0x1304EA8 Offset: 0x1304EA8 VA: 0x1304EA8
        // public void KHEKNNFCAOI() { }
    }

	public const int JNCCCCPBDIC = 2;
	private static DFHIELOMEGA KLGILMKOHOI = new DFHIELOMEGA(); // 0x0
	private static bool BAJPJGFOFIN = false; // 0x4
	private string ELLBAAFKDCH_FilePath; // 0x8

	// RVA: 0x1304800 Offset: 0x1304800 VA: 0x1304800
	public ELFECIBLHGM()
    {
        KHEKNNFCAOI();
    }

	// // RVA: 0x13048BC Offset: 0x13048BC VA: 0x13048BC
	// public void KHEKNNFCAOI(string CJEKGLGBIHF) { }

	// // RVA: 0x1304820 Offset: 0x1304820 VA: 0x1304820
	public void KHEKNNFCAOI()
    {
        ELLBAAFKDCH_FilePath = CJMOKHDNBNB.FIPFFELDIOG_PersistentPath + "/SaveData/ea0";
    }

	// // RVA: 0x13048C4 Offset: 0x13048C4 VA: 0x13048C4
	public DFHIELOMEGA PCODDPDFLHK()
    {
        KLGILMKOHOI.MOBHLLDIMMN_LastShowDate = 0;
        int a = -1;
        if(File.Exists(ELLBAAFKDCH_FilePath))
        {
            FileStream fs = new FileStream(ELLBAAFKDCH_FilePath, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            a = br.ReadInt32();
            if(a == 2)
            {
                KLGILMKOHOI.MOBHLLDIMMN_LastShowDate = br.ReadInt32();
            }
            br.Dispose();
            fs.Dispose();
        }
        return KLGILMKOHOI;
    }

	// // RVA: 0x1304ED4 Offset: 0x1304ED4 VA: 0x1304ED4
	// public bool HJMKBCFJOOH(bool FBBNPFFEJBN = False) { }

	// // RVA: 0x130557C Offset: 0x130557C VA: 0x130557C
	// public void JCHLONCMPAJ(bool OGBEGDKPDGK) { }

	// // RVA: 0x1305628 Offset: 0x1305628 VA: 0x1305628
	public bool JKHNJBFAFBL_SetLastShowDate(long KPBJHHHMOJE)
    {
        if(KPBJHHHMOJE != KLGILMKOHOI.MOBHLLDIMMN_LastShowDate)
        {
            KLGILMKOHOI.MOBHLLDIMMN_LastShowDate = KPBJHHHMOJE;
            BAJPJGFOFIN = true;
            return true;
        }
        return false;
    }

	// // RVA: 0x130577C Offset: 0x130577C VA: 0x130577C
	public long HFPEDBCGFOJ_GetLastShowDate()
    {
        return KLGILMKOHOI.MOBHLLDIMMN_LastShowDate;
    }

	// // RVA: 0x1305828 Offset: 0x1305828 VA: 0x1305828
	// public ELFECIBLHGM.DFHIELOMEGA GMOOGEHEPPH() { }

	// // RVA: 0x13058B4 Offset: 0x13058B4 VA: 0x13058B4
	// public bool CHFOOMPEABN() { }
}
