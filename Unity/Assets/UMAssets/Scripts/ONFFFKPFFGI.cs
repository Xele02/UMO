
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

	public List<ABBFICCGNOG> FPCLGFKEEFE { get { return LMMLAMKOAKA; } } //0xCAE5D8 FPNPEAAPJCL

	// RVA: 0xCAE5E0 Offset: 0xCAE5E0 VA: 0xCAE5E0
	public void KHEKNNFCAOI_Init()
    {
        JADNGGIOOJH.PCODDPDFLHK();
        BJLEOACLGBO();
    }

	// // RVA: 0xCAE618 Offset: 0xCAE618 VA: 0xCAE618
	private void BJLEOACLGBO()
    {
        long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
        CDCKLGCKHFG = JPAICCMDGHD(time);
        LMMLAMKOAKA.Clear();
        for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MLGEHCJPAFB_RichBanner.CDENCMNHNGA_table.Count; i++)
        {
            JKMLBONMAHD_RichBanner.OIDOINPHPOE dbRich = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MLGEHCJPAFB_RichBanner.CDENCMNHNGA_table[i];
            if(dbRich.PPEGAKEIEGM_Enabled > 1)
            {
                if(CDCKLGCKHFG < dbRich.PDBPFJJCADD_open_at && time >= dbRich.PDBPFJJCADD_open_at)
                {
                    if(dbRich.FDBNFFNFOND_CloseAt >= time)
                    {
                        if(dbRich.FJOLNJLLJEJ_Rank <= CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.KIECDDFNCAN_Level)
                        {
                            ABBFICCGNOG data = new ABBFICCGNOG();
                            data.DCHDFOIHMJL = dbRich.KNHOMNONOEB_AssetId;
                            LMMLAMKOAKA.Add(data);
                        }
                    }
                }
            }
        }
        CDCKLGCKHFG = time;
        JADNGGIOOJH.KOGBMDOONFA_Info.NPDKEIIMCDI_LastShowtime = time;
    }

	// // RVA: 0xCAEA18 Offset: 0xCAEA18 VA: 0xCAEA18
	private long JPAICCMDGHD(long _JHNMKKNEENE_Time)
    {
        long t = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.FMBNOBGLMKB_RichbannerLastShowTime;
        long t2 = Math.Max(t, JADNGGIOOJH.KOGBMDOONFA_Info.NPDKEIIMCDI_LastShowtime);
        if(_JHNMKKNEENE_Time < t2)
        {
            return 0;
        }
        return t2;
    }

	// // RVA: 0xCAEBB0 Offset: 0xCAEBB0 VA: 0xCAEBB0
	public void HJMKBCFJOOH()
    {
        long t = JPAICCMDGHD(CDCKLGCKHFG);
        CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.FMBNOBGLMKB_RichbannerLastShowTime = t;
        JADNGGIOOJH.KOGBMDOONFA_Info.NPDKEIIMCDI_LastShowtime = t;
        JADNGGIOOJH.HJMKBCFJOOH();
    }
}
