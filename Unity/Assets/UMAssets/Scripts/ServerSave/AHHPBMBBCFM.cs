
using System.Collections.Generic;
using XeApp.Game.Menu;
using XeSys;

[System.Obsolete("Use AHHPBMBBCFM_DecoPrivateSet", true)]
public class AHHPBMBBCFM { }
public class AHHPBMBBCFM_DecoPrivateSet : KLFDBFMNLBL_ServerSaveBlock
{
	private const int ECFEMKGFDCE = 1;
	public const int FIKANMEAEIF = 5;
	public const int CAHJOIDBJDJ = 5;
	public List<DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN> JBJHCJFOICD = new List<DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN>(); // 0x24
	private int ENOBDCFHELD; // 0x28
	private int FCEJCHGLFGN; // 0x2C

	public override bool DMICHEJIAJL { get { return true; } } // 0x15C8378 NFKFOODCJJB

	// // RVA: 0x15C6EF8 Offset: 0x15C6EF8 VA: 0x15C6EF8
	public AHHPBMBBCFM_DecoPrivateSet()
	{
		LHPDDGIJKNB_Reset();
	}

	// // RVA: 0x15C6F90 Offset: 0x15C6F90 VA: 0x15C6F90 Slot: 4
	public override void KMBPACJNEOF()
	{
		ENOBDCFHELD = (int)(Utility.GetCurrentUnixTime() ^ 0x401d3c7);
		FCEJCHGLFGN = (int)(Utility.GetCurrentUnixTime() ^ 0x8f5f2da);
		JBJHCJFOICD.Clear();
		for(int i = 0; i < 5; i++)
		{
			JBJHCJFOICD.Add(new DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN());
		}
	}

	// // RVA: 0x15C70C0 Offset: 0x15C70C0 VA: 0x15C70C0 Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
		data2.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
		for(int i = 0; i < JBJHCJFOICD.Count; i++)
		{
			data2.Add(JBJHCJFOICD[i].OKJPIBHMKMJ());
		}
		data["set_arr"] = data2;
		if(!EMBGIDLFKGM)
		{
			EDOHBJAPLPF_JsonData tmp = new EDOHBJAPLPF_JsonData();
			tmp[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = MCKEOKFMLAH;
			tmp[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] = ECFEMKGFDCE;
			tmp[JIKKNHIAEKG_BlockName] = data;
			data = tmp;
		}
		else
		{
			OILEIIEIBHP = OILEIIEIBHP[AFEHLCGHAEE_Strings.JCIBKDHKNFH_alldata];
		}
		OILEIIEIBHP[JIKKNHIAEKG_BlockName] = data;
	}

	// // RVA: 0x15C7474 Offset: 0x15C7474 VA: 0x15C7474 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool blockMissing = false;
		bool isInvalid = false;
		EDOHBJAPLPF_JsonData block = LGPBAKLCFHI_FindAndCheckBlock(OILEIIEIBHP, ref blockMissing, ref isInvalid, 1);
		if (!blockMissing)
		{
			if (block == null)
			{
				isInvalid = true;
			}
			else
			{
				EDOHBJAPLPF_JsonData ar = block["set_arr"];
				int cnt = ar.HNBFOAJIIAL_Count;
				if(cnt > 6)
				{
					isInvalid = true;
					cnt = 5;
				}
				for(int i = 0; i < cnt; i++)
				{
					JBJHCJFOICD[i].IIEMACPEEBJ(ar[i], (EDOHBJAPLPF_JsonData JGNBPFCJLKI, string LJNAKDMILMC, int BAAPMIKMLPP) =>
					{
						//0x15C8380
						return CJAENOMGPDA_ReadInt(JGNBPFCJLKI, LJNAKDMILMC, BAAPMIKMLPP, ref isInvalid);
					}, (EDOHBJAPLPF_JsonData JGNBPFCJLKI, string LJNAKDMILMC, string EMOLDMOBKLM) =>
					{
						//0x15C83D8
						return FGCNMLBACGO_ReadString(JGNBPFCJLKI, LJNAKDMILMC, EMOLDMOBKLM, ref isInvalid);
					});
				}
			}
			KFKDMBPNLJK_BlockInvalid = isInvalid;
			return true;
		}
		return false;
	}

	// // RVA: 0x15C77EC Offset: 0x15C77EC VA: 0x15C77EC Slot: 7
	public override void BMGGKONLFIC(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		AHHPBMBBCFM_DecoPrivateSet other = GPBJHKLFCEP as AHHPBMBBCFM_DecoPrivateSet;
		for(int i = 0; i < JBJHCJFOICD.Count; i++)
		{
			JBJHCJFOICD[i].BMGGKONLFIC(other.JBJHCJFOICD[i]);
		}
	}

	// // RVA: 0x15C79C0 Offset: 0x15C79C0 VA: 0x15C79C0 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		AHHPBMBBCFM_DecoPrivateSet other = GPBJHKLFCEP as AHHPBMBBCFM_DecoPrivateSet;
		for(int i = 0; i < JBJHCJFOICD.Count; i++)
		{
			if(!JBJHCJFOICD[i].AGBOGBEOFME(other.JBJHCJFOICD[i]))
				return false;
		}
		return true;
	}

	// // RVA: 0x15C7BB0 Offset: 0x15C7BB0 VA: 0x15C7BB0 Slot: 10
	public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock GJLFANGDGCL, long MCKEOKFMLAH)
	{
		TodoLogger.LogError(0, "AGHKODFKOJI");
	}

	// // RVA: 0x15C8268 Offset: 0x15C8268 VA: 0x15C8268 Slot: 11
	public override FENCAJJBLBH PFAKPFKJJKA()
	{
		TodoLogger.LogError(0, "TODO");
		return null;
	}
}
