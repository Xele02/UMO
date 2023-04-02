
using System;
using System.Collections.Generic;

public class ONFFFKPFFGI
{
    public class ABBFICCGNOG
    {
        public int DCHDFOIHMJL { get; set; } // 0x8 JCFBBPFEJCM KEKOIPNPPFP DJDJGHIJDDK
    }

	private PLLMDGNCGFL JADNGGIOOJH = new PLLMDGNCGFL(); // 0x8
	private List<ABBFICCGNOG> LMMLAMKOAKA = new List<ABBFICCGNOG>(); // 0xC
	private long CDCKLGCKHFG; // 0x10

	// public List<ABBFICCGNOG> FPCLGFKEEFE { get; } 0xCAE5D8

	// RVA: 0xCAE5E0 Offset: 0xCAE5E0 VA: 0xCAE5E0
	public void KHEKNNFCAOI()
    {
        JADNGGIOOJH.PCODDPDFLHK();
        BJLEOACLGBO();
    }

	// // RVA: 0xCAE618 Offset: 0xCAE618 VA: 0xCAE618
	private void BJLEOACLGBO()
    {
        long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
        CDCKLGCKHFG = JPAICCMDGHD(time);
        LMMLAMKOAKA.Clear();
        for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MLGEHCJPAFB_RichBanner.CDENCMNHNGA.Count; i++)
        {
            JKMLBONMAHD_RichBanner.OIDOINPHPOE dbRich = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MLGEHCJPAFB_RichBanner.CDENCMNHNGA[i];
            if(dbRich.PPEGAKEIEGM_Enabled > 1)
            {
                if(CDCKLGCKHFG < dbRich.PDBPFJJCADD && time >= dbRich.PDBPFJJCADD)
                {
                    if(dbRich.FDBNFFNFOND >= time)
                    {
                        if(dbRich.FJOLNJLLJEJ <= CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KIECDDFNCAN_Level)
                        {
                            ABBFICCGNOG data = new ABBFICCGNOG();
                            data.DCHDFOIHMJL = dbRich.KNHOMNONOEB;
                            LMMLAMKOAKA.Add(data);
                        }
                    }
                }
            }
        }
        CDCKLGCKHFG = time;
        JADNGGIOOJH.KOGBMDOONFA.NPDKEIIMCDI = time;
    }

	// // RVA: 0xCAEA18 Offset: 0xCAEA18 VA: 0xCAEA18
	private long JPAICCMDGHD(long JHNMKKNEENE)
    {
        long t = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.FMBNOBGLMKB_RichbannerLastShowTime;
        long t2 = Math.Max(t, JADNGGIOOJH.KOGBMDOONFA.NPDKEIIMCDI);
        if(JHNMKKNEENE < t2)
        {
            return 0;
        }
        return t2;
    }

	// // RVA: 0xCAEBB0 Offset: 0xCAEBB0 VA: 0xCAEBB0
	// public void HJMKBCFJOOH() { }
}
