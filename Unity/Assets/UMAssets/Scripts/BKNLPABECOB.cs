

[System.Obsolete("Use BKNLPABECOB_FacebookLinkage", true)]
public class BKNLPABECOB { }
public class BKNLPABECOB_FacebookLinkage : AILHMHMOKKA_BaseLinkage
{
	private string NOBJMCIIHKO; // 0xC

	//// RVA: 0xC890E0 Offset: 0xC890E0 VA: 0xC890E0 Slot: 4
	public override void EMKKJILHOOB_GetLinkageStatus(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		JEDJNIKPFLH_IsLinked = false;
		NCBEKFBAFCL_GetFacebookLinkageStatus req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new NCBEKFBAFCL_GetFacebookLinkageStatus());
		req.ICDEFIIADDO_Timeout = 15;
		req.NBFDEFGFLPJ = DGLAMLJFEDB_CheckError;
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0xC89A84
			NCBEKFBAFCL_GetFacebookLinkageStatus r = JIPCHHHLOMM as NCBEKFBAFCL_GetFacebookLinkageStatus;
			JEDJNIKPFLH_IsLinked = r.NFEAMMJIMPG_Result.EMEGKEGFJBK_facebook_linkage;
			_BHFHGFKBOHH_OnSuccess();
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0xC89C5C
			TodoLogger.LogError(TodoLogger.RequestFail, "MOBEEPPKFLG_OnFail");
		};
	}

	//// RVA: 0xC8935C Offset: 0xC8935C VA: 0xC8935C Slot: 5
	public override void GGNBIHHFJMP(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		NPPLCKMKIFE req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new NPPLCKMKIFE());
		req.ICDEFIIADDO_Timeout = 15;
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0xC89D3C
			JEDJNIKPFLH_IsLinked = true;
			_BHFHGFKBOHH_OnSuccess();
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0xC89D88
			if (!JIPCHHHLOMM.PDAPLCPOCMA)
			{
				if (DGLAMLJFEDB_CheckError(JIPCHHHLOMM.CJMFJOMECKI_ErrorId))
					FFGPDGJNCOO = true;
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

	//// RVA: 0xC895A4 Offset: 0xC895A4 VA: 0xC895A4 Slot: 6
	public override void MOHPODEDIEK(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		NIAECEJLJKH req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new NIAECEJLJKH());
		req.ICDEFIIADDO_Timeout = 15;
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0xC89E8C
			JEDJNIKPFLH_IsLinked = false;
			_BHFHGFKBOHH_OnSuccess();
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0xC89ED8
			if(!JIPCHHHLOMM.PDAPLCPOCMA)
			{
				if (DGLAMLJFEDB_CheckError(JIPCHHHLOMM.CJMFJOMECKI_ErrorId))
					FFGPDGJNCOO = true;
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

	//// RVA: 0xC897EC Offset: 0xC897EC VA: 0xC897EC Slot: 7
	public override void BMJMJCIKALP(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		ANLMHAMGJHP req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new ANLMHAMGJHP());
		req.ICDEFIIADDO_Timeout = 15;
		req.NBFDEFGFLPJ = NPOAJHCHJGF;
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0xC89FDC
			NKGJPJPHLIF.HHCJCDFCLOB.IJMGMJHLGDG((JIPCHHHLOMM as ANLMHAMGJHP).NFEAMMJIMPG_Result.EHGBICNIBKE_player_id);
			_BHFHGFKBOHH_OnSuccess();
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0xC8A1FC
			if(!JIPCHHHLOMM.PDAPLCPOCMA)
			{
				if(DGLAMLJFEDB_CheckError(JIPCHHHLOMM.CJMFJOMECKI_ErrorId))
				{
					FFGPDGJNCOO = true;
				}
				else
				{
					if(JIPCHHHLOMM.CJMFJOMECKI_ErrorId == SakashoErrorId.PLAYER_NOT_FOUND)
					{
						HLOKAOHAMNC(NIMPEHIECJH, "Facebook");
						return;
					}
					if(!HGOKJBPIDJB(JIPCHHHLOMM))
					{
						if (_AOCANKOMKFG_OnError != null)
							_AOCANKOMKFG_OnError();
						return;
					}
				}
				NIMPEHIECJH();
				return;
			}
			if(_AOCANKOMKFG_OnError != null)
				_AOCANKOMKFG_OnError();
		};
	}
}
