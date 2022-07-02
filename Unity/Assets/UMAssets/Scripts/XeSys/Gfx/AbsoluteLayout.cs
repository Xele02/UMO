using System.Collections.Generic;
using UnityEngine;

namespace XeSys.Gfx
{
	public class AbsoluteLayout : ViewBase
	{
		protected List<ViewBase> m_List = new List<ViewBase>(10); // 0x70
		private List<AbsoluteLayout> m_AbsoluteList = new List<AbsoluteLayout>(10); // 0x74
		private Dictionary<string, ViewBase> m_ChildViewMap = new Dictionary<string, ViewBase>(10); // 0x78
		private Dictionary<string, ViewBase> m_ChildViewMapForExid = new Dictionary<string, ViewBase>(10); // 0x7C
		protected List<ViewBase> m_xml_children = new List<ViewBase>(10); // 0x80
		private static List<ViewBase> s_FindViewList = new List<ViewBase>(); // 0x0

		public ViewBase this[int index] { get { 
			if(m_List != null)
			{
				return m_List[index];
			} 
			return null;
		} } //0x203E0C0
		public int viewCount { get { 
			if(m_List != null)
				return m_List.Count;
			return 0;
		 } private set { return; } } //0x203E13C 0x203E1B0

		// // RVA: 0x203E1B4 Offset: 0x203E1B4 VA: 0x203E1B4 Slot: 8
		// public override void Clear() { }

		// // RVA: 0x203E314 Offset: 0x203E314 VA: 0x203E314 Slot: 16
		public virtual void AddView(ViewBase child)
		{
			child.Parent = this;
			m_List.Add(child);
			m_ChildViewMap.Add(child.ID, child);
			m_ChildViewMapForExid.Add(child.EXID, child);
			if(child is AbsoluteLayout)
			{
				m_AbsoluteList.Add(child as AbsoluteLayout);
			}
		}

		// // RVA: 0x203E55C Offset: 0x203E55C VA: 0x203E55C Slot: 17
		// public virtual void AddViewCenter(ViewBase child) { }

		// // RVA: 0x203E980 Offset: 0x203E980 VA: 0x203E980 Slot: 18
		// public virtual void InsertView(int index, ViewBase child) { }

		// // RVA: 0x203EBD0 Offset: 0x203EBD0 VA: 0x203EBD0
		// public void RemoveView(ViewBase child) { }

		// // RVA: 0x203EDE0 Offset: 0x203EDE0 VA: 0x203EDE0
		// public ViewBase GetView(int index) { }

		// // RVA: 0x203EE78 Offset: 0x203EE78 VA: 0x203EE78 Slot: 19
		public virtual void SettingTexture(TexUVListManager texManager)
		{
			for(int i = 0; i < viewCount; i++)
			{
				ViewBase v = m_List[i];
				if(v != null)
				{
					if(v is ImageView)
					{
						ImageView iv = v as ImageView;
							TexUVList uvList;
						TexUVData data = texManager.GetTextureData(iv.ImageName, out uvList);
						if(v is ImageButton)
						{
							ImageButton ib = v as ImageButton;
							if(data != null && uvList != null)
								ib.SetTexture(uvList, data);
							data = texManager.GetTextureData(iv.ImageName + ImageButton.PushTexStr, out uvList);
							if(data != null && uvList != null)
							{
								ib.SetPushTexture(uvList, data);
							}
							ib.SetState(ImageButton.State.untouch);
						}
						else
						{
							if(data != null && uvList != null)
								iv.SetTexture(uvList, data);
						}
					}
					else if(v is AbsoluteLayout)
					{
						if(v is MaskView)
						{
							MaskView mv  = v as MaskView;
							TexUVList uvList;
							TexUVData data = texManager.GetTextureData(mv.ImageName, out uvList);
							if(data != null && uvList != null)
								mv.SetTexture(uvList, data);
						}
						AbsoluteLayout al = v as AbsoluteLayout;
						al.SettingTexture(texManager);
					}
				}
			}
		}

		// // RVA: 0x203F614 Offset: 0x203F614 VA: 0x203F614
		// public void SettingSwf(SwfManager swfMan) { }

