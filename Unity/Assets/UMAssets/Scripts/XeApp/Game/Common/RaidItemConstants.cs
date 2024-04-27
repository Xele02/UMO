
namespace XeApp.Game.Common
{
	public static class RaidItemConstants
	{
		public enum Type
		{
			FoldRadar = 1,
			ApHealS = 2,
			ApHealL = 3,
			_maxId = 4,
		}

		public const int TYPE_COUNT = 3;

		// RVA: 0x138A438 Offset: 0x138A438 VA: 0x138A438
		public static int MakeItemId(Type type)
		{
			return EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.CFLFPPDMFAE_RaidItem, (int)type);
		}
	}
}
