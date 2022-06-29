using UnityEngine;

namespace XeSys.Gfx
{
	public class MaskView : AbsoluteLayout
	{
		private string m_ImageName; // 0x84
		private TexUVList m_Tex; // 0x88
		private TexUVData m_UVData; // 0x8C
		private bool m_IsFlipX; // 0x90
		private bool m_IsFlipY; // 0x91
		protected bool m_IsInitTexture; // 0x92

		public string ImageName { get { return m_ImageName; } set { m_ImageName = value; } } //0x1EFF4A8 0x1F0A108
		// public TexUVList Tex { get; set; } 0x1EFF498 0x1F0A110
		// public TexUVData UVData { get; set; } 0x1EFF4A0 0x1F0A118
		public bool IsFlipX { get { return m_IsFlipX; } set { m_IsFlipX = value; } } //0x1F0A120 0x1F0A128
		public bool IsFlipY { get { return m_IsFlipY; } set { m_IsFlipY = value; } } //0x1F0A130 0x1F0A138

		// // RVA: 0x1F0A140 Offset: 0x1F0A140 VA: 0x1F0A140
		public void SetTexture(TexUVList tex, TexUVData uvdata)
		{
			if(tex != null && uvdata != null)
			{
				if(!m_IsInitTexture)
					m_IsInitTexture = true;
				m_Tex = tex;
				m_UVData = uvdata;
			}
		}

		// // RVA: 0x1F0A244 Offset: 0x1F0A244 VA: 0x1F0A244
		// public void SetTexture(TexUVList tex, string name) { }

		// // RVA: 0x1F0A28C Offset: 0x1F0A28C VA: 0x1F0A28C Slot: 8
		// public override void Clear() { }

		// // RVA: 0x1F0A2B0 Offset: 0x1F0A2B0 VA: 0x1F0A2B0 Slot: 20
		public override void UpdateAll(Matrix23 parentMat, Color parentCol)
		{
			Update(parentMat, parentCol);
			for(int i = 0; i < viewCount; i++)
			{
				if(m_List[i] is AbsoluteLayout)
				{
					(m_List[i] as AbsoluteLayout).UpdateAll(parentMat, parentCol);
				}
				else
				{
					m_List[i].Update(parentMat, parentCol);
					m_List[i].IsUpdateSRT = false;
				}
			}
			IsUpdateSRT = false;
		}

		// // RVA: 0x1F0A560 Offset: 0x1F0A560 VA: 0x1F0A560 Slot: 9
		public override bool UpdateAnim(float dt)
		{
			base.UpdateAnim(dt);
			return true;
		}

		// // RVA: 0x1F0A578 Offset: 0x1F0A578 VA: 0x1F0A578 Slot: 10
		// public override void CopyTo(ViewBase view) { }

		// // RVA: 0x1F0A698 Offset: 0x1F0A698 VA: 0x1F0A698 Slot: 11
		// public override ViewBase DeepClone() { }

		// // RVA: 0x1F0A7A0 Offset: 0x1F0A7A0 VA: 0x1F0A7A0 Slot: 15
		// public override void Serialize(List<SerializableView> list, int parent) { }
	}
}