		// // RVA: 0x203F744 Offset: 0x203F744 VA: 0x203F744
		public void SettingAnimation(LayoutAnimation anim)
		{
			ViewFrameAnimation vfa = null;
			if(anim != null)
			{
				if(AnimID.Length > 0 && anim.AnimLayers.ContainsKey(AnimID))
					vfa = anim.AnimLayers[AnimID];
				else if(anim.AnimLayers.ContainsKey(ID))
					vfa = anim.AnimLayers[ID];
			}
			SetFrameAnimation(vfa);
			for(int i = 0; i < viewCount; i++)
			{
				if(m_List[i] != null)
				{
					if(m_List[i] is AbsoluteLayout)
					{
						(m_List[i] as AbsoluteLayout).SettingAnimation(anim);
					}
					else
					{
						vfa = null;
						if(anim != null)
						{
							if(m_List[i].AnimID.Length > 0 && anim.AnimLayers.ContainsKey(m_List[i].AnimID))
								vfa = anim.AnimLayers[m_List[i].AnimID];
							else if(anim.AnimLayers.ContainsKey(m_List[i].ID))
								vfa = anim.AnimLayers[m_List[i].ID];
						}
						m_List[i].SetFrameAnimation(vfa);
					}
				}
			}
		}

		// // RVA: 0x203FB9C Offset: 0x203FB9C VA: 0x203FB9C Slot: 20
		public virtual void UpdateAll(Matrix23 parentMat, Color parentCol)
		{
			Update(parentMat, parentCol);
			if(IsVisible)
			{
				for(int i = 0; i < viewCount; i++)
				{
					if(BlendType != EBlendType.mul)
					{
						m_List[i].BlendType = BlendType;
					}
					if(!(m_List[i] is AbsoluteLayout))
					{
						m_List[i].Update(parentMat, m_CurrentColor);
						m_List[i].IsUpdateSRT = false;
					}
					else
					{
						(m_List[i] as AbsoluteLayout).UpdateAll(parentMat, m_CurrentColor);
					}
				}
				IsUpdateSRT = false;
			}
		}

		// // RVA: 0x203FE40 Offset: 0x203FE40 VA: 0x203FE40
		// public void InitAllAnimation() { }

		// // RVA: 0x2040068 Offset: 0x2040068 VA: 0x2040068
		public void UpdateAllAnimation(float dt, bool forceChildren = false)
		{
			if(enabled && (UpdateAnim(dt) || forceChildren))
			{
				for(int i = 0; i < viewCount; i++)
				{
					if(!(m_List[i] is AbsoluteLayout))
					{
						m_List[i].UpdateAnim(dt);
					}
					else
					{
						(m_List[i] as AbsoluteLayout).UpdateAllAnimation(dt, forceChildren);
					}
				}
			}
		}

		// // RVA: 0x20401D8 Offset: 0x20401D8 VA: 0x20401D8
		// public void StartAllAnimation(float time) { }

		// // RVA: 0x20402FC Offset: 0x20402FC VA: 0x20402FC
		// private void StartAllAnim(List<ViewBase> listView) { }

		// // RVA: 0x2040428 Offset: 0x2040428 VA: 0x2040428
		// public void StartAllAnim() { }

		// // RVA: 0x2040430 Offset: 0x2040430 VA: 0x2040430
		// private void StartAllAnimGoStop(List<ViewBase> listView, int start, int end) { }

		// // RVA: 0x204058C Offset: 0x204058C VA: 0x204058C
		// public void StartAllAnimGoStop(int start, int end) { }

		// // RVA: 0x20405B0 Offset: 0x20405B0 VA: 0x20405B0
		private void StartAllAnimGoStop(List<ViewBase> listView, string startLabel, string endLabel)
		{
			UnityEngine.Debug.Log(ID);
			StartAnimGoStop(startLabel, endLabel);
			for(int i = 0; i < listView.Count; i++)
			{
				if(listView[i] is AbsoluteLayout)
				{
					(listView[i] as AbsoluteLayout).StartAllAnimGoStop(startLabel, endLabel);
				}
				else
				{
					listView[i].StartAnimGoStop(startLabel, endLabel);
				}
			}
		}

		// // RVA: 0x204070C Offset: 0x204070C VA: 0x204070C
		public void StartAllAnimGoStop(string startLabel, string endLabel)
		{
			StartAllAnimGoStop(m_List, startLabel, endLabel);
		}

