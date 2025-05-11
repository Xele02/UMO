
using System;
using System.Collections.Generic;
using UnityEngine;

public static class EFMIBOEJBCD // TypeDefIndex: 10557
{
	// RVA: -1 Offset: -1
	public static void MAECPJAJNBO<T>(this List<T> CNHEPCPELGK, GIINMFDIIMD CDGMPGLAING, Func<GIINMFDIIMD, T> LOPKBLOAGGE)
    {
        CNHEPCPELGK.Clear();
        if(CDGMPGLAING != null)
        {
            CNHEPCPELGK.Capacity = CDGMPGLAING.DLENPPIJNPA.HNBFOAJIIAL_Count;
            for(int i = 0; i < CNHEPCPELGK.Capacity; i++)
            {
                CNHEPCPELGK.Add(LOPKBLOAGGE(BDLAFAPDOJE.PFBEBCDEIND(CDGMPGLAING.DLENPPIJNPA, i)));
            }
        }
    }
	/* GenericInstMethod :
	|
	|-RVA: 0x1C786DC Offset: 0x1C786DC VA: 0x1C786DC
	|-EFMIBOEJBCD.MAECPJAJNBO<ENBPNDFOOCK.FHFAAOMLEPF.EPKECJKFKJH>
	|-EFMIBOEJBCD.MAECPJAJNBO<ENBPNDFOOCK.FHFAAOMLEPF.GHPAICMBHNJ>
	|-EFMIBOEJBCD.MAECPJAJNBO<JKCDLPOPCGC.CEHKLJKGJPI.BJIJAEOEHBJ>
	|-EFMIBOEJBCD.MAECPJAJNBO<JPPCMHKHAGC.ODNJNIICCLB.GKIJMGEBIDG>
	|-EFMIBOEJBCD.MAECPJAJNBO<NCMFOICNJEB<EBHIMFFJBIJ>>
	|-EFMIBOEJBCD.MAECPJAJNBO<object>
	*/
}

[System.Obsolete("Use EAOJEDAEIJN_GetMyRaidbosses", true)]
public class EAOJEDAEIJN {}
public class EAOJEDAEIJN_GetMyRaidbosses : CACGCMBKHDI_Request
{
    public class AGCEDCMMMHH
    {
        public List<NCMFOICNJEB<EBHIMFFJBIJ>> DKNENAKHNAP = new List<NCMFOICNJEB<EBHIMFFJBIJ>>(); // 0x8

        // RVA: 0x14F5DBC Offset: 0x14F5DBC VA: 0x14F5DBC
        public AGCEDCMMMHH(EDOHBJAPLPF_JsonData DLENPPIJNPA)
        {
            DKNENAKHNAP.MAECPJAJNBO(DLENPPIJNPA.PFBEBCDEIND("raidbosses"), (GIINMFDIIMD OFLLABBNCEA) =>
            {
                //0x14F606C
                return new NCMFOICNJEB<EBHIMFFJBIJ>(OFLLABBNCEA, (GIINMFDIIMD NKDGDKKEPOO) =>
                {
                    //0x14F61D0
                    return new EBHIMFFJBIJ(NKDGDKKEPOO);
                });
            });
        }
    }

	public AGCEDCMMMHH NFEAMMJIMPG; // 0x7C

	// RVA: 0x14F5C24 Offset: 0x14F5C24 VA: 0x14F5C24 Slot: 12
	public override void DHLDNIEELHO()
    {
        EBGACDGNCAA_CallContext = SakashoRaidboss.GetMyRaidbosses(DCKLDDCAJAP, MEOCKCJBDAD);
    }

	// RVA: 0x14F5D00 Offset: 0x14F5D00 VA: 0x14F5D00 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
    {
        NFEAMMJIMPG = new AGCEDCMMMHH(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
    }
}
