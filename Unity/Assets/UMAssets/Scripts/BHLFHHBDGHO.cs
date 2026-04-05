public class BHLFHHBDGHO
{

	// RVA: 0xC7F450 Offset: 0xC7F450 VA: 0xC7F450
	public static void GEJEDJNKBOF_Validate(string CFIAJGOIOOC, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK FKKBDDDJKFB, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		CDDNGKNGPDP_NgWordsValidate req = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new CDDNGKNGPDP_NgWordsValidate());
		req.LGFLNOJDHHC_Targets["word"] = CFIAJGOIOOC;
		req.NBFDEFGFLPJ = (SakashoErrorId _CNAIDEAFAAM_Error) =>
		{
			//0xC7F7E4
			return _CNAIDEAFAAM_Error == SakashoErrorId.INCLUDED_NG_WORDS;
		};
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction JIPCHHHLOMM) =>
		{
			//0xC7F7F4
			_BHFHGFKBOHH_OnSuccess();
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction JIPCHHHLOMM) =>
		{
			//0xC7F820
			if(JIPCHHHLOMM.CJMFJOMECKI_ErrorId != SakashoErrorId.INCLUDED_NG_WORDS)
			{
				_AOCANKOMKFG_OnError();
				return;
			}
			JHHBAFKMBDL_NetUIControl.HHCJCDFCLOB_Instance.HNGIOFBLLDA(FKKBDDDJKFB);
		};
	}
}
