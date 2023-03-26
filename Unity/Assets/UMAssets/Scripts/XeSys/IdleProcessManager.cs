using System.Diagnostics;
using UnityEngine;
using System;
using System.Collections;

namespace XeSys
{
	public class IdleProcessManager : SingletonMonoBehaviour<IdleProcessManager>
	{
		public enum ProcessResult
		{
			Continue = 0,
			Next = 1,
			End = 2,
		}

		public struct IdleProcess
		{
			public Func<IdleProcessManager.ProcessResult> Process; // 0x0
			public int Priority; // 0x4
			public int Next; // 0x8
			public int Prev; // 0xC
			public int State; // 0x10
			public uint Weight; // 0x14
			public uint Age; // 0x18
		}

		private const int IDLE = 0;
		private const int REGISTERED = 1;
		private const int ACTIVE = 2;
		private const int AGE_MAX = 16;
		public int initialProcessesCount = 256; // 0xC
		private IdleProcessManager.IdleProcess[] processes; // 0x10
		private int active; // 0x14
		private int idle; // 0x18
		private int registered; // 0x1C
		private Stopwatch sw = new Stopwatch(); // 0x20
		public int lazyCount; // 0x34
		private const int LAZY_LIMIT_COUNT = 2;
		private WaitForEndOfFrame recycle = new WaitForEndOfFrame(); // 0x40

		public float ProcessingRate { get; set; } // 0x24
		public bool IsFixedTime { get; set; } // 0x28
		public int ProcessingMilliSeconds { get; set; } // 0x2C
		public bool IsAutoExtention { get; set; } // 0x30
		public bool IsBurstEnable { get; set; } // 0x38
		public float BurstProcessingRate { get; set; } // 0x3C

		// // RVA: 0x1EF2A28 Offset: 0x1EF2A28 VA: 0x1EF2A28
		private void Awake()
		{
			IsFixedTime = false;
			IsAutoExtention = true;
			ProcessingRate = 0.1f;
			BurstProcessingRate = 1.0f;
			processes = new IdleProcessManager.IdleProcess[initialProcessesCount];
			active = -1;
			idle = 0;
			registered = -1;
			lazyCount = 0;
			IsBurstEnable = true;
			InitializeRange(processes, -1, -1, 0, processes.Length);
			this.StartCoroutineWatched(IdleCoroutine());
		}

		// // RVA: g Offset: 0x1EF2CD4 VA: 0x1EF2CD4
		private void Update()
		{
			sw.Reset();
			sw.Start();
		}

		// // RVA: 0x1EF2D24 Offset: 0x1EF2D24 VA: 0x1EF2D24
		public int Register(Func<IdleProcessManager.ProcessResult> process, int priority, float weight = 0)
		{
			int target = idle;
			if(idle == -1)
			{
				if(!IsAutoExtention)
					return -1;
				Extend(processes.Length * 2);
				target = idle;
			}
			Unlink(ref idle, target);
			//UnityEngine.Debug.Log("Register process "+target);
			processes[target].State = 1;
			processes[target].Process = process;
			processes[target].Priority = priority;
			if(weight == 0)
			{
				
			}
			else
			{
				UnityEngine.Debug.LogError("Check weight "+weight);
			}
			processes[target].Weight = (uint)(weight * 10000000);
			processes[target].Age = 0;
			Link(ref registered, -1, registered, target);
			return target;
		}

		// // RVA: 0x1EF34C8 Offset: 0x1EF34C8 VA: 0x1EF34C8
		public int Register(IEnumerator coroutine, int priority, float weight = 0)
		{
			return Register(() => {
				//0x1EF3F08
				if(coroutine.MoveNext())
				{
					if(coroutine.Current != null)
					{
						if(coroutine.Current is ProcessResult)
						{
							return (ProcessResult)coroutine.Current;
						}
					}
					return ProcessResult.Next;
				}
				return ProcessResult.End;
			}, priority, weight);
		}

		// // RVA: 0x1EF35BC Offset: 0x1EF35BC VA: 0x1EF35BC
		public void Unregister(int index)
		{
			if(index > -1)
			{
				if(index < processes.Length)
				{
					if(processes[index].State != 0)
					{
						if(processes[index].State == 1)
						{
							Unlink(ref registered, index);
						}
						else
						{
							Unlink(ref active, index);
						}
						Link(ref idle, -1, idle, index);
						processes[index].Process = null;
						processes[index].State = 0;
					}
				}
			}
		}