		// // RVA: 0x2040730 Offset: 0x2040730 VA: 0x2040730
		private void StartAllAnimGoStop(List<ViewBase> listView, string Label)
		{
			StartAnimGoStop(Label);
			for(int i = 0; i < listView.Count; i++)
			{
				if(listView[i] is AbsoluteLayout)
				{
					(listView[i] as AbsoluteLayout).StartAllAnimGoStop(Label);
				}
				else
				{
					listView[i].StartAnimGoStop(Label);
				}
			}
		}

		// // RVA: 0x2040874 Offset: 0x2040874 VA: 0x2040874
		public void StartAllAnimGoStop(string Label)
		{
			StartAllAnimGoStop(m_List, Label);
		}

		// // RVA: 0x2040880 Offset: 0x2040880 VA: 0x2040880
		/*private void StartAllAnimLoop(List<ViewBase> listView, int start, int end)
		{
			StartAnimLoop(start, end);
			for(int i = 0; i < listView.Count; i++)
			{
				if(listView[i] is AbsoluteLayout)
				{
					(listView[i] as AbsoluteLayout).StartAllAnimLoop(start, end);
				}
				else
				{
					listView[i].StartAnimLoop(start, end);
				}
			}
		}*/

		// // RVA: 0x20409DC Offset: 0x20409DC VA: 0x20409DC
		/*public void StartAllAnimLoop(int start, int end)
		{
			StartAllAnimLoop(m_List, start, end);
		}*/

		// // RVA: 0x2040A00 Offset: 0x2040A00 VA: 0x2040A00
		private void StartAllAnimLoop(List<ViewBase> listView, string startLabel, string endLabel)
		{
			StartAnimLoop(startLabel, endLabel);
			for(int i = 0; i < listView.Count; i++)
			{
				if(listView[i] is AbsoluteLayout)
				{
					(listView[i] as AbsoluteLayout).StartAllAnimLoop(startLabel, endLabel);
				}
				else
				{
					listView[i].StartAnimLoop(startLabel, endLabel);
				}
			}
		}

		// // RVA: 0x2040B5C Offset: 0x2040B5C VA: 0x2040B5C
		public void StartAllAnimLoop(string startLabel, string endLabel)
		{
			StartAllAnimLoop(m_List, startLabel, endLabel);
		}

		// // RVA: 0x2040B80 Offset: 0x2040B80 VA: 0x2040B80
		private void StartAllAnimLoop(List<ViewBase> listView, string Label)
		{
			StartAnimLoop(Label);
			for(int i = 0; i < listView.Count; i++)
			{
				if(!(listView[i] is AbsoluteLayout))
				{
					listView[i].StartAnimLoop(Label);
				}
				else
				{
					(listView[i] as AbsoluteLayout).StartAllAnimLoop(Label);
				}
			}
		}

		// // RVA: 0x2040CC4 Offset: 0x2040CC4 VA: 0x2040CC4
		public void StartAllAnimLoop(string Label)
		{
			StartAllAnimLoop(m_List, Label);
		}

		// // RVA: 0x2040CD0 Offset: 0x2040CD0 VA: 0x2040CD0
		// private void StartAllAnimInverseGoStop(List<ViewBase> listView, string Label) { }

		// // RVA: 0x2040E14 Offset: 0x2040E14 VA: 0x2040E14
		// public void StartAllAnimInverseGoStop(string Label) { }

		// // RVA: 0x2040E20 Offset: 0x2040E20 VA: 0x2040E20
		// private bool IsPlayingAll(List<ViewBase> listView) { }

		// // RVA: 0x2040F90 Offset: 0x2040F90 VA: 0x2040F90
		// public bool IsPlayingAll() { }

		// [ObsoleteAttribute] // RVA: 0x692554 Offset: 0x692554 VA: 0x692554
		// // RVA: 0x2040F98 Offset: 0x2040F98 VA: 0x2040F98
		// public bool CheckAnimation() { }

		// // RVA: 0x2040FA0 Offset: 0x2040FA0 VA: 0x2040FA0
		// public void StartSiblingAnimGoStop(int start, int end) { }

		// // RVA: 0x20410DC Offset: 0x20410DC VA: 0x20410DC
		// public void StartSiblingAnimGoStop(string startLabel, string endLabel) { }

