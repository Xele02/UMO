
using System.Collections;

public abstract class IHFBKJMNIPH<ActionClass> where ActionClass : CACGCMBKHDI_Request
{
	public bool NPNNPNAIONN; // 0x0

	//// RVA: -1 Offset: -1 Slot: 4
	protected virtual void LJDCONBNPBM_Initialize()
	{
		return;
	}
	///* GenericInstMethod :
	//|
	//|-RVA: 0x26C1ADC Offset: 0x26C1ADC VA: 0x26C1ADC
	//|-IHFBKJMNIPH<object>.LJDCONBNPBM
	//*/

	//// RVA: -1 Offset: -1 Slot: 5
	protected abstract ActionClass JIJACMIFOMB_OnStartAction(PJKLMCGEJMK _CPHFEPHDJIB_ServerRequester);
	///* GenericInstMethod :
	//|
	//|-RVA: -1 Offset: -1
	//|-IHFBKJMNIPH<object>.JIJACMIFOMB
	//*/

	//// RVA: -1 Offset: -1 Slot: 6
	protected abstract bool IMOEHHBDHGN_ContinueAction();
	///* GenericInstMethod :
	//|
	//|-RVA: -1 Offset: -1
	//|-IHFBKJMNIPH<object>.IMOEHHBDHGN
	//*/

	//// RVA: -1 Offset: -1
	//public void LAOEGNLOJHC(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK MOBEEPPKFLG) { }
	///* GenericInstMethod :
	//|
	//|-RVA: 0x26C1AE0 Offset: 0x26C1AE0 VA: 0x26C1AE0
	//|-IHFBKJMNIPH<object>.LAOEGNLOJHC
	//*/

	//[IteratorStateMachineAttribute] // RVA: 0x6C3E78 Offset: 0x6C3E78 VA: 0x6C3E78
	//// RVA: -1 Offset: -1
	public IEnumerator MEGIEMBDGBE_Coroutine(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK MOBEEPPKFLG)
	{
		PJKLMCGEJMK OKDOIAEGADK;
		ActionClass DLOIHKKKNBB_Request;

		//0x26C180C
		NPNNPNAIONN = false;
		LJDCONBNPBM_Initialize();
		OKDOIAEGADK = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester;
		while (true)
		{
			DLOIHKKKNBB_Request = JIJACMIFOMB_OnStartAction(OKDOIAEGADK);
			// LAB_026c193c
			while (!DLOIHKKKNBB_Request.PLOOEECNHFB_IsDone)
				yield return null;
			if(DLOIHKKKNBB_Request.NPNNPNAIONN_IsError)
			{
				NPNNPNAIONN = true;
				if (MOBEEPPKFLG != null)
					MOBEEPPKFLG();
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
	//|-IHFBKJMNIPH<DKFCEGODKFJ_GetPlayerCounters>.MEGIEMBDGBE
	//|-IHFBKJMNIPH<LNGMNNNJBJP>.MEGIEMBDGBE
	//|-IHFBKJMNIPH<object>.MEGIEMBDGBE
	//*/
}
