using UnityEngine;

namespace XeSys.Gfx
{
	public class ScrollBar : ImageView
	{
		private bool m_IsHorizon; // 0x99
		private string m_BarImageName; // 0x9C
		private TexUVList m_BarTex; // 0xA0
		private TexUVData m_BarUVData; // 0xA4
		private float m_ValueMin; // 0xA8
		private float m_ValueMax; // 0xAC
		private float m_ContentSize; // 0xB0
		private float m_Value; // 0xB4

		public bool IsHorizon { get { return m_IsHorizon; } set { m_IsHorizon = value; } } //0x1F11330 0x1F11338
		public string BarImageName { get { return m_BarImageName; } set { m_BarImageName = value; } } //0x1EFF188 0x1F11340
		public TexUVList BarTex { get { return m_BarTex; } set { m_BarTex = value; } } //0x1EFF180 0x1F11348
		public TexUVData BarUVData { get { return m_BarUVData; } set { m_BarUVData = value; } } //0x1EFE9F8 0x1F11350
		public float ValueMin { get { return m_ValueMin; } set { m_ValueMin = value; } } //0x1F11358 0x1F11360
		public float ValueMax { get { return m_ValueMax; } set { m_ValueMax = value; } } //0x1F11368 0x1F11370
		public float ContentSize { get { return m_ContentSize; } set { m_ContentSize = value; } } //0x1F11378 0x1F11380
		public float Value { get { return m_Value; } set { m_Value = value; } } //0x1F08880 0x1F08878

		//// RVA: 0x1F11388 Offset: 0x1F11388 VA: 0x1F11388
		//public void SetBarTexture(TexUVList tex, TexUVData uvdata) { }

		//// RVA: 0x1F11394 Offset: 0x1F11394 VA: 0x1F11394 Slot: 8
		//public override void Clear() { }

		// RVA: 0x1F113D8 Offset: 0x1F113D8 VA: 0x1F113D8 Slot: 7
		public override void Update(Matrix23 parentMat, Color parentCol)
		{
			if(enabled)
			{
				base.Update(parentMat, parentCol);
				m_IsDraw = true;
			}
		}

		// RVA: 0x1F11474 Offset: 0x1F11474 VA: 0x1F11474 Slot: 10
		public override void CopyTo(ViewBase view)
		{
			base.CopyTo(view);
			ScrollBar sview = view as ScrollBar;
			sview.m_IsHorizon = m_IsHorizon;
			sview.m_BarImageName = m_BarImageName;
			sview.m_BarTex = m_BarTex;
			sview.m_BarUVData = m_BarUVData;
			sview.m_ValueMin = m_ValueMin;
			sview.m_ValueMax = m_ValueMax;
			sview.m_ContentSize = m_ContentSize;
			sview.m_Value = m_Value;
			sview.IsDraw = m_IsDraw;
			sview.IsMask = m_IsMask;
		}

		// RVA: 0x1F116D8 Offset: 0x1F116D8 VA: 0x1F116D8 Slot: 11
		public override ViewBase DeepClone()
		{
			ScrollBar res = new ScrollBar();
			CopyTo(res);
			return res;
		}

		// RVA: 0x1F11768 Offset: 0x1F11768 VA: 0x1F11768 Slot: 15
		//public override void Serialize(List<SerializableView> list, int parent) { }
	}
}