		// // RVA: 0x2041218 Offset: 0x2041218 VA: 0x2041218
		// public void StartSiblingAnimGoStop(string startLabel) { }

		// // RVA: 0x204134C Offset: 0x204134C VA: 0x204134C
		// public void StartSiblingAnimLoop(int start, int end) { }

		// // RVA: 0x2041488 Offset: 0x2041488 VA: 0x2041488
		// public void StartSiblingAnimLoop(string startLabel, string endLabel) { }

		// // RVA: 0x20415C4 Offset: 0x20415C4 VA: 0x20415C4
		// public void StartSiblingAnimLoop(string startLabel) { }

		// // RVA: 0x20416F8 Offset: 0x20416F8 VA: 0x20416F8
		// public bool IsPlayingSibling() { }

		// [ObsoleteAttribute] // RVA: 0x692588 Offset: 0x692588 VA: 0x692588
		// // RVA: 0x204184C Offset: 0x204184C VA: 0x204184C
		// public bool CheckSiblingAnimation() { }

		// // RVA: 0x2041850 Offset: 0x2041850 VA: 0x2041850
		// public void StartChildrenAnimGoStop(int start, int end) { }

		// // RVA: 0x2041874 Offset: 0x2041874 VA: 0x2041874
		// private void StartChildrenAnimGoStop(List<ViewBase> listView, int start, int end) { }

		// // RVA: 0x2041960 Offset: 0x2041960 VA: 0x2041960
		public void StartChildrenAnimGoStop(string startLabel, string endLabel)
		{
			StartChildrenAnimGoStop(m_List, startLabel, endLabel);
		}

		// // RVA: 0x2041984 Offset: 0x2041984 VA: 0x2041984
		private void StartChildrenAnimGoStop(List<ViewBase> listView, string startLabel, string endLabel)
		{
			for(int i = 0; i < listView.Count; i++)
			{
				listView[i].StartAnimGoStop(startLabel, endLabel);
			}
		}

		// // RVA: 0x2041A70 Offset: 0x2041A70 VA: 0x2041A70
		public void StartChildrenAnimGoStop(string Label)
		{
			StartChildrenAnimGoStop(m_List, Label);
		}

		// // RVA: 0x2041A7C Offset: 0x2041A7C VA: 0x2041A7C
		private void StartChildrenAnimGoStop(List<ViewBase> listView, string Label)
		{
			for(int i = 0; i < listView.Count; i++)
			{
				listView[i].StartAnimGoStop(Label);
			}
		}

		// // RVA: 0x2041B58 Offset: 0x2041B58 VA: 0x2041B58
		// public void StartChildrenAnimLoop(int start, int end) { }

		// // RVA: 0x2041B7C Offset: 0x2041B7C VA: 0x2041B7C
		// private void StartChildrenAnimLoop(List<ViewBase> listView, int start, int end) { }

		// // RVA: 0x2041C68 Offset: 0x2041C68 VA: 0x2041C68
		// public void StartChildrenAnimLoop(int current, int start, int end) { }

		// // RVA: 0x2041C94 Offset: 0x2041C94 VA: 0x2041C94
		// private void StartChildrenAnimLoop(List<ViewBase> listView, int current, int start, int end) { }

		// // RVA: 0x2041D88 Offset: 0x2041D88 VA: 0x2041D88
		// public void StartChildrenAnimLoop(string startLabel, string endLabel) { }

		// // RVA: 0x2041DAC Offset: 0x2041DAC VA: 0x2041DAC
		// private void StartChildrenAnimLoop(List<ViewBase> listView, string startLabel, string endLabel) { }

		// // RVA: 0x2041E98 Offset: 0x2041E98 VA: 0x2041E98
		// public void StartChildrenAnimLoop(string Label) { }

		// // RVA: 0x2041EA4 Offset: 0x2041EA4 VA: 0x2041EA4
		// private void StartChildrenAnimLoop(List<ViewBase> listView, string Label) { }

		// // RVA: 0x2041F80 Offset: 0x2041F80 VA: 0x2041F80
		// public void FinishAnimLoop() { }

		// // RVA: 0x2041F88 Offset: 0x2041F88 VA: 0x2041F88
		// private void FinishAnimLoop(List<ViewBase> listView) { }

