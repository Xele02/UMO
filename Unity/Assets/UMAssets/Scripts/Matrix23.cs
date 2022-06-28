using System;

public struct Matrix23
{
	private const int ROW_NUM = 2;
	private const int COLUMN_NUM = 3;
	public float _00; // 0x0
	public float _01; // 0x4
	public float _02; // 0x8
	public float _10; // 0xC
	public float _11; // 0x10
	public float _12; // 0x14

	// RVA: 0x7FD6F8 Offset: 0x7FD6F8 VA: 0x7FD6F8
	public Matrix23(float initValue)
	{
		_00 = 1.0f;
		_01 = initValue;
		_02 = initValue;
		_10 = initValue;
		_11 = 1.0f;
		_12 = initValue;
	}

	// RVA: 0x7FD718 Offset: 0x7FD718 VA: 0x7FD718
	// public Matrix23(float tx, float ty) { }

	// RVA: 0x7FD73C Offset: 0x7FD73C VA: 0x7FD73C
	public Matrix23(float m00, float m01, float m02, float m10, float m11, float m12)
	{
		_00 = m00;
		_01 = m01;
		_02 = m02;
		_10 = m10;
		_11 = m11;
		_12 = m12;
	}

	// // RVA: 0x17BDB90 Offset: 0x17BDB90 VA: 0x17BDB90
	// public static Matrix23 op_Multiply(Matrix23 lhs, Matrix23 rhs) { }

	// // RVA: 0x7FD760 Offset: 0x7FD760 VA: 0x7FD760
	// public Matrix23 MultiplyMatrix(Matrix23 mtx) { }

	// // RVA: 0x7FD7BC Offset: 0x7FD7BC VA: 0x7FD7BC
	// public void Copy(Matrix23 src) { }

	// // RVA: 0x7FD7E0 Offset: 0x7FD7E0 VA: 0x7FD7E0
	// public void Identity() { }

	// // RVA: 0x7FD818 Offset: 0x7FD818 VA: 0x7FD818
	// public void Translate(Vector3 posi) { }

	// // RVA: 0x7FD83C Offset: 0x7FD83C VA: 0x7FD83C
	// public void Translate(Vector2 posi) { }

	// // RVA: 0x7FD860 Offset: 0x7FD860 VA: 0x7FD860
	// public void Translate(float tx, float ty) { }

	// // RVA: 0x7FD884 Offset: 0x7FD884 VA: 0x7FD884
	// public void Rotate(float zrad) { }

	// // RVA: 0x7FD88C Offset: 0x7FD88C VA: 0x7FD88C
	// public void Scale(float sx, float sy) { }

	// // RVA: 0x7FD8AC Offset: 0x7FD8AC VA: 0x7FD8AC
	// public void TransRotScale(float transX, float transY, float zrad, Vector2 scale) { }

	// // RVA: 0x7FD8D4 Offset: 0x7FD8D4 VA: 0x7FD8D4
	// public void TransRotScale(Vector2 trans, float zrad, Vector2 scale) { }

	// // RVA: 0x7FD8FC Offset: 0x7FD8FC VA: 0x7FD8FC
	// public void TransRot(Vector2 posi, float zrad) { }

	// // RVA: 0x7FD918 Offset: 0x7FD918 VA: 0x7FD918
	// public void TransScale(Vector2 scale, Vector2 trans) { }

	// // RVA: 0x7FD944 Offset: 0x7FD944 VA: 0x7FD944
	// public void TransScale(float sx, float sy, float tx, float ty) { }

	// // RVA: 0x17BE0B0 Offset: 0x17BE0B0 VA: 0x17BE0B0
	// public static Vector2 op_Multiply(Vector2 pos, Matrix23 mtx) { }

	// // RVA: 0x7FD968 Offset: 0x7FD968 VA: 0x7FD968
	// public Vector2 MultiplyVector(Vector2 pos) { }

	// // RVA: 0x7FD9B4 Offset: 0x7FD9B4 VA: 0x7FD9B4
	// public Vector3 MultiplyVector(Vector3 pos) { }

	// // RVA: 0x7FDA08 Offset: 0x7FDA08 VA: 0x7FDA08
	// public Matrix4x4 ToUnityMatrix() { }

	// // RVA: 0x7FDA64 Offset: 0x7FDA64 VA: 0x7FDA64
	// public void ToUnityMatrix(ref Matrix4x4 mat) { }

	// // RVA: 0x7FDAC8 Offset: 0x7FDAC8 VA: 0x7FDAC8 Slot: 3
	// public override string ToString() { }
}
