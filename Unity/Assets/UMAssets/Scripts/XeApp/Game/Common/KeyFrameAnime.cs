using UnityEngine;
using System;
using System.Collections;

namespace XeApp.Game.Common
{
	public abstract class KeyFrameAnime : MonoBehaviour
	{
		[Serializable]
		public class KeyFrame
		{
			//[TooltipAttribute] // RVA: 0x688A14 Offset: 0x688A14 VA: 0x688A14
			public Sprite sprite; // 0x8
			//[TooltipAttribute] // RVA: 0x688A6C Offset: 0x688A6C VA: 0x688A6C
			public float time = 100; // 0xC
			//[TooltipAttribute] // RVA: 0x688AB4 Offset: 0x688AB4 VA: 0x688AB4
			public Vector2 pos = Vector2.zero; // 0x10
			[RangeAttribute(0, 359)] // RVA: 0x688AF0 Offset: 0x688AF0 VA: 0x688AF0
			//[TooltipAttribute] // RVA: 0x688AF0 Offset: 0x688AF0 VA: 0x688AF0
			public float angle; // 0x18
			//[TooltipAttribute] // RVA: 0x688B4C Offset: 0x688B4C VA: 0x688B4C
			public Vector2 scale = Vector2.one; // 0x1C
			//[TooltipAttribute] // RVA: 0x688B88 Offset: 0x688B88 VA: 0x688B88
			public Color color = Color.white; // 0x24
			//[TooltipAttribute] // RVA: 0x688BC4 Offset: 0x688BC4 VA: 0x688BC4
			public bool lerp = true; // 0x34
		}

		public enum PlayType
		{
			Loop = 0,
			Once = 1,
		}
		
		// Fields
		//[HeaderAttribute] // RVA: 0x68874C Offset: 0x68874C VA: 0x68874C
		[SerializeField]
		protected KeyFrameAnime.PlayType m_playType; // 0xC
		//[HeaderAttribute] // RVA: 0x6887A4 Offset: 0x6887A4 VA: 0x6887A4
		[SerializeField]
		protected bool m_autoAnime = true; // 0x10
		//[HeaderAttribute] // RVA: 0x68880C Offset: 0x68880C VA: 0x68880C
		[SerializeField]
		protected bool m_smoothSeams; // 0x11
		//[HeaderAttribute] // RVA: 0x688880 Offset: 0x688880 VA: 0x688880
		[SerializeField]
		protected Component m_image; // 0x14
		//[HeaderAttribute] // RVA: 0x6888E4 Offset: 0x6888E4 VA: 0x6888E4
		[SerializeField]
		protected KeyFrameAnime m_syncAnime; // 0x18
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x688964 Offset: 0x688964 VA: 0x688964
		protected int m_playIndex; // 0x1C
		//[HeaderAttribute] // RVA: 0x6889CC Offset: 0x6889CC VA: 0x6889CC
		[SerializeField]
		protected KeyFrame[] m_animeTable = new KeyFrame[2]; // 0x20
		protected float m_animStartTime; // 0x24
		protected Coroutine m_animCoroutine; // 0x28
		protected Action<KeyFrameAnime, int> m_animCallback; // 0x2C

		//public KeyFrameAnime SyncAnime { set; } 0x1103474
		//public int PlayIndex { get; } 0x110347C

		// RVA: 0x1102CD4 Offset: 0x1102CD4 VA: 0x1102CD4
		protected void Start()
		{
			Init();
		}

		// RVA: 0x1102CE4 Offset: 0x1102CE4 VA: 0x1102CE4
		private void OnEnable()
		{
			if (!m_autoAnime)
				return;
			Play(m_playType, m_playIndex, null);
		}

		// RVA: 0x1102D38 Offset: 0x1102D38 VA: 0x1102D38
		private void OnDisable()
		{
			m_animCoroutine = null;
		}

		//// RVA: 0x1102D44 Offset: 0x1102D44 VA: 0x1102D44
		public bool IsPlaying()
		{
			return m_animCoroutine != null;
		}

		//// RVA: 0x1102D14 Offset: 0x1102D14 VA: 0x1102D14
		public void Play(int index = 0, Action<KeyFrameAnime, int> callback = null)
		{
			Play(m_playType, index, callback);
		}

