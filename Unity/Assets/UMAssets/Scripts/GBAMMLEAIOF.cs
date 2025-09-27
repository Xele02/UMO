using System.Text;

public class GBAMMLEAIOF
{
	private const int FBGGEFFJJHB_xor = 23;
	public byte[] EJJEHEHFMGO; // 0x8
	public int PGEDKFOIPIP_EventIdx; // 0xC

	// // RVA: 0x1401894 Offset: 0x1401894 VA: 0x1401894
	public void KHEKNNFCAOI_Init(int _PGEDKFOIPIP_EventIdx, byte[] _IDLHJIOMJBK_data)
	{
		EJJEHEHFMGO = _IDLHJIOMJBK_data;
		this.PGEDKFOIPIP_EventIdx = _PGEDKFOIPIP_EventIdx;
		for(int i = 0; i < _IDLHJIOMJBK_data.Length; i++)
		{
			EJJEHEHFMGO[i] = (byte)(EJJEHEHFMGO[i] ^ 0x17);
			_IDLHJIOMJBK_data = EJJEHEHFMGO;
		}
	}

	// // RVA: 0x1401938 Offset: 0x1401938 VA: 0x1401938
	public void KHEKNNFCAOI_Init(int _PGEDKFOIPIP_EventIdx, EDOHBJAPLPF_JsonData AAEDAEHIONI, KIJECNFNNDB_JsonWriter LAFGAPBDKML)
	{
		LAFGAPBDKML.LCABGAFGNFL_Reset();
		IKPIMINCOPI_JsonMapper.EJCOJCGIBNG_ToJson(AAEDAEHIONI, LAFGAPBDKML);
		KHEKNNFCAOI_Init(_PGEDKFOIPIP_EventIdx, Encoding.UTF8.GetBytes(LAFGAPBDKML.ToString()));
	}

	// // RVA: 0x1401A54 Offset: 0x1401A54 VA: 0x1401A54
	public void KHEKNNFCAOI_Init(int _PGEDKFOIPIP_EventIdx, byte[] _IDLHJIOMJBK_data, int _POMLAOPLMNA_offset, int MOIECBABHNP)
    {
        this.PGEDKFOIPIP_EventIdx = _PGEDKFOIPIP_EventIdx;
        EJJEHEHFMGO = new byte[MOIECBABHNP];
        for(int i = 0; i < MOIECBABHNP; i++)
        {
            EJJEHEHFMGO[i] = _IDLHJIOMJBK_data[i + _POMLAOPLMNA_offset];
        }
    }

	// // RVA: 0x1401B74 Offset: 0x1401B74 VA: 0x1401B74
	public string HGJLBEBNMIP_LogData()
	{
		byte[] data = new byte[EJJEHEHFMGO.Length];
		for(int i = 0; i < data.Length; i++)
		{
			data[i] = (byte)(EJJEHEHFMGO[i] ^ 0x17);
		}
		return Encoding.UTF8.GetString(data);
	}
}
