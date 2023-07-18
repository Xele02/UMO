
namespace XeApp.Game.Common
{
	public static class LimitedCompoItemCompoConstants
	{
		// RVA: 0x1109D78 Offset: 0x1109D78 VA: 0x1109D78
		public static int MakeItemId(LimitedCompoContentsId itemId)
		{
			return EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.CKCPFLDGILD_LimitedCompoItem, (int)itemId);
		}
	}

	public enum LimitedCompoItemId
	{
		SkipTicket = 1,
		_maxId = 2,
	}

	public enum LimitedCompoContentsId
	{
		NormalSkipTicket = 1,
		LimitedSkipTicket = 2,
		_maxId = 3,
	}

	public enum Condition
	{
		None = 0,
		SpecialPass = 1,
	}
}
