
public class MFJONNINDCJ
{
	public string MKANHLNEEGL_filter; // 0x8
	public int ICKOHEDLEFP_ValueCrypted; // 0xC

	public int JBGEEPFKIGG_val { 
		get {
			// OLOCMINKGON 0x1315110
			return ICKOHEDLEFP_ValueCrypted ^ 0x164d06bb;
		}
		set {
			//ABAFHIBFKCE 0x1315124
			ICKOHEDLEFP_ValueCrypted = value ^ 0x164d06bb;
		}
	}
}
