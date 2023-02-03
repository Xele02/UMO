
[System.Obsolete("Use JDEFIJBCJLC_EncryptedString", true)]
public class JDEFIJBCJLC { }
public class JDEFIJBCJLC_EncryptedString
{
	private byte[] DLHDPLPLCAC; // 0x8

	public string DNJEJEANJGL_Value { get
		{
			if(DLHDPLPLCAC != null)
			{
				return FFGBKEEIBNL.HKICMNAACDA(DLHDPLPLCAC);
			}
			return null;
			//JADLONAJDAK 0x1C32C68
		} set {
			//JFNEHIGOBHH 0x1C32C8C	
			if(value == null)
				DLHDPLPLCAC = null;
			else
			{
				DLHDPLPLCAC = CEDHHAGBIBA.IHDGCICCPIG_StringToByte(value);
			}
		} }

	// RVA: 0x1C32D28 Offset: 0x1C32D28 VA: 0x1C32D28
	//public uint CAOGDCBPBAN() { }

}
