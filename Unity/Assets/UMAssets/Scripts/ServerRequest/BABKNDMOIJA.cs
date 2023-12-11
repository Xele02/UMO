
using System.Collections.Generic;
using UnityEngine;

public class BABKNDMOIJA : CACGCMBKHDI_Request
{
	public class IMNICDGDCBB
	{
		public int NPMIJMFMEKB; // 0x8
		public int NEILEPPJKIN; // 0xC
		public long IFNLEKOILPM; // 0x10

		// RVA: 0xF13EE0 Offset: 0xF13EE0 VA: 0xF13EE0
		//public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK) { }
	}

	public class FCIINFAOJPO
	{
		public List<IMNICDGDCBB> HBOIBKJEIAP; // 0x8

		// RVA: 0xF13E50 Offset: 0xF13E50 VA: 0xF13E50
		//public void KHEKNNFCAOI(EDOHBJAPLPF IDLHJIOMJBK) { }
	}

	public const int HDJIHPCCJAF = 0;
	public const int NHJPNAACGLK = 1;
	public List<int> FAMHAPONILI; // 0x7C
	public int NEILEPPJKIN = 1; // 0x80

	public FCIINFAOJPO NFEAMMJIMPG { get; private set; } // 0x84 OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	// RVA: 0xF13C5C Offset: 0xF13C5C VA: 0xF13C5C Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoFriend.SetFriendsFavoriteValue(FAMHAPONILI.ToArray(), NEILEPPJKIN, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0xF13D80 Offset: 0xF13D80 VA: 0xF13D80 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		NFEAMMJIMPG = new FCIINFAOJPO();
	}
}
