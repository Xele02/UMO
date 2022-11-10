using System.Collections.Generic;
using UnityEngine;
using System;
using XeApp.Game.RhythmGame.UI;
using XeSys;

namespace XeApp.Game.RhythmGame
{
	public class RNoteSlide : RNoteLong
	{
		private float lastGapTimeTmp; // 0x64
		private bool isPause; // 0x68
		private List<Vector2> uvListU = new List<Vector2>() { new Vector2(0.5f, 1.0f), new Vector2(0.5f, 1.0f), new Vector2(0.5f, 1.0f), 
			new Vector2(0.5f, 1.0f), new Vector2(0.5f, 1.0f), new Vector2(0.5f, 1.0f) }; // 0x6C
		private List<Vector2> uvListV = new List<Vector2>() { new Vector2(0.5f, 0.005859375f), new Vector2(0.5f, 0.005859375f), new Vector2(0.5f, 0.005859375f), 
			new Vector2(0.5f, 0.005859375f), new Vector2(0.5f, 0.005859375f), new Vector2(0.5f, 0.005859375f) }; // 0x70
		private TouchSlideTipEffect tipEffect; // 0x74
		private Action<float> makePoints; // 0x78
		public bool IsPauseKeep; // 0x7C

		// RVA: 0xDBF108 Offset: 0xDBF108 VA: 0xDBF108 Slot: 14
		public override void Initialize(RNoteObject[] objects)
		{
			base.Initialize(objects);
			uv_u_start = uvListU[GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.KDNKCOAJGCM_NotesType].x;
			uv_u_end = uvListU[GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.KDNKCOAJGCM_NotesType].y;
			uv_v_start = uvListV[GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.KDNKCOAJGCM_NotesType].x;
			uv_v_length = uvListV[GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.KDNKCOAJGCM_NotesType].y;
			lastGapTimeTmp = 0;
			isPause = false;
			makePoints = this.MakeStraightPoints;
		}

		// RVA: 0xDBF350 Offset: 0xDBF350 VA: 0xDBF350 Slot: 15
		protected override void UpdateVerticesPosition()
		{
			makePoints(width);
			if(tipEffect != null)
			{
				tipEffect.SetPosition(transform.TransformPoint(controlPoints[0].pos));
			}
		}

		// // RVA: 0xDBF508 Offset: 0xDBF508 VA: 0xDBF508
		private void MakeStraightPoints(float width_adjust)
		{
			if(isAdsorbedFirstObject)
			{
				if(lastRNoteObject.rNote.gapMilliSec == -0x7fffffff)
				{
					if(lastGapTimeTmp == 0)
					{
						lastGapTimeTmp = (float)(int)(firstRNoteObject.rNote.gapMilliSec - (lastRNoteObject.rNote.noteInfo.time - firstRNoteObject.rNote.noteInfo.time));
					}
					else if(!isPause)
					{
						lastGapTimeTmp = lastGapTimeTmp + TimeWrapper.deltaTime * 1000.0f;
					}
				}
				else
				{
					lastGapTimeTmp = (float)(int)(lastRNoteObject.rNote.gapMilliSec);
				}
				RNotePositionAnimator.AnimData data = RNotePositionAnimator.GetJustAnimationData(firstRNoteObject.rNote.noteInfo.trackID);
				RNotePositionAnimator.AnimData data2 = RNotePositionAnimator.GetJustAnimationData(lastRNoteObject.rNote.noteInfo.trackID);
				float t = lastGapTimeTmp / (lastRNoteObject.rNote.noteInfo.time - firstRNoteObject.rNote.noteInfo.time) + 1;
				Vector3 pos = Vector3.Lerp(data.localPosition, data2.localPosition, t);
				SetStraight(pos, Mathf.Lerp(data.localScale, data2.localScale, t), lastRNoteObject.transform.localPosition, lastRNoteObject.transform.localScale.x, width_adjust);
			}
			else
			{
				SetStraight(firstRNoteObject.transform.localPosition, firstRNoteObject.transform.localScale.x, lastRNoteObject.transform.localPosition, lastRNoteObject.transform.localScale.x, width_adjust);
			}
		}

		// // RVA: 0xDBFA3C Offset: 0xDBFA3C VA: 0xDBFA3C
		private void SetStraight(Vector3 startPos, float startScale, Vector3 endPos, float endScale, float width)
		{
			divid = divid_max;
			float f = 0;
			for(int i = 0; i < divid; i++)
			{
				controlPoints[i].pos = Vector3.Lerp(startPos, endPos, f);
				controlPoints[i].scale = Mathf.Lerp(startScale, endScale, f);
				f += 1.0f / (divid - 1);
			}
			for(int i = 0; i < divid; i++)
			{
				Quaternion q = Quaternion.identity;
				if(i < divid - 1)
				{
					q = Quaternion.FromToRotation(Vector3.up, controlPoints[i + 1].pos - controlPoints[i].pos);
				}
				rightSidePoints[i] = controlPoints[i].pos + q * (Vector3.right * width * controlPoints[i].scale);
				leftSidePoints[i] = controlPoints[i].pos + q * -(Vector3.right * width * controlPoints[i].scale);
				rightSidePoints[i].z += offset_z;
				leftSidePoints[i].z += offset_z;
			}
		}

		// // RVA: 0xDC0204 Offset: 0xDC0204 VA: 0xDC0204
		public void SetTipEffect(TouchSlideTipEffect eff)
		{
			tipEffect = eff;
		}

		// // RVA: 0xDC020C Offset: 0xDC020C VA: 0xDC020C
		public void ClearTipEffect()
		{
			tipEffect = null;
		}

		// // RVA: 0xDC0218 Offset: 0xDC0218 VA: 0xDC0218 Slot: 16
		// public override void Pause() { }

		// // RVA: 0xDC0234 Offset: 0xDC0234 VA: 0xDC0234 Slot: 17
		// public override void Resume() { }
	}
}
