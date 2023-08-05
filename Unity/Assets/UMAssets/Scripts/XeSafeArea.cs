using UnityEngine;

public class XeSafeArea
{
	// RVA: 0x2F94E90 Offset: 0x2F94E90 VA: 0x2F94E90
	public static Rect GetRect()
	{
		return new Rect(0, 0, Screen.width, Screen.height);
	}

	// RVA: 0x2F94EF4 Offset: 0x2F94EF4 VA: 0x2F94EF4
	public static Rect GetScreenArea()
    {
        return new Rect(0, 0, Screen.width, Screen.height);
    }
}