		// // RVA: 0x1EF2B1C Offset: 0x1EF2B1C VA: 0x1EF2B1C
		private static void InitializeRange(IdleProcessManager.IdleProcess[] processes, int prev, int next, int start, int end)
		{
			processes[start].Prev = prev;
			if((end - 1) > start)
			{
				do
				{
					processes[start].State = 0;
					processes[start].Next = start + 1;
					processes[start + 1].Prev = start;
					start++;
				} while( start != (end-1));
			}
			processes[end - 1].State = 0;
			processes[end - 1].Next = next;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x691DB4 Offset: 0x691DB4 VA: 0x691DB4
		// // RVA: 0x1EF2C48 Offset: 0x1EF2C48 VA: 0x1EF2C48
		private IEnumerator IdleCoroutine()
		{
			//0x1EF41D0
			while(true)
			{
				yield return recycle;
				Idle();
			}
		}

		// // RVA: 0x1EF3744 Offset: 0x1EF3744 VA: 0x1EF3744
		private void Idle()
		{
			if(registered > -1)
			{
				Activate();
			}
			if(active < 0)
			{
				return;
			}
			long ticks = 10000000 / Application.targetFrameRate;
			long allowedticks = 0;
			if(!IsBurstEnable)
			{
				if(!IsFixedTime)
				{
					allowedticks = ticks - sw.ElapsedTicks;
				}
				else
				{
					allowedticks = (long)(ticks * ProcessingRate);
				}
			}
			else
			{
				allowedticks = (long)(ticks * BurstProcessingRate);
			}
			sw.Stop();
			bool noExec = lazyCount > 1;
			if(allowedticks == 0 && lazyCount < 2)
			{
				lazyCount++;
				return;
			}
#if UNITY_EDITOR
			allowedticks = allowedticks * 5; // Editor is slower than build
#endif
			sw.Reset();
			sw.Start();
			int i = active;
			do
			{
				int next = processes[i].Next;
				processes[i].Age = processes[i].Age + 1;
				bool exec = false;
				if(!noExec && !IsBurstEnable)
				{
					if(processes[i].Weight == 0)
					{
						exec = true;
					}
					else if(processes[i].Age > 15)
					{
						exec = true;
					}
					else if(sw.ElapsedTicks - processes[i].Weight > 0)
					{
						exec = true;
					}
				}
				else
				{
					exec = true;
				}
				if(exec)
				{
					//UnityEngine.Debug.Log("IdleManager Exec Process : "+i);
					ProcessResult res = processes[i].Process();
					if(res != ProcessResult.Continue)
					{
						if(res == ProcessResult.End)
						{
							//UnityEngine.Debug.Log("IdleManager End Process : "+i);
							Unregister(i);
						}
					}
					else
					{
						next = i;
					}
					lazyCount = 0;
				}
				if(next < 0)
				{
					//UnityEngine.Debug.Log("Break, no more to execute");
					break;
				}
				noExec = false;
				i = next;
				//UnityEngine.Debug.Log(sw.ElapsedTicks+" < "+allowedticks);
			} while(sw.ElapsedTicks < allowedticks);
			sw.Stop();
		}

		// // RVA: 0x1EF2F68 Offset: 0x1EF2F68 VA: 0x1EF2F68
		private void Extend(int count)
		{
			if(processes.Length < count)
			{
				IdleProcessManager.IdleProcess[] newList = new IdleProcessManager.IdleProcess[count];
				for(int i = 0; i < processes.Length; i++)
				{
					newList[i] = processes[i];
				}
				if(idle > -1)
				{
					newList[idle].Prev = newList.Length - 1;
				}
				InitializeRange(newList, -1, idle, processes.Length, newList.Length);
				processes = newList;
				idle = newList.Length;
			}
		}

		// // RVA: 0x1EF3B84 Offset: 0x1EF3B84 VA: 0x1EF3B84
		private void Activate()
		{
			int target = registered;
			int prev = 0;
			if(target > -1)
			{
				do
				{
					registered = processes[registered].Next;
					processes[target].State = 2;
					int u3 = active;
					if(u3 < 0)
					{
						prev = -1;
						//UnityEngine.Debug.Log("Activate "+target+" after "+prev+" & before "+u3);
						Link(ref active, prev, u3, target);
					}
					else
					{
						if(processes[u3].Priority > processes[target].Priority)
						{
							prev = -1;
							//UnityEngine.Debug.Log("Activate 2 "+target+" after "+prev+" & before "+u3);
							Link(ref active, prev, u3, target);
						}
						else
						{
							while(true)
							{
								prev = u3;
								if(processes[prev].Next < 0)
									break;
								if(processes[target].Priority < processes[processes[prev].Next].Priority)
									break;
								u3 = processes[prev].Next;
							}
							u3 = processes[prev].Next;
							//UnityEngine.Debug.Log("Activate 3 "+target+" after "+prev+" & before "+u3);
							Link(ref active, prev, u3, target);
						}
					}
					target = registered;
				} while(target > -1);
			}
		}

		// // RVA: 0x1EF3180 Offset: 0x1EF3180 VA: 0x1EF3180
		private void Unlink(ref int top, int target)
		{
			if(target > -1)
			{
				if(processes[target].Next > -1)
				{
					processes[processes[target].Next].Prev = processes[target].Prev;
				}
				if(processes[target].Prev < 0)
				{
					top = processes[target].Next;
				}
				else
				{
					processes[processes[target].Prev].Next = processes[target].Next;
				}
			}
		}

		// // RVA: 0x1EF3398 Offset: 0x1EF3398 VA: 0x1EF3398
		private void Link(ref int top, int prev, int next, int target)
		{
			if(target > -1)
			{
				processes[target].Prev = prev;
				processes[target].Next = next;
				if(next > -1)
				{
					processes[next].Prev = target;
				}
				if(prev > -1)
				{
					processes[prev].Next = target;
				}
				else
				{
					top = target;
				}
			}
		}
	}
}
