using XeSys;
using System;

public class LGNBLDHKLJK
{
	private const int MBKBGBOEEHN = 86400;
	private const int BJFJAGGBFFE = 2;
	private long ABNEIOCBKPI; // 0x8
	public bool PPEGAKEIEGM = true; // 0x10

	// // RVA: 0x17F59C8 Offset: 0x17F59C8 VA: 0x17F59C8
	public void JOJFKIIHMOJ(long LKCCMBEOLLA)
    {
		DateTime date = Utility.GetLocalDateTime(LKCCMBEOLLA);
		ABNEIOCBKPI = Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, 0, 0, 0);
    }

	// // RVA: 0x17F5AE4 Offset: 0x17F5AE4 VA: 0x17F5AE4
	public bool LNLCIMPFCEK(long LKCCMBEOLLA)
	{
		if(!PPEGAKEIEGM || ABNEIOCBKPI == 0)
		{
			return false;
		}
		TodoLogger.Log(TodoLogger.ToCheck, "int64");
		return LKCCMBEOLLA >= ABNEIOCBKPI;
	}
}