		// // RVA: 0x204205C Offset: 0x204205C VA: 0x204205C
		private bool IsPlayingChildren(List<ViewBase> listView)
		{
			for(int i = 0; i < listView.Count; i++)
			{
				if(listView[i].enabled)
				{
					if(listView[i].IsPlaying())
						return true;
				}
			}
			return false;
		}

		// // RVA: 0x2042160 Offset: 0x2042160 VA: 0x2042160
		public bool IsPlayingChildren()
		{
			return IsPlayingChildren(m_List);
		}

		// // RVA: 0x2042168 Offset: 0x2042168 VA: 0x2042168
		public ViewBase FindViewById(string id)
		{
			if(ID == id)
				return this;
			ViewBase res = null;
			m_ChildViewMap.TryGetValue(id, out res);
			if(res == null)
			{
				for(int i = 0; i < m_AbsoluteList.Count && res == null; i++)
				{
					res = m_AbsoluteList[i].FindViewById(id);
				}
			}
			return res;
		}

		// // RVA: 0x20422EC Offset: 0x20422EC VA: 0x20422EC
		public ViewBase FindViewByExId(string exid)
		{
			if(exid == EXID)
				return this;
			ViewBase res = null;
			m_ChildViewMapForExid.TryGetValue(exid, out res);
			if(res == null)
			{
				for(int i = 0; i < m_AbsoluteList.Count && res == null; i++)
				{
					res = m_AbsoluteList[i].FindViewByExId(exid);
				}
			}
			return res;
		}

		// // RVA: 0x2042470 Offset: 0x2042470 VA: 0x2042470
		// public void SetAllAnimationFromLayout(Layout layout) { }

		// // RVA: 0x2042594 Offset: 0x2042594 VA: 0x2042594 Slot: 21
		// public virtual void SetDrawLayer(int layer) { }

		// // RVA: 0x20426C0 Offset: 0x20426C0 VA: 0x20426C0
		// public void SetViewMask() { }

		// // RVA: 0x20426C8 Offset: 0x20426C8 VA: 0x20426C8
		// public void SetViewMask(ViewBase maskView) { }

		// // RVA: 0x204277C Offset: 0x204277C VA: 0x204277C
		// public void SetViewMask(ViewBase maskView, ViewBase view) { }

		// // RVA: 0x2042CD0 Offset: 0x2042CD0 VA: 0x2042CD0
		// public void SetViewMaskEx() { }

		// // RVA: 0x2042CD8 Offset: 0x2042CD8 VA: 0x2042CD8
		// public void SetViewMaskEx(ViewBase maskView) { }

		// // RVA: 0x2042D9C Offset: 0x2042D9C VA: 0x2042D9C Slot: 22
		// public virtual void SetViewMaskEx(ViewBase maskView, ViewBase view) { }

		// // RVA: 0x2043134 Offset: 0x2043134 VA: 0x2043134
		// public void SetAllInterpolationType(ViewAnimation.InterpolationType type) { }

		// // RVA: 0x2043258 Offset: 0x2043258 VA: 0x2043258
		// public void TextFadeIn() { }

		// // RVA: 0x2043380 Offset: 0x2043380 VA: 0x2043380
		// public void TextFadeIn(float time, Color col) { }

		// // RVA: 0x20434E8 Offset: 0x20434E8 VA: 0x20434E8
		// public void TextFadeOut() { }

		// // RVA: 0x2043610 Offset: 0x2043610 VA: 0x2043610
		// public void TextFadeOut(float time, Color col) { }

		// // RVA: 0x2043778 Offset: 0x2043778 VA: 0x2043778 Slot: 10
		public override void CopyTo(ViewBase view)
		{
			base.CopyTo(view);
			AbsoluteLayout al = view as AbsoluteLayout;
			al.m_List.Clear();
			for(int i = 0; i < viewCount; i++)
			{
				al.AddView(this[i].DeepClone());
			}
		}

		// // RVA: 0x204393C Offset: 0x204393C VA: 0x204393C Slot: 11
		public override ViewBase DeepClone()
		{
			AbsoluteLayout v = new AbsoluteLayout();
			CopyTo(v);
			return v;
		}

		// // RVA: 0x2043B24 Offset: 0x2043B24 VA: 0x2043B24
		// public void StartAllAnimDefault() { }

