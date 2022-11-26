using UnityEngine;
public static class TodoLogger
{
	public static int MinLog = -9999;
	public static void Log(int priority, string str)
	{
		if(priority < MinLog)
		{
			UnityEngine.Debug.LogError(str);
		}
	}
}
