namespace XeApp.Game.RhythmGame
{
	public class RhythmGameCombo
	{
		private CEBFFLDKAEC_SecureInt current_ = new CEBFFLDKAEC_SecureInt(); // 0x8
		private LINJMMGGDKL_SecureInt2 record_ = new LINJMMGGDKL_SecureInt2(); // 0xC

		public int current { get { return current_.DNJEJEANJGL_Value; } set { current_.DNJEJEANJGL_Value = value; } } //0xDC3AB8 0xDC3AE4
		public int record { get { return record_.DNJEJEANJGL_Value; } set { record_.DNJEJEANJGL_Value = value; } } //0xDC3B18 0xDC3B44

		//// RVA: 0xDC3B78 Offset: 0xDC3B78 VA: 0xDC3B78
		//public FENCAJJBLBH CheckFalisification() { }

		//// RVA: 0xDC3BC0 Offset: 0xDC3BC0 VA: 0xDC3BC0
		public void Reset()
		{
			current = 0;
			record = 0;
		}

		//// RVA: 0xDC3BE4 Offset: 0xDC3BE4 VA: 0xDC3BE4
		//public void IncreaseCombo() { }

		//// RVA: 0xDC3C2C Offset: 0xDC3C2C VA: 0xDC3C2C
		//public void Zero() { }
	}
}
