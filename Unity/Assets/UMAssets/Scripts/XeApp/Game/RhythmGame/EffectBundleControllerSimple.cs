using UnityEngine;
using System;
using System.Collections.Generic;

namespace XeApp.Game.RhythmGame
{
	public class EffectBundleControllerSimple : MonoBehaviour
	{
		[Serializable]
		public class Param
		{
			public string groupName; // 0x8
			public GameObject[] gameObject; // 0xC
		}
		
		private class Item
		{
			public int m_index; // 0x8
			public Param m_param; // 0xC
			public Vector3 m_scale = new Vector3(1, 1, 1); // 0x10
			public Vector3 m_pos = new Vector3(0, 0, -3.2039f); // 0x1C
			public GameObject m_obj_fnt; // 0x28
			public GameObject m_obj_eff; // 0x2C
			public AnimationCurve m_curve_eff; // 0x30
			public float m_curve_eff_end; // 0x34
			public AnimationCurve m_curve_fnt; // 0x38
			public AnimationCurve m_curve_fnt_pos; // 0x3C
			public float m_curve_fnt_end; // 0x40
			public float m_rotate_speed; // 0x44

			//// RVA: 0xF73710 Offset: 0xF73710 VA: 0xF73710
			public void SetActive(bool a_enable)
			{
				if(m_obj_fnt != null)
				{
					m_obj_fnt.SetActive(a_enable);
				}
				if(m_obj_eff != null)
				{
					m_obj_eff.SetActive(a_enable);
				}
			}

			//// RVA: 0xF73AEC Offset: 0xF73AEC VA: 0xF73AEC
			public void AddRotate(float a_add_rotate)
			{
				if(m_obj_eff != null)
				{
					m_obj_eff.transform.Rotate(0, 0, a_add_rotate);
				}
			}
		}

		private class ViewItemCtrl
		{
			private Item m_item; // 0x8
			private float m_sec; // 0xC

			//// RVA: 0xF729AC Offset: 0xF729AC VA: 0xF729AC
			public void Update()
			{
				bool isEnd = false;
				if(m_item != null)
				{
					isEnd = true;
					m_sec += Time.deltaTime;
					if(m_item.m_obj_fnt != null && m_item.m_obj_fnt.activeSelf)
					{
						float s = m_item.m_curve_fnt.Evaluate(m_sec);
						m_item.m_scale = new Vector3(s, s, 1);
						m_item.m_obj_fnt.transform.localScale = m_item.m_scale;
						m_item.m_pos.y = m_item.m_curve_fnt_pos.Evaluate(m_sec);
						m_item.m_obj_fnt.transform.localPosition = m_item.m_pos;
						isEnd = false;
						if (m_item.m_curve_fnt_end < m_sec)
						{
							m_item.m_obj_fnt.SetActive(false);
							isEnd = true;
						}
					}
					if(m_item.m_obj_eff != null && m_item.m_obj_eff.activeSelf)
					{
						if(m_sec < m_item.m_curve_eff.length)
						{
							float s = m_item.m_curve_eff.Evaluate(m_sec);
							m_item.m_scale = new Vector3(s, s, 1);
							m_item.m_obj_eff.transform.localScale = m_item.m_scale;
							m_item.m_obj_eff.transform.Rotate(0, 0, s * 0.3f);
							if (m_sec <= m_item.m_curve_eff_end)
								return;
							m_item.m_obj_eff.SetActive(false);
						}
					}
					if (isEnd)
						m_item = null;
				}
			}

			//// RVA: 0xF73004 Offset: 0xF73004 VA: 0xF73004
			public void Start(Item a_item)
			{
				if(m_item != null)
				{
					m_item.SetActive(false);
					m_sec = 0;
					m_item = null;
				}
				m_item = a_item;
				m_sec = 0;
				a_item.SetActive(true);
				if(m_item.m_obj_eff != null)
				{
					float s = m_item.m_curve_eff.Evaluate(m_sec);
					m_item.m_scale = new Vector3(s, s, 1);
					m_item.m_obj_eff.transform.localScale = m_item.m_scale;
					m_item.m_obj_eff.transform.Rotate(0, 0, UnityEngine.Random.Range(0.0f, 360.0f));
				}
				if(m_item.m_obj_fnt != null)
				{
					float s = m_item.m_curve_fnt.Evaluate(m_sec);
					m_item.m_scale = new Vector3(s, s, 1);
					m_item.m_obj_fnt.transform.localScale = m_item.m_scale;
					m_item.m_pos.y = m_item.m_curve_fnt_pos.Evaluate(m_sec);
					m_item.m_obj_fnt.transform.localPosition = m_item.m_pos;
				}
			}

