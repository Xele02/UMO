
using System.Collections;

// namespace XeApp.Game.Net.Actions
[System.Obsolete()]
public abstract class IHFBKJMNIPH<ActionClass> where ActionClass : CACGCMBKHDI_NetBaseAction {}
public abstract class IHFBKJMNIPH_NetBaseLoopAction<ActionClass> where ActionClass : CACGCMBKHDI_NetBaseAction
{
	public bool NPNNPNAIONN_IsError; // 0x0

	//// RVA: -1 Offset: -1 Slot: 4
	protected virtual void LJDCONBNPBM_Initialize()
	{
		return;
	}
	///* GenericInstMethod :
	//|
	//|-RVA: 0x26C1ADC Offset: 0x26C1ADC VA: 0x26C1ADC
	//|-IHFBKJMNIPH_NetBaseLoopAction<object>.LJDCONBNPBM_Initialize
	//*/

	//// RVA: -1 Offset: -1 Slot: 5
	protected abstract ActionClass JIJACMIFOMB_OnStartAction(PJKLMCGEJMK_NetActionManager _CPHFEPHDJIB_ServerRequester);
	///* GenericInstMethod :
	//|
	//|-RVA: -1 Offset: -1
	//|-IHFBKJMNIPH_NetBaseLoopAction<object>.JIJACMIFOMB_OnStartAction
	//*/

	//// RVA: -1 Offset: -1 Slot: 6
	protected abstract bool IMOEHHBDHGN_ContinueAction();
	///* GenericInstMethod :
	//|
	//|-RVA: -1 Offset: -1
	//|-IHFBKJMNIPH_NetBaseLoopAction<object>.IMOEHHBDHGN_ContinueAction
	//*/

	//// RVA: -1 Offset: -1
	//public void LAOEGNLOJHC_Start(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail) { }
	///* GenericInstMethod :
	//|
	//|-RVA: 0x26C1AE0 Offset: 0x26C1AE0 VA: 0x26C1AE0
	//|-IHFBKJMNIPH_NetBaseLoopAction<object>.LAOEGNLOJHC_Start
	//*/

	//[IteratorStateMachineAttribute] // RVA: 0x6C3E78 Offset: 0x6C3E78 VA: 0x6C3E78
	//// RVA: -1 Offset: -1
	public IEnumerator MEGIEMBDGBE_Coroutine(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		PJKLMCGEJMK_NetActionManager OKDOIAEGADK_Server;
		ActionClass DLOIHKKKNBB_Request;

		//0x26C180C
		NPNNPNAIONN_IsError = false;
		LJDCONBNPBM_Initialize();
		OKDOIAEGADK_Server = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester;
		while (true)
		{
			DLOIHKKKNBB_Request = JIJACMIFOMB_OnStartAction(OKDOIAEGADK_Server);
			// LAB_026c193c
			while (!DLOIHKKKNBB_Request.PLOOEECNHFB_IsDone)
				yield return null;
			if(DLOIHKKKNBB_Request.NPNNPNAIONN_IsError)
			{
				NPNNPNAIONN_IsError = true;
				if (_MOBEEPPKFLG_OnFail != null)
					_MOBEEPPKFLG_OnFail();
				yield break;
			}
			if (!IMOEHHBDHGN_ContinueAction())
				break;
		}
		if (_BHFHGFKBOHH_OnSuccess != null)
			_BHFHGFKBOHH_OnSuccess();
	}
	///* GenericInstMethod :
	//|
	//|-RVA: 0x26C1B5C Offset: 0x26C1B5C VA: 0x26C1B5C
	//|-IHFBKJMNIPH_NetBaseLoopAction<DKFCEGODKFJ_GetPlayerCounters>.MEGIEMBDGBE_Coroutine
	//|-IHFBKJMNIPH_NetBaseLoopAction<LNGMNNNJBJP_SearchForPlayer>.MEGIEMBDGBE_Coroutine
	//|-IHFBKJMNIPH_NetBaseLoopAction<object>.MEGIEMBDGBE_Coroutine
	//*/
}
