using System.Reflection;
using UnityEngine;

public class AnimeCurveScriptableObject : ScriptableObject
{
	[SerializeField]
	private AnimationCurve[] m_curve = new AnimationCurve[0]; // 0xC

	public AnimationCurve this[int key] { get { return m_curve[key]; } set { m_curve[key] = value; } } //0xD647A4 0xD647EC
	public int Count { get { return m_curve.Length; } } //0xD64868
}