			//// RVA: 0xF736E0 Offset: 0xF736E0 VA: 0xF736E0
			//public void Stop() { }

			//// RVA: 0xF73698 Offset: 0xF73698 VA: 0xF73698
			//public bool IsItem(EffectBundleControllerSimple.Item a_item) { }
		}

		[SerializeField]
		public Param[] m_params; // 0xC
		[SerializeField]
		public AnimationCurve m_curve_eff; // 0x10
		[SerializeField]
		public AnimationCurve m_curve_fnt; // 0x14
		[SerializeField]
		public AnimationCurve m_curve_fnt_pos; // 0x18
		private const float EFFECT_ROT_SPEED = 0.3f;
		private List<Item> m_items = new List<Item>(); // 0x1C
		private Dictionary<int, int> m_searchDict = new Dictionary<int, int>(); // 0x20
		private ViewItemCtrl m_view_ctrl = new ViewItemCtrl(); // 0x24
		private bool m_pause; // 0x28

		// RVA: 0xF72478 Offset: 0xF72478 VA: 0xF72478
		public void Awake()
		{
			for(int i = 0; i < m_params.Length; i++)
			{
				Item item = new Item();
				item.m_index = i;
				item.m_param = m_params[i];
				item.m_obj_fnt = m_params[i].gameObject[0];
				if(m_params[i].gameObject.Length > 1)
				{
					item.m_obj_eff = m_params[i].gameObject[1];
				}
				item.m_curve_eff = m_curve_eff;
				item.m_curve_eff_end = m_curve_eff.keys[m_curve_eff.length - 1].time;
				item.m_curve_fnt = m_curve_fnt;
				item.m_curve_fnt_pos = m_curve_fnt_pos;
				item.m_curve_fnt_end = m_curve_fnt.keys[m_curve_fnt.length - 1].time;
				m_items.Add(item);
				m_searchDict.Add(m_params[i].groupName.GetHashCode(), i);
			}
		}

		// RVA: 0xF72978 Offset: 0xF72978 VA: 0xF72978
		public void Update()
		{
			if (m_pause)
				return;
			m_view_ctrl.Update();
		}

		//// RVA: 0xF72FC0 Offset: 0xF72FC0 VA: 0xF72FC0
		//public void Play(string groupName) { }

		//// RVA: 0xF6351C Offset: 0xF6351C VA: 0xF6351C
		public void Play(int groupHash, float normalizeTime = 0)
		{
			int idx = 0;
			if (m_searchDict.TryGetValue(groupHash, out idx))
			{
				m_view_ctrl.Start(m_items[idx]);
			}
		}

		//// RVA: 0xF734B4 Offset: 0xF734B4 VA: 0xF734B4
		//public void Stop(string groupName) { }

		//// RVA: 0xF734F8 Offset: 0xF734F8 VA: 0xF734F8
		//public void Stop(int groupHash) { }

		//// RVA: 0xF73838 Offset: 0xF73838 VA: 0xF73838
		//public bool IsPlaying(string groupName) { }

		//// RVA: 0xF7387C Offset: 0xF7387C VA: 0xF7387C
		//public bool IsPlaying(int groupHash) { }

		//// RVA: 0xF739A0 Offset: 0xF739A0 VA: 0xF739A0
		//public bool IsSameState(string groupName) { }

		//// RVA: 0xF739D8 Offset: 0xF739D8 VA: 0xF739D8
		//public bool IsSameState(int groupHash) { }

		//// RVA: 0xF739E0 Offset: 0xF739E0 VA: 0xF739E0
		//public int GetAnimatorLoopCount(int groupHash) { }

		//// RVA: 0xF739E8 Offset: 0xF739E8 VA: 0xF739E8
		public void Pause()
		{
			m_pause = true;
		}

		//// RVA: 0xF739F4 Offset: 0xF739F4 VA: 0xF739F4
		//public void Resume() { }
	}
}
