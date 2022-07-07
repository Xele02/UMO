namespace XeApp.Game.Common
{
	public class SeriesAttr
	{
		public enum Type
		{
			None = 0,
			Delta = 1,
			Frontia = 2,
			Seven = 3,
			First = 4,
			Plus = 5,
			Num = 6,
			Illegal = 7,
		}

		private static readonly SeriesAttr.Type[] tbl = new SeriesAttr.Type[11] { 13C46555F6180D443804482D835A8B2F937C08C0 }; // 0x0

		// RVA: 0x1391FEC Offset: 0x1391FEC VA: 0x1391FEC
		public static SeriesAttr.Type ConvertFromLogoId(SeriesLogoId.Type logo)
		{
			return tbl[(int)logo];
		}

		// RVA: 0x13920B0 Offset: 0x13920B0 VA: 0x13920B0
		//public static bool ValidateSeriesAttr(SeriesAttr.Type type) { }
	}
}
