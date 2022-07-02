namespace XeSys.Gfx
{
	public class ImageButton : ImageView
	{
		public enum State
		{
			touch = 0,
			untouch = 1,
		}

		public static string PushTexStr = "_push"; // 0x0
		private ImageButton.State m_State = State.untouch; // 0x9C
		private TexUVList m_PushTex; // 0xA0
		private TexUVData m_PushUVData; // 0xA4

		// public ImageButton.State sta { get; } 0x2048AAC
		// public TexUVList PushTex { get; set; } 0x2048AB4 0x2048ABC
		// public TexUVData PushUVData { get; set; } 0x2048AC4 0x2048ACC

		// RVA: 0x2048AD4 Offset: 0x2048AD4 VA: 0x2048AD4
		public ImageButton()
		{
			IsTouchCheck = true;
		}

		// // RVA: 0x203F52C Offset: 0x203F52C VA: 0x203F52C
		public void SetPushTexture(TexUVList tex, TexUVData uvdata)
		{
			m_PushTex = tex;
			m_PushUVData = uvdata;
		}

		// // RVA: 0x2048B94 Offset: 0x2048B94 VA: 0x2048B94 Slot: 8
		// public override void Clear() { }

		// // RVA: 0x203F538 Offset: 0x203F538 VA: 0x203F538
		public void SetState(ImageButton.State state)
		{
			if(m_State != state)
			{
				m_State = state;
				TexUVList tex = null;
				if(state == State.untouch)
				{
					tex = Tex;
				}
				else
				{
					if(state != State.touch)
						return;
					tex = m_PushTex;
				}
				if(tex != null && !m_IsInitTexture)
					m_IsInitTexture = true;
			}
		}

		// // RVA: 0x2048BC4 Offset: 0x2048BC4 VA: 0x2048BC4 Slot: 10
		public override void CopyTo(ViewBase view)
		{
			base.CopyTo(view);
			ImageButton v = view as ImageButton;
			v.m_PushTex = m_PushTex;
			v.m_PushUVData = m_PushUVData;
		}

		// // RVA: 0x2048EDC Offset: 0x2048EDC VA: 0x2048EDC Slot: 11
		public override ViewBase DeepClone()
		{
			ImageButton v = new ImageButton();
			CopyTo(v);
			return v;
		}

		// // RVA: 0x2048F7C Offset: 0x2048F7C VA: 0x2048F7C Slot: 15
		// public override void Serialize(List<SerializableView> list, int parent) { }
	}
}
