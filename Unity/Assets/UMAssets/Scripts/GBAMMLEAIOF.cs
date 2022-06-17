using System.Text;

public class GBAMMLEAIOF
{
	private const int FBGGEFFJJHB = 23;
	public byte[] EJJEHEHFMGO; // 0x8
	public int PGEDKFOIPIP; // 0xC

	// // RVA: 0x1401894 Offset: 0x1401894 VA: 0x1401894
	// public void KHEKNNFCAOI(int PGEDKFOIPIP, byte[] IDLHJIOMJBK) { }

	// // RVA: 0x1401938 Offset: 0x1401938 VA: 0x1401938
	// public void KHEKNNFCAOI(int PGEDKFOIPIP, EDOHBJAPLPF AAEDAEHIONI, KIJECNFNNDB LAFGAPBDKML) { }

	// // RVA: 0x1401A54 Offset: 0x1401A54 VA: 0x1401A54
	public void KHEKNNFCAOI(int PGEDKFOIPIP, byte[] IDLHJIOMJBK, int POMLAOPLMNA, int MOIECBABHNP)
    {
        this.PGEDKFOIPIP = PGEDKFOIPIP;
        EJJEHEHFMGO = new byte[MOIECBABHNP];
        for(int i = 0; i < MOIECBABHNP; i++)
        {
            EJJEHEHFMGO[i] = IDLHJIOMJBK[i + POMLAOPLMNA];
        }
    }

	// // RVA: 0x1401B74 Offset: 0x1401B74 VA: 0x1401B74
	public string HGJLBEBNMIP()
	{
		byte[] data = new byte[EJJEHEHFMGO.Length];
		for(int i = 0; i < data.Length; i++)
		{
			data[i] = EJJEHEHFMGO[i] ^ 0x17;
		}
		UnityEngine.Debug.LogError("Text result : " + Encoding.UTF8.GetString(data));
		return Encoding.UTF8.GetString(data);
	}
}
