
[System.Obsolete("Use AIBFEFOFMFK_LineLinkage", true)]
public class AIBFEFOFMFK { }
public class AIBFEFOFMFK_LineLinkage : AILHMHMOKKA_BaseLinkage
{
	private const int JGFDMBLDIGP_LineVersion = 1;

	//// RVA: 0xCCA700 Offset: 0xCCA700 VA: 0xCCA700 Slot: 4
	public override void EMKKJILHOOB_GetLinkageStatus(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		JEDJNIKPFLH_IsLinked = false;
		MOJEDCPFGJJ_IsVersionOk = false;
		LNBLBFPAKPP_GetLineLinkageStatus req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new LNBLBFPAKPP_GetLineLinkageStatus());
		req.ICDEFIIADDO_Timeout = 15;
		req.NBFDEFGFLPJ = DGLAMLJFEDB_CheckError;
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0xCCB0D4
			LNBLBFPAKPP_GetLineLinkageStatus r = JIPCHHHLOMM as LNBLBFPAKPP_GetLineLinkageStatus;
			JEDJNIKPFLH_IsLinked = r.NFEAMMJIMPG_Result.EFKMIECABBK_LineLinkage;
			if (r.NFEAMMJIMPG_Result.OOOIPFEGKFD_Version == JGFDMBLDIGP_LineVersion)
				MOJEDCPFGJJ_IsVersionOk = true;
			_BHFHGFKBOHH_OnSuccess();
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0xCCB418
			TodoLogger.LogError(TodoLogger.RequestFail, "MOBEEPPKFLG_OnFail");
		};
	}

	//// RVA: 0xCCA99C Offset: 0xCCA99C VA: 0xCCA99C Slot: 5
	public override void GGNBIHHFJMP(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		OMOHMPMNOJG req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new OMOHMPMNOJG());
		req.ICDEFIIADDO_Timeout = 15;
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0xCCB600
			JEDJNIKPFLH_IsLinked = true;
			MOJEDCPFGJJ_IsVersionOk = false;
			_BHFHGFKBOHH_OnSuccess();
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0xCCB668
			if (!JIPCHHHLOMM.PDAPLCPOCMA)
			{
				if (DGLAMLJFEDB_CheckError(JIPCHHHLOMM.CJMFJOMECKI_ErrorId))
				{
					FFGPDGJNCOO = true;
				}
				else
				{
					if (!HGOKJBPIDJB(JIPCHHHLOMM))
					{
						_AOCANKOMKFG_OnError();
						return;
					}
				}
				NIMPEHIECJH();
				return;
			}
			_AOCANKOMKFG_OnError();
		};
	}

	//// RVA: 0xCCABE4 Offset: 0xCCABE4 VA: 0xCCABE4 Slot: 6
	public override void MOHPODEDIEK(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		HJMMIMBMFFP req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new HJMMIMBMFFP());
		req.ICDEFIIADDO_Timeout = 15;
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0xCCB770
			JEDJNIKPFLH_IsLinked = false;
			MOJEDCPFGJJ_IsVersionOk = false;
			_BHFHGFKBOHH_OnSuccess();
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0xCCB7D4
			if (!JIPCHHHLOMM.PDAPLCPOCMA)
			{
				if(DGLAMLJFEDB_CheckError(JIPCHHHLOMM.CJMFJOMECKI_ErrorId))
				{
					FFGPDGJNCOO = true;
				}
				else
				{
					if(!HGOKJBPIDJB(JIPCHHHLOMM))
					{
						_AOCANKOMKFG_OnError();
						return;
					}
				}
				NIMPEHIECJH();
				return;
			}
			_AOCANKOMKFG_OnError();
		};
	}

	//// RVA: 0xCCAE2C Offset: 0xCCAE2C VA: 0xCCAE2C Slot: 7
	public override void BMJMJCIKALP(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		MOJEDCPFGJJ_IsVersionOk = false;
		AOODABADOGG req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new AOODABADOGG());
		req.ICDEFIIADDO_Timeout = 15;
		req.NBFDEFGFLPJ = NPOAJHCHJGF;
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0xCCB8DC
			NKGJPJPHLIF.HHCJCDFCLOB.IJMGMJHLGDG((JIPCHHHLOMM as AOODABADOGG).NFEAMMJIMPG_Result.EHGBICNIBKE_player_id);
			_BHFHGFKBOHH_OnSuccess();
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0xCCBAFC
			if(JIPCHHHLOMM.PDAPLCPOCMA)
			{
				_AOCANKOMKFG_OnError();
				return;
			}
			if (DGLAMLJFEDB_CheckError(JIPCHHHLOMM.CJMFJOMECKI_ErrorId))
			{
				FFGPDGJNCOO = true;
			}
			else
			{
				if (JIPCHHHLOMM.CJMFJOMECKI_ErrorId == SakashoErrorId.PLAYER_NOT_FOUND)
				{
					HLOKAOHAMNC(NIMPEHIECJH, "LINE");
					return;
				}
				if(!HGOKJBPIDJB(JIPCHHHLOMM))
				{
					_AOCANKOMKFG_OnError();
					return;
				}
			}
			NIMPEHIECJH();
		};
	}
}
