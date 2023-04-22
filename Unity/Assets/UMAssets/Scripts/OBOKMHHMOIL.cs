
[System.Obsolete("Use OBOKMHHMOIL_ServerInfo", true)]
public class OBOKMHHMOIL { }
public class OBOKMHHMOIL_ServerInfo
{
	public string EBCFHFIOHBN_ServerCurrentMasterRevision; // 0x8
	public string AJBPBEALBOB_ServerCurrentAssetRevision; // 0xC
	public long LCAINKFINEI_ServerCurrentDateTime; // 0x10
	public string ABFADMDAAKJ_ServerRecommendedClientVersion; // 0x18

	// // RVA: 0x1B2B8E4 Offset: 0x1B2B8E4 VA: 0x1B2B8E4
	public void LHPDDGIJKNB_Reset()
    {
		ABFADMDAAKJ_ServerRecommendedClientVersion = null;
		EBCFHFIOHBN_ServerCurrentMasterRevision = null;
		AJBPBEALBOB_ServerCurrentAssetRevision = null;
		LCAINKFINEI_ServerCurrentDateTime = 0;
    }

	// // RVA: 0x1B2B8FC Offset: 0x1B2B8FC VA: 0x1B2B8FC
	public void ODDIHGPONFL_Copy(OBOKMHHMOIL_ServerInfo GPBJHKLFCEP)
    {
		LHPDDGIJKNB_Reset();
		if(GPBJHKLFCEP == null)
			return;
		if(GPBJHKLFCEP.EBCFHFIOHBN_ServerCurrentMasterRevision != null)
			EBCFHFIOHBN_ServerCurrentMasterRevision = GPBJHKLFCEP.EBCFHFIOHBN_ServerCurrentMasterRevision;
		if(GPBJHKLFCEP.AJBPBEALBOB_ServerCurrentAssetRevision != null)
			AJBPBEALBOB_ServerCurrentAssetRevision = GPBJHKLFCEP.AJBPBEALBOB_ServerCurrentAssetRevision;
		LCAINKFINEI_ServerCurrentDateTime = GPBJHKLFCEP.LCAINKFINEI_ServerCurrentDateTime;
		if(GPBJHKLFCEP.ABFADMDAAKJ_ServerRecommendedClientVersion != null)
			ABFADMDAAKJ_ServerRecommendedClientVersion = GPBJHKLFCEP.ABFADMDAAKJ_ServerRecommendedClientVersion;
    }

	// // RVA: 0x1B2B94C Offset: 0x1B2B94C VA: 0x1B2B94C
	public void KHEKNNFCAOI_Init(string HGAMEAPCKJL)
    {
		int idx = HGAMEAPCKJL.IndexOf(AFEHLCGHAEE_Strings.EBCFHFIOHBN_SakashoCurrentMasterRevision); // SAKASHO_CURRENT_MASTER_REVISION
		if(idx >= 0)
		{
			EBCFHFIOHBN_ServerCurrentMasterRevision = MBPLJOOMEBA(HGAMEAPCKJL, idx + AFEHLCGHAEE_Strings.EBCFHFIOHBN_SakashoCurrentMasterRevision.Length + 2);
		}
		idx = HGAMEAPCKJL.IndexOf(AFEHLCGHAEE_Strings.AJBPBEALBOB_SakashoCurrentAssetRevision); // SAKASHO_CURRENT_ASSET_REVISION
		if(idx >= 0)
		{
			AJBPBEALBOB_ServerCurrentAssetRevision  = PEMIFCIFEKK(HGAMEAPCKJL, idx + AFEHLCGHAEE_Strings.AJBPBEALBOB_SakashoCurrentAssetRevision.Length + 3);
		}
		idx = HGAMEAPCKJL.IndexOf(AFEHLCGHAEE_Strings.LCAINKFINEI_SakashoCurrentDateTime); // SAKASHO_CURRENT_DATE_TIME
		if(idx >= 0)
		{
			LCAINKFINEI_ServerCurrentDateTime  = System.Int32.Parse(MBPLJOOMEBA(HGAMEAPCKJL, idx + AFEHLCGHAEE_Strings.LCAINKFINEI_SakashoCurrentDateTime.Length + 2));
		}
		idx = HGAMEAPCKJL.IndexOf(AFEHLCGHAEE_Strings.ABFADMDAAKJ_SakashoRecommendedClientVersion); // SAKASHO_RECOMMENDED_CLIENT_VERSION
		if(idx >= 0)
		{
			ABFADMDAAKJ_ServerRecommendedClientVersion  = PEMIFCIFEKK(HGAMEAPCKJL, idx + AFEHLCGHAEE_Strings.ABFADMDAAKJ_SakashoRecommendedClientVersion.Length + 3);
		}
    }

	// // RVA: 0x1B2BD60 Offset: 0x1B2BD60 VA: 0x1B2BD60
	private string MBPLJOOMEBA(string HGAMEAPCKJL, int OIPCCBHIKIA)
	{
		int idx = 0;
		while(true)
		{
			if(HGAMEAPCKJL[OIPCCBHIKIA + idx] == ',' || HGAMEAPCKJL[OIPCCBHIKIA + idx] == '}')
				break;
			idx = idx + 1;
		}
		return HGAMEAPCKJL.Substring(OIPCCBHIKIA, idx);
	}

	// // RVA: 0x1B2BDD0 Offset: 0x1B2BDD0 VA: 0x1B2BDD0
	private string PEMIFCIFEKK(string HGAMEAPCKJL, int OIPCCBHIKIA)
	{
		int idx = 0;
		while(true)
		{
			if(HGAMEAPCKJL[OIPCCBHIKIA + idx] == '"')
				break;
			idx = idx + 1;
		}
		return HGAMEAPCKJL.Substring(OIPCCBHIKIA, idx);
	}
}