		// // RVA: 0x2043BC0 Offset: 0x2043BC0 VA: 0x2043BC0
		// public void StartAllAnimDecoLoop() { }

		// // RVA: 0x2043C5C Offset: 0x2043C5C VA: 0x2043C5C
		// public void StartAllAnimIn() { }

		// // RVA: 0x2043D04 Offset: 0x2043D04 VA: 0x2043D04
		// public void StartAllAnimOut() { }

		// // RVA: 0x2043DAC Offset: 0x2043DAC VA: 0x2043DAC
		// private void StopAllAnim(List<ViewBase> listView) { }

		// // RVA: 0x2043ED8 Offset: 0x2043ED8 VA: 0x2043ED8
		// public void StopAllAnim() { }

		// // RVA: 0x2043EE0 Offset: 0x2043EE0 VA: 0x2043EE0
		// private void EnableTouchCheck(List<ViewBase> listView, bool flag) { }

		// // RVA: 0x2044024 Offset: 0x2044024 VA: 0x2044024
		// public void EnableTouchCheck(bool flag) { }

		// // RVA: 0x2044030 Offset: 0x2044030 VA: 0x2044030
		public void AddXmlChildView(ViewBase child)
		{
			m_xml_children.Add(child);
		}

		// // RVA: 0x20440B0 Offset: 0x20440B0 VA: 0x20440B0
		// public bool IsPlayingAllInXml() { }

		// [ObsoleteAttribute] // RVA: 0x6925CC Offset: 0x6925CC VA: 0x6925CC
		// // RVA: 0x20440B8 Offset: 0x20440B8 VA: 0x20440B8
		// public bool CheckAnimationInXml() { }

		// // RVA: 0x20440C0 Offset: 0x20440C0 VA: 0x20440C0
		// public void StartAllAnimInXml() { }

		// // RVA: 0x20440C8 Offset: 0x20440C8 VA: 0x20440C8
		// public void StartAllAnimGoStopInXml(int start, int end) { }

		// // RVA: 0x20440EC Offset: 0x20440EC VA: 0x20440EC
		// public void StartAllAnimGoStopInXml(string startLabel, string endLabel) { }

		// // RVA: 0x2044110 Offset: 0x2044110 VA: 0x2044110
		// public void StartAllAnimGoStopInXml(string Label) { }

		// // RVA: 0x204411C Offset: 0x204411C VA: 0x204411C
		// public void StartAllAnimLoopInXml(int start, int end) { }

		// // RVA: 0x2044140 Offset: 0x2044140 VA: 0x2044140
		// public void StartAllAnimLoopInXml(string startLabel, string endLabel) { }

		// // RVA: 0x2044164 Offset: 0x2044164 VA: 0x2044164
		// public void StartAllAnimLoopInXml(string Label) { }

		// // RVA: 0x2044170 Offset: 0x2044170 VA: 0x2044170
		// public void StopAllAnimInXml() { }

		// // RVA: 0x2044178 Offset: 0x2044178 VA: 0x2044178
		// public void EnableTouchCheckInXml(bool flag) { }

		// // RVA: 0x2044184 Offset: 0x2044184 VA: 0x2044184
		// public void StartAllAnimInverseGoStopInXml(string Label) { }

		// // RVA: 0x2044190 Offset: 0x2044190 VA: 0x2044190 Slot: 12
		// public override void StartGameObject() { }

		// // RVA: 0x204425C Offset: 0x204425C VA: 0x204425C Slot: 13
		// public override void RemoveGameObject() { }

		// // RVA: 0x2044328 Offset: 0x2044328 VA: 0x2044328 Slot: 14
		// public override void SetActiveGameObject(bool flag) { }

		// // RVA: 0x20443FC Offset: 0x20443FC VA: 0x20443FC
		// public void SearchView(AbsoluteLayout.CallbackFindView callback) { }

		// // RVA: 0x20444C4 Offset: 0x20444C4 VA: 0x20444C4
		// private void SearchViewInner(AbsoluteLayout.CallbackFindView callback) { }

		// // RVA: 0x2045074 Offset: 0x2045074 VA: 0x2045074 Slot: 15
		// public override void Serialize(List<SerializableView> list, int parent) { }
	}
}
