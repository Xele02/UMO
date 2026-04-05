
[System.Obsolete("Use MBMENEIFOJC_TwitterLinkage", true)]
public class MBMENEIFOJC { }
public class MBMENEIFOJC_TwitterLinkage : AILHMHMOKKA_BaseLinkage
{
	//// RVA: 0xA306B4 Offset: 0xA306B4 VA: 0xA306B4 Slot: 4
	public override void EMKKJILHOOB_GetLinkageStatus(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		JEDJNIKPFLH_IsLinked = false;
		DKIAFKAJMED_GetTwitterLinkageStatus req = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new DKIAFKAJMED_GetTwitterLinkageStatus());
		req.ICDEFIIADDO_Timeout = 15;
		req.NBFDEFGFLPJ = DGLAMLJFEDB_CheckError;
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction JIPCHHHLOMM) =>
		{
			//0x130B038
			DKIAFKAJMED_GetTwitterLinkageStatus r = JIPCHHHLOMM as DKIAFKAJMED_GetTwitterLinkageStatus;
			JEDJNIKPFLH_IsLinked = r.NFEAMMJIMPG_Result.MKHDOLLACEF_TwitterLinkage;
			_BHFHGFKBOHH_OnSuccess();
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction JIPCHHHLOMM) =>
		{
			//0x130B210
			if(!JIPCHHHLOMM.PDAPLCPOCMA)
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

	//// RVA: 0xA30948 Offset: 0xA30948 VA: 0xA30948 Slot: 5
	public override void GGNBIHHFJMP(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		LPBHOHLHABF req = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new LPBHOHLHABF());
		req.ICDEFIIADDO_Timeout = 15;
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction JIPCHHHLOMM) =>
		{
			//0x130B31C
			JEDJNIKPFLH_IsLinked = true;
			_BHFHGFKBOHH_OnSuccess();
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction JIPCHHHLOMM) =>
		{
			//0x130B368
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

	//// RVA: 0xA30B88 Offset: 0xA30B88 VA: 0xA30B88 Slot: 6
	public override void MOHPODEDIEK(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		GJFPPCOFEOF req = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new GJFPPCOFEOF());
		req.ICDEFIIADDO_Timeout = 15;
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction JIPCHHHLOMM) =>
		{
			//0x130B474
			JEDJNIKPFLH_IsLinked = false;
			FFGPDGJNCOO = false;
			_BHFHGFKBOHH_OnSuccess();
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction JIPCHHHLOMM) =>
		{
			//0x130B4D8
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

	//// RVA: 0xA30DC8 Offset: 0xA30DC8 VA: 0xA30DC8 Slot: 7
	public override void BMJMJCIKALP(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		NHNEDAOHCKA req = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new NHNEDAOHCKA());
		req.ICDEFIIADDO_Timeout = 15;
		req.NBFDEFGFLPJ = NPOAJHCHJGF;
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction JIPCHHHLOMM) =>
		{
			//0x130B5E4
			NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IJMGMJHLGDG((JIPCHHHLOMM as NHNEDAOHCKA).NFEAMMJIMPG_Result.EHGBICNIBKE_player_id);
			_BHFHGFKBOHH_OnSuccess();
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction JIPCHHHLOMM) =>
		{
			//0x130B804
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
						HLOKAOHAMNC(NIMPEHIECJH, "Twitter");
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
			}
			_AOCANKOMKFG_OnError();
		};
	}
}