		//// RVA: 0x1102D54 Offset: 0x1102D54 VA: 0x1102D54
		public void Play(PlayType type, int index = 0, Action<KeyFrameAnime, int> callback = null)
		{
			if(index > -1)
			{
				if(index < m_animeTable.Length)
				{
					m_animCallback = callback;
					m_playType = type;
					if(m_animCoroutine == null)
					{
						if(m_syncAnime != null)
						{
							m_animStartTime = m_syncAnime.m_animStartTime;
							float t = 0;
							for(int i = 0; i < m_animeTable.Length; i++)
							{
								t += m_animeTable[i].time / 1000.0f;
							}
							m_animStartTime = m_animStartTime + t * Mathf.Round((Time.time - m_animStartTime) / t);
							while(m_animeTable[index].time / 1000.0f <= Time.time - m_animStartTime)
							{
								m_animStartTime += m_animeTable[index].time;
								index++;
								if (index >= m_animeTable.Length)
									index = 0;
							}
						}
						else
						{
							m_animStartTime = Time.time;
						}
						m_animCoroutine = StartCoroutine(Co_Animation(index));
					}
					return;
				}
			}
			Debug.Log("StringLiteral_14032");
		}

		//[IteratorStateMachineAttribute] // RVA: 0x73D0A4 Offset: 0x73D0A4 VA: 0x73D0A4
		//// RVA: 0x11030B4 Offset: 0x11030B4 VA: 0x11030B4
		private IEnumerator Co_Animation(int index)
		{
			float start; // 0x18
			KeyFrameAnime.KeyFrame prev; // 0x1C
			KeyFrameAnime.KeyFrame next; // 0x20
			float time; // 0x24
			float wait; // 0x28
			float speed; // 0x2C

			//0x1103504
			m_playIndex = index;
			start = m_animStartTime;
			while(true)
			{
				prev = m_animeTable[m_playIndex];
				int nextIndex = m_playIndex + 1;
				if(nextIndex >= m_animeTable.Length)
					nextIndex = 0;
				next = m_animeTable[nextIndex];
				if(prev.sprite != null)
				{
					SetSprite(prev.sprite);
				}
				if(m_animCallback != null)
					m_animCallback(this, m_playIndex);
				if(prev.time <= 0)
				{
					yield return null;
					continue;
				}
				wait = prev.time / 1000.0f;
				speed = 1.0f / wait;
				while(prev.time <= wait)
				{
					time = Mathf.Clamp(Time.time - start, 0, wait);
					if(prev.lerp)
					{
						float t = time * speed;
						SetPosition((next.pos - prev.pos) * t + prev.pos);
						SetPosition((next.scale - prev.scale) * t + prev.scale);
						SetEulerAngles(new Vector3(GetEulerAngles().x, GetEulerAngles().y, prev.angle + t * (next.angle - prev.angle)));
						SetColor((next.color - prev.color) * t + prev.color);
					}
					yield return null;
				}
				SetPosition(next.pos);
				SetScale(next.scale);
				SetEulerAngles(new Vector3(GetEulerAngles().x, GetEulerAngles().y, next.angle));
				SetColor(next.color);
				if(m_smoothSeams)
				{
					start = Time.time - ((Time.time - start) - wait);
				}
				else
				{
					start = Time.time;
				}
				m_playIndex++;
				if(m_animeTable.Length <= m_playIndex)
				{
					m_playIndex = 0;
					if(m_playType == PlayType.Once)
					{
						m_animCoroutine = null;
						yield break;
					}
				}
				if(m_animCoroutine == null)
					yield break;
				prev = null;
				next = null;
			}
		}

		//// RVA: 0x110317C Offset: 0x110317C VA: 0x110317C
		public void Stop(bool immediate = false)
		{
			if(immediate && m_animCoroutine != null)
			{
				StopCoroutine(m_animCoroutine);
			}
			m_animCoroutine = null;
		}

		//// RVA: 0x11031B4 Offset: 0x11031B4 VA: 0x11031B4
		//public void SetKeyFrame(int index) { }

		//// RVA: -1 Offset: -1 Slot: 4
		protected abstract void Init();

		//// RVA: -1 Offset: -1 Slot: 5
		protected abstract void SetSprite(Sprite sprite);

		//// RVA: -1 Offset: -1 Slot: 6
		//protected abstract Vector3 GetPosition();

		//// RVA: -1 Offset: -1 Slot: 7
		protected abstract void SetPosition(Vector3 pos);

		//// RVA: -1 Offset: -1 Slot: 8
		//protected abstract Vector3 GetScale();

		//// RVA: -1 Offset: -1 Slot: 9
		protected abstract void SetScale(Vector3 scale);

		//// RVA: -1 Offset: -1 Slot: 10
		protected abstract Vector3 GetEulerAngles();

		//// RVA: -1 Offset: -1 Slot: 11
		protected abstract void SetEulerAngles(Vector3 eangle);

		//// RVA: -1 Offset: -1 Slot: 12
		//protected abstract Color GetColor();

		//// RVA: -1 Offset: -1 Slot: 13
		protected abstract void SetColor(Color color);
	}
}
